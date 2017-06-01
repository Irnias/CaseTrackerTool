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
        'Enable conection box
        ConectionBox.Enabled = True

        'Load ConectionBox
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
        'Validate ticket existence
        If SearchTicket(TicketNumberBox.Text) Then

            'Retrieve ticket information
            RetrieveTicketInformation()
        Else
            MsgBox("No ticket was find", vbExclamation, "Alert")
            TicketNumberBox.Clear()
            DataGridView1.Columns.Clear()
            TicketNumberBox.Focus()
        End If
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click

        'Validate ticket existence
        If Not SearchTicket(TicketNumberBox.Text) Then
            'Ticket does not exist
            MsgBox("No ticket was find", vbExclamation, "Alert")
            Exit Sub
        Else
            'Retrieve ticket information
            RetrieveTicketInformation()
        End If

        'Ticket must be open
        If StatusBox.Text = "Closed" Then
            MsgBox("Ticket already closed", vbExclamation, "Alert")
            Exit Sub
        End If

        'Update Ticket
        If UpdateTicket("Close") Then

            'Change mail status 
            'Team | Task | Mail Subject | Ticket Number| Ticket Status
            Outlookitem.Subject = records.Tables("TestTable").Rows(0).Item("Team") & "|"
            'Outlookitem.Subject = Outlookitem.Subject & records.Tables("TestTable").Rows(0).Item("ActivityCategory") & "|"
            Outlookitem.Subject = Outlookitem.Subject & records.Tables("TestTable").Rows(0).Item("Description") & "|"
            Outlookitem.Subject = Outlookitem.Subject & records.Tables("TestTable").Rows(0).Item("TicketNumber") & "|"
            Outlookitem.Subject = Outlookitem.Subject & records.Tables("TestTable").Rows(0).Item("Status")
        End If
                  
        'Retrieve updated ticket information
        RetrieveTicketInformation()

        Outlookitem.Save()
        Me.Close()
    End Sub

    Private Sub OpenButton_Click(sender As Object, e As EventArgs) Handles OpenButton.Click

        'Validate ticket existence
        If Not SearchTicket(TicketNumberBox.Text) Then
            'Ticket does not exist
            MsgBox("No ticket was find", vbExclamation, "Alert")
            Exit Sub
        Else
            'Retrieve ticket information
            RetrieveTicketInformation()
        End If

        'Ticket must be closed
        If StatusBox.Text = "Opened" Then
            MsgBox("Ticket already open", vbExclamation, "Alert")
            Exit Sub
        End If

        If UpdateTicket("Open") Then
            'Change mail status 
            'Team | Task | Mail Subject | Ticket Number| Ticket Status
            Outlookitem.Subject = records.Tables("TestTable").Rows(0).Item("Team") & "|"
            Outlookitem.Subject = Outlookitem.Subject & records.Tables("TestTable").Rows(0).Item("ActivityCategory") & "|"
            Outlookitem.Subject = Outlookitem.Subject & records.Tables("TestTable").Rows(0).Item("Description") & "|"
            Outlookitem.Subject = Outlookitem.Subject & records.Tables("TestTable").Rows(0).Item("TicketNumber") & "|"
            Outlookitem.Subject = Outlookitem.Subject & records.Tables("TestTable").Rows(0).Item("Status")

        End If
                          
        'Retrieve updated ticket information
        RetrieveTicketInformation()

        Outlookitem.Save()
        Me.Close()
    End Sub

    Private Sub ModifyCaseButton_Click(sender As Object, e As EventArgs) Handles ModifyCaseButton.Click

        'Validate ticket existence
        If Not SearchTicket(TicketNumberBox.Text) Then
            'Ticket does not exist
            MsgBox("No ticket was find", vbExclamation, "Alert")
            Exit Sub
        End If

        'Update Ticket
        If UpdateTicket("Modify") Then
            'Change mail status 
            'Team | Task | Mail Subject | Ticket Number| Ticket Status
            Outlookitem.Subject = records.Tables("TestTable").Rows(0).Item("Team") & "|"
            Outlookitem.Subject = Outlookitem.Subject & records.Tables("TestTable").Rows(0).Item("ActivityCategory") & "|"
            Outlookitem.Subject = Outlookitem.Subject & records.Tables("TestTable").Rows(0).Item("Description") & "|"
            Outlookitem.Subject = Outlookitem.Subject & records.Tables("TestTable").Rows(0).Item("TicketNumber") & "|"
            Outlookitem.Subject = Outlookitem.Subject & records.Tables("TestTable").Rows(0).Item("Status")
        End If

                          
        'Retrieve updated ticket information
        RetrieveTicketInformation()

        Outlookitem.Save()
        Me.Close()
    End Sub

    Private Sub ConectionBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ConectionBox.SelectedIndexChanged
        'Restart conection if open
        If conection.State = ConnectionState.Open Then
            conection.Close()
        End If

        'Start new conection
        Try
            If ConectionBox.Text = "Office" Then
                conection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = \\10.21.144.6\GBS Accenture Data\RTR\GA\MIS\Test1.accdb"
                conection.Open()
            Else
                conection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = \\ramxilss002-f04.bp.com\ACNOPs\BA\Mariner\Mariner\RTR\MIS\Test1.accdb"
                conection.Open()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'Enable and set focus over Ticket Number Box
        TicketNumberBox.Enabled = True
        TicketNumberBox.Focus()
    End Sub

    Private Sub ModifyCaseCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles ModifyCaseCheckBox.CheckedChanged

        'Validate ticket existence
        If Not SearchTicket(TicketNumberBox.Text) Then
            'Ticket does not exist
            MsgBox("No ticket was find", vbExclamation, "Alert")
            Exit Sub
        Else
            'Retrieve updated ticket information
            RetrieveTicketInformation()
        End If

        'Enable Modification fields
        If ModifyCaseCheckBox.Checked Then
            ResponsibleBox.Enabled = True
            RegionBox.Enabled = True
            OpenedDateBox.Enabled = True
            RequestorBox.Enabled = True
            PendingSourceBox.Enabled = True
            StatusBox.Enabled = True
            CommentsBox.Enabled = True
        Else
            'Disable Modification fields
            ResponsibleBox.Enabled = False
            RegionBox.Enabled = False
            OpenedDateBox.Enabled = False
            RequestorBox.Enabled = False
            PendingSourceBox.Enabled = False
            StatusBox.Enabled = False
            CommentsBox.Enabled = False
        End If
    End Sub

    Private Function SearchTicket(TicketNumber As String) As Boolean
        Dim result As Boolean = False
        Dim query As String
        Dim Rows As Integer

        If TicketNumberBox.Text <> "" Then
            Try
                query = "SELECT * FROM TestTable WHERE TicketNumber = " & TicketNumber
                adapter = New OleDbDataAdapter(query, conection)
                adapter.Fill(records, "TestTable")
                Rows = records.Tables("TestTable").Rows.Count

                If Rows <> 0 Then
                    result = True
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
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
    End Sub

    Private Function UpdateTicket(Action As String) As Boolean
        Dim result As Boolean = False
        Dim updateQuery As String = ""

        Select Case (Action)

            Case "Close"
                updateQuery = "UPDATE Testable SET "
                updateQuery = updateQuery & "Closed = '" & (DateTime.Now.ToString("MM/dd/yyyy")) & "'"
                updateQuery = updateQuery & ","
                updateQuery = updateQuery & "PendingSource = '" & DBNull.Value & "'"
                updateQuery = updateQuery & "WHERE TicketNumber = " & TicketNumberBox.Text

            Case "Open"
                updateQuery = "UPDATE TestTable Set Closed = NULL WHERE TicketNumber ="
                updateQuery = updateQuery & TicketNumberBox.Text

            Case "Modify"
                updateQuery = "UPDATE TestTable SET Analyst = '" & ResponsibleBox.Text & "'"
                updateQuery = updateQuery & ", BU = '" & RegionBox.Text & "'"
                updateQuery = updateQuery & ", Opened = '" & OpenedDateBox.Text & "'"
                updateQuery = updateQuery & ", Requestor = '" & RequestorBox.Text & "'"
                updateQuery = updateQuery & ", PendingSource = '" & PendingSourceBox.Text & "'"
                updateQuery = updateQuery & ", Comments = '" & CommentsBox.Text & "'"
                updateQuery = updateQuery & " WHERE TicketNumber = " & TicketNumberBox.Text
        End Select

        Try
            'Perform query
            command = New OleDbCommand(updateQuery, conection)
            command.ExecuteNonQuery()

            'Notify transaction status
            Select Case (Action)
                Case "Close"
                    MsgBox("Ticket closed", vbExclamation, "Alert")
                Case "Open"
                    MsgBox("Ticket opened", vbExclamation, "Alert")
                Case "Modify"
                    MsgBox("Ticket modified", vbExclamation, "Alert")
            End Select

            result = True

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        conection.Close()
        Return result
    End Function
End Class