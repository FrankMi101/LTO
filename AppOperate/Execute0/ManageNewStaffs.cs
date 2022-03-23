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
    public class ManageNewStaffs
    {
        public static void StaffsGridView(ref GridView myGridView, Staff parameter)
        {
            try
            {
                string sp = "dbo.tcdsb_LTO_RosterLTOSeachbyNameAndCPNum @SearchBy,@SearchValue";
                List<Staff> staffs = GeneralDataAccess.GetListofTypeT<Staff>(sp, parameter);
                myGridView.DataSource = staffs;
                myGridView.DataBind();
            }
            catch (System.Exception ex)
            {
                string em = ex.Message;
            }
        }

        public static void StaffsGridView(ref GridView myGridView, Staff parameter, string Scope)
        {
            try
            {
                string sp = "dbo.tcdsb_LTO_RosterTCDSBSeachbyNameAndCPNum @SearchBy,@SearchValue";
                List<Staff> staffs = GeneralDataAccess.GetListofTypeT<Staff>(sp, parameter);
                myGridView.DataSource = staffs;
                myGridView.DataBind();
            }
            catch (System.Exception ex)
            {
                string em = ex.Message;
            }
        }
         public static void StaffsGridView(ref GridView myGridView, string userID, string searchType, string searchValue)
        {
            try
            {
                Staff parameter = new Staff { SearchBy = searchType, SearchValue = searchValue };
                StaffsGridView(ref myGridView, parameter);
            }
            catch (System.Exception ex)
            {
                string em = ex.Message;
            }
        }
       public static void StaffsGridView(ref GridView myGridView, string userID, string searchType, string searchValue, string Scope)
        {
            try
            {
                 Staff parameter = new Staff { SearchBy = searchType, SearchValue = searchValue };
                 StaffsGridView(ref myGridView, parameter, Scope);
            }
            catch (System.Exception ex)
            {
                string em = ex.Message;
            }
        }
        private static List<Staff> StaffList(Staff parameter)
        {
            string sp = "dbo.tcdsb_LTO_RosterTCDSBSeachbyNameAndCPNum @SearchBy,@SearchValue";
            List<Staff> staffs = GeneralDataAccess.GetListofTypeT<Staff>(sp, parameter);
            return staffs;
        }

        public static void AssembleProfilePage(Page myPage, string operate, string userID, string CPNum)
        {
            try
            {
                Staff parameter = new Staff { Operate = operate, UserID = userID, CPNum = CPNum };
                string sp = "dbo.tcdsb_LTO_RosterLTOProfileAction @Operate,@UserID,@CPNum";
                var profile = new List<Staff>();
                profile = GeneralDataAccess.GetListofTypeT<Staff>(sp, parameter);

                Label newLable = (Label)myPage.FindControl("LabelSchoolName");
                newLable.Text = profile[0].SchoolName;
                newLable = (Label)myPage.FindControl("LabelTeacherName");
                newLable.Text = profile[0].TeacherName;
                newLable = (Label)myPage.FindControl("LabelCPNum");
                newLable.Text = profile[0].CPNum;
                newLable = (Label)myPage.FindControl("LabelHireDate");
                newLable.Text = profile[0].DateOfHire;
                newLable = (Label)myPage.FindControl("LabelCurrentStatus");
                newLable.Text = profile[0].OTType;
                TextBox newtextbox = (TextBox)myPage.FindControl("LabelOCTQualification");
                newtextbox.Text = profile[0].Qualification;

    

            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                throw new Exception();
            }
        }
        public static void GetProfilePage(Page myPage, Staff parameter)
        {
            try
            {
                //  StaffProfile parameter = new StaffProfile { Operate = operate, UserID = userID, CPNum = CPNum };
                string sp = "dbo.tcdsb_LTO_RosterLTOProfileAction @Operate,@UserID,@CPNum";
                var profile = new List<Staff>();
                profile = GeneralDataAccess.GetListofTypeT<Staff>(sp, parameter);

                Label newLable = (Label)myPage.FindControl("LabelSchoolName");
                newLable.Text = profile[0].SchoolName;
                newLable = (Label)myPage.FindControl("LabelTeacherName");
                newLable.Text = profile[0].TeacherName;
                newLable = (Label)myPage.FindControl("LabelCPNum");
                newLable.Text = profile[0].CPNum;
                newLable = (Label)myPage.FindControl("LabelHireDate");
                newLable.Text = profile[0].DateOfHire;
                newLable = (Label)myPage.FindControl("LabelCurrentStatus");
                newLable.Text = profile[0].OTType;
                TextBox newtextbox = (TextBox)myPage.FindControl("LabelOCTQualification");
                newtextbox.Text = profile[0].Qualification;
   

            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                throw new Exception();
            }
        }

        public static string SaveProfile(string operate, string userID, string CPNum, string action)
        {

            try
            {
                Staff parameter = new Staff { Operate = operate, UserID = userID, CPNum = CPNum, Action = action };
                var result = SaveProfile(parameter);
                return result;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return "Failed";
            }

        }
        public static string SaveProfile(Staff parameter)
        {

            try
            {
                //  StaffProfile parameter = new StaffProfile { Operate = operate, UserID = userID, CPNum = CPNum, Action = action };
                string sp = "dbo.tcdsb_LTO_RosterLTOProfileAction @Operate,@UserID,@CPNum,@Action";
                string result = GeneralDataAccess.TextValue(sp, parameter);
                //  return SignatureProcess.SignoffResult(operate, userID, userRole, schoolYear, schoolCode, actionType, actionDate);
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

