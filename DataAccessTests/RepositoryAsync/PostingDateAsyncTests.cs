using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using AppOperate;

namespace DataAccess.Repository.Tests
{
    [TestClass()]
    public class PostingDateAsyncTests
    {
        private readonly string SchoolYear = "20212022";
        private readonly string SchoolCode = "0204";
        private readonly string PositionType = "LTO";
        private readonly string UserID = "Tester";
        private int _ids = 0;

         private readonly   IAppServicesAsync _action = new AppServiceAsync( new PostingDateAsync(DBConnection.DBSource));

        // private readonly IAppServices _action = new AppServices(new PostingDate("Fake"));

        [TestInitialize]
        public void Setup()
        {
            // Runs before each test. (Optional)
        }

        [TestMethod()]
        public async Task DefaultDateTest_ReturdCurrentSchoolYearPostingDefaultDate()
        {
            // ********* This test will Fail if test happend public hoilday **********

            //Arrange 
            string action = "DefaultDate";
            var parameter = new
            {
                Operate = action,
                PositionType,
                SchoolYear
            };

            // Act
             var myDate = await  _action.AppOne.CommonList<LTODefalutDate>(action,parameter);
            var startDate = myDate[0].StartDate;
            var endDate = myDate[0].EndDate;
            var publishDate = myDate[0].DatePublish;
            var openDate = myDate[0].DateApplyOpen;
            var closeDate = myDate[0].DateApplyClose;

            string expect = DateFC.YMD(DateTime.Now, "/", "Y");
            string result = DateFC.YMD(publishDate, "/", "Y");

            //Assert
            Assert.AreEqual(expect, result, $"default publish Date Value  { result}");
        }

        [TestMethod()]
        public async Task DefaultDateTest_ReturdCurrentSchoolYearPostingDefaultDateObject()
        {
            // ********* This test will Fail if test happend public hoilday **********

            //Arrange 
            string action = "DefaultDate";
            var parameter = new
            {
                Operate = action,
                PositionType,
                SchoolYear
            };

            // Act
            var myDate = await _action.AppOne.CommonObject<LTODefalutDate>(action, parameter);


            var startDate = myDate.StartDate;
            var endDate = myDate.EndDate;
            var publishDate = myDate.DatePublish;
            var openDate = myDate.DateApplyOpen;
            var closeDate = myDate.DateApplyClose;

            string expect = DateFC.YMD(DateTime.Now, "/", "Y");
            string result = DateFC.YMD(publishDate, "/", "Y");

            //Assert
            Assert.AreEqual(expect, result, $"default publish Date Value  { result}");

        }

        [TestMethod()]
        public async Task DeadlineTest_GivingValidDate_ReturnValid_DeadlineDate()
        {
            //Arrange
            var action = "Deadline";
            var anonyParametere = new
            {
                Operate = action,
                PositionType,
                SchoolYear,
                PublishDate = "2021/03/24",
            };

            //Act
            string result = await _action.AppOne.CommonAction(action, anonyParametere);
            string expect = "2021/03/26";

            //Assert
            Assert.AreEqual(expect, result, $" The deasline date is { result } for publish date {anonyParametere.PublishDate } ");

        }

        [TestMethod()]
        public async Task DeadlineTest_GivingInvalidDate_ReturnInvalidDateString()
        {
            //Arrange
            var action = "Deadline";
            var anonyParametere = new
            {
                Operate = action,
                PositionType,
                SchoolYear,
                PublishDate = "2021/03/24",
            };

            //Act
            string result = await _action.AppOne.CommonAction(action, anonyParametere);
            string expect = "2021/03/26";

            //Assert
            Assert.AreEqual(expect, result, $" The deasline date is { result } for publish date {anonyParametere.PublishDate } ");

        }

        [TestMethod()]
        public async Task PostingTest_byGiveing_ValidDate_return_ValidDate()
        {
            //Arrange
            var action = "PostingDate";
            var anonyParametere = new
            {
                Operate = action,
                PositionType,
                SchoolYear ,
                PublishDate = "2022/03/24",
            };

            //Act
            string result = await _action.AppOne.CommonAction(action, anonyParametere);
            string expect = "2022/03/28";

            //Assert
            Assert.AreEqual(expect, result, $" The deasline date is { result } for publish date {anonyParametere.PublishDate } ");

        }

        [TestMethod()]
        public async Task PostingTest_byGiveing_InvalidDate_return_IncalidDateString()
        {
            //Arrange
            var action = "PostingDate";
            var anonyParametere = new
            {
                Operate = action,
                PositionType ,
                SchoolYear,
                PublishDate = "2022/03/26",
            };

            //Act
            string result = await _action.AppOne.CommonAction(action, anonyParametere);
            string expect = "Invalid Date";

            //Assert
            Assert.AreEqual(expect, result, $" The deasline date is { result } for publish date {anonyParametere.PublishDate } ");

        }

    }
}
