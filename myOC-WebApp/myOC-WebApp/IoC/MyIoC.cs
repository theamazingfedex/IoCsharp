using myOC_WebApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace myOC_WebApp.IoC
{
    public static class MyIoC
    {
        // Readonly dictionary so that instantiation of the dictionary only happens once.
        private static readonly Dictionary<Type, Type> types = new Dictionary<Type, Type>();
        private static readonly Dictionary<Type, Object> objects = new Dictionary<Type, object>();

        // Register types to return transient instances of objects
        public static void Register<IType, OType>()
        {
            types[typeof(IType)] = typeof(OType);
            System.Diagnostics.Debug.WriteLine("++++++++++ REGISTERED TRANSIENT TYPE :: <" + typeof(IType).Name + ", " + typeof(OType).Name + ">");
        }

        // Another way to register transient 
        public static void Register(Type IType, Type OType)
        {
            types[IType] = OType;
            System.Diagnostics.Debug.WriteLine("++++++++++ REGISTERED TRANSIENT TYPE :: <" + IType.Name + ", " + OType.Name + ">");
        }

        // Register types to return a singleton instance
        public static void Register(Type IType, Type OType, object instance)
        {
            objects[IType] = instance;
            System.Diagnostics.Debug.WriteLine("++++++++++ REGISTERED SINGLETON TYPE :: <" + IType.Name + ", " + OType.Name + ">");
        }

        // Another way to register a singleton
        public static void Register<IType, OType>(OType instance)
        {
            objects[typeof(IType)] = instance;
            System.Diagnostics.Debug.WriteLine("++++++++++ REGISTERED SINGLETON TYPE :: <" + typeof(IType).Name + ", " + typeof(OType).Name + ">");
        }

        // Resolve a contract type and return the stored dependency that matches it
        public static T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        // Resolve a type and return the object that is registered to the contract
        public static object Resolve(Type contract)
        {
            System.Diagnostics.Debug.WriteLine(" ---------- RESOLVING CONTRACT :: " + contract.Name);
            if (objects.ContainsKey(contract))
            {
                // Returning singleton instance of the contract
                return objects[contract];
            }
            else if (types.ContainsKey(contract))
            {
                Type implementation = types[contract];
                // Returning new (transient) implementation of the contract
                return TheObjectOf(implementation);
            }
            else // if the IoC Container has not registered the contract, throw an exception.
            {
                throw new CustomException("FATAL: " + contract.FullName + " does not exist in the IoC Container. Has it been registered?");
            }
        }

        // Returns an instance of an object type passed in. Tries to Resolve() nested dependencies.
        public static object TheObjectOf(Type implementation)
        {
            ConstructorInfo constructor;
            try {
                constructor = implementation.GetConstructors()[0];
            } catch (IndexOutOfRangeException ex) {
                throw new CustomException("FATAL: Could not find a constructor for the specified type " + implementation.Name, ex);
            }
            ParameterInfo[] constructorParameters = constructor.GetParameters();
            if (constructorParameters.Length == 0)
            {
                // if a parameterless constructor exists for the type, use it and return a new instance
                return Activator.CreateInstance(implementation);
            }
            // Otherwise, if the constructor has parameters, resolve those dependencies.
            List<object> parameters = new List<object>(constructorParameters.Length);
            foreach (ParameterInfo parameterInfo in constructorParameters)
            {
                try // to Resolve() nested dependencies
                {
                    parameters.Add(Resolve(parameterInfo.ParameterType));
                }
                catch (KeyNotFoundException ex)
                {
                    throw new CustomException("FATAL: " + implementation.FullName + " could not resolve its dependencies. Have they been registered?", ex);
                }
            }
            return constructor.Invoke(parameters.ToArray());
        }
    }
}