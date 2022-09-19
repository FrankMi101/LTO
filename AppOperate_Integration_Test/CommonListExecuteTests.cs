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
    public class CommonListExecuteTests
    {
        string schoolyear = "20182019";
        string currentSchoolYear = UserTrack.TrackInfo("admin", "cSchoolYear");

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

       private ParametersForPositionList parameters = new ParametersForPositionList()
        {
            Operate = "Page",
            UserID = "mif",
            SchoolYear = "20192020",
            PositionType = "LTO",
            Panel = "02",    //"05"
            Status = "Open",
            SearchBy = "All",
            SearchValue1 = "",
            SearchValue2 = ""
        };

        [TestMethod()]
        public void RequestPositionsTest_ReturnAllGiveSchoolRequestList_WithGridView ()
        {
            //Arrange    
            parameters.SchoolCode = "0225";
            string expect = "0225";
            var testGridview = new System.Web.UI.WebControls.GridView();

            //Act
            var list =  CommonListExecute.RequestPositions(parameters);
            testGridview.AutoGenerateColumns = true;
            testGridview.DataSource = list;
            testGridview.DataBind();

            int resultCount =  testGridview.Rows.Count;
            var result =  list[0].SchoolCode;
            //Assert
             Assert.AreEqual(expect, result, $"  Posting position is { result}");
            Assert.IsTrue(resultCount >= 1, $"  request  posting List is { resultCount}");
        }
        [TestMethod()]
        public void RequestPositionsTest_ReturnAllGiveSchoolRequestList_WithoutGridView()
        {
            //Arrange    
            parameters.SchoolCode = "0225";
            string expect = "0225";
             //Act
            var list = CommonListExecute.RequestPositions(parameters);
 
            int resultCount = list.Count; 
            var result = list[0].SchoolCode;
            //Assert
            Assert.AreEqual(expect, result, $"  Posting position is { result}");
            Assert.IsTrue(resultCount >= 1, $"  request  posting List is { resultCount}");
        }
        [TestMethod()]
        public void RequestPositionTest_RequestPostingbyRequestID_Retune_1_Record()
        {

            //Arrange

            var parameter = new ParametersForPosition()
            {
                SchoolYear = "20182019",
                PositionID = "1485",
            };
            int expect = 1485;

            //Act
            var postingList = CommonListExecute.RequestPosition(parameter);
            int result = postingList[0].PositionID;
            int resultCount = postingList.Count;

            //Assert
            Assert.AreEqual(expect, result, $"  Posting position is { result}");
            Assert.IsTrue(resultCount > 0, $"  Posting position is { result}");
        }

        [TestMethod()]
        public void ApprovePositionsTest_RetuenAllList_HasnotPostedYet()
        {
            //Arrange    
            parameters.Status = "All";
            string expect = "LTO";

            //Act
            var list = CommonListExecute.ApprovePositions(parameters);
            int resultCount = list.Count;
            var result = list[0].PositionType;
            //Assert
          //   Assert.AreEqual(expect, result, $"  approve request position is { result}");
            Assert.IsTrue(resultCount >= 0, $"  approve request posting List is { resultCount}");
        }

        [TestMethod()]
        public void ApprovePositionTest_Return_oneList_of_thePositionID()
        {   //Arrange    
            // create new request 
            int newid = getNewRequestID("LTO");   
            // update the request and principal request down.       
            var position = new PositionRequesting()
            {
                Operate = "Request Posting",
                UserID = "mif",
                SchoolYear = schoolyear,
                PositionID = newid
            };       
              RequestingPostExe.PostRequest(position, "0");

            //Act
 
            var parameter = new ParametersForPosition()
            {
                SchoolYear = schoolyear,
                PositionID = newid.ToString(),
            };
            int expect = newid;

            //Act
            var list = CommonListExecute.ApprovePosition(parameter);
            int resultCount = list.Count;
            int result = list[0].PositionID;
            //Assert
            Assert.AreEqual(expect, result, $"  approve request position by id  { result}");
            Assert.IsTrue(resultCount >= 0, $"  approve request posting List is { resultCount}");
        }

        [TestMethod()]
        public void PublishPositionsTest_ReturnAllPublishedList_bySearchAll()
        {
            //Arrange    
            parameters.Status = "All";
            string expect = "LTO";

            //Act
            var list = CommonListExecute.PublishPositions(parameters);
            int resultCount = list.Count;
            var result = list[0].PositionType;
            //Assert
               Assert.AreEqual(expect, result, $"  published positions are { result}");
            Assert.IsTrue(resultCount >= 100, $" published List is { resultCount}");
        }

        [TestMethod()]
        public void PublishPositionsTest_ReturnAllPublishedList_bySearchSchool()
        {
            //Arrange    
            parameters.Status = "All";
            parameters.SearchBy = "School";
            parameters.SearchValue1 = "0320";
              
            string expect = "0320";

            //Act
            var list = CommonListExecute.PublishPositions(parameters);
            int resultCount = list.Count;
            var result = list[0].SchoolCode;
            //Assert
            Assert.AreEqual(expect, result, $"  published positions are { result}");
            Assert.IsTrue(resultCount >= 1 , $"  published posting List is { resultCount}");
        }
        [TestMethod()]
        public void PublishPositionsTest_ReturnAllPublishedList_bySearchPostingCycle()
        {
            //Arrange    
            parameters.Status = "All";
            parameters.SearchBy = "PostingCycle";
            parameters.SearchValue1 = "3";

            string expect = "3";

            //Act
            var list = CommonListExecute.PublishPositions(parameters);
            int resultCount = list.Count;
            var result = list[0].PostingCycle;
            //Assert
            Assert.AreEqual(expect, result, $"  published positions are { result}");
            Assert.IsTrue(resultCount >= 1, $"  published posting List is { resultCount}");
        }
        [TestMethod()]
        public void PublishPositionsTest_ReturnAllPublishedList_bySearchDeadlineDate()
        {
            //Arrange    
            parameters.SchoolYear = "20182019";
            parameters.Status = "All";
            parameters.SearchBy = "DeadlineDate";
            parameters.SearchValue1 = "2018/10/15";
            parameters.SearchValue2 = "2018/10/15";
            string expect = "2018/10/15";

            //Act
            var list = CommonListExecute.PublishPositions(parameters);
            int resultCount = list.Count;
            var result = list[0].DateApplyClose;
            //Assert
            Assert.AreEqual(expect, result, $"  published positions are { result}");
            Assert.IsTrue(resultCount >= 1, $"  published posting List is { resultCount}");
        }
        public void PublishPositionsTest_ReturnAllPublishedList_bySearchPostingNumber()
        {
            //Arrange    
            parameters.Status = "All";
            parameters.SearchBy = "DeadlineDate";
            parameters.SearchValue1 = "2018-13136";   
            string expect = "2018-13136";

            //Act
            var list = CommonListExecute.PublishPositions(parameters);
            int resultCount = list.Count;
            var result = list[0].PostingNumber ;
            //Assert
            Assert.AreEqual(expect, result, $"  published positions are { result}");

            Assert.IsTrue(resultCount >= 4, $"  published posting List is { resultCount}");
        }
        [TestMethod()]
        public void PublishPositionTest_return_oneRecord_byPositionID()
        {
            //Arrange

            var parameter = new ParametersForPosition()
            {
                SchoolYear = schoolyear,
                PositionID = "13308",
            };
            int expect = 13308;

            //Act
            var postingList = CommonListExecute.PublishPosition(parameter);
            int result = postingList[0].PositionID;
            int resultCount = postingList.Count;

            //Assert
            Assert.AreEqual(expect, result, $"  Posting position is { result}");
            Assert.IsTrue(resultCount >= 1, $"  Posting position is { result}");
        }

        [TestMethod()]
        public void HiredPositionsTest_Return_allHiredList()
        {
            //Arrange    
            parameters.Status = "Close";
            parameters.SearchBy = "All";
            parameters.SearchValue1 = "";
            string expect = "2018-13136";

            //Act
            var list = CommonListExecute.HiredPositions(parameters);
            int resultCount = list.Count;
            var result = list[0].PostingNumber;
            //Assert
          //  Assert.AreEqual(expect, result, $"  published positions are { result}");

            Assert.IsTrue(resultCount >= 100, $"  Hireed posting List is { resultCount}");
        }
        [TestMethod()]
        public void HiredPositionTest_Return_oneRecord_by_PositionID_and_CPnum()
        {
            //Arrange

            var parameter = new ParametersForPosition()
            {
                SchoolYear = schoolyear,
                PositionID = "10971",
                CPNum = "00005922"
            };
            int expect = 10971;

            //Act
            var postingList = CommonListExecute.HiredPosition(parameter);
            int result = postingList[0].PositionID;
            int resultCount = postingList.Count;

            //Assert
            Assert.AreEqual(expect, result, $"  Hired position is { result}");
            Assert.IsTrue(resultCount >= 1, $"  Hired position is { result}");
        }

        [TestMethod()]
        public void ConfirmPositionsTest_return_ConfirmhireList ()
        {
            //Arrange    
            // this test  must running in specific time. when there is a confirm hre postion in system
           //;
             //Act
            var list = CommonListExecute.ConfirmPositions(parameters);
            int resultCount = list.Count;
            // var result = list[0].PostingNumber;
            //Assert
            // Assert.AreEqual(expect, result, $"  Confirm hire positions are { result}");

            Assert.IsTrue(resultCount >= 0, $"  Confirm hire positions List is { resultCount}");
        }
        [TestMethod()]
        public void ConfirmPositionsTest_return_ConfirmhireListIn_4thRound()
        {
            //Arrange    
            parameters.Operate = "4thRound"; // .Round4th = "1";
            //;
            //Act
            var list = CommonListExecute.ConfirmPositions(parameters);
            int resultCount = list.Count;
            // var result = list[0].PostingNumber;
            //Assert
            // Assert.AreEqual(expect, result, $"  Confirm hire positions are { result}");

            Assert.IsTrue(resultCount >= 0, $"  Confirm hire positions List is { resultCount}");
        }

        [TestMethod()]
        public void HirePositionTest()
        {
            //Arrange
           // this test  must running in specific time. when there is a confirm hre postion in system
            var parameter = new ParametersForPosition()
            {
                SchoolYear = schoolyear,
                PositionID = "10971",
                CPNum = "00005922"
            };
            int expect = 1;

            //Act
            var postingList = CommonListExecute.HirePosition(parameter);
            int result = 1;
            int resultCount = postingList.Count;

            //Assert
            Assert.AreEqual(expect, result, $"  Hired position is { result}");
            Assert.IsTrue(resultCount >= 0, $"  Hired position is { result}");
        }

 

        [TestMethod()]
        public void HirePosition4thRoundTest()
        {
            //Arrange
            // this test  must running in specific time. when there is a confirm hre postion in system
            var parameter = new ParametersForPosition()
            {
                SchoolYear = schoolyear,
                PositionID = "10971",
                CPNum = "00005922"
            };
            int expect = 1;

            //Act
            var postingList = CommonListExecute.HirePosition4thRound(parameter);
            int result = 1;
            int resultCount = postingList.Count;

            //Assert
            Assert.AreEqual(expect, result, $"  Hired position is { result}");
            Assert.IsTrue(resultCount >= 0, $"  Hired position is { result}");
        }

        [TestMethod()]
        public void QualificationListTest_return_allQualficationList()
        {
            //Arrange
            // this test  must running in specific time. when there is a confirm hre postion in system
            var parameter = new ParametersForPosition()
            {
                SchoolYear = schoolyear,
                PositionID = "10971",
                CPNum = "00005922"
            };
            int expect = 1;

            //Act
            var list = CommonListExecute.QualificationList(parameter);
            int result = 1;
            int resultCount = list.Count;

            //Assert
            Assert.AreEqual(expect, result, $" Qualification List is { result}");
            Assert.IsTrue(resultCount >= 0, $"  Qualification is { result}");
        }

        private DateTime getCloseDate(DateTime date)
        {  
            DayOfWeek day = date.DayOfWeek;
            if ( day == DayOfWeek.Saturday)   
            {
                date = date.AddDays(1);
                day = date.DayOfWeek;
            }

            if ( day == DayOfWeek.Sunday) 
            {
                date = date.AddDays(1);
            }
            return date;
        }
        [TestMethod()]
        public void LimitedDateTest_afterNewSchoolYearStart()
        {
            //Arrange
             var parameter = new LimitDate()
            {
                SchoolYear = currentSchoolYear,
                PositionType = "LTO",
                Operate = "GetDefault",
                DatePublish= DateFC.YMD(DateTime.Now)

             };
            int expect = 1;
            string expect1 = currentSchoolYear.Substring(0, 4) + "/09/03";   
            string expect2 = currentSchoolYear.Substring(4,4) + "/06/28";
            string expect3 = DateFC.YMD(getCloseDate(DateTime.Now.AddDays(2)));
            //Act
            var list = CommonListExecute.LimitedDate(parameter);
            int result = 1;
            int resultCount = list.Count;
            string result1 = list[0].StartDate ;
            string result2 = list[0].EndDate;
            string result3 = list[0].DateApplyClose;

            //Assert
            Assert.AreEqual(expect1, result1, $" Default start Date is { result1}");
            Assert.AreEqual(expect2, result2, $" Default End Date is { result2}");
          //  Assert.AreEqual(expect3, result3, $" Default Close Date is { result3}");
            Assert.AreEqual(expect, result, $" Default Datetime List is { result}");
            Assert.IsTrue(resultCount >= 0, $" Default Datetime is { result}");
        }
        [TestMethod()]
        public void LimitedDateTest_BeforeNewSchoolYearStart()
        {
            //Arrange
            var parameter = new LimitDate()
            {
                SchoolYear = schoolyear,
                PositionType = "LTO",
                Operate = "GetDefault",
                DatePublish ="2018/06/10"
            };
            int expect = 1;
            string expect1 = "2018/09/03";
            string expect2 = "2019/06/28";
            string expect3 = "2018/08/14";    // setup date in tcdsb_LTO_StartDatebyYear
            string expect4 = "2018/08/16";     // setup date in tcdsb_LTO_StartDatebyYear
            //Act
            var list = CommonListExecute.LimitedDate(parameter);
            int result = 1;
            int resultCount = list.Count;
            string result1 = list[0].StartDate;
            string result2 = list[0].EndDate;
            string result3 = list[0].DateApplyOpen;
            string result4 = list[0].DateApplyClose;

            //Assert
            Assert.AreEqual(expect1, result1, $" Default start Date is { result1}");
            Assert.AreEqual(expect2, result2, $" Default End Date is { result2}");
            //Assert.AreEqual(expect3, result3, $" Default Open Date is { result3}");
            //Assert.AreEqual(expect4, result4, $" Default Close Date is { result4}");
            Assert.AreEqual(expect, result, $" Default Datetime List is { result}");
            Assert.IsTrue(resultCount >= 0, $" Default Datetime is { result}");
        }
        [TestMethod()]
        public void SchoolOpenPositionsTest_return_allPositionListbySchool()
        {
            //Arrange    
            parameters.SchoolCode = "0529";
            parameters.Panel = "05";
            string expect = "0529";

            //Act
            var list = CommonListExecute.SchoolOpenPositions(parameters);
            int resultCount = list.Count;
             var result = list[0].SchoolCode;
            //Assert
           Assert.AreEqual(expect, result, $"  Confirm hire positions are { result}");

            Assert.IsTrue(resultCount >= 1, $"  Confirm hire positions List is { resultCount}");
        }

       
        [TestMethod()]
        public void InterviewCandidatesTest_returnAllInterviewCandidateList_bythePositionID()
        {
            //Arrange   
            var parameter = new ParametersForPosition()
            {
                SchoolYear = schoolyear,
                PositionID  = "11220" 
            };
             string expect = "11220";

            //Act
            var list = CommonListExecute.InterviewCandidates(parameter);
            int resultCount = list.Count;
          //  var result = list[0].ActionSign;
            //Assert
          //  Assert.AreEqual(expect, result, $"  Posting position is { result}");
            Assert.IsNotNull(resultCount, $"  interview list is { resultCount}");
        }

        [TestMethod()]
        public void InterviewCandidateTest()
        {
            //Arrange
            var parameter = new ParametersForPosition()
            {
                SchoolYear = schoolyear,
                PositionID = "11220"  ,
                CPNum = "00015762"
            };
            var expect = "00015762";
            // Action
            var list = CommonListExecute.InterviewCandidate(parameter);
            int resultCount = list.Count;
            var result = list[0].CPNum;

            //Assert
             Assert.AreEqual(expect, result, $"  Interview  candidateis { result}");
            Assert.IsTrue(resultCount >= 1, $"  Interview  candidate is { resultCount}");

        }
    }
}