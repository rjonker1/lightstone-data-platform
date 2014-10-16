using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework
{
    [DataContract]
    public class PagedCollection<TEntity>
    {
        #region Fields

        private int _pageSize = 8;

        #endregion

        #region Properties

        [DataMember]
        public int PageIndex { get; set; }

        [DataMember]
        public virtual int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        [DataMember]
        public int TotalItems { get; set; }

        [DataMember]
        public List<TEntity> Items { get; set; }

        public string Filter { get; set; }

        public List<string> OrderBy { get; set; }

        public bool Ascendent { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Paginate collection
        /// </summary>
        /// <typeparam name="TEntity">Type of model</typeparam>
        /// <param name="pagedCollection">From page collection</param>
        /// <param name="filter">Serialized expression filter</param>
        public void Paginate(PagedCollection<TEntity> pagedCollection, string filter)
        {
            if (pagedCollection == null)
                throw new ArgumentNullException("pagedCollection");

            if (filter == null)
                throw new ArgumentNullException("filter");

            PageIndex = pagedCollection.PageIndex;
            PageSize = pagedCollection.PageSize;
            Items = pagedCollection.Items;
            TotalItems = pagedCollection.TotalItems;
            Filter = filter;
        }

        /// <summary>
        ///     Paginate collection
        /// </summary>
        /// <typeparam name="T">Type of paged collection</typeparam>
        /// <typeparam name="TEntity">Type of model</typeparam>
        /// <param name="pagedCollection">From page collection</param>
        /// <param name="model">To model</param>
        public void Paginate<T>(PagedCollection<TEntity> pagedCollection, ref T model)
            where T : PagedCollection<TEntity>, new()
        {
            if (pagedCollection == null)
                throw new ArgumentNullException("pagedCollection");

            if (model == null)
                throw new ArgumentNullException("model");

            model = new T
            {
                PageIndex = pagedCollection.PageIndex,
                PageSize = pagedCollection.PageSize,
                Items = pagedCollection.Items,
                TotalItems = pagedCollection.TotalItems
            };
        }

        #endregion
    }
}