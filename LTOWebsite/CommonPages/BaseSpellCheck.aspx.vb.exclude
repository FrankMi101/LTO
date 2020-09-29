
'Imports TCDSB.Student

Partial Class BaseSpellCheck
        Inherits System.Web.UI.Page
        'Protected strRetval() As String
        'Protected strFormName As String
        'Protected strCtrlName As String
        'Dim WordApp As New Word.Application

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

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            'strFormName = Request.QueryString("FormName")
            'strCtrlName = Request.QueryString("CtrlName")
            Me.hfFormID.Value = Request.QueryString("FormName")
            Me.hfControlID.Value = Request.QueryString("CtrlName")
            If Not Page.IsPostBack Then
                Page.Response.Expires = 0
                '  Me.Label1.Text = SES.IEP.CopyIEP.IEPTitle(_userID, strTitle)
                Me.Rapidspellweblauncher1.LicenseKey = System.Configuration.ConfigurationManager.AppSettings("RapidKey")
                Dim _role As String = Session("UserRole")
                'Me.ImgLink.HRef = Common.HelpFile.FileLink("IEP", 1, "SpellCheck", 1, 1, "Teacher", "WMV")
                'If Session("UserRole") = "Admin" Then
                '    Me.labelHelpFile.Visible = True
                '    Me.labelHelpFile.Text = "<A Href=" + """" + "javascript:HelpFileSetup('IEP','1','1','SpellCheck')" + """" + ">HF</A>"
                'End If
            End If
            ' Me.RapidSpellWebLauncher1.SpellCheckText = Me.txtMyText.Value ' .text '  .CallBack()
            'Me.RapidSpellWebLauncher1.RaisePostBackEvent("RapidSpellWebLauncher1.Click")
        End Sub
        Private Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
            If Not Session("mytheme") Is Nothing Then
                Me.Theme = Session("mytheme")

            End If
        End Sub
        ' ### setup Page StylesheetTheme
        Public Overrides Property StyleSheetTheme() As String
            Get
                Return Session("mytheme")
            End Get
            Set(ByVal value As String)
            End Set
        End Property
    End Class


