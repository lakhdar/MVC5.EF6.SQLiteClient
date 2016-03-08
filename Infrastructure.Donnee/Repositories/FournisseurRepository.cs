namespace Infrastructure.Donnee
{
    using Domain;
    using Log;

    /// <summary>
    /// implementation du repository Commande
    /// </summary>
    public class CommandeRepository : Repository<Commande>, ICommandeRepository
    {
        #region Constructeur

        /// <summary>
        /// Creer une nouvelle instance de CommandeRepository
        /// </summary>
        /// <param name="unitOfWork">unit of work Associee </param>
        /// <param name="logger"> logger Associee </param>
        public CommandeRepository(UnitOfWorkSQLite unitOfWork, ILogger logger)
            : base(unitOfWork, logger)
        {
        }

        #endregion
    }
}
