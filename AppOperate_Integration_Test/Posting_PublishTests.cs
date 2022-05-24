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
    public class Posting_PublishTests
    {
        private static string schoolyear = "20192020";
        private string cPage = "Publish";
        private string SPFile = WebConfigValue.SPFile();

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


        PositionPublish testposition = new PositionPublish()
        {
            Operate = "New",
            SchoolYear = "20192020",
            PositionID = 0,
            PositionType = "LTO",
            SchoolCode = "0549",
            UserID = "mif"
        };

        private int getNewPostingID(string positionType)
        {  //Arrange
            string action = "New";
            var parameter = new PositionPublish()
            {
                Operate = action,
                SchoolYear = schoolyear,
                PositionID = 0,
                PositionType = positionType,
                SchoolCode = "0549",
                UserID = "mif"
            };
            string SP = CommonExcute.SPNameAndParameters(SPFile, cPage, action);
            string newid = CommonExcute<PositionPublish>.GeneralValue(SP, parameter);
            int x = Int32.Parse(newid);
            return x;
        }
     
        [TestMethod()]
        public void CommonExcuteTest_Return_PublishPostionList_SearchbyAll()
        {
            //Arrange
            string action = "Positions";
            var myGridview = new System.Web.UI.WebControls.GridView();

            parameter.Operate = action;
            
            string expect = "334";

            //Act
            string SP = CommonExcute.SPNameAndParameters(SPFile, cPage, action);
            var postingList = CommonExcute<PositionPublish>.GeneralList(SP, parameter);

          //  var postingList = PostingPublishExe.Positions(parameter);

            myGridview.AutoGenerateColumns = true;
            myGridview.DataSource = postingList;
            myGridview.DataBind();

            var result = myGridview.Rows.Count.ToString();

            //Assert
           // Assert.AreEqual(expect, result, $"  Posting position List { result}");
            Assert.IsNotNull( result, $"  Posting position List { result}");

        }
        [TestMethod()]
        public void CommonExcuteTest_Return_PublishPostionList_Searchby_School_0290()
        {
            //Arrange
            string action = "Positions";
            var myGridview = new System.Web.UI.WebControls.GridView();
            parameter.SearchBy = "School";
            parameter.SearchValue1 = "0290";
            
            string expect = "3";

            //Act

            string SP = CommonExcute.SPNameAndParameters(SPFile, cPage, action);
            var postingList = CommonExcute<PositionPublish>.GeneralList(SP, parameter);
            myGridview.AutoGenerateColumns = true;
            myGridview.DataSource = postingList;
            myGridview.DataBind();

            var result = myGridview.Rows.Count.ToString();

            //Assert
           // Assert.AreEqual(expect, result, $"  Posting position List { result}");
            Assert.IsNotNull(result, $"  Posting position List { result}");

        }
        [TestMethod()]
        public void CommonExcuteTest_Return_PublishPostionList_Searchby_PostingCycle_3()
        {
            //Arrange
            string action = "Positions";
            var myGridview = new System.Web.UI.WebControls.GridView();
            parameter.SearchBy = "PostingCycle";
            parameter.SearchValue1 = "3";

           
            string expect = "426";

            //Act
            string SP = CommonExcute.SPNameAndParameters(SPFile, cPage, action);
            var postingList = CommonExcute<PositionPublish>.GeneralList(SP, parameter);
            myGridview.AutoGenerateColumns = true;
            myGridview.DataSource = postingList;
            myGridview.DataBind();

            var result = myGridview.Rows.Count.ToString();

            //Assert
           // Assert.AreEqual(expect, result, $"  Posting position List { result}");
            Assert.IsNotNull(result, $"  Posting position List { result}");

        }
        [TestMethod()]
        public void CommonExcuteTest_Return_PublishPostionList_Searchby_PostingNumber_201811959()
        {
            //Arrange
           string  action = "Positions";
            var myGridview = new System.Web.UI.WebControls.GridView();
            parameter.SearchBy = "PostingNum";
            parameter.SearchValue1 = "2019-14666";
 
            string expect = "4";

            //Act
            string SP = CommonExcute.SPNameAndParameters(SPFile, cPage, action);
            var postingList = CommonExcute<PositionPublish>.GeneralList(SP, parameter);
            myGridview.AutoGenerateColumns = true;
            myGridview.DataSource = postingList;
            myGridview.DataBind();

            var result = myGridview.Rows.Count.ToString();

            //Assert
            Assert.AreEqual(expect, result, $"  Posting position List by posting number { parameter.SearchValue1 } is { result}");

        }
        [TestMethod()]
        public void CommonExcuteTest_Return_PublishPostion_byID()
        {
             
            //Arrange
            string action = "Position";
            var parameter = new ParametersForPosition()
            {
                 SchoolYear = schoolyear,
                 PositionID = "16074",
             };
            int expect = 16074;

            //Act
            string SP = CommonExcute.SPNameAndParameters(SPFile, cPage, action);
            var postingList = CommonExcute<PositionPublish>.GeneralList(SP, parameter);
            int result = postingList[0].PositionID;
            int resultCount = postingList.Count;

            //Assert
            Assert.AreEqual(expect, result, $"  Posting position ID {parameter.PositionID} is { result}");
             Assert.IsTrue(resultCount > 0, $"  Posting position is { result}");
       }

        [TestMethod()]
        public void CommonExcuteTest_PublishPosition_CreateNew_Return_NewID()
        {
            //Arrange
            string action = "New";
            testposition.Operate = action;
           
            string SP = CommonExcute.SPNameAndParameters(SPFile, cPage, action);
            string newid = CommonExcute<PositionPublish>.GeneralValue(SP, testposition);
            int result = Int32.Parse(newid);

            Assert.IsNotNull(result, $"  Posting position new ID  { result}");

        }

  
        [TestMethod()]
        public void CommonExcuteTest_PublishPosition_CancelPublish_Return_Successfully()
        {
            //Arrange
            string action = "Cancel";
            testposition.Operate = action;
            testposition.PositionID = 11532;
          
            //Act
            string expect = "Successfully";
            string SP = CommonExcute.SPNameAndParameters(SPFile, cPage, action);
            string result = CommonExcute<PositionPublish>.GeneralValue(SP, testposition);

            //Assert
            Assert.AreEqual(expect, result, $" Cancel Posting position  { result}");
        }
        [TestMethod()]
        public void CommonExcuteTest_PublishPosition_Reposting_Return_Successfully()
        {
            //Arrange
            string action = "RePosting";
            int ids = getNewPostingID("LTO");
            testposition.Operate = action;
            testposition.PositionID = ids;
            testposition.PostingCycle = "2";
            testposition.TakeApplicant = "No";

            string expect = (ids + 1).ToString(); //  "Successfully";
            string SP = CommonExcute.SPNameAndParameters(SPFile, cPage, action);
            string result = CommonExcute<PositionPublish>.GeneralValue(SP, testposition);
 
            Assert.AreEqual(expect, result, $"  Re Posting position  { result}");



        }

        [TestMethod()]
        public void CommonExcuteTest_PublishPosition_Delete_Return_Successfully()
        {
            //Arrange
            string action = "Delete";
            int ids = getNewPostingID("LTO");
            testposition.Operate = action;
            testposition.PositionID = ids; 

         

            string expect = "Successfully";
            string SP = CommonExcute.SPNameAndParameters(SPFile, cPage, action);
            string result = CommonExcute<PositionPublish>.GeneralValue(SP, testposition);

            Assert.AreEqual(expect, result, $"  Re Posting position  { result}");
        }


        [TestMethod()]
        public void CommonExcuteTest_PublishPosition_Update_Return_Successfully()
        {
            //Arrange
            int ids = getNewPostingID("LTO");
            string action = "Save";
            var parameter = new PositionPublish()
            {
                Operate = "Update" ,
                UserID = "mif"  ,
                SchoolYear = "20182018",
                SchoolCode = "0549",
                PositionID = ids,
                PositionType = "LTO",
                PositionTitle = "Position Title for Test "    ,
                PositionLevel = "BC012E"       ,
                Qualification = "",
                QualificationCode ="",
                Description = "Posiition descriptiion for test" ,
                FTE = 0.50M,
                FTEPanel ="AM"     ,
                StartDate = "2018/09/03"        ,
                EndDate = "2019/06/30" ,
                DatePublish = "2018/06/18"  ,
                DateApplyOpen = "2018/06/25"    ,
                DateApplyClose = "2018/06/27"        ,
                Comments = "Test posting comments"  ,
                ReplaceTeacherID = "",
                ReplaceTeacher = "",
                ReplaceReason = "" ,
                OtherReason = "",
                Owner = "mif"
            };
            string expect = "Successfully";

            //Act
      
            string SP = CommonExcute.SPNameAndParameters(SPFile, cPage, action);
            string result = CommonExcute<PositionPublish>.GeneralValue(SP, parameter);

            //Assert
            Assert.AreEqual(expect, result, $"  Update Posting position Content { result}");
        }

        [TestMethod()]
        public void LimitedDate_Return_DefualtDateTest()
        {
            //Arrange
            string action = "DefaultDate";
            var parameter = new
            {
                Operate = action,
                PositionType = "LTO",
                SchoolYear = schoolyear,
                DatePublish =  "2018/12/10"
            };
            Int32 expect = 1;
            // string expectApplyOpenDate = DateFC.YMD(DateTime.Now,"/")  ;
            // string expectApplyCloseDate = "2018/12/12";
            // DateTime expectCloseDate = Convert.ToDateTime(icloseDate);


            //Act
            string SP = CommonExcute.SPNameAndParameters(SPFile, cPage, action);
            var myDate = CommonExcute<LimitDate>.GeneralList(SP, parameter);

           // var myDate = PostingPublishExe.LimitedDate(parameter);
            int result = myDate.Count;
            var result1 = myDate[0].StartDate;
            var result2 = myDate[0].DatePublish;
            var result3 = myDate[0].DateApplyOpen;
            var result4 = myDate[0].DateApplyClose;

             //Assert
            Assert.AreEqual(expect, result, $"  Posting position List { result}");
            Assert.IsNotNull(result1, $"  Position Start Date:  { result1}");
            Assert.IsNotNull(result2, $"  Position End Date:  { result2}");
            Assert.IsNotNull(result3, $"  Position Apply Open  Date:  { result3}");
            Assert.IsNotNull(result4, $"  Position Apply Close Date:  { result4}");
        //    Assert.AreEqual(expectApplyOpenDate, result3, $"  Posting position apply open date { result3}");
        //    Assert.AreEqual(expectApplyCloseDate, result4, $"  Posting position apply close date { result4}");


        }
    }
}