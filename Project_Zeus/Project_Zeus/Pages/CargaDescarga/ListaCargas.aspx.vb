Public Class ListaCargas
    Inherits System.Web.UI.Page

    Private ReadOnly Log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Private Biz As New Tbl_Hist_CargaBIZ


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            If IsNothing(Session("Usuario")) Then
                Response.Redirect("~/Pages/Sair.aspx")
            Else
                AtualizaIndicadores()
                CarregarCarregamentosPendentes()
            End If
        End If

    End Sub

    Private Sub CarregarCarregamentosPendentes()

        Dim Lista As New List(Of Tbl_Hist_Carga)
        Lista = Biz.ListarCarregamentosPendentes().ToList()

        If Lista.Count > 0 Then

            lbl_Mensagem_Grid.Visible = False
            grid_carregamentos.DataSource = Nothing
            grid_carregamentos.DataSource = Lista

            grid_carregamentos.DataBind()

        Else

            lbl_Mensagem_Grid.Visible = True
            lbl_Mensagem_Grid.Text = "Não existem carregamentos pendentes no momento!"

        End If



    End Sub

    Protected Sub grid_carregamentos_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)

        Dim Lista As New List(Of Tbl_Hist_Carga)
        Lista = Biz.ListarCarregamentosPendentes().ToList()

        grid_carregamentos.DataSource = Lista
        grid_carregamentos.PageIndex = e.NewPageIndex
        grid_carregamentos.DataBind()

    End Sub

    Private Sub AtualizaIndicadores()

        Dim Lista As New List(Of Tbl_Hist_Carga)
        Lista = Biz.ListarCarregamentos()

        Dim PrimeiroDia As String = "01/" & DateTime.Now.Month & "/" & DateTime.Now.Year & " 00:00:00"


        lbl_cargahoje.Text = Lista.Where(Function(x) Format(x.DtaRegistro, "dd/MM/yyyy") = Format(Now, "dd/MM/yyyy") And x.DesTipo = "CARREGAR").Count
        lbl_descargahoje.Text = Lista.Where(Function(x) Format(x.DtaRegistro, "dd/MM/yyyy") = Format(Now, "dd/MM/yyyy") And x.DesTipo = "DESCARREGAR").Count

        lbl_cargames.Text = Lista.Where(Function(x) Format(x.DtaRegistro, "dd/MM/yyyy") >= Format(Now, "01/MM/yyyy") And Format(x.DtaRegistro, "dd/MM/yyyy") <= Format(Now, "dd/MM/yyyy") And x.DesTipo = "CARREGAR").Count
        lbl_descargames.Text = Lista.Where(Function(x) Format(x.DtaRegistro, "dd/MM/yyyy") >= Format(Now, "01/MM/yyyy") And Format(x.DtaRegistro, "dd/MM/yyyy") <= Format(Now, "dd/MM/yyyy") And x.DesTipo = "DESCARREGAR").Count

    End Sub

End Class