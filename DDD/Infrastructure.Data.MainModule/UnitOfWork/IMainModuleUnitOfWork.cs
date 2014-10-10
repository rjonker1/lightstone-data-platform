﻿#pragma warning disable 1591 // this is for supress no xml comments in public members warnings 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data.EntityClient;
using System.Data.Metadata.Edm;
using System.Data.Objects.DataClasses;
using System.Data.Objects;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;



using LightstoneApp.Infrastructure.Data.Core;
using LightstoneApp.Domain.MainModule.Entities;

namespace LightstoneApp.Infrastructure.Data.MainModule.UnitOfWork
{
    
    ///<sumary>
    ///Base contract for context in Main Module 
    ///</sumary>
    public interface IMainModuleUnitOfWork :IQueryableUnitOfWork
    {
       
        #region ObjectSet Properties
    
        IObjectSet<BankAccount> BankAccounts{get;}
        
    
        IObjectSet<BankTransfer> BankTransfers{get;}
        
    
        IObjectSet<Country> Countries{get;}
        
    
        IObjectSet<Customer> Customers{get;}
        
    
        IObjectSet<Order> Orders{get;}
        
    
        IObjectSet<OrderDetail> OrderDetails{get;}
        
    
        IObjectSet<Product> Products{get;}
        
    
        IObjectSet<CustomerPicture> CustomerPictures{get;}
        

        #endregion
    
    }
}
	
