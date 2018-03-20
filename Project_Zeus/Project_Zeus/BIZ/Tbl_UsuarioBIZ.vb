Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Configuration
Imports System.Web.SessionState


Public Class Tbl_UsuarioBIZ

    Private DAO As New Tbl_UsuarioDAO


    ''' <summary>
    ''' Valida Conta do Usuario no Sistema
    ''' </summary>
    ''' <param name="Usuario"></param>
    ''' <param name="Senha"></param>
    ''' <returns></returns>
    Public Function LogarSistema(ByVal Usuario As String, ByVal Senha As String) As Tbl_Usuario

        Dim ContaUsuario As New Tbl_Usuario

        Try

            ContaUsuario = DAO.List("SELECT * FROM dbo.TBL_USUARIO WHERE ContaLogin = '" & Usuario & "' AND SenhaLogin = '" & Senha & "'").FirstOrDefault()

            If (IsNothing(ContaUsuario) = False) Then
                Return ContaUsuario
            Else
                Return Nothing
            End If


        Catch ex As Exception

            Throw ex

        End Try


    End Function

    Friend Function ListarUsuarios() As List(Of Tbl_Usuario)

        Return DAO.List("SELECT * FROM dbo.TBL_USUARIO ORDER BY Nome").ToList()

    End Function
End Class
