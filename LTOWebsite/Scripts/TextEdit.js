function SaveDataCompleted() {
    window.alert("Saved successfully!");
}

function SaveTextBoxbyPostback(sender) {
    try {  //debugger// sender.txt_postback.value="PostBack";
        document.getElementById("txtContextChange").value = "1";
        // sender.submit();		
        // alert("ok");
    }
    catch (e)
        { }
}
function SaveTextBoxbyPostbackMe(sender) {
    try { // debugger
        var SaveButton = document.getElementById("SaveB")
        SaveButton.click();
    }
    catch (e)
        { }
}

function setTextChange() {  //debugger
         
    document.getElementById("txtContextChange").value = "1";
}

function SetSelectChange() {
    try {
        document.getElementById("txtSelectChange").value = "1";
    }
    catch (e)
        { }
}
function setTextChangeSaveON(_myText) { //debugger
    var myoText = document.getElementById(_myText);
    myoText.onchange = "javascript:SaveTextBoxbyPostback(Form1);";
}


function setTextCount(textLong, myText, myLab) {
    try {
        //var nCnt = document.Form1.elements[myText].value.length;
        setTextChange();
        var nCnt = document.getElementById(myText).value.length;
        if (myLab != "No") {
            document.getElementById(myLab).value = textLong - nCnt;
            //  document.getElementById("txtContextChange").value ="1";
        }
        if (nCnt > textLong) {
            window.alert("Text longer than " + textLong + " charaters");
        }
    }
    catch (e)
        { }
}
function setTextCount2(textLong, myText, myLab, myMenu) {
    try {
        setTextChange2(myMenu);
        var nCnt = document.getElementById(myText).value.length;
        if (myLab != "No") {
            document.getElementById(myLab).value = textLong - nCnt;
        }
        if (nCnt > textLong) {
            window.alert("Text longer than " + textLong + " charaters");
        }
    }
    catch (e)
        { window.alert("Your browser does not support the Function !"); }
}
function setTextChange2(myMenu) {   
     if (document.getElementById("txtContextChange").value != "1")
         {
          document.getElementById("txtContextChange").value = "1";
          LeftMenuEnable(myMenu, false);
         }
}   
function CheckedP(myCheck, myText, mySource) {
    try {	 //debugger
        var cCheck = document.getElementById(myCheck);
        var cText = document.getElementById(myText);
        var cSource = document.getElementById(mySource).value;
        if (cCheck.checked)
        { cText.value = cSource; }
        else
        { cText.value = ""; }
        document.getElementById("txtContextChange").value = "1";
    }
    catch (e)
        { }
}
function setTextCountPoP(textLong, myText, myLab) {
    try {
        var nCnt = document.FormPoP.elements[myText].value.length;
        document.FormPoP.elements[myLab].value = textLong - nCnt;
        if (nCnt > textLong)
            window.alert("Text longer than " + textLong + " charaters");
    }
    catch (e)
        { }
}
function EnableTextBox(textID, chkID, eValue) {
    try {	//var nCnt = document.Form1.elements[myText].value.length; 
        var myrbl = chkID + "_" + eValue; //IEP0000_1_iepForm_rblRational_0
        var myCHK = document.getElementById(myrbl);
        var myText = document.getElementById(textID);
        if (myCHK.checked)
            myText.disabled = false;
        else
            myText.disabled = true;
    }
    catch (e)
        { }
}
function DisableTextBox(myText) {
    try { //debugger 
        var pReadonly;
        var objControl = document.getElementById(myText);
        if (document.getElementById("myPageReadonly").value == "True")
            pReadonly = true;
        else
            pReadonly = false;
        objControl.readOnly = pReadonly;
    }
    catch (e)
        { }
}
function DisableMyText(myText, myRole, myCtrl) {
    try { //  debugger
        var pReadonly;
        if (myRole === "Superintendent")
        { pReadonly = false; }
        else {
            if (document.getElementById("bSignOff").value === "True")
            { pReadonly = true; }
            else {
                if (myCtrl === "T") {
                    pReadonly = myRole === "Teacher" ? false : true;
                }
                else {
                    if (myCtrl === "P") {                    
                            pReadonly = myRole === "Teacher" ? true : false;                
                    }
                    else
                        pReadonly = false;
                }
            }
        }
        document.getElementById(myText).readOnly = pReadonly;
        document.getElementById(myText).onmouseover = "";
    }
    catch (e)
      { }
}
function DisableMyTextStep(myText, myRole, myCtrl, myStep) {
    try { //debugger
        var pReadonly;
        if (myRole === "Superintendent")
        { pReadonly = false; }
        else {
            if (document.getElementById("bSignOff").value === "True")
            { pReadonly = true; }
            else {
                if (myCtrl === "T") {
                    pReadonly = myRole === "Teacher" ? false : true;
                }
                else {
                    if (myCtrl === "P") {
                        if (myRole === "Teacher")
                            pReadonly = true;
                        else {
                            pReadonly = myStep === "open" ? false : true;                     
                        }
                    }
                    else
                        pReadonly = false;
                }
            }
        }
        document.getElementById(myText).readOnly = pReadonly;
        document.getElementById(myText).onmouseover = "";
    }
    catch (e)
      { }
}

