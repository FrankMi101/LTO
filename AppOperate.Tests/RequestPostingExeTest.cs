// <copyright file="RequestPostingExeTest.cs">Copyright ©  2018</copyright>
using System;
using System.Collections.Generic;
using AppOperate;
using ClassLibrary;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppOperate.Tests
{
    /// <summary>This class contains parameterized unit tests for RequestPostingExe</summary>
    [PexClass(typeof(RequestPostingExe))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class RequestPostingExeTest
    {
        /// <summary>Test stub for Add(Object)</summary>
        [PexMethod]
        public string AddTest(object parameter)
        {
            string result = RequestPostingExe.Add(parameter);
            return result;
            // TODO: add assertions to method RequestPostingExeTest.AddTest(Object)
        }

        /// <summary>Test stub for Cancel(Object)</summary>
       
        /// <summary>Test stub for Operation(String, Object)</summary>
        [PexMethod]
        public string OperationTest(string action, object parameter)
        {
            string result = RequestPostingExe.Operation(action, parameter);
            return result;
            // TODO: add assertions to method RequestPostingExeTest.OperationTest(String, Object)
        }

        /// <summary>Test stub for Position(Object)</summary>
        [PexMethod]
        public List<PositionRequesting> PositionTest(object parameter)
        {
            List<PositionRequesting> result = RequestPostingExe.Position(parameter);
            return result;
            // TODO: add assertions to method RequestPostingExeTest.PositionTest(Object)
        }

        /// <summary>Test stub for Positions(Object)</summary>
        [PexMethod]
        public List<PositionListRequesting> PositionsTest(object parameter)
        {
            List<PositionListRequesting> result = RequestPostingExe.Positions(parameter);
            return result;
            // TODO: add assertions to method RequestPostingExeTest.PositionsTest(Object)
        }

       

        /// <summary>Test stub for QualificationSTR(Object)</summary>
        [PexMethod]
        public string QualificationSTRTest(object parameter)
        {
            string result = RequestPostingExe.QualificationSTR(parameter);
            return result;
            // TODO: add assertions to method RequestPostingExeTest.QualificationSTRTest(Object)
        }

        /// <summary>Test stub for Qualification(Object)</summary>
        [PexMethod]
        public string QualificationTest(object parameter)
        {
            string result = RequestPostingExe.Qualification(parameter);
            return result;
            // TODO: add assertions to method RequestPostingExeTest.QualificationTest(Object)
        }

        /// <summary>Test stub for RequestAttribute(Object)</summary>
        [PexMethod]
        public string RequestAttributeTest(object parameter)
        {
            string result = RequestPostingExe.RequestAttribute(parameter);
            return result;
            // TODO: add assertions to method RequestPostingExeTest.RequestAttributeTest(Object)
        }

        /// <summary>Test stub for RequestSchool(Object)</summary>
        [PexMethod]
        public string RequestSchoolTest(object parameter)
        {
            string result = RequestPostingExe.RequestSchool(parameter);
            return result;
            // TODO: add assertions to method RequestPostingExeTest.RequestSchoolTest(Object)
        }

        /// <summary>Test stub for SPName(String)</summary>
        [PexMethod]
        public string SPNameTest(string action)
        {
            string result = RequestPostingExe.SPName(action);
            return result;
            // TODO: add assertions to method RequestPostingExeTest.SPNameTest(String)
        }

        /// <summary>Test stub for TeacherName(Object)</summary>
        [PexMethod]
        public string TeacherNameTest(object parameter)
        {
            string result = RequestPostingExe.TeacherName(parameter);
            return result;
            // TODO: add assertions to method RequestPostingExeTest.TeacherNameTest(Object)
        }

        /// <summary>Test stub for TeachersList(Object)</summary>
        [PexMethod]
        public List<TeachersListByCategory> TeachersListTest(object parameter)
        {
            List<TeachersListByCategory> result = RequestPostingExe.TeachersList(parameter);
            return result;
            // TODO: add assertions to method RequestPostingExeTest.TeachersListTest(Object)
        }

        /// <summary>Test stub for Update(Object)</summary>
        [PexMethod]
        public string UpdateTest(object parameter)
        {
            string result = RequestPostingExe.Update(parameter);
            return result;
            // TODO: add assertions to method RequestPostingExeTest.UpdateTest(Object)
        }
    }
}
