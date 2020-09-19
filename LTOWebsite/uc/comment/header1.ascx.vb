'Imports TCDSB.Student

Partial Class header1
    Inherits System.Web.UI.UserControl
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        'Put user code to initialize the page here
        If Not Page.IsPostBack Then
            ' Common.UserProfileT.cPage = Me.Page
            Dim cDB As String = System.Configuration.ConfigurationManager.ConnectionStrings("currentDB").ToString
            ' Dim _applID As String = System.Configuration.ConfigurationManager.AppSettings("Application")
            '  WorkingProfile.ApplicationType = _applID
            ' Dim appID = Page.Request.QueryString("appid")
            ' If Not appID = Nothing Then WorkingProfile.ApplicationType = appID
            If Not WorkingProfile.LoginRole Is Nothing Then
                Me.hfLoginRole.Value = WorkingProfile.LoginRole
            End If

            If WorkingProfile.ApplicationType = "LTO" Then
                Me.lblApplication.Text = "LTO Assignments"
                Me.appLink.InnerHtml = "LTO"
            End If

            If WorkingProfile.ApplicationType = "POP" Then
                Me.lblApplication.Text = "Permanent Open Position"
                Me.appLink.InnerHtml = "POP"
            End If
            If WorkingProfile.UserRole = "Principal" Then
                Me.lblApplication.Text = "LTO Assignments & Permanent Open Position"
                TitilCell.Attributes.Add("class", "PTitle")

                Me.appLink.InnerHtml = "LTO/POP"
            End If
            '  Me.lblVersion.Text = "TCDSB (Version 1.0.1)"
            If cDB = "Production" Then
                Me.LabelTrain.Visible = True
                Me.LabelTrain.Text = ""
            Else
                Me.LabelTrain.Visible = True
                Me.LabelTrain.Text = WorkingProfile.ApplicationType & " " & cDB

            End If
            Dim _title As String = " You are working on " & WorkingProfile.ApplicationType & " " & cDB & " Version. Data save to " & cDB & " Database"
            Me.TableVersion.Attributes.Add("title", _title)
        End If
        GetUserSecurityProfile()


    End Sub
    Private Sub GetUserSecurityProfile()
        Try
            Dim _userID As String = HttpContext.Current.User.Identity.Name

            Dim _Role As String = WorkingProfile.UserRole
            ' WorkingProfile.Permission = Common.UserSecurity.Permission(_userID, _Role)

            Dim _lblStr1 As String = "School Year: " + "<a title ='click on the year to change school year' href='Default_Home.aspx' target='mainTop'>" + WorkingProfile.SchoolYear + "</a>"
            Dim _lblStr2 As String = "  &nbsp;&nbsp;    &nbsp;&nbsp;  " + " School:  " + "<a title ='click on the school to change school' href='Default_Home.aspx' target='mainTop'>" + WorkingProfile.SchoolCode + "--" + WorkingProfile.SchoolName + "</a>"
            Dim _lblStr4 As String = ""
            Dim _lblStr5 As String = "   &nbsp;&nbsp;   &nbsp;&nbsp;  " + "  Online Users: " + CType(Application("UsersOnline"), String)
            Dim _lblStr6 As String = ""
            If Not HttpContext.Current.User.Identity.Name = "mif" Then _lblStr5 = ""

            If Me.hfLoginRole.Value = "Admin" Or Me.hfLoginRole.Value = "HRStaff" Or Me.hfLoginRole.Value = "HRStaff4" Then
                _lblStr4 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; " + _userID + "  Login as: " + "<a title= 'click on the role to change the Login Role ' href='Default_role.aspx' target='mainTop'>" + WorkingProfile.UserRole + "</a>"
            Else
                _lblStr4 = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; " + _userID + " Login as: " + WorkingProfile.UserRole
            End If
            If Me.hfLoginRole.Value = "Admin" Or Me.hfLoginRole.Value = "HRStaff" Or Me.hfLoginRole.Value = "HRStaff4" Then
                _lblStr6 = "   &nbsp;&nbsp; &nbsp;&nbsp;" + "<a title= 'click on the link to check the LTO/Roster List' href='Default_CheckList.aspx' target='mainTop'>" + "Check OT" + "</a>"
            End If
            Me.Label1.Text = _lblStr1 & _lblStr2 & _lblStr4 & _lblStr5 + _lblStr6

        Catch ex As Exception
            ' CommonTCDSB.ShowMsg .Exception(ex, Me.Page, "get User Role Profile ")
        End Try
    End Sub
    'Private Function getNamebyID(ByVal id As String, ByVal type As String) As String
    '    Return SetupList.getNamebyID(id, type)
    'End Function

    'Private Sub mySetup()
    '    Dim _userID As String = HttpContext.Current.User.Identity.Name

    '    Dim myCtl As Menu = Me.Menu1 ' Infragistics.WebUI.UltraWebNavigator.UltraWebMenu = Me.UltraWebMenu1
    '    If Right(_userID, 3) = "mif" Then ' (_user = "mif" Or _user = "CEC\mif") Then
    '        myCtl.Items.Item(12).Enabled = True
    '    Else
    '        myCtl.Items.Item(12).Enabled = False
    '        myCtl.Items.Item(12).Text = ""
    '    End If
    'End Sub



End Class

