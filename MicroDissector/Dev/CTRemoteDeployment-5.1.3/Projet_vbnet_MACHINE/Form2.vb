Imports System
Imports System.IO
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Runtime.InteropServices.ComTypes
Imports System.Text.RegularExpressions



Public Class Form2
    'Ref to form
    Inherits System.Windows.Forms.Form
    Dim fForm As New Form1
    Dim allowedExtension = New List(Of String) From {".tiff", ".png", ".bmp", ".png"}



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Set image path to images directory
        If GlobalVariables.finalname <> "" Then
            ImageAnalysisPath.Text = GlobalVariables.finalname
            ImageAnalysis.Visible = False
            ImageAnalysisPath.Visible = False
            ImageAnalysisBrowse.Visible = False
        Else
            OpenFileDialog1.InitialDirectory = Environment.GetEnvironmentVariable("UserProfile") + "\Projet_microdissecteur\Images" 'textbox for image to analyse
            ImageAnalysisPath.Text = OpenFileDialog1.InitialDirectory
        End If

        OpenFileDialog2.InitialDirectory = Environment.GetEnvironmentVariable("UserProfile") + "\Projet_microdissecteur\Images" 'textbox for microdissecteur image
        ImageMicrodissecteurPath.Text = OpenFileDialog2.InitialDirectory

        'Set slide name
        If GlobalVariables.slide <> "" Then
            S1Position.Text = GlobalVariables.slide + " position"
        End If

        'If image was acquired, don't ask which microscope was used
        If GlobalVariables.acquiered = True Then
            MicroscopeBox.Text = "Microdissecteur"
            MicroscopeBox.Visible = False
            MicAcquisition.Visible = False
        End If

        Dim macroDir As String = Environment.GetEnvironmentVariable("UserProfile") + "\Projet_microdissecteur\Macro\"
        For Each file As String In System.IO.Directory.GetFiles(macroDir)
            MacroBox.Items.Add(System.IO.Path.GetFileNameWithoutExtension(file).Replace("_", " "))
        Next
    End Sub


    'Write user acquisition information in .txt file
    Public Function Write_tmp_file(ByVal d As Dictionary(Of String, String), ByVal c As List(Of String), ByVal p As List(Of String)) As String
        'Create & open tmp.txt file
        Dim tempfile = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".txt"
        Dim positions = New List(Of Double)
        Using f As New System.IO.StreamWriter(File.Open(tempfile, FileMode.OpenOrCreate))

            f.WriteLine(MicroscopeBox.Text) 'acquisition microscope
            f.WriteLine(SupportBox.Text) 'support type

            For Each item As KeyValuePair(Of String, String) In d 'slide names & positions
                f.Write("{0}:{1}", item.Key, item.Value)
                If item.Key <> d.Keys(d.Count - 1) Then
                    f.Write(",")
                Else
                    f.WriteLine()
                End If
            Next

            f.WriteLine(StainingBox.Text) 'staining type
            f.WriteLine(AnalysisPossibilities.Text) 'logiciel to use #TO CHANGE ??
            If GlobalVariables.acquiered = True Then 'xy positions at acquisition
                f.Write(GlobalVariables.Xposition)
                f.Write(";")
                f.Write(GlobalVariables.Yposition)
                f.WriteLine()
            Else
                f.WriteLine()
            End If

            If StainingBox.Text = "Fluorescence" Then 'fluorescence channel names
                For Each item As String In c
                    f.Write(item)
                    If item <> c.Last Then
                        f.Write(",")
                    Else
                        f.WriteLine()
                    End If
                Next

                For Each item As String In p 'phenotype of interest
                    f.Write(item)
                    If item <> p.Last Then
                        f.Write(",")
                    End If
                Next
            End If

        End Using

        Return tempfile 'return name of tmp file created
    End Function

    'Button Close X
    Private Sub Form2_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'If user clicks the X button, hide the form instead of closing it
        If e.CloseReason <> CloseReason.FormOwnerClosing Then
            Me.Hide()
            e.Cancel = True
        End If
    End Sub

    'Button Staining
    Private Sub StainingBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles StainingBox.SelectedIndexChanged
        'Displays ChannelBox (Add, Delete) if user chose fluorescence staining
        If StainingBox.Text = "Fluorescence" Then
            ChanNames.Visible = True
            ListChannelsBox.Visible = True
            AddChannel.Visible = True
            DeleteChannel.Visible = True
            ChannelName.Visible = True
        Else
            ChanNames.Visible = False
            ListChannelsBox.Visible = False
            AddChannel.Visible = False
            DeleteChannel.Visible = False
            ChannelName.Visible = False
        End If
    End Sub

    'Button Add channel
    Private Sub AddChannel_Click(sender As Object, e As EventArgs) Handles AddChannel.Click
        'Add text entered in textbox if not empty
        If ChannelName.Text <> "" Then
            ListChannelsBox.Items.Add(ChannelName.Text)
        Else
            MsgBox("The field is empty, try again.")
        End If
    End Sub

    'Button Delete channel
    Private Sub DeleteChannel_Click(sender As Object, e As EventArgs) Handles DeleteChannel.Click
        'Delete selected item
        ListChannelsBox.Items.Remove(ListChannelsBox.SelectedItem)
    End Sub


    'Button browse file for image to analyse
    Private Sub ImageAnalysisBrowse_Click(sender As Object, e As EventArgs) Handles ImageAnalysisBrowse.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            ImageAnalysisPath.Text = System.IO.Path.GetFullPath(OpenFileDialog1.FileName)
        End If
    End Sub

    'Button browse file for image scanned with microdissecteur
    Private Sub ImageMicrodissecteurBrowse_Click(sender As Object, e As EventArgs) Handles ImageMicrodissecteurBrowse.Click
        If OpenFileDialog2.ShowDialog() = DialogResult.OK Then
            ImageMicrodissecteurPath.Text = System.IO.Path.GetFullPath(OpenFileDialog2.FileName)
        End If
    End Sub


    'Button Start the prediction
    Private Sub Start_Click(sender As Object, e As EventArgs) Handles Start.Click
        'Verify if user checked all panel !!! #TODO
        If GlobalVariables.finalname <> "" Then
            ImageAnalysisPath.Text = GlobalVariables.finalname
        End If

        If ImageAnalysisPath.Text = OpenFileDialog1.InitialDirectory Then 'Add options: if file is not an image, not a good extension
            Throw New Exception("Error: the image file to analyse is not valid.")
        ElseIf (MicroscopeBox.Text <> "Microdissecteur") And (ImageMicrodissecteurPath.Text = OpenFileDialog2.InitialDirectory) Then
            Throw New Exception("Error: the microdissecteur image file to analyse is not valid.")
        Else

            'Get the differents elements (phenotype of interest, channel names, microscope, support type, position)
            Dim channels = New List(Of String)
            Dim phenotypes = New List(Of String)
            If StainingBox.Text = "Fluorescence" Then
                For i As Integer = 0 To ListChannelsBox.Items.Count - 1
                    channels.Add(ListChannelsBox.Items(i).ToString) 'Add all values in channels list
                    If ListChannelsBox.GetItemChecked(i) = True Then
                        phenotypes.Add(ListChannelsBox.Items(i).ToString) 'Add only checked values in phenotype list
                    End If
                Next
            End If

            Dim sPositions = New Dictionary(Of String, String) From {
                {"S1", PositionBox1.Text},
                {"S2", PositionBox2.Text},
                {"S3", PositionBox2.Text}
            } 'get slide names


            'Execute python script
            Dim tempfile As String = Write_tmp_file(sPositions, channels, phenotypes) 'User information filling
            Dim scriptPath As String = Environment.GetEnvironmentVariable("UserProfile") + "\Projet_microdissecteur\SCRIPT_PRINCIPAL.py "
            Dim pythonPath As String = Environment.GetEnvironmentVariable("UserProfile") + "\AppData\Local\Programs\Python\Python39\python.exe" 'get python path directly #TODO

            Dim script As New ProcessStartInfo With {
                .FileName = pythonPath,
                .Arguments = scriptPath + " " + ImageAnalysisPath.Text + " " + ImageMicrodissecteurPath.Text + " " + tempfile
            }
            'MsgBox(script.Arguments) 'Just a test to see if the arguments are OK
            Dim pythonProcess = Process.Start(script)
            pythonProcess.WaitForExit()


            If pythonProcess.ExitCode <> 0 Then 'execution error
                Throw New Exception(pythonProcess.ExitCode)

            Else 'execution ok
                Me.Hide()
                My.Computer.FileSystem.DeleteFile(tempfile)

                'Initialise the variables
                Dim Xlist = New List(Of Double)
                Dim Ylist = New List(Of Double)
                Dim i As Integer
                Dim list = New List(Of List(Of Double))
                Dim Xpos = New Dictionary(Of Integer, List(Of Double))
                Dim Ypos = New Dictionary(Of Integer, List(Of Double))

                Dim fileinfo As New FileInfo(ImageAnalysisPath.Text)
                Dim file As String = Environment.GetEnvironmentVariable("UserProfile") + "\Projet_microdissecteur\Coord\" + System.IO.Path.GetFileNameWithoutExtension(fileinfo.Name) + "_ROI.csv"

                'Read the csv file
                Using reader As New Microsoft.VisualBasic.FileIO.TextFieldParser(file)
                    reader.TextFieldType = FileIO.FieldType.Delimited 'property TextFieldType is Delimited
                    reader.SetDelimiters(";") 'delimiter = ;
                    reader.ReadLine() 'read 1st line

                    'While the file continues
                    While Not reader.EndOfData
                        Try
                            Dim fields = reader.ReadFields()
                            i = fields(1)

                            If GlobalVariables.XYpos.ContainsKey(i) Then
                                GlobalVariables.XYpos(i).Item(0).Add(fields(2)) 'add X coordinates
                                GlobalVariables.XYpos(i).Item(1).Add(fields(3)) 'add Y coordinates
                            Else
                                GlobalVariables.XYpos.Add(i, New List(Of List(Of Double)))
                                GlobalVariables.XYpos(i).Add(New List(Of Double))
                                GlobalVariables.XYpos(i).Add(New List(Of Double))
                                GlobalVariables.XYpos(i).Item(0).Add(fields(2)) 'add X coordinates
                                GlobalVariables.XYpos(i).Item(1).Add(fields(3)) 'add Y coordinates
                            End If

                        Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException 'couldn't read the line
                            MsgBox("Error: couldn't read the line" & ex.Message & ". Line skipped.")
                        End Try
                    End While
                End Using

                'My.Computer.FileSystem.DeleteFile(file) --delete coord file #TODO when everything works

                Me.Hide()

            End If
        End If
    End Sub


    'Show image upload for microdissecteur slide only if acquisition microscope <> Microdissecteur
    Private Sub MicroscopeBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MicroscopeBox.SelectedIndexChanged
        If MicroscopeBox.Text <> "Microdissecteur" Then
            'add field to add slide from confocal/scanner
        Else
            'field to add slide from confocal/scanner : not displayed
        End If
    End Sub


    'Button cancel : hide the form
    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub
End Class