using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using LightstoneApp.Domain.PackageBuilderModule.Entities.DTO;
using LightstoneApp.Domain.PackageBuilderModule.Entities.Events;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;
using Version = LightstoneApp.Infrastructure.CrossCutting.NetFramework.Version;

namespace LightstoneApp.Domain.PackageBuilderModule.Entities.Context
{
    namespace PackageBuilder
    {

        #region PackageBuilderContext


        [StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
        public sealed class PackageBuilderContext :DbContext, IPackageBuilderContext
        {
            public DbSet<DataField> DataFields { get; set; }
            public DbSet<DataProvider> DataProviders { get; set; }
            public DbSet<Industry> Industries { get; set; }
            public DbSet<Package> Packages { get; set; }
            public DbSet<PackageDataField> PackageDataFields { get; set; }
            public DbSet<State> States { get; set; }

            public PackageBuilderContext()
                : base("name=LightstoneAppDatabaseEntities")
            {
                Dictionary<RuntimeTypeHandle, object> constraintEnforcementCollectionCallbacksByTypeDictionary =
                    _ContraintEnforcementCollectionCallbacksByTypeDictionary =
                        new Dictionary<RuntimeTypeHandle, object>(7, RuntimeTypeHandleEqualityComparer.Instance);
                constraintEnforcementCollectionCallbacksByTypeDictionary.Add(
                    typeof(ConstraintEnforcementCollection<DTO.PackageBuilder.Package, PackageDataField>).TypeHandle,
                    new ConstraintEnforcementCollectionCallbacks<DTO.PackageBuilder.Package, PackageDataField>(
                        OnPackagePackageDataFieldViaPackageCollectionAdding,
                        OnPackagePackageDataFieldViaPackageCollectionAdded, null,
                        OnPackagePackageDataFieldViaPackageCollectionRemoved));
                constraintEnforcementCollectionCallbacksByTypeDictionary.Add(
                    typeof(ConstraintEnforcementCollection<DTO.State, DTO.PackageBuilder.Package>).TypeHandle,
                    new ConstraintEnforcementCollectionCallbacks<DTO.State, DTO.PackageBuilder.Package>(
                        OnStatePackageViaStateCollectionAdding, OnStatePackageViaStateCollectionAdded, null,
                        OnStatePackageViaStateCollectionRemoved));
                constraintEnforcementCollectionCallbacksByTypeDictionary.Add(
                    typeof(ConstraintEnforcementCollection<DTO.State, DataProvider>).TypeHandle,
                    new ConstraintEnforcementCollectionCallbacks<DTO.State, DataProvider>(
                        OnStateDataProviderViaStateCollectionAdding, OnStateDataProviderViaStateCollectionAdded, null,
                        OnStateDataProviderViaStateCollectionRemoved));
                constraintEnforcementCollectionCallbacksByTypeDictionary.Add(
                    typeof(ConstraintEnforcementCollection<DataProvider, DataField>).TypeHandle,
                    new ConstraintEnforcementCollectionCallbacks<DataProvider, DataField>(
                        OnDataProviderDataFieldViaDataProviderCollectionAdding,
                        OnDataProviderDataFieldViaDataProviderCollectionAdded, null,
                        OnDataProviderDataFieldViaDataProviderCollectionRemoved));
                constraintEnforcementCollectionCallbacksByTypeDictionary.Add(
                    typeof(ConstraintEnforcementCollection<DataField, PackageDataField>).TypeHandle,
                    new ConstraintEnforcementCollectionCallbacks<DataField, PackageDataField>(
                        OnDataFieldPackageDataFieldViaDataFieldCollectionAdding,
                        OnDataFieldPackageDataFieldViaDataFieldCollectionAdded, null,
                        OnDataFieldPackageDataFieldViaDataFieldCollectionRemoved));
                constraintEnforcementCollectionCallbacksByTypeDictionary.Add(
                    typeof(ConstraintEnforcementCollection<DTO.Industry, DTO.PackageBuilder.Package>).TypeHandle,
                    new ConstraintEnforcementCollectionCallbacks<DTO.Industry, DTO.PackageBuilder.Package>(
                        OnIndustryPackageViaIndustryCollectionAdding, OnIndustryPackageViaIndustryCollectionAdded, null,
                        OnIndustryPackageViaIndustryCollectionRemoved));
                constraintEnforcementCollectionCallbacksByTypeDictionary.Add(
                    typeof(ConstraintEnforcementCollection<DTO.Industry, DataField>).TypeHandle,
                    new ConstraintEnforcementCollectionCallbacks<DTO.Industry, DataField>(
                        OnIndustryDataFieldViaIndustryCollectionAdding, OnIndustryDataFieldViaIndustryCollectionAdded,
                        null, OnIndustryDataFieldViaIndustryCollectionRemoved));
                _PackageReadOnlyCollection = new ReadOnlyCollection<DTO.PackageBuilder.Package>(_PackageList = new List<DTO.PackageBuilder.Package>());
                _StateReadOnlyCollection = new ReadOnlyCollection<DTO.State>(_StateList = new List<DTO.State>());
                _DataProviderReadOnlyCollection =
                    new ReadOnlyCollection<DataProvider>(_DataProviderList = new List<DataProvider>());
                _DataFieldReadOnlyCollection = new ReadOnlyCollection<DataField>(_DataFieldList = new List<DataField>());
                _PackageDataFieldReadOnlyCollection =
                    new ReadOnlyCollection<PackageDataField>(_PackageDataFieldList = new List<PackageDataField>());
                _IndustryReadOnlyCollection = new ReadOnlyCollection<DTO.Industry>(_IndustryList = new List<DTO.Industry>());
            }

           
            #region Exception Helpers

            private static ArgumentException GetDifferentContextsException()
            {
                return GetDifferentContextsException("value");
            }

            [SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly")]
            private static ArgumentException GetDifferentContextsException(string paramName)
            {
                return new ArgumentException("All objects in a relationship must be part of the same Context.",
                    paramName);
            }

            private static ArgumentException GetConstraintEnforcementFailedException(string paramName)
            {
                return new ArgumentException("Argument failed constraint enforcement.", paramName);
            }

            #endregion // Exception Helpers

            #region Lookup and External Constraint Enforcement

            private readonly Dictionary<System.Tuple<string, string>, DTO.PackageBuilder.Package>
                _PackageNameAndVersionExternalUniquenessConstraintDictionary =
                    new Dictionary<System.Tuple<string, string>, DTO.PackageBuilder.Package>();

            public DTO.PackageBuilder.Package GetPackageByPackageNameAndVersionExternalUniquenessConstraint(string Name, string Version)
            {
                return
                    _PackageNameAndVersionExternalUniquenessConstraintDictionary[
                        new System.Tuple<string, string>(Name, Version)];
            }

            public bool TryGetPackageByPackageNameAndVersionExternalUniquenessConstraint(string Name, string Version,
                out DTO.PackageBuilder.Package Package)
            {
                return
                    _PackageNameAndVersionExternalUniquenessConstraintDictionary.TryGetValue(
                        new System.Tuple<string, string>(Name, Version), out Package);
            }

            private bool OnPackageNameAndVersionExternalUniquenessConstraintChanging(DTO.PackageBuilder.Package instance, System.Tuple<string, string> newValue)
            {
                if (newValue != null)
                {
                    DTO.PackageBuilder.Package currentInstance;
                    if (_PackageNameAndVersionExternalUniquenessConstraintDictionary.TryGetValue(newValue,
                        out currentInstance))
                    {
                        return currentInstance == instance;
                    }
                }
                return true;
            }

            private void OnPackageNameAndVersionExternalUniquenessConstraintChanged(DTO.PackageBuilder.Package instance, System.Tuple<string, string> oldValue, System.Tuple<string, string> newValue)
            {
                if (oldValue != null)
                {
                    _PackageNameAndVersionExternalUniquenessConstraintDictionary.Remove(oldValue);
                }
                if (newValue != null)
                {
                    _PackageNameAndVersionExternalUniquenessConstraintDictionary.Add(newValue, instance);
                }
            }

            private readonly Dictionary<System.Tuple<string, string>, DataProvider>
                _DataProviderNameAndVersionUniquenessConstraintDictionary =
                    new Dictionary<System.Tuple<string, string>, DataProvider>();

            public DataProvider GetDataProviderByDataProviderNameAndVersionUniquenessConstraint(string Name,
                string Version)
            {
                return
                    _DataProviderNameAndVersionUniquenessConstraintDictionary[new System.Tuple<string, string>(Name, Version)];
            }

            public bool TryGetDataProviderByDataProviderNameAndVersionUniquenessConstraint(string Name, string Version,
                out DataProvider DataProvider)
            {
                return
                    _DataProviderNameAndVersionUniquenessConstraintDictionary.TryGetValue(
                        new System.Tuple<string, string>(Name, Version), out DataProvider);
            }

            private bool OnDataProviderNameAndVersionUniquenessConstraintChanging(DataProvider instance, System.Tuple<string, string> newValue)
            {
                if (newValue != null)
                {
                    DataProvider currentInstance;
                    if (_DataProviderNameAndVersionUniquenessConstraintDictionary.TryGetValue(newValue,
                        out currentInstance))
                    {
                        return currentInstance == instance;
                    }
                }
                return true;
            }

            private void OnDataProviderNameAndVersionUniquenessConstraintChanged(DataProvider instance, System.Tuple<string, string> oldValue, System.Tuple<string, string> newValue)
            {
                if (oldValue != null)
                {
                    _DataProviderNameAndVersionUniquenessConstraintDictionary.Remove(oldValue);
                }
                if (newValue != null)
                {
                    _DataProviderNameAndVersionUniquenessConstraintDictionary.Add(newValue, instance);
                }
            }

            private readonly Dictionary<string, DataField> _DataFieldNameDictionary =
                new Dictionary<string, DataField>();

            public DataField GetDataFieldByName(string Name)
            {
                return _DataFieldNameDictionary[Name];
            }

            public bool TryGetDataFieldByName(string Name, out DataField DataField)
            {
                return _DataFieldNameDictionary.TryGetValue(Name, out DataField);
            }

            #endregion // Lookup and External Constraint Enforcement

            #region ConstraintEnforcementCollection

            private delegate bool PotentialCollectionModificationCallback<TClass, TProperty>(
                TClass instance, TProperty item)
                where TClass : class, IHasPackageBuilderContext;

            private delegate void CommittedCollectionModificationCallback<TClass, TProperty>(
                TClass instance, TProperty item)
                where TClass : class, IHasPackageBuilderContext;

            [StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
            private sealed class ConstraintEnforcementCollectionCallbacks<TClass, TProperty>
                where TClass : class, IHasPackageBuilderContext
            {
                public ConstraintEnforcementCollectionCallbacks(
                    PotentialCollectionModificationCallback<TClass, TProperty> adding,
                    CommittedCollectionModificationCallback<TClass, TProperty> added,
                    PotentialCollectionModificationCallback<TClass, TProperty> removing,
                    CommittedCollectionModificationCallback<TClass, TProperty> removed)
                {
                    Adding = adding;
                    Added = added;
                    Removing = removing;
                    Removed = removed;
                }

                public readonly PotentialCollectionModificationCallback<TClass, TProperty> Adding;
                public readonly CommittedCollectionModificationCallback<TClass, TProperty> Added;
                public readonly PotentialCollectionModificationCallback<TClass, TProperty> Removing;
                public readonly CommittedCollectionModificationCallback<TClass, TProperty> Removed;
            }

            private ConstraintEnforcementCollectionCallbacks<TClass, TProperty>
                GetConstraintEnforcementCollectionCallbacks<TClass, TProperty>()
                where TClass : class, IHasPackageBuilderContext
            {
                return
                    (ConstraintEnforcementCollectionCallbacks<TClass, TProperty>)
                        _ContraintEnforcementCollectionCallbacksByTypeDictionary[
                            typeof(ConstraintEnforcementCollection<TClass, TProperty>).TypeHandle];
            }

            [StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
            private sealed class RuntimeTypeHandleEqualityComparer : IEqualityComparer<RuntimeTypeHandle>
            {
                public static readonly RuntimeTypeHandleEqualityComparer Instance =
                    new RuntimeTypeHandleEqualityComparer();

                private RuntimeTypeHandleEqualityComparer()
                {
                }

                public bool Equals(RuntimeTypeHandle x, RuntimeTypeHandle y)
                {
                    return x.Equals(y);
                }

                public int GetHashCode(RuntimeTypeHandle obj)
                {
                    return obj.GetHashCode();
                }
            }

            private readonly Dictionary<RuntimeTypeHandle, object>
                _ContraintEnforcementCollectionCallbacksByTypeDictionary;

            [StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
            private sealed class ConstraintEnforcementCollection<TClass, TProperty> : ICollection<TProperty>
                where TClass : class, IHasPackageBuilderContext
            {
                private readonly TClass _instance;
                private readonly List<TProperty> _list = new List<TProperty>();

                public ConstraintEnforcementCollection(TClass instance)
                {
                    _instance = instance;
                }

                private IEnumerator GetNonGenericEnumerator()
                {
                    return GetEnumerator();
                }

                IEnumerator IEnumerable.GetEnumerator()
                {
                    return GetNonGenericEnumerator();
                }

                public IEnumerator<TProperty> GetEnumerator()
                {
                    return _list.GetEnumerator();
                }

                public void Add(TProperty item)
                {
                    if (item == null)
                    {
                        throw new ArgumentNullException("item");
                    }
                    TClass instance = _instance;
                    ConstraintEnforcementCollectionCallbacks<TClass, TProperty> callbacks =
                        instance.Context.GetConstraintEnforcementCollectionCallbacks<TClass, TProperty>();
                    PotentialCollectionModificationCallback<TClass, TProperty> adding = callbacks.Adding;
                    if ((object)adding == null || adding(instance, item))
                    {
                        _list.Add(item);
                        CommittedCollectionModificationCallback<TClass, TProperty> added = callbacks.Added;
                        if ((object)added != null)
                        {
                            added(instance, item);
                        }
                    }
                }

                public bool Remove(TProperty item)
                {
                    if (item == null)
                    {
                        throw new ArgumentNullException("item");
                    }
                    TClass instance = _instance;
                    ConstraintEnforcementCollectionCallbacks<TClass, TProperty> callbacks =
                        instance.Context.GetConstraintEnforcementCollectionCallbacks<TClass, TProperty>();
                    PotentialCollectionModificationCallback<TClass, TProperty> removing = callbacks.Removing;
                    if ((object)removing == null || removing(instance, item))
                    {
                        if (_list.Remove(item))
                        {
                            CommittedCollectionModificationCallback<TClass, TProperty> removed = callbacks.Removed;
                            if ((object)removed != null)
                            {
                                removed(instance, item);
                            }
                            return true;
                        }
                    }
                    return false;
                }

                public void Clear()
                {
                    List<TProperty> list = _list;
                    for (int i = list.Count - 1; i > 0; --i)
                    {
                        Remove(list[i]);
                    }
                }

                public bool Contains(TProperty item)
                {
                    return item != null && _list.Contains(item);
                }

                public void CopyTo(TProperty[] array, int arrayIndex)
                {
                    _list.CopyTo(array, arrayIndex);
                }

                public int Count
                {
                    get { return _list.Count; }
                }

                public bool IsReadOnly
                {
                    get { return false; }
                }
            }

            #endregion // ConstraintEnforcementCollection

            #region Package

            public DTO.PackageBuilder.Package CreatePackage(string name, string description, string version, DTO.State state)
            {
                if ((object)name == null)
                {
                    throw new ArgumentNullException("name");
                }
                if ((object)description == null)
                {
                    throw new ArgumentNullException("description");
                }
                if ((object)version == null)
                {
                    throw new ArgumentNullException("version");
                }
                if (state == null)
                {
                    throw new ArgumentNullException("state");
                }



                if (!OnPackageNameChanging(null, name))
                {
                    throw GetConstraintEnforcementFailedException("Name");
                }
                if (!OnPackageDescriptionChanging(null, description))
                {
                    throw GetConstraintEnforcementFailedException("Description");
                }
                if (!OnPackageVersionChanging(null, version))
                {
                    throw GetConstraintEnforcementFailedException("Version");
                }
                if (!OnPackageStateChanging(null, state))
                {
                    throw GetConstraintEnforcementFailedException("State");
                }
                return new PackageCore(this, name, description, version, state);
            }

            private bool OnPackageNameChanging(DTO.PackageBuilder.Package instance, string newValue)
            {
                if (instance != null)
                {
                    if (
                        !OnPackageNameAndVersionExternalUniquenessConstraintChanging(instance,
                            new System.Tuple<string, string>(newValue, instance.Version)))
                    {
                        return false;
                    }
                }
                return true;
            }

            private void OnPackageNameChanged(DTO.PackageBuilder.Package instance, string oldValue)
            {
                System.Tuple<string, string> packageNameAndVersionExternalUniquenessConstraintOldValueTuple;
                if ((object)oldValue != null)
                {
                    packageNameAndVersionExternalUniquenessConstraintOldValueTuple = new System.Tuple<string, string>(
                        oldValue, instance.Version);
                }
                else
                {
                    packageNameAndVersionExternalUniquenessConstraintOldValueTuple = null;
                }
                OnPackageNameAndVersionExternalUniquenessConstraintChanged(instance,
                    packageNameAndVersionExternalUniquenessConstraintOldValueTuple,
                    new System.Tuple<string, string>(instance.Name, instance.Version));
            }

            private bool OnPackageDescriptionChanging(DTO.PackageBuilder.Package instance, string newValue)
            {
                return true;
            }

            private bool OnPackageOwnerChanging(DTO.PackageBuilder.Package instance, string newValue)
            {
                return true;
            }

            private bool OnPackageCreatedChanging(DTO.PackageBuilder.Package instance, DateTime? newValue)
            {
                return true;
            }

            private bool OnPackageEditedChanging(DTO.PackageBuilder.Package instance, DateTime? newValue)
            {
                return true;
            }

            private bool OnPackageVersionChanging(DTO.PackageBuilder.Package instance, string newValue)
            {
                if (instance != null)
                {
                    if (
                        !OnPackageNameAndVersionExternalUniquenessConstraintChanging(instance,
                            new System.Tuple<string, string>(instance.Name, newValue)))
                    {
                        return false;
                    }
                }
                return true;
            }

            private void OnPackageVersionChanged(DTO.PackageBuilder.Package instance, string oldValue)
            {
                System.Tuple<string, string> packageNameAndVersionExternalUniquenessConstraintOldValueTuple;
                if ((object)oldValue != null)
                {
                    packageNameAndVersionExternalUniquenessConstraintOldValueTuple =
                        new System.Tuple<string, string>(instance.Name, oldValue);
                }
                else
                {
                    packageNameAndVersionExternalUniquenessConstraintOldValueTuple = null;
                }
                OnPackageNameAndVersionExternalUniquenessConstraintChanged(instance,
                    packageNameAndVersionExternalUniquenessConstraintOldValueTuple,
                    new System.Tuple<string, string>(instance.Name, instance.Version));
            }

            private bool OnPackagePublishedChanging(DTO.PackageBuilder.Package instance, bool? newValue)
            {
                return true;
            }

            private bool OnPackageRevisionDateChanging(DTO.PackageBuilder.Package instance, DateTime? newValue)
            {
                return true;
            }

            private bool OnPackageCostOfSaleChanging(DTO.PackageBuilder.Package instance, decimal? newValue)
            {
                return true;
            }

            private bool OnPackageRecomendedRetailPriceChanging(DTO.PackageBuilder.Package instance, decimal? newValue)
            {
                return true;
            }

            private bool OnPackageStateChanging(DTO.PackageBuilder.Package instance, DTO.State newValue)
            {
                if (this != newValue.Context)
                {
                    throw GetDifferentContextsException();
                }
                return true;
            }

            private void OnPackageStateChanged(DTO.PackageBuilder.Package instance, DTO.State oldValue)
            {
                ((ICollection<DTO.PackageBuilder.Package>)instance.State.PackageViaStateCollection).Add(instance);
                if (oldValue != null)
                {
                    ((ICollection<DTO.PackageBuilder.Package>)oldValue.PackageViaStateCollection).Remove(instance);
                }
            }

            private bool OnPackageIndustryChanging(DTO.PackageBuilder.Package instance, DTO.Industry newValue)
            {
                if (newValue != null)
                {
                    if (this != newValue.Context)
                    {
                        throw GetDifferentContextsException();
                    }
                }
                return true;
            }

            private void OnPackageIndustryChanged(DTO.PackageBuilder.Package instance, DTO.Industry oldValue)
            {
                if (instance.Industry != null)
                {
                    ((ICollection<DTO.PackageBuilder.Package>)instance.Industry.PackageViaIndustryCollection).Add(instance);
                }
                if (oldValue != null)
                {
                    ((ICollection<DTO.PackageBuilder.Package>)oldValue.PackageViaIndustryCollection).Remove(instance);
                }
            }

            private bool OnPackagePackageDataFieldViaPackageCollectionAdding(DTO.PackageBuilder.Package instance, PackageDataField item)
            {
                if (this != item.Context)
                {
                    throw GetDifferentContextsException("item");
                }
                return true;
            }

            private void OnPackagePackageDataFieldViaPackageCollectionAdded(DTO.PackageBuilder.Package instance, PackageDataField item)
            {
                item.Package = instance;
            }

            private void OnPackagePackageDataFieldViaPackageCollectionRemoved(DTO.PackageBuilder.Package instance, PackageDataField item)
            {
                if (item.Package == instance)
                {
                    item.Package = null;
                }
            }

            private readonly List<DTO.PackageBuilder.Package> _PackageList;
            private readonly ReadOnlyCollection<DTO.PackageBuilder.Package> _PackageReadOnlyCollection;

            public IEnumerable<DTO.PackageBuilder.Package> PackageCollection
            {
                get { return _PackageReadOnlyCollection; }
            }

            #region PackageCore

            [StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
            private sealed class PackageCore : DTO.PackageBuilder.Package
            {
                public PackageCore(PackageBuilderContext context, string Name, string Description, string Version,
                    DTO.State State)
                {
                    _Context = context;
                    _PackageDataFieldViaPackageCollection =
                        new ConstraintEnforcementCollection<DTO.PackageBuilder.Package, PackageDataField>(this);
                    _Name = Name;
                    context.OnPackageNameChanged(this, null);
                    _Description = Description;
                    _Version = Version;
                    context.OnPackageVersionChanged(this, null);
                    _State = State;
                    context.OnPackageStateChanged(this, null);
                    context._PackageList.Add(this);
                }

                private readonly PackageBuilderContext _Context;

                public override PackageBuilderContext Context
                {
                    get { return _Context; }
                }

                private string _Name;

                public override string Name
                {
                    get { return _Name; }
                    set
                    {
                        if ((object)value == null)
                        {
                            throw new ArgumentNullException("value");
                        }
                        string oldValue = _Name;
                        if (oldValue != (object)value && !value.Equals(oldValue))
                        {
                            if (_Context.OnPackageNameChanging(this, value) && base.OnNameChanging(value))
                            {
                                _Name = value;
                                _Context.OnPackageNameChanged(this, oldValue);
                                base.OnNameChanged(oldValue);
                            }
                        }
                    }
                }

                private string _Description;

                public override string Description
                {
                    get { return _Description; }
                    set
                    {
                        if ((object)value == null)
                        {
                            throw new ArgumentNullException("value");
                        }
                        string oldValue = _Description;
                        if (oldValue != (object)value && !value.Equals(oldValue))
                        {
                            if (_Context.OnPackageDescriptionChanging(this, value) && base.OnDescriptionChanging(value))
                            {
                                _Description = value;
                                base.OnDescriptionChanged(oldValue);
                            }
                        }
                    }
                }

                private string _Owner;

                public override string Owner
                {
                    get { return _Owner; }
                    set
                    {
                        string oldValue = _Owner;
                        if (!Equals(oldValue, value))
                        {
                            if (_Context.OnPackageOwnerChanging(this, value) && base.OnOwnerChanging(value))
                            {
                                _Owner = value;
                                base.OnOwnerChanged(oldValue);
                            }
                        }
                    }
                }

                private DateTime? _Created;

                public override DateTime? Created
                {
                    get { return _Created; }
                    set
                    {
                        DateTime? oldValue = _Created;
                        if (oldValue.GetValueOrDefault() != value.GetValueOrDefault() ||
                            oldValue.HasValue != value.HasValue)
                        {
                            if (_Context.OnPackageCreatedChanging(this, value) && base.OnCreatedChanging(value))
                            {
                                _Created = value;
                                base.OnCreatedChanged(oldValue);
                            }
                        }
                    }
                }

                private DateTime? _Edited;

                public override DateTime? Edited
                {
                    get { return _Edited; }
                    set
                    {
                        DateTime? oldValue = _Edited;
                        if (oldValue.GetValueOrDefault() != value.GetValueOrDefault() ||
                            oldValue.HasValue != value.HasValue)
                        {
                            if (_Context.OnPackageEditedChanging(this, value) && base.OnEditedChanging(value))
                            {
                                _Edited = value;
                                base.OnEditedChanged(oldValue);
                            }
                        }
                    }
                }

                private string _Version;

                public override string Version
                {
                    get { return _Version; }
                    set
                    {
                        if ((object)value == null)
                        {
                            throw new ArgumentNullException("value");
                        }
                        string oldValue = _Version;
                        if (oldValue != (object)value && !value.Equals(oldValue))
                        {
                            if (_Context.OnPackageVersionChanging(this, value) && base.OnVersionChanging(value))
                            {
                                _Version = value;
                                _Context.OnPackageVersionChanged(this, oldValue);
                                base.OnVersionChanged(oldValue);
                            }
                        }
                    }
                }

                private bool? _Published;

                public override bool? Published
                {
                    get { return _Published; }
                    set
                    {
                        bool? oldValue = _Published;
                        if (oldValue.GetValueOrDefault() != value.GetValueOrDefault() ||
                            oldValue.HasValue != value.HasValue)
                        {
                            if (_Context.OnPackagePublishedChanging(this, value) && base.OnPublishedChanging(value))
                            {
                                _Published = value;
                                base.OnPublishedChanged(oldValue);
                            }
                        }
                    }
                }

                private DateTime? _RevisionDate;

                public override DateTime? RevisionDate
                {
                    get { return _RevisionDate; }
                    set
                    {
                        DateTime? oldValue = _RevisionDate;
                        if (oldValue.GetValueOrDefault() != value.GetValueOrDefault() ||
                            oldValue.HasValue != value.HasValue)
                        {
                            if (_Context.OnPackageRevisionDateChanging(this, value) &&
                                base.OnRevisionDateChanging(value))
                            {
                                _RevisionDate = value;
                                base.OnRevisionDateChanged(oldValue);
                            }
                        }
                    }
                }

                private decimal? _CostOfSale;

                public override decimal? CostOfSale
                {
                    get { return _CostOfSale; }
                    set
                    {
                        decimal? oldValue = _CostOfSale;
                        if (oldValue.GetValueOrDefault() != value.GetValueOrDefault() ||
                            oldValue.HasValue != value.HasValue)
                        {
                            if (_Context.OnPackageCostOfSaleChanging(this, value) && base.OnCostOfSaleChanging(value))
                            {
                                _CostOfSale = value;
                                base.OnCostOfSaleChanged(oldValue);
                            }
                        }
                    }
                }

                private decimal? _RecomendedRetailPrice;

                public override decimal? RecomendedRetailPrice
                {
                    get { return _RecomendedRetailPrice; }
                    set
                    {
                        decimal? oldValue = _RecomendedRetailPrice;
                        if (oldValue.GetValueOrDefault() != value.GetValueOrDefault() ||
                            oldValue.HasValue != value.HasValue)
                        {
                            if (_Context.OnPackageRecomendedRetailPriceChanging(this, value) &&
                                base.OnRecomendedRetailPriceChanging(value))
                            {
                                _RecomendedRetailPrice = value;
                                base.OnRecomendedRetailPriceChanged(oldValue);
                            }
                        }
                    }
                }

                private DTO.State _State;

                public override DTO.State State
                {
                    get { return _State; }
                    set
                    {
                        if (value == null)
                        {
                            throw new ArgumentNullException("value");
                        }
                        DTO.State oldValue = _State;
                        if (oldValue != value)
                        {
                            if (_Context.OnPackageStateChanging(this, value) && base.OnStateChanging(value))
                            {
                                _State = value;
                                _Context.OnPackageStateChanged(this, oldValue);
                                base.OnStateChanged(oldValue);
                            }
                        }
                    }
                }

                private DTO.Industry _Industry;

                public override DTO.Industry Industry
                {
                    get { return _Industry; }
                    set
                    {
                        DTO.Industry oldValue = _Industry;
                        if (oldValue != value)
                        {
                            if (_Context.OnPackageIndustryChanging(this, value) && base.OnIndustryChanging(value))
                            {
                                _Industry = value;
                                _Context.OnPackageIndustryChanged(this, oldValue);
                                base.OnIndustryChanged(oldValue);
                            }
                        }
                    }
                }

                private readonly IEnumerable<PackageDataField> _PackageDataFieldViaPackageCollection;

                public override IEnumerable<PackageDataField> PackageDataFieldViaPackageCollection
                {
                    get { return _PackageDataFieldViaPackageCollection; }
                }
            }

            #endregion // PackageCore

            #endregion // Package

            #region State

            public DTO.State CreateState(string value)
            {
                if ((object)value == null)
                {
                    throw new ArgumentNullException("value");
                }

                // check constraint values

                var isValid = false;
                foreach (var constraintValue in DTO.State.ConstraintValues)
                {
                    if (value == constraintValue) isValid = true;

                    break;
                }

                if (!isValid)
                {
                    throw new ArgumentNullException("value");
                }


                if (!OnStateValueChanging(null, value))
                {
                    throw GetConstraintEnforcementFailedException("Value");
                }
                return new StateCore(this, value);
            }

            private bool OnStateValueChanging(DTO.State instance, string newValue)
            {
                return true;
            }

            private bool OnStatePackageViaStateCollectionAdding(DTO.State instance, DTO.PackageBuilder.Package item)
            {
                if (this != item.Context)
                {
                    throw GetDifferentContextsException("item");
                }
                return true;
            }

            private void OnStatePackageViaStateCollectionAdded(DTO.State instance, DTO.PackageBuilder.Package item)
            {
                item.State = instance;
            }

            private void OnStatePackageViaStateCollectionRemoved(DTO.State instance, DTO.PackageBuilder.Package item)
            {
                if (item.State == instance)
                {
                    item.State = null;
                }
            }

            private bool OnStateDataProviderViaStateCollectionAdding(DTO.State instance, DataProvider item)
            {
                if (this != item.Context)
                {
                    throw GetDifferentContextsException("item");
                }
                return true;
            }

            private void OnStateDataProviderViaStateCollectionAdded(DTO.State instance, DataProvider item)
            {
                item.State = instance;
            }

            private void OnStateDataProviderViaStateCollectionRemoved(DTO.State instance, DataProvider item)
            {
                if (item.State == instance)
                {
                    item.State = null;
                }
            }

            private readonly List<DTO.State> _StateList;
            private readonly ReadOnlyCollection<DTO.State> _StateReadOnlyCollection;

            public IEnumerable<DTO.State> StateCollection
            {
                get { return _StateReadOnlyCollection; }
            }

            #region StateCore

            [StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
            private sealed class StateCore : DTO.State
            {
                public StateCore(PackageBuilderContext context, string Value)
                {
                    _Context = context;
                    _PackageViaStateCollection = new ConstraintEnforcementCollection<DTO.State, DTO.PackageBuilder.Package>(this);
                    _DataProviderViaStateCollection = new ConstraintEnforcementCollection<DTO.State, DataProvider>(this);
                    _Value = Value;
                    context._StateList.Add(this);
                }

                private readonly PackageBuilderContext _Context;

                public override PackageBuilderContext Context
                {
                    get { return _Context; }
                }

                private string _Value;

                public override string Value
                {
                    get { return _Value; }
                    set
                    {
                        if ((object)value == null)
                        {
                            throw new ArgumentNullException("value");
                        }
                        string oldValue = _Value;
                        if (oldValue != (object)value && !value.Equals(oldValue))
                        {
                            if (_Context.OnStateValueChanging(this, value) && base.OnValueChanging(value))
                            {
                                _Value = value;
                                base.OnValueChanged(oldValue);
                            }
                        }
                    }
                }

                private readonly IEnumerable<DTO.PackageBuilder.Package> _PackageViaStateCollection;

                public override IEnumerable<DTO.PackageBuilder.Package> PackageViaStateCollection
                {
                    get { return _PackageViaStateCollection; }
                }

                private readonly IEnumerable<DataProvider> _DataProviderViaStateCollection;

                public override IEnumerable<DataProvider> DataProviderViaStateCollection
                {
                    get { return _DataProviderViaStateCollection; }
                }
            }

            #endregion // StateCore

            #endregion // State

            #region DataProvider

            public DataProvider CreateDataProvider(string Name, string Owner, string Version, string SourceURL,
                DTO.State State)
            {
                if ((object)Name == null)
                {
                    throw new ArgumentNullException("Name");
                }
                if ((object)Owner == null)
                {
                    throw new ArgumentNullException("Owner");
                }
                if ((object)Version == null)
                {
                    throw new ArgumentNullException("Version");
                }
                if ((object)SourceURL == null)
                {
                    throw new ArgumentNullException("SourceURL");
                }
                if (State == null)
                {
                    throw new ArgumentNullException("State");
                }
                if (!OnDataProviderNameChanging(null, Name))
                {
                    throw GetConstraintEnforcementFailedException("Name");
                }
                if (!OnDataProviderOwnerChanging(null, Owner))
                {
                    throw GetConstraintEnforcementFailedException("Owner");
                }
                if (!OnDataProviderVersionChanging(null, Version))
                {
                    throw GetConstraintEnforcementFailedException("Version");
                }
                if (!OnDataProviderSourceURLChanging(null, SourceURL))
                {
                    throw GetConstraintEnforcementFailedException("SourceURL");
                }
                if (!OnDataProviderStateChanging(null, State))
                {
                    throw GetConstraintEnforcementFailedException("State");
                }
                return new DataProviderCore(this, Name, Owner, Version, SourceURL, State);
            }

            private bool OnDataProviderNameChanging(DataProvider instance, string newValue)
            {
                if (instance != null)
                {
                    if (
                        !OnDataProviderNameAndVersionUniquenessConstraintChanging(instance,
                            new System.Tuple<string, string>(newValue, instance.Version)))
                    {
                        return false;
                    }
                }
                return true;
            }

            private void OnDataProviderNameChanged(DataProvider instance, string oldValue)
            {
                System.Tuple<string, string> DataProviderNameAndVersionUniquenessConstraintOldValueTuple;
                if ((object)oldValue != null)
                {
                    DataProviderNameAndVersionUniquenessConstraintOldValueTuple = new System.Tuple<string, string>(oldValue,
                        instance.Version);
                }
                else
                {
                    DataProviderNameAndVersionUniquenessConstraintOldValueTuple = null;
                }
                OnDataProviderNameAndVersionUniquenessConstraintChanged(instance,
                    DataProviderNameAndVersionUniquenessConstraintOldValueTuple,
                    new System.Tuple<string, string>(instance.Name, instance.Version));
            }

            private bool OnDataProviderDescriptionChanging(DataProvider instance, string newValue)
            {
                return true;
            }

            private bool OnDataProviderOwnerChanging(DataProvider instance, string newValue)
            {
                return true;
            }

            private bool OnDataProviderCreatedChanging(DataProvider instance, DateTime? newValue)
            {
                return true;
            }

            private bool OnDataProviderEditedChanging(DataProvider instance, DateTime? newValue)
            {
                return true;
            }

            private bool OnDataProviderVersionChanging(DataProvider instance, string newValue)
            {
                if (instance != null)
                {
                    if (
                        !OnDataProviderNameAndVersionUniquenessConstraintChanging(instance,
                            new System.Tuple<string, string>(instance.Name, newValue)))
                    {
                        return false;
                    }
                }
                return true;
            }

            private void OnDataProviderVersionChanged(DataProvider instance, string oldValue)
            {
                System.Tuple<string, string> DataProviderNameAndVersionUniquenessConstraintOldValueTuple;
                if ((object)oldValue != null)
                {
                    DataProviderNameAndVersionUniquenessConstraintOldValueTuple =
                        new System.Tuple<string, string>(instance.Name, oldValue);
                }
                else
                {
                    DataProviderNameAndVersionUniquenessConstraintOldValueTuple = null;
                }
                OnDataProviderNameAndVersionUniquenessConstraintChanged(instance,
                    DataProviderNameAndVersionUniquenessConstraintOldValueTuple,
                    new System.Tuple<string, string>(instance.Name, instance.Version));
            }

            private bool OnDataProviderCostOfSaleChanging(DataProvider instance, decimal? newValue)
            {
                return true;
            }

            private bool OnDataProviderRevisionDateChanging(DataProvider instance, DateTime? newValue)
            {
                return true;
            }

            private bool OnDataProviderSourceURLChanging(DataProvider instance, string newValue)
            {
                return true;
            }

            private bool OnDataProviderStateChanging(DataProvider instance, DTO.State newValue)
            {
                if (this != newValue.Context)
                {
                    throw GetDifferentContextsException();
                }
                return true;
            }

            private void OnDataProviderStateChanged(DataProvider instance, DTO.State oldValue)
            {
                ((ICollection<DataProvider>)instance.State.DataProviderViaStateCollection).Add(instance);
                if (oldValue != null)
                {
                    ((ICollection<DataProvider>)oldValue.DataProviderViaStateCollection).Remove(instance);
                }
            }

            private bool OnDataProviderDataFieldViaDataProviderCollectionAdding(DataProvider instance, DataField item)
            {
                if (this != item.Context)
                {
                    throw GetDifferentContextsException("item");
                }
                return true;
            }

            private void OnDataProviderDataFieldViaDataProviderCollectionAdded(DataProvider instance, DataField item)
            {
                item.DataProvider = instance;
            }

            private void OnDataProviderDataFieldViaDataProviderCollectionRemoved(DataProvider instance, DataField item)
            {
                if (item.DataProvider == instance)
                {
                    item.DataProvider = null;
                }
            }

            private readonly List<DataProvider> _DataProviderList;
            private readonly ReadOnlyCollection<DataProvider> _DataProviderReadOnlyCollection;

            public IEnumerable<DataProvider> DataProviderCollection
            {
                get { return _DataProviderReadOnlyCollection; }
            }

            #region DataProviderCore

            [StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
            private sealed class DataProviderCore : DataProvider
            {
                public DataProviderCore(PackageBuilderContext context, string Name, string Owner, string Version,
                    string SourceURL, DTO.State State)
                {
                    _Context = context;
                    _DataFieldViaDataProviderCollection =
                        new ConstraintEnforcementCollection<DataProvider, DataField>(this);
                    _Name = Name;
                    context.OnDataProviderNameChanged(this, null);
                    _Owner = Owner;
                    _Version = Version;
                    context.OnDataProviderVersionChanged(this, null);
                    _SourceURL = SourceURL;
                    _State = State;
                    context.OnDataProviderStateChanged(this, null);
                    context._DataProviderList.Add(this);
                }

                private readonly PackageBuilderContext _Context;

                public override PackageBuilderContext Context
                {
                    get { return _Context; }
                }

                private string _Name;

                public override string Name
                {
                    get { return _Name; }
                    set
                    {
                        if ((object)value == null)
                        {
                            throw new ArgumentNullException("value");
                        }
                        string oldValue = _Name;
                        if (oldValue != (object)value && !value.Equals(oldValue))
                        {
                            if (_Context.OnDataProviderNameChanging(this, value) && base.OnNameChanging(value))
                            {
                                _Name = value;
                                _Context.OnDataProviderNameChanged(this, oldValue);
                                base.OnNameChanged(oldValue);
                            }
                        }
                    }
                }

                private string _Description;

                public override string Description
                {
                    get { return _Description; }
                    set
                    {
                        string oldValue = _Description;
                        if (!Equals(oldValue, value))
                        {
                            if (_Context.OnDataProviderDescriptionChanging(this, value) &&
                                base.OnDescriptionChanging(value))
                            {
                                _Description = value;
                                base.OnDescriptionChanged(oldValue);
                            }
                        }
                    }
                }

                private string _Owner;

                public override string Owner
                {
                    get { return _Owner; }
                    set
                    {
                        if ((object)value == null)
                        {
                            throw new ArgumentNullException("value");
                        }
                        string oldValue = _Owner;
                        if (oldValue != (object)value && !value.Equals(oldValue))
                        {
                            if (_Context.OnDataProviderOwnerChanging(this, value) && base.OnOwnerChanging(value))
                            {
                                _Owner = value;
                                base.OnOwnerChanged(oldValue);
                            }
                        }
                    }
                }

                private DateTime? _Created;

                public override DateTime? Created
                {
                    get { return _Created; }
                    set
                    {
                        DateTime? oldValue = _Created;
                        if (oldValue.GetValueOrDefault() != value.GetValueOrDefault() ||
                            oldValue.HasValue != value.HasValue)
                        {
                            if (_Context.OnDataProviderCreatedChanging(this, value) && base.OnCreatedChanging(value))
                            {
                                _Created = value;
                                base.OnCreatedChanged(oldValue);
                            }
                        }
                    }
                }

                private DateTime? _Edited;

                public override DateTime? Edited
                {
                    get { return _Edited; }
                    set
                    {
                        DateTime? oldValue = _Edited;
                        if (oldValue.GetValueOrDefault() != value.GetValueOrDefault() ||
                            oldValue.HasValue != value.HasValue)
                        {
                            if (_Context.OnDataProviderEditedChanging(this, value) && base.OnEditedChanging(value))
                            {
                                _Edited = value;
                                base.OnEditedChanged(oldValue);
                            }
                        }
                    }
                }

                private string _Version;

                public override string Version
                {
                    get { return _Version; }
                    set
                    {
                        if ((object)value == null)
                        {
                            throw new ArgumentNullException("value");
                        }
                        string oldValue = _Version;
                        if (oldValue != (object)value && !value.Equals(oldValue))
                        {
                            if (_Context.OnDataProviderVersionChanging(this, value) && base.OnVersionChanging(value))
                            {
                                _Version = value;
                                _Context.OnDataProviderVersionChanged(this, oldValue);
                                base.OnVersionChanged(oldValue);
                            }
                        }
                    }
                }

                private decimal? _CostOfSale;

                public override decimal? CostOfSale
                {
                    get { return _CostOfSale; }
                    set
                    {
                        decimal? oldValue = _CostOfSale;
                        if (oldValue.GetValueOrDefault() != value.GetValueOrDefault() ||
                            oldValue.HasValue != value.HasValue)
                        {
                            if (_Context.OnDataProviderCostOfSaleChanging(this, value) &&
                                base.OnCostOfSaleChanging(value))
                            {
                                _CostOfSale = value;
                                base.OnCostOfSaleChanged(oldValue);
                            }
                        }
                    }
                }

                private DateTime? _RevisionDate;

                public override DateTime? RevisionDate
                {
                    get { return _RevisionDate; }
                    set
                    {
                        DateTime? oldValue = _RevisionDate;
                        if (oldValue.GetValueOrDefault() != value.GetValueOrDefault() ||
                            oldValue.HasValue != value.HasValue)
                        {
                            if (_Context.OnDataProviderRevisionDateChanging(this, value) &&
                                base.OnRevisionDateChanging(value))
                            {
                                _RevisionDate = value;
                                base.OnRevisionDateChanged(oldValue);
                            }
                        }
                    }
                }

                private string _SourceURL;

                public override string SourceURL
                {
                    get { return _SourceURL; }
                    set
                    {
                        if ((object)value == null)
                        {
                            throw new ArgumentNullException("value");
                        }
                        string oldValue = _SourceURL;
                        if (oldValue != (object)value && !value.Equals(oldValue))
                        {
                            if (_Context.OnDataProviderSourceURLChanging(this, value) && base.OnSourceURLChanging(value))
                            {
                                _SourceURL = value;
                                base.OnSourceURLChanged(oldValue);
                            }
                        }
                    }
                }

                private DTO.State _State;

                public override DTO.State State
                {
                    get { return _State; }
                    set
                    {
                        if (value == null)
                        {
                            throw new ArgumentNullException("value");
                        }
                        DTO.State oldValue = _State;
                        if (oldValue != value)
                        {
                            if (_Context.OnDataProviderStateChanging(this, value) && base.OnStateChanging(value))
                            {
                                _State = value;
                                _Context.OnDataProviderStateChanged(this, oldValue);
                                base.OnStateChanged(oldValue);
                            }
                        }
                    }
                }

                private readonly IEnumerable<DataField> _DataFieldViaDataProviderCollection;

                public override IEnumerable<DataField> DataFieldViaDataProviderCollection
                {
                    get { return _DataFieldViaDataProviderCollection; }
                }
            }

            #endregion // DataProviderCore

            #endregion // DataProvider

            #region DataField

            public DataField CreateDataField(bool Selected, decimal CostOfSale, string Name, DataProvider DataProvider,
                DTO.Industry Industry)
            {
                if ((object)Name == null)
                {
                    throw new ArgumentNullException("Name");
                }
                if (DataProvider == null)
                {
                    throw new ArgumentNullException("DataProvider");
                }
                if (Industry == null)
                {
                    throw new ArgumentNullException("Industry");
                }
                if (!OnDataFieldSelectedChanging(null, Selected))
                {
                    throw GetConstraintEnforcementFailedException("Selected");
                }
                if (!OnDataFieldCostOfSaleChanging(null, CostOfSale))
                {
                    throw GetConstraintEnforcementFailedException("CostOfSale");
                }
                if (!OnDataFieldNameChanging(null, Name))
                {
                    throw GetConstraintEnforcementFailedException("Name");
                }
                if (!OnDataFieldDataProviderChanging(null, DataProvider))
                {
                    throw GetConstraintEnforcementFailedException("DataProvider");
                }
                if (!OnDataFieldIndustryChanging(null, Industry))
                {
                    throw GetConstraintEnforcementFailedException("Industry");
                }
                return new DataFieldCore(this, Selected, CostOfSale, Name, DataProvider, Industry);
            }

            private bool OnDataFieldLabelChanging(DataField instance, string newValue)
            {
                return true;
            }

            private bool OnDataFieldTypeDefinitionChanging(DataField instance, string newValue)
            {
                return true;
            }

            private bool OnDataFieldSelectedChanging(DataField instance, bool newValue)
            {
                return true;
            }

            private bool OnDataFieldCostOfSaleChanging(DataField instance, decimal newValue)
            {
                return true;
            }

            private bool OnDataFieldNameChanging(DataField instance, string newValue)
            {
                DataField currentInstance;
                if (_DataFieldNameDictionary.TryGetValue(newValue, out currentInstance))
                {
                    if (currentInstance != instance)
                    {
                        return false;
                    }
                }
                return true;
            }

            private void OnDataFieldNameChanged(DataField instance, string oldValue)
            {
                _DataFieldNameDictionary.Add(instance.Name, instance);
                if ((object)oldValue != null)
                {
                    _DataFieldNameDictionary.Remove(oldValue);
                }
            }

            private bool OnDataFieldDataProviderChanging(DataField instance, DataProvider newValue)
            {
                if (this != newValue.Context)
                {
                    throw GetDifferentContextsException();
                }
                return true;
            }

            private void OnDataFieldDataProviderChanged(DataField instance, DataProvider oldValue)
            {
                ((ICollection<DataField>)instance.DataProvider.DataFieldViaDataProviderCollection).Add(instance);
                if (oldValue != null)
                {
                    ((ICollection<DataField>)oldValue.DataFieldViaDataProviderCollection).Remove(instance);
                }
            }

            private bool OnDataFieldIndustryChanging(DataField instance, DTO.Industry newValue)
            {
                if (this != newValue.Context)
                {
                    throw GetDifferentContextsException();
                }
                return true;
            }

            private void OnDataFieldIndustryChanged(DataField instance, DTO.Industry oldValue)
            {
                ((ICollection<DataField>)instance.Industry.DataFieldViaIndustryCollection).Add(instance);
                if (oldValue != null)
                {
                    ((ICollection<DataField>)oldValue.DataFieldViaIndustryCollection).Remove(instance);
                }
            }

            private bool OnDataFieldPackageDataFieldViaDataFieldCollectionAdding(DataField instance,
                PackageDataField item)
            {
                if (this != item.Context)
                {
                    throw GetDifferentContextsException("item");
                }
                return true;
            }

            private void OnDataFieldPackageDataFieldViaDataFieldCollectionAdded(DataField instance,
                PackageDataField item)
            {
                item.DataField = instance;
            }

            private void OnDataFieldPackageDataFieldViaDataFieldCollectionRemoved(DataField instance,
                PackageDataField item)
            {
                if (item.DataField == instance)
                {
                    item.DataField = null;
                }
            }

            private readonly List<DataField> _DataFieldList;
            private readonly ReadOnlyCollection<DataField> _DataFieldReadOnlyCollection;

            public IEnumerable<DataField> DataFieldCollection
            {
                get { return _DataFieldReadOnlyCollection; }
            }

            #region DataFieldCore

            [StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
            private sealed class DataFieldCore : DataField
            {
                public DataFieldCore(PackageBuilderContext context, bool Selected, decimal CostOfSale, string Name,
                    DataProvider DataProvider, DTO.Industry Industry)
                {
                    _Context = context;
                    _PackageDataFieldViaDataFieldCollection =
                        new ConstraintEnforcementCollection<DataField, PackageDataField>(this);
                    _Selected = Selected;
                    _CostOfSale = CostOfSale;
                    _Name = Name;
                    context.OnDataFieldNameChanged(this, null);
                    _DataProvider = DataProvider;
                    context.OnDataFieldDataProviderChanged(this, null);
                    _Industry = Industry;
                    context.OnDataFieldIndustryChanged(this, null);
                    context._DataFieldList.Add(this);
                }

                private readonly PackageBuilderContext _Context;

                public override PackageBuilderContext Context
                {
                    get { return _Context; }
                }

                private string _Label;

                public override string Label
                {
                    get { return _Label; }
                    set
                    {
                        string oldValue = _Label;
                        if (!Equals(oldValue, value))
                        {
                            if (_Context.OnDataFieldLabelChanging(this, value) && base.OnLabelChanging(value))
                            {
                                _Label = value;
                                base.OnLabelChanged(oldValue);
                            }
                        }
                    }
                }

                private string _TypeDefinition;

                public override string TypeDefinition
                {
                    get { return _TypeDefinition; }
                    set
                    {
                        string oldValue = _TypeDefinition;
                        if (!Equals(oldValue, value))
                        {
                            if (_Context.OnDataFieldTypeDefinitionChanging(this, value) &&
                                base.OnTypeDefinitionChanging(value))
                            {
                                _TypeDefinition = value;
                                base.OnTypeDefinitionChanged(oldValue);
                            }
                        }
                    }
                }

                private bool _Selected;

                public override bool Selected
                {
                    get { return _Selected; }
                    set
                    {
                        bool oldValue = _Selected;
                        if (oldValue != value)
                        {
                            if (_Context.OnDataFieldSelectedChanging(this, value) && base.OnSelectedChanging(value))
                            {
                                _Selected = value;
                                base.OnSelectedChanged(oldValue);
                            }
                        }
                    }
                }

                private decimal _CostOfSale;

                public override decimal CostOfSale
                {
                    get { return _CostOfSale; }
                    set
                    {
                        decimal oldValue = _CostOfSale;
                        if (oldValue != value)
                        {
                            if (_Context.OnDataFieldCostOfSaleChanging(this, value) && base.OnCostOfSaleChanging(value))
                            {
                                _CostOfSale = value;
                                base.OnCostOfSaleChanged(oldValue);
                            }
                        }
                    }
                }

                private string _Name;

                public override string Name
                {
                    get { return _Name; }
                    set
                    {
                        if ((object)value == null)
                        {
                            throw new ArgumentNullException("value");
                        }
                        string oldValue = _Name;
                        if (oldValue != (object)value && !value.Equals(oldValue))
                        {
                            if (_Context.OnDataFieldNameChanging(this, value) && base.OnNameChanging(value))
                            {
                                _Name = value;
                                _Context.OnDataFieldNameChanged(this, oldValue);
                                base.OnNameChanged(oldValue);
                            }
                        }
                    }
                }

                private DataProvider _DataProvider;

                public override DataProvider DataProvider
                {
                    get { return _DataProvider; }
                    set
                    {
                        if (value == null)
                        {
                            throw new ArgumentNullException("value");
                        }
                        DataProvider oldValue = _DataProvider;
                        if (oldValue != value)
                        {
                            if (_Context.OnDataFieldDataProviderChanging(this, value) &&
                                base.OnDataProviderChanging(value))
                            {
                                _DataProvider = value;
                                _Context.OnDataFieldDataProviderChanged(this, oldValue);
                                base.OnDataProviderChanged(oldValue);
                            }
                        }
                    }
                }

                private DTO.Industry _Industry;

                public override DTO.Industry Industry
                {
                    get { return _Industry; }
                    set
                    {
                        if (value == null)
                        {
                            throw new ArgumentNullException("value");
                        }
                        DTO.Industry oldValue = _Industry;
                        if (oldValue != value)
                        {
                            if (_Context.OnDataFieldIndustryChanging(this, value) && base.OnIndustryChanging(value))
                            {
                                _Industry = value;
                                _Context.OnDataFieldIndustryChanged(this, oldValue);
                                base.OnIndustryChanged(oldValue);
                            }
                        }
                    }
                }

                private readonly IEnumerable<PackageDataField> _PackageDataFieldViaDataFieldCollection;

                public override IEnumerable<PackageDataField> PackageDataFieldViaDataFieldCollection
                {
                    get { return _PackageDataFieldViaDataFieldCollection; }
                }
            }

            #endregion // DataFieldCore

            #endregion // DataField

            #region PackageDataField

            public PackageDataField CreatePackageDataField(int Priority, string UnifiedName, bool Selected,
                DTO.PackageBuilder.Package Package, DataField DataField)
            {
                if ((object)UnifiedName == null)
                {
                    throw new ArgumentNullException("UnifiedName");
                }
                if (Package == null)
                {
                    throw new ArgumentNullException("Package");
                }
                if (DataField == null)
                {
                    throw new ArgumentNullException("DataField");
                }
                if (!OnPackageDataFieldPriorityChanging(null, Priority))
                {
                    throw GetConstraintEnforcementFailedException("Priority");
                }
                if (!OnPackageDataFieldUnifiedNameChanging(null, UnifiedName))
                {
                    throw GetConstraintEnforcementFailedException("UnifiedName");
                }
                if (!OnPackageDataFieldSelectedChanging(null, Selected))
                {
                    throw GetConstraintEnforcementFailedException("Selected");
                }
                if (!OnPackageDataFieldPackageChanging(null, Package))
                {
                    throw GetConstraintEnforcementFailedException("Package");
                }
                if (!OnPackageDataFieldDataFieldChanging(null, DataField))
                {
                    throw GetConstraintEnforcementFailedException("DataField");
                }
                return new PackageDataFieldCore(this, Priority, UnifiedName, Selected, Package, DataField);
            }

            private bool OnPackageDataFieldPriorityChanging(PackageDataField instance, int newValue)
            {
                return true;
            }

            private bool OnPackageDataFieldUnifiedNameChanging(PackageDataField instance, string newValue)
            {
                return true;
            }

            private bool OnPackageDataFieldSelectedChanging(PackageDataField instance, bool newValue)
            {
                return true;
            }

            private bool OnPackageDataFieldPackageChanging(PackageDataField instance, DTO.PackageBuilder.Package newValue)
            {
                if (this != newValue.Context)
                {
                    throw GetDifferentContextsException();
                }
                return true;
            }

            private void OnPackageDataFieldPackageChanged(PackageDataField instance, DTO.PackageBuilder.Package oldValue)
            {
                ((ICollection<PackageDataField>)instance.Package.PackageDataFieldViaPackageCollection).Add(instance);
                if (oldValue != null)
                {
                    ((ICollection<PackageDataField>)oldValue.PackageDataFieldViaPackageCollection).Remove(instance);
                }
            }

            private bool OnPackageDataFieldDataFieldChanging(PackageDataField instance, DataField newValue)
            {
                if (this != newValue.Context)
                {
                    throw GetDifferentContextsException();
                }
                return true;
            }

            private void OnPackageDataFieldDataFieldChanged(PackageDataField instance, DataField oldValue)
            {
                ((ICollection<PackageDataField>)instance.DataField.PackageDataFieldViaDataFieldCollection).Add(instance);
                if (oldValue != null)
                {
                    ((ICollection<PackageDataField>)oldValue.PackageDataFieldViaDataFieldCollection).Remove(instance);
                }
            }

            private readonly List<PackageDataField> _PackageDataFieldList;
            private readonly ReadOnlyCollection<PackageDataField> _PackageDataFieldReadOnlyCollection;

            public IEnumerable<PackageDataField> PackageDataFieldCollection
            {
                get { return _PackageDataFieldReadOnlyCollection; }
            }

            #region PackageDataFieldCore

            [StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
            private sealed class PackageDataFieldCore : PackageDataField
            {
                public PackageDataFieldCore(PackageBuilderContext context, int priority, string unifiedName,
                    bool selected, DTO.PackageBuilder.Package package, DataField dataField)
                {
                    _Context = context;
                    _Priority = priority;
                    _UnifiedName = unifiedName;
                    _Selected = selected;
                    _Package = package;
                    context.OnPackageDataFieldPackageChanged(this, null);
                    _DataField = dataField;
                    context.OnPackageDataFieldDataFieldChanged(this, null);
                    context._PackageDataFieldList.Add(this);
                }

                private readonly PackageBuilderContext _Context;

                public override PackageBuilderContext Context
                {
                    get { return _Context; }
                }

                private int _Priority;

                public override int Priority
                {
                    get { return _Priority; }
                    set
                    {
                        int oldValue = _Priority;
                        if (oldValue != value)
                        {
                            if (_Context.OnPackageDataFieldPriorityChanging(this, value) &&
                                base.OnPriorityChanging(value))
                            {
                                _Priority = value;
                                base.OnPriorityChanged(oldValue);
                            }
                        }
                    }
                }

                private string _UnifiedName;

                public override string UnifiedName
                {
                    get { return _UnifiedName; }
                    set
                    {
                        if ((object)value == null)
                        {
                            throw new ArgumentNullException("value");
                        }
                        string oldValue = _UnifiedName;
                        if (oldValue != (object)value && !value.Equals(oldValue))
                        {
                            if (_Context.OnPackageDataFieldUnifiedNameChanging(this, value) &&
                                base.OnUnifiedNameChanging(value))
                            {
                                _UnifiedName = value;
                                base.OnUnifiedNameChanged(oldValue);
                            }
                        }
                    }
                }

                private bool _Selected;

                public override bool Selected
                {
                    get { return _Selected; }
                    set
                    {
                        bool oldValue = _Selected;
                        if (oldValue != value)
                        {
                            if (_Context.OnPackageDataFieldSelectedChanging(this, value) &&
                                base.OnSelectedChanging(value))
                            {
                                _Selected = value;
                                base.OnSelectedChanged(oldValue);
                            }
                        }
                    }
                }

                private DTO.PackageBuilder.Package _Package;

                public override DTO.PackageBuilder.Package Package
                {
                    get { return _Package; }
                    set
                    {
                        if (value == null)
                        {
                            throw new ArgumentNullException("value");
                        }
                        DTO.PackageBuilder.Package oldValue = _Package;
                        if (oldValue != value)
                        {
                            if (_Context.OnPackageDataFieldPackageChanging(this, value) && base.OnPackageChanging(value))
                            {
                                _Package = value;
                                _Context.OnPackageDataFieldPackageChanged(this, oldValue);
                                base.OnPackageChanged(oldValue);
                            }
                        }
                    }
                }

                private DataField _DataField;

                public override DataField DataField
                {
                    get { return _DataField; }
                    set
                    {
                        if (value == null)
                        {
                            throw new ArgumentNullException("value");
                        }
                        DataField oldValue = _DataField;
                        if (oldValue != value)
                        {
                            if (_Context.OnPackageDataFieldDataFieldChanging(this, value) &&
                                base.OnDataFieldChanging(value))
                            {
                                _DataField = value;
                                _Context.OnPackageDataFieldDataFieldChanged(this, oldValue);
                                base.OnDataFieldChanged(oldValue);
                            }
                        }
                    }
                }
            }

            #endregion // PackageDataFieldCore

            #endregion // PackageDataField

            #region Industry

            public DTO.Industry CreateIndustry(string Value)
            {
                if ((object)Value == null)
                {
                    throw new ArgumentNullException("Value");
                }
                if (!OnIndustryValueChanging(null, Value))
                {
                    throw GetConstraintEnforcementFailedException("Value");
                }
                return new IndustryCore(this, Value);
            }

            private bool OnIndustryValueChanging(DTO.Industry instance, string newValue)
            {
                return true;
            }

            private bool OnIndustryPackageViaIndustryCollectionAdding(DTO.Industry instance, DTO.PackageBuilder.Package item)
            {
                if (this != item.Context)
                {
                    throw GetDifferentContextsException("item");
                }
                return true;
            }

            private void OnIndustryPackageViaIndustryCollectionAdded(DTO.Industry instance, DTO.PackageBuilder.Package item)
            {
                item.Industry = instance;
            }

            private void OnIndustryPackageViaIndustryCollectionRemoved(DTO.Industry instance, DTO.PackageBuilder.Package item)
            {
                if (item.Industry == instance)
                {
                    item.Industry = null;
                }
            }

            private bool OnIndustryDataFieldViaIndustryCollectionAdding(DTO.Industry instance, DataField item)
            {
                if (this != item.Context)
                {
                    throw GetDifferentContextsException("item");
                }
                return true;
            }

            private void OnIndustryDataFieldViaIndustryCollectionAdded(DTO.Industry instance, DataField item)
            {
                item.Industry = instance;
            }

            private void OnIndustryDataFieldViaIndustryCollectionRemoved(DTO.Industry instance, DataField item)
            {
                if (item.Industry == instance)
                {
                    item.Industry = null;
                }
            }

            private readonly List<DTO.Industry> _IndustryList;
            private readonly ReadOnlyCollection<DTO.Industry> _IndustryReadOnlyCollection;

            public IEnumerable<DTO.Industry> IndustryCollection
            {
                get { return _IndustryReadOnlyCollection; }
            }

            #region IndustryCore

            [StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
            private sealed class IndustryCore : DTO.Industry
            {
                public IndustryCore(PackageBuilderContext context, string Value)
                {
                    _Context = context;
                    _PackageViaIndustryCollection = new ConstraintEnforcementCollection<DTO.Industry, DTO.PackageBuilder.Package>(this);
                    _DataFieldViaIndustryCollection = new ConstraintEnforcementCollection<DTO.Industry, DataField>(this);
                    _Value = Value;
                    context._IndustryList.Add(this);
                }

                private readonly PackageBuilderContext _Context;

                public override PackageBuilderContext Context
                {
                    get { return _Context; }
                }

                private string _Value;

                public override string Value
                {
                    get { return _Value; }
                    set
                    {
                        if ((object)value == null)
                        {
                            throw new ArgumentNullException("value");
                        }
                        string oldValue = _Value;
                        if (oldValue != (object)value && !value.Equals(oldValue))
                        {
                            if (_Context.OnIndustryValueChanging(this, value) && base.OnValueChanging(value))
                            {
                                _Value = value;
                                base.OnValueChanged(oldValue);
                            }
                        }
                    }
                }

                private readonly IEnumerable<DTO.PackageBuilder.Package> _PackageViaIndustryCollection;

                public override IEnumerable<DTO.PackageBuilder.Package> PackageViaIndustryCollection
                {
                    get { return _PackageViaIndustryCollection; }
                }

                private readonly IEnumerable<DataField> _DataFieldViaIndustryCollection;

                public override IEnumerable<DataField> DataFieldViaIndustryCollection
                {
                    get { return _DataFieldViaIndustryCollection; }
                }
            }

            #endregion // IndustryCore

            #endregion // Industry
        }

        #endregion // PackageBuilderContext
    }
}