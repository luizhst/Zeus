Public Class Tbl_Usuario

#Region "Atributos"

    Private _CodUsuario As Integer
    Public Property CodUsuario() As Integer
        Get
            Return _CodUsuario
        End Get
        Set(ByVal value As Integer)
            _CodUsuario = value
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

    Private _SobreNome As String
    Public Property SobreNome() As String
        Get
            Return _SobreNome
        End Get
        Set(ByVal value As String)
            _SobreNome = value
        End Set
    End Property

    Private _ContaLogin As String
    Public Property ContaLogin() As String
        Get
            Return _ContaLogin
        End Get
        Set(ByVal value As String)
            _ContaLogin = value
        End Set
    End Property

    Private _SenhaLogin As String
    Public Property SenhaLogin() As String
        Get
            Return _SenhaLogin
        End Get
        Set(ByVal value As String)
            _SenhaLogin = value
        End Set
    End Property

    Private _DtaNascimento As DateTime
    Public Property DtaNascimento() As DateTime
        Get
            Return _DtaNascimento
        End Get
        Set(ByVal value As DateTime)
            _DtaNascimento = value
        End Set
    End Property

    Private _FlgAtivo As Boolean
    Public Property FlgAtivo() As Boolean
        Get
            Return _FlgAtivo
        End Get
        Set(ByVal value As Boolean)
            _FlgAtivo = value
        End Set
    End Property

    Private _CodPerfil As Integer
    Public Property CodPerfil() As Integer
        Get
            Return _CodPerfil
        End Get
        Set(ByVal value As Integer)
            _CodPerfil = value
        End Set
    End Property

#End Region

End Class
