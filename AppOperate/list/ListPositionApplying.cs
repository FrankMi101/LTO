using ClassLibrary;
using DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{
    public class ListPositionApplying : IPositionListRepository<PositionListApplying, string>
    {
        public IList<PositionListApplying> GetList(ParametersForPositionList parameter)
        {
            try
            {
                //4th round @searchBy = PostingCycle, SearchValue1 = 4
                 string sp = "dbo.tcdsb_LTO_PositionList_ApplicantApplying @Operate,@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy, @SearchValue1, @SearchValue2" ;
                var list = GeneralDataAccess.GetListofTypeT<PositionListApplying>(sp, parameter);
                return list;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }
        }
    }
}
