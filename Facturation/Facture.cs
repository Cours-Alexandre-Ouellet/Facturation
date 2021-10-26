using System;
using System.Collections.Generic;

namespace Facturation
{
    /// <summary>
    /// Contient les informations de facturation d'une transaction
    /// </summary>
    public class Facture
    {
        /// <summary>
        /// Identifiant unique de la facture
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Liste des items de la facture
        /// </summary>
        public Dictionary<Item, int> ContenuFacture { get; private set; }

        /// <summary>
        /// Date de création de la facture
        /// </summary>
        public DateTime DateCreation { get; private set; }

        /// <summary>
        /// Indique si la transaction est close ou non
        /// </summary>
        private bool estClose;

        /// <summary>
        /// Retourne la valeur totale de la facture
        /// </summary>
        public float Total
        {
            get
            {
                float total = 0f;
                foreach(KeyValuePair<Item, int> ligneFacture in ContenuFacture)
                {
                    total += ligneFacture.Key.Prix * ligneFacture.Value;
                }
                total += Taxes.ValeurTaxeNationale + Taxes.ValeurTaxeLocale;

                return total;
            }
        }

        /// <summary>
        /// Taxes appliquées sur la facture
        /// </summary>
        public AbstractTaxes Taxes { get; set; }

        /// <summary>
        /// Crée une nouvelle facture à une date déterminée.
        /// </summary>
        /// <param name="dateCreation">La date à laquelle la facture est créée</param>
        public Facture(DateTime dateCreation)
        {
            Id = -1;
            ContenuFacture = new Dictionary<Item, int>();
            this.DateCreation = dateCreation;
            estClose = false;
        }

        /// <summary>
        /// Ajoute un item dans la facture. Si l'item est déjà présent, sa 
        /// quantité est incrémentée
        /// </summary>
        /// <param name="item">L'item à ajouter.</param>
        /// <param name="quantite">La quantité à ajouter.</param>
        public void AjouterItem(Item item, int quantite)
        {
            if (ContenuFacture.ContainsKey(item))
            {
                ContenuFacture[item] += quantite;
            }
            else
            {
                ContenuFacture.Add(item, quantite);
            }
        }

        /// <summary>
        /// Retourne tous les items qui sont taxables selon le code de taxe
        /// fournit en paramètres
        /// </summary>
        /// <param name="codeTaxe">Le code de taxe utilisé</param>
        /// <returns>Les items taxables selon la taxe utilisée</returns>
        public Dictionary<Item, int> GetItemsTaxables(string codeTaxe)
        {
            Dictionary<Item, int> itemsTaxables = new Dictionary<Item, int>();
            foreach (KeyValuePair<Item, int> ligneFacture in ContenuFacture)
            {
                if (!ligneFacture.Key.ExemptionTaxes.Contains(codeTaxe))
                {
                    itemsTaxables.Add(ligneFacture.Key, ligneFacture.Value);
                }
            }

            return itemsTaxables;
        }

        /// <summary>
        /// Clos la transaction pour empêcher les manipulations futures
        /// </summary>
        public void Clore()
        {
            estClose = true;
        }
    }
}
