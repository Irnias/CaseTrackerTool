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
        Me.TicketNumberLabel = New System.Windows.Forms.Label()
        Me.ConectionLabel = New System.Windows.Forms.Label()
        Me.ConectionBox = New System.Windows.Forms.ComboBox()
        Me.CloseCaseButton = New System.Windows.Forms.Button()
        Me.CurrentStatusLabel = New System.Windows.Forms.Label()
        Me.TicketNumberBox = New System.Windows.Forms.TextBox()
        Me.CurrentStatusBox = New System.Windows.Forms.TextBox()
        Me.CommentsBox = New System.Windows.Forms.TextBox()
        Me.CommentsLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TicketNumberLabel
        '
        Me.TicketNumberLabel.AutoSize = True
        Me.TicketNumberLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.TicketNumberLabel.ForeColor = System.Drawing.Color.White
        Me.TicketNumberLabel.Location = New System.Drawing.Point(12, 43)
        Me.TicketNumberLabel.Name = "TicketNumberLabel"
        Me.TicketNumberLabel.Size = New System.Drawing.Size(98, 19)
        Me.TicketNumberLabel.TabIndex = 39
        Me.TicketNumberLabel.Text = "Ticket Number"
        '
        'ConectionLabel
        '
        Me.ConectionLabel.AutoSize = True
        Me.ConectionLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ConectionLabel.ForeColor = System.Drawing.Color.White
        Me.ConectionLabel.Location = New System.Drawing.Point(14, 12)
        Me.ConectionLabel.Name = "ConectionLabel"
        Me.ConectionLabel.Size = New System.Drawing.Size(71, 19)
        Me.ConectionLabel.TabIndex = 38
        Me.ConectionLabel.Text = "Conection"
        '
        'ConectionBox
        '
        Me.ConectionBox.AllowDrop = True
        Me.ConectionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ConectionBox.Enabled = False
        Me.ConectionBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ConectionBox.FormattingEnabled = True
        Me.ConectionBox.Location = New System.Drawing.Point(114, 12)
        Me.ConectionBox.Name = "ConectionBox"
        Me.ConectionBox.Size = New System.Drawing.Size(126, 25)
        Me.ConectionBox.TabIndex = 36
        '
        'CloseCaseButton
        '
        Me.CloseCaseButton.Enabled = False
        Me.CloseCaseButton.FlatAppearance.BorderSize = 0
        Me.CloseCaseButton.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.CloseCaseButton.Location = New System.Drawing.Point(92, 166)
        Me.CloseCaseButton.Name = "CloseCaseButton"
        Me.CloseCaseButton.Size = New System.Drawing.Size(55, 32)
        Me.CloseCaseButton.TabIndex = 41
        Me.CloseCaseButton.Text = "Close"
        Me.CloseCaseButton.UseVisualStyleBackColor = True
        '
        'CurrentStatusLabel
        '
        Me.CurrentStatusLabel.AutoSize = True
        Me.CurrentStatusLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.CurrentStatusLabel.ForeColor = System.Drawing.Color.White
        Me.CurrentStatusLabel.Location = New System.Drawing.Point(12, 74)
        Me.CurrentStatusLabel.Name = "CurrentStatusLabel"
        Me.CurrentStatusLabel.Size = New System.Drawing.Size(98, 19)
        Me.CurrentStatusLabel.TabIndex = 42
        Me.CurrentStatusLabel.Text = "Current Status"
        '
        'TicketNumberBox
        '
        Me.TicketNumberBox.AllowDrop = True
        Me.TicketNumberBox.Enabled = False
        Me.TicketNumberBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.TicketNumberBox.Location = New System.Drawing.Point(114, 43)
        Me.TicketNumberBox.Name = "TicketNumberBox"
        Me.TicketNumberBox.Size = New System.Drawing.Size(126, 25)
        Me.TicketNumberBox.TabIndex = 43
        '
        'CurrentStatusBox
        '
        Me.CurrentStatusBox.AllowDrop = True
        Me.CurrentStatusBox.Enabled = False
        Me.CurrentStatusBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.CurrentStatusBox.Location = New System.Drawing.Point(114, 74)
        Me.CurrentStatusBox.Name = "CurrentStatusBox"
        Me.CurrentStatusBox.Size = New System.Drawing.Size(126, 25)
        Me.CurrentStatusBox.TabIndex = 44
        '
        'CommentsBox
        '
        Me.CommentsBox.AllowDrop = True
        Me.CommentsBox.Enabled = False
        Me.CommentsBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.CommentsBox.Location = New System.Drawing.Point(114, 105)
        Me.CommentsBox.Multiline = True
        Me.CommentsBox.Name = "CommentsBox"
        Me.CommentsBox.Size = New System.Drawing.Size(126, 55)
        Me.CommentsBox.TabIndex = 45
        '
        'CommentsLabel
        '
        Me.CommentsLabel.AutoSize = True
        Me.CommentsLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.CommentsLabel.ForeColor = System.Drawing.Color.White
        Me.CommentsLabel.Location = New System.Drawing.Point(12, 105)
        Me.CommentsLabel.Name = "CommentsLabel"
        Me.CommentsLabel.Size = New System.Drawing.Size(76, 19)
        Me.CommentsLabel.TabIndex = 46
        Me.CommentsLabel.Text = "Comments"
        '
        'CloseCaseForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(248, 211)
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
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Close Case"
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
End Class
