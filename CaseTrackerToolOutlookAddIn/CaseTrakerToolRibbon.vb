Imports Microsoft.Office.Interop.Outlook
Imports Microsoft.Office.Tools.Ribbon

Public Class CaseTrackerTool

    Private Sub CaseTrakerToolRibbon_Load(ByVal sender As System.Object, ByVal e As RibbonUIEventArgs) Handles MyBase.Load

    End Sub

    Private Sub AddCaseButton_Click(sender As Object, e As RibbonControlEventArgs) Handles AddCaseButton.Click
        'My.Computer.FileSystem.ReadAllText("C:\Users\" & Environment.UserName & "\Resource Planning Tool.txt", System.Text.Encoding.UTF32)
        If Not My.Computer.FileSystem.FileExists("C:\Users\" & Environment.UserName & "\Resource Planning Tool.txt") Then
            MsgBox("It seems that you didn't enter your Team's activities. Please go to Settings and add them")
        ElseIf Not My.Computer.FileSystem.FileExists("C:\Users\" & Environment.UserName & "\UserList.txt") Then
            MsgBox("It seems that you didn't enter your Team's members. Please go to Settings and add them")
        ElseIf Not (My.Computer.FileSystem.FileExists("C:\Users\" & Environment.UserName & "\OfficeConection.txt") Or (My.Computer.FileSystem.FileExists("C:\Users\" & Environment.UserName & "\HomeConection.txt"))) Then
            MsgBox("To use the tracker, first you need to mapp the database")
        Else
            Dim NewCaseForm As New NewCaseForm
            NewCaseForm.Show()
        End If
    End Sub

    Private Sub ModifyCaseButton_Click(sender As Object, e As RibbonControlEventArgs) Handles ModifyCaseButton.Click
        Dim ModifyCaseForm As New ModifyCaseForm
        ModifyCaseForm.Show()
    End Sub

    Private Sub NotifyIssueButton_Click(sender As Object, e As RibbonControlEventArgs) Handles NotifyIssueButton.Click

        Dim NewMessage As Outlook.MailItem
        Dim OutlookAppli As Outlook.Application
        OutlookAppli = CreateObject("Outlook.Application")
        NewMessage = OutlookAppli.CreateItem(OlItemType.olMailItem)
        NewMessage.To = "CaseTrackingToolSupport@accenture.com"
        NewMessage.Subject = "Case Tracker Tool | Issue Notification"
        NewMessage.Display()
    End Sub

    Private Sub Button1_Click(sender As Object, e As RibbonControlEventArgs) Handles Button1.Click
        Dim OutApp As Outlook.Application
        Dim OutItem As Outlook.MailItem
        Dim ID As String
        Dim ID2 As String

    End Sub
End Class
