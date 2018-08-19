Public Class Tbl_Perfil

    Private _CodPerfil As Integer
    Public Property CodPerfil() As Integer
        Get
            Return _CodPerfil
        End Get
        Set(ByVal value As Integer)
            _CodPerfil = value
        End Set
    End Property

    Private _DesPerfil As String
    Public Property DesPerfil() As String
        Get
            Return _DesPerfil
        End Get
        Set(ByVal value As String)
            _DesPerfil = value
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

    Private _LogData As DateTime
    Public Property LogData() As DateTime
        Get
            Return _LogData
        End Get
        Set(ByVal value As DateTime)
            _LogData = value
        End Set
    End Property

    Private _LogUser As String
    Public Property LogUser() As String
        Get
            Return _LogUser
        End Get
        Set(ByVal value As String)
            _LogUser = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return DesPerfil
    End Function

End Class
