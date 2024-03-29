﻿Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Configuration
Imports System.Web.SessionState

Public Class Tbl_Hist_CargaBIZ

    Private DAO As New Tbl_Hist_CargaDAO
    Private ReadOnly Log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Friend Function ListarCarregamentos() As List(Of Tbl_Hist_Carga)

        Return DAO.List("SELECT * FROM dbo.TBL_HIST_CARGA ORDER BY DtaRegistro").ToList()

    End Function

    Friend Function ListarCarregamentosPendentes() As List(Of Tbl_Hist_Carga)

        Return DAO.List("SELECT * FROM dbo.TBL_HIST_CARGA WHERE FlgLiberado = 'False' ORDER BY DtaRegistro").ToList()

    End Function


    Friend Function ListarCarregamentosByDate(Inicio As String, Fim As String) As List(Of Tbl_Hist_Carga)

        Return DAO.List("SELECT * FROM dbo.TBL_HIST_CARGA WHERE DtaRegistro BETWEEN '" & Inicio & "' AND '" & Fim & "'").ToList()

    End Function

    Friend Function GetCarregamentoById(ByVal Cod As Integer) As Tbl_Hist_Carga

        Return DAO.List("SELECT * FROM dbo.TBL_HIST_CARGA WHERE CodHist = " & Cod).FirstOrDefault()

    End Function

    Friend Function GetUltCarregamentoByCpf(ByVal Cpf As String) As Tbl_Hist_Carga

        Return DAO.List("SELECT * FROM dbo.TBL_HIST_CARGA WHERE NumCpfMotorista = '" & Cpf & "' ORDER BY CodHist DESC").FirstOrDefault()

    End Function

    Friend Sub InsertCarregamento(ByVal Obj As Tbl_Hist_Carga)

        Try
            If Obj.CodHist <> 0 Then
                DAO.Update(Obj)
            Else
                DAO.Insert(Obj)
            End If

        Catch ex As Exception

            Log.Fatal(ex.Message)

        End Try

    End Sub

End Class
