<%@ Control Language="vb" AutoEventWireup="false" Inherits="appheader1" CodeFile="appheader1.ascx.vb" %>
<style type="text/css">
    .appHeader {
        /* IE 11 dose not work on display: flex;*/
        display: flex;
        width: 100%;
        justify-content: space-between;
    }

    .appHeader_logo {
        width: 160px;
        height: 75px;
    }

    .appHeader_dbVersion {
        width: 120px;
    }

    .appHeader_Info {
        display: flex;
        flex-direction: column;
        /*justify-content:flex-end;*/
        /*align-items:flex-end;*/
        text-align:right; 
        /*vertical-align: top;*/
       
    }
    .appHeader_Info_Link {
        display: inline;
        font-family: Arial, helvetica, Verdana, Sans-Serif;
        font-size: 0.7em;
        vertical-align:top;
        /*padding-right:10px;*/
        margin-right:10px;
    }

    .appHeader_Info_links {
        background-image: url(images/BlueExplorer.gif);
        vertical-align: top;
        height:20px;
        margin-top:-2px;
        width:400px;

    }
    appHeader_Info_link_item
    {
     
      padding:2px
    }
    .appHeader_Info_links ul li a{
         vertical-align: middle;
        padding-left:20px;
    }
    .appHeader_Info_Title {
        width: 100%;
        text-align: right; 
        font-size:large;
          color:  #cc0033;
        
    } 
   .appHeader_Info_Version {
        width: 100%;
        text-align: right;
        vertical-align: top;
        font-size:x-small;
    } 
    .appHeader_Info_Label {
        display: block;
        /*background-color: aliceblue;*/
        height: 20px;
        width: 100%;
        align-items: flex-start;
        text-align: left; 
         
    }


   

    #curve1 {
        margin-top: -3px;
        margin-right: -10px;
    }

  

    .appHeader_Info_Link ul li:hover {
        border: 1px solid blue;
        background-image: url(images/OrangeExplorer.gif);
        margin: -1px;
    }

  

    A:link {
        text-decoration: none;
        color: purple;
    }

    A:visited {
        text-decoration: none;
        color: #333399;
    }

    A:active {
        text-decoration: none;
        color: #333399;
    }

    A:hover {
        text-decoration: underline;
        color: purple;
    }
</style>

<div class="appHeader">
    <div class="appHeader_logo">
        <img id="Image4" src="images/tcdsblogo.gif" alt="TCDSB Logo" border="0" style="width: 160px; height: 75px" />
    </div>
    <div class="appHeader_dbVersion">
        <asp:Label ID="LabelTrain" runat="server" Visible="False"
            Font-Size="Large" ForeColor="#00C000"> Training</asp:Label>
        <asp:HiddenField ID="hfLoginRole" runat="server" />
    </div>
    <div class="appHeader_Info">
        <div class="appHeader_Info_Link">
            <img id="curve1" height="22" src="images/curve2.bmp" width="55" alt="" />
            <ul class="appHeader_Info_links">



                <li class="appHeader_Info_link_item">Link Web Sites:</li>
                <li class="appHeader_Info_link_item">
                    <a href="https://www.tcdsb.org" id="A1" runat="server" target="_blank">TCDSB </a>

                </li>
                <li class="appHeader_Info_link_item">
                    <a href="https://intranet.tcdsb.org" id="A2" runat="server" target="_blank">Intranet </a>

                </li>
                <li class="appHeader_Info_link_item">
                    <a href="http://owa.tcdsb.org" id="A3" runat="server" target="_blank">Web Mail </a>

                </li>
                <li class="appHeader_Info_link_item">
                    <a href="~/logout.aspx" id="A4" runat="server" target="_self">Log out </a>

                </li>

            </ul>
        </div>

        <div class="appHeader_Info_Title">

            <asp:Label ID="lblApplication" runat="server" Text="LTO/POP Open Positions"></asp:Label>
            (<a id="appLink" runat="server" href="~/Default.aspx">LTO/POP</a>)                                  
                       
        </div>
        <div class="appHeader_Info_Version">
            <asp:Label ID="lblTCDSB" runat="server" Text="TCDSB " ForeColor="#CC0033" ToolTip="Show Application Support"></asp:Label>
            <asp:Label ID="lblVersion" runat="server" SkinID="AppVersion" Text=" (Version 4.2.2 )" ToolTip="Edit Application Support"></asp:Label>
        </div>
        <div class="appHeader_Info_Label" id ="TableVersion" runat="server">
            <asp:Label ID="Label1" Height="20px" runat="server" BackColor="Transparent" Width="99%"
                Font-Size="X-Small" Font-Names="Arial" ForeColor="purple"> </asp:Label>
        </div>
    </div>
</div>
