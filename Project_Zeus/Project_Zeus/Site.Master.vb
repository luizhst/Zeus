Public Class SiteMaster
    Inherits MasterPage

    Private Usuario As String
    Private CodUsuario As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If Not IsPostBack Then


            If Not IsNothing(Session("Usuario")) Then

                Usuario = Session("Usuario").ToString
                CodUsuario = Session("CodUsuario").ToString

                lblBemVindo.InnerText = "Bem vindo(a), " & Usuario

            Else

                Response.Redirect("~/Pages/Sair.aspx")

            End If

        End If

    End Sub
End Class