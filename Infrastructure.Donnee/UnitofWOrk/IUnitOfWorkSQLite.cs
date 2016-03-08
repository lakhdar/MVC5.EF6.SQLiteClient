namespace Infrastructure.Donnee
{
    using Domain;
    using System;
    using System.Data.Entity;

    public interface IUnitOfWorkSQLite : IQueryableUnitOfWork, IUnitOfWork, IDisposable 
    {
        IDbSet<Categorie> Categories { get; }

        IDbSet<Client> Clients { get; }

        IDbSet<Commande> Commandes { get; }

        IDbSet<Fournisseur> Fournisseurs { get; }

        IDbSet<Produit> Produits { get; }

        IDbSet<CommandeProduit> CommandeProduits { get; }
 
       
    }
}
