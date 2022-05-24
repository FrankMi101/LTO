using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace AppOperate.Tests
{
    [TestClass()]
    public class PostingDateExeTests_Deadline
    {
        private static string schoolyear = "20212022";
        private string cPage = "Request";
        
       

     

        [TestMethod()]
        [DataRow("2022/05/01", "Invalid Date")]
        [DataRow("2022/05/07", "Invalid Date")]
        [DataRow("2022/05/08", "Invalid Date")]
        public void DeadlineTest_GivingInValidDate_Return_InvalidDateString(string publishDate, string deadline)
        {
            //Arrange
            var action = "Deadline";
            var anonyParametere = new
            {
                Operate = action,
                PositionType = "LTO",
                SchoolYear = schoolyear,
                PublishDate = publishDate,
            };

            //Act
            string result = PostingDateExe.Deadline(anonyParametere);

            string expect = deadline;

            //Assert
            Assert.AreEqual(expect, result, $" The deasline date is { result } for publish date {anonyParametere.PublishDate } ");

        }

        [TestMethod()]
        [DataRow("2022/05/02", "2022/05/04")]
        [DataRow("2022/05/03", "2022/05/05")]
        [DataRow("2022/05/04", "2022/05/06")]
        [DataRow("2022/05/05", "2022/05/09")]
        [DataRow("2022/05/06", "2022/05/10")]
         public void DeadlineTest_GivingWeekDatDate_ReturnValid_DeadlineDate(string publishDate, string deadline)
        {
            //Arrange
            var action = "Deadline";
            var anonyParametere = new
            {
                Operate = action,
                PositionType = "LTO",
                SchoolYear = schoolyear,
                PublishDate = publishDate,
            };

            //Act
            string result = PostingDateExe.Deadline(anonyParametere);

            string expect = deadline;

            //Assert
            Assert.AreEqual(expect, result, $" The deasline date is { result } for publish date {anonyParametere.PublishDate } ");

        }
        [TestMethod()]
        [DataRow("2022/03/14", "2022/03/16")]
        [DataRow("2022/03/15", "2022/03/17")]
        [DataRow("2022/03/16", "2022/03/18")]
        [DataRow("2022/03/17", "2022/03/21")]
        [DataRow("2022/03/18", "2022/03/22")]
        public void DeadlineTest_GivingMarchBreakDate_ReturnValid_DeadlineDate(string publishDate, string deadline)
        {
            //Arrange
            var action = "Deadline";
            var anonyParametere = new
            {
                Operate = action,
                PositionType = "LTO",
                SchoolYear = schoolyear,
                PublishDate = publishDate,
            };

            //Act
            string result = PostingDateExe.Deadline(anonyParametere);

            string expect = deadline;

            //Assert
            Assert.AreEqual(expect, result, $" The deasline date is { result } for publish date {anonyParametere.PublishDate } ");

        }
        [TestMethod()]
        [DataRow("2022/12/26", "2022/12/28")]
        [DataRow("2022/12/27", "2022/12/29")]
        [DataRow("2022/12/28", "2022/12/30")]
        [DataRow("2022/12/29", "2023/01/02")]
        [DataRow("2022/12/30", "2023/01/03")]
        public void DeadlineTest_GivingChristmasBreakDate_ReturnValid_DeadlineDate(string publishDate, string deadline)
        {
            //Arrange
            var action = "Deadline";
            var anonyParametere = new
            {
                Operate = action,
                PositionType = "LTO",
                SchoolYear = schoolyear,
                PublishDate = publishDate,
            };

            //Act
            string result = PostingDateExe.Deadline(anonyParametere);

            string expect = deadline;

            //Assert
            Assert.AreEqual(expect, result, $" The deasline date is { result } for publish date {anonyParametere.PublishDate } ");

        }
        

    }
}