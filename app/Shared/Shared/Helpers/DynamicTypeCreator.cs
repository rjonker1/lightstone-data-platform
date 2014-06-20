using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

namespace DataPlatform.Shared.Helpers
{
    public class DynamicTypeCreator
    {
        public static Type CreateNewType(string newTypeName, Dictionary<string, Type> dict, Type baseClassType)
        {
            var noNewProperties = true;
            // create a dynamic assembly and module 
            var assemblyBldr = Thread.GetDomain().DefineDynamicAssembly(new AssemblyName("tmpAssembly"), AssemblyBuilderAccess.Run);
            var moduleBldr = assemblyBldr.DefineDynamicModule("tmpModule");

            // create a new type builder
            var typeBldr = moduleBldr.DefineType(newTypeName, TypeAttributes.Public | TypeAttributes.Class, baseClassType);

            // Loop over the attributes that will be used as the 
            // properties names in my new type
            var baseClassObj = Activator.CreateInstance(baseClassType);
            foreach (var word in dict)
            {
                var propertyName = word.Key;
                var propertyType = word.Value;

                //is it already in the base class?
                var srcPi = baseClassObj.GetType().GetProperty(propertyName);
                if (srcPi != null)
                    continue;

                // Generate a private field for the property
                var fldBldr = typeBldr.DefineField("_" + propertyName, propertyType, FieldAttributes.Private);
                // Generate a public property
                var prptyBldr = typeBldr.DefineProperty(propertyName, PropertyAttributes.None, propertyType, new[] { propertyType });
                // The property set and property get methods need the following attributes:
                const MethodAttributes getSetAttr = MethodAttributes.Public | MethodAttributes.HideBySig;
                // Define the "get" accessor method for newly created private field.
                var currGetPropMthdBldr = typeBldr.DefineMethod("get_value", getSetAttr, propertyType, null);

                // Intermediate Language stuff... as per Microsoft
                var currGetIl = currGetPropMthdBldr.GetILGenerator();
                currGetIl.Emit(OpCodes.Ldarg_0);
                currGetIl.Emit(OpCodes.Ldfld, fldBldr);
                currGetIl.Emit(OpCodes.Ret);

                // Define the "set" accessor method for the newly created private field.
                var currSetPropMthdBldr = typeBldr.DefineMethod("set_value", getSetAttr, null, new[] { propertyType });

                // More Intermediate Language stuff...
                var currSetIl = currSetPropMthdBldr.GetILGenerator();
                currSetIl.Emit(OpCodes.Ldarg_0);
                currSetIl.Emit(OpCodes.Ldarg_1);
                currSetIl.Emit(OpCodes.Stfld, fldBldr);
                currSetIl.Emit(OpCodes.Ret);

                // Assign the two methods created above to the 
                // PropertyBuilder's Set and Get
                prptyBldr.SetGetMethod(currGetPropMthdBldr);
                prptyBldr.SetSetMethod(currSetPropMthdBldr);
                noNewProperties = false; //I added at least one property
            }

            // Generate (and deliver) my type
            return noNewProperties ? baseClassType : typeBldr.CreateType();
        } 
    }
}