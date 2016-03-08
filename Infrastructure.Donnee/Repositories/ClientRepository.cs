namespace Infrastructure.Donnee
{
    using Domain;
    using Log;

    /// <summary>
    /// implementation du repository Client
    /// </summary>
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        #region Constructeur

        /// <summary>
        /// Creer une nouvelle instance de ClientRepository
        /// </summary>
        /// <param name="unitOfWork">unit of work Associee </param>
        /// <param name="logger"> logger Associee </param>
        public ClientRepository(UnitOfWorkSQLite unitOfWork, ILogger logger)
            : base(unitOfWork, logger)
        {
        }

        #endregion
    }
}
