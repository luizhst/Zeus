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

            End If

        End If

    End Sub

    Protected Sub btn_registrar_Click(sender As Object, e As EventArgs)

        RegistraSaldo()

    End Sub

    Private Sub RegistraSaldo()

        Dim Item As New Tbl_Oleo_Diesel

        Try

            _User = Session("Usuario")
            Item.DesUser = _User.Nome.ToUpper
            Item.DesPlaca_Veiculo = txt_placa.Text.ToUpper
            Item.DesNomeVeiculo = txt_des_veiculo.Text.ToUpper
            Item.NumQtdeOleo = CInt(txt_qtde.Text)
            Item.DtaRegistro = DateTime.Now
            Item.DesKm = txt_km.Text.ToUpper

            If drp_tipo.Text.Equals("Saída") Then
                Item.FlgEntrada = False
            Else
                Item.FlgEntrada = True
            End If

            Biz.InsertRegistro(Item)

            CarregarUltimosAbastecimentos()
            lbl_estoque_oleo.Text = Biz.GetEstoqueAtual.ToString("#,###")

            Limpar()

        Catch ex As Exception

            Log.Fatal(ex)

        End Try


    End Sub

    Private Sub Limpar()

        txt_placa.Text = ""
        txt_des_veiculo.Text = ""
        txt_qtde.Text = ""
        drp_tipo.SelectedIndex = -1
        txt_km.Text = ""
        lbl_Mensagem_Grid.Visible = False

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