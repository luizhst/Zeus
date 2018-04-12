Imports Project_Zeus

Public Class IncluirHistCarga
    Inherits System.Web.UI.Page

    Private _EditarCarga As String

    Private ReadOnly Log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
    Private BizCarga As New Tbl_Hist_CargaBIZ
    Private BizEntradaUsados As New Tbl_Entrada_UsadosBIZ

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        txt_data_nota.Text = Format(Now, "yyyy-MM-dd")

        If Not IsPostBack Then

            If IsNothing(Session("Usuario")) Then
                Response.Redirect("~/Pages/Sair.aspx")
            End If

            If Not IsNothing(Request.QueryString("Cod")) Then
                _EditarCarga = Request.QueryString("Cod")
                GetCarregamento(_EditarCarga)
                btn_registrar.Text = "Atualizar"
            End If

        End If

    End Sub


    Protected Sub btn_registrar_Click(sender As Object, e As EventArgs)

        Dim ObjHstCarga As New Tbl_Hist_Carga
        
        Try

            'Gera a parte de controle de entrada e saída de veículos (Fila de espera)
            ObjHstCarga = GeraObjHistCarga()
            BizCarga.InsertCarregamento(ObjHstCarga)

            Response.Redirect("~/Pages/CargaDescarga/ListaCargas.aspx")

        Catch ex As Exception

            Log.Fatal(ex.Message)

        End Try

    End Sub

    Private Function GerarEntradaUsados() As Tbl_Entrada_Usado

        Dim Obj As New Tbl_Entrada_Usado

        Try

            Obj.CodCtrl = "0"
            Obj.DtaRegistro = Format(Now, "dd/MM/yyyy HH:mm:ss")
            Obj.DtaNotaFiscal = CDate(txt_data_nota.Text)
            Obj.DesNotaFiscal = txt_notafiscal.Text
            Obj.DesOrigemDestino = txt_origem_destino.Text
            Obj.DesTipoRegistro = "E"
            Obj.DesUsuarioRegistro = Session("Usuario").ToString
            Obj.DesCnpj = ""
            Obj.DesPercentualSucata = ""
            Obj.DesProduto = ""
            Obj.FlgFaturadoFPQ = False
            Obj.FlgFaturadoSucata = False
            Obj.QtdeDisponivel = 0
            Obj.QtdeFpq = 0
            Obj.QtdeSucata = 0
            Obj.QtdeTotal = 0
            Obj.QtdeTotalLiquido = 0

        Catch ex As Exception

            Log.Fatal(ex.Message)

        End Try

        Return Obj

    End Function

    Public Function GeraObjHistCarga() As Tbl_Hist_Carga

        Dim Obj As New Tbl_Hist_Carga

        Try

            Obj.CodHist = Convert.ToInt32(txt_cod_hist.Text.ToString.PadLeft(10, "0"))
            If txt_registro.Text.Equals("") Then
                Obj.DtaRegistro = Format(Now, "dd/MM/yyyy HH:mm:ss")
            Else
                Obj.DtaRegistro = txt_registro.Text
            End If
            Obj.DtaAtualizacao = Format(Now, "dd/MM/yyyy HH:mm:ss")
            Obj.DesOrigemDestino = txt_origem_destino.Text
            Obj.DesMotorista = txt_motorista.Text
            Obj.DesTransportadora = txt_transportadora.Text
            Obj.DesPlaca1 = txt_placa1.Text
            Obj.DesPlaca2 = txt_placa2.Text
            Obj.DesPlaca3 = txt_placa3.Text
            Obj.DesNotaFiscal = txt_notafiscal.Text
            Obj.DesPedidoCompra = txt_pedidocompra.Text
            Obj.DesTipo = Convert.ToString(drp_tipo.SelectedValue)

            If drp_status.SelectedIndex = 0 Then
                Obj.FlgLiberado = False
            Else
                Obj.FlgLiberado = True
            End If

        Catch ex As Exception

            Log.Fatal(ex.Message)

        End Try

        Return Obj

    End Function

    Public Sub GetCarregamento(ByVal Cod As Integer)

        Dim Obj As New Tbl_Hist_Carga
        LimparCampos()

        Try

            Obj = BizCarga.GetCarregamentoById(Cod)

            txt_cod_hist.Text = Obj.CodHist
            txt_registro.Text = Obj.DtaRegistro
            txt_update.Text = Obj.DtaAtualizacao
            txt_origem_destino.Text = Obj.DesOrigemDestino
            txt_motorista.Text = Obj.DesMotorista
            txt_transportadora.Text = Obj.DesTransportadora
            txt_placa1.Text = Obj.DesPlaca1
            txt_placa2.Text = Obj.DesPlaca2
            txt_placa3.Text = Obj.DesPlaca3
            txt_pedidocompra.Text = Obj.DesPedidoCompra
            txt_notafiscal.Text = Obj.DesNotaFiscal

            If Obj.DesTipo = "Carregar" Then
                drp_tipo.SelectedValue = "Carregar"
            Else
                drp_tipo.SelectedValue = "Descarregar"
            End If

            If Obj.FlgLiberado = True Then
                drp_status.SelectedIndex = 1
            Else
                drp_status.SelectedIndex = 0
            End If

        Catch ex As Exception

            'Erro
            Throw ex

        End Try

    End Sub

    Private Sub LimparCampos()

        txt_cod_hist.Text = ""
        txt_motorista.Text = ""
        txt_origem_destino.Text = ""
        txt_placa1.Text = ""
        txt_placa2.Text = ""
        txt_placa3.Text = ""
        txt_registro.Text = ""
        txt_transportadora.Text = ""
        txt_update.Text = ""
        txt_notafiscal.Text = ""
        txt_pedidocompra.Text = ""
        drp_status.SelectedIndex = -1
        drp_tipo.SelectedIndex = -1

    End Sub
End Class