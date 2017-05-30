Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports System.IO
Imports System.ComponentModel

'hola espero que esto funcione

Public Class NewCaseForm
    Dim OutApp As Outlook.Application
    Dim EmailSender As String
    Dim Subject As String
    Dim OriginalEmailTime As String
    Dim OutItem As Outlook.MailItem
    Dim OutReplyItem As Outlook.MailItem
    Dim conection As New OleDbConnection
    Dim CaseID As Long
    Dim comands As New OleDbCommand
    Dim adapter As New OleDbDataAdapter
    Dim record As New DataSet
    Public filePath As String
    Public filePath2 As String

    Public Sub NewCaseForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TeamBox.Enabled = False
        ActCategoryBox.Enabled = False
        ResponsibleBox.Enabled = False

        'Load Teambox
        LoadTeamBox()

        'Load ConectionBox
        ConectionBox.Items.Add("Office")
        ConectionBox.Items.Add("Home")

        'Load StatusBox
        StatusBox.Items.Add("Closed")
        StatusBox.Items.Add("Open")
    End Sub

    Private Sub NewCaseForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        conection.Close()
        Me.Close()
    End Sub

    Private Sub NewCaseForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        conection.Close()
    End Sub

    Public Sub NewCaseForm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub CreateCaseButton_Click(sender As Object, e As EventArgs) Handles CreateCaseButton.Click
        Dim NextNumber As Long
        Dim MailSubject As String

        'Validate required fields
        If ActCategoryBox.Text = "" Then
            MsgBox("Must complete action category", vbExclamation, "Alert")
            Exit Sub
        End If

        If StatusBox.Text = "" Then
            MsgBox("Must complete status box", vbExclamation, "Alert")
            Exit Sub
        End If

        If PendingSrcBox.Text = "" And StatusBox.Text = "Opened" Then
            MsgBox("Must complete pending source", vbExclamation, "Alert")
            Exit Sub
        End If

        NextNumber = getNextTicketNumber()

        'Error
        If NextNumber = 0 Then Exit Sub

        If InsertTicket() Then

            'Save previous subject
            MailSubject = Me.Subject
            'Change mail status 
            'Team | Task | Mail Subject | Ticket Number| Ticket Status
            Me.Subject = TeamBox.Text & " | "
            'Outlookitem.Subject = ActCategoryBox.Text & "|"
            Me.Subject = Me.Subject & MailSubject & " | "
            Me.Subject = Me.Subject & NextNumber & " | "
            Me.Subject = Me.Subject & StatusBox.Text

            OutItem.Subject = Me.Subject

            OutItem.Save()
            MsgBox("Ticket " & NextNumber & " created", vbExclamation, "Alert")
        Else
            MsgBox("Creation Failed", vbExclamation, "Alert")
        End If

        conection.Close()
        Me.Close()
    End Sub

    Public Sub ConectionBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ConectionBox.SelectedIndexChanged

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

        'Reaload Teambox
        TeamBox.Items.Clear()
        LoadTeamBox()

    End Sub

    Private Sub TeamBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TeamBox.SelectedIndexChanged

        'Reload Activities
        ActCategoryBox.Items.Clear()
        LoadTeamActivitiesBox()
    End Sub

    Private Sub ActCategoryBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ActCategoryBox.SelectedIndexChanged

        'Reload Responsible Box
        ResponsibleBox.Items.Clear()
        LoadResponsibleBox()

        DateBox.Text = (DateTime.Now.ToString("MM/dd/yyyy"))
    End Sub

    Private Sub ResponsibleBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ResponsibleBox.SelectedIndexChanged
        Dim query As String = ""
        Dim rows As Integer

        Try
            query = ("SELECT * FROM TestTable ORDER BY ID DESC")
            adapter = New OleDbDataAdapter(query, conection)
            record = New DataSet
            adapter.Fill(record, "TestTable")
            rows = record.Tables("TestTable").Rows.Count
            If rows <> 0 Then
                DataGridView1.DataSource = record
                DataGridView1.DataMember = "TestTable"
                TrakingID.Text = (record.Tables("TestTable").Rows(0).Item("TicketNumber")) + 1
                TicketNumberBox.Text = TeamBox.Text & TrakingID.Text
            End If
            TicketNumberBox.Visible = True

            OutApp = CreateObject("Outlook.Application")
            OutItem = OutApp.ActiveInspector.CurrentItem
            EmailSender = OutItem.SenderName
            RequestorBox.Text = EmailSender
            Subject = OutItem.Subject
            OriginalEmailTime = OutItem.ReceivedTime

            rows = OutItem.id
        Catch ex As Exception
            MsgBox(ex)
        End Try

    End Sub

    Private Function getNextTicketNumber() As Long
        Dim result As Long = 0
        Dim query As String = ""
        Dim Rows As Integer

        Try
            query = ("SELECT TOP 1 TicketNumber FROM TestTable ORDER BY 1 DESC")
            adapter = New OleDbDataAdapter(query, conection)
            adapter.Fill(record, "TestTable")
            Rows = record.Tables("TestTable").Rows.Count
            If Rows <> 0 Then
                result = CLng(TrakingID.Text) + 1
                TicketNumberBox.Text = TeamBox.Text & TrakingID.Text
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return result
    End Function

    Private Function InsertTicket() As Boolean
        Dim result As Boolean = False
        Dim query As String = ""

        'Format query
        query = "INSERT INTO TestTable(MyITCase, Opened, Requestor, Analyst, BU, Description, PendingSource, Closed, ActivityCategory, Comments, OriginalEmailTime)"
        query = query & "VALUES("
        'MyITCase = TicketNumberBox.Text
        query = query & "'" & TicketNumberBox.Text & "',"
        'Opened = DateBox.Text
        query = query & "'" & DateBox.Text & "',"
        'Requestor = RequestorBox.Text
        query = query & "'" & RequestorBox.Text & "',"
        'Analyst = ResponsibleBox.Text
        query = query & "'" & ResponsibleBox.Text & "',"
        'BU = RegionBox.Text
        query = query & "'" & RegionBox.Text & "',"
        'Description = Subject
        query = query & "'" & Subject & "',"
        'PendingSource = PendingSrcBox.Text
        query = query & "'" & PendingSrcBox.Text & "',"
        'Closed
        If StatusBox.Text = "Closed" Then
            query = query & "'" & DateBox.Text & "',"
        Else
            query = query & " " & DBNull.Value & ","
        End If
        'ActivityCategory = ActCategoryBox.Text
        query = query & "'" & ActCategoryBox.Text & "',"
        'Comments = CommentsBox.Text
        query = query & "'" & CommentsBox.Text & "',"
        'OriginalEmailTime = OriginalEmailTime
        query = query & "'" & OriginalEmailTime & "')"

        Try
            comands = New OleDbCommand(query, conection)
            comands.ExecuteNonQuery()
            result = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        conection.Close()

        Return result

    End Function

    Private Sub LoadTeamBox()
        Dim query As String = ""
        Dim rows As Integer
        Dim items As Object
        TeamBox.Enabled = False

        Try
            query = ("SELECT * FROM SubTeams ORDER BY ID DESC")
            adapter = New OleDbDataAdapter(query, conection)
            record = New DataSet
            adapter.Fill(record, "SubTeams")
            rows = record.Tables("SubTeams").Rows.Count
            If rows <> 0 Then
                DataGridView1.DataSource = record
                DataGridView1.DataMember = "SubTeams"
                items = (record.Tables("SubTeams").Rows(0).Item("ID"))
                For x = 0 To items - 1
                    TeamBox.Items.Add(record.Tables("SubTeams").Rows(x).Item("Team"))
                Next
            End If
            TeamBox.Enabled = True

        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

    Private Sub LoadTeamActivitiesBox()
        Dim query As String = ""
        Dim rows As Integer
        Dim items As Object
        ActCategoryBox.Enabled = False

        Try
            query = ("SELECT * FROM TeamsActivities WHERE SubTeam = '" & TeamBox.Text & " ' ORDER BY ID DESC")
            adapter = New OleDbDataAdapter(query, conection)
            record = New DataSet
            adapter.Fill(record, "TeamsActivities")
            rows = record.Tables("TeamsActivities").Rows.Count
            If rows <> 0 Then
                DataGridView1.DataSource = record
                DataGridView1.DataMember = "TeamsActivities"
                items = (record.Tables("TeamsActivities").Rows(0).Item("ID"))

                For x = 0 To rows - 1
                    ActCategoryBox.Items.Add(record.Tables("TeamsActivities").Rows(x).Item("Activity"))
                Next
            End If
            ActCategoryBox.Enabled = True
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

    Private Sub LoadResponsibleBox()
        Dim query As String = ""
        Dim rows As Integer
        Dim items As Object
        ResponsibleBox.Enabled = False

        Try
            query = ("SELECT * FROM TeamMembers ORDER BY ID DESC")
            adapter = New OleDbDataAdapter(query, conection)
            record = New DataSet
            adapter.Fill(record, "TeamMembers")
            rows = record.Tables("TeamMembers").Rows.Count
            If rows <> 0 Then
                DataGridView1.DataSource = record
                DataGridView1.DataMember = "TeamMembers"
                items = (record.Tables("TeamMembers").Rows(0).Item("ID"))

                For x = 0 To items - 1
                    ResponsibleBox.Items.Add(record.Tables("TeamMembers").Rows(x).Item("MemberEnterpriceID"))
                Next
            End If
            ResponsibleBox.Enabled = True

        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub
End Class