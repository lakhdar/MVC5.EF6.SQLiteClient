using Domain;
using SQLiteClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace SQLiteClient.Extension
{
    public static class ExtensionCommande
    {

        public static IEnumerable<CommandeElementDeListeVM> ToViewModel(this IEnumerable<Commande> modelDonnee)
        {
            List<CommandeElementDeListeVM> viewModel = null;
            if (modelDonnee != null)
            {
                viewModel = new List<CommandeElementDeListeVM>();

                foreach (Commande model in modelDonnee)
                {
                    viewModel.Add(new CommandeElementDeListeVM()
                    {
                        CommandeID=model.Id,
                        DateCommande=model.DateCommande,
                        DateLivraison=model.DateLivraison,
                        Livreur=model.Livreur,
                        AdresseLivraison= model.AdresseLivraison + "  " + model.VilleLivraison + "  " + model.CodePostalLivraison + "  " + model.PaysLivraison,
                         Client=model.Client!=null? model.Client.Nom:null,
                         TotalProduits = model.CommandeProduits != null ? model.CommandeProduits.Count():0,
                    });
                }

            }

            return viewModel;
        }


        public static IEnumerable<CommandeProduitVM> ToViewModel(this IEnumerable<CommandeProduit> modelDonnee)
        {
            List<CommandeProduitVM> viewModel = null;
            if (modelDonnee != null)
            {
                viewModel = new List<CommandeProduitVM>();

                foreach (CommandeProduit model in modelDonnee)
                {
                    viewModel.Add(new CommandeProduitVM()
                    {
                        CommandeID = model.CommandeID,
                        ProduitID=model.ProduitID,
                        Quantite=model.Quantite
                    });
                }

            }

            return viewModel;
        }








        public static CommandeElementDeListeVM ToViewModel(this Commande model)
        {
            CommandeElementDeListeVM viewModel = null;
            if (model != null)
            {
                viewModel = new CommandeElementDeListeVM()
                {
                    CommandeID = model.Id,
                    DateCommande = model.DateCommande,
                    DateLivraison = model.DateLivraison,
                    Livreur = model.Livreur,
                    AdresseLivraison = model.AdresseLivraison + "  " + model.VilleLivraison + "  " + model.CodePostalLivraison + "  " + model.PaysLivraison,
                    Client = model.Client != null ? model.Client.Nom : null,
                    TotalProduits = model.CommandeProduits != null ? model.CommandeProduits.Count() : 0,
                };
            }

            return viewModel;
        }

        public static CommandeDetailsVM ToDetailViewModel(this Commande model)
        {
            CommandeDetailsVM viewModel = null;
            if (model != null)
            {
                viewModel = new CommandeDetailsVM()
                {
                    CommandeID = model.Id,
                    DateCommande = model.DateCommande,
                    DateLivraison = model.DateLivraison,
                    Livreur = model.Livreur,
                    AdresseLivraison = model.AdresseLivraison + "  " + model.VilleLivraison + "  " + model.CodePostalLivraison + "  " + model.PaysLivraison,
                    Produits = model.CommandeProduits.ToViewModel() ,
                    Client=model.Client.ToViewModel()
                };
            }

            return viewModel;
        }

        

        public static PagedList<CommandeElementDeListeVM> ToViewModel(this PagedList<Commande> modelDonnee)
        {
            PagedList<CommandeElementDeListeVM> viewModel = null;
            if (modelDonnee != null)
            {
                viewModel = new PagedList<CommandeElementDeListeVM>();
                List<CommandeElementDeListeVM> tempList = new List<CommandeElementDeListeVM>();
                viewModel.Total = modelDonnee.Total;
                viewModel.PageIndex = modelDonnee.PageIndex;
                viewModel.PageCount = modelDonnee.PageCount;
                foreach (Commande model in modelDonnee.PagedData)
                {
                    tempList.Add(new CommandeElementDeListeVM()
                    {
                        CommandeID = model.Id,
                        DateCommande = model.DateCommande,
                        DateLivraison = model.DateLivraison,
                        Livreur = model.Livreur,
                        AdresseLivraison = model.AdresseLivraison + "  " + model.VilleLivraison + "  " + model.CodePostalLivraison + "  " + model.PaysLivraison,
                        Client = model.Client != null ? model.Client.Nom : null,
                        TotalProduits = model.CommandeProduits != null ? model.CommandeProduits.Count() : 0,

                    });
                }
                viewModel.PagedData = tempList.AsEnumerable();
            }

            return viewModel;
        }

        public static Commande ToDataModel(this CommandeCreationVM model)
        {
            Commande viewModel = null;
            if (model != null)
            {
                viewModel = new Commande()
                {
                    ClientID=model.ClientID,
                    CodePostalLivraison=model.CodePostal,
                    AdresseLivraison=model.AdresseLivraison,
                    DateCommande=DateTime.UtcNow,
                    DateRequise=model.DateLivraison,
                    Livreur=model.Livreur,
                    PaysLivraison=model.Pays,
                    VilleLivraison=model.Ville                    
                };
            }

            return viewModel;
        }
    }
}