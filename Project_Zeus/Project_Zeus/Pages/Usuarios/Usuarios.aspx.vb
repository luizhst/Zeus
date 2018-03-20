Public Class Usuarios
    Inherits System.Web.UI.Page

    Private _Usuario As String
    Private Biz As New Tbl_UsuarioBIZ

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            _Usuario = Session("Usuario").ToString
            CarregarUsuarios()

        Catch ex As Exception

            Response.Redirect("~/Pages/Sair.aspx")

        End Try


    End Sub

    Private Sub CarregarUsuarios()

        Dim Lista As New List(Of Tbl_Usuario)

        Lista = Biz.ListarUsuarios().toList()

        grid_usuarios.DataSource = Nothing
        grid_usuarios.DataSource = Lista

        grid_usuarios.DataBind()

    End Sub
End Class