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
    public class DataToolsTests
    {
       

        [TestMethod()]
        public void SchoolPanel_ElemantaryScholCode_returnS_Test()
        {
            //Arrange
            string schoolcode = "0205";
            string expect = "E";

            //Act
            var result = DataTools.SchoolPanel(schoolcode);

            //Assert
            Assert.AreEqual(expect, result, $"School Coe is {schoolcode}, Panel: {result}");
        }

        [TestMethod()]
        public void SchoolPanel_XIEPScholCode_returnE_Test()
        {
            //Arrange
            string schoolcode = "XIEP";
            string expect = "E";

            //Act
            var result = DataTools.SchoolPanel(schoolcode);

            //Assert
            Assert.AreEqual(expect, result, $"School Coe is {schoolcode}, Panel: {result}");
        }

        [TestMethod()]
        public void SchoolPanel_AS23ScholCode_returnE_Test()
        {
            //Arrange
            string schoolcode = "AS23";
            string expect = "E";

            //Act
            var result = DataTools.SchoolPanel(schoolcode);

            //Assert
            Assert.AreEqual(expect, result, $"School Coe is {schoolcode}, Panel: {result}");
        }

        [TestMethod()]
        public void SchoolPanel_SecondaryScholCode_returnS_Test()
        {
            //Arrange
            string schoolcode = "0529";
            string expect = "S";

            //Act
            var result = DataTools.SchoolPanel(schoolcode);

            //Assert
            Assert.AreEqual(expect, result, $"School Coe is {schoolcode}, Panel: {result}");
        }

        [TestMethod()]
        public void SchoolPanel_DepartmentCode_returnD_Test()
        {
            //Arrange
            string schoolcode = "0830";
            string expect = "D";

            //Act
            var result = DataTools.SchoolPanel(schoolcode);

            //Assert
            Assert.AreEqual(expect, result, $"School Coe is {schoolcode}, Panel: {result}");
        }

        [TestMethod()]
        public void CheckEmail_InputWithoutAtSignl_ReturnTCDSBEmail_Test()
        {
            //Arrange
            string email = "perter.like";
            string expect = "perter.like@tcdsb.org";

            //Act
            var result = DataTools.CheckEmail(email);

            //Assert
            Assert.AreEqual(expect, result, $"Email input {email}, output: {result}");
        }

        [TestMethod()]
        public void CheckEmail_InputIncudeoutSideemail_ReturnInputEmail_Test()
        {
            //Arrange
            string email = "Perter.like@google.com";
            string expect = "Perter.like@google.com";

            //Act
            var result = DataTools.CheckEmail(email);

            //Assert
            Assert.AreEqual(expect, result, $"Email input {email}, output: {result}");
        }

        [TestMethod()]
        public void CheckEmail_InputTCDSBmail_ReturnTcdsbEmail_Test()
        {
            //Arrange
            string email = "perter.Like@tcdsb.org";
            string expect = "perter.Like@tcdsb.org";

            //Act
            var result = DataTools.CheckEmail(email);

            //Assert
            Assert.AreEqual(expect, result, $"Email input {email}, output: {result}");
        }

        [TestMethod()]
        public void CheckEmail_InputUpcaseTCDSBemail_ReturntcdsbEmail_Test()
        {
            //Arrange
            string email = "Perter.like@Tcdsb.ORG";
            string expect = "Perter.like@Tcdsb.ORG";

            //Act
            var result = DataTools.CheckEmail(email);

            //Assert
            Assert.AreEqual(expect, result, $"Email input {email}, output: {result}");
        }
    }
}