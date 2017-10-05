Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.IO
Imports System.Collections
Imports Microsoft.Office.Interop.Outlook

Public Class AddCaseForm
    Dim OutApp As Outlook.Application
    Dim OutItem As Outlook.MailItem
    Dim myInspector As Outlook.Inspector
    Dim bAssociatedEmail As Boolean = False
    Dim szConversationID As String = ""

    Dim conection As New OleDbConnection
    Dim comands As New OleDbCommand
    Dim adapter As New OleDbDataAdapter
    Dim record As New DataSet

    Dim activitiesVisualAssistForm As New ActivitiesVisualAssistForm

    Dim szActCategoryDescription As String = ""
    Dim szRequestor As String = ""
    Dim szSubject As String = ""
    Dim gdCreationTime As Date = DateTime.Today

    Dim mnHomePrefix As Integer = 0
    Dim szDateTimeFormat As String = ""

    'Form Activities
    Public Sub NewCaseForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '****************************
        'Enable Fields
        '****************************
        ConectionBox.Enabled = True

        '****************************
        'Clear Options
        '****************************
        TeamBox.Items.Clear()
        ActCategoryBox.Items.Clear()
        ResponsibleBox.Items.Clear()
        StatusBox.Items.Clear()
        PriorityBox.Items.Clear()
        RequestorBox.Items.Clear()
        RegionBox.Clear()
        PendingSrcBox.Clear()
        CommentsBox.Clear()

        '****************************
        'Load Drop Down Lists
        '****************************
        'ConectionBox
        ConectionBox.Items.Add("ACN")
        ConectionBox.Items.Add("Home - Office")
        'StatusBox
        StatusBox.Items.Add("Close")
        StatusBox.Items.Add("Open")
        'PriorityBox
        PriorityBox.Items.Add("High")
        PriorityBox.Items.Add("Medium")
        PriorityBox.Items.Add("Low")

        '****************************
        'Set default values
        '****************************
        Dim mnSelectionIndex As Integer
        'Status 
        mnSelectionIndex = StatusBox.FindString("Open")
        StatusBox.SelectedIndex = mnSelectionIndex
        'Priority
        mnSelectionIndex = PriorityBox.FindString("Medium")
        PriorityBox.SelectedIndex = mnSelectionIndex
        'Date
        DateTimePicker.Value = DateTime.Today
        'Quantity
        QuantityBox.Value = 1

        '****************************
        'Disable Fields
        '****************************
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

    'Button Activities
    Private Sub CreateCaseButton_Click(sender As Object, e As EventArgs) Handles CreateCaseButton.Click
        Dim mnNextNumber As Long = 0

        '****************************
        'Validate required fields
        '****************************
        If String.IsNullOrEmpty(ActCategoryBox.Text.Trim) Then
            MsgBox("Must complete action category", vbExclamation, "Alert")
            Exit Sub
        End If

        If String.IsNullOrEmpty(StatusBox.Text.Trim) Then
            MsgBox("Must complete status box", vbExclamation, "Alert")
            Exit Sub
        End If

        If String.IsNullOrEmpty(PendingSrcBox.Text.Trim) And StatusBox.Text = "Open" Then
            MsgBox("Must complete pending source", vbExclamation, "Alert")
            Exit Sub
        End If

        '****************************
        'Perform Insert
        '****************************
        If InsertTicket(mnNextNumber) Then

            'If ticket is associated to an email
            If bAssociatedEmail = True Then
                '****************************
                'Change mail status 
                '****************************
                'Mail szSubject | Ticket Number| Ticket Status
                szSubject = szSubject & " | TK"
                szSubject = szSubject & Convert.ToString(mnNextNumber).PadLeft(10, "0")
                If StatusBox.Text <> "Open" Then
                    szSubject = szSubject & " | " & StatusBox.Text
                End If

                OutItem.Subject = szSubject
                OutItem.Save()
            End If

            'Notify TK number
            MsgBox("Ticket " & mnNextNumber & " created", vbExclamation, "Alert")
        Else
            'Transaction error
            MsgBox("Creation Failed", vbExclamation, "Alert")
        End If
        Me.Close()
    End Sub

    Private Sub ActivitiesVisualAssistButton_Click(sender As Object, e As EventArgs) Handles ActivitiesVisualAssistButton.Click
        If Not String.IsNullOrEmpty(TeamBox.Text.Trim) Then
            If activitiesVisualAssistForm.SetConection(ConectionBox.Text) Then
                If activitiesVisualAssistForm.SetActivitiesTeam(TeamBox.Text) Then
                    activitiesVisualAssistForm.ShowDialog(Me)
                    ActCategoryBox.Text = activitiesVisualAssistForm.GetSelectedActivity()
                Else
                    MsgBox("Please select a valid team", vbExclamation, "Alert")
                    Exit Sub
                End If
            Else
                MsgBox("Please select a valid conection", vbExclamation, "Alert")
                Exit Sub
            End If
        End If
    End Sub

    'Field Validation
    Public Sub ConectionBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ConectionBox.SelectedIndexChanged
        Dim szIniFilePath As String = "C:\Users\" & Environment.UserName & "\PTT\PTTConfig.ini"
        Dim szHomeConection As String = ""
        Dim szOfficeConection As String = ""
        Dim mnSelectionIndex As Integer

        '****************************
        'Validate selected index
        '****************************
        mnSelectionIndex = ConectionBox.FindString(ConectionBox.Text.Trim)
        If mnSelectionIndex < 0 Then
            'Invalid Selection

            '****************************
            'Set default values
            '****************************
            'Status 
            mnSelectionIndex = StatusBox.FindString("Open")
            StatusBox.SelectedIndex = mnSelectionIndex
            'Priority
            mnSelectionIndex = PriorityBox.FindString("Medium")
            PriorityBox.SelectedIndex = mnSelectionIndex
            'Date
            DateTimePicker.Value = DateTime.Today
            'Quantity
            QuantityBox.Value = 1

            '****************************
            'Disable Fields/Buttons
            '****************************
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
            ActivitiesVisualAssistButton.Enabled = False

            ConectionBox.Focus()
            MsgBox("Please select a valid conection", vbExclamation, "Alert")
            Exit Sub
        End If

        '****************************
        'Search and parse INI
        '****************************
        If (File.Exists(szIniFilePath) <> True) Then
            MsgBox("Ini File does not exist", vbExclamation, "Alert")
            Exit Sub
        End If

        'Get INI Information
        Try
            'Read File
            Dim FileReader As New StreamReader(szIniFilePath)
            Dim szLine As String = ""

            'Process every line in INI file
            szLine = FileReader.ReadLine()
            'Line must have value
            While Not szLine Is Nothing
                'Dismiss comment lines
                If Not szLine.Contains(";") Then
                        Select Case True
                        'Provider
                            Case szLine.Trim.Contains("OfficeProvider")
                                szOfficeConection = "Provider=" & szLine.Substring(Microsoft.VisualBasic.InStr(szLine, "=")).Trim & ";"
                                Exit Select
                            Case szLine.Trim.Contains("HomeProvider")
                                szHomeConection = "Provider=" & szLine.Substring(Microsoft.VisualBasic.InStr(szLine, "=")).Trim & ";"
                                Exit Select
                            'DataSource
                            Case szLine.Trim.Contains("DataBasePath")
                                szOfficeConection = szOfficeConection & "Data Source = " & szLine.Substring(Microsoft.VisualBasic.InStr(szLine, "=")).Trim
                                Exit Select
                            Case szLine.Trim.Contains("DataBaseHomePath")
                                szHomeConection = szHomeConection & "Data Source = " & szLine.Substring(Microsoft.VisualBasic.InStr(szLine, "=")).Trim
                                Exit Select
                            'HomePrefix
                            Case szLine.Trim.Contains("HomePrefix")
                                mnHomePrefix = szLine.Substring(Microsoft.VisualBasic.InStr(szLine, "=")).Trim
                                Exit Select
                            'DateTimeFormat
                            Case szLine.Trim.Contains("DateTimeFormat")
                                szDateTimeFormat = szLine.Substring(Microsoft.VisualBasic.InStr(szLine, "=")).Trim
                                Exit Select
                            Case Else
                                Exit Select
                        End Select
                    End If
                    szLine = FileReader.ReadLine()
            End While
            FileReader.Close()

            'Close conection if open
            If conection.State = ConnectionState.Open Then
                conection.Close()
            End If

            'Configurate new conection
            If ConectionBox.Text = "ACN" Then
                conection.ConnectionString = szOfficeConection
            Else
                conection.ConnectionString = szHomeConection
            End If
        Catch ex As System.Exception
            MsgBox(ex.Message)
        End Try

        '****************************
        'Validate selected index
        '****************************
        'Update if inconsistent
        If ConectionBox.SelectedIndex <> mnSelectionIndex Then
            ConectionBox.SelectedIndex = mnSelectionIndex
        End If

        '****************************
        'Validation Succeed
        '****************************
        'Parse Email
        ParseEmail()

        'Reaload and enable Teambox
        LoadTeamBox()
        TeamBox.Enabled = True
        TeamBox.Focus()
    End Sub

    Private Sub TeamBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TeamBox.SelectedIndexChanged
        Dim mnSelectionIndex As Integer

        '****************************
        'Validate required fields
        '****************************
        If String.IsNullOrEmpty(ConectionBox.Text.Trim) Then
            ConectionBox.Focus()
            MsgBox("Must select a conection", vbExclamation, "Alert")
            Exit Sub
        End If

        '****************************
        'Validate selected index
        '****************************
        mnSelectionIndex = TeamBox.FindString(TeamBox.Text.Trim)
        If mnSelectionIndex < 0 Then
            'Invalid Selection

            '****************************
            'Set default values
            '****************************
            'Status 
            mnSelectionIndex = StatusBox.FindString("Open")
            StatusBox.SelectedIndex = mnSelectionIndex
            'Priority
            mnSelectionIndex = PriorityBox.FindString("Medium")
            PriorityBox.SelectedIndex = mnSelectionIndex
            'Date
            DateTimePicker.Value = DateTime.Today
            'Quantity
            QuantityBox.Value = 1

            '****************************
            'Disable Fields/Buttons
            '****************************
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
            ActivitiesVisualAssistButton.Enabled = False

            TeamBox.Focus()
            MsgBox("Please select a valid team", vbExclamation, "Alert")
            Exit Sub
        End If

        'Update if inconsistent
        If TeamBox.SelectedIndex <> mnSelectionIndex Then
            TeamBox.SelectedIndex = mnSelectionIndex
        End If

        '****************************
        'Validation Succeed
        '****************************
        'Reload and enable Activities Box
        LoadCategoryBox()
        ActCategoryBox.Enabled = True
        ActivitiesVisualAssistButton.Enabled = True
    End Sub

    Private Sub ActCategoryBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ActCategoryBox.SelectedIndexChanged
        Dim mnSelectionIndex As Integer

        '****************************
        'Validate required fields
        '****************************
        If String.IsNullOrEmpty(ConectionBox.Text.Trim) Then
            ConectionBox.Focus()
            MsgBox("Must select a conection", vbExclamation, "Alert")
            Exit Sub
        End If

        If String.IsNullOrEmpty(TeamBox.Text.Trim) And TeamBox.Items.Count <> 0 Then
            TeamBox.Focus()
            MsgBox("Must select a team", vbExclamation, "Alert")
            Exit Sub
        End If

        '****************************
        'Validate selected index
        '****************************
        mnSelectionIndex = ActCategoryBox.FindString(ActCategoryBox.Text.Trim)
        If mnSelectionIndex < 0 Then
            'Invalid Selection

            '****************************
            'Set default values
            '****************************
            'Status 
            mnSelectionIndex = StatusBox.FindString("Open")
            StatusBox.SelectedIndex = mnSelectionIndex
            'Priority
            mnSelectionIndex = PriorityBox.FindString("Medium")
            PriorityBox.SelectedIndex = mnSelectionIndex
            'Date
            DateTimePicker.Value = DateTime.Today
            'Quantity
            QuantityBox.Value = 1

            '****************************
            'Disable Fields/Buttons
            '****************************
            ResponsibleBox.Enabled = False
            StatusBox.Enabled = False
            PriorityBox.Enabled = False
            RequestorBox.Enabled = False
            RegionBox.Enabled = False
            PendingSrcBox.Enabled = False
            DateTimePicker.Enabled = False
            QuantityBox.Enabled = False
            CommentsBox.Enabled = False

            ActCategoryBox.Focus()
            MsgBox("Please select a valid category", vbExclamation, "Alert")
            Exit Sub
        End If

        'Update if inconsistent
        If ActCategoryBox.SelectedIndex <> mnSelectionIndex Then
            ActCategoryBox.SelectedIndex = mnSelectionIndex
        End If

        '****************************
        'Validation Succeed
        '****************************
        If Not String.IsNullOrEmpty(ConectionBox.Text.Trim) And Not String.IsNullOrEmpty(TeamBox.Text.Trim) And Not String.IsNullOrEmpty(ActCategoryBox.Text.Trim) Then
            'Reload and enable Responsible Box
            LoadResponsibleBox()
            ResponsibleBox.Enabled = True
        End If
    End Sub

    Private Sub ResponsibleBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ResponsibleBox.SelectedIndexChanged
        Dim mnSelectionIndex As Integer

        '****************************
        'Validate required fields
        '****************************
        If String.IsNullOrEmpty(ConectionBox.Text.Trim) Then
            ConectionBox.Focus()
            MsgBox("Must select a conection", vbExclamation, "Alert")
            Exit Sub
        End If

        If String.IsNullOrEmpty(TeamBox.Text.Trim) And TeamBox.Items.Count <> 0 Then
            TeamBox.Focus()
            MsgBox("Must select a team", vbExclamation, "Alert")
            Exit Sub
        End If

        If String.IsNullOrEmpty(ActCategoryBox.Text.Trim) And ActCategoryBox.Items.Count <> 0 Then
            ActCategoryBox.Focus()
            MsgBox("Must select a category", vbExclamation, "Alert")
            Exit Sub
        End If

        '****************************
        'Validate selected index
        '****************************
        mnSelectionIndex = ResponsibleBox.FindString(ResponsibleBox.Text.Trim)
        If mnSelectionIndex < 0 Then
            'Invalid Selection

            '****************************
            'Set default values
            '****************************
            'Status 
            mnSelectionIndex = StatusBox.FindString("Open")
            StatusBox.SelectedIndex = mnSelectionIndex
            'Priority
            mnSelectionIndex = PriorityBox.FindString("Medium")
            PriorityBox.SelectedIndex = mnSelectionIndex
            'Date
            DateTimePicker.Value = DateTime.Today
            'Quantity
            QuantityBox.Value = 1

            '****************************
            'Disable Fields
            '****************************
            StatusBox.Enabled = False
            PriorityBox.Enabled = False
            RequestorBox.Enabled = False
            RegionBox.Enabled = False
            PendingSrcBox.Enabled = False
            DateTimePicker.Enabled = False
            QuantityBox.Enabled = False
            CommentsBox.Enabled = False

            ResponsibleBox.Focus()
            MsgBox("Please select a valid responsible", vbExclamation, "Alert")
            Exit Sub
        End If

        'Update if inconsistent
        If ResponsibleBox.SelectedIndex <> mnSelectionIndex Then
            ResponsibleBox.SelectedIndex = mnSelectionIndex
        End If

        '****************************
        'Validation Succeed
        '****************************
        If Not String.IsNullOrEmpty(ConectionBox.Text.Trim) And Not String.IsNullOrEmpty(TeamBox.Text.Trim) And Not String.IsNullOrEmpty(ActCategoryBox.Text.Trim) Then
            'Enable fields
            StatusBox.Enabled = True
            PriorityBox.Enabled = True
            RequestorBox.Enabled = True
            RegionBox.Enabled = True
            PendingSrcBox.Enabled = True
            DateTimePicker.Enabled = True
            QuantityBox.Enabled = True
            CommentsBox.Enabled = True
        End If
    End Sub

    Private Sub StatusBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles StatusBox.SelectedIndexChanged
        Dim mnSelectionIndex As Integer

        '****************************
        'Validate selected index
        '****************************
        mnSelectionIndex = StatusBox.FindString(StatusBox.Text.Trim)
        If mnSelectionIndex < 0 Then
            'Invalid Selection

            '****************************
            'Set default values
            '****************************
            'Status 
            mnSelectionIndex = StatusBox.FindString("Open")
            StatusBox.SelectedIndex = mnSelectionIndex

            StatusBox.Focus()
            MsgBox("Please select a valid status", vbExclamation, "Alert")
            Exit Sub
        End If

        'Update if inconsistent
        If StatusBox.SelectedIndex <> mnSelectionIndex Then
            StatusBox.SelectedIndex = mnSelectionIndex
        End If
    End Sub

    Private Sub PriorityBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PriorityBox.SelectedIndexChanged
        Dim mnSelectionIndex As Integer

        '****************************
        'Validate selected index
        '****************************
        mnSelectionIndex = PriorityBox.FindString(PriorityBox.Text)
        If mnSelectionIndex < 0 Then
            'Invalid Selection

            '****************************
            'Set default values
            '****************************
            'Priority
            mnSelectionIndex = PriorityBox.FindString("Medium")
            PriorityBox.SelectedIndex = mnSelectionIndex

            PriorityBox.Focus()
            MsgBox("Please select a valid priority", vbExclamation, "Alert")
            Exit Sub
        End If

        'Update if inconsistent
        If PriorityBox.SelectedIndex <> mnSelectionIndex Then
            PriorityBox.SelectedIndex = mnSelectionIndex
        End If

        '****************************
        'Validation Succeed
        '****************************
        'If there is an associated email, update priority
        If PriorityBox.Text <> "" And bAssociatedEmail = True Then
            If PriorityBox.Text = "High" Then
                OutItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh
            ElseIf PriorityBox.Text = "Medium" Then
                OutItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceNormal
            ElseIf PriorityBox.Text = "Medium" Then
                OutItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceLow
            End If
        End If
    End Sub

    Private Sub RequestorBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RequestorBox.SelectedIndexChanged
        Dim szQuery As String = ""
        Dim mnRows As Integer

        '****************************
        'Validate required fields
        '****************************
        If String.IsNullOrEmpty(ConectionBox.Text.Trim) Then
            ConectionBox.Focus()
            MsgBox("Must select a conection", vbExclamation, "Alert")
            Exit Sub
        End If

        Try
            '****************************
            'Format query
            '****************************
            szQuery = ("SELECT TOP 1 * FROM Resourses WHERE szName = '" & RequestorBox.Text.Trim & "'")

            '****************************
            'Perform query
            '****************************
            conection.Open()
            adapter = New OleDbDataAdapter(szQuery, conection)
            record = New DataSet
            conection.Close()

            '****************************
            'Process retrieved data
            '****************************
            adapter.Fill(record, "Resourses")
            mnRows = record.Tables("Resourses").Rows.Count
            If mnRows <> 0 Then
                RegionBox.Text = record.Tables("Resourses").Rows(0).Item("szRegion")
            End If

        Catch ex As System.Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub PendingSrcBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PendingSrcBox.LostFocus
        'Dim NewMessage As Outlook.MailItem
        'Dim myRecipients As Outlook.Recipients

        'Dim oDialog As SelectNamesDialog
        'Dim oAL As AddressList
        'Dim oContacts As Folder

        'oDialog = OutApp.Session.GetSelectNamesDialog
        'oContacts = OutApp.Session.GetDefaultFolder(OlDefaultFolders.olFolderContacts)

        ''Look for the address list that corresponds with the Contacts folder 
        'For Each oAL In OutApp.Session.AddressLists
        '    If oAL.GetContactsFolder Is oContacts Then
        '        Exit For
        '    End If
        'Next

        'With oDialog
        '    'Initialize the dialog box with the address list representing the Contacts folder 
        '    .InitialAddressList = oAL
        '    .ShowOnlyInitialAddressList = True
        '    If .Display Then
        '        'Recipients Resolved 
        '        'Access Recipients using oDialog.Recipients 
        '    End If
        'End With


        ''****************************
        ''Validate selected index
        ''****************************
        'PendingSrcBox.Text = PendingSrcBox.Text.Trim
        'NewMessage = OutApp.CreateItem(OlItemType.olMailItem)
        'myRecipients = OutItem.Recipients
        ''Search for recepients email
        'myRecipients.Add(PendingSrcBox.Text)
        'If Not myRecipients.ResolveAll Then
        '    'Not valid name 
        '    MsgBox("Not valid pending source name", vbExclamation, "Alert")
        '    Exit Sub
        'End If

    End Sub

    Private Sub DateTimePicker_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DateTimePicker.LostFocus
        If DateTimePicker.Value.ToString(szDateTimeFormat) > DateTime.Today.ToString(szDateTimeFormat) Then
            DateTimePicker.Value = DateTime.Today
            MsgBox("Cannot select a future date", vbExclamation, "Alert")
        End If
    End Sub

    Private Sub QuantityBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles QuantityBox.LostFocus
        If QuantityBox.Value <= 0 Then
            QuantityBox.Value = 1
            MsgBox("Cannot select negative quantity", vbExclamation, "Alert")
        End If
    End Sub

    'Load Drop Down Lists
    Private Sub LoadTeamBox()
        Dim szQuery As String = ""
        Dim mnRows As Integer = 0
        Dim szPreviousTeam As String = ""
        Dim mnSelectionIndex As Integer = -1

        'Save Previous Selection
        If Not String.IsNullOrEmpty(TeamBox.Text.Trim) Then
            szPreviousTeam = TeamBox.Text
        Else
            'Not override on default value
            If Not String.IsNullOrEmpty(ConectionBox.Text.Trim) Then
                szPreviousTeam = ""
            End If
        End If

        'Clear Teambox
        TeamBox.Text = ""
        TeamBox.Items.Clear()
        Try
            conection.Open()
            szQuery = ("SELECT * FROM Teams ORDER BY szTeam ASC")
            adapter = New OleDbDataAdapter(szQuery, conection)
            record = New DataSet
            adapter.Fill(record, "Teams")
            mnRows = record.Tables("Teams").Rows.Count
            If mnRows <> 0 Then
                For x = 0 To mnRows - 1
                    TeamBox.Items.Add(record.Tables("Teams").Rows(x).Item("szTeam"))
                Next
            End If
        Catch ex As System.Exception
            MsgBox(ex.Message)
        End Try

        conection.Close()

        'Reselect Previous Value
        If Not String.IsNullOrEmpty(szPreviousTeam.Trim) Then
            mnSelectionIndex = StatusBox.FindString(szPreviousTeam)
        Else
            mnSelectionIndex = -1
        End If
        TeamBox.SelectedIndex = mnSelectionIndex
    End Sub

    Private Sub LoadCategoryBox()
        Dim szQuery As String = ""
        Dim mnRows As Integer
        Dim szPreviousCategory As String = ""
        Dim mnSelectionIndex As Integer = -1

        'Save Previous Selection
        If Not String.IsNullOrEmpty(ActCategoryBox.Text.Trim) Then
            szPreviousCategory = ActCategoryBox.Text
        Else
            'Not override on default value
            If Not String.IsNullOrEmpty(ConectionBox.Text.Trim) Then
                szPreviousCategory = ""
            End If
        End If

        'Clear CategoryBox
        ActCategoryBox.Text = ""
        ActCategoryBox.Items.Clear()
        Try
            conection.Open()
            szQuery = "SELECT szActivityCode, szActivity FROM TeamsActivities WHERE szSubTeam = '" & TeamBox.Text.Trim & "' ORDER BY 2 ASC, 1 ASC"
            adapter = New OleDbDataAdapter(szQuery, conection)
            adapter.Fill(record, "TeamsActivities")
            mnRows = record.Tables("TeamsActivities").Rows.Count
            If mnRows <> 0 Then
                For x = 0 To mnRows - 1
                    ActCategoryBox.Items.Add(record.Tables("TeamsActivities").Rows(x).Item("szActivity"))
                Next
            End If
        Catch ex As System.Exception
            MsgBox(ex.Message)
        End Try

        conection.Close()

        'Reselect Previous Value
        If (szPreviousCategory.Trim).Length > 0 Then
            mnSelectionIndex = ActCategoryBox.FindString(szPreviousCategory)
        Else
            mnSelectionIndex = -1
        End If
        ActCategoryBox.SelectedIndex = mnSelectionIndex
    End Sub

    Private Sub LoadResponsibleBox()
        Dim szQuery As String = "SELECT TeamResourses.szTeam, TeamResourses.mnResourseID, Resourses.szName FROM Resourses INNER JOIN TeamResourses ON Resourses.ID = TeamResourses.mnResourseID "
        Dim mnRows As Integer
        Dim szPreviousResponsible As String = ""
        Dim mnSelectionIndex As Integer = -1

        'Save Previous Selection
        If Not String.IsNullOrEmpty(ResponsibleBox.Text.Trim) Then
            szPreviousResponsible = ResponsibleBox.Text
        Else
            'Not override on default value
            If Not String.IsNullOrEmpty(ConectionBox.Text.Trim) Then
                szPreviousResponsible = ""
            End If
        End If

        'Clear Responsible
        ResponsibleBox.Text = ""
        ResponsibleBox.Items.Clear()
        Try
            conection.Open()
            szQuery = szQuery & "WHERE TeamResourses.szTeam = '" & TeamBox.Text.Trim & "' ORDER BY 1 ASC, 3 ASC, 2 ASC"
            adapter = New OleDbDataAdapter(szQuery, conection)
            record = New DataSet
            adapter.Fill(record, "TeamResourses")
            mnRows = record.Tables("TeamResourses").Rows.Count
            If mnRows <> 0 Then
                For x = 0 To mnRows - 1
                    ResponsibleBox.Items.Add(record.Tables("TeamResourses").Rows(x).Item("szName"))
                Next
            End If
        Catch ex As System.Exception
            MsgBox(ex.Message)
        End Try

        conection.Close()

        'Reselect Previous Value
        If (szPreviousResponsible.Trim).Length > 0 Then
            mnSelectionIndex = ResponsibleBox.FindString(szPreviousResponsible)
        Else
            mnSelectionIndex = -1
        End If
        ResponsibleBox.SelectedIndex = mnSelectionIndex
    End Sub

    Private Sub LoadRequestorBox()
        Dim szParsingString As String = ""
        Dim szPreviousRequestor As String = ""
        Dim mnSelectionIndex As Integer = -1

        'Save Previous Selection
        If Not String.IsNullOrEmpty(RequestorBox.Text.Trim) Then
            szPreviousRequestor = RequestorBox.Text
        Else
            'Not override on default value
            If Not String.IsNullOrEmpty(ConectionBox.Text.Trim) Then
                szPreviousRequestor = ""
            End If
        End If

        RequestorBox.Text = ""
        RequestorBox.Items.Clear()

        'If ticket does not have an associated email
        If bAssociatedEmail <> True Then
            RequestorBox.Items.Add(Environment.UserName)
            mnSelectionIndex = PriorityBox.FindString(Environment.UserName)
            RequestorBox.SelectedIndex = mnSelectionIndex
            Exit Sub
        End If

        'Retrieve "From" text and set as default
        Try
            If (OutItem.SentOnBehalfOfName.Trim).Length > 0 Then
                If (OutItem.SentOnBehalfOfName.Trim).Contains("(") Then
                    RequestorBox.Items.Add((OutItem.SentOnBehalfOfName.Trim.Substring(0, Microsoft.VisualBasic.InStr(OutItem.SentOnBehalfOfName.Trim, "(") - 1)).Trim)
                Else
                    RequestorBox.Items.Add(OutItem.SentOnBehalfOfName.Trim)
                End If

                mnSelectionIndex = RequestorBox.FindString(OutItem.SentOnBehalfOfName.Trim)
            Else
                If (OutItem.SendUsingAccount.UserName.Trim).Length > 0 Then
                    RequestorBox.Items.Add(OutItem.SendUsingAccount.UserName)
                    mnSelectionIndex = RequestorBox.FindString(OutItem.SendUsingAccount.UserName)
                Else
                    mnSelectionIndex = -1
                End If
            End If

            'Not override on default value
            If String.IsNullOrEmpty(szPreviousRequestor) Then
                RequestorBox.SelectedIndex = mnSelectionIndex
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
                    If (szParsingString.Substring(0, Microsoft.VisualBasic.InStr(szParsingString, ";") - 1)).Trim.Contains("(") Then
                        RequestorBox.Items.Add(((szParsingString.Substring(0, Microsoft.VisualBasic.InStr(szParsingString, ";") - 1)).Trim.Substring(0, Microsoft.VisualBasic.InStr((szParsingString.Substring(0, Microsoft.VisualBasic.InStr(szParsingString, ";") - 1)).Trim, "(") - 1)).Trim)
                    Else
                        RequestorBox.Items.Add(szParsingString.Substring(0, Microsoft.VisualBasic.InStr(szParsingString, ";") - 1))
                    End If

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
                    If (szParsingString.Substring(0, Microsoft.VisualBasic.InStr(szParsingString, ";") - 1)).Trim.Contains("(") Then
                        RequestorBox.Items.Add(((szParsingString.Substring(0, Microsoft.VisualBasic.InStr(szParsingString, ";") - 1)).Trim.Substring(0, Microsoft.VisualBasic.InStr((szParsingString.Substring(0, Microsoft.VisualBasic.InStr(szParsingString, ";") - 1)).Trim, "(") - 1)).Trim)
                    Else
                        RequestorBox.Items.Add(szParsingString.Substring(0, Microsoft.VisualBasic.InStr(szParsingString, ";") - 1))
                    End If

                    szParsingString = (szParsingString.Substring(Microsoft.VisualBasic.InStr(szParsingString, ";"))).Trim
                End While
            End If
        Catch
            'No "CC information
        End Try

        'Reselect Previous Value
        If Not String.IsNullOrEmpty(szPreviousRequestor.Trim) Then
            mnSelectionIndex = RequestorBox.FindString(szPreviousRequestor.Trim)
        End If

        RequestorBox.SelectedIndex = mnSelectionIndex
    End Sub

    'Email Function/Sub
    Private Sub ParseEmail()
        Dim objectType As Object
        Dim mnSelectionIndex As Integer

        OutApp = CreateObject("Outlook.Application")

        '****************************
        'Retrieve active item
        '****************************
        Try
            'returns reference to current item, either the one selected (Explorer), or the one currently open (Inspector)
            Select Case True
                Case TypeName(OutApp.ActiveWindow) = "Explorer"
                    objectType = OutApp.ActiveExplorer.Selection.Item(1)
                    Exit Select
                Case TypeName(OutApp.ActiveWindow) = "Inspector"
                    objectType = OutApp.ActiveInspector.CurrentItem
                    Exit Select
                Case Else
                    bAssociatedEmail = False
                    objectType = Nothing
            End Select
        Catch ex As System.Exception
            'No active item
            bAssociatedEmail = False
            objectType = Nothing
        End Try

        '****************************
        'Parse retrieved email
        '****************************
        If TypeName(objectType) = "MailItem" Then
            bAssociatedEmail = True
            OutItem = objectType

            'Retrieve default properties
            gdCreationTime = OutItem.CreationTime
            szSubject = OutItem.Subject
            Try
                szConversationID = OutItem.ConversationID.Trim
            Catch ex As system.Exception
                'Error
                szConversationID = OutItem.ConversationIndex
            End Try

            'Retrieve responsible
            ResponsibleBox.Items.Add(OutItem.Session.CurrentUser.Name)
            mnSelectionIndex = ResponsibleBox.FindString(OutItem.Session.CurrentUser.Name)
            ResponsibleBox.SelectedIndex = mnSelectionIndex

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
        Dim bResult As Boolean = False
        Dim szAuxSubject As String = Subject
        Dim mnPipeCount As Integer = 0
        Dim mnTicketNumber As Integer = 0
        Dim mnSelectionIndex As Integer

        '****************************
        'Count subject pipes
        '****************************
        Try
            mnPipeCount = (From character In szAuxSubject Where character = "|" Select character).Count()
        Catch ex As System.Exception
            mnPipeCount = 0
        End Try

        '****************************
        'Valid pipe count
        '****************************
        If 0 < mnPipeCount And mnPipeCount < 3 Then
            Try
                'Process Subject Format
                mnPipeCount = 0
                While (szAuxSubject.Contains("|") And mnPipeCount < 3) Or szAuxSubject.Contains("TK")
                    'Mail szSubject | Ticket Number| Ticket Status
                    Select Case mnPipeCount
                        Case 0
                            Subject = Microsoft.VisualBasic.Left(szAuxSubject, szAuxSubject.IndexOf("|"))
                            szAuxSubject = szAuxSubject.Substring(Microsoft.VisualBasic.InStr(szAuxSubject, " | ") + 3)
                            Exit Select
                        Case 1
                            mnTicketNumber = Convert.ToDouble(szAuxSubject.Substring(Microsoft.VisualBasic.InStr(szAuxSubject, "TK") + 1, 10))
                            szAuxSubject = szAuxSubject.Substring(Microsoft.VisualBasic.InStr(szAuxSubject, "TK") + 11)
                            Exit Select
                        Case 2
                            mnSelectionIndex = StatusBox.FindString(szAuxSubject.Trim.Substring(szAuxSubject.IndexOf(" | ") + 1, szAuxSubject.Length - 2).Trim)
                            If mnSelectionIndex > -1 Then
                                StatusBox.SelectedIndex = mnSelectionIndex
                            End If
                            szAuxSubject = szAuxSubject.Substring(Microsoft.VisualBasic.InStr(szAuxSubject, " | ") + 3)
                            Exit Select
                    End Select

                    mnPipeCount = mnPipeCount + 1
                End While

                If mnPipeCount = 2 Then
                    bResult = True
                Else
                    '****************************
                    'Set default values
                    '****************************
                    'Status 
                    mnSelectionIndex = StatusBox.FindString("Open")
                    StatusBox.SelectedIndex = mnSelectionIndex
                    'Reload Subject
                    Subject = OutItem.Subject
                End If
            Catch ex As System.Exception
                Subject = OutItem.Subject
            End Try
        End If
        Return bResult
    End Function

    'Ticket Insertion Functions/Sub
    Private Function getNextTicketNumber() As Long
        Dim mnResult As Long = 0
        Dim szQuery As String = ""
        Dim mnRows As Integer

        Try
            conection.Open()
            szQuery = ("SELECT TOP 1 mnTicketNumber, mnTicketLineNumber FROM Tickets ORDER BY 1 DESC, 2 DESC")
            adapter = New OleDbDataAdapter(szQuery, conection)

            adapter.Fill(record, "Tickets")
            mnRows = record.Tables("Tickets").Rows.Count
            If mnRows <> 0 Then
                mnResult = CLng(record.Tables("Tickets").Rows(0).Item("mnTicketNumber")) + 1
            Else
                mnResult = mnHomePrefix + 1
            End If
        Catch ex As System.Exception
            MsgBox(ex.Message)
        End Try

        conection.Close()
        Return mnResult
    End Function

    Private Function InsertTicket(ByRef NextNumber As Long) As Boolean
        Dim bResult As Boolean = False
        Dim szQuery As String = ""

        NextNumber = getNextTicketNumber()
        '****************************
        'Error
        '****************************
        If NextNumber <> 0 Then
            '****************************
            'Format query
            '****************************
            szQuery = "INSERT INTO Tickets(mnTicketNumber, mnTicketLineNumber, szTeam, szActivityCategory, szResponsible, szStatus, szPriority, szRequestor, szBusinessUnit, szPendingSource, gdOpenDate, gdCloseDate, szComments, szDescription, gdRequestedTime, mnOpenDays, szAuditUser, szLocation, gdCreationDate, mnQuantity, szConversationID)"
            szQuery = szQuery & "VALUES("
            'mnTicketNumber
            szQuery = szQuery & NextNumber & ","
            'mnTicketLineNumber (First line start with 0)
            szQuery = szQuery & 0 & ","
            'szTeam
            szQuery = szQuery & "'" & ReplaceApostrophesInString(TeamBox.Text) & "',"
            'szActivityCategory
            szQuery = szQuery & "'" & ReplaceApostrophesInString(ActCategoryBox.Text) & "',"
            'szResponsible
            szQuery = szQuery & "'" & ReplaceApostrophesInString(ResponsibleBox.Text) & "',"
            'szStatus
            szQuery = szQuery & "'" & ReplaceApostrophesInString(StatusBox.Text) & "',"
            'szPriority
            szQuery = szQuery & "'" & ReplaceApostrophesInString(PriorityBox.Text) & "',"
            'szRequestor
            szQuery = szQuery & "'" & ReplaceApostrophesInString(RequestorBox.Text) & "',"
            'szBusinessUnit
            szQuery = szQuery & "'" & ReplaceApostrophesInString(RegionBox.Text) & "',"
            'szPendingSource
            If StatusBox.Text <> "Close" Then
                szQuery = szQuery & "'" & ReplaceApostrophesInString(PendingSrcBox.Text) & "',"
            Else
                szQuery = szQuery & "NULL,"
            End If
            'gdOpenDate
            szQuery = szQuery & "'" & Convert.ToString(DateTimePicker.Value.ToString(szDateTimeFormat)) & "',"
            'gdCloseDate
            If StatusBox.Text = "Close" Then
                szQuery = szQuery & "'" & Convert.ToString(DateTimePicker.Value.ToString(szDateTimeFormat)) & "',"
            Else
                szQuery = szQuery & "NULL,"
            End If
            'szComments
            szQuery = szQuery & "'" & ReplaceApostrophesInString(CommentsBox.Text) & "',"
            'szDescription
            szQuery = szQuery & "'" & ReplaceApostrophesInString(szSubject) & "',"
            'gdRequestedTime 
            szQuery = szQuery & "'" & gdCreationTime.ToString(szDateTimeFormat) & "',"
            'mnOpenDays
            szQuery = szQuery & 0 & ","
            'szAuditUser
            szQuery = szQuery & "'" & ReplaceApostrophesInString(Environment.UserName) & "',"
            'szLocation
            szQuery = szQuery & "'" & ReplaceApostrophesInString(ConectionBox.Text) & "',"
            'gdCreationDate
            szQuery = szQuery & "'" & DateTime.Now.ToString() & "',"
            'mnQuantity
            szQuery = szQuery & QuantityBox.Value & ","
            'szConversationID
            szQuery = szQuery & "'" & ReplaceApostrophesInString(szConversationID.Trim) & "')"

            Try
                '****************************
                'Perform query
                '****************************
                conection.Open()
                comands = New OleDbCommand(szQuery, conection)
                comands.ExecuteNonQuery()
                bResult = True
            Catch ex As System.Exception
                MsgBox(ex.Message)
            End Try
        End If

        conection.Close()
        Return bResult
    End Function

    'Additional Functions/Sub
    Private Function ReplaceApostrophesInString(szString As String) As String
        Dim cSpecialCharacter As String = "'"
        Dim cNewCharacter As String = " "

        If Not String.IsNullOrEmpty(szString.Trim) Then
            'Replace all
            While szString.Contains(cSpecialCharacter)
                szString = szString.Replace(cSpecialCharacter, cNewCharacter)
            End While
        End If
        Return szString
    End Function
End Class