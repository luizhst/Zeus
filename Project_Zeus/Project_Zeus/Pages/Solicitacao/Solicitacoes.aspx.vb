Public Class Solicitacoes
    Inherits System.Web.UI.Page

    Private ReadOnly Log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Private Biz As New Tbl_SolicitacaoBIZ

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            If IsNothing(Session("Usuario")) Then
                Response.Redirect("~/Pages/Sair.aspx")
            Else
                CarregarSolicitacoesAbertas()
            End If
        End If

    End Sub

    Private Sub CarregarSolicitacoesAbertas()

        Dim Lista As New List(Of Tbl_Solicitacao)
        Lista = Biz.ListarTodasSolicitacoesAbertas()

        If Lista.Count > 0 Then

            lbl_Mensagem_Grid.Visible = False

            grid_solicitacoes.DataSource = Nothing
            grid_solicitacoes.DataSource = Lista

            grid_solicitacoes.DataBind()

        Else

            grid_solicitacoes.DataSource = Nothing
            grid_solicitacoes.DataBind()

            lbl_Mensagem_Grid.Visible = True
            lbl_Mensagem_Grid.Text = "Não existem solicitações no momento!"

        End If

    End Sub

    Protected Sub btn_filtro_abertos_Click(sender As Object, e As EventArgs)

        Dim Lista As New List(Of Tbl_Solicitacao)
        Lista = Biz.ListarTodasSolicitacoesAbertas()

        If Lista.Count > 0 Then

            lbl_Mensagem_Grid.Visible = False

            grid_solicitacoes.DataSource = Nothing
            grid_solicitacoes.DataSource = Lista

            grid_solicitacoes.DataBind()

        Else

            grid_solicitacoes.DataSource = Nothing
            grid_solicitacoes.DataBind()

            lbl_Mensagem_Grid.Visible = True
            lbl_Mensagem_Grid.Text = "Não existem solicitações no momento!"

        End If

    End Sub

    Protected Sub btn_filtro_finalizadas_Click(sender As Object, e As EventArgs)

        Dim Lista As New List(Of Tbl_Solicitacao)
        Lista = Biz.ListarTodasSolicitacoesFinalizadas()

        If Lista.Count > 0 Then

            lbl_Mensagem_Grid.Visible = False

            grid_solicitacoes.DataSource = Nothing
            grid_solicitacoes.DataSource = Lista

            grid_solicitacoes.DataBind()

        Else

            grid_solicitacoes.DataSource = Nothing
            grid_solicitacoes.DataBind()

            lbl_Mensagem_Grid.Visible = True
            lbl_Mensagem_Grid.Text = "Não existem solicitações no momento!"

        End If

    End Sub

    Protected Sub btn_filtro_todos_Click(sender As Object, e As EventArgs)

        Dim Lista As New List(Of Tbl_Solicitacao)
        Lista = Biz.ListarTodasSolicitacoes()

        If Lista.Count > 0 Then

            lbl_Mensagem_Grid.Visible = False

            grid_solicitacoes.DataSource = Nothing
            grid_solicitacoes.DataSource = Lista

            grid_solicitacoes.DataBind()

        Else

            lbl_Mensagem_Grid.Visible = True
            lbl_Mensagem_Grid.Text = "Não existem solicitações no momento!"

        End If

    End Sub
End Class