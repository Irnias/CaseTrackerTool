﻿Imports System.ComponentModel
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Windows.Forms
Imports Microsoft.Office.Interop.Outlook

Public Class ModifyCaseForm
    Dim conection As New OleDbConnection
    Dim adapter As New OleDbDataAdapter
    Dim records As New DataSet
    Dim command As New OleDbCommand

    Dim OutlookApp As Outlook.Application
    Dim OutlookItem As Outlook.MailItem
    Dim NewMessage As Outlook.MailItem
    Dim bAssociatedEmail As Boolean = False

    Dim szConversationID As String = ""
    Dim szSubject As String = ""
    Dim szTeam As String = ""
    Dim szDescription As String = ""
    Dim szPreviousPendingSrc As String = ""
    Dim szPreviousResponsible As String = ""
    Dim szPriority As String = ""

    Dim szDateTimeFormat As String = ""

    'Form Activities
    Private Sub ModifyCaseForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '****************************
        'Enable Fields and Buttons
        '****************************
        'Fields
        ConectionBox.Enabled = True
        'Buttons
        SearchButton.Enabled = True

        '****************************
        'Clear Options
        '****************************
        ConectionBox.Items.Clear()
        TicketNumberBox.Clear()
        StatusBox.Clear()
        ResponsibleBox.Clear()
        RequestorBox.Clear()
        RegionBox.Clear()
        PendingSourceBox.Clear()
        CommentsBox.Clear()

        '****************************
        'Load Drop Down Lists
        '****************************
        'ConectionBox
        ConectionBox.Items.Add("ACN")
        ConectionBox.Items.Add("Home - Office")

        '****************************
        'Set default values
        '****************************
        'Date
        DateTimePicker.Value = DateTime.Today

        '****************************
        'Disable Fields and Buttons
        '****************************
        'Fields
        TicketNumberBox.Enabled = False
        StatusBox.Enabled = False
        ResponsibleBox.Enabled = False
        RequestorBox.Enabled = False
        RegionBox.Enabled = False
        DateTimePicker.Enabled = False
        PendingSourceBox.Enabled = False
        CommentsBox.Enabled = False
        'Buttons
        ReopenButton.Enabled = False
        ModifyCaseButton.Enabled = False
    End Sub

    Private Sub ModifyCaseForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        conection.Close()
        Me.Finalize()
    End Sub

    Private Sub ModifyCaseForm_KeyDown(ByVal sender As System.Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    'Button Activities
    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click
        '****************************
        'Validate required fields
        '****************************
        If String.IsNullOrEmpty(ConectionBox.Text.Trim) Then
            MsgBox("Must select a conection", vbExclamation, "Alert")
            Exit Sub
        End If

        If String.IsNullOrEmpty(TicketNumberBox.Text.Trim) Then
            MsgBox("Must indicate a ticket number", vbExclamation, "Alert")
            Exit Sub
        End If

        '****************************
        'Validate Ticket
        '****************************
        If Not SearchTicket(TicketNumberBox.Text) Then
            'Ticket does not exist
            MsgBox("Ticket does not exist", vbExclamation, "Alert")

            'Disable buttons
            ReopenButton.Enabled = False
            ModifyCaseButton.Enabled = False

            'Clear and disable field 
            StatusBox.Enabled = False
            StatusBox.Clear()

            ResponsibleBox.Enabled = False
            ResponsibleBox.Clear()

            RequestorBox.Enabled = False
            RequestorBox.Clear()

            RegionBox.Enabled = False
            RegionBox.Clear()

            DateTimePicker.Enabled = False
            DateTimePicker.Value = DateTime.Today

            PendingSourceBox.Enabled = False
            PendingSourceBox.Clear()

            CommentsBox.Enabled = False
            CommentsBox.Clear()
        Else
            'Ticket found

            'Enable buttons
            ReopenButton.Enabled = True
            ModifyCaseButton.Enabled = True

            'Enable field 
            ResponsibleBox.Enabled = True
            PendingSourceBox.Enabled = True
            DateTimePicker.Enabled = True
            CommentsBox.Enabled = True
            CommentsBox.Clear()
        End If
    End Sub

    Private Sub ReopenButton_Click(sender As Object, e As EventArgs) Handles ReopenButton.Click
        '****************************
        'Validate required fields
        '****************************
        If String.IsNullOrEmpty(ConectionBox.Text.Trim) Then
            MsgBox("Must select a conection", vbExclamation, "Alert")
            Exit Sub
        End If

        If String.IsNullOrEmpty(TicketNumberBox.Text.Trim) Then
            MsgBox("Must indicate a ticket number", vbExclamation, "Alert")
            Exit Sub
        End If

        '****************************
        'Validate Ticket
        '****************************
        If Not SearchTicket(TicketNumberBox.Text.Trim) Then
            'Ticket does not exist
            MsgBox("Ticket does not exist", vbExclamation, "Alert")

            TicketNumberBox.Clear()
            TicketNumberBox.Focus()
            Exit Sub
        End If

        'Ticket must be closed
        If StatusBox.Text.Trim <> "Close" Then
            MsgBox("Ticket already open", vbExclamation, "Alert")
            Exit Sub
        End If

        '****************************
        'Perform Update
        '****************************
        If UpdateTicket("Reopen") Then

            'If ticket is associated to an email
            If bAssociatedEmail = True Then
                '****************************
                'Change mail status 
                '****************************
                'Mail szSubject | Ticket Number| Ticket Status
                OutlookItem.Subject = szDescription & " | TK"
                OutlookItem.Subject = OutlookItem.Subject & TicketNumberBox.Text.PadLeft(10, "0")
                OutlookItem.Subject = OutlookItem.Subject & " | Reopen"
                OutlookItem.Save()
            End If
        End If

        Me.Close()
    End Sub

    Private Sub ModifyCaseButton_Click(sender As Object, e As EventArgs) Handles ModifyCaseButton.Click
        '****************************
        'Validate required fields
        '****************************
        If String.IsNullOrEmpty(ConectionBox.Text.Trim) Then
            MsgBox("Must select a conection", vbExclamation, "Alert")
            Exit Sub
        End If

        If String.IsNullOrEmpty(TicketNumberBox.Text.Trim) Then
            MsgBox("Must indicate a ticket number", vbExclamation, "Alert")
            Exit Sub
        End If

        If "Close" = records.Tables("Tickets").Rows(0).Item("szStatus") Then
            'Cant perform changes on a close case
            MsgBox("Cannot perform changes on a close ticket", vbExclamation, "Alert")
            Exit Sub
        End If

        'Check if there was a modification perfomed
        If ResponsibleBox.Text = records.Tables("Tickets").Rows(0).Item("szResponsible") And PendingSourceBox.Text = records.Tables("Tickets").Rows(0).Item("szPendingSource") And CommentsBox.Text = records.Tables("Tickets").Rows(0).Item("szComments") Then
            'Ticket did not change
            MsgBox("Ticket did not change", vbExclamation, "Alert")
            Exit Sub
        End If

        '****************************
        'Perform Update
        '****************************
        If UpdateTicket("Modify") Then

            'If ticket is associated to an email
            If bAssociatedEmail = True Then
                '****************************
                'Change mail status 
                '****************************
                'Mail szSubject | Ticket Number| Ticket Status
                OutlookItem.Subject = szDescription & " | TK"
                OutlookItem.Subject = OutlookItem.Subject & TicketNumberBox.Text.PadLeft(10, "0")
                OutlookItem.Save()
            End If
            '****************************
            'Change Notification
            '****************************
            If ResponsibleBox.Text <> records.Tables("Tickets").Rows(0).Item("szResponsible") Then
                'NotifyNewResponsible()
            End If

            If PendingSourceBox.Text <> records.Tables("Tickets").Rows(0).Item("szPendingSource") Then
                'NotifyNewPendingSource()
            End If
        End If

        Me.Close()
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
            'Date
            DateTimePicker.Value = DateTime.Today

            '****************************
            'Disable Fields/Buttons
            '****************************
            ResponsibleBox.Enabled = False
            StatusBox.Enabled = False
            RequestorBox.Enabled = False
            RegionBox.Enabled = False
            PendingSourceBox.Enabled = False
            DateTimePicker.Enabled = False
            CommentsBox.Enabled = False

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
        'Reaload and enable Ticket Number Box
        '****************************
        TicketNumberBox.Clear()
        TicketNumberBox.Enabled = True
        TicketNumberBox.Focus()

        '****************************
        'Validation Succeed
        '****************************
        'Parse Email
        ParseEmail()
    End Sub

    Private Sub TicketNumberBox_LostFocus(sender As Object, e As EventArgs) Handles TicketNumberBox.LostFocus

        '****************************
        'Validate required fields
        '****************************
        If String.IsNullOrEmpty(ConectionBox.Text.Trim) Then
            'Clear Options
            TicketNumberBox.Clear()
            StatusBox.Clear()
            ResponsibleBox.Clear()
            RequestorBox.Clear()
            RegionBox.Clear()
            DateTimePicker.Value = DateTime.Today
            PendingSourceBox.Clear()
            CommentsBox.Clear()

            'Disable buttons
            ReopenButton.Enabled = False
            ModifyCaseButton.Enabled = False

            'Disable field 
            ResponsibleBox.Enabled = False
            PendingSourceBox.Enabled = False
            DateTimePicker.Enabled = False
            CommentsBox.Enabled = False

            ConectionBox.Focus()
            MsgBox("Must select a conection", vbExclamation, "Alert")
            Exit Sub
        End If

        If String.IsNullOrEmpty(TicketNumberBox.Text.Trim) Then
            'Clear Options
            StatusBox.Clear()
            ResponsibleBox.Clear()
            RequestorBox.Clear()
            RegionBox.Clear()
            DateTimePicker.Value = DateTime.Today
            PendingSourceBox.Clear()
            CommentsBox.Clear()

            'Disable buttons
            ReopenButton.Enabled = False
            ModifyCaseButton.Enabled = False

            'Disable field 
            ResponsibleBox.Enabled = False
            PendingSourceBox.Enabled = False
            DateTimePicker.Enabled = False
            CommentsBox.Enabled = False

            MsgBox("Must indicate a ticket number", vbExclamation, "Alert")
            Exit Sub
        End If

        '****************************
        'Validate Ticket
        '****************************
        If Not SearchTicket(TicketNumberBox.Text.Trim) Then
            'Ticket does not exist
            'Clear Options
            TicketNumberBox.Clear()
            StatusBox.Clear()
            ResponsibleBox.Clear()
            RequestorBox.Clear()
            RegionBox.Clear()
            DateTimePicker.Value = DateTime.Today
            PendingSourceBox.Clear()
            CommentsBox.Clear()

            'Disable buttons
            ReopenButton.Enabled = False
            ModifyCaseButton.Enabled = False

            'Disable field 
            ResponsibleBox.Enabled = False
            PendingSourceBox.Enabled = False
            DateTimePicker.Enabled = False
            CommentsBox.Enabled = False

            MsgBox("Ticket does not exist", vbExclamation, "Alert")
            Exit Sub
        End If
    End Sub

    Private Sub DateTimePicker_LostFocus(sender As Object, e As EventArgs) Handles DateTimePicker.LostFocus
        If DateTimePicker.Value.ToString(szDateTimeFormat) <> DateTime.Today.ToString(szDateTimeFormat) Then
            DateTimePicker.Value = DateTime.Today
            MsgBox("Cannot select a future date", vbExclamation, "Alert")
        End If
    End Sub

    'Email Function/Sub
    Private Sub ParseEmail()
        Dim objectType As Object

        OutlookApp = CreateObject("Outlook.Application")

        '****************************
        'Retrieve active item
        '****************************
        Try
            'returns reference to current item, either the one selected (Explorer), or the one currently open (Inspector)
            Select Case True
                Case TypeName(OutlookApp.ActiveWindow) = "Explorer"
                    objectType = OutlookApp.ActiveExplorer.Selection.Item(1)
                    Exit Select
                Case TypeName(OutlookApp.ActiveWindow) = "Inspector"
                    objectType = OutlookApp.ActiveInspector.CurrentItem
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
            OutlookItem = objectType

            'Retrieve default properties
            szConversationID = OutlookItem.ConversationID

            'Retrieve from subject
            If SubjectFormatted(OutlookItem.Subject) <> True Then
                TicketNumberBox.Clear()
            End If
        End If
    End Sub

    Private Function SubjectFormatted(ByVal Subject As String) As Boolean
        Dim bResult As Boolean = False
        Dim szAuxSubject As String = Subject
        Dim mnPipeCount As Integer = 0

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
                While (szAuxSubject.Contains("|") And mnPipeCount < 2) Or szAuxSubject.Contains("TK")
                    'Mail szSubject | Ticket Number| Ticket Status
                    If mnPipeCount = 1 Then
                        TicketNumberBox.Text = Convert.ToDouble(szAuxSubject.Substring(Microsoft.VisualBasic.InStr(szAuxSubject, "TK") + 1, 10))
                        szAuxSubject = szAuxSubject.Substring(Microsoft.VisualBasic.InStr(szAuxSubject, "TK") + 11)
                    End If
                    mnPipeCount = mnPipeCount + 1
                End While

                If mnPipeCount = 2 Then
                    bResult = True
                Else
                    TicketNumberBox.Clear()
                    TicketNumberBox.Focus()
                End If
            Catch ex As System.Exception
                TicketNumberBox.Clear()
            End Try
        End If

        Return bResult
    End Function

    'Ticket Insertion Functions/Sub
    Private Function SearchTicket(TicketNumber As String) As Boolean
        Dim bResult As Boolean = False
        Dim szQuery As String
        Dim mnRows As Integer

        If Not String.IsNullOrEmpty(TicketNumberBox.Text) Then
            Try
                conection.Open()
                szQuery = "SELECT TOP 1 * FROM Tickets WHERE mnTicketNumber = " & TicketNumber & " ORDER BY mnTicketNumber DESC, mnTicketLineNumber DESC"
                adapter = New OleDbDataAdapter(szQuery, conection)
                adapter.Fill(records, "Tickets")
                mnRows = records.Tables("Tickets").Rows.Count

                If mnRows <> 0 Then
                    'Change function status
                    bResult = True

                    'Retrieve Form Data
                    StatusBox.Text = Convert.ToString(records.Tables("Tickets").Rows(0).Item("szStatus"))
                    ResponsibleBox.Text = Convert.ToString(records.Tables("Tickets").Rows(0).Item("szResponsible"))
                    RequestorBox.Text = Convert.ToString(records.Tables("Tickets").Rows(0).Item("szRequestor"))
                    RegionBox.Text = Convert.ToString(records.Tables("Tickets").Rows(0).Item("szBusinessUnit"))
                    DateTimePicker.Value = Convert.ToDateTime(records.Tables("Tickets").Rows(0).Item("gdOpenDate"))
                    PendingSourceBox.Text = Convert.ToString(records.Tables("Tickets").Rows(0).Item("szPendingSource"))
                    CommentsBox.Text = Convert.ToString(records.Tables("Tickets").Rows(0).Item("szComments"))

                    'Retrieve Extra Data
                    szPriority = Convert.ToString(records.Tables("Tickets").Rows(0).Item("szPriority"))
                    szPreviousPendingSrc = Convert.ToString(PendingSourceBox.Text)
                    szPreviousResponsible = Convert.ToString(ResponsibleBox.Text)
                    szDescription = Convert.ToString(records.Tables("Tickets").Rows(0).Item("szDescription"))
                End If
            Catch ex As System.Exception
                MsgBox(ex.Message)
            End Try
            conection.Close()
        End If

        Return bResult
    End Function

    Private Function UpdateTicket(Action As String) As Boolean
        Dim bResult As Boolean = False
        Dim szQuery As String = ""

        '****************************
        'Format query
        '****************************
        szQuery = "INSERT INTO Tickets(mnTicketNumber, mnTicketLineNumber, szTeam, szActivityCategory, szResponsible, szStatus, szPriority, szRequestor, szBusinessUnit, szPendingSource, gdOpenDate, gdCloseDate, szComments, szDescription, gdRequestedTime, mnOpenDays, szAuditUser, szLocation, gdCreationDate, mnQuantity, szConversationID)"
        szQuery = szQuery & "VALUES("
        'mnTicketNumber
        szQuery = szQuery & TicketNumberBox.Text & ","
        'mnTicketLineNumber (First line start with 0)
        szQuery = szQuery & records.Tables("Tickets").Rows(0).Item("mnTicketLineNumber") + 1 & ","
        'szTeam, 
        szQuery = szQuery & "'" & ReplaceApostrophesInString(records.Tables("Tickets").Rows(0).Item("szTeam")) & "',"
        'szActivityCategory
        szQuery = szQuery & "'" & ReplaceApostrophesInString(records.Tables("Tickets").Rows(0).Item("szActivityCategory")) & "',"
        'szResponsible
        szQuery = szQuery & "'" & ReplaceApostrophesInString(ResponsibleBox.Text) & "',"
        'szStatus
        Select Case (Action)
            Case "Reopen"
                szQuery = szQuery & "'" & "Reopen" & "',"
                Exit Select
            Case "Modify"
                szQuery = szQuery & "'" & "Open" & "',"
                Exit Select
        End Select
        'szPriority
        szQuery = szQuery & "'" & ReplaceApostrophesInString(szPriority) & "',"
        'szRequestor
        szQuery = szQuery & "'" & ReplaceApostrophesInString(RequestorBox.Text) & "',"
        'szBusinessUnit
        szQuery = szQuery & "'" & ReplaceApostrophesInString(RegionBox.Text) & "',"
        'szPendingSource
        szQuery = szQuery & "'" & ReplaceApostrophesInString(PendingSourceBox.Text) & "',"
        'gdOpenDate
        szQuery = szQuery & "'" & (DateTimePicker.Value.ToString(szDateTimeFormat)) & "',"
        'gdCloseDate
        szQuery = szQuery & "NULL,"
        'szComments
        Select Case (Action)
            Case "Reopen"
                szQuery = szQuery & "'Reopen Ticket',"
                Exit Select
            Case "Modify"
                szQuery = szQuery & "'" & ReplaceApostrophesInString(CommentsBox.Text) & "',"
                Exit Select
        End Select
        'szDescription
        szQuery = szQuery & "'" & ReplaceApostrophesInString(records.Tables("Tickets").Rows(0).Item("szDescription")) & "',"
        'gdRequestedTime 
        szQuery = szQuery & "'" & ReplaceApostrophesInString(records.Tables("Tickets").Rows(0).Item("gdRequestedTime")) & "',"
        'mnOpenDays
        szQuery = szQuery & 0 & ","
        'szAuditUser
        szQuery = szQuery & "'" & ReplaceApostrophesInString(Environment.UserName) & "',"
        'szLocation
        szQuery = szQuery & "'" & ReplaceApostrophesInString(ConectionBox.Text) & "',"
        'gdCreationDate
        szQuery = szQuery & "'" & DateTime.Now.ToString() & "',"
        'mnQuantity
        szQuery = szQuery & records.Tables("Tickets").Rows(0).Item("mnQuantity") & ","
        'szConversationID
        szQuery = szQuery & "'" & records.Tables("Tickets").Rows(0).Item("szConversationID") & "')"

        Try
            '****************************
            'Perform query
            '****************************
            conection.Open()
            command = New OleDbCommand(szQuery, conection)
            command.ExecuteNonQuery()
            bResult = True

            '****************************
            'Notify transaction status
            '****************************
            Select Case (Action)
                Case "Reopen"
                    MsgBox("Ticket reopened", vbExclamation, "Alert")
                Case "Modify"
                    MsgBox("Ticket modified", vbExclamation, "Alert")
            End Select
        Catch ex As System.Exception
            MsgBox(ex.Message)
        End Try

        conection.Close()
        Return bResult
    End Function

    'Change Notification
    Private Sub NotifyNewPendingSource()
        Dim myRecipients As Outlook.Recipients

        '****************************
        'Create new email
        '****************************
        OutlookApp = CreateObject("Outlook.Application")
        NewMessage = OutlookApp.CreateItem(OlItemType.olMailItem)

        '****************************
        'Search for recepients email
        '****************************
        'NewMessage.To = PendingSourceBox.Text
        myRecipients = NewMessage.Recipients
        myRecipients.Add(PendingSourceBox.Text)
        If Not myRecipients.ResolveAll Then
            'Not valid name 
            MsgBox("Not valid pending source name", vbExclamation, "Alert")
            Exit Sub
        End If

        '****************************
        'Format email
        '****************************
        NewMessage.HTMLBody = "<html><body><h2>A change has been made in this ticket and you apear to be the new pending source</h2><p>This Message Is for the designated recipient only And may contain restricted, highly confidential, Or confidential information.<br>If you Then have received it In Error, please notify the sender immediately And delete the original.  Any other use Of the email by you Is prohibited.</p><hr></body>"
        NewMessage.Body = NewMessage.Body & vbCrLf & vbCrLf
        NewMessage.Body = NewMessage.Body & OutlookItem.Body
        NewMessage.Subject = OutlookItem.Subject
        NewMessage.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh

        '****************************
        'Ask for action
        '****************************
        Select Case MsgBox("¿Do you want edit the new pending source notification of this change?", MsgBoxStyle.YesNo, "Change notification")
            Case MsgBoxResult.Yes
                NewMessage.Display()
                Exit Select
            Case MsgBoxResult.No
                NewMessage.Send()
                Exit Select
        End Select
    End Sub

    Private Sub NotifyNewResponsible()
        Dim myRecipients As Outlook.Recipients

        '****************************
        'Create new email
        '****************************
        OutlookApp = CreateObject("Outlook.Application")
        NewMessage = OutlookApp.CreateItem(OlItemType.olMailItem)

        '****************************
        'Search for recepients email
        '****************************
        'NewMessage.To = ResponsibleBox.Text
        myRecipients = NewMessage.Recipients
        myRecipients.Add(PendingSourceBox.Text)
        If Not myRecipients.ResolveAll Then
            'Not valid name 
            MsgBox("Not valid responsible name", vbExclamation, "Alert")
            Exit Sub
        End If

        '****************************
        'Format email
        '****************************
        NewMessage.HTMLBody = "<html><body><h2>A change has been made in this ticket and you apear to be the new responsible</h2><p>This Message Is for the designated recipient only And may contain restricted, highly confidential, Or confidential information.<br>If you Then have received it In Error, please notify the sender immediately And delete the original.  Any other use Of the email by you Is prohibited.</p><hr></body>"
        NewMessage.Body = NewMessage.Body & vbCrLf & vbCrLf
        NewMessage.Body = NewMessage.Body & OutlookItem.Body
        NewMessage.Subject = OutlookItem.Subject
        NewMessage.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh

        '****************************
        'Ask for action
        '****************************
        Select Case MsgBox("¿Do you want edit the new responsible notification of this change?", MsgBoxStyle.YesNo, "Change notification")
            Case MsgBoxResult.Yes
                NewMessage.Display()
                Exit Select
            Case MsgBoxResult.No
                NewMessage.Send()
                Exit Select
        End Select
    End Sub

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