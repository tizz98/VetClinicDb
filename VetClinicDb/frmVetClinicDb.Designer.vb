<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVetClinicDb
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.grpOwnerInfo = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnLast = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnPrevious = New System.Windows.Forms.Button()
        Me.btnFirst = New System.Windows.Forms.Button()
        Me.txtIdNumber = New System.Windows.Forms.TextBox()
        Me.lblIdNumber = New System.Windows.Forms.Label()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.txtAddressZipcode = New System.Windows.Forms.TextBox()
        Me.txtAddressState = New System.Windows.Forms.TextBox()
        Me.txtAddressCity = New System.Windows.Forms.TextBox()
        Me.txtAddressStreet = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.dgPets = New System.Windows.Forms.DataGridView()
        Me.btnUpdatePetInfo = New System.Windows.Forms.Button()
        Me.grpOwnerInfo.SuspendLayout()
        CType(Me.dgPets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpOwnerInfo
        '
        Me.grpOwnerInfo.Controls.Add(Me.btnCancel)
        Me.grpOwnerInfo.Controls.Add(Me.btnSave)
        Me.grpOwnerInfo.Controls.Add(Me.btnUpdate)
        Me.grpOwnerInfo.Controls.Add(Me.btnDelete)
        Me.grpOwnerInfo.Controls.Add(Me.btnAdd)
        Me.grpOwnerInfo.Controls.Add(Me.btnLast)
        Me.grpOwnerInfo.Controls.Add(Me.btnNext)
        Me.grpOwnerInfo.Controls.Add(Me.btnPrevious)
        Me.grpOwnerInfo.Controls.Add(Me.btnFirst)
        Me.grpOwnerInfo.Controls.Add(Me.txtIdNumber)
        Me.grpOwnerInfo.Controls.Add(Me.lblIdNumber)
        Me.grpOwnerInfo.Controls.Add(Me.txtPhone)
        Me.grpOwnerInfo.Controls.Add(Me.lblPhone)
        Me.grpOwnerInfo.Controls.Add(Me.txtAddressZipcode)
        Me.grpOwnerInfo.Controls.Add(Me.txtAddressState)
        Me.grpOwnerInfo.Controls.Add(Me.txtAddressCity)
        Me.grpOwnerInfo.Controls.Add(Me.txtAddressStreet)
        Me.grpOwnerInfo.Controls.Add(Me.txtName)
        Me.grpOwnerInfo.Controls.Add(Me.lblAddress)
        Me.grpOwnerInfo.Controls.Add(Me.lblName)
        Me.grpOwnerInfo.Location = New System.Drawing.Point(13, 13)
        Me.grpOwnerInfo.Name = "grpOwnerInfo"
        Me.grpOwnerInfo.Size = New System.Drawing.Size(728, 292)
        Me.grpOwnerInfo.TabIndex = 0
        Me.grpOwnerInfo.TabStop = False
        Me.grpOwnerInfo.Text = "Owner Info"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(413, 246)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(98, 30)
        Me.btnCancel.TabIndex = 19
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        Me.btnCancel.Visible = False
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(190, 246)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(98, 30)
        Me.btnSave.TabIndex = 18
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        Me.btnSave.Visible = False
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(426, 185)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(63, 43)
        Me.btnUpdate.TabIndex = 17
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(343, 185)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(63, 43)
        Me.btnDelete.TabIndex = 16
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(263, 185)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(63, 43)
        Me.btnAdd.TabIndex = 15
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnLast
        '
        Me.btnLast.Location = New System.Drawing.Point(646, 185)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(35, 43)
        Me.btnLast.TabIndex = 14
        Me.btnLast.Text = "|>"
        Me.btnLast.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(605, 185)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(35, 43)
        Me.btnNext.TabIndex = 13
        Me.btnNext.Text = ">>"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnPrevious
        '
        Me.btnPrevious.Location = New System.Drawing.Point(116, 185)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(35, 43)
        Me.btnPrevious.TabIndex = 12
        Me.btnPrevious.Text = "<<"
        Me.btnPrevious.UseVisualStyleBackColor = True
        '
        'btnFirst
        '
        Me.btnFirst.Location = New System.Drawing.Point(75, 185)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(35, 43)
        Me.btnFirst.TabIndex = 11
        Me.btnFirst.Text = "<|"
        Me.btnFirst.UseVisualStyleBackColor = True
        '
        'txtIdNumber
        '
        Me.txtIdNumber.Enabled = False
        Me.txtIdNumber.Location = New System.Drawing.Point(635, 32)
        Me.txtIdNumber.Name = "txtIdNumber"
        Me.txtIdNumber.Size = New System.Drawing.Size(77, 20)
        Me.txtIdNumber.TabIndex = 10
        '
        'lblIdNumber
        '
        Me.lblIdNumber.AutoSize = True
        Me.lblIdNumber.Location = New System.Drawing.Point(568, 35)
        Me.lblIdNumber.Name = "lblIdNumber"
        Me.lblIdNumber.Size = New System.Drawing.Size(61, 13)
        Me.lblIdNumber.TabIndex = 9
        Me.lblIdNumber.Text = "ID Number:"
        '
        'txtPhone
        '
        Me.txtPhone.Enabled = False
        Me.txtPhone.Location = New System.Drawing.Point(93, 129)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(418, 20)
        Me.txtPhone.TabIndex = 8
        '
        'lblPhone
        '
        Me.lblPhone.AutoSize = True
        Me.lblPhone.Location = New System.Drawing.Point(27, 132)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(41, 13)
        Me.lblPhone.TabIndex = 7
        Me.lblPhone.Text = "Phone:"
        '
        'txtAddressZipcode
        '
        Me.txtAddressZipcode.Enabled = False
        Me.txtAddressZipcode.Location = New System.Drawing.Point(412, 91)
        Me.txtAddressZipcode.Name = "txtAddressZipcode"
        Me.txtAddressZipcode.Size = New System.Drawing.Size(99, 20)
        Me.txtAddressZipcode.TabIndex = 6
        '
        'txtAddressState
        '
        Me.txtAddressState.Enabled = False
        Me.txtAddressState.Location = New System.Drawing.Point(367, 91)
        Me.txtAddressState.Name = "txtAddressState"
        Me.txtAddressState.Size = New System.Drawing.Size(39, 20)
        Me.txtAddressState.TabIndex = 5
        '
        'txtAddressCity
        '
        Me.txtAddressCity.Enabled = False
        Me.txtAddressCity.Location = New System.Drawing.Point(93, 91)
        Me.txtAddressCity.Name = "txtAddressCity"
        Me.txtAddressCity.Size = New System.Drawing.Size(268, 20)
        Me.txtAddressCity.TabIndex = 4
        '
        'txtAddressStreet
        '
        Me.txtAddressStreet.Enabled = False
        Me.txtAddressStreet.Location = New System.Drawing.Point(93, 65)
        Me.txtAddressStreet.Name = "txtAddressStreet"
        Me.txtAddressStreet.Size = New System.Drawing.Size(418, 20)
        Me.txtAddressStreet.TabIndex = 3
        '
        'txtName
        '
        Me.txtName.Enabled = False
        Me.txtName.Location = New System.Drawing.Point(93, 32)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(418, 20)
        Me.txtName.TabIndex = 2
        '
        'lblAddress
        '
        Me.lblAddress.AutoSize = True
        Me.lblAddress.Location = New System.Drawing.Point(27, 68)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(48, 13)
        Me.lblAddress.TabIndex = 1
        Me.lblAddress.Text = "Address:"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(27, 35)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(38, 13)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Name:"
        '
        'dgPets
        '
        Me.dgPets.AllowUserToDeleteRows = False
        Me.dgPets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgPets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgPets.Location = New System.Drawing.Point(13, 311)
        Me.dgPets.Name = "dgPets"
        Me.dgPets.Size = New System.Drawing.Size(728, 225)
        Me.dgPets.TabIndex = 1
        '
        'btnUpdatePetInfo
        '
        Me.btnUpdatePetInfo.Location = New System.Drawing.Point(13, 542)
        Me.btnUpdatePetInfo.Name = "btnUpdatePetInfo"
        Me.btnUpdatePetInfo.Size = New System.Drawing.Size(728, 37)
        Me.btnUpdatePetInfo.TabIndex = 2
        Me.btnUpdatePetInfo.Text = "Update Pet Information"
        Me.btnUpdatePetInfo.UseVisualStyleBackColor = True
        Me.btnUpdatePetInfo.Visible = False
        '
        'frmVetClinicDb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(756, 591)
        Me.Controls.Add(Me.btnUpdatePetInfo)
        Me.Controls.Add(Me.dgPets)
        Me.Controls.Add(Me.grpOwnerInfo)
        Me.Name = "frmVetClinicDb"
        Me.Text = "Mr. Pebble's Veterinary Clinic"
        Me.grpOwnerInfo.ResumeLayout(False)
        Me.grpOwnerInfo.PerformLayout()
        CType(Me.dgPets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grpOwnerInfo As GroupBox
    Friend WithEvents txtIdNumber As TextBox
    Friend WithEvents lblIdNumber As Label
    Friend WithEvents txtPhone As TextBox
    Friend WithEvents lblPhone As Label
    Friend WithEvents txtAddressZipcode As TextBox
    Friend WithEvents txtAddressState As TextBox
    Friend WithEvents txtAddressCity As TextBox
    Friend WithEvents txtAddressStreet As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents lblAddress As Label
    Friend WithEvents lblName As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnLast As Button
    Friend WithEvents btnNext As Button
    Friend WithEvents btnPrevious As Button
    Friend WithEvents btnFirst As Button
    Friend WithEvents dgPets As DataGridView
    Friend WithEvents btnUpdatePetInfo As Button
End Class
