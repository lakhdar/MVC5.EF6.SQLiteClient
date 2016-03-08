using Domain;
using SQLiteClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQLiteClient.Extension
{
    public static class ExtensionClient
    {

        public static IEnumerable<ClientElementDeListeVM> ToViewModel(this IEnumerable<Client> modelDonnee)
        {
            List<ClientElementDeListeVM> viewModel = null;
            if (modelDonnee != null)
            {
                viewModel = new List<ClientElementDeListeVM>();

                foreach (Client model in modelDonnee)
                {
                    viewModel.Add(new ClientElementDeListeVM()
                    {
                        ClientID = model.Id,
                        Contact = model.Contact,
                        Compagnie = model.Nom,
                        Telephone = model.Telephone,
                        Adresse = model.Adresse + "  " + model.Ville + "  " + model.CodePostal + "  " + model.Pays,
                        TotalCommandes = (model.Commandes == null) ? 0 : model.Commandes.Count()

                    });
                }

            }

            return viewModel;
        }

        public static ClientElementDeListeVM ToViewModel(this Client model)
        {
            ClientElementDeListeVM viewModel = null;
            if (model != null)
            {
                viewModel = new ClientElementDeListeVM()
                {
                    ClientID = model.Id,
                    Contact = model.Contact,
                    Compagnie = model.Nom,
                    Telephone = model.Telephone,
                    Adresse = model.Adresse + "  " + model.Ville + "  " + model.CodePostal + "  " + model.Pays,
                    TotalCommandes = (model.Commandes == null) ? 0 : model.Commandes.Count()

                };
            }

            return viewModel;
        }


        public static PagedList<ClientElementDeListeVM> ToViewModel(this PagedList<Client> modelDonnee)
        {
            PagedList<ClientElementDeListeVM> viewModel = null;
            if (modelDonnee != null)
            {
                viewModel = new PagedList<ClientElementDeListeVM>();
                List<ClientElementDeListeVM> tempList = new List<ClientElementDeListeVM>();
                viewModel.Total = modelDonnee.Total;
                viewModel.PageIndex = modelDonnee.PageIndex;
                viewModel.PageCount = modelDonnee.PageCount;
                foreach (Client model in modelDonnee.PagedData)
                {
                    tempList.Add(new ClientElementDeListeVM()
                    {
                        ClientID = model.Id,
                        Contact = model.Contact,
                        Compagnie = model.Nom,
                        Telephone = model.Telephone,
                        Adresse = model.Adresse + "  " + model.Ville + "  " + model.CodePostal + "  " + model.Pays,
                        TotalCommandes = (model.Commandes == null) ? 0 : model.Commandes.Count()

                    });
                }
                viewModel.PagedData = tempList.AsEnumerable();
            }

            return viewModel;
        }





        public static Client ToDataModel(this ClientCreationVM model)
        {
            Client viewModel = null;
            if (model != null)
            {
                viewModel = new Client()
                {
                    Id = model.ClientID,
                    Contact = model.Contact,
                    Nom = model.Compagnie,
                    Telephone = model.Telephone,
                    Adresse = model.Adresse,
                    Ville = model.Ville,
                    CodePostal = model.CodePostal,
                    Pays = model.Pays,
                };
            }

            return viewModel;
        }
    }
}