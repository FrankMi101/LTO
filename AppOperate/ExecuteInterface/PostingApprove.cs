using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppOperate;
using AppOperate.ExecuteInterface;


namespace AppOperate.ExecuteInterface
{
   public class PostingApprove<T> : IPosting<T>
    {

        public List<T> Position(object parameter)
        {
            string sp = PostingPositionExe.SPName("Position");
            return CommonExcute<T>.GeneralList(sp, parameter);
        }

        public List<T> Positions(object parameter)
        {
            string sp = PostingPositionExe.SPName("Positions");
            return CommonExcute<T>.GeneralList(sp, parameter);
        }

        public string Update(object parameter)
        {
            string sp = PostingPositionExe.SPName("Update");

            return CommonExcute<string>.GeneralValue(sp, parameter);

        }
    }
}

public class PostingApprove : IPosting
{
    public List<T> Positions<T>(object parameter)
    {
        string sp = PostingPositionExe.SPName("Positions");
        return CommonExcute<T>.GeneralList(sp, parameter);
    }

    public List<T> Position<T>(object parameter)
    {
        string sp = PostingPositionExe.SPName("Position");
        return CommonExcute<T>.GeneralList(sp, parameter);
    }

    public string Update(object parameter)
    {
        throw new NotImplementedException();
    }
}

