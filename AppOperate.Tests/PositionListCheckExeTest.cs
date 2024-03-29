using System.Collections.Generic;
using ClassLibrary;
using System;
using AppOperate;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppOperate.Tests
{
    /// <summary>This class contains parameterized unit tests for PositionListCheckExe</summary>
    [TestClass]
    [PexClass(typeof(PositionListCheckExe))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class PositionListCheckExeTest
    {

        /// <summary>Test stub for AvailablePositions(Object)</summary>
        [PexMethod]
        public List<PositionListApplying> AvailablePositionsTest()
        {
            var parameter = CommonParameter.GetParameters("Get", "mif", "20212022", "LTO", "", "", "LTOTeacher", "00052589");
            List<PositionListApplying> result = PositionListCheckExe.AvailablePositions(parameter);
          //  return result;
            // TODO: add assertions to method PositionListCheckExeTest.AvailablePositionsTest(Object)
            //Assert
            var result1 = result.Count.ToString();//  myGridview.Rows.Count.ToString();

            Assert.IsNotNull(result, $" position list count {result}");
            return result;
        }

        /// <summary>Test stub for ConvertFunctionStringToTable(Object)</summary>
        [PexMethod]
        public List<GeneralCheck> ConvertFunctionStringToTableTest(object parameter)
        {
            List<GeneralCheck> result = PositionListCheckExe.ConvertFunctionStringToTable(parameter);
            return result;
            // TODO: add assertions to method PositionListCheckExeTest.ConvertFunctionStringToTableTest(Object)
        }

        /// <summary>Test stub for ConvertFunctionTableToString(Object)</summary>
        [PexMethod]
        public string ConvertFunctionTableToStringTest(object parameter)
        {
            string result = PositionListCheckExe.ConvertFunctionTableToString(parameter);
            return result;
            // TODO: add assertions to method PositionListCheckExeTest.ConvertFunctionTableToStringTest(Object)
        }

        /// <summary>Test stub for HiredPositions(Object)</summary>
        [PexMethod]
        public List<PositionListHired> HiredPositionsTest(object parameter)
        {
            List<PositionListHired> result = PositionListCheckExe.HiredPositions(parameter);
            return result;
            // TODO: add assertions to method PositionListCheckExeTest.HiredPositionsTest(Object)
        }

        /// <summary>Test stub for InterviewCandidates(Object)</summary>
        [PexMethod]
        public List<CandidateList> InterviewCandidatesTest(object parameter)
        {
            List<CandidateList> result = PositionListCheckExe.InterviewCandidates(parameter);
            return result;
            // TODO: add assertions to method PositionListCheckExeTest.InterviewCandidatesTest(Object)
        }

        /// <summary>Test stub for InterviewPositions(Object)</summary>
        [PexMethod]
        public List<PositionListPublish> InterviewPositionsTest(object parameter)
        {
            List<PositionListPublish> result = PositionListCheckExe.InterviewPositions(parameter);
            return result;
            // TODO: add assertions to method PositionListCheckExeTest.InterviewPositionsTest(Object)
        }

        /// <summary>Test stub for PublishPositions(Object)</summary>
        [PexMethod]
        public List<PositionListPublish> PublishPositionsTest(object parameter)
        {
            List<PositionListPublish> result = PositionListCheckExe.PublishPositions(parameter);
            return result;
            // TODO: add assertions to method PositionListCheckExeTest.PublishPositionsTest(Object)
        }

        /// <summary>Test stub for SelectCandidates(Object)</summary>
        [PexMethod]
        public List<ApplicantListSelect> SelectCandidatesTest(object parameter)
        {
            List<ApplicantListSelect> result = PositionListCheckExe.SelectCandidates(parameter);
            return result;
            // TODO: add assertions to method PositionListCheckExeTest.SelectCandidatesTest(Object)
        }

        /// <summary>Test stub for SelectPositions(Object)</summary>
        [PexMethod]
        public List<PositionListPublish> SelectPositionsTest(object parameter)
        {
            List<PositionListPublish> result = PositionListCheckExe.SelectPositions(parameter);
            return result;
            // TODO: add assertions to method PositionListCheckExeTest.SelectPositionsTest(Object)
        }

        /// <summary>Test stub for SpName(String)</summary>
        [PexMethod]
        public string SpNameTest(string action)
        {
            string result = PositionListCheckExe.SPName(action);
            return result;
            // TODO: add assertions to method PositionListCheckExeTest.SpNameTest(String)
        }
    }
}
