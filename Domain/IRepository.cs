namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    ///  Contrat de Base pour implemente le "Repository Pattern" 
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <typeparam name="TEntity">Entitie generique pour ce repository </typeparam>
    public interface IRepository<TEntity> 
        where TEntity : EntiteBase
    {
        /// <summary>
        /// Le unitOfWorkPour ce repository
        /// </summary>
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// Ajouter un element dans le repository
        /// </summary>
        /// <param name="item">Element a ajouter</param>
        void Ajouter(TEntity item);

        /// <summary>
        /// Supprimer un element dans le repository
        /// </summary>
        /// <param name="item">Element a supprimer</param>
        void Supprimer(TEntity item);

        /// <summary>
        ///Modifier un element dans le repository   
        /// </summary>
        /// <param name="item">Element a Modifier</param>
        void Modifier(TEntity item);

        /// <summary>
        /// Retrouve un element par son identifiant
        /// </summary>
        /// <param name="id">identifiant de l element.</param>
        /// <returns></returns>
        TEntity GetElementById(int id);
       
        /// <summary>
        /// Recuperer tous les elements
        /// </summary>
        /// <returns>Liste des elements</returns>
        IEnumerable<TEntity> GetAllElements();

        /// <summary>
        /// Recuperer tous les elements de type {TEntity} dans le repository
        /// inclure les dependances specifiee
        /// </summary>
        /// <param name="includes">idependances incluses</param>
        /// <returns>Liste des elements</returns>
        IEnumerable<TEntity> GetAllElements(params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        /// Recuperer  les elements de type {TEntity} dans le repository avec pagination
        /// </summary>
        /// <param name="pageIndex"> indexe de la page</param>
        /// <param name="pageCount">Nombre des elements dans chaque page</param>
        /// <param name="orderByExpression">L'expression d'ordre</param>
        /// <param name="ascending">specifier si par ascendance ou descendance </param>
        /// <returns>Liste des elements</returns>
        IEnumerable<TEntity> GetPagedElements<KProperty>(int pageIndex, int pageCount, Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending);

        /// <summary>
        /// Recuperer  les elements de type {TEntity} dans le repository avec pagination
        /// </summary>
        /// <param name="pageIndex"> indexe de la page</param>
        /// <param name="pageCount">Nombre des elements dans chaque page</param>
        /// <param name="orderByExpression">L'expression d'ordre</param>
        /// <param name="ascending">specifier si par ascendance ou descendance </param>
        /// <returns>Liste des elements</returns>
        PagedList<TEntity> GetPagedList<KProperty>(int pageIndex, int pageCount, Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending);



        /// <summary>
        /// Recuperer  les elements de type {TEntity} dans le repository avec pagination
        /// </summary>
        /// <param name="pageIndex"> indexe de la page</param>
        /// <param name="pageCount">Nombre des elements dans chaque page</param>
        /// <param name="orderByExpression">L'expression d'ordre</param>
        /// <param name="ascending">specifier si par ascendance ou descendance </param>
        /// <returns>Liste des elements</returns>
        PagedList<TEntity> GetPagedList<KProperty>(int pageIndex, int pageCount,
         Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending,
         params Expression<Func<TEntity, object>>[] includes);


        /// <summary>
        /// Recuperer  les elements de type {TEntity} dans le repository avec une expression 
        /// </summary>
        /// <param name="filter">Expression de filtre</param>
        /// <returns>Liste des elements</returns>
        IEnumerable<TEntity> GetFilteredElements(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Recuperer  les elements de type {TEntity} dans le repository avec une expression,
        ///  inclure les dependances specifiee
        /// </summary>
        /// <param name="filter">Expression de filtre</param>
        /// <param name="includes">L'expression d'ordre</param>
        /// <returns>Liste des elements</returns>
        IEnumerable<TEntity> GetFilteredElements(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes);
    }
}
