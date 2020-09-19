var IE = document.all ? true : false
document.onmousemove = getMousepoints; //deepak this is to identify mouse event 
var mouse_x = 0;
var mouse_y = 0;
function getMousepoints() {
    $(document).ready(function () {
        try {
            mouse_x = event.clientX + document.body.scrollLeft //to get client window X axis 
            mouse_y = event.clientY + document.body.scrollTop//to get client window Y axis 
            return true;
        }
        catch (e) { }

    });
}

var WorkingOnChartID
var WorkingOnChartIDs
var WorkingOnChartControl

function AddDIPChart(_action, txtID, _IDs, _ChartID, _elementID) {
  //  var retrieveDIP = document.getElementById("btnRetrieveDIP");
  //  retrieveDIP.click();
    var myiFrame = document.getElementById("iframeChart");
    var ev = window.event;
    WorkingOnChartControl = txtID;
    WorkingOnChartID = _ChartID;
    WorkingOnChartIDs = _IDs;
    _element = document.getElementById(_elementID);
    var HelpObject = document.getElementById("BubbleHelpText")
    var indicator = document.getElementById("lblIndicators1")
    if (HelpObject.className == "bubble show") {
        HelpObject.className = "bubble hide";
        myiFrame.src = "";
    }
    else {
        HelpObject.className = "bubble show";
    }

    if (HelpObject.className == "bubble show") {
        mouse_x = _element.offsetLeft + _element.offsetWidth + 500;
        HelpObject.style.position = 'absolute';
        HelpObject.style.top = 5; //mouse_y // +228;
        if (_action == "L")
        { HelpObject.style.left = 250; }  // mouse_x;
        else
        { HelpObject.style.left = 250; }  // mouse_x;
        HelpObject.style.height = 580;
        HelpObject.style.width = 480;

        myiFrame.src = "LearningGoal_11Chart.aspx?ChartID=" + _ChartID + "&IDs=" + _IDs;
    }


}
function AddDIPChartToCohort(_action, txtID, _IDs, _ChartID, _elementID) {
    //  var retrieveDIP = document.getElementById("btnRetrieveDIP");
    //  retrieveDIP.click();
    var myiFrame = document.getElementById("iframeChart");
    var ev = window.event;
    WorkingOnChartControl = txtID;
    WorkingOnChartID = _ChartID;
    WorkingOnChartIDs = _IDs;
    _element = document.getElementById(_elementID);
    var HelpObject = document.getElementById("BubbleHelpText")
    var indicator = document.getElementById("lblIndicators1")
    if (HelpObject.className == "bubble show") {
        HelpObject.className = "bubble hide";
        myiFrame.src = "";
    }
    else {
        HelpObject.className = "bubble show";
    }

    if (HelpObject.className == "bubble show") {
        mouse_x = _element.offsetLeft + _element.offsetWidth + 500;
        HelpObject.style.position = 'absolute';
        HelpObject.style.top = 5; //mouse_y // +228;
        if (_action == "L")
        { HelpObject.style.left = 250; }  // mouse_x;
        else
        { HelpObject.style.left = 250; }  // mouse_x;
        HelpObject.style.height = 580;
        HelpObject.style.width = 480;

        myiFrame.src = "CohortManage_11AChart.aspx?ChartID=" + _ChartID + "&IDs=" + _IDs;
    }


}
function ShowLargeChart(_action, txtID, _IDs, _ChartID) {
    var ev = window.event;
    WorkingOnChartControl = txtID;
    WorkingOnChartID = _ChartID;
    WorkingOnChartIDs = _IDs;
    var HelpObject = document.getElementById("LargeChart")
    var imgL = document.getElementById("LargeChartImage");
    var imgNo = imgL.src;
    imgL.src = imgNo.replace("DIP-NoData.jpg", _ChartID);



    if (HelpObject.className == "bubble show") {
        imgL.src = imgL.src.replace(_ChartID, "DIP-NoData.jpg");
        HelpObject.className = "bubble hide";
    }
    else {
        HelpObject.className = "bubble show";
    }
    if (HelpObject.className == "bubble show") {

        HelpObject.style.position = 'absolute';
        HelpObject.style.top = 60; //mouse_y // +228; 	         
        HelpObject.style.left = 210;
        HelpObject.style.height = 505;
        HelpObject.style.width = 605;
    }


}
function ShowHelp(_action, txtID, _elementID) {

    var ev = window.event;
    _element = document.getElementById(_elementID);
    var HelpObject = document.getElementById("BubbleHelpText")
    var indicator = document.getElementById("lblIndicators1")
    if (HelpObject.className == "bubble show") {
        HelpObject.className = "bubble hide";
        //  indicator.className = "IndicatoerLabel2";
    }
    else {
        HelpObject.className = "bubble show";
        //  indicator.className = "IndicatoerLabel1";

    }

    if (HelpObject.className == "bubble show") { //  if (_action == "Show") {
        // HelpObject.className = "bubble show";
        // var _helpText = WebServiceHelpText.getHelpText(txtID)  ;
        //  HelpObject.innerHTML =  _helpText ; 

        //   var helpText = document.getElementById("HelpText");
        //   helpText.src = "../CommonPages/BaseIndicators.aspx" + "?hID=" + txtID;
        //	            var LabXY = getAbsolutePosition(_element)   ;
        mouse_x = _element.offsetLeft + _element.offsetWidth + 500;

        // 	        if (mouse_y > 500)
        // 	           { mouse_y = mouse_y - 150; }
        // 	        else {
        // 	            if (mouse_y > 400)
        // 	               { mouse_y = mouse_y - 100; }
        // 	            else
        // 	               { mouse_y = mouse_y - 20; }
        // 	             }
        HelpObject.style.position = 'absolute';
        HelpObject.style.top = 5; //mouse_y // +228;
        if (_action == "L")
        { HelpObject.style.left = 300; }  // mouse_x;
        else
        { HelpObject.style.left = 10; }  // mouse_x;
        HelpObject.style.height = 500;
        HelpObject.style.width = 480;
    }

    // 	    else {
    // 	        HelpObject.className = "bubble hide";
    // 	        // HelpObject.innerHTML = "Bubble Help Text";


}
function getAbsolutePosition(element) {
    var ret = new Point();
    for (;
        element && element != document.body;
        ret.translate(element.offsetLeft, element.offsetTop), element = element.offsetParent
        );

    return ret;
}

function Point(x, y) {
    this.x = x || 0;
    this.y = y || 0;
    this.toString = function() {
        return '(' + this.x + ', ' + this.y + ')';
    };
    this.translate = function(dx, dy) {
        this.x += dx || 0;
        this.y += dy || 0;
    };
    this.getX = function() { return this.x; }
    this.getY = function() { return this.y; }
    this.equals = function(anotherpoint) {
        return anotherpoint.x == this.x && anotherpoint.y == this.y;
    };
}


	  
	  
	       