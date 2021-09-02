using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppOperate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using ClassLibrary;

namespace AppOperate.Tests
{
    [TestClass()]
    public class AssembleListItemTests
    {
        [TestMethod()]
        public void SetSearchListTest_AssembleingSchoolList()
        {   // Arrange
            string[] searchby = new [] { "School", "Panel", "Area", "Level", "PostingState", "PendingConfirm", "PostingCycle", "PositionStatus" };          
            var myDDLlist = new System.Web.UI.WebControls.DropDownList();
            string operate = searchby[0];// "School"; 
            string para0 = "mif";
            string para1 = "20192020";
            int expect = 332;
            //Act
            AssembleListItem.SetSearchList(myDDLlist, operate, para0, para1);
            //Assert
            var result = myDDLlist.Items.Count;
            Assert.AreEqual(expect, result,"School list include all schools " + operate + result );
        }
        [TestMethod()]
        public void SetSearchListTest_Assembleing_SchoolAreaList()
        {    //Arrange 
            string[] searchby = new[] { "School", "Panel", "Area", "Level", "PostingState", "PendingConfirm", "PostingCycle", "PositionStatus" };
            var myDDLlist = new System.Web.UI.WebControls.DropDownList();
            string operate = searchby[2];// "School"; 
            string para0 = "mif";
            string para1 = "20192020";
            int expect = 9;
            //Act
            AssembleListItem.SetSearchList(myDDLlist, operate, para0, para1);
            var result = myDDLlist.Items.Count;
            //Asser
            Assert.AreEqual(expect, result, "School Area list  " + operate + result);
        }
        [TestMethod()]
        public void SetSearchListTest_Assembleing_PostingCycle()
        {    //Arrange
            string[] searchby = new[] { "School", "Panel", "Area", "Level", "PostingState", "PendingConfirm", "PostingCycle", "PositionStatus" };
            var myDDLlist = new System.Web.UI.WebControls.DropDownList();
            string operate = searchby[6];// "School"; 
            string para0 = "mif";
            string para1 = "20192020";
            string expect = "3";

            //Act
            AssembleListItem.SetSearchList(myDDLlist, operate, para0, para1);
            myDDLlist.SelectedIndex = 2;
            var result =  myDDLlist.SelectedValue.ToString();

            //Assert
            Assert.AreEqual(expect, result, "Posting cycle 1,2,3,4 " + operate + result);
        }
        [TestMethod()]
        public void SetSearchListTest_Assembleing_PostingState()
        {   //Arrange
            string[] searchby = new[] { "School", "Panel", "Area", "Level", "PostingState", "PendingConfirm", "PostingCycle", "PositionStatus" };
            var myDDLlist = new System.Web.UI.WebControls.DropDownList();
            string operate = searchby[4];// "School"; 
            string para0 = "mif";
            string para1 = "20192020";
            string expect = "More Interview";

            //Act
            AssembleListItem.SetSearchList(myDDLlist, operate, para0, para1);
            myDDLlist.SelectedIndex = 4;
            var result = myDDLlist.SelectedItem.Text; // .SelectedValue.ToLower();

            //Assert
            Assert.AreEqual(expect, result, "Posting state  " + operate + result);
        }
        [TestMethod()]
        public void SetList_Assembling_PositionLevel_Elementary_WithIntialValue()
        {  //Arrange
            var myDDLlist = new System.Web.UI.WebControls.DropDownList();
            var parameter = new List2Item(){ Operate = "SupportingQualification", Para0 = "0204", Para1 = "LTO" };

            parameter.Operate = "SupportingQualification";
            parameter.Para0 = "0204";
            parameter.Para1 = "LTO";

            var initialValue = "BC001E";
            string expect = "Primary and Junior Divisions";

            //Act
            AssembleListItem.SetLists(myDDLlist, "SupportingQualification", parameter, initialValue);
            var result = myDDLlist.SelectedItem.Text; // .SelectedValue.ToLower();

            //Assert
            Assert.AreEqual(expect, result, "Position Level for elementary panel "   + result);
        }
        [TestMethod()]
        public void SetList_Assembling_PositionLevel_Secondary_WithIntialValue()
        {    //Arrange
            var myDDLlist = new System.Web.UI.WebControls.DropDownList();
            var parameter = new List2Item() { Operate = "SupportingQualification", Para0 = "0505", Para1 = "LTO" };

            parameter.Operate = "SupportingQualification";
            parameter.Para0 = "0505";
            parameter.Para1 = "LTO";

            var initialValue = "BC014E";
            string expect = "Senior Division";

            //Act
            AssembleListItem.SetLists(myDDLlist, "SupportingQualification", parameter, initialValue);
            var result = myDDLlist.SelectedItem.Text; // .SelectedValue.ToLower();

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
            AssembleListItem.SetLists2(myDDLlist1,myDDLlist2, parameter, initialValue);
            var result = myDDLlist2.SelectedItem.Text; // .SelectedValue.ToLower();

            //Assert
            Assert.AreEqual(expect, result, "Both School and school code list, selected All Saints Catholic " + result);
        }
    }
}