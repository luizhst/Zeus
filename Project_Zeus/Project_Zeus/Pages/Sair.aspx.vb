Public Class Sair
    Inherits System.Web.UI.Page

    Private ReadOnly Log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Log.Debug("Sessão do usuário expirada.")

        Session("Usuario") = Nothing
        Session("CodUsuario") = Nothing
        Response.Redirect("~/Pages/Acesso.aspx")

    End Sub

End Class