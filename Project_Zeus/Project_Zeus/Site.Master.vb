Public Class SiteMaster
    Inherits MasterPage

    Private Usuario As Tbl_Usuario


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        Usuario = Session("Usuario")
        If Usuario.CodPerfil = 1 Then
            _lbl_menu_config.Visible = True
            _lbl_menu_usuarios.Visible = True
        Else
            _lbl_menu_config.Visible = False
            _lbl_menu_usuarios.Visible = False
        End If

    End Sub

End Class