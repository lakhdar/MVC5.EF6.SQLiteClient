namespace Infrastructure.Donnee
{
    using Domain;
    using Log;

    /// <summary>
    /// implementation du repository Categorie
    /// </summary>
    public class CategorieRepository : Repository<Categorie>, ICategorieRepository
    {
        #region Constructeur

        /// <summary>
        /// Creer une nouvelle instance de CategorieRepository
        /// </summary>
        /// <param name="unitOfWork">unit of work Associee </param>
        /// <param name="logger"> logger Associee </param>
        public CategorieRepository(UnitOfWorkSQLite unitOfWork, ILogger logger)
            : base(unitOfWork, logger)
        {
        }

        #endregion
    }
}
