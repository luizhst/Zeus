Imports System.Configuration
Imports MySql.Data.MySqlClient
Imports System.Text

Public Class Connection


    'Private Shared StringConexao As String = My.Settings.StringConexao.ToString

    Private Shared StringConexao As String = "Server=db_servale_app.mysql.dbaas.com.br;Port=3306;Database=db_servale_app;Uid=db_servale_app;Pwd=BReWtz@p27Fa5L;"
    'Private Shared StringConexao As String = "Data Source=SERVIDOR;Initial Catalog=Db_Zeus;Persist Security Info=True;User ID=sa;Password='bgt5BGT%'"

    Private ReadOnly Log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Public Function GetConexao() As MySqlConnection

        Dim Conexao As New MySqlConnection

        Try

            Conexao.ConnectionString = StringConexao

            Conexao.Open()

        Catch ex As Exception

            Log.Fatal(ex.Message)

        End Try

        Return Conexao

    End Function


    Public Sub CloseConexao(ByVal Con As MySqlConnection)

        Try

            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If

        Catch ex As Exception

            Log.Fatal(ex.Message)

        End Try

    End Sub




End Class
