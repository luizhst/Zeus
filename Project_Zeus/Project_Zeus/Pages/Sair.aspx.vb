Public Class Sair
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session("Usuario") = Nothing
        Session("CodUsuario") = Nothing
        Response.Redirect("~/Pages/Acesso.aspx")

    End Sub

End Class