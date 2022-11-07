using System.Collections.Generic;

namespace Facturation
{
    /// <summary>
    /// Accès la BD pour les employés
    /// </summary>
    public class EmployeDAO : IDAO
    {
        /// <summary>
        /// Simule la BD pour les employés
        /// </summary>
        private readonly List<Employe> employes;

        /// <summary>
        /// Crée une nouvelle DAO pour les employés 
        /// </summary>
        public EmployeDAO()
        {
            employes = new List<Employe>()
            {
                new Employe("Joe", "Biden", "B456"),
                new Employe("Donald", "Trump", "T678"),
                new Employe("Barack", "Obama", "O752")
            };
        }

        /// <summary>
        /// Trouve un employé en utilisant le code. Si aucun employé ne porte ce code, une exception est lancée.
        /// </summary>
        /// <param name="code">Le code de l'employé recherché.</param>
        /// <returns>L'employé portant le code cherché.</returns>
        /// <exception cref="KeyNotFoundException">Si le code de l'employé recherché n'existe pas.</exception>
        public Employe GetEmployeParCode(string code)
        {
            if(employes.Find(e => e.Code == code) is Employe employe)
            {
                return employe;
            }

            throw new KeyNotFoundException($"Pas d'employe avec le code {code}.");
        }
    }
}
