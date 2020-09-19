

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
   
   function IdentifyUserOLog(CtrlName1,CtrlName2)
		{   var tab = igtab_getTabById("UltraWebTab2")
		    var t =   tab.Tabs[1];
		    var imgCtl =  document.Form1.elements[CtrlName2]; 
		    if (t.getEnabled()) //    imgCtl == "./Images/TeacherLogin.gif" )
	          { imgCtl.src="../Images/TeacherLogin.gif";
	            changeEnable();
	           }
	        else
	          { var MyIdentify  = window.showModalDialog('../CommonPages/BaseIdentify3EnableTeacherTab.aspx', window, "scroll:no;resizable:no;help:no;status:no;dialogTop:250;dialogLeft:200;dialogHeight:200px;dialogWidth:350px" );
                if (MyIdentify != null )
                   {if (MyIdentify == "OK")
                       { imgCtl.src="../Images/TeacherLogout.gif";
                         changeEnable();
                       }
                   }     
	          }   
		}  
   function changeEnable()
      { var i = 1;
        var tab = igtab_getTabById("UltraWebTab2");
        if(tab != null)
          {var t = tab;
           if(i >= 0 && i < 5) t = tab.Tabs[i];
                t.setEnabled(!t.getEnabled());
          }
       }  
 ///document.onmousemove = captureMousePosition;

//xMousePos = 0; // Horizontal position of the mouse on the screen
//yMousePos = 0; // Vertical position of the mouse on the screen
//xMousePosMax = 0; // Width of the page
//yMousePosMax = 0; // Height of the page


// function captureMousePosition(e) {
//        xMousePos = window.event.x+document.body.scrollLeft;
//        yMousePos = window.event.y+document.body.scrollTop;
//        xMousePosMax = document.body.clientWidth+document.body.scrollLeft;
//        yMousePosMax = document.body.clientHeight+document.body.scrollTop;
//    window.status = "xMousePos=" + xMousePos + ", yMousePos=" + yMousePos + ", xMousePosMax=" + xMousePosMax + ", yMousePosMax=" + yMousePosMax;
//}

 
var DragObj;
var DragCell;
var DragScop; 
function UltraWebGrid1_InitializeRowHandler(gridName, rowId)
        { var mGrid = igtbl_getGridById(gridName);
	       var Row = igtbl_getRowById(rowId);	
	       var checkDate =  Row.cells[3].getValue ;
	       if (checkDate != null)
	          { Row.cells[1].Element.style.color ="red";
	            Row.cells[2].Element.style.color ="red";
              }  
        }     
       
function UltraWebGrid1_MouseDownHandler(gridName, id, button)
{  //  debugger    
        
         if (id =="UltraWebGrid1_c_0_1")
	        {DragdropEvidenceLogClear(); }
         else
            { if (id =="UltraWebGrid1_c_0_2")
	             {DragScop ="All";
                  DragObj = gridName; 
 	              MoveDragTextBox("Copy over all Evidence Log");
                 }   
	          else
	             {var cell=igtbl_getCellById(id);
	              var column=cell.Column;
                  if(column.Key == "Notes")
	                // {if(cell.NextSibling.innerText == " ") 
	                     {DragObj = gridName;
	                      DragCell  = id; 
	                      DragScop = "One";  
	                      MoveDragTextBox( cell.getValue() );
	                     }
	                 // else
	                 //    { DragdropEvidenceLogClear();}  
	                // }
 	            }
	        } 
  }
function MoveDragTextBox( _text )
{ 
		      var dragtext =  document.getElementById("DragDropText");
              dragtext.innerHTML =  _text ;//  cell.getValue(); 
	          dragtext.className = "bubbleS show";	                      
              var xMousePos = window.event.x // + document.body.scrollLeft;
              var yMousePos = window.event.y //  +document.body.scrollTop;
              var topP =  document.getElementById("topPosition").value;
              var yPos
              var xPos = 580;
                            if (topP == "1" )
     		                   yPos = 220 ; 
                            if (topP == "2" )
     		                    yPos =  215 ; 
                            if (topP == "3" )
     		                   yPos =   280 ; 
                            if (topP == "4" )
     		                   yPos = 180 ; 
                            if (topP == "5" )
     		                  yPos =  75 ; 
                            if (topP == "6" )
     		                  yPos =   75 ; 
     		                if (topP == "11" )
     		                   {yPos = 182 ; xPos = 565;}
                            if (topP == "12" )
     		                   { yPos =  103 ;  xPos = 580;}
                            if (topP == "13" )
     		                   { yPos =  180 ; xPos = 565;}
     		                    
     		    dragtext.style.top  =  yMousePos + yPos ;      
 		        dragtext.style.left =  xMousePos + xPos ; //  offsetLeft ;// "600px" ;// mousePosI.x;
 	            makeDraggable(dragtext);
	            dragtext.onmousedown();
}

