
namespace Domain
{
    using System.Collections.Generic;


    /// <summary>
    /// Description du client 
    /// </summary>
    public class Client : EntiteBase
    {

        /// <summary>
        /// Identifiant Client
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Nom de la compagnie du client 
        /// </summary>
        public string Nom { get; set; }
        /// <summary>
        /// le Nom du contact
        /// </summary>
        public string Contact { get; set; }
        /// <summary>
        /// le titre (emploi) du contact
        /// </summary>
        public string TitreContact { get; set; }
        /// <summary>
        /// adresse du client
        /// </summary>
        public string Adresse { get; set; }
        /// <summary>
        /// ville du contact
        /// </summary>
        public string Ville { get; set; }
        /// <summary>
        /// le code postal 
        /// </summary>
        public string CodePostal { get; set; }
        /// <summary>
        /// pays du client 
        /// </summary>
        public string Pays { get; set; }
        /// <summary>
        /// Le telephone du client 
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// Les Commandes faites par le client
        /// </summary>
        public virtual ICollection<Commande> Commandes { get; set; }

    }
}
