Public Class Settings
    Private Sub Settings_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dim f1 As New Form1
        Hide()
        f1.ShowDialog()
        f1.Dispose()
        Show()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        ' SETTING IS SAVE IF THE TEXTBOX INPUT IS GREATER THAN 0
        If TxtUsername.Text.Length > 0 Then
            My.Settings.Username = TxtUsername.Text.Trim 'NEED TO PUT Username and password Variable in the property general and settings
            My.Settings.Password = TxtPassword.Text.Trim
            My.Settings.Save() 'USE TO SAVE THE SETTIGS ABOVE
            MessageBox.Show("Settings Saved", "ACCOUNT", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim response As DialogResult = MessageBox.Show("Do you want to go to Mainform?", "ACCOUNT", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If response = DialogResult.Yes Then
                Dim f1 As New Form1
                Hide()
                f1.ShowDialog()
                f1.Dispose()
                Show()
            End If

        Else
            My.Settings.Username = ""
            My.Settings.Password = ""
            MessageBox.Show("Settings Saved", "ACCOUNT", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtUsername.Text = My.Settings.Username
        TxtPassword.Text = My.Settings.Password
    End Sub
End Class