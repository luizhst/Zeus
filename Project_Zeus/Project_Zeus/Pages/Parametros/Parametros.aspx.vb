Public Class Parametros
    Inherits System.Web.UI.Page

    Private _Usuario As New Tbl_Usuario
    Private Util As New Util
    Private BIZ As New Tbl_Parametro_BIZ
    Private _Editar As String

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
                _Editar = Request.QueryString("Cod")
                GetParametro(_Editar)
                btn_registrar.Text = "Atualizar"
            End If

            CarregarParametros()

        End If

    End Sub

    Private Sub CarregarParametros()

        Dim Lista As New List(Of Tbl_Parametro)
        Lista = BIZ.GetParametros().ToList()

        If Lista.Count > 0 Then

            lbl_Mensagem_Grid.Visible = False
            grid_parametros.DataSource = Nothing
            grid_parametros.DataSource = Lista

            grid_parametros.DataBind()

        Else

            lbl_Mensagem_Grid.Visible = True
            lbl_Mensagem_Grid.Text = "Não existem veículos cadastrados no sistema!"

        End If



    End Sub

    Public Sub GetParametro(ByVal Cod As Integer)

        Dim Obj As New Tbl_Parametro
        LimparCampos()

        Try

            Obj = BIZ.GetParametroById(Cod)

            txt_codParametro.Text = Cod
            txt_Nome.Text = Obj.Nome
            txt_Nome.ReadOnly = True
            txt_Valor.Text = Obj.Valor
            txt_obs.Text = Obj.Observacao

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

        txt_codParametro.Text = ""
        txt_Nome.Text = ""
        txt_Valor.Text = ""
        txt_obs.Text = ""
        drp_status.SelectedValue = 0

    End Sub

    Protected Sub btn_registrar_Click(sender As Object, e As EventArgs)
        Dim Obj As New Tbl_Parametro

        Try

            Obj.CodParametro = Convert.ToInt32(txt_codParametro.Text.ToString.PadLeft(10, "0"))
            Obj.Nome = txt_Nome.Text
            Obj.Valor = txt_Valor.Text
            Obj.Observacao = txt_obs.Text
            Obj.DtaRegistro = DateTime.Now
            _Usuario = Session("Usuario")
            Obj.UsuarioRegistro = IIf(IsNothing(_Usuario.ContaLogin), "", _Usuario.ContaLogin)

            If drp_status.SelectedValue = 0 Then
                Obj.FlagAtivo = False
            Else
                Obj.FlagAtivo = True
            End If

            BIZ.InsertParametro(Obj)

            btn_registrar.Text = "Salvar"
            CarregarParametros()
            LimparCampos()

        Catch ex As Exception

            Log.Fatal(ex.Message)

        End Try
    End Sub
End Class