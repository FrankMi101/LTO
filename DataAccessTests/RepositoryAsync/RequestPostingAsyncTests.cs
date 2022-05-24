using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace DataAccess.Repository.Tests
{
    [TestClass()]
    public class RequestPostingAsyncTests
    {
         private int _ids = 0;
       
        private readonly IAppServicesAsync _action = new AppServiceAsync( new RequestPostingAsync(DBConnection.DBSource));
        //  private readonly IAppServices _action = new AppServices(new RequestPosting("Fake"));

        [TestMethod()]
        public async Task  RequestPosting_Positions_Action_ReturnAllRequestListbyPara_Test()
        {
            //Arrange
            string action = "Positions";
            var para = new
            {
                Operate = "All",
                UserID = "mif",
                SchoolYear = "20212022",
                SchoolCode ="0290"
            };
            int expect = 17;

            //Act
            var positions = await _action.AppOne.CommonList<PositionRequesting>(action, para);
            int result = positions.Count();
            //Assert
            Assert.AreEqual(expect, result, $" Request Posting Positions = { result } ");
        }

        [TestMethod()]
        public async Task  RequestPosting_Position_Action_ReturnPostionbyID_Test()
        {
            //Arrange
            string action = "Position";
            var para = new
            {
                SchoolYear = "20212022",
                PositionID = "5710"
            };
            string expect = "Grade 01 Teacher";

            //Act
            var position = await _action.AppOne.CommonObject<PositionRequesting>("Position", para);
            string result = position.PositionTitle;

            //Assert
            Assert.AreEqual(expect, result, $" Request Posting Position by ID = { result } ");
        }

        [TestMethod()]
        public async Task  RequestPosting_NewRequest_Action_ReturnNewID_Test()
        {
            //Arrange
            string action = "NewRequest";
            var para = new { Operate = "NewRequest", UserID = "Tester", SchoolYear = "20212022", SchoolCode = "0204", PositionID = "0", PositionType = "LTO" };


            //Act
            var result = await _action.AppOne.CommonAction(action, para); 
            _ids = int.Parse(result);

            //Assert
            Assert.IsNotNull( result, $" Request Posting Position by ID = { result } ");
        }


        [TestMethod()]
        public async Task  RequestPosting_UpdateRequest_Action_ReturnSuccessfully_Test()
        {
            //Arrange
            string action = "Update";
            PerpareForTest(action);
            var para = new { Operate = action, UserID = "Tester", SchoolYear = "20212022", SchoolCode = "0204", 
                PositionID = _ids.ToString(), 
                PositionType = "LTO",
                StartDate = "2021-09-06",
                EndDate = "2022-06-30",
                Comments = "Intergration Test Update Action "
            };
            string expect = "Successfully";

            //Act
            var result = await _action.AppOne.CommonAction(action, para); 

            //Assert
            Assert.IsNotNull(expect,result, $" Request Posting Position Update Test  { result } ");
        }

        [TestMethod()]
        public async Task  RequestPosting_DeleteRequest_Action_ReturnSuccessfully_Test()
        {
            //Arrange
            string action = "Delete";
            PerpareForTest(action);
            var para = new { Operate = action,UserID = "",SchoolYear = "",SchoolCode = "", PositionID = _ids.ToString()};
            string expect = "Successfully";

            //Act
            var result = await _action.AppOne.CommonAction(action,para);

            //Assert
            Assert.IsNotNull(expect, result, $" Request Posting Position Update Test  { result } ");
        }

        [TestMethod()]
        public async Task  RequestPosting_CallBack_Action_ReturnSuccessfully_Test()
        {
            //Arrange
            string action = "Call Back";
            PerpareForTest(action);

            var para = new { Operate = action, UserID = "", SchoolYear = "", SchoolCode = "", PositionID = _ids.ToString() };
            string expect = "Successfully";
            string expect2 = "Initial";

            //Act
            var result = await _action.AppOne.CommonAction(action,para);

            var paraGet = new
            {
                SchoolYear = "20212022",
                PositionID = _ids.ToString()
            };
            var position = await _action.AppOne.CommonObject<PositionRequesting>("Position", paraGet);
            var result2 = position.RequestStatus;
            //Assert
            Assert.AreEqual(expect, result, $" Recall Request Posting Test  { result } ");
            Assert.AreEqual(expect2, result2, $" Request Posting Position Update Test  { result } ");
        }

        [TestMethod()]
        public async Task  SpNameTest_ReturnSP_Name_byAction()
        {
            //Arrange
             string action = "Positions";
           var para = new { Operate = action, SchoolYear = "2021202" };
             string expect = "dbo.tcdsb_LTO_PageRequest_Positions";

            //Act
            string result =   _action.AppOne.SpName(action, para);

            //Assert
            Assert.AreEqual(expect, result, $" SpName = { result } "); 
        }

        [TestMethod()]
        public async Task  SpNameTest_ReturnSP_NameandParameters_byActionAndNoAnonymousOBject()
        {
            //Arrange
            string action = "Positions";
             var para = new PositionPublish() { Operate = action,UserID ="test", SchoolYear = "20210222" , SchoolCode="0299" };
            string expect = "dbo.tcdsb_LTO_PageRequest_Positions @Operate, @UserID, @SchoolYear, @SchoolCode";

            //Act
            string result =   _action.AppOne.SpName(action, para);

            //Assert
            Assert.AreEqual(expect, result, $" SpName = { result } ");
        }


        [TestCleanup]
        public async Task  TestCleanup()
        {
            try
            {
                var para = new {Operate ="Delete",UserID="",SchoolYear="",SchoolCode="", PositionID = _ids.ToString()};
               await _action.AppOne.CommonAction("Delete",para);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private async Task PerpareForTest(string action)
        {
            try
            {
                 action = "NewRequest";
                var para = new { Operate = action, UserID = "Tester", SchoolYear = "20212022", SchoolCode = "0204", PositionID = "0", PositionType = "LTO" };
                var result = await _action.AppOne.CommonAction(action,para); // .AddObj(_para).Replace("Successfully", "");
                _ids = int.Parse(result);
            }
            catch (Exception)
            {
                _ids = 0;
            }
        }
    }
}