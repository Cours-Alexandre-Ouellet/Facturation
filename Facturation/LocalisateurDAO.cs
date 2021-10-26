using System;
using System.Collections.Generic;

namespace Facturation
{
    /// <summary>
    /// Localisateur de service pour les DAO
    /// </summary>
    public class LocalisateurDAO
    {
        /// <summary>
        /// Liste des instances de DAO de l'application
        /// </summary>
        private Dictionary<Type, object> instancesDAO;

        /// <summary>
        /// Implémentation du singleton
        /// </summary>
        private static LocalisateurDAO instance;
        public static LocalisateurDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LocalisateurDAO();
                }
                return instance;
            }
        }

        /// <summary>
        /// Crée un nouveau localisateur de services
        /// </summary>
        private LocalisateurDAO()
        {
            instancesDAO = new Dictionary<Type, object>();
        }

        /// <summary>
        /// Accède à une DAO et retourne son instance. Crée la DAO
        /// si elle n'existe pas
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetDAO<T>() where T : IDAO
        {
            if(instancesDAO.TryGetValue(typeof(T), out object dao))
            {
                return (T)dao;
            }
            else
            {
                T nouvelleDAO = (T) Activator.CreateInstance(typeof(T));
                instancesDAO.Add(typeof(T), nouvelleDAO);

                return nouvelleDAO;
            }
        }

    }
}
