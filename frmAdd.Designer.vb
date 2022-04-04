<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAdd
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
        Me.gboInformation = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtZip = New System.Windows.Forms.TextBox()
        Me.txtState = New System.Windows.Forms.TextBox()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.txtLName = New System.Windows.Forms.TextBox()
        Me.txtFName = New System.Windows.Forms.TextBox()
        Me.gboInformation.SuspendLayout()
        Me.SuspendLayout()
        '
        'gboInformation
        '
        Me.gboInformation.Controls.Add(Me.btnCancel)
        Me.gboInformation.Controls.Add(Me.btnSave)
        Me.gboInformation.Controls.Add(Me.lblAddress)
        Me.gboInformation.Controls.Add(Me.lblName)
        Me.gboInformation.Controls.Add(Me.txtZip)
        Me.gboInformation.Controls.Add(Me.txtState)
        Me.gboInformation.Controls.Add(Me.txtCity)
        Me.gboInformation.Controls.Add(Me.txtAddress)
        Me.gboInformation.Controls.Add(Me.txtLName)
        Me.gboInformation.Controls.Add(Me.txtFName)
        Me.gboInformation.Location = New System.Drawing.Point(8, 7)
        Me.gboInformation.Margin = New System.Windows.Forms.Padding(2)
        Me.gboInformation.Name = "gboInformation"
        Me.gboInformation.Padding = New System.Windows.Forms.Padding(2)
        Me.gboInformation.Size = New System.Drawing.Size(550, 220)
        Me.gboInformation.TabIndex = 0
        Me.gboInformation.TabStop = False
        Me.gboInformation.Text = "New Owner Information"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(306, 142)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(78, 34)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(176, 142)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(78, 34)
        Me.btnSave.TabIndex = 13
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lblAddress
        '
        Me.lblAddress.AutoSize = True
        Me.lblAddress.Location = New System.Drawing.Point(37, 60)
        Me.lblAddress.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(52, 15)
        Me.lblAddress.TabIndex = 8
        Me.lblAddress.Text = "Address:"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(37, 35)
        Me.lblName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(42, 15)
        Me.lblName.TabIndex = 7
        Me.lblName.Text = "Name:"
        '
        'txtZip
        '
        Me.txtZip.Location = New System.Drawing.Point(364, 85)
        Me.txtZip.Margin = New System.Windows.Forms.Padding(2)
        Me.txtZip.Name = "txtZip"
        Me.txtZip.Size = New System.Drawing.Size(151, 23)
        Me.txtZip.TabIndex = 5
        '
        'txtState
        '
        Me.txtState.Location = New System.Drawing.Point(293, 85)
        Me.txtState.Margin = New System.Windows.Forms.Padding(2)
        Me.txtState.Name = "txtState"
        Me.txtState.Size = New System.Drawing.Size(68, 23)
        Me.txtState.TabIndex = 4
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(120, 85)
        Me.txtCity.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(170, 23)
        Me.txtCity.TabIndex = 3
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(120, 60)
        Me.txtAddress.Margin = New System.Windows.Forms.Padding(2)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(395, 23)
        Me.txtAddress.TabIndex = 2
        '
        'txtLName
        '
        Me.txtLName.Location = New System.Drawing.Point(293, 35)
        Me.txtLName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLName.Name = "txtLName"
        Me.txtLName.Size = New System.Drawing.Size(222, 23)
        Me.txtLName.TabIndex = 1
        '
        'txtFName
        '
        Me.txtFName.Location = New System.Drawing.Point(120, 35)
        Me.txtFName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFName.Name = "txtFName"
        Me.txtFName.Size = New System.Drawing.Size(170, 23)
        Me.txtFName.TabIndex = 0
        '
        'frmAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(568, 241)
        Me.Controls.Add(Me.gboInformation)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmAdd"
        Me.Text = "Form1"
        Me.gboInformation.ResumeLayout(False)
        Me.gboInformation.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gboInformation As GroupBox
    Friend WithEvents lblAddress As Label
    Friend WithEvents lblName As Label
    Friend WithEvents txtZip As TextBox
    Friend WithEvents txtState As TextBox
    Friend WithEvents txtCity As TextBox
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents txtLName As TextBox
    Friend WithEvents txtFName As TextBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
End Class