function SpellingCheck(FormName, CtrlName, cTitle) {
    try {
        var txtCtl = document.getElementById(CtrlName).readOnly;
        if (txtCtl.readOnly || txtCtl.isDisabled)
            var mytext = txtCtl.readOnly;
        else {
            var MyReturnValue
            try {
                MyReturnValue = window.showModalDialog('../CommonPages/BaseSpellCheck.aspx?FormName=' + FormName + '&CtrlName=' + CtrlName + '&Title=' + cTitle, window, "unadorned:no;scroll:no;resizable:no;help:no;status:no;dialogTop:50;dialogLeft:50;dialogHeight:520px;dialogWidth:710px");
                }
            catch (e) {
                try {
                    MyReturnValue = window.showModalDialog('../CommonPages/BaseSpellCheck.aspx?FormName=' + FormName + '&CtrlName=' + CtrlName + '&Title=' + cTitle, window, "dialogTop:50;dialogLeft:50;dialogHeight:520px;dialogWidth:710px");
                 }
                catch (e) {
                    window.alert("Your Browser Doesn't Support the Show Modal Dialog open !")
                } 
              }
            if (MyReturnValue != null) {
                document.getElementById(CtrlName).value = MyReturnValue;
                document.getElementById("txtContextChange").value = "1";
                try {
                     LeftMenuEnable("WebExplorerBar1", false);
                }
                catch (e)
                  { }
            }
        }
    }
    catch (e)
      { window.alert("Your Browser Doesn't Support the Show Modal Dialog open !") }
}

function SpellingCheckNew(myForm, myText, myCode) {
    try {
        if (myText != null) {
            popPage = "../CommonPages/BaseSpellCheck.aspx?FormName=" + myForm + '&CtrlName=' + myText + '&Title=' + myCode;
            popPageS = "unadorned:no;scroll:no;resizable:no;help:no;status:no;dialogTop:50;dialogLeft:50;dialogHeight:520px;dialogWidth:710px";
            var MyReturnValue = window.showModalDialog(popPage, window, popPageS);
            if (MyReturnValue != null) {
                var myReturn = "#" + myText;
                $(myReturn).val(MyReturnValue);  //     document.getElementById(myText).value =  MyReturnValue;;
                setTextChange();
            }
        }
    }
    catch (e)
                { }
}


