using System;

namespace Facturation
{
    public class Program
    {
        // Exemple d'un scénario d'exécution
        static void Main(string[] args)
        {
            Inventaire inventaire = LocalisateurDAO.Instance.GetDAO<InventaireDAO>().ChargerInventaire();

            ControleurVente controleur = new ControleurVente();
            controleur.DemarrerVente();

            controleur.AjouterItem(inventaire.TrouverItemParNom("Fourchette de luxe"), 5);
            controleur.AjouterItem(inventaire.TrouverItemParNom("Très gros chaudron"), 1);
            controleur.AjouterItem(inventaire.TrouverItemParNom("Fourchette de luxe"), 2);

            Facture facture = controleur.ConclureFacture();
            Console.WriteLine($"Il vous coutera {facture.Total:c}");
        }
    }
}
