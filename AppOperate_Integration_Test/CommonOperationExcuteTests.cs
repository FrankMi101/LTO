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
        string schoolyear = "20192020";
        [TestMethod()]
        public void InterviewOperationTest_return_Successfully()
        {
            //Arrange         
            InterviewResult operation = new InterviewResult();

            operation.Operate = "Update";
            operation.PositionID = "11220";
            operation.CPNum = "00019270";
            var expect = "Successfully";
            //Act
            var result = CommonOperationExcute.InterviewOperation(operation, operation.PositionID);
            //Assert
            Assert.AreEqual(expect, result, $"  Interview Update is { result}");


        }

        [TestMethod()]
        public void PublishOperationTest()
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

            var newid = CommonOperationExcute.PublishOperation(parameter, "0");

            parameter.PositionID = Int32.Parse(newid);


            //Verify Act
            var result = CommonOperationExcute.PublishOperation(parameter, newid)[0];

            //Assert
            Assert.AreEqual(expect, result, $"  New LTO Posting position  { result}");
        }

        [TestMethod()]
        public void CommonOperationTest_For_Interview()
        {
            
            //Arrange         
            var operation = new InterviewResult();

            operation.Operate = "Update";
            operation.PositionID = "11220";
            operation.CPNum = "00019270";
            var expect = "Successfully";
            //Act
            var result = CommonOperationExcute<InterviewResult>.CommonOperation(operation, "Update");
            //Assert
            Assert.AreEqual(expect, result, $"  Interview Update is { result}");

        }
        [TestMethod()]
        public void CommonOperationTest_For_Publish()
        {

            //Arrange         
            var parameter = new PositionPublish()
            {
                Operate = "Save",
                SchoolYear = schoolyear,
                PositionID = 11568,
                PositionType = "LTO",
                SchoolCode = "0531",
                UserID = "mif"  ,
                Qualification ="English, French"        ,
                PositionTitle ="New Test Class"  ,
                PositionLevel = "BC708E"


            };
            var expect = "Successfully";
            //Act

            var result = CommonOperationExcute<PositionPublish>.CommonOperation(parameter, "Save");
            //Assert
            Assert.AreEqual(expect, result, $"  Interview Update is { result}");

        }
    }
}