function openBigTextPage(CtrlName, cTitle, countName) {
    try { ///debugger
        var txtCtl = document.getElementById(CtrlName).readOnly;
        if (txtCtl.readOnly || txtCtl.isDisabled)
            var mytext = txtCtl.readOnly;
        else {
            var MyReturnValue = window.showModalDialog('../CommonPages/BaseEditor.aspx?FormName=' + document.forms[0].name + '&CtrlName=' + CtrlName + '&Title=' + cTitle, window, "scroll:no;resizable:no;help:no;status:no;dialogTop:10;dialogLeft:10;dialogHeight:600px;dialogWidth:790px");
            if (MyReturnValue != null) {
                var nCnt = MyReturnValue.length;
                document.getElementById(CtrlName).value = MyReturnValue;
                document.getElementById(countName).value = textLong - nCnt;
            }
        }
    }
    catch (e) { 
          window.alert("Your Browser Doesn't Support the Show Modal Dialog open !")
         }
}

function TextEditBigPage(CtrlName, cTitle, countName, txtLong) {
    try { ///debugger
        var txtCtl = document.getElementById(CtrlName).readOnly;
        if (txtCtl.readOnly || txtCtl.isDisabled)
            var mytext = txtCtl.readOnly;
        else {
            var MyReturnValue = window.showModalDialog('../CommonPages/BaseEditor.aspx?FormName=' + document.forms[0].name + '&CtrlName=' + CtrlName + '&Title=' + cTitle + '&txtLong=' + txtLong, window, "scroll:no;resizable:no;help:no;status:no;dialogTop:10;dialogLeft:10;dialogHeight:600px;dialogWidth:790px");
            if (MyReturnValue != null) {
                var nCnt = MyReturnValue.length;
                document.getElementById(CtrlName).value = MyReturnValue;
                document.getElementById(countName).value = txtLong - nCnt;
                document.getElementById("txtContextChange").value = "1";
            }
        }
    }
    catch (e)
      { }
}


function getCompentencyToText(objText, listIndex, chkCode) {
    try {
        document.getElementById("txtSelectedCompentency").value = chkCode;
        var oListClick = document.getElementById(listIndex);
        var oText = document.getElementById(objText);
        if (oListClick.checked == true) {
            var selectText = oListClick.offsetParent.innerText;
            document.getElementById("txtContextChange").value = "1";
            selectText = selectText.replace("The teacher", getTeacherName("HeShe")) + "\n";
            selectText = selectText.replace("his or her", getTeacherName("hisher"));
            if (oText.value.length > 2)
                oText.value += selectText + "\n";
            else {
                var tName = document.getElementById("txtTeacherName").value;
                oText.value = tName + ":" + "\n" + "\n" + selectText + "\n";
            }
            //  oText.onchange();    
        }
    }
    catch (e)
    { }
}


function getCompentencyToText0(chkCode, listIndex) {
    try {//debugger
        document.getElementById("txtSelectedCompentency").value = chkCode;
        var oListClick = document.getElementById(listIndex);

    }
    catch (e)
    { }
}

function getCompentencyToText1(chkCode, listIndex) {
    try { //debugger
        document.getElementById("txtSelectedCompentency").value = chkCode;
        // var oListClick = document.getElementById(listIndex);
        // var oText = document.getElementById(objText);
        // var selectChk = document.getElementById("txtSelectedCompentency2"); 
        var oListClick = document.getElementById(listIndex);
        oListClick.click();

    }
    catch (e)
    { }
}

function getCompentencyToText2(objText, listIndex, chkCode, code, imgB) {
    try {
        if (document.getElementById("bSignOff").value != "True") {
            var imgC = document.getElementById(imgB);
            if (imgC.border == "0") {
                document.getElementById("txtSelectedCompentency").value = chkCode;
                var oListClick = document.getElementById(listIndex);
                var oText = document.getElementById(objText);

                var selectChk = document.getElementById("txtSelectedCompentency2");
                oListClick.click();
                if (code == "S")
                    selectChk.value = "1";
                else
                    selectChk.value = "2";
                var selectText = oListClick.offsetParent.innerText;
                document.getElementById("txtContextChange").value = "1";
                selectText = selectText.replace("The teacher", getTeacherName("HeShe", code)) + "\n";
                selectText = selectText.replace("his or her", getTeacherName("hisher", code));
                if (oText.value.length > 2)
                    oText.value += selectText + "\n";
                else {
                    var tName = document.getElementById("txtTeacherName").value;
                    oText.value = tName + ":" + "\n" + "\n" + selectText + "\n";
                }
            }
        }
    }
    catch (e)
    { }
}

