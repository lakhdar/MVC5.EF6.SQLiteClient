

namespace Infrastructure.Dependances
{
    using Application.ServiceGestion;
    using Domain;
    using Donnee;
    using Log;
    using Microsoft.Practices.Unity;
    using Resources;
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    /// <summary>
    /// Implemented container in Microsoft Practices Unity
    /// </summary>
    sealed class DependanceContainer
        :IContainer
    {
        #region Champs

        IDictionary<string, IUnityContainer> _DictionaireContainer;


        #endregion

        #region Constructeur

        /// <summary>
        /// Creer une instance de DependanceContainer
        /// </summary>
        public DependanceContainer()
        {
            _DictionaireContainer = new Dictionary<string, IUnityContainer>();

            IUnityContainer  containerRacine = new UnityContainer();
            _DictionaireContainer.Add("ContextBase", containerRacine);

            IUnityContainer containerApplicationReelle = containerRacine.CreateChildContainer();
            _DictionaireContainer.Add("containerApplicationReelle", containerApplicationReelle);

                //Create container for testing, child of root container
            IUnityContainer containerApplicationTest = containerRacine.CreateChildContainer();
            _DictionaireContainer.Add("containerApplicationTest", containerApplicationTest);
            ConfigurerContainerRacine(containerRacine);
            ConfigureContainerReel(containerApplicationReelle);
            ConfigureContainerTest(containerApplicationTest);
        }

        #endregion

        #region Methodes Privées

        /// <summary>
        /// Configurer le container racine .Enregistrer les types et leurs cycles de vie
        /// </summary>
        /// <param name="container"> Le container a configurer</param>
        void ConfigurerContainerRacine(IUnityContainer container)
        {
            ////repositories
            container.RegisterType<IProduitRepository, ProduitRepository>(new TransientLifetimeManager());
            container.RegisterType<IFournisseurRepository, FournisseurRepository>(new TransientLifetimeManager());
            container.RegisterType<ICommandeRepository, CommandeRepository>(new TransientLifetimeManager());
            container.RegisterType<IClientRepository, ClientRepository>(new TransientLifetimeManager());
            container.RegisterType<ICategorieRepository, CategorieRepository>(new TransientLifetimeManager());
            container.RegisterType<ILogger, Logger>(new TransientLifetimeManager());

            ////GEstion
            container.RegisterType<IServiceGestionProduits,  ServiceGestionProduits>(new TransientLifetimeManager());
            container.RegisterType<IServiceGestionCategories, ServiceGestionCategories>(new TransientLifetimeManager());
            container.RegisterType<IServiceGestionFournisseurs, ServiceGestionFournisseurs>(new TransientLifetimeManager());
            container.RegisterType<IServiceGestionClients, ServiceGestionClients>(new TransientLifetimeManager());
            container.RegisterType<IServiceGestionCommandes, ServiceGestionCommandes>(new TransientLifetimeManager());

        }

        /// <summary>
        /// Configurer le container pour l application qui s'excute reellement .Enregistrer les types et leurs cycles de vie
        /// </summary>
        /// <param name="container">Le container a configurer</param>
        void ConfigureContainerReel(IUnityContainer container)
        {
           container.RegisterType<IUnitOfWorkSQLite, UnitOfWorkSQLite>(new HierarchicalLifetimeManager(), new InjectionConstructor());
        }

        /// <summary>
        /// Configurer le container pour les tests .Enregistrer les types et leurs cycles de vie
        /// </summary>
        /// <param name="container">Le container a configurer</param>
        void ConfigureContainerTest(IUnityContainer container)
        {
           
        }

        #endregion

        #region   Membres de IContainer

        /// <summary>
        /// <see cref="M:Infrastructure.Dependances.IContainer.Resoudre{TObject}"/>
        /// </summary>
        /// <typeparam name="TObject"><see cref="M:Infrastructure.Dependances.IContainer.Resoudre{TObject}"/></typeparam>
        /// <returns><see cref="M:Infrastructure.Dependances.Resoudre{TObject}"/></returns>
        public TObject Resoudre<TObject>()
        {
            //We use the default container specified in AppSettings
            string containerName = ConfigurationManager.AppSettings["ContainerActuel"];

            if (String.IsNullOrEmpty(containerName)
                ||
                String.IsNullOrWhiteSpace(containerName))
            {
                containerName = "containerApplicationReelle";
            }

            if (!_DictionaireContainer.ContainsKey(containerName))
                throw new InvalidOperationException(Messages.ContainerIntrouvable);

            IUnityContainer container = _DictionaireContainer[containerName];

            return container.Resolve<TObject>();
        }
        /// <summary>
        /// <see cref="M:Infrastructure.Dependances.IContainer.Resoudre"/>
        /// </summary>
        /// <param name="type"><see cref="M:Infrastructure.Dependances.IContainer.Resoudre"/></param>
        /// <returns><see cref="M:Infrastructure.Dependances.IContainer.Resoudre"/></returns>
        public object Resoudre(Type type)
        {
            string containerName = ConfigurationManager.AppSettings["ContainerActuel"];

            if (String.IsNullOrEmpty(containerName)
                ||
                String.IsNullOrWhiteSpace(containerName))
            {
                containerName = "containerApplicationReelle";
            }

            if (!_DictionaireContainer.ContainsKey(containerName))
                throw new InvalidOperationException(Messages.ContainerIntrouvable);

            IUnityContainer container = _DictionaireContainer[containerName];

            return container.Resolve(type, null);
        }

        /// <summary>
        /// <see cref="M:Infrastructure.Dependances.IContainer.EnregisterType"/>
        /// </summary>
        /// <param name="type"><see cref="M:Infrastructure.Dependances.IContainer.EnregisterType"/></param>
        public void EnregisterType(Type type)
        {
            IUnityContainer container = this._DictionaireContainer["ContextBase"];

            if (container != null)
                container.RegisterType(type, new TransientLifetimeManager());
        }

        /// <summary>
        /// <see cref="M:Infrastructure.Dependances.IContainer.ResoudreTout"/>
        /// </summary>
        /// <param name="type"><see cref="M:Infrastructure.Dependances.IContainer.ResoudreTout"/></param>
        public IEnumerable<object> ResoudreTout(Type type)
        {
            string containerName = ConfigurationManager.AppSettings["ContainerActuel"];

            if (String.IsNullOrEmpty(containerName)
                ||
                String.IsNullOrWhiteSpace(containerName))
            {
                containerName = "containerApplicationReelle";
            }

            if (!_DictionaireContainer.ContainsKey(containerName))
                throw new InvalidOperationException(Messages.ContainerIntrouvable);

            IUnityContainer container = _DictionaireContainer[containerName];

            return container.ResolveAll(type);
        }

        /// <summary>
        /// <see cref="M:Infrastructure.Dependances.IContainer.CreerContainerEnfant"/>
        /// </summary>
        /// <return><see cref="M:Infrastructure.Dependances.IContainer.CreerContainerEnfant"/></return>
        public IContainer CreerContainerEnfant()
        {
            return this; 
        }


        /// <summary>
        /// <see cref="M:Infrastructure.Dependances.EnregisterInstance"/>
        /// </summary>
        /// <typeparam name="TFrom"> <see cref="M:Infrastructure.Dependances.EnregisterInstance"/></typeparam>
        /// <typeparam name="TTo"> <see cref="M:Infrastructure.Dependances.EnregisterInstance"/></typeparam>
        public void EnregisterInstance<TFrom, TTo>() where TTo : TFrom
        {
            IUnityContainer container = this._DictionaireContainer["ContextBase"];
            if (container == null)
                return;

            container.RegisterType<TFrom, TTo>(new TransientLifetimeManager());
        }


        public void Dispose()
        {
        }

        #endregion




       
    }
}

