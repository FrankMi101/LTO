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
    public class PostingInterviewExcTests
    {
        string expect = "Successfully";
        int positionID = 0;
        string schoolyear = "20182019";
        ParametersForPositionList parameters = new ParametersForPositionList()
        {
            Operate = "Page",
            UserID = "mif",
            SchoolYear = "20182019",
            PositionType = "LTO",
            Panel = "02",    //"05"
            Status = "Open",
            SearchBy = "All",
            SearchValue1 = "",
            SearchValue2 = ""
        };
        InterviewResult interview = new InterviewResult()
        {
            Operate = "Update",
            UserID = "mif",
            SchoolYear = "20182019",
            CPNum = "00015762",
            Recommendation = "Recommendation for hire",
            InterviewDate = "2018/08/21",
            EffectiveDate = "2018/09/04",
            OutCome = "0",
            Acceptance = "0"

        };

        ParametersForPosition forPosition = new ParametersForPosition()
        {
            SchoolYear = "20182019",
            PositionID = "11220",
            CPNum = "00019270"

        };


        [TestMethod()]
        public void PositionsTest_return_all_school_posted_Positions ()
        {
            //Arrange    
            parameters.SchoolCode = "0529";
            parameters.Panel = "05";
            string expect = "0529";

            //Act
            var list = PostingInterviewExc.Positions(parameters);
            int resultCount = list.Count;
            var result = list[0].SchoolCode;
            //Assert
            Assert.AreEqual(expect, result, $"  posting interview open position   { result}");

            Assert.IsTrue(resultCount >= 1, $"  posting interview open position  { resultCount}");

        }



        [TestMethod()]
        public void InterviewCandidatesTest_return_all_interviewCandidate_forThePosted_byPositionID()
        {
            //Arrange   

            forPosition.PositionID = "11220";
            string expect = "11220";

            //Act
            var list = CommonListExecute.InterviewCandidates(forPosition);
            int resultCount = list.Count;
            var result = list[0].CPNum;
            //Assert
            //  Assert.AreEqual(expect, result, $"  Posting position is { result}");
            Assert.IsTrue(resultCount >= 1, $"  interview list is { resultCount}");
        }

        [TestMethod()]
        public void CandidateTest_Return_onlyoneRecord_forTheCandiate()
        {
            //Arrange   
          
            string expect = "00019270";

            //Act
            var list = PostingInterviewExc.Candidate(forPosition);
            int resultCount = list.Count;
            var result = list[0].CPNum;
            //Assert
            Assert.AreEqual(expect, result, $"  Interview candidate is { result}");
            Assert.IsTrue(resultCount >= 1, $"  Interview  candidate list is { resultCount}");
        }

        [TestMethod()]
        public void SaveInterviewTest()
        {
            //Arrange                          
            interview.Operate = "Update";
            interview.PositionID = "11220";
            interview.CPNum = "00019270";

            //Act
            var result = PostingInterviewExc.InterviewOperation(interview, interview.PositionID);
            //Assert
            Assert.AreEqual(expect, result, $"  Interview candidate is { result}");
        }

        [TestMethod()]
        public void RecommendHireTest()
        {
            //Arrange   
            interview.Operate = "Update";
            interview.PositionID = "10929";
            interview.CPNum = "00038916";
            interview.Acceptance = "1";

            //Act
           // var result = PostingInterviewExc.RecommendHire(interview, interview.PositionID);
            var result = PostingInterviewExc.InterviewOperation(interview, interview.PositionID);
            //Assert
            Assert.AreEqual(expect, result, $"  Interview candidate is { result}");
        }


        [TestMethod()]
        public void InterviewSignOffActionTest()
        {
            //Arrange
            //Arrange
            interview.Operate = "SignOffAction";
            interview.UserID = "mif";
            interview.PositionID = "10929";
            interview.CPNum = "00038916";
            expect = "All,Sign Off Successfully, Interview candidate";
            //Act
            var result = PostingInterviewExc.InterviewOperation(interview, interview.PositionID); // PostingInterviewExc.InterviewSignOffAction(interview, interview.PositionID);
            var index = expect.IndexOf(result);
            //Assert
            Assert.IsTrue(index > 0, $"  Process Status Test is ok { result}");

        }
        [TestMethod()]
        public void CheckInterviewCountTest()
        {

            //Arrange
            interview.Operate = "InterviewCount";
            interview.UserID = "mif";
            interview.PositionID = "10929";
            interview.CPNum = "00038916";
            expect = "0";
             //Act
            var result = PostingInterviewExc.InterviewOperation(interview, interview.PositionID); // PostingInterviewExc.CheckInterviewCount(interview, interview.PositionID);
            int remaindCount = Int32.Parse(result);  
            //Assert

            Assert.IsTrue(remaindCount >= 0, $"  Interview remaind candidate is { result}");
        }
        [TestMethod()]
        public void CheckSignOffCountTest()
        {
            //Arrange
            interview.Operate = "SignOffCount";
            interview.UserID = "mif";
            interview.PositionID = "10929";
            interview.CPNum = "00038916";
            expect = "1";
            //Act
            var result = PostingInterviewExc.InterviewOperation(interview, interview.PositionID); // PostingInterviewExc.CheckSignOffCount(interview, interview.PositionID);
            int signOffCount = Int32.Parse(result);
            //Assert
            Assert.IsTrue(signOffCount >= 0, $" Candidate signoff on HM40 aggreement count { result}");

        }
        [TestMethod()]
        public void CheckHiringProcessStatusTest()
        {
            //Arrange
            interview.Operate = "PositionHiringStatus";
            interview.UserID = "mif";
            interview.PositionID = "10929";
            interview.CPNum = "00038916";
            interview.SchoolYear = "20182019";

            expect = "All,Hired,End,Recommend,Revoked,Noticed,More Interview";
            //Act
            var result = PostingInterviewExc.InterviewOperation(interview, interview.PositionID); //   PostingInterviewExc.CheckHiringProcessStatus(interview, interview.PositionID);
            var index = expect.IndexOf(result);
            //Assert
            Assert.IsTrue( index > 0 , $"  Process Status Test is ok { result}");

        }

    }
}