<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NewCaseForm
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
        Me.CreateCaseButton = New System.Windows.Forms.Button()
        Me.TrakingID = New System.Windows.Forms.Label()
        Me.RequestorBox = New System.Windows.Forms.TextBox()
        Me.RequestorLabel = New System.Windows.Forms.Label()
        Me.ResponsibleLabel = New System.Windows.Forms.Label()
        Me.TicketNumberBox = New System.Windows.Forms.TextBox()
        Me.TicketNumberLabel = New System.Windows.Forms.Label()
        Me.ResponsibleBox = New System.Windows.Forms.ComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DateBox = New System.Windows.Forms.TextBox()
        Me.StatusLabel = New System.Windows.Forms.Label()
        Me.RegionBox = New System.Windows.Forms.TextBox()
        Me.RegionLabel = New System.Windows.Forms.Label()
        Me.PendingSrcBox = New System.Windows.Forms.TextBox()
        Me.PendingSrcLabel = New System.Windows.Forms.Label()
        Me.DateLabel = New System.Windows.Forms.Label()
        Me.ConectionBox = New System.Windows.Forms.ComboBox()
        Me.ConectionLabel = New System.Windows.Forms.Label()
        Me.StatusBox = New System.Windows.Forms.ComboBox()
        Me.ActCategoryBox = New System.Windows.Forms.ComboBox()
        Me.ActCategoryLabel = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.TeamBox = New System.Windows.Forms.ComboBox()
        Me.TeamLabel = New System.Windows.Forms.Label()
        Me.CommentsLabel = New System.Windows.Forms.Label()
        Me.CommentsBox = New System.Windows.Forms.TextBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CreateCaseButton
        '
        Me.CreateCaseButton.FlatAppearance.BorderSize = 0
        Me.CreateCaseButton.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.CreateCaseButton.Location = New System.Drawing.Point(188, 321)
        Me.CreateCaseButton.Name = "CreateCaseButton"
        Me.CreateCaseButton.Size = New System.Drawing.Size(55, 32)
        Me.CreateCaseButton.TabIndex = 12
        Me.CreateCaseButton.Text = "Create"
        Me.CreateCaseButton.UseVisualStyleBackColor = True
        '
        'TrakingID
        '
        Me.TrakingID.AutoSize = True
        Me.TrakingID.BackColor = System.Drawing.Color.Black
        Me.TrakingID.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.TrakingID.ForeColor = System.Drawing.Color.White
        Me.TrakingID.Location = New System.Drawing.Point(119, 14)
        Me.TrakingID.Margin = New System.Windows.Forms.Padding(3)
        Me.TrakingID.Name = "TrakingID"
        Me.TrakingID.Size = New System.Drawing.Size(13, 19)
        Me.TrakingID.TabIndex = 2
        Me.TrakingID.Text = " "
        Me.TrakingID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RequestorBox
        '
        Me.RequestorBox.AllowDrop = True
        Me.RequestorBox.Enabled = False
        Me.RequestorBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.RequestorBox.Location = New System.Drawing.Point(117, 181)
        Me.RequestorBox.Name = "RequestorBox"
        Me.RequestorBox.Size = New System.Drawing.Size(126, 25)
        Me.RequestorBox.TabIndex = 7
        '
        'RequestorLabel
        '
        Me.RequestorLabel.AutoSize = True
        Me.RequestorLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.RequestorLabel.ForeColor = System.Drawing.Color.White
        Me.RequestorLabel.Location = New System.Drawing.Point(11, 181)
        Me.RequestorLabel.Name = "RequestorLabel"
        Me.RequestorLabel.Size = New System.Drawing.Size(71, 19)
        Me.RequestorLabel.TabIndex = 5
        Me.RequestorLabel.Text = "Requestor"
        '
        'ResponsibleLabel
        '
        Me.ResponsibleLabel.AutoSize = True
        Me.ResponsibleLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ResponsibleLabel.ForeColor = System.Drawing.Color.White
        Me.ResponsibleLabel.Location = New System.Drawing.Point(11, 96)
        Me.ResponsibleLabel.Name = "ResponsibleLabel"
        Me.ResponsibleLabel.Size = New System.Drawing.Size(81, 19)
        Me.ResponsibleLabel.TabIndex = 6
        Me.ResponsibleLabel.Text = "Responsible"
        '
        'TicketNumberBox
        '
        Me.TicketNumberBox.AllowDrop = True
        Me.TicketNumberBox.Enabled = False
        Me.TicketNumberBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.TicketNumberBox.Location = New System.Drawing.Point(117, 153)
        Me.TicketNumberBox.Name = "TicketNumberBox"
        Me.TicketNumberBox.Size = New System.Drawing.Size(126, 25)
        Me.TicketNumberBox.TabIndex = 6
        '
        'TicketNumberLabel
        '
        Me.TicketNumberLabel.AutoSize = True
        Me.TicketNumberLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.TicketNumberLabel.ForeColor = System.Drawing.Color.White
        Me.TicketNumberLabel.Location = New System.Drawing.Point(11, 153)
        Me.TicketNumberLabel.Name = "TicketNumberLabel"
        Me.TicketNumberLabel.Size = New System.Drawing.Size(96, 19)
        Me.TicketNumberLabel.TabIndex = 11
        Me.TicketNumberLabel.Text = "Ticket number"
        '
        'ResponsibleBox
        '
        Me.ResponsibleBox.AllowDrop = True
        Me.ResponsibleBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ResponsibleBox.Enabled = False
        Me.ResponsibleBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ResponsibleBox.FormattingEnabled = True
        Me.ResponsibleBox.Location = New System.Drawing.Point(117, 96)
        Me.ResponsibleBox.Name = "ResponsibleBox"
        Me.ResponsibleBox.Size = New System.Drawing.Size(126, 25)
        Me.ResponsibleBox.TabIndex = 4
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(218, 410)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(10, 10)
        Me.DataGridView1.TabIndex = 16
        '
        'DateBox
        '
        Me.DateBox.AllowDrop = True
        Me.DateBox.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.DateBox.Enabled = False
        Me.DateBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.DateBox.Location = New System.Drawing.Point(117, 265)
        Me.DateBox.Name = "DateBox"
        Me.DateBox.Size = New System.Drawing.Size(126, 25)
        Me.DateBox.TabIndex = 10
        '
        'StatusLabel
        '
        Me.StatusLabel.AutoSize = True
        Me.StatusLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.StatusLabel.ForeColor = System.Drawing.Color.White
        Me.StatusLabel.Location = New System.Drawing.Point(11, 125)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(47, 19)
        Me.StatusLabel.TabIndex = 20
        Me.StatusLabel.Text = "Status"
        '
        'RegionBox
        '
        Me.RegionBox.AllowDrop = True
        Me.RegionBox.Enabled = False
        Me.RegionBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.RegionBox.Location = New System.Drawing.Point(117, 209)
        Me.RegionBox.Name = "RegionBox"
        Me.RegionBox.Size = New System.Drawing.Size(126, 25)
        Me.RegionBox.TabIndex = 8
        '
        'RegionLabel
        '
        Me.RegionLabel.AutoSize = True
        Me.RegionLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.RegionLabel.ForeColor = System.Drawing.Color.White
        Me.RegionLabel.Location = New System.Drawing.Point(11, 209)
        Me.RegionLabel.Name = "RegionLabel"
        Me.RegionLabel.Size = New System.Drawing.Size(51, 19)
        Me.RegionLabel.TabIndex = 22
        Me.RegionLabel.Text = "Region"
        '
        'PendingSrcBox
        '
        Me.PendingSrcBox.AllowDrop = True
        Me.PendingSrcBox.Enabled = False
        Me.PendingSrcBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.PendingSrcBox.Location = New System.Drawing.Point(117, 237)
        Me.PendingSrcBox.Name = "PendingSrcBox"
        Me.PendingSrcBox.Size = New System.Drawing.Size(126, 25)
        Me.PendingSrcBox.TabIndex = 9
        '
        'PendingSrcLabel
        '
        Me.PendingSrcLabel.AutoSize = True
        Me.PendingSrcLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.PendingSrcLabel.ForeColor = System.Drawing.Color.White
        Me.PendingSrcLabel.Location = New System.Drawing.Point(11, 237)
        Me.PendingSrcLabel.Name = "PendingSrcLabel"
        Me.PendingSrcLabel.Size = New System.Drawing.Size(80, 19)
        Me.PendingSrcLabel.TabIndex = 24
        Me.PendingSrcLabel.Text = "Pending Src"
        '
        'DateLabel
        '
        Me.DateLabel.AutoSize = True
        Me.DateLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.DateLabel.ForeColor = System.Drawing.Color.White
        Me.DateLabel.Location = New System.Drawing.Point(11, 265)
        Me.DateLabel.Name = "DateLabel"
        Me.DateLabel.Size = New System.Drawing.Size(38, 19)
        Me.DateLabel.TabIndex = 26
        Me.DateLabel.Text = "Date"
        '
        'ConectionBox
        '
        Me.ConectionBox.AllowDrop = True
        Me.ConectionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ConectionBox.Enabled = False
        Me.ConectionBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ConectionBox.FormattingEnabled = True
        Me.ConectionBox.Location = New System.Drawing.Point(117, 11)
        Me.ConectionBox.Name = "ConectionBox"
        Me.ConectionBox.Size = New System.Drawing.Size(126, 25)
        Me.ConectionBox.TabIndex = 1
        '
        'ConectionLabel
        '
        Me.ConectionLabel.AutoSize = True
        Me.ConectionLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ConectionLabel.ForeColor = System.Drawing.Color.White
        Me.ConectionLabel.Location = New System.Drawing.Point(11, 14)
        Me.ConectionLabel.Name = "ConectionLabel"
        Me.ConectionLabel.Size = New System.Drawing.Size(71, 19)
        Me.ConectionLabel.TabIndex = 28
        Me.ConectionLabel.Text = "Conection"
        '
        'StatusBox
        '
        Me.StatusBox.AllowDrop = True
        Me.StatusBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.StatusBox.Enabled = False
        Me.StatusBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.StatusBox.FormattingEnabled = True
        Me.StatusBox.Location = New System.Drawing.Point(117, 125)
        Me.StatusBox.Name = "StatusBox"
        Me.StatusBox.Size = New System.Drawing.Size(126, 25)
        Me.StatusBox.TabIndex = 5
        '
        'ActCategoryBox
        '
        Me.ActCategoryBox.AllowDrop = True
        Me.ActCategoryBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ActCategoryBox.Enabled = False
        Me.ActCategoryBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ActCategoryBox.FormattingEnabled = True
        Me.ActCategoryBox.Location = New System.Drawing.Point(117, 67)
        Me.ActCategoryBox.Name = "ActCategoryBox"
        Me.ActCategoryBox.Size = New System.Drawing.Size(126, 25)
        Me.ActCategoryBox.TabIndex = 3
        '
        'ActCategoryLabel
        '
        Me.ActCategoryLabel.AutoSize = True
        Me.ActCategoryLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ActCategoryLabel.ForeColor = System.Drawing.Color.White
        Me.ActCategoryLabel.Location = New System.Drawing.Point(11, 67)
        Me.ActCategoryLabel.Name = "ActCategoryLabel"
        Me.ActCategoryLabel.Size = New System.Drawing.Size(92, 19)
        Me.ActCategoryLabel.TabIndex = 32
        Me.ActCategoryLabel.Text = "Act. Category"
        '
        'TextBox6
        '
        Me.TextBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox6.Location = New System.Drawing.Point(248, 145)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(14, 24)
        Me.TextBox6.TabIndex = 33
        Me.TextBox6.Visible = False
        '
        'TeamBox
        '
        Me.TeamBox.AllowDrop = True
        Me.TeamBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TeamBox.Enabled = False
        Me.TeamBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.TeamBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TeamBox.Location = New System.Drawing.Point(117, 39)
        Me.TeamBox.Name = "TeamBox"
        Me.TeamBox.Size = New System.Drawing.Size(126, 25)
        Me.TeamBox.TabIndex = 2
        '
        'TeamLabel
        '
        Me.TeamLabel.AutoSize = True
        Me.TeamLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.TeamLabel.ForeColor = System.Drawing.Color.White
        Me.TeamLabel.Location = New System.Drawing.Point(11, 39)
        Me.TeamLabel.Name = "TeamLabel"
        Me.TeamLabel.Size = New System.Drawing.Size(41, 19)
        Me.TeamLabel.TabIndex = 35
        Me.TeamLabel.Text = "Team"
        '
        'CommentsLabel
        '
        Me.CommentsLabel.AutoSize = True
        Me.CommentsLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.CommentsLabel.ForeColor = System.Drawing.Color.White
        Me.CommentsLabel.Location = New System.Drawing.Point(12, 293)
        Me.CommentsLabel.Name = "CommentsLabel"
        Me.CommentsLabel.Size = New System.Drawing.Size(76, 19)
        Me.CommentsLabel.TabIndex = 36
        Me.CommentsLabel.Text = "Comments"
        '
        'CommentsBox
        '
        Me.CommentsBox.AllowDrop = True
        Me.CommentsBox.Enabled = False
        Me.CommentsBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.CommentsBox.Location = New System.Drawing.Point(117, 293)
        Me.CommentsBox.Name = "CommentsBox"
        Me.CommentsBox.Size = New System.Drawing.Size(126, 25)
        Me.CommentsBox.TabIndex = 11
        '
        'NewCaseForm
        '
        Me.AcceptButton = Me.CreateCaseButton
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(248, 408)
        Me.Controls.Add(Me.CommentsBox)
        Me.Controls.Add(Me.CommentsLabel)
        Me.Controls.Add(Me.TeamLabel)
        Me.Controls.Add(Me.TeamBox)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.ActCategoryLabel)
        Me.Controls.Add(Me.ActCategoryBox)
        Me.Controls.Add(Me.StatusBox)
        Me.Controls.Add(Me.ConectionLabel)
        Me.Controls.Add(Me.ConectionBox)
        Me.Controls.Add(Me.DateLabel)
        Me.Controls.Add(Me.PendingSrcLabel)
        Me.Controls.Add(Me.PendingSrcBox)
        Me.Controls.Add(Me.RegionLabel)
        Me.Controls.Add(Me.RegionBox)
        Me.Controls.Add(Me.StatusLabel)
        Me.Controls.Add(Me.DateBox)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ResponsibleBox)
        Me.Controls.Add(Me.TicketNumberLabel)
        Me.Controls.Add(Me.TicketNumberBox)
        Me.Controls.Add(Me.ResponsibleLabel)
        Me.Controls.Add(Me.RequestorLabel)
        Me.Controls.Add(Me.RequestorBox)
        Me.Controls.Add(Me.TrakingID)
        Me.Controls.Add(Me.CreateCaseButton)
        Me.ImeMode = System.Windows.Forms.ImeMode.Close
        Me.KeyPreview = True
        Me.MaximumSize = New System.Drawing.Size(264, 447)
        Me.MinimumSize = New System.Drawing.Size(264, 447)
        Me.Name = "NewCaseForm"
        Me.ShowIcon = False
        Me.Text = "New Case"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CreateCaseButton As System.Windows.Forms.Button
    Friend WithEvents TrakingID As System.Windows.Forms.Label
    Friend WithEvents RequestorBox As System.Windows.Forms.TextBox
    Friend WithEvents RequestorLabel As System.Windows.Forms.Label
    Friend WithEvents ResponsibleLabel As System.Windows.Forms.Label
    Friend WithEvents TicketNumberBox As System.Windows.Forms.TextBox
    Friend WithEvents TicketNumberLabel As System.Windows.Forms.Label
    Friend WithEvents ResponsibleBox As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DateBox As System.Windows.Forms.TextBox
    Friend WithEvents StatusLabel As System.Windows.Forms.Label
    Friend WithEvents RegionBox As System.Windows.Forms.TextBox
    Friend WithEvents RegionLabel As System.Windows.Forms.Label
    Friend WithEvents PendingSrcBox As System.Windows.Forms.TextBox
    Friend WithEvents PendingSrcLabel As System.Windows.Forms.Label
    Friend WithEvents DateLabel As System.Windows.Forms.Label
    Friend WithEvents ConectionBox As System.Windows.Forms.ComboBox
    Friend WithEvents ConectionLabel As System.Windows.Forms.Label
    Friend WithEvents StatusBox As System.Windows.Forms.ComboBox
    Friend WithEvents ActCategoryBox As System.Windows.Forms.ComboBox
    Friend WithEvents ActCategoryLabel As System.Windows.Forms.Label
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents TeamBox As System.Windows.Forms.ComboBox
    Friend WithEvents TeamLabel As System.Windows.Forms.Label
    Friend WithEvents CommentsLabel As System.Windows.Forms.Label
    Friend WithEvents CommentsBox As System.Windows.Forms.TextBox
End Class
