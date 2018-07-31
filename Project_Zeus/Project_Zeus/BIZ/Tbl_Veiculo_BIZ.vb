Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Configuration
Imports System.Web.SessionState

Public Class Tbl_Veiculo_BIZ

    Private DAO As New Tbl_Veiculo_DAO
    Private ReadOnly Log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Friend Function GetVeiculos() As List(Of Tbl_Veiculo)

        Return DAO.List("SELECT * FROM dbo.TBL_VEICULO ORDER BY Descricao").ToList()

    End Function

End Class
