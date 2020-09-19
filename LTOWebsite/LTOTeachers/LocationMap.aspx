<%@ Page Language="VB" AutoEventWireup="false" CodeFile="LocationMap.aspx.vb" Inherits="LocationMap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Gooogle Map School Location</title>

    <style>
        table {
            height: 100%;
            width: 100%;
            text-align: center;
            vertical-align: middle;
            font-family: Arabic Typesetting;
            font-size: medium;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div id="map_canvas" style="width: 100%; height: 100%"></div>


        <div>
            <iframe id="myGooglMap" runat="server" name="myGooglMap" width="640" height="500" frameborder="0" scrolling="no" marginheight="0" marginwidth="0"
                src="#"></iframe>
        </div>

    </form>
</body>
</html>

<script src="../Scripts/jQuery/jquery-1.11.2.min.js" type="text/javascript"></script>
<script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCnmtu8PZSh57V0NYxcz5qMTYrxBKsZa9A&sensor=false"> </script>


<script type="text/javascript">
    $(document).ready(function () {

        $("#BackLink").click(function (e) {
            try {
                CallParentPostBack("", "", "")

            }
            catch (e) {

            }
        });

    });
    function CallParentPostBack(action, positionTitle, strMessage) {
        try {
            parent.document.Script.CloseMe(action);
        }
        catch (e) {
            try {
                window.opener.CloseMe(action);
            }
            catch (e) {
                try {
                    parent.CloseMe(action);
                }
                catch (e) {
                    window.alert("Your Browser does not support iFrame Call !")
                }

            }

        }
    }


</script>

