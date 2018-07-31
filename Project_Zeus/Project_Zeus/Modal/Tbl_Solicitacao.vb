Public Class Tbl_Solicitacao

    Private _CodSolicitacao As Integer
    Public Property CodSolicitacao() As Integer
        Get
            Return _CodSolicitacao
        End Get
        Set(ByVal value As Integer)
            _CodSolicitacao = value
        End Set
    End Property


    Private _DesSolicitante As String
    Public Property DesSolicitante() As String
        Get
            Return _DesSolicitante
        End Get
        Set(ByVal value As String)
            _DesSolicitante = value
        End Set
    End Property

    Private _DtaSolicitacao As DateTime
    Public Property DtaSolicitacao() As DateTime
        Get
            Return _DtaSolicitacao
        End Get
        Set(ByVal value As DateTime)
            _DtaSolicitacao = value
        End Set
    End Property

    Private _DesTitulo As String
    Public Property DesTitulo() As String
        Get
            Return _DesTitulo
        End Get
        Set(ByVal value As String)
            _DesTitulo = value
        End Set
    End Property

    Private _DesSolicitacao As String
    Public Property DesSolicitacao() As String
        Get
            Return _DesSolicitacao
        End Get
        Set(ByVal value As String)
            _DesSolicitacao = value
        End Set
    End Property

    Private _DesStatus As String
    Public Property DesStatus() As String
        Get
            Return _DesStatus
        End Get
        Set(ByVal value As String)
            _DesStatus = value
        End Set
    End Property

    Private _DesAtribuidoPara As String
    Public Property DesAtribuidoPara() As String
        Get
            Return _DesAtribuidoPara
        End Get
        Set(ByVal value As String)
            _DesAtribuidoPara = value
        End Set
    End Property

    Private _DtaUltimaAtualizacao As DateTime
    Public Property DtaUltimaAtualizacao() As DateTime
        Get
            Return _DtaUltimaAtualizacao
        End Get
        Set(ByVal value As DateTime)
            _DtaUltimaAtualizacao = value
        End Set
    End Property

    Private _DesResolucao As String
    Public Property DesResolucao() As String
        Get
            Return _DesResolucao
        End Get
        Set(ByVal value As String)
            _DesResolucao = value
        End Set
    End Property

End Class
