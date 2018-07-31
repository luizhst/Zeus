Imports System.Data.SqlClient
Imports System.Text

Public Class Tbl_Hist_CargaDAO


    Private ReadOnly Log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
    Private DB As New Connection

    Public Sub Insert(ByVal Item As Tbl_Hist_Carga)

        Dim Conexao As New SqlConnection
        Dim Comando As New SqlCommand
        Comando.CommandTimeout = 60
        Dim Sql As New StringBuilder


        Sql.Append("INSERT INTO dbo.TBL_HIST_CARGA (DtaRegistro, DtaAtualizacao, DesOrigemDestino, DesMotorista, DesTransportadora, " &
                                                   "DesPlaca1, DesPlaca2, DesPlaca3, DesTipo, FlgLiberado, DesNotaFiscal, DesPedidoCompra, NumCpfMotorista, " &
                                                   "DtaNotaFiscal, DesTelefone, NumQtdePallet) VALUES " &
                                                   "(@DtaRegistro, @DtaAtualizacao, @DesOrigemDestino, @DesMotorista, @DesTransportadora, " &
                                                   "@DesPlaca1, @DesPlaca2, @DesPlaca3, @DesTipo, @FlgLiberado, @DesNotaFiscal, @DesPedidoCompra, @NumCpfMotorista, " &
                                                   "@DtaNotaFiscal, @DesTelefone, @NumQtdePallet)")

        Try

            Conexao = DB.GetConexao()
            Comando.Connection = Conexao
            Comando.CommandText = Sql.ToString()

            Comando.Parameters.AddWithValue("@DtaRegistro", Item.DtaRegistro)
            Comando.Parameters.AddWithValue("@DtaAtualizacao", Item.DtaAtualizacao)
            Comando.Parameters.AddWithValue("@DesOrigemDestino", Item.DesOrigemDestino)
            Comando.Parameters.AddWithValue("@DesMotorista", Item.DesMotorista)
            Comando.Parameters.AddWithValue("@DesTransportadora", Item.DesTransportadora)
            Comando.Parameters.AddWithValue("@DesPlaca1", Item.DesPlaca1)
            Comando.Parameters.AddWithValue("@DesPlaca2", Item.DesPlaca2)
            Comando.Parameters.AddWithValue("@DesPlaca3", Item.DesPlaca3)
            Comando.Parameters.AddWithValue("@DesTipo", Item.DesTipo)
            Comando.Parameters.AddWithValue("@FlgLiberado", Item.FlgLiberado)
            Comando.Parameters.AddWithValue("@DesNotaFiscal", Item.DesNotaFiscal)
            Comando.Parameters.AddWithValue("@DesPedidoCompra", Item.DesPedidoCompra)
            Comando.Parameters.AddWithValue("@NumCpfMotorista", Item.NumCpfMotorista)
            Comando.Parameters.AddWithValue("@DtaNotaFiscal", Item.DtaNotaFiscal)
            Comando.Parameters.AddWithValue("@DesTelefone", Item.DesTelefone)
            Comando.Parameters.AddWithValue("@NumQtdePallet", Item.NumQtdePallet)

            Comando.ExecuteNonQuery()

        Catch ex As Exception

            Log.Fatal(ex.Message)

        Finally

            DB.CloseConexao(Conexao)

        End Try


    End Sub


    Public Sub Update(ByVal Item As Tbl_Hist_Carga)

        Dim Conexao As New SqlConnection
        Dim Comando As New SqlCommand
        Comando.CommandTimeout = 60
        Dim Sql As New StringBuilder

        Sql.Append("UPDATE dbo.TBL_HIST_CARGA SET DtaRegistro = @DtaRegistro, DtaAtualizacao = @DtaAtualizacao, DesOrigemDestino = @DesOrigemDestino, DesMotorista = @DesMotorista, " &
                   "DesTransportadora = @DesTransportadora, DesPlaca1 = @DesPlaca1, DesPlaca2 = @DesPlaca2, DesPlaca3 = @DesPlaca3, " &
                   "DesTipo = @DesTipo, FlgLiberado = @FlgLiberado, DesPedidoCompra = @DesPedidoCompra, DesNotaFiscal = @DesNotaFiscal, NumCpfMotorista = @NumCpfMotorista, " &
                   "DtaNotaFiscal = @DtaNotaFiscal, DesTelefone = @DesTelefone, NumQtdePallet = @NumQtdePallet WHERE CodHist = @CodHist")

        Try

            Conexao = DB.GetConexao()
            Comando.Connection = Conexao
            Comando.CommandText = Sql.ToString()

            Comando.Parameters.AddWithValue("@CodHist", Item.CodHist)
            Comando.Parameters.AddWithValue("@DtaRegistro", Item.DtaRegistro)
            Comando.Parameters.AddWithValue("@DtaAtualizacao", Item.DtaAtualizacao)
            Comando.Parameters.AddWithValue("@DesOrigemDestino", Item.DesOrigemDestino)
            Comando.Parameters.AddWithValue("@DesMotorista", Item.DesMotorista)
            Comando.Parameters.AddWithValue("@DesTransportadora", Item.DesTransportadora)
            Comando.Parameters.AddWithValue("@DesPlaca1", Item.DesPlaca1)
            Comando.Parameters.AddWithValue("@DesPlaca2", Item.DesPlaca2)
            Comando.Parameters.AddWithValue("@DesPlaca3", Item.DesPlaca3)
            Comando.Parameters.AddWithValue("@DesTipo", Item.DesTipo)
            Comando.Parameters.AddWithValue("@FlgLiberado", Item.FlgLiberado)
            Comando.Parameters.AddWithValue("@DesPedidoCompra", Item.DesPedidoCompra)
            Comando.Parameters.AddWithValue("@DesNotaFiscal", Item.DesNotaFiscal)
            Comando.Parameters.AddWithValue("@NumCpfMotorista", Item.NumCpfMotorista)
            Comando.Parameters.AddWithValue("@DtaNotaFiscal", Item.DtaNotaFiscal)
            Comando.Parameters.AddWithValue("@DesTelefone", Item.DesTelefone)
            Comando.Parameters.AddWithValue("@NumQtdePallet", Item.NumQtdePallet)

            Comando.ExecuteNonQuery()

        Catch ex As Exception

            Log.Fatal(ex.Message)

        Finally

            DB.CloseConexao(Conexao)

        End Try


    End Sub

    Public Function List(ByVal Sql As String) As List(Of Tbl_Hist_Carga)

        Dim Lista As New List(Of Tbl_Hist_Carga)
        Dim Item As New Tbl_Hist_Carga
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

                    Item = New Tbl_Hist_Carga


                    Item.CodHist = Reader("CodHist")
                    Item.DtaRegistro = Reader("DtaRegistro")
                    Item.DtaAtualizacao = Reader("DtaAtualizacao")
                    Item.DesOrigemDestino = Reader("DesOrigemDestino").ToString
                    Item.DesMotorista = Reader("DesMotorista").ToString
                    Item.DesTransportadora = Reader("DesTransportadora").ToString
                    Item.DesPlaca1 = Reader("DesPlaca1").ToString
                    Item.DesPlaca2 = Reader("DesPlaca2").ToString
                    Item.DesPlaca3 = Reader("DesPlaca3").ToString
                    Item.DesTipo = Reader("DesTipo").ToString
                    Item.FlgLiberado = Reader("FlgLiberado")
                    Item.DesPedidoCompra = Reader("DesPedidoCompra").ToString
                    Item.DesNotaFiscal = Reader("DesNotaFiscal").ToString
                    Item.NumCpfMotorista = Reader("NumCpfMotorista").ToString
                    Item.DtaNotaFiscal = Reader("DtaNotaFiscal").ToString
                    Item.DesTelefone = Reader("DesTelefone").ToString
                    Item.NumQtdePallet = CInt(Reader("NumQtdePallet").ToString.PadLeft(4, "0"))

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
