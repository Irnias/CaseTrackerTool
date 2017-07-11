Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class AddCaseForm
    Dim OutApp As Outlook.Application
    Dim OutItem As Outlook.MailItem
    Dim myInspector As Outlook.Inspector

    Dim conection As New OleDbConnection
    Dim comands As New OleDbCommand
    Dim adapter As New OleDbDataAdapter
    Dim record As New DataSet

    Dim activitiesVisualAssistForm As New ActivitiesVisualAssistForm

    Dim szActCategoryDescription As String = ""
    Dim szSubject As String
    Dim gdCreationTime As Date
    Dim mnHomePrefix As Integer = 0

    Public Sub NewCaseForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConectionBox.Enabled = True

        'Clear Options
        TeamBox.Items.Clear()
        ActCategoryBox.Items.Clear()
        ResponsibleBox.Items.Clear()
        StatusBox.Items.Clear()
        PriorityBox.Items.Clear()
        RequestorBox.Clear()
        RegionBox.Clear()
        PendingSrcBox.Clear()
        DateBox.Clear()
        CommentsBox.Clear()

        'Load ConectionBox
        ConectionBox.Items.Add("ACN")
        ConectionBox.Items.Add("Home - Office")

        'Load StatusBox
        StatusBox.Items.Add("Close")
        StatusBox.Items.Add("Open")

        'Load PriorityBox
        PriorityBox.Items.Add("High")
        PriorityBox.Items.Add("Medium")
        PriorityBox.Items.Add("Low")

        'Parse Email
        ParseEmail()

        'Set default value
        DateBox.Text = (DateTime.Now.ToString("MM/dd/yyyy"))

    End Sub

    Private Sub NewCaseForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        conection.Close()
        Me.Finalize()
    End Sub

    Public Sub NewCaseForm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub CreateCaseButton_Click(sender As Object, e As EventArgs) Handles CreateCaseButton.Click
        Dim NextNumber As Long = 0

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

        'Perform Insert
        If InsertTicket(NextNumber) Then
            'Change mail status 
            'Mail szSubject | Ticket Number| Ticket Status
            szSubject = szSubject & " | TK"
            szSubject = szSubject & Convert.ToString(NextNumber).PadLeft(10, "0")
            If StatusBox.Text <> "Open" Then
                szSubject = szSubject & " | " & StatusBox.Text
            End If

            OutItem.Subject = szSubject
            OutItem.Save()
            MsgBox("Ticket " & NextNumber & " created", vbExclamation, "Alert")
        Else
            MsgBox("Creation Failed", vbExclamation, "Alert")
        End If
        Me.Close()
    End Sub

    Public Sub ConectionBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ConectionBox.SelectedIndexChanged
        'Clear Options
        TeamBox.Items.Clear()
        ActCategoryBox.Items.Clear()
        ResponsibleBox.Items.Clear()

        'Restart conection if open
        If conection.State = ConnectionState.Open Then
            conection.Close()
        End If

        'Start new conection
        Try
            If ConectionBox.Text = "ACN" Then
                conection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = \\10.21.144.6\GBS Accenture Data\RTR\GA\MIS\Test1.accdb"
                mnHomePrefix = 0
            Else
                conection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = \\ramxilss002-f04.bp.com\ACNOPs\BA\Mariner\Mariner\RTR\MIS\Test1.accdb"
                mnHomePrefix = 1000000000
            End If
        Catch ex As System.Exception
            MsgBox(ex.Message)
        End Try

        'Reaload and enable Teambox
        TeamBox.Items.Clear()
        LoadTeamBox()
        TeamBox.Enabled = True
    End Sub

    Private Sub TeamBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TeamBox.SelectedIndexChanged
        'Clear Options
        ResponsibleBox.Items.Clear()

        'Reload and enable Activities Box
        ActCategoryBox.Items.Clear()
        ActCategoryBox.Enabled = True
        LoadCategoryBox()
        ActivitiesVisualAssistButton.Enabled = True
    End Sub

    Private Sub ActCategoryBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ActCategoryBox.SelectedIndexChanged

        'Reload and enable Responsible Box
        ResponsibleBox.Items.Clear()
        LoadResponsibleBox()
        ResponsibleBox.Enabled = True
    End Sub

    Private Sub ResponsibleBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ResponsibleBox.SelectedIndexChanged

        'Enable fields
        StatusBox.Enabled = True
        PriorityBox.Enabled = True
        RequestorBox.Enabled = True
        RegionBox.Enabled = True
        PendingSrcBox.Enabled = True
        DateBox.Enabled = True
        CommentsBox.Enabled = True
    End Sub

    Private Sub DateBox_TextChanged(sender As Object, e As EventArgs) Handles DateBox.LostFocus
        If IsDate(DateBox.Text) = False Then
            DateBox.Text = ""
            MsgBox("Date format not allowed", vbExclamation, "Alert")
        End If
    End Sub

    Private Function getNextTicketNumber() As Long
        Dim result As Long = 0
        Dim query As String = ""
        Dim rows As Integer

        Try
            conection.Open()
            query = ("SELECT TOP 1 mnTicketNumber, mnTicketLineNumber FROM Tickets ORDER BY 1 DESC, 2 DESC")
            adapter = New OleDbDataAdapter(query, conection)

            adapter.Fill(record, "Tickets")
            rows = record.Tables("Tickets").Rows.Count
            If rows <> 0 Then
                result = CLng(record.Tables("Tickets").Rows(0).Item("mnTicketNumber")) + 1
            Else
                result = mnHomePrefix + 1
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        conection.Close()
        Return result
    End Function

    Private Function InsertTicket(ByRef NextNumber As Long) As Boolean
        Dim result As Boolean = False
        Dim query As String = ""

        NextNumber = getNextTicketNumber()

        'Error
        If NextNumber <> 0 Then
            conection.Open()
            'Format query
            query = "INSERT INTO Tickets(mnTicketNumber, mnTicketLineNumber, szTeam, szActivityCategory, szResponsible, szStatus, szPriority,szRequestor, szBusinessUnit, szPendingSource, gdOpenDate, gdCloseDate, szComments, szDescription, gdRequestedTime, mnOpenDays, szAuditUser, szLocation, gdCreationDate)"
            query = query & "VALUES("
            'mnTicketNumber
            query = query & NextNumber & ","
            'mnTicketLineNumber (First line start with 0)
            query = query & 0 & ","
            'szTeam
            query = query & "'" & TeamBox.Text & "',"
            'szActivityCategory
            query = query & "'" & ActCategoryBox.Text & "',"
            'szResponsible
            query = query & "'" & ResponsibleBox.Text & "',"
            'szStatus
            query = query & "'" & StatusBox.Text & "',"
            'szPriority
            query = query & "'" & PriorityBox.Text & "',"
            'szRequestor
            query = query & "'" & RequestorBox.Text & "',"
            'szBusinessUnit
            query = query & "'" & RegionBox.Text & "',"
            'szPendingSource
            If StatusBox.Text <> "Close" Then
                query = query & "'" & PendingSrcBox.Text & "',"
            Else
                query = query & "'',"
            End If
            'gdOpenDate
            query = query & "'" & DateBox.Text & "',"
            'gdCloseDate
            If StatusBox.Text = "Close" Then
                query = query & "'" & DateBox.Text & "',"
            Else
                query = query & "'" & DBNull.Value & "',"
            End If
            'szComments
            query = query & "'" & CommentsBox.Text & "',"
            'szDescription
            query = query & "'" & szSubject & "',"
            'gdRequestedTime 
            query = query & "'" & gdCreationTime.ToString("MM/dd/yyyy") & "',"
            'mnOpenDays
            query = query & 0 & ","
            'szAuditUser
            query = query & "'" & Environment.UserName & "',"
            'szLocation
            query = query & "'" & ConectionBox.Text & "',"
            'gdCreationDate
            query = query & "'" & DateTime.Now.ToString("MM/dd/yyyy") & "')"

            Try
                comands = New OleDbCommand(query, conection)
                comands.ExecuteNonQuery()
                result = True
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If

        conection.Close()
        Return result
    End Function

    Private Sub LoadTeamBox()
        Dim query As String = ""
        Dim rows As Integer

        Try
            conection.Open()
            query = ("SELECT * FROM Teams ORDER BY szTeam DESC")
            adapter = New OleDbDataAdapter(query, conection)
            record = New DataSet
            adapter.Fill(record, "Teams")
            rows = record.Tables("Teams").Rows.Count
            If rows <> 0 Then
                For x = 0 To rows - 1
                    TeamBox.Items.Add(record.Tables("Teams").Rows(x).Item("szTeam"))
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        conection.Close()
    End Sub

    Private Sub LoadCategoryBox()
        Dim query As String = ""
        Dim rows As Integer
        Try
            conection.Open()
            query = "SELECT szActivityCode, szActivity FROM TeamsActivities WHERE SubTeam = '" & TeamBox.Text & "' ORDER BY 2 ASC, 1 ASC"
            adapter = New OleDbDataAdapter(query, conection)
            adapter.Fill(record, "TeamsActivities")
            rows = record.Tables("TeamsActivities").Rows.Count
            If rows <> 0 Then
                For x = 0 To rows - 1
                    ActCategoryBox.Items.Add(record.Tables("TeamsActivities").Rows(x).Item("szActivity"))
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        conection.Close()
    End Sub

    Private Sub LoadResponsibleBox()
        Dim query As String = "SELECT TeamResourses.szTeam, TeamResourses.mnResourseID, Resourses.szName FROM Resourses INNER JOIN TeamResourses ON Resourses.ID = TeamResourses.mnResourseID "
        Dim rows As Integer

        Try
            conection.Open()
            query = query & "WHERE TeamResourses.szTeam = '" & TeamBox.Text.ToString & "' ORDER BY 1 ASC, 3 ASC, 2 ASC"
            adapter = New OleDbDataAdapter(query, conection)
            record = New DataSet
            adapter.Fill(record, "TeamResourses")
            rows = record.Tables("TeamResourses").Rows.Count
            If rows <> 0 Then
                For x = 0 To rows - 1
                    ResponsibleBox.Items.Add(record.Tables("TeamResourses").Rows(x).Item("szName"))
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        conection.Close()
    End Sub

    Private Sub RequestorBox_TextChanged(sender As Object, e As EventArgs) Handles RequestorBox.LostFocus
        Dim query As String = ""
        Dim rows As Integer

        If ConectionBox.Text.Length > 0 Then

            Try
                conection.Open()
                query = ("SELECT TOP 1 * FROM Resourses WHERE szName = '" & RequestorBox.Text & "'")
                adapter = New OleDbDataAdapter(query, conection)
                record = New DataSet
                adapter.Fill(record, "Resourses")
                rows = record.Tables("Resourses").Rows.Count
                If rows <> 0 Then
                    RegionBox.Text = record.Tables("Resourses").Rows(0).Item("szRegion")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        conection.Close()
    End Sub

    Private Sub ActivitiesVisualAssistButton_Click(sender As Object, e As EventArgs) Handles ActivitiesVisualAssistButton.Click
        activitiesVisualAssistForm.SetActivitiesTeam(TeamBox.Text)
        activitiesVisualAssistForm.ShowDialog(Me)
        ActCategoryBox.Text = activitiesVisualAssistForm.GetSelectedActivity()
    End Sub

    Private Sub ParseEmail()
        Dim objectType As Object

        OutApp = CreateObject("Outlook.Application")

        'Retrieve active item
        'returns reference to current item, either the one selected (Explorer), or the one currently open (Inspector)
        Select Case True
            Case TypeName(OutApp.ActiveWindow) = "Explorer"
                objectType = OutApp.ActiveExplorer.Selection.Item(1)
                Exit Select
            Case TypeName(OutApp.ActiveWindow) = "Inspector"
                objectType = OutApp.ActiveInspector.CurrentItem
                Exit Select
            Case Else
                objectType = vbObject
        End Select

        'Parse retrieved email
        If TypeName(objectType) = "MailItem" Then
            OutItem = objectType

            'Retrieve default properties
            ResponsibleBox.Text = OutItem.Session.CurrentUser.Name
            RequestorBox.Text = OutItem.SenderName
            gdCreationTime = OutItem.CreationTime
            szSubject = OutItem.Subject

            ''Parse szSubject if already formated
            SubjectFormatted(szSubject)

            'If SubjectFormatted(szSubject) = False Then
            '    'szSubject is not formated
            '    szSubject = OutItem.szSubject
            'End If
        End If
    End Sub

    Private Function SubjectFormatted(ByVal Subject As String) As Boolean
        Dim result As Boolean = False
        Dim auxSubject As String = Subject
        Dim pipeCount As Integer = 0
        Dim mnTicketNumber As Integer = 0

        'Count how many pipes has the subject
        pipeCount = (From character In auxSubject Where character = "|" Select character).Count()

        'If, pipe count is valid
        If 0 < pipeCount < 3 Then
            Try
                'Process Subject Format
                pipeCount = 0
                While (auxSubject.Contains("|") And pipeCount < 3) Or auxSubject.Contains("TK")
                    'Mail szSubject | Ticket Number| Ticket Status
                    Select Case pipeCount
                        Case 0
                            Subject = Microsoft.VisualBasic.Left(auxSubject, auxSubject.IndexOf("|"))
                            auxSubject = auxSubject.Substring(Microsoft.VisualBasic.InStr(auxSubject, " | ") + 3)
                            Exit Select
                        Case 1
                            mnTicketNumber = Convert.ToDouble(auxSubject.Substring(Microsoft.VisualBasic.InStr(auxSubject, "TK") + 1, 10))
                            auxSubject = auxSubject.Substring(Microsoft.VisualBasic.InStr(auxSubject, "TK") + 11)
                            Exit Select
                        Case 2
                            StatusBox.Text = Microsoft.VisualBasic.Right(auxSubject, auxSubject.IndexOf("|"))
                            auxSubject = auxSubject.Substring(Microsoft.VisualBasic.InStr(auxSubject, " | ") + 3)
                            Exit Select
                    End Select

                    pipeCount = pipeCount + 1
                End While

                If pipeCount = 2 Then
                    result = True
                Else
                    TeamBox.Text = ""
                    Subject = OutItem.Subject
                    StatusBox.Text = ""
                End If

            Catch ex As Exception
                TeamBox.Text = ""
                Subject = OutItem.Subject
                StatusBox.Text = ""
            End Try
        End If

        Return result
    End Function

    Private Sub PriorityBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PriorityBox.SelectedIndexChanged
        If PriorityBox.Text <> "" Then
            If PriorityBox.Text = "High" Then
                OutItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh
            ElseIf PriorityBox.Text = "Medium" Then
                OutItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceNormal
            ElseIf PriorityBox.Text = "Medium" Then
                OutItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceLow
            End If
        End If
    End Sub
End Class