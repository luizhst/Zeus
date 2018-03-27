Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Configuration
Imports System.Web.SessionState

Public Class Tbl_Hist_CargaBIZ

    Private DAO As New Tbl_Hist_CargaDAO

    Friend Function ListarCarregamentos() As List(Of Tbl_Hist_Carga)

        Return DAO.List("SELECT * FROM dbo.TBL_HIST_CARGA ORDER BY DtaRegistro DESC").ToList()

    End Function

    Friend Function ListarCarregamentosPendentes() As List(Of Tbl_Hist_Carga)

        Return DAO.List("SELECT * FROM dbo.TBL_HIST_CARGA WHERE FlgLiberado = 'False' ORDER BY DtaRegistro DESC").ToList()

    End Function

    Friend Function GetCarregamentoById(ByVal Cod As Integer) As Tbl_Hist_Carga

        Return DAO.List("SELECT * FROM dbo.TBL_HIST_CARGA WHERE CodHist = " & Cod).FirstOrDefault()

    End Function

    Friend Sub InsertCarregamento(ByVal Obj As Tbl_Hist_Carga)

        Try
            If Obj.CodHist <> 0 Then
                DAO.Update(Obj)
            Else
                DAO.Insert(Obj)
            End If

        Catch ex As Exception

            Throw ex

        End Try

    End Sub

End Class
