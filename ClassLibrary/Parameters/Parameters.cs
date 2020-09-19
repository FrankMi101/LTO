using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Parameters <T>  :IParameters <T>
    {
        public Parameters() { }

        public IParameters<T> GetParamaterTypebyT()
        {
             var objName = (typeof(T)).Name;
            switch (objName)
            {
                case "NewRequest":
                    return  new Parameters<T>();
                case "NewPublish":
                    return new Parameters<T>();
                case "Request":
                    return new Parameters<T>();
                case "Publish":
                    return new Parameters<T>();
                default:
                   return  new Parameters<T>();

            }


        }
    }
    
}
