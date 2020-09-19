		 
 function closeIt()
  {
	if ( window.event.clientY < 0 )
	 {
		event.returnValue = "You will lose all changes made since your last save & submit.";
     }
  }
	
  
function confirm_Cancel()
		{
			if (confirm("Are you sure you want to Cancel what you just did ?")==true)
				return true;
			else
				return false;
		}
 
function Close()            
		{
			window.close();        
		}	
		

function DeleteRecord_Confirm()
		{
			var result = confirm("Do you want to delete this row?");
			if(result)
			   {return 0;}
			else
				{return 1;}
	    }
function ShowWarningDeletIEP()
      {
		//Add code to handle your event here.
			var result = confirm("This Step will Remove Current Student's IEP." + "\n" + "You cannot UNDO this remove !!!" +"\n"   +"\n" + "Click OK to Remove Current Student IEP Form.");
			if(result)
				return 0;
			else
				return 1;
	  }
	     
  function ShowWarningDeleteLE()
		   {
			//Add code to handle your event here.
			var result = confirm("This action will delete all Learning Expecations." + "\n" + "Cannot undo this action !!!" +"\n"   +"\n" + "Click OK to Continue.");
			if(result)
				return true;
			else
				return false;
	     	}	  
	     		     