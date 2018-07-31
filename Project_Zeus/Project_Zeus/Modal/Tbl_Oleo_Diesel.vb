Public Class Tbl_Oleo_Diesel

    Private _CodRegistro As Integer
    Public Property CodRegistro() As Integer
        Get
            Return _CodRegistro
        End Get
        Set(ByVal value As Integer)
            _CodRegistro = value
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

    Private _DesUser As String
    Public Property DesUser() As String
        Get
            Return _DesUser
        End Get
        Set(ByVal value As String)
            _DesUser = value
        End Set
    End Property

    Private _DesPlaca_Veiculo As String
    Public Property DesPlaca_Veiculo() As String
        Get
            Return _DesPlaca_Veiculo
        End Get
        Set(ByVal value As String)
            _DesPlaca_Veiculo = value
        End Set
    End Property

    Private _DesNomeVeiculo As String
    Public Property DesNomeVeiculo() As String
        Get
            Return _DesNomeVeiculo
        End Get
        Set(ByVal value As String)
            _DesNomeVeiculo = value
        End Set
    End Property

    Private _NumQtdeOleo As Integer
    Public Property NumQtdeOleo() As Integer
        Get
            Return _NumQtdeOleo
        End Get
        Set(ByVal value As Integer)
            _NumQtdeOleo = value
        End Set
    End Property

    Private _NumSaldo As Integer
    Public Property NumSaldo() As Integer
        Get
            Return _NumSaldo
        End Get
        Set(ByVal value As Integer)
            _NumSaldo = value
        End Set
    End Property

    Private _FlgEntrada As Boolean
    Public Property FlgEntrada() As Boolean
        Get
            Return _FlgEntrada
        End Get
        Set(ByVal value As Boolean)
            _FlgEntrada = value
        End Set
    End Property

    Private _DesKm As String
    Public Property DesKm() As String
        Get
            Return _DesKm
        End Get
        Set(ByVal value As String)
            _DesKm = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return DesPlaca_Veiculo
    End Function

End Class
