Public Class About
    Private Sub About_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LblProductName.Text = My.Application.Info.ProductName
        LblVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)

        LblCompanyName.Text = My.Application.Info.CompanyName
        LblDescription.Text = My.Application.Info.Description
    End Sub

    Private Sub About_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dim F1 As New Form1
        Hide()
        F1.ShowDialog()
        F1.Dispose()
        Show()
    End Sub
End Class