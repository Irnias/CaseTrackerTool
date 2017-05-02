Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports System.IO
Imports System.ComponentModel

Public Class Form1
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
        ComboBox5.Items.Add("BSI")
        ComboBox5.Items.Add("MAP")
        ComboBox5.Items.Add("BPC")
        ComboBox5.Items.Add("GT1")
        ComboBox5.Items.Add("MIS")
        ComboBox5.Items.Add("GFT")
        ComboBox2.Items.Add("Office")
        ComboBox2.Items.Add("Home")
        ComboBox3.Items.Add("Closed")
        ComboBox3.Items.Add("Open")
        TextBox6.Text = (DateTime.Now.ToString("MM/dd/yyyy"))
        filePath = "C:\Users\" & Environment.UserName & "\Resource Planning Tool.txt"
        ComboBox4.Items.AddRange(File.ReadAllLines(filePath))
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If (((ComboBox4.Text = "") Or (TextBox3.Text = "")) Or ((ComboBox3.Text = "Open") And (TextBox4.Text = ""))) Then
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
                    TextBox3.Text = ComboBox5.Text & Label2.Text
                End If

                If Label2.Text = (registros.Tables("TestTable").Rows(0).Item("TicketNumber")) Then
                    Label2.Text = Label2.Text + 1
                    TextBox3.Text = ComboBox5.Text & Label2.Text
                End If

                comands = New OleDbCommand("INSERT INTO TestTable(MyITCase, Opened, Requestor, Analyst, BU, Description, PendingSource, Closed, ActivityCategory, Comments)" & Chr(13) &
                                           "VALUES(Textbox3, Textbox5, Textbox1, Combobox1, Textbox2, Subject, Textbox4, TextBox6, ComboBox4, TextBox7)", conection)

                comands.Parameters.AddWithValue("@MyITCase", TextBox3.Text)
                comands.Parameters.AddWithValue("@Opened", TextBox5.Text)
                comands.Parameters.AddWithValue("@Requestor", TextBox1.Text)
                comands.Parameters.AddWithValue("@Analyst", ComboBox1.Text)
                comands.Parameters.AddWithValue("@BU", TextBox2.Text)
                comands.Parameters.AddWithValue("@Description", Subject)
                comands.Parameters.AddWithValue("@PendingSource", TextBox4.Text)

                If ComboBox3.Text = "Closed" Then
                    comands.Parameters.AddWithValue("@Closed", TextBox6.Text)
                Else
                    comands.Parameters.AddWithValue("@Closed", DBNull.Value)
                End If

                comands.Parameters.AddWithValue("@ActivityCategory", ComboBox4.Text)
                comands.Parameters.AddWithValue("@Comments", TextBox7.Text)
                comands.ExecuteNonQuery()

                conection.Close()

                If ComboBox3.Text = "Closed" Then               'si el caso fue cerrado o no
                    OutItem.Subject = OutItem.Subject & " - " & Label2.Text & " Completed"
                Else
                    OutItem.Subject = OutItem.Subject & " - " & Label2.Text
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

    Public Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged


        Try
            If ComboBox2.Text = "Office" Then
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
                Label2.Text = (registros.Tables("TestTable").Rows(0).Item("TicketNumber")) + 1
                TextBox3.Text = ComboBox5.Text & Label2.Text                                     'FUNCIONA PARA BSI
            End If
        Catch ex As Exception
            MsgBox("Error when trying to get the ticket number. Please contact the administrator", vbCritical)
        End Try

        filePath = "C:\Users\" & Environment.UserName & "\UserList.txt"

        Try
            TextBox5.Text = (DateTime.Now.ToString("MM/dd/yyyy"))
            ComboBox1.Items.Clear()
            ComboBox1.Items.AddRange(File.ReadAllLines(filePath))

        Catch ex As Exception
            MsgBox("Error when trying yo get the analyst names", vbCritical)
        End Try

        Try

            OutApp = CreateObject("Outlook.Application")
            OutItem = OutApp.ActiveInspector.CurrentItem
            EmailSender = OutItem.SenderName
            TextBox1.Text = EmailSender
            Subject = OutItem.Subject
            ' TextBox6.Text = "Closed"

        Catch ex As Exception
            MsgBox("Error when trying to get data from the current email item", vbCritical)
        End Try

    End Sub

    Private Sub ComboBox2_MouseClick(sender As Object, e As MouseEventArgs) Handles ComboBox2.MouseClick

    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        conection.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)

    End Sub
End Class




