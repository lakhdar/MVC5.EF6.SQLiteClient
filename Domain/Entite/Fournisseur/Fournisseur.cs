

namespace Domain 
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Descit le fournisseur
    /// </summary>
    public  class Fournisseur : EntiteBase
    {
         
        /// <summary>
        /// Nom   de la Compangnie 
        /// </summary>
        [MaxLength(100)]
        [Index("IX_Fournisseur_Nom")]
        [Required]
        public string Nom { get; set; }
        /// <summary>
        /// identifiant du Contact 
        /// </summary>
        [MaxLength(100)]
        [Index("IX_Fournisseur_Contact")]
        public string Contact { get; set; }
        /// <summary>
        /// Titre du contact 
        /// </summary>
        public string TitreDuContact { get; set; }
        /// <summary>
        /// Adresse du fournisseur
        /// </summary>
        public string Adresse { get; set; }
        /// <summary>
        /// Ville du fournisseur
        /// </summary>
        public string Ville { get; set; }
        /// <summary>
        /// Code postal du fournisseur
        /// </summary>
        public string CodePostal { get; set; }
        /// <summary>
        /// Pays du fournisseur
        /// </summary>
        public string Pays { get; set; }
        /// <summary>
        /// Telephone du fournisseur
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// Les Produits du fournisseur
        /// </summary>
        public virtual ICollection<Produit> Produits { get; set; }

    }
}
