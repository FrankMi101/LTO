using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppOperate.ExecuteDelegate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace AppOperate.ExecuteDelegate.Tests
{
    [TestClass()]
    public class DataProcessDelegateTests
    {

        [TestMethod()]
        public void ListOfTTest_Return_PublishPositions()
        {
            //Assert

            string page = "Publish";
            string action = "Positions";
            var parameter = new ParametersForPositionList()
            {
                Operate = "Page",
                UserID = "mif",
                SchoolYear = "20192020",
                PositionType = "LTO",
                Panel = "All",
                Status = "Open",
                SearchBy = "All",
                SearchValue1 = "",
                SearchValue2 = ""
            };
            //Action
            var testList = DataProcessDelegate<PositionPublish>.ListOfT(page, action, parameter);

            //Assert
            int rcount = testList.Count;
            Assert.IsNotNull(testList, $"Delgate function return publish position list is { rcount }");
        }
        [TestMethod()]
        public void ListOfTTest_Return_PublishPositionbyPositionID()
        {
            //Assert
            string expect = "15590";
            string page = "Publish";
            string action = "Position";
            var parameter = new
            {
                SchoolYear = "20192020",
                PositionID = expect,

            };
            //Action
            var testList = DataProcessDelegate<PositionListRequesting>.ListOfT(page, action, parameter);

            //Assert
            string result = testList[0].PositionID.ToString();
            Assert.AreEqual(expect, result, $"Delgate function return publish position list is { result }");
        }

        [TestMethod()]
        public void ListOfTTest_Return_RequestPositions()
        {
            //Assert

            string page = "Request";
            string action = "Positions";
            var parameter = new
            {
                Operate = "Positions",
                UserID = "mif",
                SchoolYear = "20192020",
                SchoolCode = "0549",

            };
            //Action
            var testList = DataProcessDelegate<PositionListRequesting>.ListOfT(page, action, parameter);

            //Assert
            int rcount = testList.Count;
            Assert.IsNotNull(testList, $"Delgate function return publish position list is { rcount }");
        }
        [TestMethod()]
        public void ListOfTTest_Return_RequestPosition_byReqiestID()
        {
            //Assert
            string expect = "2655";
            string page = "Request";
            string action = "Position";
            var parameter = new
            {
                SchoolYear = "20192020",
                PositionID = expect,

            };
            //Action
            var testList = DataProcessDelegate<PositionRequesting>.ListOfT(page, action, parameter);

            //Assert
            string result = testList[0].PositionID.ToString();
            Assert.AreEqual(expect, result, $"Delgate function return publish position list is { result }");
        }

        [TestMethod()]
        public void ValueOfTTest_CreateNewRequest_returnNewRequestID()
        {
            // Arrange
            string page = "Request";
            string action = "New";
            NewPosition parameter = new NewPosition()
            {
                Operate = "New",
                SchoolYear = "20192020",
                PositionID = "0",
                PositionType = "LTO",
                SchoolCode = "0549",
                UserID = "mif"
            };
            //Act 
            
            var result = DataProcessDelegate<int>.ValueOfT(page, action, parameter).ToString();

            //Assert 
            Assert.IsNotNull( result, $" New Request ID is { result }");

        }
        [TestMethod()]
        public void ValueOfTTest_CreateNewPublish_returnNewPublishID()
        {
            // Arrange
            string page = "Publish";
            string action = "New";
            NewPosition parameter = new NewPosition()
            {
                Operate = "New",
                SchoolYear = "20192020",
                PositionID = "0",
                PositionType = "LTO",
                SchoolCode = "0549",
                UserID = "mif"
            };
            //Act 

            var result = DataProcessDelegate<int>.ValueOfT(page, action, parameter).ToString();

            //Assert 
            Assert.IsNotNull(result, $" New Request ID is { result }");

        }
    }
}