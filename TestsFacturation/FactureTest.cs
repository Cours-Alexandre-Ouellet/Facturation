using Microsoft.VisualStudio.TestTools.UnitTesting;
using Facturation;
using System;

namespace TestsFacturation
{
    [TestClass]
    public class FactureTest
    {
        // Références utilisées dans les tests
        private Facture facture;
        private Item itemTest;

        [TestInitialize]
        public void InitialisationTests()
        {
            facture = new Facture(DateTime.Now);
            itemTest = new Item(5f, "Test", null);
        }

        [TestCleanup]
        public void NettoyageTests()
        {
            // On remet les objets dans un état d'origine
        }

        [TestMethod]
        public void TestAjoutItem()
        {
            // On ajoute un item
            facture.AjouterItem(itemTest, 1);
            Assert.AreEqual(1, facture.ContenuFacture[itemTest]);
        }

        [TestMethod]
        public void TestAjoutItemMultiple()
        {
            // On ajoute plusieurs fois le même item
            facture.AjouterItem(itemTest, 1);
            facture.AjouterItem(itemTest, 2);
            Assert.AreEqual(3, facture.ContenuFacture[itemTest]);
        }
    }
}
