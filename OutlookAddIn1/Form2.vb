Imports System.ComponentModel
Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms

Public Class Form2
    Dim conexion As New OleDbConnection
    Dim adaptador As New OleDbDataAdapter
    Dim registros As New DataSet
    Dim OutlookAppli As Outlook.Application
    Dim Subject As String
    Dim Outlookitem As Outlook.MailItem

    Private Sub Form2_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
        TextBox9.Enabled = False

        ComboBox2.Items.Add("Office")
        ComboBox2.Items.Add("Home")

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox1.Text = "MaxForm" Then


            Me.WindowState = FormWindowState.Maximized

            DataGridView1.Width = 1350
            DataGridView1.Height = 100
        Else

            Try
                Dim consultar As String
                Dim lista As Byte
                If TextBox1.Text <> "" Then
                    consultar = "SELECT * FROM TestTable WHERE MyITCase = '" & TextBox1.Text & "'"
                    adaptador = New OleDbDataAdapter(consultar, conexion)
                    registros = New DataSet
                    adaptador.Fill(registros, "TestTable")
                    lista = registros.Tables("TestTable").Rows.Count
                    If lista <> 0 Then
                        DataGridView1.DataSource = registros
                        DataGridView1.DataMember = "TestTable"
                        TextBox2.Text = registros.Tables("TestTable").Rows(0).Item("Analyst")
                        TextBox4.Text = registros.Tables("TestTable").Rows(0).Item("Opened")
                        TextBox3.Text = registros.Tables("TestTable").Rows(0).Item("BU")
                        TextBox5.Text = registros.Tables("TestTable").Rows(0).Item("Requestor")
                        TextBox6.Text = registros.Tables("TestTable").Rows(0).Item("PendingSource")
                        TextBox7.Text = registros.Tables("TestTable").Rows(0).Item("Status")
                        TextBox9.Text = registros.Tables("TestTable").Rows(0).Item("Comments")

                    Else
                        MsgBox("Unable to find case", vbExclamation, "Alert")
                        TextBox1.Clear()
                        DataGridView1.Columns.Clear()
                        TextBox1.Focus()
                    End If

                End If

            Catch ex As Exception
                MsgBox("Unable to find case", vbExclamation, "Alert")
            End Try
        End If

    End Sub

    Private Sub Form2_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        conexion.Close()
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        TextBox6.Enabled = True
        TextBox9.Enabled = True
    End Sub

    Dim comandos As New OleDbCommand
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim actualizar As String
        '  actualizar = "UPDATE TestTable SET PendingSource = '" & TextBox6.Text & "' WHERE MyITCase = '" & TextBox1.Text & "'"

        actualizar = "UPDATE TestTable SET Analyst = '" & TextBox2.Text &
         "', BU = '" & TextBox3.Text &
         "', Opened = '" & TextBox4.Text &
         "', Requestor = '" & TextBox5.Text &
         "', PendingSource = '" & TextBox6.Text &
         "', Comments = '" & TextBox9.Text &
         "' WHERE MyITCase = '" & TextBox1.Text & "'"

        comandos = New OleDbCommand(actualizar, conexion)
        comandos.ExecuteNonQuery()
        MsgBox("Changes Done", vbInformation, "Alert")
        conexion.Close()

    End Sub

    Private Sub Form2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        If TextBox7.Text <> "Closed" Or TextBox6.Text <> "" Then

            Try
                Dim actualizar As String
                actualizar = "UPDATE TestTable SET Closed = '" & (DateTime.Now.ToString("MM/dd/yyyy")) & "' WHERE MyITCase = '" & TextBox1.Text & "'"
                comandos = New OleDbCommand(actualizar, conexion)
                comandos.ExecuteNonQuery()
                ' Outlookitem.Subject = Outlookitem.Subject & " - " & "Ticket closed"
                MsgBox("Case closed correctly", vbInformation, "Correct")

            Catch ex As Exception
                MsgBox("The case cannot be closed", vbInformation, "Correct")
            End Try

            OutlookAppli = CreateObject("Outlook.Application")
            Outlookitem = OutlookAppli.ActiveInspector.CurrentItem

            Try
                Outlookitem.Subject = Outlookitem.Subject & "Completed"
            Catch ex As Exception
            End Try

            TextBox7.Text = "Closed"
            Outlookitem.Save()
        Else
            MsgBox("Make sure the ticket is not already closed and the pending source field is blank", vbInformation, "Ticket already closed")

        End If


    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        If TextBox7.Text <> "Opened" Then

            Try
                Dim actualizar As String

                actualizar = "UPDATE TestTable SET Closed = NULL WHERE MyITCase = '" & TextBox1.Text & "'"
                comandos = New OleDbCommand(actualizar, conexion)
                comandos.ExecuteNonQuery()
                MsgBox("Case Opened correctly", vbInformation, "Correct")

            Catch ex As Exception
                MsgBox("The case cannot be opened", vbInformation, "Correct")
            End Try

            OutlookAppli = CreateObject("Outlook.Application")
            Outlookitem = OutlookAppli.ActiveInspector.CurrentItem

            Try
                Outlookitem.Subject = Replace(Outlookitem.Subject, "Completed", "")
            Catch ex As Exception
            End Try

            TextBox7.Text = "Opened"
            Outlookitem.Save()
        Else
            MsgBox("The ticket is already opened.", vbInformation, "Ticket already opened")

        End If

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.Text = "Office" Then
            conexion.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = \\10.21.144.6\GBS Accenture Data\RTR\GA\MIS\Test1.accdb"
            conexion.Open()
        Else
            conexion.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = \\ramxilss002-f04.bp.com\ACNOPs\BA\Mariner\Mariner\RTR\MIS\Test1.accdb"
            conexion.Open()
        End If

        conexion.Open()
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
        TextBox7.Enabled = False
        TextBox1.Focus()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Form2_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        conexion.Close()
    End Sub
End Class