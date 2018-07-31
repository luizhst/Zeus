Imports System.IO
Imports System.Data
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Configuration

Public Class Relatorio
    Inherits System.Web.UI.Page


    Private ReadOnly Log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            If IsNothing(Session("Usuario")) Then
                Response.Redirect("~/Pages/Sair.aspx")
            End If

            txt_data_inicio.Text = Format(Now, "yyyy-MM-dd")
            txt_data_fim.Text = Format(Now, "yyyy-MM-dd")

        End If

    End Sub

    Protected Sub btn_gerar_Click(sender As Object, e As EventArgs)

        If CDate(txt_data_inicio.Text) > CDate(txt_data_fim.Text) Then

            grid_carregamentos_rel.Visible = False
            lbl_Mensagem_Grid.Visible = True
            lbl_Mensagem_Grid.Text = "Data inicio não pode ser maior do que data fim da consulta!"

        Else
            lbl_Mensagem_Grid.Visible = False
            Gerar_Relatorio_Cargas_Descargas(txt_data_inicio.Text, txt_data_fim.Text)
        End If



    End Sub

    Private Sub Gerar_Relatorio_Cargas_Descargas(DtaInicio As String, DtaFim As String)

        Dim Lista As New List(Of Tbl_Hist_Carga)
        Dim Biz As New Tbl_Hist_CargaBIZ

        Try
            Lista = Biz.ListarCarregamentosByDate(Format(CDate(DtaInicio), "dd/MM/yyyy 00:00:01"), Format(CDate(DtaFim), "dd/MM/yyyy 23:59:59"))

            If Lista.Count > 0 Then

                lbl_Mensagem_Grid.Visible = False
                grid_carregamentos_rel.Visible = True
                grid_carregamentos_rel.DataSource = Nothing
                grid_carregamentos_rel.DataSource = Lista
                'btn_exportar.Visible = True

                grid_carregamentos_rel.DataBind()

            Else

                btn_exportar.Visible = False
                grid_carregamentos_rel.Visible = False
                lbl_Mensagem_Grid.Visible = True
                lbl_Mensagem_Grid.Text = "Não existem registros para esse período!"

            End If

        Catch ex As Exception

            Log.Debug(ex.Message)

        End Try


    End Sub

    Protected Sub btn_exportar_Click(sender As Object, e As EventArgs)

        ExportarExcel()

    End Sub

    Public Sub ExportarExcel()

        Try


            Response.Clear()
            Response.Buffer = True
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls")
            Response.Charset = ""
            Response.ContentType = "application/vnd.ms-excel"
            Dim sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)

            'To Export all pages

            grid_carregamentos_rel.HeaderRow.BackColor = Color.White
            For Each cell As TableCell In grid_carregamentos_rel.HeaderRow.Cells
                cell.BackColor = grid_carregamentos_rel.HeaderStyle.BackColor
            Next
            For Each row As GridViewRow In grid_carregamentos_rel.Rows
                row.BackColor = Color.White
                For Each cell As TableCell In row.Cells
                    If row.RowIndex Mod 2 = 0 Then
                        cell.BackColor = grid_carregamentos_rel.AlternatingRowStyle.BackColor
                    Else
                        cell.BackColor = grid_carregamentos_rel.RowStyle.BackColor
                    End If
                    cell.CssClass = "textmode"
                Next
            Next

            grid_carregamentos_rel.RenderControl(hw)
            'style to format numbers to string
            Dim style As String = "<style> .textmode { } </style>"
            Response.Write(style)
            Response.Output.Write(sw.ToString())
            Response.Flush()
            Response.[End]()



        Catch ex As Exception

            Log.Fatal(ex.Message)

        End Try

    End Sub
End Class