var currentTR;
var signCell;
var myImg;

function pageLoad(sender, args) {

    $(document).ready(function () {
        MakeStaticHeader("GridView1", 270, 1500, 25, false, 'DivHeaderRow', 'GridView2', 'DivMainContent');
        var hireState = $('#HiddenFieldHired').val();
        var x = 0;
        $("#GridView1 tr").each(function () {
            try {
                var row = $(this).find('td.myRowNo').text();
                if (row === "5") {
                    $(this).addClass("top5Row");
                }
                var vNoticed = $(this).find('td.myNoticed').text();
                if (hireState === "Hired") {
                    $(this).find('#GridView1_cbSelect_' + x.toString()).attr('disabled', true);
                }
                else {
                    if (vNoticed === "Y") {
                        $(this).find('#GridView1_cbSelect_' + x.toString()).attr('disabled', true);
                    }
                }
                if (vNoticed === "Y" || vNoticed === "N") { x++; }
            }
            catch (ex) {
                throw new Error(" Gridview TR action");
            }
        });

        $('td > .myCheck').dblclick(function (event) {
            // alert("you are double click the check box, please refresh this list.");
            location.reload();
        });

        $('td > .myCheck').click(function (event) {
          
            var eventCell = $(this);
            var check = eventCell[0].childNodes['0'].checked;
            var action = "0";
            if (check) { action = "1"; }
        
            if ($("#HiddenFieldUserRole").val() !== "Superintendent") {

             
                var applyuserID = $(this).closest('tr').find('td.EditCPNum').text();
                // var mySelectImg = $(this).closest('tr').find('a.mySelect').html() ;
                myImg = $(this).closest('tr').find('a.mySelect');
                var schoolyear = $("#HiddenFieldSchoolYear").val();
                var positionID = $("#HiddenFieldPositionID").val();

                var vNoticed = $(this).closest('tr').find('td.myNoticed').text();
                var hireState = $('#HiddenFieldHired').val();
                if (hireState !== "Hired") {
                    if (vNoticed !== "Y") {
                        ChangeSelectSign(schoolyear, positionID, applyuserID, action);
                    }
                }
            }
        });

        $("#btnExcel").click(function (e) {

            var appType = $("#ddlappType").val();
            var includeAll = "No";
            if ($("#checkboxAll").attr('checked')) { includeAll = "Yes"; }

            var schoolyear = $("#HiddenFieldSchoolYear").val();
            var positionID = $("#HiddenFieldPositionID").val();

            var goPage = "../PDFLoading/EXCELDocument_Loading.aspx?rID=ApplicantList_Interview&yID=" + schoolyear + "&pID=" + positionID + "&includeAll=" + includeAll;

            window.open(goPage, "", "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,width=450 height=300, top=10, left=10");
            return false;
        });
    });
}
 
function PopUpDIV3() {
    el = parent.parent.document.getElementById("PopUpDIV");
    el.style.visibility = (el.style.visibility == "visible") ? "hidden" : "visible";
    var DisableAction = '0';
}

function ChangeSelectSign(schoolyear, positionID, applyuserID, action) {

    var newSelect = WebService.SelectInterview(schoolyear, positionID, applyuserID, action, onSuccess, onFailure);

}

