var IE = document.all ? true : false;
document.onmousemove = getMousepoints; //deepak this is to identify mouse event  

var mouse_x = 0;
var mouse_y = 0;
function getMousepoints() {
    try {
        mouse_x = event.clientX + document.body.scrollLeft;  //to get client window X axis
        mouse_y = event.clientY + document.body.scrollTop; //to get client window Y axis 
        return true;
    }
    catch (ex)
    { var ms = ""; }
   
}

function IECompatibility() {
    var agentStr = navigator.userAgent;
    this.IsIE = false;
    this.IsOn = undefined;  //defined only if IE
    this.Version = undefined;
    this.Compatible = undefined;

    if (agentStr.indexOf("compatible") > -1) {
        this.IsIE = true;
        this.IsOn = true;
        this.Compatible = true;
    }
    else {
        this.Compatible = false;
    }

}
function IEVersion() {
    var agentStr = navigator.userAgent;
    this.IsIE = false;
    this.IsOn = undefined;  //defined only if IE
    this.Version = undefined;

    if (agentStr.indexOf("MSIE 7.0") > -1) {
        this.IsIE = true;
        this.IsOn = true;
        if (agentStr.indexOf("Trident/7.0") > -1) {
            this.Version = 'IE11';
        } else if (agentStr.indexOf("Trident/6.0") > -1) {
            this.Version = 'IE10';
        } else if (agentStr.indexOf("Trident/5.0") > -1) {
            this.Version = 'IE9';
        } else if (agentStr.indexOf("Trident/4.0") > -1) {
            this.Version = 'IE8';
        } else {
            this.IsOn = false; // compatability mimics 7, thus not on
            this.Version = 'IE7';
        }
    } //IE 7

}