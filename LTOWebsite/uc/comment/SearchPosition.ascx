<%@ Control Language="VB" AutoEventWireup="false" CodeFile="SearchPosition.ascx.vb" Inherits="SearchPosition" %>
<table style="width:480px;">
    <tr>
        <td><strong>Search Position by:</strong></td>
        <td>
            <asp:DropDownList ID="ddlSearchby" runat="server" Width="100px" SkinID="ddlSmall" Visible="true" AutoPostBack="True">
                <asp:ListItem Selected="True">All</asp:ListItem>
                <asp:ListItem>Area</asp:ListItem>
                <asp:ListItem>School</asp:ListItem>
                <asp:ListItem>Panel</asp:ListItem>
                <asp:ListItem>Title</asp:ListItem>
                <asp:ListItem>Level</asp:ListItem>
                <asp:ListItem Value="PostingState">Posting State</asp:ListItem>
                <asp:ListItem Value="PostingNum">Posting Number</asp:ListItem>
                <asp:ListItem Value="PostingCycle">Posting Cycle</asp:ListItem>
                <asp:ListItem Value="PublishDate">Publish Date</asp:ListItem>
                <asp:ListItem Value="DeadlineDate">Deadline Date</asp:ListItem>
                <asp:ListItem Value="OpenDate">Posting Open Date</asp:ListItem>
                <asp:ListItem Value="CloseDate">Posting Close Date</asp:ListItem>
                <asp:ListItem Value="PositionStartDate">Position Start Date</asp:ListItem>
                <asp:ListItem Value="PositionEndDate">Position End Date</asp:ListItem>
                <asp:ListItem Value="PendingConfirm">Pending Confirm</asp:ListItem>
                <asp:ListItem>Applicants </asp:ListItem>
            </asp:DropDownList></td>
        <td style=" width:52%; text-wrap:avoid">

            <asp:DropDownList ID="ddlSearchbyValue" runat="server" Width="200px" SkinID="ddlSmall" Visible="false">
            </asp:DropDownList>
            <asp:TextBox ID="txtSearchbyValue" runat="server" Width="200px" Visible="true"></asp:TextBox>
            <div id="SearchDateDIV" runat="server" visible="false" style="display: block">
                <input runat="server" visible="true" type="text" id="datepicker" size="9" />
                <asp:Label ID="DateTo" runat="server" Text="To"></asp:Label>
                <input runat="server" visible="true" type="text" id="datepicker2" size="9" />
            </div>
        </td>
    </tr>
</table>





<script src="../Scripts/jQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
<script src="../JQuery-UI/jquery-ui-1.11.4.min.js" type="text/javascript"></script>
<script src="../Scripts/CommonDOM.js" type="text/javascript"></script>

<script type="text/javascript">

    $(document).ready(function () {
        LoadDatePicker();
          $("#SearchPosition1_ddlSearchby").change(function (e) {
             $("#SearchType").val($("#SearchPosition1_ddlSearchby").val());
         });
        
        $("#SearchPosition1_ddlSearchbyValue").change(function (e) {

             $("#SearchForListValue1").val($("#SearchPosition1_ddlSearchbyValue").val());
         });

        $("#SearchPosition1_txtSearchbyValue").change(function (e) {
            $("#SearchForListValue1").val($("#SearchPosition1_txtSearchbyValue").val());
         });

        $("#SearchPosition1_datepicker").change(function (e) {
            $("#SearchForListValue1").val($("#SearchPosition1_datepicker").val());
         });
        $("#SearchPosition1_datepicker2").change(function (e) {
            $("#SearchForListValue2").val($("#SearchPosition1_datepicker2").val());
         });
    });
    function LoadDatePicker() {
        JDatePicker.InitialL($("#SearchPosition1_datepicker"));
        JDatePicker.InitialL($("#SearchPosition1_datepicker2"));
    }
</script>
