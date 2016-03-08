namespace Domain 
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    /// <summary>
    /// Description de la commande
    /// </summary>
    public class Commande : EntiteBase
    {

        /// <summary>
        /// Date   de la Commande 
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime DateCommande { get; set; }

        /// <summary>
        /// Date requise pour  la Commande 
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime DateRequise { get; set; }
        /// <summary>
        /// Date de livraison
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime DateLivraison { get; set; }
        /// <summary>
        /// Nom du livreur
        /// </summary>
        
        public string Livreur { get; set; }
        /// <summary>
        /// Adresse de livraison
        /// </summary>
        public string AdresseLivraison { get; set; }
        /// <summary>
        /// Ville de livraison 
        /// </summary>
        public string VilleLivraison { get; set; }
        /// <summary>
        /// Code postal de livraison 
        /// </summary>
        public string CodePostalLivraison { get; set; }
        /// <summary>
        /// Pays de livraison 
        /// </summary>
        public string PaysLivraison { get; set; }

        /// <summary>
        /// identifiant  du client 
        /// </summary>
        [Required]
        public int ClientID { get; set; }
        /// <summary>
        ///  Fournisseur du produit
        /// </summary>
        [ForeignKey("ClientID")]
        public virtual Client Client { get; set; }

        /// <summary>
        /// Les Produits associées
        /// </summary>
        public virtual ICollection<CommandeProduit> CommandeProduits { get; set; }
    }
}
