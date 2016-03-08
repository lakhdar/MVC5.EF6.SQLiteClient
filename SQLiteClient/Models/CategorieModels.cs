using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SQLiteClient.Models
{
    public class CategorieElementDeListeVM
    {

        [Display(Name = "CategorieID", ResourceType =typeof(Messages))]
        public int CategorieID { get; set; }


        [Display(Name = "Nom ", ResourceType = typeof(Messages))]
        public string Nom  { get; set; }


        [Display(Name = "Description", ResourceType = typeof(Messages))]
        public string Description { get; set; }
        
    }
}