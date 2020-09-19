using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace AppOperate.ExecuteInterface
{
    public class PostingPublish<T> : IPosting<T>
    {
        public List<T> Position(object parameter)
        {
            string sp = PublishPositionExe.SpName("Position");
            return CommonExcute<T>.GeneralList(sp, parameter);
        }

        public List<T> Positions(object parameter)
        {
            string sp = PublishPositionExe.SpName("Positions");
            return CommonExcute<T>.GeneralList(sp, parameter);
        }

        public string Update(object parameter)
        {
            string sp = PublishPositionExe.SpName("Update");
            
            return CommonExcute<string>.GeneralValue(sp, parameter);
            
        }
 
    }

    public class PostingPublish : IPosting
    {
        public List<T> Position<T>(object parameter)
        {

            string sp = PublishPositionExe.SpName("Position");
            return CommonExcute<T>.GeneralList(sp, parameter);

           // return PublishPositionExe.Position(parameter);
        }

        public List<T> Positions<T>(object parameter)
        {
            string sp = PublishPositionExe.SpName("Positions");
            return CommonExcute<T>.GeneralList(sp, parameter);
        }

        public string Update(object parameter)
        {
            return PublishPositionExe.Update(parameter);

        }

    }
}
