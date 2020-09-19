

    var _StatePanel = "open" ;
    var _cImg ;
    function Panel()
      {// debugger
        var myMenu = document.getElementById("iepmenutree") 
        var myimg = document.getElementById("panelimg") 
        if (_StatePanel == "open")
           { myMenu.style.width ="0px";
             myimg.src ="../images/closeMenu.bmp";
             myimg.title ="Show the EvidenceLog";
             _StatePanel ="close";
           } 
        else
           { myMenu.style.width ="250px";
             myimg.src ="../images/openMenu.bmp";
             myimg.title ="Hide the EvidenceLog";
            _StatePanel ="open";
            
           }
      }
  function PanelChange(_op)
  {  var myimg = document.getElementById("panelimg") 
     if (_op =="over")
        { if (_StatePanel == "open")
             myimg.src ="../images/openMenu_over.bmp";
          else
             myimg.src ="../images/closeMenu_over.bmp"; 
        }
     else
        { if (_StatePanel == "open")
            myimg.src ="../images/openMenu.bmp";
         else
            myimg.src ="../images/closeMenu.bmp";    
        }        
  }    
   

 
var DragObj;
var DragCell;
var DragScop;
var dragdropDIVText = null;
 
function Indicator_MouseDownHandler()
{  //  debugger

    var ev = window.event;
    var obj = ev.srcElement.id;
    vDIV = document.getElementById(obj);
    dragdropDIVText = vDIV.innerHTML;
	      MoveDragTextBox(dragdropDIVText);
	                 
  }
function MoveDragTextBox( _text )
{ 
		      var dragtext =  document.getElementById("DragDropText");
              dragtext.innerHTML =  _text ;//  cell.getValue(); 
	          dragtext.className = "bubbleS show";
	          DragObj = dragtext;
              DragScop = "One";
              var xMousePos = window.event.x // + document.body.scrollLeft;
              var yMousePos = window.event.y //  +document.body.scrollTop;
              var topP = "1" //  document.getElementById("topPosition").value;
              var yPos = 10
              var xPos =  10;
                           
     		   dragtext.style.top = yMousePos + yPos ;
     		   dragtext.style.left = xMousePos + xPos ; //  offsetLeft ;// "600px" ;// mousePosI.x;
 	            makeDraggable(dragtext);
	            dragtext.onmousedown();
}

function Indicator_MouseUpHandler()
{
    DragDropTextClear()
	 var dragtext =  document.getElementById("DragDropText"); 
	 dragtext.innerHTML =  "Drag Drop Text"; 
	 dragtext.className = "bubble hide";
}



function DragDropTextClear()
{ 
    DragObj=null;
    DragCell=null;
    DragScop=null;     
    var dragtext =  document.getElementById("DragDropText"); 
	dragtext.innerHTML =  "Drag Drop Text";
	dragtext.className = "bubble hide";
	dragdropDIVText = null;
        
}
function GetDragDropText()
{
    try {
          if (dragdropDIVText != null)
             { var myText = document.getElementById("MyText");
		           myText.value += "\n" + dragdropDIVText + "\n"; 
 		            setTextChange();
 		         DragDropTextClear();
 		     }          
        }
    catch (e)
      {} 

}
 
 
  function setTextChange()
     {  //debugger
        document.getElementById("txtContextChange").value ="1";
     } 
     
     