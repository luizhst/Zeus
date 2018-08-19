Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Configuration
Imports System.Web.SessionState
Imports Project_Zeus

Public Class Tbl_Veiculo_BIZ

    Private DAO As New Tbl_Veiculo_DAO
    Private ReadOnly Log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Friend Function GetVeiculos() As List(Of Tbl_Veiculo)

        Return DAO.List("SELECT * FROM dbo.TBL_VEICULO ORDER BY Descricao").ToList()

    End Function

    Friend Function GetVeiculoById(cod As Integer) As Tbl_Veiculo

        Return DAO.List("SELECT * FROM dbo.TBL_VEICULO WHERE CodVeiculo = " & cod & " ORDER BY Descricao").FirstOrDefault()

    End Function

    Friend Sub InsertVeiculo(ByVal Obj As Tbl_Veiculo)

        Try

            If Obj.CodVeiculo <> 0 Then
                DAO.Update(Obj)
            Else
                DAO.Insert(Obj)
            End If

        Catch ex As Exception

            Log.Fatal(ex.Message)

        End Try

    End Sub


End Class
