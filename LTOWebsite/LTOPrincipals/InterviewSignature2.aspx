<%@ Page Language="VB" AutoEventWireup="false" CodeFile="InterviewSignature2.aspx.vb" Inherits="InterviewSignature2" EnableTheming="true" %>

<link href="../Styles/BubbleHelp.css" rel="stylesheet" />

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Principal Interview </title>
    <base target="_self" />
    <meta http-equiv="Pragma" content="No-cache" />
    <style type="text/css">
        body {
            height: 97%;
            width: 99.5%;
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
            background-color: skyblue;
        }

        .textboxF {
            font-family: Arial, 'DejaVu Sans', 'Liberation Sans', Freesans, sans-serif;
            font-size: 12px;
        }

        .SingOffButton {
            border: 2px outset skyblue;
            background-color: #ff9900;
            width: 80px;
            height: 20px;
            text-align:center;
          margin-top:3px;
          padding-top:3px;
        }

        #SignOffTable {
            font-size: small;
            height: 100px;
        }

            #SignOffTable tr {
                height: 25px;
            }

        #PopUpSignOff table tr {
            height: 25px;
        }

        img {
            width: 25px;
            height: 25px;
        }

        #iHM40 {
            height: 350px;
            width: 650px;
        }

        #LabelCandidateName {
            border-bottom: 2px solid;
        }
    </style>


