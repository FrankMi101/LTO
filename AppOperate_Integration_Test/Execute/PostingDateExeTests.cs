using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace AppOperate.Tests
{
    [TestClass()]
    public class PostingDateExeTests
    {
        private static string schoolyear = "20212022";
        private string cPage = "Request";
        
       

        [TestMethod()]
        public void DefaultDateTest_ReturdCurrentSchoolYearPostingDefaultDate()
        {
            // ********* This test will Fail if test happend public hoilday **********

            //Arrange 
            string action = "DefaultDate";
            var parameter = new
            {
                Operate = action,
                PositionType = "LTO",
                SchoolYear = schoolyear
            };

            // Act
            List<LTODefalutDate> myDate = PostingDateExe.DefaultDate(parameter);
 

            var startDate = myDate[0].StartDate;
            var endDate = myDate[0].EndDate;
            var publishDate = myDate[0].DatePublish;
            var openDate = myDate[0].DateApplyOpen;
            var closeDate = myDate[0].DateApplyClose;

            string expect =  DateFC.YMD(DateTime.Now,"/","Y");
            string result = DateFC.YMD(publishDate,"/","Y");

            //Assert
            Assert.AreEqual(expect, result, $"default publish Date Value  { result}");


        }
 

        [TestMethod()]
        public void DeadlineTest_GivingValidDate_ReturnValid_DeadlineDate()
        {
            //Arrange
            var action = "Deadline";
            var anonyParametere = new
            {
                Operate = action,
                PositionType = "LTO",
                SchoolYear = schoolyear,
                PublishDate = "2021/03/24",
            };

            //Act
            string result = PostingDateExe.Deadline(anonyParametere);
            string expect = "2021/03/26";

            //Assert
            Assert.AreEqual(expect, result, $" The deasline date is { result } for publish date {anonyParametere.PublishDate } ");

        }

        [TestMethod()]
        public void DeadlineTest_GivingInvalidDate_ReturnInvalidDateString()
        {
            //Arrange
            var action = "Deadline";
            var anonyParametere = new
            {
                Operate = action,
                PositionType = "LTO",
                SchoolYear = schoolyear,
                PublishDate = "2021/03/24",
            };

            //Act
            string result = PostingDateExe.Deadline(anonyParametere);
            string expect = "2021/03/26";

            //Assert
            Assert.AreEqual(expect, result, $" The deasline date is { result } for publish date {anonyParametere.PublishDate } ");

        }

        [TestMethod()]
        public void PostingTest_byGiveing_ValidDate_return_ValidDate()
        {
            //Arrange
            var action = "PostingDate";
            var anonyParametere = new
            {
                Operate = action,
                PositionType = "LTO",
                SchoolYear = schoolyear,
                PublishDate = "2022/03/24",
            };

            //Act
            string result = PostingDateExe.PostingDate(anonyParametere);
            string expect = "2022/03/28";

            //Assert
            Assert.AreEqual(expect, result, $" The deasline date is { result } for publish date {anonyParametere.PublishDate } ");

        }

        [TestMethod()]
        public void PostingTest_byGiveing_InvalidDate_return_IncalidDateString()
        {
            //Arrange
            var action = "PostingDate";
            var anonyParametere = new
            {
                Operate = action,
                PositionType = "LTO",
                SchoolYear = schoolyear,
                PublishDate = "2022/03/26",
            };

            //Act
            string result = PostingDateExe.PostingDate(anonyParametere);
            string expect = "Invalid Date";

            //Assert
            Assert.AreEqual(expect, result, $" The deasline date is { result } for publish date {anonyParametere.PublishDate } ");

        }

    }
}