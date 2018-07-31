Public Class IncluiVeiculo
    Inherits System.Web.UI.Page

    Private _Usuario As New Tbl_Usuario
    Private Util As New Util
    Private BIZ As New Tbl_Veiculo_BIZ

    Private ReadOnly Log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            If IsNothing(Session("Usuario")) Then
                Response.Redirect("~/Pages/Sair.aspx")
            Else
                _Usuario = Session("Usuario")
                If Util.VerificaAcesso(_Usuario, Me.Title) = False Then Response.Redirect("~/Pages/AcessoNegado.aspx")
            End If

            CarregarVeiculos()

        End If

    End Sub

    Private Sub CarregarVeiculos()

        Dim Lista As New List(Of Tbl_Veiculo)
        Lista = BIZ.GetVeiculos().ToList()

        If Lista.Count > 0 Then

            lbl_Mensagem_Grid.Visible = False
            grid_veiculos.DataSource = Nothing
            grid_veiculos.DataSource = Lista

            grid_veiculos.DataBind()

        Else

            lbl_Mensagem_Grid.Visible = True
            lbl_Mensagem_Grid.Text = "Não existem veículos cadastrados no sistema!"

        End If



    End Sub

End Class