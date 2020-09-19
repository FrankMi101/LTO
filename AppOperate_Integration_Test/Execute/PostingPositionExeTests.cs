using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AppOperate.Tests
{
    [TestClass()]
    public class PostingPositionExeTests
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
        private int GetNewRequestId(string positionType)
        {

            request.PositionType = positionType;
            string newid = RequestPostingExe.Add(request);
            int x = Int32.Parse(newid);
            return x;
        }

        [TestMethod()]
        public void SPNameTest_retrun_Positions_StoreProcedure_name()
        {
            //Arrange 
            string action = "Positions";

            //Act
            string expect = "dbo.tcdsb_LTO_PageApprove_Positions @Operate,@UserID,@SchoolYear,@PositionType,@Panel,@Status,@SearchBy,@SearchValue1,@SearchValue2";
            string result = PostingPositionExe.SPName(action);

            //Assert
            Assert.AreEqual(expect, result, $" Appraove  Positions list Store Procedure Name:  { result}");

        }
        [TestMethod()]
        public void SPNameTest_retrun_Position_StoreProcedure_name()
        {
            //Arrange 
            string action = "Position";

            //Act
            string expect = "dbo.tcdsb_LTO_PageApprove_Position @SchoolYear,@PositionID";
            string result = PostingPositionExe.SPName(action);

            //Assert
            Assert.AreEqual(expect, result, $" Approve position  by requestid :  { result}");

        }
        [TestMethod()]
        public void SPNameTest_retrun_PostingPosition_StoreProcedure_name()
        {
            //Arrange 
            string action = "Posting";

            //Act
            string expect = "dbo.tcdsb_LTO_PageApprove_OperationPosting @Operate,@UserID,@SchoolYear,@SchoolCode,@PositionID,@Comments,@CPNum,@StartDate,@EndDate,@DatePublish,@DateApplyOpen,@DateApplyClose,@RequestSource";
            string result = PostingPositionExe.SPName(action);

            //Assert
            Assert.AreEqual(expect, result, $" Approve position  by requestid :  { result}");

        }
        [TestMethod()]
        public void SPNameTest_retrun_RejectRequest_StoreProcedure_name()
        {
            //Arrange 
            string action = "Reject";

            //Act
            string expect = "dbo.tcdsb_LTO_PageApprove_OperationReject @Operate,@UserID,@SchoolYear,@SchoolCode,@PositionID,@Comments,@CPNum";
            string result = PostingPositionExe.SPName(action);

            //Assert
            Assert.AreEqual(expect, result, $" Approve position  by requestid :  { result}");

        }

        [TestMethod()]
        public void PositionsTest_return_allActive_schoolRequestedPostingPosition()
        {
            //Arrange
            var gridView = new System.Web.UI.WebControls.GridView();
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
            //Act
            var postingList = PostingPositionExe.Positions(parameter);
            string expect = "";
            gridView.AutoGenerateColumns = true;
            gridView.DataSource = postingList;
            gridView.DataBind();

            var result = gridView.Rows.Count.ToString();

            //Assert
            Assert.IsNotNull(result, $" Posting positions count is { result } ");
        }

        [TestMethod()]
        public void PositionTest_return_postingRequestPosition_byRequestID()
        {
            //Arrange
            int newRequest = GetNewRequestId("LTO"); // create new request
            var parameter = new
            {
                SchoolYear = "20192020",
                PositionID = newRequest
            };

            //Act
            var postingPosition = PostingPositionExe.Position(parameter);  // get request poting 
            string result = postingPosition[0].RequestSource;
            string expect = "Principal";

            //Assert
            Assert.AreEqual(expect, result, $" request posting position is {postingPosition[0].PositionID} ");
        }

        [TestMethod()]
        public void SaveTest_return_successfully_Save_EditContent()
        {
            //Arrange        
            var parameter = new
            {
                SchoolYear = "20192020",
                PositionID = GetNewRequestId("LTO").ToString() // create new request
            };
            var parameterForDeadline = new
            {
                SchoolYear = "20192020",
                DatePublish = "2019/11/12",
                PositionType = "LTO"
            };
            var requestPosition = PostingPositionExe.Position(parameter)[0]; // get the posting position
            requestPosition.Operate = "Save";
            requestPosition.Comments = "Posting school request post position test process";
            requestPosition.CPNum = "00000000";
            requestPosition.StartDate = "2019/09/03";
            requestPosition.EndDate = "2020/06/30";
            requestPosition.DatePublish = "2019/11/11";
            requestPosition.DateApplyOpen = "2019/11/12";
            requestPosition.DateApplyClose = PublishPositionExe.Deadline(parameterForDeadline);
            requestPosition.Qualification = "";
            requestPosition.QualificationCode = "";
            requestPosition.FTE = 1.00M;
            requestPosition.FTEPanel = "Full";

            //Act
            string result = PostingPositionExe.Save(requestPosition);
            string expect = "Successfully";
            //Assert
            Assert.AreEqual(expect, result, $"Posting Edit save action for { parameter.PositionID } is { result }");

        }

        [TestMethod()]
        public void RejectTest_return_rejectResult_Successfully()
        {

            //Arrange        
            var parameter = new
            {
                SchoolYear = "20192020",
                PositionID = GetNewRequestId("LTO").ToString() // create new request
            };

            var requestPosition = PostingPositionExe.Position(parameter)[0]; // get the posting position
            requestPosition.Comments = "Reject school request post position test process";
            requestPosition.CPNum = "00000000";

            string expect = "Successfully";


            //Act
            string result = PostingPositionExe.Reject(requestPosition); // go for posting


            //Assert 
            Assert.AreEqual(expect, result, $"Reject posting request on  { parameter.PositionID } is { result }  ");



        }

        [TestMethod()]
        public void PostingTest_return_PublishPositionID()
        {
            //Arrange        
            var parameter = new
            {
                SchoolYear = "20192020",
                PositionID = GetNewRequestId("LTO").ToString() // create new request
            };

            var parameterForDeadline = new
            {
                SchoolYear = "20192020",
                DatePublish = "2019/11/12",
                PositionType = "LTO"
            };
            var requestPosition = PostingPositionExe.Position(parameter)[0]; // get the posting position
            requestPosition.Comments = "Posting school request post position test process";
            requestPosition.CPNum = "00000000";
            requestPosition.StartDate = "2019/09/03";
            requestPosition.EndDate = "2020/06/30";
            requestPosition.DatePublish = "2019/11/11";
            requestPosition.DateApplyOpen = "2019/11/12";
            requestPosition.DateApplyClose = PublishPositionExe.Deadline(parameterForDeadline);

            //Act
            string postingPositionId = PostingPositionExe.Posting(requestPosition); // go for posting

            var parameterFormPublishPosition = new
            {
                SchoolYear = "20192020",
                PositionID = postingPositionId
            };

            var publishPosition = PublishPositionExe.Position(parameterFormPublishPosition)[0]; // get Published Position
            string expect = parameter.PositionID;
            string result = publishPosition.RequestID.ToString();

            //Assert 
            Assert.AreEqual(expect, result, $"position posted new position ID is { postingPositionId }. request ID is { result }  ");

        }

        [TestMethod()]
        public void PostingNumberTest()
        {
            //Arrange        
            var parameter = new
            {
                SchoolYear = "20192020",
                PositionID = GetNewRequestId("LTO").ToString() // create new request
            };

            var parameterForDeadline = new
            {
                SchoolYear = "20192020",
                DatePublish = "2019/11/12",
                PositionType = "LTO"
            };
            var requestPosition = PostingPositionExe.Position(parameter)[0]; // get the posting position
            requestPosition.Comments = "Posting school request post position test process";
            requestPosition.CPNum = "00000000";
            requestPosition.StartDate = "2019/09/03";
            requestPosition.EndDate = "2020/06/30";
            requestPosition.DatePublish = "2019/11/11";
            requestPosition.DateApplyOpen = "2019/11/12";
            requestPosition.DateApplyClose = PublishPositionExe.Deadline(parameterForDeadline);

            //Act
            string postingPositionId = PostingPositionExe.Posting(requestPosition); // go for posting

            var parameterForGetPostingNumber = new
            {
                Operate = "Get",
                PositionID = postingPositionId
            };

            var result = PostingPositionExe.PostingNumber(parameterForGetPostingNumber); // get Published Position
            string expect = DateTime.Now.Year.ToString() + "-" + postingPositionId;


            //Assert 
            Assert.AreEqual(expect, result, $"Posting Number  is { result }   ");

        }
    }

}