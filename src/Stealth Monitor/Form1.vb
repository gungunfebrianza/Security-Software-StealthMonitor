Imports System.IO
Public Class Form1

    Private Declare Function GetForegroundWindow Lib "user32.dll" () As IntPtr
    Private Declare Function GetWindowThreadProcessId Lib "user32.dll" (ByVal hwnd As IntPtr, ByRef lpdwProcessID As Integer) As Integer
    Private Declare Function GetWindowText Lib "user32.dll" Alias "GetWindowTextA" (ByVal hWnd As IntPtr, ByVal WinTitle As String, ByVal MaxLength As Integer) As Integer
    Private Declare Function GetWindowTextLength Lib "user32.dll" Alias "GetWindowTextLengthA" (ByVal hwnd As IntPtr) As Integer

    Public Function killprocess(ByVal processname As String)

        'Get list of all running processes
        Dim proc() As Process = Process.GetProcesses

        'Loop through all processes
        For i As Integer = 0 To proc.GetUpperBound(0)
            If proc(i).ProcessName = processname Then
                proc(i).Kill()
            End If
        Next

    End Function

    Public Sub killer()
        killprocess("firefox")
        killprocess("chrome")
        killprocess("iexplore")
        killprocess("opera")
        killprocess("safari")
        killprocess("flock")
    End Sub

    Private Sub RepoveDuplicate()
        For Row As Int16 = 0 To ListBox1.Items.Count - 2
            For RowAgain As Int16 = ListBox1.Items.Count - 1 To Row + 1 Step -1
                If ListBox1.Items(Row).ToString = ListBox1.Items(RowAgain).ToString Then
                    ListBox1.Items.RemoveAt(RowAgain)
                End If
            Next
        Next
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            '—– Get the Handle to the Current Forground Window —–
            Dim hWnd As IntPtr = GetForegroundWindow()
            If hWnd = IntPtr.Zero Then Exit Sub

            '—– Find the Length of the Window’s Title —–
            Dim TitleLength As Integer
            TitleLength = GetWindowTextLength(hWnd)

            '—– Find the Window’s Title —–
            Dim WindowTitle As String = StrDup(TitleLength + 1, "*")
            GetWindowText(hWnd, WindowTitle, TitleLength + 1)

            '—– Find the PID of the Application that Owns the Window —–
            Dim pid As Integer = 0
            GetWindowThreadProcessId(hWnd, pid)
            If pid = 0 Then Exit Sub

            '—– Get the actual PROCESS from the process ID —–
            Dim proc As Process = Process.GetProcessById(pid)
            If proc Is Nothing Then Exit Sub


            TextBox3.Text = proc.MainWindowTitle
            RepoveDuplicate()


        Catch

        End Try

    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged

        ListBox1.Items.Add(TextBox3.Text)
        If TextBox3.Text.Contains("abcd") Then
            MessageBox.Show("Please do not open sexual site content!", "Stealth Monitor", MessageBoxButtons.OK, MessageBoxIcon.Information)
            killer()

        ElseIf TextBox3.Text.Contains("Facebook") Then
            MsgBox("Detected Open Facebook!", 262144, Title:="Stealth Monitor")

        ElseIf TextBox3.Text.Contains("GitHub") Then
            MsgBox("Detected Open Github!", 262144, Title:="Stealth Monitor")

        ElseIf TextBox3.Text.Contains("Bitcoin") Then
            MsgBox("Detected Open Bitcoin Core! Execute Virus Now", 262144, Title:="Stealth Monitor")

        End If
    End Sub

    Private Sub OriginButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OriginButton1.Click

        Timer1.Start()
        'mengubah warna tulisan logs history
        ListBox1.ForeColor = System.Drawing.Color.Red
        ListBox1.Items.Add("Monitoring Start...")
        ListBox1.Items.Add("")

    End Sub

    Private Sub OriginButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OriginButton2.Click

        Timer1.Stop()
        'mengubah warna tulisan logs history
        ListBox1.ForeColor = System.Drawing.Color.Red
        ListBox1.Items.Add("Monitoring Stopped..")
        ListBox1.Items.Add("")

    End Sub

    Private Sub GraphiteButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GraphiteButton1.Click

        ' menyembunyikan form 
        Me.Visible = False

        'Menampilkan judul untuk Notif ikon
        NotifyIcon1.BalloonTipTitle = "Indonesia Stealth Monitor"

        'Menampilkan Ballontiptext untuk Notif ikon
        NotifyIcon1.BalloonTipText = "Monitoring here.."

        'Notif ikon ditampilkan selama 2 detik
        NotifyIcon1.ShowBalloonTip(2)

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            'memuat logs history, logs disimpan didrive c
            Dim items() As String = File.ReadAllLines("C:\\AI.kaizer")
            ListBox1.Items.Clear()

            ' if necessary
            ListBox1.Items.AddRange(items)
            ListBox1.SelectedIndex = 0

        Catch ex As System.Exception

        End Try

    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        Try

            'menyimpan logs history. lokasinya di drive c:\
            Dim sw As System.IO.StreamWriter = New System.IO.StreamWriter("C:\\AI.kaizer")
            For Each item As Object In ListBox1.Items
                sw.WriteLine(item.ToString)
            Next
            sw.Close()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub GraphiteButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GraphiteButton2.Click

        'membersihkan listbox
        ListBox1.Items.Clear()

    End Sub

    Private Sub SecondOriginButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SecondOriginButton1.Click

        'button save result
        Using WWW As New SaveFileDialog

            WWW.Filter = "(*.txt) |*.txt|(*.*) |*.*"
            If WWW.ShowDialog = Windows.Forms.DialogResult.OK Then
                Using saef As New System.IO.StreamWriter(WWW.FileName)
                    For Each item As String In ListBox1.Items
                        saef.Write(item)
                    Next
                    saef.Close()
                End Using
            End If

        End Using

    End Sub

    Private Sub ShowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowToolStripMenuItem.Click

        'menampilkan form
        Me.Visible = True

    End Sub

    Private Sub HideToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideToolStripMenuItem.Click

        'menyembunyikan form
        Me.Visible = False

    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick

        'menampilkan form
        Me.Visible = True

    End Sub

    Private Sub SaveResultToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveResultToolStripMenuItem.Click

        'button save result
        Using WWW As New SaveFileDialog

            WWW.Filter = "(*.txt) |*.txt|(*.*) |*.*"
            If WWW.ShowDialog = Windows.Forms.DialogResult.OK Then
                Using saef As New System.IO.StreamWriter(WWW.FileName)
                    For Each item As String In ListBox1.Items
                        saef.Write(item)
                    Next
                    saef.Close()
                End Using
            End If

        End Using

    End Sub

    Private Sub HideInTrayIconToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideInTrayIconToolStripMenuItem.Click

        ' menyembunyikan form 
        Me.Visible = False

        'Menampilkan judul untuk Notif ikon
        NotifyIcon1.BalloonTipTitle = "Indonesia Stealth Monitor"

        'Menampilkan Ballontiptext untuk Notif ikon
        NotifyIcon1.BalloonTipText = "Monitoring here.."

        'Notif ikon ditampilkan selama 2 detik
        NotifyIcon1.ShowBalloonTip(2)

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click

        'keluar dari aplikasi
        Application.Exit()

    End Sub

    Private Sub StartMonitoringToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartMonitoringToolStripMenuItem.Click

        Timer1.Start()
        'mengubah warna tulisan logs history
        ListBox1.ForeColor = System.Drawing.Color.Red
        ListBox1.Items.Add("Monitoring Start...")
        ListBox1.Items.Add("")

    End Sub

    Private Sub StopMonitoringToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopMonitoringToolStripMenuItem.Click

        Timer1.Stop()
        'mengubah warna tulisan logs history
        ListBox1.ForeColor = System.Drawing.Color.Red
        ListBox1.Items.Add("Monitoring Stopped..")
        ListBox1.Items.Add("")

    End Sub

    Private Sub KaizerFamilyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KaizerFamilyToolStripMenuItem.Click
        Process.Start("www.facebook.com/indonesiaitintelijensi")
    End Sub

    Private Sub CreditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreditToolStripMenuItem.Click
        MessageBox.Show("Tedd , The Erwan & Aeonhack", "Thanks & Credit For", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class
