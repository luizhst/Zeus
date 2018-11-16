

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

    Public Function GetValorOleo() As Decimal

        Dim BIZParametro As New Tbl_Parametro_BIZ

        Return Convert.ToDecimal(BIZParametro.GetParametroById(1).Valor)

    End Function

    Public Function GetTimbreEmailSolicitacoes() As String

        Dim BIZParametro As New Tbl_Parametro_BIZ

        Return BIZParametro.GetParametroById(2).Valor

    End Function

    Public Function GetEmailEnvio() As String

        Dim BIZParametro As New Tbl_Parametro_BIZ

        Return BIZParametro.GetParametroById(3).Valor

    End Function

    Public Function GetSenhaEnvio() As String

        Dim BIZParametro As New Tbl_Parametro_BIZ

        Return BIZParametro.GetParametroById(4).Valor

    End Function

    Public Function GetSMTPEnvio() As String

        Dim BIZParametro As New Tbl_Parametro_BIZ

        Return BIZParametro.GetParametroById(5).Valor

    End Function

End Class
