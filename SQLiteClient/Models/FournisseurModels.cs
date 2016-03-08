using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SQLiteClient.Models
{
    public class FournisseurElementDeListeVM
    {
        [Display(Name = "Identifiant", ResourceType =typeof(Messages))]
        public int FournisseurID { get; set; }


        [Display(Name = "Compagnie", ResourceType = typeof(Messages))]
        public string Compagnie { get; set; }


        [Display(Name = "Contact", ResourceType = typeof(Messages))]
        public string Contact { get; set; }


        [Display(Name = "Adresse", ResourceType = typeof(Messages))]
        public string Adresse { get; set; }


        [Display(Name = "Telephone", ResourceType = typeof(Messages))]
        public string Telephone { get; set; }

        [Display(Name = "TotalProduits", ResourceType = typeof(Messages))]
        public int TotalProduits { get; set; }

    }

    public class FournisseurDetailsVM
    {
        [Display(Name = "Identifiant", ResourceType = typeof(Messages))]
        public int FournisseurID { get; set; }


        [Display(Name = "Compangnie", ResourceType = typeof(Messages))]
        public string Compangnie { get; set; }


        [Display(Name = "Contact", ResourceType = typeof(Messages))]
        public string Contact { get; set; }


        [Display(Name = "Adresse", ResourceType = typeof(Messages))]
        public string Adresse { get; set; }


        [Display(Name = "Telephone", ResourceType = typeof(Messages))]
        public string Telephone { get; set; }

        [Display(Name = "Produits", ResourceType = typeof(Messages))]

        public IEnumerable<ProduitElementDeListeVM>  Produits { get; set; }

    }

    public class FournisseurCreationVM
    {

        [Display(Name = "Compangnie", ResourceType = typeof(Messages))]
        public string Compangnie { get; set; }


        [Display(Name = "Contact", ResourceType = typeof(Messages))]
        public string Contact { get; set; }


        [Display(Name = "Adresse", ResourceType = typeof(Messages))]
        public string Adresse { get; set; }


        [Display(Name = "Ville", ResourceType = typeof(Messages))]
        public string Ville { get; set; }


        [Display(Name = "CodePostal", ResourceType = typeof(Messages))]
        public string CodePostal { get; set; }
        

        [Display(Name = "Telephone", ResourceType = typeof(Messages))]
        public string Telephone { get; set; }


        [Display(Name = "Pays", ResourceType = typeof(Messages))]
        public string Pays { get; set; }
    }

}