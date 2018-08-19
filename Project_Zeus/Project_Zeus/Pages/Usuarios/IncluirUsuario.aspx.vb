Public Class IncluirUsuario
    Inherits System.Web.UI.Page


    Private _Usuario As Tbl_Usuario
    Private _EditarUsuario As String


    Private ReadOnly Log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
    Private Biz As New Tbl_UsuarioBIZ

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            _Usuario = Session("Usuario")

            If IsNothing(Session("Usuario")) Then
                Response.Redirect("~/Pages/Sair.aspx")
            End If


            If Not IsPostBack() Then
                If Not IsNothing(Request.QueryString("Cod")) Then
                    _EditarUsuario = Request.QueryString("Cod")
                    GetUsuario(_EditarUsuario)
                    btn_registrar.Text = "Atualizar"
                End If
            End If

            GetPerfis()

        Catch ex As Exception

            Log.Fatal(ex.Message)

        End Try

    End Sub

    Private Sub GetPerfis()

        Dim Lista As New List(Of Tbl_Perfil)

        If IsNothing(Session("Perfis")) Then

            Lista = Biz.GetPerfis().ToList()
            Session("Perfis") = Lista

        Else

            Lista = Session("Perfis")

        End If

        drp_perfil.DataSource = Lista
        drp_perfil.DataValueField = "CodPerfil"
        drp_perfil.DataTextField = "DesPerfil"
        drp_perfil.DataBind()

    End Sub

    Protected Sub btn_registrar_Click(sender As Object, e As EventArgs)

        Dim Obj As New Tbl_Usuario

        Try

            Obj.CodUsuario = Convert.ToInt32(txt_cod_usuario.Text.ToString.PadLeft(10, "0"))
            Obj.Nome = txt_nome_usuario.Text
            Obj.SobreNome = txt_sobrenome_usuario.Text
            Obj.ContaLogin = txt_login.Text
            Obj.SenhaLogin = txt_senha.Text
            Obj.DtaNascimento = txt_nascimento.Text
            Obj.CodPerfil = drp_perfil.SelectedValue

            If drp_status.SelectedIndex = 0 Then
                Obj.FlgAtivo = True
            Else
                Obj.FlgAtivo = False
            End If

            Biz.InsertUsuario(Obj)

            Response.Redirect("Usuarios.aspx")

        Catch ex As Exception

            Log.Fatal(ex.Message)

        End Try


    End Sub

    Public Sub GetUsuario(ByVal Cod As Integer)

        Dim Obj As New Tbl_Usuario
        LimparCampos()

        Try

            Obj = Biz.GetUsuarioById(Cod)

            txt_cod_usuario.Text = Cod
            txt_nome_usuario.Text = Obj.Nome
            txt_sobrenome_usuario.Text = Obj.SobreNome
            txt_senha.Text = Obj.SenhaLogin
            txt_senha.Attributes("value") = Obj.SenhaLogin
            txt_login.Text = Obj.ContaLogin
            txt_nascimento.Text = Obj.DtaNascimento
            drp_perfil.SelectedValue = Obj.CodPerfil

            If Obj.FlgAtivo = True Then
                drp_status.SelectedIndex = 0
            Else
                drp_status.SelectedIndex = 1
            End If

        Catch ex As Exception

            'Erro
            Log.Fatal(ex.Message)

        End Try

    End Sub

    Private Sub LimparCampos()
        txt_cod_usuario.Text = ""
        txt_nome_usuario.Text = ""
        txt_sobrenome_usuario.Text = ""
        txt_senha.Text = ""
        txt_login.Text = ""
        txt_nascimento.Text = ""
        drp_status.SelectedIndex = -1
        drp_perfil.SelectedIndex = -1
    End Sub


End Class