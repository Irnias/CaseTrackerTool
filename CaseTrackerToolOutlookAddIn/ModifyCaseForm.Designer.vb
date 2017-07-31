<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ModifyCaseForm
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TicketNumberBox = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ReopenButton = New System.Windows.Forms.Button()
        Me.ConectionBox = New System.Windows.Forms.ComboBox()
        Me.CommentsLabel = New System.Windows.Forms.Label()
        Me.PendingSrcLabel = New System.Windows.Forms.Label()
        Me.DateLabel = New System.Windows.Forms.Label()
        Me.RegionLabel = New System.Windows.Forms.Label()
        Me.StatusLabel = New System.Windows.Forms.Label()
        Me.RequestorLabel = New System.Windows.Forms.Label()
        Me.PendingSourceBox = New System.Windows.Forms.TextBox()
        Me.ResponsibleBox = New System.Windows.Forms.TextBox()
        Me.ModifyCaseButton = New System.Windows.Forms.Button()
        Me.RequestorBox = New System.Windows.Forms.TextBox()
        Me.RegionBox = New System.Windows.Forms.TextBox()
        Me.ResponsibleLabel = New System.Windows.Forms.Label()
        Me.TicketNumberLabel = New System.Windows.Forms.Label()
        Me.ConectionLabel = New System.Windows.Forms.Label()
        Me.CommentsBox = New System.Windows.Forms.TextBox()
        Me.StatusBox = New System.Windows.Forms.TextBox()
        Me.DateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.SearchButton = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TicketNumberBox
        '
        Me.TicketNumberBox.Enabled = False
        Me.TicketNumberBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.TicketNumberBox.Location = New System.Drawing.Point(114, 39)
        Me.TicketNumberBox.Name = "TicketNumberBox"
        Me.TicketNumberBox.Size = New System.Drawing.Size(126, 25)
        Me.TicketNumberBox.TabIndex = 2
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(8, 444)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(10, 10)
        Me.DataGridView1.TabIndex = 17
        '
        'ReopenButton
        '
        Me.ReopenButton.Enabled = False
        Me.ReopenButton.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ReopenButton.Location = New System.Drawing.Point(123, 289)
        Me.ReopenButton.Name = "ReopenButton"
        Me.ReopenButton.Size = New System.Drawing.Size(55, 32)
        Me.ReopenButton.TabIndex = 0
        Me.ReopenButton.Text = "Reopen"
        Me.ReopenButton.UseVisualStyleBackColor = True
        '
        'ConectionBox
        '
        Me.ConectionBox.AllowDrop = True
        Me.ConectionBox.Enabled = False
        Me.ConectionBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ConectionBox.FormattingEnabled = True
        Me.ConectionBox.Location = New System.Drawing.Point(114, 12)
        Me.ConectionBox.Name = "ConectionBox"
        Me.ConectionBox.Size = New System.Drawing.Size(126, 25)
        Me.ConectionBox.TabIndex = 1
        '
        'CommentsLabel
        '
        Me.CommentsLabel.AllowDrop = True
        Me.CommentsLabel.AutoSize = True
        Me.CommentsLabel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CommentsLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.CommentsLabel.ForeColor = System.Drawing.Color.White
        Me.CommentsLabel.Location = New System.Drawing.Point(12, 231)
        Me.CommentsLabel.Name = "CommentsLabel"
        Me.CommentsLabel.Size = New System.Drawing.Size(76, 19)
        Me.CommentsLabel.TabIndex = 61
        Me.CommentsLabel.Text = "Comments"
        '
        'PendingSrcLabel
        '
        Me.PendingSrcLabel.AutoSize = True
        Me.PendingSrcLabel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.PendingSrcLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.PendingSrcLabel.ForeColor = System.Drawing.Color.White
        Me.PendingSrcLabel.Location = New System.Drawing.Point(12, 204)
        Me.PendingSrcLabel.Name = "PendingSrcLabel"
        Me.PendingSrcLabel.Size = New System.Drawing.Size(80, 19)
        Me.PendingSrcLabel.TabIndex = 60
        Me.PendingSrcLabel.Text = "Pending Src"
        '
        'DateLabel
        '
        Me.DateLabel.AutoSize = True
        Me.DateLabel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.DateLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.DateLabel.ForeColor = System.Drawing.Color.White
        Me.DateLabel.Location = New System.Drawing.Point(12, 177)
        Me.DateLabel.Name = "DateLabel"
        Me.DateLabel.Size = New System.Drawing.Size(38, 19)
        Me.DateLabel.TabIndex = 59
        Me.DateLabel.Text = "Date"
        '
        'RegionLabel
        '
        Me.RegionLabel.AutoSize = True
        Me.RegionLabel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.RegionLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.RegionLabel.ForeColor = System.Drawing.Color.White
        Me.RegionLabel.Location = New System.Drawing.Point(12, 150)
        Me.RegionLabel.Name = "RegionLabel"
        Me.RegionLabel.Size = New System.Drawing.Size(51, 19)
        Me.RegionLabel.TabIndex = 58
        Me.RegionLabel.Text = "Region"
        '
        'StatusLabel
        '
        Me.StatusLabel.AutoSize = True
        Me.StatusLabel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.StatusLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.StatusLabel.ForeColor = System.Drawing.Color.White
        Me.StatusLabel.Location = New System.Drawing.Point(12, 69)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(47, 19)
        Me.StatusLabel.TabIndex = 57
        Me.StatusLabel.Text = "Status"
        '
        'RequestorLabel
        '
        Me.RequestorLabel.AutoSize = True
        Me.RequestorLabel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.RequestorLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.RequestorLabel.ForeColor = System.Drawing.Color.White
        Me.RequestorLabel.Location = New System.Drawing.Point(12, 123)
        Me.RequestorLabel.Name = "RequestorLabel"
        Me.RequestorLabel.Size = New System.Drawing.Size(71, 19)
        Me.RequestorLabel.TabIndex = 56
        Me.RequestorLabel.Text = "Requestor"
        '
        'PendingSourceBox
        '
        Me.PendingSourceBox.Enabled = False
        Me.PendingSourceBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.PendingSourceBox.Location = New System.Drawing.Point(114, 201)
        Me.PendingSourceBox.Name = "PendingSourceBox"
        Me.PendingSourceBox.Size = New System.Drawing.Size(126, 25)
        Me.PendingSourceBox.TabIndex = 8
        '
        'ResponsibleBox
        '
        Me.ResponsibleBox.Enabled = False
        Me.ResponsibleBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ResponsibleBox.Location = New System.Drawing.Point(114, 93)
        Me.ResponsibleBox.Name = "ResponsibleBox"
        Me.ResponsibleBox.Size = New System.Drawing.Size(126, 25)
        Me.ResponsibleBox.TabIndex = 4
        '
        'ModifyCaseButton
        '
        Me.ModifyCaseButton.Enabled = False
        Me.ModifyCaseButton.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ModifyCaseButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ModifyCaseButton.Location = New System.Drawing.Point(184, 289)
        Me.ModifyCaseButton.Name = "ModifyCaseButton"
        Me.ModifyCaseButton.Size = New System.Drawing.Size(55, 32)
        Me.ModifyCaseButton.TabIndex = 0
        Me.ModifyCaseButton.Text = "Modify"
        Me.ModifyCaseButton.UseVisualStyleBackColor = True
        '
        'RequestorBox
        '
        Me.RequestorBox.Enabled = False
        Me.RequestorBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.RequestorBox.Location = New System.Drawing.Point(114, 120)
        Me.RequestorBox.Name = "RequestorBox"
        Me.RequestorBox.Size = New System.Drawing.Size(126, 25)
        Me.RequestorBox.TabIndex = 5
        '
        'RegionBox
        '
        Me.RegionBox.Enabled = False
        Me.RegionBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.RegionBox.Location = New System.Drawing.Point(114, 147)
        Me.RegionBox.Name = "RegionBox"
        Me.RegionBox.Size = New System.Drawing.Size(126, 25)
        Me.RegionBox.TabIndex = 6
        '
        'ResponsibleLabel
        '
        Me.ResponsibleLabel.AutoSize = True
        Me.ResponsibleLabel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ResponsibleLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ResponsibleLabel.ForeColor = System.Drawing.Color.White
        Me.ResponsibleLabel.Location = New System.Drawing.Point(12, 96)
        Me.ResponsibleLabel.Name = "ResponsibleLabel"
        Me.ResponsibleLabel.Size = New System.Drawing.Size(81, 19)
        Me.ResponsibleLabel.TabIndex = 49
        Me.ResponsibleLabel.Text = "Responsible"
        '
        'TicketNumberLabel
        '
        Me.TicketNumberLabel.AutoSize = True
        Me.TicketNumberLabel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.TicketNumberLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.TicketNumberLabel.ForeColor = System.Drawing.Color.White
        Me.TicketNumberLabel.Location = New System.Drawing.Point(12, 42)
        Me.TicketNumberLabel.Name = "TicketNumberLabel"
        Me.TicketNumberLabel.Size = New System.Drawing.Size(96, 19)
        Me.TicketNumberLabel.TabIndex = 62
        Me.TicketNumberLabel.Text = "Ticket number"
        '
        'ConectionLabel
        '
        Me.ConectionLabel.AutoSize = True
        Me.ConectionLabel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ConectionLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ConectionLabel.ForeColor = System.Drawing.Color.White
        Me.ConectionLabel.Location = New System.Drawing.Point(12, 15)
        Me.ConectionLabel.Name = "ConectionLabel"
        Me.ConectionLabel.Size = New System.Drawing.Size(71, 19)
        Me.ConectionLabel.TabIndex = 63
        Me.ConectionLabel.Text = "Conection"
        '
        'CommentsBox
        '
        Me.CommentsBox.AllowDrop = True
        Me.CommentsBox.Enabled = False
        Me.CommentsBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.CommentsBox.Location = New System.Drawing.Point(114, 228)
        Me.CommentsBox.Multiline = True
        Me.CommentsBox.Name = "CommentsBox"
        Me.CommentsBox.Size = New System.Drawing.Size(126, 55)
        Me.CommentsBox.TabIndex = 64
        '
        'StatusBox
        '
        Me.StatusBox.BackColor = System.Drawing.Color.White
        Me.StatusBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.StatusBox.Enabled = False
        Me.StatusBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.StatusBox.ForeColor = System.Drawing.Color.Black
        Me.StatusBox.Location = New System.Drawing.Point(114, 66)
        Me.StatusBox.Name = "StatusBox"
        Me.StatusBox.ReadOnly = True
        Me.StatusBox.Size = New System.Drawing.Size(126, 25)
        Me.StatusBox.TabIndex = 0
        '
        'DateTimePicker
        '
        Me.DateTimePicker.Enabled = False
        Me.DateTimePicker.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker.Location = New System.Drawing.Point(114, 174)
        Me.DateTimePicker.Name = "DateTimePicker"
        Me.DateTimePicker.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DateTimePicker.Size = New System.Drawing.Size(126, 25)
        Me.DateTimePicker.TabIndex = 66
        '
        'SearchButton
        '
        Me.SearchButton.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.SearchButton.Location = New System.Drawing.Point(62, 289)
        Me.SearchButton.Name = "SearchButton"
        Me.SearchButton.Size = New System.Drawing.Size(55, 32)
        Me.SearchButton.TabIndex = 67
        Me.SearchButton.Text = "Search"
        Me.SearchButton.UseVisualStyleBackColor = True
        '
        'ModifyCaseForm
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(248, 431)
        Me.Controls.Add(Me.SearchButton)
        Me.Controls.Add(Me.DateTimePicker)
        Me.Controls.Add(Me.CommentsBox)
        Me.Controls.Add(Me.ConectionLabel)
        Me.Controls.Add(Me.TicketNumberLabel)
        Me.Controls.Add(Me.CommentsLabel)
        Me.Controls.Add(Me.PendingSrcLabel)
        Me.Controls.Add(Me.DateLabel)
        Me.Controls.Add(Me.RegionLabel)
        Me.Controls.Add(Me.StatusLabel)
        Me.Controls.Add(Me.RequestorLabel)
        Me.Controls.Add(Me.StatusBox)
        Me.Controls.Add(Me.PendingSourceBox)
        Me.Controls.Add(Me.ResponsibleBox)
        Me.Controls.Add(Me.ModifyCaseButton)
        Me.Controls.Add(Me.RequestorBox)
        Me.Controls.Add(Me.RegionBox)
        Me.Controls.Add(Me.ResponsibleLabel)
        Me.Controls.Add(Me.ConectionBox)
        Me.Controls.Add(Me.ReopenButton)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.TicketNumberBox)
        Me.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.KeyPreview = True
        Me.Name = "ModifyCaseForm"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Modify Case"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TicketNumberBox As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ReopenButton As System.Windows.Forms.Button
    Friend WithEvents ConectionBox As System.Windows.Forms.ComboBox
    Friend WithEvents CommentsLabel As System.Windows.Forms.Label
    Friend WithEvents PendingSrcLabel As System.Windows.Forms.Label
    Friend WithEvents DateLabel As System.Windows.Forms.Label
    Friend WithEvents RegionLabel As System.Windows.Forms.Label
    Friend WithEvents StatusLabel As System.Windows.Forms.Label
    Friend WithEvents RequestorLabel As System.Windows.Forms.Label
    Friend WithEvents PendingSourceBox As System.Windows.Forms.TextBox
    Friend WithEvents ResponsibleBox As System.Windows.Forms.TextBox
    Friend WithEvents ModifyCaseButton As System.Windows.Forms.Button
    Friend WithEvents RequestorBox As System.Windows.Forms.TextBox
    Friend WithEvents RegionBox As System.Windows.Forms.TextBox
    Friend WithEvents ResponsibleLabel As System.Windows.Forms.Label
    Friend WithEvents TicketNumberLabel As System.Windows.Forms.Label
    Friend WithEvents ConectionLabel As System.Windows.Forms.Label
    Friend WithEvents CommentsBox As System.Windows.Forms.TextBox
    Friend WithEvents StatusBox As System.Windows.Forms.TextBox
    Friend WithEvents DateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents SearchButton As System.Windows.Forms.Button
End Class