function getTeacherName(_type, code) {
    var rName = "";
    var tName = document.getElementById("txtTeacherName").value;
    var tGender = document.getElementById("txtTeacherGender").value;
    var firstS = document.getElementById("txtFirstTime");
    if (firstS.value == "Yes") {
        if (code == "S")
            rName = " - "; // tName   + "\n"  + "\n" 
        else
            rName = " - infrequently";
        firstS.value = "No";
    }
    else {
        if (_type == "HeShe") {
            if (code == "S")
                rName = " - ";
            else
                rName = " - infrequently";
        }
        else {
            if (tGender == "M")
                rName = "his";
            else
                rName = "her";
        }
    }
    return rName;
}

function GetFramework3(type, CtrlName, countName, cTitle) {
    try { // debugger
        var txtCtl = document.getElementById(CtrlName).readOnly;
        if (txtCtl.readOnly || txtCtl.isDisabled)
            var mytext = txtCtl.readOnly;
        else {
            var pageName = "../CommonPages/BaseSelectFrameworkS.aspx?Title=" + cTitle + "&Type=" + type;
            //  var pageName = "http://localhost/mysilverlight";

            var MyReturnValue = window.showModalDialog(pageName, window, "scroll:no;resizable:no;help:no;status:no;dialogTop:10;dialogLeft:10;dialogHeight:600px;dialogWidth:800px");
            if (MyReturnValue != null) {// MyReturnValue = MyReturnValue.replace("The teacher", getTeacherName("HeShe") );
                var oText = document.getElementById(CtrlName);
                oText.value += "\n" + MyReturnValue;
                var nCnt = oText.value.length;
                document.getElementById(countName).value = 4000 - nCnt;
                document.getElementById("txtContextChange").value = "1";
                // oText.onchange(); 
            }
        }
    }
    catch (e)
        { }
}
function GetSmartGoal3(type, CtrlName, countName, cTitle) {
    try { // debugger
        var txtCtl = document.getElementById(CtrlName).readOnly;
        if (txtCtl.readOnly || txtCtl.isDisabled)
            var mytext = txtCtl.readOnly;
        else {
            var pageName = "../CommonPages/BaseSmartGoal.aspx?Title=" + cTitle + "&Type=" + type;
            var MyReturnValue = window.showModalDialog(pageName, window, "scroll:no;resizable:no;help:no;status:no;dialogTop:10;dialogLeft:10;dialogHeight:650px;dialogWidth:800px");
            if (MyReturnValue != null) {// MyReturnValue = MyReturnValue.replace("The teacher", getTeacherName("HeShe") );
                var oText = document.getElementById(CtrlName);
                oText.value += "\n" + MyReturnValue;
                var nCnt = oText.value.length;
                document.getElementById(countName).value = 4000 - nCnt;
                document.getElementById("txtContextChange").value = "1";
                // oText.onchange(); 
            }
        }
    }
    catch (e)
        { }
}
function GetIndicators3(type, CtrlName, countName, cTitle) {
    try { // debugger
        var txtCtl = document.getElementById(CtrlName).readOnly;
        if (txtCtl.readOnly || txtCtl.isDisabled)
            var mytext = txtCtl.readOnly;
        else {
            var pageName = "../CommonPages/BaseSelectIndicators.aspx?Title=" + cTitle + "&Type=" + type;
            var MyReturnValue = window.showModalDialog(pageName, window, "scroll:no;resizable:no;help:no;status:no;dialogTop:10;dialogLeft:10;dialogHeight:600px;dialogWidth:800px");
            if (MyReturnValue != null) {// MyReturnValue = MyReturnValue.replace("The teacher", getTeacherName("HeShe") );
                var oText = document.getElementById(CtrlName);
                oText.value += "\n" + MyReturnValue;
                var nCnt = oText.value.length;
                document.getElementById(countName).value = 4000 - nCnt;
                document.getElementById("txtContextChange").value = "1";
                // oText.onchange(); 
            }
        }
    }
    catch (e)
        { }
}

