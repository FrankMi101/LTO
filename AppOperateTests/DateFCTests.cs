using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppOperate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOperate.Tests
{
    [TestClass()]
    public class DateFCTests
    {

        [TestMethod()]
        public void Date_Format_EnterDate_Return_YYYYMMDD_Test()
        {   //Arrange
            string iDate = "12/08/2018";
            DateTime tDate = Convert.ToDateTime(iDate);
            var expect = "2018/12/08";

            // Act                                        
            var result = DateFC.Format(tDate, "YYYYMMDD");

            //Assert
            Assert.AreEqual(expect, result, $"Format the date in 2018/12/08, {result}  ");
        }
        [TestMethod()]
        public void Date_Format_EnterDate_Return_DDMMYYYY_Test()
        {   //Arrange
            string iDate = "12/08/2018";
            DateTime tDate = Convert.ToDateTime(iDate);
            var expect = "08/12/2018";

            // Act                                        
            var result = DateFC.Format(tDate, "DDMMYYYY");

            //Assert
            Assert.AreEqual(expect, result, $"Format the date in 08/12/2018, {result} ");
        }
        [TestMethod()]
        public void Date_Format_EnterDate_Return_MMDDYYYY_Test()
        {   //Arrange
            string iDate = "12/08/2018";
            DateTime tDate = Convert.ToDateTime(iDate);
            var expect = "12/08/2018";
            // Act                                        
            var result = DateFC.Format(tDate, "MMDDYYYY");

            //Assert
            Assert.AreEqual(expect, result, $"Format the date in 12/08/2018, {result}");
        }
        [TestMethod()]
        public void Date_Format_EnterDate_Return_MMMDDYYYY_Test()
        {   //Arrange
            string iDate = "12/08/2018";
            DateTime tDate = Convert.ToDateTime(iDate);
            var expect = "Dec/08/2018";

            // Act                                        
            var result = DateFC.Format(tDate, "MMMDDYYYY");

            //Assert
            Assert.AreEqual(expect, result, $"Format the date in 08/12/2018, {result}");
        }
  
        [TestMethod()]
        public void Date_Format_YMD_Test()
        {
            //Arrange
            string iDate = "12/08/2018";
            DateTime tDate = Convert.ToDateTime(iDate);
            var expect = "2018/12/08";

            // Act                                        
            var result = DateFC.YMD(tDate);

            //Assert
            Assert.AreEqual(expect, result, $"Format the date YMD method 2018/12/08, {result}");
        }
        [TestMethod()]
        public void Date_Format_YMD_withLinkSignTie_Test()
        {
            //Arrange
            string iDate = "12/08/2018";
            DateTime tDate = Convert.ToDateTime(iDate);
            var expect = "2018-12-08";

            // Act                                        
            var result = DateFC.YMD(tDate,"-");

            //Assert
            Assert.AreEqual(expect, result, $"Format the date YMD method 2018/12/08, {result}");
        }
        [TestMethod()]
        public void Date_Format_YMD_withLinkSignSlish_Test()
        {
            //Arrange
            string iDate = "12/08/2018";
            DateTime tDate = Convert.ToDateTime(iDate);
            var expect = "2018/12/08";

            // Act                                        
            var result = DateFC.YMD(tDate,"/");

            //Assert
            Assert.AreEqual(expect, result, $"Format the date YMD method 2018/12/08, {result}");
        }
  
        [TestMethod()]
        public void Age_GetAgebyCurrentDate_Test()
        {
            //Arrange
            string iDate = "12/08/2010";
            DateTime tDate = Convert.ToDateTime(iDate);
            string expect = "11";

            // Act                                        
            var result = DateFC.Age(tDate).ToString();

            //Assert
            Assert.AreEqual(expect, result, $"Get Age by current date 8, {result}");
        }

        [TestMethod()]
        public void Age_GetAgebyGivenDate_Test()
        {
            //Arrange
            string iDate = "12/08/2005";
            DateTime tDate = Convert.ToDateTime(iDate);
            string compaireDate = "2020/12/08";
            DateTime tCompaireDate = Convert.ToDateTime(compaireDate);
           string expect = "15";

            // Act                                        
            var result = DateFC.Age(tDate, tCompaireDate).ToString();

            //Assert
            Assert.AreEqual(expect, result, $"get Age by given date 15, {result}");
        }

        [TestMethod()]
        public void SchoolYearFromTest()
        {
            //Arrange
            string cschoolyear = "20172018";
                   
            string expect = "2017-2018";

            // Act                                        
            var result = DateFC.SchoolYearFrom("-", cschoolyear);

            //Assert
            Assert.AreEqual(expect, result, $"school year format, {result}");
        }

        [TestMethod()]
        public void SchoolYearNextTest()
        {
            //Arrange
            string cschoolyear = "20172018";

            string expect = "2018-2019";

            // Act                                        
            var result = DateFC.SchoolYearNext("-", cschoolyear);

            //Assert
            Assert.AreEqual(expect, result, $"Next school year format, {result}");
        }

        [TestMethod()]
        public void SchoolYearPreviousTest()
        {
            //Arrange
            string cschoolyear = "20172018";

            string expect = "2016-2017";

            // Act                                        
            var result = DateFC.SchoolYearPrevious("-", cschoolyear);

            //Assert
            Assert.AreEqual(expect, result, $"school year previous school year format, {result}");
        }

        [TestMethod()]
        public void YearTOGOTest_Next()
        {
            //Arrange
            string cschoolyear = "20182019";

            string expect = "20192020";

            // Act                                        
            var result = DateFC.YearTOGO("Next", 10, cschoolyear);

            //Assert
            Assert.AreEqual(expect, result, $"school year Go Next, {result}");
        }

        [TestMethod()]
        public void YearTOGOTest_Previous()
        {
            //Arrange
            string cschoolyear = "20182019";

            string expect = "20172018";

            // Act                                        
            var result = DateFC.YearTOGO("Pre", 10, cschoolyear);

            //Assert
            Assert.AreEqual(expect, result, $"school year Go Previous, {result}");
        }
    }
}