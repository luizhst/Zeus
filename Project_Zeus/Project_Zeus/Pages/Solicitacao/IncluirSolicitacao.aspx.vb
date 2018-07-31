Public Class IncluirSolicitacao
    Inherits System.Web.UI.Page

    Private _User As New Tbl_Usuario
    Private Util As New Util
    Private Biz As New Tbl_SolicitacaoBIZ

    Private ReadOnly Log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            If IsNothing(Session("Usuario")) Then
                Response.Redirect("~/Pages/Sair.aspx")

            Else
                _User = Session("Usuario")

                If _User.DesPerfil <> "AD" Then

                    txt_resolucao.ReadOnly = True
                    btn_registrar_solucao.Visible = False

                End If

                If Not IsNothing(Request.QueryString("Cod")) Then
                    GetSolicitacao(Request.QueryString("Cod"))
                    btn_registrar_solicitacao.Text = "Atualizar Solicitação"
                End If

            End If

        End If


    End Sub

    Private Sub GetSolicitacao(codSolicitacao As Integer)

        Dim Item As New Tbl_Solicitacao
        Limpar()

        Try

            Item = Biz.GetSolicitacaoById(codSolicitacao)

            txt_cod.Text = Item.CodSolicitacao
            txt_titulo.Text = Item.DesTitulo
            txt_dta_registro.Text = Item.DtaSolicitacao
            txt_solicitante.Text = Item.DesSolicitante
            txt_descricao.Text = Item.DesSolicitacao
            txt_resolucao.Text = Item.DesResolucao
            txt_atribuido_para.Text = Item.DesAtribuidoPara
            txt_status.Text = Item.DesStatus
            txt_ultima_atualizacao.Text = Item.DtaUltimaAtualizacao

        Catch ex As Exception

            Log.Fatal(ex.Message)

        End Try

    End Sub

    Public Sub Limpar()

        txt_cod.Text = ""
        txt_atribuido_para.Text = ""
        txt_descricao.Text = ""
        txt_resolucao.Text = ""
        txt_solicitante.Text = ""
        txt_status.Text = ""
        txt_ultima_atualizacao.Text = ""
        txt_titulo.Text = ""
        txt_dta_registro.Text = ""

    End Sub

    Protected Sub btn_registrar_solicitacao_Click(sender As Object, e As EventArgs)

        CriarSolicitacao(1)

    End Sub

    Private Sub CriarSolicitacao(ByVal Acao As Integer)

        Dim Item As New Tbl_Solicitacao

        Try

            _User = Session("Usuario")

            Item.CodSolicitacao = IIf(Convert.ToInt32(txt_cod.Text.ToString.PadLeft(4, "0")) = 0, 0, Convert.ToInt32(txt_cod.Text.ToString.PadLeft(4, "0")))
            Item.DesSolicitacao = txt_descricao.Text

            If txt_dta_registro.Text <> "" Then
                Item.DtaSolicitacao = txt_dta_registro.Text
            Else
                Item.DtaSolicitacao = Date.Now
            End If

            Item.DtaUltimaAtualizacao = Date.Now

            If txt_solicitante.Text <> "" Then
                Item.DesSolicitante = txt_solicitante.Text
            Else
                Item.DesSolicitante = _User.Nome & " " & _User.SobreNome
            End If

            If Acao = 1 Then
                Item.DesStatus = "Em Aberto"
                Item.DesAtribuidoPara = ""
            Else
                Item.DesStatus = "Finalizada"
                Item.DesAtribuidoPara = _User.Nome & " " & _User.SobreNome
            End If

            Item.DesTitulo = txt_titulo.Text
            Item.DesResolucao = txt_resolucao.Text

            Biz.InsertSolicitacao(Item)

            Response.Redirect("~/Pages/Solicitacao/Solicitacoes.aspx")

            Limpar()


        Catch ex As Exception

            Log.Debug(ex.Message)

        End Try

    End Sub

    Protected Sub btn_registrar_solucao_Click(sender As Object, e As EventArgs)

        CriarSolicitacao(2)

    End Sub
End Class