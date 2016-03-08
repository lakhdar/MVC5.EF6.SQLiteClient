namespace Application.ServiceGestion
{
    using Domain;
    using Infrastructure.Log;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// <see cref="Application.ServiceGestion.IServiceGestionClients"/>
    /// </summary>
    public class ServiceGestionClients : IServiceGestionClients
    {

        #region Champs
        private IClientRepository _clientRepository;
        private ILogger _logger;
        #endregion


        #region Constructeur
        public ServiceGestionClients(IClientRepository clientRepository, ILogger logger)
        {
            if (clientRepository == (IClientRepository)null)
                throw new ArgumentNullException("clientRepository");
            if (logger == (ILogger)null)
                throw new ArgumentNullException("logger");
            this._clientRepository = clientRepository;
            this._logger = logger;
        }
        #endregion


        #region Methodes

        /// <summary>
        /// <see cref="Application.ServiceGestion.IServiceGestionClients"/>
        /// </summary>
        /// <param name="client"><see cref="Application.ServiceGestion.IServiceGestionClients"/></param>
        public void Ajouter(Client client)
        {
            if (client == (Client)null)
                throw new ArgumentNullException("client");

            this._clientRepository.Ajouter(client);
            this._clientRepository.UnitOfWork.Engager();
        }

        /// <summary>
        /// <see cref="Application.ServiceGestion.IServiceGestionClients"/>
        /// </summary>
        /// <param name="indexPage"><see cref="Application.ServiceGestion.IServiceGestionClients"/></param>
        /// <param name="tailePage"><see cref="Application.ServiceGestion.IServiceGestionClients"/></param>
        /// <returns><see cref="Application.ServiceGestion.IServiceGestionClients"/></returns>
        public IEnumerable<Client> ListPaginee(int indexPage, int tailePage)
        {
            if (tailePage <= 0)
                throw new ArgumentNullException("tailePage");
            return this._clientRepository.GetPagedElements(indexPage, tailePage,p=>p.Nom, true);
        }

        /// <summary>
        /// <see cref="Application.ServiceGestion.IServiceGestionClients"
        /// </summary>
        /// <param name="id"><see cref="Application.ServiceGestion.IServiceGestionClients"</param>
        /// <returns><see cref="Application.ServiceGestion.IServiceGestionClients"</returns>
        public Client GetElementById(int id)
        {
            return this._clientRepository.GetFilteredElements(x=>x.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// <see cref="Application.ServiceGestion.IServiceGestionClients"/>
        /// </summary>
        /// <param name="indexPage"><see cref="Application.ServiceGestion.IServiceGestionClients"/></param>
        /// <param name="tailePage"><see cref="Application.ServiceGestion.IServiceGestionClients"/></param>
        /// <returns><see cref="Application.ServiceGestion.IServiceGestionClients"/></returns>
        public PagedList<Client> ListPagineeAvecTotal(int indexPage, int tailePage)
        {
            if (tailePage <= 0)
                throw new ArgumentNullException("tailePage");
            return this._clientRepository.GetPagedList(indexPage, tailePage, p => p.Nom, true,x=>x.Commandes);
        }
        #endregion
    }
}
