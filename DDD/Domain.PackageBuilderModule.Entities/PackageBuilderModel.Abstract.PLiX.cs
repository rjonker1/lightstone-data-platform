using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Xml;
namespace LightstoneApp.Domain.PackageBuilderModule.Context
{
	namespace PackageBuilder
	{
		#region Package
		[DataObject()]
		[System.CodeDom.Compiler.GeneratedCode("OIALtoPLiX", "1.0")]
		[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto, CharSet=System.Runtime.InteropServices.CharSet.Auto)]
		public abstract partial class Package : INotifyPropertyChanged, IHasPackageBuilderContext
		{
			protected Package()
			{
			}
			#region Package INotifyPropertyChanged Implementation
			private PropertyChangedEventHandler _propertyChangedEventHandler;
			[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
			event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
			{
				add
				{
					if ((object)value != null)
					{
						PropertyChangedEventHandler currentHandler;
						while ((object)System.Threading.Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this._propertyChangedEventHandler, (PropertyChangedEventHandler)System.Delegate.Combine(currentHandler = this._propertyChangedEventHandler, value), currentHandler) != (object)currentHandler)
						{
						}
					}
				}
				remove
				{
					if ((object)value != null)
					{
						PropertyChangedEventHandler currentHandler;
						while ((object)System.Threading.Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this._propertyChangedEventHandler, (PropertyChangedEventHandler)System.Delegate.Remove(currentHandler = this._propertyChangedEventHandler, value), currentHandler) != (object)currentHandler)
						{
						}
					}
				}
			}
			private void OnPropertyChanged(string propertyName)
			{
				PropertyChangedEventHandler eventHandler;
				if ((object)(eventHandler = this._propertyChangedEventHandler) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this, new PropertyChangedEventArgs(propertyName));
				}
			}
			#endregion // Package INotifyPropertyChanged Implementation
			#region Package Property Change Events
			private System.Delegate[] _events;
			private System.Delegate[] Events
			{
				get
				{
					System.Delegate[] localEvents;
					return (localEvents = this._events) ?? System.Threading.Interlocked.CompareExchange<System.Delegate[]>(ref this._events, localEvents = new System.Delegate[24], null) ?? localEvents;
				}
			}
			private static void InterlockedDelegateCombine(ref System.Delegate location, System.Delegate value)
			{
				System.Delegate currentHandler;
				while ((object)System.Threading.Interlocked.CompareExchange<System.Delegate>(ref location, System.Delegate.Combine(currentHandler = location, value), currentHandler) != (object)currentHandler)
				{
				}
			}
			private static void InterlockedDelegateRemove(ref System.Delegate location, System.Delegate value)
			{
				System.Delegate currentHandler;
				while ((object)System.Threading.Interlocked.CompareExchange<System.Delegate>(ref location, System.Delegate.Remove(currentHandler = location, value), currentHandler) != (object)currentHandler)
				{
				}
			}
			public event EventHandler<PropertyChangingEventArgs<Package, string>> NameChanging
			{
				add
				{
					if ((object)value != null)
					{
						Package.InterlockedDelegateCombine(ref this.Events[0], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						Package.InterlockedDelegateRemove(ref events[0], value);
					}
				}
			}
			protected bool OnNameChanging(string newValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangingEventArgs<Package, string>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<Package, string>>)events[0]) != null)
				{
					return EventHandlerUtility.InvokeCancelableEventHandler<PropertyChangingEventArgs<Package, string>>(eventHandler, this, new PropertyChangingEventArgs<Package, string>(this, "Name", this.Name, newValue));
				}
				return true;
			}
			public event EventHandler<PropertyChangedEventArgs<Package, string>> NameChanged
			{
				add
				{
					if ((object)value != null)
					{
						Package.InterlockedDelegateCombine(ref this.Events[1], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						Package.InterlockedDelegateRemove(ref events[1], value);
					}
				}
			}
			protected void OnNameChanged(string oldValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangedEventArgs<Package, string>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<Package, string>>)events[1]) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync<PropertyChangedEventArgs<Package, string>>(eventHandler, this, new PropertyChangedEventArgs<Package, string>(this, "Name", oldValue, this.Name), this._propertyChangedEventHandler);
				}
				else
				{
					this.OnPropertyChanged("Name");
				}
			}
			public event EventHandler<PropertyChangingEventArgs<Package, string>> DescriptionChanging
			{
				add
				{
					if ((object)value != null)
					{
						Package.InterlockedDelegateCombine(ref this.Events[2], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						Package.InterlockedDelegateRemove(ref events[2], value);
					}
				}
			}
			protected bool OnDescriptionChanging(string newValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangingEventArgs<Package, string>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<Package, string>>)events[2]) != null)
				{
					return EventHandlerUtility.InvokeCancelableEventHandler<PropertyChangingEventArgs<Package, string>>(eventHandler, this, new PropertyChangingEventArgs<Package, string>(this, "Description", this.Description, newValue));
				}
				return true;
			}
			public event EventHandler<PropertyChangedEventArgs<Package, string>> DescriptionChanged
			{
				add
				{
					if ((object)value != null)
					{
						Package.InterlockedDelegateCombine(ref this.Events[3], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						Package.InterlockedDelegateRemove(ref events[3], value);
					}
				}
			}
			protected void OnDescriptionChanged(string oldValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangedEventArgs<Package, string>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<Package, string>>)events[3]) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync<PropertyChangedEventArgs<Package, string>>(eventHandler, this, new PropertyChangedEventArgs<Package, string>(this, "Description", oldValue, this.Description), this._propertyChangedEventHandler);
				}
				else
				{
					this.OnPropertyChanged("Description");
				}
			}
			public event EventHandler<PropertyChangingEventArgs<Package, string>> OwnerChanging
			{
				add
				{
					if ((object)value != null)
					{
						Package.InterlockedDelegateCombine(ref this.Events[4], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						Package.InterlockedDelegateRemove(ref events[4], value);
					}
				}
			}
			protected bool OnOwnerChanging(string newValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangingEventArgs<Package, string>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<Package, string>>)events[4]) != null)
				{
					return EventHandlerUtility.InvokeCancelableEventHandler<PropertyChangingEventArgs<Package, string>>(eventHandler, this, new PropertyChangingEventArgs<Package, string>(this, "Owner", this.Owner, newValue));
				}
				return true;
			}
			public event EventHandler<PropertyChangedEventArgs<Package, string>> OwnerChanged
			{
				add
				{
					if ((object)value != null)
					{
						Package.InterlockedDelegateCombine(ref this.Events[5], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						Package.InterlockedDelegateRemove(ref events[5], value);
					}
				}
			}
			protected void OnOwnerChanged(string oldValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangedEventArgs<Package, string>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<Package, string>>)events[5]) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync<PropertyChangedEventArgs<Package, string>>(eventHandler, this, new PropertyChangedEventArgs<Package, string>(this, "Owner", oldValue, this.Owner), this._propertyChangedEventHandler);
				}
				else
				{
					this.OnPropertyChanged("Owner");
				}
			}
			public event EventHandler<PropertyChangingEventArgs<Package, Nullable<int>>> CreatedChanging
			{
				add
				{
					if ((object)value != null)
					{
						Package.InterlockedDelegateCombine(ref this.Events[6], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						Package.InterlockedDelegateRemove(ref events[6], value);
					}
				}
			}
			protected bool OnCreatedChanging(Nullable<int> newValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangingEventArgs<Package, Nullable<int>>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<Package, Nullable<int>>>)events[6]) != null)
				{
					return EventHandlerUtility.InvokeCancelableEventHandler<PropertyChangingEventArgs<Package, Nullable<int>>>(eventHandler, this, new PropertyChangingEventArgs<Package, Nullable<int>>(this, "Created", this.Created, newValue));
				}
				return true;
			}
			public event EventHandler<PropertyChangedEventArgs<Package, Nullable<int>>> CreatedChanged
			{
				add
				{
					if ((object)value != null)
					{
						Package.InterlockedDelegateCombine(ref this.Events[7], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						Package.InterlockedDelegateRemove(ref events[7], value);
					}
				}
			}
			protected void OnCreatedChanged(Nullable<int> oldValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangedEventArgs<Package, Nullable<int>>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<Package, Nullable<int>>>)events[7]) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync<PropertyChangedEventArgs<Package, Nullable<int>>>(eventHandler, this, new PropertyChangedEventArgs<Package, Nullable<int>>(this, "Created", oldValue, this.Created), this._propertyChangedEventHandler);
				}
				else
				{
					this.OnPropertyChanged("Created");
				}
			}
			public event EventHandler<PropertyChangingEventArgs<Package, Nullable<int>>> EditedChanging
			{
				add
				{
					if ((object)value != null)
					{
						Package.InterlockedDelegateCombine(ref this.Events[8], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						Package.InterlockedDelegateRemove(ref events[8], value);
					}
				}
			}
			protected bool OnEditedChanging(Nullable<int> newValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangingEventArgs<Package, Nullable<int>>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<Package, Nullable<int>>>)events[8]) != null)
				{
					return EventHandlerUtility.InvokeCancelableEventHandler<PropertyChangingEventArgs<Package, Nullable<int>>>(eventHandler, this, new PropertyChangingEventArgs<Package, Nullable<int>>(this, "Edited", this.Edited, newValue));
				}
				return true;
			}
			public event EventHandler<PropertyChangedEventArgs<Package, Nullable<int>>> EditedChanged
			{
				add
				{
					if ((object)value != null)
					{
						Package.InterlockedDelegateCombine(ref this.Events[9], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						Package.InterlockedDelegateRemove(ref events[9], value);
					}
				}
			}
			protected void OnEditedChanged(Nullable<int> oldValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangedEventArgs<Package, Nullable<int>>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<Package, Nullable<int>>>)events[9]) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync<PropertyChangedEventArgs<Package, Nullable<int>>>(eventHandler, this, new PropertyChangedEventArgs<Package, Nullable<int>>(this, "Edited", oldValue, this.Edited), this._propertyChangedEventHandler);
				}
				else
				{
					this.OnPropertyChanged("Edited");
				}
			}
			public event EventHandler<PropertyChangingEventArgs<Package, string>> VersionChanging
			{
				add
				{
					if ((object)value != null)
					{
						Package.InterlockedDelegateCombine(ref this.Events[10], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						Package.InterlockedDelegateRemove(ref events[10], value);
					}
				}
			}
			protected bool OnVersionChanging(string newValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangingEventArgs<Package, string>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<Package, string>>)events[10]) != null)
				{
					return EventHandlerUtility.InvokeCancelableEventHandler<PropertyChangingEventArgs<Package, string>>(eventHandler, this, new PropertyChangingEventArgs<Package, string>(this, "Version", this.Version, newValue));
				}
				return true;
			}
			public event EventHandler<PropertyChangedEventArgs<Package, string>> VersionChanged
			{
				add
				{
					if ((object)value != null)
					{
						Package.InterlockedDelegateCombine(ref this.Events[11], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						Package.InterlockedDelegateRemove(ref events[11], value);
					}
				}
			}
			protected void OnVersionChanged(string oldValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangedEventArgs<Package, string>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<Package, string>>)events[11]) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync<PropertyChangedEventArgs<Package, string>>(eventHandler, this, new PropertyChangedEventArgs<Package, string>(this, "Version", oldValue, this.Version), this._propertyChangedEventHandler);
				}
				else
				{
					this.OnPropertyChanged("Version");
				}
			}
			public event EventHandler<PropertyChangingEventArgs<Package, Nullable<bool>>> PublishedChanging
			{
				add
				{
					if ((object)value != null)
					{
						Package.InterlockedDelegateCombine(ref this.Events[12], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						Package.InterlockedDelegateRemove(ref events[12], value);
					}
				}
			}
			protected bool OnPublishedChanging(Nullable<bool> newValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangingEventArgs<Package, Nullable<bool>>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<Package, Nullable<bool>>>)events[12]) != null)
				{
					return EventHandlerUtility.InvokeCancelableEventHandler<PropertyChangingEventArgs<Package, Nullable<bool>>>(eventHandler, this, new PropertyChangingEventArgs<Package, Nullable<bool>>(this, "Published", this.Published, newValue));
				}
				return true;
			}
			public event EventHandler<PropertyChangedEventArgs<Package, Nullable<bool>>> PublishedChanged
			{
				add
				{
					if ((object)value != null)
					{
						Package.InterlockedDelegateCombine(ref this.Events[13], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						Package.InterlockedDelegateRemove(ref events[13], value);
					}
				}
			}
			protected void OnPublishedChanged(Nullable<bool> oldValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangedEventArgs<Package, Nullable<bool>>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<Package, Nullable<bool>>>)events[13]) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync<PropertyChangedEventArgs<Package, Nullable<bool>>>(eventHandler, this, new PropertyChangedEventArgs<Package, Nullable<bool>>(this, "Published", oldValue, this.Published), this._propertyChangedEventHandler);
				}
				else
				{
					this.OnPropertyChanged("Published");
				}
			}
			public event EventHandler<PropertyChangingEventArgs<Package, Nullable<int>>> RevisionDateChanging
			{
				add
				{
					if ((object)value != null)
					{
						Package.InterlockedDelegateCombine(ref this.Events[14], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						Package.InterlockedDelegateRemove(ref events[14], value);
					}
				}
			}
			protected bool OnRevisionDateChanging(Nullable<int> newValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangingEventArgs<Package, Nullable<int>>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<Package, Nullable<int>>>)events[14]) != null)
				{
					return EventHandlerUtility.InvokeCancelableEventHandler<PropertyChangingEventArgs<Package, Nullable<int>>>(eventHandler, this, new PropertyChangingEventArgs<Package, Nullable<int>>(this, "RevisionDate", this.RevisionDate, newValue));
				}
				return true;
			}
			public event EventHandler<PropertyChangedEventArgs<Package, Nullable<int>>> RevisionDateChanged
			{
				add
				{
					if ((object)value != null)
					{
						Package.InterlockedDelegateCombine(ref this.Events[15], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						Package.InterlockedDelegateRemove(ref events[15], value);
					}
				}
			}
			protected void OnRevisionDateChanged(Nullable<int> oldValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangedEventArgs<Package, Nullable<int>>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<Package, Nullable<int>>>)events[15]) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync<PropertyChangedEventArgs<Package, Nullable<int>>>(eventHandler, this, new PropertyChangedEventArgs<Package, Nullable<int>>(this, "RevisionDate", oldValue, this.RevisionDate), this._propertyChangedEventHandler);
				}
				else
				{
					this.OnPropertyChanged("RevisionDate");
				}
			}
			public event EventHandler<PropertyChangingEventArgs<Package, Nullable<decimal>>> CostOfSaleChanging
			{
				add
				{
					if ((object)value != null)
					{
						Package.InterlockedDelegateCombine(ref this.Events[16], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						Package.InterlockedDelegateRemove(ref events[16], value);
					}
				}
			}
			protected bool OnCostOfSaleChanging(Nullable<decimal> newValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangingEventArgs<Package, Nullable<decimal>>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<Package, Nullable<decimal>>>)events[16]) != null)
				{
					return EventHandlerUtility.InvokeCancelableEventHandler<PropertyChangingEventArgs<Package, Nullable<decimal>>>(eventHandler, this, new PropertyChangingEventArgs<Package, Nullable<decimal>>(this, "CostOfSale", this.CostOfSale, newValue));
				}
				return true;
			}
			public event EventHandler<PropertyChangedEventArgs<Package, Nullable<decimal>>> CostOfSaleChanged
			{
				add
				{
					if ((object)value != null)
					{
						Package.InterlockedDelegateCombine(ref this.Events[17], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						Package.InterlockedDelegateRemove(ref events[17], value);
					}
				}
			}
			protected void OnCostOfSaleChanged(Nullable<decimal> oldValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangedEventArgs<Package, Nullable<decimal>>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<Package, Nullable<decimal>>>)events[17]) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync<PropertyChangedEventArgs<Package, Nullable<decimal>>>(eventHandler, this, new PropertyChangedEventArgs<Package, Nullable<decimal>>(this, "CostOfSale", oldValue, this.CostOfSale), this._propertyChangedEventHandler);
				}
				else
				{
					this.OnPropertyChanged("CostOfSale");
				}
			}
			public event EventHandler<PropertyChangingEventArgs<Package, Nullable<decimal>>> RecomendedRetailPriceChanging
			{
				add
				{
					if ((object)value != null)
					{
						Package.InterlockedDelegateCombine(ref this.Events[18], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						Package.InterlockedDelegateRemove(ref events[18], value);
					}
				}
			}
			protected bool OnRecomendedRetailPriceChanging(Nullable<decimal> newValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangingEventArgs<Package, Nullable<decimal>>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<Package, Nullable<decimal>>>)events[18]) != null)
				{
					return EventHandlerUtility.InvokeCancelableEventHandler<PropertyChangingEventArgs<Package, Nullable<decimal>>>(eventHandler, this, new PropertyChangingEventArgs<Package, Nullable<decimal>>(this, "RecomendedRetailPrice", this.RecomendedRetailPrice, newValue));
				}
				return true;
			}
			public event EventHandler<PropertyChangedEventArgs<Package, Nullable<decimal>>> RecomendedRetailPriceChanged
			{
				add
				{
					if ((object)value != null)
					{
						Package.InterlockedDelegateCombine(ref this.Events[19], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						Package.InterlockedDelegateRemove(ref events[19], value);
					}
				}
			}
			protected void OnRecomendedRetailPriceChanged(Nullable<decimal> oldValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangedEventArgs<Package, Nullable<decimal>>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<Package, Nullable<decimal>>>)events[19]) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync<PropertyChangedEventArgs<Package, Nullable<decimal>>>(eventHandler, this, new PropertyChangedEventArgs<Package, Nullable<decimal>>(this, "RecomendedRetailPrice", oldValue, this.RecomendedRetailPrice), this._propertyChangedEventHandler);
				}
				else
				{
					this.OnPropertyChanged("RecomendedRetailPrice");
				}
			}
			public event EventHandler<PropertyChangingEventArgs<Package, State>> StateChanging
			{
				add
				{
					if ((object)value != null)
					{
						Package.InterlockedDelegateCombine(ref this.Events[20], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						Package.InterlockedDelegateRemove(ref events[20], value);
					}
				}
			}
			protected bool OnStateChanging(State newValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangingEventArgs<Package, State>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<Package, State>>)events[20]) != null)
				{
					return EventHandlerUtility.InvokeCancelableEventHandler<PropertyChangingEventArgs<Package, State>>(eventHandler, this, new PropertyChangingEventArgs<Package, State>(this, "State", this.State, newValue));
				}
				return true;
			}
			public event EventHandler<PropertyChangedEventArgs<Package, State>> StateChanged
			{
				add
				{
					if ((object)value != null)
					{
						Package.InterlockedDelegateCombine(ref this.Events[21], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						Package.InterlockedDelegateRemove(ref events[21], value);
					}
				}
			}
			protected void OnStateChanged(State oldValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangedEventArgs<Package, State>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<Package, State>>)events[21]) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync<PropertyChangedEventArgs<Package, State>>(eventHandler, this, new PropertyChangedEventArgs<Package, State>(this, "State", oldValue, this.State), this._propertyChangedEventHandler);
				}
				else
				{
					this.OnPropertyChanged("State");
				}
			}
			public event EventHandler<PropertyChangingEventArgs<Package, Industry>> IndustryChanging
			{
				add
				{
					if ((object)value != null)
					{
						Package.InterlockedDelegateCombine(ref this.Events[22], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						Package.InterlockedDelegateRemove(ref events[22], value);
					}
				}
			}
			protected bool OnIndustryChanging(Industry newValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangingEventArgs<Package, Industry>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<Package, Industry>>)events[22]) != null)
				{
					return EventHandlerUtility.InvokeCancelableEventHandler<PropertyChangingEventArgs<Package, Industry>>(eventHandler, this, new PropertyChangingEventArgs<Package, Industry>(this, "Industry", this.Industry, newValue));
				}
				return true;
			}
			public event EventHandler<PropertyChangedEventArgs<Package, Industry>> IndustryChanged
			{
				add
				{
					if ((object)value != null)
					{
						Package.InterlockedDelegateCombine(ref this.Events[23], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						Package.InterlockedDelegateRemove(ref events[23], value);
					}
				}
			}
			protected void OnIndustryChanged(Industry oldValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangedEventArgs<Package, Industry>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<Package, Industry>>)events[23]) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync<PropertyChangedEventArgs<Package, Industry>>(eventHandler, this, new PropertyChangedEventArgs<Package, Industry>(this, "Industry", oldValue, this.Industry), this._propertyChangedEventHandler);
				}
				else
				{
					this.OnPropertyChanged("Industry");
				}
			}
			#endregion // Package Property Change Events
			#region Package Abstract Properties
			public abstract PackageBuilderContext Context
			{
				get;
			}
			[DataObjectField(false, false, false)]
			public abstract string Name
			{
				get;
				set;
			}
			[DataObjectField(false, false, false)]
			public abstract string Description
			{
				get;
				set;
			}
			[DataObjectField(false, false, true)]
			public abstract string Owner
			{
				get;
				set;
			}
			[DataObjectField(false, false, true)]
			public abstract Nullable<int> Created
			{
				get;
				set;
			}
			[DataObjectField(false, false, true)]
			public abstract Nullable<int> Edited
			{
				get;
				set;
			}
			[DataObjectField(false, false, false)]
			public abstract string Version
			{
				get;
				set;
			}
			[DataObjectField(false, false, true)]
			public abstract Nullable<bool> Published
			{
				get;
				set;
			}
			[DataObjectField(false, false, true)]
			public abstract Nullable<int> RevisionDate
			{
				get;
				set;
			}
			[DataObjectField(false, false, true)]
			public abstract Nullable<decimal> CostOfSale
			{
				get;
				set;
			}
			[DataObjectField(false, false, true)]
			public abstract Nullable<decimal> RecomendedRetailPrice
			{
				get;
				set;
			}
			[DataObjectField(false, false, false)]
			public abstract State State
			{
				get;
				set;
			}
			[DataObjectField(false, false, true)]
			public abstract Industry Industry
			{
				get;
				set;
			}
			[DataObjectField(false, false, true)]
			public abstract IEnumerable<PackageDataField> PackageDataFieldViaPackageCollection
			{
				get;
			}
			#endregion // Package Abstract Properties
			#region Package ToString Methods
			public override string ToString()
			{
				return this.ToString(null);
			}
			public virtual string ToString(IFormatProvider provider)
			{
				return string.Format(provider, @"Package{0}{{{0}{1}Name = ""{2}"",{0}{1}Description = ""{3}"",{0}{1}Owner = ""{4}"",{0}{1}Created = ""{5}"",{0}{1}Edited = ""{6}"",{0}{1}Version = ""{7}"",{0}{1}Published = ""{8}"",{0}{1}RevisionDate = ""{9}"",{0}{1}CostOfSale = ""{10}"",{0}{1}RecomendedRetailPrice = ""{11}"",{0}{1}State = {12},{0}{1}Industry = {13}{0}}}", Environment.NewLine, @"	", this.Name, this.Description, this.Owner, this.Created, this.Edited, this.Version, this.Published, this.RevisionDate, this.CostOfSale, this.RecomendedRetailPrice, "TODO: Recursively call ToString for customTypes...", "TODO: Recursively call ToString for customTypes...");
			}
			#endregion // Package ToString Methods
		}
		#endregion // Package
		#region State
		[DataObject()]
		[System.CodeDom.Compiler.GeneratedCode("OIALtoPLiX", "1.0")]
		[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto, CharSet=System.Runtime.InteropServices.CharSet.Auto)]
		public abstract partial class State : INotifyPropertyChanged, IHasPackageBuilderContext
		{
			protected State()
			{
			}
			#region State INotifyPropertyChanged Implementation
			private PropertyChangedEventHandler _propertyChangedEventHandler;
			[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
			event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
			{
				add
				{
					if ((object)value != null)
					{
						PropertyChangedEventHandler currentHandler;
						while ((object)System.Threading.Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this._propertyChangedEventHandler, (PropertyChangedEventHandler)System.Delegate.Combine(currentHandler = this._propertyChangedEventHandler, value), currentHandler) != (object)currentHandler)
						{
						}
					}
				}
				remove
				{
					if ((object)value != null)
					{
						PropertyChangedEventHandler currentHandler;
						while ((object)System.Threading.Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this._propertyChangedEventHandler, (PropertyChangedEventHandler)System.Delegate.Remove(currentHandler = this._propertyChangedEventHandler, value), currentHandler) != (object)currentHandler)
						{
						}
					}
				}
			}
			private void OnPropertyChanged(string propertyName)
			{
				PropertyChangedEventHandler eventHandler;
				if ((object)(eventHandler = this._propertyChangedEventHandler) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this, new PropertyChangedEventArgs(propertyName));
				}
			}
			#endregion // State INotifyPropertyChanged Implementation
			#region State Property Change Events
			private System.Delegate[] _events;
			private System.Delegate[] Events
			{
				get
				{
					System.Delegate[] localEvents;
					return (localEvents = this._events) ?? System.Threading.Interlocked.CompareExchange<System.Delegate[]>(ref this._events, localEvents = new System.Delegate[2], null) ?? localEvents;
				}
			}
			private static void InterlockedDelegateCombine(ref System.Delegate location, System.Delegate value)
			{
				System.Delegate currentHandler;
				while ((object)System.Threading.Interlocked.CompareExchange<System.Delegate>(ref location, System.Delegate.Combine(currentHandler = location, value), currentHandler) != (object)currentHandler)
				{
				}
			}
			private static void InterlockedDelegateRemove(ref System.Delegate location, System.Delegate value)
			{
				System.Delegate currentHandler;
				while ((object)System.Threading.Interlocked.CompareExchange<System.Delegate>(ref location, System.Delegate.Remove(currentHandler = location, value), currentHandler) != (object)currentHandler)
				{
				}
			}
			public event EventHandler<PropertyChangingEventArgs<State, string>> ValueChanging
			{
				add
				{
					if ((object)value != null)
					{
						State.InterlockedDelegateCombine(ref this.Events[0], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						State.InterlockedDelegateRemove(ref events[0], value);
					}
				}
			}
			protected bool OnValueChanging(string newValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangingEventArgs<State, string>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<State, string>>)events[0]) != null)
				{
					return EventHandlerUtility.InvokeCancelableEventHandler<PropertyChangingEventArgs<State, string>>(eventHandler, this, new PropertyChangingEventArgs<State, string>(this, "Value", this.Value, newValue));
				}
				return true;
			}
			public event EventHandler<PropertyChangedEventArgs<State, string>> ValueChanged
			{
				add
				{
					if ((object)value != null)
					{
						State.InterlockedDelegateCombine(ref this.Events[1], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						State.InterlockedDelegateRemove(ref events[1], value);
					}
				}
			}
			protected void OnValueChanged(string oldValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangedEventArgs<State, string>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<State, string>>)events[1]) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync<PropertyChangedEventArgs<State, string>>(eventHandler, this, new PropertyChangedEventArgs<State, string>(this, "Value", oldValue, this.Value), this._propertyChangedEventHandler);
				}
				else
				{
					this.OnPropertyChanged("Value");
				}
			}
			#endregion // State Property Change Events
			#region State Abstract Properties
			public abstract PackageBuilderContext Context
			{
				get;
			}
			[DataObjectField(false, false, false)]
			public abstract string Value
			{
				get;
				set;
			}
			[DataObjectField(false, false, true)]
			public abstract IEnumerable<Package> PackageViaStateCollection
			{
				get;
			}
			[DataObjectField(false, false, true)]
			public abstract IEnumerable<DataProvider> DataProviderViaStateCollection
			{
				get;
			}
			#endregion // State Abstract Properties
			#region State ToString Methods
			public override string ToString()
			{
				return this.ToString(null);
			}
			public virtual string ToString(IFormatProvider provider)
			{
				return string.Format(provider, @"State{0}{{{0}{1}Value = ""{2}""{0}}}", Environment.NewLine, @"	", this.Value);
			}
			#endregion // State ToString Methods
		}
		#endregion // State
		#region DataProvider
		[DataObject()]
		[System.CodeDom.Compiler.GeneratedCode("OIALtoPLiX", "1.0")]
		[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto, CharSet=System.Runtime.InteropServices.CharSet.Auto)]
		public abstract partial class DataProvider : INotifyPropertyChanged, IHasPackageBuilderContext
		{
			protected DataProvider()
			{
			}
			#region DataProvider INotifyPropertyChanged Implementation
			private PropertyChangedEventHandler _propertyChangedEventHandler;
			[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
			event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
			{
				add
				{
					if ((object)value != null)
					{
						PropertyChangedEventHandler currentHandler;
						while ((object)System.Threading.Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this._propertyChangedEventHandler, (PropertyChangedEventHandler)System.Delegate.Combine(currentHandler = this._propertyChangedEventHandler, value), currentHandler) != (object)currentHandler)
						{
						}
					}
				}
				remove
				{
					if ((object)value != null)
					{
						PropertyChangedEventHandler currentHandler;
						while ((object)System.Threading.Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this._propertyChangedEventHandler, (PropertyChangedEventHandler)System.Delegate.Remove(currentHandler = this._propertyChangedEventHandler, value), currentHandler) != (object)currentHandler)
						{
						}
					}
				}
			}
			private void OnPropertyChanged(string propertyName)
			{
				PropertyChangedEventHandler eventHandler;
				if ((object)(eventHandler = this._propertyChangedEventHandler) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this, new PropertyChangedEventArgs(propertyName));
				}
			}
			#endregion // DataProvider INotifyPropertyChanged Implementation
			#region DataProvider Property Change Events
			private System.Delegate[] _events;
			private System.Delegate[] Events
			{
				get
				{
					System.Delegate[] localEvents;
					return (localEvents = this._events) ?? System.Threading.Interlocked.CompareExchange<System.Delegate[]>(ref this._events, localEvents = new System.Delegate[20], null) ?? localEvents;
				}
			}
			private static void InterlockedDelegateCombine(ref System.Delegate location, System.Delegate value)
			{
				System.Delegate currentHandler;
				while ((object)System.Threading.Interlocked.CompareExchange<System.Delegate>(ref location, System.Delegate.Combine(currentHandler = location, value), currentHandler) != (object)currentHandler)
				{
				}
			}
			private static void InterlockedDelegateRemove(ref System.Delegate location, System.Delegate value)
			{
				System.Delegate currentHandler;
				while ((object)System.Threading.Interlocked.CompareExchange<System.Delegate>(ref location, System.Delegate.Remove(currentHandler = location, value), currentHandler) != (object)currentHandler)
				{
				}
			}
			public event EventHandler<PropertyChangingEventArgs<DataProvider, string>> NameChanging
			{
				add
				{
					if ((object)value != null)
					{
						DataProvider.InterlockedDelegateCombine(ref this.Events[0], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						DataProvider.InterlockedDelegateRemove(ref events[0], value);
					}
				}
			}
			protected bool OnNameChanging(string newValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangingEventArgs<DataProvider, string>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<DataProvider, string>>)events[0]) != null)
				{
					return EventHandlerUtility.InvokeCancelableEventHandler<PropertyChangingEventArgs<DataProvider, string>>(eventHandler, this, new PropertyChangingEventArgs<DataProvider, string>(this, "Name", this.Name, newValue));
				}
				return true;
			}
			public event EventHandler<PropertyChangedEventArgs<DataProvider, string>> NameChanged
			{
				add
				{
					if ((object)value != null)
					{
						DataProvider.InterlockedDelegateCombine(ref this.Events[1], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						DataProvider.InterlockedDelegateRemove(ref events[1], value);
					}
				}
			}
			protected void OnNameChanged(string oldValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangedEventArgs<DataProvider, string>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<DataProvider, string>>)events[1]) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync<PropertyChangedEventArgs<DataProvider, string>>(eventHandler, this, new PropertyChangedEventArgs<DataProvider, string>(this, "Name", oldValue, this.Name), this._propertyChangedEventHandler);
				}
				else
				{
					this.OnPropertyChanged("Name");
				}
			}
			public event EventHandler<PropertyChangingEventArgs<DataProvider, string>> DescriptionChanging
			{
				add
				{
					if ((object)value != null)
					{
						DataProvider.InterlockedDelegateCombine(ref this.Events[2], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						DataProvider.InterlockedDelegateRemove(ref events[2], value);
					}
				}
			}
			protected bool OnDescriptionChanging(string newValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangingEventArgs<DataProvider, string>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<DataProvider, string>>)events[2]) != null)
				{
					return EventHandlerUtility.InvokeCancelableEventHandler<PropertyChangingEventArgs<DataProvider, string>>(eventHandler, this, new PropertyChangingEventArgs<DataProvider, string>(this, "Description", this.Description, newValue));
				}
				return true;
			}
			public event EventHandler<PropertyChangedEventArgs<DataProvider, string>> DescriptionChanged
			{
				add
				{
					if ((object)value != null)
					{
						DataProvider.InterlockedDelegateCombine(ref this.Events[3], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						DataProvider.InterlockedDelegateRemove(ref events[3], value);
					}
				}
			}
			protected void OnDescriptionChanged(string oldValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangedEventArgs<DataProvider, string>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<DataProvider, string>>)events[3]) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync<PropertyChangedEventArgs<DataProvider, string>>(eventHandler, this, new PropertyChangedEventArgs<DataProvider, string>(this, "Description", oldValue, this.Description), this._propertyChangedEventHandler);
				}
				else
				{
					this.OnPropertyChanged("Description");
				}
			}
			public event EventHandler<PropertyChangingEventArgs<DataProvider, string>> OwnerChanging
			{
				add
				{
					if ((object)value != null)
					{
						DataProvider.InterlockedDelegateCombine(ref this.Events[4], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						DataProvider.InterlockedDelegateRemove(ref events[4], value);
					}
				}
			}
			protected bool OnOwnerChanging(string newValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangingEventArgs<DataProvider, string>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<DataProvider, string>>)events[4]) != null)
				{
					return EventHandlerUtility.InvokeCancelableEventHandler<PropertyChangingEventArgs<DataProvider, string>>(eventHandler, this, new PropertyChangingEventArgs<DataProvider, string>(this, "Owner", this.Owner, newValue));
				}
				return true;
			}
			public event EventHandler<PropertyChangedEventArgs<DataProvider, string>> OwnerChanged
			{
				add
				{
					if ((object)value != null)
					{
						DataProvider.InterlockedDelegateCombine(ref this.Events[5], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						DataProvider.InterlockedDelegateRemove(ref events[5], value);
					}
				}
			}
			protected void OnOwnerChanged(string oldValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangedEventArgs<DataProvider, string>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<DataProvider, string>>)events[5]) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync<PropertyChangedEventArgs<DataProvider, string>>(eventHandler, this, new PropertyChangedEventArgs<DataProvider, string>(this, "Owner", oldValue, this.Owner), this._propertyChangedEventHandler);
				}
				else
				{
					this.OnPropertyChanged("Owner");
				}
			}
			public event EventHandler<PropertyChangingEventArgs<DataProvider, Nullable<int>>> CreatedChanging
			{
				add
				{
					if ((object)value != null)
					{
						DataProvider.InterlockedDelegateCombine(ref this.Events[6], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						DataProvider.InterlockedDelegateRemove(ref events[6], value);
					}
				}
			}
			protected bool OnCreatedChanging(Nullable<int> newValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangingEventArgs<DataProvider, Nullable<int>>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<DataProvider, Nullable<int>>>)events[6]) != null)
				{
					return EventHandlerUtility.InvokeCancelableEventHandler<PropertyChangingEventArgs<DataProvider, Nullable<int>>>(eventHandler, this, new PropertyChangingEventArgs<DataProvider, Nullable<int>>(this, "Created", this.Created, newValue));
				}
				return true;
			}
			public event EventHandler<PropertyChangedEventArgs<DataProvider, Nullable<int>>> CreatedChanged
			{
				add
				{
					if ((object)value != null)
					{
						DataProvider.InterlockedDelegateCombine(ref this.Events[7], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						DataProvider.InterlockedDelegateRemove(ref events[7], value);
					}
				}
			}
			protected void OnCreatedChanged(Nullable<int> oldValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangedEventArgs<DataProvider, Nullable<int>>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<DataProvider, Nullable<int>>>)events[7]) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync<PropertyChangedEventArgs<DataProvider, Nullable<int>>>(eventHandler, this, new PropertyChangedEventArgs<DataProvider, Nullable<int>>(this, "Created", oldValue, this.Created), this._propertyChangedEventHandler);
				}
				else
				{
					this.OnPropertyChanged("Created");
				}
			}
			public event EventHandler<PropertyChangingEventArgs<DataProvider, Nullable<int>>> EditedChanging
			{
				add
				{
					if ((object)value != null)
					{
						DataProvider.InterlockedDelegateCombine(ref this.Events[8], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						DataProvider.InterlockedDelegateRemove(ref events[8], value);
					}
				}
			}
			protected bool OnEditedChanging(Nullable<int> newValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangingEventArgs<DataProvider, Nullable<int>>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<DataProvider, Nullable<int>>>)events[8]) != null)
				{
					return EventHandlerUtility.InvokeCancelableEventHandler<PropertyChangingEventArgs<DataProvider, Nullable<int>>>(eventHandler, this, new PropertyChangingEventArgs<DataProvider, Nullable<int>>(this, "Edited", this.Edited, newValue));
				}
				return true;
			}
			public event EventHandler<PropertyChangedEventArgs<DataProvider, Nullable<int>>> EditedChanged
			{
				add
				{
					if ((object)value != null)
					{
						DataProvider.InterlockedDelegateCombine(ref this.Events[9], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						DataProvider.InterlockedDelegateRemove(ref events[9], value);
					}
				}
			}
			protected void OnEditedChanged(Nullable<int> oldValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangedEventArgs<DataProvider, Nullable<int>>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<DataProvider, Nullable<int>>>)events[9]) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync<PropertyChangedEventArgs<DataProvider, Nullable<int>>>(eventHandler, this, new PropertyChangedEventArgs<DataProvider, Nullable<int>>(this, "Edited", oldValue, this.Edited), this._propertyChangedEventHandler);
				}
				else
				{
					this.OnPropertyChanged("Edited");
				}
			}
			public event EventHandler<PropertyChangingEventArgs<DataProvider, string>> VersionChanging
			{
				add
				{
					if ((object)value != null)
					{
						DataProvider.InterlockedDelegateCombine(ref this.Events[10], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						DataProvider.InterlockedDelegateRemove(ref events[10], value);
					}
				}
			}
			protected bool OnVersionChanging(string newValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangingEventArgs<DataProvider, string>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<DataProvider, string>>)events[10]) != null)
				{
					return EventHandlerUtility.InvokeCancelableEventHandler<PropertyChangingEventArgs<DataProvider, string>>(eventHandler, this, new PropertyChangingEventArgs<DataProvider, string>(this, "Version", this.Version, newValue));
				}
				return true;
			}
			public event EventHandler<PropertyChangedEventArgs<DataProvider, string>> VersionChanged
			{
				add
				{
					if ((object)value != null)
					{
						DataProvider.InterlockedDelegateCombine(ref this.Events[11], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						DataProvider.InterlockedDelegateRemove(ref events[11], value);
					}
				}
			}
			protected void OnVersionChanged(string oldValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangedEventArgs<DataProvider, string>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<DataProvider, string>>)events[11]) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync<PropertyChangedEventArgs<DataProvider, string>>(eventHandler, this, new PropertyChangedEventArgs<DataProvider, string>(this, "Version", oldValue, this.Version), this._propertyChangedEventHandler);
				}
				else
				{
					this.OnPropertyChanged("Version");
				}
			}
			public event EventHandler<PropertyChangingEventArgs<DataProvider, Nullable<decimal>>> CostOfSaleChanging
			{
				add
				{
					if ((object)value != null)
					{
						DataProvider.InterlockedDelegateCombine(ref this.Events[12], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						DataProvider.InterlockedDelegateRemove(ref events[12], value);
					}
				}
			}
			protected bool OnCostOfSaleChanging(Nullable<decimal> newValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangingEventArgs<DataProvider, Nullable<decimal>>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<DataProvider, Nullable<decimal>>>)events[12]) != null)
				{
					return EventHandlerUtility.InvokeCancelableEventHandler<PropertyChangingEventArgs<DataProvider, Nullable<decimal>>>(eventHandler, this, new PropertyChangingEventArgs<DataProvider, Nullable<decimal>>(this, "CostOfSale", this.CostOfSale, newValue));
				}
				return true;
			}
			public event EventHandler<PropertyChangedEventArgs<DataProvider, Nullable<decimal>>> CostOfSaleChanged
			{
				add
				{
					if ((object)value != null)
					{
						DataProvider.InterlockedDelegateCombine(ref this.Events[13], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						DataProvider.InterlockedDelegateRemove(ref events[13], value);
					}
				}
			}
			protected void OnCostOfSaleChanged(Nullable<decimal> oldValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangedEventArgs<DataProvider, Nullable<decimal>>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<DataProvider, Nullable<decimal>>>)events[13]) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync<PropertyChangedEventArgs<DataProvider, Nullable<decimal>>>(eventHandler, this, new PropertyChangedEventArgs<DataProvider, Nullable<decimal>>(this, "CostOfSale", oldValue, this.CostOfSale), this._propertyChangedEventHandler);
				}
				else
				{
					this.OnPropertyChanged("CostOfSale");
				}
			}
			public event EventHandler<PropertyChangingEventArgs<DataProvider, Nullable<int>>> RevisionDateChanging
			{
				add
				{
					if ((object)value != null)
					{
						DataProvider.InterlockedDelegateCombine(ref this.Events[14], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						DataProvider.InterlockedDelegateRemove(ref events[14], value);
					}
				}
			}
			protected bool OnRevisionDateChanging(Nullable<int> newValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangingEventArgs<DataProvider, Nullable<int>>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<DataProvider, Nullable<int>>>)events[14]) != null)
				{
					return EventHandlerUtility.InvokeCancelableEventHandler<PropertyChangingEventArgs<DataProvider, Nullable<int>>>(eventHandler, this, new PropertyChangingEventArgs<DataProvider, Nullable<int>>(this, "RevisionDate", this.RevisionDate, newValue));
				}
				return true;
			}
			public event EventHandler<PropertyChangedEventArgs<DataProvider, Nullable<int>>> RevisionDateChanged
			{
				add
				{
					if ((object)value != null)
					{
						DataProvider.InterlockedDelegateCombine(ref this.Events[15], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						DataProvider.InterlockedDelegateRemove(ref events[15], value);
					}
				}
			}
			protected void OnRevisionDateChanged(Nullable<int> oldValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangedEventArgs<DataProvider, Nullable<int>>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<DataProvider, Nullable<int>>>)events[15]) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync<PropertyChangedEventArgs<DataProvider, Nullable<int>>>(eventHandler, this, new PropertyChangedEventArgs<DataProvider, Nullable<int>>(this, "RevisionDate", oldValue, this.RevisionDate), this._propertyChangedEventHandler);
				}
				else
				{
					this.OnPropertyChanged("RevisionDate");
				}
			}
			public event EventHandler<PropertyChangingEventArgs<DataProvider, string>> SourceURLChanging
			{
				add
				{
					if ((object)value != null)
					{
						DataProvider.InterlockedDelegateCombine(ref this.Events[16], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						DataProvider.InterlockedDelegateRemove(ref events[16], value);
					}
				}
			}
			protected bool OnSourceURLChanging(string newValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangingEventArgs<DataProvider, string>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<DataProvider, string>>)events[16]) != null)
				{
					return EventHandlerUtility.InvokeCancelableEventHandler<PropertyChangingEventArgs<DataProvider, string>>(eventHandler, this, new PropertyChangingEventArgs<DataProvider, string>(this, "SourceURL", this.SourceURL, newValue));
				}
				return true;
			}
			public event EventHandler<PropertyChangedEventArgs<DataProvider, string>> SourceURLChanged
			{
				add
				{
					if ((object)value != null)
					{
						DataProvider.InterlockedDelegateCombine(ref this.Events[17], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						DataProvider.InterlockedDelegateRemove(ref events[17], value);
					}
				}
			}
			protected void OnSourceURLChanged(string oldValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangedEventArgs<DataProvider, string>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<DataProvider, string>>)events[17]) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync<PropertyChangedEventArgs<DataProvider, string>>(eventHandler, this, new PropertyChangedEventArgs<DataProvider, string>(this, "SourceURL", oldValue, this.SourceURL), this._propertyChangedEventHandler);
				}
				else
				{
					this.OnPropertyChanged("SourceURL");
				}
			}
			public event EventHandler<PropertyChangingEventArgs<DataProvider, State>> StateChanging
			{
				add
				{
					if ((object)value != null)
					{
						DataProvider.InterlockedDelegateCombine(ref this.Events[18], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						DataProvider.InterlockedDelegateRemove(ref events[18], value);
					}
				}
			}
			protected bool OnStateChanging(State newValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangingEventArgs<DataProvider, State>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<DataProvider, State>>)events[18]) != null)
				{
					return EventHandlerUtility.InvokeCancelableEventHandler<PropertyChangingEventArgs<DataProvider, State>>(eventHandler, this, new PropertyChangingEventArgs<DataProvider, State>(this, "State", this.State, newValue));
				}
				return true;
			}
			public event EventHandler<PropertyChangedEventArgs<DataProvider, State>> StateChanged
			{
				add
				{
					if ((object)value != null)
					{
						DataProvider.InterlockedDelegateCombine(ref this.Events[19], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						DataProvider.InterlockedDelegateRemove(ref events[19], value);
					}
				}
			}
			protected void OnStateChanged(State oldValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangedEventArgs<DataProvider, State>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<DataProvider, State>>)events[19]) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync<PropertyChangedEventArgs<DataProvider, State>>(eventHandler, this, new PropertyChangedEventArgs<DataProvider, State>(this, "State", oldValue, this.State), this._propertyChangedEventHandler);
				}
				else
				{
					this.OnPropertyChanged("State");
				}
			}
			#endregion // DataProvider Property Change Events
			#region DataProvider Abstract Properties
			public abstract PackageBuilderContext Context
			{
				get;
			}
			[DataObjectField(false, false, false)]
			public abstract string Name
			{
				get;
				set;
			}
			[DataObjectField(false, false, true)]
			public abstract string Description
			{
				get;
				set;
			}
			[DataObjectField(false, false, false)]
			public abstract string Owner
			{
				get;
				set;
			}
			[DataObjectField(false, false, true)]
			public abstract Nullable<int> Created
			{
				get;
				set;
			}
			[DataObjectField(false, false, true)]
			public abstract Nullable<int> Edited
			{
				get;
				set;
			}
			[DataObjectField(false, false, false)]
			public abstract string Version
			{
				get;
				set;
			}
			[DataObjectField(false, false, true)]
			public abstract Nullable<decimal> CostOfSale
			{
				get;
				set;
			}
			[DataObjectField(false, false, true)]
			public abstract Nullable<int> RevisionDate
			{
				get;
				set;
			}
			[DataObjectField(false, false, false)]
			public abstract string SourceURL
			{
				get;
				set;
			}
			[DataObjectField(false, false, false)]
			public abstract State State
			{
				get;
				set;
			}
			[DataObjectField(false, false, true)]
			public abstract IEnumerable<DataField> DataFieldViaDataProviderCollection
			{
				get;
			}
			#endregion // DataProvider Abstract Properties
			#region DataProvider ToString Methods
			public override string ToString()
			{
				return this.ToString(null);
			}
			public virtual string ToString(IFormatProvider provider)
			{
				return string.Format(provider, @"DataProvider{0}{{{0}{1}Name = ""{2}"",{0}{1}Description = ""{3}"",{0}{1}Owner = ""{4}"",{0}{1}Created = ""{5}"",{0}{1}Edited = ""{6}"",{0}{1}Version = ""{7}"",{0}{1}CostOfSale = ""{8}"",{0}{1}RevisionDate = ""{9}"",{0}{1}SourceURL = ""{10}"",{0}{1}State = {11}{0}}}", Environment.NewLine, @"	", this.Name, this.Description, this.Owner, this.Created, this.Edited, this.Version, this.CostOfSale, this.RevisionDate, this.SourceURL, "TODO: Recursively call ToString for customTypes...");
			}
			#endregion // DataProvider ToString Methods
		}
		#endregion // DataProvider
		#region DataField
		[DataObject()]
		[System.CodeDom.Compiler.GeneratedCode("OIALtoPLiX", "1.0")]
		[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto, CharSet=System.Runtime.InteropServices.CharSet.Auto)]
		public abstract partial class DataField : INotifyPropertyChanged, IHasPackageBuilderContext
		{
			protected DataField()
			{
			}
			#region DataField INotifyPropertyChanged Implementation
			private PropertyChangedEventHandler _propertyChangedEventHandler;
			[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
			event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
			{
				add
				{
					if ((object)value != null)
					{
						PropertyChangedEventHandler currentHandler;
						while ((object)System.Threading.Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this._propertyChangedEventHandler, (PropertyChangedEventHandler)System.Delegate.Combine(currentHandler = this._propertyChangedEventHandler, value), currentHandler) != (object)currentHandler)
						{
						}
					}
				}
				remove
				{
					if ((object)value != null)
					{
						PropertyChangedEventHandler currentHandler;
						while ((object)System.Threading.Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this._propertyChangedEventHandler, (PropertyChangedEventHandler)System.Delegate.Remove(currentHandler = this._propertyChangedEventHandler, value), currentHandler) != (object)currentHandler)
						{
						}
					}
				}
			}
			private void OnPropertyChanged(string propertyName)
			{
				PropertyChangedEventHandler eventHandler;
				if ((object)(eventHandler = this._propertyChangedEventHandler) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this, new PropertyChangedEventArgs(propertyName));
				}
			}
			#endregion // DataField INotifyPropertyChanged Implementation
			#region DataField Property Change Events
			private System.Delegate[] _events;
			private System.Delegate[] Events
			{
				get
				{
					System.Delegate[] localEvents;
					return (localEvents = this._events) ?? System.Threading.Interlocked.CompareExchange<System.Delegate[]>(ref this._events, localEvents = new System.Delegate[14], null) ?? localEvents;
				}
			}
			private static void InterlockedDelegateCombine(ref System.Delegate location, System.Delegate value)
			{
				System.Delegate currentHandler;
				while ((object)System.Threading.Interlocked.CompareExchange<System.Delegate>(ref location, System.Delegate.Combine(currentHandler = location, value), currentHandler) != (object)currentHandler)
				{
				}
			}
			private static void InterlockedDelegateRemove(ref System.Delegate location, System.Delegate value)
			{
				System.Delegate currentHandler;
				while ((object)System.Threading.Interlocked.CompareExchange<System.Delegate>(ref location, System.Delegate.Remove(currentHandler = location, value), currentHandler) != (object)currentHandler)
				{
				}
			}
			public event EventHandler<PropertyChangingEventArgs<DataField, string>> LabelChanging
			{
				add
				{
					if ((object)value != null)
					{
						DataField.InterlockedDelegateCombine(ref this.Events[0], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						DataField.InterlockedDelegateRemove(ref events[0], value);
					}
				}
			}
			protected bool OnLabelChanging(string newValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangingEventArgs<DataField, string>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<DataField, string>>)events[0]) != null)
				{
					return EventHandlerUtility.InvokeCancelableEventHandler<PropertyChangingEventArgs<DataField, string>>(eventHandler, this, new PropertyChangingEventArgs<DataField, string>(this, "Label", this.Label, newValue));
				}
				return true;
			}
			public event EventHandler<PropertyChangedEventArgs<DataField, string>> LabelChanged
			{
				add
				{
					if ((object)value != null)
					{
						DataField.InterlockedDelegateCombine(ref this.Events[1], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						DataField.InterlockedDelegateRemove(ref events[1], value);
					}
				}
			}
			protected void OnLabelChanged(string oldValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangedEventArgs<DataField, string>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<DataField, string>>)events[1]) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync<PropertyChangedEventArgs<DataField, string>>(eventHandler, this, new PropertyChangedEventArgs<DataField, string>(this, "Label", oldValue, this.Label), this._propertyChangedEventHandler);
				}
				else
				{
					this.OnPropertyChanged("Label");
				}
			}
			public event EventHandler<PropertyChangingEventArgs<DataField, string>> TypeDefinitionChanging
			{
				add
				{
					if ((object)value != null)
					{
						DataField.InterlockedDelegateCombine(ref this.Events[2], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						DataField.InterlockedDelegateRemove(ref events[2], value);
					}
				}
			}
			protected bool OnTypeDefinitionChanging(string newValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangingEventArgs<DataField, string>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<DataField, string>>)events[2]) != null)
				{
					return EventHandlerUtility.InvokeCancelableEventHandler<PropertyChangingEventArgs<DataField, string>>(eventHandler, this, new PropertyChangingEventArgs<DataField, string>(this, "TypeDefinition", this.TypeDefinition, newValue));
				}
				return true;
			}
			public event EventHandler<PropertyChangedEventArgs<DataField, string>> TypeDefinitionChanged
			{
				add
				{
					if ((object)value != null)
					{
						DataField.InterlockedDelegateCombine(ref this.Events[3], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						DataField.InterlockedDelegateRemove(ref events[3], value);
					}
				}
			}
			protected void OnTypeDefinitionChanged(string oldValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangedEventArgs<DataField, string>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<DataField, string>>)events[3]) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync<PropertyChangedEventArgs<DataField, string>>(eventHandler, this, new PropertyChangedEventArgs<DataField, string>(this, "TypeDefinition", oldValue, this.TypeDefinition), this._propertyChangedEventHandler);
				}
				else
				{
					this.OnPropertyChanged("TypeDefinition");
				}
			}
			public event EventHandler<PropertyChangingEventArgs<DataField, bool>> SelectedChanging
			{
				add
				{
					if ((object)value != null)
					{
						DataField.InterlockedDelegateCombine(ref this.Events[4], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						DataField.InterlockedDelegateRemove(ref events[4], value);
					}
				}
			}
			protected bool OnSelectedChanging(bool newValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangingEventArgs<DataField, bool>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<DataField, bool>>)events[4]) != null)
				{
					return EventHandlerUtility.InvokeCancelableEventHandler<PropertyChangingEventArgs<DataField, bool>>(eventHandler, this, new PropertyChangingEventArgs<DataField, bool>(this, "Selected", this.Selected, newValue));
				}
				return true;
			}
			public event EventHandler<PropertyChangedEventArgs<DataField, bool>> SelectedChanged
			{
				add
				{
					if ((object)value != null)
					{
						DataField.InterlockedDelegateCombine(ref this.Events[5], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						DataField.InterlockedDelegateRemove(ref events[5], value);
					}
				}
			}
			protected void OnSelectedChanged(bool oldValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangedEventArgs<DataField, bool>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<DataField, bool>>)events[5]) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync<PropertyChangedEventArgs<DataField, bool>>(eventHandler, this, new PropertyChangedEventArgs<DataField, bool>(this, "Selected", oldValue, this.Selected), this._propertyChangedEventHandler);
				}
				else
				{
					this.OnPropertyChanged("Selected");
				}
			}
			public event EventHandler<PropertyChangingEventArgs<DataField, decimal>> CostOfSaleChanging
			{
				add
				{
					if ((object)value != null)
					{
						DataField.InterlockedDelegateCombine(ref this.Events[6], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						DataField.InterlockedDelegateRemove(ref events[6], value);
					}
				}
			}
			protected bool OnCostOfSaleChanging(decimal newValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangingEventArgs<DataField, decimal>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<DataField, decimal>>)events[6]) != null)
				{
					return EventHandlerUtility.InvokeCancelableEventHandler<PropertyChangingEventArgs<DataField, decimal>>(eventHandler, this, new PropertyChangingEventArgs<DataField, decimal>(this, "CostOfSale", this.CostOfSale, newValue));
				}
				return true;
			}
			public event EventHandler<PropertyChangedEventArgs<DataField, decimal>> CostOfSaleChanged
			{
				add
				{
					if ((object)value != null)
					{
						DataField.InterlockedDelegateCombine(ref this.Events[7], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						DataField.InterlockedDelegateRemove(ref events[7], value);
					}
				}
			}
			protected void OnCostOfSaleChanged(decimal oldValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangedEventArgs<DataField, decimal>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<DataField, decimal>>)events[7]) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync<PropertyChangedEventArgs<DataField, decimal>>(eventHandler, this, new PropertyChangedEventArgs<DataField, decimal>(this, "CostOfSale", oldValue, this.CostOfSale), this._propertyChangedEventHandler);
				}
				else
				{
					this.OnPropertyChanged("CostOfSale");
				}
			}
			public event EventHandler<PropertyChangingEventArgs<DataField, string>> NameChanging
			{
				add
				{
					if ((object)value != null)
					{
						DataField.InterlockedDelegateCombine(ref this.Events[8], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						DataField.InterlockedDelegateRemove(ref events[8], value);
					}
				}
			}
			protected bool OnNameChanging(string newValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangingEventArgs<DataField, string>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<DataField, string>>)events[8]) != null)
				{
					return EventHandlerUtility.InvokeCancelableEventHandler<PropertyChangingEventArgs<DataField, string>>(eventHandler, this, new PropertyChangingEventArgs<DataField, string>(this, "Name", this.Name, newValue));
				}
				return true;
			}
			public event EventHandler<PropertyChangedEventArgs<DataField, string>> NameChanged
			{
				add
				{
					if ((object)value != null)
					{
						DataField.InterlockedDelegateCombine(ref this.Events[9], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						DataField.InterlockedDelegateRemove(ref events[9], value);
					}
				}
			}
			protected void OnNameChanged(string oldValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangedEventArgs<DataField, string>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<DataField, string>>)events[9]) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync<PropertyChangedEventArgs<DataField, string>>(eventHandler, this, new PropertyChangedEventArgs<DataField, string>(this, "Name", oldValue, this.Name), this._propertyChangedEventHandler);
				}
				else
				{
					this.OnPropertyChanged("Name");
				}
			}
			public event EventHandler<PropertyChangingEventArgs<DataField, DataProvider>> DataProviderChanging
			{
				add
				{
					if ((object)value != null)
					{
						DataField.InterlockedDelegateCombine(ref this.Events[10], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						DataField.InterlockedDelegateRemove(ref events[10], value);
					}
				}
			}
			protected bool OnDataProviderChanging(DataProvider newValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangingEventArgs<DataField, DataProvider>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<DataField, DataProvider>>)events[10]) != null)
				{
					return EventHandlerUtility.InvokeCancelableEventHandler<PropertyChangingEventArgs<DataField, DataProvider>>(eventHandler, this, new PropertyChangingEventArgs<DataField, DataProvider>(this, "DataProvider", this.DataProvider, newValue));
				}
				return true;
			}
			public event EventHandler<PropertyChangedEventArgs<DataField, DataProvider>> DataProviderChanged
			{
				add
				{
					if ((object)value != null)
					{
						DataField.InterlockedDelegateCombine(ref this.Events[11], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						DataField.InterlockedDelegateRemove(ref events[11], value);
					}
				}
			}
			protected void OnDataProviderChanged(DataProvider oldValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangedEventArgs<DataField, DataProvider>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<DataField, DataProvider>>)events[11]) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync<PropertyChangedEventArgs<DataField, DataProvider>>(eventHandler, this, new PropertyChangedEventArgs<DataField, DataProvider>(this, "DataProvider", oldValue, this.DataProvider), this._propertyChangedEventHandler);
				}
				else
				{
					this.OnPropertyChanged("DataProvider");
				}
			}
			public event EventHandler<PropertyChangingEventArgs<DataField, Industry>> IndustryChanging
			{
				add
				{
					if ((object)value != null)
					{
						DataField.InterlockedDelegateCombine(ref this.Events[12], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						DataField.InterlockedDelegateRemove(ref events[12], value);
					}
				}
			}
			protected bool OnIndustryChanging(Industry newValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangingEventArgs<DataField, Industry>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<DataField, Industry>>)events[12]) != null)
				{
					return EventHandlerUtility.InvokeCancelableEventHandler<PropertyChangingEventArgs<DataField, Industry>>(eventHandler, this, new PropertyChangingEventArgs<DataField, Industry>(this, "Industry", this.Industry, newValue));
				}
				return true;
			}
			public event EventHandler<PropertyChangedEventArgs<DataField, Industry>> IndustryChanged
			{
				add
				{
					if ((object)value != null)
					{
						DataField.InterlockedDelegateCombine(ref this.Events[13], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						DataField.InterlockedDelegateRemove(ref events[13], value);
					}
				}
			}
			protected void OnIndustryChanged(Industry oldValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangedEventArgs<DataField, Industry>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<DataField, Industry>>)events[13]) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync<PropertyChangedEventArgs<DataField, Industry>>(eventHandler, this, new PropertyChangedEventArgs<DataField, Industry>(this, "Industry", oldValue, this.Industry), this._propertyChangedEventHandler);
				}
				else
				{
					this.OnPropertyChanged("Industry");
				}
			}
			#endregion // DataField Property Change Events
			#region DataField Abstract Properties
			public abstract PackageBuilderContext Context
			{
				get;
			}
			[DataObjectField(false, false, true)]
			public abstract string Label
			{
				get;
				set;
			}
			[DataObjectField(false, false, true)]
			public abstract string TypeDefinition
			{
				get;
				set;
			}
			[DataObjectField(false, false, false)]
			public abstract bool Selected
			{
				get;
				set;
			}
			[DataObjectField(false, false, false)]
			public abstract decimal CostOfSale
			{
				get;
				set;
			}
			[DataObjectField(false, false, false)]
			public abstract string Name
			{
				get;
				set;
			}
			[DataObjectField(false, false, false)]
			public abstract DataProvider DataProvider
			{
				get;
				set;
			}
			[DataObjectField(false, false, false)]
			public abstract Industry Industry
			{
				get;
				set;
			}
			[DataObjectField(false, false, true)]
			public abstract IEnumerable<PackageDataField> PackageDataFieldViaDataFieldCollection
			{
				get;
			}
			#endregion // DataField Abstract Properties
			#region DataField ToString Methods
			public override string ToString()
			{
				return this.ToString(null);
			}
			public virtual string ToString(IFormatProvider provider)
			{
				return string.Format(provider, @"DataField{0}{{{0}{1}Label = ""{2}"",{0}{1}TypeDefinition = ""{3}"",{0}{1}Selected = ""{4}"",{0}{1}CostOfSale = ""{5}"",{0}{1}Name = ""{6}"",{0}{1}DataProvider = {7},{0}{1}Industry = {8}{0}}}", Environment.NewLine, @"	", this.Label, this.TypeDefinition, this.Selected, this.CostOfSale, this.Name, "TODO: Recursively call ToString for customTypes...", "TODO: Recursively call ToString for customTypes...");
			}
			#endregion // DataField ToString Methods
		}
		#endregion // DataField
		#region PackageDataField
		[DataObject()]
		[System.CodeDom.Compiler.GeneratedCode("OIALtoPLiX", "1.0")]
		[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto, CharSet=System.Runtime.InteropServices.CharSet.Auto)]
		public abstract partial class PackageDataField : INotifyPropertyChanged, IHasPackageBuilderContext
		{
			protected PackageDataField()
			{
			}
			#region PackageDataField INotifyPropertyChanged Implementation
			private PropertyChangedEventHandler _propertyChangedEventHandler;
			[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
			event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
			{
				add
				{
					if ((object)value != null)
					{
						PropertyChangedEventHandler currentHandler;
						while ((object)System.Threading.Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this._propertyChangedEventHandler, (PropertyChangedEventHandler)System.Delegate.Combine(currentHandler = this._propertyChangedEventHandler, value), currentHandler) != (object)currentHandler)
						{
						}
					}
				}
				remove
				{
					if ((object)value != null)
					{
						PropertyChangedEventHandler currentHandler;
						while ((object)System.Threading.Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this._propertyChangedEventHandler, (PropertyChangedEventHandler)System.Delegate.Remove(currentHandler = this._propertyChangedEventHandler, value), currentHandler) != (object)currentHandler)
						{
						}
					}
				}
			}
			private void OnPropertyChanged(string propertyName)
			{
				PropertyChangedEventHandler eventHandler;
				if ((object)(eventHandler = this._propertyChangedEventHandler) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this, new PropertyChangedEventArgs(propertyName));
				}
			}
			#endregion // PackageDataField INotifyPropertyChanged Implementation
			#region PackageDataField Property Change Events
			private System.Delegate[] _events;
			private System.Delegate[] Events
			{
				get
				{
					System.Delegate[] localEvents;
					return (localEvents = this._events) ?? System.Threading.Interlocked.CompareExchange<System.Delegate[]>(ref this._events, localEvents = new System.Delegate[10], null) ?? localEvents;
				}
			}
			private static void InterlockedDelegateCombine(ref System.Delegate location, System.Delegate value)
			{
				System.Delegate currentHandler;
				while ((object)System.Threading.Interlocked.CompareExchange<System.Delegate>(ref location, System.Delegate.Combine(currentHandler = location, value), currentHandler) != (object)currentHandler)
				{
				}
			}
			private static void InterlockedDelegateRemove(ref System.Delegate location, System.Delegate value)
			{
				System.Delegate currentHandler;
				while ((object)System.Threading.Interlocked.CompareExchange<System.Delegate>(ref location, System.Delegate.Remove(currentHandler = location, value), currentHandler) != (object)currentHandler)
				{
				}
			}
			public event EventHandler<PropertyChangingEventArgs<PackageDataField, int>> PriorityChanging
			{
				add
				{
					if ((object)value != null)
					{
						PackageDataField.InterlockedDelegateCombine(ref this.Events[0], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						PackageDataField.InterlockedDelegateRemove(ref events[0], value);
					}
				}
			}
			protected bool OnPriorityChanging(int newValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangingEventArgs<PackageDataField, int>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<PackageDataField, int>>)events[0]) != null)
				{
					return EventHandlerUtility.InvokeCancelableEventHandler<PropertyChangingEventArgs<PackageDataField, int>>(eventHandler, this, new PropertyChangingEventArgs<PackageDataField, int>(this, "Priority", this.Priority, newValue));
				}
				return true;
			}
			public event EventHandler<PropertyChangedEventArgs<PackageDataField, int>> PriorityChanged
			{
				add
				{
					if ((object)value != null)
					{
						PackageDataField.InterlockedDelegateCombine(ref this.Events[1], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						PackageDataField.InterlockedDelegateRemove(ref events[1], value);
					}
				}
			}
			protected void OnPriorityChanged(int oldValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangedEventArgs<PackageDataField, int>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<PackageDataField, int>>)events[1]) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync<PropertyChangedEventArgs<PackageDataField, int>>(eventHandler, this, new PropertyChangedEventArgs<PackageDataField, int>(this, "Priority", oldValue, this.Priority), this._propertyChangedEventHandler);
				}
				else
				{
					this.OnPropertyChanged("Priority");
				}
			}
			public event EventHandler<PropertyChangingEventArgs<PackageDataField, string>> UnifiedNameChanging
			{
				add
				{
					if ((object)value != null)
					{
						PackageDataField.InterlockedDelegateCombine(ref this.Events[2], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						PackageDataField.InterlockedDelegateRemove(ref events[2], value);
					}
				}
			}
			protected bool OnUnifiedNameChanging(string newValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangingEventArgs<PackageDataField, string>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<PackageDataField, string>>)events[2]) != null)
				{
					return EventHandlerUtility.InvokeCancelableEventHandler<PropertyChangingEventArgs<PackageDataField, string>>(eventHandler, this, new PropertyChangingEventArgs<PackageDataField, string>(this, "UnifiedName", this.UnifiedName, newValue));
				}
				return true;
			}
			public event EventHandler<PropertyChangedEventArgs<PackageDataField, string>> UnifiedNameChanged
			{
				add
				{
					if ((object)value != null)
					{
						PackageDataField.InterlockedDelegateCombine(ref this.Events[3], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						PackageDataField.InterlockedDelegateRemove(ref events[3], value);
					}
				}
			}
			protected void OnUnifiedNameChanged(string oldValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangedEventArgs<PackageDataField, string>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<PackageDataField, string>>)events[3]) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync<PropertyChangedEventArgs<PackageDataField, string>>(eventHandler, this, new PropertyChangedEventArgs<PackageDataField, string>(this, "UnifiedName", oldValue, this.UnifiedName), this._propertyChangedEventHandler);
				}
				else
				{
					this.OnPropertyChanged("UnifiedName");
				}
			}
			public event EventHandler<PropertyChangingEventArgs<PackageDataField, bool>> SelectedChanging
			{
				add
				{
					if ((object)value != null)
					{
						PackageDataField.InterlockedDelegateCombine(ref this.Events[4], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						PackageDataField.InterlockedDelegateRemove(ref events[4], value);
					}
				}
			}
			protected bool OnSelectedChanging(bool newValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangingEventArgs<PackageDataField, bool>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<PackageDataField, bool>>)events[4]) != null)
				{
					return EventHandlerUtility.InvokeCancelableEventHandler<PropertyChangingEventArgs<PackageDataField, bool>>(eventHandler, this, new PropertyChangingEventArgs<PackageDataField, bool>(this, "Selected", this.Selected, newValue));
				}
				return true;
			}
			public event EventHandler<PropertyChangedEventArgs<PackageDataField, bool>> SelectedChanged
			{
				add
				{
					if ((object)value != null)
					{
						PackageDataField.InterlockedDelegateCombine(ref this.Events[5], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						PackageDataField.InterlockedDelegateRemove(ref events[5], value);
					}
				}
			}
			protected void OnSelectedChanged(bool oldValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangedEventArgs<PackageDataField, bool>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<PackageDataField, bool>>)events[5]) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync<PropertyChangedEventArgs<PackageDataField, bool>>(eventHandler, this, new PropertyChangedEventArgs<PackageDataField, bool>(this, "Selected", oldValue, this.Selected), this._propertyChangedEventHandler);
				}
				else
				{
					this.OnPropertyChanged("Selected");
				}
			}
			public event EventHandler<PropertyChangingEventArgs<PackageDataField, Package>> PackageChanging
			{
				add
				{
					if ((object)value != null)
					{
						PackageDataField.InterlockedDelegateCombine(ref this.Events[6], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						PackageDataField.InterlockedDelegateRemove(ref events[6], value);
					}
				}
			}
			protected bool OnPackageChanging(Package newValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangingEventArgs<PackageDataField, Package>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<PackageDataField, Package>>)events[6]) != null)
				{
					return EventHandlerUtility.InvokeCancelableEventHandler<PropertyChangingEventArgs<PackageDataField, Package>>(eventHandler, this, new PropertyChangingEventArgs<PackageDataField, Package>(this, "Package", this.Package, newValue));
				}
				return true;
			}
			public event EventHandler<PropertyChangedEventArgs<PackageDataField, Package>> PackageChanged
			{
				add
				{
					if ((object)value != null)
					{
						PackageDataField.InterlockedDelegateCombine(ref this.Events[7], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						PackageDataField.InterlockedDelegateRemove(ref events[7], value);
					}
				}
			}
			protected void OnPackageChanged(Package oldValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangedEventArgs<PackageDataField, Package>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<PackageDataField, Package>>)events[7]) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync<PropertyChangedEventArgs<PackageDataField, Package>>(eventHandler, this, new PropertyChangedEventArgs<PackageDataField, Package>(this, "Package", oldValue, this.Package), this._propertyChangedEventHandler);
				}
				else
				{
					this.OnPropertyChanged("Package");
				}
			}
			public event EventHandler<PropertyChangingEventArgs<PackageDataField, DataField>> DataFieldChanging
			{
				add
				{
					if ((object)value != null)
					{
						PackageDataField.InterlockedDelegateCombine(ref this.Events[8], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						PackageDataField.InterlockedDelegateRemove(ref events[8], value);
					}
				}
			}
			protected bool OnDataFieldChanging(DataField newValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangingEventArgs<PackageDataField, DataField>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<PackageDataField, DataField>>)events[8]) != null)
				{
					return EventHandlerUtility.InvokeCancelableEventHandler<PropertyChangingEventArgs<PackageDataField, DataField>>(eventHandler, this, new PropertyChangingEventArgs<PackageDataField, DataField>(this, "DataField", this.DataField, newValue));
				}
				return true;
			}
			public event EventHandler<PropertyChangedEventArgs<PackageDataField, DataField>> DataFieldChanged
			{
				add
				{
					if ((object)value != null)
					{
						PackageDataField.InterlockedDelegateCombine(ref this.Events[9], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						PackageDataField.InterlockedDelegateRemove(ref events[9], value);
					}
				}
			}
			protected void OnDataFieldChanged(DataField oldValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangedEventArgs<PackageDataField, DataField>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<PackageDataField, DataField>>)events[9]) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync<PropertyChangedEventArgs<PackageDataField, DataField>>(eventHandler, this, new PropertyChangedEventArgs<PackageDataField, DataField>(this, "DataField", oldValue, this.DataField), this._propertyChangedEventHandler);
				}
				else
				{
					this.OnPropertyChanged("DataField");
				}
			}
			#endregion // PackageDataField Property Change Events
			#region PackageDataField Abstract Properties
			public abstract PackageBuilderContext Context
			{
				get;
			}
			[DataObjectField(false, false, false)]
			public abstract int Priority
			{
				get;
				set;
			}
			[DataObjectField(false, false, false)]
			public abstract string UnifiedName
			{
				get;
				set;
			}
			[DataObjectField(false, false, false)]
			public abstract bool Selected
			{
				get;
				set;
			}
			[DataObjectField(false, false, false)]
			public abstract Package Package
			{
				get;
				set;
			}
			[DataObjectField(false, false, false)]
			public abstract DataField DataField
			{
				get;
				set;
			}
			#endregion // PackageDataField Abstract Properties
			#region PackageDataField ToString Methods
			public override string ToString()
			{
				return this.ToString(null);
			}
			public virtual string ToString(IFormatProvider provider)
			{
				return string.Format(provider, @"PackageDataField{0}{{{0}{1}Priority = ""{2}"",{0}{1}UnifiedName = ""{3}"",{0}{1}Selected = ""{4}"",{0}{1}Package = {5},{0}{1}DataField = {6}{0}}}", Environment.NewLine, @"	", this.Priority, this.UnifiedName, this.Selected, "TODO: Recursively call ToString for customTypes...", "TODO: Recursively call ToString for customTypes...");
			}
			#endregion // PackageDataField ToString Methods
		}
		#endregion // PackageDataField
		#region Industry
		[DataObject()]
		[System.CodeDom.Compiler.GeneratedCode("OIALtoPLiX", "1.0")]
		[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto, CharSet=System.Runtime.InteropServices.CharSet.Auto)]
		public abstract partial class Industry : INotifyPropertyChanged, IHasPackageBuilderContext
		{
			protected Industry()
			{
			}
			#region Industry INotifyPropertyChanged Implementation
			private PropertyChangedEventHandler _propertyChangedEventHandler;
			[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
			event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
			{
				add
				{
					if ((object)value != null)
					{
						PropertyChangedEventHandler currentHandler;
						while ((object)System.Threading.Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this._propertyChangedEventHandler, (PropertyChangedEventHandler)System.Delegate.Combine(currentHandler = this._propertyChangedEventHandler, value), currentHandler) != (object)currentHandler)
						{
						}
					}
				}
				remove
				{
					if ((object)value != null)
					{
						PropertyChangedEventHandler currentHandler;
						while ((object)System.Threading.Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this._propertyChangedEventHandler, (PropertyChangedEventHandler)System.Delegate.Remove(currentHandler = this._propertyChangedEventHandler, value), currentHandler) != (object)currentHandler)
						{
						}
					}
				}
			}
			private void OnPropertyChanged(string propertyName)
			{
				PropertyChangedEventHandler eventHandler;
				if ((object)(eventHandler = this._propertyChangedEventHandler) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync(eventHandler, this, new PropertyChangedEventArgs(propertyName));
				}
			}
			#endregion // Industry INotifyPropertyChanged Implementation
			#region Industry Property Change Events
			private System.Delegate[] _events;
			private System.Delegate[] Events
			{
				get
				{
					System.Delegate[] localEvents;
					return (localEvents = this._events) ?? System.Threading.Interlocked.CompareExchange<System.Delegate[]>(ref this._events, localEvents = new System.Delegate[2], null) ?? localEvents;
				}
			}
			private static void InterlockedDelegateCombine(ref System.Delegate location, System.Delegate value)
			{
				System.Delegate currentHandler;
				while ((object)System.Threading.Interlocked.CompareExchange<System.Delegate>(ref location, System.Delegate.Combine(currentHandler = location, value), currentHandler) != (object)currentHandler)
				{
				}
			}
			private static void InterlockedDelegateRemove(ref System.Delegate location, System.Delegate value)
			{
				System.Delegate currentHandler;
				while ((object)System.Threading.Interlocked.CompareExchange<System.Delegate>(ref location, System.Delegate.Remove(currentHandler = location, value), currentHandler) != (object)currentHandler)
				{
				}
			}
			public event EventHandler<PropertyChangingEventArgs<Industry, string>> ValueChanging
			{
				add
				{
					if ((object)value != null)
					{
						Industry.InterlockedDelegateCombine(ref this.Events[0], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						Industry.InterlockedDelegateRemove(ref events[0], value);
					}
				}
			}
			protected bool OnValueChanging(string newValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangingEventArgs<Industry, string>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangingEventArgs<Industry, string>>)events[0]) != null)
				{
					return EventHandlerUtility.InvokeCancelableEventHandler<PropertyChangingEventArgs<Industry, string>>(eventHandler, this, new PropertyChangingEventArgs<Industry, string>(this, "Value", this.Value, newValue));
				}
				return true;
			}
			public event EventHandler<PropertyChangedEventArgs<Industry, string>> ValueChanged
			{
				add
				{
					if ((object)value != null)
					{
						Industry.InterlockedDelegateCombine(ref this.Events[1], value);
					}
				}
				remove
				{
					System.Delegate[] events;
					if ((object)value != null && (object)(events = this._events) != null)
					{
						Industry.InterlockedDelegateRemove(ref events[1], value);
					}
				}
			}
			protected void OnValueChanged(string oldValue)
			{
				System.Delegate[] events;
				EventHandler<PropertyChangedEventArgs<Industry, string>> eventHandler;
				if ((object)(events = this._events) != null && (object)(eventHandler = (EventHandler<PropertyChangedEventArgs<Industry, string>>)events[1]) != null)
				{
					EventHandlerUtility.InvokeEventHandlerAsync<PropertyChangedEventArgs<Industry, string>>(eventHandler, this, new PropertyChangedEventArgs<Industry, string>(this, "Value", oldValue, this.Value), this._propertyChangedEventHandler);
				}
				else
				{
					this.OnPropertyChanged("Value");
				}
			}
			#endregion // Industry Property Change Events
			#region Industry Abstract Properties
			public abstract PackageBuilderContext Context
			{
				get;
			}
			[DataObjectField(false, false, false)]
			public abstract string Value
			{
				get;
				set;
			}
			[DataObjectField(false, false, true)]
			public abstract IEnumerable<Package> PackageViaIndustryCollection
			{
				get;
			}
			[DataObjectField(false, false, true)]
			public abstract IEnumerable<DataField> DataFieldViaIndustryCollection
			{
				get;
			}
			#endregion // Industry Abstract Properties
			#region Industry ToString Methods
			public override string ToString()
			{
				return this.ToString(null);
			}
			public virtual string ToString(IFormatProvider provider)
			{
				return string.Format(provider, @"Industry{0}{{{0}{1}Value = ""{2}""{0}}}", Environment.NewLine, @"	", this.Value);
			}
			#endregion // Industry ToString Methods
		}
		#endregion // Industry
		#region IHasPackageBuilderContext
		[System.CodeDom.Compiler.GeneratedCode("OIALtoPLiX", "1.0")]
		public interface IHasPackageBuilderContext
		{
			PackageBuilderContext Context
			{
				get;
			}
		}
		#endregion // IHasPackageBuilderContext
		#region IPackageBuilderContext
		[System.CodeDom.Compiler.GeneratedCode("OIALtoPLiX", "1.0")]
		public interface IPackageBuilderContext
		{
			Package GetPackageByPackageNameAndVersionExternalUniquenessConstraint(string Name, string Version);
			bool TryGetPackageByPackageNameAndVersionExternalUniquenessConstraint(string Name, string Version, out Package Package);
			DataProvider GetDataProviderByDataProviderNameAndVersionUniquenessConstraint(string Name, string Version);
			bool TryGetDataProviderByDataProviderNameAndVersionUniquenessConstraint(string Name, string Version, out DataProvider DataProvider);
			DataField GetDataFieldByName(string Name);
			bool TryGetDataFieldByName(string Name, out DataField DataField);
			Package CreatePackage(string Name, string Description, string Version, State State);
			IEnumerable<Package> PackageCollection
			{
				get;
			}
			State CreateState(string Value);
			IEnumerable<State> StateCollection
			{
				get;
			}
			DataProvider CreateDataProvider(string Name, string Owner, string Version, string SourceURL, State State);
			IEnumerable<DataProvider> DataProviderCollection
			{
				get;
			}
			DataField CreateDataField(bool Selected, decimal CostOfSale, string Name, DataProvider DataProvider, Industry Industry);
			IEnumerable<DataField> DataFieldCollection
			{
				get;
			}
			PackageDataField CreatePackageDataField(int Priority, string UnifiedName, bool Selected, Package Package, DataField DataField);
			IEnumerable<PackageDataField> PackageDataFieldCollection
			{
				get;
			}
			Industry CreateIndustry(string Value);
			IEnumerable<Industry> IndustryCollection
			{
				get;
			}
		}
		#endregion // IPackageBuilderContext
	}
}