function onSuccess(result) {
    changeSign(result);
    $("#labelSelected").text(result);
    //  window.alert(result);
}
function onFailure(result) {
    $("#labelSelected").text(result);
    window.alert(result);
}
function changeSign(result) {
    var signCellHTML = myImg.html();
    var signCellNew = "";
    var iec = new IECompatibility();
    if (iec.Compatible) {
        if (signCellHTML.indexOf("width=0 height=0") == -1) {
            signCellNew = signCellHTML.replace("width=25 height=25", "width=0 height=0");
        }
        else {
            signCellNew = signCellHTML.replace("width=0 height=0", "width=25 height=25");
        }
    }
    else {
        if (signCellHTML.indexOf("width=\"0\" height=\"0\"") == -1) {
            signCellNew = signCellHTML.replace("width=\"25\" height=\"25\"", "width=\"0\" height=\"0\"");
        }
        else {
            signCellNew = signCellHTML.replace("width=\"0\" height=\"0\"", "width=\"25\" height=\"25\"");
        }
    }
    myImg.html(signCellNew);

    // signCell._element.innerHTML = signCellNew;

    parent.changeEmailCellSign();
}
function openInterview(schoolyear, applyuserID, positionID, teacherName) {
    // var goPage = "Loading2.aspx?pID=LTOHRStaffs/ApplicantDetails.aspx&SchoolYear=" + schoolyear + "&ApplyUserID=" + applyuserID + "&PositionID=" + positionID + "&TeacherName=" + teacherName;
    var goPage = "Loading2.aspx?pID=LTOHRStaffs/ApplicantDetails2.aspx&SchoolYear=" + schoolyear + "&ApplyUserID=" + applyuserID + "&PositionID=" + positionID + "&TeacherName=" + teacherName;
    if ($("#HiddenFieldUserRole").val() !== "Superintendent") {
        openDetailPage(500, 650, goPage, "Recommend for Interview");
    }
}
function closeHRComments() {
    $("#CommentsDIV").fadeToggle("fast");
}
function openHRComments(schoolyear, cpnum, pending) {
    var goPage = "HRPendingComments.aspx?SchoolYear=" + schoolyear + "&CPNum=" + cpnum;
    var xTop = mouse_y + 10; // event.currentTarget.offsetTop;
  //  var upPart = 250;
   // if (xTop > 150) { xTop = mouse_y - 210; }
    xTop = 50; //  mouse_y - 210;
    var xLeft = mouse_x + 20; // event.currentTarget.offsetLeft + 70;

    if (pending === "Pending")
        $("#CommentsDIV").removeClass("boardColor").addClass("boardPending");
    else
        $("#CommentsDIV").removeClass("boardPending").addClass("boardColor");

    $("#CommentsiFrame").attr('src', goPage);
    $("#CommentsDIV").css({
        top: xTop,
        left: xLeft,
        height: 200,
        width: 450 
    });
    $("#CommentsDIV").fadeToggle("fast");


}

function openOCT(schoolyear, schoolcode, OCTNumber) {
    window.open("OCTSite.aspx?OCTNum=" + OCTNumber, "", "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes,width=950,height=750,top=5,left=5");
    currentTR.addClass("highlightBoard");

}
function openLTOAppraisal(schoolyear, schoolcode, PositionID, TeacherID) {
    var printPage = "../PDFLoading/PDFDocument_Loading.aspx?rID=InterviewPackage" + "&yID=" + schoolyear + "&CPNum=" + TeacherID + "&pID=" + PositionID;
    var popup1 = window.open(printPage, "", "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=yes,width=800,height=600,top=0,left=0");
}


function openComment(schoolyear, positionID, CPNum) {
    var printPage = "ApplicantComments.aspx?SchoolYear=" + schoolyear + "&ApplyUserID=" + CPNum + "&PositionID=" + positionID;
    var w = 400;
    var h = 300;
    var left = (screen.width / 2) - (w / 2);
    var top = (screen.height / 2) - (h / 2);
    var popup1 = window.open(printPage, "", "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=yes,width=" + w + ",height=" + h + ",top=" + top + ",left=" + left);
}

function openDetailPage(vHeight, vWidth, goPage, pTitle) {
    var vLeft = (screen.width / 2) - (vWidth / 2) - 50;
    var vTop = (screen.height / 2) - (vHeight / 2) - 50;
    $(document).ready(function () {
        try {
            $("#PositionDetailFrame", parent.parent.document).attr('src', goPage);
            $("#popPagetitle", parent.parent.document).text(pTitle);
            $("#hfInvokePageFrom", parent.parent.document).val("LTOHRStaffs/ApplicantList2.aspx");
            $("#PositionDetailDIV", parent.parent.document).css({
                top: vTop,
                left: vLeft,
                height: vHeight,
                width: vWidth
            });
            $("#PopUpDIV", parent.parent.document).fadeToggle("fast");
            $("#PositionDetailDIV", parent.parent.document).fadeToggle("fast");

        }
        catch (ex) {
            throw new Error("Open detail error message");
        }
    });

}
function openResumeCoverLetter(type, schoolYear, ids, cpNum, positionID, grantView) {
    var goPage = "../LTOTeachers/FileShow.aspx?Type=" + type + "&IDs=" + ids + "&CPNum=" + cpNum + "&PositionID=" + positionID + "&SchoolYear=" + schoolYear;
    window.open(goPage, "", "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=no,width=700 height=500, top=50, left=50");

}