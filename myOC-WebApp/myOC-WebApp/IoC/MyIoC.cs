using myOC_WebApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace myOC_WebApp.IoC
{
    public static class MyIoC
    {
        private static readonly Dictionary<Type, Type> types = new Dictionary<Type, Type>();
        private static readonly Dictionary<Type, Object> objects = new Dictionary<Type, object>();

        public static void Register<IType, OType>()
        {
            types[typeof(IType)] = typeof(OType);
            //Register<IType, OType>((OType)Resolve(typeof(IType)));
            System.Diagnostics.Debug.WriteLine("++++++++++ REGISTERED TYPES :: " + types.ToString());
        }
        public static void Register<IType, OType>(OType instance)
        {
            objects[typeof(IType)] = instance;
        }

        public static T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        public static object Resolve(Type contract)
        {
            System.Diagnostics.Debug.WriteLine(" ---------- RESOLVING CONTRACT :: " + contract.FullName);
            if (objects.ContainsKey(contract))
            {
                return objects[contract];
            }
            else if (types.ContainsKey(contract))
            {
                Type implementation = types[contract];
                return TheObjectOf(implementation);
            }
            else
            {
                return TheObjectOf(contract);
            }
        }

        private static object TheObjectOf(Type implementation)
        {
            ConstructorInfo constructor = implementation.GetConstructors()[0];
            ParameterInfo[] constructorParameters = constructor.GetParameters();
            if (constructorParameters.Length == 0)
            {
                return Activator.CreateInstance(implementation);
            }
            List<object> parameters = new List<object>(constructorParameters.Length);
            foreach (ParameterInfo parameterInfo in constructorParameters)
            {
                //try {
                    parameters.Add(Resolve(parameterInfo.ParameterType));
                //}
                //catch (KeyNotFoundException ex)
                //{
                //    new Logger().Log(ex.Message);
                //    parameters.Add(TheObjectOf(parameterInfo.ParameterType));
                //}
            }
            return constructor.Invoke(parameters.ToArray());
        }
    }
}