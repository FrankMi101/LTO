using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AppOperate.Tests
{
    [TestClass()]
    public class StaffManageTests
    {
        private Staff parameter = new Staff
        {
            Operate = "Save",
            UserID = "mif",
            CPNum = "20192020",
            Action = "Pending",
            Comments = "Pending comments",
            IDs = "",
        };


        [TestMethod()]
        public void LTOStaffManageExe_Save_RetureSuccessfullyValue_For_PendingAction()
        {
            //Arrange 
            parameter.Action = "Pending";
            parameter.CPNum = "00034440"; // Vescio,	Nicola
            parameter.Comments = "Pending the User from Test";

            // Act
            string expect = "Successfully"; 
            string result = LTOStaffManageExe.Save(parameter) ;
            string otType = LTOStaffManageExe.ApplicantOTType(parameter);
;            //Assert
            Assert.AreEqual(expect, result, $"Pending Action for Applicant { parameter.CPNum }  was { result}");
            StringAssert.Contains("LTOTeacher,Roster,Pending", otType, $"Pending Action for Applicant { parameter.CPNum }  was { otType}");

        }
        [TestMethod()]
        public void LTOStaffManageExe_Save_RetureSuccessfullyValue_For_RemovePendingAction()
        {
            //Arrange 
            parameter.Action = "Remove Pending Status";
            parameter.CPNum = "00034440"; // Vescio,	Nicola
            parameter.Comments = "Remove the Pending state action from Test";

            // Act
            string expect = "Successfully";
            string result = LTOStaffManageExe.Save(parameter);
           string otType = LTOStaffManageExe.ApplicantOTType(parameter);
 
            //Assert
            Assert.AreEqual(expect, result, $"Remove Pending Atate Action for Applicant { parameter.CPNum }  was { result}");
            Assert.AreEqual("LTOTeacher", otType, $"Pending Action for Applicant { parameter.CPNum }  was { otType}");

        }

        [TestMethod()]
        public void LTOStaffManageExe_Save_RetureSuccessfullyValue_For_RemoveApplicantFromLTOTeacherList()
        {
            //Arrange 
            parameter.Action = "Remove Staff From LTO Teacher List";
            parameter.CPNum = "00042338"; // Agozzino-Organ	Leigh
            parameter.Comments = "Remove Staff From LTO Teacher List";

            // Act
            string expect = "Successfully";
            string result = LTOStaffManageExe.Save(parameter);
            string otType = LTOStaffManageExe.ApplicantOTType(parameter);

            //Assert
              Assert.AreEqual(expect, result, $"Remove Applicant from Roster list  { parameter.CPNum }  was { result}");
             Assert.AreEqual("Not In List", otType, $"Pending Action for Applicant { parameter.CPNum }  was { otType}");

        }
        [TestMethod()]
        public void LTOStaffManageExe_Save_RetureSuccessfullyValue_For_AddStaff_to_LTOTeacherList()
        {
            //Arrange 
            parameter.Action = "Add Staff To LTO List";
            parameter.CPNum = "00042338"; //  Agozzino-Organ	Leigh
            parameter.Comments = "Add Staff To LTO List";
 
            // Act
            string expect = "Successfully";
            string result = LTOStaffManageExe.Save(parameter);
           string otType = LTOStaffManageExe.ApplicantOTType(parameter);

            //Assert
            Assert.AreEqual(expect, result, $"Add Applicant to LTO /Roster list  { parameter.CPNum }  was { result}");
            Assert.AreEqual("LTOTeacher", otType, $"Pending Action for Applicant { parameter.CPNum }  was { otType}");

        }
        [TestMethod()]
        public void LTOStaffManageExe_Save_RetureSuccessfullyValue_For_RemoveApplicantFromRosterList()
        {
            //Arrange 
            parameter.Action = "Remove Staff From Roster List";
            parameter.CPNum = "00033038"; // Abou Jaoudi	Eliane
            parameter.Comments = "Remove Staff From Roster List";

            // Act
            string expect = "Successfully";
            string result = LTOStaffManageExe.Save(parameter);
            string otType = LTOStaffManageExe.ApplicantOTType(parameter);

            //Assert
            Assert.AreEqual(expect, result, $"Remove Applicant from Roster list  { parameter.CPNum }  was { result}");
            Assert.AreEqual("Not In List", otType, $"Pending Action for Applicant { parameter.CPNum }  was { otType}");

        }
        [TestMethod()]
        public void LTOStaffManageExe_Save_RetureSuccessfullyValue_For_AddStaff_to_RosterList()
        {
            //Arrange 
            parameter.Action = "Add Staff To Roster List";
            parameter.CPNum = "00033038"; // Abou Jaoudi	Eliane
            parameter.Comments = "Add Staff To Roster List";

            // Act
            string expect = "Successfully";
            string result = LTOStaffManageExe.Save(parameter);
            string otType = LTOStaffManageExe.ApplicantOTType(parameter);

            //Assert
            Assert.AreEqual(expect, result, $"Add Applicant to LTO /Roster list  { parameter.CPNum }  was { result}");
            StringAssert.Contains("LTOTeacher,Roster", otType, $"Pending Action for Applicant { parameter.CPNum }  was { otType}");

        }
        [TestMethod()]
        public void LTOStaffManageExe_Save_RetureSuccessfullyValue_For_Move_Applicant_To_Roster_From_LTO()
        {
            //Arrange 
            parameter.Action = "Move Staff LTO To Roster";
            parameter.CPNum = "00036554"; // Yabut	Marjoree
            parameter.Comments = "Move Staff LTO To Roster";

            // Act
            string expect = "Successfully";
            string result = LTOStaffManageExe.Save(parameter);
            string otType = LTOStaffManageExe.ApplicantOTType(parameter);

            //Assert
            Assert.AreEqual(expect, result, $"Move Staff LTO To Roster list  { parameter.CPNum }  was { result}");
            Assert.AreEqual("Roster", otType, $"Pending Action for Applicant { parameter.CPNum }  was { otType}");

        }
        [TestMethod()]
        public void LTOStaffManageExe_Save_RetureSuccessfullyValue_For_Move_Applicant_To_LTO_From_Roster_LTO()
        {
            //Arrange 
            parameter.Action = "Move Staff From Roster To LTOTeacher";
            parameter.CPNum = "00053936"; // Alcantra	Marites
            parameter.Comments = "Move Staff From Roster To LTOTeacher";

            // Act
            string expect = "Successfully";
            string result = LTOStaffManageExe.Save(parameter);
            string otType = LTOStaffManageExe.ApplicantOTType(parameter);

            //Assert
            Assert.AreEqual(expect, result, $"Move Staff From Roster To LTOTeacher { parameter.CPNum }  was { result}");
            Assert.AreEqual("LTOTeacher", otType, $"Pending Action for Applicant { parameter.CPNum }  was { otType}");

        }
    }
}