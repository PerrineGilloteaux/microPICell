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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.CurrentPos = New System.Windows.Forms.Button()
        Me.BImage = New System.Windows.Forms.Button()
        Me.Scale = New System.Windows.Forms.Button()
        Me.Scaleg = New System.Windows.Forms.Label()
        Me.LX = New System.Windows.Forms.Label()
        Me.LY = New System.Windows.Forms.Label()
        Me.LZ = New System.Windows.Forms.Label()
        Me.Init = New System.Windows.Forms.Button()
        Me.Initialize = New System.Windows.Forms.Label()
        Me.Predict = New System.Windows.Forms.Button()
        Me.ProcessShape = New System.Windows.Forms.Button()
        Me.SetID = New System.Windows.Forms.Button()
        Me.ROIList = New System.Windows.Forms.ListBox()
        Me.DisplayShape = New System.Windows.Forms.Button()
        Me.SaveImage = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Move = New System.Windows.Forms.Button()
        Me.X = New System.Windows.Forms.TextBox()
        Me.Y = New System.Windows.Forms.TextBox()
        Me.Z = New System.Windows.Forms.TextBox()
        Me.GetID = New System.Windows.Forms.TextBox()
        Me.GetD = New System.Windows.Forms.Button()
        Me.Xcoord = New System.Windows.Forms.Label()
        Me.Ycoord = New System.Windows.Forms.Label()
        Me.Zcoord = New System.Windows.Forms.Label()
        Me.Calibrate = New System.Windows.Forms.Button()
        Me.Calibrated = New System.Windows.Forms.Label()
        Me.id = New System.Windows.Forms.Label()
        Me.Index = New System.Windows.Forms.Label()
        Me.indexbox = New System.Windows.Forms.TextBox()
        Me.Group = New System.Windows.Forms.Label()
        Me.groupbox = New System.Windows.Forms.TextBox()
        Me.nIndex = New System.Windows.Forms.Label()
        Me.setindex = New System.Windows.Forms.Button()
        Me.setgroup = New System.Windows.Forms.Button()
        Me.nGroup = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.imageMagnification = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(213, 70)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(178, 152)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'CurrentPos
        '
        Me.CurrentPos.Location = New System.Drawing.Point(12, 379)
        Me.CurrentPos.Name = "CurrentPos"
        Me.CurrentPos.Size = New System.Drawing.Size(86, 23)
        Me.CurrentPos.TabIndex = 1
        Me.CurrentPos.Text = "Current Position"
        Me.CurrentPos.UseVisualStyleBackColor = True
        '
        'BImage
        '
        Me.BImage.Location = New System.Drawing.Point(213, 12)
        Me.BImage.Name = "BImage"
        Me.BImage.Size = New System.Drawing.Size(86, 23)
        Me.BImage.TabIndex = 2
        Me.BImage.Text = "Acquire Image"
        Me.BImage.UseVisualStyleBackColor = True
        '
        'Scale
        '
        Me.Scale.Location = New System.Drawing.Point(12, 35)
        Me.Scale.Name = "Scale"
        Me.Scale.Size = New System.Drawing.Size(86, 23)
        Me.Scale.TabIndex = 3
        Me.Scale.Text = "GetScale"
        Me.Scale.UseVisualStyleBackColor = True
        '
        'Scaleg
        '
        Me.Scaleg.AutoSize = True
        Me.Scaleg.Location = New System.Drawing.Point(104, 40)
        Me.Scaleg.Name = "Scaleg"
        Me.Scaleg.Size = New System.Drawing.Size(33, 13)
        Me.Scaleg.TabIndex = 4
        Me.Scaleg.Text = "Label"
        '
        'LX
        '
        Me.LX.AutoSize = True
        Me.LX.Location = New System.Drawing.Point(110, 384)
        Me.LX.Name = "LX"
        Me.LX.Size = New System.Drawing.Size(20, 13)
        Me.LX.TabIndex = 5
        Me.LX.Text = "LX"
        '
        'LY
        '
        Me.LY.AutoSize = True
        Me.LY.Location = New System.Drawing.Point(110, 406)
        Me.LY.Name = "LY"
        Me.LY.Size = New System.Drawing.Size(20, 13)
        Me.LY.TabIndex = 6
        Me.LY.Text = "LY"
        '
        'LZ
        '
        Me.LZ.AutoSize = True
        Me.LZ.Location = New System.Drawing.Point(110, 428)
        Me.LZ.Name = "LZ"
        Me.LZ.Size = New System.Drawing.Size(20, 13)
        Me.LZ.TabIndex = 7
        Me.LZ.Text = "LZ"
        '
        'Init
        '
        Me.Init.Location = New System.Drawing.Point(12, 6)
        Me.Init.Name = "Init"
        Me.Init.Size = New System.Drawing.Size(86, 23)
        Me.Init.TabIndex = 8
        Me.Init.Text = "Init"
        Me.Init.UseVisualStyleBackColor = True
        '
        'Initialize
        '
        Me.Initialize.AutoSize = True
        Me.Initialize.Location = New System.Drawing.Point(104, 11)
        Me.Initialize.Name = "Initialize"
        Me.Initialize.Size = New System.Drawing.Size(33, 13)
        Me.Initialize.TabIndex = 9
        Me.Initialize.Text = "Label"
        '
        'Predict
        '
        Me.Predict.Location = New System.Drawing.Point(305, 30)
        Me.Predict.Name = "Predict"
        Me.Predict.Size = New System.Drawing.Size(86, 23)
        Me.Predict.TabIndex = 17
        Me.Predict.Text = "Predict"
        Me.Predict.UseVisualStyleBackColor = True
        '
        'ProcessShape
        '
        Me.ProcessShape.Location = New System.Drawing.Point(305, 269)
        Me.ProcessShape.Name = "ProcessShape"
        Me.ProcessShape.Size = New System.Drawing.Size(86, 23)
        Me.ProcessShape.TabIndex = 19
        Me.ProcessShape.Text = "Cut Shapes"
        Me.ProcessShape.UseVisualStyleBackColor = True
        '
        'SetID
        '
        Me.SetID.Location = New System.Drawing.Point(12, 114)
        Me.SetID.Name = "SetID"
        Me.SetID.Size = New System.Drawing.Size(86, 23)
        Me.SetID.TabIndex = 20
        Me.SetID.Text = "Set Slide ID"
        Me.SetID.UseVisualStyleBackColor = True
        '
        'ROIList
        '
        Me.ROIList.FormattingEnabled = True
        Me.ROIList.HorizontalScrollbar = True
        Me.ROIList.Location = New System.Drawing.Point(48, 240)
        Me.ROIList.Name = "ROIList"
        Me.ROIList.Size = New System.Drawing.Size(251, 82)
        Me.ROIList.TabIndex = 22
        '
        'DisplayShape
        '
        Me.DisplayShape.Location = New System.Drawing.Point(305, 240)
        Me.DisplayShape.Name = "DisplayShape"
        Me.DisplayShape.Size = New System.Drawing.Size(86, 23)
        Me.DisplayShape.TabIndex = 25
        Me.DisplayShape.Text = "Display Shape"
        Me.DisplayShape.UseVisualStyleBackColor = True
        '
        'SaveImage
        '
        Me.SaveImage.Location = New System.Drawing.Point(213, 41)
        Me.SaveImage.Name = "SaveImage"
        Me.SaveImage.Size = New System.Drawing.Size(86, 23)
        Me.SaveImage.TabIndex = 26
        Me.SaveImage.Text = "Save Image"
        Me.SaveImage.UseVisualStyleBackColor = True
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "tiff"
        Me.SaveFileDialog1.FileName = "acquired_image.tiff"
        '
        'Move
        '
        Me.Move.Location = New System.Drawing.Point(12, 350)
        Me.Move.Name = "Move"
        Me.Move.Size = New System.Drawing.Size(86, 23)
        Me.Move.TabIndex = 28
        Me.Move.Text = "Move"
        Me.Move.UseVisualStyleBackColor = True
        '
        'X
        '
        Me.X.Location = New System.Drawing.Point(107, 353)
        Me.X.Name = "X"
        Me.X.Size = New System.Drawing.Size(26, 20)
        Me.X.TabIndex = 29
        '
        'Y
        '
        Me.Y.Location = New System.Drawing.Point(139, 353)
        Me.Y.Name = "Y"
        Me.Y.Size = New System.Drawing.Size(26, 20)
        Me.Y.TabIndex = 30
        '
        'Z
        '
        Me.Z.Location = New System.Drawing.Point(171, 353)
        Me.Z.Name = "Z"
        Me.Z.Size = New System.Drawing.Size(26, 20)
        Me.Z.TabIndex = 31
        '
        'GetID
        '
        Me.GetID.Location = New System.Drawing.Point(107, 117)
        Me.GetID.Name = "GetID"
        Me.GetID.Size = New System.Drawing.Size(43, 20)
        Me.GetID.TabIndex = 32
        '
        'GetD
        '
        Me.GetD.Location = New System.Drawing.Point(12, 143)
        Me.GetD.Name = "GetD"
        Me.GetD.Size = New System.Drawing.Size(86, 23)
        Me.GetD.TabIndex = 33
        Me.GetD.Text = "Get Slide ID"
        Me.GetD.UseVisualStyleBackColor = True
        '
        'Xcoord
        '
        Me.Xcoord.AutoSize = True
        Me.Xcoord.Location = New System.Drawing.Point(104, 337)
        Me.Xcoord.Name = "Xcoord"
        Me.Xcoord.Size = New System.Drawing.Size(14, 13)
        Me.Xcoord.TabIndex = 35
        Me.Xcoord.Text = "X"
        '
        'Ycoord
        '
        Me.Ycoord.AutoSize = True
        Me.Ycoord.Location = New System.Drawing.Point(136, 337)
        Me.Ycoord.Name = "Ycoord"
        Me.Ycoord.Size = New System.Drawing.Size(14, 13)
        Me.Ycoord.TabIndex = 36
        Me.Ycoord.Text = "Y"
        '
        'Zcoord
        '
        Me.Zcoord.AutoSize = True
        Me.Zcoord.Location = New System.Drawing.Point(168, 337)
        Me.Zcoord.Name = "Zcoord"
        Me.Zcoord.Size = New System.Drawing.Size(14, 13)
        Me.Zcoord.TabIndex = 37
        Me.Zcoord.Text = "Z"
        '
        'Calibrate
        '
        Me.Calibrate.Location = New System.Drawing.Point(12, 184)
        Me.Calibrate.Name = "Calibrate"
        Me.Calibrate.Size = New System.Drawing.Size(86, 23)
        Me.Calibrate.TabIndex = 38
        Me.Calibrate.Text = "Calibrate"
        Me.Calibrate.UseVisualStyleBackColor = True
        '
        'Calibrated
        '
        Me.Calibrated.AutoSize = True
        Me.Calibrated.Location = New System.Drawing.Point(104, 189)
        Me.Calibrated.Name = "Calibrated"
        Me.Calibrated.Size = New System.Drawing.Size(56, 13)
        Me.Calibrated.TabIndex = 39
        Me.Calibrated.Text = "Calibration"
        '
        'id
        '
        Me.id.AutoSize = True
        Me.id.Location = New System.Drawing.Point(109, 148)
        Me.id.Name = "id"
        Me.id.Size = New System.Drawing.Size(41, 13)
        Me.id.TabIndex = 41
        Me.id.Text = "SlideID"
        '
        'Index
        '
        Me.Index.AutoSize = True
        Me.Index.Location = New System.Drawing.Point(259, 355)
        Me.Index.Name = "Index"
        Me.Index.Size = New System.Drawing.Size(33, 13)
        Me.Index.TabIndex = 43
        Me.Index.Text = "Index"
        '
        'indexbox
        '
        Me.indexbox.Location = New System.Drawing.Point(298, 352)
        Me.indexbox.Name = "indexbox"
        Me.indexbox.Size = New System.Drawing.Size(26, 20)
        Me.indexbox.TabIndex = 42
        '
        'Group
        '
        Me.Group.AutoSize = True
        Me.Group.Location = New System.Drawing.Point(256, 384)
        Me.Group.Name = "Group"
        Me.Group.Size = New System.Drawing.Size(36, 13)
        Me.Group.TabIndex = 45
        Me.Group.Text = "Group"
        '
        'groupbox
        '
        Me.groupbox.Location = New System.Drawing.Point(298, 381)
        Me.groupbox.Name = "groupbox"
        Me.groupbox.Size = New System.Drawing.Size(26, 20)
        Me.groupbox.TabIndex = 46
        '
        'nIndex
        '
        Me.nIndex.AutoSize = True
        Me.nIndex.Location = New System.Drawing.Point(373, 355)
        Me.nIndex.Name = "nIndex"
        Me.nIndex.Size = New System.Drawing.Size(33, 13)
        Me.nIndex.TabIndex = 48
        Me.nIndex.Text = "Index"
        '
        'setindex
        '
        Me.setindex.Location = New System.Drawing.Point(330, 350)
        Me.setindex.Name = "setindex"
        Me.setindex.Size = New System.Drawing.Size(37, 23)
        Me.setindex.TabIndex = 47
        Me.setindex.Text = "Set"
        Me.setindex.UseVisualStyleBackColor = True
        '
        'setgroup
        '
        Me.setgroup.Location = New System.Drawing.Point(330, 379)
        Me.setgroup.Name = "setgroup"
        Me.setgroup.Size = New System.Drawing.Size(37, 23)
        Me.setgroup.TabIndex = 49
        Me.setgroup.Text = "Set"
        Me.setgroup.UseVisualStyleBackColor = True
        '
        'nGroup
        '
        Me.nGroup.AutoSize = True
        Me.nGroup.Location = New System.Drawing.Point(373, 384)
        Me.nGroup.Name = "nGroup"
        Me.nGroup.Size = New System.Drawing.Size(36, 13)
        Me.nGroup.TabIndex = 50
        Me.nGroup.Text = "Group"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 64)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(86, 23)
        Me.Button1.TabIndex = 51
        Me.Button1.Text = "Magnification"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'imageMagnification
        '
        Me.imageMagnification.AutoSize = True
        Me.imageMagnification.Location = New System.Drawing.Point(104, 70)
        Me.imageMagnification.Name = "imageMagnification"
        Me.imageMagnification.Size = New System.Drawing.Size(33, 13)
        Me.imageMagnification.TabIndex = 52
        Me.imageMagnification.Text = "Label"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(419, 461)
        Me.Controls.Add(Me.imageMagnification)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.nGroup)
        Me.Controls.Add(Me.setgroup)
        Me.Controls.Add(Me.nIndex)
        Me.Controls.Add(Me.setindex)
        Me.Controls.Add(Me.groupbox)
        Me.Controls.Add(Me.Group)
        Me.Controls.Add(Me.Index)
        Me.Controls.Add(Me.indexbox)
        Me.Controls.Add(Me.id)
        Me.Controls.Add(Me.Calibrated)
        Me.Controls.Add(Me.Calibrate)
        Me.Controls.Add(Me.Zcoord)
        Me.Controls.Add(Me.Ycoord)
        Me.Controls.Add(Me.Xcoord)
        Me.Controls.Add(Me.GetD)
        Me.Controls.Add(Me.GetID)
        Me.Controls.Add(Me.Z)
        Me.Controls.Add(Me.Y)
        Me.Controls.Add(Me.X)
        Me.Controls.Add(Me.Move)
        Me.Controls.Add(Me.SaveImage)
        Me.Controls.Add(Me.DisplayShape)
        Me.Controls.Add(Me.ROIList)
        Me.Controls.Add(Me.SetID)
        Me.Controls.Add(Me.ProcessShape)
        Me.Controls.Add(Me.Predict)
        Me.Controls.Add(Me.Initialize)
        Me.Controls.Add(Me.Init)
        Me.Controls.Add(Me.LZ)
        Me.Controls.Add(Me.LY)
        Me.Controls.Add(Me.LX)
        Me.Controls.Add(Me.Scaleg)
        Me.Controls.Add(Me.Scale)
        Me.Controls.Add(Me.BImage)
        Me.Controls.Add(Me.CurrentPos)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Form1"
        Me.Text = "Microdissecteur "
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents CurrentPos As Button
    Friend WithEvents BImage As Button
    Friend WithEvents Scale As Button
    Friend WithEvents Scaleg As Label
    Friend WithEvents LX As Label
    Friend WithEvents LY As Label
    Friend WithEvents LZ As Label
    Friend WithEvents Init As Button
    Friend WithEvents Initialize As Label
    Friend WithEvents Predict As Button
    Friend WithEvents ProcessShape As Button
    Friend WithEvents SetID As Button
    Friend WithEvents ROIList As ListBox
    Friend WithEvents DisplayShape As Button
    Friend WithEvents SaveImage As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents Move As Button
    Friend WithEvents X As TextBox
    Friend WithEvents Y As TextBox
    Friend WithEvents Z As TextBox
    Friend WithEvents GetID As TextBox
    Friend WithEvents GetD As Button
    Friend WithEvents Xcoord As Label
    Friend WithEvents Ycoord As Label
    Friend WithEvents Zcoord As Label
    Friend WithEvents Calibrate As Button
    Friend WithEvents Calibrated As Label
    Friend WithEvents id As Label
    Friend WithEvents Index As Label
    Friend WithEvents indexbox As TextBox
    Friend WithEvents Group As Label
    Friend WithEvents groupbox As TextBox
    Friend WithEvents nIndex As Label
    Friend WithEvents setindex As Button
    Friend WithEvents setgroup As Button
    Friend WithEvents nGroup As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents imageMagnification As Label
End Class
