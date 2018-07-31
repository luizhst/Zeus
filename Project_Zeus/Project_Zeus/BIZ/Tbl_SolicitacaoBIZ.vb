Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Configuration
Imports System.Web.SessionState

Public Class Tbl_SolicitacaoBIZ


    Private DAO As New Tbl_SolicitacaoDAO
    Private ReadOnly Log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)


    Friend Function ListarTodasSolicitacoes() As List(Of Tbl_Solicitacao)

        Return DAO.List("SELECT * FROM dbo.TBL_SOLICITACAO ORDER BY CodSolicitacao DESC").ToList()

    End Function

    Friend Function ListarTodasSolicitacoesAbertas() As List(Of Tbl_Solicitacao)

        Return DAO.List("SELECT * FROM dbo.TBL_SOLICITACAO WHERE DesStatus = 'Em Aberto' ORDER BY CodSolicitacao DESC").ToList()

    End Function

    Friend Function ListarTodasSolicitacoesFinalizadas() As List(Of Tbl_Solicitacao)

        Return DAO.List("SELECT * FROM dbo.TBL_SOLICITACAO WHERE DesStatus = 'Finalizada' ORDER BY CodSolicitacao DESC").ToList()

    End Function

    Friend Function GetSolicitacaoById(ByVal Cod As Integer) As Tbl_Solicitacao

        Return DAO.List("SELECT * FROM dbo.TBL_SOLICITACAO WHERE CodSolicitacao = " & Cod).FirstOrDefault()

    End Function


    Friend Sub InsertSolicitacao(ByVal Obj As Tbl_Solicitacao)

        Try

            If Obj.CodSolicitacao <> 0 Then
                DAO.Update(Obj)
            Else
                DAO.Insert(Obj)
            End If

        Catch ex As Exception

            Log.Fatal(ex.Message)

        End Try

    End Sub

End Class
