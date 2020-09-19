Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Security.Cryptography
Imports System.IO
Imports System.Configuration
Imports System.Web

''' <summary>
''' Symetric encryption routines to encrypt and decrypt strings for URLs
''' Primarily used for TCDSB Single Sign On (SSO)
''' Usage:
'''   GetSsoQueryString("bob") 
'''     returns full Query string for SSO valid for limited time. Simple append to existing url using  question or ampersand connector
'''   
'''   ValidateKeyFromQueryString(key,[minutes])  
'''     returns true if key is valid and within time limit -30 minute default, but optionally may specify longer
'''   DecryptValueFromQueryString("encrypted value in query string")
'''     returns the string as originally entered as emaple above  "bob"
''' 
''' Other optional methods
'''   EncryptValueForQueryString("mystring") - encyrpts any string to a URL acceptable format
'''   DecryptValueFromQueryString("encrypted string") - decrypts any string encrypted by methood EncryptValueForQueryString
''' </summary>
''' <remarks></remarks>
Public Class TcdsbSymetricEncryption
    Private Shared ReadOnly IV As String = "SuFjcEmp/TE="
    Private Shared ReadOnly Key As String = "KIPSToILGp6fl+3gXJvMsN4IajizYBBT"
    Private Shared ReadOnly DateTimeFormatString As String = "yyyy/MM/dd HH:mm:ss"
    Private Shared ReadOnly SsoFormatString As String = "userid={0}"
    Private Shared ReadOnly DefaultMaxMinutes As Integer = 30
    Private Shared ReadOnly ValidationKeySeparator As String = "***"
    Private Shared ReadOnly CombinedUidValidationKeyFormatString As String = "{0}{1}{2}"

    Public Shared Function GetSsoQueryString(ByVal userid As String) As String
        Try
            Dim currentDateTimeString As String = DateTime.Now.ToString(DateTimeFormatString)
            Dim sso As String = String.Format(CombinedUidValidationKeyFormatString, userid, ValidationKeySeparator, currentDateTimeString)
            Dim encryptedSso As String = EncryptValueForQueryString(sso)
            Dim encryptedSsoQuerystring As String = String.Format(SsoFormatString, encryptedSso)
            Return encryptedSsoQuerystring
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Public Shared Function GetValidatedSsoFromQueryString(ByVal queryStringKeyValue As String, ByVal signal As String) As String

        Return GetValidatedSsoFromQueryString(queryStringKeyValue, signal, DefaultMaxMinutes)
    End Function
    Public Shared Function GetValidatedSsoFromQueryString(ByVal queryStringKeyValue As String, ByVal signal As String, ByVal maxMinutes As Integer) As String
        Try
            If signal = "NameOnly" Then
                Return queryStringKeyValue
            End If
            'Dim urlUnEncodedValue As String = HttpUtility.UrlDecode(queryStringKeyValue)
            'Dim decryptedValue = GetDecryptedValue(urlUnEncodedValue)
            Dim decryptedValue = GetDecryptedValue(queryStringKeyValue)
            Dim startValidationKeySeparator = decryptedValue.IndexOf(ValidationKeySeparator)
            If startValidationKeySeparator < 0 Then
                Return String.Empty
            End If
            Dim queryStringDateTimePortion = decryptedValue.Substring(startValidationKeySeparator + ValidationKeySeparator.Length)
            Dim queryStringUidPortion As String = decryptedValue.Substring(0, startValidationKeySeparator)

            Dim queryStringDateTimeParsed As DateTime = DateTime.ParseExact(queryStringDateTimePortion, DateTimeFormatString, System.Globalization.CultureInfo.InvariantCulture)

            Dim currentDateTime As DateTime = DateTime.Now
            Dim timeDiff As TimeSpan = currentDateTime - queryStringDateTimeParsed
            If (timeDiff.TotalMinutes > maxMinutes) Then
                Return String.Empty
            Else
                Return queryStringUidPortion
            End If
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Public Shared Function EncryptValueForQueryString(ByVal inputValue As String) As String
        Try
            Dim encryptedValue = GetEncryptedValue(inputValue)
            Dim urlEncodedValue As String = HttpUtility.UrlEncode(encryptedValue)
            Return urlEncodedValue

        Catch ex As Exception
            Return String.Empty
        End Try
    End Function
    Public Shared Function DecryptValueFromQueryString(ByVal inputValue As String) As String
        Dim urlUnEncodedValue As String = HttpUtility.UrlDecode(inputValue)
        Dim decryptedValue = GetDecryptedValue(urlUnEncodedValue)
        Return decryptedValue
    End Function
    Private Shared Function GetEncryptedValue(ByVal inputValue As String) As String
        Dim mStream As MemoryStream = Nothing
        Dim cStream As CryptoStream = Nothing
        Try
            Dim provider As TripleDESCryptoServiceProvider = GetCryptoProvider()
            mStream = New MemoryStream()

            cStream = New CryptoStream(mStream, provider.CreateEncryptor(), CryptoStreamMode.Write)

            Dim toEncrypt As Byte() = New UTF8Encoding().GetBytes(inputValue)

            cStream.Write(toEncrypt, 0, toEncrypt.Length)
            cStream.FlushFinalBlock()

            Dim ret As Byte() = mStream.ToArray()
            Return Convert.ToBase64String(ret)

        Catch ex As Exception
            Return String.Empty
        Finally
            If (cStream IsNot Nothing) Then
                cStream.Close()
            End If
            If (mStream IsNot Nothing) Then
                mStream.Close()
            End If
        End Try

    End Function

    Private Shared Function GetCryptoProvider() As TripleDESCryptoServiceProvider

        Dim provider As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider()
        provider.IV = Convert.FromBase64String(IV)
        provider.Key = Convert.FromBase64String(Key)
        Return provider
    End Function

    Private Shared Function GetDecryptedValue(ByVal inputValue As String) As String

        Dim csDecrypt As CryptoStream = Nothing
        Try
            Dim provider As TripleDESCryptoServiceProvider = GetCryptoProvider()
            Dim inputEquivalent As Byte() = Convert.FromBase64String(inputValue)
            Dim msDecrypt As MemoryStream = New MemoryStream()

            csDecrypt = New CryptoStream(msDecrypt, provider.CreateDecryptor(), CryptoStreamMode.Write)
            csDecrypt.Write(inputEquivalent, 0, inputEquivalent.Length)
            csDecrypt.FlushFinalBlock()
            Return New UTF8Encoding().GetString(msDecrypt.ToArray())

        Catch ex As Exception
            Return String.Empty
        Finally
            If (csDecrypt IsNot Nothing) Then
                csDecrypt.Close()
            End If

        End Try

    End Function

End Class

