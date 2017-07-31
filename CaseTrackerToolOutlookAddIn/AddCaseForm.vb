Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.IO
Imports System.Collections

Public Class AddCaseForm
    Dim OutApp As Outlook.Application
    Dim OutItem As Outlook.MailItem
    Dim myInspector As Outlook.Inspector
    Dim bIsEmail As Boolean = False

    Dim conection As New OleDbConnection
    Dim comands As New OleDbCommand
    Dim adapter As New OleDbDataAdapter
    Dim record As New DataSet

    Dim activitiesVisualAssistForm As New ActivitiesVisualAssistForm

    Dim szActCategoryDescription As String = ""
    Dim szRequestor As String = ""
    Dim szSubject As String = ""
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
        RequestorBox.Items.Clear()
        RegionBox.Clear()
        PendingSrcBox.Clear()
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

        'Set default values
        Dim iSelectionIndex As Integer

        'Status 
        iSelectionIndex = StatusBox.FindString("Open")
        StatusBox.SelectedIndex = iSelectionIndex

        'Priority
        iSelectionIndex = PriorityBox.FindString("Medium")
        PriorityBox.SelectedIndex = iSelectionIndex

        'Date
        DateTimePicker.Enabled = False
        DateTimePicker.Value = Today.Date

        'Quantity
        QuantityBox.Value = 1

        'Disable Fields
        TeamBox.Enabled = False
        ActCategoryBox.Enabled = False
        ResponsibleBox.Enabled = False
        StatusBox.Enabled = False
        PriorityBox.Enabled = False
        RequestorBox.Enabled = False
        RegionBox.Enabled = False
        PendingSrcBox.Enabled = False
        DateTimePicker.Enabled = False
        QuantityBox.Enabled = False
        CommentsBox.Enabled = False
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
        If ActCategoryBox.Text.Trim = "" Then
            MsgBox("Must complete action category", vbExclamation, "Alert")
            Exit Sub
        End If

        If StatusBox.Text.Trim = "" Then
            MsgBox("Must complete status box", vbExclamation, "Alert")
            Exit Sub
        End If

        If PendingSrcBox.Text.Trim = "" And StatusBox.Text = "Open" Then
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
        Dim szIniFilePath As String = "C:\Users\" & Environment.UserName & "\PTT\PTTConfig.ini"
        Dim szHomeConection As String = ""
        Dim szOfficeConection As String = ""

        'Search for INI
        If (File.Exists(szIniFilePath) <> True) Then
            MsgBox("Ini File does not exist", vbExclamation, "Alert")
            Exit Sub
        End If

        'Get Conection Information
        Try
            'Read File
            Dim FileReader As New StreamReader(szIniFilePath)
            Dim szLine As String = ""

            'For each line i find 
            Do
                szLine = FileReader.ReadLine()
                If (Not szLine Is Nothing) Then
                    'Check Provider
                    If szLine.Trim.Contains("OfficeProvider") Then
                        szOfficeConection = "Provider=" & szLine.Substring(Microsoft.VisualBasic.InStr(szLine, "=")).Trim & ";"
                    ElseIf szLine.Trim.Contains("HomeProvider") Then
                        szHomeConection = "Provider=" & szLine.Substring(Microsoft.VisualBasic.InStr(szLine, "=")).Trim & ";"

                        'Check DataSource
                    ElseIf szLine.Trim.Contains("DataBasePath") Then
                        szOfficeConection = szOfficeConection & "Data Source = " & szLine.Substring(Microsoft.VisualBasic.InStr(szLine, "=")).Trim
                    ElseIf szLine.Trim.Contains("DataBaseHomePath") Then
                        szHomeConection = szHomeConection & "Data Source = " & szLine.Substring(Microsoft.VisualBasic.InStr(szLine, "=")).Trim
                    ElseIf szLine.Trim.Contains("HomePrefix") Then
                        mnHomePrefix = szLine.Substring(Microsoft.VisualBasic.InStr(szLine, "=")).Trim
                    End If
                End If
            Loop Until szLine Is Nothing
            FileReader.Close()

        Catch ex As System.Exception
            MsgBox(ex.Message)
        End Try

        'Restart conection if open
        If conection.State = ConnectionState.Open Then
            conection.Close()
        End If

        'Start new conection
        Try
            If ConectionBox.Text = "ACN" Then
                conection.ConnectionString = szOfficeConection
            Else
                conection.ConnectionString = szHomeConection
            End If
        Catch ex As System.Exception
            MsgBox(ex.Message)
        End Try

        'Reaload and enable Teambox
        LoadTeamBox()
        TeamBox.Enabled = True
    End Sub

    Private Sub TeamBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TeamBox.SelectedIndexChanged
        'Reload and enable Activities Box
        LoadCategoryBox()
        ActCategoryBox.Enabled = True
        ActivitiesVisualAssistButton.Enabled = True
    End Sub

    Private Sub ActCategoryBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ActCategoryBox.SelectedIndexChanged
        'Reload and enable Responsible Box
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
        DateTimePicker.Enabled = True
        QuantityBox.Enabled = True
        CommentsBox.Enabled = True
    End Sub

    Private Sub DateTimePicker_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker.ValueChanged
        If DateTimePicker.Value > Today.Date Then
            DateTimePicker.Value = Today.Date
            MsgBox("Cannot select a future date", vbExclamation, "Alert")
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
            query = "INSERT INTO Tickets(mnTicketNumber, mnTicketLineNumber, szTeam, szActivityCategory, szResponsible, szStatus, szPriority,szRequestor, szBusinessUnit, szPendingSource, gdOpenDate, gdCloseDate, szComments, szDescription, gdRequestedTime, mnOpenDays, szAuditUser, szLocation, gdCreationDate, mnQuantity)"
            query = query & "VALUES("
            'mnTicketNumber
            query = query & NextNumber & ","
            'mnTicketLineNumber (First line start with 0)
            query = query & 0 & ","
            'szTeam
            query = query & "'" & ReplaceApostrophesInString(TeamBox.Text) & "',"
            'szActivityCategory
            query = query & "'" & ReplaceApostrophesInString(ActCategoryBox.Text) & "',"
            'szResponsible
            query = query & "'" & ReplaceApostrophesInString(ResponsibleBox.Text) & "',"
            'szStatus
            query = query & "'" & ReplaceApostrophesInString(StatusBox.Text) & "',"
            'szPriority
            query = query & "'" & ReplaceApostrophesInString(PriorityBox.Text) & "',"
            'szRequestor
            query = query & "'" & ReplaceApostrophesInString(RequestorBox.Text) & "',"
            'szBusinessUnit
            query = query & "'" & ReplaceApostrophesInString(RegionBox.Text) & "',"
            'szPendingSource
            If StatusBox.Text <> "Close" Then
                query = query & "'" & ReplaceApostrophesInString(PendingSrcBox.Text) & "',"
            Else
                query = query & "'',"
            End If
            'gdOpenDate
            query = query & "'" & Convert.ToString(DateTimePicker.Value) & "',"
            'gdCloseDate
            If StatusBox.Text = "Close" Then
                query = query & "'" & Convert.ToString(DateTimePicker.Value) & "',"
            Else
                query = query & "'" & DBNull.Value & "',"
            End If
            'szComments
            query = query & "'" & ReplaceApostrophesInString(CommentsBox.Text) & "',"
            'szDescription
            query = query & "'" & ReplaceApostrophesInString(szSubject) & "',"
            'gdRequestedTime 
            query = query & "'" & gdCreationTime.ToString("MM/DD/YYYY") & "',"
            'mnOpenDays
            query = query & 0 & ","
            'szAuditUser
            query = query & "'" & ReplaceApostrophesInString(Environment.UserName) & "',"
            'szLocation
            query = query & "'" & ReplaceApostrophesInString(ConectionBox.Text) & "',"
            'gdCreationDate
            query = query & "'" & DateTime.Now.ToString("MM/DD/YYYY") & "',"
            'mnQuantity
            query = query & QuantityBox.Value & ")"

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
        Dim rows As Integer = 0
        Dim szPreviousTeam As String = ""
        Dim iSelectionIndex As Integer = 0

        'Save Previous Selection
        If (TeamBox.Text.Trim).Length > 0 Then
            szPreviousTeam = TeamBox.Text
        Else
            'Not override on default value
            If Not String.IsNullOrEmpty(ConectionBox.Text) Then
                szPreviousTeam = ""
            End If
        End If

        'Clear Teambox
        TeamBox.Items.Clear()
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

        'Reselect Previous Value
        If (szPreviousTeam.Trim).Length > 0 Then
            iSelectionIndex = StatusBox.FindString(szPreviousTeam)
        Else
            iSelectionIndex = -1
        End If
        TeamBox.SelectedIndex = iSelectionIndex
    End Sub

    Private Sub LoadCategoryBox()
        Dim query As String = ""
        Dim rows As Integer
        Dim szPreviousCategory As String = ""
        Dim iSelectionIndex As Integer = 0

        'Save Previous Selection
        If (ActCategoryBox.Text.Trim).Length > 0 Then
            szPreviousCategory = ActCategoryBox.Text
        Else
            'Not override on default value
            If Not String.IsNullOrEmpty(ConectionBox.Text) Then
                szPreviousCategory = ""
            End If
        End If

        'Clear CategoryBox
        ActCategoryBox.Items.Clear()
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

        'Reselect Previous Value
        If (szPreviousCategory.Trim).Length > 0 Then
            iSelectionIndex = ActCategoryBox.FindString(szPreviousCategory)
        Else
            iSelectionIndex = -1
        End If
        ActCategoryBox.SelectedIndex = iSelectionIndex
    End Sub

    Private Sub LoadResponsibleBox()
        Dim query As String = "SELECT TeamResourses.szTeam, TeamResourses.mnResourseID, Resourses.szName FROM Resourses INNER JOIN TeamResourses ON Resourses.ID = TeamResourses.mnResourseID "
        Dim rows As Integer
        Dim szPreviousResponsible As String = ""
        Dim iSelectionIndex As Integer = 0

        'Save Previous Selection
        If (ResponsibleBox.Text.Trim).Length > 0 Then
            szPreviousResponsible = ResponsibleBox.Text
        Else
            'Not override on default value
            If Not String.IsNullOrEmpty(ConectionBox.Text) Then
                szPreviousResponsible = ""
            End If
        End If

        'Clear Responsible
        ResponsibleBox.Items.Clear()
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

        'Reselect Previous Value
        If (szPreviousResponsible.Trim).Length > 0 Then
            iSelectionIndex = ResponsibleBox.FindString(szPreviousResponsible)
        Else
            iSelectionIndex = -1
        End If
        ResponsibleBox.SelectedIndex = iSelectionIndex
    End Sub

    Private Sub LoadRequestorBox()
        Dim szParsingString As String = ""
        Dim szPreviousRequestor As String = ""
        Dim iSelectionIndex As Integer = -1

        'Save Previous Selection
        If (RequestorBox.Text.Trim).Length > 0 Then
            szPreviousRequestor = RequestorBox.Text
        Else
            'Not override on default value
            If Not String.IsNullOrEmpty(ConectionBox.Text) Then
                szPreviousRequestor = ""
            End If
        End If

        RequestorBox.Items.Clear()

        'Retrieve "From" text and set as default
        Try
            If (OutItem.SentOnBehalfOfName.Trim).Length > 0 Then
                RequestorBox.Items.Add(OutItem.SentOnBehalfOfName.Trim)
                iSelectionIndex = RequestorBox.FindString(OutItem.SentOnBehalfOfName.Trim)
            Else
                If (OutItem.SendUsingAccount.UserName.Trim).Length > 0 Then
                    RequestorBox.Items.Add(OutItem.SendUsingAccount.UserName)
                    iSelectionIndex = RequestorBox.FindString(OutItem.SendUsingAccount.UserName)
                Else
                    iSelectionIndex = -1
                End If
            End If

            'Not override on default value
            If String.IsNullOrEmpty(szPreviousRequestor) Then
                RequestorBox.SelectedIndex = iSelectionIndex
            End If

        Catch
            'No "From" information
        End Try

        'Retrieve "To"
        Try
            szParsingString = OutItem.To.Trim
            If szParsingString.Length > 1 Then
                szParsingString = szParsingString & ";"
                While (szParsingString.Contains(";"))
                    RequestorBox.Items.Add(szParsingString.Substring(0, Microsoft.VisualBasic.InStr(szParsingString, ";") - 1))
                    szParsingString = (szParsingString.Substring(Microsoft.VisualBasic.InStr(szParsingString, ";"))).Trim
                End While
            End If
        Catch
            'No "To" information
        End Try

        'Retrieve "CC"
        Try
            szParsingString = OutItem.CC.Trim
            If szParsingString.Length > 1 Then
                szParsingString = szParsingString & ";"
                While (szParsingString.Contains(";"))
                    RequestorBox.Items.Add(szParsingString.Substring(0, Microsoft.VisualBasic.InStr(szParsingString, ";") - 1))
                    szParsingString = (szParsingString.Substring(Microsoft.VisualBasic.InStr(szParsingString, ";"))).Trim
                End While
            End If
        Catch
            'No "CC information
        End Try

        'Reselect Previous Value
        If (szPreviousRequestor.Trim).Length > 0 Then
            iSelectionIndex = RequestorBox.FindString(szPreviousRequestor)
        End If
        RequestorBox.SelectedIndex = iSelectionIndex

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
            gdCreationTime = OutItem.CreationTime
            szSubject = OutItem.Subject

            'Retrieve responsible
            Dim iSelectionIndex As Integer
            ResponsibleBox.Items.Add(OutItem.Session.CurrentUser.Name)
            iSelectionIndex = ResponsibleBox.FindString(OutItem.Session.CurrentUser.Name)
            ResponsibleBox.SelectedIndex = iSelectionIndex

            'Load Requestor with "From", "To", "CC"
            LoadRequestorBox()

            'Parse szSubject if already formated
            If SubjectFormatted(szSubject) = False Then
                'szSubject is not formated
                szSubject = OutItem.Subject
            End If
        End If
    End Sub

    Private Function SubjectFormatted(ByVal Subject As String) As Boolean
        Dim result As Boolean = False
        Dim auxSubject As String = Subject
        Dim pipeCount As Integer = 0
        Dim mnTicketNumber As Integer = 0

        'Count how many pipes has the subject
        Try
            pipeCount = (From character In auxSubject Where character = "|" Select character).Count()
        Catch ex As Exception
            pipeCount = 0
        End Try

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

    Private Function ReplaceApostrophesInString(szString As String) As String
        Dim cSpecialCharacter As String = "'"
        Dim cNewCharacter As String = " "
        Return szString.Replace(cSpecialCharacter, cNewCharacter)
    End Function

    Private Sub QuantityBox_ValueChanged(sender As Object, e As EventArgs) Handles QuantityBox.ValueChanged
        If QuantityBox.Value <= 0 Then
            QuantityBox.Value = 1
            MsgBox("Cannot select negative quantity", vbExclamation, "Alert")
        End If
    End Sub
End Class