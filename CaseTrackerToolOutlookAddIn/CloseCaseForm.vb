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

    Private Sub CloseCaseForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Enable conection box
        ConectionBox.Enabled = True

        'Load ConectionBox
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
        CurrentStatusBox.Text = ""
        TicketNumberBox.Text = ""
        TicketNumberBox.Enabled = True
        TicketNumberBox.Focus()

        'Retrieve data from email
        ParseEmail()

    End Sub

    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click
        If TicketNumberBox.Text.Trim <> "" Then
            If SearchTicketNumber(TicketNumberBox.Text) = True Then
                CommentsBox.Enabled = True
                CloseCaseButton.Enabled = True
            Else
                TicketNumberBox.Text = ""
                CurrentStatusBox.Text = ""
                CommentsBox.Text = ""
                CommentsBox.Enabled = False
                CloseCaseButton.Enabled = False

                'Ticket does not exist
                MsgBox("Ticket does not exist", vbExclamation, "Alert")
                TicketNumberBox.Focus()
            End If
        End If
    End Sub

    Private Sub CloseCaseButton_Click(sender As Object, e As EventArgs) Handles CloseCaseButton.Click
        'Validate ticket existence
        If Not SearchTicketNumber(TicketNumberBox.Text) Then
            'Ticket does not exist
            MsgBox("Ticket does not exist", vbExclamation, "Alert")
            Exit Sub
        End If

        'Ticket must be closed
        If CurrentStatusBox.Text = "Close" Then
            MsgBox("Ticket already Closed", vbExclamation, "Alert")
            Exit Sub
        End If

        If InsertClosingLine() Then
            'Change mail status 
            'Mail szSubject | Ticket Number| Ticket Status
            OutlookItem.Subject = records.Tables("Tickets").Rows(0).Item("szDescription") & " | TK"
            OutlookItem.Subject = OutlookItem.Subject & TicketNumberBox.Text.PadLeft(10, "0")
            OutlookItem.Subject = OutlookItem.Subject & " | Close"

            OutlookItem.Save()
        End If

        Me.Close()
    End Sub

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

        If TicketNumberBox.Text <> "" Then
            'Format query
            query = "INSERT INTO Tickets(mnTicketNumber, mnTicketLineNumber, szTeam, szActivityCategory, szResponsible, szStatus, szPriority, szRequestor, szBusinessUnit, szPendingSource, gdOpenDate, gdCloseDate, szComments, szDescription, gdRequestedTime, mnOpenDays, szAuditUser, szLocation, gdCreationDate)"
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
            query = query & "'" & ReplaceApostrophesInString(records.Tables("Tickets").Rows(0).Item("szResponsible")) & "', "
            'szStatus
            query = query & "'" & "Close" & "', "
            'szPriority
            query = query & "'" & ReplaceApostrophesInString(records.Tables("Tickets").Rows(0).Item("szPriority")) & "', "
            'szRequestor
            query = query & "'" & ReplaceApostrophesInString(records.Tables("Tickets").Rows(0).Item("szRequestor")) & "', "
            'szBusinessUnit
            query = query & "'" & ReplaceApostrophesInString(records.Tables("Tickets").Rows(0).Item("szBusinessUnit")) & "', "
            'szPendingSource
            query = query & "'" & DBNull.Value & "', "
            'gdOpenDate
            query = query & "'" & records.Tables("Tickets").Rows(0).Item("gdOpenDate") & "', "
            'gdCloseDate
            query = query & "'" & (DateTime.Now.ToString("MM/dd/yyyy")) & "', "
            'szComments
            query = query & "'" & ReplaceApostrophesInString(CommentsBox.Text) & "', "
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
            query = query & "'" & DateTime.Now.ToString("MM/dd/yyyy") & "')"

            Try
                'Perform query
                conection.Open()
                command = New OleDbCommand(query, conection)
                command.ExecuteNonQuery()

                'Notify transaction status
                MsgBox("Ticket closed", vbExclamation, "Alert")
                result = True
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            conection.Close()
        Else
            'Ticket does not exist
            MsgBox("Ticket does not exist", vbExclamation, "Alert")
        End If
        Return result
    End Function

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