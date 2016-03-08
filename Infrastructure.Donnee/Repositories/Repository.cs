namespace Infrastructure.Donnee
{
    using Domain;
    using Log;
    using Resources;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Rla classe generique pour le repository 
    /// </summary>
    /// <typeparam name="TEntity">TLentite sousjacente </typeparam>
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : EntiteBase
    {
        #region Members

        IQueryableUnitOfWork _UnitOfWork;
        ILogger _logger;

        #endregion

        #region Constructeurr

        /// <summary>
        /// Cree une nouvelle instance 
        /// </summary>
        /// <param name="unitOfWork"> UnitOfWork </param>
        /// <param name="logger"> logger Associe</param>
        public Repository(IQueryableUnitOfWork unitOfWork, ILogger logger)
        {
            if (unitOfWork == (IUnitOfWork)null)
                throw new ArgumentNullException("unitOfWork");
            if (logger == (ILogger)null)
                throw new ArgumentNullException("logger");

            _UnitOfWork = unitOfWork;
            _logger = logger;
        }

        #endregion

        #region Membres IRepository 

        /// <summary>
        /// <see cref="Domain.IRepository{TEntity}"/>
        /// </summary>
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _UnitOfWork;
            }
        }

        /// <summary>
        /// <see cref="Domain.IRepository{TEntity}"/>
        /// </summary>
        /// <param name="item"><see cref="Domain.IRepository{TEntity}"/></param>
        public virtual void Ajouter(TEntity item)
        {
            if (item == (TEntity)null)
                throw new ArgumentNullException(typeof(TEntity).ToString(), Messages.AjouterObjeNull);
            GetSet().Add(item);  
        }
        /// <summary>
        /// <see cref="Domain.IRepository{TEntity}"/>
        /// </summary>
        /// <param name="item"><see cref="Domain.IRepository{TEntity}"/></param>
        public virtual void Supprimer(TEntity item)
        {
            if (item == (TEntity)null)
                throw new ArgumentNullException(typeof(TEntity).ToString(), Messages.SupprimerObjetNull);
            _UnitOfWork.Attach(item);
            GetSet().Remove(item);
        }

         

        /// <summary>
        /// <see cref="Domain.IRepository{TEntity}"/>
        /// </summary>
        /// <param name="item"><see cref="Domain.IRepository{TEntity}"/></param>
        public virtual void Modifier(TEntity item)
        {
            if (item == (TEntity)null)
                throw new ArgumentNullException(typeof(TEntity).ToString(), Messages.SupprimerObjetNull);
            _UnitOfWork.SetModified(item);

        }

        
        /// <summary>
        /// <see cref="Domain.IRepository{TEntity}"/>
        /// </summary>
        /// <param name="id"><see cref="Domain.IRepository{TEntity}"/></param>
        /// <returns><see cref="Domain.IRepository{TEntity}"/></returns>
        public virtual TEntity GetElementById(int id)
        {
           return GetSet().Find(id);
             
        }

        /// <summary>
        /// <see cref="Domain.IRepository{TEntity}"/>
        /// </summary>
        /// <returns><see cref="Domain.IRepository{TEntity}"/></returns>
        public virtual IEnumerable<TEntity> GetAllElements()
        {
            return GetSet();
        }

        /// <summary>
        /// <see cref="Domain.IRepository.GetAllElements{TEntity}"/>
        /// </summary>
        /// <param name="includes"><see cref="Domain.IRepository.GetAllElements{TEntity}"/></param>
        /// <returns><see cref="Domain.IRepository.GetAllElements{TEntity}"/></returns>
        public virtual IEnumerable<TEntity> GetAllElements(params Expression<Func<TEntity, object>>[] includes)
        {
            return includes
           .Aggregate(
               GetSet().AsQueryable(),
               (current, include) => current.Include(include)
           );
        }


        /// <summary>
        /// <see cref="Domain.IRepository{TEntity}"/>
        /// </summary>
        /// <typeparam name="S"><see cref="Domain.IRepository{TEntity}"/></typeparam>
        /// <param name="pageIndex"><see cref="Domain.IRepository{TEntity}"/></param>
        /// <param name="pageCount"><see cref="Domain.IRepository{TEntity}"/></param>
        /// <param name="orderByExpression"><see cref="Domain.IRepository{TEntity}"/></param>
        /// <param name="ascending"><see cref="Domain.IRepository{TEntity}"/></param>
        /// <returns><see cref="Domain.IRepository{TEntity}"/></returns>
        public virtual IEnumerable<TEntity> GetPagedElements<KProperty>(int pageIndex, int pageCount,
            Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending)
        {
            if (pageIndex < 0)
                throw new ArgumentException(Resources.Messages.IndexDePageInvalide, "pageIndex");

            if (pageCount <= 0)
                throw new ArgumentException(Resources.Messages.NombreDePagesInvalide, "pageCount");

            if (orderByExpression == (Expression<Func<TEntity, KProperty>>)null)
                throw new ArgumentNullException("orderByExpression", Resources.Messages.ExpressionOrdreByNullInvalide);

            var set = GetSet();

            if (ascending)
            {
                return set.OrderBy(orderByExpression)
                          .Skip(pageCount * pageIndex)
                          .Take(pageCount)
                          .AsEnumerable();
            }
            else
            {
                return set.OrderByDescending(orderByExpression)
                          .Skip(pageCount * pageIndex)
                          .Take(pageCount)
                          .AsEnumerable();
            }
        }

        /// <summary>
        /// <see cref="Domain.IRepository{TEntity}"/>
        /// </summary>
        /// <typeparam name="S"><see cref="Domain.IRepository{TEntity}"/></typeparam>
        /// <param name="pageIndex"><see cref="Domain.IRepository{TEntity}"/></param>
        /// <param name="pageCount"><see cref="Domain.IRepository{TEntity}"/></param>
        /// <param name="orderByExpression"><see cref="Domain.IRepository{TEntity}"/></param>
        /// <param name="ascending"><see cref="Domain.IRepository{TEntity}"/></param>
        /// <returns><see cref="Domain.IRepository{TEntity}"/></returns>
        public PagedList<TEntity> GetPagedList<KProperty>(int pageIndex, int pageCount, Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending)
        {
            if (pageIndex < 0)
                throw new ArgumentException(Resources.Messages.IndexDePageInvalide, "pageIndex");

            if (pageCount <= 0)
                throw new ArgumentException(Resources.Messages.NombreDePagesInvalide, "pageCount");

            if (orderByExpression == (Expression<Func<TEntity, KProperty>>)null)
                throw new ArgumentNullException("orderByExpression", Resources.Messages.ExpressionOrdreByNullInvalide);

            var set = GetSet();
            PagedList<TEntity> pagedList = new PagedList<TEntity>();
            pagedList.PageIndex = pageIndex;
            pagedList.PageCount = pageCount;
            pagedList.Total = set.Count();
            if (ascending)
            {
                pagedList.PagedData= set.OrderBy(orderByExpression)
                          .Skip(pageCount * pageIndex)
                          .Take(pageCount)
                          .AsEnumerable();
            }
            else
            {
                pagedList.PagedData = set.OrderByDescending(orderByExpression)
                          .Skip(pageCount * pageIndex)
                          .Take(pageCount)
                          .AsEnumerable();
            }

            return pagedList;

        }

        /// <summary>
        /// <see cref="Domain.IRepository{TEntity}"/>
        /// </summary>
        /// <typeparam name="S"><see cref="Domain.IRepository{TEntity}"/></typeparam>
        /// <param name="pageIndex"><see cref="Domain.IRepository{TEntity}"/></param>
        /// <param name="pageCount"><see cref="Domain.IRepository{TEntity}"/></param>
        /// <param name="orderByExpression"><see cref="Domain.IRepository{TEntity}"/></param>
        /// <param name="ascending"><see cref="Domain.IRepository{TEntity}"/></param>
        /// <returns><see cref="Domain.IRepository{TEntity}"/></returns>
        public virtual PagedList<TEntity> GetPagedList<KProperty>(int pageIndex, int pageCount,
            Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending,
            params Expression<Func<TEntity, object>>[] includes)
        {
            if (pageIndex < 0)
                throw new ArgumentException(Resources.Messages.IndexDePageInvalide, "pageIndex");

            if (pageCount <= 0)
                throw new ArgumentException(Resources.Messages.NombreDePagesInvalide, "pageCount");

            if (orderByExpression == (Expression<Func<TEntity, KProperty>>)null)
                throw new ArgumentNullException("orderByExpression", Resources.Messages.ExpressionOrdreByNullInvalide);

            if (includes == (Expression<Func<TEntity, object>>[])null)
                throw new ArgumentNullException("includes");

            var set = GetSet();
            PagedList<TEntity> pagedList = new PagedList<TEntity>();
            pagedList.PageIndex = pageIndex;
            pagedList.PageCount = pageCount;
            pagedList.Total = set.Count();
            if (ascending)
            {
                if (includes.Any())
                {
                    pagedList.PagedData = includes.Aggregate(set.OrderBy(orderByExpression).Skip(pageCount * pageIndex).Take(pageCount).AsQueryable(),
                                     (current, include) => current.Include(include));
                }

                pagedList.PagedData = set.OrderBy(orderByExpression).Skip(pageCount * pageIndex).Take(pageCount);
            }
            else
            {
                if (includes.Any())
                {
                    pagedList.PagedData = includes.Aggregate(set.OrderByDescending(orderByExpression).Skip(pageCount * pageIndex).Take(pageCount).AsQueryable(),
                                            (current, include) => current.Include(include));
                }

                pagedList.PagedData = set.OrderByDescending(orderByExpression).Skip(pageCount * pageIndex).Take(pageCount);
            }
            return pagedList;
        }


        /// <summary>
        /// <see cref="Domain.IRepository.GetFilteredElements{TEntity}"/>
        /// </summary>
        /// <param name="filter"><see cref="Domain.IRepository{TEntity}"/></param>
        /// <returns><see cref="Domain.IRepository{TEntity}"/></returns>
        public virtual IEnumerable<TEntity> GetFilteredElements(Expression<Func<TEntity, bool>> filter)
        {
            if (filter == (Expression<Func<TEntity, bool>>)null)
                throw new ArgumentNullException("filter", Resources.Messages.FiltreNullInvalide);

            return GetSet().Where(filter)
                           .AsEnumerable();
        }

        /// <summary>
        /// <see cref="Domain.IRepository.GetFilteredElements{TEntity}"/>
        /// </summary>
        /// <param name="filter"><see cref="Domain.IRepository.GetFilteredElements{TEntity}"/></param>
        /// <param name="includes"><see cref="Domain.IRepository.GetFilteredElements{TEntity}"/></param>
        /// <returns><see cref="Domain.IRepository.GetFilteredElements{TEntity}"/></returns>
        public virtual IEnumerable<TEntity> GetFilteredElements(Expression<Func<TEntity, bool>> filter,
            params Expression<Func<TEntity, object>>[] includes)
        {
            if (filter == (Expression<Func<TEntity, bool>>)null)
                throw new ArgumentNullException("filter", Resources.Messages.FiltreNullInvalide);

            if (includes == (Expression<Func<TEntity, object>>[])null)
                throw new ArgumentNullException("includes", Resources.Messages.InclusionNullInvalide);

            var query = GetSet().Where(filter);
            if (includes.Any())
            {
                return includes.Aggregate(query.AsQueryable(), (current, include) => current.Include(include));
            }
            return query;
        }

        #endregion

        #region   Methodes Privees

        IDbSet<TEntity> GetSet()
        {
            return _UnitOfWork.CreateSet<TEntity>();
        }
        #endregion

    }
}
