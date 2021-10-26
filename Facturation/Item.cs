using System.Collections.Generic;

namespace Facturation
{
    /// <summary>
    /// Item de l'inventaire de l'entreprise
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Prix de l'item
        /// </summary>
        public float Prix { get; private set; }

        /// <summary>
        /// Nom de l'item 
        /// </summary>
        public string Nom { get; private set; }

        /// <summary>
        /// Liste des codes de taxe pour lesquels l'item est exempté
        /// </summary>
        public List<string> ExemptionTaxes { get; private set; }

        /// <summary>
        /// Crée un nouvel item.
        /// </summary>
        /// <param name="prix">Le prix de l'item.</param>
        /// <param name="nom">Le nom de l'item.</param>
        /// <param name="codesExemption">Le code d'exemption de taxes.</param>
        public Item (float prix, string nom, params string[] codesExemption)
        {
            Prix = prix;
            Nom = nom;
            ExemptionTaxes = (codesExemption == null) ? new List<string>() : new List<string>(codesExemption);
        }
    }
}
