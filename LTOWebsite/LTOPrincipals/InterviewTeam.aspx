<%@ Page Language="VB" AutoEventWireup="false" CodeFile="InterviewTeam.aspx.vb" Inherits="InterviewTeam" EnableTheming="true" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Principal Interview </title>
    <base target="_self" />
    <meta http-equiv="Pragma" content="No-cache" />
    <style type="text/css">
        body {
            height: 99%;
            width: 99%;
            font-family: Arial, sans-serif;
        }

        input {
            font-family: Arial, 'DejaVu Sans', 'Liberation Sans', Freesans, sans-serif;
            font-size: 12px;
        }

        textarea {
            font-family: Arial, 'DejaVu Sans', 'Liberation Sans', Freesans, sans-serif;
            font-size: 12px;
        }

        .Itemtitle {
            text-wrap: none;
            font-size: 12px;
        }

        #PopUpDIV1 tr td {
            border-width: 0px;
            border-style: solid;
            border-color: blue;
        }

        .textboxF {
            font-family: Arial, 'DejaVu Sans', 'Liberation Sans', Freesans, sans-serif;
            font-size: 12px;
        }

        #SignOffTable {
            font-family:  Arial, sans-serif;
            font-size: small;
        }

        .interviewList {
            width: 200px;
        }

        .LableItem {
            background-color: antiquewhite;
            width: 120px;
        }

        .sTitle {
            display: inline;
            width: 300px;
        }
        .titleContent {
         font-family:  Arial, sans-serif;
         font-size:small;
         }
        #btnEmail {
         border:2px outset #0094ff
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div style="background-image: url(../images/message_body_m.bmp)">
            <h3>Interview Team for          
            </h3>
         
           
            <div>
                <table  class ="titleContent">
                     <tr>
                        <td style="width:10%; ">School</td>
                        <td style="width:15%; ">Name:</td>
                         <td style="width:3%; "> </td>
                        <td style="width:72%; "><asp:Label ID="LabelSchool" runat="server" Text="Label" Width="350px" CssClass="LableItem" /></td>

                            

                    </tr>
                    <tr>
                        <td colspan="3"> Teacher Being Replaced : </td>
                        
                        <td> <asp:Label ID="LabelReplaceTeacher" runat="server" Text="Label" Width="250px" CssClass="LableItem" /></td>
                    </tr>
                     <tr>
                        <td>Posting</td>
                        <td>Number:</td>
                           <td></td>
                        <td> <asp:Label ID="LabelPostingNumber" runat="server" Text="Label" CssClass="LableItem"></asp:Label></td>
                    </tr>
                     <tr>
                        <td>Position</td>
                        <td>Title:</td>
                           <td></td>
                        <td> <asp:Label ID="LabelPositionTitle" runat="server" Text="Label" CssClass="LableItem"></asp:Label></td>
                    </tr>
                     <tr>
                        <td> </td>
                        <td>Start Date: </td>
                           <td></td>
                        <td>  <asp:Label ID="LabelStart" runat="server" Text="Label" CssClass="LableItem" /></td>
                    </tr>
                     <tr>
                        <td></td>
                        <td>End Date:</td>
                           <td></td>
                        <td> <asp:Label ID="LabelEnd" runat="server" Text="Label" CssClass="LableItem" /></td>
                    </tr>
             
                </table>
            </div>
            <table id="SignOffTable" style="width: 99%; border: 1px solid #808080"  class ="titleContent">

                <tr>
                    <td>1<sup>st</sup> Interviewer :</td>
                    <td>
                        <div class="ui-widget" style="display: none">

                            <select id="combobox1" runat="server" style="background-color: lightgoldenrodyellow">
                                <option value="">Select Teacher...</option>

                            </select>
                        </div>
                        <asp:DropDownList ID="ddlInterview1" runat="server" AutoPostBack="true" CssClass="interviewList"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:HiddenField ID="hfUserIDP1" runat="server" />
                    </td>
                    <td></td>


                </tr>
                <tr>
                    <td>2<sup>nd</sup> Interviewer:</td>
                    <td>
                        <div class="ui-widget" style="display: none">

                            <select id="combobox2" runat="server" style="background-color: lightgoldenrodyellow">
                                <option value="">Select Teacher...</option>

                            </select>
                        </div>
                        <asp:DropDownList ID="ddlInterview2" runat="server" AutoPostBack="true" CssClass="interviewList"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:HiddenField ID="hfUserIDP2" runat="server" />
                    </td>
                    <td style="width: 20%">
                        <asp:Button ID="btnRemoveP2" runat="server" Text="Remove" />
                    </td>

                </tr>
                <tr id="SignOffRow3" runat="server">
                    <td>3<sup>rd</sup> Interviewer :</td>
                    <td>
                        <div class="ui-widget" style="display: none">

                            <select id="combobox3" runat="server" style="background-color: lightgoldenrodyellow">
                                <option value="">Select Teacher...</option>

                            </select>
                        </div>
                        <asp:DropDownList ID="ddlInterview3" runat="server" AutoPostBack="true" CssClass="interviewList"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:HiddenField ID="hfUserIDP3" runat="server" />
                    </td>
                    <td>
                        <asp:Button ID="btnRemoveP3" runat="server" Text="Remove" /></td>


                </tr>
            </table>
            <asp:Button ID="btnSave" runat="server" Text="Save" Visible="false" />
            <br />
             <asp:Button ID="btnEmail" runat="server" Text="Send a Signature link to interviewer team members" ToolTip="The Principal can sign off from the mobile phone through the link."   />
      
            </div>

        <asp:HiddenField ID="HiddenFieldAction" runat="server" Value="No" />
        <asp:HiddenField ID="hfUserCPNum" runat="server" />
        <asp:HiddenField ID="hfSchoolyear" runat="server" />
        <asp:HiddenField ID="hfSchoolname" runat="server" />
        <asp:HiddenField ID="hfIDs" runat="server" />
        <asp:HiddenField ID="hfPositionID" runat="server" />
        <asp:HiddenField ID="hfPrincipalName" runat="server" />
        <asp:HiddenField ID="hfPositionType" runat="server" />


    </form>
</body>
</html>
<script src="../Scripts/jQuery/jquery-1.11.2.js"></script> 

<script>
    function pageLoad(sender, args) {

        $(document).ready(function () {
          
            $("#btnEmail").click(function (e) {
               window.alert ("Sign Off Link email sent out successfully!")
            
            });
        });

    }


   
</script>
