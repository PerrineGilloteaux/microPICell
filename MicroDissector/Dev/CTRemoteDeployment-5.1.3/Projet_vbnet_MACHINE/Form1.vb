Imports System
Imports System.IO
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Runtime.InteropServices.ComTypes
Imports CTRemote

Public Class Form1
    Dim iStream As System.Runtime.InteropServices.ComTypes.IStream
    WithEvents CTRemote As CTRemoteCoClass
    Dim sForm As Form2 'second form

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CTRemote = DirectCast(Marshal.GetActiveObject("CTRemote.CTRemoteCoClass"), CTRemoteCoClass)

        nIndex.Text = GlobalVariables.index
        nGroup.Text = GlobalVariables.group
    End Sub

    'TransferShapes : transfer shape to CellTools & displays in programm (ROI list)
    Private Sub DisplayShape_Click(sender As Object, e As EventArgs) Handles DisplayShape.Click
        'If dictionnary os positions is not empty
        If GlobalVariables.XYpos IsNot Nothing Then
            For Each kv As KeyValuePair(Of Integer, List(Of List(Of Double))) In GlobalVariables.XYpos
                'Display shapes to ROILIST
                Dim str As String = "X(" + String.Join(",", kv.Value(0)) + "), Y(" + String.Join(",", kv.Value(1)) + ")" 'Get XY coord list as string
                ROIList.Items.Add(str) 'Add to ROILIST

                'Transfer shapes to CT
                Dim group As Int32 = 1 'change default 1 and textbox
                Dim Xpos As Double()
                Dim Ypos As Double()

                Xpos = kv.Value(0).ToArray()
                Ypos = kv.Value(1).ToArray()

                GlobalVariables.slide = CTRemote.GetSampleID(GlobalVariables.index)
                'CTRemote.CTCalibrateStage()
                CTRemote.TransferShapeToCT(GlobalVariables.slide, GlobalVariables.group, Xpos, Ypos, GlobalVariables.Zposition)
            Next
        Else
            ROIList.Items.Add("RIEN")
            MsgBox("You need to predict the shapes before displaying it.")
        End If
    End Sub


    'AcquireImage
    Private Sub BImage_Click(sender As Object, e As EventArgs) Handles BImage.Click
        'get IStream from CTRemote
        iStream = CTRemote.CTAquireCurrentImage

        'create transfer buffer
        Dim bufferSize As Integer = 8192
        Dim buffer(bufferSize) As Byte
        Dim bufferSizeRead = Marshal.AllocCoTaskMem(Marshal.SizeOf(bufferSize))

        ' copy to memory stream
        Dim mStream As New MemoryStream
        Dim bytesRead As Integer
        bytesRead = bufferSize
        While (bytesRead > 0)
            iStream.Read(buffer, buffer.Length, bufferSizeRead)
            bytesRead = Marshal.ReadInt32(bufferSizeRead)
            mStream.Write(buffer, 0, bytesRead)
        End While

        'copy to picture box
        PictureBox1.Image = Image.FromStream(mStream)
    End Sub


    'Save : Checks file extension & save image to hard disk
    Private Sub SaveImage_Click(sender As Object, e As EventArgs) Handles SaveImage.Click
        'If Image was acquired
        If Not PictureBox1.Image Is Nothing Then
            SaveFileDialog1.InitialDirectory = Environment.GetEnvironmentVariable("UserProfile") + "\Projet_microdissecteur\Images"

            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                Dim fullPath = Path.GetFullPath(SaveFileDialog1.FileName)
                Dim imagePath = Path.GetDirectoryName(fullPath)
                Dim imageName = Path.GetFileName(fullPath)

                'Check image extension
                If Path.GetExtension(imageName).ToString <> ".tiff" Then
                    imageName = Path.GetFileNameWithoutExtension(imageName) + ".tiff"
                End If

                'Save
                GlobalVariables.finalname = Path.Combine(imagePath, imageName)
                PictureBox1.Image.Save(GlobalVariables.finalname)

                'Get XYZ position
                'CTRemote.CTCalibrateStage()
                GlobalVariables.Zposition = CTRemote.CTCurrentZ
                GlobalVariables.Xposition = CTRemote.CTCurrentX
                GlobalVariables.Yposition = CTRemote.CTCurrentY

                LX.Text = GlobalVariables.Xposition
                LY.Text = GlobalVariables.Yposition
                LZ.Text = GlobalVariables.Zposition

                GlobalVariables.acquiered = True

                'If no image were acquired, display error message 
            Else
                MsgBox("No images were acquired yet.")
            End If
        End If
    End Sub


    'GetScale
    Private Sub BPixel_Click(sender As Object, e As EventArgs) Handles Scale.Click
        Dim number As Double
        number = CTRemote.CTCurrentPixelPerMM
        Scaleg.Text = number
    End Sub


    'Initialize : checks if demo server is running
    Private Sub BInit_Click(sender As Object, e As EventArgs) Handles Init.Click
        CTRemote.Demo = True
        If CTRemote.Demo Then
            Initialize.Text = "Demo running"
        Else
            Initialize.Text = "Demo not running"
        End If
    End Sub


    'Predict : displays second form
    Private Sub Predict_Click(sender As Object, e As EventArgs) Handles Predict.Click
        GlobalVariables.slide = CTRemote.GetSampleID(GlobalVariables.index)

        If GlobalVariables.XYpos IsNot Nothing Then
            GlobalVariables.XYpos.clear()
        End If

        If sForm Is Nothing Then
            sForm = New Form2
        End If
        sForm.Show()
    End Sub

    'CutShapes
    Private Sub ProcesseShape_Click(sender As Object, e As EventArgs) Handles ProcessShape.Click
        'Displays a message box asking if user wants to process shapes
        Dim msg = "Are you sure you want to dissect the selected shapes ?"
        Dim buttons = vbYesNo
        Dim response = MsgBox(msg, buttons)

        'If user says yes, process. Else do nothing
        If response = vbYes Then
            CTRemote.CTProcessShapes()
        End If
    End Sub

    'Boutons de test
    'SetID : checks if slide field is not empty and set ID (with string name & int index)
    Private Sub SetID_Click(sender As Object, e As EventArgs) Handles SetID.Click
        If GetID.Text <> "" Then
            CTRemote.SetSampleID(GlobalVariables.index, GetID.Text)
            MsgBox("Slide n" + GlobalVariables.index.ToString + " name set to '" + GetID.Text + "'.")
            GetID.Text = ""
        Else
            MsgBox("The field is empty, try again.")
        End If
    End Sub

    'Get ID : get slide name from its index
    Private Sub GetD_Click(sender As Object, e As EventArgs) Handles GetD.Click
        id.Text = CTRemote.GetSampleID(GlobalVariables.index)
    End Sub

    'Move : checks if positions were indicated and move
    Private Sub Move_Click(sender As Object, e As EventArgs) Handles Move.Click
        If X.Text <> "" And Y.Text <> "" And Z.Text <> "" Then
            CTRemote.CTMoveTo(X.Text, Y.Text, Z.Text)
            X.Text = ""
            Y.Text = ""
            Z.Text = ""
        Else
            MsgBox("The fields are empty, try again.")
        End If
    End Sub

    'Current : displays current position
    Private Sub CurrentPos_Click(sender As Object, e As EventArgs) Handles CurrentPos.Click
        LX.Text = CTRemote.CTCurrentX
        LY.Text = CTRemote.CTCurrentY
        LZ.Text = CTRemote.CTCurrentZ
    End Sub

    'Calibrate
    Private Sub Calibrate_Click(sender As Object, e As EventArgs) Handles Calibrate.Click
        CTRemote.CTCalibrateStage()
        Calibrated.Text = "Calibration ok"
    End Sub

    'Set index
    Private Sub setindex_Click(sender As Object, e As EventArgs) Handles setindex.Click
        If indexbox.Text <> "" Then
            GlobalVariables.index = indexbox.Text
            nIndex.Text = GlobalVariables.index
            indexbox.Text = ""
        Else
            MsgBox("The field is empty, try again.")
        End If
    End Sub

    'Set group
    Private Sub setgroup_Click(sender As Object, e As EventArgs) Handles setgroup.Click
        If groupbox.Text <> "" Then
            GlobalVariables.group = groupbox.Text
            nGroup.Text = GlobalVariables.group
            groupbox.Text = ""
        Else
            MsgBox("The field is empty, try again.")
        End If
    End Sub


    'Get image magnification
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim number As Double
        GlobalVariables.slide = CTRemote.GetSampleID(GlobalVariables.index)
        number = CTRemote.GetScannedImageMagnification(GlobalVariables.slide)
        imageMagnification.Text = number
    End Sub
End Class



'Global variables needed for both forms
Public Class GlobalVariables
    Public Shared Zposition As Double
    Public Shared Xposition As Double
    Public Shared Yposition As Double
    Public Shared index As Int32 = 0 'index slide ID
    Public Shared group As Int32 = 1 'group transfer shape
    Public Shared slide As String 'slide ID
    Public Shared acquiered As Boolean = False
    Public Shared finalname As String = "" 'name of the acquired image
    Public Shared XYpos = New Dictionary(Of Integer, List(Of List(Of Double))) 'dictionnary of XY positions
End Class
