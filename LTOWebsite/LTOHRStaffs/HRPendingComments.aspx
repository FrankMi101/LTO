<%@ Page Language="VB" AutoEventWireup="false" CodeFile="HRPendingComments.aspx.vb" Inherits="HRPendingComments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="../Styles/ListPage.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        html {
        margin:auto
        }
        body {
            margin:auto;
            height: 100%;
            width: 99.9%;
        }

        .auto-style1 {
            height: 350px;
        }



        .WDG {
            height: 100%;
            width: 100%;
        }

        .DataContentTile {
            font-family: Arial;
            font-size: small;
            font-weight: 300;
            color: blue;
            table-layout: auto;
            display: block;
            height: 99%;
        }


        .SubstituedCell {
            color: red;
            text-decoration: underline;
        }

        .emptyData {
            font-size: xx-large;
            text-align: center;
            color: blue;
        }

        .EditCPNum {
            display: none;
        }

        .FixedHeader {
            position: absolute;
            font-weight: bold;
            width: 100%;
            display: block;
        }

        .highlightBoard {
            border: 2px #ff6a00 solid;
        }

        .defaultBoard {
            border: 0px #ff6a00 solid;
        }

        .top5Row {
            /*background-color:lightgreen;*/
            border-bottom: 8px solid darkcyan;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
       
     
        <div id="DivRoot"  style="width: 100%; height:100%;">
          <%--  <div style="overflow: hidden;" id="DivHeaderRow">
                <table id="GridView2" style="border: 1px ridge gray; width: 100%; height: 100%; background-color: white;" rules="all" cellspacing="1" cellpadding="1" borderwidth="1px">
                </table>
            </div>--%>

            <div style="overflow: auto; width: 100%; height: 300px" >
                <asp:GridView ID="GridView1" runat="server" CellPadding="1" Height="100%" Width="100%" GridLines="Both" AutoGenerateColumns="False" BackColor="White" BorderColor="gray" BorderStyle="Ridge" BorderWidth="1px" CellSpacing="1" EmptyDataText="No Applicants in selected position" EmptyDataRowStyle-CssClass="emptyData" ShowHeaderWhenEmpty="true">
                    <Columns>

                        <asp:BoundField DataField="IDs" ReadOnly="True" Visible="False" /> 

                        <asp:BoundField DataField="CommentsBy" HeaderText="User"  >
                            <ItemStyle Width="150px" />
                        </asp:BoundField>
                     
                        <asp:BoundField DataField="CommentsDate" HeaderText="Date">
                            <ItemStyle Width="85px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Comments" HeaderText="Comments">
                            <ItemStyle Width="70%" />
                        </asp:BoundField>
                       
                    </Columns>

                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                    <HeaderStyle BackColor="cornflowerblue" ForeColor="white" Height="25px" />
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#594B9C" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#33276A" />
                </asp:GridView>
            </div>
          
        </div>
      
    </form>
</body>
</html>

<script src="../Scripts/jQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
<script src="../Scripts/PopUpDIVLeft.js" type="text/javascript"></script>



<script type="text/javascript">
  

    $(document).ready(function () {

      //  MakeStaticHeader("GridView1", 350, 450, 30, false)
    })

 
</script>



<script type="text/javascript">
    function MakeStaticHeader(gridId, height, width, headerHeight, isFooter) {
        var tbl = document.getElementById(gridId);
        if (tbl) {
            var DivHR = document.getElementById('DivHeaderRow');
            var DivHeader = document.getElementById('GridView2');
            var DivMC = document.getElementById('DivMainContent');
            //   var DivFR = document.getElementById('DivFooterRow');

            //*** Set divheaderRow Properties ****
            DivHR.style.height = headerHeight + 'px';
            DivHR.style.width = '99.9%'; // (parseInt(width) - 16) + 'px';
            DivHR.style.position = 'relative';
            DivHR.style.top = '0px';
            DivHR.style.zIndex = '10';
            DivHR.style.verticalAlign = 'top';

            //*** Set divMainContent Properties ****
            DivMC.style.width = '100%'; // width + 'px';
            DivMC.style.height = height + 'px';
            DivMC.style.position = 'relative';
            DivMC.style.top = -headerHeight + 'px';
            DivMC.style.zIndex = '1';



            //  DivHR.appendChild(tableH );
            DivHeader.appendChild(tbl.rows['0'].cloneNode(true));
            DivHeader.appendChild(tbl.rows['1'].cloneNode(true));
            //   DivHR.appendChild("</table>"  );
            //   div.insertAdjacentHTML('beforeend', str);

            //   addGridViewHeader();
        }
    }

    function addGridViewHeader() {
        var index = 0
        //  var $myHeader = $("#GridView1").clone(true);


        $('#GridView1 > tbody  > tr:not(:first)').each(function () {
            var t1 = $(this).text();
            $(this).find('td').each(function (i, el) {
                var myHeaderStyle = this.style.cssText;
                // window.alert(myHeaderStyle);
            });
            return false;
        })




    }

    function OnScrollDiv(Scrollablediv) {
        document.getElementById('DivHeaderRow').scrollLeft = Scrollablediv.scrollLeft;
        //   document.getElementById('DivFooterRow').scrollLeft = Scrollablediv.scrollLeft;
    }


</script>
