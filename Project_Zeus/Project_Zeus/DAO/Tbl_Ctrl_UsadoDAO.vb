Imports System.Data.SqlClient
Imports System.Text

Public Class Tbl_Ctrl_UsadoDAO

    Private DB As New Connection
    Private ReadOnly Log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Public Sub Insert(ByVal Item As Tbl_Ctrl_Usado)

        Dim Conexao As New SqlConnection
        Dim Comando As New SqlCommand
        Comando.CommandTimeout = 60
        Dim Sql As New StringBuilder


        Sql.Append("INSERT INTO dbo.TBL_CTRL_USADOS (CodHist, DtaRegistro, DtaNotaFiscal, DesNotaFiscal, DesCnpj, DesOrigemDestino, " &
                                                    "DesProduto, QtdeTotal, QtdeFpq, DesPercentualSucata, QtdeSucata, QtdeTotalLiquido, " &
                                                    "QtdeDisponivel, FlgFaturadoSucata, FlgFaturadoFPQ, DesTipoRegistro, DesUsuarioRegistro) " &
                                                    "VALUES " &
                                                    "(@CodHist, @DtaRegistro, @DtaNotaFiscal, @DesNotaFiscal, @DesCnpj, @DesOrigemDestino, " &
                                                    "@DesProduto, @QtdeTotal, @QtdeFpq, @DesPercentualSucata, @QtdeSucata, @QtdeTotalLiquido, " &
                                                    "@QtdeDisponivel, @FlgFaturadoSucata, @FlgFaturadoFPQ, @DesTipoRegistro, @DesUsuarioRegistro)")

        Try

            Conexao = DB.GetConexao()
            Comando.Connection = Conexao
            Comando.CommandText = Sql.ToString()

            Comando.Parameters.AddWithValue("@CodHist", Item.HistCarga.CodHist)
            Comando.Parameters.AddWithValue("@DtaRegistro", Item.DtaRegistro)
            Comando.Parameters.AddWithValue("@DtaNotaFiscal", Item.DtaNotaFiscal)
            Comando.Parameters.AddWithValue("@DesNotaFiscal", Item.DesNotaFiscal)
            Comando.Parameters.AddWithValue("@DesCnpj", Item.DesCnpj)
            Comando.Parameters.AddWithValue("@DesOrigemDestino", Item.DesOrigemDestino)

            Comando.Parameters.AddWithValue("@DesProduto", Item.DesProduto)
            Comando.Parameters.AddWithValue("@QtdeTotal", Item.QtdeTotal)
            Comando.Parameters.AddWithValue("@QtdeFpq", Item.QtdeFpq)
            Comando.Parameters.AddWithValue("@DesPercentualSucata", Item.DesPercentualSucata)
            Comando.Parameters.AddWithValue("@QtdeSucata", Item.QtdeSucata)
            Comando.Parameters.AddWithValue("@QtdeTotalLiquido", Item.QtdeTotalLiquido)

            Comando.Parameters.AddWithValue("@QtdeDisponivel", Item.QtdeDisponivel)
            Comando.Parameters.AddWithValue("@FlgFaturadoSucata", Item.FlgFaturadoSucata)
            Comando.Parameters.AddWithValue("@FlgFaturadoFPQ", Item.FlgFaturadoFPQ)
            Comando.Parameters.AddWithValue("@DesTipoRegistro", Item.DesTipoRegistro)
            Comando.Parameters.AddWithValue("@DesUsuarioRegistro", Item.DesUsuarioRegistro)

            Comando.ExecuteNonQuery()

        Catch ex As Exception

            Log.Fatal(ex.Message)

        Finally

            DB.CloseConexao(Conexao)

        End Try


    End Sub


    Public Sub Update(ByVal Item As Tbl_Ctrl_Usado)

        Dim Conexao As New SqlConnection
        Dim Comando As New SqlCommand
        Comando.CommandTimeout = 60
        Dim Sql As New StringBuilder

        Sql.Append("UPDATE dbo.TBL_CTRL_USADOS SET CodHist = @CodHist, DtaRegistro = @DtaRegistro, DtaNotaFiscal = @DtaNotaFiscal, DesNotaFiscal = @DesNotaFiscal, " &
                                                  "DesCnpj = @DesCnpj, DesOrigemDestino = @DesOrigemDestino, DesProduto = @DesProduto, QtdeTotal = @QtdeTotal, " &
                                                  "QtdeFpq = @QtdeFpq, DesPercentualSucata = @DesPercentualSucata, QtdeSucata = @QtdeSucata, QtdeTotalLiquido = @QtdeTotalLiquido, " &
                                                  "QtdeDisponivel = @QtdeDisponivel, FlgFaturadoSucata = @FlgFaturadoSucata, FlgFaturadoFPQ = @FlgFaturadoFPQ, " &
                                                  "DesTipoRegistro = @DesTipoRegistro, DesUsuarioRegistro = @DesUsuarioRegistro " &
                                                  "WHERE CodCtrl = @CodCtrl")

        Try

            Conexao = DB.GetConexao()
            Comando.Connection = Conexao
            Comando.CommandText = Sql.ToString()

            Comando.Parameters.AddWithValue("@CodHist", Item.HistCarga.CodHist)
            Comando.Parameters.AddWithValue("@DtaRegistro", Item.DtaRegistro)
            Comando.Parameters.AddWithValue("@DtaNotaFiscal", Item.DtaNotaFiscal)
            Comando.Parameters.AddWithValue("@DesNotaFiscal", Item.DesNotaFiscal)
            Comando.Parameters.AddWithValue("@DesCnpj", Item.DesCnpj)
            Comando.Parameters.AddWithValue("@DesOrigemDestino", Item.DesOrigemDestino)

            Comando.Parameters.AddWithValue("@DesProduto", Item.DesProduto)
            Comando.Parameters.AddWithValue("@QtdeTotal", Item.QtdeTotal)
            Comando.Parameters.AddWithValue("@QtdeFpq", Item.QtdeFpq)
            Comando.Parameters.AddWithValue("@DesPercentualSucata", Item.DesPercentualSucata)
            Comando.Parameters.AddWithValue("@QtdeSucata", Item.QtdeSucata)
            Comando.Parameters.AddWithValue("@QtdeTotalLiquido", Item.QtdeTotalLiquido)

            Comando.Parameters.AddWithValue("@QtdeDisponivel", Item.QtdeDisponivel)
            Comando.Parameters.AddWithValue("@FlgFaturadoSucata", Item.FlgFaturadoSucata)
            Comando.Parameters.AddWithValue("@FlgFaturadoFPQ", Item.FlgFaturadoFPQ)
            Comando.Parameters.AddWithValue("@DesTipoRegistro", Item.DesTipoRegistro)
            Comando.Parameters.AddWithValue("@DesUsuarioRegistro", Item.DesUsuarioRegistro)
            Comando.Parameters.AddWithValue("@CodCtrl", Item.CodCtrl)

            Comando.ExecuteNonQuery()

        Catch ex As Exception

            Log.Fatal(ex.Message)

        Finally

            DB.CloseConexao(Conexao)

        End Try


    End Sub

    Public Function List(ByVal Sql As String) As List(Of Tbl_Ctrl_Usado)

        Dim Lista As New List(Of Tbl_Ctrl_Usado)
        Dim Item As New Tbl_Ctrl_Usado
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

                    Item = New Tbl_Ctrl_Usado
                    Item.HistCarga = New Tbl_Hist_Carga

                    Item.CodCtrl = Reader("CodCtrl")
                    Item.HistCarga.CodHist = Reader("CodHist")
                    Item.DtaRegistro = Reader("DtaRegistro")
                    Item.DtaNotaFiscal = Reader("DtaNotaFiscal").ToString
                    Item.DesNotaFiscal = Reader("DesNotaFiscal").ToString
                    Item.DesCnpj = Reader("DesCnpj").ToString
                    Item.DesOrigemDestino = Reader("DesOrigemDestino").ToString
                    Item.DesProduto = Reader("DesProduto").ToString
                    Item.QtdeTotal = Reader("QtdeTotal")
                    Item.QtdeFpq = Reader("QtdeFpq")
                    Item.DesPercentualSucata = Reader("DesPercentualSucata").ToString
                    Item.QtdeSucata = Reader("QtdeSucata")
                    Item.QtdeTotalLiquido = Reader("QtdeTotalLiquido")
                    Item.QtdeDisponivel = Reader("QtdeDisponivel")
                    Item.FlgFaturadoSucata = Reader("FlgFaturadoSucata")
                    Item.FlgFaturadoFPQ = Reader("FlgFaturadoFPQ")
                    Item.DesTipoRegistro = Reader("DesTipoRegistro").ToString
                    Item.DesUsuarioRegistro = Reader("DesUsuarioRegistro").ToString

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
