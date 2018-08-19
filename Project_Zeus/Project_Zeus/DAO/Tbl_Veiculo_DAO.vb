Imports System.Data.SqlClient
Imports System.Text

Public Class Tbl_Veiculo_DAO

    Private DB As New Connection
    Private ReadOnly Log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Public Sub Insert(ByVal Item As Tbl_Veiculo)

        Dim Conexao As New SqlConnection
        Dim Comando As New SqlCommand
        Comando.CommandTimeout = 60
        Dim Sql As New StringBuilder


        Sql.Append("INSERT INTO dbo.TBL_VEICULO (Descricao, Placa1, Placa2, Motorista, DtaCadastro, DtaAtualizacao, FlagAtivo) VALUES " &
                                               "(@Descricao, @Placa1, @Placa2, @Motorista, @DtaCadastro, @DtaAtualizacao, @FlagAtivo)")

        Try

            Conexao = DB.GetConexao()
            Comando.Connection = Conexao
            Comando.CommandText = Sql.ToString()

            Comando.Parameters.AddWithValue("@Descricao", Item.Descricao)
            Comando.Parameters.AddWithValue("@Placa1", Item.Placa1)
            Comando.Parameters.AddWithValue("@Placa2", Item.Placa2)
            Comando.Parameters.AddWithValue("@Motorista", Item.Motorista)
            Comando.Parameters.AddWithValue("@DtaCadastro", DateTime.Now)
            Comando.Parameters.AddWithValue("@DtaAtualizacao", DateTime.Now)
            Comando.Parameters.AddWithValue("@FlagAtivo", Item.FlagAtivo)

            Comando.ExecuteNonQuery()

        Catch ex As Exception

            Log.Fatal(ex.Message)

        Finally

            DB.CloseConexao(Conexao)

        End Try


    End Sub

    Public Sub Update(ByVal Item As Tbl_Veiculo)

        Dim Conexao As New SqlConnection
        Dim Comando As New SqlCommand
        Comando.CommandTimeout = 60
        Dim Sql As New StringBuilder

        Sql.Append("UPDATE dbo.TBL_VEICULO SET Descricao = @Descricao, Placa1 = @Placa1, Placa2 = @Placa2, " &
                   "Motorista = @Motorista, DtaAtualizacao = @DtaAtualizacao, FlagAtivo = @FlagAtivo " &
                   "WHERE CodVeiculo = @CodVeiculo")

        Try

            Conexao = DB.GetConexao()
            Comando.Connection = Conexao
            Comando.CommandText = Sql.ToString()

            Comando.Parameters.AddWithValue("@CodVeiculo", Item.CodVeiculo)
            Comando.Parameters.AddWithValue("@Descricao", Item.Descricao)
            Comando.Parameters.AddWithValue("@Placa1", Item.Placa1)
            Comando.Parameters.AddWithValue("@Placa2", Item.Placa2)
            Comando.Parameters.AddWithValue("@Motorista", Item.Motorista)
            Comando.Parameters.AddWithValue("@DtaAtualizacao", DateTime.Now)
            Comando.Parameters.AddWithValue("@FlagAtivo", Item.FlagAtivo)

            Comando.ExecuteNonQuery()

        Catch ex As Exception

            Log.Fatal(ex.Message)

        Finally

            DB.CloseConexao(Conexao)

        End Try


    End Sub


    Public Function List(ByVal Sql As String) As List(Of Tbl_Veiculo)

        Dim Lista As New List(Of Tbl_Veiculo)
        Dim Item As New Tbl_Veiculo
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

                    Item = New Tbl_Veiculo

                    Item.CodVeiculo = Reader("CodVeiculo")
                    Item.Descricao = Reader("Descricao").ToString
                    Item.Placa1 = Reader("Placa1").ToString
                    Item.Placa2 = Reader("Placa2").ToString
                    Item.Motorista = Reader("Motorista").ToString
                    Item.DtaCadastro = Reader("DtaCadastro")
                    Item.FlagAtivo = Reader("FlagAtivo")
                    Item.DtaAtualizacao = Reader("DtaAtualizacao")

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
