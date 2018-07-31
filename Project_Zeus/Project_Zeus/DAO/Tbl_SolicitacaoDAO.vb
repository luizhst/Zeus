Imports System.Data.SqlClient
Imports System.Text

Public Class Tbl_SolicitacaoDAO

    Private DB As New Connection
    Private ReadOnly Log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Public Sub Insert(ByVal Item As Tbl_Solicitacao)

        Dim Conexao As New SqlConnection
        Dim Comando As New SqlCommand
        Comando.CommandTimeout = 60
        Dim Sql As New StringBuilder


        Sql.Append("INSERT INTO dbo.TBL_SOLICITACAO (DesSolicitante, DtaSolicitacao, DesSolicitacao, DesStatus, DesAtribuidoPara, DtaUltimaAtualizacao, DesResolucao, DesTitulo) VALUES " &
                                               "(@DesSolicitante, @DtaSolicitacao, @DesSolicitacao, @DesStatus, @DesAtribuidoPara, @DtaUltimaAtualizacao, @DesResolucao, @DesTitulo)")

        Try

            Conexao = DB.GetConexao()
            Comando.Connection = Conexao
            Comando.CommandText = Sql.ToString()

            Comando.Parameters.AddWithValue("@DesSolicitante", Item.DesSolicitante)
            Comando.Parameters.AddWithValue("@DtaSolicitacao", Item.DtaSolicitacao)
            Comando.Parameters.AddWithValue("@DesSolicitacao", Item.DesSolicitacao)
            Comando.Parameters.AddWithValue("@DesStatus", Item.DesStatus)
            Comando.Parameters.AddWithValue("@DesAtribuidoPara", Item.DesAtribuidoPara)
            Comando.Parameters.AddWithValue("@DtaUltimaAtualizacao", Item.DtaUltimaAtualizacao)
            Comando.Parameters.AddWithValue("@DesResolucao", Item.DesResolucao)
            Comando.Parameters.AddWithValue("@DesTitulo", Item.DesTitulo)

            Comando.ExecuteNonQuery()

        Catch ex As Exception

            Log.Fatal(ex.Message)

        Finally

            DB.CloseConexao(Conexao)

        End Try


    End Sub


    Public Sub Update(ByVal Item As Tbl_Solicitacao)

        Dim Conexao As New SqlConnection
        Dim Comando As New SqlCommand
        Comando.CommandTimeout = 60
        Dim Sql As New StringBuilder

        Sql.Append("UPDATE dbo.TBL_SOLICITACAO SET DesSolicitante = @DesSolicitante, DtaSolicitacao = @DtaSolicitacao, DesSolicitacao = @DesSolicitacao, " &
                   "DesStatus = @DesStatus, DesAtribuidoPara = @DesAtribuidoPara, DtaUltimaAtualizacao = @DtaUltimaAtualizacao, DesResolucao = @DesResolucao, " &
                   "DesTitulo = @DesTitulo WHERE CodSolicitacao = @CodSolicitacao")

        Try

            Conexao = DB.GetConexao()
            Comando.Connection = Conexao
            Comando.CommandText = Sql.ToString()

            Comando.Parameters.AddWithValue("@CodSolicitacao", Item.CodSolicitacao)
            Comando.Parameters.AddWithValue("@DesSolicitante", Item.DesSolicitante)
            Comando.Parameters.AddWithValue("@DtaSolicitacao", Item.DtaSolicitacao)
            Comando.Parameters.AddWithValue("@DesSolicitacao", Item.DesSolicitacao)
            Comando.Parameters.AddWithValue("@DesStatus", Item.DesStatus)
            Comando.Parameters.AddWithValue("@DesAtribuidoPara", Item.DesAtribuidoPara)
            Comando.Parameters.AddWithValue("@DtaUltimaAtualizacao", Item.DtaUltimaAtualizacao)
            Comando.Parameters.AddWithValue("@DesResolucao", Item.DesResolucao)
            Comando.Parameters.AddWithValue("@DesTitulo", Item.DesTitulo)

            Comando.ExecuteNonQuery()

        Catch ex As Exception

            Log.Fatal(ex.Message)

        Finally

            DB.CloseConexao(Conexao)

        End Try


    End Sub

    Public Function List(ByVal Sql As String) As List(Of Tbl_Solicitacao)

        Dim Lista As New List(Of Tbl_Solicitacao)
        Dim Item As New Tbl_Solicitacao
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

                    Item = New Tbl_Solicitacao

                    Item.CodSolicitacao = Reader("CodSolicitacao")
                    Item.DesSolicitante = Reader("DesSolicitante")
                    Item.DtaSolicitacao = Reader("DtaSolicitacao")
                    Item.DesSolicitacao = Reader("DesSolicitacao")
                    Item.DesStatus = Reader("DesStatus")
                    Item.DesAtribuidoPara = Reader("DesAtribuidoPara")
                    Item.DtaUltimaAtualizacao = Reader("DtaUltimaAtualizacao")
                    Item.DesResolucao = Reader("DesResolucao")
                    Item.DesTitulo = Reader("DesTitulo")

                    Lista.Add(Item)

                End While

            End If

        Catch ex As Exception

            Log.Fatal(ex.Message)

        Finally

            DB.CloseConexao(Conexao)

        End Try

        Return Lista

    End Function


End Class
