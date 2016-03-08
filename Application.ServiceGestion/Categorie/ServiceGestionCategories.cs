namespace Application.ServiceGestion
{
    using Domain;
    using Infrastructure.Log;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// <see cref="Application.ServiceGestion.IServiceGestionCategories"/>
    /// </summary>
    public class ServiceGestionCategories : IServiceGestionCategories
    {

        #region Champs
        private ICategorieRepository _categorieRepository;
        private ILogger _logger;
        #endregion


        #region Constructeur
        public ServiceGestionCategories(ICategorieRepository  categorieRepository, ILogger logger)
        {
            if (categorieRepository == (ICategorieRepository)null)
                throw new ArgumentNullException("categorieRepository");
            if (logger == (ILogger)null)
                throw new ArgumentNullException("logger");
            this._categorieRepository = categorieRepository;
            this._logger = logger;
        }
        #endregion


        #region Methodes

        /// <summary>
        /// <see cref="Application.ServiceGestion.IServiceGestionProduits"/>
        /// </summary>
        /// <param name="item"><see cref="Application.ServiceGestion.IServiceGestionProduits"/></param>
        public void Ajouter(Categorie categorie)
        {
            if (categorie == (Categorie)null)
                throw new ArgumentNullException("Categorie");

            this._categorieRepository.Ajouter(categorie);
            this._categorieRepository.UnitOfWork.Engager();
        }

        /// <summary>
        /// <see cref="Application.ServiceGestion.IServiceGestionProduits"/>
        /// </summary>
        /// <param name="indexPage"><see cref="Application.ServiceGestion.IServiceGestionProduits"/></param>
        /// <param name="tailePage"><see cref="Application.ServiceGestion.IServiceGestionProduits"/></param>
        /// <returns><see cref="Application.ServiceGestion.IServiceGestionProduits"/></returns>
        public IEnumerable<Categorie> ListPaginee(int indexPage, int tailePage)
        {
            if (tailePage <= 0)
                throw new ArgumentNullException("tailePage");
            return this._categorieRepository.GetPagedElements(indexPage, tailePage,p=>p.Nom, true);
        }

        /// <summary>
        /// <see cref="Application.ServiceGestion.IServiceGestionProduits"
        /// </summary>
        /// <param name="id"><see cref="Application.ServiceGestion.IServiceGestionProduits"</param>
        /// <returns><see cref="Application.ServiceGestion.IServiceGestionProduits"</returns>
        public Categorie GetElementById(int id)
        {
            return this._categorieRepository.GetElementById(id);
        }

        /// <summary>
        /// <see cref="Application.ServiceGestion.IServiceGestionProduits"/>
        /// </summary>
        /// <param name="indexPage"><see cref="Application.ServiceGestion.IServiceGestionProduits"/></param>
        /// <param name="tailePage"><see cref="Application.ServiceGestion.IServiceGestionProduits"/></param>
        /// <returns><see cref="Application.ServiceGestion.IServiceGestionProduits"/></returns>
        public PagedList<Categorie> ListPagineeAvecTotal(int indexPage, int tailePage)
        {
            if (tailePage <= 0)
                throw new ArgumentNullException("tailePage");
            return this._categorieRepository.GetPagedList(indexPage, tailePage, p => p.Nom, true);
        }
        #endregion
    }
}
