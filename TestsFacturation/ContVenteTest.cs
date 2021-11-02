using Microsoft.VisualStudio.TestTools.UnitTesting;
using ControleurVente;
using System;

namespace ContVenteTest
{
    [TestClass]
    public class ContVenteTest
    {
        [TestInitialize]
        public void InitialisationTests()
        {
            ControleurVente controleur = new ControleurVente();
            controleur.DemarrerVente();

            controleur.AjouterItem(inventaire.TrouverItemParNom("Fourchette de luxe"), 5);
        }

        [TestMethod]
        public void TestConclureFacture()
        {
            Facture facture = controleur.ConclureFacture();
            if(!facture.ContenuFacture){
                Assert.fail()
            }
            
        }
    }
}