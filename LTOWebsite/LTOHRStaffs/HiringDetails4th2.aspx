<%@ Page Language="VB" AutoEventWireup="false" CodeFile="HiringDetails4th2.aspx.vb" Inherits="HiringDetails4th2" EnableTheming="true" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HR Confirm for Hire -- 4th Round Posting </title>
    <base target="_self" />
    <meta http-equiv="Pragma" content="No-cache" />
    <link href="../Styles/DetailsPage.css" rel="stylesheet" type="text/css" />
    <link href="../JQuery-UI/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/DetailsPage.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/CommonDOM.js" type="text/javascript"></script>
    <script src="../Scripts/angular.min.js"></script>
    <style>
        .custom-combobox {
            position: relative;
            display: inline-block;
        }

        .custom-combobox-toggle {
            position: absolute;
            top: 0;
            bottom: 0;
            margin-left: -1px;
            padding: 0;
        }

        .custom-combobox-input {
            margin: 0;
            padding: 5px 10px;
            background-color: #ffffcc;
        }

        input.ng-invalid {
            background-color: #ffffcc;
        }

        input.ng-valid {
            background-color: white;
        }

        .applicantT {
            width: 100%;
        }

            .applicantT td {
                border: 1px solid silver;
            }
    </style>
    <style type="text/css">
        body {
            height: 100%;
            width: 99%;
        }

        .noWrap {
            text-wrap: avoid;
            width: 110px;
        }

        .auto-style4 {
            width: 14px;
            height: 15px;
        }
    </style>
    <script src="../Scripts/jQuery/jquery-1.11.2.min.js" type="text/javascript"></script>

    <script type="text/javascript">

        function CallBackReloadParent(action, strMessage) {
            try {
                if (action != "") {
                    window.alert(action + " " + strMessage);
                    $("#hdChildFormAction", parent.document).val(action);
                    $("#PopUpDIV", parent.document).fadeToggle("fast");
                    $("#PositionDetailDIV", parent.document).fadeToggle("fast");
                    window.parent.frames["mainTop"].document.location.reload();
                }
                else {
                    $("#PopUpDIV", parent.document).fadeToggle("fast");
                    $("#PositionDetailDIV", parent.document).fadeToggle("fast");
                }
            }
            catch (e) {
                var s = e.message;
            }

        }


    </script>

