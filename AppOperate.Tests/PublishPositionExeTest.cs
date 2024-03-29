using System.Collections.Generic;
using ClassLibrary;
using System;
using AppOperate;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppOperate.Tests
{
    /// <summary>This class contains parameterized unit tests for PublishPositionExe</summary>
    [TestClass]
    [PexClass(typeof(PublishPositionExe))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class PublishPositionExeTest
    {

        /// <summary>Test stub for Add(Object)</summary>
        [PexMethod]
        public string AddTest(object parameter)
        {
            string result = PublishPositionExe.Add(parameter);
            return result;
            // TODO: add assertions to method PublishPositionExeTest.AddTest(Object)
        }

        /// <summary>Test stub for Attribute(Object)</summary>
        [PexMethod]
        public string AttributeTest(object parameter)
        {
            string result = PublishPositionExe.Attribute(parameter);
            return result;
            // TODO: add assertions to method PublishPositionExeTest.AttributeTest(Object)
        }

        /// <summary>Test stub for Cancel(Object)</summary>
        [PexMethod]
        public string CancelTest(object parameter)
        {
            string result = PublishPositionExe.Cancel(parameter);
            return result;
            // TODO: add assertions to method PublishPositionExeTest.CancelTest(Object)
        }

        /// <summary>Test stub for Deadline(Object)</summary>
        [PexMethod]
        public string DeadlineTest(object parameter)
        {
            string result = PublishPositionExe.Deadline(parameter);
            return result;
            // TODO: add assertions to method PublishPositionExeTest.DeadlineTest(Object)
        }

        /// <summary>Test stub for DefaultDate(Object)</summary>
        [PexMethod]
        public List<LTODefalutDate> DefaultDateTest(object parameter)
        {
            List<LTODefalutDate> result = PublishPositionExe.DefaultDate(parameter);
            return result;
            // TODO: add assertions to method PublishPositionExeTest.DefaultDateTest(Object)
        }

        /// <summary>Test stub for Delete(Object)</summary>
        [PexMethod]
        public string DeleteTest(object parameter)
        {
            string result = PublishPositionExe.Delete(parameter);
            return result;
            // TODO: add assertions to method PublishPositionExeTest.DeleteTest(Object)
        }

        /// <summary>Test stub for Position(Object)</summary>
        [PexMethod]
        public List<PositionPublish> PositionTest(object parameter)
        {
            List<PositionPublish> result = PublishPositionExe.Position(parameter);
            return result;
            // TODO: add assertions to method PublishPositionExeTest.PositionTest(Object)
        }

        /// <summary>Test stub for PositionInfo(Object)</summary>
        [PexMethod]
        public List<PositionInfo> PositionInfoTest(object parameter)
        {
            List<PositionInfo> result = PublishPositionExe.PositionInfo(parameter);
            return result;
            // TODO: add assertions to method PublishPositionExeTest.PositionInfoTest(Object)
        }

        /// <summary>Test stub for Positions(Object)</summary>
        [PexMethod]
        public List<PositionListPublish> PositionsTest(object parameter)
        {
            List<PositionListPublish> result = PublishPositionExe.Positions(parameter);
            return result;
            // TODO: add assertions to method PublishPositionExeTest.PositionsTest(Object)
        }

        /// <summary>Test stub for PostingRounds(Object)</summary>
        [PexMethod]
        public List<PositionPublish> PostingRoundsTest(object parameter)
        {
            List<PositionPublish> result = PublishPositionExe.PostingRounds(parameter);
            return result;
            // TODO: add assertions to method PublishPositionExeTest.PostingRoundsTest(Object)
        }

        /// <summary>Test stub for PrincipalsEmail(Object)</summary>
        [PexMethod]
        public string PrincipalsEmailTest(object parameter)
        {
            string result = PublishPositionExe.PrincipalsEmail(parameter);
            return result;
            // TODO: add assertions to method PublishPositionExeTest.PrincipalsEmailTest(Object)
        }

        /// <summary>Test stub for RePosting(Object)</summary>
        [PexMethod]
        public string RePostingTest(object parameter)
        {
            string result = PublishPositionExe.RePosting(parameter);
            return result;
            // TODO: add assertions to method PublishPositionExeTest.RePostingTest(Object)
        }

        /// <summary>Test stub for SPName(String)</summary>
        [PexMethod]
        public string SPNameTest(string action)
        {
            string result = PublishPositionExe.SpName(action);
            return result;
            // TODO: add assertions to method PublishPositionExeTest.SPNameTest(String)
        }

        /// <summary>Test stub for Update(Object)</summary>
        [PexMethod]
        public string UpdateTest(object parameter)
        {
            string result = PublishPositionExe.Update(parameter);
            return result;
            // TODO: add assertions to method PublishPositionExeTest.UpdateTest(Object)
        }
    }
}
