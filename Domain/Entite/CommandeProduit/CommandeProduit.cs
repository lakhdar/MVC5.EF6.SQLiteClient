namespace Domain 
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class CommandeProduit
    {

        /// <summary>
        /// identifiant du fournisseur 
        /// </summary>
        [DataType(DataType.Currency)]
        public Decimal PrixUnitaire { get; set; }
        /// <summary>
        /// identifiant du Categorie 
        /// </summary>
        public int Quantite { get; set; }

        /// <summary>
        /// identifiant du Produit 
        /// </summary>
        [Key,Column(Order =0)]
        public int ProduitID { get; set; }

        /// <summary>
        ///    produit Commandé
        /// </summary>
        [ForeignKey("ProduitID")]
        public virtual Produit Produit { get; set; }

        /// <summary>
        /// Nom  de la Commande
        /// </summary>
        [Key, Column(Order = 1)]
        public int CommandeID { get; set; }

        /// <summary>
        ///  Commande du produit
        /// </summary>
        [ForeignKey("CommandeID")]
        public virtual Commande Commande { get; set; }
    }
}
