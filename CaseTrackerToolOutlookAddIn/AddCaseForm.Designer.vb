<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddCaseForm
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
        Me.TrakingID = New System.Windows.Forms.Label()
        Me.RequestorLabel = New System.Windows.Forms.Label()
        Me.ResponsibleLabel = New System.Windows.Forms.Label()
        Me.ResponsibleBox = New System.Windows.Forms.ComboBox()
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
        Me.TeamLabel = New System.Windows.Forms.Label()
        Me.QuantityLabel = New System.Windows.Forms.Label()
        Me.CommentsBox = New System.Windows.Forms.TextBox()
        Me.PriorityLabel = New System.Windows.Forms.Label()
        Me.PriorityBox = New System.Windows.Forms.ComboBox()
        Me.TeamBox = New System.Windows.Forms.ComboBox()
        Me.ActivitiesVisualAssistButton = New System.Windows.Forms.Button()
        Me.CreateCaseButton = New System.Windows.Forms.Button()
        Me.RequestorBox = New System.Windows.Forms.ComboBox()
        Me.DateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.QuantityBox = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.QuantityBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'ResponsibleBox
        '
        Me.ResponsibleBox.AllowDrop = True
        Me.ResponsibleBox.DropDownWidth = 400
        Me.ResponsibleBox.Enabled = False
        Me.ResponsibleBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ResponsibleBox.FormattingEnabled = True
        Me.ResponsibleBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.ResponsibleBox.Location = New System.Drawing.Point(117, 95)
        Me.ResponsibleBox.Name = "ResponsibleBox"
        Me.ResponsibleBox.Size = New System.Drawing.Size(126, 25)
        Me.ResponsibleBox.TabIndex = 5
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
        Me.RegionBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.RegionBox.Location = New System.Drawing.Point(117, 207)
        Me.RegionBox.Name = "RegionBox"
        Me.RegionBox.Size = New System.Drawing.Size(126, 25)
        Me.RegionBox.TabIndex = 9
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
        Me.PendingSrcBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.PendingSrcBox.Location = New System.Drawing.Point(117, 235)
        Me.PendingSrcBox.Name = "PendingSrcBox"
        Me.PendingSrcBox.Size = New System.Drawing.Size(126, 25)
        Me.PendingSrcBox.TabIndex = 10
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
        Me.ConectionBox.BackColor = System.Drawing.SystemColors.Window
        Me.ConectionBox.DropDownWidth = 126
        Me.ConectionBox.Enabled = False
        Me.ConectionBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ConectionBox.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ConectionBox.FormattingEnabled = True
        Me.ConectionBox.ImeMode = System.Windows.Forms.ImeMode.Disable
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
        Me.StatusBox.Enabled = False
        Me.StatusBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.StatusBox.FormattingEnabled = True
        Me.StatusBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.StatusBox.Location = New System.Drawing.Point(117, 123)
        Me.StatusBox.Name = "StatusBox"
        Me.StatusBox.Size = New System.Drawing.Size(126, 25)
        Me.StatusBox.TabIndex = 6
        '
        'ActCategoryBox
        '
        Me.ActCategoryBox.AllowDrop = True
        Me.ActCategoryBox.DropDownWidth = 400
        Me.ActCategoryBox.Enabled = False
        Me.ActCategoryBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ActCategoryBox.FormattingEnabled = True
        Me.ActCategoryBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.ActCategoryBox.Location = New System.Drawing.Point(117, 67)
        Me.ActCategoryBox.Name = "ActCategoryBox"
        Me.ActCategoryBox.Size = New System.Drawing.Size(95, 25)
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
        'QuantityLabel
        '
        Me.QuantityLabel.AutoSize = True
        Me.QuantityLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.QuantityLabel.ForeColor = System.Drawing.Color.White
        Me.QuantityLabel.Location = New System.Drawing.Point(11, 293)
        Me.QuantityLabel.Name = "QuantityLabel"
        Me.QuantityLabel.Size = New System.Drawing.Size(63, 19)
        Me.QuantityLabel.TabIndex = 36
        Me.QuantityLabel.Text = "Quantity"
        '
        'CommentsBox
        '
        Me.CommentsBox.AllowDrop = True
        Me.CommentsBox.Enabled = False
        Me.CommentsBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.CommentsBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.CommentsBox.Location = New System.Drawing.Point(117, 319)
        Me.CommentsBox.Multiline = True
        Me.CommentsBox.Name = "CommentsBox"
        Me.CommentsBox.Size = New System.Drawing.Size(126, 55)
        Me.CommentsBox.TabIndex = 12
        '
        'PriorityLabel
        '
        Me.PriorityLabel.AutoSize = True
        Me.PriorityLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.PriorityLabel.ForeColor = System.Drawing.Color.White
        Me.PriorityLabel.Location = New System.Drawing.Point(11, 153)
        Me.PriorityLabel.Name = "PriorityLabel"
        Me.PriorityLabel.Size = New System.Drawing.Size(53, 19)
        Me.PriorityLabel.TabIndex = 11
        Me.PriorityLabel.Text = "Priority"
        '
        'PriorityBox
        '
        Me.PriorityBox.AllowDrop = True
        Me.PriorityBox.Enabled = False
        Me.PriorityBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.PriorityBox.FormattingEnabled = True
        Me.PriorityBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.PriorityBox.Location = New System.Drawing.Point(117, 151)
        Me.PriorityBox.Name = "PriorityBox"
        Me.PriorityBox.Size = New System.Drawing.Size(126, 25)
        Me.PriorityBox.TabIndex = 7
        '
        'TeamBox
        '
        Me.TeamBox.AllowDrop = True
        Me.TeamBox.DropDownWidth = 126
        Me.TeamBox.Enabled = False
        Me.TeamBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.TeamBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TeamBox.Location = New System.Drawing.Point(117, 39)
        Me.TeamBox.Name = "TeamBox"
        Me.TeamBox.Size = New System.Drawing.Size(126, 25)
        Me.TeamBox.TabIndex = 2
        '
        'ActivitiesVisualAssistButton
        '
        Me.ActivitiesVisualAssistButton.Enabled = False
        Me.ActivitiesVisualAssistButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ActivitiesVisualAssistButton.Location = New System.Drawing.Point(215, 66)
        Me.ActivitiesVisualAssistButton.Name = "ActivitiesVisualAssistButton"
        Me.ActivitiesVisualAssistButton.Size = New System.Drawing.Size(28, 27)
        Me.ActivitiesVisualAssistButton.TabIndex = 4
        Me.ActivitiesVisualAssistButton.Text = "..."
        Me.ActivitiesVisualAssistButton.UseVisualStyleBackColor = True
        '
        'CreateCaseButton
        '
        Me.CreateCaseButton.FlatAppearance.BorderSize = 0
        Me.CreateCaseButton.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.CreateCaseButton.Location = New System.Drawing.Point(188, 377)
        Me.CreateCaseButton.Name = "CreateCaseButton"
        Me.CreateCaseButton.Size = New System.Drawing.Size(55, 32)
        Me.CreateCaseButton.TabIndex = 13
        Me.CreateCaseButton.Text = "Create"
        Me.CreateCaseButton.UseVisualStyleBackColor = True
        '
        'RequestorBox
        '
        Me.RequestorBox.AllowDrop = True
        Me.RequestorBox.Enabled = False
        Me.RequestorBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.RequestorBox.FormattingEnabled = True
        Me.RequestorBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.RequestorBox.Location = New System.Drawing.Point(117, 179)
        Me.RequestorBox.Name = "RequestorBox"
        Me.RequestorBox.Size = New System.Drawing.Size(126, 25)
        Me.RequestorBox.TabIndex = 8
        '
        'DateTimePicker
        '
        Me.DateTimePicker.Enabled = False
        Me.DateTimePicker.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker.Location = New System.Drawing.Point(117, 263)
        Me.DateTimePicker.Name = "DateTimePicker"
        Me.DateTimePicker.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DateTimePicker.Size = New System.Drawing.Size(126, 25)
        Me.DateTimePicker.TabIndex = 11
        '
        'QuantityBox
        '
        Me.QuantityBox.Enabled = False
        Me.QuantityBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.QuantityBox.Location = New System.Drawing.Point(117, 291)
        Me.QuantityBox.Name = "QuantityBox"
        Me.QuantityBox.Size = New System.Drawing.Size(126, 25)
        Me.QuantityBox.TabIndex = 37
        Me.QuantityBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(11, 322)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 19)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Comments"
        '
        'AddCaseForm
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(248, 431)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.QuantityBox)
        Me.Controls.Add(Me.DateTimePicker)
        Me.Controls.Add(Me.RequestorBox)
        Me.Controls.Add(Me.CreateCaseButton)
        Me.Controls.Add(Me.ActivitiesVisualAssistButton)
        Me.Controls.Add(Me.PriorityBox)
        Me.Controls.Add(Me.CommentsBox)
        Me.Controls.Add(Me.QuantityLabel)
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
        Me.Controls.Add(Me.ResponsibleBox)
        Me.Controls.Add(Me.PriorityLabel)
        Me.Controls.Add(Me.ResponsibleLabel)
        Me.Controls.Add(Me.RequestorLabel)
        Me.Controls.Add(Me.TrakingID)
        Me.ImeMode = System.Windows.Forms.ImeMode.Close
        Me.Name = "AddCaseForm"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add Case"
        CType(Me.QuantityBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrakingID As System.Windows.Forms.Label
    Friend WithEvents RequestorLabel As System.Windows.Forms.Label
    Friend WithEvents ResponsibleLabel As System.Windows.Forms.Label
    Friend WithEvents ResponsibleBox As System.Windows.Forms.ComboBox
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
    Friend WithEvents TeamLabel As System.Windows.Forms.Label
    Friend WithEvents QuantityLabel As System.Windows.Forms.Label
    Friend WithEvents CommentsBox As System.Windows.Forms.TextBox
    Friend WithEvents PriorityLabel As System.Windows.Forms.Label
    Friend WithEvents PriorityBox As System.Windows.Forms.ComboBox
    Friend WithEvents TeamBox As System.Windows.Forms.ComboBox
    Friend WithEvents ActivitiesVisualAssistButton As System.Windows.Forms.Button
    Friend WithEvents CreateCaseButton As System.Windows.Forms.Button
    Friend WithEvents RequestorBox As System.Windows.Forms.ComboBox
    Friend WithEvents DateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents QuantityBox As System.Windows.Forms.NumericUpDown
End Class
