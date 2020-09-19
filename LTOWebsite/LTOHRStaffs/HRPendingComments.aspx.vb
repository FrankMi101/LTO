'Imports System.Data
'Imports System.Data.SqlClient
Imports AppOperate
Imports ClassLibrary
'Imports TCDSB.Student
Partial Class HRPendingComments

    Inherits System.Web.UI.Page


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Page.Response.Expires = 0
            BindGridData()
        End If

    End Sub


    Private Sub BindGridData()
        Try
            '  Dim ds As DataSet
            '  ds = GetDataset(goDatabase)
            Me.GridView1.DataSource = getDataSource() ' ds.Tables(0)
            GridView1.DataBind()

        Catch ex As Exception
            ShowMessage.Exception(ex, Me.Page, "Bind data action")
        End Try
    End Sub
    Private Function getDataSource() As List(Of HRComments)

        Dim para = New With {Key .Action = "Get", Key .UserID = User.Identity.Name, Key .CPNum = Page.Request.QueryString("CPNum")}
        Dim comments As List(Of HRComments) = LTOStaffManageExe.CommentsList(para)
        Return comments
    End Function


End Class
