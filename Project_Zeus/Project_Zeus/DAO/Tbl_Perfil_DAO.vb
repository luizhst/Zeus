Imports System.Data.SqlClient
Imports System.Text

Public Class Tbl_Perfil_DAO

    Private DB As New Connection
    Private ReadOnly Log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Public Function List(ByVal Sql As String) As List(Of Tbl_Perfil)

        Dim Lista As New List(Of Tbl_Perfil)
        Dim Item As New Tbl_Perfil
        Dim Conexao As New SqlConnection
        Dim Comando As New SqlCommand
        Comando.CommandTimeout = 60
        Dim Reader As SqlDataReader

        Try

            Conexao = DB.GetConexao()

            Comando.CommandText = Sql
            Comando.CommandType = System.Data.CommandType.Text
            Comando.Connection = Conexao
            Reader = Comando.ExecuteReader()

            If (Reader.HasRows) Then

                While (Reader.Read())

                    Item = New Tbl_Perfil

                    Item.CodPerfil = Reader("CodPerfil")
                    Item.DesPerfil = Reader("DesPerfil").ToString
                    Item.FlagAtivo = Reader("FlagAtivo")
                    Item.LogData = Reader("LogData")
                    Item.LogUser = Reader("LogUser").ToString


                    Lista.Add(Item)

                End While

            End If

        Catch ex As Exception

            Log.Error("Erro ao executar: " & Sql)
            Log.Fatal(ex.Message)

        Finally

            DB.CloseConexao(Conexao)

        End Try

        Return Lista

    End Function

End Class
