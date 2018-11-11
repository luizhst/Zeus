Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Text

Public Class Connection


    Private Shared StringConexao As String = My.Settings.StringConexao.ToString

    'Private Shared StringConexao As String = "Data Source=NB-LUIZHST;Initial Catalog=Db_Zeus;Persist Security Info=True;User ID=sa;Password='bgt5BGT%'"
    'Private Shared StringConexao As String = "Data Source=SERVIDOR;Initial Catalog=Db_Zeus;Persist Security Info=True;User ID=sa;Password='bgt5BGT%'"

    Private ReadOnly Log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Public Function GetConexao() As SqlConnection

        Dim Conexao As New SqlConnection

        Try

            Conexao.ConnectionString = StringConexao

            Conexao.Open()

        Catch ex As Exception

            Log.Fatal(ex.Message)

        End Try

        Return Conexao

    End Function


    Public Sub CloseConexao(ByVal Con As SqlConnection)

        Try

            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If

        Catch ex As Exception

            Log.Fatal(ex.Message)

        End Try

    End Sub




End Class
