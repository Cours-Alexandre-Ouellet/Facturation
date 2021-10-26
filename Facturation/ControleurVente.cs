using System;

namespace Facturation
{
    /// <summary>
    /// Gestionnaire des opérations d'une vente
    /// </summary>
    public class ControleurVente
    {
        /// <summary>
        /// Facture créée pour la vente
        /// </summary>
        private Facture facture;

        /// <summary>
        /// Inventaire du magasin
        /// </summary>
        private readonly Inventaire inventaire;

        /// <summary>
        /// Calculateur de taxes
        /// </summary>
        private readonly CalculateurTaxes calculateurTaxes;

        /// <summary>
        /// Crée un nouveau contrôleur de vente
        /// </summary>
        public ControleurVente()
        {
            inventaire = LocalisateurDAO.Instance.GetDAO<InventaireDAO>().ChargerInventaire();
            calculateurTaxes = new CalculateurTaxes();
        }

        /// <summary>
        /// Commence une nouvelle vente
        /// </summary>
        public void DemarrerVente()
        {
            facture = new Facture(DateTime.Now);
        }

        /// <summary>
        /// Ajoute un item à une vente
        /// </summary>
        /// <param name="item">L'item qui sera ajoutée à la vente.</param>
        /// <param name="quantite">Le nombre de fois que cet item doit être inclus.</param>
        public void AjouterItem(Item item, int quantite)
        {
            facture.AjouterItem(item, quantite);
            inventaire.RetirerItem(item, quantite);

            LocalisateurDAO.Instance.GetDAO<InventaireDAO>().Sauvegarder(inventaire);
        }

        /// <summary>
        /// Conclu la facture et calcule les taxes.
        /// </summary>
        /// <returns>La facture complétée</returns>
        public Facture ConclureFacture()
        {
            AbstractTaxes taxes = calculateurTaxes.CalculerTaxes(facture);
            facture.Taxes = taxes;
            facture.Clore();

            LocalisateurDAO.Instance.GetDAO<FactureDAO>().Sauvegarder(facture);

            return facture;
        }

    }
}
