using System;
using System.Collections.Generic;
using System.Text;

namespace Facturation
{
    /// <summary>
    /// Employé de la boutique
    /// </summary>
    public class Employe
    {
        /// <summary>
        /// Nom de famille de l'employé
        /// </summary>
        public string Nom { get; }

        /// <summary>
        /// Prénom de l'employé
        /// </summary>
        public string Prenom { get; }

        /// <summary>
        /// code d'identification de l'employé
        /// </summary>
        public string Code { get; }

        public Employe(string prenom, string nom, string code)
        {
            Prenom = prenom;
            Nom = nom;
            Code = code;
        }
    }
}
