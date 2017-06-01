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
        Me.TicketNumberLabel = New System.Windows.Forms.Label()
        Me.TicketNumberBox = New System.Windows.Forms.TextBox()
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.SearchButton = New System.Windows.Forms.Button()
        Me.OpenButton = New System.Windows.Forms.Button()
        Me.ConectionBox = New System.Windows.Forms.ComboBox()
        Me.ConectionLabel = New System.Windows.Forms.Label()
        Me.CommentsLabel = New System.Windows.Forms.Label()
        Me.PendingSrcLabel = New System.Windows.Forms.Label()
        Me.RequestorLabel = New System.Windows.Forms.Label()
        Me.OpenedDateLabel = New System.Windows.Forms.Label()
        Me.StatusLabel = New System.Windows.Forms.Label()
        Me.RegionLabel = New System.Windows.Forms.Label()
        Me.CommentsBox = New System.Windows.Forms.TextBox()
        Me.StatusBox = New System.Windows.Forms.TextBox()
        Me.PendingSourceBox = New System.Windows.Forms.TextBox()
        Me.ResponsibleBox = New System.Windows.Forms.TextBox()
        Me.ModifyCaseButton = New System.Windows.Forms.Button()
        Me.RegionBox = New System.Windows.Forms.TextBox()
        Me.RequestorBox = New System.Windows.Forms.TextBox()
        Me.OpenedDateBox = New System.Windows.Forms.TextBox()
        Me.ResponsibleLabel = New System.Windows.Forms.Label()
        Me.ModifyCaseCheckBox = New System.Windows.Forms.CheckBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TicketNumberLabel
        '
        Me.TicketNumberLabel.AutoSize = True
        Me.TicketNumberLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TicketNumberLabel.ForeColor = System.Drawing.Color.White
        Me.TicketNumberLabel.Location = New System.Drawing.Point(12, 41)
        Me.TicketNumberLabel.Name = "TicketNumberLabel"
        Me.TicketNumberLabel.Size = New System.Drawing.Size(96, 19)
        Me.TicketNumberLabel.TabIndex = 13
        Me.TicketNumberLabel.Text = "Ticket number"
        '
        'TicketNumberBox
        '
        Me.TicketNumberBox.Enabled = False
        Me.TicketNumberBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.TicketNumberBox.Location = New System.Drawing.Point(117, 41)
        Me.TicketNumberBox.Name = "TicketNumberBox"
        Me.TicketNumberBox.Size = New System.Drawing.Size(126, 25)
        Me.TicketNumberBox.TabIndex = 2
        '
        'CloseButton
        '
        Me.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CloseButton.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.CloseButton.Location = New System.Drawing.Point(130, 72)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(55, 32)
        Me.CloseButton.TabIndex = 0
        Me.CloseButton.Text = "Close"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(8, 444)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(10, 10)
        Me.DataGridView1.TabIndex = 17
        '
        'SearchButton
        '
        Me.SearchButton.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.SearchButton.Location = New System.Drawing.Point(71, 72)
        Me.SearchButton.Name = "SearchButton"
        Me.SearchButton.Size = New System.Drawing.Size(55, 32)
        Me.SearchButton.TabIndex = 0
        Me.SearchButton.Text = "Search"
        Me.SearchButton.UseVisualStyleBackColor = True
        '
        'OpenButton
        '
        Me.OpenButton.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.OpenButton.Location = New System.Drawing.Point(188, 72)
        Me.OpenButton.Name = "OpenButton"
        Me.OpenButton.Size = New System.Drawing.Size(55, 32)
        Me.OpenButton.TabIndex = 0
        Me.OpenButton.Text = "Open"
        Me.OpenButton.UseVisualStyleBackColor = True
        '
        'ConectionBox
        '
        Me.ConectionBox.AllowDrop = True
        Me.ConectionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ConectionBox.Enabled = False
        Me.ConectionBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ConectionBox.FormattingEnabled = True
        Me.ConectionBox.Location = New System.Drawing.Point(117, 13)
        Me.ConectionBox.Name = "ConectionBox"
        Me.ConectionBox.Size = New System.Drawing.Size(126, 25)
        Me.ConectionBox.TabIndex = 1
        '
        'ConectionLabel
        '
        Me.ConectionLabel.AutoSize = True
        Me.ConectionLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConectionLabel.ForeColor = System.Drawing.Color.White
        Me.ConectionLabel.Location = New System.Drawing.Point(12, 14)
        Me.ConectionLabel.Name = "ConectionLabel"
        Me.ConectionLabel.Size = New System.Drawing.Size(71, 19)
        Me.ConectionLabel.TabIndex = 35
        Me.ConectionLabel.Text = "Conection"
        '
        'CommentsLabel
        '
        Me.CommentsLabel.AllowDrop = True
        Me.CommentsLabel.AutoSize = True
        Me.CommentsLabel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CommentsLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.CommentsLabel.ForeColor = System.Drawing.Color.White
        Me.CommentsLabel.Location = New System.Drawing.Point(9, 311)
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
        Me.PendingSrcLabel.Location = New System.Drawing.Point(9, 283)
        Me.PendingSrcLabel.Name = "PendingSrcLabel"
        Me.PendingSrcLabel.Size = New System.Drawing.Size(80, 19)
        Me.PendingSrcLabel.TabIndex = 60
        Me.PendingSrcLabel.Text = "Pending Src"
        '
        'RequestorLabel
        '
        Me.RequestorLabel.AutoSize = True
        Me.RequestorLabel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.RequestorLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.RequestorLabel.ForeColor = System.Drawing.Color.White
        Me.RequestorLabel.Location = New System.Drawing.Point(9, 255)
        Me.RequestorLabel.Name = "RequestorLabel"
        Me.RequestorLabel.Size = New System.Drawing.Size(71, 19)
        Me.RequestorLabel.TabIndex = 59
        Me.RequestorLabel.Text = "Requestor"
        '
        'OpenedDateLabel
        '
        Me.OpenedDateLabel.AutoSize = True
        Me.OpenedDateLabel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.OpenedDateLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.OpenedDateLabel.ForeColor = System.Drawing.Color.White
        Me.OpenedDateLabel.Location = New System.Drawing.Point(9, 227)
        Me.OpenedDateLabel.Name = "OpenedDateLabel"
        Me.OpenedDateLabel.Size = New System.Drawing.Size(91, 19)
        Me.OpenedDateLabel.TabIndex = 58
        Me.OpenedDateLabel.Text = "Opened Date"
        '
        'StatusLabel
        '
        Me.StatusLabel.AutoSize = True
        Me.StatusLabel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.StatusLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.StatusLabel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.StatusLabel.Location = New System.Drawing.Point(9, 143)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(47, 19)
        Me.StatusLabel.TabIndex = 57
        Me.StatusLabel.Text = "Status"
        '
        'RegionLabel
        '
        Me.RegionLabel.AutoSize = True
        Me.RegionLabel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.RegionLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.RegionLabel.ForeColor = System.Drawing.Color.White
        Me.RegionLabel.Location = New System.Drawing.Point(9, 199)
        Me.RegionLabel.Name = "RegionLabel"
        Me.RegionLabel.Size = New System.Drawing.Size(51, 19)
        Me.RegionLabel.TabIndex = 56
        Me.RegionLabel.Text = "Region"
        '
        'CommentsBox
        '
        Me.CommentsBox.Enabled = False
        Me.CommentsBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.CommentsBox.Location = New System.Drawing.Point(114, 311)
        Me.CommentsBox.Multiline = True
        Me.CommentsBox.Name = "CommentsBox"
        Me.CommentsBox.Size = New System.Drawing.Size(126, 25)
        Me.CommentsBox.TabIndex = 9
        '
        'StatusBox
        '
        Me.StatusBox.BackColor = System.Drawing.Color.LightGray
        Me.StatusBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.StatusBox.Enabled = False
        Me.StatusBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.StatusBox.ForeColor = System.Drawing.Color.DodgerBlue
        Me.StatusBox.Location = New System.Drawing.Point(114, 143)
        Me.StatusBox.Name = "StatusBox"
        Me.StatusBox.Size = New System.Drawing.Size(126, 25)
        Me.StatusBox.TabIndex = 0
        '
        'PendingSourceBox
        '
        Me.PendingSourceBox.Enabled = False
        Me.PendingSourceBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.PendingSourceBox.Location = New System.Drawing.Point(114, 283)
        Me.PendingSourceBox.Name = "PendingSourceBox"
        Me.PendingSourceBox.Size = New System.Drawing.Size(126, 25)
        Me.PendingSourceBox.TabIndex = 8
        '
        'ResponsibleBox
        '
        Me.ResponsibleBox.Enabled = False
        Me.ResponsibleBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ResponsibleBox.Location = New System.Drawing.Point(114, 171)
        Me.ResponsibleBox.Name = "ResponsibleBox"
        Me.ResponsibleBox.Size = New System.Drawing.Size(126, 25)
        Me.ResponsibleBox.TabIndex = 4
        '
        'ModifyCaseButton
        '
        Me.ModifyCaseButton.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ModifyCaseButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ModifyCaseButton.Location = New System.Drawing.Point(185, 339)
        Me.ModifyCaseButton.Name = "ModifyCaseButton"
        Me.ModifyCaseButton.Size = New System.Drawing.Size(55, 32)
        Me.ModifyCaseButton.TabIndex = 0
        Me.ModifyCaseButton.Text = "Modify"
        Me.ModifyCaseButton.UseVisualStyleBackColor = True
        '
        'RegionBox
        '
        Me.RegionBox.Enabled = False
        Me.RegionBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.RegionBox.Location = New System.Drawing.Point(114, 199)
        Me.RegionBox.Name = "RegionBox"
        Me.RegionBox.Size = New System.Drawing.Size(126, 25)
        Me.RegionBox.TabIndex = 5
        '
        'RequestorBox
        '
        Me.RequestorBox.Enabled = False
        Me.RequestorBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.RequestorBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.RequestorBox.Location = New System.Drawing.Point(114, 255)
        Me.RequestorBox.Name = "RequestorBox"
        Me.RequestorBox.Size = New System.Drawing.Size(126, 25)
        Me.RequestorBox.TabIndex = 7
        '
        'OpenedDateBox
        '
        Me.OpenedDateBox.Enabled = False
        Me.OpenedDateBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.OpenedDateBox.Location = New System.Drawing.Point(114, 227)
        Me.OpenedDateBox.Name = "OpenedDateBox"
        Me.OpenedDateBox.Size = New System.Drawing.Size(126, 25)
        Me.OpenedDateBox.TabIndex = 6
        '
        'ResponsibleLabel
        '
        Me.ResponsibleLabel.AutoSize = True
        Me.ResponsibleLabel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ResponsibleLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ResponsibleLabel.ForeColor = System.Drawing.Color.White
        Me.ResponsibleLabel.Location = New System.Drawing.Point(9, 171)
        Me.ResponsibleLabel.Name = "ResponsibleLabel"
        Me.ResponsibleLabel.Size = New System.Drawing.Size(81, 19)
        Me.ResponsibleLabel.TabIndex = 49
        Me.ResponsibleLabel.Text = "Responsible"
        '
        'ModifyCaseCheckBox
        '
        Me.ModifyCaseCheckBox.AutoSize = True
        Me.ModifyCaseCheckBox.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ModifyCaseCheckBox.ForeColor = System.Drawing.Color.White
        Me.ModifyCaseCheckBox.Location = New System.Drawing.Point(9, 110)
        Me.ModifyCaseCheckBox.Name = "ModifyCaseCheckBox"
        Me.ModifyCaseCheckBox.Size = New System.Drawing.Size(89, 17)
        Me.ModifyCaseCheckBox.TabIndex = 3
        Me.ModifyCaseCheckBox.Text = "Modify Case"
        Me.ModifyCaseCheckBox.UseVisualStyleBackColor = True
        '
        'ModifyCaseForm
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(248, 408)
        Me.Controls.Add(Me.CommentsLabel)
        Me.Controls.Add(Me.PendingSrcLabel)
        Me.Controls.Add(Me.RequestorLabel)
        Me.Controls.Add(Me.OpenedDateLabel)
        Me.Controls.Add(Me.StatusLabel)
        Me.Controls.Add(Me.RegionLabel)
        Me.Controls.Add(Me.CommentsBox)
        Me.Controls.Add(Me.StatusBox)
        Me.Controls.Add(Me.PendingSourceBox)
        Me.Controls.Add(Me.ResponsibleBox)
        Me.Controls.Add(Me.ModifyCaseButton)
        Me.Controls.Add(Me.RegionBox)
        Me.Controls.Add(Me.RequestorBox)
        Me.Controls.Add(Me.OpenedDateBox)
        Me.Controls.Add(Me.ResponsibleLabel)
        Me.Controls.Add(Me.ModifyCaseCheckBox)
        Me.Controls.Add(Me.ConectionLabel)
        Me.Controls.Add(Me.ConectionBox)
        Me.Controls.Add(Me.OpenButton)
        Me.Controls.Add(Me.SearchButton)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.TicketNumberBox)
        Me.Controls.Add(Me.TicketNumberLabel)
        Me.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.KeyPreview = True
        Me.MaximumSize = New System.Drawing.Size(264, 447)
        Me.Name = "ModifyCaseForm"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds
        Me.Text = "Modify Case"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TicketNumberLabel As System.Windows.Forms.Label
    Friend WithEvents TicketNumberBox As System.Windows.Forms.TextBox
    Friend WithEvents CloseButton As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents SearchButton As System.Windows.Forms.Button
    Friend WithEvents OpenButton As System.Windows.Forms.Button
    Friend WithEvents ConectionBox As System.Windows.Forms.ComboBox
    Friend WithEvents ConectionLabel As System.Windows.Forms.Label
    Friend WithEvents CommentsLabel As System.Windows.Forms.Label
    Friend WithEvents PendingSrcLabel As System.Windows.Forms.Label
    Friend WithEvents RequestorLabel As System.Windows.Forms.Label
    Friend WithEvents OpenedDateLabel As System.Windows.Forms.Label
    Friend WithEvents StatusLabel As System.Windows.Forms.Label
    Friend WithEvents RegionLabel As System.Windows.Forms.Label
    Friend WithEvents CommentsBox As System.Windows.Forms.TextBox
    Friend WithEvents StatusBox As System.Windows.Forms.TextBox
    Friend WithEvents PendingSourceBox As System.Windows.Forms.TextBox
    Friend WithEvents ResponsibleBox As System.Windows.Forms.TextBox
    Friend WithEvents ModifyCaseButton As System.Windows.Forms.Button
    Friend WithEvents RegionBox As System.Windows.Forms.TextBox
    Friend WithEvents RequestorBox As System.Windows.Forms.TextBox
    Friend WithEvents OpenedDateBox As System.Windows.Forms.TextBox
    Friend WithEvents ResponsibleLabel As System.Windows.Forms.Label
    Friend WithEvents ModifyCaseCheckBox As System.Windows.Forms.CheckBox
End Class
