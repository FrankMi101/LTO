using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppOperate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace AppOperate.Tests
{
    [TestClass()]
    public class CommonOperationExcuteTests
    {
        string schoolyear = "20182019";
        [TestMethod()]
        public void InterviewOperationTest_return_Successfully()
        {
            //Arrange         
            InterviewResult operation = new InterviewResult();

            operation.Operate = "Update";
            operation.PositionID = "11220";
            operation.CPNum = "00019270";
            var expect = "Successfully,Failed";
            //Act
            var result = CommonOperationExcute.InterviewOperation(operation, operation.PositionID);
            //Assert
            StringAssert.Contains(expect, result, $"  Interview Update is { result}");


        }

        [TestMethod()]
        public void PublishOperationTest_AddNewPosting_ReturnNewPositingID()
        {
            //Arrange
            var parameter = new PositionPublish()
            {
                Operate = "New",
                SchoolYear = schoolyear,
                PositionID = 0,
                PositionType = "LTO",
                SchoolCode = "0391",
                UserID = "mif"
            };
            //Act
            string expect = "LTO";

            var newid = CommonOperationExcute.PublishOperation(parameter, "New");

            parameter.PositionID = Int32.Parse(newid);

 

            //Assert
            Assert.IsNotNull(newid, $"  New LTO Posting position  { newid}");
        }

        [TestMethod()]
        public void CommonOperationTest_For_Interview_Return_Successfully()
        {

            //Arrange         
            var operation = new InterviewResult()
            {
                Operate = "Update",
                UserID = "mif",
                SchoolYear = schoolyear,
                PositionID = "11220",
                CPNum = "00015762",
            };


            var expect = "Successfully";
            //Act
            var result = CommonOperationExcute<InterviewResult>.CommonOperation(operation, "Update");
            //Assert
            Assert.AreEqual(expect, result, $"  Interview Update is { result}");

        }
        [TestMethod()]
        public void CommonOperationTest_For_Interview_Return_NoApplicantexists()
        {

            //Arrange         
            var operation = new InterviewResult()
            {
                Operate = "Update",
                UserID = "mif",
                SchoolYear = schoolyear,
                PositionID = "11220",
                CPNum = "00000002",
            };


            var expect = "No Applicant exists";
            //Act
            var result = CommonOperationExcute<InterviewResult>.CommonOperation(operation, "Update");
            //Assert
            Assert.AreEqual(expect, result, $"  Interview Update is { result}");

        }

        [TestMethod()]
        public void CommonOperationTest_For_Publish_UpdatePosition_ReturnSuccessfully()
        {

            //Arrange         
            var parameter = new PositionPublish()
            {
                Operate = "Update",
                SchoolYear = schoolyear,
                PositionID = 11568,
                PositionType = "POP",
                SchoolCode = "0531",
                UserID = "mif",
                Qualification = "English, French",
                PositionTitle = "New Test Class",
                Comments = "Update Position testing",
                PositionLevel = "BC708E",
                ReplaceTeacher ="",
                ReplaceTeacherID=""
            };
            var expect = "Successfully";
            //Act

            var result = CommonOperationExcute<PositionPublish>.CommonOperation(parameter, "Save");
            //Assert
            Assert.AreEqual(expect, result, $"  Interview Update is { result}");

        }
        [TestMethod()]
        public void CommonOperationTest_For_Publish_UpdatePosition_ReturnFailed()
        {

            //Arrange         
            var parameter = new PositionPublish()
            {
                Operate = "Insert",
                SchoolYear = schoolyear,
                PositionID = 0,
                PositionType = "POP",
                SchoolCode = "0531",
                UserID = "mif",
                Qualification = "English, French",
                PositionTitle = "New Test Class Insert",
                Comments = "Insert Position testing",
                PositionLevel = "BC708E",
                ReplaceTeacher = "",
                ReplaceTeacherID = ""
            };
            var expect = "Successfully";
            //Act

            var result = CommonOperationExcute<PositionPublish>.CommonOperation(parameter, "Save");
            //Assert
            Assert.IsNotNull( result, $"  Interview Update is { result}");

        }
    }
}