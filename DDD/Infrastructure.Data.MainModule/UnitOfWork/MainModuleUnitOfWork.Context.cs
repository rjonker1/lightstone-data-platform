﻿using System.Data.Objects;
#pragma warning disable 1591 // this is for supress no xml comments in public members warnings 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data.EntityClient;
using System.Data.Metadata.Edm;
using System.Data.Objects.DataClasses;

using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;



using LightstoneApp.Domain.Core.Entities;
using LightstoneApp.Domain.Core;
using LightstoneApp.Domain.MainModule.Entities;
using System.Reflection;

namespace LightstoneApp.Infrastructure.Data.MainModule.UnitOfWork
{
    [System.Diagnostics.DebuggerNonUserCode()]
    public partial class MainModuleUnitOfWork : ObjectContext,IMainModuleUnitOfWork
    {
        public const string ConnectionString = "name=MainModuleUnitOfWork";
        public const string ContainerName = "MainModuleUnitOfWork";
    
        #region Constructors
    	
        public MainModuleUnitOfWork()
            : base(ConnectionString, ContainerName)
        {
            Initialize();
        }
    
        public MainModuleUnitOfWork(string connectionString)
            : base(connectionString, ContainerName)
        {
            Initialize();
        }
    
        public MainModuleUnitOfWork(EntityConnection connection)
            : base(connection, ContainerName)
        {
            Initialize();
        }
    
        private void Initialize()
        {
            // Creating proxies requires the use of the ProxyDataContractResolver and
            // may allow lazy loading which can expand the loaded graph during serialization.
            ContextOptions.ProxyCreationEnabled = false;
    		ContextOptions.LazyLoadingEnabled = false;
            ObjectMaterialized += new ObjectMaterializedEventHandler(HandleObjectMaterialized);
        }
    
        private void HandleObjectMaterialized(object sender, ObjectMaterializedEventArgs e)
        {
            var entity = e.Entity as IObjectWithChangeTracker;
            if (entity != null)
            {
                bool changeTrackingEnabled = entity.ChangeTracker.ChangeTrackingEnabled;
                try
                {
                    entity.MarkAsUnchanged();
                }
                finally
                {
                    entity.ChangeTracker.ChangeTrackingEnabled = changeTrackingEnabled;
                }
                this.StoreReferenceKeyValues(entity);
            }
        }
    
        #endregion
        #region IMainModuleUnitOfWork
    	
