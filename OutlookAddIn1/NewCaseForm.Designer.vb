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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TrakingID = New System.Windows.Forms.Label()
        Me.RequestorBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TicketNumberBox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ResponsibleBox = New System.Windows.Forms.ComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DateBox = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.RegionBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PendingSrcBox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ConectionBox = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.StatusBox = New System.Windows.Forms.ComboBox()
        Me.ActCategoryBox = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.TeamBox = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.CommentsBox = New System.Windows.Forms.TextBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CreateCaseButton
        '
        Me.CreateCaseButton.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.CreateCaseButton.Location = New System.Drawing.Point(189, 349)
        Me.CreateCaseButton.Name = "CreateCaseButton"
        Me.CreateCaseButton.Size = New System.Drawing.Size(55, 32)
        Me.CreateCaseButton.TabIndex = 0
        Me.CreateCaseButton.Text = "Create"
        Me.CreateCaseButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Tracking ID:"
        '
        'TrakingID
        '
        Me.TrakingID.AutoSize = True
        Me.TrakingID.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.TrakingID.ForeColor = System.Drawing.Color.White
        Me.TrakingID.Location = New System.Drawing.Point(119, 14)
        Me.TrakingID.Margin = New System.Windows.Forms.Padding(3)
        Me.TrakingID.Name = "TrakingID"
        Me.TrakingID.Size = New System.Drawing.Size(121, 19)
        Me.TrakingID.TabIndex = 2
        Me.TrakingID.Text = "00000000000000"
        Me.TrakingID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RequestorBox
        '
        Me.RequestorBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.RequestorBox.Location = New System.Drawing.Point(117, 181)
        Me.RequestorBox.Name = "RequestorBox"
        Me.RequestorBox.Size = New System.Drawing.Size(126, 25)
        Me.RequestorBox.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(11, 181)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 19)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Requestor:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(11, 209)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 19)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Responsible:"
        '
        'TicketNumberBox
        '
        Me.TicketNumberBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.TicketNumberBox.Location = New System.Drawing.Point(117, 153)
        Me.TicketNumberBox.Name = "TicketNumberBox"
        Me.TicketNumberBox.Size = New System.Drawing.Size(126, 25)
        Me.TicketNumberBox.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(11, 153)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(99, 19)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Ticket number:"
        '
        'ResponsibleBox
        '
        Me.ResponsibleBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ResponsibleBox.FormattingEnabled = True
        Me.ResponsibleBox.Location = New System.Drawing.Point(117, 209)
        Me.ResponsibleBox.Name = "ResponsibleBox"
        Me.ResponsibleBox.Size = New System.Drawing.Size(126, 25)
        Me.ResponsibleBox.TabIndex = 14
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
        Me.DateBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.DateBox.Location = New System.Drawing.Point(117, 125)
        Me.DateBox.Name = "DateBox"
        Me.DateBox.Size = New System.Drawing.Size(126, 25)
        Me.DateBox.TabIndex = 19
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(11, 125)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 19)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Date:"
        '
        'RegionBox
        '
        Me.RegionBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.RegionBox.Location = New System.Drawing.Point(117, 237)
        Me.RegionBox.Name = "RegionBox"
        Me.RegionBox.Size = New System.Drawing.Size(126, 25)
        Me.RegionBox.TabIndex = 21
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(11, 237)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 19)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Region:"
        '
        'PendingSrcBox
        '
        Me.PendingSrcBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.PendingSrcBox.Location = New System.Drawing.Point(117, 265)
        Me.PendingSrcBox.Name = "PendingSrcBox"
        Me.PendingSrcBox.Size = New System.Drawing.Size(126, 25)
        Me.PendingSrcBox.TabIndex = 23
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(11, 265)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 19)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Pending Src:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(11, 293)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 19)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Status:"
        '
        'ConectionBox
        '
        Me.ConectionBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ConectionBox.FormattingEnabled = True
        Me.ConectionBox.Location = New System.Drawing.Point(117, 97)
        Me.ConectionBox.Name = "ConectionBox"
        Me.ConectionBox.Size = New System.Drawing.Size(126, 25)
        Me.ConectionBox.TabIndex = 27
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(11, 97)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(74, 19)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Conection:"
        '
        'StatusBox
        '
        Me.StatusBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.StatusBox.FormattingEnabled = True
        Me.StatusBox.Location = New System.Drawing.Point(117, 293)
        Me.StatusBox.Name = "StatusBox"
        Me.StatusBox.Size = New System.Drawing.Size(126, 25)
        Me.StatusBox.TabIndex = 30
        '
        'ActCategoryBox
        '
        Me.ActCategoryBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ActCategoryBox.FormattingEnabled = True
        Me.ActCategoryBox.Location = New System.Drawing.Point(117, 69)
        Me.ActCategoryBox.Name = "ActCategoryBox"
        Me.ActCategoryBox.Size = New System.Drawing.Size(126, 25)
        Me.ActCategoryBox.TabIndex = 31
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(12, 69)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(95, 19)
        Me.Label12.TabIndex = 32
        Me.Label12.Text = "Act. Category:"
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
        Me.TeamBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.TeamBox.FormattingEnabled = True
        Me.TeamBox.Location = New System.Drawing.Point(117, 41)
        Me.TeamBox.Name = "TeamBox"
        Me.TeamBox.Size = New System.Drawing.Size(126, 25)
        Me.TeamBox.TabIndex = 34
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(11, 41)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(44, 19)
        Me.Label13.TabIndex = 35
        Me.Label13.Text = "Team:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(12, 321)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(79, 19)
        Me.Label14.TabIndex = 36
        Me.Label14.Text = "Comments:"
        '
        'CommentsBox
        '
        Me.CommentsBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.CommentsBox.Location = New System.Drawing.Point(117, 321)
        Me.CommentsBox.Name = "CommentsBox"
        Me.CommentsBox.Size = New System.Drawing.Size(126, 25)
        Me.CommentsBox.TabIndex = 37
        '
        'NewCaseForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ClientSize = New System.Drawing.Size(248, 408)
        Me.Controls.Add(Me.CommentsBox)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TeamBox)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.ActCategoryBox)
        Me.Controls.Add(Me.StatusBox)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.ConectionBox)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.PendingSrcBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.RegionBox)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.DateBox)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ResponsibleBox)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TicketNumberBox)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.RequestorBox)
        Me.Controls.Add(Me.TrakingID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CreateCaseButton)
        Me.MaximumSize = New System.Drawing.Size(264, 447)
        Me.MinimumSize = New System.Drawing.Size(264, 447)
        Me.Name = "NewCaseForm"
        Me.ShowIcon = False
        Me.Text = "Perf. Tracking Tool"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CreateCaseButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TrakingID As System.Windows.Forms.Label
    Friend WithEvents RequestorBox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TicketNumberBox As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ResponsibleBox As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DateBox As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents RegionBox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PendingSrcBox As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ConectionBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents StatusBox As System.Windows.Forms.ComboBox
    Friend WithEvents ActCategoryBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents TeamBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents CommentsBox As System.Windows.Forms.TextBox
End Class
