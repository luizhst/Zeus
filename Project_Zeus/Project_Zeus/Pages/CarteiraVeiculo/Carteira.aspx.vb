Public Class Carteira
    Inherits System.Web.UI.Page

    Private _Usuario As New Tbl_Usuario
    Private Util As New Util
    Private vBIZ As New Tbl_Veiculo_BIZ
    Private mcBIZ As New Tbl_Movimento_Carteira_Veiculo_BIZ
    Private _VeiculoCarteira As String
    Private _ListaTipos As New List(Of Tbl_Tipo_Movimento_Carteira)

    Private ReadOnly Log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            If IsNothing(Session("Usuario")) Then
                Response.Redirect("~/Pages/Sair.aspx")
            Else
                _Usuario = Session("Usuario")
                If Util.VerificaAcesso(_Usuario, Me.Title) = False Then Response.Redirect("~/Pages/AcessoNegado.aspx")
            End If

            If Not IsNothing(Request.QueryString("Veiculo")) Then
                _VeiculoCarteira = Request.QueryString("Veiculo")
                GetVeiculo(_VeiculoCarteira)
                'btn_registrar.Text = "Atualizar"
            End If

            GetTipoMovimentos()
            GetLançamentos()
        End If



    End Sub

    Private Sub GetTipoMovimentos()

        Dim BIZ As New Tbl_Tipo_Movimento_Carteira_BIZ
        _ListaTipos = BIZ.GetTipos()
        Session("TiposVeiculos") = _ListaTipos

        drp_tipo_movimento.DataSource = _ListaTipos
        drp_tipo_movimento.DataTextField = "Descricao"
        drp_tipo_movimento.DataValueField = "CodTipoMovimentoCarteira"

        drp_tipo_movimento.DataBind()


    End Sub

    Private Sub GetVeiculo(Cod As String)

        Dim Obj As New Tbl_Veiculo
        LimparCampos(2)

        Try

            Obj = vBIZ.GetVeiculoById(Cod)

            hfd_codVeiculo.Value = Cod
            lbl_veiculo.Text = Obj.Descricao
            lbl_motorista.Text = Obj.Motorista
            lbl_placa1.Text = Obj.Placa1
            lbl_placa2.Text = Obj.Placa2
            lbl_saldo.Text = "R$ " & "0.000,00"

            GetSaldo(Cod)

        Catch ex As Exception

            'Erro
            Log.Fatal(ex.Message)

        End Try

    End Sub


    Private Sub GetSaldo(Cod As Integer)
        Try

            Dim Saldo As Double = mcBIZ.GetSaldo(Cod).ToString()
            'lbl_saldo.Text = Saldo.ToString("R$ #,###.##")
            lbl_saldo.Text = Saldo.ToString("R$ #,###.##")

        Catch ex As Exception

            Log.Fatal(ex.Message)

        End Try

    End Sub

    Private Sub LimparCampos(form As Integer)

        If form = 1 Then
            lbl_carteira.Text = ""
            lbl_motorista.Text = ""
            lbl_placa1.Text = ""
            lbl_placa2.Text = ""
            lbl_saldo.Text = ""
            lbl_veiculo.Text = ""
        Else
            txt_descricao.Text = ""
            txt_valor.Text = ""
        End If

    End Sub

    Private Sub GetLançamentos()

        Dim Lista As New List(Of Tbl_Movimento_Carteira_Veiculo)

        Try

            If Not IsNothing(hfd_codVeiculo.Value) Then

                Lista = mcBIZ.GetLancamentos(hfd_codVeiculo.Value)

                grid_lancamentos.DataSource = Lista
                grid_lancamentos.DataBind()

            End If

        Catch ex As Exception

            'Erro
            Log.Fatal(ex.Message)

        End Try


    End Sub

    Protected Sub btn_registrar_Click(sender As Object, e As EventArgs)

        Dim Obj As New Tbl_Movimento_Carteira_Veiculo
        Obj.Veiculo = New Tbl_Veiculo
        Obj.TipoMovimento = New Tbl_Tipo_Movimento_Carteira

        Try

            Obj.Veiculo.CodVeiculo = Convert.ToInt32(hfd_codVeiculo.Value.ToString.PadLeft(10, "0"))
            Obj.TipoMovimento.CodTipoMovimentoCarteira = drp_tipo_movimento.SelectedValue
            Obj.Descricao = txt_descricao.Text
            Obj.Valor = txt_valor.Text
            Obj.DesTipoRegistro = drp_credito_debito.SelectedValue

            mcBIZ.InsertMovimento(Obj)

            btn_registrar.Text = "Salvar"
            LimparCampos(2)
            GetLançamentos()
            GetSaldo(Obj.Veiculo.CodVeiculo)

        Catch ex As Exception

            Log.Fatal(ex.Message)

        End Try

    End Sub
End Class