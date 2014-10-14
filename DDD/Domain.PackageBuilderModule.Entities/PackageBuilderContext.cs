using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace LightstoneApp.Domain.PackageBuilderModule.Entities
{
    namespace PackageBuilder
    {

        #region PackageBuilderContext
        
        public sealed class PackageBuilderContext : IPackageBuilderContext
        {
            public PackageBuilderContext()
            {
                Dictionary<RuntimeTypeHandle, object> constraintEnforcementCollectionCallbacksByTypeDictionary =
                    _ContraintEnforcementCollectionCallbacksByTypeDictionary =
                        new Dictionary<RuntimeTypeHandle, object>(9, RuntimeTypeHandleEqualityComparer.Instance);

                constraintEnforcementCollectionCallbacksByTypeDictionary.Add(
                    typeof (ConstraintEnforcementCollection<Abstract.PackageBuilder.Owner, Abstract.Package>).TypeHandle,
                    new ConstraintEnforcementCollectionCallbacks<Abstract.PackageBuilder.Owner, Abstract.Package>(
                        OnOwnerPackageViaPackageOwnerCollectionAdding, OnOwnerPackageViaPackageOwnerCollectionAdded,
                        null, OnOwnerPackageViaPackageOwnerCollectionRemoved));

                constraintEnforcementCollectionCallbacksByTypeDictionary.Add(
                    typeof (ConstraintEnforcementCollection<Abstract.PackageBuilder.Owner, Abstract.DataSource>).TypeHandle,
                    new ConstraintEnforcementCollectionCallbacks<Abstract.PackageBuilder.Owner, Abstract.DataSource>(
                        OnOwnerDataSourceViaDataSourceOwnerCollectionAdding,
                        OnOwnerDataSourceViaDataSourceOwnerCollectionAdded, null,
                        OnOwnerDataSourceViaDataSourceOwnerCollectionRemoved));

                constraintEnforcementCollectionCallbacksByTypeDictionary.Add(
                    typeof (ConstraintEnforcementCollection<Abstract.State, Abstract.Package>).TypeHandle,
                    new ConstraintEnforcementCollectionCallbacks<Abstract.State, Abstract.Package>(
                        OnStatePackageViaPackageStateCollectionAdding, OnStatePackageViaPackageStateCollectionAdded,
                        null, OnStatePackageViaPackageStateCollectionRemoved));

                constraintEnforcementCollectionCallbacksByTypeDictionary.Add(
                    typeof (ConstraintEnforcementCollection<Abstract.State, Abstract.DataSource>).TypeHandle,
                    new ConstraintEnforcementCollectionCallbacks<Abstract.State, Abstract.DataSource>(
                        OnStateDataSourceViaDataSourceStateCollectionAdding,
                        OnStateDataSourceViaDataSourceStateCollectionAdded, null,
                        OnStateDataSourceViaDataSourceStateCollectionRemoved));

                constraintEnforcementCollectionCallbacksByTypeDictionary.Add(
                    typeof (ConstraintEnforcementCollection<Abstract.Industry, Abstract.Package>).TypeHandle,
                    new ConstraintEnforcementCollectionCallbacks<Abstract.Industry, Abstract.Package>(
                        OnIndustryPackageViaPackageIndustryCollectionAdding,
                        OnIndustryPackageViaPackageIndustryCollectionAdded, null,
                        OnIndustryPackageViaPackageIndustryCollectionRemoved));

                constraintEnforcementCollectionCallbacksByTypeDictionary.Add(
                    typeof (ConstraintEnforcementCollection<Abstract.Industry, Abstract.DateField>).TypeHandle,
                    new ConstraintEnforcementCollectionCallbacks<Abstract.Industry, Abstract.DateField>(
                        OnIndustryDateFieldViaIndustryCollectionAdding, OnIndustryDateFieldViaIndustryCollectionAdded,
                        null, OnIndustryDateFieldViaIndustryCollectionRemoved));

                constraintEnforcementCollectionCallbacksByTypeDictionary.Add(
                    typeof (ConstraintEnforcementCollection<Abstract.Package, Abstract.DataSource>).TypeHandle,
                    new ConstraintEnforcementCollectionCallbacks<Abstract.Package, Abstract.DataSource>(
                        OnPackageDataSourceViaPackageCollectionAdding, OnPackageDataSourceViaPackageCollectionAdded,
                        null, OnPackageDataSourceViaPackageCollectionRemoved));
                constraintEnforcementCollectionCallbacksByTypeDictionary.Add(
                    typeof (ConstraintEnforcementCollection<Abstract.DataSource, Abstract.DateField>).TypeHandle,
                    new ConstraintEnforcementCollectionCallbacks<Abstract.DataSource, Abstract.DateField>(
                        OnDataSourceDateFieldViaDataSourceCollectionAdding,
                        OnDataSourceDateFieldViaDataSourceCollectionAdded, null,
                        OnDataSourceDateFieldViaDataSourceCollectionRemoved));
                constraintEnforcementCollectionCallbacksByTypeDictionary.Add(
                    typeof (ConstraintEnforcementCollection<Abstract.DataSource, Abstract.FileAttachment>).TypeHandle,
                    new ConstraintEnforcementCollectionCallbacks<Abstract.DataSource, Abstract.FileAttachment>(
                        OnDataSourceFileAttachmentViaDataSourceCollectionAdding,
                        OnDataSourceFileAttachmentViaDataSourceCollectionAdded, null,
                        OnDataSourceFileAttachmentViaDataSourceCollectionRemoved));
                _OwnerReadOnlyCollection = new ReadOnlyCollection<Abstract.PackageBuilder.Owner>(_OwnerList = new List<Abstract.PackageBuilder.Owner>());
                _StateReadOnlyCollection = new ReadOnlyCollection<Abstract.State>(_StateList = new List<Abstract.State>());
                _IndustryReadOnlyCollection = new ReadOnlyCollection<Abstract.Industry>(_IndustryList = new List<Abstract.Industry>());
                _PackageReadOnlyCollection = new ReadOnlyCollection<Abstract.Package>(_PackageList = new List<Abstract.Package>());
                _DataSourceReadOnlyCollection =
                    new ReadOnlyCollection<Abstract.DataSource>(_DataSourceList = new List<Abstract.DataSource>());
                _DateFieldReadOnlyCollection = new ReadOnlyCollection<Abstract.DateField>(_DateFieldList = new List<Abstract.DateField>());
                _FileAttachmentReadOnlyCollection =
                    new ReadOnlyCollection<Abstract.FileAttachment>(_FileAttachmentList = new List<Abstract.FileAttachment>());
            }

            #region Exception Helpers

            private static ArgumentException GetDifferentContextsException()
            {
                return GetDifferentContextsException("value");
            }

            [SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly")]
            private static ArgumentException GetDifferentContextsException(string paramName)
            {
                return new ArgumentException(@"All objects in a relationship must be part of the same Context.",
                    paramName);
            }

            private static ArgumentException GetConstraintEnforcementFailedException(string paramName)
            {
                return new ArgumentException(@"Argument failed constraint enforcement.", paramName);
            }

            #endregion // Exception Helpers

            #region Lookup and External Constraint Enforcement

            private readonly Dictionary<string, Abstract.PackageBuilder.Owner> _OwnerOwnerValueDictionary = new Dictionary<string, Abstract.PackageBuilder.Owner>();

            public Abstract.PackageBuilder.Owner GetOwnerByOwnerValue(string OwnerValue)
            {
                return _OwnerOwnerValueDictionary[OwnerValue];
            }

            public bool TryGetOwnerByOwnerValue(string OwnerValue, out Abstract.PackageBuilder.Owner Owner)
            {
                return _OwnerOwnerValueDictionary.TryGetValue(OwnerValue, out Owner);
            }

            private readonly Dictionary<string, Abstract.State> _StateStateValueDictionary = new Dictionary<string, Abstract.State>();

            public Abstract.State GetStateByStateValue(string StateValue)
            {
                return _StateStateValueDictionary[StateValue];
            }

            public bool TryGetStateByStateValue(string StateValue, out Abstract.State State)
            {
                return _StateStateValueDictionary.TryGetValue(StateValue, out State);
            }

            private readonly Dictionary<string, Abstract.Industry> _IndustryIndustryValueDictionary =
                new Dictionary<string, Abstract.Industry>();

            public Abstract.Industry GetIndustryByIndustryValue(string IndustryValue)
            {
                return _IndustryIndustryValueDictionary[IndustryValue];
            }

            public bool TryGetIndustryByIndustryValue(string IndustryValue, out Abstract.Industry Industry)
            {
                return _IndustryIndustryValueDictionary.TryGetValue(IndustryValue, out Industry);
            }

            #endregion // Lookup and External Constraint Enforcement

            #region ConstraintEnforcementCollection

            private delegate bool PotentialCollectionModificationCallback<TClass, TProperty>(
                TClass instance, TProperty item)
                where TClass : class, IHasPackageBuilderContext;

            private delegate void CommittedCollectionModificationCallback<TClass, TProperty>(
                TClass instance, TProperty item)
                where TClass : class, IHasPackageBuilderContext;

            
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
                            typeof (ConstraintEnforcementCollection<TClass, TProperty>).TypeHandle];
            }

            
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
                    if ((object) adding == null || adding(instance, item))
                    {
                        _list.Add(item);
                        CommittedCollectionModificationCallback<TClass, TProperty> added = callbacks.Added;
                        if ((object) added != null)
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
                    if ((object) removing == null || removing(instance, item))
                    {
                        if (_list.Remove(item))
                        {
                            CommittedCollectionModificationCallback<TClass, TProperty> removed = callbacks.Removed;
                            if ((object) removed != null)
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

            #region Owner

            public Abstract.PackageBuilder.Owner CreateOwner(string OwnerValue)
            {
                if ((object) OwnerValue == null)
                {
                    throw new ArgumentNullException("OwnerValue");
                }
                if (!OnOwnerOwnerValueChanging(null, OwnerValue))
                {
                    throw GetConstraintEnforcementFailedException("OwnerValue");
                }
                return new OwnerCore(this, OwnerValue);
            }

            private bool OnOwnerOwnerValueChanging(Abstract.PackageBuilder.Owner instance, string newValue)
            {
                Abstract.PackageBuilder.Owner currentInstance;
                if (_OwnerOwnerValueDictionary.TryGetValue(newValue, out currentInstance))
                {
                    if (currentInstance != instance)
                    {
                        return false;
                    }
                }
                return true;
            }

            private void OnOwnerOwnerValueChanged(Abstract.PackageBuilder.Owner instance, string oldValue)
            {
                _OwnerOwnerValueDictionary.Add(instance.OwnerValue, instance);
                if ((object) oldValue != null)
                {
                    _OwnerOwnerValueDictionary.Remove(oldValue);
                }
            }

            private bool OnOwnerPackageViaPackageOwnerCollectionAdding(Abstract.PackageBuilder.Owner instance, Abstract.Package item)
            {
                if (this != item.Context)
                {
                    throw GetDifferentContextsException("item");
                }
                return true;
            }

            private void OnOwnerPackageViaPackageOwnerCollectionAdded(Abstract.PackageBuilder.Owner instance, Abstract.Package item)
            {
                item.PackageOwner = instance;
            }

            private void OnOwnerPackageViaPackageOwnerCollectionRemoved(Abstract.PackageBuilder.Owner instance, Abstract.Package item)
            {
                if (item.PackageOwner == instance)
                {
                    item.PackageOwner = null;
                }
            }

            private bool OnOwnerDataSourceViaDataSourceOwnerCollectionAdding(Abstract.PackageBuilder.Owner instance, Abstract.DataSource item)
            {
                if (this != item.Context)
                {
                    throw GetDifferentContextsException("item");
                }
                return true;
            }

            private void OnOwnerDataSourceViaDataSourceOwnerCollectionAdded(Abstract.PackageBuilder.Owner instance, Abstract.DataSource item)
            {
                item.DataSourceOwner = instance;
            }

            private void OnOwnerDataSourceViaDataSourceOwnerCollectionRemoved(Abstract.PackageBuilder.Owner instance, Abstract.DataSource item)
            {
                if (item.DataSourceOwner == instance)
                {
                    item.DataSourceOwner = null;
                }
            }

            private readonly List<Abstract.PackageBuilder.Owner> _OwnerList;
            private readonly ReadOnlyCollection<Abstract.PackageBuilder.Owner> _OwnerReadOnlyCollection;

            public IEnumerable<Abstract.PackageBuilder.Owner> OwnerCollection
            {
                get { return _OwnerReadOnlyCollection; }
            }

            #region OwnerCore

            
            private sealed class OwnerCore : Abstract.PackageBuilder.Owner
            {
                public OwnerCore(PackageBuilderContext context, string OwnerValue)
                {
                    _Context = context;
                    _PackageViaPackageOwnerCollection = new ConstraintEnforcementCollection<Abstract.PackageBuilder.Owner, Abstract.Package>(this);
                    _DataSourceViaDataSourceOwnerCollection =
                        new ConstraintEnforcementCollection<Abstract.PackageBuilder.Owner, Abstract.DataSource>(this);
                    _OwnerValue = OwnerValue;
                    context.OnOwnerOwnerValueChanged(this, null);
                    context._OwnerList.Add(this);
                }

                private readonly PackageBuilderContext _Context;

                public override PackageBuilderContext Context
                {
                    get { return _Context; }
                }

                private string _OwnerValue;

                public override string OwnerValue
                {
                    get { return _OwnerValue; }
                    set
                    {
                        if ((object) value == null)
                        {
                            throw new ArgumentNullException("value");
                        }
                        string oldValue = _OwnerValue;
                        if (oldValue != (object) value && !value.Equals(oldValue))
                        {
                            if (_Context.OnOwnerOwnerValueChanging(this, value) && base.OnOwnerValueChanging(value))
                            {
                                _OwnerValue = value;
                                _Context.OnOwnerOwnerValueChanged(this, oldValue);
                                base.OnOwnerValueChanged(oldValue);
                            }
                        }
                    }
                }

                private readonly IEnumerable<Abstract.Package> _PackageViaPackageOwnerCollection;

                public override IEnumerable<Abstract.Package> PackageViaPackageOwnerCollection
                {
                    get { return _PackageViaPackageOwnerCollection; }
                }

                private readonly IEnumerable<Abstract.DataSource> _DataSourceViaDataSourceOwnerCollection;

                public override IEnumerable<Abstract.DataSource> DataSourceViaDataSourceOwnerCollection
                {
                    get { return _DataSourceViaDataSourceOwnerCollection; }
                }
            }

            #endregion // OwnerCore

            #endregion // Owner

            #region State

            public Abstract.State CreateState(string StateValue)
            {
                if ((object) StateValue == null)
                {
                    throw new ArgumentNullException("StateValue");
                }
                if (!OnStateStateValueChanging(null, StateValue))
                {
                    throw GetConstraintEnforcementFailedException("StateValue");
                }
                return new StateCore(this, StateValue);
            }

            private bool OnStateStateValueChanging(Abstract.State instance, string newValue)
            {
                Abstract.State currentInstance;
                if (_StateStateValueDictionary.TryGetValue(newValue, out currentInstance))
                {
                    if (currentInstance != instance)
                    {
                        return false;
                    }
                }
                return true;
            }

            private void OnStateStateValueChanged(Abstract.State instance, string oldValue)
            {
                _StateStateValueDictionary.Add(instance.StateValue, instance);
                if ((object) oldValue != null)
                {
                    _StateStateValueDictionary.Remove(oldValue);
                }
            }

            private bool OnStatePackageViaPackageStateCollectionAdding(Abstract.State instance, Abstract.Package item)
            {
                if (this != item.Context)
                {
                    throw GetDifferentContextsException("item");
                }
                return true;
            }

            private void OnStatePackageViaPackageStateCollectionAdded(Abstract.State instance, Abstract.Package item)
            {
                item.PackageState = instance;
            }

            private void OnStatePackageViaPackageStateCollectionRemoved(Abstract.State instance, Abstract.Package item)
            {
                if (item.PackageState == instance)
                {
                    item.PackageState = null;
                }
            }

            private bool OnStateDataSourceViaDataSourceStateCollectionAdding(Abstract.State instance, Abstract.DataSource item)
            {
                if (this != item.Context)
                {
                    throw GetDifferentContextsException("item");
                }
                return true;
            }

            private void OnStateDataSourceViaDataSourceStateCollectionAdded(Abstract.State instance, Abstract.DataSource item)
            {
                item.DataSourceState = instance;
            }

            private void OnStateDataSourceViaDataSourceStateCollectionRemoved(Abstract.State instance, Abstract.DataSource item)
            {
                if (item.DataSourceState == instance)
                {
                    item.DataSourceState = null;
                }
            }

            private readonly List<Abstract.State> _StateList;
            private readonly ReadOnlyCollection<Abstract.State> _StateReadOnlyCollection;

            public IEnumerable<Abstract.State> StateCollection
            {
                get { return _StateReadOnlyCollection; }
            }

            #region StateCore

            
            private sealed class StateCore : Abstract.State
            {
                public StateCore(PackageBuilderContext context, string StateValue)
                {
                    _Context = context;
                    _PackageViaPackageStateCollection = new ConstraintEnforcementCollection<Abstract.State, Abstract.Package>(this);
                    _DataSourceViaDataSourceStateCollection =
                        new ConstraintEnforcementCollection<Abstract.State, Abstract.DataSource>(this);
                    _StateValue = StateValue;
                    context.OnStateStateValueChanged(this, null);
                    context._StateList.Add(this);
                }

                private readonly PackageBuilderContext _Context;

                public override PackageBuilderContext Context
                {
                    get { return _Context; }
                }

                private string _StateValue;

                public override string StateValue
                {
                    get { return _StateValue; }
                    set
                    {
                        if ((object) value == null)
                        {
                            throw new ArgumentNullException("value");
                        }
                        string oldValue = _StateValue;
                        if (oldValue != (object) value && !value.Equals(oldValue))
                        {
                            if (_Context.OnStateStateValueChanging(this, value) && base.OnStateValueChanging(value))
                            {
                                _StateValue = value;
                                _Context.OnStateStateValueChanged(this, oldValue);
                                base.OnStateValueChanged(oldValue);
                            }
                        }
                    }
                }

                private readonly IEnumerable<Abstract.Package> _PackageViaPackageStateCollection;

                public override IEnumerable<Abstract.Package> PackageViaPackageStateCollection
                {
                    get { return _PackageViaPackageStateCollection; }
                }

                private readonly IEnumerable<Abstract.DataSource> _DataSourceViaDataSourceStateCollection;

                public override IEnumerable<Abstract.DataSource> DataSourceViaDataSourceStateCollection
                {
                    get { return _DataSourceViaDataSourceStateCollection; }
                }
            }

            #endregion // StateCore

            #endregion // State

            #region Industry

            public Abstract.Industry CreateIndustry(string IndustryValue)
            {
                if ((object) IndustryValue == null)
                {
                    throw new ArgumentNullException("IndustryValue");
                }
                if (!OnIndustryIndustryValueChanging(null, IndustryValue))
                {
                    throw GetConstraintEnforcementFailedException("IndustryValue");
                }
                return new IndustryCore(this, IndustryValue);
            }

            private bool OnIndustryIndustryValueChanging(Abstract.Industry instance, string newValue)
            {
                Abstract.Industry currentInstance;
                if (_IndustryIndustryValueDictionary.TryGetValue(newValue, out currentInstance))
                {
                    if (currentInstance != instance)
                    {
                        return false;
                    }
                }
                return true;
            }

            private void OnIndustryIndustryValueChanged(Abstract.Industry instance, string oldValue)
            {
                _IndustryIndustryValueDictionary.Add(instance.IndustryValue, instance);
                if ((object) oldValue != null)
                {
                    _IndustryIndustryValueDictionary.Remove(oldValue);
                }
            }

            private bool OnIndustryPackageViaPackageIndustryCollectionAdding(Abstract.Industry instance, Abstract.Package item)
            {
                if (this != item.Context)
                {
                    throw GetDifferentContextsException("item");
                }
                return true;
            }

            private void OnIndustryPackageViaPackageIndustryCollectionAdded(Abstract.Industry instance, Abstract.Package item)
            {
                item.PackageIndustry = instance;
            }

            private void OnIndustryPackageViaPackageIndustryCollectionRemoved(Abstract.Industry instance, Abstract.Package item)
            {
                if (item.PackageIndustry == instance)
                {
                    item.PackageIndustry = null;
                }
            }

            private bool OnIndustryDateFieldViaIndustryCollectionAdding(Abstract.Industry instance, Abstract.DateField item)
            {
                if (this != item.Context)
                {
                    throw GetDifferentContextsException("item");
                }
                return true;
            }

            private void OnIndustryDateFieldViaIndustryCollectionAdded(Abstract.Industry instance, Abstract.DateField item)
            {
                item.Industry = instance;
            }

            private void OnIndustryDateFieldViaIndustryCollectionRemoved(Abstract.Industry instance, Abstract.DateField item)
            {
                if (item.Industry == instance)
                {
                    item.Industry = null;
                }
            }

            private readonly List<Abstract.Industry> _IndustryList;
            private readonly ReadOnlyCollection<Abstract.Industry> _IndustryReadOnlyCollection;

            public IEnumerable<Abstract.Industry> IndustryCollection
            {
                get { return _IndustryReadOnlyCollection; }
            }

            #region IndustryCore

            
            private sealed class IndustryCore : Abstract.Industry
            {
                public IndustryCore(PackageBuilderContext context, string IndustryValue)
                {
                    _Context = context;
                    _PackageViaPackageIndustryCollection = new ConstraintEnforcementCollection<Abstract.Industry, Abstract.Package>(this);
                    _DateFieldViaIndustryCollection = new ConstraintEnforcementCollection<Abstract.Industry, Abstract.DateField>(this);
                    _IndustryValue = IndustryValue;
                    context.OnIndustryIndustryValueChanged(this, null);
                    context._IndustryList.Add(this);
                }

                private readonly PackageBuilderContext _Context;

                public override PackageBuilderContext Context
                {
                    get { return _Context; }
                }

                private string _IndustryValue;

                public override string IndustryValue
                {
                    get { return _IndustryValue; }
                    set
                    {
                        if ((object) value == null)
                        {
                            throw new ArgumentNullException("value");
                        }
                        string oldValue = _IndustryValue;
                        if (oldValue != (object) value && !value.Equals(oldValue))
                        {
                            if (_Context.OnIndustryIndustryValueChanging(this, value) &&
                                base.OnIndustryValueChanging(value))
                            {
                                _IndustryValue = value;
                                _Context.OnIndustryIndustryValueChanged(this, oldValue);
                                base.OnIndustryValueChanged(oldValue);
                            }
                        }
                    }
                }

                private readonly IEnumerable<Abstract.Package> _PackageViaPackageIndustryCollection;

                public override IEnumerable<Abstract.Package> PackageViaPackageIndustryCollection
                {
                    get { return _PackageViaPackageIndustryCollection; }
                }

                private readonly IEnumerable<Abstract.DateField> _DateFieldViaIndustryCollection;

                public override IEnumerable<Abstract.DateField> DateFieldViaIndustryCollection
                {
                    get { return _DateFieldViaIndustryCollection; }
                }
            }

            #endregion // IndustryCore

            #endregion // Industry

            #region Package

            public Abstract.Package CreatePackage()
            {
                return new PackageCore(this);
            }

            private bool OnPackageNameChanging(Abstract.Package instance, string newValue)
            {
                return true;
            }

            private bool OnPackageDescriptionChanging(Abstract.Package instance, string newValue)
            {
                return true;
            }

            private bool OnPackageCreatedChanging(Abstract.Package instance, DateTime? newValue)
            {
                return true;
            }

            private bool OnPackageEditedChanging(Abstract.Package instance, DateTime? newValue)
            {
                return true;
            }

            private bool OnPackageVersionChanging(Abstract.Package instance, string newValue)
            {
                return true;
            }

            private bool OnPackagePublishedChanging(Abstract.Package instance, bool? newValue)
            {
                return true;
            }

            private bool OnPackageRevisionDateChanging(Abstract.Package instance, DateTime? newValue)
            {
                return true;
            }

            private bool OnPackageCostOfSaleChanging(Abstract.Package instance, decimal? newValue)
            {
                return true;
            }

            private bool OnPackagePackageOwnerChanging(Abstract.Package instance, Abstract.PackageBuilder.Owner newValue)
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

            private void OnPackagePackageOwnerChanged(Abstract.Package instance, Abstract.PackageBuilder.Owner oldValue)
            {
                if (instance.PackageOwner != null)
                {
                    ((ICollection<Abstract.Package>) instance.PackageOwner.PackageViaPackageOwnerCollection).Add(instance);
                }
                if (oldValue != null)
                {
                    ((ICollection<Abstract.Package>) oldValue.PackageViaPackageOwnerCollection).Remove(instance);
                }
            }

            private bool OnPackagePackageStateChanging(Abstract.Package instance, Abstract.State newValue)
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

            private void OnPackagePackageStateChanged(Abstract.Package instance, Abstract.State oldValue)
            {
                if (instance.PackageState != null)
                {
                    ((ICollection<Abstract.Package>) instance.PackageState.PackageViaPackageStateCollection).Add(instance);
                }
                if (oldValue != null)
                {
                    ((ICollection<Abstract.Package>) oldValue.PackageViaPackageStateCollection).Remove(instance);
                }
            }

            private bool OnPackagePackageIndustryChanging(Abstract.Package instance, Abstract.Industry newValue)
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

            private void OnPackagePackageIndustryChanged(Abstract.Package instance, Abstract.Industry oldValue)
            {
                if (instance.PackageIndustry != null)
                {
                    ((ICollection<Abstract.Package>) instance.PackageIndustry.PackageViaPackageIndustryCollection).Add(instance);
                }
                if (oldValue != null)
                {
                    ((ICollection<Abstract.Package>) oldValue.PackageViaPackageIndustryCollection).Remove(instance);
                }
            }

            private bool OnPackageDataSourceViaPackageCollectionAdding(Abstract.Package instance, Abstract.DataSource item)
            {
                if (this != item.Context)
                {
                    throw GetDifferentContextsException("item");
                }
                return true;
            }

            private void OnPackageDataSourceViaPackageCollectionAdded(Abstract.Package instance, Abstract.DataSource item)
            {
                item.Package = instance;
            }

            private void OnPackageDataSourceViaPackageCollectionRemoved(Abstract.Package instance, Abstract.DataSource item)
            {
                if (item.Package == instance)
                {
                    item.Package = null;
                }
            }

            private readonly List<Abstract.Package> _PackageList;
            private readonly ReadOnlyCollection<Abstract.Package> _PackageReadOnlyCollection;

            public IEnumerable<Abstract.Package> PackageCollection
            {
                get { return _PackageReadOnlyCollection; }
            }

            #region PackageCore

            
            private sealed class PackageCore : Abstract.Package
            {
                public PackageCore(PackageBuilderContext context)
                {
                    _Context = context;
                    _DataSourceViaPackageCollection = new ConstraintEnforcementCollection<Abstract.Package, Abstract.DataSource>(this);
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
                        string oldValue = _Name;
                        if (!Equals(oldValue, value))
                        {
                            if (_Context.OnPackageNameChanging(this, value) && base.OnNameChanging(value))
                            {
                                _Name = value;
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
                            if (_Context.OnPackageDescriptionChanging(this, value) && base.OnDescriptionChanging(value))
                            {
                                _Description = value;
                                base.OnDescriptionChanged(oldValue);
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
                        string oldValue = _Version;
                        if (oldValue != value)
                        {
                            if (_Context.OnPackageVersionChanging(this, value) && base.OnVersionChanging(value))
                            {
                                _Version = value;
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

                private Abstract.PackageBuilder.Owner _PackageOwner;

                public override Abstract.PackageBuilder.Owner PackageOwner
                {
                    get { return _PackageOwner; }
                    set
                    {
                        Abstract.PackageBuilder.Owner oldValue = _PackageOwner;
                        if (oldValue != value)
                        {
                            if (_Context.OnPackagePackageOwnerChanging(this, value) &&
                                base.OnPackageOwnerChanging(value))
                            {
                                _PackageOwner = value;
                                _Context.OnPackagePackageOwnerChanged(this, oldValue);
                                base.OnPackageOwnerChanged(oldValue);
                            }
                        }
                    }
                }

                private Abstract.State _PackageState;

                public override Abstract.State PackageState
                {
                    get { return _PackageState; }
                    set
                    {
                        Abstract.State oldValue = _PackageState;
                        if (oldValue != value)
                        {
                            if (_Context.OnPackagePackageStateChanging(this, value) &&
                                base.OnPackageStateChanging(value))
                            {
                                _PackageState = value;
                                _Context.OnPackagePackageStateChanged(this, oldValue);
                                base.OnPackageStateChanged(oldValue);
                            }
                        }
                    }
                }

                private Abstract.Industry _PackageIndustry;

                public override Abstract.Industry PackageIndustry
                {
                    get { return _PackageIndustry; }
                    set
                    {
                        Abstract.Industry oldValue = _PackageIndustry;
                        if (oldValue != value)
                        {
                            if (_Context.OnPackagePackageIndustryChanging(this, value) &&
                                base.OnPackageIndustryChanging(value))
                            {
                                _PackageIndustry = value;
                                _Context.OnPackagePackageIndustryChanged(this, oldValue);
                                base.OnPackageIndustryChanged(oldValue);
                            }
                        }
                    }
                }

                private readonly IEnumerable<Abstract.DataSource> _DataSourceViaPackageCollection;

                public override IEnumerable<Abstract.DataSource> DataSourceViaPackageCollection
                {
                    get { return _DataSourceViaPackageCollection; }
                }
            }

            #endregion // PackageCore

            #endregion // Package

            #region DataSource

            public Abstract.DataSource CreateDataSource()
            {
                return new DataSourceCore(this);
            }

            private bool OnDataSourceNameChanging(Abstract.DataSource instance, string newValue)
            {
                return true;
            }

            private bool OnDataSourceDescriptionChanging(Abstract.DataSource instance, string newValue)
            {
                return true;
            }

            private bool OnDataSourceCreatedChanging(Abstract.DataSource instance, DateTime? newValue)
            {
                return true;
            }

            private bool OnDataSourceEditedChanging(Abstract.DataSource instance, DateTime? newValue)
            {
                return true;
            }

            private bool OnDataSourceVersionChanging(Abstract.DataSource instance, string newValue)
            {
                return true;
            }

            private bool OnDataSourceCostOfSaleChanging(Abstract.DataSource instance, decimal? newValue)
            {
                return true;
            }

            private bool OnDataSourceRevisionDateChanging(Abstract.DataSource instance, DateTime? newValue)
            {
                return true;
            }

            private bool OnDataSourceSourceURLChanging(Abstract.DataSource instance, string newValue)
            {
                return true;
            }

            private bool OnDataSourcePackageChanging(Abstract.DataSource instance, Abstract.Package newValue)
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

            private void OnDataSourcePackageChanged(Abstract.DataSource instance, Abstract.Package oldValue)
            {
                if (instance.Package != null)
                {
                    ((ICollection<Abstract.DataSource>) instance.Package.DataSourceViaPackageCollection).Add(instance);
                }
                if (oldValue != null)
                {
                    ((ICollection<Abstract.DataSource>) oldValue.DataSourceViaPackageCollection).Remove(instance);
                }
            }

            private bool OnDataSourceDataSourceOwnerChanging(Abstract.DataSource instance, Abstract.PackageBuilder.Owner newValue)
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

            private void OnDataSourceDataSourceOwnerChanged(Abstract.DataSource instance, Abstract.PackageBuilder.Owner oldValue)
            {
                if (instance.DataSourceOwner != null)
                {
                    ((ICollection<Abstract.DataSource>) instance.DataSourceOwner.DataSourceViaDataSourceOwnerCollection).Add(
                        instance);
                }
                if (oldValue != null)
                {
                    ((ICollection<Abstract.DataSource>) oldValue.DataSourceViaDataSourceOwnerCollection).Remove(instance);
                }
            }

            private bool OnDataSourceDataSourceStateChanging(Abstract.DataSource instance, Abstract.State newValue)
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

            private void OnDataSourceDataSourceStateChanged(Abstract.DataSource instance, Abstract.State oldValue)
            {
                if (instance.DataSourceState != null)
                {
                    ((ICollection<Abstract.DataSource>) instance.DataSourceState.DataSourceViaDataSourceStateCollection).Add(
                        instance);
                }
                if (oldValue != null)
                {
                    ((ICollection<Abstract.DataSource>) oldValue.DataSourceViaDataSourceStateCollection).Remove(instance);
                }
            }

            private bool OnDataSourceDateFieldViaDataSourceCollectionAdding(Abstract.DataSource instance, Abstract.DateField item)
            {
                if (this != item.Context)
                {
                    throw GetDifferentContextsException("item");
                }
                return true;
            }

            private void OnDataSourceDateFieldViaDataSourceCollectionAdded(Abstract.DataSource instance, Abstract.DateField item)
            {
                item.DataSource = instance;
            }

            private void OnDataSourceDateFieldViaDataSourceCollectionRemoved(Abstract.DataSource instance, Abstract.DateField item)
            {
                if (item.DataSource == instance)
                {
                    item.DataSource = null;
                }
            }

            private bool OnDataSourceFileAttachmentViaDataSourceCollectionAdding(Abstract.DataSource instance,
                Abstract.FileAttachment item)
            {
                if (this != item.Context)
                {
                    throw GetDifferentContextsException("item");
                }
                return true;
            }

            private void OnDataSourceFileAttachmentViaDataSourceCollectionAdded(Abstract.DataSource instance, Abstract.FileAttachment item)
            {
                item.DataSource = instance;
            }

            private void OnDataSourceFileAttachmentViaDataSourceCollectionRemoved(Abstract.DataSource instance,
                Abstract.FileAttachment item)
            {
                if (item.DataSource == instance)
                {
                    item.DataSource = null;
                }
            }

            private readonly List<Abstract.DataSource> _DataSourceList;
            private readonly ReadOnlyCollection<Abstract.DataSource> _DataSourceReadOnlyCollection;

            public IEnumerable<Abstract.DataSource> DataSourceCollection
            {
                get { return _DataSourceReadOnlyCollection; }
            }

            #region DataSourceCore

            
            private sealed class DataSourceCore : Abstract.DataSource
            {
                public DataSourceCore(PackageBuilderContext context)
                {
                    _Context = context;
                    _DateFieldViaDataSourceCollection = new ConstraintEnforcementCollection<Abstract.DataSource, Abstract.DateField>(this);
                    _FileAttachmentViaDataSourceCollection =
                        new ConstraintEnforcementCollection<Abstract.DataSource, Abstract.FileAttachment>(this);
                    context._DataSourceList.Add(this);
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
                        string oldValue = _Name;
                        if (!Equals(oldValue, value))
                        {
                            if (_Context.OnDataSourceNameChanging(this, value) && base.OnNameChanging(value))
                            {
                                _Name = value;
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
                            if (_Context.OnDataSourceDescriptionChanging(this, value) &&
                                base.OnDescriptionChanging(value))
                            {
                                _Description = value;
                                base.OnDescriptionChanged(oldValue);
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
                            if (_Context.OnDataSourceCreatedChanging(this, value) && base.OnCreatedChanging(value))
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
                            if (_Context.OnDataSourceEditedChanging(this, value) && base.OnEditedChanging(value))
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
                        string oldValue = _Version;
                        if (oldValue != value||
                            oldValue != value)
                        {
                            if (_Context.OnDataSourceVersionChanging(this, value) && base.OnVersionChanging(value))
                            {
                                _Version = value;
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
                            if (_Context.OnDataSourceCostOfSaleChanging(this, value) && base.OnCostOfSaleChanging(value))
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
                            if (_Context.OnDataSourceRevisionDateChanging(this, value) &&
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
                        string oldValue = _SourceURL;
                        if (!Equals(oldValue, value))
                        {
                            if (_Context.OnDataSourceSourceURLChanging(this, value) && base.OnSourceURLChanging(value))
                            {
                                _SourceURL = value;
                                base.OnSourceURLChanged(oldValue);
                            }
                        }
                    }
                }

                private Abstract.Package _Package;

                public override Abstract.Package Package
                {
                    get { return _Package; }
                    set
                    {
                        Abstract.Package oldValue = _Package;
                        if (oldValue != value)
                        {
                            if (_Context.OnDataSourcePackageChanging(this, value) && base.OnPackageChanging(value))
                            {
                                _Package = value;
                                _Context.OnDataSourcePackageChanged(this, oldValue);
                                base.OnPackageChanged(oldValue);
                            }
                        }
                    }
                }

                private Abstract.PackageBuilder.Owner _DataSourceOwner;

                public override Abstract.PackageBuilder.Owner DataSourceOwner
                {
                    get { return _DataSourceOwner; }
                    set
                    {
                        Abstract.PackageBuilder.Owner oldValue = _DataSourceOwner;
                        if (oldValue != value)
                        {
                            if (_Context.OnDataSourceDataSourceOwnerChanging(this, value) &&
                                base.OnDataSourceOwnerChanging(value))
                            {
                                _DataSourceOwner = value;
                                _Context.OnDataSourceDataSourceOwnerChanged(this, oldValue);
                                base.OnDataSourceOwnerChanged(oldValue);
                            }
                        }
                    }
                }

                private Abstract.State _DataSourceState;

                public override Abstract.State DataSourceState
                {
                    get { return _DataSourceState; }
                    set
                    {
                        Abstract.State oldValue = _DataSourceState;
                        if (oldValue != value)
                        {
                            if (_Context.OnDataSourceDataSourceStateChanging(this, value) &&
                                base.OnDataSourceStateChanging(value))
                            {
                                _DataSourceState = value;
                                _Context.OnDataSourceDataSourceStateChanged(this, oldValue);
                                base.OnDataSourceStateChanged(oldValue);
                            }
                        }
                    }
                }

                private readonly IEnumerable<Abstract.DateField> _DateFieldViaDataSourceCollection;

                public override IEnumerable<Abstract.DateField> DateFieldViaDataSourceCollection
                {
                    get { return _DateFieldViaDataSourceCollection; }
                }

                private readonly IEnumerable<Abstract.FileAttachment> _FileAttachmentViaDataSourceCollection;

                public override IEnumerable<Abstract.FileAttachment> FileAttachmentViaDataSourceCollection
                {
                    get { return _FileAttachmentViaDataSourceCollection; }
                }
            }

            #endregion // DataSourceCore

            #endregion // DataSource

            #region DateField

            public Abstract.DateField CreateDateField()
            {
                return new DateFieldCore(this);
            }

            private bool OnDateFieldLabelChanging(Abstract.DateField instance, string newValue)
            {
                return true;
            }

            private bool OnDateFieldDefinitionChanging(Abstract.DateField instance, string newValue)
            {
                return true;
            }

            private bool OnDateFieldSelectedChanging(Abstract.DateField instance, bool? newValue)
            {
                return true;
            }

            private bool OnDateFieldDataSourceChanging(Abstract.DateField instance, Abstract.DataSource newValue)
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

            private void OnDateFieldDataSourceChanged(Abstract.DateField instance, Abstract.DataSource oldValue)
            {
                if (instance.DataSource != null)
                {
                    ((ICollection<Abstract.DateField>) instance.DataSource.DateFieldViaDataSourceCollection).Add(instance);
                }
                if (oldValue != null)
                {
                    ((ICollection<Abstract.DateField>) oldValue.DateFieldViaDataSourceCollection).Remove(instance);
                }
            }

            private bool OnDateFieldIndustryChanging(Abstract.DateField instance, Abstract.Industry newValue)
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

            private void OnDateFieldIndustryChanged(Abstract.DateField instance, Abstract.Industry oldValue)
            {
                if (instance.Industry != null)
                {
                    ((ICollection<Abstract.DateField>) instance.Industry.DateFieldViaIndustryCollection).Add(instance);
                }
                if (oldValue != null)
                {
                    ((ICollection<Abstract.DateField>) oldValue.DateFieldViaIndustryCollection).Remove(instance);
                }
            }

            private readonly List<Abstract.DateField> _DateFieldList;
            private readonly ReadOnlyCollection<Abstract.DateField> _DateFieldReadOnlyCollection;

            public IEnumerable<Abstract.DateField> DateFieldCollection
            {
                get { return _DateFieldReadOnlyCollection; }
            }

            #region DateFieldCore

            
            private sealed class DateFieldCore : Abstract.DateField
            {
                public DateFieldCore(PackageBuilderContext context)
                {
                    _Context = context;
                    context._DateFieldList.Add(this);
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
                            if (_Context.OnDateFieldLabelChanging(this, value) && base.OnLabelChanging(value))
                            {
                                _Label = value;
                                base.OnLabelChanged(oldValue);
                            }
                        }
                    }
                }

                private string _Definition;

                public override string Definition
                {
                    get { return _Definition; }
                    set
                    {
                        string oldValue = _Definition;
                        if (!Equals(oldValue, value))
                        {
                            if (_Context.OnDateFieldDefinitionChanging(this, value) && base.OnDefinitionChanging(value))
                            {
                                _Definition = value;
                                base.OnDefinitionChanged(oldValue);
                            }
                        }
                    }
                }

                private bool? _Selected;

                public override bool? Selected
                {
                    get { return _Selected; }
                    set
                    {
                        bool? oldValue = _Selected;
                        if (oldValue.GetValueOrDefault() != value.GetValueOrDefault() ||
                            oldValue.HasValue != value.HasValue)
                        {
                            if (_Context.OnDateFieldSelectedChanging(this, value) && base.OnSelectedChanging(value))
                            {
                                _Selected = value;
                                base.OnSelectedChanged(oldValue);
                            }
                        }
                    }
                }

                private Abstract.DataSource _DataSource;

                public override Abstract.DataSource DataSource
                {
                    get { return _DataSource; }
                    set
                    {
                        Abstract.DataSource oldValue = _DataSource;
                        if (oldValue != value)
                        {
                            if (_Context.OnDateFieldDataSourceChanging(this, value) && base.OnDataSourceChanging(value))
                            {
                                _DataSource = value;
                                _Context.OnDateFieldDataSourceChanged(this, oldValue);
                                base.OnDataSourceChanged(oldValue);
                            }
                        }
                    }
                }

                private Abstract.Industry _Industry;

                public override Abstract.Industry Industry
                {
                    get { return _Industry; }
                    set
                    {
                        Abstract.Industry oldValue = _Industry;
                        if (oldValue != value)
                        {
                            if (_Context.OnDateFieldIndustryChanging(this, value) && base.OnIndustryChanging(value))
                            {
                                _Industry = value;
                                _Context.OnDateFieldIndustryChanged(this, oldValue);
                                base.OnIndustryChanged(oldValue);
                            }
                        }
                    }
                }
            }

            #endregion // DateFieldCore

            #endregion // DateField

            #region FileAttachment

            public Abstract.FileAttachment CreateFileAttachment()
            {
                return new FileAttachmentCore(this);
            }

            private bool OnFileAttachmentFileNameChanging(Abstract.FileAttachment instance, string newValue)
            {
                return true;
            }

            private bool OnFileAttachmentBlobChanging(Abstract.FileAttachment instance, byte[] newValue)
            {
                return true;
            }

            private bool OnFileAttachmentDataSourceChanging(Abstract.FileAttachment instance, Abstract.DataSource newValue)
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

            private void OnFileAttachmentDataSourceChanged(Abstract.FileAttachment instance, Abstract.DataSource oldValue)
            {
                if (instance.DataSource != null)
                {
                    ((ICollection<Abstract.FileAttachment>) instance.DataSource.FileAttachmentViaDataSourceCollection).Add(
                        instance);
                }
                if (oldValue != null)
                {
                    ((ICollection<Abstract.FileAttachment>) oldValue.FileAttachmentViaDataSourceCollection).Remove(instance);
                }
            }

            private readonly List<Abstract.FileAttachment> _FileAttachmentList;
            private readonly ReadOnlyCollection<Abstract.FileAttachment> _FileAttachmentReadOnlyCollection;

            public IEnumerable<Abstract.FileAttachment> FileAttachmentCollection
            {
                get { return _FileAttachmentReadOnlyCollection; }
            }

            #region FileAttachmentCore

            
            private sealed class FileAttachmentCore : Abstract.FileAttachment
            {
                public FileAttachmentCore(PackageBuilderContext context)
                {
                    _Context = context;
                    context._FileAttachmentList.Add(this);
                }

                private readonly PackageBuilderContext _Context;

                public override PackageBuilderContext Context
                {
                    get { return _Context; }
                }

                private string _FileName;

                public override string FileName
                {
                    get { return _FileName; }
                    set
                    {
                        string oldValue = _FileName;
                        if (!Equals(oldValue, value))
                        {
                            if (_Context.OnFileAttachmentFileNameChanging(this, value) && base.OnFileNameChanging(value))
                            {
                                _FileName = value;
                                base.OnFileNameChanged(oldValue);
                            }
                        }
                    }
                }

                private byte[] _Blob;

                public override byte[] Blob
                {
                    get { return _Blob; }
                    set
                    {
                        byte[] oldValue = _Blob;
                        if (!Equals(oldValue, value))
                        {
                            if (_Context.OnFileAttachmentBlobChanging(this, value) && base.OnBlobChanging(value))
                            {
                                _Blob = value;
                                base.OnBlobChanged(oldValue);
                            }
                        }
                    }
                }

                private Abstract.DataSource _DataSource;

                public override Abstract.DataSource DataSource
                {
                    get { return _DataSource; }
                    set
                    {
                        Abstract.DataSource oldValue = _DataSource;
                        if (oldValue != value)
                        {
                            if (_Context.OnFileAttachmentDataSourceChanging(this, value) &&
                                base.OnDataSourceChanging(value))
                            {
                                _DataSource = value;
                                _Context.OnFileAttachmentDataSourceChanged(this, oldValue);
                                base.OnDataSourceChanged(oldValue);
                            }
                        }
                    }
                }
            }

            #endregion // FileAttachmentCore

            #endregion // FileAttachment
        }

        #endregion // PackageBuilderContext
    }
}