</head>
<body>
    <form id="form1" runat="server" ng-app="" name="myForm">

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div style="background-image: url(../images/message_body_m.bmp)">

            <table>
                <tr>
                    <td>Posting Number </td>
                    <td colspan="1">
                        <asp:Label ID="lblPostingNum" runat="server" Text="2017-0000"></asp:Label>
                        <asp:Label ID="lblPositionOwner" runat="server" Text=""></asp:Label>
                    </td>

                    <td>Hire Date:</td>
                    <td colspan="3">
                        <input runat="server" type="text" id="dateHire" size="9" />

                        <asp:Label ID="lblPostingCycle" runat="server" Height="20px" Width="30px" BackColor="Transparent" Visible="false"></asp:Label>
                        <asp:Label ID="lblTeacherPersonID" runat="server" Text="person id" Visible="false"></asp:Label>
                        <asp:Label ID="lblTeacherOTPrnr" runat="server" Height="20px" Width="30px" BackColor="Transparent"></asp:Label>
                    </td>
                </tr>

                <tr>


                    <td>Position Title:</td>
                    <td colspan="5">
                        <asp:TextBox ID="TextPositionTitle" runat="server" Height="20px" Width="400px" BackColor="Transparent"></asp:TextBox>
                        FTE
                      <asp:Label ID="lblPositionFTE" runat="server" Height="20px" Width="30px" BackColor="Transparent"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>Mandatory Qualification:</td>
                    <td colspan="5">
                        <asp:TextBox ID="TextPostionLevel" runat="server" Height="20px" Width="99%" BackColor="Transparent"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Position School:</td>
                    <td colspan="5">
                        <asp:TextBox ID="TextSchool" runat="server" BackColor="Transparent" Height="20px" Width="99%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Position
                        <br />
                        Qualification:</td>
                    <td colspan="5">
                        <asp:TextBox ID="TextQualification" runat="server" BackColor="Transparent" TextMode="MultiLine" Height="40px" Width="99%"></asp:TextBox>


                    </td>
                </tr>
                <tr style="border: 1px solid grey">
                    <td>Position Description:</td>
                    <td colspan="5">
                        <asp:TextBox ID="TextDescription" runat="server" BackColor="Transparent" TextMode="MultiLine" Height="30px" Width="99%"></asp:TextBox>
                        <div id="F100TimeTable" runat="Server"></div>
                        <div id="F100MultipleSchool" runat="Server"></div>
                    </td>
                </tr>
                <tr style="border: 1px solid grey">
                    <td>Applicants:</td>
                    <td colspan="5">
                        <div id="ApplicantsList" runat="Server" visible="false"></div>

                    </td>
                </tr>


                <tr style="border: 1px solid grey">
                    <td>Teacher be Replaced </td>

                    <td colspan="5">
                        <asp:TextBox ID="lblTeacherBeReplaced" runat="server" Text="teacher name" ReadOnly="true" Width="120px"></asp:TextBox>
                        Person ID
                        <asp:TextBox ID="lblTeacherBeReplacedPersonID" runat="server" Text="person id" Width="80px" ReadOnly="true"></asp:TextBox>
                        Replaced Reason<asp:TextBox ID="lblReasonReplacement" TabIndex="14" runat="server" ReadOnly="true" Width="150px"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td colspan="6">
                        <table style="width: 100%; border: solid 2px orange">
                            <tr>
                                <td>Hire Comments</td>
                                <td colspan="3">
                                    <asp:TextBox ID="TextHiredcomments" runat="server" Height="30px" TextMode="MultiLine" Width="98%" BackColor="#ffffcc"></asp:TextBox>

                                </td>
                            </tr>

                            <tr>
                                <td>Hire Teacher Name:</td>
                                <td>
                                    <div class="ui-widget">

                                        <select id="combobox" runat="server" style="background-color: lightgoldenrodyellow"
                                            ng-model="myText" required>
                                            <option value="">Select Teacher...</option>

                                        </select>

                                    </div>
                                    <div id="inputTeacherName" runat="server" style="display: none">

                                        <input runat="server" id="TextInputTeacherName" style="width: 100%; background-color: #ffffcc" type="text" name="teacher name" class="inputFiled editArea" placeholder="new teacher Name" />

                                    </div>
                                    <asp:HiddenField ID="HiddenFieldTeacherName" runat="server" />

                                </td>
                                <td>
                                    <%--                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="combobox" ErrorMessage="Must select a Teacher. " Font-Size="x-Large" SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>--%>


                                    <img id="imgNewTeacher" runat="server" alt="teacher img" src="../images/teacher.gif" title="Click to add New Teacher" style="height: 20px; width: 20px" />

                                </td>
                                <td>

                                    <div id="inputPersonID" runat="server">
                                        PersonID :    
                                       <%-- <asp:TextBox ID="TextCPNum" runat="server" Width="80px" BackColor="Silver"  required ></asp:TextBox>
                                       --%>
                                        <input runat="server" type="text" id="TextCPNum" size="9" ng-model="Silver" />
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextCPNum" ErrorMessage="Must have. " Font-Size="x-Large" SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                    </div>

                                </td>
                            </tr>
                            <%-- <tr style="display: none;">
                                <td>Hire Teacher Name:
                                </td>
                                <td colspan="3">
                                    <asp:DropDownList ID="ddlApplicant" runat="server" Width="150px" BackColor="#ffffcc" Height="20px" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>

                            </tr>--%>
                            <tr>
                                <td style="text-align: right; width: 16%">
                                    <asp:Label ID="LabelStartDate" runat="server" Text=" LTO start date:"></asp:Label>
                                </td>

                                <td style="width: 34%; text-wrap: none; overflow-wrap: normal">
                                    <input runat="server" type="text" id="dateEffective" size="9" ng-model="myText1" required />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="dateEffective" ErrorMessage="Must input Start Date. " Font-Size="x-Large" SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>

                                </td>
                                <td style="width: 17%">
                                    <asp:Label ID="Label1" runat="server" Text="Assignment End Date:"></asp:Label></td>
                                <td style="width: 33%; text-wrap: none; overflow-wrap: normal">
                                    <input runat="server" type="text" id="dateEnd" size="9" ng-model="myText2" required />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="dateEnd" ErrorMessage="Must input End Date. " Font-Size="x-Large" SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>

                                </td>

                            </tr>

                        </table>

                    </td>
                </tr>

                <tr>
                    <td colspan="4" style="text-align: center;">

                        <asp:Button ID="btnSaveHired" runat="server" Text="Confirm Hire" Width="140px" />
                        <asp:Button ID="btnSave" runat="server" Text="Save Edit" Width="140px" />
                        <asp:Button ID="btnEmail" runat="server" Text="Re-Send Email" Width="160px" Visible="false" />


                    </td>
                    <td colspan="2" style="text-align: left;">
                        <asp:CheckBox ID="chbNoticeToPrincipal" runat="server" Text="Email to Principal" Checked="true" />
                        <br />
                        <asp:CheckBox ID="chbNoticeToUnion" runat="server" Text="Email to Union" Checked="true" />
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <asp:Label runat="server" ID="lblmessage" ForeColor="Red">* To input a new hire staff (not TCDSB staff yet) by click on the person image   </asp:Label>
                        <img src="../images/teacher.gif" style="height: 15px; width: 15px" />
                    </td>
                </tr>
                <tr id="HiredMessageRow" runat="server" visible="false">
                    <td>
                        <img id="HiredAlert" runat="server" src="../images/alert.gif" visible="false" />


                    </td>
                    <td colspan="5">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="SingleParagraph" ForeColor="red" />

                        <asp:Label ID="HiredMessage" runat="server" Text="Label" ForeColor="Red" Width="440px" Visible="false"></asp:Label>
                        FTE
                        <asp:Label ID="lblHiredFTE" runat="server" Text="Label" ForeColor="Red" Width="30px" Visible="false"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>

        <asp:HiddenField ID="HiddenFieldAction" runat="server" Value="No" />
        <asp:HiddenField ID="hfUserCPNum" runat="server" />
        <asp:HiddenField ID="hfSchoolyear" runat="server" />
        <asp:HiddenField ID="hfSchoolCode" runat="server" />
        <asp:HiddenField ID="hfSchoolname" runat="server" />
        <asp:HiddenField ID="hfIDs" runat="server" />
        <asp:HiddenField ID="hfPositionID" runat="server" />
        <asp:HiddenField ID="hfPrincipalName" runat="server" />
        <asp:HiddenField ID="hfPrincipalID" runat="server" />
        <asp:HiddenField ID="hfPrincipalNameTo" runat="server" />
        <asp:HiddenField ID="hfPositionType" runat="server" />
        <asp:HiddenField ID="hfConfirmUser" runat="server" />
        <asp:HiddenField ID="hfPositionType1" runat="server" />
        <asp:HiddenField ID="hfPositionTypeHired" runat="server" />
        <asp:HiddenField ID="hfHiredStatus" runat="server" />
        <asp:HiddenField ID="hfSchoolyearStartDate" runat="server" Value="2017-09-05" />
        <asp:HiddenField ID="hfSchoolyearEndDate" runat="server" Value="2018-06-26" />        
        <asp:HiddenField ID="hfPositionNumber" runat="server" />

    </form>
