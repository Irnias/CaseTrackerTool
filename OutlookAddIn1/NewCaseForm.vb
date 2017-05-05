Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports System.IO
Imports System.ComponentModel

Public Class NewCaseForm
    Dim OutApp As Outlook.Application
    Dim EmailSender As String
    Dim Subject As String
    Dim OutItem As Outlook.MailItem
    Dim OutReplyItem As Outlook.MailItem
    Dim conection As New OleDbConnection
    Dim Comandos As New OleDbCommand
    Dim CaseID As Long
    Dim comands As New OleDbCommand
    Dim adaptador As New OleDbDataAdapter
    Dim registros As New DataSet
    Dim consulta As String
    Dim lista As Long
    Public filePath As String
    Public filePath2 As String

    'si usas un "byte", maximo seran 256 registros
    'si usas un "entero corto", son aprox. 65mil
    'un "entero largo" o un autonumerico te permiten guardar aprox. 2 mil millones de registros

    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TeamBox.Items.Add("BSI")
        TeamBox.Items.Add("MAP")
        TeamBox.Items.Add("BPC")
        TeamBox.Items.Add("GT1")
        TeamBox.Items.Add("MIS")
        TeamBox.Items.Add("GFT")
        ConectionBox.Items.Add("Office")
        ConectionBox.Items.Add("Home")
        StatusBox.Items.Add("Closed")
        StatusBox.Items.Add("Open")
        TextBox6.Text = (DateTime.Now.ToString("MM/dd/yyyy"))
        filePath = "C:\Users\" & Environment.UserName & "\Resource Planning Tool.txt"
        ActCategoryBox.Items.AddRange(File.ReadAllLines(filePath))
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles CreateCaseButton.Click

        If (((ActCategoryBox.Text = "") Or (TicketNumberBox.Text = "")) Or ((StatusBox.Text = "Open") And (PendingSrcBox.Text = ""))) Then
            MsgBox("The ticket number field and Activity Category cannot be empty! If the ticket is open there must be a pending source.")

        Else
            Try
                consulta = ("SELECT * FROM TestTable ORDER BY ID DESC")
                adaptador = New OleDbDataAdapter(consulta, conection)
                registros = New DataSet
                adaptador.Fill(registros, "TestTable")
                lista = registros.Tables("TestTable").Rows.Count
                If lista <> 0 Then
                    DataGridView1.DataSource = registros
                    DataGridView1.DataMember = "TestTable"
                    TicketNumberBox.Text = TeamBox.Text & TrakingID.Text
                End If

                If TrakingID.Text = (registros.Tables("TestTable").Rows(0).Item("TicketNumber")) Then
                    TrakingID.Text = TrakingID.Text + 1
                    TicketNumberBox.Text = TeamBox.Text & TrakingID.Text
                End If

                comands = New OleDbCommand("INSERT INTO TestTable(MyITCase, Opened, Requestor, Analyst, BU, Description, PendingSource, Closed, ActivityCategory, Comments)" & Chr(13) &
                                           "VALUES(Textbox3, Textbox5, Textbox1, Combobox1, Textbox2, Subject, Textbox4, TextBox6, ComboBox4, TextBox7)", conection)

                comands.Parameters.AddWithValue("@MyITCase", TicketNumberBox.Text)
                comands.Parameters.AddWithValue("@Opened", DateBox.Text)
                comands.Parameters.AddWithValue("@Requestor", RequestorBox.Text)
                comands.Parameters.AddWithValue("@Analyst", ResponsibleBox.Text)
                comands.Parameters.AddWithValue("@BU", RegionBox.Text)
                comands.Parameters.AddWithValue("@Description", Subject)
                comands.Parameters.AddWithValue("@PendingSource", PendingSrcBox.Text)

                If StatusBox.Text = "Closed" Then
                    comands.Parameters.AddWithValue("@Closed", TextBox6.Text)
                Else
                    comands.Parameters.AddWithValue("@Closed", DBNull.Value)
                End If

                comands.Parameters.AddWithValue("@ActivityCategory", ActCategoryBox.Text)
                comands.Parameters.AddWithValue("@Comments", CommentsBox.Text)
                comands.ExecuteNonQuery()

                conection.Close()

                If StatusBox.Text = "Closed" Then               'si el caso fue cerrado o no
                    OutItem.Subject = OutItem.Subject & " - " & TrakingID.Text & " Completed"
                Else
                    OutItem.Subject = OutItem.Subject & " - " & TrakingID.Text
                End If

                OutItem.Save()
                MsgBox("Saved", vbInformation)


            Catch ex As Exception

                MsgBox("For some reason the case cannot be created. Please contact the administrator", vbCritical)

            End Try

            conection.Close()
            Me.Close()

        End If

    End Sub

    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        conection.Close()
        Me.Close()
    End Sub

    Public Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ConectionBox.SelectedIndexChanged


        Try
            If ConectionBox.Text = "Office" Then
                conection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = \\10.21.144.6\GBS Accenture Data\RTR\GA\MIS\Test1.accdb"
                conection.Open()
            Else
                conection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = \\ramxilss002-f04.bp.com\ACNOPs\BA\Mariner\Mariner\RTR\MIS\Test1.accdb"
                conection.Open()
            End If

        Catch ex As Exception

        End Try


        Try
            consulta = ("SELECT * FROM TestTable ORDER BY ID DESC")
            adaptador = New OleDbDataAdapter(consulta, conection)
            registros = New DataSet
            adaptador.Fill(registros, "TestTable")
            lista = registros.Tables("TestTable").Rows.Count
            If lista <> 0 Then
                DataGridView1.DataSource = registros
                DataGridView1.DataMember = "TestTable"
                TrakingID.Text = (registros.Tables("TestTable").Rows(0).Item("TicketNumber")) + 1
                TicketNumberBox.Text = TeamBox.Text & TrakingID.Text                                     'FUNCIONA PARA BSI
            End If
        Catch ex As Exception
            MsgBox("Error when trying to get the ticket number. Please contact the administrator", vbCritical)
        End Try

        filePath = "C:\Users\" & Environment.UserName & "\UserList.txt"

        Try
            DateBox.Text = (DateTime.Now.ToString("MM/dd/yyyy"))
            ResponsibleBox.Items.Clear()
            ResponsibleBox.Items.AddRange(File.ReadAllLines(filePath))

        Catch ex As Exception
            MsgBox("Error when trying yo get the analyst names", vbCritical)
        End Try

        Try

            OutApp = CreateObject("Outlook.Application")
            OutItem = OutApp.ActiveInspector.CurrentItem
            EmailSender = OutItem.SenderName
            RequestorBox.Text = EmailSender
            Subject = OutItem.Subject
            ' TextBox6.Text = "Closed"

        Catch ex As Exception
            MsgBox("Error when trying to get data from the current email item", vbCritical)
        End Try

    End Sub

    Private Sub ComboBox2_MouseClick(sender As Object, e As MouseEventArgs) Handles ConectionBox.MouseClick

    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        conection.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles RegionBox.TextChanged

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub
End Class




