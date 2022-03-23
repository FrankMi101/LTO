using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using AppOperate;
using System.Web.UI.WebControls;

namespace DataAccess.Repository.Tests
{
    [TestClass()]
    public class GeneralItemsTests
    {
        private readonly string SchoolYear = "20212022";
        private readonly string SchoolCode = "0204";
        private readonly string PositionType = "LTO";
        private readonly string UserID = "Tester";
        private int _ids = 0;
        private DropDownList myDDLlist = new DropDownList();

        private readonly   IAppServices _action = new AppServices(DBConnection.DBSource, new GeneralItems());
        //   private readonly IAppServices _action = new AppServices("Fake" , new GeneralItems()));

        [TestInitialize]
        public void Setup()
        {
            // Runs before each test. (Optional)

          //  var ds = new DataOperateServiceSQL<PositionPublish>();
          //  _action = new PublishPosting<PositionPublish>(ds);

        }

 

        [TestMethod()]
        [DataRow("PostingCycle", "1", "Round 1")]
        [DataRow("PostingState", "Cancel Posting", "Cancel Posting")]
        [DataRow("RequestState", "Posted", "Posted")]
        [DataRow("Area", "Area 03", "Area 03")]
        [DataRow("School", "0299", "Annunciation")]
        [DataRow("PositionLevel", "BC001E", "Primary and Junior")]
        [DataRow("FTEList", "50", "50%")]
        [DataRow("SchoolYear", "20192020", "20192020")]
        [DataRow("ApplicationType", "POP", "Permanent Open Position")]
        public void GetAppListItems_ReturnSelectItemName(string Operate, object initialValue, object expect)
        {
            //Arrange
            var action = "DDList";
            var para = new { Operate, Para1 = "20202021" }; 

            //Act
            var list = _action.AppOne.CommonList<NameValueList>(action, para);

            AssemblingList.SetLists(myDDLlist, list, "Value", "Name", initialValue.ToString());
            var result = myDDLlist.SelectedItem.Text; 

            //Assert
            Assert.IsNotNull(list);
            Assert.AreEqual(expect, result, Operate + "  " + result);
        }

        [TestMethod()]
        public void SpNameTest_ReturnSP_Name_byAction()
        { 
            //Arrange
            string action = "DDList";
            string expect = "dbo.tcdsb_LTO_PageGeneral_List";
            var para = new {Operate = action, Para1 ="202022021"};

            //Act
            string result = _action.AppOne.SpName(action, para);

            //Assert
            Assert.AreEqual(expect, result, $" SpName = { result } ");
        }

        [TestMethod()]
        public void SpNameTest_ReturnSP_NameWithParameter_byActionandNon_Anonymous()
        {
            //Arrange
            string action = "DDList";
            string expect = "dbo.tcdsb_LTO_PageGeneral_List @Operate,@Para0,@Para1,@Para2,@Para3";
            var para = new CommonParameter(); 
            //Act
            string result = _action.AppOne.SpName(action, para);

            //Assert
            Assert.AreEqual(expect, result, $" SpName = { result } ");
        }

        [TestMethod()]
        public void SpNameTest_ReturnSP_Name_byActionSchools()
        { 
            //Arrange
            string action = "Schools";
            string expect = "dbo.tcdsb_LTO_PageGeneral_ListSchools";
            var para = new { Operate = action, Para1 = "202022021" };
            //Act
            string result = _action.AppOne.SpName(action, para);

            //Assert
            Assert.AreEqual(expect, result, $" SpName = { result } ");
        }

        [TestMethod()]
        public void SpNameTest_ReturnSP_NameWithParameter_byActionSchoolandNon_Anonymous()
        {
            //Arrange
            string action = "Schools";
            string expect = "dbo.tcdsb_LTO_PageGeneral_ListSchools @Operate,@Para0,@Para1,@Para2,@Para3";
            var para = new CommonParameter();

            //Act
            string result = _action.AppOne.SpName(action, para);

            //Assert
            Assert.AreEqual(expect, result, $" SpName = { result } ");
        }
    }
}
