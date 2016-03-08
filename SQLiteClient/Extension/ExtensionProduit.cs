using Domain;
using SQLiteClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQLiteClient.Extension
{
    public static class ExtensionProduit
    {

        public static IEnumerable<ProduitElementDeListeVM> ToViewModel(this IEnumerable<Produit> modelDonnee)
        {
            List<ProduitElementDeListeVM> viewModel = null;
            if (modelDonnee != null)
            {
                viewModel = new List<ProduitElementDeListeVM>();

                foreach (Produit model in modelDonnee)
                {
                    viewModel.Add(new ProduitElementDeListeVM()
                    {
                        ProduitID = model.Id,
                        Produit = model.Nom,
                        Categorie = model.Categorie.Nom,
                        Fournisseur = model.Fournisseur.Nom,
                        TotalCommandes = model.CommandeProduits.Count(),
                        PrixUnitaire = model.PrixUnitaire,
                        UnityDansStock = model.UnityDansStock,

                    });
                }

            }

            return viewModel;
        }

        public static ProduitElementDeListeVM ToViewModel(this Produit model)
        {
            ProduitElementDeListeVM viewModel = null;
            if (model != null)
            {
                viewModel = new ProduitElementDeListeVM()
                {
                    ProduitID = model.Id,
                    Produit = model.Nom,
                    Categorie = model.Categorie.Nom,
                    Fournisseur = model.Fournisseur.Nom,
                    TotalCommandes = model.CommandeProduits.Count(),
                    PrixUnitaire = model.PrixUnitaire,
                    UnityDansStock = model.UnityDansStock,

                } ;
            }

            return viewModel;
        }
        public static Produit ToDataModel(this ProduitElementDeListeVM  model)
        {
            Produit viewModel = null;
            if (model != null)
            {
                viewModel = new Produit()
                {
                    Id = model.ProduitID,
                    Nom = model.Produit,
                    PrixUnitaire = model.PrixUnitaire,
                    FournisseurID=1,
                    CategorieID=1,
                    UnityDansStock = model.UnityDansStock
                };
            }

            return viewModel;
        }

        public static PagedList<ProduitElementDeListeVM> ToViewModel(this PagedList<Produit> modelDonnee)
        {
            PagedList<ProduitElementDeListeVM> viewModel = null;
            if (modelDonnee != null)
            {
                viewModel = new PagedList<ProduitElementDeListeVM>();
                List<ProduitElementDeListeVM> tempList = new List<ProduitElementDeListeVM>();
                viewModel.Total = modelDonnee.Total;
                viewModel.PageIndex = modelDonnee.PageIndex;
                viewModel.PageCount = modelDonnee.PageCount;
                foreach (Produit model in modelDonnee.PagedData)
                {
                    tempList.Add(new ProduitElementDeListeVM()
                    {
                        ProduitID = model.Id,
                        Produit = model.Nom,
                        Categorie = model.Categorie.Nom,
                        Fournisseur = model.Fournisseur.Nom,
                        TotalCommandes =( model.CommandeProduits!= null)? model.CommandeProduits.Count():0,
                        PrixUnitaire = model.PrixUnitaire,
                        UnityDansStock = model.UnityDansStock,

                    });
                }
                viewModel.PagedData = tempList.AsEnumerable();
            }

            return viewModel;
        }





        public static Produit ToDataModel(this ProduitCreationVM model)
        {
            Produit viewModel = null;
            if (model != null)
            {
                viewModel = new Produit()
                {
                    Nom = model.Produit,
                    PrixUnitaire = model.PrixUnitaire,
                    FournisseurID =int.Parse(model.FournisseurID),
                    CategorieID = int.Parse(model.CategorieID),
                    UnityDansStock = model.UnityDansStock
                };
            }

            return viewModel;
        }
    }
}