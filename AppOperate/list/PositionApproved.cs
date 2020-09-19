using ClassLibrary;
using DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{
    public class PositionApproved
    {
        public static string SavePosition(PositionApprove position)
        {

            try
            {
                //  StaffProfile parameter = new StaffProfile { Operate = operate, UserID = userID, CPNum = CPNum, Action = action };
                string paramaters = "@Operate,@UserID,@SchoolYear,@SchoolCode,@PositionID,@PositionType,@PositionTitle,@PositionLevel, @Qualification, @Description,@FTE,@FTEPanel, @StartDate,@EndDate, @DatePublish,@DateApplyStart,@DateDeadline, @Comments, @ReplaceTeacherID, @ReplaceTeacher";
                string sp = "dbo.tcdsb_LTO_PositionDetails_Approve " + paramaters;
                string result = GeneralDataAccess.TextValue(sp, position);
                //  return SignatureProcess.SignoffResult(operate, userID, userRole, schoolYear, schoolCode, actionType, actionDate);
                return result;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return "Failed";
            }

        }
    }
}
