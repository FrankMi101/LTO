using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace AppOperate
{

    public static class Factory
    {
        public static T Get<T>() where T : class
        {
            var tName = typeof(T).ToString();
            //  string typeName = ConfigurationManager.AppSettings[tName];
            Type resolvedType = Type.GetType(tName);
            object instance = Activator.CreateInstance(resolvedType);
            return instance as T;
          //  return (T) instance ;
        }


        public static ICommonList<T> GetClass<T>() where T : class
        {
            var tName = typeof(T).ToString();
            switch (tName)
            {
                case "PositionListRequesting":
                    return new CommonList<T>();
                case "CommonList":
                    return new CommonList<T>();
                default:
                    return new CommonList<T>();

            }
        }

    }
    public class ObjClassFactory
    {
        
       
        public static ICommonList<T> GetListClassObj<T>()
        {
            return new CommonList<T>();
        }

        public static ICommonOperation<T> GetOperationClassObj<T>()
        {
            return new CommonOperation<T>();
        }
        public static ICommonParameter GetParametersObj<T>()
        {
            return new CommonParameter<T>();
        }

        public static IParametersForOperation GetParametersObj()
        {
            return new ParametersForOperation();
        }
      
    }
}