</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table>
            <tr>
                <td>
                    <div style="background-image: url(../images/message_body_m.bmp)">
                        <h3 style="display:none;">Signature for Interview Candidate:    
                            <asp:Label ID="LabelName" runat="server" Text="" ForeColor="Blue"></asp:Label>
                        </h3>

                        <table id="SignOffTable" style="width: 450px; border: 1px solid #808080; font-family:Arial, sans-serif; font-size:small">
                            <tr>
                                <td>Candidate Sign Off:</td>
                                <td>
                                    <asp:Label ID="LabelSignatureP0" runat="server" Text="" CssClass="SignOffName"></asp:Label></td>
                                <td>
                                    <asp:HiddenField ID="hfUserIDP0" runat="server" />
                                </td>
                                <td>
                                    <img alt="" src="../images/chinaz13.ico" id="imgSignOffP0" runat="server" />
                                </td>
                                <td>

                                    <asp:Label ID="LabelSignOffP0" runat="server" Text="Sign Off" CssClass="SingOffButton"></asp:Label>
                                </td>

                                <td>
                                    <asp:HiddenField ID="hfSignOffP0" runat="server" />

                                </td>
                            </tr>
                            <tr>
                                <td>1<sup>st </sup>Interviewer Sign Off:</td>
                                <td>
                                    <asp:Label ID="LabelSignatureP1" runat="server" Text="" CssClass="SignOffName"></asp:Label></td>
                                <td>
                                    <asp:HiddenField ID="hfUserIDP1" runat="server" />
                                </td>
                                <td>
                                    <img alt="" src="../images/chinaz13.ico" id="imgSignOffP1" runat="server" />
                                </td>
                                <td>
                                    <asp:Label ID="LabelSignOffP1" runat="server" Text="Sign Off" CssClass="SingOffButton"></asp:Label>
                                </td>

                                <td>
                                    <asp:HiddenField ID="hfSignOffP1" runat="server" />

                                </td>
                            </tr>
                            <tr>
                                <td>2<sup>nd</sup> Interviewer Sign Off:</td>
                                <td>
                                    <asp:Label ID="LabelSignatureP2" runat="server" Text="" CssClass="SignOffName"></asp:Label></td>
                                <td>
                                    <asp:HiddenField ID="hfUserIDP2" runat="server" />
                                </td>
                                <td>
                                    <img alt="" src="../images/chinaz13.ico" id="imgSignOffP2" runat="server" />
                                </td>
                                <td>
                                    <asp:Label ID="LabelSignOffP2" runat="server" Text="Sign Off" CssClass="SingOffButton"></asp:Label>
                                </td>

                                <td>
                                    <asp:HiddenField ID="hfSignOffP2" runat="server" />

                                </td>
                            </tr>
                            <tr id="SignOffRow3" runat="server">
                                <td>3<sup>rd</sup> Interviewer Sign Off:


                                </td>
                                <td>
                                    <asp:Label ID="LabelSignatureP3" runat="server" Text="" CssClass="SignOffName"></asp:Label></td>
                                <td>
                                    <asp:HiddenField ID="hfUserIDP3" runat="server" />
                                </td>
                                <td>
                                    <img alt="" src="../images/chinaz13.ico" id="imgSignOffP3" runat="server" /></td>
                                <td>
                                    <asp:Label ID="LabelSignOffP3" runat="server" Text="Sign Off" CssClass="SingOffButton"></asp:Label>
                                </td>

                                <td>
                                    <asp:HiddenField ID="hfSignOffP3" runat="server" />

                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="font-family: Arial, sans-serif; font-size: small; height: 350px; width: 100%; overflow: auto;">
                        <b>TCDSB POLICY REGISTER, </b>
                        <br />
                        <h3>FAIR PRACTICE IN HIRING AND PROMOTION H.M. 40 </h3>
                        <b>Policy: </b>
                        The TCDSB is committed to hiring and promoting the best, most qualified individuals supportive of its Multi Year Strategic Plan, subject to its denominational rights and in accordance with the Ontario Human Rights Code. The application, interview, hiring and promotion of individuals at TCDSB will be based on ability and qualifications and will be conducted in a fair and transparent manner, free from discrimination, nepotism and cronyism.
                        <br />
                        <b>Regulations:</b>
                        <br />
                        <ol>
                            <li>Recruitment practices and application processes used at TCDSB will be open and transparent, free from nepotism and cronyism, ensuring no partiality or preferential treatment as a result of personal relationships.
                            </li>
                            <li>Any applicant for employment or promotion at TCDSB will not be advantaged or disadvantaged as a result of a relationship with an immediate family member or relative employed at TCDSB.
                            </li>
                            <li>The procedures followed for the review of applications for employment will allow for equal opportunity for all applicants, free from conflict of interest. (hyperlink to Appendix A).
                            </li>
                            <li>Any TCDSB employee charged with responsibilities for interviewing, hiring, placement or promotion of applicants must declare a conflict of interest, where applicable, prior to fulfilling their duties and may be excluded from the decision-making process.
                            </li>
                            <li>A Trustee or a TCDSB employee in a position of leadership will not influence the hiring or promotion process through unsolicited promotion and recommendations of candidates.
                            </li>
                            <li>Placement of employees through the transfer process shall be fair, transparent and respectful of collective agreements and/or terms and conditions of employment contracts.
                            </li>
                            <li>Applicants unsuccessful in their attempt to gain employment or promotion at TCDSB will be afforded the opportunity to request descriptive feedback.
                            </li>
                        </ol>
                        <b style="font-size: 1.2em">Definitions: </b>
                        <br />
                        <b>Conflict of Interest: </b>This is a situation in which the impartial exercise of the duty of an individual acting for an organization is compromised by that person’s self-interest and position, often undermining the public trust.
                        <br />
                        <b>Cronyism: </b>The act of showing partiality to friends or close colleagues, especially in the application, hiring, placement and promotion stages of employment, without regard to qualifications or ability. In the context of this policy, cronyism can occur when an individual within the organization influences the decision to hire or promote a friend or colleague.
                        <br />
                        <b>Immediate Family:</b> Members consist of a person’s spouse, child(ren), step child(ren) or parent of an employee.
                        <br />
                        <b>Nepotism: </b>The act of showing favouritism or providing preferential treatment to a family member or close relatives, especially in the application, hiring and placement stages of employment. In the context of this policy, nepotism can occur when an individual within the organization influences the decision to hire or promote a close family member, or supervises that subordinate family member.
                        <br />
                        <b>Relative:</b> Members consist of siblings, step-children, nieces, nephews, grandparents, cousins and in-laws.
                        <br />
                        <br />
                        CANDIDATE(s):
                        <asp:Label ID="LabelCandidateName" runat="server" Text="Candidate Name" Font-Bold="true" Font-Size="small"></asp:Label>
                        <br />
                        <br />
                        <b>I have read Policy H.M. 40 and I have no conflict interviewing the above candidate(s)</b>
                        <br />
                        <br />
                        Interview Committee Signature: Name (Print) ____________ Name (Signature) ______________
                     
                        <br />
                        <br />
                        <b>This form must be completed for each candidate interviewer/applicant.</b>
                    </div>

                </td>

            </tr>

        </table>


        <asp:HiddenField ID="HiddenFieldAction" runat="server" Value="No" />
        <asp:HiddenField ID="hfUserCPNum" runat="server" />
        <asp:HiddenField ID="hfSchoolyear" runat="server" />
        <asp:HiddenField ID="hfSchoolname" runat="server" />
        <asp:HiddenField ID="hfIDs" runat="server" />
        <asp:HiddenField ID="hfPositionID" runat="server" />
        <asp:HiddenField ID="hfSignOffNo" runat="server" />
        <asp:HiddenField ID="hfSignOfffUserID" runat="server" />


        <div id="PopUpSignOff" class="bubble hide" style="width: 200px; height: 130px; background-color: skyblue;">
            <table id="Table2" cellspacing="1" cellpadding="1" align="left" border="0" style="width: 180px; height: 100px; font-size: x-small">

                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server">Domain:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDomain" runat="server" Width="100px" ReadOnly="true">CEC</asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server">Username:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUsername" runat="server" Width="100px" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server">Password:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" Width="100px" TextMode="Password" AutoComplete="Disabled" AutoCompleteType="Disabled"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td align="left" colspan="2">
                        <p align="center">
                            <asp:Button ID="btnLogin" runat="server" Text="Login" Width="101px" BackColor="#E0E0E0"></asp:Button>
                        </p>

                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="errorlabel" runat="server" Visible="false"> </asp:Label>
                    </td>
                </tr>

            </table>
        </div>

    </form>
