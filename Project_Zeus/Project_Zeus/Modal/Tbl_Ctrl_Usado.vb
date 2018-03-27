Public Class Tbl_Ctrl_Usado


    Private _CodCtrl As Integer
    Public Property CodCtrl() As Integer
        Get
            Return _CodCtrl
        End Get
        Set(ByVal value As Integer)
            _CodCtrl = value
        End Set
    End Property

    Private _HistCarga As Tbl_Hist_Carga
    Public Property HistCarga() As Tbl_Hist_Carga
        Get
            Return _HistCarga
        End Get
        Set(ByVal value As Tbl_Hist_Carga)
            _HistCarga = value
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

    Private _DtaNotaFiscal As DateTime
    Public Property DtaNotaFiscal() As DateTime
        Get
            Return _DtaNotaFiscal
        End Get
        Set(ByVal value As DateTime)
            _DtaNotaFiscal = value
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

    Private _DesCnpj As String
    Public Property DesCnpj() As String
        Get
            Return _DesCnpj
        End Get
        Set(ByVal value As String)
            _DesCnpj = value
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

    Private _DesProduto As String
    Public Property DesProduto() As String
        Get
            Return _DesProduto
        End Get
        Set(ByVal value As String)
            _DesProduto = value
        End Set
    End Property

    Private _QtdeTotal As Integer
    Public Property QtdeTotal() As Integer
        Get
            Return _QtdeTotal
        End Get
        Set(ByVal value As Integer)
            _QtdeTotal = value
        End Set
    End Property

    Private _QtdeFpq As Integer
    Public Property QtdeFpq() As Integer
        Get
            Return _QtdeFpq
        End Get
        Set(ByVal value As Integer)
            _QtdeFpq = value
        End Set
    End Property

    Private _DesPercentualSucata As String
    Public Property DesPercentualSucata() As String
        Get
            Return _DesPercentualSucata
        End Get
        Set(ByVal value As String)
            _DesPercentualSucata = value
        End Set
    End Property

    Private _QtdeSucata As Integer
    Public Property QtdeSucata() As Integer
        Get
            Return _QtdeSucata
        End Get
        Set(ByVal value As Integer)
            _QtdeSucata = value
        End Set
    End Property

    Private _QtdeTotalLiquido As Integer
    Public Property QtdeTotalLiquido() As Integer
        Get
            Return _QtdeTotalLiquido
        End Get
        Set(ByVal value As Integer)
            _QtdeTotalLiquido = value
        End Set
    End Property

    Private _QtdeDisponivel As Integer
    Public Property QtdeDisponivel() As Integer
        Get
            Return _QtdeDisponivel
        End Get
        Set(ByVal value As Integer)
            _QtdeDisponivel = value
        End Set
    End Property

    Private _FlgFaturadoSucata As Boolean
    Public Property FlgFaturadoSucata() As Boolean
        Get
            Return _FlgFaturadoSucata
        End Get
        Set(ByVal value As Boolean)
            _FlgFaturadoSucata = value
        End Set
    End Property

    Private _FlgFaturadoFPQ As Boolean
    Public Property FlgFaturadoFPQ() As Boolean
        Get
            Return _FlgFaturadoFPQ
        End Get
        Set(ByVal value As Boolean)
            _FlgFaturadoFPQ = value
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

    Private _DesUsuarioRegistro As String
    Public Property DesUsuarioRegistro() As String
        Get
            Return _DesUsuarioRegistro
        End Get
        Set(ByVal value As String)
            _DesUsuarioRegistro = value
        End Set
    End Property


End Class

