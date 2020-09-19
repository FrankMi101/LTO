
var ProgressWindow;

//function CallParentPostBack() {
//    try {
//       // parent.document.Script.callPostBack();
//        parent.document.callPostBack();
//    }
//    catch (e) { }

//}

//function callPostBack() {
//    try {
//        window.document.location.reload();
//    }
//    catch (e) { }
//}
// 
function closeIt()
  {
	if ( window.event.clientY < 0 )
	 {  
	    window.open("Logout.aspx","","toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,");					
		// event.returnValue = "You will lose all changes made since your last save & submit.";
     }
  }
function closeIt2()
  {	if ( window.event.clientY < 0 )
	 { window.open("../Logout.aspx","","toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,");					
      }
  }

function openTPA3(myPage)
{
  try
    { window.showModalDialog(myPage, window,"scroll:no;resizable:yes;help:no;status:no;dialogTop:5;dialogLeft:5;dialogHeight:700px;dialogWidth:1030px");
	 
	//	var popup1 = window.open(myPage, "","toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=yes,width=1000 height=650, top=100, left=20");				
	//	if (popup1==null)
	//	{	return;}		
 
	//		top.opener = top; 
	//	top.window.close();
	}
  catch (e)
   {}	

}
function openTPA3P(myPage,yID,sID,tID)
{
  try
    { window.showModalDialog( myPage +"?yID=" + yID + "&sID=" + sID + "&tID=" + tID , window,"scroll:no;resizable:yes;help:no;status:no;dialogTop:2;dialogLeft:2;dialogHeight:740px;dialogWidth:1000px");
	 // window.showModalDialog("LoadingAppraisal.aspx?pID="+ myPage +"&yID=" + yID + "&sID=" + sID + "&tID=" + tID, window,"scroll:yes;resizable:yes;help:no;status:no;dialogTop:50;dialogLeft:10;dialogHeight:700px;dialogWidth:1030px");
	 
	//	var popup1 = window.open(myPage, "","toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=yes,width=1000 height=650, top=100, left=20");				
	//	if (popup1==null)
	//	{	return;}		
 
	//		top.opener = top; 
	//	top.window.close();
	}
  catch (e)
   {}	

}
function openTPA3A(myPage,yID,sID,tID)
{
  try
    { window.showModalDialog( myPage +"?yID=" + yID + "&sID=" + sID + "&tID=" + tID  +"&ALP=Yes", window,"scroll:no;resizable:yes;help:no;status:no;dialogTop:2;dialogLeft:2;dialogHeight:750px;dialogWidth:1000px");
	 // window.showModalDialog("LoadingAppraisal.aspx?pID="+ myPage +"&yID=" + yID + "&sID=" + sID + "&tID=" + tID, window,"scroll:yes;resizable:yes;help:no;status:no;dialogTop:50;dialogLeft:10;dialogHeight:700px;dialogWidth:1030px");
	 
	//	var popup1 = window.open(myPage, "","toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=yes,width=1000 height=650, top=100, left=20");				
	//	if (popup1==null)
	//	{	return;}		
 
	//		top.opener = top; 
	//	top.window.close();
	}
  catch (e)
   {}	

}

function openTPA3N(myPage,yID,sID,tID)
{
  try
    { window.showModalDialog( myPage +"?yID=" + yID + "&sID=" + sID + "&tID=" + tID , window,"scroll:yes;resizable:yes;help:no;status:no;dialogTop:2;dialogLeft:2;dialogHeight:750px;dialogWidth:1000px");
 
	}
  catch (e)
   {}	

}
function openPDF0P(myPage,yID,sID,tID)
{
  try
    { window.showModalDialog(myPage +"?yID=" + yID + "&sID=" + sID + "&tID=" + tID , window,"scroll:no;resizable:yes;help:no;status:no;dialogTop:5;dialogLeft:5;dialogHeight:700px;dialogWidth:1030px");
    }
  catch (e)
   {}	

}


function openDocument(pID)
  { try
      {// debugger
  	    window.open("../Attfiles/Loading.aspx?pID=" + pID, "PDFDocument", "width=800 height=600, top=50, left=50, toolbars=no, scrollbars=no,status=no,resizable=no" );
      }
  catch (e)
     {}    
  }  



