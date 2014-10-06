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
    SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Scope = "member",
        Target = "LightstoneApp.Infrastructure.Data.Core.MemorySet`1.#.ctor(System.Collections.Generic.List`1<!0>)")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope = "member",
        Target =
            "LightstoneApp.Infrastructure.Data.Core.ExtendedRepository`1.#GetFilteredElements`2(System.Linq.Expressions.Expression`1<System.Func`2<!!0,System.Boolean>>,System.Linq.Expressions.Expression`1<System.Func`2<!!0,!!1>>,System.Boolean)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope = "member",
        Target =
            "LightstoneApp.Infrastructure.Data.Core.ExtendedRepository`1.#GetFilteredElements`1(System.Linq.Expressions.Expression`1<System.Func`2<!!0,System.Boolean>>)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope = "member",
        Target =
            "LightstoneApp.Infrastructure.Data.Core.ExtendedRepository`1.#GetPagedElements`2(System.Int32,System.Int32,System.Linq.Expressions.Expression`1<System.Func`2<!!0,!!1>>,System.Boolean)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope = "member",
        Target =
            "LightstoneApp.Infrastructure.Data.Core.Extensions.IQueryableExtensions.#Include`1(System.Linq.IQueryable`1<!!0>,System.Linq.Expressions.Expression`1<System.Func`2<!!0,System.Object>>)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope = "member",
        Target =
            "LightstoneApp.Infrastructure.Data.Core.Repository`1.#GetFilteredElements`1(System.Linq.Expressions.Expression`1<System.Func`2<!0,System.Boolean>>,System.Linq.Expressions.Expression`1<System.Func`2<!0,!!0>>,System.Boolean)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope = "member",
        Target =
            "LightstoneApp.Infrastructure.Data.Core.Repository`1.#GetFilteredElements`1(System.Linq.Expressions.Expression`1<System.Func`2<!0,System.Boolean>>,System.Int32,System.Int32,System.Linq.Expressions.Expression`1<System.Func`2<!0,!!0>>,System.Boolean)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope = "member",
        Target =
            "LightstoneApp.Infrastructure.Data.Core.Repository`1.#GetPagedElements`1(System.Int32,System.Int32,System.Linq.Expressions.Expression`1<System.Func`2<!0,!!0>>,System.Boolean)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope = "member",
        Target =
            "LightstoneApp.Infrastructure.Data.Core.Repository`1.#GetPagedElements`1(System.Int32,System.Int32,System.Linq.Expressions.Expression`1<System.Func`2<!0,!!0>>,LightstoneApp.Domain.Core.Specification.ISpecification`1<!0>,System.Boolean)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1061:DoNotHideBaseClassMethods", Scope = "member",
        Target =
            "LightstoneApp.Infrastructure.Data.Core.ExtendedRepository`1.#GetBySpec`1(LightstoneApp.Domain.Core.Specification.ISpecification`1<!!0>)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1061:DoNotHideBaseClassMethods", Scope = "member",
        Target =
            "LightstoneApp.Infrastructure.Data.Core.ExtendedRepository`1.#GetFilteredElements`2(System.Linq.Expressions.Expression`1<System.Func`2<!!0,System.Boolean>>,System.Linq.Expressions.Expression`1<System.Func`2<!!0,!!1>>,System.Boolean)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1061:DoNotHideBaseClassMethods", Scope = "member",
        Target =
            "LightstoneApp.Infrastructure.Data.Core.ExtendedRepository`1.#GetFilteredElements`1(System.Linq.Expressions.Expression`1<System.Func`2<!!0,System.Boolean>>)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1061:DoNotHideBaseClassMethods", Scope = "member",
        Target =
            "LightstoneApp.Infrastructure.Data.Core.ExtendedRepository`1.#GetPagedElements`2(System.Int32,System.Int32,System.Linq.Expressions.Expression`1<System.Func`2<!!0,!!1>>,System.Boolean)"
        )]
[assembly:
    SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Scope = "member",
        Target =
            "LightstoneApp.Infrastructure.Data.Core.ExtendedRepository`1.#.ctor(LightstoneApp.Infrastructure.Data.Core.IQueryableUnitOfWork,LightstoneApp.Infrastructure.CrossCutting.Logging.ITraceManager)"
        )]
[assembly:
    SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Scope = "member",
        Target =
            "LightstoneApp.Infrastructure.Data.Core.Repository`1.#.ctor(LightstoneApp.Infrastructure.Data.Core.IQueryableUnitOfWork,LightstoneApp.Infrastructure.CrossCutting.Logging.ITraceManager)"
        )]