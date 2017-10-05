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
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContactUsGroup = Me.Factory.CreateRibbonGroup
        Me.ContactAdministratorsButton = Me.Factory.CreateRibbonButton
        Me.OptionsGroup = Me.Factory.CreateRibbonGroup
        Me.AddCaseButton = Me.Factory.CreateRibbonButton
        Me.ModifyCaseButton = Me.Factory.CreateRibbonButton
        Me.CloseCaseButton = Me.Factory.CreateRibbonButton
        Me.SearchCaseButton = Me.Factory.CreateRibbonButton
        Me.PerformanceTrackingToolTab = Me.Factory.CreateRibbonTab
        Me.VersionID = Me.Factory.CreateRibbonGroup
        Me.VersionLabel = Me.Factory.CreateRibbonLabel
        Me.SendLocalDataBaseButton = Me.Factory.CreateRibbonButton
        Me.ContactUsGroup.SuspendLayout()
        Me.OptionsGroup.SuspendLayout()
        Me.PerformanceTrackingToolTab.SuspendLayout()
        Me.VersionID.SuspendLayout()
        Me.SuspendLayout()
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'ContactUsGroup
        '
        Me.ContactUsGroup.Items.Add(Me.SendLocalDataBaseButton)
        Me.ContactUsGroup.Items.Add(Me.ContactAdministratorsButton)
        Me.ContactUsGroup.Label = "Contact Us"
        Me.ContactUsGroup.Name = "ContactUsGroup"
        '
        'ContactAdministratorsButton
        '
        Me.ContactAdministratorsButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.ContactAdministratorsButton.Image = CType(resources.GetObject("ContactAdministratorsButton.Image"), System.Drawing.Image)
        Me.ContactAdministratorsButton.KeyTip = "N"
        Me.ContactAdministratorsButton.Label = "Contact Administrators"
        Me.ContactAdministratorsButton.Name = "ContactAdministratorsButton"
        Me.ContactAdministratorsButton.ShowImage = True
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
        'PerformanceTrackingToolTab
        '
        Me.PerformanceTrackingToolTab.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office
        Me.PerformanceTrackingToolTab.Groups.Add(Me.OptionsGroup)
        Me.PerformanceTrackingToolTab.Groups.Add(Me.ContactUsGroup)
        Me.PerformanceTrackingToolTab.Groups.Add(Me.VersionID)
        Me.PerformanceTrackingToolTab.KeyTip = "C"
        Me.PerformanceTrackingToolTab.Label = "Performance Tracking Tool"
        Me.PerformanceTrackingToolTab.Name = "PerformanceTrackingToolTab"
        '
        'VersionID
        '
        Me.VersionID.Items.Add(Me.VersionLabel)
        Me.VersionID.Label = "Version"
        Me.VersionID.Name = "VersionID"
        '
        'VersionLabel
        '
        Me.VersionLabel.Label = "Version 7.0"
        Me.VersionLabel.Name = "VersionLabel"
        '
        'SendLocalDataBaseButton
        '
        Me.SendLocalDataBaseButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.SendLocalDataBaseButton.Image = CType(resources.GetObject("SendLocalDataBaseButton.Image"), System.Drawing.Image)
        Me.SendLocalDataBaseButton.KeyTip = "N"
        Me.SendLocalDataBaseButton.Label = "Send Local DataBase"
        Me.SendLocalDataBaseButton.Name = "SendLocalDataBaseButton"
        Me.SendLocalDataBaseButton.ShowImage = True
        '
        'CaseTrackerTool
        '
        Me.Name = "CaseTrackerTool"
        Me.RibbonType = resources.GetString("$this.RibbonType")
        Me.Tabs.Add(Me.PerformanceTrackingToolTab)
        Me.ContactUsGroup.ResumeLayout(False)
        Me.ContactUsGroup.PerformLayout()
        Me.OptionsGroup.ResumeLayout(False)
        Me.OptionsGroup.PerformLayout()
        Me.PerformanceTrackingToolTab.ResumeLayout(False)
        Me.PerformanceTrackingToolTab.PerformLayout()
        Me.VersionID.ResumeLayout(False)
        Me.VersionID.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContactUsGroup As RibbonGroup
    Friend WithEvents ContactAdministratorsButton As RibbonButton
    Friend WithEvents OptionsGroup As RibbonGroup
    Friend WithEvents AddCaseButton As RibbonButton
    Friend WithEvents ModifyCaseButton As RibbonButton
    Friend WithEvents CloseCaseButton As RibbonButton
    Friend WithEvents SearchCaseButton As RibbonButton
    Friend WithEvents PerformanceTrackingToolTab As RibbonTab
    Friend WithEvents VersionID As RibbonGroup
    Friend WithEvents VersionLabel As RibbonLabel
    Friend WithEvents SendLocalDataBaseButton As RibbonButton
End Class

Partial Class ThisRibbonCollection

    <System.Diagnostics.DebuggerNonUserCode()> _
    Friend ReadOnly Property Ribbon1() As CaseTrackerTool
        Get
            Return Me.GetRibbon(Of CaseTrackerTool)()
        End Get
    End Property
End Class
