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
    public static class ExtensionFournisseur
    {

        public static IEnumerable<FournisseurElementDeListeVM> ToViewModel(this IEnumerable<Fournisseur> modelDonnee)
        {
            List<FournisseurElementDeListeVM> viewModel = null;
            if (modelDonnee != null)
            {
                viewModel = new List<FournisseurElementDeListeVM>();

                foreach (Fournisseur model in modelDonnee)
                {
                    viewModel.Add(new FournisseurElementDeListeVM()
                    {
                        FournisseurID = model.Id,
                        Compagnie = model.Nom,
                        Contact = model.Contact,
                        Telephone = model.Telephone,
                        Adresse = model.Adresse + "  " + model.Ville + "  " + model.CodePostal + "  " + model.Pays,
                        TotalProduits = model.Produits == null ? 0 : model.Produits.Count()
                    });
                }

            }

            return viewModel;
        }

        public static FournisseurElementDeListeVM ToViewModel(this Fournisseur model)
        {
            FournisseurElementDeListeVM viewModel = null;
            if (model != null)
            {
                viewModel = new FournisseurElementDeListeVM()
                {
                    FournisseurID = model.Id,
                    Compagnie = model.Nom,
                    Contact = model.Contact,
                    Telephone = model.Telephone,
                    Adresse = model.Adresse + "  " + model.Ville + "  " + model.CodePostal + "  " + model.Pays,
                    TotalProduits = model.Produits == null ? 0 : model.Produits.Count()
                };
            }

            return viewModel;
        }

        public static FournisseurDetailsVM ToDetailViewModel(this Fournisseur model)
        {
            FournisseurDetailsVM viewModel = null;
            if (model != null)
            {
                viewModel = new FournisseurDetailsVM()
                {
                    FournisseurID = model.Id,
                    Compangnie = model.Nom,
                    Contact = model.Contact,
                    Telephone = model.Telephone,
                    Adresse = model.Adresse + "  " + model.Ville + "  " + model.CodePostal + "  " + model.Pays,
                    Produits = model.Produits.ToViewModel() 
                };
            }

            return viewModel;
        }

        

        public static PagedList<FournisseurElementDeListeVM> ToViewModel(this PagedList<Fournisseur> modelDonnee)
        {
            PagedList<FournisseurElementDeListeVM> viewModel = null;
            if (modelDonnee != null)
            {
                viewModel = new PagedList<FournisseurElementDeListeVM>();
                List<FournisseurElementDeListeVM> tempList = new List<FournisseurElementDeListeVM>();
                viewModel.Total = modelDonnee.Total;
                viewModel.PageIndex = modelDonnee.PageIndex;
                viewModel.PageCount = modelDonnee.PageCount;
                foreach (Fournisseur model in modelDonnee.PagedData)
                {
                    tempList.Add(new FournisseurElementDeListeVM()
                    {
                        FournisseurID = model.Id,
                        Compagnie = model.Nom,
                        Contact = model.Contact,
                        Telephone = model.Telephone,
                        Adresse = model.Adresse + "  " + model.Ville + "  " + model.CodePostal + "  " + model.Pays,
                        TotalProduits=model.Produits==null?0: model.Produits.Count()

                    });
                }
                viewModel.PagedData = tempList.AsEnumerable();
            }

            return viewModel;
        }

        public static Fournisseur ToDataModel(this FournisseurCreationVM model)
        {
            Fournisseur viewModel = null;
            if (model != null)
            {
                viewModel = new Fournisseur()
                {
                    Nom  = model.Compangnie,
                    Contact = model. Contact,
                    Telephone = model.Telephone,
                    Adresse = model.Adresse,
                    Ville = model.Ville,
                    CodePostal= model.CodePostal,
                    Pays = model.Pays,
                };
            }

            return viewModel;
        }

        public static IEnumerable<ListItem> ToSelectListItem(this IEnumerable<Fournisseur> modelDonnee)
        {
            List<ListItem> viewModel = null;
            if (modelDonnee != null)
            {
                viewModel = new List<ListItem>();

                foreach (Fournisseur model in modelDonnee)
                {
                    viewModel.Add(new ListItem()
                    {
                        Value = model.Id.ToString(),
                        Text = model.Nom,
                    });
                }
            }

            return viewModel;
        }
    }
}