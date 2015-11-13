using System;
using System.Collections.Generic;
using System.Linq;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;

namespace PackageBuilder.Domain.Entities
{
    public static class IEnumerableExtensions
    {
        //public static IEnumerable<IDataField> Traverse(this IEnumerable<IDataField> dataFields)
        //{
        //    if (dataFields == null) return Enumerable.Empty<IDataField>();
        //    var fields = dataFields as IList<IDataField> ?? dataFields.ToList();
        //    return fields.Any() ? fields.SelectMany(x => x != null ? x.Traverse(y => y.DataFields, x.Name) : Enumerable.Empty<IDataField>()) : Enumerable.Empty<IDataField>();
        //}

        //private static IEnumerable<T> Traverse<T>(this T root, Func<T, IEnumerable<T>> childrenSelector, string name) where T : class, IDataField
        //{
        //    root.Namespace = name;
        //    yield return root;

        //    var childNodes = childrenSelector(root);
        //    if (childNodes == null)
        //        yield break;

        //    var children = childNodes.SelectMany(n => n.Traverse(childrenSelector, root.Namespace));
        //    foreach (var childNode in children)
        //    {
        //        childNode.Namespace += "." + childNode.Name;
        //        yield return childNode;
        //    }
        //}

        //public static IEnumerable<IDataFieldOverride> Traverse(this IEnumerable<IDataFieldOverride> dataFields)
        //{
        //    if (dataFields == null) return Enumerable.Empty<IDataFieldOverride>();
        //    var fields = dataFields as IList<IDataFieldOverride> ?? dataFields.ToList();
        //    return fields.Any() ? fields.SelectMany(x => x != null ? x.Traverse(y => y.DataFieldOverrides, x.Name) : Enumerable.Empty<IDataFieldOverride>()) : Enumerable.Empty<IDataFieldOverride>();
        //}

        //private static IEnumerable<IDataFieldOverride> Traverse(this IDataFieldOverride root, Func<IDataFieldOverride, IEnumerable<IDataFieldOverride>> childrenSelector, string name) 
        //{
        //    root.Namespace = name;
        //    yield return root;

        //    var childNodes = childrenSelector(root);
        //    if (childNodes == null)
        //        yield break;

        //    var children = childNodes.SelectMany(n => n.Traverse(childrenSelector, root.Namespace));
        //    foreach (var childNode in children)
        //    {
        //        childNode.Namespace += "." + childNode.Name;
        //        yield return childNode;
        //    }
        //}

        //public static IEnumerable<T> Traverse<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> childrenSelector)
        //{
        //    return source != null ? source.SelectMany(c => childrenSelector(c).Traverse(childrenSelector)).Concat(source) : Enumerable.Empty<T>();
        //}

        //public static IEnumerable<T> Flatten<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> childrenSelector)
        //{
        //    if (source == null)
        //        return new List<T>();

        //    var list = source;
        //    if (childrenSelector != null)
        //        foreach (var item in source)
        //            list = list.Concat(childrenSelector(item).Flatten(childrenSelector));

        //    return list;
        //}
        //public static IEnumerable<T> SelectHierarchy<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> childrenSelector, Func<T, bool> predicate)
        //{
        //    if (source == null)
        //        yield break;
        //    foreach (var item in source)
        //    {
        //        if (predicate(item))
        //            yield return item;
        //        var childResults = SelectHierarchy(childrenSelector(item), childrenSelector, predicate);
        //        foreach (var childItem in childResults)
        //            yield return childItem;
        //    }
        //}

        public static void RecursiveForEach(this IEnumerable<IDataField> dataFields, Action<IDataField> action)
        {
            if (dataFields == null) return;
            foreach (var dataField in dataFields.Where(dataField => dataField != null))
            {
                action(dataField);
                dataField.DataFields.RecursiveForEach(action);
            }
        }

        public static IEnumerable<IDataField> ToNamespace(this IEnumerable<IDataField> dataFields, string namespaceRoot = "")
        {
            if (dataFields == null)
                return Enumerable.Empty<IDataField>();

            var fields = dataFields as IList<IDataField> ?? dataFields.ToList();
            foreach (var dataField in fields.Where(x => x != null))
            {
                dataField.Namespace = string.IsNullOrEmpty(namespaceRoot) ? dataField.Name : namespaceRoot + "." + dataField.Name;
                dataField.DataFields.ToNamespace(dataField.Namespace);
            }

            return fields;
        }

        public static IEnumerable<IDataFieldOverride> ToNamespace(this IEnumerable<IDataFieldOverride> dataFields, string namespaceRoot = "") 
        {
            if (dataFields == null)
                return Enumerable.Empty<IDataFieldOverride>();

            var fields = dataFields as IList<IDataFieldOverride> ?? dataFields.ToList();
            foreach (var dataField in fields.Where(x => x != null))
            {
                dataField.Namespace = string.IsNullOrEmpty(namespaceRoot) ? dataField.Name : namespaceRoot + "." + dataField.Name;
                dataField.DataFieldOverrides.ToNamespace(dataField.Namespace);
            }

            return fields;
        }

        public static IEnumerable<IDataField> Filter(this IEnumerable<IDataField> dataFields, Func<IDataField, bool> predicate = null) 
        {
            if (dataFields == null)
                yield break;
            if (predicate == null)
                predicate = field => true;
            foreach (var dataField in dataFields.Where(x => x != null))
            {
                if (predicate(dataField))
                    yield return dataField;

                var childResults = dataField.DataFields.Filter(predicate);
                foreach (var childItem in childResults)
                    yield return childItem;
            }
        }

        public static IEnumerable<IDataFieldOverride> Filter(this IEnumerable<IDataFieldOverride> dataFields, Func<IDataFieldOverride, bool> predicate = null)
        {
            if (dataFields == null)
                yield break;
            if (predicate == null)
                predicate = field => true;
            foreach (var dataField in dataFields.Where(x => x != null))
            {
                if (predicate(dataField))
                    yield return dataField;

                var childResults = dataField.DataFieldOverrides.Filter(predicate);
                foreach (var childItem in childResults)
                    yield return childItem;
            }
        }

        public static void RemoveFields(this IEnumerable<IDataField> dataFields, Func<IDataField, bool> predicate = null)
        {
            if (dataFields == null)
                return;
            if (predicate == null)
                predicate = field => true;

            var fields = dataFields as IList<IDataField> ?? dataFields.ToList();
            foreach (var dataField in fields.Where(x => x != null).ToList())
            {
                if (predicate(dataField))
                    fields.Remove(dataField);

                dataField.DataFields.RemoveFields(predicate);
            }
        }

        // Return only selected Datafields
        public static IEnumerable<IDataField> GetSelected(this IEnumerable<IDataField> dataFields)
        {
            if (dataFields == null)
                yield break;

            foreach (var dataField in dataFields.Where(x => x != null).ToList())
            {
                if (dataField.IsSelected.HasValue && dataField.IsSelected.Value)
                {
                    dataField.DataFields = dataField.DataFields.GetSelected();
                    yield return dataField;
                }
            }
        }
    }
}