

Public Class Util

    Public Function VerificaAcesso(ByVal Usuario As Tbl_Usuario, ByVal Pagina As String) As Boolean

        Dim PermiteAcesso As Boolean = True

        'If Pagina = "Incluir | Atualizar Carregamento" Then
        '    If Usuario.DesPerfil <> "AD" And Usuario.DesPerfil <> "UA" Then
        '        PermiteAcesso = False
        '    End If

        'ElseIf Pagina = "Cadastro Usuario" Then
        '    If Usuario.DesPerfil <> "AD" And Usuario.DesPerfil <> "UA" Then
        '        PermiteAcesso = False
        '    End If
        'End If

        Return PermiteAcesso

    End Function

End Class
