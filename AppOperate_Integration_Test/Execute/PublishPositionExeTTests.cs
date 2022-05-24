using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace AppOperate.Tests
{
    [TestClass()]
    public class PublishPositionExeTTests
    {
        private static string schoolyear = "20192020";
        private string cPage = "Request";
        PositionPublish publishposition = new PositionPublish();

        ParametersForPositionList parameter = new ParametersForPositionList()
        {
            Operate = "Positions",
            UserID = "mif",
            SchoolYear = schoolyear,
            PositionType = "LTO",
            Panel = "All",
            Status = "Open",
            SearchBy = "All",
            SearchValue1 = "",
            SearchValue2 = ""
        };


        NewPosition publish = new NewPosition()
        {
            Operate = "New",
            SchoolYear = "20192020",
            PositionID = "0",
            PositionType = "LTO",
            SchoolCode = "0549",
            UserID = "mif"
        };

        private int getNewPublishID(string positionType)
        {

            publish.PositionType = positionType;
            string newid = PublishPositionExe<string>.Add(publish);
            int x = Int32.Parse(newid);
            return x;
        }



        [TestMethod()]
        public void SPNameTest_retrun_Position_StoreProcedure_name()
        {
            //Arrange 
            string action = "Position";
            var para = new ParametersForPosition();
            //Act
            string expect = "dbo.tcdsb_LTO_PagePublish_Position @SchoolYear, @PositionID";
            string result = PublishPositionExe<string>.SpName(action,para);

            //Assert
            Assert.AreEqual(expect, result, $" Publish Position Store Procedure Name:  { result}");

        }
        [TestMethod()]
        public void SPNameTest_retrun_Positions_StoreProcedure_name()
        {
            //Arrange 
            string action = "Positions";
            var para = new ParametersForPosition();

            //Act
            string expect = "dbo.tcdsb_LTO_PagePublish_Positions @Operate,@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy,@SearchValue1,@SearchValue2";
            string result = PublishPositionExe<string>.SpName(action, para);

            //Assert
            Assert.AreEqual(expect, result, $" Publish Positions list Store Procedure Name:  { result}");

        }
        [TestMethod()]
        public void SPNameTest_retrun_CreateNewPublish_StoreProcedure_name()
        {
            //Arrange 
            string action = "New";
            var para = new ParametersForPosition();
            //Act
            string expect = "dbo.tcdsb_LTO_PagePublish_CreateNew @Operate,@UserID,@SchoolYear,@SchoolCode,@PositionID,@PositionType";
            string result = PublishPositionExe<string>.SpName(action, para);

            //Assert
            Assert.AreEqual(expect, result, $" Create new Publish Position Store Procedure Name:  { result}");

        }

        [TestMethod()]
        public void PositionsTest_Return_All_published_Postion_List()
        {
            //Arrange
            var myGridview = new System.Web.UI.WebControls.GridView();
            var parameter = new ParametersForPositionList()
            {
                Operate = "Page",
                UserID = "mif",
                SchoolYear = schoolyear,
                PositionType = "LTO",
                Panel = "All",
                Status = "Open",
                SearchBy = "All",
                SearchValue1 = "",
                SearchValue2 = ""
            };
            string expect = "334";

            //Act
           var publishList = PublishPositionExe<PositionListPublish>.Positions(parameter);
            myGridview.AutoGenerateColumns = true;
            myGridview.DataSource = publishList;
            myGridview.DataBind();

            var result = myGridview.Rows.Count.ToString();

            //Assert
            Assert.IsNotNull(result, $" Publish positions count is { result } ");
        }

        [TestMethod()]
        public void PositionTest_return_publishPosition_by_giving_PositionID()
        {
            //Arrange
             
            var parameter = new ParametersForPosition()
            {
                SchoolYear = schoolyear,
                PositionID = getNewPublishID("LTO").ToString()
            };
            string expect = parameter.PositionID;

            //Act
            var publishposition = PublishPositionExe<PositionPublish>.Position(parameter)[0];


            string result = publishposition.PositionID.ToString();

 
            //Assert
            Assert.AreEqual(expect, result, $" Publish positions ID is { result } ");


        }

        [TestMethod()]
        public void PositionInfoTest()
        {
            //Arrange

            var parameter = new ParametersForPosition()
            {
                SchoolYear = schoolyear,
                PositionID = getNewPublishID("LTO").ToString()
            };
            var position = PublishPositionExe<PositionPublish>.Position(parameter)[0];
            position.Operate = "Update";
            position.SchoolYear = schoolyear;
            position.PositionTitle = "Test Grade 10 Teacher";
            position.PositionLevel = "BC708E";
            position.Description = " position descriptions from HR staff";
            position.StartDate = "2019/09/03";
            position.EndDate = "2020/06/30";
            position.DatePublish = "2019/11/11";
            position.DateApplyOpen = "2019/11/13";
            position.DateApplyClose = "2019/11/15";

            //Act
            string updateresult = PublishPositionExe<string>.Update(position);

            List<PositionInfo> positionInfo = PublishPositionExe<PositionInfo>.PositionInfo(parameter);
            string expect = position.PositionTitle + "(" + parameter.PositionID + ")";
            string expect2 = position.StartDate;
            string result = positionInfo[0].PositionTitle;
            string result2 = positionInfo[0].StartDate;
            //Assert
            Assert.AreEqual(expect, result, $" Position { parameter.PositionID }  title is { result} ");
            Assert.AreEqual(expect2, result2, $" Position { parameter.PositionID }  Apply open Date is { result2} ");

        }

        [TestMethod()]
        public void DefaultDateTest()
        {
            // ********* This test will Fail if test happend public hoilday **********

            //Arrange 
            string action = "DefaultDate";
             string expect =  DateFC.YMD(DateTime.Now,"/","Y");
     
            var parameter = new  
            {
                Operate = action,
                PositionType = "LTO",
                SchoolYear = "20192020",
            };

            // Act
            var myDate = PublishPositionExe<PositionPublish>.DefaultDate(parameter);

             var startDate = myDate[0].StartDate;
            var endDate = myDate[0].EndDate;
            var publishDate = myDate[0].DatePublish;
            var openDate = myDate[0].DateApplyOpen;
            var closeDate = myDate[0].DateApplyClose;

            string result = publishDate;

            //Assert
            Assert.AreEqual(expect, result, $"default publish Date Value  { result}");


        }

        [TestMethod()]
        public void PostingRoundsTest()
        {
            //Arrange
            var para = new
            {
                SchoolYear = schoolyear,
                PositionID = "14609",
            };
            //Act
            List<PositionPublish> result = PublishPositionExe<PositionPublish>.PostingRounds(para);

            int expect = result.Count;
            // Assert

            Assert.AreEqual(expect, result.Count,$"posting cycle number is { result.Count }" ) ;
        }

        [TestMethod()]
        public void AddTest_Creat_NewLTO_PublishPosition()
        {   //Arrange
            publish.PositionType = "LTO";
            //Act
            string result = PublishPositionExe<string>.Add(publish);

            //Assert
            Assert.IsNotNull(result, $"Creat new publish ID is { result }");
        }

        [TestMethod()]
        public void AddTest_Creat_NewPOP_PublishPosition()
        {   //Arrange
            publish.PositionType = "POP";
            //Act
            string result = PublishPositionExe<string>.Add(publish);

            //Assert
            Assert.IsNotNull(result, $"Creat new publish ID is { result }");
        }

        [TestMethod()]
        public void UpdateTest_return_Successfully_check()
        {
            //Arrange

            var parameter = new ParametersForPosition()
            {
                SchoolYear = schoolyear,
                PositionID = getNewPublishID("LTO").ToString()
            };
            var position = PublishPositionExe<PositionPublish>.Position(parameter)[0];
            position.Operate = "Update";
            position.SchoolYear = schoolyear;
            position.PositionTitle = "Test Grade 10 Teacher";
            position.PositionLevel = "BC708E";
            position.Description = " position descriptions from HR staff";
            position.StartDate = "2019/09/03";
            position.EndDate = "2020/06/30";
            position.DatePublish = "2019/11/11";
            position.DateApplyOpen = "2019/11/13";
            position.DateApplyClose = "2019/11/15";


            string expect = "Successfully";

            //Act    
            string result = PublishPositionExe<string>.Update(position);

            //Assert
            Assert.AreEqual(expect, result, $" Postion update is { result} ");
        }

        [TestMethod()]
        public void UpdateTest_using_reretive_update_result_value_ToVerify()
        {
            //Arrange

            var parameter = new ParametersForPosition()
            {
                SchoolYear = schoolyear,
                PositionID = getNewPublishID("LTO").ToString()
            };
            var position = PublishPositionExe<PositionPublish>.Position(parameter)[0];
            position.Operate = "Update";
            position.SchoolYear = schoolyear;
            position.PositionTitle = "Test Grade 10 Teacher";
            position.PositionLevel = "BC708E";
            position.Description = " position descriptions from HR staff";
            position.StartDate = "2019/09/03";
            position.EndDate = "2020/06/30";
            position.DatePublish = "2019/11/11";
            position.DateApplyOpen = "2019/11/13";
            position.DateApplyClose = "2019/11/15";


            string expect = "Successfully";
            string expect2 = "2019/11/15";
            string expect3 = parameter.PositionID;
            //Act    
            string result = PublishPositionExe<string>.Update(position);
            var position2 = PublishPositionExe<PositionPublish>.Position(parameter)[0];
            string result2 = position2.DateApplyClose;
            string result3 = position2.PositionID.ToString();

            //Assert
            Assert.AreEqual(expect, result, $" Postion update is { result} ");
            Assert.AreEqual(expect2, result2, $" Check with apply cloase Date. Postion Apply close Date is { result2} ");
            Assert.AreEqual(expect3, result3, $" check with Position ID  Position ID is { parameter.PositionID} ");
        }


        [TestMethod()]
        public void DeleteTest()
        {
            // Arrange
            var parameter = new ParametersForPosition()
            {
                SchoolYear = schoolyear,
                PositionID = getNewPublishID("LTO").ToString()
            };

            var position = PublishPositionExe<PositionPublish>.Position(parameter)[0];
            position.Operate = "Delete";
            //Act
            string result = PublishPositionExe<string>.Delete(position);
            string expect = "Successfully";

            //Assert
            Assert.AreEqual(expect, result, $" { parameter.PositionID }  has been delete   { result} ");


        }

        [TestMethod()]
        public void CancelTest()
        {
            // Arrange
            var parameter = new ParametersForPosition()
            {
                SchoolYear = schoolyear,
                PositionID = getNewPublishID("LTO").ToString()
            };

            var position = PublishPositionExe<PositionPublish>.Position(parameter)[0];
            position.Operate = "Cancel";
            //Act
            string result = PublishPositionExe<string>.Cancel(position);
            string expect = "Successfully";

            //Assert
            Assert.AreEqual(expect, result, $" { parameter.PositionID }  has been cancel   { result} ");
        }

        [TestMethod()]
        public void RePostingTest()
        {
            //Arrange

            var parameter = new ParametersForPosition()
            {
                SchoolYear = schoolyear,
                PositionID = getNewPublishID("LTO").ToString()
            };
            var position = PublishPositionExe<PositionPublish>.Position(parameter)[0];
            string prePostingCycle = position.PostingCycle;
            position.Operate = "RePosting";
            position.UserID = "mif";
            position.Comments = "Reposting from test process";
            position.PostingCycle = "2";

            string repostingID = PublishPositionExe<string>.RePosting(position);
            parameter.PositionID = repostingID;

            var parameter2 = new ParametersForPosition()
            {
                SchoolYear = schoolyear,
                PositionID = repostingID
            };
            var position2 = PublishPositionExe<PositionPublish>.Position(parameter2)[0];

            string expect = position.PostingNumber;
            string result = position2.PostingNumber;
            string expect2 = prePostingCycle;
            string result2 = position2.PostingCycle;

            //Assert
            Assert.AreEqual(expect, result, $" { parameter.PositionID } reporting to  { parameter2.PositionID} ");
            Assert.AreEqual(expect, result, $" { parameter.PositionID } posting Number is { expect} ");
            Assert.AreNotEqual(expect2, result2, $" { parameter.PositionID } posting Number is { expect} ");

        }

        [TestMethod()]
        public void DeadlineTest_return_DeadlineDate_bygiveingPublishDate()
        {
            //Arrange
            var anonyParametere = new
            {
                SchoolYear = "20192020",
                PublishDate = "2019/11/11",
                PositionType = "LTO"
            };

            //Act
            string result = PublishPositionExe<string>.Deadline(anonyParametere);
            string expect = "2019/11/13";

            //Assert
            Assert.AreEqual(expect, result, $" The deasline date is { result } for publish date {anonyParametere.PublishDate } ");

        }

        [TestMethod()]
        public void PrincipalsEmailTest()
        {

            var parameter = new
            {
                SchoolYear = "20192020",
                SchoolCode = "0227",
                PositionID = "14641"
            };

    
            //Act
            string result = PublishPositionExe<string>.PrincipalsEmail(parameter);
          

            //Assert
            Assert.IsNotNull(result, $"request position Info  { result} .");


        
        }

        [TestMethod()]
        public void AttributeTest()
        {

            //Arrange
            string action = "PositionInfo";
            publish.UserID = "mif";
            publish.Operate = action;
            publish.SchoolYear = "20192020";
            publish.SchoolCode = "0549";
            publish.PositionID = getNewPublishID("LTO").ToString();
            //act
            string expect = "0549";

            //Act
            string result = PublishPositionExe<string>.Attribute(publish);

            //Assert
            Assert.IsNotNull(result, $"request position Info  { result} .");
        }
    }
}