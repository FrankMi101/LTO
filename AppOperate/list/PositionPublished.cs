using ClassLibrary;
using DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppOperate
{                                   
/// <summary>
/// PositionPublished class is all about the HR publish the new position operation  
/// get sigal position by postion ID 
/// </summary>
    public class PositionPublished: IPositionRepository< PositionPosting, int>
    {
        public PositionPublished() { }
        // get sigal position by ID
        public static  List<PositionPosting> PositionByID (ParameterCL  parameter)
        {
            try
            {
                string sp = "dbo.tcdsb_LTO_PositionDetails_PublishbyID @SchoolYear,@PositionID";
                List<PositionPosting> position1 = GeneralDataAccess.GetListofTypeT<PositionPosting>(sp, parameter);
                return position1;
            }
            catch (System.Exception ex)
            {
                string em = ex.Message;
                return null;
            }
        }
        // get Default position Date
        public static List <LimitDate> LimitedDate(object parameter)
        {
            try
            {
               string sp = "dbo.tcdsb_LTO_PositionDetails_DefaultDate @Operate, @AppType, @SchoolYear";
                List<LimitDate> limitedate = GeneralDataAccess.GetListofTypeT<LimitDate>(sp, parameter);
                return limitedate;
            }
            catch (System.Exception ex)
            {
                string em = ex.Message;
                return null;
            }
        }
        public static void AssembleDetails(Page myPage, PositionBase parameter)
        {
            try
            {

                string sp = "dbo.tcdsb_LTO_PositionDetails_PublishbyID @SchoolYear,@PositionID";
                List<PositionPosting> position = GeneralDataAccess.GetListofTypeT<PositionPosting>(sp, parameter);



            //IPositionRepository<PositionPosting, string> repository = Factory.Get<PositionPosting>(); 

            //        IList<Employee2> gridData = repository.GetListItems(WorkingProfile.UserRole, userID, schoolyear, schoolcode, searchby, searchvalue);
             



                //Label newLable = (Label)myPage.FindControl("LabelSchoolName");
                //newLable.Text = position[0].SchoolName;
                //newLable = (Label)myPage.FindControl("LabelTeacherName");
                //newLable.Text = position[0].TeacherName;
                //newLable = (Label)myPage.FindControl("LabelCPNum");
                //newLable.Text = position[0].CPNum;
                //newLable = (Label)myPage.FindControl("LabelHireDate");
                //newLable.Text = position[0].DateOfHire;
                //newLable = (Label)myPage.FindControl("LabelCurrentStatus");
                //newLable.Text = position[0].OTType;
                //TextBox newtextbox = (TextBox)myPage.FindControl("LabelOCTQualification");
                //newtextbox.Text = position[0].Qualification;





                //foreach (Staff myitem in profile)
                //{                     
                //    Label newLable = (Label)myPage.FindControl("LabelSchoolName");
                //    newLable.Text =      myitem.SchoolName;
                //    HtmlTextArea newArea = (HtmlTextArea)myPage.FindControl("Text" + code);
                //    newArea.Value = myitem.Notes;
                //}



            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                throw new Exception();
            }
        }
        // get Position Qualification selected value
        public static  bool QualificaitonSelected(string schoolYear, int positionID, string ItemCode)
        {
            try
            {                                                   
                PositionPosting parameter = new PositionPosting { SchoolYear = schoolYear, PositionID =positionID, QualificationID =ItemCode };
                string sp = "dbo.tcdsb_LTO_checkpositionQualificationbyID @SchoolYear,@PositionID,@QualificationID";
                Boolean result = GeneralDataAccess.BoolValue(sp, parameter);
                return result;
            }
            catch (System.Exception ex)
            {
                string em = ex.Message;
                return false;
            }
        }
       // save position changes
        public static string SavePosition(PositionPosting  position)
        {

            try
            {
                //  StaffProfile parameter = new StaffProfile { Operate = operate, UserID = userID, CPNum = CPNum, Action = action };
                string paramaters ="@Operate,@UserID,@SchoolYear,@SchoolCode,@PositionID,@PositionType,@PositionTitle,@PositionLevel, @Qualification, @Description,@FTE,@FTEPanel, @StartDate,@EndDate, @DatePublish,@DateApplyStart,@DateDeadline, @Comments, @ReplaceTeacherID, @ReplaceTeacher";
                string sp = "dbo.tcdsb_LTO_PositionDetails_RequestAddSave " + paramaters;
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
        public static string CancelPosting(PositionPosting parameter)
        {          
            try
            {
                string sp = "dbo.tcdsb_LTO_PositionDetails_CancelPosting @Operate,@UserID,@SchoolYear,@PositionID, @Comments"; 
                string result = GeneralDataAccess.TextValue(sp, parameter);
                return result;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return "Failed";
            }

        }
        public static string RePosting(PositionPosting parameter)
        {
            try
            {   string parameters = "@Operate,@UserID,@SchoolYear,@PositionID, @PostingCycle,@TakeApplicant";
                string sp = "dbo.tcdsb_LTO_PositionDetails_RePosting " + parameters;
                string result = GeneralDataAccess.TextValue(sp, parameter);
                 return result;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return "Failed";
            }

        }

        public IList<PositionPosting> GetPosition( int positionID)
        {
            try
            {
                string sp = "dbo.tcdsb_LTO_PositionDetails_PublishbyID @SchoolYear, @PositionID";
              var parameter = new ParameterCL() { PositionID = positionID, SchoolYear="" };
                List<PositionPosting> position1 = GeneralDataAccess.GetListofTypeT<PositionPosting>(sp, parameter);
                return position1;
            }
            catch (System.Exception ex)
            {
                string em = ex.Message;
                return null;
            }
        }  

        public IList<PositionPosting> GetPosition(ParametersForPosition parameter)
        {  try
            {
                string sp = "dbo.tcdsb_LTO_PositionDetails_PublishbyID @SchoolYear, @PositionID";
             // var parameter = new ParameterCL() { PositionID = positionID, SchoolYear = "" };
                List<PositionPosting> position1 = GeneralDataAccess.GetListofTypeT<PositionPosting>(sp, parameter);
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
