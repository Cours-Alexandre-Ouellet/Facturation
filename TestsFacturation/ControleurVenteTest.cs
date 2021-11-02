using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Facturation;

namespace TestsFacturation
{
    [TestClass]
    public class ControleurVenteTest
    {
        private ControleurVente controleur;

        [TestInitialize]
        public void InitialisationTests()
        {
            controleur = new ControleurVente();
        }

        [TestMethod]
        public void DemarrerVenteTest()
        {
            try { 
                controleur.DemarrerVente();
            }
            catch(Exception e)
            {
                Assert.Fail("L'exécution de la méthode a échoué! Erreur: " + e);
            }
        }
    }
}
