Public Class Acesso
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_logar_Click(sender As Object, e As EventArgs)

        Dim Biz As New Tbl_UsuarioBIZ
        Dim Usuario As New Tbl_Usuario

        Try

            Usuario = Biz.LogarSistema(txt_conta.Value.ToString.Trim(), txt_senha.Value.ToString.Trim())

            If Not IsNothing(Usuario) Then

                If Usuario.FlgAtivo Then

                    Session("Usuario") = Usuario.Nome
                    Session("CodUsuario") = Usuario.CodUsuario
                    Response.Redirect("~/Pages/Default.aspx")

                Else

                    lblMensagem.Text = "Usuário inativo, procure um administrador!"

                End If

            Else

                lblMensagem.Text = "Usuário e/ou Senha não encontrados no banco de dados!"

            End If
        Catch ex As Exception

            lblMensagem.Text = ex.Message.ToString()

        End Try





    End Sub
End Class