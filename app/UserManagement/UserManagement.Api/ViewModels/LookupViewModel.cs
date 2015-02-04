using System;

namespace UserManagement.Api.ViewModels
{
    public class LookupViewModel
    {
        public string Name { get; set; }
        public string AssemblyQualifiedName { get; set; }

        public LookupViewModel(Type type)
        {
            Name = type.Name;
            AssemblyQualifiedName = type.AssemblyQualifiedName;
        }
    }
}