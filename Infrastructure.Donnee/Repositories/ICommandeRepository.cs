namespace Infrastructure.Donnee
{
    using Domain;
    using Log;

    /// <summary>
    /// implementation du repository Fournisseur
    /// </summary>
    public class FournisseurRepository : Repository<Fournisseur>, IFournisseurRepository
    {
        #region Constructeur

        /// <summary>
        /// Creer une nouvelle instance de FournisseurRepository
        /// </summary>
        /// <param name="unitOfWork">unit of work Associee </param>
        /// <param name="logger"> logger Associee </param>
        public FournisseurRepository(UnitOfWorkSQLite unitOfWork, ILogger logger)
            : base(unitOfWork, logger)
        {
        }

        #endregion
    }
}
