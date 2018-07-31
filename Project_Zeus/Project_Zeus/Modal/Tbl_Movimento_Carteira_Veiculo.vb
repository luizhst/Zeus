Public Class Tbl_Movimento_Carteira_Veiculo

    Private _CodCarteira As Integer
    Public Property CodCarteira() As Integer
        Get
            Return _CodCarteira
        End Get
        Set(ByVal value As Integer)
            _CodCarteira = value
        End Set
    End Property

    Private _Veiculo As Tbl_Veiculo
    Public Property Veiculo() As Tbl_Veiculo
        Get
            Return _Veiculo
        End Get
        Set(ByVal value As Tbl_Veiculo)
            _Veiculo = value
        End Set
    End Property

    Private _TipoMovimento As Tbl_Tipo_Movimento_Carteira
    Public Property TipoMovimento() As Tbl_Tipo_Movimento_Carteira
        Get
            Return _TipoMovimento
        End Get
        Set(ByVal value As Tbl_Tipo_Movimento_Carteira)
            _TipoMovimento = value
        End Set
    End Property

    Private _DtaRegistro As DateTime
    Public Property DtaRegistro() As DateTime
        Get
            Return _DtaRegistro
        End Get
        Set(ByVal value As DateTime)
            _DtaRegistro = value
        End Set
    End Property

    Private _DesTipoRegistro As String
    Public Property DesTipoRegistro() As String
        Get
            Return _DesTipoRegistro
        End Get
        Set(ByVal value As String)
            _DesTipoRegistro = value
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

    Private _Valor As Decimal
    Public Property Valor() As Decimal
        Get
            Return _Valor
        End Get
        Set(ByVal value As Decimal)
            _Valor = value
        End Set
    End Property

    Private _Saldo As Decimal
    Public Property Saldo() As Decimal
        Get
            Return _Saldo
        End Get
        Set(ByVal value As Decimal)
            _Saldo = value
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