function openPopUp2(myPage)
  { try
      {// debugger
	   window.showModalDialog(myPage, window,"scroll:no;resizable:yes;help:no;status:no;dialogTop:100;dialogLeft:20;dialogHeight:650px;dialogWidth:1000px");
      }
  catch (e)
     {}    
  }  
function openPopUp(myPage)
  {
   // debugger
	 window.showModalDialog(myPage, window,"scroll:no;resizable:no;help:no;status:no;dialogTop:20;dialogLeft:20;dialogHeight:550px;dialogWidth:750px");

  }  

function openHelpPage(cID,iID)
		{  //debugger 
			//ChildWindow = window.open('BaseHelp.aspx?cID=' + cID + '&iID=' + iID, "HelpPage", "width=630 height=500, top=100, left=50, toolbars=no, scrollbars=no,status=no,resizable=no" );
           	   window.showModalDialog('../CommonPages/BaseHelp.aspx?cID=' + cID + '&iID=' + iID, window,"scroll:no;resizable:no;help:no;status:no;dialogTop:50;dialogLeft:50;dialogHeight:550px;dialogWidth:650px");
		}   
		
function openHelpPageAll(cID,iID)
		{   
			//ChildWindow = window.open('BaseHelp.aspx?cID=' + cID + '&iID=' + iID, "HelpPage", "width=630 height=500, top=100, left=50, toolbars=no, scrollbars=no,status=no,resizable=no" );
           	   window.showModalDialog('../CommonPages/BaseHelpAll.aspx?cID=' + cID + '&iID=' + iID, window,"scroll:no;resizable:no;help:no;status:no;dialogTop:50;dialogLeft:50;dialogHeight:600px;dialogWidth:800px");
		}   
function openDDLEdit(cID)
		{   
			//ChildWindow = window.open('BaseDDLEdit.aspx?cID=' + cID, "DDLEditPage", "width=630 height=500, top=100, left=50, toolbars=no, scrollbars=no,status=no,resizable=no" );
           	   window.showModalDialog('../CommonPages/BaseDDLEdit.aspx?cID=' + cID, window,"scroll:no;resizable:no;help:no;status:no;dialogTop:30;dialogLeft:50;dialogHeight:570px;dialogWidth:730px");

		}

function openFeedBack(pCode,pTitle) {
		    //ChildWindow = window.open('BaseDDLEdit.aspx?cID=' + cID, "DDLEditPage", "width=630 height=500, top=100, left=50, toolbars=no, scrollbars=no,status=no,resizable=no" );
    window.showModalDialog('../CommonPages/BaseFeedBack.aspx?pCode=' + pCode + "&pTitle=" + pTitle, window, "scroll:no;resizable:no;help:no;status:no;dialogTop:30;dialogLeft:50;dialogHeight:500px;dialogWidth:800px");

		}    

   
function GetDate(CtrlName,xPX,yPX)
		{   
		 var txtCtl =  document.Form1.elements[CtrlName].disabled ; 
		     if (txtCtl)
	           {
	           document.Form1.elements[CtrlName].readOnly  = txtCtl ;
	           }
	        else
	           {
			   ChildWindow = window.open('../CommonPage/BaseCalendar.aspx?FormName=' + document.forms[0].name + '&CtrlName=' + CtrlName, "GetDatePage", "width=300 height=250, top=" + xPX + ", left=" + yPX + ", titlebar=no, toolbars=no, scrollbars=no,status=no,resizable=no,close=no" );
	           ChildWindow.focus();
	           }   	
	    }  
 	    
