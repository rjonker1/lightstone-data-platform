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
    SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member",
        Target =
            "LightstoneApp.Infrastructure.CrossCutting.IoC.Unity.IoCUnityContainer.#ConfigureRootContainer(Microsoft.Practices.Unity.IUnityContainer)"
        )]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member",
        Target =
            "LightstoneApp.Infrastructure.CrossCutting.IoC.Unity.IoCUnityContainer.#ConfigureFakeContainer(Microsoft.Practices.Unity.IUnityContainer)"
        )]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline", Scope = "member",
        Target = "LightstoneApp.Infrastructure.CrossCutting.IoC.IoCFactory.#.cctor()")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member",
        Target =
            "LightstoneApp.Infrastructure.CrossCutting.IoC.Unity.IoCUnityContainer.#ConfigureRealContainer(Microsoft.Practices.Unity.IUnityContainer)"
        )]