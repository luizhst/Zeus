Imports System.Net
Imports System.Net.Mail

Public Class Email


    Private ReadOnly Log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    ' </summary>
    ' <param name="from">Endereco do Remetente</param>
    ' <param name="recepient">Destinatario</param>
    ' <param name="bcc">recipiente Bcc</param>
    ' <param name="cc">recipiente Cc</param>
    ' <param name="subject">Assunto do email</param>
    '<param name="body">Corpo da mensagem de email</param>
    Public Sub EnviaMensagemEmail(ByVal from As String, ByVal recepient As String, ByVal subject As String, ByVal body As String, ByVal servidorSMTP As String)


        ' cria uma instância do objeto MailMessage
        Dim mMailMessage As New MailMessage()
        Dim Util As New Util

        ' Define o endereço do remetente
        mMailMessage.From = New MailAddress(from)

        ' Define o destinario da mensagem
        mMailMessage.To.Add(New MailAddress(recepient))

        ' Define o assunto
        mMailMessage.Subject = subject
        ' Define o corpo da mensagem
        mMailMessage.Body = body

        ' Define o formato do email como HTML
        mMailMessage.IsBodyHtml = True

        ' Define a prioridade da mensagem como normal
        mMailMessage.Priority = MailPriority.Normal

        ' Cria uma instância de SmtpClient - Nota - Define qual o host a ser usado para envio
        ' de mensagens, no local de smtp.server.com use o nome do SEU servidor

        Try
            Dim mSmtpClient As New SmtpClient With {
                .Credentials = New NetworkCredential(Util.GetEmailEnvio, Util.GetSenhaEnvio),
                .Port = 587,
                .Host = Util.GetSMTPEnvio,
                .EnableSsl = True
            }

            ' Envia o email
            mSmtpClient.Send(mMailMessage)
        Catch ex As Exception

            Log.Error(ex.Message)

        End Try

    End Sub



End Class
