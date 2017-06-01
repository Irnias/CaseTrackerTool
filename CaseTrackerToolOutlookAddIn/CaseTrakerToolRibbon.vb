Imports Microsoft.Office.Interop.Outlook
Imports Microsoft.Office.Tools.Ribbon

Public Class CaseTrackerTool

    Private Sub CaseTrakerToolRibbon_Load(ByVal sender As System.Object, ByVal e As RibbonUIEventArgs) Handles MyBase.Load

    End Sub

    Private Sub AddCaseButton_Click(sender As Object, e As RibbonControlEventArgs) Handles AddCaseButton.Click
        Dim NewCaseForm As New NewCaseForm
        NewCaseForm.Show()
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

End Class
