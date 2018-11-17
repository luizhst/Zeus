Imports System.Data.SqlClient
Imports System.Text

Public Class Tbl_Oleo_Diesel_DAO

    Private ReadOnly Log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
    Private DB As New Connection

    Public Sub Insert(ByVal Item As Tbl_Oleo_Diesel)

        Dim Conexao As New SqlConnection
        Dim Comando As New SqlCommand
        Comando.CommandTimeout = 60
        Dim Sql As New StringBuilder
        Dim ItemOld As New Tbl_Oleo_Diesel

        ItemOld = List("SELECT TOP 1 * FROM dbo.TBL_OLEO_DIESEL ORDER BY CodRegistro DESC").FirstOrDefault

        'Faz o cálculo do saldo de estoque
        If IsNothing(ItemOld) Then

            If Item.FlgEntrada = True Then
                Item.NumSaldo = Item.NumQtdeOleo
            Else
                Item.NumSaldo = -Item.NumQtdeOleo
            End If

        Else
            If Item.DesEstoque.Equals("Bomba") Then
                If Item.FlgEntrada = True Then
                    Log.Debug("Adicionando " & Item.NumQtdeOleo & " ao estoque de " & ItemOld.NumSaldo)
                    Item.NumSaldo = ItemOld.NumSaldo + Item.NumQtdeOleo
                Else
                    Log.Debug("Subtraindo " & Item.NumQtdeOleo & " do estoque de " & ItemOld.NumSaldo)
                    Item.NumSaldo = ItemOld.NumSaldo - Item.NumQtdeOleo
                End If
            Else

                Log.Debug("Lançamento de abastecimento em posto de gasolina, placa: " & Item.DesPlaca_Veiculo)
                Item.NumSaldo = ItemOld.NumSaldo

            End If

        End If


        Sql.Append("INSERT INTO dbo.TBL_OLEO_DIESEL (DtaRegistro, DesUser, DesPlaca_Veiculo, DesNomeVeiculo, NumQtdeOleo, " &
                                                   "NumSaldo, FlgEntrada, DesKm, DesEstoque) VALUES " &
                                                   "(@DtaRegistro, @DesUser, @DesPlaca_Veiculo, @DesNomeVeiculo, @NumQtdeOleo, " &
                                                   "@NumSaldo, @FlgEntrada, @DesKm, @DesEstoque)")
        Try

            Conexao = DB.GetConexao()
            Comando.Connection = Conexao
            Comando.CommandText = Sql.ToString()

            Comando.Parameters.AddWithValue("@DtaRegistro", Item.DtaRegistro)
            Comando.Parameters.AddWithValue("@DesUser", Item.DesUser)
            Comando.Parameters.AddWithValue("@DesPlaca_Veiculo", Item.DesPlaca_Veiculo)
            Comando.Parameters.AddWithValue("@DesNomeVeiculo", Item.DesNomeVeiculo)
            Comando.Parameters.AddWithValue("@NumQtdeOleo", Item.NumQtdeOleo)
            Comando.Parameters.AddWithValue("@NumSaldo", Item.NumSaldo)
            Comando.Parameters.AddWithValue("@FlgEntrada", Item.FlgEntrada)
            Comando.Parameters.AddWithValue("@DesKm", Item.DesKm)
            Comando.Parameters.AddWithValue("@DesEstoque", Item.DesEstoque)

            Comando.ExecuteNonQuery()

        Catch ex As Exception

            Log.Fatal(ex.Message)

        Finally

            DB.CloseConexao(Conexao)

        End Try


    End Sub


    Public Function List(ByVal Sql As String) As List(Of Tbl_Oleo_Diesel)

        Dim Lista As New List(Of Tbl_Oleo_Diesel)
        Dim Item As New Tbl_Oleo_Diesel
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

                    Item = New Tbl_Oleo_Diesel


                    Item.CodRegistro = Reader("CodRegistro")
                    Item.DtaRegistro = Reader("DtaRegistro")
                    Item.DesUser = Reader("DesUser")
                    Item.DesPlaca_Veiculo = Reader("DesPlaca_Veiculo").ToString
                    Item.DesNomeVeiculo = Reader("DesNomeVeiculo").ToString
                    Item.NumQtdeOleo = Reader("NumQtdeOleo").ToString
                    Item.NumSaldo = Reader("NumSaldo").ToString
                    Item.FlgEntrada = Reader("FlgEntrada").ToString
                    Item.DesKm = Reader("DesKm").ToString
                    Item.DesEstoque = Reader("DesEstoque").ToString

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
