﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using AppOperate;

namespace DataAccess.Repository.Tests
{
    [TestClass()]
    public class PublishPostingTests
    {
        private readonly string SchoolYear = "20212022";
        private readonly string SchoolCode = "0204";
        private readonly string PositionType = "LTO";
        private readonly string UserID = "Tester";
        private int _ids = 0;
       private readonly   IAppServices _action = new AppServices(DBConnection.DBSource, new PublishPosting());
       // private readonly IAppServices _action = new AppServices(DBConnection.DBSource);
        //   private readonly IAppServices _action = new AppServices("Fake");

        [TestInitialize]
        public void Setup()
        {
            // Runs before each test. (Optional)

          //  var ds = new DataOperateServiceSQL<PositionPublish>();
          //  _action = new PublishPosting<PositionPublish>(ds);

        }


        [TestMethod()]
        public void PublishPosting_Positions_Action_ReturnAllPublishListbyPara_Test()
        {
            //Arrange
            string action = "Positions";
            var para = new
            {
                Operate = "List",
                UserID,
                SchoolYear,
                PositionType,
                Panel ="All",
                Status="Open",
                Searchby ="School",
                SearchValue1 ="0290"
            };
            int expect = 1;

            //Act
            var positions = _action.AppOne.CommonList<PositionListPublish>(action, para);// .AppPublishPosting.CommonList<PositionListPublish>(action, para);
            int result = positions.Count();
            //Assert
            Assert.AreEqual(expect, result, $" Publish Posting Positions = { result } ");
        }

        [TestMethod()]
        public void PublishPosting_Position_Action_ReturnPostionbyID_Test()
        {
            //Arrange
             string expect = "BC708E"; // "Primary, Junior & Intermediate Divisions";
           string action = "Positions";
            var para = new { SchoolYear = "20202021", PositionID = "19972" };
            //var para = new
            //{   Operate = "GetbyID",
            //    SchoolYear = "20202021",
            //    SchoolCode,
            //    PositionID = "19972",
            //    PositionLevel = expect
            //};

            //Act
            var position = _action.AppOne.CommonObject<PositionPublish>("Position", para);
            string result = position.PositionLevel;

            //Assert
            Assert.AreEqual(expect, result, $" Publish Posting Position by ID = { result } ");
            Assert.AreEqual(19972, position.PositionID , $" Publish Posting Position by ID = { result } ");
        }


        [TestMethod()]
        public void PublishPosting_Position_Action_ReturnDeadlineDate_Test()
        {
            //Arrange
            string action = "Deadline";
            var para = new
            {
                 SchoolYear,
                PublishDate = "2021/03/07",
                PositionType
            };
  
            string expect = "2021/03/09"; // "Primary, Junior & Intermediate Divisions";

            //Act
            var result = _action.AppOne.CommonAction(action, para);
          

            //Assert
            Assert.IsNotNull( result, $" Publish Posting Position by ID = { result } ");
        }

        [TestMethod()]
        public void PublishPosting_Position_Action_ReturnInvalidDate_Test()
        {
            //Arrange
            string action = "Deadline";
            var para = new
            {
                 SchoolYear,
                PublishDate = "2022/03/06",
                PositionType
            };
            string expect = "Invalid Date"; // "Primary, Junior & Intermediate Divisions";

            //Act
            var result = _action.AppOne.CommonAction(action, para);


            //Assert
            Assert.AreEqual(expect, result, $" Publish Posting Position by ID = { result } ");
        }

        [TestMethod()]
        public void PublishPosting_Position_Action_ReturnDefaultDate_Test()
        {
            //Arrange
            string action = "DefaultDate";
            var para = new
            {
               Operate = "DefaultDate",
               AppType = PositionType,
                SchoolYear = "20212022",
                DatePublish = "2022/03/07" 
            };
            string expect = DateFC.YMD(DateTime.Today ,"/");

            //Act
            var defaultDate = _action.AppOne.CommonObject<PositionPublish>("DefaultDate", para);
            var result = defaultDate.DatePublish;

            //Assert
            Assert.AreEqual(expect, result, $" Publish Posting Position by ID = { result } ");
        }

        [TestMethod()]
        public void PublishPosting_NewPublish_Action_ReturnNewID_Test()
        {
            //Arrange
            string action = "New";
            var para = new { Operate = action, UserID , SchoolYear, SchoolCode, PositionID = "0", PositionType };


            //Act
            var result = _action.AppOne.CommonAction(action, para);
            _ids = int.Parse(result);

            //Assert
            Assert.IsNotNull(result, $" Publish Posting Position by ID = { result } ");
        }


