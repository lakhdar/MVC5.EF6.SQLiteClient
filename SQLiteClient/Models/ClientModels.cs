using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SQLiteClient.Models
{
    public class ClientElementDeListeVM
    {
        [Display(Name = "Identifiant", ResourceType =typeof(Messages))]
        public int ClientID { get; set; }


        [Display(Name = "Compagnie", ResourceType = typeof(Messages))]
        public string Compagnie { get; set; }


        [Display(Name = "Contact", ResourceType = typeof(Messages))]
        public string Contact { get; set; }


        [Display(Name = "Adresse", ResourceType = typeof(Messages))]
        public string Adresse { get; set; }


        [Display(Name = "Telephone", ResourceType = typeof(Messages))]
        public string Telephone { get; set; }


        [Display(Name = "TotalCommandes", ResourceType = typeof(Messages))]
        public int TotalCommandes { get; set; }
    }

    public class ClientCreationVM
    {

        [Display(Name = "Identifiant", ResourceType = typeof(Messages))]
        public int ClientID { get; set; }


        [Display(Name = "Compagnie", ResourceType = typeof(Messages))]
        public string Compagnie { get; set; }


        [Display(Name = "Contact", ResourceType = typeof(Messages))]
        public string Contact { get; set; }


        [Display(Name = "Adresse", ResourceType = typeof(Messages))]
        public string Adresse { get; set; }


        [Display(Name = "Ville", ResourceType = typeof(Messages))]
        public string Ville { get; set; }


        [Display(Name = "CodePostal", ResourceType = typeof(Messages))]
        public string CodePostal { get; set; }

        [Display(Name = "Pays", ResourceType = typeof(Messages))]
        public string Pays { get; set; }





        [Display(Name = "Telephone", ResourceType = typeof(Messages))]
        public string Telephone { get; set; }


         
    }

}