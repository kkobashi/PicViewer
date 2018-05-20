'File: frmFileInfo.vb
'Purpose: Image file info property form 
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
Imports System.Drawing
Imports System.IO

Public Class frmFileInfo
    Private Sub frmFileInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv.RowHeadersVisible = False
        dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray
        dgv.BackgroundColor = Color.White
        dgv.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgv.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgv.EnableHeadersVisualStyles = False

        Dim bmp = New Bitmap(frmMain.GetImageFilename())

        dgv.Rows.Add("Directory", Path.GetDirectoryName(frmMain.GetImageFilename()))
        dgv.Rows.Add("Filename", Path.GetFileNameWithoutExtension(frmMain.GetImageFilename()))
        dgv.Rows.Add("File type", Path.GetExtension(frmMain.GetImageFilename()).Replace(".", "").ToUpper())
        dgv.Rows.Add("Width", bmp.Width)
        dgv.Rows.Add("Height", bmp.Height)
    End Sub

    Private Sub frmFileInfo_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        dgv.Rows.Clear()
    End Sub
End Class