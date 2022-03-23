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
    public class RequestingPostExeTests
    {
        string schoolyear = "20192020";
        private int getNewRequestID(string positionType)
        {
            var parameter = new PositionRequesting()
            {
                Operate = "New",
                SchoolYear = schoolyear,
                PositionID = 0,
                PositionType = positionType,
                SchoolCode = "0320",
                UserID = "mif"
            };
            string newid = RequestingPostExe.NewRequest(parameter, "0");  
            int x = Int32.Parse(newid);
            return x;
        }

        [TestMethod()]
        public void PositionsTest_PostingRequestList_ReturnAllbySchool()
        {
            //Arrange
            var myGridview = new System.Web.UI.WebControls.GridView();

            //  var parameters = CommonParameter.GetParameters("Request", User.Identity.Name, Me.ddlSchoolYear.SelectedValue, Me.ddlschoolcode.SelectedValue)

            var parameter = new ParametersForPositionList()
            {
                Operate = "Retrieve",
                UserID = "mif",
                SchoolYear = schoolyear,
                SchoolCode = "0320"
            };
            string expect = "334";

            //Act
            var postingList = PostingPublishExe.Positions(parameter);
            myGridview.AutoGenerateColumns = true;
            myGridview.DataSource = postingList;
            myGridview.DataBind();

            var result = myGridview.Rows.Count.ToString();

            //Assert
            Assert.IsNotNull(result, $"  Posting position List { result}");

        }

        [TestMethod()]
        public void PositionTest_RequestPostingbyRequestID()
        {    //Arrange

            int newid = getNewRequestID("LTO");

            ParametersForPosition parameters = CommonParameter.GetParameters(schoolyear, newid.ToString());

            int expect = newid;

            //Act
            PositionRequesting position = RequestingPostExe.Position(parameters)[0];

            int result = position.PositionID;

            //Assert
            Assert.AreEqual(expect, result, $"  Request position by ID { result} ");

        }

        [TestMethod()]
        public void SaveRequestTest()
        {  //Arrange 

            int newid = getNewRequestID("LTO");
            var parameter = new PositionRequesting()
            {
                Operate = "Update",
                UserID = "mif",
                SchoolYear = schoolyear,
                SchoolCode = "0320",
                PositionID = newid,
                Comments = "Posting reques,t comment ",
                PositionType = "LTO",
                PositionTitle = "Title of posting",
                PositionLevel = "BC708E",
                Qualification = "",
                Description = "Description",
                FTE = 67,
                FTEPanel = "AM",
                StartDate = "2019/03/10",
                EndDate = "2019/06/25 ",
                ReplaceTeacher = "New Teacher",
                ReplaceTeacherID = "00031675",
                ReplaceReason = "Pregnancy/Parental",
                Owner = "frijiom"
            };
            string expect = "Successfully";
            //Act
            var result = RequestingPostExe.SaveRequest(parameter, "0");

            //Assert
            Assert.AreEqual(expect, result, $"  Request position by ID { result} ");


        }

        [TestMethod()]
        public void PostRequestTest()
        {
            //Arrange 

            int newid = getNewRequestID("LTO");
            var position = new PositionRequesting()
            {
                Operate = "Request Posting",
                UserID = "mif",
                SchoolYear = schoolyear,
                PositionID = newid
            };
            string expect = "Successfully";
            //Act
            var result = RequestingPostExe.PostRequest(position, "0");

             //Assert
            Assert.AreEqual(expect, result, $" Create New Request position   { result} ");
        }

       
        [TestMethod()]
        public void DeleteRequestTest()
        {     //Arrange 

            int newid = getNewRequestID("LTO");
             var position = new PositionRequesting()
            {
                Operate = "Delete",
                UserID = "mif",
                SchoolYear = schoolyear,
                 PositionID = newid
             };
            string expect = "Successfully";
            //Act
            var result = RequestingPostExe.DeleteRequest(position, "0");

            //Assert
            Assert.AreEqual(expect, result, $" Create New Request position   { result} ");
        }

        [TestMethod()]
        public void NewRequestTest()
        {
            //Arrange 
            var position = new PositionRequesting()
            {
   
                Operate = "Request",
                UserID = "mif",
                SchoolYear = schoolyear,
                SchoolCode = "0320",
                PositionID = 0,
                PositionType = "LTO",
  
            };
            int expect = 1633;
            //Act
            var result = RequestingPostExe.NewRequest(position, "0");
             
            //Assert
            Assert.IsNotNull( result, $" Create New Request position   { result} ");

        }

        [TestMethod()]
        public void UpdateQualificationTest()
        {
            //Arrange 
            int newid = getNewRequestID("LTO"); 
            var position = new QualificationUpdate()
            {

                Operate = "Update",
                UserID = "mif",
                SchoolYear = schoolyear,
                SchoolCode = "0320",
                PositionID = newid,
                SourceID = "Request"    ,
                QualificationID = "230",
                Selected = "True"  
             };

            string expect = "Successfully,Failed";
            //Act
            var result = RequestingPostExe.UpdateQualification(position, newid.ToString());

  
            //Assert
            StringAssert.Contains(expect, result, $" Create New Request position   { result} ");

        }
    }
}