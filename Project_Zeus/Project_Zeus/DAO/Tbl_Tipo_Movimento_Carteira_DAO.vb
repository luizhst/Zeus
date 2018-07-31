Imports System.Data.SqlClient
Imports System.Text

Public Class Tbl_Tipo_Movimento_Carteira_DAO

    Private DB As New Connection
    Private ReadOnly Log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Public Sub Insert(ByVal Item As Tbl_Tipo_Movimento_Carteira)

        Dim Conexao As New SqlConnection
        Dim Comando As New SqlCommand
        Comando.CommandTimeout = 60
        Dim Sql As New StringBuilder


        Sql.Append("INSERT INTO dbo.TBL_TIPO_MOVIMENTO_CARTEIRA (Descricao, FlagAtivo) VALUES " &
                                                                "(@Descricao, @FlagAtivo)")

        Try

            Conexao = DB.GetConexao()
            Comando.Connection = Conexao
            Comando.CommandText = Sql.ToString()

            Comando.Parameters.AddWithValue("@Descricao", Item.Descricao)
            Comando.Parameters.AddWithValue("@FlagAtivo", Item.FlagAtivo)

            Comando.ExecuteNonQuery()

        Catch ex As Exception

            Log.Fatal(ex.Message)

        Finally

            DB.CloseConexao(Conexao)

        End Try


    End Sub

    Public Sub Update(ByVal Item As Tbl_Tipo_Movimento_Carteira)

        Dim Conexao As New SqlConnection
        Dim Comando As New SqlCommand
        Comando.CommandTimeout = 60
        Dim Sql As New StringBuilder

        Sql.Append("UPDATE dbo.TBL_TIPO_MOVIMENTO_CARTEIRA SET Descricao = @Descricao, FlagAtivo = @FlagAtivo " &
                   "WHERE CodTipoMovimentoCarteira = @CodTipoMovimentoCarteira")

        Try

            Conexao = DB.GetConexao()
            Comando.Connection = Conexao
            Comando.CommandText = Sql.ToString()

            Comando.Parameters.AddWithValue("@CodTipoMovimentoCarteira", Item.CodTipoMovimentoCarteira)
            Comando.Parameters.AddWithValue("@Descricao", Item.Descricao)
            Comando.Parameters.AddWithValue("@FlagAtivo", Item.FlagAtivo)

            Comando.ExecuteNonQuery()

        Catch ex As Exception

            Log.Fatal(ex.Message)

        Finally

            DB.CloseConexao(Conexao)

        End Try


    End Sub


    Public Function List(ByVal Sql As String) As List(Of Tbl_Tipo_Movimento_Carteira)

        Dim Lista As New List(Of Tbl_Tipo_Movimento_Carteira)
        Dim Item As New Tbl_Tipo_Movimento_Carteira
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

                    Item = New Tbl_Tipo_Movimento_Carteira

                    Item.CodTipoMovimentoCarteira = Reader("CodTipoMovimentoCarteira")
                    Item.Descricao = Reader("Descricao").ToString
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
