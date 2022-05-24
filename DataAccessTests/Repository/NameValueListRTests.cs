using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using System.Web.UI.WebControls;
using AppOperate;

namespace DataAccess.Repository.Tests
{
    [TestClass()]
    public class NameValueListRTests
    {
        private List2Item parameter = new List2Item() { Operate = "Panel", Para0 = "mif", Para1 = "20192020" };
        private DropDownList myDDLlist = new DropDownList();
 
       //   private readonly IAppServices _action = new AppServices(DBConnection.DBSource);
         private readonly IAppServices _action = new AppServices("Fake");

        [TestInitialize]
        public void Setup()
        {
            // Runs before each test. (Optional)
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
        public void GetAppListItems_FromFakeDataSource_ReturnSelectItemName(string operate, object initialValue, object expect)
        {
            //Arrange
            parameter.Operate = operate;
     
            //Act
            var list = _action.AppNVList.ListOfT("", parameter);

            //myDDLlist.DataSource = list;
            //myDDLlist.DataTextField = "Name";
            //myDDLlist.DataValueField = "Value";
            //myDDLlist.DataBind();

           AssemblingList.SetLists(myDDLlist,list,"Value","Name", initialValue.ToString());
            var result = myDDLlist.SelectedItem.Text;


            //var result = from s in list
            //             where s.Value == initialValue.ToString()
            //             select s.Name; 

          // Assert.IsNotNull(list);
          //  Assert.AreEqual(expect, result.FirstOrDefault(), operate + "  " + result);

            //Assert
           Assert.IsNotNull(list);
           Assert.AreEqual(expect, result , operate + "  " + result);
        }
    }
}