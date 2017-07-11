<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ActivitiesVisualAssistForm
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ActivitiesVisualAssistGrid = New System.Windows.Forms.DataGridView()
        CType(Me.ActivitiesVisualAssistGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ActivitiesVisualAssistGrid
        '
        Me.ActivitiesVisualAssistGrid.AllowUserToAddRows = False
        Me.ActivitiesVisualAssistGrid.AllowUserToDeleteRows = False
        Me.ActivitiesVisualAssistGrid.AllowUserToOrderColumns = True
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ActivitiesVisualAssistGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.ActivitiesVisualAssistGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.ActivitiesVisualAssistGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ActivitiesVisualAssistGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.ActivitiesVisualAssistGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ActivitiesVisualAssistGrid.DefaultCellStyle = DataGridViewCellStyle7
        Me.ActivitiesVisualAssistGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ActivitiesVisualAssistGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.ActivitiesVisualAssistGrid.Location = New System.Drawing.Point(0, 0)
        Me.ActivitiesVisualAssistGrid.MultiSelect = False
        Me.ActivitiesVisualAssistGrid.Name = "ActivitiesVisualAssistGrid"
        Me.ActivitiesVisualAssistGrid.ReadOnly = True
        Me.ActivitiesVisualAssistGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ActivitiesVisualAssistGrid.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.ActivitiesVisualAssistGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ActivitiesVisualAssistGrid.ShowCellErrors = False
        Me.ActivitiesVisualAssistGrid.ShowCellToolTips = False
        Me.ActivitiesVisualAssistGrid.ShowEditingIcon = False
        Me.ActivitiesVisualAssistGrid.ShowRowErrors = False
        Me.ActivitiesVisualAssistGrid.Size = New System.Drawing.Size(584, 229)
        Me.ActivitiesVisualAssistGrid.TabIndex = 0
        '
        'ActivitiesVisualAssistForm
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(584, 229)
        Me.Controls.Add(Me.ActivitiesVisualAssistGrid)
        Me.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.KeyPreview = True
        Me.Name = "ActivitiesVisualAssistForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Activities Visual Assist"
        CType(Me.ActivitiesVisualAssistGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ActivitiesVisualAssistGrid As System.Windows.Forms.DataGridView
End Class
