using System.Linq;

namespace AppOperate
{
    public class GetSpNameFormJsonFile
    {
        public static string SPName(string action, string page)
        {
            // When action is a direct store procedure and parameter such as dbo.tcdsb_LTO_PageGeneral_SpecificOne @Operate, @IDS,@SchoolYear.
            // should reture the action directly when exception happend.

            string jsonFile = SPSource.SPFile;
            return CommonExcute.SPNameAndParameters(jsonFile, page, action);

        }

    }
}
