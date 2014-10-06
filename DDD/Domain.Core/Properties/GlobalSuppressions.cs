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
    SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope = "member",
        Target =
            "LightstoneApp.Domain.Core.IExtendedRepository`1.#GetFilteredElements`1(System.Linq.Expressions.Expression`1<System.Func`2<!!0,System.Boolean>>)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope = "member",
        Target =
            "LightstoneApp.Domain.Core.IExtendedRepository`1.#GetFilteredElements`1(System.Linq.Expressions.Expression`1<System.Func`2<!0,System.Boolean>>,System.Linq.Expressions.Expression`1<System.Func`2<!0,!!0>>,System.Boolean)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope = "member",
        Target =
            "LightstoneApp.Domain.Core.IExtendedRepository`1.#GetFilteredElements`2(System.Linq.Expressions.Expression`1<System.Func`2<!!0,System.Boolean>>,System.Linq.Expressions.Expression`1<System.Func`2<!!0,!!1>>,System.Boolean)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope = "member",
        Target =
            "LightstoneApp.Domain.Core.IExtendedRepository`1.#GetPagedElements`2(System.Int32,System.Int32,System.Linq.Expressions.Expression`1<System.Func`2<!!0,!!1>>,System.Boolean)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Scope = "member",
        Target = "LightstoneApp.Domain.Core.IRepository`1.#GetAll()")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope = "member",
        Target =
            "LightstoneApp.Domain.Core.IRepository`1.#GetFilteredElements(System.Linq.Expressions.Expression`1<System.Func`2<!0,System.Boolean>>)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope = "member",
        Target =
            "LightstoneApp.Domain.Core.IRepository`1.#GetFilteredElements`1(System.Linq.Expressions.Expression`1<System.Func`2<!0,System.Boolean>>,System.Int32,System.Int32,System.Linq.Expressions.Expression`1<System.Func`2<!0,!!0>>,System.Boolean)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope = "member",
        Target =
            "LightstoneApp.Domain.Core.IRepository`1.#GetPagedElements`1(System.Int32,System.Int32,System.Linq.Expressions.Expression`1<System.Func`2<!0,!!0>>,LightstoneApp.Domain.Core.Specification.ISpecification`1<!0>,System.Boolean)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope = "member",
        Target =
            "LightstoneApp.Domain.Core.IRepository`1.#GetPagedElements`1(System.Int32,System.Int32,System.Linq.Expressions.Expression`1<System.Func`2<!0,!!0>>,System.Boolean)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope = "member",
        Target =
            "LightstoneApp.Domain.Core.Specification.DirectSpecification`1.#.ctor(System.Linq.Expressions.Expression`1<System.Func`2<!0,System.Boolean>>)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope = "member",
        Target =
            "LightstoneApp.Domain.Core.Specification.ExpressionBuilder.#And`1(System.Linq.Expressions.Expression`1<System.Func`2<!!0,System.Boolean>>,System.Linq.Expressions.Expression`1<System.Func`2<!!0,System.Boolean>>)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Scope = "member",
        Target =
            "LightstoneApp.Domain.Core.Specification.ExpressionBuilder.#Compose`1(System.Linq.Expressions.Expression`1<!!0>,System.Linq.Expressions.Expression`1<!!0>,System.Func`3<System.Linq.Expressions.Expression,System.Linq.Expressions.Expression,System.Linq.Expressions.Expression>)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope = "member",
        Target =
            "LightstoneApp.Domain.Core.Specification.ExpressionBuilder.#Or`1(System.Linq.Expressions.Expression`1<System.Func`2<!!0,System.Boolean>>,System.Linq.Expressions.Expression`1<System.Func`2<!!0,System.Boolean>>)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope = "member",
        Target = "LightstoneApp.Domain.Core.Specification.ISpecification`1.#SatisfiedBy()")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope = "member",
        Target =
            "LightstoneApp.Domain.Core.Specification.NotSpecification`1.#.ctor(System.Linq.Expressions.Expression`1<System.Func`2<!0,System.Boolean>>)"
        )]
[assembly:
    SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates", Scope = "member",
        Target =
            "LightstoneApp.Domain.Core.Specification.Specification`1.#op_BitwiseOr(LightstoneApp.Domain.Core.Specification.Specification`1<!0>,LightstoneApp.Domain.Core.Specification.Specification`1<!0>)"
        )]
[assembly:
    SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates", Scope = "member",
        Target =
            "LightstoneApp.Domain.Core.Specification.Specification`1.#op_False(LightstoneApp.Domain.Core.Specification.Specification`1<!0>)"
        )]
[assembly:
    SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "specification", Scope = "member",
        Target =
            "LightstoneApp.Domain.Core.Specification.Specification`1.#op_False(LightstoneApp.Domain.Core.Specification.Specification`1<!0>)"
        )]
[assembly:
    SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates", Scope = "member",
        Target =
            "LightstoneApp.Domain.Core.Specification.Specification`1.#op_LogicalNot(LightstoneApp.Domain.Core.Specification.Specification`1<!0>)"
        )]
[assembly:
    SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates", Scope = "member",
        Target =
            "LightstoneApp.Domain.Core.Specification.Specification`1.#op_True(LightstoneApp.Domain.Core.Specification.Specification`1<!0>)"
        )]
[assembly:
    SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates", Scope = "member",
        Target =
            "LightstoneApp.Domain.Core.Specification.Specification`1.#op_BitwiseAnd(LightstoneApp.Domain.Core.Specification.Specification`1<!0>,LightstoneApp.Domain.Core.Specification.Specification`1<!0>)"
        )]