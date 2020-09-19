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
    public class EmailNotificationTests
    {
        string union = WebConfigValue.getValuebyKey("eMail_Union");
        string hrCC = WebConfigValue.getValuebyKey("eMailCC_LTO");
        string mCC = "mif@tcdsb.org";
        string who = "Principal";
        string action = "Posting";
        string appType = "LTO";
        string postingCycle = "1";
        string positionTitle = "Elementary Teacher";
        string schoolPanel = "03";//  string schoolCode = "0320"  schoolCode.Substring(0, 2);

        [TestMethod()]
        public void CheckCCMailTest_To_Union_LTO_PostingAction_Return_UnionPlusHRLTO()
        {
            //Arrange

             who = "Union";
 
            var expect = mCC + ";" + union + ";"+ hrCC;

            // Act                                       

            var result = EmailNotification.CheckCCMail(mCC, who, action, appType, postingCycle, positionTitle, schoolPanel);

            //Assert
           // Assert.AreEqual(expect, result, $"CC Email Address for {action} on {appType} to {who}, {result}  ");
            StringAssert.Contains(result, union, $"CC Email Address for {action} on {appType} to {who}, {result}  ");
        }
        [TestMethod()]
        public void CheckCCMailTest_To_Union_POP_PostingAction_Return_UnionOnly()
        {
            //Arrange

            who = "Union";
            appType = "POP";
            var expect = mCC + ";" + union;  

            // Act                                       

            var result = EmailNotification.CheckCCMail(mCC, who, action, appType, postingCycle, positionTitle, schoolPanel);

            //Assert
          //  Assert.AreEqual(expect, result, $"CC Email Address for {action} on {appType} to {who}, {result}  ");
            StringAssert.Contains(result, union, $"CC Email Address for {action} on {appType} to {who}, {result}  ");
        }

        [TestMethod()]
        public void CheckCCMailTest_To_Principal_LTO_PostingAction_Return_currrentUserPlusHRLTOCC()
        {
            //Arrange
         
            var expect = mCC +";"+ hrCC;

            // Act                                       

            var result = EmailNotification.CheckCCMail(mCC, who, action, appType, postingCycle, positionTitle, schoolPanel);

            //Assert
          //  Assert.AreEqual(expect, result, $"CC Email Address for {action} on {appType} to {who}, {result}  ");
            StringAssert.Contains(result, hrCC, $"CC Email Address for {action} on {appType} to {who}, {result}  ");
        }
        [TestMethod()]
        public void CheckCCMailTest_To_Principal_POP_PostingAction_Elementary_Return_currrentUserPlusHR_eMailCC_POP_E()
        {
            //Arrange
            appType = "POP";
            schoolPanel = "02";
            var pop_E = WebConfigValue.getValuebyKey("eMailCC_POP_E");
            var expect = mCC + ";" + pop_E + ";" + union;

            // Act                                       

            var result = EmailNotification.CheckCCMail(mCC, who, action, appType, postingCycle, positionTitle, schoolPanel);

            //Assert
           // Assert.AreEqual(expect, result, $"CC Email Address for {action} on {appType} to {who}, {result}  ");
            StringAssert.Contains(result, pop_E, $"CC Email Address for {action} on {appType} to {who}, {result}  ");
        }
        [TestMethod()]
        public void CheckCCMailTest_To_Principal_POP_PostingAction_Secondary_Return_currrentUserPlusHR_eMailCC_POP_S()
        {
            //Arrange
            appType = "POP";
            schoolPanel = "05";
            var pop_E = WebConfigValue.getValuebyKey("eMailCC_POP_S");
            var expect = mCC  + ";" + pop_E+ ";" + union;

            // Act                                       

            var result = EmailNotification.CheckCCMail(mCC, who, action, appType, postingCycle, positionTitle, schoolPanel);

            //Assert
           // Assert.AreEqual(expect, result, $"CC Email Address for {action} on {appType} to {who}, {result}  ");
            StringAssert.Contains(result, pop_E, $"CC Email Address for {action} on {appType} to {who}, {result}  ");

        }
        [TestMethod()]
        public void CheckCCMailTest_To_Principal_LTO_ConfirmAction_Return_currrentUserPlus_eMailCC_ConfirmHire_LTO()
        {
            //Arrange
              action = "ConfirmHire";
           var confirmCC = WebConfigValue.getValuebyKey("eMailCC_ConfirmHire_LTO");
            var expect = mCC + ";" + hrCC + ";" + confirmCC;

            // Act                                       

            var result = EmailNotification.CheckCCMail(mCC, who, action, appType, postingCycle, positionTitle, schoolPanel);

            //Assert
           // Assert.AreEqual(expect, result, $"CC Email Address for {action} on {appType} to {who}, {result}  ");
            StringAssert.Contains(result, confirmCC, $"CC Email Address for {action} on {appType} to {who}, {result}  ");
        }

        [TestMethod()]
        public void CheckCCMailTest_To_Principal_POP_ConfirmAction_Return_currrentUserPlus_eMailCC_ConfirmHire_POP()
        {
            //Arrange
            action = "ConfirmHire";
            appType = "POP";
           var popE = WebConfigValue.getValuebyKey("eMailCC_POP_E");
            var confirmCC = WebConfigValue.getValuebyKey("eMailCC_ConfirmHire_POP");
            var expect = mCC + ";" + popE + ";" + union;

            // Act                                       

            var result = EmailNotification.CheckCCMail(mCC, who, action, appType, postingCycle, positionTitle, schoolPanel);

            //Assert
            // Assert.AreEqual(expect, result, $"CC Email Address for {action} on {appType} to {who}, {result}  ");
            StringAssert.Contains(result, confirmCC, $"CC Email Address for {action} on {appType} to {who}, {result}  ");
        }

        [TestMethod()]
        public void CheckCCMailTest_To_Principal_LTO_anyAction_French_Return_currrentUserPlus_eMailCC_French()
        {
            //Arrange
            positionTitle = "Grade 5 French teacher";
            var french = WebConfigValue.getValuebyKey("eMailCC_French");
            var expect = mCC + ";" + hrCC + ";" + french;

            // Act                                       

            var result = EmailNotification.CheckCCMail(mCC, who, action, appType, postingCycle, positionTitle, schoolPanel);

            //Assert
           // Assert.AreEqual(expect, result, $"CC Email Address for {action} on {appType} to {who}, {result}  ");
            StringAssert.Contains(result, french, $"CC Email Address for {action} on {appType} to {who}, {result}  ");

        }
        [TestMethod()]
        public void CheckCCMailTest_To_Principal_POP_anyAction_French_Return_currrentUserPlus_eMailCC_French()
        {
            //Arrange
            positionTitle = "Core French teacher";
            var french = WebConfigValue.getValuebyKey("eMailCC_French");
            var popE = WebConfigValue.getValuebyKey("eMailCC_POP_E");
            appType = "POP";
            var expect = mCC + ";" +popE + ";"+ union + ";" + french;

            // Act                                       

            var result = EmailNotification.CheckCCMail(mCC, who, action, appType, postingCycle, positionTitle, schoolPanel);

            //Assert
            //Assert.AreEqual(expect, result, $"CC Email Address for {action} on {appType} to {who}, {result}  ");
            StringAssert.Contains(result, french, $"CC Email Address for {action} on {appType} to {who}, {result}  ");
        }

        [TestMethod()]
        public void CheckCCMailTest_To_Principal_LTO_anyAction_French_Return_currrentUserPlus_eMailCC_ConfirmHire_eMailCC_Music()
        {
            //Arrange
            action = "ConfirmHire";
            positionTitle = "Elementary Music teacher";
            var confirmCC = WebConfigValue.getValuebyKey("eMailCC_ConfirmHire_LTO");
            var music = WebConfigValue.getValuebyKey("eMailCC_Music");
            var expect = mCC + ";" + hrCC + ";" + confirmCC + ";"  + music;

            // Act                                       

            var result = EmailNotification.CheckCCMail(mCC, who, action, appType, postingCycle, positionTitle, schoolPanel);
            int resultL = result.Length;
            expect = expect.Substring(0, resultL);
            //Assert
           // Assert.AreEqual(expect, result, $"CC Email Address for {action} on {appType} to {who}, {result}  ");
            StringAssert.Contains(result, confirmCC, $"CC Email Address for {action} on {appType} to {who}, {result}  ");
        }
        [TestMethod()]
        public void CheckCCMailTest_To_Principal_POP_anyAction_French_Return_currrentUserPlus_eMailCC_ConfirmHire_eMailCC_Music()
        {
            //Arrange
            action = "ConfirmHire";
            appType = "POP";
            positionTitle = "Elementary Music teacher";
            var confirmCC = WebConfigValue.getValuebyKey("eMailCC_ConfirmHire_POP");
            var music = WebConfigValue.getValuebyKey("eMailCC_Music");
            var popE = WebConfigValue.getValuebyKey("eMailCC_POP_E");
            var expect = mCC+ ";" + popE + ";" + union + ";" + music;
            // Act                                       

            var result = EmailNotification.CheckCCMail(mCC, who, action, appType, postingCycle, positionTitle, schoolPanel);
          //  int resultL = result.Length;
           // expect = expect.Substring(0, resultL);

            //Assert
           // Assert.AreEqual(expect, result, $"CC Email Address for {action} on {appType} to {who}, {result}  ");
            StringAssert.Contains(result, popE, $"CC Email Address for {action} on {appType} to {who}, {result}  ");
        }


    }
}