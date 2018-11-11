Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Configuration
Imports System.Web.SessionState

Public Class Tbl_Oleo_Diesel_BIZ

    Private DAO As New Tbl_Oleo_Diesel_DAO
    Private ReadOnly Log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Friend Function GetEstoqueAtual() As Integer

        Try
            Return DAO.List("SELECT TOP 1 * FROM dbo.TBL_OLEO_DIESEL ORDER BY CodRegistro DESC").FirstOrDefault().NumSaldo()

        Catch ex As Exception

            Log.Fatal(ex.Message)
            Return 0

        End Try


    End Function

    Friend Function GetLancamentosMedia(ByVal Veiculo As String)

        Return DAO.List("SELECT TOP 2 * FROM dbo.TBL_OLEO_DIESEL WHERE DESPLACA_VEICULO = '" & Veiculo & "' AND DESKM > 0 ORDER BY CodRegistro DESC").ToList()

    End Function

    Friend Function GetLast5Lancamentos() As List(Of Tbl_Oleo_Diesel)

        Return DAO.List("SELECT TOP 5 * FROM dbo.TBL_OLEO_DIESEL ORDER BY CodRegistro DESC").ToList()

    End Function

    Friend Sub InsertRegistro(ByVal Obj As Tbl_Oleo_Diesel)

        Try

            DAO.Insert(Obj)

        Catch ex As Exception

            Log.Fatal(ex.Message)

        End Try

    End Sub

End Class
