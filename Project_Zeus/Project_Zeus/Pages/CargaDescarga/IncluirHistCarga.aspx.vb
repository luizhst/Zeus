Public Class IncluirHistCarga
    Inherits System.Web.UI.Page

    Private _EditarCarga As String

    Private Biz As New Tbl_Hist_CargaBIZ

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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

            Biz.InsertCarregamento(Obj)

            Response.Redirect("../Default.aspx")

        Catch ex As Exception

            Throw ex

        End Try

    End Sub

    Public Sub GetCarregamento(ByVal Cod As Integer)

        Dim Obj As New Tbl_Hist_Carga
        LimparCampos()

        Try

            Obj = Biz.GetCarregamentoById(Cod)

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