using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SQLiteClient.Models
{
    public class CommandeElementDeListeVM
    {
        [Display(Name = "Identifiant", ResourceType =typeof(Messages))]
        public int CommandeID { get; set; }


        [Display(Name = "DateCommande", ResourceType = typeof(Messages))]
        public DateTime DateCommande { get; set; }


        [Display(Name = "DateLivraison", ResourceType = typeof(Messages))]
        public DateTime DateLivraison { get; set; }


        [Display(Name = "AdresseLivraison", ResourceType = typeof(Messages))]
        public string AdresseLivraison { get; set; }

        [Display(Name = "Livreur", ResourceType = typeof(Messages))]
        public string Livreur { get; set; }


        [Display(Name = "Client", ResourceType = typeof(Messages))]
        public string Client { get; set; }

        [Display(Name = "TotalProduits", ResourceType = typeof(Messages))]
        public int TotalProduits { get; set; }

    }

    public class CommandeDetailsVM
    {
        [Display(Name = "Identifiant", ResourceType = typeof(Messages))]
        public int CommandeID { get; set; }


        [Display(Name = "DateCommande", ResourceType = typeof(Messages))]
        public DateTime DateCommande { get; set; }


        [Display(Name = "DateLivraison", ResourceType = typeof(Messages))]
        public DateTime DateLivraison { get; set; }


        [Display(Name = "AdresseLivraison", ResourceType = typeof(Messages))]
        public string AdresseLivraison { get; set; }

        [Display(Name = "Livreur", ResourceType = typeof(Messages))]
        public string Livreur { get; set; }


        [Display(Name = "Client", ResourceType = typeof(Messages))]
        public ClientElementDeListeVM Client { get; set; }

        [Display(Name = "Produit", ResourceType = typeof(Messages))]
        public IEnumerable<CommandeProduitVM> Produits { get; set; }

    }
    public class CommandeProduitVM
    {
       
        public int CommandeID { get; set; }


        
        public int ProduitID { get; set; }


        [Display(Name = "Quantite", ResourceType = typeof(Messages))]
        public int Quantite { get; set; }

    }



    

    public class CommandeCreationVM
    {

        [Display(Name = "DateCommande", ResourceType = typeof(Messages))]
        public DateTime DateCommande { get; set; }


        [Display(Name = "DateLivraison", ResourceType = typeof(Messages))]
        public DateTime DateLivraison { get; set; }


        [Display(Name = "AdresseLivraison", ResourceType = typeof(Messages))]
        public string AdresseLivraison { get; set; }

        [Display(Name = "Ville", ResourceType = typeof(Messages))]
        public string Ville { get; set; }


        [Display(Name = "CodePostal", ResourceType = typeof(Messages))]
        public string CodePostal { get; set; }


        [Display(Name = "Telephone", ResourceType = typeof(Messages))]
        public string Telephone { get; set; }


        [Display(Name = "Pays", ResourceType = typeof(Messages))]
        public string Pays { get; set; }


        [Display(Name = "Livreur", ResourceType = typeof(Messages))]
        public string Livreur { get; set; }


        [Display(Name = "Client", ResourceType = typeof(Messages))]
        public int ClientID { get; set; }

        [Display(Name = "Produit", ResourceType = typeof(Messages))]
        public int ProduitId { get; set; }
    }

}