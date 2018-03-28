Imports System.Data.SqlClient
Imports System.Text

Public Class Tbl_UsuarioDAO

    Private DB As New Connection
    Private ReadOnly Log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Public Sub Insert(ByVal Item As Tbl_Usuario)

        Dim Conexao As New SqlConnection
        Dim Comando As New SqlCommand
        Comando.CommandTimeout = 60
        Dim Sql As New StringBuilder


        Sql.Append("INSERT INTO dbo.TBL_USUARIO (Nome, SobreNome, ContaLogin, SenhaLogin, DtaNascimento, FlgAtivo) VALUES " &
                                               "(@Nome, @SobreNome, @ContaLogin, @SenhaLogin, @DtaNascimento, @FlgAtivo)")

        Try

            Conexao = DB.GetConexao()
            Comando.Connection = Conexao
            Comando.CommandText = Sql.ToString()

            Comando.Parameters.AddWithValue("@Nome", Item.Nome)
            Comando.Parameters.AddWithValue("@SobreNome", Item.SobreNome)
            Comando.Parameters.AddWithValue("@ContaLogin", Item.ContaLogin)
            Comando.Parameters.AddWithValue("@SenhaLogin", Item.SenhaLogin)
            Comando.Parameters.AddWithValue("@DtaNascimento", Item.DtaNascimento)
            Comando.Parameters.AddWithValue("@FlgAtivo", Item.FlgAtivo)

            Comando.ExecuteNonQuery()

        Catch ex As Exception

            Log.Fatal(ex.Message)

        Finally

            DB.CloseConexao(Conexao)

        End Try


    End Sub


    Public Sub Update(ByVal Item As Tbl_Usuario)

        Dim Conexao As New SqlConnection
        Dim Comando As New SqlCommand
        Comando.CommandTimeout = 60
        Dim Sql As New StringBuilder

        Sql.Append("UPDATE dbo.TBL_USUARIO SET Nome = @Nome, SobreNome = @SobreNome, ContaLogin = @ContaLogin, " &
                   "SenhaLogin = @SenhaLogin, DtaNascimento = @DtaNascimento, FlgAtivo = @FlgAtivo " &
                   "WHERE CodUsuario = @CodUsuario")

        Try

            Conexao = DB.GetConexao()
            Comando.Connection = Conexao
            Comando.CommandText = Sql.ToString()

            Comando.Parameters.AddWithValue("@CodUsuario", Item.CodUsuario)
            Comando.Parameters.AddWithValue("@Nome", Item.Nome)
            Comando.Parameters.AddWithValue("@SobreNome", Item.SobreNome)
            Comando.Parameters.AddWithValue("@ContaLogin", Item.ContaLogin)
            Comando.Parameters.AddWithValue("@SenhaLogin", Item.SenhaLogin)
            Comando.Parameters.AddWithValue("@DtaNascimento", Item.DtaNascimento)
            Comando.Parameters.AddWithValue("@FlgAtivo", Item.FlgAtivo)

            Comando.ExecuteNonQuery()

        Catch ex As Exception

            Log.Fatal(ex.Message)

        Finally

            DB.CloseConexao(Conexao)

        End Try


    End Sub

    Public Function List(ByVal Sql As String) As List(Of Tbl_Usuario)

        Dim Lista As New List(Of Tbl_Usuario)
        Dim Item As New Tbl_Usuario
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

                    Item = New Tbl_Usuario

                    Item.CodUsuario = Reader("CodUsuario")
                    Item.Nome = Reader("Nome").ToString
                    Item.SobreNome = Reader("SobreNome").ToString
                    Item.ContaLogin = Reader("ContaLogin").ToString
                    Item.SenhaLogin = Reader("SenhaLogin").ToString
                    Item.DtaNascimento = Reader("DtaNascimento")
                    Item.FlgAtivo = Reader("FlgAtivo")

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
