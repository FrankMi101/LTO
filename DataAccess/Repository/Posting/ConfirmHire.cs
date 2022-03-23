using DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ConfirmHire : PostingBase, IConfirmHire
    {
        public ConfirmHire() : base()
        {
        }

        public ConfirmHire(string dataSource) : base(dataSource)
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
                    return "dbo.tcdsb_LTO_PageConfirmHire_Positions" ;
                case "Position":
                    return "dbo.tcdsb_LTO_PageConfirmHire_Position" ;
                case "Position4th":
                    return "dbo.tcdsb_LTO_PageConfirmHire_Position4th" ;
                case "Confirm":
                    return "dbo.tcdsb_LTO_PageConfirmHire_Operation" ;
                case "Confirm4th":
                    return "dbo.tcdsb_LTO_PageConfirmHire_Operation4th" ;
                case "Revoke":
                    return "dbo.tcdsb_LTO_PageConfirmHire_Revoke" ;
                case "PernrNum":
                    return "dbo.tcdsb_LTO_PageGeneral_Profile" ;
                default:
                    return action;

            }

        }

        private string GetParameters(string action)
        {
            string parameters = "@Operate,@UserID,@SchoolYear,@PositionType,@PositionID,@CPNum,@Comments,@Acceptance,@DateConfirm,@DateEffective,@DateEnd,@PrincipalEmail,@OfficerEmail,@PayStatus";
            string ParaPosition = "@SchoolYear, @PositionID, @CPNum";
            string ParaPositions = "@Operate,@UserID,@SchoolYear,@PositionType, @SearchBy, @SearchValue1";

            switch (action)
            {
                case "Positions":       return ParaPositions;
                case "Position":        return ParaPosition;
                case "Position4th":     return ParaPosition;
                case "Confirm":         return parameters;
                case "Confirm4th":      return parameters + ",@TeacherName";
                case "Revoke":          return "@UserID,@SchoolYear,@PositionID,@CPNum,@Comments";
                case "PernrNum":        return "@Operate,@UserID,@SchoolYear,@ProfileType,@CheckValue";

                default:                return "";



            }
        }
    }
}

