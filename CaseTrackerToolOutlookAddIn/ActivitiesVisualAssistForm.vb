Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms

Public Class ActivitiesVisualAssistForm
    Dim conection As New OleDbConnection
    Dim adapter As New OleDbDataAdapter
    Dim records As New DataSet
    Dim teamActivities As String = ""
    Dim selectedActivity As String = ""

    Private Sub ActivitiesVisualAssistForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim result As Boolean = False
        Dim query As String
        Dim Rows As Integer

        If conection.State = ConnectionState.Open Then
            conection.Close()
        End If

        'Try to conect
        Try
            conection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = \\10.21.144.6\GBS Accenture Data\RTR\GA\MIS\Test1.accdb"
            conection.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'Try to retrieve activities
        Try

            query = "SELECT szActivityCode, szActivity, szLongDescription, szSubTeam FROM TeamsActivities WHERE SubTeam = '" & teamActivities & "' ORDER BY 1 ASC, 2 ASC"
            adapter = New OleDbDataAdapter(query, conection)
            adapter.Fill(records, "TeamsActivities")
            Rows = records.Tables("TeamsActivities").Rows.Count

            If Rows <> 0 Then
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
                For x = 0 To Rows - 1
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
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        conection.Close()
    End Sub

    Private Sub ActivitiesVisualAssistForm_Close(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Finalize()
    End Sub

    Public Sub ActivitiesVisualAssistGrid_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub ActivitiesVisualAssistGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ActivitiesVisualAssistGrid.CellContentClick
        selectedActivity = ActivitiesVisualAssistGrid.SelectedRows.Item(0).Cells(1).FormattedValue
        Me.Hide()
    End Sub

    Public Function SetActivitiesTeam(team As String) As Boolean
        teamActivities = team
        Return True
    End Function

    Public Function GetSelectedActivity() As String
        Return selectedActivity
    End Function

End Class