function GetDatePoP(CtrlName,xPX,yPX)
{try
		{ //debugger   
		 var txtCtl =  document.Form1.elements[CtrlName].disabled ; 
		     if (txtCtl)
	           {
	           document.Form1.elements[CtrlName].readOnly  = txtCtl ;
	           }
	        else
	           {
			    //var myReturnValue =  window.showModalDialog('BaseCalendar.aspx?FormName=' + document.forms[0].name + '&CtrlName=' + CtrlName, window, "width=200 height=150, top=" + xPX + ", left=" + yPX + ", titlebar=no, toolbars=no, scrollbars=no,status=no,resizable=no,close=no" );
	            var myReturnValue =  window.showModalDialog('../CommonPage/BaseCalendar.aspx?FormName=' + document.forms[0].name + '&CtrlName=' + CtrlName, window,"unadorned:no;scroll:no;resizable:no;help:no;status:no;dialogTop:" + xPX + ";dialogLeft:" + yPX + ";dialogHeight:250px;dialogWidth:280px");
 	            if (myReturnValue == null)
			    	{ // return false;
				     //window.alert("Nothing returned from child. No changes made to input boxes")
			    	}
		         else
				    { 
				      document.getElementById(CtrlName).value  =  myReturnValue;
				    }
	           }   	
	    }  
 
  catch (e)
      {}
}    	    	    	 
	    	 
 function GetDate2(CtrlName,xPX,yPX)
		{   
		 //debugger
		 var txtCtl =  document.forms[0].elements[CtrlName].disabled ; 
		 if (txtCtl)
	        {document.forms[0].elements[CtrlName].readOnly  = txtCtl ; }
	     else
	        {var MyReturnValue  = window.showModalDialog('../CommonPage/BaseCalendarM.aspx?FormName=' + document.forms[0].name + '&CtrlName=' + CtrlName,   window,"scroll:no;resizable:no;help:no;status:no;dialogTop:" + xPX + ";dialogLeft:" + yPX + ";dialogHeight:230px;dialogWidth:250px");
             if (MyReturnValue == null)
			    { // return false; //window.alert("Nothing returned from child. No changes made to input boxes")
			    }
		     else
				{  
				 var toDayDate  =  document.getElementById("LabelToday").innerText;  
				 if (CtrlName == "datePre" )
				    { 
				      if ( MyReturnValue <= toDayDate )
				          document.forms[0].elements[CtrlName].value   =  MyReturnValue;
				      else
				         {window.alert ("Date must be earlier than or equal to today's Date");}  
				    }  
				 if (CtrlName == "dateClass" )
				    { var _datePre = document.getElementById("datePre").value;
				      if (MyReturnValue >= _datePre ) 
				         {  if ( MyReturnValue <= toDayDate )
				                  document.forms[0].elements[CtrlName].value   =  MyReturnValue;
				            else
				                  window.alert ("Date must be earlier than or equal to today's Date"); 
				         }
 				      else
				         {window.alert ("Classroom Observation Date must be later than or equal to Pre Observation Date");}  
				    }   
				 if (CtrlName == "datePost" )
				    { var _datePre = document.getElementById("dateClass").value;
				      if (MyReturnValue >= _datePre ) 
				         {    if ( MyReturnValue <= toDayDate )
				                  document.forms[0].elements[CtrlName].value   =  MyReturnValue;
				               else
				                  window.alert ("Date must be earlier than or equal to today's Date"); 
				         }
				      else
				         {window.alert ("Post Observation Date must be later than or equal to Classroom Observation Date");}  
				    }        
				  
                } 

 	        }   	
	    }  
	    	 
	    	 
	    	    
function GetDatePanel(CtrlName,xPX,yPX)
		{   
			   ChildWindow = window.open('../CommonPage/BaseCalendar.aspx?FormName=' + document.forms[0].name + '&CtrlName=' + CtrlName, "GetDatePage", "width=260 height=220, top=" + xPX + ", left=" + yPX + ", titlebar=no, toolbars=no, scrollbars=no,status=no,resizable=no,close=no" );
	           ChildWindow.focus();
	          
	    }  
 function LoginASOpen()
		{   
			window.close();    
	 	    ChildWindow = window.open('default.aspx');

		}   
function Close()            
		{
			window.close();        
		}	
		
     
		 
	 
