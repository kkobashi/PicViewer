'File: frmMain.vb
'Purpose: Main application form 
'Author: Kerry Kobashi
'Copyright: Kobashi Computing (c) 2018. All rights reserved.

'Permission Is hereby granted, free Of charge, to any person obtaining a copy
'of this software And associated documentation files (the "Software"), to deal
'in the Software without restriction, including without limitation the rights
'to use, copy, modify, merge, publish, distribute, sublicense, And/Or sell
'copies of the Software, And to permit persons to whom the Software Is
'furnished to do so, subject to the following conditions:

'The above copyright notice And this permission notice shall be included In all
'copies Or substantial portions of the Software.

'THE SOFTWARE Is PROVIDED "AS IS", WITHOUT WARRANTY Of ANY KIND, EXPRESS Or
'IMPLIED, INCLUDING BUT Not LIMITED To THE WARRANTIES Of MERCHANTABILITY,
'FITNESS FOR A PARTICULAR PURPOSE And NONINFRINGEMENT. IN NO EVENT SHALL THE
'AUTHORS Or COPYRIGHT HOLDERS BE LIABLE For ANY CLAIM, DAMAGES Or OTHER
'LIABILITY, WHETHER In AN ACTION Of CONTRACT, TORT Or OTHERWISE, ARISING FROM,
'OUT OF Or IN CONNECTION WITH THE SOFTWARE Or THE USE Or OTHER DEALINGS IN THE
'SOFTWARE.

Imports System.ComponentModel
Imports System.IO

