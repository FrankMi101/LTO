<%@ Page Language="VB" Async="true" AutoEventWireup="false" CodeFile="RequestPositionDetails_MultipleSchool.aspx.vb" Inherits="RequestPositionDetails_MultipleSchool" EnableTheming="true" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add New open Position</title>
    <base target="_self" />
    <meta http-equiv="Pragma" content="No-cache" />
    <style type="text/css">
        body, #editcellAllow {
            width: 100%;
        }

        table, td {
            border: 1px solid skyblue;
            width: 98%;
        }
    </style>
    <link href="../Styles/DetailsPage.css" rel="stylesheet" type="text/css" />
    <link href="../JQuery-UI/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script src="../JQuery-UI/jquery-ui-1.11.4.min.js" type="text/javascript"></script>



</head>
<body>
    <form id="form1" runat="server">

        <div>
            <table>
                <tr>
                    <th>No.</th>
                    <th>School </th>
                    <th>Title</th>
                    <th>FTE</th>
                </tr>
                <tr>
                    <td style="width:10px;" >1
                        <asp:HiddenField ID="hfID1" runat="server" />
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSchool1" runat="server" Width="200px" CssClass="editcellAllow"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignment1" runat="server" Width="300px" CssClass="editcellAllow"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="txtFTE1" runat="server" Width="40px" CssClass="editcellAllow"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>2
                          <asp:HiddenField ID="hfID2" runat="server" />
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSchool2" runat="server" Width="200px" CssClass="editcellAllow"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignment2" runat="server" Width="300px" CssClass="editcellAllow"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="txtFTE2" runat="server" Width="40px" CssClass="editcellAllow"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>3
                          <asp:HiddenField ID="hfID3" runat="server" />
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSchool3" runat="server" Width="200px" CssClass="editcellAllow"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignment3" runat="server" Width="300px" CssClass="editcellAllow"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="txtFTE3" runat="server" Width="40px" CssClass="editcellAllow"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>4
                          <asp:HiddenField ID="hfID4" runat="server" />
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSchool4" runat="server" Width="200px" CssClass="editcellAllow"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignment4" runat="server" Width="300px" CssClass="editcellAllow"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="txtFTE4" runat="server" Width="40px" CssClass="editcellAllow"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>5
                          <asp:HiddenField ID="hfID5" runat="server" />
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSchool5" runat="server" Width="200px" CssClass="editcellAllow"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssignment5" runat="server" Width="300px" CssClass="editcellAllow"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="txtFTE5" runat="server" Width="40px" CssClass="editcellAllow"></asp:TextBox></td>
                </tr>
            </table>

            <div style="text-align: center">
                <asp:Button ID="btnSave" runat="server" Text="Save & Submit" Width="100px" />
            </div>


        </div>



    </form>

</body>
</html>
<script type="text/javascript">
    $(document).ready(function () {

        $("#btnSave").click(function () {
            var rVal = "";
            for (var i = 1; i<6; i++ )
            {
                if ($("#txtAssignment" +i).val() != "") {
                    rVal += $("#ddlSchool" + i + " option:selected").text() + " " + $("#txtFTE"+ i).val() + "% ; ";
                }
            }
            //if ($("#txtAssignment1").val() != "") {
            //    rVal += $("#ddlSchool1 option:selected").text() + " " + $("#txtFTE1").val() + "% ; ";
            //}
            //if ($("#txtAssignment2").val() != "") {
            //    rVal += $("#ddlSchool2 option:selected").text() + " " + $("#txtFTE2").val() + '% ; ';

            //}
            //if ($("#txtAssignment3").val() != "") {
            //    rVal += $("#ddlSchool3 option:selected").text() + " " + $("#txtFTE3").val() + '% ';

            //}
            //if ($("#txtAssignment4").val() != "") {
            //    rVal += $("#ddlSchool4 option:selected").text() + " " + $("#txtFTE4").val() + '% ; ';

            //}
            //if ($("#txtAssignment5").val() != "") {
            //    rVal += $("#ddlSchool5 option:selected").text() + " " + $("#txtFTE5").val() + '% ';

            //}

            $("#TextPositionDescription", parent.document).val(rVal);

            if ($("#F100MultipleSchool", parent.document).css("display") == "none") {
                $("#F100MultipleSchool", parent.document).show();
            }
            else {
                $("#F100MultipleSchool", parent.document).hide();
            }
            if ($("#LTOMultipleSchool", parent.document).css("display") == "none") {

                $("#LTOMultipleSchool", parent.document).show();
            }
            else {
                $("#LTOMultipleSchool", parent.document).hide();
            }

        })


        //$(window).unload(function () {
        //    //   var myaction = document.getElementById("HiddenFieldAction").value;

        //});




    });


</script>