</body>
</html>
<script src="../JQuery-UI/jquery-ui-1.11.4.min.js" type="text/javascript"></script>
<script src="../Scripts/PopUpDIVLeft.js" type="text/javascript"></script>
    <script src="../Scripts/CommonDOM.js" type="text/javascript"></script>


<script type="text/jscript">
    var today = new Date();  
    var minD = new Date($("#hfSchoolyearStartDate").val()); // today.getDate() - 90; //
    var maxD = new Date($("#hfSchoolyearEndDate").val()); 

    $(document).ready(function () {
        // $("#inputTeacherName").hide();
      InitialDatePickerControl();
        $(window).unload(function () {
            window.returnValue = $("#HiddenFieldAction").val();
        });
        DOMaction.Button("#btnSaveHired", true);
        if ($("#hfPositionType1").val() == "POP") { $("#dateEnd").removeAttr("required"); }
 
        //$("#dateEnd").datepicker(
        //    {
        //        dateFormat: 'yy-mm-dd',
        //        showOn: "button",
        //        buttonImage: "../images/calendar.gif",
        //        buttonImageOnly: true,
        //        minDate: minD,
        //        maxDate: maxD,
        //        changeMonth: true,
        //        changeYear: true
        //    });
        //$("#dateEffective").datepicker(
        //    {
              
        //        dateFormat: 'yy-mm-dd',
        //        showOn: "button",
        //        buttonImage: "../images/calendar.gif",
        //        buttonImageOnly: true,
        //        minDate: minD,
        //        maxDate: maxD,
        //        changeMonth: true,
        //        changeYear: true
                 

        //    });
        $("#btnSaveHired_old").click(function (e) {
            var actionsTitle = $(this).attr('value');
            var result = confirm("Are you sure, you want to " + actionsTitle + " ?");
            if (result) {
                $("#HiddenFieldAction").val("Yes");
                return true;
            }
            else { return false; }
        })

        $("#interviewPackage").click(function (e) {
            var yID = $("#hfSchoolyear").val();
            var cpnum = $("#hfUserCPNum").val();
            var pID = $("#hfPositionID").val();
            var printPage = "../PDFLoading/PDFDocument_Loading.aspx?rID=InterviewPackage" + "&yID=" + yID + "&CPNum=" + cpnum + "&pID=" + pID;
            var popup1 = window.open(printPage, "", "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=yes,width=800,height=600,top=0,left=0");

        });

        //$("#combobox").click(function (e) {

        //    var vCPNum = $(this).val();
        //    $("#TextCPNum").val(vCPNum);
        //});
        $("#imgNewTeacher").click(function (e) {
            if ($("#inputTeacherName").is(":hidden")) {
                $("#inputTeacherName").show();
                $("#TextCPNum").val("NS000000");
                $(".ui-widget").hide();
                $("#combobox").removeAttr("required");
                $("#TextInputTeacherName").prop('required', true);
                $(".custom-combobox-input").removeAttr('required');


            }
            else {
                $("#inputTeacherName").hide();
                $("#TextCPNum").val("");
                $(".ui-widget").show();
                $("#TextInputTeacherName").removeAttr("required");
                $("#combobox").prop('required', true);
                $(".custom-combobox-input").prop('required', true);
            }

        });
        $("#TextInputTeacherName").change(function (e) {
            $("#HiddenFieldTeacherName").val($("#TextInputTeacherName").val());
            //  checkRequestButton();

        });
    });

    function InitialDatePickerControl() {
        var value = new Date().toDateString;

        JDatePicker.Initial($("#dateEffective"), minD, maxD);
        JDatePicker.Initial($("#dateEnd"), minD, maxD);
      // JDatePicker.Initial($("#dateHire"), minD, maxD);

        
    }
    function openLTOAppraisal(schoolyear, schoolcode, SessionID, TeacherID) {
        var printPage = "../PDFLoading/PDFDocument_Loading.aspx?rID=InterviewPackage" + "&yID=" + schoolyear + "&CPNum=" + TeacherID + "&pID=" + SessionID;
        var popup1 = window.open(printPage, "", "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=yes,width=800,height=600,top=0,left=0");
    }
    function checkRequestButton() {
        if ($("#TextCPNum").val() != "" && $("#dateEffective").val() != "") { DOMaction.Button("#btnSaveHired", false); }
    }
