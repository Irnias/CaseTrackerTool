<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ProgressForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.ProcessLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(12, 51)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(260, 23)
        Me.ProgressBar.TabIndex = 0
        '
        'ProcessLabel
        '
        Me.ProcessLabel.AutoSize = True
        Me.ProcessLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ProcessLabel.ForeColor = System.Drawing.Color.White
        Me.ProcessLabel.Location = New System.Drawing.Point(100, 20)
        Me.ProcessLabel.Name = "ProcessLabel"
        Me.ProcessLabel.Size = New System.Drawing.Size(85, 19)
        Me.ProcessLabel.TabIndex = 29
        Me.ProcessLabel.Text = "Creating File"
        '
        'ProgressForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(284, 106)
        Me.Controls.Add(Me.ProcessLabel)
        Me.Controls.Add(Me.ProgressBar)
        Me.Name = "ProgressForm"
        Me.Text = "Action Progress"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents ProcessLabel As System.Windows.Forms.Label
End Class