    	public  IObjectSet<TEntity> CreateSet<TEntity>() 
    		where TEntity : class,IObjectWithChangeTracker
    	{
    		return base.CreateObjectSet<TEntity>() as IObjectSet<TEntity>;
    	}
    	public void RegisterChanges<TEntity>(TEntity item)
    		where TEntity : class, IObjectWithChangeTracker
    	{
    		this.CreateObjectSet<TEntity>().ApplyChanges(item);
    	}
    	public void CommitAndRefreshChanges()
    	{
    		try
    		{
    			//Default option is DetectChangesBeforeSave
    			base.SaveChanges();
    			
    			//accept all changes in STE entities attached in context
                IEnumerable<IObjectWithChangeTracker> steEntities = (from entry in 
    																	this.ObjectStateManager.GetObjectStateEntries(~EntityState.Detached)
                                                                     where 
    																 	entry.Entity != null 
    																 && 
    																 	(entry.Entity as IObjectWithChangeTracker != null)
                                                                     select
    																 	entry.Entity as IObjectWithChangeTracker);
    
                steEntities.ToList().ForEach(ste => ste.MarkAsUnchanged());
    		}
    		catch (OptimisticConcurrencyException ex)
    		{
    			
    			//if client wins refresh data ( queries database and adapt original values
    			//and re-save changes in client
    			base.Refresh(RefreshMode.ClientWins, ex.StateEntries.Select(se => se.Entity));
    			
    			base.SaveChanges(); 
    			
    			//accept all changes in STE entities attached in context
                IEnumerable<IObjectWithChangeTracker> steEntities = (from entry in 
    																	this.ObjectStateManager.GetObjectStateEntries(~EntityState.Detached)
                                                                     where 
    																 	entry.Entity != null 
    																 && 
    																 	(entry.Entity as IObjectWithChangeTracker != null)
                                                                     select
    																 	entry.Entity as IObjectWithChangeTracker);
    
                steEntities.ToList().ForEach(ste => ste.MarkAsUnchanged());
    		}
    	}
    	public  void Commit()
    	{
    		//Default option is DetectChangesBeforeSave
    		base.SaveChanges();
    		
    		//accept all changes in STE entities attached in context
    		IEnumerable<IObjectWithChangeTracker> steEntities = (from entry in 
    																	this.ObjectStateManager.GetObjectStateEntries(~EntityState.Detached)
                                                                     where 
    																 	entry.Entity != null 
    																 && 
    																 	(entry.Entity as IObjectWithChangeTracker != null)
                                                                     select
    																 	entry.Entity as IObjectWithChangeTracker);
    
    		steEntities.ToList().ForEach(ste => ste.MarkAsUnchanged());
    	}
    	public void RollbackChanges()
    	{
    		//Refresh context and override changes
                
    		IEnumerable<object> itemsToRefresh = base.ObjectStateManager.GetObjectStateEntries(EntityState.Modified)
                                                                        .Where(ose=>!ose.IsRelationship && ose.Entity != null)
                                                                        .Select(ose=>ose.Entity);
            base.Refresh(RefreshMode.StoreWins, itemsToRefresh);
    	}
    	public IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters)
        {
    		return base.ExecuteStoreQuery<TEntity>(sqlQuery, parameters);
       	}
    
    	public int ExecuteCommand(string sqlCommand, params object[] parameters)
    	{
    		return base.ExecuteStoreCommand(sqlCommand, parameters);
    	}
    	

        #endregion
        #region ObjectSet Properties
    
        public IObjectSet<BankAccount> BankAccounts
        {
            get { return _bankAccounts  ?? (_bankAccounts = CreateObjectSet<BankAccount>("BankAccounts")); }
        }
        private ObjectSet<BankAccount> _bankAccounts;
    
        public IObjectSet<BankTransfer> BankTransfers
        {
            get { return _bankTransfers  ?? (_bankTransfers = CreateObjectSet<BankTransfer>("BankTransfers")); }
        }
        private ObjectSet<BankTransfer> _bankTransfers;
    
        public IObjectSet<Country> Countries
        {
            get { return _countries  ?? (_countries = CreateObjectSet<Country>("Countries")); }
        }
        private ObjectSet<Country> _countries;
    
        public IObjectSet<Customer> Customers
        {
            get { return _customers  ?? (_customers = CreateObjectSet<Customer>("Customers")); }
        }
        private ObjectSet<Customer> _customers;
    
        public IObjectSet<Order> Orders
        {
            get { return _orders  ?? (_orders = CreateObjectSet<Order>("Orders")); }
        }
        private ObjectSet<Order> _orders;
    
        public IObjectSet<OrderDetail> OrderDetails
        {
            get { return _orderDetails  ?? (_orderDetails = CreateObjectSet<OrderDetail>("OrderDetails")); }
        }
        private ObjectSet<OrderDetail> _orderDetails;
    
        public IObjectSet<Product> Products
        {
            get { return _products  ?? (_products = CreateObjectSet<Product>("Products")); }
        }
        private ObjectSet<Product> _products;
    
        public IObjectSet<CustomerPicture> CustomerPictures
        {
            get { return _customerPictures  ?? (_customerPictures = CreateObjectSet<CustomerPicture>("CustomerPictures")); }
        }
        private ObjectSet<CustomerPicture> _customerPictures;

        #endregion
    }
    
}