Public Class frmMain
    Private imgSource As Image
    Private scaleFactor As Double
    Private scaleImageWidth As Integer
    Private scaleImageHeight As Integer
    Private bDrag As Boolean
    Private ptOrigin As Point
    Private theScreen As Screen
    Private pathImage As String

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            imgSource = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "Intro.png")
        Catch ex As Exception
            MessageBox.Show("Program cannot continue. Missing Intro.png file. Make sure you installed PicViewer properly.", "PicView Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End Try

        bDrag = False
        picBox.SizeMode = PictureBoxSizeMode.Normal
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False

        ToolStripMenuItemBorderless.Checked = False
        ToolStripMenuItemPin.Checked = False
        ToolStripMenuItemFileInfo.Enabled = False
        DrawPictureToScale(1.0)

        CenterToScreen()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click

        ' Setup openfiledialog box
        ' Pay attention to spaces and semicolons in filter format
        Try
            openFileDlg.Filter = "Image Files (*.jpg;*.png;*.gif) |*.jpg;*.png;*.gif|All Files (*.*) |*.*"
            openFileDlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            openFileDlg.FileName = ""
            openFileDlg.FilterIndex = 1
            If (openFileDlg.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
                If openFileDlg.FileName <> "" Then
                    pathImage = openFileDlg.FileName
                    imgSource = Image.FromFile(openFileDlg.FileName)
                    Me.Text = "PicViewer - " & Path.GetFileName(openFileDlg.FileName)
                    ToolStripMenuItemFileInfo.Enabled = True
                    DrawPictureToScale(1.0)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Could not open file." & vbCrLf & "Only files of type JPG, PNG, and GIF are supported.", "PicView Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmMain_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        ' Right mouse button click brings up context menu
        If (e.Button = MouseButtons.Right) Then
            Me.MyContextMenuStrip.Show()
        End If
    End Sub

    Private Sub ToolStripMenuItem50Pct_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem50Pct.Click
        DrawPictureToScale(0.5)
    End Sub

    Private Sub ToolStripMenuItem80Pct_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem80Pct.Click
        DrawPictureToScale(0.8)
    End Sub

    Private Sub ToolStripMenuItem100Pct_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemOriginalSize.Click
        DrawPictureToScale(1.0)
    End Sub

    Private Sub ToolStripMenuItem120Pct_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem120Pct.Click
        DrawPictureToScale(1.2)
    End Sub

    Private Sub ToolStripMenuItemFullscreen_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemFullscreen.Click
        DrawPictureToFullScreen()
    End Sub

    Private Sub ToolStripMenuItemBorderless_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemBorderless.Click
        ' Borderless forces a no border style form
        ' A form with a border allows a non resizeable form

        If ToolStripMenuItemBorderless.Checked = False Then
            ToolStripMenuItemBorderless.Checked = True
            Me.FormBorderStyle = FormBorderStyle.None
        Else
            ToolStripMenuItemBorderless.Checked = False
            Me.FormBorderStyle = FormBorderStyle.FixedSingle
            ToolStripMenuItemPin.Checked = False
        End If

    End Sub

    Private Sub ToolStripMenuItemPin_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemPin.Click
        ' Pinning forces no form movement along with a borderless window without caption
        ' Not being pinned lets form movement in both borderless and border mode

        If ToolStripMenuItemPin.Checked = False Then
            Me.FormBorderStyle = FormBorderStyle.None
            ToolStripMenuItemBorderless.Checked = True
            ToolStripMenuItemPin.Checked = True
        Else
            ToolStripMenuItemPin.Checked = False
        End If

    End Sub

    Public Function GetImageFilename() As String
        Return pathImage
    End Function

    Private Sub SetScaleMenu()
        Select Case scaleFactor
            Case 0.0
                ToolStripMenuItem50Pct.Checked = False
                ToolStripMenuItem80Pct.Checked = False
                ToolStripMenuItemOriginalSize.Checked = False
                ToolStripMenuItem120Pct.Checked = False
                ToolStripMenuItemFullscreen.Checked = True
            Case 0.5
                ToolStripMenuItem50Pct.Checked = True
                ToolStripMenuItem80Pct.Checked = False
                ToolStripMenuItemOriginalSize.Checked = False
                ToolStripMenuItem120Pct.Checked = False
                ToolStripMenuItemFullscreen.Checked = False
            Case 0.8
                ToolStripMenuItem50Pct.Checked = False
                ToolStripMenuItem80Pct.Checked = True
                ToolStripMenuItemOriginalSize.Checked = False
                ToolStripMenuItem120Pct.Checked = False
                ToolStripMenuItemFullscreen.Checked = False
            Case 1.0
                ToolStripMenuItem50Pct.Checked = False
                ToolStripMenuItem80Pct.Checked = False
                ToolStripMenuItemOriginalSize.Checked = True
                ToolStripMenuItem120Pct.Checked = False
                ToolStripMenuItemFullscreen.Checked = False
            Case 1.2
                ToolStripMenuItem50Pct.Checked = False
                ToolStripMenuItem80Pct.Checked = False
                ToolStripMenuItemOriginalSize.Checked = False
                ToolStripMenuItem120Pct.Checked = True
                ToolStripMenuItemFullscreen.Checked = False
        End Select
    End Sub
    Private Sub DrawPictureToFullScreen()
        ' Only if we have an image
        If imgSource Is Nothing Then
            Exit Sub
        End If

        ' Set fullscreen mode and note that its a stretch operation and maximize box is true
        picBox.SizeMode = PictureBoxSizeMode.StretchImage
        Me.FormBorderStyle = FormBorderStyle.None
        Me.MaximizeBox = True

        ' Fullscreen is scalefactor 0.0
        ' Don't forget to check the borderless menu item
        scaleFactor = 0.0
        SetScaleMenu()
        ToolStripMenuItemBorderless.Checked = True

        ' Get the dimensions of the screen we are on
        Dim theScreen As Screen
        theScreen = Screen.FromPoint(Me.Location)

        ' Calculate image size
        scaleImageWidth = CInt(theScreen.Bounds.Width)
        scaleImageHeight = CInt(theScreen.Bounds.Height)

        ' Setup new form size
        ' Get the screen the form is on and use the screen offset for left and top
        Me.Left = theScreen.Bounds.Left
        Me.Top = theScreen.Bounds.Top
        Me.Width = scaleImageWidth
        Me.Height = scaleImageHeight

        ' Setup new picBox size
        picBox.Left = 0
        picBox.Top = 0
        picBox.Width = scaleImageWidth
        picBox.Height = scaleImageHeight

        ' Okay now WM_PAINT the client area
        Me.Invalidate()
    End Sub
    Private Sub DrawPictureToScale(scale As Double)
        ' Only if we have an image
        If imgSource Is Nothing Then
            Exit Sub
        End If

        picBox.SizeMode = PictureBoxSizeMode.Normal
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False

        scaleFactor = scale
        SetScaleMenu()
        ToolStripMenuItemBorderless.Checked = False

        ' Calculate image size
        scaleImageWidth = CInt(imgSource.Width * scaleFactor)
        scaleImageHeight = CInt(imgSource.Height * scaleFactor)

        ' Calculate border width and titlebar heights
        Dim borderWidth As Integer
        Dim titlebarHeight As Integer
        borderWidth = Me.Width - Me.ClientSize.Width
        titlebarHeight = (Me.Height - Me.ClientSize.Height)

        ' Setup new form size
        ' Me.Left = 0 and Me.Top = 0 don't set and use current form position relative to current screen
        Me.Width = scaleImageWidth + borderWidth
        Me.Height = scaleImageHeight + titlebarHeight

        ' Setup new picBox size relative to form
        picBox.Left = 0
        picBox.Top = 0
        picBox.Width = scaleImageWidth
        picBox.Height = scaleImageHeight

        ' Okay now WM_PAINT the client area
        Me.Invalidate()
    End Sub

    Private Sub frmMain_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        ' Only if we have an image
        If imgSource Is Nothing Then
            Exit Sub
        End If

        ' Rescale source and set picturebox image bitmap
        Dim bitmapDest As New Bitmap(scaleImageWidth, scaleImageHeight)
        Dim graphicsObj = Graphics.FromImage(bitmapDest)

        graphicsObj.DrawImage(imgSource, 0, 0, scaleImageWidth, scaleImageHeight)
        picBox.Image = bitmapDest
    End Sub

    Private Sub picBox_MouseDown(sender As Object, e As MouseEventArgs) Handles picBox.MouseDown
        ' mouse is inside the picture box and is being dragged

        ' If pinned, don't allow form to be moved
        If Me.ToolStripMenuItemPin.Checked = True Then
            Exit Sub
        End If

        ' treat this as a form window move if in borderless style and not fullscreen
        If Me.FormBorderStyle = FormBorderStyle.None And Me.MaximizeBox <> True Then
            bDrag = True
        End If
    End Sub

    Private Sub picBox_MouseMove(sender As Object, e As MouseEventArgs) Handles picBox.MouseMove
        If bDrag = False Then
            Exit Sub
        End If

        Me.Left = PointToScreen(New Point(e.X, e.Y)).X
        Me.Top = PointToScreen(New Point(e.X, e.Y)).Y
        Me.Width = scaleImageWidth
        Me.Height = scaleImageHeight

    End Sub

    Private Sub picBox_MouseUp(sender As Object, e As MouseEventArgs) Handles picBox.MouseUp
        bDrag = False
    End Sub

    Private Sub ToolStripMenuItemFileInfo_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemFileInfo.Click
        frmFileInfo.StartPosition = FormStartPosition.CenterParent
        frmFileInfo.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItemAbout_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemAbout.Click
        AboutBox.StartPosition = FormStartPosition.CenterParent
        AboutBox.ShowDialog() ' Don't use show or show(me) or show(this)
    End Sub
End Class
