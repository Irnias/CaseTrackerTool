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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TicketNumberBox = New System.Windows.Forms.TextBox()
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.SearchButton = New System.Windows.Forms.Button()
        Me.OpenButton = New System.Windows.Forms.Button()
        Me.ConectionBox = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CommentsBox = New System.Windows.Forms.TextBox()
        Me.StatusBox = New System.Windows.Forms.TextBox()
        Me.PendingSourceBox = New System.Windows.Forms.TextBox()
        Me.ResponsibleBox = New System.Windows.Forms.TextBox()
        Me.ModifyCaseButton = New System.Windows.Forms.Button()
        Me.RegionBox = New System.Windows.Forms.TextBox()
        Me.RequestorBox = New System.Windows.Forms.TextBox()
        Me.OpenedDateBox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ModifyCaseCheckBox = New System.Windows.Forms.CheckBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 19)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Ticket number:"
        '
        'TicketNumberBox
        '
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
        Me.ConectionBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ConectionBox.FormattingEnabled = True
        Me.ConectionBox.Location = New System.Drawing.Point(117, 13)
        Me.ConectionBox.Name = "ConectionBox"
        Me.ConectionBox.Size = New System.Drawing.Size(126, 25)
        Me.ConectionBox.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(12, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 19)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "Conection:"
        '
        'Label6
        '
        Me.Label6.AllowDrop = True
        Me.Label6.AutoSize = True
        Me.Label6.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(9, 311)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 19)
        Me.Label6.TabIndex = 61
        Me.Label6.Text = "Comments:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(9, 283)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 19)
        Me.Label7.TabIndex = 60
        Me.Label7.Text = "Pending Src:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(9, 255)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 19)
        Me.Label3.TabIndex = 59
        Me.Label3.Text = "Requestor:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(9, 227)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 19)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "Opened Date:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(9, 143)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 19)
        Me.Label4.TabIndex = 57
        Me.Label4.Text = "Status"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(9, 199)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 19)
        Me.Label10.TabIndex = 56
        Me.Label10.Text = "Region:"
        '
        'CommentsBox
        '
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
        Me.StatusBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.StatusBox.ForeColor = System.Drawing.Color.DodgerBlue
        Me.StatusBox.Location = New System.Drawing.Point(114, 143)
        Me.StatusBox.Name = "StatusBox"
        Me.StatusBox.Size = New System.Drawing.Size(126, 25)
        Me.StatusBox.TabIndex = 3
        '
        'PendingSourceBox
        '
        Me.PendingSourceBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.PendingSourceBox.Location = New System.Drawing.Point(114, 283)
        Me.PendingSourceBox.Name = "PendingSourceBox"
        Me.PendingSourceBox.Size = New System.Drawing.Size(126, 25)
        Me.PendingSourceBox.TabIndex = 8
        '
        'ResponsibleBox
        '
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
        Me.ModifyCaseButton.TabIndex = 10
        Me.ModifyCaseButton.Text = "Modify"
        Me.ModifyCaseButton.UseVisualStyleBackColor = True
        '
        'RegionBox
        '
        Me.RegionBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.RegionBox.Location = New System.Drawing.Point(114, 199)
        Me.RegionBox.Name = "RegionBox"
        Me.RegionBox.Size = New System.Drawing.Size(126, 25)
        Me.RegionBox.TabIndex = 5
        '
        'RequestorBox
        '
        Me.RequestorBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.RequestorBox.Location = New System.Drawing.Point(114, 255)
        Me.RequestorBox.Name = "RequestorBox"
        Me.RequestorBox.Size = New System.Drawing.Size(126, 25)
        Me.RequestorBox.TabIndex = 7
        '
        'OpenedDateBox
        '
        Me.OpenedDateBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.OpenedDateBox.Location = New System.Drawing.Point(114, 227)
        Me.OpenedDateBox.Name = "OpenedDateBox"
        Me.OpenedDateBox.Size = New System.Drawing.Size(126, 25)
        Me.OpenedDateBox.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(9, 171)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 19)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "Responsible:"
        '
        'ModifyCaseCheckBox
        '
        Me.ModifyCaseCheckBox.AutoSize = True
        Me.ModifyCaseCheckBox.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ModifyCaseCheckBox.ForeColor = System.Drawing.Color.White
        Me.ModifyCaseCheckBox.Location = New System.Drawing.Point(9, 110)
        Me.ModifyCaseCheckBox.Name = "ModifyCaseCheckBox"
        Me.ModifyCaseCheckBox.Size = New System.Drawing.Size(89, 17)
        Me.ModifyCaseCheckBox.TabIndex = 50
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
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.CommentsBox)
        Me.Controls.Add(Me.StatusBox)
        Me.Controls.Add(Me.PendingSourceBox)
        Me.Controls.Add(Me.ResponsibleBox)
        Me.Controls.Add(Me.ModifyCaseButton)
        Me.Controls.Add(Me.RegionBox)
        Me.Controls.Add(Me.RequestorBox)
        Me.Controls.Add(Me.OpenedDateBox)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ModifyCaseCheckBox)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ConectionBox)
        Me.Controls.Add(Me.OpenButton)
        Me.Controls.Add(Me.SearchButton)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.TicketNumberBox)
        Me.Controls.Add(Me.Label1)
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TicketNumberBox As System.Windows.Forms.TextBox
    Friend WithEvents CloseButton As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents SearchButton As System.Windows.Forms.Button
    Friend WithEvents OpenButton As System.Windows.Forms.Button
    Friend WithEvents ConectionBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CommentsBox As System.Windows.Forms.TextBox
    Friend WithEvents StatusBox As System.Windows.Forms.TextBox
    Friend WithEvents PendingSourceBox As System.Windows.Forms.TextBox
    Friend WithEvents ResponsibleBox As System.Windows.Forms.TextBox
    Friend WithEvents ModifyCaseButton As System.Windows.Forms.Button
    Friend WithEvents RegionBox As System.Windows.Forms.TextBox
    Friend WithEvents RequestorBox As System.Windows.Forms.TextBox
    Friend WithEvents OpenedDateBox As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ModifyCaseCheckBox As System.Windows.Forms.CheckBox
End Class
