using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace AppOperate.ExecuteInterface
{
   public interface IPosting<T>
   {
       List<T> Positions(object parameter);

       List<T> Position(object parameter);
       string Update(object parameter);

   }

   public interface IPosting
   {
       List<T> Positions<T>(object parameter);
       List<T> Position<T>(object parameter);
       string Update(object parameter);


   }

  
}
