Public Class _Default
    Inherits Page

    Private ReadOnly Log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Private Biz As New Tbl_Hist_CargaBIZ

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load


        If Not IsPostBack Then
            If IsNothing(Session("Usuario")) Then
                Response.Redirect("~/Pages/Sair.aspx")
            Else
                CarregarCarregamentosPendentes()
            End If
        End If

    End Sub

    Private Sub CarregarCarregamentosPendentes()

        Dim Lista As New List(Of Tbl_Hist_Carga)

        Lista = Biz.ListarCarregamentosPendentes().ToList()

        grid_carregamentos.DataSource = Nothing
        grid_carregamentos.DataSource = Lista

        grid_carregamentos.DataBind()

    End Sub

End Class