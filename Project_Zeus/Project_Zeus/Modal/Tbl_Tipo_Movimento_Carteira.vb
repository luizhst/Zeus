Public Class Tbl_Tipo_Movimento_Carteira

    Private _CodTipoMovimentoCarteira As Integer
    Public Property CodTipoMovimentoCarteira() As Integer
        Get
            Return _CodTipoMovimentoCarteira
        End Get
        Set(ByVal value As Integer)
            _CodTipoMovimentoCarteira = value
        End Set
    End Property

    Private _Descricao As String
    Public Property Descricao() As String
        Get
            Return _Descricao
        End Get
        Set(ByVal value As String)
            _Descricao = value
        End Set
    End Property

    Private _FlagAtivo As Boolean
    Public Property FlagAtivo() As Boolean
        Get
            Return _FlagAtivo
        End Get
        Set(ByVal value As Boolean)
            _FlagAtivo = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return Descricao
    End Function

End Class
