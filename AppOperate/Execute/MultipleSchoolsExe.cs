using ClassLibrary;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate 
{
   public  class MultipleSchoolsExe
    {

        public MultipleSchoolsExe()
        { }
        public static string SPName(string action)
        {
            return GetSP(action);
        }
        public static List<MultipleSchool> MultipleSchools(object parameter)
        {
            string SP = GetSP("MultipleSchools");
            return CommonExcute<MultipleSchool>.GeneralList(SP, parameter);
        }
      
  
        public static string Update(object parameter)
        {
            string SP = GetSP("Update");
            return CommonExcute<string>.GeneralValue(SP, parameter);
        }
        public static string Delete(object parameter)
        {
            string SP = GetSP("Insert");
            return CommonExcute<string>.GeneralValue(SP, parameter);
        }
   
        private static string GetSP(string action)
        {
            if (SPSource.SPFile == "")
            { return GetSPInClass(action); }
            else
            { return GetSPFromJsonFile(action); }

        }
        private static string GetSPInClass(string action)
        {
            string parameter = " @UserID, @SchoolYear, @PositionID, @IDs,@SchoolCode,@PositionTitle,@FTE,@Description";
 
            switch (action)
            {
                 case "Insert":
                    return "dbo.tcdsb_LTO_PagePublish_MultipleSchool" + parameter;
                  case "Update":
                    return "dbo.tcdsb_LTO_PagePublish_MultipleSchool" + parameter;
                case "MultipleSchools":
                    return "dbo.tcdsb_LTO_PagePublish_MultipleSchool" + " @UserID, @SchoolYear, @PositionID";
                  default:
                    return action;

            }

        }
        private static string GetSPFromJsonFile(string action)
        {
  
            return GetSpNameFormJsonFile.SPName(action, "MultipleSchools");
        }
    }
}
