using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using DataAccess.Common;

namespace AppOperate
{
    public class PositionApproveed : IPositionRepository<PositionApprove, int>
    {
        public IList<PositionApprove> GetPosition(int requestID)
        {
            try
            {
                string sp = "dbo.tcdsb_LTO_PositionDetails_RequestbyID @SchoolYear, @PositionID";
                var parameter = new ParameterCL() { PositionID = requestID, SchoolYear = "" };
               // List<PositionApprove> position1 = CommonExcute<PositionApprove>.GeneralList(sp, parameter);
               List<PositionApprove> position1 = GeneralDataAccess.GetListofTypeT<PositionApprove>(sp, parameter);
                return position1;
            }
            catch (System.Exception ex)
            {
                string em = ex.Message;
                return null;
            }
        }

        public IList<PositionApprove> GetPosition(ParametersForPosition parameter)
        {
            try
            {
                string sp = "dbo.tcdsb_LTO_PositionDetails_RequestbyID @SchoolYear, @PositionID";
                // var parameter = new ParameterCL() { PositionID = positionID, SchoolYear = "" };
              //  List<PositionApprove> position1 = CommonExcute<PositionApprove>.GeneralList(sp, parameter);
              List<PositionApprove> position1 = GeneralDataAccess.GetListofTypeT<PositionApprove>(sp, parameter);
                return position1;
            }
            catch (System.Exception ex)
            {
                string em = ex.Message;
                return null;
            }
        }

      
    }
}
