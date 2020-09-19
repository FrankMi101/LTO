using ClassLibrary;
using DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{
  

    public class PostingQualification : IQualification<QualificationSelected>
    {

        public List<QualificationSelected> rList(ParametersForPosition parameter)
        {
            try
            {
                //4th round @searchBy = PostingCycle, SearchValue1 = 4
                string sp = "dbo.tcdsb_LTO_QualificationSelectedList  @SchoolYear,@PositionID";
                var list = GeneralDataAccess.GetListofTypeT<QualificationSelected>(sp, parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }

        public string QualificationUpdate(QualificationUpdate qual)
        {
            try
            {
                string paramaters = "@Operate,@UserID,@SchoolYear,@SchoolCode,@PositionID,@SourceID, @QualificationID, @Selected";
                string sp = "dbo.tcdsb_LTO_Qualification_Update " + paramaters;
                var result = GeneralDataAccess.TextValue(sp, qual);
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
