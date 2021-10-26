using System.Collections.Generic;

namespace Facturation
{
    /// <summary>
    /// Contient l'inventaire du magasin
    /// </summary>
    public class Inventaire
    {
        /// <summary>
        /// Contenu de l'inventaire
        /// </summary>
        public Dictionary<Item, int> Contenu { get; private set; }

        /// <summary>
        /// Crée un nouvel inventaire
        /// </summary>
        public Inventaire()
        {
            Contenu = new Dictionary<Item, int>();
        }

        /// <summary>
        /// Retire un item de l'inventaire
        /// </summary>
        /// <param name="item">L'item à retirer de l'inventaire</param>
        /// <param name="quantite">La quantite à retirer de l'inventaire</param>
        public void RetirerItem(Item item, int quantite)
        {
            Contenu[item] -= quantite;
        }

        /// <summary>
        /// Retourne l'item associé au nom ou la valeur nulle si aucun item
        /// ne porte ce nom
        /// </summary>
        /// <param name="nomItem">Le nom de l'item à trouver.</param>
        /// <returns>Le premier item qui porte ce nom ou null.</returns>
        public Item TrouverItemParNom(string nomItem)
        {
            foreach(Item item in Contenu.Keys)
            {
                if (item.Nom == nomItem)
                {
                    return item;
                }
            }

            return null;
        }
    }
}
