namespace Application.ServiceGestion
{
    using Domain;
    using Infrastructure.Log;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// <see cref="Application.ServiceGestion.IServiceGestionProduits"/>
    /// </summary>
    public class ServiceGestionProduits : IServiceGestionProduits
    {

        #region Champs
        private IProduitRepository _produitRepository;
        private ILogger _logger;
        #endregion


        #region Constructeur
        public ServiceGestionProduits(IProduitRepository produitRepository, ILogger logger)
        {
            if (produitRepository == (IProduitRepository)null)
                throw new ArgumentNullException("produitRepository");
            if (logger == (ILogger)null)
                throw new ArgumentNullException("logger");
            this._produitRepository = produitRepository;
            this._logger = logger;
        }
        #endregion


        #region Methodes

        /// <summary>
        /// <see cref="Application.ServiceGestion.IServiceGestionProduits"/>
        /// </summary>
        /// <param name="item"><see cref="Application.ServiceGestion.IServiceGestionProduits"/></param>
        public void Ajouter(Produit produit)
        {
            if (produit == (Produit)null)
                throw new ArgumentNullException("produit");

            this._produitRepository.Ajouter(produit);
            this._produitRepository.UnitOfWork.Engager();
        }

        /// <summary>
        /// <see cref="Application.ServiceGestion.IServiceGestionProduits"/>
        /// </summary>
        /// <param name="indexPage"><see cref="Application.ServiceGestion.IServiceGestionProduits"/></param>
        /// <param name="tailePage"><see cref="Application.ServiceGestion.IServiceGestionProduits"/></param>
        /// <returns><see cref="Application.ServiceGestion.IServiceGestionProduits"/></returns>
        public IEnumerable<Produit> ListPaginee(int indexPage, int tailePage)
        {
            if (tailePage <= 0)
                throw new ArgumentNullException("tailePage");
            return this._produitRepository.GetPagedElements(indexPage, tailePage,p=>p.Nom, true);
        }

        /// <summary>
        /// <see cref="Application.ServiceGestion.IServiceGestionProduits"
        /// </summary>
        /// <param name="id"><see cref="Application.ServiceGestion.IServiceGestionProduits"</param>
        /// <returns><see cref="Application.ServiceGestion.IServiceGestionProduits"</returns>
        public Produit GetElementById(int id)
        {
            return this._produitRepository.GetElementById(id);
        }

        /// <summary>
        /// <see cref="Application.ServiceGestion.IServiceGestionProduits"/>
        /// </summary>
        /// <param name="indexPage"><see cref="Application.ServiceGestion.IServiceGestionProduits"/></param>
        /// <param name="tailePage"><see cref="Application.ServiceGestion.IServiceGestionProduits"/></param>
        /// <returns><see cref="Application.ServiceGestion.IServiceGestionProduits"/></returns>
        public PagedList<Produit> ListPagineeAvecTotal(int indexPage, int tailePage)
        {
            if (tailePage <= 0)
                throw new ArgumentNullException("tailePage");
            return this._produitRepository.GetPagedList(indexPage, tailePage, p => p.Nom, true,x=>x.Fournisseur,x=>x.Categorie,x=>x.CommandeProduits);
        }
        #endregion
    }
}
