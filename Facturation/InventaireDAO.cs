using System.Collections.Generic;

namespace Facturation
{
    /// <summary>
    /// Interface la base de données pour la gestion de l'inventaire
    /// </summary>
    public class InventaireDAO :IDAO
    {
        /// <summary>
        /// Émulation de l'inventaire
        /// </summary>
        private readonly Dictionary<Item, int> contenu;

        /// <summary>
        /// Crée une nouvelle interface pour l'inventaire
        /// </summary>
        public InventaireDAO()
        {
            contenu = new Dictionary<Item, int>
            {
                // On peuple un peu la "BD"
                { new Item(15.99f, "Fourchette de luxe", null), 15 },
                { new Item(2.99f, "Tasse à café", null), 20 },
                { new Item(48.79f, "Très gros chaudron", "QC"), 35 },
                { new Item(39.19f, "Poêle qui colle", null), 8 }
            };
        }

        /// <summary>
        /// Retourne un objet inventaire contenant les informations de la BD
        /// </summary>
        /// <returns>Un objet inventaire avec l'état de la BD</returns>
        public Inventaire ChargerInventaire()
        {
            Inventaire inventaire = new Inventaire();

            // On utilise la réflexivité pour contourner le modification de visibilité privé
            typeof(Inventaire).GetProperty("Contenu").SetValue(inventaire, contenu);
            
            return inventaire;
        }

        /// <summary>
        /// Sauvegarde l'inventaire dans la BD.
        /// </summary>
        /// <param name="inventaire">L'inventaire à sauvegarder</param>
        public void Sauvegarder(Inventaire inventaire)
        {
            // On utilise des références, donc la sauvegarde se fait déjà automatiquement
        }
    }
}
