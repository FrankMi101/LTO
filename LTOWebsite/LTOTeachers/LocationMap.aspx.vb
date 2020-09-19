'Imports TCDSB.Student
Imports AppOperate

Partial Class LocationMap
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Me.Page.Response.Expires = 0
            Dim schoolcode As String = Page.Request.QueryString("Schoolcode")
            Dim geoCode As String = UserTrack.SchoolGeoProfile("GeoCode", schoolcode)
            Dim City As String = UserTrack.SchoolGeoProfile("City", schoolcode)
            Dim postalcode As String = UserTrack.SchoolGeoProfile("PostalCode", schoolcode)

            Dim _mapSite As String = "https://maps.google.ca/maps?f=q&source=s_q"
            _mapSite = _mapSite & "&hl=en&geocode=&q=" & postalcode & "&aq=" '  " m2n+6e8&aq="
            _mapSite = _mapSite & "&sll=" & geoCode & "&sspn=" '  43.762788,-79.407978&sspn=0.083312,0.196552"
            _mapSite = _mapSite & "&ie=UTF8&hq=&hnear=" & City & "+" & postalcode & "&t=m" '  North+York,+Ontario"  ' +M2N+6E8&t=m"
            _mapSite = _mapSite & "&ll=" & geoCode & "&spn=&z=14&output=embed" '"43.76285,-79.407978&spn=0.029754,0.054932&z=14&output=embed"
            '     _mapSite = _mapSite & "&sll=" & geoCode & "&sspn=0.083312,0.196552" '  43.762788,-79.407978&sspn=0.083312,0.196552"
            '      _mapSite = _mapSite & "&ll=" & geoCode & "&spn=0.029754,0.054932&z=14&output=embed" '"43.76285,-79.407978&spn=0.029754,0.054932&z=14&output=embed"

            Me.myGooglMap.Attributes.Add("src", _mapSite)
            Dim _mapSite2 As String = "https://maps.google.ca/maps?f=q&source=embed"
            _mapSite2 = _mapSite2 & "&hl=en&geocode=&q=" & postalcode & "&aq = " ' m2n+6e8&aq="
            _mapSite2 = _mapSite2 & "&sll=" & geoCode & "&sspn=" ' 0.083312,0.196552" ' "&sll=43.762788,-79.407978&sspn=0.083312,0.196552"
            _mapSite2 = _mapSite2 & "&ie=UTF8&hq=&hnear=" & City & "+" & postalcode & "&t=m"  '"&ie=UTF8&hq=&hnear=North+York,+Ontario+M2N+6E8&t=m"
            _mapSite2 = _mapSite2 & "&ll=" & geoCode & "&spn=&z=14" '"&ll=43.76285,-79.407978&spn=0.029754,0.054932&z=14"
            '   Me.goBig.HRef = _mapSite2

        End If
    End Sub
End Class
