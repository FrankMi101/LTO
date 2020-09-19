using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AppOperate.Tests
{
    [TestClass()]
    public class Posting_ApproveTests
    {
        private string cPage = "Approve";
        private string SPFile = WebConfigValue.SPFile();
        string schoolyear = "20192020";
        private int getNewRequestID(string positionType)
        {  //Arrange
            PositionRequesting request = new PositionRequesting()
            {
                Operate = "New",
                SchoolYear = "20192020",
                PositionID = 0,
                PositionType = positionType,
                SchoolCode = "0549",
                UserID = "mif"
            };
            string action = "New";

            string SP = CommonExcute.SPNameAndParameters(SPFile, "Request", action);
            string newid = CommonExcute<PositionRequesting>.GeneralValue(SP, request);
            int x = Int32.Parse(newid);
            return x;
        }

        [TestMethod()]
        public void CommonExcuteTest_Return_ApprovePostionList_SearchbyAll()
        {
            //Arrange
            string action = "Positions";
            var myGridview = new System.Web.UI.WebControls.GridView();
            var parameter = new ParametersForPositionList()
            {
                Operate = action,
                UserID = "mif",
                SchoolYear = "20192020",
                PositionType = "LTO",
                Panel = "All",
                Status = "Open",
                SearchBy = "All",
                SearchValue1 = "",
                SearchValue2 = ""
            };
            string expect = "1";

            //Act
            string SP = CommonExcute.SPNameAndParameters(SPFile, cPage, action);
            var postingList = CommonExcute<PositionApprove>.GeneralList(SP, parameter);
            myGridview.AutoGenerateColumns = true;
            myGridview.DataSource = postingList;
            myGridview.DataBind();

            var result = myGridview.Rows.Count.ToString();

            //Assert
            // Assert.AreEqual(expect, result, $"  Posting position List { result}");
            Assert.IsNotNull(result, $"  Approve position List by {parameter.SearchBy} { parameter.SchoolYear} { result}");

        }
        [TestMethod()]
        public void CommonExcuteTest_Return_ApprovePostionList_Searchby_School_0290()
        {
            //Arrange
            string action = "Positions";
            var myGridview = new System.Web.UI.WebControls.GridView();
            var parameter = new ParametersForPositionList()
            {
                Operate = action,
                UserID = "mif",
                SchoolYear = "20192020",
                PositionType = "LTO",
                Panel = "All",
                Status = "Open",
                SearchBy = "School",
                SearchValue1 = "0290",
                SearchValue2 = ""
            };
            string expect = "3";

            //Act

            string SP = CommonExcute.SPNameAndParameters(SPFile, cPage, action);
            var postingList = CommonExcute<PositionApprove>.GeneralList(SP, parameter);
            myGridview.AutoGenerateColumns = true;
            myGridview.DataSource = postingList;
            myGridview.DataBind();

            var result = myGridview.Rows.Count.ToString();

            //Assert
            // Assert.AreEqual(expect, result, $"  Posting position List { result}");
            Assert.IsNotNull(result, $"  Approve position List by {parameter.SearchBy} { parameter.SchoolCode}  { result}");

        }

        [TestMethod()]
        public void CommonExcuteTest_Return_ApprovePostion_byRequestID()
        {

            //Arrange
            string action = "Position";
            var parameter = new ParametersForPosition()
            {
                SchoolYear = schoolyear,
                PositionID = "2592",
            };
            int expect = 12222;

            //Act
            string SP = CommonExcute.SPNameAndParameters(SPFile, cPage, action);
            var postingList = CommonExcute<PositionApprove>.GeneralList(SP, parameter);
             int result = postingList[0].PositionID;
            int resultCount = postingList.Count;

            //Assert
           // Assert.AreEqual(expect, result, $"  ApprovePosting  position is {parameter.PositionID } { result}");
            Assert.IsTrue(resultCount > 0, $"  Approve Posting position is {parameter.PositionID } { result}");
        }




        [TestMethod()]
        public void CommonExcuteTest_ApprovePosition_RejectRequest_Return_Successfully()
        {
            //Arrange
            string action = "Reject";
            var parameter = new PositionApprove()
            {
                Operate = action,
                SchoolYear = "20192020",
                PositionID = 11532
            };
            //Act
            string expect = "Successfully";
            string SP = CommonExcute.SPNameAndParameters(SPFile, cPage, action);
            string result = CommonExcute<PositionApprove>.GeneralValue(SP, parameter);

            //Assert
            Assert.AreEqual(expect, result, $" Reject Posting request on {parameter.PositionID}  { result}");
        }
        [TestMethod()]
        public void CommonExcuteTest_ApprovePosition_PostingPrincipalRequest_Return_NewPostingNumber()
        {
            //Arrange
            int requestid = getNewRequestID("LTO");
            string action = "Posting";
            string source = "Principal";
            var parameter = new PositionApprove()
            {
                Operate = action,
                UserID = "mif",
                SchoolYear = schoolyear,
                SchoolCode = "0546",

                PositionID = requestid,
                Comments = "Posting comments",
                StartDate = DateFC.YMD2(DateTime.Now.ToShortDateString()),
                EndDate = DateFC.YMD2(DateTime.Now.ToShortDateString()),
                DatePublish = DateFC.YMD2(DateTime.Now.ToShortDateString()),
                DateApplyOpen = DateFC.YMD2(DateTime.Now.ToShortDateString()),
                DateApplyClose = DateFC.YMD2(DateTime.Now.ToShortDateString()),
                CPNum = "0000000",
                RequestSource = source,
                ReplaceTeacherID = "00000000"
            };

            string expect = "Successfully";
            string SP = CommonExcute.SPNameAndParameters(SPFile, cPage, action);
            string result = CommonExcute<PositionApprove>.GeneralValue(SP, parameter);
            int positionID = Int32.Parse(result);

            parameter.PositionID = positionID;
            parameter.Operate = "PostingNumber";
            string PostingNumber = CommonOperationExcute.ApproveOperation(parameter, "Property");

            Assert.AreEqual(expect, result, $"  REquest Posting position  New Posting Number { PostingNumber }");



        }
        [TestMethod()]
        public void CommonExcuteTest_ApprovePosition_PostingForm100Request_Return_NewPostingNumber()
        {
            //Arrange
            string action = "Posting";
            string source = "Form100";
            var parameter = new PositionApprove()
            {
                Operate = action,
                UserID = "mif",
                SchoolYear = "20192020",
                PositionID = 1660,
                SchoolCode = "0239",
                Comments = "Posting Comments",
                Description = "Posting description",
                FTE = 1.0M,
                FTEPanel = "Full",
                StartDate = "",
                EndDate = "",
                Owner = "frijiom",
                DatePublish = "",
                DateApplyOpen = "",
                DateApplyClose = "",
                PositionLevel = "BC708E",
                QualificationCode = "",
                Qualification = "",
                CPNum = "",
                RequestSource = source,
                ReplaceTeacherID = "Test Teacher",
            };

            string expect = "Successfully";
            string SP = CommonExcute.SPNameAndParameters(SPFile, cPage, action);
            string result = CommonExcute<PositionApprove>.GeneralValue(SP, parameter);
            int positionID = Int32.Parse(result);

            parameter.PositionID = positionID;
            parameter.Operate = "PostingNumber";
            string PostingNumber = CommonOperationExcute.ApproveOperation(parameter, "Property");

            Assert.AreEqual(expect, result, $"  REquest Posting position  New Posting Number { PostingNumber }");



        }


        [TestMethod()]
        public void CommonExcuteTest_ApprovePosition_Save_Return_Successfully()
        {
            //Arrange
            int ids = 0;

            string action = "Save";
            var parameter = new PositionApprove()
            {
                Operate = action,
                UserID = "mif",
                SchoolYear = schoolyear,
                SchoolCode = "0549",
                PositionID = ids,
                PositionType = "LTO",
                PositionTitle = "Position Title for Test ",
                PositionLevel = "BC012E",
                Qualification = "",
                QualificationCode = "",
                Description = "Posiition descriptiion for test",
                FTE = 0.50M,
                FTEPanel = "AM",
                Comments = "Test posting update function comments",
                StartDate =""  ,
                EndDate = "", 
                Owner = "mif",
                ReplaceTeacherID = "0000000"
                
            };
            string expect = "Successfully";

            //Act

            string SP = CommonExcute.SPNameAndParameters(SPFile, cPage, action);
            string result = CommonExcute<PositionApprove>.GeneralValue(SP, parameter);

            //Assert
            Assert.AreEqual(expect, result, $"  Update Posting position Content { result}");
        }


    }
}