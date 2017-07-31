Imports System.ComponentModel
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

    Dim szSubject As String
    Dim szTeam As String = ""
    Dim szDescription As String = ""
    Dim szPreviousPendingSrc As String = ""
    Dim szPreviousResponsible As String = ""
    Dim szPriority As String = ""

    Private Sub ModifyCaseForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Enable conection box
        ConectionBox.Enabled = True

        'Load ConectionBox
        ConectionBox.Items.Add("ACN")
        ConectionBox.Items.Add("Home - Office")

        'Date
        DateTimePicker.Enabled = False
        DateTimePicker.Value = Today.Date

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

    Private Sub ReopenButton_Click(sender As Object, e As EventArgs) Handles ReopenButton.Click
        'Validate ticket existence
        If Not SearchTicket(TicketNumberBox.Text) Then
            'Ticket does not exist
            MsgBox("Ticket does not exist", vbExclamation, "Alert")
            TicketNumberBox.Clear()
            TicketNumberBox.Focus()
            Exit Sub
        End If

        'Ticket must be closed
        If StatusBox.Text <> "Close" Then
            MsgBox("Ticket already open", vbExclamation, "Alert")
            Exit Sub
        End If

        If UpdateTicket("Reopen") Then
            'Change mail status 
            'Mail szSubject | Ticket Number| Ticket Status
            OutlookItem.Subject = szDescription & " | "
            OutlookItem.Subject = OutlookItem.Subject & "TK" & TicketNumberBox.Text
            OutlookItem.Subject = OutlookItem.Subject & " | Reopen"

            OutlookItem.Save()
        End If

        Me.Close()
    End Sub

    Private Sub ModifyCaseButton_Click(sender As Object, e As EventArgs) Handles ModifyCaseButton.Click
        'Cant perform changes on a close case
        If "Close" = records.Tables("Tickets").Rows(0).Item("szStatus") Then
            'Ticket does not exist
            MsgBox("Cannot perform changes on a close case", vbExclamation, "Alert")
            Exit Sub
        End If

        'Check if there was a modification perfomed
        If ResponsibleBox.Text = records.Tables("Tickets").Rows(0).Item("szResponsible") And PendingSourceBox.Text = records.Tables("Tickets").Rows(0).Item("szPendingSource") And CommentsBox.Text = records.Tables("Tickets").Rows(0).Item("szComments") Then
            'Ticket did not change
            MsgBox("Ticket did not change", vbExclamation, "Alert")
            Exit Sub
        End If

        'Update Ticket
        If UpdateTicket("Modify") Then
            'Change mail status 
            'Mail szSubject | Ticket Number| Ticket Status
            OutlookItem.Subject = szDescription & " | TK"
            OutlookItem.Subject = OutlookItem.Subject & TicketNumberBox.Text.PadLeft(10, "0")
            OutlookItem.Save()

            If ResponsibleBox.Text <> records.Tables("Tickets").Rows(0).Item("szResponsible") Then
                NotifyNewResponsible()
            End If

            If PendingSourceBox.Text <> records.Tables("Tickets").Rows(0).Item("szPendingSource") Then
                NotifyNewPendingSource()
            End If
        End If

        Me.Close()
    End Sub

    Private Sub ConectionBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ConectionBox.SelectedIndexChanged
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

        'Enable and set focus over Ticket Number Box
        TicketNumberBox.Text = ""
        TicketNumberBox.Enabled = True
        TicketNumberBox.Focus()

        'Retrieve data from email
        ParseEmail()
    End Sub

    Private Sub TicketNumberBox_TextChanged(sender As Object, e As EventArgs) Handles TicketNumberBox.LostFocus
        If TicketNumberBox.Text.Trim <> "" Then
            'Validate ticket existence
            If Not SearchTicket(TicketNumberBox.Text) Then
                'Ticket does not exist
                MsgBox("Ticket does not exist", vbExclamation, "Alert")
                Exit Sub
            End If
        End If
    End Sub

    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click
        'Validate ticket existence
        If Not SearchTicket(TicketNumberBox.Text) Then
            'Ticket does not exist
            MsgBox("Ticket does not exist", vbExclamation, "Alert")

            'Disable and clean fields
            'Disable buttons
            ReopenButton.Enabled = False
            ModifyCaseButton.Enabled = False

            'Disable field 
            ResponsibleBox.Enabled = False
            PendingSourceBox.Enabled = False
            DateTimePicker.Enabled = False
            CommentsBox.Enabled = False

            SearchTicket(TicketNumberBox.Text)
            Exit Sub
        Else
            'Enable buttons
            ReopenButton.Enabled = True
            ModifyCaseButton.Enabled = True

            'Enable field 
            ResponsibleBox.Enabled = True
            PendingSourceBox.Enabled = True
            DateTimePicker.Enabled = True
            CommentsBox.Enabled = True
            CommentsBox.Text = ""
        End If
    End Sub

    Private Sub DateTimePicker_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker.ValueChanged
        If DateTimePicker.Value > Today.Date Then
            DateTimePicker.Value = Today.Date
            MsgBox("Cannot select a future date", vbExclamation, "Alert")
        End If
    End Sub

    Private Function SearchTicket(TicketNumber As String) As Boolean
        Dim result As Boolean = False
        Dim query As String
        Dim Rows As Integer

        If TicketNumberBox.Text <> "" Then
            Try
                conection.Open()
                query = "SELECT TOP 1 * FROM Tickets WHERE mnTicketNumber = " & TicketNumber & " ORDER BY mnTicketNumber DESC, mnTicketLineNumber DESC"
                adapter = New OleDbDataAdapter(query, conection)
                adapter.Fill(records, "Tickets")
                Rows = records.Tables("Tickets").Rows.Count

                If Rows <> 0 Then
                    'Change function status
                    result = True

                    'Retrieve Form Data
                    StatusBox.Text = records.Tables("Tickets").Rows(0).Item("szStatus")
                    ResponsibleBox.Text = records.Tables("Tickets").Rows(0).Item("szResponsible")
                    RequestorBox.Text = records.Tables("Tickets").Rows(0).Item("szRequestor")
                    RegionBox.Text = records.Tables("Tickets").Rows(0).Item("szBusinessUnit")
                    DateTimePicker.Value = Convert.ToDateTime(records.Tables("Tickets").Rows(0).Item("gdOpenDate"))
                    PendingSourceBox.Text = records.Tables("Tickets").Rows(0).Item("szPendingSource")
                    CommentsBox.Text = records.Tables("Tickets").Rows(0).Item("szComments")

                    'Retrieve Extra Data
                    szPriority = records.Tables("Tickets").Rows(0).Item("szPriority")
                    szPreviousPendingSrc = PendingSourceBox.Text
                    szPreviousResponsible = ResponsibleBox.Text
                    szDescription = records.Tables("Tickets").Rows(0).Item("szDescription")
                End If
            Catch ex As System.Exception
                MsgBox(ex.Message)
            End Try
            conection.Close()
        End If
        Return result
    End Function

    Private Function UpdateTicket(Action As String) As Boolean
        Dim result As Boolean = False
        Dim query As String = ""

        'Format query
        query = "INSERT INTO Tickets(mnTicketNumber, mnTicketLineNumber, szTeam, szActivityCategory, szResponsible, szStatus, szPriority, szRequestor, szBusinessUnit, szPendingSource, gdOpenDate, gdCloseDate, szComments, szDescription, gdRequestedTime, mnOpenDays, szAuditUser, szLocation, gdCreationDate, mnQuantity)"
        query = query & "VALUES("
        'mnTicketNumber
        query = query & TicketNumberBox.Text & ","
        'mnTicketLineNumber (First line start with 0)
        query = query & records.Tables("Tickets").Rows(0).Item("mnTicketLineNumber") + 1 & ", "
        'szTeam, 
        query = query & "'" & ReplaceApostrophesInString(records.Tables("Tickets").Rows(0).Item("szTeam")) & "', "
        'szActivityCategory
        query = query & "'" & ReplaceApostrophesInString(records.Tables("Tickets").Rows(0).Item("szActivityCategory")) & "', "
        'szResponsible
        query = query & "'" & ReplaceApostrophesInString(ResponsibleBox.Text) & "', "
        'szStatus
        Select Case (Action)
            Case "Reopen"
                query = query & "'" & "Reopen" & "', "
                Exit Select
            Case "Modify"
                query = query & "'" & "Open" & "', "
                Exit Select
        End Select
        'szPriority
        query = query & "'" & ReplaceApostrophesInString(szPriority) & "', "
        'szRequestor
        query = query & "'" & ReplaceApostrophesInString(RequestorBox.Text) & "', "
        'szBusinessUnit
        query = query & "'" & ReplaceApostrophesInString(RegionBox.Text) & "', "
        'szPendingSource
        query = query & "'" & ReplaceApostrophesInString(PendingSourceBox.Text) & "', "
        'gdOpenDate
        query = query & "'" & (DateTime.Now.ToString("mm/dd/yyyy")) & "', "
        'gdCloseDate
        query = query & "'" & DBNull.Value & "', "
        'szComments
        Select Case (Action)
            Case "Reopen"
                query = query & "'Reopen Ticket', "
                Exit Select
            Case "Modify"
                query = query & "'" & ReplaceApostrophesInString(CommentsBox.Text) & "', "
                Exit Select
        End Select
        'szDescription
        query = query & "'" & ReplaceApostrophesInString(records.Tables("Tickets").Rows(0).Item("szDescription")) & "', "
        'gdRequestedTime 
        query = query & "'" & ReplaceApostrophesInString(records.Tables("Tickets").Rows(0).Item("gdRequestedTime")) & "', "
        'mnOpenDays
        query = query & 0 & ", "
        'szAuditUser
        query = query & "'" & ReplaceApostrophesInString(Environment.UserName) & "', "
        'szLocation
        query = query & "'" & ReplaceApostrophesInString(ConectionBox.Text) & "', "
        'gdCreationDate
        query = query & "'" & DateTime.Now.ToString("mm/dd/yyyy") & "',"
        'mnQuantity
        query = query & records.Tables("Tickets").Rows(0).Item("mnQuantity") & ") "

        Try
            'Perform query
            conection.Open()
            command = New OleDbCommand(query, conection)
            command.ExecuteNonQuery()

            'Notify transaction status
            Select Case (Action)
                Case "Reopen"
                    MsgBox("Ticket reopened", vbExclamation, "Alert")
                Case "Modify"
                    MsgBox("Ticket modified", vbExclamation, "Alert")
            End Select

            result = True

        Catch ex As System.Exception
            MsgBox(ex.Message)
        End Try

        conection.Close()
        Return result
    End Function

    Private Sub NotifyNewPendingSource()
        'Notify New Pending Source+
        OutlookApp = CreateObject("Outlook.Application")
        NewMessage = OutlookApp.CreateItem(OlItemType.olMailItem)
        NewMessage.To = PendingSourceBox.Text
        NewMessage.HTMLBody = "<html><body><h2>A change has been made in this ticket and you apear to be the new pending source</h2><p>This Message Is for the designated recipient only And may contain restricted, highly confidential, Or confidential information.<br>If you Then have received it In Error, please notify the sender immediately And delete the original.  Any other use Of the email by you Is prohibited.</p><hr></body>"
        NewMessage.Body = NewMessage.Body & vbCrLf & vbCrLf
        NewMessage.Body = NewMessage.Body & OutlookItem.Body
        NewMessage.Subject = OutlookItem.Subject
        NewMessage.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh

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
        'Notify New Responsible
        OutlookApp = CreateObject("Outlook.Application")
        NewMessage = OutlookApp.CreateItem(OlItemType.olMailItem)
        NewMessage.To = ResponsibleBox.Text
        NewMessage.HTMLBody = "<html><body><h2>A change has been made in this ticket and you apear to be the new responsible</h2><p>This Message Is for the designated recipient only And may contain restricted, highly confidential, Or confidential information.<br>If you Then have received it In Error, please notify the sender immediately And delete the original.  Any other use Of the email by you Is prohibited.</p><hr></body>"
        NewMessage.Body = NewMessage.Body & vbCrLf & vbCrLf
        NewMessage.Body = NewMessage.Body & OutlookItem.Body
        NewMessage.Subject = OutlookItem.Subject
        NewMessage.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh

        Select Case MsgBox("¿Do you want edit the new responsible notification of this change?", MsgBoxStyle.YesNo, "Change notification")
            Case MsgBoxResult.Yes
                NewMessage.Display()
                Exit Select
            Case MsgBoxResult.No
                NewMessage.Send()
                Exit Select
        End Select
    End Sub

    Private Sub ParseEmail()
        Dim objectType As Object

        OutlookApp = CreateObject("Outlook.Application")

        'Retrieve active item
        'returns reference to current item, either the one selected (Explorer), or the one currently open (Inspector)
        Select Case True
            Case TypeName(OutlookApp.ActiveWindow) = "Explorer"
                objectType = OutlookApp.ActiveExplorer.Selection.Item(1)
                Exit Select
            Case TypeName(OutlookApp.ActiveWindow) = "Inspector"
                objectType = OutlookApp.ActiveInspector.CurrentItem
                Exit Select
            Case Else
                objectType = vbObject
        End Select

        'Parse retrieved email
        If TypeName(objectType) = "MailItem" Then
            OutlookItem = objectType

            'Retrieve from subject
            TicketNumberBox.Focus()
            If SubjectFormatted(OutlookItem.Subject) = True Then
                'Loose focus on field to trigger lost focus event
                TicketNumberLabel.Focus()
            Else
                TicketNumberBox.Text = ""
            End If
        End If
    End Sub

    Private Function SubjectFormatted(ByVal Subject As String) As Boolean
        Dim result As Boolean = False
        Dim auxSubject As String = Subject
        Dim pipeCount As Integer = 0

        'Count how many pipes has the subject
        pipeCount = (From character In auxSubject Where character = "|" Select character).Count()

        'If, pipe count is valid
        If 0 < pipeCount < 3 Then
            Try
                'Process Subject Format
                pipeCount = 0
                While (auxSubject.Contains("|") And pipeCount < 2) Or auxSubject.Contains("TK")
                    'Mail szSubject | Ticket Number| Ticket Status
                    If pipeCount = 1 Then
                        TicketNumberBox.Text = Convert.ToDouble(auxSubject.Substring(Microsoft.VisualBasic.InStr(auxSubject, "TK") + 1, 10))
                        auxSubject = auxSubject.Substring(Microsoft.VisualBasic.InStr(auxSubject, "TK") + 11)
                    End If
                    pipeCount = pipeCount + 1
                End While

                If pipeCount = 2 Then
                    result = True
                Else
                    TicketNumberBox.Text = ""
                End If

            Catch ex As System.Exception
                TicketNumberBox.Text = ""
            End Try
        End If

        Return result
    End Function

    Private Function ReplaceApostrophesInString(szString As String) As String
        Dim cSpecialCharacter As String = "'"
        Dim cNewCharacter As String = " "
        Return szString.Replace(cSpecialCharacter, cNewCharacter)
    End Function

End Class