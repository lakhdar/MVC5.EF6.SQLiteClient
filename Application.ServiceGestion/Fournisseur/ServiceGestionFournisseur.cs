namespace Application.ServiceGestion
{
    using Domain;
    using Infrastructure.Log;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// <see cref="Application.ServiceGestion.IServiceGestionFournisseurs"/>
    /// </summary>
    public class ServiceGestionFournisseurs : IServiceGestionFournisseurs
    {

        #region Champs
        private IFournisseurRepository _fournisseurRepository;
        private ILogger _logger;
        #endregion


        #region Constructeur
        public ServiceGestionFournisseurs(IFournisseurRepository fournisseurRepository, ILogger logger)
        {
            if (fournisseurRepository == (IFournisseurRepository)null)
                throw new ArgumentNullException("fournisseurRepository");
            if (logger == (ILogger)null)
                throw new ArgumentNullException("logger");
            this._fournisseurRepository = fournisseurRepository;
            this._logger = logger;
        }
        #endregion


        #region Methodes

        /// <summary>
        /// <see cref="Application.ServiceGestion.IServiceGestionFournisseurs"/>
        /// </summary>
        /// <param name="item"><see cref="Application.ServiceGestion.IServiceGestionProduits"/></param>
        public void Ajouter(Fournisseur fournisseur)
        {
            if (fournisseur == (Fournisseur)null)
                throw new ArgumentNullException("Categorie");

            this._fournisseurRepository.Ajouter(fournisseur);
            this._fournisseurRepository.UnitOfWork.Engager();
        }

        /// <summary>
        /// <see cref="Application.ServiceGestion.IServiceGestionFournisseurs"/>
        /// </summary>
        /// <param name="indexPage"><see cref="Application.ServiceGestion.IServiceGestionFournisseurs"/></param>
        /// <param name="tailePage"><see cref="Application.ServiceGestion.IServiceGestionFournisseurs"/></param>
        /// <returns><see cref="Application.ServiceGestion.IServiceGestionFournisseurs"/></returns>
        public IEnumerable<Fournisseur> ListPaginee(int indexPage, int tailePage)
        {
            if (tailePage <= 0)
                throw new ArgumentNullException("tailePage");
            return this._fournisseurRepository.GetPagedElements(indexPage, tailePage,p=>p.Nom, true);
        }

        /// <summary>
        /// <see cref="Application.ServiceGestion.IServiceGestionFournisseurs"
        /// </summary>
        /// <param name="id"><see cref="Application.ServiceGestion.IServiceGestionFournisseurs"</param>
        /// <returns><see cref="Application.ServiceGestion.IServiceGestionFournisseurs"</returns>
        public Fournisseur GetElementById(int id)
        {
            return this._fournisseurRepository.GetElementById(id);
        }

        /// <summary>
        /// <see cref="Application.ServiceGestion.IServiceGestionFournisseurs"/>
        /// </summary>
        /// <param name="indexPage"><see cref="Application.ServiceGestion.IServiceGestionFournisseurs"/></param>
        /// <param name="tailePage"><see cref="Application.ServiceGestion.IServiceGestionFournisseurs"/></param>
        /// <returns><see cref="Application.ServiceGestion.IServiceGestionFournisseurs"/></returns>
        public PagedList<Fournisseur> ListPagineeAvecTotal(int indexPage, int tailePage)
        {
            if (tailePage <= 0)
                throw new ArgumentNullException("tailePage");
            return this._fournisseurRepository.GetPagedList(indexPage, tailePage, p => p.Nom, true,x=>x.Produits);
        }
        #endregion
    }
}
