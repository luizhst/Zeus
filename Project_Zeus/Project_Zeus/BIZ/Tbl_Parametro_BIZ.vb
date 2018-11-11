Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Configuration
Imports System.Web.SessionState
Imports Project_Zeus


Public Class Tbl_Parametro_BIZ


    Private DAO As New Tbl_Parametro_DAO
    Private ReadOnly Log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Friend Function GetParametros() As List(Of Tbl_Parametro)

        Return DAO.List("SELECT * FROM dbo.TBL_PARAMETROS ORDER BY CodParametro").ToList()

    End Function

    Friend Function GetParametroById(cod As Integer) As Tbl_Parametro

        Return DAO.List("SELECT * FROM dbo.TBL_PARAMETROS WHERE CodParametro = " & cod).FirstOrDefault()

    End Function

    Friend Sub InsertParametro(ByVal Obj As Tbl_Parametro)

        Try

            If Obj.CodParametro <> 0 Then
                DAO.Update(Obj)
            Else
                DAO.Insert(Obj)
            End If

        Catch ex As Exception

            Log.Fatal(ex.Message)

        End Try

    End Sub

End Class
