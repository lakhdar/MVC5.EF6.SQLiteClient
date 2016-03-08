namespace Infrastructure.Donnee
{
    using Domain;
    using Log;

    /// <summary>
    /// implementation du repository Produit
    /// </summary>
    public class ProduitRepository: Repository<Produit>, IProduitRepository
    {
        #region Constructeur

        /// <summary>
        /// Creer une nouvelle instance de ProduitRepository
        /// </summary>
        /// <param name="unitOfWork">unit of work Associee </param>
        /// <param name="logger"> logger Associee </param>
        public ProduitRepository(UnitOfWorkSQLite unitOfWork, ILogger logger)
            : base(unitOfWork, logger)
        {
        }

        #endregion
    }
}
