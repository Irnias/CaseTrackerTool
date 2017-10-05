Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Windows.Forms

Public Class ActivitiesVisualAssistForm
    Dim conection As New OleDbConnection
    Dim adapter As New OleDbDataAdapter
    Dim records As New DataSet

    Dim szTeam As String = ""
    Dim szselectedActivity As String = ""

    'Form Activities
    Private Sub ActivitiesVisualAssistForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim bResult As Boolean = False
        Dim szQuery As String
        Dim mnRows As Integer

        '****************************
        'Try to retrieve activities
        '****************************
        Try
            'Format query and try to conect
            szQuery = "SELECT szActivityCode, szActivity, szLongDescription, szSubTeam FROM TeamsActivities WHERE szSubTeam = '" & szTeam & "' ORDER BY 2 ASC, 1 ASC"

            conection.Open()
            adapter = New OleDbDataAdapter(szQuery, conection)
            adapter.Fill(records, "TeamsActivities")
            mnRows = records.Tables("TeamsActivities").Rows.Count
            conection.Close()

            bResult = True
        Catch ex As Exception
            bResult = False
            MsgBox(ex.Message)
        End Try

        '****************************
        'Process retrieved activities
        '****************************
        If mnRows <> 0 And bResult = True Then
            Dim auxiliarGrid As New DataTable
            Dim szActivityCode As String = ""
            Dim szActivity As String = ""
            Dim szLongDescription As String = ""
            Dim szSubTeam As String = ""

            'Clean grid
            auxiliarGrid.Clear()

            'Load grid columns
            auxiliarGrid.Columns.Add("Activity Code", GetType(String))
            auxiliarGrid.Columns.Add("Activity", GetType(String))
            auxiliarGrid.Columns.Add("Activity Description", GetType(String))
            auxiliarGrid.Columns.Add("Team", GetType(String))

            'Repeat For Grid
            For x = 0 To mnRows - 1
                szActivityCode = Convert.ToString(records.Tables("TeamsActivities").Rows(x).Item("szActivityCode"))
                szActivity = Convert.ToString(records.Tables("TeamsActivities").Rows(x).Item("szActivity"))
                szLongDescription = Convert.ToString(records.Tables("TeamsActivities").Rows(x).Item("szLongDescription"))
                szSubTeam = Convert.ToString(records.Tables("TeamsActivities").Rows(x).Item("szSubTeam"))

                'Format Row
                szActivityCode.Trim()
                szActivity.Trim()
                szLongDescription.Trim()
                szSubTeam.Trim()

                'Insert Row
                auxiliarGrid.Rows.Add(szActivityCode, szActivity, szLongDescription, szSubTeam)
            Next

            'Load Grid
            ActivitiesVisualAssistGrid.DataSource = auxiliarGrid

            'Unselect default rows 
            ActivitiesVisualAssistGrid.ClearSelection()
        End If

    End Sub

    Private Sub ActivitiesVisualAssistForm_Close(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Finalize()
    End Sub

    Public Sub ActivitiesVisualAssistGrid_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    'Grid Sub / Functions
    Private Sub ActivitiesVisualAssistGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ActivitiesVisualAssistGrid.CellContentClick
        szselectedActivity = ActivitiesVisualAssistGrid.SelectedRows.Item(0).Cells(1).FormattedValue
        Me.Hide()
    End Sub

    'Getters and setters
    Public Function SetConection(szConection As String) As Boolean
        Dim bReturnValue As Boolean = False
        Dim szIniFilePath As String = "C:\Users\" & Environment.UserName & "\PTT\PTTConfig.ini"
        Dim szHomeConection As String = ""
        Dim szOfficeConection As String = ""

        '****************************
        'Validate conection type
        '****************************
        If szConection = "ACN" Or szConection = "Home - Office" Then
            bReturnValue = True
        End If

        '****************************
        'Search and parse INI
        '****************************
        If bReturnValue = True Then
            If (File.Exists(szIniFilePath) <> True) Then
                MsgBox("Ini File does not exist", vbExclamation, "Alert")
                bReturnValue = False
            End If
        End If

        '****************************
        ''Get INI Information
        '****************************
        If bReturnValue = True Then
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
                If szConection = "ACN" Then
                    conection.ConnectionString = szOfficeConection
                Else
                    conection.ConnectionString = szHomeConection
                End If
            Catch ex As System.Exception
                bReturnValue = False
                MsgBox(ex.Message)
            End Try
        End If

        Return bReturnValue
    End Function

    Public Function SetActivitiesTeam(szTeam As String) As Boolean
        Me.szTeam = szTeam
        Return True
    End Function

    Public Function GetSelectedActivity() As String
        Return szselectedActivity
    End Function

End Class
