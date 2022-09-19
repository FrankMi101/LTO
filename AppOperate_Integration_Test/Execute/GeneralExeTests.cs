using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AppOperate.Tests
{
    [TestClass()]
    public class GeneralExeTests
    {
        private List2Item parameter = new List2Item
        {
            Operate = "DDList",
            Para0 = "mif",
            Para1 = "20192020",
            Para2 = "LTO",
            Para3 = "All"
        };


        [TestMethod()]
        public void SPNameTest_Return_SPName_whatAction_Provide()
        {
            //Arrange 
            string action = "dbo.tcdsb_LTO_anySPName @Operate,@Para0,@Para1,@Para2,@Para3";

            //Act
            string expect = action;
            string result = GeneralExe.SPName(action);

            //Assert
            Assert.AreEqual(expect, result, $" action provide Store Procedure Name and Parameters is:  { result}");

        }
        [TestMethod()]
        public void SPNameTest_Return_DDList_SPName()
        {
            //Arrange 
            string action = "DDList";
            var para = new CommonParameter();
            //Act
            string expect = "dbo.tcdsb_LTO_PageGeneral_List @Operate,@Para0,@Para1,@Para2,@Para3";
            string result = GeneralExe.SPName(action, para);

            //Assert
            Assert.AreEqual(expect, result, $" DDList Store Procedure Name:  { result}");

        }

        [TestMethod()]
        public void SPNameTest_Return_SchoolList_SPName()
        {
            //Arrange 
            string action = "Schools";

            //Act
            string expect = "dbo.tcdsb_LTO_PageGeneral_ListSchools @Operate,@Para0,@Para1,@Para2,@Para3";
            string result = GeneralExe.SPName(action);

            //Assert
            Assert.AreEqual(expect, result, $" School List Store Procedure Name  { result}");

        }

        [TestMethod()]
        public void SPNameTest_Return_SchoolList_SPName_byDelegateHelpMethod()
        {
            //Arrange 
            string action = "Schools";
            string page = "General";
            //Act
            string expect = "dbo.tcdsb_LTO_PageGeneral_ListSchools @Operate,@Para0,@Para1,@Para2,@Para3";
            string result = GeneralExe.SPName(action, page);

            //Assert
            Assert.AreEqual(expect, result, $" action provide Store Procedure Name and Parameters is:  { result}");

        }
        [TestMethod()]
        public void SPNameTest_Return_SchoolList_SPName_byDelegateFuncMethod()
        {
            //Arrange 
            string action = "Schools";
            string page = "General";
            string func = "GeneralExe.Schools";
            //Act
            string expect = "dbo.tcdsb_LTO_PageGeneral_ListSchools @Operate,@Para0,@Para1,@Para2,@Para3";
            string result = GeneralExe.SPName(action, page, func);

            //Assert
            Assert.AreEqual(expect, result, $" action provide Store Procedure Name and Parameters is:  { result}");

        }


        [TestMethod()]
        public void DDListNVTest_return_Elementary_panel_PositionLevel()
        {
            //Arrange 
            string action = "PositionLevel";
            parameter.Operate = action;
            parameter.Para0 = "20192020";
            parameter.Para1 = "0204";
            parameter.Para2 = "0000";
            var testDDLControl = new System.Web.UI.WebControls.DropDownList();

            // Act
            string expect = "Primary, Junior & Intermediate";
            string intitalValue = "BC708E";
            object datasourceList = GeneralExe.DDListNV(parameter);
            AssemblingList.SetLists(testDDLControl, datasourceList, "Value", "Name", intitalValue);
            string result = testDDLControl.SelectedItem.Text;

            //Assert
            Assert.AreEqual(expect, result, $"DD List Select Value  { result}");

        }

        [TestMethod()]
        public void DDListNVTest_return_Secondary_panel_PositionLevel()
        {
            //Arrange 
            string action = "PositionLevel";
            parameter.Operate = action;
            parameter.Para0 = "20192020";
            parameter.Para1 = "0505";
            parameter.Para2 = "0000";
            var testDDLControl = new System.Web.UI.WebControls.DropDownList();

            // Act
            string expect = "Intermediate and Senior";
            string intitalValue = "BC003E";
            object datasourceList = GeneralExe.DDListNV(parameter);
            AssemblingList.SetLists(testDDLControl, datasourceList, "Value", "Name", intitalValue);
            string result = testDDLControl.SelectedItem.Text;

            //Assert
            Assert.AreEqual(expect, result, $"DD List Select Value  { result}");

        }

        [TestMethod()]
        public void SchoolListTest_return_AllTCDSB_SchoolList()
        {
            //Arrange 
            string action = "SchoolList";
            parameter.Operate = action;
            parameter.Para0 = "mif";
            parameter.Para1 = "admin";
            parameter.Para2 = "";
            parameter.Para3 = "20192020";

            var testDDLControl = new System.Web.UI.WebControls.DropDownList();

            // Act
            string expect = "All Saints Catholic School";
            int expect2 = 335;
            string intitalValue = "0290";
            object datasourceList = GeneralExe.SchoolList(parameter);
            AssemblingList.SetLists(testDDLControl, datasourceList, "Code", "Name", intitalValue);
            string result = testDDLControl.SelectedItem.Text;
            int result2 = testDDLControl.Items.Count;
            // Assert
            Assert.AreEqual(expect, result, $"DD List Select Value  { result}");
            Assert.AreEqual(expect2, result2, $"DD List Totle Count Value  { result2}");

        }
        [TestMethod()]
        public void SchoolListTest_return_AllTCDSB_SchoolList_byaction_SPName()
        {
            //Arrange 
            string action = "SchoolList";
            string spName = "dbo.tcdsb_LTO_PageGeneral_ListSchools @Operate,@Para0,@Para1,@Para2,@Para3";
            parameter.Operate = action;
            parameter.Para0 = "mif";
            parameter.Para1 = "admin";
            parameter.Para2 = "";
            parameter.Para3 = "20192020";

            var testDDLControl = new System.Web.UI.WebControls.DropDownList();

            // Act
            string expect = "All Saints Catholic School";
            int expect2 = 335;
            string intitalValue = "0290";
            object datasourceList = GeneralExe<ListSchool>.myListOfT(spName, parameter);
            AssemblingList.SetLists(testDDLControl, datasourceList, "Code", "Name", intitalValue);
            string result = testDDLControl.SelectedItem.Text;
            int result2 = testDDLControl.Items.Count;
            // Assert
            Assert.AreEqual(expect, result, $"DD List Select Value  { result}");
            Assert.AreEqual(expect2, result2, $"DD List Totle Count Value  { result2}");

        }

        [TestMethod()]
        public void SchoolListTest_return_AllTCDSB_SchoolList_byDelegateMethod()
        {
            //Arrange 
            string action = "SchoolList";
            parameter.Operate = action;
            parameter.Para0 = "mif";
            parameter.Para1 = "admin";
            parameter.Para2 = "";
            parameter.Para3 = "20192020";

            var testDDLControl = new System.Web.UI.WebControls.DropDownList();

            // Act
            string expect = "All Saints Catholic School";
            int expect2 = 335;
            string intitalValue = "0290";
            object datasourceList = GeneralExe<ListSchool>.myListofT_DelegateHelp_Method("Schools", parameter);

            AssemblingList.SetLists(testDDLControl, datasourceList, "Code", "Name", intitalValue);
            string result = testDDLControl.SelectedItem.Text;
            int result2 = testDDLControl.Items.Count;
            // Assert
            Assert.AreEqual(expect, result, $"DD List Select Value  { result}");
            Assert.AreEqual(expect2, result2, $"DD List Totle Count Value  { result2}");

        }

        [TestMethod()]
        public void SearchListTest_return_List_byCategory_PostingCycle()
        {
            //Arrange 
            string action = "PostingCycle";
            SearchParameter search = new SearchParameter()
            {
                Operate = action,
                SchoolYear = "20192020",
                PositionType = "LTO",
                SearchType = action

            };

            // Act
            var testDDLControl = new System.Web.UI.WebControls.DropDownList();
            string expect = "Round 3";
            int expect2 = 4;
            string intitalValue = "3";
            object datasourceList = GeneralExe.SearchList(search);
            AssemblingList.SetLists(testDDLControl, datasourceList, "Value", "Name", intitalValue);
            string result = testDDLControl.SelectedItem.Text;
            int result2 = testDDLControl.Items.Count;

            // Assert
            Assert.AreEqual(expect, result, $"Search by Posting cycle, Select Value  { result}");
            Assert.AreEqual(expect2, result2, $" Totel Posting Cycle is   { result2}");
        }
        [TestMethod()]
        public void SearchListTest_return_List_byCategory_PostingState()
        {
            //Arrange 
            string action = "PostingState";
            SearchParameter search = new SearchParameter()
            {
                Operate = action,
                SchoolYear = "20192020",
                PositionType = "LTO",
                SearchType = action

            };

            // Act
            var testDDLControl = new System.Web.UI.WebControls.DropDownList();
            string expect = "New Posting";
            int expect2 = 9;
            string intitalValue = "New Posting";
            object datasourceList = GeneralExe.SearchList(search);

            AssemblingList.SetLists(testDDLControl, datasourceList, "Value", "Name", intitalValue);
            string result = testDDLControl.SelectedItem.Text;
            int result2 = testDDLControl.Items.Count - 1;

            //Assert
            Assert.AreEqual(expect, result, $"Search by Posting State, Select Value  { result}");
            Assert.AreEqual(expect2, result2, $" Totel Posting state is   { result2}");
        }
        [TestMethod()]
        public void DefaultDateTest_return_runingDateValue_LTO()
        {
            //Arrange 
            string action = "DefaultDate";
            SearchParameter parameter = new SearchParameter()
            {
                Operate = action,
                SchoolYear = "20192020",
                PositionType = "LTO"
            };


            // Act
            var myGridview = new System.Web.UI.WebControls.GridView();


            var myDate = GeneralExe.DefaultDate(parameter)[0];
            //myGridview.AutoGenerateColumns = true;
            //myGridview.DataSource = myDatasource;
            //myGridview.DataBind();

            var startDate = myDate.StartDate;
            var endDate = myDate.EndDate;
            var publishDate = myDate.DatePublish;
            var openDate = myDate.DateApplyOpen;
            var closeDate = myDate.DateApplyClose;

            string expect = DateFC.YMD(DateTime.Now);
            string result =  publishDate ;

            //Assert
            Assert.AreEqual(expect, result, $"default publish Date Value  { result}");

        }
        [TestMethod()]
        public void DefaultDateTest_return_runingDateValue_POP()
        {
            //Arrange 
            string action = "DefaultDate";
            SearchParameter parameter = new SearchParameter()
            {
                Operate = action,
                SchoolYear = "20192020",
                PositionType = "POP"
            };

            // Act
            var myDate = GeneralExe.DefaultDate(parameter)[0];
            var startDate = myDate.StartDate;
            var endDate = myDate.EndDate;
            var publishDate = myDate.DatePublish;
            var openDate = myDate.DateApplyOpen;
            var closeDate = myDate.DateApplyClose;

            string expect = DateFC.YMD(DateTime.Now);
            string result =  publishDate ;

            //Assert
            Assert.AreEqual(expect, result, $"default publish Date Value  { result}");

        }
        [TestMethod()]
        public void OpenCloseDateTest_ByType_Return_CheckCloseDate()
        {
            //Arrange 
            string action = "OpenCloseDate";
            string publishDate = "2019/10/8";
            SearchParameter parameter = new SearchParameter()
            {
                Operate = action,
                SchoolYear = "20192020",
                PositionType = "LTO",
                DatePublish = publishDate

            };

            // Act
            DateTime currentDate = DateTime.Now;
            var myDate = GeneralExe.OpenCloseDate(parameter)[0];
            var openDate = myDate.DateApplyOpen;
            var closeDate = myDate.DateApplyClose;
            string expect = "2019/10/10";
            string result =  closeDate ;

            //Assert
            Assert.AreEqual(expect, result, $"Close date Value  { result} is  based on publish Date { publishDate} ");
        }

        [TestMethod()]
        public void StartEndDateTest_byType_LTO_CheckStartDate_uu()
        {
            //Arrange 
            string action = "StartDate";
            string expectStartDate = "2019/09/03";
            DateTime actinDate = DateFC.YMD(expectStartDate);
            DateTime currentDate = DateTime.Now;
            SearchParameter parameter = new SearchParameter()
            {
                Operate = action,
                SchoolYear = "20192020",
                PositionType = "LTO"
            };
            if (currentDate > actinDate)
                expectStartDate = DateFC.YMD(currentDate, "/");

            // Act
            var myDate = GeneralExe.StartEndDate(parameter)[0];
            var startDate = myDate.StartDate;
            string expect = expectStartDate;
            string result =  startDate ;

            //Assert
            Assert.AreEqual(expect, result, $"Start date Value  { result} ");
        }
        [TestMethod()]
        public void StartEndDateTest_byType_LTO_CheckStartDate_using_GeneralMethod()
        {
            //Arrange 
            string action = "StartDate";
            string expectStartDate = "2019/09/03";
            DateTime actinDate = DateFC.YMD(expectStartDate);
            DateTime currentDate = DateTime.Now;
            var parameter = new 
            {
                Operate = action,
               SchoolYear = "20192020",
                PositionType = "LTO"
           };
            if (currentDate > actinDate)
                expectStartDate = DateFC.YMD(currentDate, "/");

            // Act
            var myDate = GeneralExe<LTODefalutDate>.myListOfT("StartEndDate", parameter)[0];
            var startDate = myDate.StartDate;
            string expect = expectStartDate;
            string result =  startDate ;

            //Assert
            Assert.AreEqual(expect, result, $"Start date Value  { result} ");
        }

        [TestMethod()]
        public void StartEndDateTest_byType_POP_CheckStartDate()
        {
            //Arrange 
            string action = "StartDate";
            string expectStartDate = "2019/09/01";
            DateTime actinDate = DateFC.YMD(expectStartDate);
            DateTime currentDate = DateTime.Now;
            SearchParameter parameter = new SearchParameter()
            {
                Operate = action,
                SchoolYear = "20192020",
                PositionType = "POP"
            };
            if (currentDate > actinDate)
                expectStartDate = DateFC.YMD(currentDate, "/");

            // Act
            var myDate = GeneralExe.StartEndDate(parameter)[0];
            var startDate = myDate.StartDate;
            string expect = expectStartDate;
            string result =  startDate ;

            //Assert
            Assert.AreEqual(expect, result, $"Start date Value  { result} ");
        }

        [TestMethod()]
        public void ProfileTest_Return_PostingNumber_byPositionID()
        {
            //Arrange 
            string action = "PostingNumber";
            string positinoID = "15586";
            Profile parameter = new Profile()
            {
                Operate = action,
                SchoolYear = "20192020",
                ProfileType = action,
                CheckValue = positinoID
            };

            // Act         
            string expect = "2019-14595";
            string result = GeneralExe.Profile(parameter);

            //Assert
            Assert.AreEqual(expect, result, $"Posting Number is { result} from position ID: { positinoID } ");
        }


      
        [TestMethod()]
        public void ProfileTest_Return_Applicant_Role()
        {
            //Arrange 
            string action = "UserRole";
            string userid = "antonim03";
            Profile parameter = new Profile()
            {
                Operate = action,
                SchoolYear = "20192020",
                ProfileType = action,
                CheckValue = userid
            };

            // Act         
            string expect = "LTOTeacher,Roster,Other";
            string result = GeneralExe.Profile(parameter);

            //Assert
           StringAssert.Contains( expect,result, $" User Role is { result} from User ID: { userid } ");
        }
        [TestMethod()]
        public void ProfileTest_Return_Applicant_Role_using_GeneralMethod()
        {
            //Arrange 
            string action = "UserRole";
            string userid = "antonim03";
            Profile parameter = new Profile()
            {
                Operate = action,
                SchoolYear = "20192020",
                ProfileType = action,
                CheckValue = userid
            };

            // Act         
            string expect = "LTOTeacher,Roster,Other";
            string result = GeneralExe.Profile( parameter);
            /*
            parameter.ProfileType = "CPNum";
            int cpnum = GeneralExe<int>.myValueOfT("Profile", parameter);
            parameter.ProfileType = "StartDate";
            DateTime startDate = GeneralExe<DateTime>.myValueOfT("Profile", parameter);
             */
            //Assert
            StringAssert.Contains(expect, result, $" User Role is { result} from User ID: { userid } ");
        }

        [TestMethod()]
        public void TeachersListTest_Return_School_TeacherList_Searchby_Startwith_K_of_LastName()
        {
            //Arrange 
            string action = "TeachersList";

            var myAnonymousParametere = new
            {
                SchoolYear = "20182019",
                SchoolCode = "0209",
                SearchValue1 = "K"
            };

            var testDDLControl = new System.Web.UI.WebControls.DropDownList();

            // Act
            string expect = "Kurnik,Cassandra";
            int expect2 = 203;
            string intitalValue = "00045299"; // "kurnikc";
            object datasourceList = GeneralExe.TeachersList(myAnonymousParametere);
            AssemblingList.SetLists(testDDLControl, datasourceList, "CPNum", "TeacherName", intitalValue);
            string result = testDDLControl.SelectedItem.Text;
            int result2 = testDDLControl.Items.Count;
            // Assert
            Assert.AreEqual(expect, result, $"Teacher List From School Select Value  { result}");
            Assert.AreEqual(expect2, result2, $"DD List Totle Count Value  { result2}");
        }

        [TestMethod()]
        public void TeachersListTest_Return_School_TeacherList_Searchby_Startwith_K_of_LastName_usingGeneralList()
        {
            //Arrange 
            string action = "TeachersList";

            var myAnonymousParametere = new
            {
                SchoolYear = "20192020",
                SchoolCode = "0209",
                SearchValue1 = "K"
            };

            var testDDLControl = new System.Web.UI.WebControls.DropDownList();

            // Act
            string expect = "Kurnik,Cassandra";
            int expect2 = 203;
            string intitalValue = "00045299"; // "kurnikc";
            object datasourceList = GeneralExe<TeachersListByCategory>.myListOfT(action, myAnonymousParametere);
            AssemblingList.SetLists(testDDLControl, datasourceList, "CPNum", "TeacherName", intitalValue);
            string result = testDDLControl.SelectedItem.Text;
            int result2 = testDDLControl.Items.Count;
            // Assert
            Assert.AreEqual(expect, result, $"Teacher List From School Select Value  { result}");
            Assert.AreEqual(expect2, result2, $"DD List Totle Count Value  { result2}");
        }
        [TestMethod()]
        public void TeacherNameTest_Return_Name_by_givingCPNum()
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
            testTextControl.Text = GeneralExe.TeacherName(myAnonymousParametere);
            string result = testTextControl.Text;

            // Assert
            Assert.AreEqual(expect, result, $"Teacher Name is { result} from CPNum {intitalValue} ");
        }

        [TestMethod()]
        public void TeacherNameTest_using_GeneralMethod_Return_Name_byGiveingCPNum()
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
            testTextControl.Text = GeneralExe<string>.myValueOfT(action, myAnonymousParametere);
            string result = testTextControl.Text;

            // Assert
            Assert.AreEqual(expect, result, $"Teacher Name is { result} from CPNum {intitalValue} ");
        }

        [TestMethod()]
        public void ValidateDateTest_Return_VaildateDate_20191111()
        {
            //Arrange
            var checkDate = new
            {
                Operate = "Check",
                SchoolYear = "20192020",
                PositionType = "LTO",
                ValidateDate = "2019/11/11"
            };

            //Act 
            string expect = checkDate.ValidateDate;
            string result = GeneralExe.ValidateDate(checkDate);

            //Assert
            Assert.AreEqual(expect, result, $" {result} is a vaildate date. ");


        }
        [TestMethod()]
        public void ValidateDateTest_Return_NextAvailable_WorkDaye_20191111()
        {
            //Arrange
            var checkDate = new
            {
                Operate = "Check",
                SchoolYear = "20192020",
                PositionType = "LTO",
                ValidateDate = "2019/11/11"
            };

            //Act 
            string expect = checkDate.ValidateDate;
            string result = GeneralExe.ValidateDate(checkDate);

            //Assert
            Assert.AreEqual(expect, result, $" { result } is a next available work date for { checkDate.ValidateDate } . ");


        }
        [TestMethod()]
        public void ValidateDateTest_Return_InVaildate_whenWeekends_20191110()
        {
            //Arrange
            var checkDate = new
            {
                Operate = "Check",
                SchoolYear = "20192020",
                PositionType = "LTO",
                ValidateDate = "2019/11/10"
            };

            //Act 
            string expect = "Invalid Date";
            string result = GeneralExe.ValidateDate(checkDate);

            //Assert
            Assert.AreEqual(expect, result, $" { checkDate.ValidateDate } is a Invaildate date. ");


        }
        [TestMethod()]
        public void ValidateDateTest_Return_NextAvailable_WorkDay_whenWeekends_20191109()
        {
            //Arrange
            var checkDate = new
            {
                Operate = "NextWorkDay",
                SchoolYear = "20192020",
                PositionType = "LTO",
                ValidateDate = "2019/11/09"
            };

            //Act 
            string expect = "2019/11/12";
            string result = GeneralExe.ValidateDate(checkDate);

            //Assert
            Assert.AreEqual(expect, result, $" Next work day is { result } for { checkDate.ValidateDate}");


        }
        [TestMethod()]
        public void ValidateDateTest_Return_InVaildate_whenPublicHailday_20191014()
        {
            //Arrange
            var checkDate = new
            {
                Operate = "Check",
                SchoolYear = "20192020",
                PositionType = "LTO",
                ValidateDate = "2019/10/14"
            };

            //Act 
            string expect = "Invalid Date";
            string result = GeneralExe.ValidateDate(checkDate);

            //Assert
            Assert.AreEqual(expect, result, $" { checkDate.ValidateDate} is a Invaildate date. ");

        }
        [TestMethod()]
        public void ValidateDateTest_Return_InVaildate_whenPublicHailday2_20191225()
        {
            //Arrange
            var checkDate = new
            {
                Operate = "Check",
                SchoolYear = "20192020",
                PositionType = "LTO",
                ValidateDate = "2019/12/25"
            };

            //Act 
            string expect = "Invalid Date";
            string result = GeneralExe.ValidateDate(checkDate);

            //Assert
            Assert.AreEqual(expect, result, $" { checkDate.ValidateDate} is a Invaildate date. ");

        }

        [TestMethod()]
        public void ValidateDateTest_Return_NextAvailable_WorkDay_whenPublicHailday_20191014()
        {
            //Arrange
            var checkDate = new
            {
                Operate = "NextWorkDay",
                SchoolYear = "20192020",
                PositionType = "LTO",
                ValidateDate = "2019/10/14"
            };

            //Act 
            string expect = "2019/10/16";
            string result = GeneralExe.ValidateDate(checkDate);

            //Assert
            Assert.AreEqual(expect, result, $" Next work day is {result } for { checkDate.ValidateDate}. ");

        }
        [TestMethod()]
        public void ValidateDateTest_Return_NextAvailable_WorkDay_whenPublicHailday_20191225()
        {
            //Arrange
            var checkDate = new
            {
                Operate = "NextWorkDay",
                SchoolYear = "20192020",
                PositionType = "LTO",
                ValidateDate = "2019/12/25"
            };

            //Act 
            string expect = "2020/01/07";
            string result = GeneralExe.ValidateDate(checkDate);

            //Assert
            Assert.AreEqual(expect, result, $" Next work day is { result } for { checkDate.ValidateDate} is a Invaildate date. ");

        }
        [TestMethod()]
        public void RandomApplicantTest_Return_a_Random_applicant_LTOOnly_From_teacherLists()
        {
            //Arrange
            ApplicantRandom  parameter = new ApplicantRandom()
            {
                Operate = "Apply",
                SchoolYear = "20192020",
                PositionID = "0",
                PositionType = "LTO",
                PostingCycle = "1",
                CPNum = "00000000"
            };

            //Act 
            string expect = "1";

            List<Applicant> applicant1 = GeneralExe.RandomApplicant(parameter);

            string result = applicant1.Count.ToString();
            string rName = applicant1[0].TeacherName;
            
            //Assert
             Assert.IsNotNull( result, $" Random Applicant is a { applicant1[0].ApplicantType } of { rName }");
            Assert.AreEqual( expect, result, $" Random Applicant is { rName }");

            parameter.CPNum = applicant1[0].CPNum;
            parameter.PostingCycle = "3";
            List<Applicant> applicant2 = GeneralExe.RandomApplicant(parameter);
            string result2 = applicant2.Count.ToString();
            string rName2 = applicant2[0].TeacherName;

            //Assert2
            Assert.IsNotNull(result2, $" Random Applicant is a { applicant1[0].ApplicantType } of { rName2 }");
            Assert.AreEqual(expect, result2, $" Random Applicant is { rName2 }");


        }
    }
}