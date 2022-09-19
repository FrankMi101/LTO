using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppOperate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using ClassLibrary;
using System.Web.UI.HtmlControls;

namespace AppOperate.Tests
{
    [TestClass()]
    public class AssemblingListTests
    {
        private readonly string[] searchby = new[] { "School", "Panel", "Area", "Level", "PostingState", "PendingConfirm", "PostingCycle", "PositionStatus" };
        private List2Item parameter = new List2Item() { Operate = "Panel", Para0 = "mif", Para1 = "20192020" };
        private DropDownList myDDLlist = new DropDownList();


        [TestMethod()]
        public void SetListTest_Assembleing_ProvideDataSourceDirectly()
        {
            //Arrange 
            var dataSource = new List<NameValueList>()
            { new NameValueList{ Name = "Round 1", Value = "1" },
            new NameValueList{ Name = "Round 2", Value = "2" },
            new NameValueList{ Name = "Round 3", Value = "3" },
            new NameValueList{ Name = "Round 4", Value = "4" },
            };


            int expect = 4;
            string expect2 = "Round 3";

            //Act
            AssemblingList.SetLists( myDDLlist, dataSource,"Value","Name");
            var result = myDDLlist.Items.Count;

            AssemblingList.SetValue(myDDLlist, 3);
            var result2 = myDDLlist.SelectedItem.Text;


            //Asser
            Assert.AreEqual(expect, result, "School Area list  " +   result);
            Assert.AreEqual(expect2, result2, "School Area list  " +   result2);
        }



        [TestMethod()]
        public void SetListTest_AssembleingSchoolList()
        {   // Arrange
                      
            string operate = "School";  
            int expect = 335;

            //Act
            AssemblingList.SetLists("",myDDLlist, operate, parameter);

            //Assert
            var result = myDDLlist.Items.Count;
            Assert.IsNotNull( result,"School list include all schools " + operate + result );
        }

        [TestMethod()]
        public void SetListTest_Assembleing_SchoolAreaList()
        { 
            //Arrange 
            string operate = "Area";
            int expect = 15;
            string expect2 = "Area 03";

            //Act
            AssemblingList.SetLists("", myDDLlist, operate, parameter);
            var result = myDDLlist.Items.Count;
            AssemblingList.SetValue(myDDLlist, expect2);
            var result2 = myDDLlist.SelectedValue; 

            //Asser
            Assert.AreEqual(expect, result, "School Area list  " + operate + result);
            Assert.AreEqual(expect2, result2, "School Area list  " + operate + result2);
        }

        [TestMethod()]
        public void SetListTest_Assembleing_PostingCycle()
        {
            //Arrange
            string operate = "PostingCycle";
            string expect = "Round 1";

            //Act
            AssemblingList.SetLists("", myDDLlist, operate, parameter); 

            myDDLlist.SelectedIndex = 1;
            var result =  myDDLlist.SelectedItem.Text;

            //Assert
            Assert.AreEqual(expect, result, "Posting cycle 1,2,3,4 " + operate + result);
        }

        [TestMethod()]
        public void SetListTest_Assembleing_PostingState()
        { 
            //Arrange
            string operate = "PostingState";
            string expect = "Cancel Posting";

            //Act
            AssemblingList.SetLists("", myDDLlist, operate, parameter);
            myDDLlist.SelectedIndex = 3;
            var result = myDDLlist.SelectedItem.Text; 

            //Assert
            Assert.AreEqual(expect, result, "Posting state  " + operate + result);
        }

        [TestMethod()]
        public void SetList_Assembling_PositionLevel_Elementary_WithIntialValue()
        {
            //Arrange
            string operate = "SupportingQualification";
            var parameter = new List2Item(){ Operate = operate, Para0 = "0204", Para1 = "LTO" };
            var initialValue = "BC001E";
            string expect = "Primary and Junior Divisions";

            //Act
            AssemblingList.SetLists("", myDDLlist, operate, parameter,initialValue);
            var result = myDDLlist.SelectedItem.Text;  

            //Assert
            Assert.AreEqual(expect, result, "Position Level for elementary panel "   + result);
        }

        [TestMethod()]
        public void SetList_Assembling_PositionLevel_Secondary_WithIntialValue()
        {
            //Arrange
            string operate = "SupportingQualification";
            var parameter = new List2Item() { Operate = operate, Para0 = "0505", Para1 = "LTO" };
            var initialValue = "BC014E";
            string expect = "Senior Division";

            //Act
            AssemblingList.SetLists("", myDDLlist, operate, parameter, initialValue);
            var result = myDDLlist.SelectedItem.Text;

            //Assert
            Assert.AreEqual(expect, result, "Position Level for secondary panel " + result);
        }
 
