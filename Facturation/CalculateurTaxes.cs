using System;
using System.Collections.Generic;
using System.Text;

namespace Facturation
{
    /// <summary>
    /// Calcule les taxes selon la région actuelle
    /// </summary>
    class CalculateurTaxes
    {
        /// <summary>
        /// Region dans laquelle on se situe
        /// </summary>
        private string region;

        /// <summary>
        /// Liste des taxations en vigueur
        /// </summary>
        private Dictionary<string, AbstractTaxes> taxations;

        /// <summary>
        /// Nouveau calculateur de taxes
        /// </summary>
        public CalculateurTaxes()
        {
            taxations = new Dictionary<string, AbstractTaxes>();

            taxations.Add("QC", new TaxesRegulieres("QC", 0.05f, 0.9975f));

            // Simplification de l'exécution. En temps normal on lirait cette données dans un 
            // fichier de configuration
            region = "QC";
        }
        /// <summary>
        /// Calcule la valeur de la taxe pour une facture
        /// </summary>
        /// <param name="facture">La facture pour laquelle calculer les taxes</param>
        /// <param name="codeTaxe">Le code de taxe utilisé pour la facture</param>
        /// <returns>Le montant des taxes pour la facture</returns>
        public AbstractTaxes CalculerTaxes(Facture facture, string codeTaxe = null)
        {
            // Magie ==> si codeTaxe est nul alors il vaut la valeur définie dans région
            codeTaxe ??= region;

            if (taxations.TryGetValue(codeTaxe, out AbstractTaxes modeleTaxe))
            {
                AbstractTaxes taxes = modeleTaxe.Clone();

                Dictionary<Item, int> itemsTaxables = facture.GetItemsTaxables(codeTaxe);
                float prixItem;
                foreach (KeyValuePair<Item, int> item in itemsTaxables)
                {
                    prixItem = item.Key.Prix * item.Value;
                    taxes.ValeurTaxeNationale += prixItem * taxes.TauxTaxeNationale;
                    taxes.ValeurTaxeLocale += prixItem * taxes.TauxTaxeLocale;
                }

                return taxes;
            }

            throw new Exception("Le code de taxe \"" + codeTaxe + "\" n'existe pas.");
        }
    }
}
