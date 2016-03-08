

namespace Domain 
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Description du produit 
    /// </summary>
    public class Produit : EntiteBase
    {
        /// <summary>
        /// Nom   du Produit 
        /// </summary>
        [MaxLength(100)]
        [Index("IX_Produit_Nom")]  
        [Required]
        public string Nom { get; set; }
      
        /// <summary>
        /// Quantite par unité  expediée
        /// </summary>
        public string QuantitieParUnite { get; set; }
        /// <summary>
        /// Prix unitaire
        /// </summary>

        [DataType(DataType.Currency)]
        public Decimal PrixUnitaire { get; set; }
        /// <summary>
        /// Les unités en stock
        /// </summary>
        public int UnityDansStock { get; set; }

        /// <summary>
        /// identifiant du Categorie 
        /// </summary>
        public int CategorieID { get; set; }

        /// <summary>
        ///  Categorie du produit
        /// </summary>
        [ForeignKey("CategorieID")]
        public virtual  Categorie Categorie  { get; set; }

        /// <summary>
        /// identifiant du fournisseur 
        /// </summary>
        public int FournisseurID { get; set; }

        /// <summary>
        ///  Fournisseur du produit
        /// </summary>
        [ForeignKey("FournisseurID")]
        public virtual Fournisseur Fournisseur { get; set; }

        /// <summary>
        /// Les commandes associées
        /// </summary>
        public virtual ICollection<CommandeProduit> CommandeProduits { get; set; }
    }
}
