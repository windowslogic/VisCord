Public Class Main
    Private Sub WebView21_CoreWebView2InitializationCompleted(sender As Object, e As Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs) Handles WebView21.CoreWebView2InitializationCompleted
        WebView21.CoreWebView2.Settings.AreDefaultScriptDialogsEnabled = False
        WebView21.CoreWebView2.Settings.AreBrowserAcceleratorKeysEnabled = False
        WebView21.CoreWebView2.Settings.AreDefaultContextMenusEnabled = False
        WebView21.CoreWebView2.Settings.AreDevToolsEnabled = False
    End Sub

    Private Sub ContentTimer_Tick(sender As Object, e As EventArgs) Handles ContentTimer.Tick

        'Attempt to update window title to match area of Discord. 
        Try
            Me.Text = WebView21.CoreWebView2.DocumentTitle + " - VisCord"

            If Me.Text.Contains("Settings") Then
                Panel1.Visible = True
            Else
                Panel1.Visible = False
            End If
        Catch

        End Try


    End Sub

    Private Sub StartupCheckbox_CheckedChanged(sender As Object, e As EventArgs) Handles StartupCheckbox.CheckedChanged
        If StartupCheckbox.Checked = True Then
            My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).SetValue(Application.ProductName, Application.ExecutablePath)
            My.Settings.Startup = 1
        Else
            My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).DeleteValue(Application.ProductName)
            My.Settings.Startup = 0
        End If
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load Startup settings.
        If My.Settings.Startup = 0 Then
            StartupCheckbox.Checked = False
        Else
            StartupCheckbox.Checked = True
        End If
    End Sub

    Private Sub SysTrayCheckbox_CheckedChanged(sender As Object, e As EventArgs) Handles SysTrayCheckbox.CheckedChanged

    End Sub

    Private Sub BadgeCheckbox_CheckedChanged(sender As Object, e As EventArgs) Handles BadgeCheckbox.CheckedChanged

    End Sub

    Private Sub NotifyCheckbox_CheckedChanged(sender As Object, e As EventArgs) Handles NotifyCheckbox.CheckedChanged

    End Sub
End Class
