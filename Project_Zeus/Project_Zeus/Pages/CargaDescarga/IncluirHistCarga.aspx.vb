Imports Project_Zeus

Public Class IncluirHistCarga
    Inherits System.Web.UI.Page

    Private _EditarCarga As String
    Private _Usuario As New Tbl_Usuario

    Private ReadOnly Log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
    Private BizCarga As New Tbl_Hist_CargaBIZ
    Private Util As New Util

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        If Not IsPostBack Then


            If IsNothing(Session("Usuario")) Then
                Response.Redirect("~/Pages/Sair.aspx")
            Else
                _Usuario = Session("Usuario")
                If Util.VerificaAcesso(_Usuario, Me.Title) = False Then Response.Redirect("~/Pages/AcessoNegado.aspx")

            End If

            If Not IsNothing(Request.QueryString("Cod")) Then
                _EditarCarga = Request.QueryString("Cod")
                GetCarregamento(_EditarCarga)
                btn_registrar.Text = "Atualizar"
                btn_link_pesquisa.Visible = False

            Else

                txt_data_nota.Text = Format(Now, "yyyy-MM-dd")

            End If

        Else

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
            Obj.DesOrigemDestino = txt_origem_destino.Text.ToUpper
            Obj.DesMotorista = txt_motorista.Text.ToUpper
            Obj.DesTransportadora = txt_transportadora.Text.ToUpper
            Obj.DesPlaca1 = txt_placa1.Text.ToUpper
            Obj.DesPlaca2 = txt_placa2.Text.ToUpper
            Obj.DesPlaca3 = txt_placa3.Text.ToUpper 'Mudou para descrição do veículo
            Obj.DesNotaFiscal = txt_notafiscal.Text.ToUpper
            Obj.DesPedidoCompra = txt_pedidocompra.Text.ToUpper 'Mudou para Tipo do Pallet
            Obj.DesTipo = Convert.ToString(drp_tipo.SelectedValue.ToUpper)
            Obj.NumCpfMotorista = txt_cpf.Text.ToUpper
            Obj.DtaNotaFiscal = Convert.ToDateTime(txt_data_nota.Text)
            Obj.DesTelefone = txt_telefone.Text.ToUpper
            Obj.NumQtdePallet = txt_qtdepallet.Text

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
            txt_placa3.Text = Obj.DesPlaca3 'Mudou para descrição do veículo
            txt_pedidocompra.Text = Obj.DesPedidoCompra ''Mudou para Tipo do Pallet
            txt_notafiscal.Text = Obj.DesNotaFiscal
            txt_cpf.Text = Obj.NumCpfMotorista
            txt_data_nota.Text = Format(CDate(Obj.DtaNotaFiscal), "yyyy-MM-dd")
            txt_telefone.Text = Obj.DesTelefone
            txt_qtdepallet.Text = Obj.NumQtdePallet

            If Obj.DesTipo = "CARREGAR" Then
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
            Log.Fatal(ex.Message)

        End Try

    End Sub

    Private Sub LimparCampos()

        txt_cod_hist.Text = ""
        txt_motorista.Text = ""
        txt_origem_destino.Text = ""
        txt_placa1.Text = ""
        txt_placa2.Text = ""
        txt_placa3.Text = "" 'Mudou para descrição do veículo
        txt_registro.Text = ""
        txt_transportadora.Text = ""
        txt_update.Text = ""
        txt_notafiscal.Text = ""
        txt_pedidocompra.Text = "" ''Mudou para Tipo do Pallet
        drp_status.SelectedIndex = -1
        drp_tipo.SelectedIndex = -1
        txt_cpf.Text = ""
        txt_telefone.Text = ""
        txt_qtdepallet.Text = ""



    End Sub

    Protected Sub btn_pesquisa_Click(sender As Object, e As EventArgs)

        If Not txt_cpf.Text.Equals("") Then
            GetCarregamentoByCpf(txt_cpf.Text)
        End If

    End Sub

    Public Sub GetCarregamentoByCpf(ByVal CPF As String)

        Dim Obj As New Tbl_Hist_Carga

        Try

            Obj = BizCarga.GetUltCarregamentoByCpf(CPF)

            If Not IsNothing(Obj) Then

                txt_origem_destino.Text = Obj.DesOrigemDestino
                txt_motorista.Text = Obj.DesMotorista
                txt_transportadora.Text = Obj.DesTransportadora
                txt_placa1.Text = Obj.DesPlaca1
                txt_placa2.Text = Obj.DesPlaca2
                txt_placa3.Text = Obj.DesPlaca3 'Mudou para descrição do veículo
                txt_cpf.Text = Obj.NumCpfMotorista
                txt_pedidocompra.Text = Obj.DesPedidoCompra ''Mudou para Tipo do Pallet
                txt_telefone.Text = Obj.DesTelefone
                txt_qtdepallet.Text = Obj.NumQtdePallet

                If Obj.DesTipo = "Carregar" Then
                    drp_tipo.SelectedValue = "Carregar"
                Else
                    drp_tipo.SelectedValue = "Descarregar"
                End If

                drp_status.SelectedIndex = 0

                btn_link_pesquisa.Enabled = False

            Else

                btn_link_pesquisa.Visible = False
                lbl_resultado_pesquisa.Text = "A pesquisa não retornou resultados!"
                lbl_resultado_pesquisa.Visible = True
                LimparCampos()
                txt_cpf.Text = CPF

            End If


        Catch ex As Exception

            'Erro
            Throw ex

        End Try

    End Sub

End Class