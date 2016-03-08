using System.Collections.Generic;

namespace Domain
{

    /// <summary>
    ///  Une liste paginée
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <typeparam name="TEntity">Entitie generique pour ceette liste paginée</typeparam>
    public class PagedList<TEntity>
        where TEntity : class
    {
        public int Total { get; set; }
        public int PageIndex { get; set; }
        public int PageCount { get; set; }
        public IEnumerable<TEntity> PagedData { get; set; }

    }
}
