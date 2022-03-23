using DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class HiredPositions : PostingBase, IHiredPositions
    {
        public HiredPositions() : base()
        {
        }

        public HiredPositions(string dataSource) : base(dataSource)
        {
        }

        public override string SpName(string action, object parameter)
        {
            if (SPSource.SPFile == "") return GetspNameAndParameter(action, parameter);

            return GetSPFromJSonFile.SPandParameter(SPSource.SPFile, "Applicant", action);
        }

        private string GetspNameAndParameter(string action, object parameter)
        {
            bool IsAnonymous = parameter.GetType().FullName.Contains("AnonymousType");
            string sp = GetspName(action);
            if (IsAnonymous)
                return sp;
            else
            {
                string para = GetParameters(action);
                if (para.Length > 1) return sp + " " + para;

                return sp;
            }
        }
        private string GetspName(string action)
        {
 
            switch (action)
            {
                case "Positions":
                    return "dbo.tcdsb_LTO_PageHired_Positions";
                case "Position":
                    return "dbo.tcdsb_LTO_PageHired_Position";
                case "Revoke":
                    return "dbo.tcdsb_LTO_PageHired_OperationRevoke";
                case "Delete":
                    return "dbo.tcdsb_LTO_PageHired_Operation";
                default:
                    return "";

            }

        }
        private string GetParameters(string action)
        {
            string ParaPosition = " @SchoolYear, @PositionID, @CPNum";
            string ParaPositions = " @Operate,@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy,@SearchValue1,@SearchValue2";

            switch (action)
            {
                case "Positions":   return ParaPositions;
                case "Position":    return ParaPosition;
                case "Revoke":      return "@UserID," + ParaPosition;
                case "Delete":      return "@UserID," + ParaPosition;

                default:            return "";
            }

        }
        
    }
}

