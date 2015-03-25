﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Billing.Domain.Core.Helpers
{
    public interface IPagedList<T> : IEnumerable<T>
    {
        int PageIndex { get; }
        int PageSize { get; }
        int RecordsTotal { get; }
        int PageTotal { get; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
    }

    public class PagedList<T> : IPagedList<T>
    {
        private readonly List<T> _inner;
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int PageTotal { get; private set; }
        public int RecordsTotal { get; private set; }
        public int RecordsFiltered { get; private set; }

        public PagedList(IQueryable<T> source, int pageIndex, int pageSize)
            : this(source, pageIndex, pageSize, source.Count(), x => true)
        { }

        public PagedList(IQueryable<T> source, int pageIndex, int pageSize, Expression<Func<T, bool>> predicate)
            : this(source, pageIndex, pageSize, source.Count(), predicate)
        { }

        public PagedList(IQueryable<T> source, int pageIndex, int pageSize, int recordsTotal, Expression<Func<T, bool>> predicate)
        {
            _inner = new List<T>();

            RecordsTotal = recordsTotal;
            PageSize = pageSize;
            PageIndex = pageIndex;

            if (pageSize > 0)
            {
                PageTotal = RecordsTotal / pageSize;
                if (RecordsTotal % pageSize > 0)
                    PageTotal++;
            }

            var filtered = source.Where(predicate);
            RecordsFiltered = filtered.Count();

            _inner.AddRange(filtered.Skip(pageIndex * pageSize).Take(pageSize));
        }

        public bool HasPreviousPage
        {
            get { return (PageIndex > 1); }
        }

        public bool HasNextPage
        {
            get { return (PageIndex < PageTotal); }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _inner.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}