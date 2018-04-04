Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Configuration
Imports System.Web.SessionState
Imports Project_Zeus

Public Class Tbl_Entrada_UsadosBIZ


    Private DAO As New Tbl_Entrada_UsadoDAO
    Private ReadOnly Log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Friend Sub InsertEntradaUsados(ByVal Obj As Tbl_Entrada_Usado)

        Try
            If Obj.CodCtrl <> 0 Then
                DAO.Update(Obj)
            Else
                DAO.Insert(Obj)
            End If

        Catch ex As Exception

            Log.Fatal(ex.Message)

        End Try

    End Sub

    Friend Function ListarPendentesLancamento() As List(Of Tbl_Entrada_Usado)

        Return DAO.List("SELECT * FROM dbo.TBL_ENTRADA_USADOS WHERE DesCnpj IS NULL OR DesCnpj = '' ORDER BY DtaNotaFiscal").ToList()

    End Function

    Friend Function GetEntradaById(editarNota As Integer) As Tbl_Entrada_Usado

        Return DAO.List("SELECT * FROM dbo.TBL_ENTRADA_USADOS WHERE CodCtrl = " & editarNota).FirstOrDefault

    End Function

End Class
