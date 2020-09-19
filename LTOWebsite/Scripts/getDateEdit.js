


function GetDate(CtrlName, xPX, yPX) {
    var txtCtl = document.Form1.elements[CtrlName].disabled;
    if (txtCtl) {
        document.Form1.elements[CtrlName].readOnly = txtCtl;
    }
    else {
        ChildWindow = window.open('../BaseCalendar.aspx?FormName=' + document.forms[0].name + '&CtrlName=' + CtrlName, "GetDatePage", "width=300 height=250, top=" + xPX + ", left=" + yPX + ", titlebar=no, toolbars=no, scrollbars=no,status=no,resizable=no,close=no");
        ChildWindow.focus();
    }
}

function GetDatePoP(CtrlName, xPX, yPX) {
    try { //debugger   
        var txtCtl = document.Form1.elements[CtrlName].disabled;
        if (txtCtl) {
            document.Form1.elements[CtrlName].readOnly = txtCtl;
        }
        else {
            //var myReturnValue =  window.showModalDialog('BaseCalendar.aspx?FormName=' + document.forms[0].name + '&CtrlName=' + CtrlName, window, "width=200 height=150, top=" + xPX + ", left=" + yPX + ", titlebar=no, toolbars=no, scrollbars=no,status=no,resizable=no,close=no" );
            var myReturnValue = window.showModalDialog('../CommonPages/BaseCalendar3.aspx?FormName=' + document.forms[0].name + '&CtrlName=' + CtrlName, window, "unadorned:no;scroll:no;resizable:no;help:no;status:no;dialogTop:" + xPX + ";dialogLeft:" + yPX + ";dialogHeight:250px;dialogWidth:280px");
            if (myReturnValue == null) { // return false;
                //window.alert("Nothing returned from child. No changes made to input boxes")
            }
            else {
                document.getElementById(CtrlName).value = myReturnValue;
            }
        }
    }

    catch (e) { }
}


function GetDatePoP3(CtrlName, xPX, yPX) {
    try { //debugger   
        var txtCtl = document.Form1.elements[CtrlName].disabled;
        if (txtCtl) {
            document.Form1.elements[CtrlName].readOnly = txtCtl;
        }
        else {
            //var myReturnValue =  window.showModalDialog('BaseCalendar.aspx?FormName=' + document.forms[0].name + '&CtrlName=' + CtrlName, window, "width=200 height=150, top=" + xPX + ", left=" + yPX + ", titlebar=no, toolbars=no, scrollbars=no,status=no,resizable=no,close=no" );
            var myReturnValue = window.showModalDialog('../CommonPages/BaseCalendar3.aspx?FormName=' + document.forms[0].name + '&CtrlName=' + CtrlName, window, "unadorned:no;scroll:no;resizable:no;help:no;status:no;dialogTop:" + xPX + ";dialogLeft:" + yPX + ";dialogHeight:250px;dialogWidth:280px");
            if (myReturnValue == null) { // return false;
                //window.alert("Nothing returned from child. No changes made to input boxes")
            }
            else {
                document.getElementById(CtrlName).value = myReturnValue;
            }
        }
    }

    catch (e) { }
}

function UndoSignOff3(CtrlName, CtrlName2) {
    try { //debugger   
        var txtCtl = document.Form1.elements[CtrlName];
        var txtCtl2 = document.Form1.elements[CtrlName2];
        if (txtCtl !== null)
            txtCtl.value = "";
        if (txtCtl2 !== null)
            txtCtl2.value = "";

    }

    catch (e) { }
}
function GetDate2(CtrlName, xPX, yPX) {
    //debugger
    var txtCtl = document.forms[0].elements[CtrlName].disabled;
    if (txtCtl) { document.forms[0].elements[CtrlName].readOnly = txtCtl; }
    else {
        var MyReturnValue = window.showModalDialog('../CommonPages/BaseCalendar3.aspx?FormName=' + document.forms[0].name + '&CtrlName=' + CtrlName, window, "scroll:no;resizable:no;help:no;status:no;dialogTop:" + xPX + ";dialogLeft:" + yPX + ";dialogHeight:230px;dialogWidth:250px");
        if (MyReturnValue === null) { // return false; //window.alert("Nothing returned from child. No changes made to input boxes")
        }
        else {
            var _datePre;
            var toDayDate = document.getElementById("LabelToday").innerText;
            if (CtrlName == "datePre") {
                if (MyReturnValue <= toDayDate)
                    document.forms[0].elements[CtrlName].value = MyReturnValue;
                else { window.alert("Date must be earlier than or equal to today's Date"); }
            }
            if (CtrlName == "dateClass") {
                _datePre = document.getElementById("datePre").value;
                if (MyReturnValue >= _datePre) {
                    if (MyReturnValue <= toDayDate)
                        document.forms[0].elements[CtrlName].value = MyReturnValue;
                    else
                        window.alert("Date must be earlier than or equal to today's Date");
                }
                else { window.alert("Classroom Observation Date must be later than or equal to Pre Observation Date"); }
            }
            if (CtrlName == "datePost") {
                 _datePre = document.getElementById("dateClass").value;
                if (MyReturnValue >= _datePre) {
                    if (MyReturnValue <= toDayDate)
                        document.forms[0].elements[CtrlName].value = MyReturnValue;
                    else
                        window.alert("Date must be earlier than or equal to today's Date");
                }
                else { window.alert("Post Observation Date must be later than or equal to Classroom Observation Date"); }
            }

        }

    }
}


function GetDatePanel(CtrlName, xPX, yPX) {
    ChildWindow = window.open('BaseCalendar.aspx?FormName=' + document.forms[0].name + '&CtrlName=' + CtrlName, "GetDatePage", "width=260 height=220, top=" + xPX + ", left=" + yPX + ", titlebar=no, toolbars=no, scrollbars=no,status=no,resizable=no,close=no");
    ChildWindow.focus();

}