function UltraWebGrid1_MouseUpHandler(gridName, id, button)
{
	DragdropEvidenceLogClear()
	 var dragtext =  document.getElementById("DragDropText"); 
	 dragtext.innerHTML =  "Drag Drop Text"; 
	 dragtext.className = "bubble hide";
}
function  DragdropEvidenceLog()
{   if (DragScop =="All")
        {GetEvidenceLogAll(DragObj);}
    if (DragScop =="One")
        {GetEvidenceLogOne(DragObj, DragCell);}
   DragdropEvidenceLogClear() 
        
}
function  DragdropEvidenceLogClear()
{ 
    DragObj=null;
    DragCell=null;
    DragScop=null;     
    var dragtext =  document.getElementById("DragDropText"); 
	dragtext.innerHTML =  "Drag Drop Text"; 
	dragtext.className = "bubble hide";
        
}
function UltraWebGrid1_CellClickHandler(gridName, cellId, button)
 {   
     var cell=igtbl_getCellById(cellId);
	 var column=cell.Column;
     if(column.Key == "Notes")
	    {   GetEvidenceLogOne(gridName, cellId); 
	    }
	DragdropEvidenceLogClear()  ;       
}
function UltraWebGrid1_ColumnHeaderClickHandler(gridName, columnId, button)
{ if (columnId =="UltraWebGrid1_c_0_2")
	   {GetEvidenceLogAll(gridName); }
  DragdropEvidenceLogClear()  ;
}

function UltraWebGrid1_DblClickHandler1(gridName, cellId)
{
	     if (cellId =="UltraWebGrid1_c_0_1")
	         {DragObj=null;}
	     else
	        {if (cellId =="UltraWebGrid1_c_0_2")
	            {GetEvidenceLogAll(gridName);
	            }
	         else	 
	            {var cell=igtbl_getCellById(cellId);
	             var column=cell.Column;
                 if(column.Key == "Notes")
	                { 
	                    GetEvidenceLogOne(gridName, cellId);
	                }
 	            }
	        }
	  DragdropEvidenceLogClear()  ;   
	    
}
 

function GetEvidenceLogOne(gridName, cellId)
{
    try    
       {var SignOff = document.getElementById("bSignOff").value;
        var cRole = document.getElementById("ccUserRole").value;
         var cell=igtbl_getCellById(cellId);
        if ((cRole == "Principal") && (SignOff != "True"))
           {  var row=igtbl_getRowById(cellId);
		      //if(row.cells[3].getValue() == null )
		           var myText = document.getElementById("MyText");
 		             myText.value   += "\n" + cell.getValue() +  "\n" ; 
		             cell.Element.style.color ="red";
		             var Today1  = row.cells[4].getValue();  // new Date(); 
		             row.cells[3].setValue(Today1);  //  row.cells[0].Value = _Gr;
		             row.cells[2].Element.style.color ="red"; 
 		             setTextChange();     
                    
      
           }
       }
    catch (e)
      {} 

}
function  GetEvidenceLogAll(gridName)
{ //debugger
        var SignOff = document.getElementById("bSignOff").value;
        var cRole = document.getElementById("ccUserRole").value;
        if ((cRole == "Principal") && (SignOff != "True"))
             {var myText = document.getElementById("MyText"); 
              var myGrid = igtbl_getGridById(gridName);
              for(var i = 0; i < myGrid.Rows.length; i++)
                  {var row = myGrid.Rows.getRow(i);  
                  // if (row.getCell(3).getValue() == null )
                      var Today = row.getCell(4).getValue() ; // new Date();
                       row.getCell(3).setValue(Today);
                       myText.value   += "\n" +  row.getCell(2).getValue() + "\n" ; 
                       row.getCell(2).Element.style.color ="red"; 
                       setTextChange();  
                      // sTextCell =null;
                      
                  } 
            
             }
    
}
 
  function setTextChange()
     {  //debugger
        document.getElementById("txtContextChange").value ="1";
     } 
     
     