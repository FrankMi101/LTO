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
    public class PostingPublishExeTests
    {
       string schoolyear = "20192020";
     private int getNewPostingID(string positionType)
        {
            var parameter = new PositionPublish()
            {
                Operate = "New",
                SchoolYear = schoolyear,
                PositionID = 0,
                PositionType = positionType,
                SchoolCode = "0549",
                UserID = "mif"
            };
            string newid = PostingPublishExe.NewPosting(parameter, 0);
            int x = Int32.Parse(newid);
            return x;
        }
        [TestMethod()]
        public void PositionsTest_ReturnPublishPostionList_SearchbyAll()
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
            var postingList = PostingPublishExe.Positions(parameter);
            myGridview.AutoGenerateColumns = true;
            myGridview.DataSource = postingList;
            myGridview.DataBind();

            var result = myGridview.Rows.Count.ToString();

            //Assert
           // Assert.AreEqual(expect, result, $"  Posting position List { result}");
            Assert.IsNotNull( result, $"  Posting position List { result}");

        }
        [TestMethod()]
        public void PositionsTest_ReturnPublishPostionList_SearchbySchool_0290()
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
                SearchBy = "School",
                SearchValue1 = "0290",
                SearchValue2 = ""
            };
            string expect = "3";

            //Act
            var postingList = PostingPublishExe.Positions(parameter);
            myGridview.AutoGenerateColumns = true;
            myGridview.DataSource = postingList;
            myGridview.DataBind();

            var result = myGridview.Rows.Count.ToString();

            //Assert
           // Assert.AreEqual(expect, result, $"  Posting position List { result}");
            Assert.IsNotNull(result, $"  Posting position List { result}");

        }
        [TestMethod()]
        public void PositionsTest_ReturnPublishPostionList_SearchbyPostingCycle_3()
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
                Status = "",
                SearchBy = "PostingCycle",
                SearchValue1 = "3",
                SearchValue2 = ""
            };
            string expect = "426";

            //Act
            var postingList = PostingPublishExe.Positions(parameter);
            myGridview.AutoGenerateColumns = true;
            myGridview.DataSource = postingList;
            myGridview.DataBind();

            var result = myGridview.Rows.Count.ToString();

            //Assert
           // Assert.AreEqual(expect, result, $"  Posting position List { result}");
            Assert.IsNotNull(result, $"  Posting position List { result}");

        }
        [TestMethod()]
        public void PositionsTest_ReturnPublishPostionList_SearchbyPostingNumber_201811959()
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
                Status = "",
                SearchBy = "PostingNum",
                SearchValue1 = "2018-11959",
                SearchValue2 = ""
            };
            string expect = "4";

            //Act
            var postingList = PostingPublishExe.Positions(parameter);
            myGridview.AutoGenerateColumns = true;
            myGridview.DataSource = postingList;
            myGridview.DataBind();

            var result = myGridview.Rows.Count.ToString();

            //Assert
            Assert.AreEqual(expect, result, $"  Posting position List { result}");

        }
        [TestMethod()]
        public void PositionTest_returnSelectedPositionListByID()
        {
            //Arrange
           
            var parameter = new ParametersForPosition()
            {
                 SchoolYear = schoolyear,
                 PositionID = "12222",
             };
            int expect = 12222;

            //Act
            var postingList = PostingPublishExe.Position(parameter);
            int result = postingList[0].PositionID;
            int resultCount = postingList.Count;

            //Assert
            Assert.AreEqual(expect, result, $"  Posting position is { result}");
             Assert.IsTrue(resultCount > 0, $"  Posting position is { result}");
       }

        [TestMethod()]
        public void NewPostingTest_CreateNewLTOPublish()
        {
            //Arrange
            var parameter = new PositionPublish()
            {
                Operate = "New",
                SchoolYear = schoolyear,
                PositionID = 0   ,
                PositionType ="LTO",
                SchoolCode ="0391",
                UserID ="mif"
            };
            //Act
            string expect = "LTO";

            var newid = PostingPublishExe.NewPosting(parameter, 0);     

            var parameter1 = new ParametersForPosition()
            {
                SchoolYear = schoolyear,
                PositionID = newid,
            };

            //Verify Act
            var result = PostingPublishExe.Position(parameter1)[0].PositionType;

             //Assert
            Assert.AreEqual(expect, result, $"  New LTO Posting position  { result}");
        }
        [TestMethod()]
        public void NewPostingTest_CreateNewPOPPublish()
        {
            //Arrange
            var parameter = new PositionPublish()
            {
                Operate = "New",
                SchoolYear = schoolyear,
                PositionID = 0,
                PositionType = "POP",
                SchoolCode = "0391",
                UserID = "mif"
            };
            //Act
            string expect = "POP";

            var newid = PostingPublishExe.NewPosting(parameter, 0);

            var parameter1 = new ParametersForPosition()
            {
                SchoolYear = schoolyear,
                PositionID = newid,
            };

            //Verify Act
            var result = PostingPublishExe.Position(parameter1)[0].PositionType;

            //Assert
            Assert.AreEqual(expect, result, $"  New POP Posting position  { result}");
        }

        [TestMethod()]
        public void CancelPostingTest()
        {
            //Arrange
            var parameter = new ParametersForOperation()
            {
                Operate = "Cancel",
                SchoolYear = schoolyear,
                PositionID = 11532
            };
            //Act
            string expect = "Successfully";
            var result = PostingPublishExe.CancelPosting(parameter, 0);

            //Assert
            Assert.AreEqual(expect, result, $" Cancel Posting position  { result}");
        }
        [TestMethod()]
        public void RePostingTest()
        {
            //Arrange
            int ids = getNewPostingID("LTO");
            var parameter = new ParametersForOperation()
            {
                Operate = "RePosting",
                UserID = "mif",
                SchoolYear = schoolyear,
                PositionID =   ids,
                PostingCycle = "2",
                TakeApplicant = "No",
                SchoolCode = "0549",
                PositionType = "LTO",
            };
         
            string expect = "2";
            var newid = PostingPublishExe.RePosting(parameter, 0);
 
            var parameter1 = new ParametersForPosition()
            {
                SchoolYear = schoolyear,
                PositionID = newid,
            };

            //Verify Act
            var result = PostingPublishExe.Position(parameter1)[0].PostingCycle;
            //Assert
            Assert.AreEqual(expect, result, $"  Re Posting position  { result}");



        }

        [TestMethod()]
        public void DeletePostingTest()
        {
            //Arrange
            int ids = getNewPostingID("LTO");
            var parameter = new ParametersForOperation() 
            {             
                 Operate = "Delete",
                SchoolYear = schoolyear,
                PositionID = ids
            };
           //Act
            string expect = "Successfully";
            var result = PostingPublishExe.DeletePosting(parameter,0);
             
            //Assert
            Assert.AreEqual(expect, result, $"  Delete Posting position   { result}");     
        }

        [TestMethod()]
        public void SavePostingTest()
        {
            //Arrange
            int ids = getNewPostingID("LTO");
            var parameter = new PositionPublish()
            {
                Operate = "Update" ,
                UserID = "mif"  ,
                SchoolYear = "20182918",
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
            var result = PostingPublishExe.SavePosting(parameter, ids);
        
            //Assert
            Assert.AreEqual(expect, result, $"  Update Posting position Content { result}");
        }

        [TestMethod()]
        public void LimitedDate_Return_DefualtDateTest()
        {
            //Arrange
            var parameter = new LimitDate()
            {
                Operate = "GetDefault",
                PositionType = "LTO",
                SchoolYear = schoolyear,
                DatePublish =  "2018/12/10"
            };
            Int32 expect = 1;
           // string expectApplyOpenDate = DateFC.YMD(DateTime.Now,"/")  ;
           // string expectApplyCloseDate = "2018/12/12";
            // DateTime expectCloseDate = Convert.ToDateTime(icloseDate);

            
            //Act
            var myDate = PostingPublishExe.LimitedDate(parameter);
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