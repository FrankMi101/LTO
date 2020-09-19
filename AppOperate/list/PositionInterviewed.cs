using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using DataAccess.Common;
namespace AppOperate
{
    public class PositionInterviewed : IPositionRepository<PositionInterview, int>
    {
        public IList<PositionInterview> GetPosition(int positionID)
        {
            try
            {
                string sp = "dbo.tcdsb_LTO_PositionDetails_RequestbyID @SchoolYear, @PositionID";
                var parameter = new ParameterCL() { PositionID = positionID, SchoolYear = "" };
                List<PositionInterview> position1 = GeneralDataAccess.GetListofTypeT<PositionInterview>(sp, parameter);
                return position1;
            }
            catch (System.Exception ex)
            {
                string em = ex.Message;
                return null;
            }
        }

        public IList<PositionInterview> GetPosition(ParametersForPosition parameter)
        {
            try
            {
                string sp = "dbo.tcdsb_LTO_PositionDetails_RequestbyID @SchoolYear, @PositionID";
                // var parameter = new ParameterCL() { PositionID = positionID, SchoolYear = "" };
                List<PositionInterview> position1 = GeneralDataAccess.GetListofTypeT<PositionInterview>(sp, parameter);
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
