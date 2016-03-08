
namespace Infrastructure.Dependances
{


    /// <summary>
    /// Description de la classe DependanceFactory
    /// </summary>
    public sealed class DependanceFactory
    {
        #region Singleton

        static readonly DependanceFactory instance = new DependanceFactory();

        /// <summary>
        /// Get singleton instance of IoCFactory
        /// </summary>
        public static DependanceFactory Instance
        {
            get
            {
                return instance;
            }
        }

        #endregion

        #region Champs

        IContainer _ContainerActuel;

        /// <summary>
        /// Le container actuel configuré  
        /// </summary>
        public IContainer ContainerActuel
        {
            get
            {
                return _ContainerActuel;
            }
        }

        #endregion

        #region Constructeur

        /// <summary>
        /// Un constructeur pour initialiser le Singleton
        /// </summary>
        static DependanceFactory() { }
        DependanceFactory()
        {
            _ContainerActuel = new DependanceContainer();
        }

        #endregion
    }
}
