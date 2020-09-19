//var myPassText;
  var ProgressWindow;

function openProgress()
	{ 
		try
		   {  
 	       ProgressWindow = window.open("BaseProgressClock.aspx", "ProgressPage", "width=300 height=150 top=250, left=250, toolbars=no, scrollbars=no,status=no,resizable=no,help=no" );
           }
        catch (e)
           {
            return;
           }    
	}
function closeProgress()
   { 
      try 
          {
           if (ProgressWindow==null)
              return;
           else
              if(false == ProgressWindow.closed) 
                 ProgressWindow.close(); 
           }
      catch (e)
         { 
           return;
         } 
    }

function IdentifyUserO3(CtrlName,CtrlName2,CtrlName3)
	{   
	 //debugger
      //	ChildWindow = window.open('../CommonPages/BaseIdentify3EnableTeacherBox.aspx?FormName=' + document.forms[0].name + '&CtrlName=' + CtrlName+ '&CtrlName2=' + CtrlName2+ '&CtrlName3=' + CtrlName3, "IdentifyUserO", "width=350 height=200, top=250, left=200, toolbars=no, scrollbars=no,status=no,resizable=no" );
		var mytxtCell = document.getElementById("myTextCell") ;
		var txtCtl =  document.Form1.elements[CtrlName].readOnly ; 
		if (txtCtl)
	        { var MyVerify  = window.showModalDialog('../CommonPages/BaseIdentify3EnableTeacherBox.aspx?FormName=' + document.forms[0].name, window, "scroll:no;resizable:no;help:no;status:no;dialogTop:400;dialogLeft:420;dialogHeight:200px;dialogWidth:300px" );
              if (MyVerify != null)
  	   	          if ( MyVerify =="Yes" )
			   	         {
			   	          document.Form1.elements[CtrlName].readOnly  = false ;
			   	          document.Form1.elements[CtrlName2].src="../Images/AppraiseeLogout.gif" ;
			   	          mytxtCell.className = "TextCellEditBG";
			   	        //  document.Form1.elements[CtrlName3].disabled = false;
 			   	         }
 	              else 
 	                 document.Form1.elements[CtrlName].readOnly  = true ;  
  	        }   
	    else
	        {
	           document.Form1.elements[CtrlName].readOnly  = true ;
	           document.Form1.elements[CtrlName2].src = "../Images/AppraiseeLogin.gif";
	           mytxtCell.className = "TextCellreadonlyBG";
 	        }  
		     
	}
	 
	function IdentifyUserO2(CtrlName,CtrlName1,CtrlName2)
		{   
		    //debugger
		     var txtCtl =  document.Form1.elements[CtrlName].disabled ; 
		     if (txtCtl)
	           {
		    	ChildWindow = window.open('../CommonPages/BaseIdentify3EnableTeacherBox.aspx?FormName=' + document.forms[0].name + '&CtrlName=' + CtrlName+ '&CtrlName1=' + CtrlName1 + '&CtrlName2=' + CtrlName2+ '&CtrlName3=SignOff', "IdentifyUserO2", "width=300 height=150, top=250, left=200, toolbars=no, scrollbars=no,status=no,resizable=no" );
	           }
	         else
	           {
	           document.Form1.elements[CtrlName].disabled = true ;
	           document.Form1.elements[CtrlName1].src = "../Images/AppraiseeLogin.gif";
	           document.Form1.elements[CtrlName2].disabled= true;
	           }   
		     
		}   		 

  		function IdentifyUser(ctlNameP,ctlDateP,ctlNameT,ctlDateT)
		{   
		  
			ChildWindow = window.open('BaseIdentify.aspx?FormName=' + document.forms[0].name + '&NameP=' + ctlNameP + '&DateP=' + ctlDateP+ '&NameT=' + ctlNameT+ '&DateT=' + ctlDateT, "IdentifyUser", "width=350 height=250, top=250, left=200, toolbars=no, scrollbars=no,status=no,resizable=no" );
		}   
    
		function IdentifySupervisory(ctlNameP,ctlDateP,ctlNameT,ctlDateT)
		{   
		  
			ChildWindow = window.open('BaseIdentifySupervisory.aspx?FormName=' + document.forms[0].name + '&NameP=' + ctlNameP + '&DateP=' + ctlDateP+ '&NameT=' + ctlNameT+ '&DateT=' + ctlDateT, "IdentifyUser", "width=350 height=250, top=250, left=200, toolbars=no, scrollbars=no,status=no,resizable=no" );
		}   

   function doPostbackPage()
        {
              __doPostBack(me,'');

		}
 
 function VerifyUser(signatureP,dateP,signatureT,dateT)
  {  try
		{ // debugger
		   var MySignature = new Array();
           var MySignature  = window.showModalDialog('../CommonPages/BaseIdentify3.aspx?FormName=' + document.forms[0].name, window, "scroll:no;resizable:no;help:no;status:no;dialogTop:400;dialogLeft:420;dialogHeight:300px;dialogWidth:400px" );
           if (MySignature == null)
			   {//window.alert("Nothing returned from child. No changes made to input boxes")
			   }
 		   else
				{  var P_signature = document.getElementById(signatureP);  
		           var T_signature = document.getElementById(signatureT);  
		           var P_date = document.getElementById(dateP);  
		           var T_date = document.getElementById(dateT); 
		           P_signature.value = MySignature[0];
		           T_signature.value = MySignature[1];
		           P_date.value = MySignature[2];
		           T_date.value = MySignature[2];
		           
		         
 				}	
		}   
	catch (e)
	   {}
 }	
  
 function VerifyUserT(signatureP,dateP,signatureT,dateT)
  {  try
		{ // debugger
		   var MyVerify ;
           var MyVerify  = window.showModalDialog('../CommonPages/BaseIdentifyUser3.aspx?FormName=' + document.forms[0].name, window, "scroll:no;resizable:no;help:no;status:no;dialogTop:400;dialogLeft:420;dialogHeight:220px;dialogWidth:300px" );
           if (MyVerify == null)
			   {//window.alert("Nothing returned from child. No changes made to input boxes")
			   }
 		   else
				{  var P_signature = document.getElementById(signatureP);  
		           var T_signature = document.getElementById(signatureT);  
		           var P_date = document.getElementById(dateP);  
		           var T_date = document.getElementById(dateT); 
		           var vBool = true
		           if (MyVerify == "False")
		             { vBool = false; }
		           P_signature.disabled =  vBool;
		           T_signature.disabled =  vBool;
		           P_date.disabled =  vBool;
		           T_date.disabled =  vBool;
		            
 				}	
		}   
	catch (e)
	   {}
 }	