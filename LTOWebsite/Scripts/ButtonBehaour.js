function Close()            
		{
			window.close();        
		}			

function setMyCtlImage(myCtl)	
   { try  
         { var ctl =  document.getElementById(myCtl);  
            ctl.src="./images/studentS.bmp";
         }
    catch (e)
         {}
   }              
function getMyCtlImage(myCtl)
   { try  
         { var ctl =  document.getElementById(myCtl);  
            ctl.src="./images/student.bmp";
         } 
    catch (e)
         {}
   }              	  
        
function setMyBoard(myCtl)
   { try  
        {  var ctl = document.getElementById(myCtl);  
	 	   ctl.border ="1";
		} 
    catch (e)
         {}
   }              
		
function getMyBoard(myCtl)
   { try  
        {  var ctl =  document.getElementById(myCtl);  
		    ctl.border ="0";
		}      
    catch (e)
         {}
   }              
		     	  		
function setMyBoardColor(myCtl)
   { try  
       { var ctl =  document.getElementById(myCtl);  
		  ctl.border ="2"; 
		} 
    catch (e)
         {}
   }              
		
function getMyBoardColor(myCtl)
   { try  
        { var ctl =  document.getElementById(myCtl);  
		  ctl.border ="0";
		}   
    catch (e)
         {}
   }              
		
function setFont(sender, oCSS)
{try
   {  // debugger
     // var ctl =  document.getElementById(sender);
       sender.className = oCSS;
        var myoText = document.getElementById("MyText");  
        myoText.onchange=""; 

   }
 catch (e)
   {}
}






function setImg(sender, oCSS) {
    try {  // debugger
        // var ctl =  document.getElementById(sender);
        sender.className = oCSS;
      

    }
    catch (e)
   { }
}
	
function setLink(sender, oCSS) {
    /// <summary>set up a button behaivour when Mouse action  </Summary>
    ///<Param name = "sender" type="button"> The Event object as control object</Param>
    ///<Param name = "oCSS" type="string"> The Event object Style sheet object object</Param>
    try
   {  //debugger
       this.sender = sender;
       this.oCSS = oCSS;
    var myObj = document.getElementById(sender);  
   //  myObj.className = oCSS;
    if (oCSS == "LinkMouseOver")
         { myObj.style.textDecorationOverline = true;}
    else
        { myObj.style.textDecorationOverline = false;}
   }
 catch (e)
   {}  
}

function Event1(name, date, location) {
    /// <Summary> this  event function</Summary>
    ///<Param name ="name" type ="string"> then evemt name as string</Param>
    ///<Param name ="date" type ="string"> then evemt date as string</Param>
    ///<Param name ="location" type ="string"> then evemt location as string</Param>

    this.name = name;
    this.date = date;
    this.location = location;
    
}
function openPrintPage(vHeight,vWidth) {

    $(document).ready(function () {
        try {
            $("#PrientListDIV").css({
                top: mouse_y + 10,
                left: mouse_x - (vWidth +15 ),
                height: vHeight,
                width: vWidth
            })
            $("#PrientListDIV").fadeToggle("slow");
        }
        catch (e) { }

    });

}
function openPrintPage2() {

    try {
        var PrintMenu = $("#PrientListDIV"); //  document.getElementById("PrientBubbleHelpDIV");
        if (PrintMenu.attr("class") == "bubble show")
        { PrintMenu.attr("class", "bubble hide"); }
        else {
            PrintMenu.attr("class", "bubble show");
            PrintMenu.css({
                top: mouse_y + 10,
                left: mouse_x - 220,
                height: "110",
                width: "200"
            });
        }
    }
    catch (e) { }
}