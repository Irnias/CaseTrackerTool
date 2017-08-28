Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Windows.Forms

Public Class CloseCaseForm
    Dim conection As New OleDbConnection
    Dim adapter As New OleDbDataAdapter
    Dim records As New DataSet
    Dim command As New OleDbCommand

    Dim szSubject As String
    Dim OutlookApp As Outlook.Application
    Dim OutlookItem As Outlook.MailItem
    Dim NewMessage As Outlook.MailItem
    Dim bAssociatedEmail As Boolean = False

    'Form Activities
    Private Sub CloseCaseForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '****************************
        'Enable Fields
        '****************************
        ConectionBox.Enabled = True

        '****************************
        'Load Drop Down Lists
        '****************************
        'ConectionBox
        ConectionBox.Items.Add("ACN")
        ConectionBox.Items.Add("Home - Office")
    End Sub

    Private Sub CloseCaseForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        conection.Close()
        Me.Finalize()
    End Sub

    Private Sub CloseCaseForm_KeyDown(ByVal sender As System.Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    'Button Activities
    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click
        '****************************
        'Validate required fields
        '****************************
        If ConectionBox.Text.Trim = "" Then
            MsgBox("Must select a conection", vbExclamation, "Alert")
            Exit Sub
        End If

        If TicketNumberBox.Text.Trim = "" Then
            MsgBox("Must indicate a ticket number", vbExclamation, "Alert")
            Exit Sub
        End If

        '****************************
        'Validate Ticket
        '****************************
        If SearchTicketNumber(TicketNumberBox.Text.Trim) = True Then
            'Enable and clean fields
            CommentsBox.Enabled = True
            CommentsBox.Clear()

            'Enable buttons
            CloseCaseButton.Enabled = True
        Else
            'Disable and clean fields
            TicketNumberBox.Clear()
            CurrentStatusBox.Clear()
            CommentsBox.Enabled = False
            CommentsBox.Clear()

            'Disable buttons
            CloseCaseButton.Enabled = False

            'Ticket does not exist
            MsgBox("Ticket does not exist", vbExclamation, "Alert")
            TicketNumberBox.Clear()
            TicketNumberBox.Focus()
        End If
    End Sub

    Private Sub CloseCaseButton_Click(sender As Object, e As EventArgs) Handles CloseCaseButton.Click
        '****************************
        'Validate required fields
        '****************************
        If ConectionBox.Text.Trim = "" Then
            MsgBox("Must select a conection", vbExclamation, "Alert")
            Exit Sub
        End If

        If TicketNumberBox.Text.Trim = "" Then
            MsgBox("Must indicate a ticket number", vbExclamation, "Alert")
            Exit Sub
        End If

        '****************************
        'Validate Ticket
        '****************************
        If Not SearchTicketNumber(TicketNumberBox.Text) Then
            'Ticket does not exist
            MsgBox("Ticket does not exist", vbExclamation, "Alert")
            TicketNumberBox.Clear()
            TicketNumberBox.Focus()
            Exit Sub
        End If

        'Ticket cannot be closed
        If CurrentStatusBox.Text = "Close" Then
            MsgBox("Ticket already Closed", vbExclamation, "Alert")
            Exit Sub
        End If

        '****************************
        'Perform Update
        '****************************
        If InsertClosingLine() Then
            'If ticket is associated to an email
            If bAssociatedEmail = True Then
                '****************************
                'Change mail status 
                '****************************
                'Mail szSubject | Ticket Number| Ticket Status
                OutlookItem.Subject = records.Tables("Tickets").Rows(0).Item("szDescription") & " | TK"
                OutlookItem.Subject = OutlookItem.Subject & TicketNumberBox.Text.PadLeft(10, "0")
                OutlookItem.Subject = OutlookItem.Subject & " | Close"
                OutlookItem.Save()
            End If
        End If

        Me.Close()
    End Sub

    'Field Validation
    Private Sub ConectionBox_Validating(sender As Object, e As EventArgs) Handles ConectionBox.SelectedIndexChanged
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
        CurrentStatusBox.Clear()
        TicketNumberBox.Clear()
        TicketNumberBox.Enabled = True
        TicketNumberBox.Focus()

        '****************************
        'Validation Succeed
        '****************************
        'Parse Email
        ParseEmail()
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

            'Retrieve from subject
            TicketNumberBox.Focus()
            If SubjectFormatted(OutlookItem.Subject) = True Then
                'Loose focus on field to trigger lost focus event
                TicketNumberLabel.Focus()
            Else
                TicketNumberBox.Clear()
            End If
        End If
    End Sub


    Private Function SubjectFormatted(ByVal Subject As String) As Boolean
        Dim result As Boolean = False
        Dim auxSubject As String = Subject
        Dim pipeCount As Integer = 0

        '****************************
        'Count subject pipes
        '****************************
        Try
            pipeCount = (From character In auxSubject Where character = "|" Select character).Count()
        Catch ex As System.Exception
            pipeCount = 0
        End Try

        '****************************
        'Valid pipe count
        '****************************
        If 0 < pipeCount And pipeCount < 3 Then
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
                    TicketNumberBox.Clear()
                End If

            Catch ex As System.Exception
                TicketNumberBox.Clear()
            End Try
        End If

        Return result
    End Function

    'Ticket Update Functions/Sub
    Private Function SearchTicketNumber(mnTicketNumber As Integer) As Boolean
        Dim result As Boolean = False
        Dim query As String
        Dim Rows As Integer

        If TicketNumberBox.Text <> "" Then
            Try
                conection.Open()
                query = "SELECT TOP 1 * FROM Tickets WHERE mnTicketNumber = " & TicketNumberBox.Text & " ORDER BY mnTicketNumber DESC, mnTicketLineNumber DESC"
                adapter = New OleDbDataAdapter(query, conection)
                adapter.Fill(records, "Tickets")
                Rows = records.Tables("Tickets").Rows.Count
                If Rows <> 0 Then
                    CurrentStatusBox.Text = records.Tables("Tickets").Rows(0).Item("szStatus")
                    result = True
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            conection.Close()
        End If

        Return result
    End Function

    Private Function InsertClosingLine() As Boolean
        Dim result As Boolean = False
        Dim query As String = ""

        '****************************
        'Format query
        '****************************
        query = "INSERT INTO Tickets(mnTicketNumber, mnTicketLineNumber, szTeam, szActivityCategory, szResponsible, szStatus, szPriority, szRequestor, szBusinessUnit, szPendingSource, gdOpenDate, gdCloseDate, szComments, szDescription, gdRequestedTime, mnOpenDays, szAuditUser, szLocation, gdCreationDate, mnQuantity, szConversationID)"
        query = query & "VALUES("
        'mnTicketNumber
        query = query & TicketNumberBox.Text & ","
        'mnTicketLineNumber (First line start with 0)
        query = query & records.Tables("Tickets").Rows(0).Item("mnTicketLineNumber") + 1 & ", "
        'szTeam, 
        query = query & "'" & ReplaceApostrophesInString(Convert.ToString(records.Tables("Tickets").Rows(0).Item("szTeam"))) & "',"
        'szActivityCategory
        query = query & "'" & ReplaceApostrophesInString(Convert.ToString(records.Tables("Tickets").Rows(0).Item("szActivityCategory"))) & "',"
        'szResponsible
        query = query & "'" & ReplaceApostrophesInString(Convert.ToString(records.Tables("Tickets").Rows(0).Item("szResponsible"))) & "',"
        'szStatus
        query = query & "'" & "Close" & "',"
        'szPriority
        query = query & "'" & ReplaceApostrophesInString(Convert.ToString(records.Tables("Tickets").Rows(0).Item("szPriority"))) & "',"
        'szRequestor
        query = query & "'" & ReplaceApostrophesInString(Convert.ToString(records.Tables("Tickets").Rows(0).Item("szRequestor"))) & "',"
        'szBusinessUnit
        query = query & "'" & ReplaceApostrophesInString(Convert.ToString(records.Tables("Tickets").Rows(0).Item("szBusinessUnit"))) & "',"
        'szPendingSource
        query = query & "'',"
        'gdOpenDate
        query = query & "'" & Convert.ToString(records.Tables("Tickets").Rows(0).Item("gdOpenDate").ToString("MM/dd/yyyy")) & "',"
        'gdCloseDate
        query = query & "'" & DateTime.Today.ToString("MM/dd/yyyy") & "',"
        'szComments
        query = query & "'" & Convert.ToString(ReplaceApostrophesInString(CommentsBox.Text)) & "',"
        'szDescription
        query = query & "'" & Convert.ToString(ReplaceApostrophesInString(records.Tables("Tickets").Rows(0).Item("szDescription"))) & "',"
        'gdRequestedTime 
        query = query & "'" & Convert.ToString(ReplaceApostrophesInString(records.Tables("Tickets").Rows(0).Item("gdRequestedTime"))) & "',"
        'mnOpenDays
        query = query & 0 & ","
        'szAuditUser
        query = query & "'" & Convert.ToString(ReplaceApostrophesInString(Environment.UserName)) & "',"
        'szLocation
        query = query & "'" & Convert.ToString(ReplaceApostrophesInString(ConectionBox.Text)) & "',"
        'gdCreationDate
        query = query & "'" & DateTime.Today.ToString("MM/dd/yyyy") & "',"
        'mnQuantity
        query = query & records.Tables("Tickets").Rows(0).Item("mnQuantity") & ","
        'szConversationID
        query = query & "'" & records.Tables("Tickets").Rows(0).Item("szConversationID") & "')"

        Try
            '****************************
            'Perform query
            '****************************
            conection.Open()
            command = New OleDbCommand(query, conection)
            command.ExecuteNonQuery()
            result = True

            '****************************
            'Notify transaction status
            '****************************
            MsgBox("Ticket closed", vbExclamation, "Alert")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        conection.Close()

        Return result
    End Function

    'Additional Functions/Sub
    Private Function ReplaceApostrophesInString(szString As String) As String
        Dim cSpecialCharacter As String = "'"
        Dim cNewCharacter As String = " "

        If String.IsNullOrEmpty(szString.Trim) Then
            'Replace all
            While szString.Contains(cSpecialCharacter)
                szString = szString.Replace(cSpecialCharacter, cNewCharacter)
            End While
        End If
        Return szString
    End Function

End Class