function GetComments3(type, CtrlName, countName, cTitle) {
    try {  // debugger
        var txtCtl = document.getElementById(CtrlName).readOnly;
        if (txtCtl.readOnly || txtCtl.isDisabled)
            var mytext = txtCtl.readOnly;
        else {
            var pageName = "../CommonPages/BaseComments.aspx?Title=" + cTitle;
            var MyReturnValue = window.showModalDialog(pageName, window, "scroll:no;resizable:no;help:no;status:no;dialogTop:10;dialogLeft:10;dialogHeight:550px;dialogWidth:700px");
            if (MyReturnValue != null) {// MyReturnValue = MyReturnValue.replace("The teacher", getTeacherName("HeShe") );
                // MyReturnValue = MyReturnValue.replace("He or She",   getTeacherName("HeShe") ); 
                //  MyReturnValue = MyReturnValue.replace("TN",   getTeacherName("HeShe") );
                // MyReturnValue = MyReturnValue.replace("his or her",  getTeacherName("hisher") ); 
                var oText = document.getElementById(CtrlName);
                oText.value += "\n" + MyReturnValue;
                var nCnt = oText.value.length;
                document.getElementById(countName).value = 4000 - nCnt;
                document.getElementById("txtContextChange").value = "1";
                // oText.onchange(); 
            }
        }
    }
    catch (e)
        { }
}

