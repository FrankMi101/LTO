using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate.ExecuteDelegate
{
    public class SpNameParameterDelegate
    {

        //private delegate string GetSPNameAndParameters(string value );
        //private delegate string GetSPNameAndParameters2(string valu,string value1);

        //private static string GetSPHelper(GetSPNameAndParameters delegateFunc, string value )
        //{
        //    return delegateFunc(value );

        //}
        //private static string GetSPHelper(GetSPNameAndParameters2 delegateFunc, string value,string value2)
        //{
        //    return delegateFunc(value,value2);

        //}
        public static string GetSPbyDelegateHelp(string action, string page)
        {
        

            if (SPSource.SPFile == "")
            {
                switch (page)
                {

                    case "Request":
                      return GeneralDelegate.RuningDelegate( RequestPostingExe.SPName, action );
                      //  return Func<string, string>(action, RequestPostingExe.SPName);
                    case "Approve":
                        return GeneralDelegate.RuningDelegate(PostingPositionExe.SPName, action);
                    case "Publish":
                        return GeneralDelegate.RuningDelegate(PublishPositionExe.SpName, action);
                    case "Candidate":
                        return GeneralDelegate.RuningDelegate(SelectCandidateExe.SPName, action);
                    case "Hiring":
                        return GeneralDelegate.RuningDelegate(ConfirmHireExe.SPName, action);
                    case "Hired":
                        return GeneralDelegate.RuningDelegate(HiredPositionExe.SPName, action);
                    case "Interview":
                        return GeneralDelegate.RuningDelegate(InterviewProcessExe.SPName, action);
                    case "Applying":
                        return GeneralDelegate.RuningDelegate(ApplyProcessExe.SPName, action);
                    case "MultipleSchools":
                        return GeneralDelegate.RuningDelegate(MultipleSchoolsExe.SPName,action);
                    case "Staff":
                        return GeneralDelegate.RuningDelegate(LTOStaffManageExe.SPName,action);
                    case "Summary":
                        return GeneralDelegate.RuningDelegate(PostingSummaryExe.SPName,action);
                    default:
                        return GeneralDelegate.RuningDelegate(GeneralExe.SPName,action);

                }
            }
            else
            {
                return GeneralDelegate.RuningDelegate(GetSpNameFormJsonFile.SPName, page, action);
            }
        }


       // public  delegate  string Func<string value, string value, out string> (string value, string value1)
        public static string GetSPbyFounc(string action, string page)
        {
          

            if (SPSource.SPFile == "")
            {
                switch (page)
                {

                    case "Request":
                       return GeneralDelegate<string>.RunningTDelegate (RequestPostingExe.SPName, action); 
                    case "Approve":
                        return GeneralDelegate<string>.RunningTDelegate(PostingPositionExe.SPName, action);
                    case "Publish":
                        return GeneralDelegate<string>.RunningTDelegate(PublishPositionExe.SpName, action);
                    case "Candidate":
                        return GeneralDelegate<string>.RunningTDelegate(SelectCandidateExe.SPName, action);
                    case "Hiring":
                        return GeneralDelegate.RuningDelegate(ConfirmHireExe.SPName, action);
                    case "Hired":
                        return GeneralDelegate.RuningDelegate(HiredPositionExe.SPName, action);
                    case "Interview":
                        return GeneralDelegate.RuningDelegate(InterviewProcessExe.SPName, action);
                    case "Applying":
                        return GeneralDelegate.RuningDelegate(ApplyProcessExe.SPName, action);
                    case "MultipleSchools":
                        return GeneralDelegate.RuningDelegate(MultipleSchoolsExe.SPName, action);
                    case "Staff":
                        return GeneralDelegate.RuningDelegate(LTOStaffManageExe.SPName, action);
                    case "Summary":
                        return GeneralDelegate.RuningDelegate(PostingSummaryExe.SPName, action);
                    default:
                        return GeneralDelegate.RuningDelegate(GeneralExe.SPName, action);

                }
            }
            else
            {
                return GeneralDelegate<string>.RunningTDelegate(GetSpNameFormJsonFile.SPName, page, action);
            }
        }
    }
}