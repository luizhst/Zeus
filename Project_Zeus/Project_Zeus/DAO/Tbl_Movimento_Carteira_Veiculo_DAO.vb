Imports MySql.Data.MySqlClient
Imports System.Text
Imports Project_Zeus

Public Class Tbl_Movimento_Carteira_Veiculo_DAO

    Private DB As New Connection
    Private ReadOnly Log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Public Sub Insert(ByVal Item As Tbl_Movimento_Carteira_Veiculo)

        Dim Conexao As New MySqlConnection
        Dim Comando As New MySqlCommand
        Comando.CommandTimeout = 60
        Dim Sql As New StringBuilder


        Sql.Append("INSERT INTO TBL_MOVIMENTO_CARTEIRA_VEICULO (CodVeiculo, CodTipoMovimentoCarteira, DtaRegistro, DesTipoRegistro, Descricao, " &
                                                                   "Valor, Saldo, FlagAtivo) VALUES " &
                                                                   "(@CodVeiculo, @CodTipoMovimentoCarteira, @DtaRegistro, @DesTipoRegistro, @Descricao, " &
                                                                   "@Valor, @Saldo, @FlagAtivo)")

        Try

            Conexao = DB.GetConexao()
            Comando.Connection = Conexao
            Comando.CommandText = Sql.ToString()

            Comando.Parameters.AddWithValue("@CodVeiculo", Item.Veiculo.CodVeiculo)
            Comando.Parameters.AddWithValue("@CodTipoMovimentoCarteira", Item.TipoMovimento.CodTipoMovimentoCarteira)
            Comando.Parameters.AddWithValue("@DtaRegistro", DateTime.Now)
            Comando.Parameters.AddWithValue("@DesTipoRegistro", Item.DesTipoRegistro)
            Comando.Parameters.AddWithValue("@Descricao", Item.Descricao)
            Comando.Parameters.AddWithValue("@Valor", Item.Valor)
            Comando.Parameters.AddWithValue("@Saldo", Item.Saldo)
            Comando.Parameters.AddWithValue("@FlagAtivo", 1)

            Comando.ExecuteNonQuery()

        Catch ex As Exception

            Log.Fatal(ex.Message)

        Finally

            DB.CloseConexao(Conexao)

        End Try


    End Sub


    Public Sub Update(ByVal Item As Tbl_Movimento_Carteira_Veiculo)

        Dim Conexao As New MySqlConnection
        Dim Comando As New MySqlCommand
        Comando.CommandTimeout = 60
        Dim Sql As New StringBuilder

        Sql.Append("UPDATE TBL_MOVIMENTO_CARTEIRA_VEICULO SET CodVeiculo = @CodVeiculo, CodTipoMovimentoCarteira = @CodTipoMovimentoCarteira " &
                   "DtaRegistro = @DtaRegistro, DesTipoRegistro = @DesTipoRegistro, Descricao = @Descricao, Valor = @Valor, Saldo = @Saldo, FlagAtivo = @FlagAtivo " &
                   "WHERE CodCarteira = @CodCarteira")

        Try

            Conexao = DB.GetConexao()
            Comando.Connection = Conexao
            Comando.CommandText = Sql.ToString()

            Comando.Parameters.AddWithValue("@CodCarteira", Item.CodCarteira)
            Comando.Parameters.AddWithValue("@CodVeiculo", Item.Veiculo.CodVeiculo)
            Comando.Parameters.AddWithValue("@CodTipoMovimentoCarteira", Item.TipoMovimento.CodTipoMovimentoCarteira)
            Comando.Parameters.AddWithValue("@DtaRegistro", DateTime.Now)
            Comando.Parameters.AddWithValue("@DesTipoRegistro", Item.DesTipoRegistro)
            Comando.Parameters.AddWithValue("@Descricao", Item.Descricao)
            Comando.Parameters.AddWithValue("@Valor", Item.Valor)
            Comando.Parameters.AddWithValue("@Saldo", Item.Saldo)
            Comando.Parameters.AddWithValue("@FlagAtivo", Item.FlagAtivo)

            Comando.ExecuteNonQuery()

        Catch ex As Exception

            Log.Fatal(ex.Message)

        Finally

            DB.CloseConexao(Conexao)

        End Try


    End Sub


    Public Function List(ByVal Sql As String) As List(Of Tbl_Movimento_Carteira_Veiculo)

        Dim Lista As New List(Of Tbl_Movimento_Carteira_Veiculo)
        Dim Item As New Tbl_Movimento_Carteira_Veiculo
        Dim Conexao As New MySqlConnection
        Dim Comando As New MySqlCommand
        Comando.CommandTimeout = 60
        Dim Reader As MySqlDataReader

        Try

            Conexao = DB.GetConexao()

            Comando.CommandText = Sql
            Comando.CommandType = System.Data.CommandType.Text
            Comando.Connection = Conexao
            Reader = Comando.ExecuteReader()

            If (Reader.HasRows) Then

                While (Reader.Read())

                    Item = New Tbl_Movimento_Carteira_Veiculo
                    Item.Veiculo = New Tbl_Veiculo
                    Item.TipoMovimento = New Tbl_Tipo_Movimento_Carteira


                    Item.CodCarteira = Reader("CodCarteira")
                    Item.Veiculo.CodVeiculo = Reader("CodVeiculo")
                    Item.TipoMovimento.CodTipoMovimentoCarteira = Reader("CodTipoMovimentoCarteira")
                    Item.DtaRegistro = Reader("DtaRegistro")
                    Item.DesTipoRegistro = Reader("DesTipoRegistro").ToString
                    Item.Descricao = Reader("Descricao").ToString
                    Item.Valor = Reader("Valor")
                    Item.Saldo = Reader("Saldo")
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

    Public Function Saldo(ByVal Sql As String) As Double

        Dim Conexao As New MySqlConnection
        Dim Comando As New MySqlCommand
        Comando.CommandTimeout = 60
        'Dim Reader As SqlDataReader
        Dim _Saldo As Double

        Try

            Conexao = DB.GetConexao()

            Comando.CommandText = Sql
            Comando.CommandType = System.Data.CommandType.Text
            Comando.Connection = Conexao
            Try
                _Saldo = Comando.ExecuteScalar()
            Catch ex As Exception
                Log.Fatal(ex.Message)
            End Try

            'If (Reader.HasRows) Then
            '    Return Reader("TOTAL")
            'Else
            '    Return ""
            'End If

        Catch ex As Exception

            Log.Error("Erro ao executar: " & Sql)
            Log.Fatal(ex.Message)

        Finally

            DB.CloseConexao(Conexao)

        End Try

        Return _Saldo.ToString()

    End Function


End Class
