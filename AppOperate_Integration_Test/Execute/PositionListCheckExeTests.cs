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
    public class PositionListCheckExeTests
    {
        private  string schoolyear = "20212022";
        private string cPage = "Request";
        PositionPublish publishposition = new PositionPublish();
        ParametersForPositionList parameter = new ParametersForPositionList()
        {
            Operate = "Positions",
            UserID = "mif",
            SchoolYear = "20212022",
            PositionType = "LTO",
            Panel = "All",
            Status = "Open",
            SearchBy = "All",
            SearchValue1 = "",
            SearchValue2 = ""
        };

        [TestMethod()]
        public void PublishPositionsTest()
        {
            //Arrange
           // var myGridview = new System.Web.UI.WebControls.GridView();
           
            string expect = "334";

            //Act
            List<PositionListPublish> checkList = PositionListCheckExe.PublishPositions(parameter);
            //myGridview.AutoGenerateColumns = true;
            //myGridview.DataSource = publishList;
            //myGridview.DataBind();

            var result = checkList.Count.ToString();//  myGridview.Rows.Count.ToString();

            //Assert
            Assert.IsNotNull(result, $" Publish positions count is { result } ");
        }

        [TestMethod()]
        public void HiredPositionTest()
        {
            //Arrange
            var parameter = CommonParameter.GetParameters("Get", "mif", "20212022", "LTO", "", "0", "", "","");
 
            //Act
            List<PositionListHired> checkList = PositionListCheckExe.HiredPositions(parameter);

            //Assert
            var result = checkList.Count.ToString();//  myGridview.Rows.Count.ToString();

            Assert.IsNotNull(result, $" position list count {result}");
        }
        [TestMethod()]
        public void HiredPosition4thRoundTest()
        {
            //Arrange
            var parameter = CommonParameter.GetParameters("Get", "mif", "20212022", "LTO", "", "1", "", "", "");

            //Act
            List<PositionListHired> checkList = PositionListCheckExe.HiredPositions(parameter);

            //Assert
            var result = checkList.Count.ToString();//  myGridview.Rows.Count.ToString();

            Assert.IsNotNull(result, $" position list count {result}");
        }

        [TestMethod()]
        public void AvailablePositionsTest()
        {
            //Arrange
            var parameter = CommonParameter.GetParameters("Get", "mif", "20212022", "LTO", "", "", "LTOTeacher", "00052589");

            //Act
            List<PositionListApplying> checkList = PositionListCheckExe.AvailablePositions(parameter);
            
            //Assert
            var result = checkList.Count.ToString();//  myGridview.Rows.Count.ToString();

            Assert.IsNotNull(result, $" position list count {result}");
        }

        [TestMethod()]
        public void SelectPositionsTest()
        {
            //Arrange
           // var parameter = CommonParameter.GetParameters("Get", "mif", "20212022", "LTO", "", "", "LTOTeacher", "00052589");

            //Act
            List<PositionListPublish> checkList = PositionListCheckExe.SelectPositions(parameter);

            //Assert
            var result = checkList.Count.ToString();//  myGridview.Rows.Count.ToString();

            Assert.IsNotNull(result, $" position list count {result}");
        }

        [TestMethod()]
        public void InterviewPositionsTest()
        {
            //Arrange
             var parameter = CommonParameter.GetParameters("Get", "mif", "20212022", "LTO", "", "", "LTOTeacher", "00052589");

            //Act
            List<PositionListPublish> checkList = PositionListCheckExe.InterviewPositions(parameter);

            //Assert
            var result = checkList.Count.ToString();//  myGridview.Rows.Count.ToString();

            Assert.IsNotNull(result, $" position list count {result}");
        }

        [TestMethod()]
        public void SelectCandidatesTest()
        {
            //Arrange
           // var parameters = CommonParameter.GetParameters3("IncludeAll", "20212022", "23886");
            var parameter = new { Operate = "IncludeAll", SchoolYear = "20212022", PositionID = "23886" };
            //Act
            List<ApplicantListSelect> checkList = PositionListCheckExe.SelectCandidates(parameter);

            //Assert
            var result = checkList.Count.ToString();//  myGridview.Rows.Count.ToString();

            Assert.IsNotNull(result, $" position list count {result}");
        }

        [TestMethod()]
        public void InterviewCandidatesTest()
        {
            //Arrange
         
            var parameter = new { SchoolYear = "20212022", PositionID = "23886"};

            //Act
            List<CandidateList> checkList = PositionListCheckExe.InterviewCandidates(parameter);

            //Assert
            var result = checkList.Count.ToString();//  myGridview.Rows.Count.ToString();

            Assert.IsNotNull(result, $" position list count {result}");
        }

        [TestMethod()]
        public void ConvertFunctionStringToTable_GoodValueTest()
        {
            //Arrange
            var parameter =  new { Operate ="StringToTable",StringValue="332;357;420;501;000",Delimiter =";", TableName = "", CheckType = "" } ;
            int expect = 5;
            //Act
            List<GeneralCheck> checkList = PositionListCheckExe.ConvertFunctionStringToTable(parameter);

            //Assert
            int result = checkList.Count;//  myGridview.Rows.Count.ToString();

            Assert.AreEqual(expect, result, $" position list count {result}");
        }
        [TestMethod()]
        public void ConvertFunctionStringToTable_BadInputValue_ReturnTableTest()
        {
            //Arrange
            var parameter = new { Operate = "StringToTable", StringValue = "33222; ;357;4;501;00012313;1;;24320824324", Delimiter = ";", TableName = "", CheckType = "" };
            int expect = 8;
            //Act
            List<GeneralCheck> checkList = PositionListCheckExe.ConvertFunctionStringToTable(parameter);

            //Assert
            int result = checkList.Count; //  myGridview.Rows.Count.ToString();

            Assert.AreEqual( expect, result, $" position list count {result}");
        }

        [TestMethod()]
        public void ConvertFunctionStringToTable_SingalInputValue_ReturnOneRecordTest()
        {
            //Arrange
            var parameter = new { Operate = "StringToTable", StringValue = "as ad adada adaas dad;", Delimiter = ";", TableName = "", CheckType = "" };
            int expect = 1;
            //Act
            List<GeneralCheck> checkList = PositionListCheckExe.ConvertFunctionStringToTable(parameter);

            //Assert
            int result = checkList.Count; //  myGridview.Rows.Count.ToString();

            Assert.AreEqual(expect, result, $" position list count {result}");
        }

        [TestMethod()]
        public void ConvertFunctionTableToString_NotSelectTestInputTable_ReturnStringInclude_GoodValue2_Test()
        {
            //Arrange
            var parameter = new { Operate = "TableToString", StringValue = "", Delimiter = ";", TableName = "",CheckType="" };
            var expect = "Good Value 2";
            //Act
            string  checkvalue = PositionListCheckExe.ConvertFunctionTableToString(parameter);

            //Assert
            var result = checkvalue;//  myGridview.Rows.Count.ToString();

            StringAssert.Contains(result, expect, $" position list count {result}");
        }

        [TestMethod()]
        public void ConvertFunctionTableToString_SelectTestTableInputTableWithGoodCheck_ReturnStringInclude_GoodValue2_Test()
        {
            //Arrange
            var parameter = new { Operate = "TableToString", StringValue = "", Delimiter = ";", TableName = "TestTable", CheckType = "Good" };
            var expect = "Good Value 1";
            //Act
            string checkvalue = PositionListCheckExe.ConvertFunctionTableToString(parameter);

            //Assert
            var result = checkvalue;//  myGridview.Rows.Count.ToString();

            StringAssert.Contains(result, expect, $" position list count {result}");

        }

        [TestMethod()]
        public void ConvertFunctionTableToString_SelectTestTableInputTableWithBadCheck_ReturnStringInclude_BadValue3_Test()
        {
            //Arrange
            var parameter = new { Operate = "TableToString", StringValue = "", Delimiter = ";", TableName = "TestTable", CheckType = "Bad" };
             var expect = "Bad Value 3";
            //Act
            string checkvalue = PositionListCheckExe.ConvertFunctionTableToString(parameter);

            //Assert
            var result = checkvalue;//  myGridview.Rows.Count.ToString();

            StringAssert.Contains(result, expect, $" position list count {result}");
         }

        [TestMethod()]
        public void ConvertFunctionTableToString_SelectTestQualification_ReturnStringInclude_TeachersOCTQualification_Test()
        {
            //Arrange
            var parameter = new { Operate = "TableToString", StringValue = "", Delimiter = ";", TableName = "StaffQualification", CheckType = "Good" };
            var expect = "Intermediate and Senior Divisions";
            //Act
            string checkvalue = PositionListCheckExe.ConvertFunctionTableToString(parameter);

            //Assert
            var result = checkvalue;//  myGridview.Rows.Count.ToString();

            StringAssert.Contains(result, expect, $" position list count {result}");
        }
    }
}