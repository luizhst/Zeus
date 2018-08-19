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
    Private ReadOnly Log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

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

            Log.Fatal(ex.Message)

        End Try

    End Function

    Friend Function ListarUsuarios() As List(Of Tbl_Usuario)

        Return DAO.List("SELECT * FROM dbo.TBL_USUARIO ORDER BY Nome").ToList()

    End Function

    Friend Function GetUsuarioById(ByVal Cod As Integer) As Tbl_Usuario

        Return DAO.List("SELECT * FROM dbo.TBL_USUARIO WHERE CodUsuario = " & Cod).FirstOrDefault()

    End Function

    Friend Function GetPerfis() As List(Of Tbl_Perfil)

        Dim DAO As New Tbl_Perfil_DAO
        Return DAO.List("SELECT * FROM dbo.TBL_PERFIL ORDER BY DesPerfil").ToList()

    End Function


    Friend Sub InsertUsuario(ByVal Obj As Tbl_Usuario)

        Try

            If Obj.CodUsuario <> 0 Then
                DAO.Update(Obj)
            Else
                DAO.Insert(Obj)
            End If

        Catch ex As Exception

            Log.Fatal(ex.Message)

        End Try

    End Sub


End Class
