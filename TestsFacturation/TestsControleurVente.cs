using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Facturation;

namespace TestsFacturation
{
    [TestClass]
    public class TestsControleurVente
    {
        // R�f�rences utilis�es dans les tests
        private ControleurVente controleurVente;
        private int itemQuantite;
        private Item itemTest;
        private Random rand;

        [TestInitialize]
        public void InitialisationTests()
        {
            controleurVente = new ControleurVente();
            rand = new Random();
            itemQuantite = rand.Next(0,10);
            itemTest = new Item(5f, "Test", null);
        }

        [TestCleanup]
        public void NettoyageTests()
        {
            // On remet les objets dans un �tat d'origine
            rand = new Random();
            itemQuantite = rand.Next(0, 10);
            itemTest = new Item(15.99f, "Fourchette de luxe", null);
        }

        [TestMethod]
        public void TestControleurVenteAjoutItem()
        {
            controleurVente.DemarrerVente();
            controleurVente.AjouterItem(itemTest, itemQuantite);
        }
    }
}
