using System.Collections.Generic;

namespace Facturation
{
    /// <summary>
    /// Interface la base de données pour la gestion des factures
    /// </summary>
    public class FactureDAO : IDAO
    {
        /// <summary>
        /// Émulation de la BD
        /// </summary>
        private readonly List<Facture> factures;

        /// <summary>
        /// Crée une nouvelle interface
        /// </summary>
        public FactureDAO()
        {
            factures = new List<Facture>();
        }

        /// <summary>
        /// Enregistre une facture dans la base de données
        /// </summary>
        /// <param name="facture">La facture à enregistrer</param>
        public void Sauvegarder(Facture facture)
        {
            if (facture.Id < 0)
            {
                facture.Id = factures.Count;
                factures.Add(facture);
            }
            else
            {
                // Comme on travail sur des références, ça se fait tout seul...
                // Sinon on ferait un UPDATE ici
            }
        }
    }
}
