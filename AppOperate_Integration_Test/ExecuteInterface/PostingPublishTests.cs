using System;
using AppOperate.ExecuteInterface;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppOperate.ExecuteInterface.Tests
{
    [TestClass()]
    public class PostingPublishTests

    {
        private int getNewPublishID(string positionType)
        {
            NewPosition publish = new NewPosition()
            {
                Operate = "New",
                SchoolYear = "20192020",
                PositionID = "0",
                PositionType = "LTO",
                SchoolCode = "0549",
                UserID = "mif"
            };
            publish.PositionType = positionType;
            string newid = PublishPositionExe<string>.Add(publish);
            int x = Int32.Parse(newid);
            return x;
        }


        //[TestMethod()]
        //public void PositionTest_return_a_Published_Position_from_PositinoID_15574()
        //{
        //    // Arrange
        //    var expect = "15574";
        //    string action = "Position";
        //    var parameter = new { SchoolYear = "20192020", PositionID = expect };
        //  //  var myList = new PostingPosition<PositionPublish>(new PostingPublish<PositionPublish>());
        //    var myList = new Posting(new PostingPublish());


        //    //   IPostingPosition<PositionPublish> myList = new PostingPublish<PositionPublish>();
        //    var testList = myList.Position<PositionPublish>(parameter);// RequestPostingExe.Positions(parameter);
        //    var result = testList[0].PositionID.ToString();

        //    //Assert
        //    Assert.AreEqual(expect, result, $"  Posting position List { result}");
        //}

        //[TestMethod()]
        //public void PositionsTest_Return_All_Published_PositionList()
        //{    //Arrange
        //    ParametersForPositionList parameter = new ParametersForPositionList()
        //    {
        //        Operate = "Position",
        //        UserID = "mif",
        //        SchoolYear = "20192020",
        //        PositionType = "LTO",
        //        Panel = "All",
        //        Status = "Open",
        //        SearchBy = "All",
        //        SearchValue1 = "",
        //        SearchValue2 = ""
        //    };
        //    string action = "Position";
        //    //  parameter.Operate = action;
        //    string expect = "334";

        //    //Act     
        //   // var myList = new PostingPosition<PositionListPublish>(new PostingPublish<PositionListPublish>());
        //    var myList = new Posting(new PostingPublish());
        //    // IPostingPosition<PositionListPublish> myList = new PostingPublish<PositionListPublish>();
        //    var testList = myList.Positions<PositionListPublish>(parameter);
        //    var myGridview = new System.Web.UI.WebControls.GridView();
        //    myGridview.AutoGenerateColumns = true;
        //    myGridview.DataSource = testList;
        //    myGridview.DataBind();
        //    var result = myGridview.Rows.Count.ToString();

        //    //Assert
        //    // Assert.AreEqual(expect, result, $"  Posting position List { result}");
        //    Assert.IsNotNull(result, $"  Request Posting position List { result}");

        //}

        [TestMethod()]
        public void UpdateTest_createNewPublish_and_Update_Position_Return_Successfully()
        {
            //Arrange

            var parameter = new ParametersForPosition()
            {
                SchoolYear = "20192020",
                PositionID = getNewPublishID("LTO").ToString()
            };
            var position = PublishPositionExe<PositionPublish>.Position(parameter)[0];
            position.Operate = "Update";
            position.SchoolYear = "20192020";
            position.PositionTitle = "Test Grade 10 Teacher";
            position.PositionLevel = "BC708E";
            position.Description = " position descriptions from HR staff using interface method";
            position.StartDate = "2019/09/03";
            position.EndDate = "2020/06/30";
            position.DatePublish = "2019/12/11";
            position.DateApplyOpen = "2019/12/13";
            position.DateApplyClose = "2019/12/15";


            string expect = "Successfully";

            //Act    
           var testPosition =  new Posting(new PostingPublish());
           // IPostingPosition<string> testPosition = new PostingPublish<string>();
          //  var testList = testPosition.Update(parameter)  .Position(parameter);// RequestPostingExe.Positions(parameter);
            string result = testPosition.Update(position);

            //Assert
            Assert.AreEqual(expect, result, $" Postion update is { result} ");
        }
    }
}