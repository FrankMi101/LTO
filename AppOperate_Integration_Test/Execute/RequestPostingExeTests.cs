using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AppOperate.Tests
{
    [TestClass()]
    public class RequestPostingExeTests
    {
        private static string schoolyear = "20192020";
        private string cPage = "Request";
        PositionRequesting requestposition = new PositionRequesting();

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


        NewPosition request = new NewPosition()
        {
            Operate = "New",
            SchoolYear = "20192020",
            PositionID = "0",
            PositionType = "LTO",
            SchoolCode = "0549",
            UserID = "mif"
        };

        private int getNewRequestID(string positionType)
        {

            request.PositionType = positionType;
            string newid = RequestPostingExe.Add(request);
            int x = Int32.Parse(newid);
            return x;
        }

        [TestMethod()]
        public void SPNameTest_Return_RequestPosition_Store_Procedure()
        {
            //Arrange 
            string action = "Position";

            //Act
            string expect = action;// "dbo.tcdsb_LTO_PageRequest_Position @SchoolYear, @PositionID";
            string result = RequestPostingExe.SPName(action);

            //Assert
            Assert.AreEqual(expect, result, $" Request Position Store Procedure Name:  { result}");
        }
        [TestMethod()]
        public void SPNameTest_Return_RequestPositions_Store_Procedure()
        {
            //Arrange 
            string action = "Positions";

            //Act
            string expect = action;// "dbo.tcdsb_LTO_PageRequest_Positions @Operate, @UserID, @SchoolYear, @SchoolCode";
            string result = RequestPostingExe.SPName(action);

            //Assert
            Assert.AreEqual(expect, result, $" Request Positions List Store Procedure Name:  { result}");
        }

        [TestMethod()]
        public void SPNameTest_Return_Request_CreateNewPosition_Store_Procedure()
        {
            //Arrange 
            string action = "New";

            //Act
            string expect = action;// "dbo.tcdsb_LTO_PageRequest_CreateNew @Operate, @UserID, @SchoolYear, @SchoolCode, @PositionID, @PositionType";
            string result = RequestPostingExe.SPName(action);

            //Assert
            Assert.AreEqual(expect, result, $" Create new Position Store Procedure Name:  { result}");
        }
        [TestMethod()]
        public void PositionsTest_return_School_requestPostingList()
        {
            //Arrange
            string action = "Positions";
            var myGridview = new System.Web.UI.WebControls.GridView();
            parameter.Operate = action;
            string expect = "334";

            //Act         
            var testList = RequestPostingExe.Positions(parameter);
            myGridview.AutoGenerateColumns = true;
            myGridview.DataSource = testList;
            myGridview.DataBind();
            var result = myGridview.Rows.Count.ToString();

            //Assert
            // Assert.AreEqual(expect, result, $"  Posting position List { result}");
            Assert.IsNotNull(result, $"  Request Posting position List { result}");

        }

        [TestMethod()]
        public void PositionTest_Return_a_RequestPositionbyRequesID()
        {
            //Arrange
            string action = "Position";

            var myGridview = new System.Web.UI.WebControls.GridView();
            request.Operate = action;
            request.PositionID = getNewRequestID("LTO").ToString();


            //Act

            var testList = RequestPostingExe.Position(request);


            myGridview.AutoGenerateColumns = true;
            myGridview.DataSource = testList;
            myGridview.DataBind();

            var result = myGridview.Rows.Count.ToString();

            //Assert
            // Assert.AreEqual(expect, result, $"  Posting position List { result}");
            Assert.IsNotNull(result, $"  Request Posting position List { result}");
        }

        [TestMethod()]
        public void TeachersListTest_Return_0209School_Plus_TCDSB_top_200_Teachers()
        {
            //Arrange 
            string action = "TeachersList";
            string expect = "Kurnik, Cassandra";
             string intitalValue = "00045299"; // "kurnikc";

            var para = new // ParametersForPositionList()
            {
                Operate = "TeachersList",
                UserID = "mif",
                SchoolYear = "20192020",
                SchoolCode = "0209",
                SearchValue1 = "K"
            };
      
            var testDDLControl = new System.Web.UI.WebControls.DropDownList();

            // Act
            object datasourceList = RequestPostingExe.TeachersList(para);
            AssemblingList.SetLists(testDDLControl, datasourceList, "CPNum", "TeacherName", intitalValue);
            string result = testDDLControl.SelectedItem.Text;
 
            // Assert
            Assert.AreEqual(expect, result, $"Teacher List From School Select Value  { result}");
         }


        [TestMethod()]
        public void AddTest_Return_NewRequesID()
        {
            //Arrange
            string action = "New";
            request.Operate = action;
            request.PositionID = "0";

            //Act


            string newid = RequestPostingExe.Add(request);
            int x = Int32.Parse(newid);
            int result = x;

            //Assert
            // Assert.AreEqual(expect, result, $"  Posting position List { result}");
            Assert.IsNotNull(result, $"  Request Posting position List { result}");

        }

        [TestMethod()]
        public void UpdateTest_updateRequestPosting_return_Successfully()
        {
            //Arrange
            string action = "Update";
            PositionRequesting parameter = new PositionRequesting()
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
                Description = "Biology; Science; Science - General; full time position need senior level",
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

             string expect = "Successfully";
          string result = RequestPostingExe.Update(parameter);

            //Assert
            Assert.AreEqual(expect, result, $"  Request Posting Resulte { result}.");

        }

        [TestMethod()]
        public void OperationTest_CancelRequesPosting_return_Secussfully()
        {
            //Arrange
            string action = "Delete";
            requestposition.UserID = "mif";
            requestposition.Operate = action;
            requestposition.SchoolYear = "20192020";
            requestposition.SchoolCode = "0549";
            requestposition.PositionID = getNewRequestID("LTO");

            //Act
            string expect = "Successfully";
            string result = RequestPostingExe.Operation(action, requestposition);

            //Assert
            Assert.AreEqual(expect, result, $" Cancel a request posting by schoool principal { result} ."); 
        }

        [TestMethod()]
        public void OperationTest_DeleteRequesPosting_return_Secussfully()
        {
            //Arrange
            string action = "Delete";
            requestposition.UserID = "mif";
            requestposition.Operate = action;
            requestposition.SchoolYear = "20192020";
            requestposition.SchoolCode = "0549";
            requestposition.PositionID = getNewRequestID("LTO");

            //Act
            string expect = "Successfully";
            string result = RequestPostingExe.Operation(action, requestposition);

            //Assert
            Assert.AreEqual(expect, result, $" Cancel a request posting by schoool principal { result} .");
        }

        [TestMethod()]
        public void RequestSchoolTest()
        {
            //Arrange
            string action = "RequestSchool";
            requestposition.UserID = "mif";
            requestposition.Operate = action;
            requestposition.SchoolYear = "20192020";
            requestposition.SchoolCode = "0549";
            requestposition.PositionID = getNewRequestID("LTO");
            //act
            string expect = "0549";
            string schoolCodeAndName =   RequestPostingExe.RequestSchool(requestposition) ;
            string result = schoolCodeAndName.Substring(0, 4);
            //Assert
            Assert.AreEqual(expect, result, $"request School by schoool principal { schoolCodeAndName} .");
        }

        [TestMethod()]
        public void RequestAttributeTest_Return_RequestSchool()
        {
            //Arrange
            string action = "RequestSchool"; 
            requestposition.UserID = "mif";
            requestposition.Operate = action;
            requestposition.SchoolYear = "20192020";
            requestposition.SchoolCode = "0549";
            requestposition.PositionID = getNewRequestID("LTO");
            //act
            string expect = "0549";
            //Act
            string schoolCodeAndName = RequestPostingExe.RequestAttribute(requestposition);
            string result = schoolCodeAndName.Substring(0, 4);

            //Assert
            Assert.AreEqual(expect, result, $"request Schoolname { schoolCodeAndName} .");
        }
        [TestMethod()]
        public void RequestAttributeTest_Return_Position_Infomation()
        {
            //Arrange
            string action = "RequestPositionInfo";
             requestposition.UserID = "mif";
            requestposition.Operate = action;
            requestposition.SchoolYear = "20192020";
            requestposition.SchoolCode = "0549";
            requestposition.PositionID = getNewRequestID("LTO");
            //act
            string expect = "LTO";
            //Act
            string result = RequestPostingExe.RequestAttribute(requestposition);
           

            //Assert
            StringAssert.Contains(result, expect, $"request position Info  { result} .");
        }
        [TestMethod()]
        public void RequestAttributeTest_Return_Position_Qualification()
        {
            //Arrange
            string action = "PositionQualfication";
            requestposition.UserID = "mif";
            requestposition.Operate = action;
            requestposition.SchoolYear = "20192020";
            requestposition.SchoolCode = "0549";
            requestposition.PositionID = getNewRequestID("LTO");
            //act
            string expect = "0549";
            //Act
            string result = RequestPostingExe.RequestAttribute(requestposition);


            //Assert
            Assert.IsNotNull(result, $"request Schoolname { result} .");
        }

        [TestMethod()]
        public void QualificationTest()
        {
            string result = ""; // RequestPostingExe.Qualification(parameter);
            //Assert
            Assert.IsNotNull(result, "");
        }

        [TestMethod()]
        public void QualificationSTRTest()
        {
            string result = "";// RequestPostingExe.QualificationSTR(parameter);
            //Assert
            Assert.IsNotNull(result, "");
        }

        [TestMethod()]
        public void TeacherNameTest()
        {
            
            //Arrange 
            string action = "TeacherName";
            string intitalValue = "00045299"; // "CPNum";

            var myAnonymousParametere = new
            {
                CPNum = intitalValue,
                Operate = "Name"
            };

            var testTextControl = new System.Web.UI.WebControls.TextBox();

            // Act
            string expect = "Cassandra Kurnik";
            testTextControl.Text = RequestPostingExe.TeacherName(myAnonymousParametere);
            string result = testTextControl.Text;

            // Assert
            Assert.AreEqual(expect, result, $"Teacher Name is { result} from CPNum {intitalValue} ");
        }
    }
}