Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Windows.Forms

Public Class CloseCaseForm
    Dim conection As New OleDbConnection
    Dim adapter As New OleDbDataAdapter
    Dim records As New DataSet
    Dim command As New OleDbCommand

    Dim OutlookApp As Outlook.Application
    Dim OutlookItem As Outlook.MailItem
    Dim NewMessage As Outlook.MailItem

    Dim szSubject As String = ""
    Dim bAssociatedEmail As Boolean = False

    Dim szDateTimeFormat As String = ""

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
                End If

            Catch ex As System.Exception
                TicketNumberBox.Clear()
            End Try
        End If

        Return bResult
    End Function

    'Ticket Update Functions/Sub
    Private Function SearchTicketNumber(mnTicketNumber As Integer) As Boolean
        Dim bResult As Boolean = False
        Dim szQuery As String
        Dim mnRows As Integer

        If TicketNumberBox.Text <> "" Then
            Try
                conection.Open()
                szQuery = "SELECT TOP 1 * FROM Tickets WHERE mnTicketNumber = " & TicketNumberBox.Text & " ORDER BY mnTicketNumber DESC, mnTicketLineNumber DESC"
                adapter = New OleDbDataAdapter(szQuery, conection)
                adapter.Fill(records, "Tickets")
                mnRows = records.Tables("Tickets").Rows.Count
                If mnRows <> 0 Then
                    CurrentStatusBox.Text = records.Tables("Tickets").Rows(0).Item("szStatus")
                    bResult = True
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            conection.Close()
        End If

        Return bResult
    End Function

    Private Function InsertClosingLine() As Boolean
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
        szQuery = szQuery & records.Tables("Tickets").Rows(0).Item("mnTicketLineNumber") + 1 & ", "
        'szTeam, 
        szQuery = szQuery & "'" & ReplaceApostrophesInString(Convert.ToString(records.Tables("Tickets").Rows(0).Item("szTeam"))) & "',"
        'szActivityCategory
        szQuery = szQuery & "'" & ReplaceApostrophesInString(Convert.ToString(records.Tables("Tickets").Rows(0).Item("szActivityCategory"))) & "',"
        'szResponsible
        szQuery = szQuery & "'" & ReplaceApostrophesInString(Convert.ToString(records.Tables("Tickets").Rows(0).Item("szResponsible"))) & "',"
        'szStatus
        szQuery = szQuery & "'" & "Close" & "',"
        'szPriority
        szQuery = szQuery & "'" & ReplaceApostrophesInString(Convert.ToString(records.Tables("Tickets").Rows(0).Item("szPriority"))) & "',"
        'szRequestor
        szQuery = szQuery & "'" & ReplaceApostrophesInString(Convert.ToString(records.Tables("Tickets").Rows(0).Item("szRequestor"))) & "',"
        'szBusinessUnit
        szQuery = szQuery & "'" & ReplaceApostrophesInString(Convert.ToString(records.Tables("Tickets").Rows(0).Item("szBusinessUnit"))) & "',"
        'szPendingSource
        szQuery = szQuery & "NULL,"
        'gdOpenDate
        szQuery = szQuery & "'" & Convert.ToString(records.Tables("Tickets").Rows(0).Item("gdOpenDate")) & "',"
        'gdCloseDate
        szQuery = szQuery & "'" & DateTime.Now.ToString(szDateTimeFormat) & "',"
        'szComments
        szQuery = szQuery & "'" & Convert.ToString(ReplaceApostrophesInString(CommentsBox.Text)) & "',"
        'szDescription
        szQuery = szQuery & "'" & Convert.ToString(ReplaceApostrophesInString(records.Tables("Tickets").Rows(0).Item("szDescription"))) & "',"
        'gdRequestedTime 
        szQuery = szQuery & "'" & Convert.ToString(ReplaceApostrophesInString(records.Tables("Tickets").Rows(0).Item("gdRequestedTime"))) & "',"
        'mnOpenDays
        szQuery = szQuery & 0 & ","
        'szAuditUser
        szQuery = szQuery & "'" & Convert.ToString(ReplaceApostrophesInString(Environment.UserName)) & "',"
        'szLocation
        szQuery = szQuery & "'" & Convert.ToString(ReplaceApostrophesInString(ConectionBox.Text)) & "',"
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
            MsgBox("Ticket closed", vbExclamation, "Alert")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

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