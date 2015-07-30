using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myOC_WebApp.IoC
{
    public class MyIoC
    {
        private static Dictionary<Type, Type> types = new Dictionary<Type, Type>();
        private static Dictionary<Type, Object> objects = new Dictionary<Type, object>();

        public static void Register<IType, OType>()
        {
            types[typeof(IType)] = typeof(OType);
        }
        public static void Register<IType, OType>(OType instance)
        {
            objects[typeof(IType)] = instance;
        }
        public static object Resolve(Type contract)
        {
            return "cheese!!<3!!";
        }
    }
}