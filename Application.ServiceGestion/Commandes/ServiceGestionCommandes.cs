namespace Application.ServiceGestion
{
    using Domain;
    using Infrastructure.Log;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// <see cref="Application.ServiceGestion.IServiceGestionCommandes"/>
    /// </summary>
    public class ServiceGestionCommandes : IServiceGestionCommandes
    {

        #region Champs
        private ICommandeRepository _commandeRepository;
        private ILogger _logger;
        #endregion


        #region Constructeur
        public ServiceGestionCommandes(ICommandeRepository commandeRepository, ILogger logger)
        {
            if (commandeRepository == (ICommandeRepository)null)
                throw new ArgumentNullException("commandeRepository");
            if (logger == (ILogger)null)
                throw new ArgumentNullException("logger");
            this._commandeRepository = commandeRepository;
            this._logger = logger;
        }
        #endregion


        #region Methodes

        /// <summary>
        /// <see cref="Application.ServiceGestion.IServiceGestionCommandes"/>
        /// </summary>
        /// <param name="commande"><see cref="Application.ServiceGestion.IServiceGestionCommandes"/></param>
        public void Ajouter(Commande commande)
        {
            if (commande == (Commande)null)
                throw new ArgumentNullException("Commande");

            this._commandeRepository.Ajouter(commande);
            this._commandeRepository.UnitOfWork.Engager();
        }

        /// <summary>
        /// <see cref="Application.ServiceGestion.IServiceGestionCommandes"/>
        /// </summary>
        /// <param name="indexPage"><see cref="Application.ServiceGestion.IServiceGestionCommandes"/></param>
        /// <param name="tailePage"><see cref="Application.ServiceGestion.IServiceGestionCommandes"/></param>
        /// <returns><see cref="Application.ServiceGestion.IServiceGestionCommandes"/></returns>
        public IEnumerable<Commande> ListPaginee(int indexPage, int tailePage)
        {
            if (tailePage <= 0)
                throw new ArgumentNullException("tailePage");
            return this._commandeRepository.GetPagedElements(indexPage, tailePage,p=>p.DateCommande, true);
        }

        /// <summary>
        /// <see cref="Application.ServiceGestion.IServiceGestionCommandes"
        /// </summary>
        /// <param name="id"><see cref="Application.ServiceGestion.IServiceGestionCommandes"</param>
        /// <returns><see cref="Application.ServiceGestion.IServiceGestionCommandes"</returns>
        public Commande GetElementById(int id)
        {
            return this._commandeRepository.GetElementById(id);
        }

        /// <summary>
        /// <see cref="Application.ServiceGestion.IServiceGestionCommandes"/>
        /// </summary>
        /// <param name="indexPage"><see cref="Application.ServiceGestion.IServiceGestionCommandes"/></param>
        /// <param name="tailePage"><see cref="Application.ServiceGestion.IServiceGestionCommandes"/></param>
        /// <returns><see cref="Application.ServiceGestion.IServiceGestionCommandes"/></returns>
        public PagedList<Commande> ListPagineeAvecTotal(int indexPage, int tailePage)
        {
            if (tailePage <= 0)
                throw new ArgumentNullException("tailePage");
            return this._commandeRepository.GetPagedList(indexPage, tailePage, p => p.DateCommande, true);
        }
        #endregion
    }
}