function OpenUserList()
		{   
             window.showModalDialog("UserList.aspx?FormName=" + document.forms[0].name, window,"scroll:no;resizable:yes;help:no;status:no;dialogTop:10;dialogLeft:10;dialogHeight:590px;dialogWidth:790px");
		}    
	 	
 function openRedirectAppl(aID,pID)
		{ 
            window.showModalDialog("BaseRedirectPage.aspx?aID=" + aID + "&pID=" + pID, window,"scroll:no;resizable:yes;help:no;status:no;dialogTop:10;dialogLeft:10;dialogHeight:600px;dialogWidth:800px");
 
		} 

 
         
   function openReportPrintPage(rName,rType,rBlank)
		{   
			   window.open('Report_Print.aspx?rID=' + rName + '&rType=' + rType + '&rBlank=' + rBlank, "PrintForm", "width=800 height=600, top=50, left=50, toolbars=no, scrollbars=no,status=no,resizable=no" );
 	    }  		         
   function  PrintPage()
		{   
			   window.print(); 
 	    }  
 	    
    function openRedirectPage(vType)
		{   
	       	   window.open("RedirectPage.aspx?vType=" + vType, "ReportForm","width=800 height=600, top=5, left=5, toolbars=no, scrollbars=yes,status=no,resizable=yes" );
	       	 //  window.showModalDialog("RedirectPage.aspx", window,"scroll:yes;resizable:yes;help:no;status:no;dialogTop:100;dialogLeft:100;dialogHeight:600px;dialogWidth:800px");
 	
	    }	    		         
   
  
   function HelpFileSetup(A,G,I,C)
		{   
	       	    window.showModalDialog("../BaseHelpFileSetUp.aspx?A=" + A + "&G=" + G + "&I=" + I +"&C=" + C , window,"scroll:no;resizable:yes;help:no;status:no;dialogTop:100;dialogLeft:100;dialogHeight:400px;dialogWidth:600px");
 		//		   window.open('BaseHelpFileSetUp.aspx?A=' + A + '&G='+ G + '&I=' + I +'&C=' + C , "HelpSetup", "width=500 height=400, top=100, left=100, toolbars=no, scrollbars=no,status=no,resizable=no" );

	    }


function SubmitMainPage()
   { try  
        { 
	        window.dialogArguments.Form1.submit(); 
	        window.close();
	    }		
    catch (e)
         {}
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
  
 function PageOnLoad_New1()
	{
		var newWindow = window.open("Login.aspx","","toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes,");					
		if (newWindow==null)
		{	return;}		
		newWindow.moveTo(0,0);
		newWindow.resizeTo(screen.availWidth,screen.availHeight);
		
		//newWindow.focus();
		
		//window.close();
		
		top.opener = top; 
		top.window.close();
	}
	
 	         
function GetNotes(DomainID,CompetencyID)
		{   
			window.showModalDialog('TA_Observation_CompetencyNotes.aspx?DomainID=' + DomainID + '&CompetencyID=' + CompetencyID + '&Title=Observation', window,"scroll:no;resizable:yes;help:no;status:no;dialogTop:50;dialogLeft:50;dialogHeight:400px;dialogWidth:605px");
		} 
		function GetNotesS(DomainID,CompetencyID)
		{   
                window.showModalDialog('TA_Observation_CompetencyNotes.aspx?DomainID=' + DomainID + '&CompetencyID=' + CompetencyID + '&Title=Sumative', window, "scroll:no;resizable:yes;help:no;status:no;dialogTop:50;dialogLeft:50;dialogHeight:400px;dialogWidth:605px");
               //  ChildWindow = window.open('TA_Observation_CompetencyNotes.aspx?DomainID=' + DomainID + '&CompetencyID=' + CompetencyID + '&Title=Sumative', "Notes", "width=605 height=400, top=100, left=50, toolbars=no, scrollbars=no,status=no,resizable=no" );
		}   		
		function GetNotesALL()
		{   
 			window.showModalDialog('TA_Observation_CompetencyNotesALL.aspx',  window, "scroll:no;resizable:yes;help:no;status:no;dialogTop:50;dialogLeft:50;dialogHeight:505px;dialogWidth:665px");
 			//ChildWindow = window.open('TA_Observation_CompetencyNotesALL.aspx', "NotesALL", "width=665 height=505, top=50, left=50, toolbars=no, scrollbars=no,status=no,resizable=no" );
		}   			         