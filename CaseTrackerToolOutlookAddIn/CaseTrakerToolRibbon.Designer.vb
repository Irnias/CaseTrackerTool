Partial Class CaseTrackerTool
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
        Me.CaseTrackerToolTab = Me.Factory.CreateRibbonTab
        Me.OptionsGroup = Me.Factory.CreateRibbonGroup
        Me.AddCaseButton = Me.Factory.CreateRibbonButton
        Me.ModifyCaseButton = Me.Factory.CreateRibbonButton
        Me.IssuesGroup = Me.Factory.CreateRibbonGroup
        Me.NotifyIssueButton = Me.Factory.CreateRibbonButton
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.CaseTrackerToolTab.SuspendLayout()
        Me.OptionsGroup.SuspendLayout()
        Me.IssuesGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'CaseTrackerToolTab
        '
        Me.CaseTrackerToolTab.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office
        Me.CaseTrackerToolTab.Groups.Add(Me.OptionsGroup)
        Me.CaseTrackerToolTab.Groups.Add(Me.IssuesGroup)
        Me.CaseTrackerToolTab.Label = "Case Tracker Tool"
        Me.CaseTrackerToolTab.Name = "CaseTrackerToolTab"
        '
        'OptionsGroup
        '
        Me.OptionsGroup.Items.Add(Me.AddCaseButton)
        Me.OptionsGroup.Items.Add(Me.ModifyCaseButton)
        Me.OptionsGroup.Label = "Options"
        Me.OptionsGroup.Name = "OptionsGroup"
        '
        'AddCaseButton
        '
        Me.AddCaseButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.AddCaseButton.Image = CType(resources.GetObject("AddCaseButton.Image"), System.Drawing.Image)
        Me.AddCaseButton.Label = "Add Case"
        Me.AddCaseButton.Name = "AddCaseButton"
        Me.AddCaseButton.ShowImage = True
        '
        'ModifyCaseButton
        '
        Me.ModifyCaseButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.ModifyCaseButton.Image = CType(resources.GetObject("ModifyCaseButton.Image"), System.Drawing.Image)
        Me.ModifyCaseButton.Label = "Modify Case"
        Me.ModifyCaseButton.Name = "ModifyCaseButton"
        Me.ModifyCaseButton.ShowImage = True
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
        Me.RibbonType = "Microsoft.Outlook.Appointment, Microsoft.Outlook.Mail.Compose, Microsoft.Outlook." &
    "Mail.Read, Microsoft.Outlook.MeetingRequest.Read, Microsoft.Outlook.MeetingReque" &
    "st.Send, Microsoft.Outlook.Resend"
        Me.Tabs.Add(Me.CaseTrackerToolTab)
        Me.CaseTrackerToolTab.ResumeLayout(False)
        Me.CaseTrackerToolTab.PerformLayout()
        Me.OptionsGroup.ResumeLayout(False)
        Me.OptionsGroup.PerformLayout()
        Me.IssuesGroup.ResumeLayout(False)
        Me.IssuesGroup.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CaseTrackerToolTab As Microsoft.Office.Tools.Ribbon.RibbonTab
    Friend WithEvents AddCaseButton As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents OptionsGroup As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ModifyCaseButton As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents IssuesGroup As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents NotifyIssueButton As Microsoft.Office.Tools.Ribbon.RibbonButton
End Class

Partial Class ThisRibbonCollection

    <System.Diagnostics.DebuggerNonUserCode()> _
    Friend ReadOnly Property Ribbon1() As CaseTrackerTool
        Get
            Return Me.GetRibbon(Of CaseTrackerTool)()
        End Get
    End Property
End Class
