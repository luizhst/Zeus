Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Configuration
Imports System.Web.SessionState
Imports Project_Zeus

Public Class Tbl_Movimento_Carteira_Veiculo_BIZ

    Private DAO As New Tbl_Movimento_Carteira_Veiculo_DAO
    Private ReadOnly Log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Friend Function GetLancamentos(Veiculo As Integer) As List(Of Tbl_Movimento_Carteira_Veiculo)

        Return DAO.List("SELECT * FROM dbo.TBL_MOVIMENTO_CARTEIRA_VEICULO WHERE CodVeiculo = " & Veiculo & " ORDER BY CodCarteira DESC").ToList()

    End Function

    Friend Function GetSaldo(Veiculo As Integer) As Double

        'Return DAO.List("SELECT TOP 1 * FROM dbo.TBL_MOVIMENTO_CARTEIRA_VEICULO WHERE CodVeiculo = " & Veiculo & " ORDER BY CodCarteira DESC").FirstOrDefault()

        Return DAO.Saldo("SELECT ISNULL(TOTAIS.totalreceber, 0) - ISNULL(TOTAIS.totalpagar, 0) AS TOTAL " &
                         "FROM   (SELECT " &
                         "               (SELECT Sum (dr.valor) " &
                         "                FROM   dbo.TBL_MOVIMENTO_CARTEIRA_VEICULO dr WITH(NOLOCK) " &
                         "				WHERE  DesTipoRegistro = 'C'  " &
                         "					   AND FlagAtivo = 1  " &
                         "					   AND CodVeiculo =  " & Veiculo & ")             AS totalreceber,  " &
                         "               (SELECT Sum (dr.valor) " &
                         "                FROM   dbo.TBL_MOVIMENTO_CARTEIRA_VEICULO dr WITH(NOLOCK) " &
                         "				WHERE  DesTipoRegistro = 'D'  " &
                         "					   AND FlagAtivo = 1  " &
                         "					   AND CodVeiculo =  " & Veiculo & ")              AS totalpagar " &
                         "      ) " &
                         "AS TOTAIS ")

    End Function

    Friend Sub InsertMovimento(ByVal Obj As Tbl_Movimento_Carteira_Veiculo)

        Try

            If Obj.CodCarteira <> 0 Then
                DAO.Update(Obj)
            Else
                DAO.Insert(Obj)
            End If

        Catch ex As Exception

            Log.Fatal(ex.Message)

        End Try

    End Sub

End Class


Public Class Tbl_Tipo_Movimento_Carteira_BIZ

    Private DAO As New Tbl_Tipo_Movimento_Carteira_DAO
    Private ReadOnly Log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Friend Function GetTipos() As List(Of Tbl_Tipo_Movimento_Carteira)

        Return DAO.List("SELECT * FROM dbo.TBL_TIPO_MOVIMENTO_CARTEIRA WHERE FlagAtivo = 1 ORDER BY Descricao").ToList()

    End Function

    Friend Sub InsertTipoMovimento(ByVal Obj As Tbl_Tipo_Movimento_Carteira)

        Try

            If Obj.CodTipoMovimentoCarteira <> 0 Then
                DAO.Update(Obj)
            Else
                DAO.Insert(Obj)
            End If

        Catch ex As Exception

            Log.Fatal(ex.Message)

        End Try

    End Sub


End Class
