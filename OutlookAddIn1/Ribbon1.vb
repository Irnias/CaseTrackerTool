Imports Microsoft.Office.Tools.Ribbon
Imports System
Imports System.IO
Imports System.Text

Public Class Ribbon1

    Private Sub Ribbon1_Load(ByVal sender As System.Object, ByVal e As RibbonUIEventArgs) Handles MyBase.Load

    End Sub

    Private Sub ToggleButton1_Click(sender As Object, e As RibbonControlEventArgs)

    End Sub

    Private Sub ToggleButton2_Click(sender As Object, e As RibbonControlEventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As RibbonControlEventArgs) Handles Button1.Click

        'My.Computer.FileSystem.ReadAllText("C:\Users\" & Environment.UserName & "\Resource Planning Tool.txt", System.Text.Encoding.UTF32)
        If Not My.Computer.FileSystem.FileExists("C:\Users\" & Environment.UserName & "\Resource Planning Tool.txt") Then
            MsgBox("It seems that you didn't enter youR Team's activities. Please go to Settings and add them")
        ElseIf Not My.Computer.FileSystem.FileExists("C:\Users\" & Environment.UserName & "\UserList.txt") Then
            MsgBox("It seems that you didn't enter your Team's members. Please go to Settings and add them")
        ElseIf Not (My.Computer.FileSystem.FileExists("C:\Users\" & Environment.UserName & "\OfficeConection.txt") Or (My.Computer.FileSystem.FileExists("C:\Users\" & Environment.UserName & "\HomeConection.txt"))) Then
            MsgBox("To use the tracker, first you need to mapp the database")
        Else
            Dim form1 As New Form1
            form1.Show()
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As RibbonControlEventArgs) Handles Button3.Click
        Dim form2 As New Form2

        form2.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As RibbonControlEventArgs)

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As RibbonControlEventArgs)

    End Sub

End Class
