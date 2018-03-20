Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Text

Public Class Connection


    'Private Shared StringConexao As String = ConfigurationManager.ConnectionStrings("").ConnectionString

    Private Shared StringConexao As String = "Data Source=NB-LUIZHST;Initial Catalog=Db_Zeus;Persist Security Info=True;User ID='sa';Password='BGT5bgt%'"

    Public Function GetConexao() As SqlConnection

        Dim Conexao As New SqlConnection

        StringConexao = "Data Source=NB-LUIZHST;Initial Catalog=Db_Zeus;Persist Security Info=True;User ID=sa;Password='bgt5BGT%'"

        Try

            Conexao.ConnectionString = StringConexao

            Conexao.Open()

        Catch ex As Exception

            MsgBox(ex.Message.ToUpper)

        End Try

        Return Conexao

    End Function


    Public Sub CloseConexao(ByVal Con As SqlConnection)

        Try

            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If

        Catch ex As Exception

            MsgBox(ex.Message.ToUpper)

        End Try

    End Sub




End Class
