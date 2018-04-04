Public Class NotasPendentesUsados
    Inherits System.Web.UI.Page

    Private _Usuario As String
    Private _BizEntradaUsados As New Tbl_Entrada_UsadosBIZ

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'grid_notas_usadas
        If Not IsPostBack Then

            If IsNothing(Session("Usuario")) Then
                Response.Redirect("~/Pages/Sair.aspx")
            End If

            CarregarNotasPendentes()

        End If

    End Sub

    Private Sub CarregarNotasPendentes()

        Dim Lista As New List(Of Tbl_Entrada_Usado)

        Lista = _BizEntradaUsados.ListarPendentesLancamento()

        If Lista.Count > 0 Then
            grid_notas_usadas.DataSource = Nothing
            grid_notas_usadas.DataSource = Lista

            grid_notas_usadas.DataBind()

            lb_mensagem.Text = "Total de notas pendentes: " & Lista.Count() & "."
        Else
            lb_mensagem.Text = "Nenhuma nota pendente de lançamento."
        End If



    End Sub
End Class