</script>
<script>

    function pageLoad(sender, args) {
        $(".custom-combobox-input").focus();
        // $("#combobox").focus();
        //   DOMaction.Button("#btnSaveHired", true);

        $(".custom-combobox-input").prop('required', true);

    }
    $(function () {
        $.widget("custom.combobox", {
            _create: function () {
                this.wrapper = $("<span>")
                    .addClass("custom-combobox")
                    .insertAfter(this.element);

                this.element.hide();
                this._createAutocomplete();
                this._createShowAllButton();
            },

            _createAutocomplete: function () {
                var selected = this.element.children(":selected"),
                    value = selected.val() ? selected.text() : "";

                this.input = $("<input>")
                    .appendTo(this.wrapper)
                    .val(value)
                    .attr("title", "")
                    .addClass("custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left")
                    .autocomplete({
                        delay: 0,
                        minLength: 0,
                        source: $.proxy(this, "_source")
                    })
                    .tooltip({
                        classes: {
                            "ui-tooltip": "ui-state-highlight"
                        }
                    });

                this._on(this.input, {
                    autocompleteselect: function (event, ui) {
                        ui.item.option.selected = true;
                        this._trigger("select", event, {
                            item: ui.item.option
                        });
                        var vCPNum = ui.item.option.value;
                        $("#TextCPNum").val(vCPNum);
                        $("#HiddenFieldTeacherName").val(ui.item.value);
                    },

                    //  autocompletechange: "_removeIfInvalid" we allow user input new one
                });
            },

            _createShowAllButton: function () {
                var input = this.input,
                    wasOpen = false;

                $("<a>")
                    .attr("tabIndex", -1)
                    .attr("title", "Show All Items")
                    .tooltip()
                    .appendTo(this.wrapper)
                    .button({
                        icons: {
                            primary: "ui-icon-triangle-1-s"
                        },
                        text: false
                    })
                    .removeClass("ui-corner-all")
                    .addClass("custom-combobox-toggle ui-corner-right")
                    .on("mousedown", function () {
                        wasOpen = input.autocomplete("widget").is(":visible");
                    })
                    .on("click", function () {
                        input.trigger("focus");

                        // Close if already visible
                        if (wasOpen) {
                            return;
                        }

                        // Pass empty string as value to search for, displaying all results
                        input.autocomplete("search", "");
                    });
            },

            _source: function (request, response) {
                var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                response(this.element.children("option").map(function () {
                    var text = $(this).text();
                    if (this.value && (!request.term || matcher.test(text)))
                        return {
                            label: text,
                            value: text,
                            option: this
                        };
                }));
            },

            _removeIfInvalid: function (event, ui) {

                // Selected an item, nothing to do
                if (ui.item) {
                    return;
                }

                // Search for a match (case-insensitive)
                var value = this.input.val(),
                    valueLowerCase = value.toLowerCase(),
                    valid = false;
                this.element.children("option").each(function () {
                    if ($(this).text().toLowerCase() === valueLowerCase) {
                        this.selected = valid = true;
                        return false;
                    }
                });

                // Found a match, nothing to do
                if (valid) {
                    return;
                }

                // Remove invalid value
                this.input
                    .val("")
                    .attr("title", value + " didn't match any item")
                    .tooltip("open");
                this.element.val("");
                this._delay(function () {
                    this.input.tooltip("close").attr("title", "");
                }, 2500);
                this.input.autocomplete("instance").term = "";
            },

            _destroy: function () {
                this.wrapper.remove();
                this.element.show();
            }
        });

        $("#combobox").combobox();

    });
</script>
