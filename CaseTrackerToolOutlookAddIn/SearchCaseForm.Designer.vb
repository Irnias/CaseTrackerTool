<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SearchCaseForm
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
        Me.TicketNumberBox = New System.Windows.Forms.TextBox()
        Me.TicketNumberLabel = New System.Windows.Forms.Label()
        Me.ConectionLabel = New System.Windows.Forms.Label()
        Me.ConectionBox = New System.Windows.Forms.ComboBox()
        Me.CommentsLabel = New System.Windows.Forms.Label()
        Me.TeamLabel = New System.Windows.Forms.Label()
        Me.ActCategoryLabel = New System.Windows.Forms.Label()
        Me.DateLabel = New System.Windows.Forms.Label()
        Me.PendingSrcLabel = New System.Windows.Forms.Label()
        Me.RegionLabel = New System.Windows.Forms.Label()
        Me.StatusLabel = New System.Windows.Forms.Label()
        Me.PriorityLabel = New System.Windows.Forms.Label()
        Me.ResponsibleLabel = New System.Windows.Forms.Label()
        Me.RequestorLabel = New System.Windows.Forms.Label()
        Me.TeamBox = New System.Windows.Forms.TextBox()
        Me.ActCategoryBox = New System.Windows.Forms.TextBox()
        Me.ResponsibleBox = New System.Windows.Forms.TextBox()
        Me.StatusBox = New System.Windows.Forms.TextBox()
        Me.PriorityBox = New System.Windows.Forms.TextBox()
        Me.RequestorBox = New System.Windows.Forms.TextBox()
        Me.RegionBox = New System.Windows.Forms.TextBox()
        Me.PendingSourceBox = New System.Windows.Forms.TextBox()
        Me.DateBox = New System.Windows.Forms.TextBox()
        Me.CommentsBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'TicketNumberBox
        '
        Me.TicketNumberBox.AllowDrop = True
        Me.TicketNumberBox.Enabled = False
        Me.TicketNumberBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.TicketNumberBox.Location = New System.Drawing.Point(116, 37)
        Me.TicketNumberBox.Name = "TicketNumberBox"
        Me.TicketNumberBox.Size = New System.Drawing.Size(126, 25)
        Me.TicketNumberBox.TabIndex = 47
        '
        'TicketNumberLabel
        '
        Me.TicketNumberLabel.AutoSize = True
        Me.TicketNumberLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.TicketNumberLabel.ForeColor = System.Drawing.Color.White
        Me.TicketNumberLabel.Location = New System.Drawing.Point(9, 40)
        Me.TicketNumberLabel.Name = "TicketNumberLabel"
        Me.TicketNumberLabel.Size = New System.Drawing.Size(98, 19)
        Me.TicketNumberLabel.TabIndex = 46
        Me.TicketNumberLabel.Text = "Ticket Number"
        '
        'ConectionLabel
        '
        Me.ConectionLabel.AutoSize = True
        Me.ConectionLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ConectionLabel.ForeColor = System.Drawing.Color.White
        Me.ConectionLabel.Location = New System.Drawing.Point(11, 12)
        Me.ConectionLabel.Name = "ConectionLabel"
        Me.ConectionLabel.Size = New System.Drawing.Size(71, 19)
        Me.ConectionLabel.TabIndex = 45
        Me.ConectionLabel.Text = "Conection"
        '
        'ConectionBox
        '
        Me.ConectionBox.AllowDrop = True
        Me.ConectionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ConectionBox.Enabled = False
        Me.ConectionBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ConectionBox.FormattingEnabled = True
        Me.ConectionBox.Location = New System.Drawing.Point(116, 9)
        Me.ConectionBox.Name = "ConectionBox"
        Me.ConectionBox.Size = New System.Drawing.Size(126, 25)
        Me.ConectionBox.TabIndex = 44
        '
        'CommentsLabel
        '
        Me.CommentsLabel.AutoSize = True
        Me.CommentsLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.CommentsLabel.ForeColor = System.Drawing.Color.White
        Me.CommentsLabel.Location = New System.Drawing.Point(13, 317)
        Me.CommentsLabel.Name = "CommentsLabel"
        Me.CommentsLabel.Size = New System.Drawing.Size(76, 19)
        Me.CommentsLabel.TabIndex = 57
        Me.CommentsLabel.Text = "Comments"
        '
        'TeamLabel
        '
        Me.TeamLabel.AutoSize = True
        Me.TeamLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.TeamLabel.ForeColor = System.Drawing.Color.White
        Me.TeamLabel.Location = New System.Drawing.Point(12, 68)
        Me.TeamLabel.Name = "TeamLabel"
        Me.TeamLabel.Size = New System.Drawing.Size(41, 19)
        Me.TeamLabel.TabIndex = 56
        Me.TeamLabel.Text = "Team"
        '
        'ActCategoryLabel
        '
        Me.ActCategoryLabel.AutoSize = True
        Me.ActCategoryLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ActCategoryLabel.ForeColor = System.Drawing.Color.White
        Me.ActCategoryLabel.Location = New System.Drawing.Point(12, 96)
        Me.ActCategoryLabel.Name = "ActCategoryLabel"
        Me.ActCategoryLabel.Size = New System.Drawing.Size(92, 19)
        Me.ActCategoryLabel.TabIndex = 55
        Me.ActCategoryLabel.Text = "Act. Category"
        '
        'DateLabel
        '
        Me.DateLabel.AutoSize = True
        Me.DateLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.DateLabel.ForeColor = System.Drawing.Color.White
        Me.DateLabel.Location = New System.Drawing.Point(12, 291)
        Me.DateLabel.Name = "DateLabel"
        Me.DateLabel.Size = New System.Drawing.Size(38, 19)
        Me.DateLabel.TabIndex = 54
        Me.DateLabel.Text = "Date"
        '
        'PendingSrcLabel
        '
        Me.PendingSrcLabel.AutoSize = True
        Me.PendingSrcLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.PendingSrcLabel.ForeColor = System.Drawing.Color.White
        Me.PendingSrcLabel.Location = New System.Drawing.Point(12, 263)
        Me.PendingSrcLabel.Name = "PendingSrcLabel"
        Me.PendingSrcLabel.Size = New System.Drawing.Size(80, 19)
        Me.PendingSrcLabel.TabIndex = 53
        Me.PendingSrcLabel.Text = "Pending Src"
        '
        'RegionLabel
        '
        Me.RegionLabel.AutoSize = True
        Me.RegionLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.RegionLabel.ForeColor = System.Drawing.Color.White
        Me.RegionLabel.Location = New System.Drawing.Point(12, 235)
        Me.RegionLabel.Name = "RegionLabel"
        Me.RegionLabel.Size = New System.Drawing.Size(51, 19)
        Me.RegionLabel.TabIndex = 52
        Me.RegionLabel.Text = "Region"
        '
        'StatusLabel
        '
        Me.StatusLabel.AutoSize = True
        Me.StatusLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.StatusLabel.ForeColor = System.Drawing.Color.White
        Me.StatusLabel.Location = New System.Drawing.Point(12, 152)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(47, 19)
        Me.StatusLabel.TabIndex = 51
        Me.StatusLabel.Text = "Status"
        '
        'PriorityLabel
        '
        Me.PriorityLabel.AutoSize = True
        Me.PriorityLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.PriorityLabel.ForeColor = System.Drawing.Color.White
        Me.PriorityLabel.Location = New System.Drawing.Point(12, 180)
        Me.PriorityLabel.Name = "PriorityLabel"
        Me.PriorityLabel.Size = New System.Drawing.Size(53, 19)
        Me.PriorityLabel.TabIndex = 50
        Me.PriorityLabel.Text = "Priority"
        '
        'ResponsibleLabel
        '
        Me.ResponsibleLabel.AutoSize = True
        Me.ResponsibleLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ResponsibleLabel.ForeColor = System.Drawing.Color.White
        Me.ResponsibleLabel.Location = New System.Drawing.Point(12, 124)
        Me.ResponsibleLabel.Name = "ResponsibleLabel"
        Me.ResponsibleLabel.Size = New System.Drawing.Size(81, 19)
        Me.ResponsibleLabel.TabIndex = 49
        Me.ResponsibleLabel.Text = "Responsible"
        '
        'RequestorLabel
        '
        Me.RequestorLabel.AutoSize = True
        Me.RequestorLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.RequestorLabel.ForeColor = System.Drawing.Color.White
        Me.RequestorLabel.Location = New System.Drawing.Point(12, 207)
        Me.RequestorLabel.Name = "RequestorLabel"
        Me.RequestorLabel.Size = New System.Drawing.Size(71, 19)
        Me.RequestorLabel.TabIndex = 48
        Me.RequestorLabel.Text = "Requestor"
        '
        'TeamBox
        '
        Me.TeamBox.AllowDrop = True
        Me.TeamBox.Enabled = False
        Me.TeamBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.TeamBox.Location = New System.Drawing.Point(116, 65)
        Me.TeamBox.Name = "TeamBox"
        Me.TeamBox.Size = New System.Drawing.Size(126, 25)
        Me.TeamBox.TabIndex = 58
        '
        'ActCategoryBox
        '
        Me.ActCategoryBox.AllowDrop = True
        Me.ActCategoryBox.Enabled = False
        Me.ActCategoryBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ActCategoryBox.Location = New System.Drawing.Point(116, 93)
        Me.ActCategoryBox.Name = "ActCategoryBox"
        Me.ActCategoryBox.Size = New System.Drawing.Size(126, 25)
        Me.ActCategoryBox.TabIndex = 59
        '
        'ResponsibleBox
        '
        Me.ResponsibleBox.AllowDrop = True
        Me.ResponsibleBox.Enabled = False
        Me.ResponsibleBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ResponsibleBox.Location = New System.Drawing.Point(116, 121)
        Me.ResponsibleBox.Name = "ResponsibleBox"
        Me.ResponsibleBox.Size = New System.Drawing.Size(126, 25)
        Me.ResponsibleBox.TabIndex = 60
        '
        'StatusBox
        '
        Me.StatusBox.AllowDrop = True
        Me.StatusBox.Enabled = False
        Me.StatusBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.StatusBox.Location = New System.Drawing.Point(116, 149)
        Me.StatusBox.Name = "StatusBox"
        Me.StatusBox.Size = New System.Drawing.Size(126, 25)
        Me.StatusBox.TabIndex = 61
        '
        'PriorityBox
        '
        Me.PriorityBox.AllowDrop = True
        Me.PriorityBox.Enabled = False
        Me.PriorityBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.PriorityBox.Location = New System.Drawing.Point(116, 177)
        Me.PriorityBox.Name = "PriorityBox"
        Me.PriorityBox.Size = New System.Drawing.Size(126, 25)
        Me.PriorityBox.TabIndex = 62
        '
        'RequestorBox
        '
        Me.RequestorBox.AllowDrop = True
        Me.RequestorBox.Enabled = False
        Me.RequestorBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.RequestorBox.Location = New System.Drawing.Point(116, 204)
        Me.RequestorBox.Name = "RequestorBox"
        Me.RequestorBox.Size = New System.Drawing.Size(126, 25)
        Me.RequestorBox.TabIndex = 63
        '
        'RegionBox
        '
        Me.RegionBox.AllowDrop = True
        Me.RegionBox.Enabled = False
        Me.RegionBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.RegionBox.Location = New System.Drawing.Point(116, 232)
        Me.RegionBox.Name = "RegionBox"
        Me.RegionBox.Size = New System.Drawing.Size(126, 25)
        Me.RegionBox.TabIndex = 64
        '
        'PendingSourceBox
        '
        Me.PendingSourceBox.AllowDrop = True
        Me.PendingSourceBox.Enabled = False
        Me.PendingSourceBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.PendingSourceBox.Location = New System.Drawing.Point(116, 260)
        Me.PendingSourceBox.Name = "PendingSourceBox"
        Me.PendingSourceBox.Size = New System.Drawing.Size(126, 25)
        Me.PendingSourceBox.TabIndex = 65
        '
        'DateBox
        '
        Me.DateBox.AllowDrop = True
        Me.DateBox.Enabled = False
        Me.DateBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.DateBox.Location = New System.Drawing.Point(116, 288)
        Me.DateBox.Name = "DateBox"
        Me.DateBox.Size = New System.Drawing.Size(126, 25)
        Me.DateBox.TabIndex = 66
        '
        'CommentsBox
        '
        Me.CommentsBox.AllowDrop = True
        Me.CommentsBox.Enabled = False
        Me.CommentsBox.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.CommentsBox.Location = New System.Drawing.Point(116, 317)
        Me.CommentsBox.Multiline = True
        Me.CommentsBox.Name = "CommentsBox"
        Me.CommentsBox.Size = New System.Drawing.Size(126, 55)
        Me.CommentsBox.TabIndex = 67
        '
        'SearchCaseForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(248, 411)
        Me.Controls.Add(Me.CommentsBox)
        Me.Controls.Add(Me.DateBox)
        Me.Controls.Add(Me.PendingSourceBox)
        Me.Controls.Add(Me.RegionBox)
        Me.Controls.Add(Me.RequestorBox)
        Me.Controls.Add(Me.PriorityBox)
        Me.Controls.Add(Me.StatusBox)
        Me.Controls.Add(Me.ResponsibleBox)
        Me.Controls.Add(Me.ActCategoryBox)
        Me.Controls.Add(Me.TeamBox)
        Me.Controls.Add(Me.CommentsLabel)
        Me.Controls.Add(Me.TeamLabel)
        Me.Controls.Add(Me.ActCategoryLabel)
        Me.Controls.Add(Me.DateLabel)
        Me.Controls.Add(Me.PendingSrcLabel)
        Me.Controls.Add(Me.RegionLabel)
        Me.Controls.Add(Me.StatusLabel)
        Me.Controls.Add(Me.PriorityLabel)
        Me.Controls.Add(Me.ResponsibleLabel)
        Me.Controls.Add(Me.RequestorLabel)
        Me.Controls.Add(Me.TicketNumberBox)
        Me.Controls.Add(Me.TicketNumberLabel)
        Me.Controls.Add(Me.ConectionLabel)
        Me.Controls.Add(Me.ConectionBox)
        Me.Name = "SearchCaseForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Search Case"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TicketNumberBox As System.Windows.Forms.TextBox
    Friend WithEvents TicketNumberLabel As System.Windows.Forms.Label
    Friend WithEvents ConectionLabel As System.Windows.Forms.Label
    Friend WithEvents ConectionBox As System.Windows.Forms.ComboBox
    Friend WithEvents CommentsLabel As System.Windows.Forms.Label
    Friend WithEvents TeamLabel As System.Windows.Forms.Label
    Friend WithEvents ActCategoryLabel As System.Windows.Forms.Label
    Friend WithEvents DateLabel As System.Windows.Forms.Label
    Friend WithEvents PendingSrcLabel As System.Windows.Forms.Label
    Friend WithEvents RegionLabel As System.Windows.Forms.Label
    Friend WithEvents StatusLabel As System.Windows.Forms.Label
    Friend WithEvents PriorityLabel As System.Windows.Forms.Label
    Friend WithEvents ResponsibleLabel As System.Windows.Forms.Label
    Friend WithEvents RequestorLabel As System.Windows.Forms.Label
    Friend WithEvents TeamBox As System.Windows.Forms.TextBox
    Friend WithEvents ActCategoryBox As System.Windows.Forms.TextBox
    Friend WithEvents ResponsibleBox As System.Windows.Forms.TextBox
    Friend WithEvents StatusBox As System.Windows.Forms.TextBox
    Friend WithEvents PriorityBox As System.Windows.Forms.TextBox
    Friend WithEvents RequestorBox As System.Windows.Forms.TextBox
    Friend WithEvents RegionBox As System.Windows.Forms.TextBox
    Friend WithEvents PendingSourceBox As System.Windows.Forms.TextBox
    Friend WithEvents DateBox As System.Windows.Forms.TextBox
    Friend WithEvents CommentsBox As System.Windows.Forms.TextBox
End Class
