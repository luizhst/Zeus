Public Class Tbl_Hist_Carga

    Private _CodHist As Integer
    Public Property CodHist() As Integer
        Get
            Return _CodHist
        End Get
        Set(ByVal value As Integer)
            _CodHist = value
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

    Private _DtaAtualizacao As DateTime
    Public Property DtaAtualizacao() As DateTime
        Get
            Return _DtaAtualizacao
        End Get
        Set(ByVal value As DateTime)
            _DtaAtualizacao = value
        End Set
    End Property

    Private _DesOrigemDestino As String
    Public Property DesOrigemDestino() As String
        Get
            Return _DesOrigemDestino
        End Get
        Set(ByVal value As String)
            _DesOrigemDestino = value
        End Set
    End Property

    Private _DesMotorista As String
    Public Property DesMotorista() As String
        Get
            Return _DesMotorista
        End Get
        Set(ByVal value As String)
            _DesMotorista = value
        End Set
    End Property

    Private _DesTransportadora As String
    Public Property DesTransportadora() As String
        Get
            Return _DesTransportadora
        End Get
        Set(ByVal value As String)
            _DesTransportadora = value
        End Set
    End Property

    Private _DesPlaca1 As String
    Public Property DesPlaca1() As String
        Get
            Return _DesPlaca1
        End Get
        Set(ByVal value As String)
            _DesPlaca1 = value
        End Set
    End Property

    Private _DesPlaca2 As String
    Public Property DesPlaca2() As String
        Get
            Return _DesPlaca2
        End Get
        Set(ByVal value As String)
            _DesPlaca2 = value
        End Set
    End Property

    Private _DesPlaca3 As String
    Public Property DesPlaca3() As String
        Get
            Return _DesPlaca3
        End Get
        Set(ByVal value As String)
            _DesPlaca3 = value
        End Set
    End Property

    Private _DesTipo As String
    Public Property DesTipo() As String
        Get
            Return _DesTipo
        End Get
        Set(ByVal value As String)
            _DesTipo = value
        End Set
    End Property

    Private _FlgLiberado As Boolean
    Public Property FlgLiberado() As Boolean
        Get
            Return _FlgLiberado
        End Get
        Set(ByVal value As Boolean)
            _FlgLiberado = value
        End Set
    End Property

    Private _DesNotaFiscal As String
    Public Property DesNotaFiscal() As String
        Get
            Return _DesNotaFiscal
        End Get
        Set(ByVal value As String)
            _DesNotaFiscal = value
        End Set
    End Property

    Private _DesPedidoCompra As String
    Public Property DesPedidoCompra() As String
        Get
            Return _DesPedidoCompra
        End Get
        Set(ByVal value As String)
            _DesPedidoCompra = value
        End Set
    End Property

End Class
