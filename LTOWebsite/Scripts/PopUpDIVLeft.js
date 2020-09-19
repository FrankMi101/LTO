
var DisableAction;
function PopUpDIV() {
    if (DisableAction != '1') {
        DisableAction = '1';
        el = document.getElementById("PopUpDIV");
        el.style.visibility = (el.style.visibility == "visible") ? "hidden" : "visible";
    }
}
function PopUpDIV1() {
    el = document.getElementById("PopUpDIV");
    el.style.visibility = (el.style.visibility == "visible") ? "hidden" : "visible";
    DisableAction = '0';
}

function PopUpDIV2() {
    el = parent.document.getElementById("PopUpDIV");
    el.style.visibility = (el.style.visibility == "visible") ? "hidden" : "visible";
    DisableAction = '0';
}

function PopUpDIV3() {
    el = parent.parent.document.getElementById("PopUpDIV");
    el.style.visibility = (el.style.visibility == "visible") ? "hidden" : "visible";
    DisableAction = '0';
}