        [TestMethod()]
        public void SetLists2_Assembling_SchoolandSchoolCodeList_WithInitialValue()
        {
            //Arrange
            var myDDLlist1 = new System.Web.UI.WebControls.DropDownList();
            var myDDLlist2 = new System.Web.UI.WebControls.DropDownList();
            var parameter = new List2Item() { Operate = "SchoolList",   Para0 = "mif",  Para1 ="Admin", Para3 = "20182019"  };
  

            var initialValue = "0290";
            string expect = "All Saints Catholic School";

            //Act
            AssemblingList.SetListSchool( myDDLlist1,myDDLlist2, "SchoolList",parameter, initialValue);
            var result = myDDLlist2.SelectedItem.Text; // .SelectedValue.ToLower();

            //Assert
            Assert.AreEqual(expect, result, "Both School and school code list, selected All Saints Catholic " + result);
        }

        [TestMethod()]
        [DataRow("PostingCycle", "1","Round 1")]
        [DataRow("PostingState", "Cancel Posting", "Cancel Posting")]
        [DataRow("RequestState", "Posted", "Posted")]
        [DataRow("Area", "Area 03", "Area 03")]
        [DataRow("School", "0299", "Annunciation")]
        [DataRow("PositionLevel", "BC001E", "Primary and Junior")]
        [DataRow("LeaveReason", "6", "Medical Leave")]
        [DataRow("FTEList", "50", "50%")]
        [DataRow("SchoolYear", "20192020", "20192020")]
        [DataRow("ApplicationType", "POP", "Permanent Open Position")]
        public void SetValueTest_ReturnAcoorectValuebyInitialValue(string operate, object initialValue, object expect )
        {
            //Arrange
   

            //Act
            AssemblingList.SetLists("", myDDLlist, operate, parameter);
            AssemblingList.SetValue(myDDLlist, initialValue);
            var result = myDDLlist.SelectedItem.Text;
          

            //Assert
            Assert.AreEqual(expect, result,   operate + "  " + result);
        }

        [TestMethod()]
        [DataRow("PostingCycle", "1", "Round 1")]
        [DataRow("PostingState", "Cancel Posting", "Cancel Posting")]
        [DataRow("RequestState", "Posted", "Posted")]
        [DataRow("Area", "Area 03", "Area 03")]
        [DataRow("School", "0299", "Annunciation")]
        [DataRow("PositionLevel", "BC001E", "Primary and Junior")]
        [DataRow("LeaveReason", "6", "Medical Leave")]
        [DataRow("FTEList", "50", "50%")]
        [DataRow("SchoolYear", "20192020", "20192020")]
        [DataRow("ApplicationType", "POP", "Permanent Open Position")]
        public void SetListsTest_WithInitialValue_ReturnSelectItemText(string operate, object initialValue, object expect)
        {
            //Arrange


            //Act
            AssemblingList.SetLists("", myDDLlist, operate, parameter, initialValue);
            var result = myDDLlist.SelectedItem.Text;


            //Assert
            Assert.AreEqual(expect, result, operate + "  " + result);
        }

        [TestMethod()]
        [DataRow("PostingCycle", "1", "Round 1")]
        [DataRow("PostingState", "Cancel Posting", "Cancel Posting")]
        [DataRow("RequestState", "Posted", "Posted")]
        [DataRow("Area", "Area 03", "Area 03")]
        [DataRow("School", "0299", "Annunciation")]
        [DataRow("PositionLevel", "BC001E", "Primary and Junior")]
        [DataRow("LeaveReason", "6", "Medical Leave")]
        [DataRow("FTEList", "50", "50%")]
        [DataRow("SchoolYear", "20192020", "20192020")]
        [DataRow("ApplicationType", "POP", "Permanent Open Position")]
        public void SetListsTest_WithInitialValue_ReturnSelectItemValue(string operate, object initialValue, object expect2)
        {
            //Arrange

            object expect = initialValue;
            //Act
            AssemblingList.SetLists("", myDDLlist, operate, parameter, initialValue);
            var result = myDDLlist.SelectedItem.Value;


            //Assert
            Assert.AreEqual(expect, result, operate + "  " + result);
        }

        [TestMethod()]
        public void SetObjList_Assembling_GetAllApplicants_Test()
        {
            //Arrange
            string operate = "Applicant";
            var parameter = new List2Item() { Operate = operate, Para0 = "20202021", Para1 = "All",Para2="admin",Para3 ="%" };
            string expect = "Primary and Junior Divisions";
            object myObjList = new HtmlSelect();
        
            //Act
            AssemblingList.SetListsObj("", myObjList, operate, parameter);
    

            //Assert
            Assert.IsNotNull(myObjList, "First person in Applicant List is" + " OK");
        }
    }
}