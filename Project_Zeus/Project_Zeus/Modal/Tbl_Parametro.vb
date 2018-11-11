Public Class Tbl_Parametro

    Private _CodParametro As Integer
    Public Property CodParametro() As Integer
        Get
            Return _CodParametro
        End Get
        Set(ByVal value As Integer)
            _CodParametro = value
        End Set
    End Property

    Private _Nome As String
    Public Property Nome() As String
        Get
            Return _Nome
        End Get
        Set(ByVal value As String)
            _Nome = value
        End Set
    End Property

    Private _Valor As String
    Public Property Valor() As String
        Get
            Return _Valor
        End Get
        Set(ByVal value As String)
            _Valor = value
        End Set
    End Property

    Private _Observacao As String
    Public Property Observacao() As String
        Get
            Return _Observacao
        End Get
        Set(ByVal value As String)
            _Observacao = value
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

    Private _UsuarioRegistro As String
    Public Property UsuarioRegistro() As String
        Get
            Return _UsuarioRegistro
        End Get
        Set(ByVal value As String)
            _UsuarioRegistro = value
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
        Return Nome
    End Function

End Class
