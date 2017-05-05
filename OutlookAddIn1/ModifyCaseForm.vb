Imports System.ComponentModel
Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms

Public Class ModifyCaseForm
    Dim conexion As New OleDbConnection
    Dim adaptador As New OleDbDataAdapter
    Dim registros As New DataSet
    Dim OutlookAppli As Outlook.Application
    Dim Subject As String
    Dim Outlookitem As Outlook.MailItem

    Private Sub Form2_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
        ResponsibleBox.Enabled = False
        RegionBox.Enabled = False
        OpenedDateBox.Enabled = False
        RequestorBox.Enabled = False
        PendingSourceBox.Enabled = False
        CommentsBox.Enabled = False

        ConectionBox.Items.Add("Office")
        ConectionBox.Items.Add("Home")

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles SearchButton.Click

        If TicketNumberBox.Text = "MaxForm" Then


            Me.WindowState = FormWindowState.Maximized

            DataGridView1.Width = 1350
            DataGridView1.Height = 100
        Else

            Try
                Dim consultar As String
                Dim lista As Byte
                If TicketNumberBox.Text <> "" Then
                    consultar = "SELECT * FROM TestTable WHERE MyITCase = '" & TicketNumberBox.Text & "'"
                    adaptador = New OleDbDataAdapter(consultar, conexion)
                    registros = New DataSet
                    adaptador.Fill(registros, "TestTable")
                    lista = registros.Tables("TestTable").Rows.Count
                    If lista <> 0 Then
                        DataGridView1.DataSource = registros
                        DataGridView1.DataMember = "TestTable"
                        ResponsibleBox.Text = registros.Tables("TestTable").Rows(0).Item("Analyst")
                        OpenedDateBox.Text = registros.Tables("TestTable").Rows(0).Item("Opened")
                        RegionBox.Text = registros.Tables("TestTable").Rows(0).Item("BU")
                        RequestorBox.Text = registros.Tables("TestTable").Rows(0).Item("Requestor")
                        PendingSourceBox.Text = registros.Tables("TestTable").Rows(0).Item("PendingSource")
                        StatusBox.Text = registros.Tables("TestTable").Rows(0).Item("Status")
                        CommentsBox.Text = registros.Tables("TestTable").Rows(0).Item("Comments")

                    Else
                        MsgBox("Unable to find case", vbExclamation, "Alert")
                        TicketNumberBox.Clear()
                        DataGridView1.Columns.Clear()
                        TicketNumberBox.Focus()
                    End If

                End If

            Catch ex As Exception
                MsgBox("Unable to find case", vbExclamation, "Alert")
            End Try
        End If

    End Sub

    Private Sub Form2_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        conexion.Close()
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
        ResponsibleBox.Enabled = True
        RegionBox.Enabled = True
        OpenedDateBox.Enabled = True
        RequestorBox.Enabled = True
        PendingSourceBox.Enabled = True
        CommentsBox.Enabled = True
    End Sub

    Dim comandos As New OleDbCommand
    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Dim actualizar As String
        '  actualizar = "UPDATE TestTable SET PendingSource = '" & TextBox6.Text & "' WHERE MyITCase = '" & TextBox1.Text & "'"

        actualizar = "UPDATE TestTable SET Analyst = '" & ResponsibleBox.Text &
         "', BU = '" & RegionBox.Text &
         "', Opened = '" & OpenedDateBox.Text &
         "', Requestor = '" & RequestorBox.Text &
         "', PendingSource = '" & PendingSourceBox.Text &
         "', Comments = '" & CommentsBox.Text &
         "' WHERE MyITCase = '" & TicketNumberBox.Text & "'"

        comandos = New OleDbCommand(actualizar, conexion)
        comandos.ExecuteNonQuery()
        MsgBox("Changes Done", vbInformation, "Alert")
        conexion.Close()

    End Sub

    Private Sub Form2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles CloseButton.Click


        If StatusBox.Text <> "Closed" Or PendingSourceBox.Text <> "" Then

            Try
                Dim actualizar As String
                actualizar = "UPDATE TestTable SET Closed = '" & (DateTime.Now.ToString("MM/dd/yyyy")) & "' WHERE MyITCase = '" & TicketNumberBox.Text & "'"
                comandos = New OleDbCommand(actualizar, conexion)
                comandos.ExecuteNonQuery()
                ' Outlookitem.Subject = Outlookitem.Subject & " - " & "Ticket closed"
                MsgBox("Case closed correctly", vbInformation, "Correct")

            Catch ex As Exception
                MsgBox("The case cannot be closed", vbInformation, "Correct")
            End Try

            OutlookAppli = CreateObject("Outlook.Application")
            Outlookitem = OutlookAppli.ActiveInspector.CurrentItem

            Try
                Outlookitem.Subject = Outlookitem.Subject & "Completed"
            Catch ex As Exception
            End Try

            StatusBox.Text = "Closed"
            Outlookitem.Save()
        Else
            MsgBox("Make sure the ticket is not already closed and the pending source field is blank", vbInformation, "Ticket already closed")

        End If


    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles OpenButton.Click

        If StatusBox.Text <> "Opened" Then

            Try
                Dim actualizar As String

                actualizar = "UPDATE TestTable SET Closed = NULL WHERE MyITCase = '" & TicketNumberBox.Text & "'"
                comandos = New OleDbCommand(actualizar, conexion)
                comandos.ExecuteNonQuery()
                MsgBox("Case Opened correctly", vbInformation, "Correct")

            Catch ex As Exception
                MsgBox("The case cannot be opened", vbInformation, "Correct")
            End Try

            OutlookAppli = CreateObject("Outlook.Application")
            Outlookitem = OutlookAppli.ActiveInspector.CurrentItem

            Try
                Outlookitem.Subject = Replace(Outlookitem.Subject, "Completed", "")
            Catch ex As Exception
            End Try

            StatusBox.Text = "Opened"
            Outlookitem.Save()
        Else
            MsgBox("The ticket is already opened.", vbInformation, "Ticket already opened")

        End If

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ConectionBox.SelectedIndexChanged
        If ConectionBox.Text = "Office" Then
            conexion.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = \\10.21.144.6\GBS Accenture Data\RTR\GA\MIS\Test1.accdb"
            conexion.Open()
        Else
            conexion.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = \\ramxilss002-f04.bp.com\ACNOPs\BA\Mariner\Mariner\RTR\MIS\Test1.accdb"
            conexion.Open()
        End If

        conexion.Open()
        ResponsibleBox.Enabled = False
        RegionBox.Enabled = False
        OpenedDateBox.Enabled = False
        RequestorBox.Enabled = False
        PendingSourceBox.Enabled = False
        StatusBox.Enabled = False
        TicketNumberBox.Focus()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TicketNumberBox.TextChanged

    End Sub

    Private Sub Form2_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        conexion.Close()
    End Sub
End Class