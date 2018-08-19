Public Class IncluiVeiculo
    Inherits System.Web.UI.Page

    Private _Usuario As New Tbl_Usuario
    Private Util As New Util
    Private BIZ As New Tbl_Veiculo_BIZ
    Private _EditarVeiculo As String

    Private ReadOnly Log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            If IsNothing(Session("Usuario")) Then
                Response.Redirect("~/Pages/Sair.aspx")
            Else
                _Usuario = Session("Usuario")
                If Util.VerificaAcesso(_Usuario, Me.Title) = False Then Response.Redirect("~/Pages/AcessoNegado.aspx")
            End If

            If Not IsNothing(Request.QueryString("Cod")) Then
                _EditarVeiculo = Request.QueryString("Cod")
                GetVeiculo(_EditarVeiculo)
                btn_registrar.Text = "Atualizar"
            End If

            CarregarVeiculos()

        End If

    End Sub

    Private Sub CarregarVeiculos()

        Dim Lista As New List(Of Tbl_Veiculo)
        Lista = BIZ.GetVeiculos().ToList()

        If Lista.Count > 0 Then

            lbl_Mensagem_Grid.Visible = False
            grid_veiculos.DataSource = Nothing
            grid_veiculos.DataSource = Lista

            grid_veiculos.DataBind()

        Else

            lbl_Mensagem_Grid.Visible = True
            lbl_Mensagem_Grid.Text = "Não existem veículos cadastrados no sistema!"

        End If



    End Sub

    Protected Sub btn_registrar_Click(sender As Object, e As EventArgs)

        Dim Obj As New Tbl_Veiculo

        Try

            Obj.CodVeiculo = Convert.ToInt32(txt_codVeiculo.Text.ToString.PadLeft(10, "0"))
            Obj.Descricao = txt_des_veiculo.Text
            Obj.Placa1 = txt_placa1.Text
            Obj.Placa2 = txt_placa2.Text
            Obj.Motorista = txt_motorista.Text

            If drp_status.SelectedValue = 0 Then
                Obj.FlagAtivo = False
            Else
                Obj.FlagAtivo = True
            End If

            BIZ.InsertVeiculo(Obj)

            btn_registrar.Text = "Salvar"
            CarregarVeiculos()
            LimparCampos()

        Catch ex As Exception

            Log.Fatal(ex.Message)

        End Try

    End Sub

    Public Sub GetVeiculo(ByVal Cod As Integer)

        Dim Obj As New Tbl_Veiculo
        LimparCampos()

        Try

            Obj = BIZ.GetVeiculoById(Cod)

            txt_codVeiculo.Text = Cod
            txt_des_veiculo.Text = Obj.Descricao
            txt_motorista.Text = Obj.Motorista
            txt_placa1.Text = Obj.Placa1
            txt_placa2.Text = Obj.Placa2

            If Obj.FlagAtivo = True Then
                drp_status.SelectedValue = 1

            Else
                drp_status.SelectedValue = 0
            End If

        Catch ex As Exception

            'Erro
            Log.Fatal(ex.Message)

        End Try

    End Sub

    Private Sub LimparCampos()

        txt_codVeiculo.Text = ""
        txt_des_veiculo.Text = ""
        txt_motorista.Text = ""
        txt_placa1.Text = ""
        txt_placa2.Text = ""
        drp_status.SelectedValue = 0

    End Sub
End Class