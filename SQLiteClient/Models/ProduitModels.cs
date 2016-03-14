using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SQLiteClient.Models
{
    public class ProduitElementDeListeVM
    {
        [Display(Name = "ProduitID", ResourceType =typeof(Messages))]
        public int ProduitID { get; set; }

        [Display(Name = "Produit", ResourceType = typeof(Messages))]
        public string Produit { get; set; }



        [Display(Name = "Categorie", ResourceType = typeof(Messages))]
        public string Categorie { get; set; }

        [Display(Name = "Fournisseur", ResourceType = typeof(Messages))]
        public string Fournisseur { get; set; }


        [Display(Name = "TotalCommandes", ResourceType = typeof(Messages))]
        public int TotalCommandes { get; set; }


        [Display(Name = "PrixUnitaire", ResourceType = typeof(Messages))]
        public Decimal PrixUnitaire { get; set; }


        [Display(Name = "UnitesDansStock", ResourceType = typeof(Messages))]
        public int UnitesDansStock { get; set; }
    }

    public class ProduitCreationVM
    {
         

        [Display(Name = "Produit", ResourceType = typeof(Messages))]
        public string Produit { get; set; }


        [Display(Name = "Categorie", ResourceType = typeof(Messages))]
        [Required]
        public string CategorieID { get; set; }

        [Display(Name = "Fournisseur", ResourceType = typeof(Messages))]
        [Required]
        public string FournisseurID { get; set; }


        [Display(Name = "PrixUnitaire", ResourceType = typeof(Messages))]
        public Decimal PrixUnitaire { get; set; }


        [Display(Name = "UnityDansStock", ResourceType = typeof(Messages))]
        public int UnityDansStock { get; set; }
    }

}