using System;
using AppOperate;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppOperate.Tests
{
    /// <summary>This class contains parameterized unit tests for DateFC</summary>
    [TestClass]
    [PexClass(typeof(DateFC))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class DateFCTest
    {

        /// <summary>Test stub for Age(DateTime)</summary>
        [PexMethod(MaxConstraintSolverTime = 2)]
        public int AgeTest(DateTime BirthDate)
        {
            int result = DateFC.Age(BirthDate);
            return result;
            // TODO: add assertions to method DateFCTest.AgeTest(DateTime)
        }

        /// <summary>Test stub for Age(DateTime, DateTime)</summary>
        [PexMethod(MaxConstraintSolverTime = 2)]
        public int AgeTest01(DateTime birthdate, DateTime comparedate)
        {
            int result = DateFC.Age(birthdate, comparedate);
            return result;
            // TODO: add assertions to method DateFCTest.AgeTest01(DateTime, DateTime)
        }

        /// <summary>Test stub for CurrentYearString()</summary>
        [PexMethod]
        public string CurrentYearStringTest()
        {
            string result = DateFC.CurrentYearString();
            return result;
            // TODO: add assertions to method DateFCTest.CurrentYearStringTest()
        }

        /// <summary>Test stub for Format(DateTime, String)</summary>
        [PexMethod]
        public string FormatTest(DateTime pDate, string pFormat)
        {
            string result = DateFC.Format(pDate, pFormat);
            return result;
            // TODO: add assertions to method DateFCTest.FormatTest(DateTime, String)
        }

        /// <summary>Test stub for SchoolYearFrom(String, String)</summary>
        [PexMethod]
        public string SchoolYearFromTest(string strType, string cSchoolYear)
        {
            string result = DateFC.SchoolYearFrom(strType, cSchoolYear);
            return result;
            // TODO: add assertions to method DateFCTest.SchoolYearFromTest(String, String)
        }

        /// <summary>Test stub for SchoolYearNext(String, String)</summary>
        [PexMethod]
        public string SchoolYearNextTest(string strType, string cSchoolYear)
        {
            string result = DateFC.SchoolYearNext(strType, cSchoolYear);
            return result;
            // TODO: add assertions to method DateFCTest.SchoolYearNextTest(String, String)
        }

        /// <summary>Test stub for SchoolYearPrevious(String, String)</summary>
        [PexMethod]
        public string SchoolYearPreviousTest(string strType, string cSchoolYear)
        {
            string result = DateFC.SchoolYearPrevious(strType, cSchoolYear);
            return result;
            // TODO: add assertions to method DateFCTest.SchoolYearPreviousTest(String, String)
        }

        /// <summary>Test stub for YMD(DateTime)</summary>
        [PexMethod]
        public string YMDTest(DateTime vDate)
        {
            string result = DateFC.YMD(vDate);
            return result;
            // TODO: add assertions to method DateFCTest.YMDTest(DateTime)
        }

        /// <summary>Test stub for YMD(String)</summary>
        [PexMethod]
        public DateTime YMDTest01(string eDate)
        {
            DateTime result = DateFC.YMD(eDate);
            return result;
            // TODO: add assertions to method DateFCTest.YMDTest01(String)
        }

        /// <summary>Test stub for YMD(DateTime, String)</summary>
        [PexMethod]
        public string YMDTest02(DateTime vDate, string sign)
        {
            string result = DateFC.YMD(vDate, sign);
            return result;
            // TODO: add assertions to method DateFCTest.YMDTest02(DateTime, String)
        }

        /// <summary>Test stub for YMD2(String)</summary>
        [PexMethod]
        public string YMD2Test(string eDate)
        {
            string result = DateFC.YMD2(eDate);
            return result;
            // TODO: add assertions to method DateFCTest.YMD2Test(String)
        }

        /// <summary>Test stub for YMDStr(String)</summary>
        [PexMethod]
        public string YMDStrTest(string vDate)
        {
            string result = DateFC.YMDStr(vDate);
            return result;
            // TODO: add assertions to method DateFCTest.YMDStrTest(String)
        }

        /// <summary>Test stub for YearTOGO(String, String)</summary>
        [PexMethod]
        public string YearTOGOTest(string strType, string cSchoolYear)
        {
            string result = DateFC.YearTOGO(strType, cSchoolYear);
            return result;
            // TODO: add assertions to method DateFCTest.YearTOGOTest(String, String)
        }
    }
}
