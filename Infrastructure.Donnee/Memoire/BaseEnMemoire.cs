

namespace Infrastructure.Donnee
{
    using Domain;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class BaseEnMemoire
    {
        #region Champs
        private List<Categorie> _categories;
        private List<Client> _clients;
        private List<Commande> _commandes;
        private List<Fournisseur> _fournisseurs;
        private List<Produit> _produits;
        private List<CommandeProduit> _commandeProduits;

        #endregion
       

        #region Properietes


        public string DataDirectory
        {
            get
            {
                return (string)AppDomain.CurrentDomain.GetData("DataDirectory");
            }
        }
        public List<Categorie> Categories
        {
            get
            {
                if (this._categories == null)
                {
                    string clientJSon = File.ReadAllText(Path.Combine(this.DataDirectory, "Categories.json"));
                    this._categories = JsonConvert.DeserializeObject<List<Categorie>>(clientJSon);  
                }

                return this._categories;
            }
        }

        public List<Client> Clients
        {
            get
            {
                if (this._clients == null)
                {
                   
                    string clientJSon = File.ReadAllText(Path.Combine(this.DataDirectory, "Client.json"));
                    this._clients = JsonConvert.DeserializeObject<List<Client>>(clientJSon);
                     foreach(Client cl in this._clients)
                    {
                        cl.Commandes = this.Commandes.Where(x => x.ClientID == cl.Id).ToList();
                    }
                }
                return this._clients;
            }
        }

        public List<Commande> Commandes
        {
            get
            {
                if (this._commandes == null)
                {

                    string clientJSon = File.ReadAllText(Path.Combine(this.DataDirectory, "Commandes.json"));
                    this._commandes = JsonConvert.DeserializeObject<List<Commande>>(clientJSon);
                    foreach (Commande cl in this._commandes)
                    {
                        cl.CommandeProduits = this.CommandeProduits.Where(x => x.CommandeID == cl.Id).ToList();
                    }
                }

                return this._commandes;
            }
        }



        public List<Fournisseur> Fournisseurs
        {
            get
            {
                if (this._fournisseurs == null)
                {
                    string clientJSon = File.ReadAllText(Path.Combine(this.DataDirectory, "fournisseurs.json"));
                    this._fournisseurs = JsonConvert.DeserializeObject<List<Fournisseur>>(clientJSon);
                    foreach (Fournisseur cl in this._fournisseurs)
                    {
                        cl.Produits = this.Produits.Where(x => x.FournisseurID == cl.Id).ToList();
                    }
                }
                return this._fournisseurs;
            }
        }

        public List<Produit> Produits
        {
            get
            {
                

                if (this._produits == null)
                {
                    string clientJSon = File.ReadAllText(Path.Combine(this.DataDirectory, "Produit.json"));
                    this._produits = JsonConvert.DeserializeObject<List<Produit>>(clientJSon);
                    foreach (Produit cl in this._produits)
                    {
                        cl.Categorie = this.Categories.FirstOrDefault(x => x.Id== cl.Id) ;
                        cl.CommandeProduits = this.CommandeProduits.Where(x => x.ProduitID == cl.Id).ToList();
                    }
                }
                return this._produits;
            }
        }

        public List<CommandeProduit> CommandeProduits
        {
            get
            {
                if (this._commandeProduits == null)
                {
                    string clientJSon = File.ReadAllText(Path.Combine(this.DataDirectory, "CommandeProduits.json"));
                    this._commandeProduits = JsonConvert.DeserializeObject<List<CommandeProduit>>(clientJSon);
                }

                return this._commandeProduits;
            }
        }


        #endregion
    }
}
