<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.btnLast = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnPrevious = New System.Windows.Forms.Button()
        Me.btnFirst = New System.Windows.Forms.Button()
        Me.lblID = New System.Windows.Forms.Label()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.txtZip = New System.Windows.Forms.TextBox()
        Me.txtState = New System.Windows.Forms.TextBox()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.txtLName = New System.Windows.Forms.TextBox()
        Me.txtFName = New System.Windows.Forms.TextBox()
        Me.dgvVehicle = New System.Windows.Forms.DataGridView()
        Me.gboInformation.SuspendLayout()
        CType(Me.dgvVehicle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gboInformation
        '
        Me.gboInformation.Controls.Add(Me.btnLast)
        Me.gboInformation.Controls.Add(Me.btnNext)
        Me.gboInformation.Controls.Add(Me.btnDelete)
        Me.gboInformation.Controls.Add(Me.btnUpdate)
        Me.gboInformation.Controls.Add(Me.btnAdd)
        Me.gboInformation.Controls.Add(Me.btnPrevious)
        Me.gboInformation.Controls.Add(Me.btnFirst)
        Me.gboInformation.Controls.Add(Me.lblID)
        Me.gboInformation.Controls.Add(Me.lblAddress)
        Me.gboInformation.Controls.Add(Me.lblName)
        Me.gboInformation.Controls.Add(Me.txtID)
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
        Me.gboInformation.Size = New System.Drawing.Size(718, 226)
        Me.gboInformation.TabIndex = 0
        Me.gboInformation.TabStop = False
        Me.gboInformation.Text = "Owner Information:"
        '
        'btnLast
        '
        Me.btnLast.Location = New System.Drawing.Point(656, 137)
        Me.btnLast.Margin = New System.Windows.Forms.Padding(2)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(32, 34)
        Me.btnLast.TabIndex = 16
        Me.btnLast.Text = "|>"
        Me.btnLast.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(616, 137)
        Me.btnNext.Margin = New System.Windows.Forms.Padding(2)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(32, 34)
        Me.btnNext.TabIndex = 15
        Me.btnNext.Text = ">>"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(322, 137)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(78, 34)
        Me.btnDelete.TabIndex = 13
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(463, 137)
        Me.btnUpdate.Margin = New System.Windows.Forms.Padding(2)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(78, 34)
        Me.btnUpdate.TabIndex = 14
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(183, 137)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(78, 34)
        Me.btnAdd.TabIndex = 12
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnPrevious
        '
        Me.btnPrevious.Location = New System.Drawing.Point(77, 137)
        Me.btnPrevious.Margin = New System.Windows.Forms.Padding(2)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(32, 34)
        Me.btnPrevious.TabIndex = 11
        Me.btnPrevious.Text = "<<"
        Me.btnPrevious.UseVisualStyleBackColor = True
        '
        'btnFirst
        '
        Me.btnFirst.Location = New System.Drawing.Point(37, 137)
        Me.btnFirst.Margin = New System.Windows.Forms.Padding(2)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(32, 34)
        Me.btnFirst.TabIndex = 10
        Me.btnFirst.Text = "<|"
        Me.btnFirst.UseVisualStyleBackColor = True
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(561, 37)
        Me.lblID.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(68, 15)
        Me.lblID.TabIndex = 9
        Me.lblID.Text = "ID Number:"
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
        'txtID
        '
        Me.txtID.Enabled = False
        Me.txtID.Location = New System.Drawing.Point(638, 35)
        Me.txtID.Margin = New System.Windows.Forms.Padding(2)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(77, 23)
        Me.txtID.TabIndex = 6
        '
        'txtZip
        '
        Me.txtZip.Enabled = False
        Me.txtZip.Location = New System.Drawing.Point(364, 85)
        Me.txtZip.Margin = New System.Windows.Forms.Padding(2)
        Me.txtZip.Name = "txtZip"
        Me.txtZip.Size = New System.Drawing.Size(151, 23)
        Me.txtZip.TabIndex = 5
        '
        'txtState
        '
        Me.txtState.Enabled = False
        Me.txtState.Location = New System.Drawing.Point(293, 85)
        Me.txtState.Margin = New System.Windows.Forms.Padding(2)
        Me.txtState.Name = "txtState"
        Me.txtState.Size = New System.Drawing.Size(68, 23)
        Me.txtState.TabIndex = 4
        '
        'txtCity
        '
        Me.txtCity.Enabled = False
        Me.txtCity.Location = New System.Drawing.Point(120, 85)
        Me.txtCity.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(170, 23)
        Me.txtCity.TabIndex = 3
        '
        'txtAddress
        '
        Me.txtAddress.Enabled = False
        Me.txtAddress.Location = New System.Drawing.Point(120, 60)
        Me.txtAddress.Margin = New System.Windows.Forms.Padding(2)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(395, 23)
        Me.txtAddress.TabIndex = 2
        '
        'txtLName
        '
        Me.txtLName.Enabled = False
        Me.txtLName.Location = New System.Drawing.Point(293, 35)
        Me.txtLName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLName.Name = "txtLName"
        Me.txtLName.Size = New System.Drawing.Size(222, 23)
        Me.txtLName.TabIndex = 1
        '
        'txtFName
        '
        Me.txtFName.Enabled = False
        Me.txtFName.Location = New System.Drawing.Point(120, 35)
        Me.txtFName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFName.Name = "txtFName"
        Me.txtFName.Size = New System.Drawing.Size(170, 23)
        Me.txtFName.TabIndex = 0
        '
        'dgvVehicle
        '
        Me.dgvVehicle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVehicle.Location = New System.Drawing.Point(8, 241)
        Me.dgvVehicle.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvVehicle.Name = "dgvVehicle"
        Me.dgvVehicle.RowHeadersWidth = 62
        Me.dgvVehicle.RowTemplate.Height = 33
        Me.dgvVehicle.Size = New System.Drawing.Size(718, 137)
        Me.dgvVehicle.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(736, 426)
        Me.Controls.Add(Me.dgvVehicle)
        Me.Controls.Add(Me.gboInformation)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.gboInformation.ResumeLayout(False)
        Me.gboInformation.PerformLayout()
        CType(Me.dgvVehicle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gboInformation As GroupBox
    Friend WithEvents btnLast As Button
    Friend WithEvents btnNext As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnPrevious As Button
    Friend WithEvents btnFirst As Button
    Friend WithEvents lblID As Label
    Friend WithEvents lblAddress As Label
    Friend WithEvents lblName As Label
    Friend WithEvents txtID As TextBox
    Friend WithEvents txtZip As TextBox
    Friend WithEvents txtState As TextBox
    Friend WithEvents txtCity As TextBox
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents txtLName As TextBox
    Friend WithEvents txtFName As TextBox
    Friend WithEvents dgvVehicle As DataGridView
End Class
