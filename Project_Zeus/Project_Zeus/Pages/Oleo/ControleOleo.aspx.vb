Public Class ControleOleo
    Inherits System.Web.UI.Page

    Private _User As New Tbl_Usuario
    Private Biz As New Tbl_Oleo_Diesel_BIZ

    Private ReadOnly Log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
    Private Util As New Util

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not IsPostBack Then

            If IsNothing(Session("Usuario")) Then
                Response.Redirect("~/Pages/Sair.aspx")

            Else
                _User = Session("Usuario")
                If Util.VerificaAcesso(_User, Me.Title) = False Then Response.Redirect("~/Pages/AcessoNegado.aspx")

                lbl_estoque_oleo.Text = Biz.GetEstoqueAtual.ToString("#,###")
                CarregarUltimosAbastecimentos()
                CarregaVeiculosCadastrados()

            End If

        End If

    End Sub

    Private Sub CarregaVeiculosCadastrados()

        Dim Veiculos As New List(Of Tbl_Veiculo)
        Dim BizVeiculos As New Tbl_Veiculo_BIZ

        Veiculos = BizVeiculos.GetVeiculos()

        ddl_veiculos.DataSource = Veiculos
        ddl_veiculos.DataTextField = "Placa1"
        ddl_veiculos.DataValueField = "CodVeiculo"
        ddl_veiculos.DataBind()


    End Sub

    Protected Sub btn_registrar_Click(sender As Object, e As EventArgs)

        RegistraSaldo()

    End Sub

    Private Sub RegistraSaldo()

        Dim Item As New Tbl_Oleo_Diesel

        Try

            _User = Session("Usuario")
            Item.DesUser = _User.Nome.ToUpper
            Item.DesPlaca_Veiculo = ddl_veiculos.SelectedItem.Text.ToUpper
            Item.DesNomeVeiculo = txt_des_veiculo.Text.ToUpper
            Item.NumQtdeOleo = CInt(txt_qtde.Text)
            Item.DtaRegistro = DateTime.Now
            Item.DesKm = txt_km.Text.ToUpper
            Item.DesEstoque = drp_estoque.Text

            If drp_tipo.Text.Equals("Saída") Then
                Item.FlgEntrada = False
            Else
                Item.FlgEntrada = True
            End If

            Biz.InsertRegistro(Item)
            RegistraMovimentoCarteira()


            CarregarUltimosAbastecimentos()
            lbl_estoque_oleo.Text = Biz.GetEstoqueAtual.ToString("#,###")

            Limpar()

        Catch ex As Exception

            Log.Fatal(ex)

        End Try


    End Sub

    Private Sub RegistraMovimentoCarteira()

        Dim Obj As New Tbl_Movimento_Carteira_Veiculo
        Obj.Veiculo = New Tbl_Veiculo
        Obj.TipoMovimento = New Tbl_Tipo_Movimento_Carteira
        Dim Util As New Util

        Try

            Obj.Veiculo.CodVeiculo = Convert.ToInt32(ddl_veiculos.SelectedItem.Value.ToString.PadLeft(10, "0"))
            Obj.TipoMovimento.CodTipoMovimentoCarteira = 1
            Obj.Descricao = "Lançamento automático sobre abastecimento"
            Obj.Valor = (txt_qtde.Text * Util.GetValorOleo()).ToString
            Obj.DesTipoRegistro = "D"

            Dim mcBIZ As New Tbl_Movimento_Carteira_Veiculo_BIZ
            mcBIZ.InsertMovimento(Obj)

        Catch ex As Exception

            Log.Fatal(ex.Message)

        End Try

    End Sub

    Private Sub Limpar()

        ddl_veiculos.SelectedIndex = 0
        txt_des_veiculo.Text = ""
        txt_qtde.Text = ""
        drp_tipo.SelectedIndex = -1
        txt_km.Text = ""
        lbl_Mensagem_Grid.Visible = False
        drp_estoque.SelectedIndex = 0

    End Sub


    Private Sub CarregarUltimosAbastecimentos()

        Dim Lista As New List(Of Tbl_Oleo_Diesel)
        Lista = Biz.GetLast5Lancamentos.ToList()

        If Lista.Count > 0 Then

            grid_abastecimentos.DataSource = Nothing
            grid_abastecimentos.DataSource = Lista

            grid_abastecimentos.DataBind()

        Else

            lbl_Mensagem_Grid.Visible = True
            lbl_Mensagem_Grid.Text = "Não existem abastecimentos ainda."

        End If



    End Sub


End Class