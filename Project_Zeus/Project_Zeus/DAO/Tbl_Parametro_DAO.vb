Imports System.Data.SqlClient
Imports System.Text

Public Class Tbl_Parametro_DAO

    Private DB As New Connection
    Private ReadOnly Log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Public Sub Insert(ByVal Item As Tbl_Parametro)

        Dim Conexao As New SqlConnection
        Dim Comando As New SqlCommand
        Comando.CommandTimeout = 60
        Dim Sql As New StringBuilder


        Sql.Append("INSERT INTO dbo.TBL_PARAMETROS (Nome, Valor, Observacao, DtaRegistro, UsuarioRegistro, FlagAtivo) VALUES " &
                                               "(@Nome, @Valor, @Observacao, @DtaRegistro, @UsuarioRegistro, @FlagAtivo)")

        Try

            Conexao = DB.GetConexao()
            Comando.Connection = Conexao
            Comando.CommandText = Sql.ToString()

            Comando.Parameters.AddWithValue("@Nome", Item.Nome)
            Comando.Parameters.AddWithValue("@Valor", Item.Valor)
            Comando.Parameters.AddWithValue("@Observacao", Item.Observacao)
            Comando.Parameters.AddWithValue("@DtaRegistro", DateTime.Now)
            Comando.Parameters.AddWithValue("@UsuarioRegistro", Item.UsuarioRegistro)
            Comando.Parameters.AddWithValue("@FlagAtivo", Item.FlagAtivo)

            Comando.ExecuteNonQuery()

        Catch ex As Exception

            Log.Fatal(ex.Message)

        Finally

            DB.CloseConexao(Conexao)

        End Try


    End Sub

    Public Sub Update(ByVal Item As Tbl_Parametro)

        Dim Conexao As New SqlConnection
        Dim Comando As New SqlCommand
        Comando.CommandTimeout = 60
        Dim Sql As New StringBuilder

        Sql.Append("UPDATE dbo.TBL_PARAMETROS SET Valor = @Valor, Observacao = @Observacao, " &
                   "FlagAtivo = @FlagAtivo WHERE CodParametro = @CodParametro")

        Try

            Conexao = DB.GetConexao()
            Comando.Connection = Conexao
            Comando.CommandText = Sql.ToString()

            Comando.Parameters.AddWithValue("@CodParametro", Item.CodParametro)
            Comando.Parameters.AddWithValue("@Valor", Item.Valor)
            Comando.Parameters.AddWithValue("@Observacao", Item.Observacao)
            Comando.Parameters.AddWithValue("@FlagAtivo", Item.FlagAtivo)

            Comando.ExecuteNonQuery()

        Catch ex As Exception

            Log.Fatal(ex.Message)

        Finally

            DB.CloseConexao(Conexao)

        End Try


    End Sub


    Public Function List(ByVal Sql As String) As List(Of Tbl_Parametro)

        Dim Lista As New List(Of Tbl_Parametro)
        Dim Item As New Tbl_Parametro
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

                    Item = New Tbl_Parametro

                    Item.CodParametro = Reader("CodParametro")
                    Item.Nome = Reader("Nome").ToString
                    Item.Valor = Reader("Valor").ToString
                    Item.Observacao = Reader("Observacao").ToString
                    Item.DtaRegistro = Reader("DtaRegistro").ToString
                    Item.UsuarioRegistro = Reader("UsuarioRegistro")
                    Item.FlagAtivo = Reader("FlagAtivo")

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
