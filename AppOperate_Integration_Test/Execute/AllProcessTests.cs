using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AppOperate.Tests
{
    [TestClass()]
    public class AllProcessTests
    {
        readonly string  _schoolYear = "20212022";
        readonly string  _schoolCode = "0549";
        readonly string _dateStart ="2021-09-01";
        readonly string _dateEnd = "2022-06-30";
        readonly string _publishDate = DateFC.YMD(DateTime.Now , "-");
        readonly string _applyDate= DateFC.YMD(DateTime.Now, "-");
        int _requestId = 0;
        int _positionId = 0;
        string _principalId = "";
        string _hiredCpNum = "0000";
        string _cpNum = "00000000";
        PositionRequesting _request = new PositionRequesting();
        PositionApplying _applyFor = new PositionApplying();

        [TestMethod()]
        public void LTO_Hire_Full_Process_Test()
        {
            string expect = "Successfully";
            string result = "Successfully";
            if (result == expect)
            {
                // 1. Request a New Posting position 
                result = Step1_CreateNewReques();
            }
            if (result == expect)
            {
                // 2. Get this new Request 
                result = Step2_GetRequestPosition();

            }
            if (result == expect)
            {
                // 3. update Request Posting Content
                result = Step3_UpdateRequestPosiiton();

            }

            if (result == expect)
            {
                // 4. Posting Request and get publish Position ID 
                result = Step4_PostingRequestandGetPositionID();
            }
            if (result == expect)
            {
                // 5. retrieve a posted position for apply
                result = Step5_GetanApplyPositionbyID();
            }
            if (result == expect)
            {
                // 6. Applicant apply for the posted positiont 
                result = Step6_ApplyOpenPosition_byApplicant_CPNum();
            }

            if (result == expect)
            {
                // 7. Select five interview candidate
                result = Step7_SelectInterviewCandidats();
            }
            if (result == expect)
            {
                // 8. Notice School Principal for candidate list 
                result = Step8_NoticeCandidateToSchoolPrincipal();
            }

            if (result == expect)
            {
                // 9. interview all candiates
                result = Step9_InterviewCandidats_Result();
            }

            if (result == expect)
            {
                // 10. Recommend for a candidate for hire
                result = Step10_RecommendForHire();
            }

            if (result == expect)
            {
                // 11. Confirm hire
                result = Step11_ConfirmHire();
            }
            if (result == expect)
            {
                // 12. Revoke Confirm hire
                result = Step12_ConfirmHireRevoke();
            }
            if (result == expect)
            {
                // 99. Revoke Confirm hire
              //  result = Step99_ClearupTestingProcess();
            }

        }
        private string Step1_CreateNewReques()
        {
            // 1. Request a New Posting position 
            //Arrange 
            NewPosition request = new NewPosition()
            {
                Operate = "New",
                SchoolYear = _schoolYear,
                PositionID = "0",
                PositionType = "LTO",
                SchoolCode = _schoolCode,
                UserID = "mif"
            };
            //Act 
            string newid = RequestPostingExe.Add(request);
            int x = Int32.Parse(newid);
            _requestId = Int32.Parse(newid);

            //Assert

            Assert.IsNotNull(newid, $"Request ID { newid } ");

            return "Successfully";

        }
        private string Step2_GetRequestPosition()
        {
            // 2. Get this new Request 
            //Arrange
            var parameterForRequest = new
            {
                SchoolYear = _schoolYear,
                PositionID = _requestId.ToString()
            };

            //Act
            List<PositionRequesting> request1 = RequestPostingExe.Position(parameterForRequest);
            _request = request1[0];

            //Assert
            Assert.IsNotNull(_request, $" Get Request Position ");

            return "Successfully";
        }
        private string Step3_UpdateRequestPosiiton()
        {
            //Arrange
            PositionRequesting updatePosition = new PositionRequesting()
            {
                Operate = "Update",
                UserID = "mif",
                SchoolYear = _schoolYear,
                SchoolCode = _schoolCode,
                PositionID = _requestId,
                Comments = "Test request posting Update function by new",
                PositionType = "LTO",
                PositionTitle = "English Grade 10 Teacher",
                PositionLevel = "BC003E",
                Qualification = "Biology; Science; Science - General; ",
                QualificationCode = "317; 401; 405; ",
                Description = "Biology; Science; Science - General; full time position need senior level",
                FTE = 1.00M,
                FTEPanel = "Full",
                StartDate = DateFC.YMD2(_dateStart),
                EndDate = DateFC.YMD2(_dateEnd),
                ReplaceTeacher = "replace teachername",
                ReplaceTeacherID = "00019103",
                ReplaceReason = "6",
                OtherReason = "Medical Leave",
                Owner = "frijiom",
                PrincipalID = _principalId
            };

            //Act
            string result = RequestPostingExe.Update(updatePosition);
            string expect = "Successfully";

            //Assert
            Assert.AreEqual(expect, result, $" Update and save postion request action was:  { result}");

            return "Successfully";
        }
        private string Step4_PostingRequestandGetPositionID()
        {
            // 4. posting Request 
            //Arrange        
            var parameter = new
            {
                SchoolYear = _schoolYear,
                PositionID = _requestId.ToString() // create new request
            };

            var parameterForDeadline = new
            {
                SchoolYear = _schoolYear,
                DatePublish = _publishDate,
                PositionType = "LTO"
            };
            var requestPosition = PostingPositionExe.Position(parameter)[0]; // get the posting position
            requestPosition.Comments = "Posting school request post position test process";
            requestPosition.CPNum = _cpNum;
            requestPosition.StartDate = _dateStart;
            requestPosition.EndDate = _dateEnd;
            requestPosition.DatePublish = _publishDate;
            requestPosition.DateApplyOpen = _applyDate;
            requestPosition.DateApplyClose = PublishPositionExe.Deadline(parameterForDeadline);

            //Act
            string postingPositionId = PostingPositionExe.Posting(requestPosition); // go for posting
            _positionId = _requestId = Int32.Parse(postingPositionId);
            var parameterForGetPostingNumber = new
            {
                Operate = "Get",
                PositionID = postingPositionId
            };

            var result = PostingPositionExe.PostingNumber(parameterForGetPostingNumber); // get Published Position
            string expect = DateTime.Now.Year.ToString() + "-" + postingPositionId;


            //Assert
            Assert.AreEqual(expect, result, $"Posting Request {result }");
            return "Successfully";
        }

        private string Step5_GetanApplyPositionbyID()
        {
            //Step 5 Get an position apply for

            //Arrange
            var paraApply = new
            {
                PositionID = _positionId,
                SchoolYear = _schoolYear,
                CPNum = _cpNum
            };


            //Act
            List<PositionApplying> position = ApplyProcessExe.Position(paraApply);
            _applyFor = position[0];
            _principalId = _applyFor.PrincipalID;
            string expect = "English Grade 10 Teacher";
            string result = _applyFor.PositionTitle;
            //Assert
            Assert.AreEqual(expect, result, $" Apply Position id { _applyFor.PositionID } { _applyFor.PositionTitle } ");

            return "Successfully";
        }

        private string Step6_ApplyOpenPosition_byApplicant_CPNum()
        {
            //Step 6  apply position

            //Arrange


            ApplicantRandom parameter = new ApplicantRandom()
            {
                Operate = "Apply",
                SchoolYear = _schoolYear,
                PositionID = _positionId.ToString(),
                PositionType = "LTO",
                PostingCycle = "1",
                CPNum = _cpNum
            };

            for (int i = 0; i < 10; i++)
            {

                List<Applicant> applicant = GeneralExe.RandomApplicant(parameter);
                string cpnum = applicant[0].CPNum;
                string name = applicant[0].TeacherName;
                string userid = applicant[0].UserID;
                Step6_ApplyOpenPosition_Action(cpnum, name, userid);
                parameter.CPNum = cpnum;

            }

            return "Successfully";
        }

        private void Step6_ApplyOpenPosition_Action(string cpnum, string applicantName, string userID)
        {
            ParametersForApply paraForApply = new ParametersForApply();

            paraForApply.Operate = "Apply";
            paraForApply.Action = "Applied";
            paraForApply.Comments = applicantName + " applying for this positng by Full Test processs";
            paraForApply.SchoolYear = _schoolYear;
            paraForApply.CPNum = cpnum;
            paraForApply.PositionID = _positionId.ToString();
            paraForApply.UserID = userID;

            // Act
            string expect = "Successfully";
            string result = ApplyProcessExe.Appied(paraForApply);

            //Assert
            Assert.AreEqual(expect, result, $" apply applicant  { applicantName}  ");

         
        }
        private string Step7_SelectInterviewCandidats()
        {

            // 7. Request a New Posting position 
            //Arrange 
            ParametersForOperation interviewcanddate = new ParametersForOperation()
            {
                Operate = "SelectForInterview",
                SchoolYear = _schoolYear,
                PositionID = _positionId,
                PositionType = "LTO",
                SchoolCode = _schoolCode,
                UserID = "mif",
                CPNum = _cpNum,
                Action = "1"
            };

            ApplicantRandom random = new ApplicantRandom()
            {
                Operate = "Candidate",
                SchoolYear = _schoolYear,
                PositionID = _positionId.ToString(),
                PositionType = "LTO",
                PostingCycle = "1",
                CPNum = _cpNum
            };

            //Act 
            string result = "1";
            for (int i = 0; i < 5; i++)
            {
                List<Applicant> applicant = GeneralExe.RandomApplicant(random);
                string cpnum = applicant[0].CPNum;
                random.CPNum = applicant[0].CPNum;
                interviewcanddate.CPNum = applicant[0].CPNum;

                result = SelectCandidateExe.Selected(interviewcanddate);

            }

            string expect = "Successfully";

            //Assert
            Assert.IsNotNull( result, $" select interview candaitae.");


            return "Successfully";

        }
        private string Step8_NoticeCandidateToSchoolPrincipal()
        {
            //Arrange

            InterviewNotice interviewNotice = new InterviewNotice()
            {
                Operate = "Notice Update",
                UserID = "mif",
                SchoolYear = _schoolYear,
                PositionID = _positionId.ToString(),
                NoticeDate = DateFC.YMD(DateTime.Now),
                PrincipalID = _principalId
            };

            //Act
            string expect = "Successfully";
            string result = SelectCandidateExe.NoticeUpdate(interviewNotice);


            //Assert
            Assert.AreEqual(expect, result, $"Notice position { interviewNotice.PositionID } interview candiates to  School Principal { _principalId } ");


            return "Successfully";
        }
        private string Step9_InterviewCandidats_Result()
        {

            // 9. candidate interview outcome 
            //Arrange 
            string result = "";
            InterviewResult outcome = new InterviewResult()
            {
                Operate = "Update",
                SchoolYear = _schoolYear,
                PositionID = _positionId.ToString(),
                UserID = _principalId,
                CPNum = _cpNum,
                Acceptance = "1",
                OutCome = "6", // interview
                Recommendation = "Principal interview comments from full testing process interview step 9",
                InterviewDate = DateFC.YMD(DateTime.Now),
                EffectiveDate = DateFC.YMD(DateTime.Now),
            };

            var parameter = new
            {   Operate = "IncludeAll",
                SchoolYear = _schoolYear,
                PositionID = _positionId
            };

            List<ApplicantListSelect> interviewlist = SelectCandidateExe.Applicants(parameter);
            foreach (ApplicantListSelect applicant in interviewlist)
            {
                string teachername = applicant.TeacherName;
                outcome.CPNum = applicant.CPNum;
                result = InterviewProcessExe.Update(outcome);

            }

            //Act 

            string expect = "Successfully";

            //Assert
            Assert.AreEqual(expect, result, $" Interview outcome update result ");


            return expect;

        }
        private string Step10_RecommendForHire()
        {

            // 10 Recommend one interview candidate for hire  
            //Arrange 

            //Arrange 
            string result = "";
            InterviewResult outcome = new InterviewResult()
            {
                Operate = "Recommend",
                SchoolYear = _schoolYear,
                PositionID = _positionId.ToString(),
                UserID = _principalId,
                CPNum = _cpNum,
                Acceptance = "1",
                OutCome = "6", // interview
                Recommendation = "Principal interview comments from full testing process interview step 9",
                InterviewDate = DateFC.YMD(DateTime.Now),
                EffectiveDate = DateFC.YMD(DateTime.Now),
            };

            var parameter = new
            {
                Operate = "",
                SchoolYear = _schoolYear,
                PositionID = _positionId
            };

            //Act
            string expect = "Successfully";
            List<ApplicantListSelect> interviewlist = SelectCandidateExe.Applicants(parameter);
            foreach (ApplicantListSelect applicant in interviewlist)
            {
                string teachername = applicant.TeacherName;
                outcome.CPNum = applicant.CPNum;

                if (outcome.Acceptance == "1" && outcome.OutCome == "6")
                {
                    result = InterviewProcessExe.Recommend(outcome);
                    _hiredCpNum = outcome.CPNum;
                    break;
                }
            }
            //Assert
            Assert.AreEqual(expect, result, $" Recommented for hire of { outcome.CPNum } ");
            return result;

        }
        private string Step11_ConfirmHire()
        {

            // 11. HR staff confirm hire  
            //Arrange 
            var parameter = new
            {
                SchoolYear = _schoolYear,
                PositionID = _positionId,
                CPNum = _hiredCpNum
            };
 
             
           List<PositionHire> hirePositionlist = ConfirmHireExe.Position(parameter);
            PositionHire position = hirePositionlist[0];
    
            //Act
            ParametersForOperationHire goHire = new ParametersForOperationHire()
            {
                Operate = "ConfirmHire",
                UserID = "mif",
                SchoolYear = _schoolYear,
                Comments = $"Auto testing Hired the person { position.TeacherName  } to this { position.PositionTitle } by Full test process ",
                PositionID = position.PositionID,
                PositionType = position.PositionType,
                CPNum = _hiredCpNum,
                DateConfirm = DateFC.YMD(DateTime.Now),
                DateEffective = position.DateEffective,
                DateEnd = position.EndDate,
                Acceptance = "1",
                PrincipalEmail = "1",
                OfficerEmail = "0",
                PayStatus = "9",
                Action = "ConfirmHire"
            };

            string result = ConfirmHireExe.Confirm(goHire);
            string expect = "Successfully";

            //Assert
            Assert.AreEqual(expect, result, $"Hired { position.TeacherName } on  { position.PositionTitle } . " );


            return "Successfully";

        }
        private string Step12_ConfirmHireRevoke()
        {

            // 12. HR staff  revoke confirm hire  
            //Arrange 
            var parameter = new
            {
                SchoolYear = _schoolYear,
                PositionID = _positionId,
                CPNum = _hiredCpNum,
            };

 

            List<PositionHired> hirePositionlist = HiredPositionExe.Position(parameter);
            PositionHired position = hirePositionlist[0];
            position.Operate = "Revoke";
            position.Comments = $"Auto testing 12 HR staff Revoke { position.TeacherName }  Hire on {  position.PositionTitle } ";
         //   position.CPNum = position.TeacherCPNum;

            string result = HiredPositionExe.Revoke(position);
            string expect = "Successfully";

            //Assert
            Assert.AreEqual(expect, result, $" Revoke Hired { position.TeacherName } on  { position.PositionTitle } . ");


            return "Successfully";

        }

        private string Step99_ClearupTestingProcess()
        {

            // 12. HR staff  revoke confirm hire  
            //Arrange 
            var parameter = new
            {
                SchoolYear = _schoolYear,
                PositionID = _positionId,
                CPNum = _hiredCpNum
            };


            List<PositionHired> hirePositionlist = HiredPositionExe.Position(parameter);
            PositionHired position = hirePositionlist[0];
            position.Operate = "Delete";
            position.Comments = $"Auto testing 12 HR staff Revoke { position.TeacherName }  Hire on {  position.PositionTitle } ";


            string result = HiredPositionExe.Revoke(position);
            string expect = "Successfully";

            //Assert
            Assert.AreEqual(expect, result, $" Revoke Hired { position.TeacherName } on  { position.PositionTitle } . ");


            return "Successfully";

        }
    }
}