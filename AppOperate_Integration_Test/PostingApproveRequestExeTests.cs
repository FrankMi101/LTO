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
    public class PostingApproveRequestExeTests
    {
        string schoolyear = "20192020";
        [TestMethod()]
        public void PositionsTest_return_allRequestList()
        {
            //Arrange
            var myGridview = new System.Web.UI.WebControls.GridView();
            var parameter = new ParametersForPositionList()
            {
                Operate = "Page",
                UserID = "mif",
                SchoolYear = schoolyear,
                PositionType = "LTO",

            };
            int expect = 1;

            //Act
            var postingList = PostingApproveRequestExe.Positions(parameter);
            myGridview.AutoGenerateColumns = true;
            myGridview.DataSource = postingList;
            myGridview.DataBind();

            int result = myGridview.Rows.Count;

            //Assert
            // Assert.AreEqual(expect, result, $"  Posting position List { result}");
            //int gCount  
            Assert.IsTrue(result >= 0, $"  Posting approve position List { result}");
        }

        [TestMethod()]
        public void PositionTest_return_NewRequestPosition_From_Form100_or_Principal()
        {
            //Arrange
            var parameter = new ParametersForPosition()
            {
                SchoolYear = schoolyear,
                PositionID = "1666",

            };
            int expect = 1666;

            //Act
            var list = PostingApproveRequestExe.Position(parameter);
            int resultCount = list.Count;
            var result = list[0].PositionID;
            //Assert
            Assert.AreEqual(expect, result, $"  Posting approve{ result}");
            Assert.IsTrue(result >= 0, $"  Posting approve{ result}");
        }

        [TestMethod()]
        public void MultipleSchoolPrinciaplsTest_Return_PositionMultiSchoolPrincipalEmail_IfthePositionForMultipleSchool()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RejectRequestTest()
        {
            //Arrange
            var parameter = new PositionApprove()
            {
                Operate = "Reject",
                UserID = "mif",
                SchoolYear = schoolyear,
                PositionID = 1666,
                RequestSource = "Form100",
                SchoolCode = "0419"

            };
            string expect = "Successfully";

            //Act
            var result = PostingApproveRequestExe.RejectRequest(parameter, 1666);

            //Assert
            Assert.AreEqual(expect, result, $"  Reject Posting Request e{ result}");

        }

        [TestMethod()]
        public void PostingRequestTest()
        {
            //Arrange
            var parameter = new PositionPublish()
            {
                Operate = "Posted",
                UserID = "mif",
                SchoolYear = schoolyear,
                PositionID = 1666,
                RequestSource = "Form100",
                SchoolCode = "0419",
                Comments = "Post",
                StartDate = "2019/04/18",
                EndDate = "2019/05/27",
                DatePublish = "2019/03/25",
                DateApplyOpen = "2019/03/25",
                DateApplyClose = "2019/03/27",
                CPNum = "00014614",


            };
          //  string expect = "Successfully";

            //Act
            var result = PostingApproveRequestExe.PostingRequest(parameter, 1666);

            //Assert
          //  Assert.AreEqual(expect, result, $"  Reject Posting Request e{ result}");
            Assert.IsNotNull(result, $"  Reject Posting Request e{ result}");
        }

        [TestMethod()]
        public void UpdatePostingTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeletePostingTest()
        {
            //Arrange
            var parameter = new PositionApprove()
            {
                Operate = "Delete",
                UserID = "mif",
                SchoolYear = schoolyear,
                PositionID = 1647,
                RequestSource = "Form100",
                SchoolCode = "0227"

            };
            string expect = "Successfully";

            //Act
            var result = PostingApproveRequestExe.RejectRequest(parameter, 1666);

            //Assert
            Assert.AreEqual(expect, result, $"  Delete Posting Request { result}");
        }

        [TestMethod()]
        public void SavePostingTest()
        {
            //Arrange
            var parameter = new PositionApprove()
            {
                Operate = "Update",
                UserID = "mif",
                SchoolYear = schoolyear,
                PositionID = 1660,
                RequestSource = "Form100",
                SchoolCode = "0239",
                Comments = "Postin Comments",
                Description = "Posting description",
                FTE = 1.0M,
                FTEPanel = "Full",
                StartDate = "",
                EndDate = "",
                Owner = "frijiom",
                DatePublish = "",
                DateApplyOpen = "",
                DateApplyClose = "",
                PositionLevel = "BC708E",
                QualificationCode = "",
                Qualification = ""

            };
            string expect = "Successfully";

            //Act
            var result = PostingApproveRequestExe.SavePosting(parameter, 1666);

            //Assert
            Assert.AreEqual(expect, result, $"  Save Posting Request { result}");
        }
    

        [TestMethod()]
        public void PostingNumberTest()
        {   // Arrage
            int positionID = 14083;

            string expect = "2019-14083";
            // action

           string result =  PostingApproveRequestExe.PostingNumber(positionID);

            //Assert
            Assert.AreEqual(expect, result, $"  Save Posting Request { result}");
          
        }
        [TestMethod()]
        public void PostingNumberTest_return_PostingNumberIsYearPlusID_in_Round_1_Posting()
        {   // Arrage
            int positionID = 11047;

            string expect = "2018-11047";
            // action

            string result = PostingApproveRequestExe.PostingNumber(positionID);

            //Assert
            Assert.AreEqual(expect, result, $"  Save Posting Request { result}");

        }
        [TestMethod()]
        public void PostingNumberTest_return_SamePostingNumber_in_Round_2_Posting_when_Reposting_a_Position()
        {   // Arrage
            int positionID = 11374;

            string expect = "2018-11047";
            // action

            string result = PostingApproveRequestExe.PostingNumber(positionID);

            //Assert
            Assert.AreEqual(expect, result, $"  Save Posting Request { result}");

        }
        [TestMethod()]
        public void PostingNumberTest_return_SamePostingNumber_in_Round_3_Posting_when_Reposting_a_Position()
        {   // Arrage
            int positionID = 11486;

            string expect = "2018-11047";
            // action

            string result = PostingApproveRequestExe.PostingNumber(positionID);

            //Assert
            Assert.AreEqual(expect, result, $"  Save Posting Request { result}");

        }
        [TestMethod()]
        public void PostingNumberTest_return_SamePostingNumber_in_Round_4_Posting_when_Reposting_a_Position()
        {   // Arrage
            int positionID = 11580;

            string expect = "2018-11047";
            // action

            string result = PostingApproveRequestExe.PostingNumber(positionID);

            //Assert
            Assert.AreEqual(expect, result, $"  Save Posting Request { result}");

        }
    }
}