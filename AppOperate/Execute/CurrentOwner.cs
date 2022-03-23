using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{
    public class CurrentOwner
    {
        public static Contact PositionOwner(string jsonFile, string userId)
        {
            return JsonFileReader.CurrentOwner(jsonFile, userId);

        }
    }
}
