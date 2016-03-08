using Domain;
using Infrastructure.Donnee.Resources;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Infrastructure.Donnee
{
    public class UnitOfWorkSQLite : DbContext, IUnitOfWorkSQLite
    {
        #region Champs
        private IDbSet<Categorie> _categories;
        private IDbSet<Client> _clients;
        private IDbSet<Commande> _commandes;
        private IDbSet<Fournisseur> _fournisseurs;
        private IDbSet<Produit> _produits;
        private IDbSet<CommandeProduit> _commandeProduits;
 
        #endregion

        #region Properietes
        public IDbSet<Categorie> Categories
        {
            get
            {
                if (this._categories == null)
                    this._categories = (IDbSet<Categorie>)this.Set<Categorie>();
                return this._categories;
            }
        }

        public IDbSet<Client> Clients
        {
            get
            {
                if (this._clients == null)
                    this._clients = (IDbSet<Client>)this.Set<Client>();
                return this._clients;
            }
        }

        public IDbSet<Commande> Commandes
        {
            get
            {
                if (this._commandes == null)
                    this._commandes = (IDbSet<Commande>)this.Set<Commande>();
                return this._commandes;
            }
        }



        public IDbSet<Fournisseur> Fournisseurs
        {
            get
            {
                if (this._fournisseurs == null)
                    this._fournisseurs = (IDbSet<Fournisseur>)this.Set<Fournisseur>();
                return this._fournisseurs;
            }
        }

        public IDbSet<Produit> Produits
        {
            get
            {
                if (this._produits == null)
                    this._produits = (IDbSet<Produit>)this.Set<Produit>();
                return this._produits;
            }
        }

        public IDbSet<CommandeProduit> CommandeProduits
        {
            get
            {
                if (this._commandeProduits == null)
                    this._commandeProduits = (IDbSet<CommandeProduit>)this.Set<CommandeProduit>();
                return this._commandeProduits;
            }
        }


        #endregion

        #region Constructeur
        public UnitOfWorkSQLite()
            : base("gestionStockDB")
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }
        #endregion


        #region IQueryableUnitOfWork
        public virtual IDbSet<TEntity> CreateSet<TEntity>() where TEntity : class
        {
            return (IDbSet<TEntity>)this.Set<TEntity>();
        }

        public virtual void Attach<TEntity>(TEntity item) where TEntity : class
        {
            this.Entry<TEntity>(item).State = EntityState.Unchanged;
        }

        public virtual void SetModified<TEntity>(TEntity item) where TEntity : class
        {
            this.Entry<TEntity>(item).State = EntityState.Modified;
        }

        public virtual void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : class
        {
            this.Entry<TEntity>(original).CurrentValues.SetValues((object)current);
        }

        #endregion

        #region IUnitOfWork
        public virtual void Engager()
        {
            try
            {
                this.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                throw this.GetDBValidationExptions(ex);
            }
        }

       

        
 

        #endregion

        

        #region DbContext
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions..ForeignKeyIndexConvention>();
            var initializer = new UnitOfWorkSQLiteInitialiseur(modelBuilder);
            Database.SetInitializer(initializer);
        }

        #endregion

        #region local
        private Exception GetDBValidationExptions(DbEntityValidationException dbEx)
        {
            string message = string.Empty;
            foreach (DbEntityValidationResult validationResult in dbEx.EntityValidationErrors)
            {
                foreach (DbValidationError dbValidationError in (IEnumerable<DbValidationError>)validationResult.ValidationErrors)
                    message = message + string.Format("Properiete: {0} Erreur: {1}", (object)dbValidationError.PropertyName, (object)dbValidationError.ErrorMessage);
            }
            return new Exception(Messages.ErreurDeValidation, new Exception(message));
        }

        #endregion
    }
}
