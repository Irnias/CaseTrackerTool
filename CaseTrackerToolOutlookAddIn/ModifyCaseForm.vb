Imports System.ComponentModel
Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms

Public Class ModifyCaseForm
    Dim conection As New OleDbConnection
    Dim adapter As New OleDbDataAdapter
    Dim records As New DataSet
    Dim OutlookAppli As Outlook.Application
    Dim Subject As String
    Dim Outlookitem As Outlook.MailItem
    Dim command As New OleDbCommand

    Private Sub ModifyCaseForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResponsibleBox.Enabled = False
        RegionBox.Enabled = False
        OpenedDateBox.Enabled = False
        RequestorBox.Enabled = False
        PendingSourceBox.Enabled = False
        CommentsBox.Enabled = False

        ConectionBox.Items.Add("Office")
        ConectionBox.Items.Add("Home")
    End Sub

    Private Sub ModifyCaseForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        conection.Close()
        Me.Close()
    End Sub

    Private Sub ModifyCaseForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        conection.Close()
    End Sub

    Private Sub ModifyCaseForm_KeyDown(ByVal sender As System.Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click
        Dim Rows As Integer

        'Validate ticket existence
        If SearchTicket(Rows) Then

            'Retrieve ticket information
            RetrieveTicketInformation()
        Else
            MsgBox("No case was find", vbExclamation, "Alert")
            TicketNumberBox.Clear()
            DataGridView1.Columns.Clear()
            TicketNumberBox.Focus()
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
        ResponsibleBox.Enabled = True
        RegionBox.Enabled = True
        OpenedDateBox.Enabled = True
        RequestorBox.Enabled = True
        PendingSourceBox.Enabled = True
        CommentsBox.Enabled = True
    End Sub

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

        command = New OleDbCommand(actualizar, conection)
        command.ExecuteNonQuery()
        MsgBox("Changes Done", vbInformation, "Alert")
        conection.Close()

    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click


        If StatusBox.Text <> "Closed" Or PendingSourceBox.Text <> "" Then

            Try
                Dim actualizar As String
                'actualizar = "UPDATE TestTable SET Closed = '" & (DateTime.Now.ToString("MM/dd/yyyy")) & "' WHERE TicketNumber = '" & TicketNumberBox.Text & "'"

                actualizar = "UPDATE Testable SET Closed = '" & (DateTime.Now.ToString("MM/dd/yyyy")) & "' ,PendingSource = '" & DBNull.Value & "' WHERE TicketNumber = '" & TicketNumberBox.Text & "'"

                command = New OleDbCommand(actualizar, conection)
                command.ExecuteNonQuery()
                ' Outlookitem.Subject = Outlookitem.Subject & " - " & "Ticket closed"
                MsgBox("Case closed correctly", vbInformation, "Correct")

            Catch ex As Exception
                MsgBox("The Case cannot be closed", vbInformation, "Correct")
            End Try

            OutlookAppli = CreateObject("Outlook.Application")
            Outlookitem = OutlookAppli.ActiveInspector.CurrentItem

            Try
                Outlookitem.Subject = Outlookitem.Subject & " Completed"
            Catch ex As Exception
            End Try

            StatusBox.Text = "Closed"
            Outlookitem.Save()
        Else
            MsgBox("Make sure the ticket Is Not already closed And the pending source field Is blank", vbInformation, "Ticket already closed")
        End If
    End Sub

    Private Sub OpenButton_Click(sender As Object, e As EventArgs) Handles OpenButton.Click

        If StatusBox.Text <> "Opened" Then

            Try
                Dim actualizar As String

                actualizar = "UPDATE TestTable Set Closed = NULL WHERE TicketNumber = '" & TicketNumberBox.Text & "'"
                command = New OleDbCommand(actualizar, conection)
                command.ExecuteNonQuery()
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

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ConectionBox.SelectedIndexChanged
        'Restart conection if open
        If conection.State. = "Open" Then
            conection.Close()
        End If

        If ConectionBox.Text = "Office" Then
            conection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = \\10.21.144.6\GBS Accenture Data\RTR\GA\MIS\Test1.accdb"
            conection.Open()
        Else
            conection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = \\ramxilss002-f04.bp.com\ACNOPs\BA\Mariner\Mariner\RTR\MIS\Test1.accdb"
            conection.Open()
        End If

        conection.Open()
        ResponsibleBox.Enabled = False
        RegionBox.Enabled = False
        OpenedDateBox.Enabled = False
        RequestorBox.Enabled = False
        PendingSourceBox.Enabled = False
        StatusBox.Enabled = False
        TicketNumberBox.Focus()
    End Sub

    Private Sub ModifyCaseCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles ModifyCaseCheckBox.CheckedChanged
        ResponsibleBox.Enabled = True
        RegionBox.Enabled = True
        OpenedDateBox.Enabled = True
        RequestorBox.Enabled = True
        PendingSourceBox.Enabled = True
        StatusBox.Enabled = True
    End Sub

    Private Sub ModifyCaseButton_Click(sender As Object, e As EventArgs) Handles ModifyCaseButton.Click
        Dim actualizar As String
        actualizar = "UPDATE TestTable SET Analyst = '" & ResponsibleBox.Text &
         "', BU = '" & RegionBox.Text &
         "', Opened = '" & OpenedDateBox.Text &
         "', Requestor = '" & RequestorBox.Text &
         "', PendingSource = '" & PendingSourceBox.Text &
         "', Comments = '" & CommentsBox.Text &
         "' WHERE TicketNumber = '" & TicketNumberBox.Text & "'"

        command = New OleDbCommand(actualizar, conection)
        command.ExecuteNonQuery()
        MsgBox("Changes Done", vbInformation, "Alert")

    End Sub

    Private Function SearchTicket(Rows As Integer) As Boolean
        Dim consult As String
        Dim result As Boolean = False

        If TicketNumberBox.Text <> "" Then
            consult = "SELECT * FROM TestTable WHERE TicketNumber = '" & TicketNumberBox.Text & "'"
            adapter = New OleDbDataAdapter(consult, conection)
            records = New DataSet
            adapter.Fill(records, "TestTable")
            Rows = records.Tables("TestTable").Rows.Count

            If Rows <> 0 Then
                result = True
                MsgBox("Select performed", vbExclamation, "Alert")
            Else
                MsgBox("Error in selection", vbExclamation, "Alert")
            End If

        End If

        Return result
    End Function

    Private Sub RetrieveTicketInformation()
        DataGridView1.DataSource = records
        DataGridView1.DataMember = "TestTable"
        ResponsibleBox.Text = records.Tables("TestTable").Rows(0).Item("Analyst")
        OpenedDateBox.Text = records.Tables("TestTable").Rows(0).Item("Opened")
        RegionBox.Text = records.Tables("TestTable").Rows(0).Item("BU")
        RequestorBox.Text = records.Tables("TestTable").Rows(0).Item("Requestor")
        PendingSourceBox.Text = records.Tables("TestTable").Rows(0).Item("PendingSource")
        StatusBox.Text = records.Tables("TestTable").Rows(0).Item("Status")
        CommentsBox.Text = records.Tables("TestTable").Rows(0).Item("Comments")

        'Borrar
        MsgBox("Case Found", vbExclamation, "Alert")
    End Sub

End Class