﻿Partial Class CaseTrackerTool
    Inherits Microsoft.Office.Tools.Ribbon.RibbonBase

    <System.Diagnostics.DebuggerNonUserCode()>
    Public Sub New(ByVal container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        If (container IsNot Nothing) Then
            container.Add(Me)
        End If

    End Sub

    <System.Diagnostics.DebuggerNonUserCode()>
    Public Sub New()
        MyBase.New(Globals.Factory.GetRibbonFactory())

        'This call is required by the Component Designer.
        InitializeComponent()

    End Sub

    'Component overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CaseTrackerTool))
        Me.PerformanceTrackingToolTab = Me.Factory.CreateRibbonTab
        Me.OptionsGroup = Me.Factory.CreateRibbonGroup
        Me.AddCaseButton = Me.Factory.CreateRibbonButton
        Me.ModifyCaseButton = Me.Factory.CreateRibbonButton
        Me.CloseCaseButton = Me.Factory.CreateRibbonButton
        Me.SearchCaseButton = Me.Factory.CreateRibbonButton
        Me.IssuesGroup = Me.Factory.CreateRibbonGroup
        Me.NotifyIssueButton = Me.Factory.CreateRibbonButton
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.PerformanceTrackingToolTab.SuspendLayout()
        Me.OptionsGroup.SuspendLayout()
        Me.IssuesGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'PerformanceTrackingToolTab
        '
        Me.PerformanceTrackingToolTab.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office
        Me.PerformanceTrackingToolTab.Groups.Add(Me.OptionsGroup)
        Me.PerformanceTrackingToolTab.Groups.Add(Me.IssuesGroup)
        Me.PerformanceTrackingToolTab.KeyTip = "C"
        Me.PerformanceTrackingToolTab.Label = "Performance Tracking Tool"
        Me.PerformanceTrackingToolTab.Name = "PerformanceTrackingToolTab"
        '
        'OptionsGroup
        '
        Me.OptionsGroup.Items.Add(Me.AddCaseButton)
        Me.OptionsGroup.Items.Add(Me.ModifyCaseButton)
        Me.OptionsGroup.Items.Add(Me.CloseCaseButton)
        Me.OptionsGroup.Items.Add(Me.SearchCaseButton)
        Me.OptionsGroup.Label = "Options"
        Me.OptionsGroup.Name = "OptionsGroup"
        '
        'AddCaseButton
        '
        Me.AddCaseButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.AddCaseButton.Image = CType(resources.GetObject("AddCaseButton.Image"), System.Drawing.Image)
        Me.AddCaseButton.KeyTip = "A"
        Me.AddCaseButton.Label = "Add Case"
        Me.AddCaseButton.Name = "AddCaseButton"
        Me.AddCaseButton.ShowImage = True
        '
        'ModifyCaseButton
        '
        Me.ModifyCaseButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.ModifyCaseButton.Image = CType(resources.GetObject("ModifyCaseButton.Image"), System.Drawing.Image)
        Me.ModifyCaseButton.KeyTip = "M"
        Me.ModifyCaseButton.Label = "Modify Case"
        Me.ModifyCaseButton.Name = "ModifyCaseButton"
        Me.ModifyCaseButton.ShowImage = True
        '
        'CloseCaseButton
        '
        Me.CloseCaseButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.CloseCaseButton.Image = CType(resources.GetObject("CloseCaseButton.Image"), System.Drawing.Image)
        Me.CloseCaseButton.KeyTip = "C"
        Me.CloseCaseButton.Label = "Close Case"
        Me.CloseCaseButton.Name = "CloseCaseButton"
        Me.CloseCaseButton.ShowImage = True
        '
        'SearchCaseButton
        '
        Me.SearchCaseButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.SearchCaseButton.Image = CType(resources.GetObject("SearchCaseButton.Image"), System.Drawing.Image)
        Me.SearchCaseButton.KeyTip = "S"
        Me.SearchCaseButton.Label = "Search Case"
        Me.SearchCaseButton.Name = "SearchCaseButton"
        Me.SearchCaseButton.ShowImage = True
        '
        'IssuesGroup
        '
        Me.IssuesGroup.Items.Add(Me.NotifyIssueButton)
        Me.IssuesGroup.Label = "Issues"
        Me.IssuesGroup.Name = "IssuesGroup"
        '
        'NotifyIssueButton
        '
        Me.NotifyIssueButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.NotifyIssueButton.Image = CType(resources.GetObject("NotifyIssueButton.Image"), System.Drawing.Image)
        Me.NotifyIssueButton.KeyTip = "N"
        Me.NotifyIssueButton.Label = "Notify Issue"
        Me.NotifyIssueButton.Name = "NotifyIssueButton"
        Me.NotifyIssueButton.ShowImage = True
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'CaseTrackerTool
        '
        Me.Name = "CaseTrackerTool"
        Me.RibbonType = resources.GetString("$this.RibbonType")
        Me.Tabs.Add(Me.PerformanceTrackingToolTab)
        Me.PerformanceTrackingToolTab.ResumeLayout(False)
        Me.PerformanceTrackingToolTab.PerformLayout()
        Me.OptionsGroup.ResumeLayout(False)
        Me.OptionsGroup.PerformLayout()
        Me.IssuesGroup.ResumeLayout(False)
        Me.IssuesGroup.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PerformanceTrackingToolTab As Microsoft.Office.Tools.Ribbon.RibbonTab
    Friend WithEvents AddCaseButton As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents OptionsGroup As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ModifyCaseButton As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents IssuesGroup As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents NotifyIssueButton As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents CloseCaseButton As RibbonButton
    Friend WithEvents SearchCaseButton As RibbonButton
End Class

Partial Class ThisRibbonCollection

    <System.Diagnostics.DebuggerNonUserCode()> _
    Friend ReadOnly Property Ribbon1() As CaseTrackerTool
        Get
            Return Me.GetRibbon(Of CaseTrackerTool)()
        End Get
    End Property
End Class