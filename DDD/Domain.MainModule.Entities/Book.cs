using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

#pragma warning disable 1591 // this is for supress no xml comments in public members warnings 

using LightstoneApp.Domain.Core.Entities;

namespace LightstoneApp.Domain.MainModule.Entities
{
    [DataContract(IsReference = true)]
    [System.CodeDom.Compiler.GeneratedCode("STE-EF",".NET 4.0")]

    public partial class Book : Product, IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public string Editor
        {
            get { return _editor; }
            set
            {
                if (_editor != value)
                {
                    _editor = value;
                    OnPropertyChanged("Editor");
                }
            }
        }
        private string _editor;

        #endregion
        #region ChangeTracking
    
        protected override void ClearNavigationProperties()
        {
            base.ClearNavigationProperties();
        }

        #endregion
    }
}
