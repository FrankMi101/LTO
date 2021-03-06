﻿using ClassLibrary;
using DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{
    public class ListPositionPublish : IPositionListRepository<PositionListPublish, string>
    {
        public IList<PositionListPublish> GetList(ParametersForPositionList parameter)
        {
            try
            {
                //4th round @searchBy = PostingCycle, SearchValue1 = 4
                 string sp = "dbo.tcdsb_LTO_PositionList_Published @Operate,@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy, @SearchValue1, @SearchValue2" ;
                var list = GeneralDataAccess.GetListofTypeT<PositionListPublish>(sp, parameter);
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