        [TestMethod()]
        public void PublishPosting_UpdatePublish_Action_ReturnSuccessfully_Test()
        {
            //Arrange
            string action = "Update";
            PerpareForTest(action);
            var para = new
            {
                Operate = action,
                UserID ,
                SchoolYear,
                SchoolCode,
                PositionID = _ids.ToString(),
                PositionType,
                Comments = "Intergration Test Update Action ",
                PositionTitle ="Elementary Teacher form test ",
                PositionLevel= "BC001E",
            };
            string expect = "Successfully";

            //Act
            var result = _action.AppOne.CommonAction(action, para);

            //Assert
            Assert.AreEqual(expect, result, $" Publish Posting Position Update Test  { result } ");
        }

        [TestMethod()]
        public void PublishPosting_DeletePublish_Action_ReturnSuccessfully_Test()
        {
            //Arrange
            string action = "Delete";
            PerpareForTest(action);
            var para = new { Operate = action, UserID, SchoolYear, SchoolCode, PositionID = _ids.ToString() };
            string expect = "Successfully";

            //Act
            var result = _action.AppOne.CommonAction(action, para);

            //Assert
            Assert.IsNotNull(expect, result, $" Publish Posting Position Update Test  { result } ");
        }

        [TestMethod()]
        public void PublishPosting_Reposting_Action_ReturnNewID_Test()
        {
            //Arrange
            var para1 = new { SchoolYear, PositionID = "25019" };
          //  var para1 = new { SchoolYear, PositionID = "25019", Operate = "GetbyID" } for Fake;
            var oldPosting = _action.AppOne.CommonObject<PositionPublish>("Position", para1);

            string action = "RePosting";
            var para = new { Operate = action, UserID = "tester", 
                SchoolYear = oldPosting.SchoolYear, 
                SchoolCode = oldPosting.SchoolCode, 
                PositionID = oldPosting.PositionID,
                PositionType = oldPosting.PositionType,
                Comments = "Re posting a position from Test for " + oldPosting.PostingNumber,
                PostingCycle ="4",
                TakeApplicant ="No",
                PostingNumber = oldPosting.PostingNumber
            };
            string expect = oldPosting.PostingNumber;
            string expect2 = "4";


            //Act
            var newId = _action.AppOne.CommonAction(action, para);
            _ids = int.Parse(newId);

            var paraGet = new
            {
                SchoolYear = "20212022",
                PositionID = _ids.ToString()
            };
            var newPosting = _action.AppOne.CommonObject<PositionPublish>("Position", paraGet);

            var result = newPosting.PostingNumber;
            var result2 = newPosting.PostingCycle;

            //Assert
            Assert.AreEqual(expect, result, $" Recall Publish Posting Test  { result } ");
            Assert.AreEqual(expect2, result2, $" Publish Posting Position Update Test  { result } ");
        }

        [TestMethod()]
        public void SpNameTest_ReturnSP_Name_byAction()
        {
            //Arrange
            string action = "Position";
            string expect = "dbo.tcdsb_LTO_PagePublish_Position";
            var para = new { SchoolYear = "202022021", PositionID = "0" };
            //Act
            string result = _action.AppOne.SpName(action, para);

            //Assert
            Assert.AreEqual(expect, result, $" SpName = { result } ");
        }

        [TestMethod()]
        public void SpNameTest_ReturnSP_NameWithParameter_byActionandNon_Anonymous()
        {
            //Arrange
            string action = "Position";
            string expect = "dbo.tcdsb_LTO_PagePublish_Position @SchoolYear, @PositionID";
            var para = new PositionPublish() { SchoolYear = "202022021", PositionID = 0 };
            //Act
            string result = _action.AppOne.SpName(action, para);

            //Assert
            Assert.AreEqual(expect, result, $" SpName = { result } ");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            try
            {
                string action = "Delete";
                var para = new { Operate = action, UserID , SchoolYear , SchoolCode, PositionID = _ids.ToString() };
                _action.AppOne.CommonAction(action, para);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void PerpareForTest(string action)
        {
            try
            {
                action = "New";
                var para = new { Operate = action, UserID, SchoolYear, SchoolCode, PositionID = "0", PositionType };
                var result = _action.AppOne.CommonAction(action, para);  
                _ids = int.Parse(result);
            }
            catch (Exception)
            {
                _ids = 0;
            }
        }
    }
}
