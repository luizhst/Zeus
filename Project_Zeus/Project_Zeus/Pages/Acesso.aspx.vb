Public Class Acesso
    Inherits System.Web.UI.Page

    Private ReadOnly Log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_logar_Click(sender As Object, e As EventArgs)

        Dim Biz As New Tbl_UsuarioBIZ
        Dim Usuario As New Tbl_Usuario

        Try

            Log.Debug("Tentativa de login. Usuário: " & txt_conta.Value & " - Host: " & Environment.MachineName)
            Usuario = Biz.LogarSistema(txt_conta.Value.ToString.Trim(), txt_senha.Value.ToString.Trim())

            If Not IsNothing(Usuario) Then

                If Usuario.FlgAtivo Then

                    Log.Debug("Login realizado com sucesso.")

                    Session("Usuario") = Usuario
                    Response.Redirect("~/Pages/Default.aspx")

                Else

                    lblMensagem.Text = "Usuário inativo, procure um administrador!"
                    Log.Debug(lblMensagem.Text)

                End If

            Else

                lblMensagem.Text = "Usuário e/ou Senha não encontrados no banco de dados!"
                Log.Debug(lblMensagem.Text)

            End If
        Catch ex As Exception

            lblMensagem.Text = ex.Message.ToString()
            Log.Debug(lblMensagem.Text)

        End Try

    End Sub
End Class