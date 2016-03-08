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
    public static class ExtensionCategorie
    {

        public static IEnumerable<CategorieElementDeListeVM> ToViewModel(this IEnumerable<Categorie> modelDonnee)
        {
            List<CategorieElementDeListeVM> viewModel = null;
            if (modelDonnee != null)
            {
                viewModel = new List<CategorieElementDeListeVM>();

                foreach (Categorie model in modelDonnee)
                {
                    viewModel.Add(new CategorieElementDeListeVM()
                    {
                         CategorieID= model.Id,
                         Nom=model.Nom,
                         Description=model.Description
                    });
                }

            }

            return viewModel;
        }

        public static CategorieElementDeListeVM ToViewModel(this Categorie model)
        {
            CategorieElementDeListeVM viewModel = null;
            if (model != null)
            {
                viewModel = new CategorieElementDeListeVM()
                {
                    CategorieID = model.Id,
                    Nom = model.Nom,
                    Description = model.Description

                } ;
            }

            return viewModel;
        }
        public static Categorie ToDataModel(this CategorieElementDeListeVM model)
        {
            Categorie viewModel = null;
            if (model != null)
            {
                viewModel = new Categorie()
                {
                    Id = model.CategorieID,
                    Nom  = model.Nom,
                    Description = model.Description
                };
            }

            return viewModel;
        }

        public static PagedList<CategorieElementDeListeVM> ToViewModel(this PagedList<Categorie> modelDonnee)
        {
            PagedList<CategorieElementDeListeVM> viewModel = null;
            if (modelDonnee != null)
            {
                viewModel = new PagedList<CategorieElementDeListeVM>();
                List<CategorieElementDeListeVM> tempList = new List<CategorieElementDeListeVM>();
                viewModel.Total = modelDonnee.Total;
                viewModel.PageIndex = modelDonnee.PageIndex;
                viewModel.PageCount = modelDonnee.PageCount;
                foreach (Categorie model in modelDonnee.PagedData)
                {
                    tempList.Add(new CategorieElementDeListeVM()
                    {
                        CategorieID = model.Id,
                        Nom = model.Nom,
                        Description = model.Description

                    });
                }
                viewModel.PagedData = tempList.AsEnumerable();
            }

            return viewModel;
        }

        public static IEnumerable<ListItem> ToSelectListItem(this IEnumerable<Categorie> modelDonnee)
        {
            List<ListItem> viewModel = null;
            if (modelDonnee != null)
            {
                viewModel = new List<ListItem>();

                foreach (Categorie model in modelDonnee)
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