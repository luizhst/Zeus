Public Class InserirControleUsados
    Inherits System.Web.UI.Page

    Private _Usuario As String
    Private _EditarNota As String
    Private _BizEntradaUsados As New Tbl_Entrada_UsadosBIZ

    Private ReadOnly Log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            _Usuario = Session("Usuario").ToString

            If IsNothing(_Usuario) Then
                Response.Redirect("~/Pages/Sair.aspx")
            End If

            If Not IsPostBack() Then
                If Not IsNothing(Request.QueryString("Cod")) Then
                    _EditarNota = Request.QueryString("Cod")
                    GetNotaEditar(_EditarNota)
                    btn_registrar.Text = "Atualizar"
                End If
            End If

        Catch ex As Exception

            Log.Fatal(ex.Message)

        End Try

    End Sub

    Public Sub GetNotaEditar(ByVal Cod As Integer)

        Try

            Dim Obj As New Tbl_Entrada_Usado
            LimparCampos()

            Obj = _BizEntradaUsados.GetEntradaById(_EditarNota)

            txt_cod.Text = Obj.CodCtrl
            txt_notafiscal.Text = Obj.DesNotaFiscal
            txt_dta_notafiscal.Text = Obj.DtaNotaFiscal
            drp_tipo.SelectedValue = Obj.DesTipoRegistro
            txt_cnpj_nota.Text = Obj.DesCnpj
            txt_origem_destino.Text = Obj.DesOrigemDestino
            drp_produto.SelectedValue = Obj.DesProduto
            txt_qtde_total.Text = Obj.QtdeTotal
            txt_qtde_fpq.Text = Obj.QtdeFpq
            txt_perc_sucata.Text = Obj.DesPercentualSucata
            txt_qtde_sucata.Text = Obj.QtdeSucata
            txt_total_liquido.Text = Obj.QtdeTotalLiquido
            txt_total_disponivel.Text = Obj.QtdeDisponivel
            If Obj.FlgFaturadoFPQ = True Then
                drp_faturado_fpq.SelectedIndex = 1
            Else
                drp_faturado_fpq.SelectedIndex = 0
            End If
            If Obj.FlgFaturadoSucata = True Then
                drp_faturado_sucata.SelectedIndex = 1
            Else
                drp_faturado_sucata.SelectedIndex = 0
            End If

            txt_registro.Text = Obj.DtaRegistro
            txt_usuario.Text = Obj.DesUsuarioRegistro

        Catch ex As Exception

            Log.Fatal(ex.Message)

        End Try


    End Sub

    Private Sub LimparCampos()

        txt_cod.Text = ""
        txt_notafiscal.Text = ""
        txt_dta_notafiscal.Text = ""
        drp_tipo.SelectedIndex = -1
        txt_cnpj_nota.Text = ""
        txt_origem_destino.Text = ""
        drp_produto.SelectedIndex = -1
        txt_qtde_total.Text = 0
        txt_qtde_fpq.Text = 0
        txt_perc_sucata.Text = 0
        txt_qtde_sucata.Text = 0
        txt_total_liquido.Text = 0
        txt_total_disponivel.Text = 0
        drp_faturado_sucata.SelectedIndex = 0
        drp_faturado_fpq.SelectedIndex = 0
        txt_registro.Text = ""
        txt_usuario.Text = ""

    End Sub

    Protected Sub btn_registrar_Click(sender As Object, e As EventArgs)

        Try

            Dim Obj As New Tbl_Entrada_Usado
            Obj = GerarControleUsados()
            _BizEntradaUsados.InsertEntradaUsados(Obj)
            Response.Redirect("~/Pages/Controle/NotasPendentesUsados.aspx")

        Catch ex As Exception

            Log.Fatal(ex.Message)

        End Try

    End Sub

    Public Function GerarControleUsados() As Tbl_Entrada_Usado

        Dim Obj As New Tbl_Entrada_Usado

        Try

            Obj.CodCtrl = CInt(txt_cod.Text.ToString.PadLeft(10, "0"))
            Obj.DesNotaFiscal = txt_notafiscal.Text
            Obj.DtaNotaFiscal = txt_dta_notafiscal.Text
            Obj.DesTipoRegistro = drp_tipo.SelectedValue
            Obj.DesCnpj = txt_cnpj_nota.Text
            Obj.DesOrigemDestino = txt_origem_destino.Text
            Obj.DesProduto = drp_produto.SelectedValue
            Obj.QtdeTotal = txt_qtde_total.Text
            Obj.QtdeFpq = txt_qtde_fpq.Text
            Obj.DesPercentualSucata = txt_perc_sucata.Text
            Obj.QtdeSucata = txt_qtde_sucata.Text
            Obj.QtdeTotalLiquido = txt_total_liquido.Text

            If txt_total_disponivel.Text.Trim.Equals("") Then
                Obj.QtdeDisponivel = txt_total_liquido.Text
            Else
                Obj.QtdeDisponivel = txt_total_disponivel.Text
            End If

            If drp_faturado_fpq.SelectedValue = "Sim" Then
                Obj.FlgFaturadoFPQ = True
            Else
                Obj.FlgFaturadoFPQ = False
            End If

            If drp_faturado_sucata.SelectedValue = "Sim" Then
                Obj.FlgFaturadoSucata = True
            Else
                Obj.FlgFaturadoSucata = False
            End If

            Obj.DtaRegistro = txt_registro.Text
            Obj.DesUsuarioRegistro = txt_usuario.Text

        Catch ex As Exception

            Log.Fatal(ex.Message)

        End Try

        Return Obj

    End Function

    Protected Sub txt_perc_sucata_TextChanged(sender As Object, e As EventArgs)

        txt_qtde_sucata.Text = CalculaSucata()
        txt_total_liquido.Text = CalculaTotalLiquido()

    End Sub

    Private Function CalculaTotalLiquido() As String
        Try

            Return CInt(txt_qtde_total.Text) - CInt(txt_qtde_fpq.Text) - CInt(txt_qtde_sucata.Text)

        Catch ex As Exception

            Return 0

        End Try
    End Function

    Public Function CalculaSucata()
        Try

            Return CInt(CDbl(txt_qtde_total.Text) * CDbl(txt_perc_sucata.Text) / 100)

        Catch ex As Exception

            Return 0

        End Try


    End Function


End Class