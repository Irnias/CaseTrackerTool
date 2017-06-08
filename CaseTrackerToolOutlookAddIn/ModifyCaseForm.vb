Imports System.ComponentModel
Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms

Public Class ModifyCaseForm
    Dim conection As New OleDbConnection
    Dim adapter As New OleDbDataAdapter
    Dim records As New DataSet
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
            Outlookitem.Subject = records.Tables("Tickets").Rows(0).Item("szTeam") & "|"
            'Outlookitem.Subject = Outlookitem.Subject & records.Tables("Tickets").Rows(0).Item("szActivityCategory") & "|"
            Outlookitem.Subject = Outlookitem.Subject & records.Tables("Tickets").Rows(0).Item("szDescription") & "|"
            Outlookitem.Subject = Outlookitem.Subject & records.Tables("Tickets").Rows(0).Item("mnTicketNumber") & "|"
            Outlookitem.Subject = Outlookitem.Subject & records.Tables("Tickets").Rows(0).Item("szStatus")
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
            Outlookitem.Subject = records.Tables("Tickets").Rows(0).Item("szTeam") & "|"
            'Outlookitem.Subject = Outlookitem.Subject & records.Tables("Tickets").Rows(0).Item("szActivityCategory") & "|"
            Outlookitem.Subject = Outlookitem.Subject & records.Tables("Tickets").Rows(0).Item("szDescription") & "|"
            Outlookitem.Subject = Outlookitem.Subject & records.Tables("Tickets").Rows(0).Item("mnTicketNumber") & "|"
            Outlookitem.Subject = Outlookitem.Subject & records.Tables("Tickets").Rows(0).Item("szStatus")

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
            Outlookitem.Subject = records.Tables("Tickets").Rows(0).Item("szTeam") & "|"
            'Outlookitem.Subject = Outlookitem.Subject & records.Tables("Tickets").Rows(0).Item("szActivityCategory") & "|"
            Outlookitem.Subject = Outlookitem.Subject & records.Tables("Tickets").Rows(0).Item("szDescription") & "|"
            Outlookitem.Subject = Outlookitem.Subject & records.Tables("Tickets").Rows(0).Item("mnTicketNumber") & "|"
            Outlookitem.Subject = Outlookitem.Subject & records.Tables("Tickets").Rows(0).Item("szStatus")
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
                query = "SELECT * FROM Tickets WHERE mnTicketNumber = " & TicketNumber
                adapter = New OleDbDataAdapter(query, conection)
                adapter.Fill(records, "Tickets")
                Rows = records.Tables("Tickets").Rows.Count

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
        DataGridView1.DataMember = "Tickets"

        StatusBox.Text = records.Tables("Tickets").Rows(0).Item("szStatus")
        ResponsibleBox.Text = records.Tables("Tickets").Rows(0).Item("szResponsible")
        RegionBox.Text = records.Tables("Tickets").Rows(0).Item("szBusinessUnit")
        OpenedDateBox.Text = records.Tables("Tickets").Rows(0).Item("gdOpenDate")
        RequestorBox.Text = records.Tables("Tickets").Rows(0).Item("szRequestor")
        PendingSourceBox.Text = records.Tables("Tickets").Rows(0).Item("szPendingSource")
        CommentsBox.Text = records.Tables("Tickets").Rows(0).Item("szComments")
    End Sub

    Private Function UpdateTicket(Action As String) As Boolean
        Dim result As Boolean = False
        Dim query As String = ""

        'Format query
        query = "INSERT INTO Tickets(mnTicketNumber, mnTicketLineNumber, szTeam, szActivityCategory, szResponsible, szStatus, szRequestor, szBusinessUnit, szPendingSource, gdOpenDate, gdCloseDate, szComments, szDescription, gdRequestedTime, mnOpenDays, szAuditUser, szLocation, gdCreationDate)"
        query = query & "VALUES("
        'mnTicketNumber
        query = query & TicketNumberBox.Text & ","
        'mnTicketLineNumber (First line start with 0)
        query = query & records.Tables("Tickets").Rows(0).Item("mnTicketLineNumber") + 1 & ", "
        'szTeam, 
        query = query & "'" & records.Tables("Tickets").Rows(0).Item("szTeam") & "', "
        'szActivityCategory
        query = query & "'" & records.Tables("Tickets").Rows(0).Item("szActivityCategory") & "', "
        'szResponsible
        query = query & "'" & ResponsibleBox.Text & "', "
        'szStatus
        query = query & "'" & StatusBox.Text & "', "
        'szRequestor
        query = query & "'" & RequestorBox.Text & "', "
        'szBusinessUnit
        query = query & "'" & RegionBox.Text & "', "
        'szPendingSource
        Select Case (Action)
            Case "Close"
                query = query & "'" & DBNull.Value & "', "
            Case "Open"
                query = query & "'" & PendingSourceBox.Text & "', "
            Case "Modify"
                query = query & "'" & PendingSourceBox.Text & "', "
        End Select
        'gdOpenDate
        query = query & "'" & OpenedDateBox.Text & "', "
        'gdCloseDate
        Select Case (Action)
            Case "Close"
                query = query & "'" & (DateTime.Now.ToString("MM/dd/yyyy")) & "', "
            Case "Open"
                query = query & "'" & DBNull.Value & "', "
            Case "Modify"
                query = query & "'" & OpenedDateBox.Text & "', "
        End Select
        'szComments
        query = query & "'" & CommentsBox.Text & "', "
        'szDescription
        query = query & "'" & Subject & "', "
        'gdRequestedTime 
        query = query & "'" & records.Tables("Tickets").Rows(0).Item("gdRequestedTime") & "', "
        'mnOpenDays
        query = query & 0 & ", "
        'szAuditUser
        query = query & "'" & Environment.UserName & "', "
        'szLocation
        query = query & "'" & ConectionBox.Text & "', "
        'gdCreationDate
        query = query & "'" & DateTime.Now.ToString("MM/dd/yyyy") & "')"

        Try
            'Perform query
            command = New OleDbCommand(query, conection)
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