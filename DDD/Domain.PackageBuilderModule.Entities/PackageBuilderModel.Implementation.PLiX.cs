using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Xml;
namespace LightstoneApp.Domain.PackageBuilderModule.Context
{
	namespace PackageBuilder
	{
		#region PackageBuilderContext
		[System.CodeDom.Compiler.GeneratedCode("OIALtoPLiX", "1.0")]
		[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto, CharSet=System.Runtime.InteropServices.CharSet.Auto)]
		public sealed class PackageBuilderContext : IPackageBuilderContext
		{
			public PackageBuilderContext()
			{
				Dictionary<RuntimeTypeHandle, object> constraintEnforcementCollectionCallbacksByTypeDictionary = this._ContraintEnforcementCollectionCallbacksByTypeDictionary = new Dictionary<RuntimeTypeHandle, object>(7, RuntimeTypeHandleEqualityComparer.Instance);
				constraintEnforcementCollectionCallbacksByTypeDictionary.Add(typeof(ConstraintEnforcementCollection<Package, PackageDataField>).TypeHandle, new ConstraintEnforcementCollectionCallbacks<Package, PackageDataField>(new PotentialCollectionModificationCallback<Package, PackageDataField>(this.OnPackagePackageDataFieldViaPackageCollectionAdding), new CommittedCollectionModificationCallback<Package, PackageDataField>(this.OnPackagePackageDataFieldViaPackageCollectionAdded), null, new CommittedCollectionModificationCallback<Package, PackageDataField>(this.OnPackagePackageDataFieldViaPackageCollectionRemoved)));
				constraintEnforcementCollectionCallbacksByTypeDictionary.Add(typeof(ConstraintEnforcementCollection<State, Package>).TypeHandle, new ConstraintEnforcementCollectionCallbacks<State, Package>(new PotentialCollectionModificationCallback<State, Package>(this.OnStatePackageViaStateCollectionAdding), new CommittedCollectionModificationCallback<State, Package>(this.OnStatePackageViaStateCollectionAdded), null, new CommittedCollectionModificationCallback<State, Package>(this.OnStatePackageViaStateCollectionRemoved)));
				constraintEnforcementCollectionCallbacksByTypeDictionary.Add(typeof(ConstraintEnforcementCollection<State, DataProvider>).TypeHandle, new ConstraintEnforcementCollectionCallbacks<State, DataProvider>(new PotentialCollectionModificationCallback<State, DataProvider>(this.OnStateDataProviderViaStateCollectionAdding), new CommittedCollectionModificationCallback<State, DataProvider>(this.OnStateDataProviderViaStateCollectionAdded), null, new CommittedCollectionModificationCallback<State, DataProvider>(this.OnStateDataProviderViaStateCollectionRemoved)));
				constraintEnforcementCollectionCallbacksByTypeDictionary.Add(typeof(ConstraintEnforcementCollection<DataProvider, DataField>).TypeHandle, new ConstraintEnforcementCollectionCallbacks<DataProvider, DataField>(new PotentialCollectionModificationCallback<DataProvider, DataField>(this.OnDataProviderDataFieldViaDataProviderCollectionAdding), new CommittedCollectionModificationCallback<DataProvider, DataField>(this.OnDataProviderDataFieldViaDataProviderCollectionAdded), null, new CommittedCollectionModificationCallback<DataProvider, DataField>(this.OnDataProviderDataFieldViaDataProviderCollectionRemoved)));
				constraintEnforcementCollectionCallbacksByTypeDictionary.Add(typeof(ConstraintEnforcementCollection<DataField, PackageDataField>).TypeHandle, new ConstraintEnforcementCollectionCallbacks<DataField, PackageDataField>(new PotentialCollectionModificationCallback<DataField, PackageDataField>(this.OnDataFieldPackageDataFieldViaDataFieldCollectionAdding), new CommittedCollectionModificationCallback<DataField, PackageDataField>(this.OnDataFieldPackageDataFieldViaDataFieldCollectionAdded), null, new CommittedCollectionModificationCallback<DataField, PackageDataField>(this.OnDataFieldPackageDataFieldViaDataFieldCollectionRemoved)));
				constraintEnforcementCollectionCallbacksByTypeDictionary.Add(typeof(ConstraintEnforcementCollection<Industry, Package>).TypeHandle, new ConstraintEnforcementCollectionCallbacks<Industry, Package>(new PotentialCollectionModificationCallback<Industry, Package>(this.OnIndustryPackageViaIndustryCollectionAdding), new CommittedCollectionModificationCallback<Industry, Package>(this.OnIndustryPackageViaIndustryCollectionAdded), null, new CommittedCollectionModificationCallback<Industry, Package>(this.OnIndustryPackageViaIndustryCollectionRemoved)));
				constraintEnforcementCollectionCallbacksByTypeDictionary.Add(typeof(ConstraintEnforcementCollection<Industry, DataField>).TypeHandle, new ConstraintEnforcementCollectionCallbacks<Industry, DataField>(new PotentialCollectionModificationCallback<Industry, DataField>(this.OnIndustryDataFieldViaIndustryCollectionAdding), new CommittedCollectionModificationCallback<Industry, DataField>(this.OnIndustryDataFieldViaIndustryCollectionAdded), null, new CommittedCollectionModificationCallback<Industry, DataField>(this.OnIndustryDataFieldViaIndustryCollectionRemoved)));
				this._PackageReadOnlyCollection = new ReadOnlyCollection<Package>(this._PackageList = new List<Package>());
				this._StateReadOnlyCollection = new ReadOnlyCollection<State>(this._StateList = new List<State>());
				this._DataProviderReadOnlyCollection = new ReadOnlyCollection<DataProvider>(this._DataProviderList = new List<DataProvider>());
				this._DataFieldReadOnlyCollection = new ReadOnlyCollection<DataField>(this._DataFieldList = new List<DataField>());
				this._PackageDataFieldReadOnlyCollection = new ReadOnlyCollection<PackageDataField>(this._PackageDataFieldList = new List<PackageDataField>());
				this._IndustryReadOnlyCollection = new ReadOnlyCollection<Industry>(this._IndustryList = new List<Industry>());
			}
			#region Exception Helpers
			private static ArgumentException GetDifferentContextsException()
			{
				return PackageBuilderContext.GetDifferentContextsException("value");
			}
			[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly")]
			private static ArgumentException GetDifferentContextsException(string paramName)
			{
				return new ArgumentException("All objects in a relationship must be part of the same Context.", paramName);
			}
			private static ArgumentException GetConstraintEnforcementFailedException(string paramName)
			{
				return new ArgumentException("Argument failed constraint enforcement.", paramName);
			}
			#endregion // Exception Helpers
			#region Lookup and External Constraint Enforcement
			private readonly Dictionary<Tuple<string, string>, Package> _PackageNameAndVersionExternalUniquenessConstraintDictionary = new Dictionary<Tuple<string, string>, Package>();
			public Package GetPackageByPackageNameAndVersionExternalUniquenessConstraint(string Name, string Version)
			{
				return this._PackageNameAndVersionExternalUniquenessConstraintDictionary[Tuple.CreateTuple<string, string>(Name, Version)];
			}
			public bool TryGetPackageByPackageNameAndVersionExternalUniquenessConstraint(string Name, string Version, out Package Package)
			{
				return this._PackageNameAndVersionExternalUniquenessConstraintDictionary.TryGetValue(Tuple.CreateTuple<string, string>(Name, Version), out Package);
			}
			private bool OnPackageNameAndVersionExternalUniquenessConstraintChanging(Package instance, Tuple<string, string> newValue)
			{
				if ((object)newValue != null)
				{
					Package currentInstance;
					if (this._PackageNameAndVersionExternalUniquenessConstraintDictionary.TryGetValue(newValue, out currentInstance))
					{
						return (object)currentInstance == (object)instance;
					}
				}
				return true;
			}
			private void OnPackageNameAndVersionExternalUniquenessConstraintChanged(Package instance, Tuple<string, string> oldValue, Tuple<string, string> newValue)
			{
				if ((object)oldValue != null)
				{
					this._PackageNameAndVersionExternalUniquenessConstraintDictionary.Remove(oldValue);
				}
				if ((object)newValue != null)
				{
					this._PackageNameAndVersionExternalUniquenessConstraintDictionary.Add(newValue, instance);
				}
			}
			private readonly Dictionary<Tuple<string, string>, DataProvider> _DataProviderNameAndVersionUniquenessConstraintDictionary = new Dictionary<Tuple<string, string>, DataProvider>();
			public DataProvider GetDataProviderByDataProviderNameAndVersionUniquenessConstraint(string Name, string Version)
			{
				return this._DataProviderNameAndVersionUniquenessConstraintDictionary[Tuple.CreateTuple<string, string>(Name, Version)];
			}
			public bool TryGetDataProviderByDataProviderNameAndVersionUniquenessConstraint(string Name, string Version, out DataProvider DataProvider)
			{
				return this._DataProviderNameAndVersionUniquenessConstraintDictionary.TryGetValue(Tuple.CreateTuple<string, string>(Name, Version), out DataProvider);
			}
			private bool OnDataProviderNameAndVersionUniquenessConstraintChanging(DataProvider instance, Tuple<string, string> newValue)
			{
				if ((object)newValue != null)
				{
					DataProvider currentInstance;
					if (this._DataProviderNameAndVersionUniquenessConstraintDictionary.TryGetValue(newValue, out currentInstance))
					{
						return (object)currentInstance == (object)instance;
					}
				}
				return true;
			}
			private void OnDataProviderNameAndVersionUniquenessConstraintChanged(DataProvider instance, Tuple<string, string> oldValue, Tuple<string, string> newValue)
			{
				if ((object)oldValue != null)
				{
					this._DataProviderNameAndVersionUniquenessConstraintDictionary.Remove(oldValue);
				}
				if ((object)newValue != null)
				{
					this._DataProviderNameAndVersionUniquenessConstraintDictionary.Add(newValue, instance);
				}
			}
			private readonly Dictionary<string, DataField> _DataFieldNameDictionary = new Dictionary<string, DataField>();
			public DataField GetDataFieldByName(string Name)
			{
				return this._DataFieldNameDictionary[Name];
			}
			public bool TryGetDataFieldByName(string Name, out DataField DataField)
			{
				return this._DataFieldNameDictionary.TryGetValue(Name, out DataField);
			}
			#endregion // Lookup and External Constraint Enforcement
			#region ConstraintEnforcementCollection
			private delegate bool PotentialCollectionModificationCallback<TClass, TProperty>(TClass instance, TProperty item)
				where TClass : class, IHasPackageBuilderContext;
			private delegate void CommittedCollectionModificationCallback<TClass, TProperty>(TClass instance, TProperty item)
				where TClass : class, IHasPackageBuilderContext;
			[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto, CharSet=System.Runtime.InteropServices.CharSet.Auto)]
			private sealed class ConstraintEnforcementCollectionCallbacks<TClass, TProperty>
				where TClass : class, IHasPackageBuilderContext
			{
				public ConstraintEnforcementCollectionCallbacks(PotentialCollectionModificationCallback<TClass, TProperty> adding, CommittedCollectionModificationCallback<TClass, TProperty> added, PotentialCollectionModificationCallback<TClass, TProperty> removing, CommittedCollectionModificationCallback<TClass, TProperty> removed)
				{
					this.Adding = adding;
					this.Added = added;
					this.Removing = removing;
					this.Removed = removed;
				}
				public readonly PotentialCollectionModificationCallback<TClass, TProperty> Adding;
				public readonly CommittedCollectionModificationCallback<TClass, TProperty> Added;
				public readonly PotentialCollectionModificationCallback<TClass, TProperty> Removing;
				public readonly CommittedCollectionModificationCallback<TClass, TProperty> Removed;
			}
			private ConstraintEnforcementCollectionCallbacks<TClass, TProperty> GetConstraintEnforcementCollectionCallbacks<TClass, TProperty>()
				where TClass : class, IHasPackageBuilderContext
			{
				return (ConstraintEnforcementCollectionCallbacks<TClass, TProperty>)this._ContraintEnforcementCollectionCallbacksByTypeDictionary[typeof(ConstraintEnforcementCollection<TClass, TProperty>).TypeHandle];
			}
			[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto, CharSet=System.Runtime.InteropServices.CharSet.Auto)]
			private sealed class RuntimeTypeHandleEqualityComparer : IEqualityComparer<RuntimeTypeHandle>
			{
				public static readonly RuntimeTypeHandleEqualityComparer Instance = new RuntimeTypeHandleEqualityComparer();
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
			private readonly Dictionary<RuntimeTypeHandle, object> _ContraintEnforcementCollectionCallbacksByTypeDictionary;
			[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto, CharSet=System.Runtime.InteropServices.CharSet.Auto)]
			private sealed class ConstraintEnforcementCollection<TClass, TProperty> : ICollection<TProperty>
				where TClass : class, IHasPackageBuilderContext
			{
				private readonly TClass _instance;
				private readonly List<TProperty> _list = new List<TProperty>();
				public ConstraintEnforcementCollection(TClass instance)
				{
					this._instance = instance;
				}
				private System.Collections.IEnumerator GetNonGenericEnumerator()
				{
					return this.GetEnumerator();
				}
				System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
				{
					return this.GetNonGenericEnumerator();
				}
				public IEnumerator<TProperty> GetEnumerator()
				{
					return this._list.GetEnumerator();
				}
				public void Add(TProperty item)
				{
					if (item == null)
					{
						throw new ArgumentNullException("item");
					}
					TClass instance = this._instance;
					ConstraintEnforcementCollectionCallbacks<TClass, TProperty> callbacks = instance.Context.GetConstraintEnforcementCollectionCallbacks<TClass, TProperty>();
					PotentialCollectionModificationCallback<TClass, TProperty> adding = callbacks.Adding;
					if ((object)adding == null || adding(instance, item))
					{
						this._list.Add(item);
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
					TClass instance = this._instance;
					ConstraintEnforcementCollectionCallbacks<TClass, TProperty> callbacks = instance.Context.GetConstraintEnforcementCollectionCallbacks<TClass, TProperty>();
					PotentialCollectionModificationCallback<TClass, TProperty> removing = callbacks.Removing;
					if ((object)removing == null || removing(instance, item))
					{
						if (this._list.Remove(item))
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
					List<TProperty> list = this._list;
					for (int i = list.Count - 1; i > 0; --i)
					{
						this.Remove(list[i]);
					}
				}
				public bool Contains(TProperty item)
				{
					return item != null && this._list.Contains(item);
				}
				public void CopyTo(TProperty[] array, int arrayIndex)
				{
					this._list.CopyTo(array, arrayIndex);
				}
				public int Count
				{
					get
					{
						return this._list.Count;
					}
				}
				public bool IsReadOnly
				{
					get
					{
						return false;
					}
				}
			}
			#endregion // ConstraintEnforcementCollection
			#region Package
			public Package CreatePackage(string Name, string Description, string Version, State State)
			{
				if ((object)Name == null)
				{
					throw new ArgumentNullException("Name");
				}
				if ((object)Description == null)
				{
					throw new ArgumentNullException("Description");
				}
				if ((object)Version == null)
				{
					throw new ArgumentNullException("Version");
				}
				if ((object)State == null)
				{
					throw new ArgumentNullException("State");
				}
				if (!this.OnPackageNameChanging(null, Name))
				{
					throw PackageBuilderContext.GetConstraintEnforcementFailedException("Name");
				}
				if (!this.OnPackageDescriptionChanging(null, Description))
				{
					throw PackageBuilderContext.GetConstraintEnforcementFailedException("Description");
				}
				if (!this.OnPackageVersionChanging(null, Version))
				{
					throw PackageBuilderContext.GetConstraintEnforcementFailedException("Version");
				}
				if (!this.OnPackageStateChanging(null, State))
				{
					throw PackageBuilderContext.GetConstraintEnforcementFailedException("State");
				}
				return new PackageCore(this, Name, Description, Version, State);
			}
			private bool OnPackageNameChanging(Package instance, string newValue)
			{
				if ((object)instance != null)
				{
					if (!this.OnPackageNameAndVersionExternalUniquenessConstraintChanging(instance, Tuple.CreateTuple<string, string>(newValue, instance.Version)))
					{
						return false;
					}
				}
				return true;
			}
			private void OnPackageNameChanged(Package instance, string oldValue)
			{
				Tuple<string, string> PackageNameAndVersionExternalUniquenessConstraintOldValueTuple;
				if ((object)oldValue != null)
				{
					PackageNameAndVersionExternalUniquenessConstraintOldValueTuple = Tuple.CreateTuple<string, string>(oldValue, instance.Version);
				}
				else
				{
					PackageNameAndVersionExternalUniquenessConstraintOldValueTuple = null;
				}
				this.OnPackageNameAndVersionExternalUniquenessConstraintChanged(instance, PackageNameAndVersionExternalUniquenessConstraintOldValueTuple, Tuple.CreateTuple<string, string>(instance.Name, instance.Version));
			}
			private bool OnPackageDescriptionChanging(Package instance, string newValue)
			{
				return true;
			}
			private bool OnPackageOwnerChanging(Package instance, string newValue)
			{
				return true;
			}
			private bool OnPackageCreatedChanging(Package instance, Nullable<int> newValue)
			{
				return true;
			}
			private bool OnPackageEditedChanging(Package instance, Nullable<int> newValue)
			{
				return true;
			}
			private bool OnPackageVersionChanging(Package instance, string newValue)
			{
				if ((object)instance != null)
				{
					if (!this.OnPackageNameAndVersionExternalUniquenessConstraintChanging(instance, Tuple.CreateTuple<string, string>(instance.Name, newValue)))
					{
						return false;
					}
				}
				return true;
			}
			private void OnPackageVersionChanged(Package instance, string oldValue)
			{
				Tuple<string, string> PackageNameAndVersionExternalUniquenessConstraintOldValueTuple;
				if ((object)oldValue != null)
				{
					PackageNameAndVersionExternalUniquenessConstraintOldValueTuple = Tuple.CreateTuple<string, string>(instance.Name, oldValue);
				}
				else
				{
					PackageNameAndVersionExternalUniquenessConstraintOldValueTuple = null;
				}
				this.OnPackageNameAndVersionExternalUniquenessConstraintChanged(instance, PackageNameAndVersionExternalUniquenessConstraintOldValueTuple, Tuple.CreateTuple<string, string>(instance.Name, instance.Version));
			}
			private bool OnPackagePublishedChanging(Package instance, Nullable<bool> newValue)
			{
				return true;
			}
			private bool OnPackageRevisionDateChanging(Package instance, Nullable<int> newValue)
			{
				return true;
			}
			private bool OnPackageCostOfSaleChanging(Package instance, Nullable<decimal> newValue)
			{
				return true;
			}
			private bool OnPackageRecomendedRetailPriceChanging(Package instance, Nullable<decimal> newValue)
			{
				return true;
			}
			private bool OnPackageStateChanging(Package instance, State newValue)
			{
				if ((object)this != (object)newValue.Context)
				{
					throw PackageBuilderContext.GetDifferentContextsException();
				}
				return true;
			}
			private void OnPackageStateChanged(Package instance, State oldValue)
			{
				((ICollection<Package>)instance.State.PackageViaStateCollection).Add(instance);
				if ((object)oldValue != null)
				{
					((ICollection<Package>)oldValue.PackageViaStateCollection).Remove(instance);
				}
			}
			private bool OnPackageIndustryChanging(Package instance, Industry newValue)
			{
				if ((object)newValue != null)
				{
					if ((object)this != (object)newValue.Context)
					{
						throw PackageBuilderContext.GetDifferentContextsException();
					}
				}
				return true;
			}
			private void OnPackageIndustryChanged(Package instance, Industry oldValue)
			{
				if ((object)instance.Industry != null)
				{
					((ICollection<Package>)instance.Industry.PackageViaIndustryCollection).Add(instance);
				}
				if ((object)oldValue != null)
				{
					((ICollection<Package>)oldValue.PackageViaIndustryCollection).Remove(instance);
				}
			}
			private bool OnPackagePackageDataFieldViaPackageCollectionAdding(Package instance, PackageDataField item)
			{
				if ((object)this != (object)item.Context)
				{
					throw PackageBuilderContext.GetDifferentContextsException("item");
				}
				return true;
			}
			private void OnPackagePackageDataFieldViaPackageCollectionAdded(Package instance, PackageDataField item)
			{
				item.Package = instance;
			}
			private void OnPackagePackageDataFieldViaPackageCollectionRemoved(Package instance, PackageDataField item)
			{
				if ((object)item.Package == (object)instance)
				{
					item.Package = null;
				}
			}
			private readonly List<Package> _PackageList;
			private readonly ReadOnlyCollection<Package> _PackageReadOnlyCollection;
			public IEnumerable<Package> PackageCollection
			{
				get
				{
					return this._PackageReadOnlyCollection;
				}
			}
			#region PackageCore
			[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto, CharSet=System.Runtime.InteropServices.CharSet.Auto)]
			private sealed class PackageCore : Package
			{
				public PackageCore(PackageBuilderContext context, string Name, string Description, string Version, State State)
				{
					this._Context = context;
					this._PackageDataFieldViaPackageCollection = new ConstraintEnforcementCollection<Package, PackageDataField>(this);
					this._Name = Name;
					context.OnPackageNameChanged(this, null);
					this._Description = Description;
					this._Version = Version;
					context.OnPackageVersionChanged(this, null);
					this._State = State;
					context.OnPackageStateChanged(this, null);
					context._PackageList.Add(this);
				}
				private readonly PackageBuilderContext _Context;
				public sealed override PackageBuilderContext Context
				{
					get
					{
						return this._Context;
					}
				}
				private string _Name;
				public sealed override string Name
				{
					get
					{
						return this._Name;
					}
					set
					{
						if ((object)value == null)
						{
							throw new ArgumentNullException("value");
						}
						string oldValue = this._Name;
						if ((object)oldValue != (object)value && !value.Equals(oldValue))
						{
							if (this._Context.OnPackageNameChanging(this, value) && base.OnNameChanging(value))
							{
								this._Name = value;
								this._Context.OnPackageNameChanged(this, oldValue);
								base.OnNameChanged(oldValue);
							}
						}
					}
				}
				private string _Description;
				public sealed override string Description
				{
					get
					{
						return this._Description;
					}
					set
					{
						if ((object)value == null)
						{
							throw new ArgumentNullException("value");
						}
						string oldValue = this._Description;
						if ((object)oldValue != (object)value && !value.Equals(oldValue))
						{
							if (this._Context.OnPackageDescriptionChanging(this, value) && base.OnDescriptionChanging(value))
							{
								this._Description = value;
								base.OnDescriptionChanged(oldValue);
							}
						}
					}
				}
				private string _Owner;
				public sealed override string Owner
				{
					get
					{
						return this._Owner;
					}
					set
					{
						string oldValue = this._Owner;
						if (!object.Equals(oldValue, value))
						{
							if (this._Context.OnPackageOwnerChanging(this, value) && base.OnOwnerChanging(value))
							{
								this._Owner = value;
								base.OnOwnerChanged(oldValue);
							}
						}
					}
				}
				private Nullable<int> _Created;
				public sealed override Nullable<int> Created
				{
					get
					{
						return this._Created;
					}
					set
					{
						Nullable<int> oldValue = this._Created;
						if (oldValue.GetValueOrDefault() != value.GetValueOrDefault() || oldValue.HasValue != value.HasValue)
						{
							if (this._Context.OnPackageCreatedChanging(this, value) && base.OnCreatedChanging(value))
							{
								this._Created = value;
								base.OnCreatedChanged(oldValue);
							}
						}
					}
				}
				private Nullable<int> _Edited;
				public sealed override Nullable<int> Edited
				{
					get
					{
						return this._Edited;
					}
					set
					{
						Nullable<int> oldValue = this._Edited;
						if (oldValue.GetValueOrDefault() != value.GetValueOrDefault() || oldValue.HasValue != value.HasValue)
						{
							if (this._Context.OnPackageEditedChanging(this, value) && base.OnEditedChanging(value))
							{
								this._Edited = value;
								base.OnEditedChanged(oldValue);
							}
						}
					}
				}
				private string _Version;
				public sealed override string Version
				{
					get
					{
						return this._Version;
					}
					set
					{
						if ((object)value == null)
						{
							throw new ArgumentNullException("value");
						}
						string oldValue = this._Version;
						if ((object)oldValue != (object)value && !value.Equals(oldValue))
						{
							if (this._Context.OnPackageVersionChanging(this, value) && base.OnVersionChanging(value))
							{
								this._Version = value;
								this._Context.OnPackageVersionChanged(this, oldValue);
								base.OnVersionChanged(oldValue);
							}
						}
					}
				}
				private Nullable<bool> _Published;
				public sealed override Nullable<bool> Published
				{
					get
					{
						return this._Published;
					}
					set
					{
						Nullable<bool> oldValue = this._Published;
						if (oldValue.GetValueOrDefault() != value.GetValueOrDefault() || oldValue.HasValue != value.HasValue)
						{
							if (this._Context.OnPackagePublishedChanging(this, value) && base.OnPublishedChanging(value))
							{
								this._Published = value;
								base.OnPublishedChanged(oldValue);
							}
						}
					}
				}
				private Nullable<int> _RevisionDate;
				public sealed override Nullable<int> RevisionDate
				{
					get
					{
						return this._RevisionDate;
					}
					set
					{
						Nullable<int> oldValue = this._RevisionDate;
						if (oldValue.GetValueOrDefault() != value.GetValueOrDefault() || oldValue.HasValue != value.HasValue)
						{
							if (this._Context.OnPackageRevisionDateChanging(this, value) && base.OnRevisionDateChanging(value))
							{
								this._RevisionDate = value;
								base.OnRevisionDateChanged(oldValue);
							}
						}
					}
				}
				private Nullable<decimal> _CostOfSale;
				public sealed override Nullable<decimal> CostOfSale
				{
					get
					{
						return this._CostOfSale;
					}
					set
					{
						Nullable<decimal> oldValue = this._CostOfSale;
						if (oldValue.GetValueOrDefault() != value.GetValueOrDefault() || oldValue.HasValue != value.HasValue)
						{
							if (this._Context.OnPackageCostOfSaleChanging(this, value) && base.OnCostOfSaleChanging(value))
							{
								this._CostOfSale = value;
								base.OnCostOfSaleChanged(oldValue);
							}
						}
					}
				}
				private Nullable<decimal> _RecomendedRetailPrice;
				public sealed override Nullable<decimal> RecomendedRetailPrice
				{
					get
					{
						return this._RecomendedRetailPrice;
					}
					set
					{
						Nullable<decimal> oldValue = this._RecomendedRetailPrice;
						if (oldValue.GetValueOrDefault() != value.GetValueOrDefault() || oldValue.HasValue != value.HasValue)
						{
							if (this._Context.OnPackageRecomendedRetailPriceChanging(this, value) && base.OnRecomendedRetailPriceChanging(value))
							{
								this._RecomendedRetailPrice = value;
								base.OnRecomendedRetailPriceChanged(oldValue);
							}
						}
					}
				}
				private State _State;
				public sealed override State State
				{
					get
					{
						return this._State;
					}
					set
					{
						if ((object)value == null)
						{
							throw new ArgumentNullException("value");
						}
						State oldValue = this._State;
						if ((object)oldValue != (object)value)
						{
							if (this._Context.OnPackageStateChanging(this, value) && base.OnStateChanging(value))
							{
								this._State = value;
								this._Context.OnPackageStateChanged(this, oldValue);
								base.OnStateChanged(oldValue);
							}
						}
					}
				}
				private Industry _Industry;
				public sealed override Industry Industry
				{
					get
					{
						return this._Industry;
					}
					set
					{
						Industry oldValue = this._Industry;
						if ((object)oldValue != (object)value)
						{
							if (this._Context.OnPackageIndustryChanging(this, value) && base.OnIndustryChanging(value))
							{
								this._Industry = value;
								this._Context.OnPackageIndustryChanged(this, oldValue);
								base.OnIndustryChanged(oldValue);
							}
						}
					}
				}
				private readonly IEnumerable<PackageDataField> _PackageDataFieldViaPackageCollection;
				public sealed override IEnumerable<PackageDataField> PackageDataFieldViaPackageCollection
				{
					get
					{
						return this._PackageDataFieldViaPackageCollection;
					}
				}
			}
			#endregion // PackageCore
			#endregion // Package
			#region State
			public State CreateState(string Value)
			{
				if ((object)Value == null)
				{
					throw new ArgumentNullException("Value");
				}
				if (!this.OnStateValueChanging(null, Value))
				{
					throw PackageBuilderContext.GetConstraintEnforcementFailedException("Value");
				}
				return new StateCore(this, Value);
			}
			private bool OnStateValueChanging(State instance, string newValue)
			{
				return true;
			}
			private bool OnStatePackageViaStateCollectionAdding(State instance, Package item)
			{
				if ((object)this != (object)item.Context)
				{
					throw PackageBuilderContext.GetDifferentContextsException("item");
				}
				return true;
			}
			private void OnStatePackageViaStateCollectionAdded(State instance, Package item)
			{
				item.State = instance;
			}
			private void OnStatePackageViaStateCollectionRemoved(State instance, Package item)
			{
				if ((object)item.State == (object)instance)
				{
					item.State = null;
				}
			}
			private bool OnStateDataProviderViaStateCollectionAdding(State instance, DataProvider item)
			{
				if ((object)this != (object)item.Context)
				{
					throw PackageBuilderContext.GetDifferentContextsException("item");
				}
				return true;
			}
			private void OnStateDataProviderViaStateCollectionAdded(State instance, DataProvider item)
			{
				item.State = instance;
			}
			private void OnStateDataProviderViaStateCollectionRemoved(State instance, DataProvider item)
			{
				if ((object)item.State == (object)instance)
				{
					item.State = null;
				}
			}
			private readonly List<State> _StateList;
			private readonly ReadOnlyCollection<State> _StateReadOnlyCollection;
			public IEnumerable<State> StateCollection
			{
				get
				{
					return this._StateReadOnlyCollection;
				}
			}
			#region StateCore
			[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto, CharSet=System.Runtime.InteropServices.CharSet.Auto)]
			private sealed class StateCore : State
			{
				public StateCore(PackageBuilderContext context, string Value)
				{
					this._Context = context;
					this._PackageViaStateCollection = new ConstraintEnforcementCollection<State, Package>(this);
					this._DataProviderViaStateCollection = new ConstraintEnforcementCollection<State, DataProvider>(this);
					this._Value = Value;
					context._StateList.Add(this);
				}
				private readonly PackageBuilderContext _Context;
				public sealed override PackageBuilderContext Context
				{
					get
					{
						return this._Context;
					}
				}
				private string _Value;
				public sealed override string Value
				{
					get
					{
						return this._Value;
					}
					set
					{
						if ((object)value == null)
						{
							throw new ArgumentNullException("value");
						}
						string oldValue = this._Value;
						if ((object)oldValue != (object)value && !value.Equals(oldValue))
						{
							if (this._Context.OnStateValueChanging(this, value) && base.OnValueChanging(value))
							{
								this._Value = value;
								base.OnValueChanged(oldValue);
							}
						}
					}
				}
				private readonly IEnumerable<Package> _PackageViaStateCollection;
				public sealed override IEnumerable<Package> PackageViaStateCollection
				{
					get
					{
						return this._PackageViaStateCollection;
					}
				}
				private readonly IEnumerable<DataProvider> _DataProviderViaStateCollection;
				public sealed override IEnumerable<DataProvider> DataProviderViaStateCollection
				{
					get
					{
						return this._DataProviderViaStateCollection;
					}
				}
			}
			#endregion // StateCore
			#endregion // State
			#region DataProvider
			public DataProvider CreateDataProvider(string Name, string Owner, string Version, string SourceURL, State State)
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
				if ((object)State == null)
				{
					throw new ArgumentNullException("State");
				}
				if (!this.OnDataProviderNameChanging(null, Name))
				{
					throw PackageBuilderContext.GetConstraintEnforcementFailedException("Name");
				}
				if (!this.OnDataProviderOwnerChanging(null, Owner))
				{
					throw PackageBuilderContext.GetConstraintEnforcementFailedException("Owner");
				}
				if (!this.OnDataProviderVersionChanging(null, Version))
				{
					throw PackageBuilderContext.GetConstraintEnforcementFailedException("Version");
				}
				if (!this.OnDataProviderSourceURLChanging(null, SourceURL))
				{
					throw PackageBuilderContext.GetConstraintEnforcementFailedException("SourceURL");
				}
				if (!this.OnDataProviderStateChanging(null, State))
				{
					throw PackageBuilderContext.GetConstraintEnforcementFailedException("State");
				}
				return new DataProviderCore(this, Name, Owner, Version, SourceURL, State);
			}
			private bool OnDataProviderNameChanging(DataProvider instance, string newValue)
			{
				if ((object)instance != null)
				{
					if (!this.OnDataProviderNameAndVersionUniquenessConstraintChanging(instance, Tuple.CreateTuple<string, string>(newValue, instance.Version)))
					{
						return false;
					}
				}
				return true;
			}
			private void OnDataProviderNameChanged(DataProvider instance, string oldValue)
			{
				Tuple<string, string> DataProviderNameAndVersionUniquenessConstraintOldValueTuple;
				if ((object)oldValue != null)
				{
					DataProviderNameAndVersionUniquenessConstraintOldValueTuple = Tuple.CreateTuple<string, string>(oldValue, instance.Version);
				}
				else
				{
					DataProviderNameAndVersionUniquenessConstraintOldValueTuple = null;
				}
				this.OnDataProviderNameAndVersionUniquenessConstraintChanged(instance, DataProviderNameAndVersionUniquenessConstraintOldValueTuple, Tuple.CreateTuple<string, string>(instance.Name, instance.Version));
			}
			private bool OnDataProviderDescriptionChanging(DataProvider instance, string newValue)
			{
				return true;
			}
			private bool OnDataProviderOwnerChanging(DataProvider instance, string newValue)
			{
				return true;
			}
			private bool OnDataProviderCreatedChanging(DataProvider instance, Nullable<int> newValue)
			{
				return true;
			}
			private bool OnDataProviderEditedChanging(DataProvider instance, Nullable<int> newValue)
			{
				return true;
			}
			private bool OnDataProviderVersionChanging(DataProvider instance, string newValue)
			{
				if ((object)instance != null)
				{
					if (!this.OnDataProviderNameAndVersionUniquenessConstraintChanging(instance, Tuple.CreateTuple<string, string>(instance.Name, newValue)))
					{
						return false;
					}
				}
				return true;
			}
			private void OnDataProviderVersionChanged(DataProvider instance, string oldValue)
			{
				Tuple<string, string> DataProviderNameAndVersionUniquenessConstraintOldValueTuple;
				if ((object)oldValue != null)
				{
					DataProviderNameAndVersionUniquenessConstraintOldValueTuple = Tuple.CreateTuple<string, string>(instance.Name, oldValue);
				}
				else
				{
					DataProviderNameAndVersionUniquenessConstraintOldValueTuple = null;
				}
				this.OnDataProviderNameAndVersionUniquenessConstraintChanged(instance, DataProviderNameAndVersionUniquenessConstraintOldValueTuple, Tuple.CreateTuple<string, string>(instance.Name, instance.Version));
			}
			private bool OnDataProviderCostOfSaleChanging(DataProvider instance, Nullable<decimal> newValue)
			{
				return true;
			}
			private bool OnDataProviderRevisionDateChanging(DataProvider instance, Nullable<int> newValue)
			{
				return true;
			}
			private bool OnDataProviderSourceURLChanging(DataProvider instance, string newValue)
			{
				return true;
			}
			private bool OnDataProviderStateChanging(DataProvider instance, State newValue)
			{
				if ((object)this != (object)newValue.Context)
				{
					throw PackageBuilderContext.GetDifferentContextsException();
				}
				return true;
			}
			private void OnDataProviderStateChanged(DataProvider instance, State oldValue)
			{
				((ICollection<DataProvider>)instance.State.DataProviderViaStateCollection).Add(instance);
				if ((object)oldValue != null)
				{
					((ICollection<DataProvider>)oldValue.DataProviderViaStateCollection).Remove(instance);
				}
			}
			private bool OnDataProviderDataFieldViaDataProviderCollectionAdding(DataProvider instance, DataField item)
			{
				if ((object)this != (object)item.Context)
				{
					throw PackageBuilderContext.GetDifferentContextsException("item");
				}
				return true;
			}
			private void OnDataProviderDataFieldViaDataProviderCollectionAdded(DataProvider instance, DataField item)
			{
				item.DataProvider = instance;
			}
			private void OnDataProviderDataFieldViaDataProviderCollectionRemoved(DataProvider instance, DataField item)
			{
				if ((object)item.DataProvider == (object)instance)
				{
					item.DataProvider = null;
				}
			}
			private readonly List<DataProvider> _DataProviderList;
			private readonly ReadOnlyCollection<DataProvider> _DataProviderReadOnlyCollection;
			public IEnumerable<DataProvider> DataProviderCollection
			{
				get
				{
					return this._DataProviderReadOnlyCollection;
				}
			}
			#region DataProviderCore
			[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto, CharSet=System.Runtime.InteropServices.CharSet.Auto)]
			private sealed class DataProviderCore : DataProvider
			{
				public DataProviderCore(PackageBuilderContext context, string Name, string Owner, string Version, string SourceURL, State State)
				{
					this._Context = context;
					this._DataFieldViaDataProviderCollection = new ConstraintEnforcementCollection<DataProvider, DataField>(this);
					this._Name = Name;
					context.OnDataProviderNameChanged(this, null);
					this._Owner = Owner;
					this._Version = Version;
					context.OnDataProviderVersionChanged(this, null);
					this._SourceURL = SourceURL;
					this._State = State;
					context.OnDataProviderStateChanged(this, null);
					context._DataProviderList.Add(this);
				}
				private readonly PackageBuilderContext _Context;
				public sealed override PackageBuilderContext Context
				{
					get
					{
						return this._Context;
					}
				}
				private string _Name;
				public sealed override string Name
				{
					get
					{
						return this._Name;
					}
					set
					{
						if ((object)value == null)
						{
							throw new ArgumentNullException("value");
						}
						string oldValue = this._Name;
						if ((object)oldValue != (object)value && !value.Equals(oldValue))
						{
							if (this._Context.OnDataProviderNameChanging(this, value) && base.OnNameChanging(value))
							{
								this._Name = value;
								this._Context.OnDataProviderNameChanged(this, oldValue);
								base.OnNameChanged(oldValue);
							}
						}
					}
				}
				private string _Description;
				public sealed override string Description
				{
					get
					{
						return this._Description;
					}
					set
					{
						string oldValue = this._Description;
						if (!object.Equals(oldValue, value))
						{
							if (this._Context.OnDataProviderDescriptionChanging(this, value) && base.OnDescriptionChanging(value))
							{
								this._Description = value;
								base.OnDescriptionChanged(oldValue);
							}
						}
					}
				}
				private string _Owner;
				public sealed override string Owner
				{
					get
					{
						return this._Owner;
					}
					set
					{
						if ((object)value == null)
						{
							throw new ArgumentNullException("value");
						}
						string oldValue = this._Owner;
						if ((object)oldValue != (object)value && !value.Equals(oldValue))
						{
							if (this._Context.OnDataProviderOwnerChanging(this, value) && base.OnOwnerChanging(value))
							{
								this._Owner = value;
								base.OnOwnerChanged(oldValue);
							}
						}
					}
				}
				private Nullable<int> _Created;
				public sealed override Nullable<int> Created
				{
					get
					{
						return this._Created;
					}
					set
					{
						Nullable<int> oldValue = this._Created;
						if (oldValue.GetValueOrDefault() != value.GetValueOrDefault() || oldValue.HasValue != value.HasValue)
						{
							if (this._Context.OnDataProviderCreatedChanging(this, value) && base.OnCreatedChanging(value))
							{
								this._Created = value;
								base.OnCreatedChanged(oldValue);
							}
						}
					}
				}
				private Nullable<int> _Edited;
				public sealed override Nullable<int> Edited
				{
					get
					{
						return this._Edited;
					}
					set
					{
						Nullable<int> oldValue = this._Edited;
						if (oldValue.GetValueOrDefault() != value.GetValueOrDefault() || oldValue.HasValue != value.HasValue)
						{
							if (this._Context.OnDataProviderEditedChanging(this, value) && base.OnEditedChanging(value))
							{
								this._Edited = value;
								base.OnEditedChanged(oldValue);
							}
						}
					}
				}
				private string _Version;
				public sealed override string Version
				{
					get
					{
						return this._Version;
					}
					set
					{
						if ((object)value == null)
						{
							throw new ArgumentNullException("value");
						}
						string oldValue = this._Version;
						if ((object)oldValue != (object)value && !value.Equals(oldValue))
						{
							if (this._Context.OnDataProviderVersionChanging(this, value) && base.OnVersionChanging(value))
							{
								this._Version = value;
								this._Context.OnDataProviderVersionChanged(this, oldValue);
								base.OnVersionChanged(oldValue);
							}
						}
					}
				}
				private Nullable<decimal> _CostOfSale;
				public sealed override Nullable<decimal> CostOfSale
				{
					get
					{
						return this._CostOfSale;
					}
					set
					{
						Nullable<decimal> oldValue = this._CostOfSale;
						if (oldValue.GetValueOrDefault() != value.GetValueOrDefault() || oldValue.HasValue != value.HasValue)
						{
							if (this._Context.OnDataProviderCostOfSaleChanging(this, value) && base.OnCostOfSaleChanging(value))
							{
								this._CostOfSale = value;
								base.OnCostOfSaleChanged(oldValue);
							}
						}
					}
				}
				private Nullable<int> _RevisionDate;
				public sealed override Nullable<int> RevisionDate
				{
					get
					{
						return this._RevisionDate;
					}
					set
					{
						Nullable<int> oldValue = this._RevisionDate;
						if (oldValue.GetValueOrDefault() != value.GetValueOrDefault() || oldValue.HasValue != value.HasValue)
						{
							if (this._Context.OnDataProviderRevisionDateChanging(this, value) && base.OnRevisionDateChanging(value))
							{
								this._RevisionDate = value;
								base.OnRevisionDateChanged(oldValue);
							}
						}
					}
				}
				private string _SourceURL;
				public sealed override string SourceURL
				{
					get
					{
						return this._SourceURL;
					}
					set
					{
						if ((object)value == null)
						{
							throw new ArgumentNullException("value");
						}
						string oldValue = this._SourceURL;
						if ((object)oldValue != (object)value && !value.Equals(oldValue))
						{
							if (this._Context.OnDataProviderSourceURLChanging(this, value) && base.OnSourceURLChanging(value))
							{
								this._SourceURL = value;
								base.OnSourceURLChanged(oldValue);
							}
						}
					}
				}
				private State _State;
				public sealed override State State
				{
					get
					{
						return this._State;
					}
					set
					{
						if ((object)value == null)
						{
							throw new ArgumentNullException("value");
						}
						State oldValue = this._State;
						if ((object)oldValue != (object)value)
						{
							if (this._Context.OnDataProviderStateChanging(this, value) && base.OnStateChanging(value))
							{
								this._State = value;
								this._Context.OnDataProviderStateChanged(this, oldValue);
								base.OnStateChanged(oldValue);
							}
						}
					}
				}
				private readonly IEnumerable<DataField> _DataFieldViaDataProviderCollection;
				public sealed override IEnumerable<DataField> DataFieldViaDataProviderCollection
				{
					get
					{
						return this._DataFieldViaDataProviderCollection;
					}
				}
			}
			#endregion // DataProviderCore
			#endregion // DataProvider
			#region DataField
			public DataField CreateDataField(bool Selected, decimal CostOfSale, string Name, DataProvider DataProvider, Industry Industry)
			{
				if ((object)Name == null)
				{
					throw new ArgumentNullException("Name");
				}
				if ((object)DataProvider == null)
				{
					throw new ArgumentNullException("DataProvider");
				}
				if ((object)Industry == null)
				{
					throw new ArgumentNullException("Industry");
				}
				if (!this.OnDataFieldSelectedChanging(null, Selected))
				{
					throw PackageBuilderContext.GetConstraintEnforcementFailedException("Selected");
				}
				if (!this.OnDataFieldCostOfSaleChanging(null, CostOfSale))
				{
					throw PackageBuilderContext.GetConstraintEnforcementFailedException("CostOfSale");
				}
				if (!this.OnDataFieldNameChanging(null, Name))
				{
					throw PackageBuilderContext.GetConstraintEnforcementFailedException("Name");
				}
				if (!this.OnDataFieldDataProviderChanging(null, DataProvider))
				{
					throw PackageBuilderContext.GetConstraintEnforcementFailedException("DataProvider");
				}
				if (!this.OnDataFieldIndustryChanging(null, Industry))
				{
					throw PackageBuilderContext.GetConstraintEnforcementFailedException("Industry");
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
				if (this._DataFieldNameDictionary.TryGetValue(newValue, out currentInstance))
				{
					if ((object)currentInstance != (object)instance)
					{
						return false;
					}
				}
				return true;
			}
			private void OnDataFieldNameChanged(DataField instance, string oldValue)
			{
				this._DataFieldNameDictionary.Add(instance.Name, instance);
				if ((object)oldValue != null)
				{
					this._DataFieldNameDictionary.Remove(oldValue);
				}
			}
			private bool OnDataFieldDataProviderChanging(DataField instance, DataProvider newValue)
			{
				if ((object)this != (object)newValue.Context)
				{
					throw PackageBuilderContext.GetDifferentContextsException();
				}
				return true;
			}
			private void OnDataFieldDataProviderChanged(DataField instance, DataProvider oldValue)
			{
				((ICollection<DataField>)instance.DataProvider.DataFieldViaDataProviderCollection).Add(instance);
				if ((object)oldValue != null)
				{
					((ICollection<DataField>)oldValue.DataFieldViaDataProviderCollection).Remove(instance);
				}
			}
			private bool OnDataFieldIndustryChanging(DataField instance, Industry newValue)
			{
				if ((object)this != (object)newValue.Context)
				{
					throw PackageBuilderContext.GetDifferentContextsException();
				}
				return true;
			}
			private void OnDataFieldIndustryChanged(DataField instance, Industry oldValue)
			{
				((ICollection<DataField>)instance.Industry.DataFieldViaIndustryCollection).Add(instance);
				if ((object)oldValue != null)
				{
					((ICollection<DataField>)oldValue.DataFieldViaIndustryCollection).Remove(instance);
				}
			}
			private bool OnDataFieldPackageDataFieldViaDataFieldCollectionAdding(DataField instance, PackageDataField item)
			{
				if ((object)this != (object)item.Context)
				{
					throw PackageBuilderContext.GetDifferentContextsException("item");
				}
				return true;
			}
			private void OnDataFieldPackageDataFieldViaDataFieldCollectionAdded(DataField instance, PackageDataField item)
			{
				item.DataField = instance;
			}
			private void OnDataFieldPackageDataFieldViaDataFieldCollectionRemoved(DataField instance, PackageDataField item)
			{
				if ((object)item.DataField == (object)instance)
				{
					item.DataField = null;
				}
			}
			private readonly List<DataField> _DataFieldList;
			private readonly ReadOnlyCollection<DataField> _DataFieldReadOnlyCollection;
			public IEnumerable<DataField> DataFieldCollection
			{
				get
				{
					return this._DataFieldReadOnlyCollection;
				}
			}
			#region DataFieldCore
			[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto, CharSet=System.Runtime.InteropServices.CharSet.Auto)]
			private sealed class DataFieldCore : DataField
			{
				public DataFieldCore(PackageBuilderContext context, bool Selected, decimal CostOfSale, string Name, DataProvider DataProvider, Industry Industry)
				{
					this._Context = context;
					this._PackageDataFieldViaDataFieldCollection = new ConstraintEnforcementCollection<DataField, PackageDataField>(this);
					this._Selected = Selected;
					this._CostOfSale = CostOfSale;
					this._Name = Name;
					context.OnDataFieldNameChanged(this, null);
					this._DataProvider = DataProvider;
					context.OnDataFieldDataProviderChanged(this, null);
					this._Industry = Industry;
					context.OnDataFieldIndustryChanged(this, null);
					context._DataFieldList.Add(this);
				}
				private readonly PackageBuilderContext _Context;
				public sealed override PackageBuilderContext Context
				{
					get
					{
						return this._Context;
					}
				}
				private string _Label;
				public sealed override string Label
				{
					get
					{
						return this._Label;
					}
					set
					{
						string oldValue = this._Label;
						if (!object.Equals(oldValue, value))
						{
							if (this._Context.OnDataFieldLabelChanging(this, value) && base.OnLabelChanging(value))
							{
								this._Label = value;
								base.OnLabelChanged(oldValue);
							}
						}
					}
				}
				private string _TypeDefinition;
				public sealed override string TypeDefinition
				{
					get
					{
						return this._TypeDefinition;
					}
					set
					{
						string oldValue = this._TypeDefinition;
						if (!object.Equals(oldValue, value))
						{
							if (this._Context.OnDataFieldTypeDefinitionChanging(this, value) && base.OnTypeDefinitionChanging(value))
							{
								this._TypeDefinition = value;
								base.OnTypeDefinitionChanged(oldValue);
							}
						}
					}
				}
				private bool _Selected;
				public sealed override bool Selected
				{
					get
					{
						return this._Selected;
					}
					set
					{
						bool oldValue = this._Selected;
						if (oldValue != value)
						{
							if (this._Context.OnDataFieldSelectedChanging(this, value) && base.OnSelectedChanging(value))
							{
								this._Selected = value;
								base.OnSelectedChanged(oldValue);
							}
						}
					}
				}
				private decimal _CostOfSale;
				public sealed override decimal CostOfSale
				{
					get
					{
						return this._CostOfSale;
					}
					set
					{
						decimal oldValue = this._CostOfSale;
						if (oldValue != value)
						{
							if (this._Context.OnDataFieldCostOfSaleChanging(this, value) && base.OnCostOfSaleChanging(value))
							{
								this._CostOfSale = value;
								base.OnCostOfSaleChanged(oldValue);
							}
						}
					}
				}
				private string _Name;
				public sealed override string Name
				{
					get
					{
						return this._Name;
					}
					set
					{
						if ((object)value == null)
						{
							throw new ArgumentNullException("value");
						}
						string oldValue = this._Name;
						if ((object)oldValue != (object)value && !value.Equals(oldValue))
						{
							if (this._Context.OnDataFieldNameChanging(this, value) && base.OnNameChanging(value))
							{
								this._Name = value;
								this._Context.OnDataFieldNameChanged(this, oldValue);
								base.OnNameChanged(oldValue);
							}
						}
					}
				}
				private DataProvider _DataProvider;
				public sealed override DataProvider DataProvider
				{
					get
					{
						return this._DataProvider;
					}
					set
					{
						if ((object)value == null)
						{
							throw new ArgumentNullException("value");
						}
						DataProvider oldValue = this._DataProvider;
						if ((object)oldValue != (object)value)
						{
							if (this._Context.OnDataFieldDataProviderChanging(this, value) && base.OnDataProviderChanging(value))
							{
								this._DataProvider = value;
								this._Context.OnDataFieldDataProviderChanged(this, oldValue);
								base.OnDataProviderChanged(oldValue);
							}
						}
					}
				}
				private Industry _Industry;
				public sealed override Industry Industry
				{
					get
					{
						return this._Industry;
					}
					set
					{
						if ((object)value == null)
						{
							throw new ArgumentNullException("value");
						}
						Industry oldValue = this._Industry;
						if ((object)oldValue != (object)value)
						{
							if (this._Context.OnDataFieldIndustryChanging(this, value) && base.OnIndustryChanging(value))
							{
								this._Industry = value;
								this._Context.OnDataFieldIndustryChanged(this, oldValue);
								base.OnIndustryChanged(oldValue);
							}
						}
					}
				}
				private readonly IEnumerable<PackageDataField> _PackageDataFieldViaDataFieldCollection;
				public sealed override IEnumerable<PackageDataField> PackageDataFieldViaDataFieldCollection
				{
					get
					{
						return this._PackageDataFieldViaDataFieldCollection;
					}
				}
			}
			#endregion // DataFieldCore
			#endregion // DataField
			#region PackageDataField
			public PackageDataField CreatePackageDataField(int Priority, string UnifiedName, bool Selected, Package Package, DataField DataField)
			{
				if ((object)UnifiedName == null)
				{
					throw new ArgumentNullException("UnifiedName");
				}
				if ((object)Package == null)
				{
					throw new ArgumentNullException("Package");
				}
				if ((object)DataField == null)
				{
					throw new ArgumentNullException("DataField");
				}
				if (!this.OnPackageDataFieldPriorityChanging(null, Priority))
				{
					throw PackageBuilderContext.GetConstraintEnforcementFailedException("Priority");
				}
				if (!this.OnPackageDataFieldUnifiedNameChanging(null, UnifiedName))
				{
					throw PackageBuilderContext.GetConstraintEnforcementFailedException("UnifiedName");
				}
				if (!this.OnPackageDataFieldSelectedChanging(null, Selected))
				{
					throw PackageBuilderContext.GetConstraintEnforcementFailedException("Selected");
				}
				if (!this.OnPackageDataFieldPackageChanging(null, Package))
				{
					throw PackageBuilderContext.GetConstraintEnforcementFailedException("Package");
				}
				if (!this.OnPackageDataFieldDataFieldChanging(null, DataField))
				{
					throw PackageBuilderContext.GetConstraintEnforcementFailedException("DataField");
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
			private bool OnPackageDataFieldPackageChanging(PackageDataField instance, Package newValue)
			{
				if ((object)this != (object)newValue.Context)
				{
					throw PackageBuilderContext.GetDifferentContextsException();
				}
				return true;
			}
			private void OnPackageDataFieldPackageChanged(PackageDataField instance, Package oldValue)
			{
				((ICollection<PackageDataField>)instance.Package.PackageDataFieldViaPackageCollection).Add(instance);
				if ((object)oldValue != null)
				{
					((ICollection<PackageDataField>)oldValue.PackageDataFieldViaPackageCollection).Remove(instance);
				}
			}
			private bool OnPackageDataFieldDataFieldChanging(PackageDataField instance, DataField newValue)
			{
				if ((object)this != (object)newValue.Context)
				{
					throw PackageBuilderContext.GetDifferentContextsException();
				}
				return true;
			}
			private void OnPackageDataFieldDataFieldChanged(PackageDataField instance, DataField oldValue)
			{
				((ICollection<PackageDataField>)instance.DataField.PackageDataFieldViaDataFieldCollection).Add(instance);
				if ((object)oldValue != null)
				{
					((ICollection<PackageDataField>)oldValue.PackageDataFieldViaDataFieldCollection).Remove(instance);
				}
			}
			private readonly List<PackageDataField> _PackageDataFieldList;
			private readonly ReadOnlyCollection<PackageDataField> _PackageDataFieldReadOnlyCollection;
			public IEnumerable<PackageDataField> PackageDataFieldCollection
			{
				get
				{
					return this._PackageDataFieldReadOnlyCollection;
				}
			}
			#region PackageDataFieldCore
			[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto, CharSet=System.Runtime.InteropServices.CharSet.Auto)]
			private sealed class PackageDataFieldCore : PackageDataField
			{
				public PackageDataFieldCore(PackageBuilderContext context, int Priority, string UnifiedName, bool Selected, Package Package, DataField DataField)
				{
					this._Context = context;
					this._Priority = Priority;
					this._UnifiedName = UnifiedName;
					this._Selected = Selected;
					this._Package = Package;
					context.OnPackageDataFieldPackageChanged(this, null);
					this._DataField = DataField;
					context.OnPackageDataFieldDataFieldChanged(this, null);
					context._PackageDataFieldList.Add(this);
				}
				private readonly PackageBuilderContext _Context;
				public sealed override PackageBuilderContext Context
				{
					get
					{
						return this._Context;
					}
				}
				private int _Priority;
				public sealed override int Priority
				{
					get
					{
						return this._Priority;
					}
					set
					{
						int oldValue = this._Priority;
						if (oldValue != value)
						{
							if (this._Context.OnPackageDataFieldPriorityChanging(this, value) && base.OnPriorityChanging(value))
							{
								this._Priority = value;
								base.OnPriorityChanged(oldValue);
							}
						}
					}
				}
				private string _UnifiedName;
				public sealed override string UnifiedName
				{
					get
					{
						return this._UnifiedName;
					}
					set
					{
						if ((object)value == null)
						{
							throw new ArgumentNullException("value");
						}
						string oldValue = this._UnifiedName;
						if ((object)oldValue != (object)value && !value.Equals(oldValue))
						{
							if (this._Context.OnPackageDataFieldUnifiedNameChanging(this, value) && base.OnUnifiedNameChanging(value))
							{
								this._UnifiedName = value;
								base.OnUnifiedNameChanged(oldValue);
							}
						}
					}
				}
				private bool _Selected;
				public sealed override bool Selected
				{
					get
					{
						return this._Selected;
					}
					set
					{
						bool oldValue = this._Selected;
						if (oldValue != value)
						{
							if (this._Context.OnPackageDataFieldSelectedChanging(this, value) && base.OnSelectedChanging(value))
							{
								this._Selected = value;
								base.OnSelectedChanged(oldValue);
							}
						}
					}
				}
				private Package _Package;
				public sealed override Package Package
				{
					get
					{
						return this._Package;
					}
					set
					{
						if ((object)value == null)
						{
							throw new ArgumentNullException("value");
						}
						Package oldValue = this._Package;
						if ((object)oldValue != (object)value)
						{
							if (this._Context.OnPackageDataFieldPackageChanging(this, value) && base.OnPackageChanging(value))
							{
								this._Package = value;
								this._Context.OnPackageDataFieldPackageChanged(this, oldValue);
								base.OnPackageChanged(oldValue);
							}
						}
					}
				}
				private DataField _DataField;
				public sealed override DataField DataField
				{
					get
					{
						return this._DataField;
					}
					set
					{
						if ((object)value == null)
						{
							throw new ArgumentNullException("value");
						}
						DataField oldValue = this._DataField;
						if ((object)oldValue != (object)value)
						{
							if (this._Context.OnPackageDataFieldDataFieldChanging(this, value) && base.OnDataFieldChanging(value))
							{
								this._DataField = value;
								this._Context.OnPackageDataFieldDataFieldChanged(this, oldValue);
								base.OnDataFieldChanged(oldValue);
							}
						}
					}
				}
			}
			#endregion // PackageDataFieldCore
			#endregion // PackageDataField
			#region Industry
			public Industry CreateIndustry(string Value)
			{
				if ((object)Value == null)
				{
					throw new ArgumentNullException("Value");
				}
				if (!this.OnIndustryValueChanging(null, Value))
				{
					throw PackageBuilderContext.GetConstraintEnforcementFailedException("Value");
				}
				return new IndustryCore(this, Value);
			}
			private bool OnIndustryValueChanging(Industry instance, string newValue)
			{
				return true;
			}
			private bool OnIndustryPackageViaIndustryCollectionAdding(Industry instance, Package item)
			{
				if ((object)this != (object)item.Context)
				{
					throw PackageBuilderContext.GetDifferentContextsException("item");
				}
				return true;
			}
			private void OnIndustryPackageViaIndustryCollectionAdded(Industry instance, Package item)
			{
				item.Industry = instance;
			}
			private void OnIndustryPackageViaIndustryCollectionRemoved(Industry instance, Package item)
			{
				if ((object)item.Industry == (object)instance)
				{
					item.Industry = null;
				}
			}
			private bool OnIndustryDataFieldViaIndustryCollectionAdding(Industry instance, DataField item)
			{
				if ((object)this != (object)item.Context)
				{
					throw PackageBuilderContext.GetDifferentContextsException("item");
				}
				return true;
			}
			private void OnIndustryDataFieldViaIndustryCollectionAdded(Industry instance, DataField item)
			{
				item.Industry = instance;
			}
			private void OnIndustryDataFieldViaIndustryCollectionRemoved(Industry instance, DataField item)
			{
				if ((object)item.Industry == (object)instance)
				{
					item.Industry = null;
				}
			}
			private readonly List<Industry> _IndustryList;
			private readonly ReadOnlyCollection<Industry> _IndustryReadOnlyCollection;
			public IEnumerable<Industry> IndustryCollection
			{
				get
				{
					return this._IndustryReadOnlyCollection;
				}
			}
			#region IndustryCore
			[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto, CharSet=System.Runtime.InteropServices.CharSet.Auto)]
			private sealed class IndustryCore : Industry
			{
				public IndustryCore(PackageBuilderContext context, string Value)
				{
					this._Context = context;
					this._PackageViaIndustryCollection = new ConstraintEnforcementCollection<Industry, Package>(this);
					this._DataFieldViaIndustryCollection = new ConstraintEnforcementCollection<Industry, DataField>(this);
					this._Value = Value;
					context._IndustryList.Add(this);
				}
				private readonly PackageBuilderContext _Context;
				public sealed override PackageBuilderContext Context
				{
					get
					{
						return this._Context;
					}
				}
				private string _Value;
				public sealed override string Value
				{
					get
					{
						return this._Value;
					}
					set
					{
						if ((object)value == null)
						{
							throw new ArgumentNullException("value");
						}
						string oldValue = this._Value;
						if ((object)oldValue != (object)value && !value.Equals(oldValue))
						{
							if (this._Context.OnIndustryValueChanging(this, value) && base.OnValueChanging(value))
							{
								this._Value = value;
								base.OnValueChanged(oldValue);
							}
						}
					}
				}
				private readonly IEnumerable<Package> _PackageViaIndustryCollection;
				public sealed override IEnumerable<Package> PackageViaIndustryCollection
				{
					get
					{
						return this._PackageViaIndustryCollection;
					}
				}
				private readonly IEnumerable<DataField> _DataFieldViaIndustryCollection;
				public sealed override IEnumerable<DataField> DataFieldViaIndustryCollection
				{
					get
					{
						return this._DataFieldViaIndustryCollection;
					}
				}
			}
			#endregion // IndustryCore
			#endregion // Industry
		}
		#endregion // PackageBuilderContext
	}
}
