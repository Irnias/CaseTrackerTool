<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CloseCaseForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CloseCaseForm))
        Me.TicketNumberLabel = New System.Windows.Forms.Label()
        Me.ConectionLabel = New System.Windows.Forms.Label()
        Me.ConectionBox = New System.Windows.Forms.ComboBox()
        Me.CloseCaseButton = New System.Windows.Forms.Button()
        Me.CurrentStatusLabel = New System.Windows.Forms.Label()
        Me.TicketNumberBox = New System.Windows.Forms.TextBox()
        Me.CurrentStatusBox = New System.Windows.Forms.TextBox()
        Me.CommentsBox = New System.Windows.Forms.TextBox()
        Me.CommentsLabel = New System.Windows.Forms.Label()
        Me.SearchButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TicketNumberLabel
        '
        resources.ApplyResources(Me.TicketNumberLabel, "TicketNumberLabel")
        Me.TicketNumberLabel.ForeColor = System.Drawing.Color.White
        Me.TicketNumberLabel.Name = "TicketNumberLabel"
        '
        'ConectionLabel
        '
        resources.ApplyResources(Me.ConectionLabel, "ConectionLabel")
        Me.ConectionLabel.ForeColor = System.Drawing.Color.White
        Me.ConectionLabel.Name = "ConectionLabel"
        '
        'ConectionBox
        '
        Me.ConectionBox.AllowDrop = True
        resources.ApplyResources(Me.ConectionBox, "ConectionBox")
        Me.ConectionBox.FormattingEnabled = True
        Me.ConectionBox.Name = "ConectionBox"
        '
        'CloseCaseButton
        '
        resources.ApplyResources(Me.CloseCaseButton, "CloseCaseButton")
        Me.CloseCaseButton.FlatAppearance.BorderSize = 0
        Me.CloseCaseButton.Name = "CloseCaseButton"
        Me.CloseCaseButton.UseVisualStyleBackColor = True
        '
        'CurrentStatusLabel
        '
        resources.ApplyResources(Me.CurrentStatusLabel, "CurrentStatusLabel")
        Me.CurrentStatusLabel.ForeColor = System.Drawing.Color.White
        Me.CurrentStatusLabel.Name = "CurrentStatusLabel"
        '
        'TicketNumberBox
        '
        Me.TicketNumberBox.AllowDrop = True
        resources.ApplyResources(Me.TicketNumberBox, "TicketNumberBox")
        Me.TicketNumberBox.Name = "TicketNumberBox"
        '
        'CurrentStatusBox
        '
        Me.CurrentStatusBox.AllowDrop = True
        resources.ApplyResources(Me.CurrentStatusBox, "CurrentStatusBox")
        Me.CurrentStatusBox.Name = "CurrentStatusBox"
        '
        'CommentsBox
        '
        Me.CommentsBox.AllowDrop = True
        resources.ApplyResources(Me.CommentsBox, "CommentsBox")
        Me.CommentsBox.Name = "CommentsBox"
        '
        'CommentsLabel
        '
        resources.ApplyResources(Me.CommentsLabel, "CommentsLabel")
        Me.CommentsLabel.ForeColor = System.Drawing.Color.White
        Me.CommentsLabel.Name = "CommentsLabel"
        '
        'SearchButton
        '
        resources.ApplyResources(Me.SearchButton, "SearchButton")
        Me.SearchButton.Name = "SearchButton"
        Me.SearchButton.UseVisualStyleBackColor = True
        '
        'CloseCaseForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Controls.Add(Me.SearchButton)
        Me.Controls.Add(Me.CommentsBox)
        Me.Controls.Add(Me.CommentsLabel)
        Me.Controls.Add(Me.CurrentStatusBox)
        Me.Controls.Add(Me.TicketNumberBox)
        Me.Controls.Add(Me.CurrentStatusLabel)
        Me.Controls.Add(Me.CloseCaseButton)
        Me.Controls.Add(Me.TicketNumberLabel)
        Me.Controls.Add(Me.ConectionLabel)
        Me.Controls.Add(Me.ConectionBox)
        Me.Name = "CloseCaseForm"
        Me.ShowIcon = False
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TicketNumberLabel As System.Windows.Forms.Label
    Friend WithEvents ConectionLabel As System.Windows.Forms.Label
    Friend WithEvents ConectionBox As System.Windows.Forms.ComboBox
    Friend WithEvents CloseCaseButton As System.Windows.Forms.Button
    Friend WithEvents CurrentStatusLabel As System.Windows.Forms.Label
    Friend WithEvents TicketNumberBox As System.Windows.Forms.TextBox
    Friend WithEvents CurrentStatusBox As System.Windows.Forms.TextBox
    Friend WithEvents CommentsBox As System.Windows.Forms.TextBox
    Friend WithEvents CommentsLabel As System.Windows.Forms.Label
    Friend WithEvents SearchButton As System.Windows.Forms.Button
End Class
