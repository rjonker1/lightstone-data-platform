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
                    typeof (ConstraintEnforcementCollection<Owner, Package>).TypeHandle,
                    new ConstraintEnforcementCollectionCallbacks<Owner, Package>(
                        OnOwnerPackageViaPackageOwnerCollectionAdding, OnOwnerPackageViaPackageOwnerCollectionAdded,
                        null, OnOwnerPackageViaPackageOwnerCollectionRemoved));

                constraintEnforcementCollectionCallbacksByTypeDictionary.Add(
                    typeof (ConstraintEnforcementCollection<Owner, DataSource>).TypeHandle,
                    new ConstraintEnforcementCollectionCallbacks<Owner, DataSource>(
                        OnOwnerDataSourceViaDataSourceOwnerCollectionAdding,
                        OnOwnerDataSourceViaDataSourceOwnerCollectionAdded, null,
                        OnOwnerDataSourceViaDataSourceOwnerCollectionRemoved));

                constraintEnforcementCollectionCallbacksByTypeDictionary.Add(
                    typeof (ConstraintEnforcementCollection<State, Package>).TypeHandle,
                    new ConstraintEnforcementCollectionCallbacks<State, Package>(
                        OnStatePackageViaPackageStateCollectionAdding, OnStatePackageViaPackageStateCollectionAdded,
                        null, OnStatePackageViaPackageStateCollectionRemoved));

                constraintEnforcementCollectionCallbacksByTypeDictionary.Add(
                    typeof (ConstraintEnforcementCollection<State, DataSource>).TypeHandle,
                    new ConstraintEnforcementCollectionCallbacks<State, DataSource>(
                        OnStateDataSourceViaDataSourceStateCollectionAdding,
                        OnStateDataSourceViaDataSourceStateCollectionAdded, null,
                        OnStateDataSourceViaDataSourceStateCollectionRemoved));

                constraintEnforcementCollectionCallbacksByTypeDictionary.Add(
                    typeof (ConstraintEnforcementCollection<Industry, Package>).TypeHandle,
                    new ConstraintEnforcementCollectionCallbacks<Industry, Package>(
                        OnIndustryPackageViaPackageIndustryCollectionAdding,
                        OnIndustryPackageViaPackageIndustryCollectionAdded, null,
                        OnIndustryPackageViaPackageIndustryCollectionRemoved));

                constraintEnforcementCollectionCallbacksByTypeDictionary.Add(
                    typeof (ConstraintEnforcementCollection<Industry, DateField>).TypeHandle,
                    new ConstraintEnforcementCollectionCallbacks<Industry, DateField>(
                        OnIndustryDateFieldViaIndustryCollectionAdding, OnIndustryDateFieldViaIndustryCollectionAdded,
                        null, OnIndustryDateFieldViaIndustryCollectionRemoved));

                constraintEnforcementCollectionCallbacksByTypeDictionary.Add(
                    typeof (ConstraintEnforcementCollection<Package, DataSource>).TypeHandle,
                    new ConstraintEnforcementCollectionCallbacks<Package, DataSource>(
                        OnPackageDataSourceViaPackageCollectionAdding, OnPackageDataSourceViaPackageCollectionAdded,
                        null, OnPackageDataSourceViaPackageCollectionRemoved));
                constraintEnforcementCollectionCallbacksByTypeDictionary.Add(
                    typeof (ConstraintEnforcementCollection<DataSource, DateField>).TypeHandle,
                    new ConstraintEnforcementCollectionCallbacks<DataSource, DateField>(
                        OnDataSourceDateFieldViaDataSourceCollectionAdding,
                        OnDataSourceDateFieldViaDataSourceCollectionAdded, null,
                        OnDataSourceDateFieldViaDataSourceCollectionRemoved));
                constraintEnforcementCollectionCallbacksByTypeDictionary.Add(
                    typeof (ConstraintEnforcementCollection<DataSource, FileAttachment>).TypeHandle,
                    new ConstraintEnforcementCollectionCallbacks<DataSource, FileAttachment>(
                        OnDataSourceFileAttachmentViaDataSourceCollectionAdding,
                        OnDataSourceFileAttachmentViaDataSourceCollectionAdded, null,
                        OnDataSourceFileAttachmentViaDataSourceCollectionRemoved));
                _OwnerReadOnlyCollection = new ReadOnlyCollection<Owner>(_OwnerList = new List<Owner>());
                _StateReadOnlyCollection = new ReadOnlyCollection<State>(_StateList = new List<State>());
                _IndustryReadOnlyCollection = new ReadOnlyCollection<Industry>(_IndustryList = new List<Industry>());
                _PackageReadOnlyCollection = new ReadOnlyCollection<Package>(_PackageList = new List<Package>());
                _DataSourceReadOnlyCollection =
                    new ReadOnlyCollection<DataSource>(_DataSourceList = new List<DataSource>());
                _DateFieldReadOnlyCollection = new ReadOnlyCollection<DateField>(_DateFieldList = new List<DateField>());
                _FileAttachmentReadOnlyCollection =
                    new ReadOnlyCollection<FileAttachment>(_FileAttachmentList = new List<FileAttachment>());
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

            private readonly Dictionary<string, Owner> _OwnerOwnerValueDictionary = new Dictionary<string, Owner>();

            public Owner GetOwnerByOwnerValue(string OwnerValue)
            {
                return _OwnerOwnerValueDictionary[OwnerValue];
            }

            public bool TryGetOwnerByOwnerValue(string OwnerValue, out Owner Owner)
            {
                return _OwnerOwnerValueDictionary.TryGetValue(OwnerValue, out Owner);
            }

            private readonly Dictionary<string, State> _StateStateValueDictionary = new Dictionary<string, State>();

            public State GetStateByStateValue(string StateValue)
            {
                return _StateStateValueDictionary[StateValue];
            }

            public bool TryGetStateByStateValue(string StateValue, out State State)
            {
                return _StateStateValueDictionary.TryGetValue(StateValue, out State);
            }

            private readonly Dictionary<string, Industry> _IndustryIndustryValueDictionary =
                new Dictionary<string, Industry>();

            public Industry GetIndustryByIndustryValue(string IndustryValue)
            {
                return _IndustryIndustryValueDictionary[IndustryValue];
            }

            public bool TryGetIndustryByIndustryValue(string IndustryValue, out Industry Industry)
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

            public Owner CreateOwner(string OwnerValue)
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

            private bool OnOwnerOwnerValueChanging(Owner instance, string newValue)
            {
                Owner currentInstance;
                if (_OwnerOwnerValueDictionary.TryGetValue(newValue, out currentInstance))
                {
                    if (currentInstance != instance)
                    {
                        return false;
                    }
                }
                return true;
            }

            private void OnOwnerOwnerValueChanged(Owner instance, string oldValue)
            {
                _OwnerOwnerValueDictionary.Add(instance.OwnerValue, instance);
                if ((object) oldValue != null)
                {
                    _OwnerOwnerValueDictionary.Remove(oldValue);
                }
            }

            private bool OnOwnerPackageViaPackageOwnerCollectionAdding(Owner instance, Package item)
            {
                if (this != item.Context)
                {
                    throw GetDifferentContextsException("item");
                }
                return true;
            }

            private void OnOwnerPackageViaPackageOwnerCollectionAdded(Owner instance, Package item)
            {
                item.PackageOwner = instance;
            }

            private void OnOwnerPackageViaPackageOwnerCollectionRemoved(Owner instance, Package item)
            {
                if (item.PackageOwner == instance)
                {
                    item.PackageOwner = null;
                }
            }

            private bool OnOwnerDataSourceViaDataSourceOwnerCollectionAdding(Owner instance, DataSource item)
            {
                if (this != item.Context)
                {
                    throw GetDifferentContextsException("item");
                }
                return true;
            }

            private void OnOwnerDataSourceViaDataSourceOwnerCollectionAdded(Owner instance, DataSource item)
            {
                item.DataSourceOwner = instance;
            }

            private void OnOwnerDataSourceViaDataSourceOwnerCollectionRemoved(Owner instance, DataSource item)
            {
                if (item.DataSourceOwner == instance)
                {
                    item.DataSourceOwner = null;
                }
            }

            private readonly List<Owner> _OwnerList;
            private readonly ReadOnlyCollection<Owner> _OwnerReadOnlyCollection;

            public IEnumerable<Owner> OwnerCollection
            {
                get { return _OwnerReadOnlyCollection; }
            }

            #region OwnerCore

            
            private sealed class OwnerCore : Owner
            {
                public OwnerCore(PackageBuilderContext context, string OwnerValue)
                {
                    _Context = context;
                    _PackageViaPackageOwnerCollection = new ConstraintEnforcementCollection<Owner, Package>(this);
                    _DataSourceViaDataSourceOwnerCollection =
                        new ConstraintEnforcementCollection<Owner, DataSource>(this);
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

                private readonly IEnumerable<Package> _PackageViaPackageOwnerCollection;

                public override IEnumerable<Package> PackageViaPackageOwnerCollection
                {
                    get { return _PackageViaPackageOwnerCollection; }
                }

                private readonly IEnumerable<DataSource> _DataSourceViaDataSourceOwnerCollection;

                public override IEnumerable<DataSource> DataSourceViaDataSourceOwnerCollection
                {
                    get { return _DataSourceViaDataSourceOwnerCollection; }
                }
            }

            #endregion // OwnerCore

            #endregion // Owner

            #region State

            public State CreateState(string StateValue)
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

            private bool OnStateStateValueChanging(State instance, string newValue)
            {
                State currentInstance;
                if (_StateStateValueDictionary.TryGetValue(newValue, out currentInstance))
                {
                    if (currentInstance != instance)
                    {
                        return false;
                    }
                }
                return true;
            }

            private void OnStateStateValueChanged(State instance, string oldValue)
            {
                _StateStateValueDictionary.Add(instance.StateValue, instance);
                if ((object) oldValue != null)
                {
                    _StateStateValueDictionary.Remove(oldValue);
                }
            }

            private bool OnStatePackageViaPackageStateCollectionAdding(State instance, Package item)
            {
                if (this != item.Context)
                {
                    throw GetDifferentContextsException("item");
                }
                return true;
            }

            private void OnStatePackageViaPackageStateCollectionAdded(State instance, Package item)
            {
                item.PackageState = instance;
            }

            private void OnStatePackageViaPackageStateCollectionRemoved(State instance, Package item)
            {
                if (item.PackageState == instance)
                {
                    item.PackageState = null;
                }
            }

            private bool OnStateDataSourceViaDataSourceStateCollectionAdding(State instance, DataSource item)
            {
                if (this != item.Context)
                {
                    throw GetDifferentContextsException("item");
                }
                return true;
            }

            private void OnStateDataSourceViaDataSourceStateCollectionAdded(State instance, DataSource item)
            {
                item.DataSourceState = instance;
            }

            private void OnStateDataSourceViaDataSourceStateCollectionRemoved(State instance, DataSource item)
            {
                if (item.DataSourceState == instance)
                {
                    item.DataSourceState = null;
                }
            }

            private readonly List<State> _StateList;
            private readonly ReadOnlyCollection<State> _StateReadOnlyCollection;

            public IEnumerable<State> StateCollection
            {
                get { return _StateReadOnlyCollection; }
            }

            #region StateCore

            
            private sealed class StateCore : State
            {
                public StateCore(PackageBuilderContext context, string StateValue)
                {
                    _Context = context;
                    _PackageViaPackageStateCollection = new ConstraintEnforcementCollection<State, Package>(this);
                    _DataSourceViaDataSourceStateCollection =
                        new ConstraintEnforcementCollection<State, DataSource>(this);
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

                private readonly IEnumerable<Package> _PackageViaPackageStateCollection;

                public override IEnumerable<Package> PackageViaPackageStateCollection
                {
                    get { return _PackageViaPackageStateCollection; }
                }

                private readonly IEnumerable<DataSource> _DataSourceViaDataSourceStateCollection;

                public override IEnumerable<DataSource> DataSourceViaDataSourceStateCollection
                {
                    get { return _DataSourceViaDataSourceStateCollection; }
                }
            }

            #endregion // StateCore

            #endregion // State

            #region Industry

            public Industry CreateIndustry(string IndustryValue)
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

            private bool OnIndustryIndustryValueChanging(Industry instance, string newValue)
            {
                Industry currentInstance;
                if (_IndustryIndustryValueDictionary.TryGetValue(newValue, out currentInstance))
                {
                    if (currentInstance != instance)
                    {
                        return false;
                    }
                }
                return true;
            }

            private void OnIndustryIndustryValueChanged(Industry instance, string oldValue)
            {
                _IndustryIndustryValueDictionary.Add(instance.IndustryValue, instance);
                if ((object) oldValue != null)
                {
                    _IndustryIndustryValueDictionary.Remove(oldValue);
                }
            }

            private bool OnIndustryPackageViaPackageIndustryCollectionAdding(Industry instance, Package item)
            {
                if (this != item.Context)
                {
                    throw GetDifferentContextsException("item");
                }
                return true;
            }

            private void OnIndustryPackageViaPackageIndustryCollectionAdded(Industry instance, Package item)
            {
                item.PackageIndustry = instance;
            }

            private void OnIndustryPackageViaPackageIndustryCollectionRemoved(Industry instance, Package item)
            {
                if (item.PackageIndustry == instance)
                {
                    item.PackageIndustry = null;
                }
            }

            private bool OnIndustryDateFieldViaIndustryCollectionAdding(Industry instance, DateField item)
            {
                if (this != item.Context)
                {
                    throw GetDifferentContextsException("item");
                }
                return true;
            }

            private void OnIndustryDateFieldViaIndustryCollectionAdded(Industry instance, DateField item)
            {
                item.Industry = instance;
            }

            private void OnIndustryDateFieldViaIndustryCollectionRemoved(Industry instance, DateField item)
            {
                if (item.Industry == instance)
                {
                    item.Industry = null;
                }
            }

            private readonly List<Industry> _IndustryList;
            private readonly ReadOnlyCollection<Industry> _IndustryReadOnlyCollection;

            public IEnumerable<Industry> IndustryCollection
            {
                get { return _IndustryReadOnlyCollection; }
            }

            #region IndustryCore

            
            private sealed class IndustryCore : Industry
            {
                public IndustryCore(PackageBuilderContext context, string IndustryValue)
                {
                    _Context = context;
                    _PackageViaPackageIndustryCollection = new ConstraintEnforcementCollection<Industry, Package>(this);
                    _DateFieldViaIndustryCollection = new ConstraintEnforcementCollection<Industry, DateField>(this);
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

                private readonly IEnumerable<Package> _PackageViaPackageIndustryCollection;

                public override IEnumerable<Package> PackageViaPackageIndustryCollection
                {
                    get { return _PackageViaPackageIndustryCollection; }
                }

                private readonly IEnumerable<DateField> _DateFieldViaIndustryCollection;

                public override IEnumerable<DateField> DateFieldViaIndustryCollection
                {
                    get { return _DateFieldViaIndustryCollection; }
                }
            }

            #endregion // IndustryCore

            #endregion // Industry

            #region Package

            public Package CreatePackage()
            {
                return new PackageCore(this);
            }

            private bool OnPackageNameChanging(Package instance, string newValue)
            {
                return true;
            }

            private bool OnPackageDescriptionChanging(Package instance, string newValue)
            {
                return true;
            }

            private bool OnPackageCreatedChanging(Package instance, int? newValue)
            {
                return true;
            }

            private bool OnPackageEditedChanging(Package instance, int? newValue)
            {
                return true;
            }

            private bool OnPackageVersionChanging(Package instance, int? newValue)
            {
                return true;
            }

            private bool OnPackagePublishedChanging(Package instance, bool? newValue)
            {
                return true;
            }

            private bool OnPackageRevisionDateChanging(Package instance, int? newValue)
            {
                return true;
            }

            private bool OnPackageCostOfSaleChanging(Package instance, decimal? newValue)
            {
                return true;
            }

            private bool OnPackagePackageOwnerChanging(Package instance, Owner newValue)
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

            private void OnPackagePackageOwnerChanged(Package instance, Owner oldValue)
            {
                if (instance.PackageOwner != null)
                {
                    ((ICollection<Package>) instance.PackageOwner.PackageViaPackageOwnerCollection).Add(instance);
                }
                if (oldValue != null)
                {
                    ((ICollection<Package>) oldValue.PackageViaPackageOwnerCollection).Remove(instance);
                }
            }

            private bool OnPackagePackageStateChanging(Package instance, State newValue)
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

            private void OnPackagePackageStateChanged(Package instance, State oldValue)
            {
                if (instance.PackageState != null)
                {
                    ((ICollection<Package>) instance.PackageState.PackageViaPackageStateCollection).Add(instance);
                }
                if (oldValue != null)
                {
                    ((ICollection<Package>) oldValue.PackageViaPackageStateCollection).Remove(instance);
                }
            }

            private bool OnPackagePackageIndustryChanging(Package instance, Industry newValue)
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

            private void OnPackagePackageIndustryChanged(Package instance, Industry oldValue)
            {
                if (instance.PackageIndustry != null)
                {
                    ((ICollection<Package>) instance.PackageIndustry.PackageViaPackageIndustryCollection).Add(instance);
                }
                if (oldValue != null)
                {
                    ((ICollection<Package>) oldValue.PackageViaPackageIndustryCollection).Remove(instance);
                }
            }

            private bool OnPackageDataSourceViaPackageCollectionAdding(Package instance, DataSource item)
            {
                if (this != item.Context)
                {
                    throw GetDifferentContextsException("item");
                }
                return true;
            }

            private void OnPackageDataSourceViaPackageCollectionAdded(Package instance, DataSource item)
            {
                item.Package = instance;
            }

            private void OnPackageDataSourceViaPackageCollectionRemoved(Package instance, DataSource item)
            {
                if (item.Package == instance)
                {
                    item.Package = null;
                }
            }

            private readonly List<Package> _PackageList;
            private readonly ReadOnlyCollection<Package> _PackageReadOnlyCollection;

            public IEnumerable<Package> PackageCollection
            {
                get { return _PackageReadOnlyCollection; }
            }

            #region PackageCore

            
            private sealed class PackageCore : Package
            {
                public PackageCore(PackageBuilderContext context)
                {
                    _Context = context;
                    _DataSourceViaPackageCollection = new ConstraintEnforcementCollection<Package, DataSource>(this);
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

                private int? _Created;

                public override int? Created
                {
                    get { return _Created; }
                    set
                    {
                        int? oldValue = _Created;
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

                private int? _Edited;

                public override int? Edited
                {
                    get { return _Edited; }
                    set
                    {
                        int? oldValue = _Edited;
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

                private int? _Version;

                public override int? Version
                {
                    get { return _Version; }
                    set
                    {
                        int? oldValue = _Version;
                        if (oldValue.GetValueOrDefault() != value.GetValueOrDefault() ||
                            oldValue.HasValue != value.HasValue)
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

                private int? _RevisionDate;

                public override int? RevisionDate
                {
                    get { return _RevisionDate; }
                    set
                    {
                        int? oldValue = _RevisionDate;
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

                private Owner _PackageOwner;

                public override Owner PackageOwner
                {
                    get { return _PackageOwner; }
                    set
                    {
                        Owner oldValue = _PackageOwner;
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

                private State _PackageState;

                public override State PackageState
                {
                    get { return _PackageState; }
                    set
                    {
                        State oldValue = _PackageState;
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

                private Industry _PackageIndustry;

                public override Industry PackageIndustry
                {
                    get { return _PackageIndustry; }
                    set
                    {
                        Industry oldValue = _PackageIndustry;
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

                private readonly IEnumerable<DataSource> _DataSourceViaPackageCollection;

                public override IEnumerable<DataSource> DataSourceViaPackageCollection
                {
                    get { return _DataSourceViaPackageCollection; }
                }
            }

            #endregion // PackageCore

            #endregion // Package

            #region DataSource

            public DataSource CreateDataSource()
            {
                return new DataSourceCore(this);
            }

            private bool OnDataSourceNameChanging(DataSource instance, string newValue)
            {
                return true;
            }

            private bool OnDataSourceDescriptionChanging(DataSource instance, string newValue)
            {
                return true;
            }

            private bool OnDataSourceCreatedChanging(DataSource instance, int? newValue)
            {
                return true;
            }

            private bool OnDataSourceEditedChanging(DataSource instance, int? newValue)
            {
                return true;
            }

            private bool OnDataSourceVersionChanging(DataSource instance, int? newValue)
            {
                return true;
            }

            private bool OnDataSourceCostOfSaleChanging(DataSource instance, decimal? newValue)
            {
                return true;
            }

            private bool OnDataSourceRevisionDateChanging(DataSource instance, int? newValue)
            {
                return true;
            }

            private bool OnDataSourceSourceURLChanging(DataSource instance, string newValue)
            {
                return true;
            }

            private bool OnDataSourcePackageChanging(DataSource instance, Package newValue)
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

            private void OnDataSourcePackageChanged(DataSource instance, Package oldValue)
            {
                if (instance.Package != null)
                {
                    ((ICollection<DataSource>) instance.Package.DataSourceViaPackageCollection).Add(instance);
                }
                if (oldValue != null)
                {
                    ((ICollection<DataSource>) oldValue.DataSourceViaPackageCollection).Remove(instance);
                }
            }

            private bool OnDataSourceDataSourceOwnerChanging(DataSource instance, Owner newValue)
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

            private void OnDataSourceDataSourceOwnerChanged(DataSource instance, Owner oldValue)
            {
                if (instance.DataSourceOwner != null)
                {
                    ((ICollection<DataSource>) instance.DataSourceOwner.DataSourceViaDataSourceOwnerCollection).Add(
                        instance);
                }
                if (oldValue != null)
                {
                    ((ICollection<DataSource>) oldValue.DataSourceViaDataSourceOwnerCollection).Remove(instance);
                }
            }

            private bool OnDataSourceDataSourceStateChanging(DataSource instance, State newValue)
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

            private void OnDataSourceDataSourceStateChanged(DataSource instance, State oldValue)
            {
                if (instance.DataSourceState != null)
                {
                    ((ICollection<DataSource>) instance.DataSourceState.DataSourceViaDataSourceStateCollection).Add(
                        instance);
                }
                if (oldValue != null)
                {
                    ((ICollection<DataSource>) oldValue.DataSourceViaDataSourceStateCollection).Remove(instance);
                }
            }

            private bool OnDataSourceDateFieldViaDataSourceCollectionAdding(DataSource instance, DateField item)
            {
                if (this != item.Context)
                {
                    throw GetDifferentContextsException("item");
                }
                return true;
            }

            private void OnDataSourceDateFieldViaDataSourceCollectionAdded(DataSource instance, DateField item)
            {
                item.DataSource = instance;
            }

            private void OnDataSourceDateFieldViaDataSourceCollectionRemoved(DataSource instance, DateField item)
            {
                if (item.DataSource == instance)
                {
                    item.DataSource = null;
                }
            }

            private bool OnDataSourceFileAttachmentViaDataSourceCollectionAdding(DataSource instance,
                FileAttachment item)
            {
                if (this != item.Context)
                {
                    throw GetDifferentContextsException("item");
                }
                return true;
            }

            private void OnDataSourceFileAttachmentViaDataSourceCollectionAdded(DataSource instance, FileAttachment item)
            {
                item.DataSource = instance;
            }

            private void OnDataSourceFileAttachmentViaDataSourceCollectionRemoved(DataSource instance,
                FileAttachment item)
            {
                if (item.DataSource == instance)
                {
                    item.DataSource = null;
                }
            }

            private readonly List<DataSource> _DataSourceList;
            private readonly ReadOnlyCollection<DataSource> _DataSourceReadOnlyCollection;

            public IEnumerable<DataSource> DataSourceCollection
            {
                get { return _DataSourceReadOnlyCollection; }
            }

            #region DataSourceCore

            
            private sealed class DataSourceCore : DataSource
            {
                public DataSourceCore(PackageBuilderContext context)
                {
                    _Context = context;
                    _DateFieldViaDataSourceCollection = new ConstraintEnforcementCollection<DataSource, DateField>(this);
                    _FileAttachmentViaDataSourceCollection =
                        new ConstraintEnforcementCollection<DataSource, FileAttachment>(this);
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

                private int? _Created;

                public override int? Created
                {
                    get { return _Created; }
                    set
                    {
                        int? oldValue = _Created;
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

                private int? _Edited;

                public override int? Edited
                {
                    get { return _Edited; }
                    set
                    {
                        int? oldValue = _Edited;
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

                private int? _Version;

                public override int? Version
                {
                    get { return _Version; }
                    set
                    {
                        int? oldValue = _Version;
                        if (oldValue.GetValueOrDefault() != value.GetValueOrDefault() ||
                            oldValue.HasValue != value.HasValue)
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

                private int? _RevisionDate;

                public override int? RevisionDate
                {
                    get { return _RevisionDate; }
                    set
                    {
                        int? oldValue = _RevisionDate;
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

                private Package _Package;

                public override Package Package
                {
                    get { return _Package; }
                    set
                    {
                        Package oldValue = _Package;
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

                private Owner _DataSourceOwner;

                public override Owner DataSourceOwner
                {
                    get { return _DataSourceOwner; }
                    set
                    {
                        Owner oldValue = _DataSourceOwner;
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

                private State _DataSourceState;

                public override State DataSourceState
                {
                    get { return _DataSourceState; }
                    set
                    {
                        State oldValue = _DataSourceState;
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

                private readonly IEnumerable<DateField> _DateFieldViaDataSourceCollection;

                public override IEnumerable<DateField> DateFieldViaDataSourceCollection
                {
                    get { return _DateFieldViaDataSourceCollection; }
                }

                private readonly IEnumerable<FileAttachment> _FileAttachmentViaDataSourceCollection;

                public override IEnumerable<FileAttachment> FileAttachmentViaDataSourceCollection
                {
                    get { return _FileAttachmentViaDataSourceCollection; }
                }
            }

            #endregion // DataSourceCore

            #endregion // DataSource

            #region DateField

            public DateField CreateDateField()
            {
                return new DateFieldCore(this);
            }

            private bool OnDateFieldLabelChanging(DateField instance, string newValue)
            {
                return true;
            }

            private bool OnDateFieldDefinitionChanging(DateField instance, string newValue)
            {
                return true;
            }

            private bool OnDateFieldSelectedChanging(DateField instance, bool? newValue)
            {
                return true;
            }

            private bool OnDateFieldDataSourceChanging(DateField instance, DataSource newValue)
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

            private void OnDateFieldDataSourceChanged(DateField instance, DataSource oldValue)
            {
                if (instance.DataSource != null)
                {
                    ((ICollection<DateField>) instance.DataSource.DateFieldViaDataSourceCollection).Add(instance);
                }
                if (oldValue != null)
                {
                    ((ICollection<DateField>) oldValue.DateFieldViaDataSourceCollection).Remove(instance);
                }
            }

            private bool OnDateFieldIndustryChanging(DateField instance, Industry newValue)
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

            private void OnDateFieldIndustryChanged(DateField instance, Industry oldValue)
            {
                if (instance.Industry != null)
                {
                    ((ICollection<DateField>) instance.Industry.DateFieldViaIndustryCollection).Add(instance);
                }
                if (oldValue != null)
                {
                    ((ICollection<DateField>) oldValue.DateFieldViaIndustryCollection).Remove(instance);
                }
            }

            private readonly List<DateField> _DateFieldList;
            private readonly ReadOnlyCollection<DateField> _DateFieldReadOnlyCollection;

            public IEnumerable<DateField> DateFieldCollection
            {
                get { return _DateFieldReadOnlyCollection; }
            }

            #region DateFieldCore

            
            private sealed class DateFieldCore : DateField
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

                private DataSource _DataSource;

                public override DataSource DataSource
                {
                    get { return _DataSource; }
                    set
                    {
                        DataSource oldValue = _DataSource;
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

                private Industry _Industry;

                public override Industry Industry
                {
                    get { return _Industry; }
                    set
                    {
                        Industry oldValue = _Industry;
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

            public FileAttachment CreateFileAttachment()
            {
                return new FileAttachmentCore(this);
            }

            private bool OnFileAttachmentFileNameChanging(FileAttachment instance, string newValue)
            {
                return true;
            }

            private bool OnFileAttachmentBlobChanging(FileAttachment instance, byte[] newValue)
            {
                return true;
            }

            private bool OnFileAttachmentDataSourceChanging(FileAttachment instance, DataSource newValue)
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

            private void OnFileAttachmentDataSourceChanged(FileAttachment instance, DataSource oldValue)
            {
                if (instance.DataSource != null)
                {
                    ((ICollection<FileAttachment>) instance.DataSource.FileAttachmentViaDataSourceCollection).Add(
                        instance);
                }
                if (oldValue != null)
                {
                    ((ICollection<FileAttachment>) oldValue.FileAttachmentViaDataSourceCollection).Remove(instance);
                }
            }

            private readonly List<FileAttachment> _FileAttachmentList;
            private readonly ReadOnlyCollection<FileAttachment> _FileAttachmentReadOnlyCollection;

            public IEnumerable<FileAttachment> FileAttachmentCollection
            {
                get { return _FileAttachmentReadOnlyCollection; }
            }

            #region FileAttachmentCore

            
            private sealed class FileAttachmentCore : FileAttachment
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

                private DataSource _DataSource;

                public override DataSource DataSource
                {
                    get { return _DataSource; }
                    set
                    {
                        DataSource oldValue = _DataSource;
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
