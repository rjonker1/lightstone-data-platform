﻿using System;
using System.Collections.Generic;
using System.Linq;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;

namespace PackageBuilder.Domain.Entities
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<IDataField> Traverse(this IEnumerable<IDataField> dataFields)
        {
            return dataFields != null ? dataFields.SelectMany(x => x.Traverse(y => y.DataFields, x.Name)) : Enumerable.Empty<IDataField>();
        }

        public static IEnumerable<T> Traverse<T>(this T root, Func<T, IEnumerable<T>> childrenSelector, string name) where T : class, IDataField
        {
            root.Namespace = name;
            yield return root;

            var childNodes = childrenSelector(root);
            if (childNodes == null)
                yield break;

            var children = childNodes.SelectMany(n => n.Traverse(childrenSelector, root.Namespace));
            foreach (var childNode in children)
            {
                childNode.Namespace += "." + childNode.Name;
                yield return childNode;
            }
        }

        public static IEnumerable<IDataFieldOverride> Traverse(this IEnumerable<IDataFieldOverride> dataFields)
        {
            return dataFields != null ? dataFields.SelectMany(x => x.Traverse(y => y.DataFieldOverrides, x.Name)) : Enumerable.Empty<IDataFieldOverride>();
        }

        public static IEnumerable<IDataFieldOverride> Traverse(this IDataFieldOverride root, Func<IDataFieldOverride, IEnumerable<IDataFieldOverride>> childrenSelector, string name) 
        {
            root.Namespace = name;
            yield return root;

            var childNodes = childrenSelector(root);
            if (childNodes == null)
                yield break;

            var children = childNodes.SelectMany(n => n.Traverse(childrenSelector, root.Namespace));
            foreach (var childNode in children)
            {
                childNode.Namespace += "." + childNode.Name;
                yield return childNode;
            }
        }

        public static IEnumerable<T> Traverse<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> childrenSelector)
        {
            return source != null ? source.SelectMany(c => childrenSelector(c).Traverse(childrenSelector)).Concat(source) : Enumerable.Empty<T>();
        }

        public static IEnumerable<T> Flatten<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> childrenSelector)
        {
            if (source == null)
                return new List<T>();

            var list = source;
            if (childrenSelector != null)
                foreach (var item in source)
                    list = list.Concat(childrenSelector(item).Flatten(childrenSelector));

            return list;
        }
        public static IEnumerable<T> SelectHierarchy<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> childrenSelector, Func<T, bool> predicate)
        {
            if (source == null)
                yield break;
            foreach (var item in source)
            {
                if (predicate(item))
                    yield return item;
                var childResults = SelectHierarchy(childrenSelector(item), childrenSelector, predicate);
                foreach (var childItem in childResults)
                    yield return childItem;
            }
        }
    }
}