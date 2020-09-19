Namespace Common

    Public Class CAttachment

        Private _Split As String = "~~!!@@##$$%%^^&&**(())__++||"

        Private _AttachName As String

        Private _EncodeAttach As String = ""

        Private _AttachFileCount As Integer

        Private _AttachFiles As CFileCollection

        Public ReadOnly Property GetAttachFiles() As CFileCollection

            Get

                Return _AttachFiles

            End Get

        End Property

        Public ReadOnly Property GetAttachFileCount() As Integer

            Get

                Return _AttachFileCount

            End Get

        End Property

        Public ReadOnly Property AttachName() As String

            Get

                Return _AttachName

            End Get

        End Property

        Public ReadOnly Property GetAttachContent() As String

            Get

                If _EncodeAttach = "" Then

                    EncodeAttach(_EncodeAttach, _AttachName, _AttachFiles)

                End If

                Return _EncodeAttach

            End Get

        End Property

        Public Sub New(ByVal attach_name As String, ByVal attach_file As CAttachFile)

            _AttachName = attach_name

            _AttachFiles = New CFileCollection

            _AttachFiles.Add(attach_file)

            _AttachFileCount = _AttachFiles.Count

        End Sub

        Public Sub New(ByVal attach_name As String, ByVal attach_files As CFileCollection)

            _AttachName = attach_name

            _AttachFiles = attach_files

            _AttachFileCount = attach_files.Count

        End Sub

        Public Sub New(ByVal attach_content As String)

            _EncodeAttach = attach_content

            _AttachFiles = New CFileCollection

            DecodeAttach(_EncodeAttach, _AttachName, _AttachFiles)

            _AttachFileCount = _AttachFiles.Count

        End Sub

        Private Function EncodeFile(ByVal buf As Byte()) As String

            Return System.Convert.ToBase64String(buf)

        End Function

        Private Function DecodeFile(ByVal encodefile As String) As Byte()

            Dim buf() As Byte

            buf = System.Convert.FromBase64String(encodefile)

            Return buf

        End Function

        Private Function stringsplit(ByVal mainstr As String, ByVal splitstr As String) As String()

            Dim tempstr(mainstr.Length / splitstr.Length) As String

            Dim i, j, k As Integer

            If splitstr.Length <= 1 Then

                Return mainstr.Split(splitstr)

            Else

                i = 0

                k = 0

                Do While i < mainstr.Length



                    j = mainstr.IndexOf(splitstr, i)

                    If j = -1 Then

                        j = mainstr.Length

                    End If

                    tempstr(k) = mainstr.Substring(i, j - i)

                    i = j + splitstr.Length

                    k += 1

                Loop

                Dim retstr(k - 1) As String

                For i = 0 To k - 1

                    retstr(i) = tempstr(i)

                Next

                Return retstr

            End If

        End Function

        Private Function EncodeAttach(ByRef attach_content As String, ByVal attachname As String, ByVal attachfiles As CFileCollection) As Boolean

            Try

                Dim header As String = ""

                Dim body As String = ""

                Dim boundary1 As String = GetBoundary()

                Dim boundary2 As String = "-" + boundary1 + "-"

                header += "attachname:" + attachname.ToString + _Split

                header += "attachfiles:" + attachfiles.Count.ToString + _Split

                header += "boundary:" + boundary1 + _Split + _Split + _Split

                header += boundary2

                Dim attachfile As CAttachFile

                Dim i As Integer

                For i = 1 To attachfiles.Count

                    attachfile = attachfiles.Item(i)

                    body += "filename:" + attachfile.FileName + _Split

                    body += "filetype:" + attachfile.FileType + _Split

                    body += "filetitle:" + attachfile.FileTitle + _Split

                    body += "filedescription:" + attachfile.FileDescription + _Split

                    body += "filelength:" + attachfile.FileLength + _Split + _Split

                    body += EncodeFile(attachfile.GetBuf)

                    body += boundary2

                Next

                attach_content = header + body

            Catch ex As Exception

                Return False

            End Try

            Return True

        End Function

        Private Function DecodeAttach(ByVal attach_content As String, ByRef attachname As String, ByRef attachfiles As CFileCollection) As Boolean

            Try

                Dim header As String = ""

                Dim body As String = ""

                Dim boundary1, boundary2 As String

                Dim files_count As Integer

                Dim s(), afs(), h(), att(), b(), f() As String

                Dim filename, filetype, filetitle, filedescription As String

                s = stringsplit(attach_content, _Split + _Split + _Split)

                header = s(0)

                body = s(1)

                'handling header

                h = stringsplit(header, _Split)

                att = stringsplit(h(0), "attachname:")

                attachname = att(att.GetLength(0) - 1)

                afs = stringsplit(h(1), "attachfiles:")

                files_count = Int(afs(afs.GetLength(0) - 1))

                b = stringsplit(h(2), "boundary:")

                boundary1 = b(b.GetLength(0) - 1)

                boundary2 = "-" + boundary1 + "-"

                'handling body

                f = stringsplit(body, boundary2)

                Dim i As Integer

                Dim j As Integer = 0

                For i = 0 To f.GetLength(0) - 1

                    Dim temp() As String

                    temp = stringsplit(f(i), _Split + _Split)

                    If temp.GetLength(0) = 2 Then

                        Dim fs(), fn(), ft(), ftitle(), fdes() As String

                        Dim buf() As Byte

                        fs = stringsplit(temp(0), _Split)

                        fn = stringsplit(fs(0), "filename:")

                        filename = fn(fn.GetLength(0) - 1)

                        ft = stringsplit(fs(1), "filetype:")

                        filetype = ft(ft.GetLength(0) - 1)

                        ftitle = stringsplit(fs(2), "filetitle:")

                        filetitle = ftitle(ftitle.GetLength(0) - 1)

                        fdes = stringsplit(fs(3), "filedescription:")

                        filedescription = fdes(fdes.GetLength(0) - 1)

                        buf = DecodeFile(temp(1))

                        Dim attachfile As New CAttachFile(buf, filename, filetype, filetitle, filedescription)

                        attachfiles.Add(attachfile)

                        j += 1

                    End If

                Next

            Catch ex As Exception

                Return False

            End Try



            Return True

        End Function

        Private Function GetBoundary() As String

            Dim boundary As String = ""

            '  Dim dt As DateTime

            Dim rnd As New System.Random

            boundary += "---=_NextPart_"

            '  boundary += dt.Now().Ticks.ToString.Substring(10, 8)

            boundary += rnd.NextDouble.ToString.Substring(2)

            boundary += "---"

            Return boundary

        End Function

    End Class

    Public Class CAttachFile

        Private _FileName As String

        Private _FileType As String

        Private _FileLength As Long

        Private _FileTitle As String = ""

        Private _FileDescription As String = ""

        Private _Buf() As Byte

        Public ReadOnly Property FileName() As String

            Get

                Return _FileName

            End Get

        End Property

        Public ReadOnly Property FileType() As String

            Get

                Return _FileType

            End Get

        End Property

        Public ReadOnly Property FileLength() As String

            Get

                Return _FileLength

            End Get

        End Property

        Public Property FileTitle() As String

            Get

                Return _FileTitle



            End Get

            Set(ByVal Value As String)

                _FileTitle = Value

            End Set

        End Property

        Public Property FileDescription() As String

            Get

                Return _FileDescription



            End Get

            Set(ByVal Value As String)

                _FileDescription = Value

            End Set

        End Property

        Public ReadOnly Property GetBuf() As Byte()

            Get

                Return _Buf

            End Get

        End Property

        Public Sub New(ByVal Fstream As System.IO.Stream, ByVal Fname As String, Optional ByVal Ftype As String = "", Optional ByVal Ftitle As String = "", Optional ByVal Fdescription As String = "")

            Dim buf(Fstream.Length - 1) As Byte

            Fstream.Read(buf, 0, Fstream.Length)

            _FileName = Fname

            If Ftype = "" Then

                _FileType = "application/octet-stream"

            Else

                _FileType = Ftype

            End If

            _FileTitle = Ftitle

            _FileDescription = Fdescription

            _Buf = buf

            _FileLength = _Buf.GetLength(0)

        End Sub

        Public Sub New(ByVal Fbuf() As Byte, ByVal Fname As String, Optional ByVal Ftype As String = "", Optional ByVal Ftitle As String = "", Optional ByVal Fdescription As String = "")

            Dim buf(Fbuf.GetLength(0) - 1) As Byte

            '   Fbuf.Copy(Fbuf, buf, Fbuf.GetLength(0))

            _FileName = Fname

            If Ftype = "" Then

                _FileType = "application/octet-stream"

            Else

                _FileType = Ftype

            End If

            _FileTitle = Ftitle

            _FileDescription = Fdescription

            _Buf = buf

            _FileLength = _Buf.GetLength(0)

        End Sub

        Public Sub DownloadFile(ByVal apage As System.Web.UI.Page)

            apage.Response.Clear()

            apage.Response.ClearHeaders()

            apage.Response.Buffer = False

            apage.Response.ContentType = _FileType

            apage.Response.AppendHeader("Content-Disposition", "attachment;filename=" + _FileName)

            apage.Response.AppendHeader("Content-Length", _FileLength.ToString)

            apage.Response.BinaryWrite(_Buf)

            apage.Response.Flush()

            apage.Response.End()

        End Sub

    End Class

    Public Class CFileCollection

        Private _FileCollection As Collection

        Public ReadOnly Property GetAttachFiles() As Collection

            Get

                Return _FileCollection

            End Get

        End Property

        Public Sub Add(ByVal attachfile As CAttachFile)

            _FileCollection.Add(attachfile)

        End Sub

        Public ReadOnly Property Count()

            Get

                Return _FileCollection.Count

            End Get

        End Property



        Public Sub Remove(ByVal attachfile As CAttachFile)

            Dim i As Integer

            For i = 1 To _FileCollection.Count

                If _FileCollection(i) Is attachfile Then

                    _FileCollection.Remove(i)

                    Exit For

                End If

            Next

        End Sub

        Public Sub Remove(ByVal index As Integer)

            If index > 0 And index <= _FileCollection.Count Then

                _FileCollection.Remove(index)

            End If

        End Sub

        Public Function Item(ByVal index As Integer) As CAttachFile

            If index > 0 And index <= _FileCollection.Count Then

                Return _FileCollection.Item(index)

            End If

            Return Nothing

        End Function

        Public Sub New()

            _FileCollection = New Collection

        End Sub

    End Class

    Public Class UpLoadFileData
        Public Shared cPage As Object
        Public Shared Function getAttachmentID(ByVal _user As String, ByVal _action As String, ByVal _IDS As String, ByVal _aTitle As String, ByVal _aFileName As String, ByVal _aCatalog As String, ByVal _comments As String, ByVal _fileLocate As String, ByVal _context As String, ByVal _fileType As String) As String
            Dim _SP As String = "tcdsb_TPA_AttachmentFiles"
            Try
                Dim myPara(9) ' ' As tpaWS.MyParameter ' TCDSB.Student.Data.MyParameter   ' MyParameterStructure
                setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _user)
                setParameterArray(myPara, 1, "@Oprate", DbType.String, 20, _action)
                setParameterArray(myPara, 2, "@IDs", DbType.String, 10, _IDS)
                setParameterArray(myPara, 3, "@Title", DbType.String, 100, _aTitle)
                setParameterArray(myPara, 4, "@aFileName", DbType.String, 100, _aFileName)
                setParameterArray(myPara, 5, "@aCatalog", DbType.String, 50, _aCatalog)
                setParameterArray(myPara, 6, "@Comments", DbType.String, 500, _comments)
                setParameterArray(myPara, 7, "@ConText", DbType.String, 0, _context)
                setParameterArray(myPara, 8, "@FileLocate", DbType.String, 50, _fileLocate)
                setParameterArray(myPara, 9, "@FileType", DbType.String, 20, _fileType)
                Return getMyDataValue(_SP, myPara)

            Catch ex As Exception
                CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
                Return ""
            End Try

        End Function
        Public Shared Function getAttachmentText(ByVal _user As String, ByVal _attaID As String) As String
            Dim _SP As String = "tcdsb_TPA_AttachmentID_getConText"
            Try
                Dim myPara(1) ' ' As tpaWS.MyParameter ' TCDSB.Student.Data.MyParameter   ' MyParameterStructure
                setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _user)
                setParameterArray(myPara, 1, "@attaID", DbType.String, 10, _attaID)
                Return getMyDataValue(_SP, myPara)
            Catch ex As Exception
                CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
                Return ""
            End Try

        End Function
        Public Shared Function updateObjectTab(ByVal _user As String, ByVal _IDs As String, ByVal _attaID As String)
            Dim _SP As String = "tcdsb_TPA_AttachmentID_UpdateMessage"
            Try
                Dim myPara(2) ' ' As tpaWS.MyParameter ' TCDSB.Student.Data.MyParameter   ' MyParameterStructure
                setParameterArray(myPara, 0, "@UserID", DbType.String, 30, _user)
                setParameterArray(myPara, 1, "@IDs", DbType.String, 10, _IDs)
                setParameterArray(myPara, 2, "@attaID", DbType.String, 10, _attaID)
                Return getMyDataValue(_SP, myPara)
            Catch ex As Exception
                CommonTCDSB.ShowMsg.Exception(ex, cPage, _SP)
                Return ""
            End Try

        End Function
    End Class


End Namespace
'End Namespace