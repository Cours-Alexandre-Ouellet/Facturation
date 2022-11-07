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
            Employe employe = new Employe("Yvan", "Dubois", "D007");
            facture = new Facture(DateTime.Now, employe);
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

        [TestMethod]
        public void TestGetItemsTaxables()
        {
            int value = 0;

            var itemIncluded = new Item(56.56f, "Inclus", null);
            var itemExcluded = new Item(56.56f, "Inclus", new string[1] { "Exclus" });

            facture.AjouterItem(itemIncluded, 2);
            facture.AjouterItem(itemExcluded, 56);

            var liste = facture.GetItemsTaxables("Exclus");

            //Vérifie si l'item à exclure a été exclu
            liste.TryGetValue(itemExcluded, out value);
            Assert.AreEqual(0, value);

            value = 0;

            //Vérifie si l'item à garder a été trouvé
            liste.TryGetValue(itemIncluded, out value);
            Assert.AreNotEqual(0, value);

        }
    }
}
