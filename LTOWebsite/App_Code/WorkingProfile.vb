Imports System.Web.Configuration
Imports System.Net.Mail
Imports AppOperate
Public Class WorkingProfile

    Public ApplName As String = "LTO"

    'Public Shared Property CurrentPage() As String
    '    Get
    '        Return HttpContext.Current.Session("currentpage")
    '    End Get
    '    Set(ByVal value As String)
    '        HttpContext.Current.Session("currentpage") = value
    '     End Set
    'End Property
    Public Shared Function checkAppTypebyUserID(ByVal userID As String, ByVal appID As String) As String
        Dim rAppID As String = appID
        '   If userID = "frijiom" Then rAppID = "LTO"  required by Mary Frijio at 2014/08/11, take out this check
        If userID = "krasnor" Then rAppID = "POP"
        If userID = "boreanf" Then rAppID = "POP"
        Return rAppID
    End Function

    Public Shared Property LoginStatues(ByVal action As String) As String
        Get
            Return HttpContext.Current.Session("LoginStatues")
        End Get
        Set(ByVal value As String)
            HttpContext.Current.Session("LoginStatues") = value
            UserTrack.TrackInfo(UserID, action, value)
        End Set
    End Property
    Public Shared Property UserID() As String
        Get
            If HttpContext.Current.Session("userID") = Nothing Then HttpContext.Current.Session("userID") = HttpContext.Current.User.Identity.Name
            Return HttpContext.Current.Session("userID")
        End Get
        Set(ByVal value As String)
            HttpContext.Current.Session("userID") = value
        End Set
    End Property
    Public Shared Property UserRole() As String
        Get
            If HttpContext.Current.Session("userrole") = Nothing Then
                HttpContext.Current.Session("userrole") = UserTrack.TrackInfo(UserID, "UserRole")
            End If
            Return HttpContext.Current.Session("userrole")
        End Get
        Set(ByVal value As String)
            If value = "Design" Then value = "Admin"
            HttpContext.Current.Session("userrole") = value
            UserTrack.TrackInfo(UserID, "UserRole", value)
        End Set
    End Property
    Public Shared Property LoginRole() As String
        Get
            If HttpContext.Current.Session("loginrole") = Nothing Then HttpContext.Current.Session("loginrole") = WorkingProfile.UserRole
            Return HttpContext.Current.Session("loginrole")
        End Get
        Set(ByVal value As String)
            HttpContext.Current.Session("loginrole") = value
        End Set
    End Property
    Public Shared Property UserName() As String
        Get
            If HttpContext.Current.Session("username") = Nothing Then HttpContext.Current.Session("username") = UserTrack.TrackInfo(UserID, "UserName")
            Return HttpContext.Current.Session("username")
        End Get
        Set(ByVal value As String)
            HttpContext.Current.Session("username") = value
        End Set
    End Property

    Public Shared Property UserPosition() As String
        Get
            If HttpContext.Current.Session("userposition") = Nothing Then HttpContext.Current.Session("userposition") = UserTrack.TrackInfo(UserID, "UserPosition")
            Return HttpContext.Current.Session("userposition")
        End Get
        Set(ByVal value As String)
            HttpContext.Current.Session("userposition") = value
        End Set
    End Property
    Public Shared Property UserCPNum() As String
        Get
            If HttpContext.Current.Session("usercpnum") = Nothing Then HttpContext.Current.Session("usercpnum") = UserTrack.TrackInfo(UserID, "CPNum")
            Return HttpContext.Current.Session("usercpnum")
        End Get
        Set(ByVal value As String)
            HttpContext.Current.Session("usercpnum") = value
        End Set
    End Property


    Public Shared Property SchoolYear() As String
        Get
            If HttpContext.Current.Session("schoolyear") = Nothing Then HttpContext.Current.Session("schoolyear") = UserTrack.TrackInfo(UserID, "SchoolYear")
            Return HttpContext.Current.Session("schoolyear")
        End Get
        Set(ByVal value As String)
            If Not value = Nothing Then
                If Not value = HttpContext.Current.Session("schoolyear") Then
                    HttpContext.Current.Session("schoolyear") = value
                    UserTrack.TrackInfo(UserID, "SchoolYear", value)
                End If
            End If
        End Set
    End Property
    Public Shared Property SchoolYearPre() As String
        Get
            If HttpContext.Current.Session("schoolyearPre") = Nothing Then HttpContext.Current.Session("schoolyearPre") = UserTrack.TrackInfo(UserID, "pSchoolYear")
            Return HttpContext.Current.Session("schoolyearPre")
        End Get
        Set(ByVal value As String)
            HttpContext.Current.Session("schoolyearPre") = value

        End Set
    End Property
    Public Shared Property SchoolYearCurrent() As String
        Get
            If HttpContext.Current.Session("schoolyearcurrent") = Nothing Then HttpContext.Current.Session("schoolyearcurrent") = UserTrack.TrackInfo(UserID, "cSchoolYear")
            Return HttpContext.Current.Session("schoolyearcurrent")
        End Get
        Set(ByVal value As String)
            HttpContext.Current.Session("schoolyearcurrent") = value
        End Set
    End Property

    Public Shared Property SchoolName() As String
        Get
            If HttpContext.Current.Session("schoolname") = Nothing Then HttpContext.Current.Session("schoolname") = UserTrack.TrackInfo(UserID, "SchoolName")

            Return HttpContext.Current.Session("schoolname")
        End Get
        Set(ByVal value As String)
            HttpContext.Current.Session("schoolname") = value
        End Set
    End Property
    Public Shared Property SchoolBriefName() As String
        Get
            Return HttpContext.Current.Session("schoolbriefname")
        End Get
        Set(ByVal value As String)
            HttpContext.Current.Session("schoolbriefname") = value
        End Set
    End Property
    Public Shared Property SchoolCode() As String
        Get
            If HttpContext.Current.Session("schoolcode") Is Nothing Then HttpContext.Current.Session("schoolcode") = UserTrack.TrackInfo(UserID, "SchoolCode")
            Return HttpContext.Current.Session("schoolcode")
        End Get
        Set(ByVal value As String)
            If Not value = Nothing Then
                If Not value = HttpContext.Current.Session("schoolcode") Then
                    HttpContext.Current.Session("schoolcode") = value
                    UserTrack.TrackInfo(UserID, "SchoolCode", value)
                    SchoolArea = UserTrack.SchoolProfile("SchoolArea", SchoolYear, SchoolCode)
                    SchoolSuper = UserTrack.SchoolProfile("SchoolSuper", SchoolYear, SchoolCode)
                End If
            End If

        End Set
    End Property

    Public Shared Property ApplicationType() As String
        Get
            If HttpContext.Current.Session("typeapplication1") Is Nothing Then
                HttpContext.Current.Session("typeapplication1") = UserTrack.TrackInfo(UserID, "ApplicationType")
            End If

            Return HttpContext.Current.Session("typeapplication1")
        End Get
        Set(ByVal value As String)
            If Not value = Nothing Then
                If Not value = HttpContext.Current.Session("typeapplication1") Then
                    HttpContext.Current.Session("typeapplication1") = value
                    UserTrack.TrackInfo(UserID, "ApplicationType", value)
                End If
            End If
        End Set
    End Property

    Public Shared Property Panel() As String
        Get
            If HttpContext.Current.Session("workingPanel") Is Nothing Then
                HttpContext.Current.Session("workingPanel") = UserTrack.TrackInfo(UserID, "WorkingPanel")
                'If Left(SchoolCode, 2) = "05" Then
                '    HttpContext.Current.Session("workingPanel") = "05"
                'Else
                '    HttpContext.Current.Session("workingPanel") = "02"
                'End If
            End If

            Return HttpContext.Current.Session("workingPanel")
        End Get
        Set(ByVal value As String)
            HttpContext.Current.Session("workingPanel") = value
        End Set
    End Property

    Public Shared Property SearchBy() As String
        Get
            If HttpContext.Current.Session("searchby") Is Nothing Then HttpContext.Current.Session("searchby") = UserTrack.TrackInfo(UserID, "searchby")
            Return HttpContext.Current.Session("searchby")
        End Get
        Set(ByVal value As String)
            If Not value = Nothing Then
                If Not value = HttpContext.Current.Session("searchby") Then
                    HttpContext.Current.Session("searchby") = value
                    UserTrack.TrackInfo(UserID, "searchby", value)
                End If
            End If

        End Set

    End Property
    Public Shared Property SearchByValue() As String
        Get
            If HttpContext.Current.Session("searchValue") Is Nothing Then HttpContext.Current.Session("searchValue") = UserTrack.TrackInfo(UserID, "searchValue")
            Return HttpContext.Current.Session("searchValue")
        End Get
        Set(ByVal value As String)
            If Not value = Nothing Then
                If Not value = HttpContext.Current.Session("searchValue") Then
                    HttpContext.Current.Session("searchValue") = value
                    UserTrack.TrackInfo(UserID, "searchValue", value)
                End If
            End If

        End Set

    End Property
    Public Shared Property SearchByValue2() As String
        Get
            If HttpContext.Current.Session("searchValue2") Is Nothing Then HttpContext.Current.Session("searchValue2") = UserTrack.TrackInfo(UserID, "searchValue2")
            Return HttpContext.Current.Session("searchValue2")
        End Get
        Set(ByVal value As String)
            If Not value = Nothing Then
                If Not value = HttpContext.Current.Session("searchValue2") Then
                    HttpContext.Current.Session("searchValue2") = value
                    UserTrack.TrackInfo(UserID, "searchValue2", value)
                End If
            End If

        End Set

    End Property
    Public Shared Property SchoolDate() As String
        Get
            If HttpContext.Current.Session("schooldate") Is Nothing Then HttpContext.Current.Session("schooldate") = UserTrack.TrackInfo(UserID, "SchoolDate")
            Return HttpContext.Current.Session("schooldate")
        End Get
        Set(ByVal value As String)
            HttpContext.Current.Session("schooldate") = value
            UserTrack.TrackInfo(UserID, "SchoolDate", value)
        End Set
    End Property
    Public Shared Property SmartGoalCategory() As String
        Get
            If HttpContext.Current.Session("personID") Is Nothing Then HttpContext.Current.Session("personID") = UserTrack.TrackInfo(UserID, "PersonID")
            Return HttpContext.Current.Session("personID")
        End Get
        Set(ByVal value As String)
            HttpContext.Current.Session("personID") = value
            UserTrack.TrackInfo(UserID, "PersonID", value)
        End Set
    End Property


    Public Shared Property Permission() As String
        Get
            Return HttpContext.Current.Session("permission")
        End Get
        Set(ByVal value As String)
            HttpContext.Current.Session("permission") = value
        End Set
    End Property
    Public Shared Property Position() As String
        Get
            If HttpContext.Current.Session("userposition") = Nothing Then HttpContext.Current.Session("userposition") = UserTrack.TrackInfo(UserID, "UserPosition")
            Return HttpContext.Current.Session("userposition")
        End Get
        Set(ByVal value As String)
            HttpContext.Current.Session("userposition") = value
        End Set
    End Property
    Public Shared Property SuperArea() As String
        Get
            If HttpContext.Current.Session("superArea") = Nothing Then HttpContext.Current.Session("superArea") = UserTrack.TrackInfo(UserID, "SuperArea")
            Return HttpContext.Current.Session("superArea")
        End Get
        Set(ByVal value As String)
            HttpContext.Current.Session("superArea") = value
        End Set
    End Property
    Public Shared Property SuperName() As String
        Get
            If HttpContext.Current.Session("superName") = Nothing Then HttpContext.Current.Session("superName") = UserTrack.TrackInfo(UserID, "SuperName")
            Return HttpContext.Current.Session("superName")
        End Get
        Set(ByVal value As String)
            HttpContext.Current.Session("superName") = value
        End Set
    End Property

    Public Shared Property WorkingPage() As String
        Get
            Return HttpContext.Current.Session("WorkingPage")
        End Get
        Set(ByVal value As String)
            HttpContext.Current.Session("WorkingPage") = value
        End Set
    End Property
    Public Shared Property WorkingItem() As String
        Get
            Return HttpContext.Current.Session("WorkingItemID")
        End Get
        Set(ByVal value As String)
            HttpContext.Current.Session("WorkingItemID") = value
        End Set
    End Property
    Public Shared Property WorkingQuestionID() As String
        Get
            Return HttpContext.Current.Session("WorkingQuestionID")
        End Get
        Set(ByVal value As String)
            HttpContext.Current.Session("WorkingQuestionID") = value
        End Set
    End Property
    Public Shared Property GQType() As String
        Get
            Return HttpContext.Current.Session("GQType")
        End Get
        Set(ByVal value As String)
            HttpContext.Current.Session("GQType") = value
        End Set
    End Property
    Public Shared Property GQCode() As String
        Get
            Return HttpContext.Current.Session("GQCode")
        End Get
        Set(ByVal value As String)
            HttpContext.Current.Session("GQcode") = value
        End Set
    End Property
    Public Shared Property ResponseType() As String
        Get
            Return HttpContext.Current.Session("ResponseType")
        End Get
        Set(ByVal value As String)
            HttpContext.Current.Session("ResponseType") = value
        End Set
    End Property
    Public Shared Property ResponseOwner() As String
        Get
            Return HttpContext.Current.Session("ResponseOwner")
        End Get
        Set(ByVal value As String)
            HttpContext.Current.Session("ResponseOwner") = value
        End Set
    End Property

    Public Shared Property SchoolArea() As String
        Get
            If HttpContext.Current.Session("SchoolArea") = Nothing Then HttpContext.Current.Session("SchoolArea") = UserTrack.SchoolProfile("SchoolArea", SchoolYear, SchoolCode)

            Return HttpContext.Current.Session("SchoolArea")
        End Get
        Set(ByVal value As String)
            HttpContext.Current.Session("SchoolArea") = value
        End Set
    End Property

    Public Shared Property SchoolSuper() As String
        Get
            If HttpContext.Current.Session("SchoolSuper") = Nothing Then HttpContext.Current.Session("SchoolSuper") = UserTrack.SchoolProfile("SchoolSuper", SchoolYear, SchoolCode)

            Return HttpContext.Current.Session("SchoolSuper")
        End Get
        Set(ByVal value As String)
            HttpContext.Current.Session("SchoolSuper") = value
        End Set
    End Property
End Class

