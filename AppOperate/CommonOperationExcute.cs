using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate
{
    public class CommonOperationExcute
    {
        private static string Operation<T>(T operation, string action)
        {
            var myval = ObjClassFactory.GetOperationClassObj<T>();  //new CommonOperation<T>();
            return myval.Operation(operation, action);
        }

        public static string InterviewOperation(InterviewResult operation, string action)
        {
            // var myval = new CommonOperation<InterviewResult>();//  PostingInterview() ;
            // return myval.Operation(operation, action);   //  myval.InterviewOperation(operation, positonID );
            // return CommonOperationExcute<InterviewResult>.CommonOperation(operation, action);
            return Operation(operation, action);
        }
        public static string InterviewNotice(InterviewNotice operation, string action)
        {
          //  return CommonOperationExcute<InterviewNotice>.CommonOperation(operation, action);
            return Operation(operation, action);
        }
        public static string PublishOperation(PositionPublish operation, string action)
        {
           //  return CommonOperationExcute<PositionPublish>.CommonOperation(operation, action);
            return Operation(operation, action);
        }
        public static string RequestOperation(PositionRequesting operation, string action)
        {
           //  return CommonOperationExcute<PositionRequesting>.CommonOperation(operation, action);
            return Operation(operation, action);
        }
        public static string PublishNewOperation(NewPosition operation, string action)
        {
            //  return CommonOperationExcute<PositionPublish>.CommonOperation(operation, action);
            return Operation(operation, action);
        }
        public static string RequestNewOperation(NewPosition operation, string action)
        {
            //  return CommonOperationExcute<PositionRequesting>.CommonOperation(operation, action);
            return Operation(operation, action);
        }
        public static string ApproveOperation(PositionApprove operation, string action)
        {
             return Operation(operation, action);
        }
        public static string HiringOperation(PositionHire operation)
        {
             return Operation(operation, operation.Operate);
        }
        public static string HiringOperation( ParametersForOperationHire  operation, string action)
        {
            return Operation(operation, action);
        }
        public static string HiringOperation4th(ParametersForOperationHire operation, string action)
        {
            return Operation(operation, action);
        }
        public static string HiredOperation(PositionHired operation)
        {
             return Operation(operation, operation.Operate);
        }
        public static string HiredOperation(PositionHired operation, string action)
        {
            return Operation(operation, action);
        }
        public static string SelectedInterviewCandidate(ParametersForOperation operation, string action)
        {
            return Operation(operation, action);
        }
        public static string SelectedForInterviewCandidate(ParametersForOperation operation, string action)
        {
            return Operation(operation, action);
        }
        public static string ActingPrincipal(ParametersForOperation operation, string action)
        {
            return Operation(operation, action);
        }
        public static string MultipleSchoolPrincipal(ParametersForOperation operation, string action)
        {
            return Operation(operation, action);
        }
        public static string GeneralInforamtion(ParametersForOperation operation, string action)
        {
            return Operation(operation, action);
        }
        public static string ApplicantContactUpdate(ApplicantContact operation, string action)
        {
            return Operation(operation, action);
        }
        public static string ApplyingOperation(ParametersForApply operation, string action)
        {
            return Operation(operation, action);
        }
        public static string TeacherNameByCPNum(ParametersForTeacher operation, string action)
        {
            return Operation(operation, action);
        }
    }
    public class CommonOperationExcute<T>
    {
        public static string CommonOperation(T operation, string action)
        {
            // ICommonOperation<T> repository = Factory.Get<CommonOperation<T>>();  
            //return repository.Operation(operation,action)  ;

            var myval = new CommonOperation<T>();
            return myval.Operation(operation, action);
        }
        public static string CommonOperation(T operation,string sp, string action)
        {
            // ICommonOperation<T> repository = Factory.Get<CommonOperation<T>>();  
            //return repository.Operation(operation,action)  ;

            var myval = new CommonOperation<T>();
            return myval.Operation(operation,sp, action);
        }

        public static string ObjSP(string objName, string action)
        {
            var myval = new CommonOperation<T>();
            return myval.GetSPNameAndParametersbyType(objName, action);
        }
    }

   
}