function GetGoals3(type, CtrlName, countName, cTitle) {
    try {
        var txtCtl = document.getElementById(CtrlName).readOnly;
        if (txtCtl.readOnly || txtCtl.isDisabled)
            var mytext = txtCtl.readOnly;
        else {
            var pageName = "../CommonPages/BaseSchoolLearningPlan3.aspx?Title=" + cTitle;
            var MyReturnValue = window.showModalDialog(pageName, window, "scroll:no;resizable:no;help:no;status:no;dialogTop:10;dialogLeft:10;dialogHeight:700px;dialogWidth:800px");
            if (MyReturnValue != null) { // MyReturnValue = MyReturnValue.replace("The teacher", getTeacherName("HeShe") );
                // MyReturnValue = MyReturnValue.replace("his or her",  getTeacherName("hisher") );    
                //			          document.getElementById(CtrlName).value  +=  "\n" +MyReturnValue ;
                // 				      var nCnt = document.getElementById(CtrlName).value.length; 
                // 			  	      document.getElementById(countName).value = 4000 - nCnt;
                var oText = document.getElementById(CtrlName);
                oText.value += "\n" + MyReturnValue;
                var nCnt = oText.value.length;
                document.getElementById(countName).value = 4000 - nCnt;
                document.getElementById("txtContextChange").value = "1";
                //    oText.onchange(); 
            }
        }
    }
    catch (e)
        { }
}
function GetTips3(type, CtrlName, countName, cTitle) {
    try {
        var txtCtl = document.getElementById(CtrlName).readOnly;
        if (txtCtl.readOnly || txtCtl.isDisabled)
            var mytext = txtCtl.readOnly;
        else {
            var pageName = "../CommonPages/BaseSelectTips3.aspx?Title=" + cTitle;
            var MyReturnValue = window.showModalDialog(pageName, window, "scroll:no;resizable:no;help:no;status:no;dialogTop:10;dialogLeft:10;dialogHeight:500px;dialogWidth:700px");
            if (MyReturnValue != null) { // MyReturnValue = MyReturnValue.replace("The teacher", getTeacherName("HeShe") );
                // MyReturnValue = MyReturnValue.replace("He or She",   getTeacherName("HeShe") ); 
                // MyReturnValue = MyReturnValue.replace("TN",   getTeacherName("HeShe") ); 
                // MyReturnValue = MyReturnValue.replace("his or her",  getTeacherName("hisher") );    
                // document.getElementById(CtrlName).value  +=  "\n" +MyReturnValue ;
                // var nCnt = document.getElementById(CtrlName).value.length; 
                // document.getElementById(countName).value = 4000 - nCnt; 

                var oText = document.getElementById(CtrlName);
                oText.value += "\n" + MyReturnValue;
                var nCnt = oText.value.length;
                document.getElementById(countName).value = 4000 - nCnt;
                document.getElementById("txtContextChange").value = "1";
                //  oText.onchange(); 
            }
        }
    }
    catch (e)
        { }
}
function GetCopy3(type, CtrlName, countName, cTitle) {
    try {
        var txtCtl = document.getElementById(CtrlName).readOnly;
        if (txtCtl.readOnly || txtCtl.isDisabled)
            var mytext = txtCtl.readOnly;
        else {
            var pageName = "../CommonPages/BaseSelectCopy3.aspx?Title=" + cTitle;
            var MyReturnValue = window.showModalDialog(pageName, window, "scroll:no;resizable:no;help:no;status:no;dialogTop:10;dialogLeft:10;dialogHeight:500px;dialogWidth:700px");
            if (MyReturnValue != null) { //MyReturnValue = MyReturnValue.replace("The teacher", getTeacherName("HeShe") );
                //MyReturnValue = MyReturnValue.replace("his or her",  getTeacherName("hisher") );    
                //document.getElementById(CtrlName).value  +=  "\n" +MyReturnValue ;
                //var nCnt = document.getElementById(CtrlName).value.length; 
                //document.getElementById(countName).value = 4000 - nCnt;

                var oText = document.getElementById(CtrlName);
                oText.value += "\n" + MyReturnValue;
                var nCnt = oText.value.length;
                document.getElementById(countName).value = 4000 - nCnt;
                document.getElementById("txtContextChange").value = "1";
                //  oText.onchange(); 
            }
        }
    }
    catch (e)
        { }
}


function GetTLCP(type, CtrlName, countName, cTitle) {
    try {  // debugger

        var pageName = "SmartGoalTLCP.aspx?Title=" + cTitle;
        window.showModalDialog(pageName, window, "scroll:no;resizable:no;help:no;status:no;dialogTop:10;dialogLeft:10;dialogHeight:400px;dialogWidth:600px");
    }
    catch (e)
        { }
}

function openHistroy() {
    try {  // debugger

        var pageName = "SmartGoalDocumentsHistroy.aspx"
        window.showModalDialog(pageName, window, "scroll:no;resizable:no;help:no;status:no;dialogTop:10;dialogLeft:10;dialogHeight:600px;dialogWidth:800px");
    }
    catch (e)
        { }
}
function openHTMLPagePrint() {
    try {  // debugger

        var pageName = "SmartGoalHTMLPrint.aspx";

        window.open(pageName, "HTMLDocument", "width=800, height=600,toolbars=yes");  //, top=50, left=50, toolbars=yes, scrollbars=no,status=no,resizable=no");
        //   window.showModalDialog(pageName, window, "scroll:no;resizable:no;help:no;status:no;dialogTop:10;dialogLeft:10;dialogHeight:600px;dialogWidth:800px");

    }
    catch (e)
        { }
}


function openReportingPDF(type, documentType) {
    try {  // debugger
        var pageName = "SmartGoalDocument.aspx?pID=" + type + "&dID=" + documentType;
        //            if (type == "Publish")
        //            { pageName = "SmartGoalHTMLPublish.aspx" }
        window.open(pageName, "HTMLDocument", "width=800, height=600,  top=50, left=20, toolbars=yes, scrollbars=yes,status=no,resizable=yes");
        //   window.showModalDialog(pageName, window, "scroll:no;resizable:no;help:no;status:no;dialogTop:10;dialogLeft:10;dialogHeight:600px;dialogWidth:800px");

    }
    catch (e)
        { }
}

