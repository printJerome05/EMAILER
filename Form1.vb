Imports System.Net.Mail

Public Class Form1

    Dim username As String
    Dim password As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtFrom.Text = My.Settings.Username
        username = My.Settings.Username 'USERNAME FROM THE 
        password = My.Settings.Password

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnSendMessage.Click

        ' SIMPLE VALIDATION 
        If TxtFrom.Text.Trim.Length = 0 Then
            MessageBox.Show("From is Empty", "SUBMIT", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf TxtTo.Text.Trim.Length = 0 Then
            MessageBox.Show("To is Empty", "SUBMIT", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf TxtSubject.Text.Trim.Length = 0 Then
            MessageBox.Show("Subject is Empty", "SUBMIT", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf RtxtMessageBody.Text.Trim.Length = 0 Then
            MessageBox.Show("Message is Empty", "SUBMIT", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Try
                Dim smtp As New SmtpClient
                Dim email As New MailMessage
                smtp.UseDefaultCredentials = False
                smtp.Credentials = New Net.NetworkCredential(username, password)
                smtp.Port = 587
                smtp.EnableSsl = True
                smtp.Host = "smtp.gmail.com"
                email = New MailMessage
                email.From = New MailAddress(TxtFrom.Text)
                email.To.Add(TxtTo.Text)
                email.Subject = TxtSubject.Text
                email.IsBodyHtml = False
                email.Body = RtxtMessageBody.Text
                MessageBox.Show("Message Sent", "SUBMIT", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

    End Sub


    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Environment.Exit(1) 'BETTER THAN APPLICATION EXIT
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Dim about As New About
        Hide()
        about.ShowDialog()
        about.Dispose()
        Show()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim sttngs As New Settings
        Hide()
        sttngs.ShowDialog()
        sttngs.Dispose()
        Show()
    End Sub
End Class
