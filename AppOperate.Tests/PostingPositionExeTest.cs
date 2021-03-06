using System.Collections.Generic;
using ClassLibrary;
using System;
using AppOperate;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppOperate.Tests
{
    /// <summary>This class contains parameterized unit tests for PostingPositionExe</summary>
    [TestClass]
    [PexClass(typeof(PostingPositionExe))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class PostingPositionExeTest
    {

        /// <summary>Test stub for Position(Object)</summary>
        [PexMethod]
        public List<PositionApprove> PositionTest(object parameter)
        {
            List<PositionApprove> result = PostingPositionExe.Position(parameter);
            return result;
            // TODO: add assertions to method PostingPositionExeTest.PositionTest(Object)
        }

        /// <summary>Test stub for Positions(Object)</summary>
        [PexMethod]
        public List<PositionListApprove> PositionsTest(object parameter)
        {
            List<PositionListApprove> result = PostingPositionExe.Positions(parameter);
            return result;
            // TODO: add assertions to method PostingPositionExeTest.PositionsTest(Object)
        }

        /// <summary>Test stub for Posting(Object)</summary>
        [PexMethod]
        public string PostingTest(object parameter)
        {
            string result = PostingPositionExe.Posting(parameter);
            return result;
            // TODO: add assertions to method PostingPositionExeTest.PostingTest(Object)
        }

        /// <summary>Test stub for PostingNumber(Object)</summary>
        [PexMethod]
        public string PostingNumberTest(object parameter)
        {
            string result = PostingPositionExe.PostingNumber(parameter);
            return result;
            // TODO: add assertions to method PostingPositionExeTest.PostingNumberTest(Object)
        }

        /// <summary>Test stub for Reject(Object)</summary>
        [PexMethod]
        public string RejectTest(object parameter)
        {
            string result = PostingPositionExe.Reject(parameter);
            return result;
            // TODO: add assertions to method PostingPositionExeTest.RejectTest(Object)
        }

        /// <summary>Test stub for SPName(String)</summary>
        [PexMethod]
        public string SPNameTest(string action)
        {
            string result = PostingPositionExe.SPName(action);
            return result;
            // TODO: add assertions to method PostingPositionExeTest.SPNameTest(String)
        }

        /// <summary>Test stub for Save(Object)</summary>
        [PexMethod]
        public string SaveTest(object parameter)
        {
            string result = PostingPositionExe.Save(parameter);
            return result;
            // TODO: add assertions to method PostingPositionExeTest.SaveTest(Object)
        }
    }
}
