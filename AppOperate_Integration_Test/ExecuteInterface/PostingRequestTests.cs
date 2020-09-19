using System;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppOperate.ExecuteInterface.Tests
{
    [TestClass()]
    public class PostingRequestTes
    {


        private int getNewRequestID(string positionType)
        {
            NewPosition request = new NewPosition()
            {
                Operate = "New",
                SchoolYear = "20192020",
                PositionID = "0",
                PositionType = "LTO",
                SchoolCode = "0549",
                UserID = "mif"
            };

            request.PositionType = positionType;
            string newid = RequestPostingExe.Add(request);
            int x = Int32.Parse(newid);
            return x;
        }
        ParametersForPositionList parameter = new ParametersForPositionList()
        {
            Operate = "Positions",
            UserID = "mif",
            SchoolYear = "20192020",
            PositionType = "LTO",
            Panel = "All",
            Status = "Open",
            SearchBy = "All",
            SearchValue1 = "",
            SearchValue2 = ""
        };
        [TestMethod()]
        public void PositionTest_return_a_RequestPostionList_of_PositionID_2662()
        {

            // Arrange
            var expect = "2662";
            string action = "Position";
            var parameter = new { SchoolYear = "20192020", PositionID = expect };
            //  IPostingPosition<PositionRequesting> myList = new PostingRequest<PositionRequesting>();
            var myList = new Posting<PositionRequesting>(new PostingPublish<PositionRequesting>());
            var testList = myList.Position(parameter);// RequestPostingExe.Positions(parameter);
            var result = testList[0].PositionID.ToString();

            //Assert
            Assert.AreEqual(expect, result, $"  Posting position List { result}");
            //  Assert.IsNotNull(result, $"  Request Posting position List { result}");
        }

        [TestMethod()]
        public void PositionsTest_fromSearchConditionParameter_ReturnAllRequestList()
        {
            //Arrange
            string action = "Positions";
            var myGridview = new System.Web.UI.WebControls.GridView();
            //  parameter.Operate = action;
            string expect = "334";

            //Act     
            var parameter = new { Operate = action, UserID = "mif", SchoolYear = "20192020", SchoolCode = "0506" };
           // IPostingPosition<PositionListRequesting> myList = new PostingRequest<PositionListRequesting>();
            var myList = new Posting<PositionListRequesting>(new PostingRequest<PositionListRequesting>());
            var testList = myList.Positions(parameter);// RequestPostingExe.Positions(parameter);
            myGridview.AutoGenerateColumns = true;
            myGridview.DataSource = testList;
            myGridview.DataBind();
            var result = myGridview.Rows.Count.ToString();

            //Assert
            // Assert.AreEqual(expect, result, $"  Posting position List { result}");
            Assert.IsNotNull(result, $"  Request Posting position List { result}");
        }

        [TestMethod()]
        public void UpdateTest_create_a_NewRequest_and_Update_RequestInformation_return_Successfully()
        {
            //Arrange
            string action = "Update";
            var request = new PositionRequesting()
            {
                Operate = "Update",
                UserID = "mif",
                SchoolYear = "20192020",
                SchoolCode = "0549",
                PositionID = getNewRequestID("LTO"),
                Comments = "Test request posting Update function by new",
                PositionType = "LTO",
                PositionTitle = "English Grade 10 Teacher",
                PositionLevel = "BC003E",
                Qualification = "Biology; Science; Science - General; ",
                QualificationCode = "317; 401; 405; ",
                Description = "Biology; Science; Science - General; full time position need senior levelUpdate process from interface class",
                FTE = 1.00M,
                FTEPanel = "Full",
                StartDate = DateFC.YMD2("2019/09/01"),
                EndDate = DateFC.YMD2("2020/06/30"),
                ReplaceTeacher = "replace teachername",
                ReplaceTeacherID = "00019103",
                ReplaceReason = "6",
                OtherReason = "Medical Leave",
                Owner = "frijiom"
            };

            //Act


            //Act    
          //  IPostingPosition<string> testPosition = new PostingRequest<string>();

            var testPosition = new Posting(new PostingRequest());
            string result = testPosition.Update(request);  //string result = RequestPostingExe.Update(parameter);
            string expect = "Successfully";
            //Assert
            Assert.AreEqual(expect, result, $"  Request Posting Resulte { result}.");
        }
    }
}