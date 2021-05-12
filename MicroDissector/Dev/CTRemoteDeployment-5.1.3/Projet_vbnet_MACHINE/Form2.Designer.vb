<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.MicAcquisition = New System.Windows.Forms.Label()
        Me.Support = New System.Windows.Forms.Label()
        Me.SupportBox = New System.Windows.Forms.ComboBox()
        Me.Staining = New System.Windows.Forms.Label()
        Me.StainingBox = New System.Windows.Forms.ComboBox()
        Me.Start = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.MicroscopeBox = New System.Windows.Forms.ComboBox()
        Me.S1Position = New System.Windows.Forms.Label()
        Me.PositionBox1 = New System.Windows.Forms.ComboBox()
        Me.PositionBox2 = New System.Windows.Forms.ComboBox()
        Me.S2Position = New System.Windows.Forms.Label()
        Me.PositionBox3 = New System.Windows.Forms.ComboBox()
        Me.S3Position = New System.Windows.Forms.Label()
        Me.ListChannelsBox = New System.Windows.Forms.CheckedListBox()
        Me.ChanNames = New System.Windows.Forms.Label()
        Me.AddChannel = New System.Windows.Forms.Button()
        Me.DeleteChannel = New System.Windows.Forms.Button()
        Me.ChannelName = New System.Windows.Forms.TextBox()
        Me.Analysis = New System.Windows.Forms.Label()
        Me.AnalysisPossibilities = New System.Windows.Forms.ComboBox()
        Me.ImageAnalysisPath = New System.Windows.Forms.TextBox()
        Me.ImageAnalysisBrowse = New System.Windows.Forms.Button()
        Me.ImageAnalysis = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ImageMicrodissecteur = New System.Windows.Forms.Label()
        Me.ImageMicrodissecteurBrowse = New System.Windows.Forms.Button()
        Me.ImageMicrodissecteurPath = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.Macro = New System.Windows.Forms.Label()
        Me.MacroBox = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'MicAcquisition
        '
        Me.MicAcquisition.AutoSize = True
        Me.MicAcquisition.Location = New System.Drawing.Point(15, 134)
        Me.MicAcquisition.Name = "MicAcquisition"
        Me.MicAcquisition.Size = New System.Drawing.Size(115, 13)
        Me.MicAcquisition.TabIndex = 1
        Me.MicAcquisition.Text = "Acquisition microscope"
        '
        'Support
        '
        Me.Support.AutoSize = True
        Me.Support.Location = New System.Drawing.Point(86, 52)
        Me.Support.Name = "Support"
        Me.Support.Size = New System.Drawing.Size(44, 13)
        Me.Support.TabIndex = 2
        Me.Support.Text = "Support"
        '
        'SupportBox
        '
        Me.SupportBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SupportBox.FormattingEnabled = True
        Me.SupportBox.Items.AddRange(New Object() {"Slide", "Box"})
        Me.SupportBox.Location = New System.Drawing.Point(136, 49)
        Me.SupportBox.Name = "SupportBox"
        Me.SupportBox.Size = New System.Drawing.Size(77, 21)
        Me.SupportBox.TabIndex = 3
        '
        'Staining
        '
        Me.Staining.AutoSize = True
        Me.Staining.Location = New System.Drawing.Point(86, 170)
        Me.Staining.Name = "Staining"
        Me.Staining.Size = New System.Drawing.Size(45, 13)
        Me.Staining.TabIndex = 6
        Me.Staining.Text = "Staining"
        '
        'StainingBox
        '
        Me.StainingBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.StainingBox.FormattingEnabled = True
        Me.StainingBox.Items.AddRange(New Object() {"Fluorescence", "H&E", "H-DAB"})
        Me.StainingBox.Location = New System.Drawing.Point(137, 167)
        Me.StainingBox.Name = "StainingBox"
        Me.StainingBox.Size = New System.Drawing.Size(107, 21)
        Me.StainingBox.TabIndex = 7
        '
        'Start
        '
        Me.Start.Location = New System.Drawing.Point(317, 455)
        Me.Start.Name = "Start"
        Me.Start.Size = New System.Drawing.Size(75, 23)
        Me.Start.TabIndex = 8
        Me.Start.Text = "Start"
        Me.Start.UseVisualStyleBackColor = True
        '
        'Cancel
        '
        Me.Cancel.Location = New System.Drawing.Point(398, 455)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(75, 23)
        Me.Cancel.TabIndex = 9
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = True
        '
        'MicroscopeBox
        '
        Me.MicroscopeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MicroscopeBox.FormattingEnabled = True
        Me.MicroscopeBox.Items.AddRange(New Object() {"Microdissecteur", "Confocal", "Scanner", "Codex"})
        Me.MicroscopeBox.Location = New System.Drawing.Point(136, 131)
        Me.MicroscopeBox.Name = "MicroscopeBox"
        Me.MicroscopeBox.Size = New System.Drawing.Size(121, 21)
        Me.MicroscopeBox.TabIndex = 10
        '
        'S1Position
        '
        Me.S1Position.AutoSize = True
        Me.S1Position.Location = New System.Drawing.Point(283, 51)
        Me.S1Position.Name = "S1Position"
        Me.S1Position.Size = New System.Drawing.Size(60, 13)
        Me.S1Position.TabIndex = 13
        Me.S1Position.Text = "S1 Position"
        '
        'PositionBox1
        '
        Me.PositionBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PositionBox1.FormattingEnabled = True
        Me.PositionBox1.Items.AddRange(New Object() {"Up", "Mid", "Down"})
        Me.PositionBox1.Location = New System.Drawing.Point(349, 48)
        Me.PositionBox1.Name = "PositionBox1"
        Me.PositionBox1.Size = New System.Drawing.Size(57, 21)
        Me.PositionBox1.TabIndex = 14
        '
        'PositionBox2
        '
        Me.PositionBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PositionBox2.FormattingEnabled = True
        Me.PositionBox2.Items.AddRange(New Object() {"Up", "Mid", "Down"})
        Me.PositionBox2.Location = New System.Drawing.Point(349, 75)
        Me.PositionBox2.Name = "PositionBox2"
        Me.PositionBox2.Size = New System.Drawing.Size(57, 21)
        Me.PositionBox2.TabIndex = 16
        Me.PositionBox2.Visible = False
        '
        'S2Position
        '
        Me.S2Position.AutoSize = True
        Me.S2Position.Location = New System.Drawing.Point(283, 78)
        Me.S2Position.Name = "S2Position"
        Me.S2Position.Size = New System.Drawing.Size(60, 13)
        Me.S2Position.TabIndex = 15
        Me.S2Position.Text = "S2 Position"
        Me.S2Position.Visible = False
        '
        'PositionBox3
        '
        Me.PositionBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PositionBox3.FormattingEnabled = True
        Me.PositionBox3.Items.AddRange(New Object() {"Up", "Mid", "Down"})
        Me.PositionBox3.Location = New System.Drawing.Point(349, 102)
        Me.PositionBox3.Name = "PositionBox3"
        Me.PositionBox3.Size = New System.Drawing.Size(57, 21)
        Me.PositionBox3.TabIndex = 18
        Me.PositionBox3.Visible = False
        '
        'S3Position
        '
        Me.S3Position.AutoSize = True
        Me.S3Position.Location = New System.Drawing.Point(283, 105)
        Me.S3Position.Name = "S3Position"
        Me.S3Position.Size = New System.Drawing.Size(60, 13)
        Me.S3Position.TabIndex = 17
        Me.S3Position.Text = "S3 Position"
        Me.S3Position.Visible = False
        '
        'ListChannelsBox
        '
        Me.ListChannelsBox.CheckOnClick = True
        Me.ListChannelsBox.FormattingEnabled = True
        Me.ListChannelsBox.Location = New System.Drawing.Point(137, 214)
        Me.ListChannelsBox.Name = "ListChannelsBox"
        Me.ListChannelsBox.Size = New System.Drawing.Size(336, 124)
        Me.ListChannelsBox.TabIndex = 19
        Me.ListChannelsBox.Visible = False
        '
        'ChanNames
        '
        Me.ChanNames.AutoSize = True
        Me.ChanNames.Location = New System.Drawing.Point(45, 214)
        Me.ChanNames.Name = "ChanNames"
        Me.ChanNames.Size = New System.Drawing.Size(82, 13)
        Me.ChanNames.TabIndex = 20
        Me.ChanNames.Text = "Channel Names"
        Me.ChanNames.Visible = False
        '
        'AddChannel
        '
        Me.AddChannel.Location = New System.Drawing.Point(32, 286)
        Me.AddChannel.Name = "AddChannel"
        Me.AddChannel.Size = New System.Drawing.Size(95, 23)
        Me.AddChannel.TabIndex = 21
        Me.AddChannel.Text = "Add channel"
        Me.AddChannel.UseVisualStyleBackColor = True
        Me.AddChannel.Visible = False
        '
        'DeleteChannel
        '
        Me.DeleteChannel.Location = New System.Drawing.Point(32, 315)
        Me.DeleteChannel.Name = "DeleteChannel"
        Me.DeleteChannel.Size = New System.Drawing.Size(95, 23)
        Me.DeleteChannel.TabIndex = 22
        Me.DeleteChannel.Text = "Delete channel"
        Me.DeleteChannel.UseVisualStyleBackColor = True
        Me.DeleteChannel.Visible = False
        '
        'ChannelName
        '
        Me.ChannelName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ChannelName.Location = New System.Drawing.Point(32, 260)
        Me.ChannelName.Name = "ChannelName"
        Me.ChannelName.Size = New System.Drawing.Size(95, 20)
        Me.ChannelName.TabIndex = 24
        Me.ChannelName.Visible = False
        '
        'Analysis
        '
        Me.Analysis.AutoSize = True
        Me.Analysis.Location = New System.Drawing.Point(91, 15)
        Me.Analysis.Name = "Analysis"
        Me.Analysis.Size = New System.Drawing.Size(45, 13)
        Me.Analysis.TabIndex = 25
        Me.Analysis.Text = "Analysis"
        '
        'AnalysisPossibilities
        '
        Me.AnalysisPossibilities.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.AnalysisPossibilities.FormattingEnabled = True
        Me.AnalysisPossibilities.Items.AddRange(New Object() {"QuPath", "ImageJ", "Ilastik"})
        Me.AnalysisPossibilities.Location = New System.Drawing.Point(136, 12)
        Me.AnalysisPossibilities.Name = "AnalysisPossibilities"
        Me.AnalysisPossibilities.Size = New System.Drawing.Size(78, 21)
        Me.AnalysisPossibilities.TabIndex = 26
        '
        'ImageAnalysisPath
        '
        Me.ImageAnalysisPath.Location = New System.Drawing.Point(137, 382)
        Me.ImageAnalysisPath.Name = "ImageAnalysisPath"
        Me.ImageAnalysisPath.ReadOnly = True
        Me.ImageAnalysisPath.Size = New System.Drawing.Size(230, 20)
        Me.ImageAnalysisPath.TabIndex = 27
        '
        'ImageAnalysisBrowse
        '
        Me.ImageAnalysisBrowse.Location = New System.Drawing.Point(373, 380)
        Me.ImageAnalysisBrowse.Name = "ImageAnalysisBrowse"
        Me.ImageAnalysisBrowse.Size = New System.Drawing.Size(100, 23)
        Me.ImageAnalysisBrowse.TabIndex = 28
        Me.ImageAnalysisBrowse.Text = "Browse"
        Me.ImageAnalysisBrowse.UseVisualStyleBackColor = True
        '
        'ImageAnalysis
        '
        Me.ImageAnalysis.AutoSize = True
        Me.ImageAnalysis.Location = New System.Drawing.Point(44, 385)
        Me.ImageAnalysis.Name = "ImageAnalysis"
        Me.ImageAnalysis.Size = New System.Drawing.Size(87, 13)
        Me.ImageAnalysis.TabIndex = 29
        Me.ImageAnalysis.Text = "Image to analyse"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ImageMicrodissecteur
        '
        Me.ImageMicrodissecteur.AutoSize = True
        Me.ImageMicrodissecteur.Location = New System.Drawing.Point(19, 411)
        Me.ImageMicrodissecteur.Name = "ImageMicrodissecteur"
        Me.ImageMicrodissecteur.Size = New System.Drawing.Size(105, 13)
        Me.ImageMicrodissecteur.TabIndex = 32
        Me.ImageMicrodissecteur.Text = "Microdissecteur slide"
        Me.ImageMicrodissecteur.Visible = False
        '
        'ImageMicrodissecteurBrowse
        '
        Me.ImageMicrodissecteurBrowse.Location = New System.Drawing.Point(373, 406)
        Me.ImageMicrodissecteurBrowse.Name = "ImageMicrodissecteurBrowse"
        Me.ImageMicrodissecteurBrowse.Size = New System.Drawing.Size(100, 23)
        Me.ImageMicrodissecteurBrowse.TabIndex = 31
        Me.ImageMicrodissecteurBrowse.Text = "Browse"
        Me.ImageMicrodissecteurBrowse.UseVisualStyleBackColor = True
        Me.ImageMicrodissecteurBrowse.Visible = False
        '
        'ImageMicrodissecteurPath
        '
        Me.ImageMicrodissecteurPath.Location = New System.Drawing.Point(137, 408)
        Me.ImageMicrodissecteurPath.Name = "ImageMicrodissecteurPath"
        Me.ImageMicrodissecteurPath.ReadOnly = True
        Me.ImageMicrodissecteurPath.Size = New System.Drawing.Size(230, 20)
        Me.ImageMicrodissecteurPath.TabIndex = 30
        Me.ImageMicrodissecteurPath.Visible = False
        '
        'OpenFileDialog2
        '
        Me.OpenFileDialog2.FileName = "OpenFileDialog2"
        '
        'Macro
        '
        Me.Macro.AutoSize = True
        Me.Macro.Location = New System.Drawing.Point(257, 15)
        Me.Macro.Name = "Macro"
        Me.Macro.Size = New System.Drawing.Size(37, 13)
        Me.Macro.TabIndex = 33
        Me.Macro.Text = "Macro"
        '
        'MacroBox
        '
        Me.MacroBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MacroBox.FormattingEnabled = True
        Me.MacroBox.Location = New System.Drawing.Point(300, 12)
        Me.MacroBox.Name = "MacroBox"
        Me.MacroBox.Size = New System.Drawing.Size(106, 21)
        Me.MacroBox.TabIndex = 34
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(503, 490)
        Me.Controls.Add(Me.MacroBox)
        Me.Controls.Add(Me.Macro)
        Me.Controls.Add(Me.ImageMicrodissecteur)
        Me.Controls.Add(Me.ImageMicrodissecteurBrowse)
        Me.Controls.Add(Me.ImageMicrodissecteurPath)
        Me.Controls.Add(Me.ImageAnalysis)
        Me.Controls.Add(Me.ImageAnalysisBrowse)
        Me.Controls.Add(Me.ImageAnalysisPath)
        Me.Controls.Add(Me.AnalysisPossibilities)
        Me.Controls.Add(Me.Analysis)
        Me.Controls.Add(Me.ChannelName)
        Me.Controls.Add(Me.DeleteChannel)
        Me.Controls.Add(Me.AddChannel)
        Me.Controls.Add(Me.ChanNames)
        Me.Controls.Add(Me.ListChannelsBox)
        Me.Controls.Add(Me.PositionBox3)
        Me.Controls.Add(Me.S3Position)
        Me.Controls.Add(Me.PositionBox2)
        Me.Controls.Add(Me.S2Position)
        Me.Controls.Add(Me.PositionBox1)
        Me.Controls.Add(Me.S1Position)
        Me.Controls.Add(Me.MicroscopeBox)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.Start)
        Me.Controls.Add(Me.StainingBox)
        Me.Controls.Add(Me.Staining)
        Me.Controls.Add(Me.SupportBox)
        Me.Controls.Add(Me.Support)
        Me.Controls.Add(Me.MicAcquisition)
        Me.Name = "Form2"
        Me.Text = "Acquisition informations"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MicAcquisition As Label
    Friend WithEvents Support As Label
    Friend WithEvents SupportBox As ComboBox
    Friend WithEvents Staining As Label
    Friend WithEvents StainingBox As ComboBox
    Friend WithEvents Start As Button
    Friend WithEvents Cancel As Button
    Friend WithEvents MicroscopeBox As ComboBox
    Friend WithEvents S1Position As Label
    Friend WithEvents PositionBox1 As ComboBox
    Friend WithEvents PositionBox2 As ComboBox
    Friend WithEvents S2Position As Label
    Friend WithEvents PositionBox3 As ComboBox
    Friend WithEvents S3Position As Label
    Friend WithEvents ListChannelsBox As CheckedListBox
    Friend WithEvents ChanNames As Label
    Friend WithEvents AddChannel As Button
    Friend WithEvents DeleteChannel As Button
    Friend WithEvents ChannelName As TextBox
    Friend WithEvents Analysis As Label
    Friend WithEvents AnalysisPossibilities As ComboBox
    Friend WithEvents ImageAnalysisPath As TextBox
    Friend WithEvents ImageAnalysisBrowse As Button
    Friend WithEvents ImageAnalysis As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents ImageMicrodissecteur As Label
    Friend WithEvents ImageMicrodissecteurBrowse As Button
    Friend WithEvents ImageMicrodissecteurPath As TextBox
    Friend WithEvents OpenFileDialog2 As OpenFileDialog
    Friend WithEvents Macro As Label
    Friend WithEvents MacroBox As ComboBox
End Class
