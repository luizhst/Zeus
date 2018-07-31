Public Class Tbl_Veiculo

    Private _CodVeiculo As Integer
    Public Property CodVeiculo() As Integer
        Get
            Return _CodVeiculo
        End Get
        Set(ByVal value As Integer)
            _CodVeiculo = value
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

    Private _Placa1 As String
    Public Property Placa1() As String
        Get
            Return _Placa1
        End Get
        Set(ByVal value As String)
            _Placa1 = value
        End Set
    End Property

    Private _Placa2 As String
    Public Property Placa2() As String
        Get
            Return _Placa2
        End Get
        Set(ByVal value As String)
            _Placa2 = value
        End Set
    End Property

    Private _Motorista As String
    Public Property Motorista() As String
        Get
            Return _Motorista
        End Get
        Set(ByVal value As String)
            _Motorista = value
        End Set
    End Property

    Private _DtaCadastro As DateTime
    Public Property DtaCadastro() As DateTime
        Get
            Return _DtaCadastro
        End Get
        Set(ByVal value As DateTime)
            _DtaCadastro = value
        End Set
    End Property

    Private _DtaAtualizacao As DateTime
    Public Property DtaAtualizacao() As DateTime
        Get
            Return _DtaAtualizacao
        End Get
        Set(ByVal value As DateTime)
            _DtaAtualizacao = value
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
        Return Placa1 & " - " & Descricao
    End Function

End Class