</body>
</html>

<script src="../Scripts/jQuery/jquery-1.11.2.js" type="text/javascript"></script>
<script src="../JQuery-UI/jquery-ui-1.11.4.min.js" type="text/javascript"></script>
<link href="../JQuery-UI/jquery-ui.css" rel="stylesheet" type="text/css" />
<script type="text/jscript">


    $(document).ready(function () {
        var dv1 = "none";
        var dv = $("#hfSignOffP0").val();
        $("#imgSignOffP0").css("display", dv);
        $("#LabelSignOffP0").css("display", ((dv == 'none') ? 'block' : 'none'))

        dv = $("#hfSignOffP1").val();
        $("#imgSignOffP1").css("display", dv);
        $("#LabelSignOffP1").css("display", ((dv == 'none') ? 'block' : 'none'))

        dv = $("#hfSignOffP2").val();
        $("#imgSignOffP2").css("display", dv);
        $("#LabelSignOffP2").css("display", ((dv == 'none') ? 'block' : 'none'))

        dv = $("#hfSignOffP3").val();
        $("#imgSignOffP3").css("display", dv);
        $("#LabelSignOffP3").css("display", ((dv == 'none') ? 'block' : 'none'))


        $(".SingOffButton").click(function (e) {
            ItemCode = $(this)[0].id;
            $("#hfSignOffNo").val(ItemCode);
            var objID = ItemCode.replace("LabelSignOff", "hfUserID");
            $("#txtUsername").val($("#" + objID).val());
            $("#hfSignOfffUserID").val($("#txtUsername").val());
            var vTop = event.currentTarget.offsetTop;
            var vLeft = event.currentTarget.offsetLeft;

            POPHelp(vTop, vLeft + 460, 110, 180);
            //var yID = $("#hfSchoolyear").val();
            //var cpnum = $("#hfUserCPNum").val();
            //var pID = $("#hfPositionID").val();
            //var printPage = "../PDFLoading/PDFDocument_Loading.aspx?rID=InterviewPackage" + "&yID=" + yID + "&CPNum=" + cpnum + "&pID=" + pID;
            //var popup1 = window.open(printPage, "", "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=yes,width=800,height=600,top=0,left=0");

        });


    });
    function openLTOAppraisal(schoolyear, schoolcode, SessionID, TeacherID) {
        var printPage = "../PDFLoading/PDFDocument_Loading.aspx?rID=InterviewPackage" + "&yID=" + schoolyear + "&CPNum=" + TeacherID + "&pID=" + SessionID;
        var popup1 = window.open(printPage, "", "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=yes,width=800,height=600,top=0,left=0");
    }
    function POPHelp(vTop, vLeft, vHeight, vWidth) {
        $("#PopUpSignOff").css({
            top: vTop,
            left: vLeft,
            height: vHeight,
            width: vWidth
        })
        // window.alert(vTop);

        $("#PopUpSignOff").fadeToggle("fast");//.show();// 
    }

</script>
