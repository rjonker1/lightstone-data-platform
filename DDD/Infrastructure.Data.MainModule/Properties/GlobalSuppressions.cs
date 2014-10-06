// This file is used by Code Analysis to maintain SuppressMessage 
// attributes that are applied to this project. 
// Project-level suppressions either have no target or are given 
// a specific target and scoped to a namespace, type, member, etc. 
//
// To add a suppression to this file, right-click the message in the 
// Error List, point to "Suppress Message(s)", and click 
// "In Project Suppression File". 
// You do not need to add suppressions to this file manually. 

using System.Diagnostics.CodeAnalysis;

[assembly:
    SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly", Scope = "type",
        Target = "LightstoneApp.Infrastructure.Data.MainModule.UnitOfWork.MainModuleUnitOfWork")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "changeTracker", Scope = "member",
        Target =
            "LightstoneApp.Infrastructure.Data.MainModule.Context.ObjectContextExtensions.#ApplyChanges`1(System.Data.Objects.ObjectContext,System.String,!!0)"
        )]
[assembly:
    SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Scope = "member",
        Target =
            "LightstoneApp.Infrastructure.Data.MainModule.Context.ObjectContextExtensions.#HandleRelationshipKeys(System.Data.Objects.ObjectContext,LightstoneApp.Infrastructure.Data.MainModule.Context.ObjectContextExtensions+EntityIndex,LightstoneApp.Infrastructure.Data.MainModule.Context.ObjectContextExtensions+RelationshipSet,LightstoneApp.Domain.Core.Entities.IObjectWithChangeTracker)"
        )]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "foundKeyMembers",
        Scope = "member",
        Target =
            "LightstoneApp.Infrastructure.Data.MainModule.Context.ObjectContextExtensions.#MoveSavedReferenceKey(System.Data.Objects.DataClasses.EntityReference,System.Object,System.Data.Metadata.Edm.NavigationProperty,System.Collections.Generic.IDictionary`2<System.String,System.Object>,System.Collections.Generic.IDictionary`2<System.String,System.Object>)"
        )]