function openCopyDocument() {
    try {  // debugger
        var pageName = "SmartGoalDocumentCopy.aspx"
        //            if (type == "Publish")
        //            { pageName = "SmartGoalHTMLPublish.aspx" }
        window.open(pageName, "copyDocument", "width=600, height=350,  top=200, left=180, toolbars=no, scrollbars=no,status=no,resizable=no");
        //   window.showModalDialog(pageName, window, "scroll:no;resizable:no;help:no;status:no;dialogTop:10;dialogLeft:10;dialogHeight:600px;dialogWidth:800px");

    }
    catch (e)
        { }
}

function GetRecover(type, CtrlName, iCode, cTitle) {
    try { // debugger
        var txtCtl = document.getElementById(CtrlName).readOnly;
        if (txtCtl != true) {
            var pageName = "../CommonPages/BaseRecover.aspx?tID=" + cTitle + "&iID=" + iCode;
            var MyReturnValue = window.showModalDialog(pageName, window, "scroll:no;resizable:no;help:no;status:no;dialogTop:1;dialogLeft:1;dialogHeight:600px;dialogWidth:800px");
            if (MyReturnValue != null) {
                document.getElementById(CtrlName).value = MyReturnValue;
                setTextChange();
            }
        }

    }
    catch (e)
        { }
}
function GetRecoverQA(type, CtrlName, iCode, cTitle) {
    try { // debugger
        var txtCtl = document.getElementById(CtrlName).readOnly;
        if (txtCtl != true) {
            var pageName = "../CommonPages/BaseRecoverQA.aspx?tID=" + cTitle + "&iID=" + iCode;
            var MyReturnValue = window.showModalDialog(pageName, window, "scroll:no;resizable:no;help:no;status:no;dialogTop:1;dialogLeft:1;dialogHeight:600px;dialogWidth:800px");
            if (MyReturnValue != null) {
                document.getElementById(CtrlName).value = MyReturnValue;
                setTextChange();
            }
        }

    }
    catch (e)
        { }
}
function GetRecover4(type, CtrlName, iCode, cTitle) {
    try { // debugger
        var txtCtl = document.getElementById(CtrlName).readOnly;
        if (txtCtl != true) {
            var pageName = "../CommonPages/BaseRecover4.aspx?tID=" + cTitle + "&iID=" + iCode;
            var MyReturnValue = window.showModalDialog(pageName, window, "scroll:no;resizable:yes;help:no;status:no;dialogTop:1;dialogLeft:1;dialogHeight:600px;dialogWidth:800px");
            if (MyReturnValue != null) {
                document.getElementById(CtrlName).value = MyReturnValue;
                setTextChange();
                try {
                    LeftMenuEnable("WebExplorerBar1", false);
                }
                catch (e)
                  { }
            }
        }

    }
    catch (e) {
        window.alert(" Your Browser Does not Support the ShowModalDialog Function ! ");
    }
}
function GetRecover5(type, CtrlName, iCode, cTitle) {
    try { // debugger
        var txtCtl = document.getElementById(CtrlName).readOnly;
        if (txtCtl != true) {
            var pageName = "../CommonPages/BaseRecover5.aspx?tID=" + cTitle + "&iID=" + iCode;
            var MyReturnValue = window.showModalDialog(pageName, window, "scroll:no;resizable:yes;help:no;status:no;dialogTop:1;dialogLeft:1;dialogHeight:600px;dialogWidth:800px");
            if (MyReturnValue != null) {
                document.getElementById(CtrlName).value = MyReturnValue;
                setTextChange();
            }
        }

    }
    catch (e) {
        window.alert(" Your Browser Does not Support this Function ! ");
    }
}