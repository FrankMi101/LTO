using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace AppOperate.ExecuteInterface
{
    public class PostingRequest<T> : IPosting<T>
    {
        public List<T> Position(object parameter)
        {
            string sp = RequestPostingExe.SPName("Position");
            return CommonExcute<T>.GeneralList(sp, parameter);
        }

        public List<T> Positions(object parameter)
        {
            string sp = RequestPostingExe.SPName("Positions");
            return CommonExcute<T>.GeneralList(sp, parameter);
        }

        public string Update(object parameter)
        {
            string sp = RequestPostingExe.SPName("Update");
            return CommonExcute<string>.GeneralValue(sp, parameter);
        }
    }

    public class PostingRequest : IPosting
    {
        public List<T> Position<T>(object parameter)
        {

            string sp = RequestPostingExe.SPName("Position");
            return CommonExcute<T>.GeneralList(sp, parameter);
        }

        public List<T> Positions<T>(object parameter)
        {
            string sp = RequestPostingExe.SPName("Positions");
            return CommonExcute<T>.GeneralList(sp, parameter);
        }

        public string Update(object parameter)
        {
            return RequestPostingExe.Update(parameter);

        }

    }


}
