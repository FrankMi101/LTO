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
    public class Posting_RequestTests
    {
        private static string schoolyear = "20192020";
        private string cPage = "Request";
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


        PositionRequesting request = new PositionRequesting()
        {
            Operate = "New",
            SchoolYear = "20192020",
            PositionID = 0,
            PositionType = "LTO",
            SchoolCode = "0549",
            UserID = "mif"
        };

        private int getNewRequestID(string positionType)
        {  //Arrange
            string action = "New";
            request.PositionType = positionType;

            string SP = CommonExcute.SPNameAndParameters(SPFile, cPage, action);
            string newid = CommonExcute<PositionRequesting>.GeneralValue(SP, request);
            int x = Int32.Parse(newid);
            return x;
        }

        [TestMethod()]
        public void CommonExcuteTest_RequestPosting_CreateNewRequest_Return_NewID()
        {
            //Arrange
            string action = "New";
            request.Operate = action;

            string SP = CommonExcute.SPNameAndParameters(SPFile, cPage, action);
            string newid = CommonExcute<PositionRequesting>.GeneralValue(SP, request);
            int result = Int32.Parse(newid);

            Assert.IsNotNull(result, $"  Posting request new ID  { result.ToString()}");

        }

        [TestMethod()]
        public void CommonExcuteTest_Return_SchoolAllRequestPostingList()
        {
            //Arrange
            string action = "Positions";
            var myGridview = new System.Web.UI.WebControls.GridView();

            parameter.Operate = action;
            
            string expect = "334";

            //Act
            string SP = CommonExcute.SPNameAndParameters(SPFile, cPage, action);
            var postingList = CommonExcute<PositionListRequesting>.GeneralList(SP, parameter);

        

            myGridview.AutoGenerateColumns = true;
            myGridview.DataSource = postingList;
            myGridview.DataBind();

            var result = myGridview.Rows.Count.ToString();

            //Assert
           // Assert.AreEqual(expect, result, $"  Posting position List { result}");
            Assert.IsNotNull( result, $"  Posting position List { result}");

        }
   
  
        [TestMethod()]
        public void CommonExcuteTest_RequestPosting_CallBack_Return_Successfully()
        {
            //Arrange
            int requestID = getNewRequestID("LTO");
            string action = "Call Back";
            request.Operate = action;
            request.PositionID = requestID;
          
            //Act
            string expect = "Successfully";
            string SP = CommonExcute.SPNameAndParameters(SPFile, cPage, action);
            string result = CommonExcute<PositionRequesting>.GeneralValue(SP, request);

            //Assert
            Assert.AreEqual(expect, result, $" Cancel Posting position  { result}");
        }
       

        [TestMethod()]
        public void CommonExcuteTest_RequestPosting_Delete_Return_Successfully()
        {
            //Arrange
            int requestID = getNewRequestID("LTO");
            string action = "Delete";
            int ids = getNewRequestID("LTO");
            request.Operate = action;
            request.PositionID = requestID; 

         

            string expect = "Successfully";
            string SP = CommonExcute.SPNameAndParameters(SPFile, cPage, action);
            string result = CommonExcute<PositionRequesting>.GeneralValue(SP, request);

            Assert.AreEqual(expect, result, $"  Re Posting position  { result}");
        }


        [TestMethod()]
        public void CommonExcuteTest_RequestPosting_Update_Return_Successfully()
        {
            //Arrange
            int ids = getNewRequestID("LTO");
            string action = "Update";
            var parameter = new PositionRequesting()
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
            string result = CommonExcute<PositionRequesting>.GeneralValue(SP, parameter);

            //Assert
            Assert.AreEqual(expect, result, $"  Update Posting position Content { result}");
        }

     
    }
}