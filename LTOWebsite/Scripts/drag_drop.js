// JScript File

  
document.onmousemove = mouseMove;
document.onmousedown = mouseDown;
document.onmouseup = mouseUp;
var dragObject  = null;
var mouseOffset = null;
 

function mouseCoords(ev)
{
	if(ev.pageX || ev.pageY){
		return {x:ev.pageX, y:ev.pageY};
	}
	return {
		x:ev.clientX + document.body.scrollLeft - document.body.clientLeft,
		y:ev.clientY + document.body.scrollTop  - document.body.clientTop
	};
}
function makeClickable(object)
{ 
	object.onmousedown = function()
	{  
		dragObject = this;
	}
}
function mouseDown(ev)
{if(dragObject){// debugger
//		dragObject.style.position = 'absolute';
//		dragObject.style.top      = mousePos.y - mouseOffset.y;
//		dragObject.style.left     = mousePos.x - mouseOffset.x;

	//	return false;
	}	
}  
function mouseUp(ev){
	dragObject = null;
}
 function getMouseOffset(target, ev)
{
	ev = ev || window.event;

	var docPos    = getPosition(target);
	var mousePos  = mouseCoords(ev);
	return {x:mousePos.x - docPos.x, y:mousePos.y - docPos.y};
}

function getPosition(e)
{
	var left = 0;
	var top  = 0;

	while (e.offsetParent){
		left += e.offsetLeft;
		top  += e.offsetTop;
		e     = e.offsetParent;
	}

	left += e.offsetLeft;
	top  += e.offsetTop;

	return {x:left, y:top};
}
 
function mouseMove(ev)
{
	ev           = ev || window.event;
	var mousePos = mouseCoords(ev);

	if(dragObject){// debugger
		dragObject.style.position = 'absolute';
		dragObject.style.top      = mousePos.y - mouseOffset.y;
		dragObject.style.left     = mousePos.x - mouseOffset.x;

		return false;
	}
} 

function makeDraggable(item)
{
	if(!item) return;
    item.onmousedown = function (ev) {
        dragObject = item; //this;
        mouseOffset = getMouseOffset(item, ev) // (this, ev);
        return false;
    };
}
 

//var dropTargets = []; 

//function addDropTarget(dropTarget){
//	dropTargets.push(dropTarget);
//}

//function mouseUp(ev){
//	ev           = ev || window.event;
//	var mousePos = mouseCoords(ev);

//	for(var i=0; i<dropTargets.length; i++){
//		var curTarget  = dropTargets[i];
//		var targPos    = getPosition(curTarget);
//		var targWidth  = parseInt(curTarget.offsetWidth);
//		var targHeight = parseInt(curTarget.offsetHeight);

//		if(
//			(mousePos.x > targPos.x)                &&
//			(mousePos.x < (targPos.x + targWidth))  &&
//			(mousePos.y > targPos.y)                &&
//			(mousePos.y < (targPos.y + targHeight))){
//				// dragObject was dropped onto curTarget!
//		}
//	}

//	dragObject   = null;
//}

