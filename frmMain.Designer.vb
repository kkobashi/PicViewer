<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Me.openFileDlg = New System.Windows.Forms.OpenFileDialog()
        Me.MyContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemFileInfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItemOriginalSize = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem50Pct = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem80Pct = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem120Pct = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemFullscreen = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItemBorderless = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemPin = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.picBox = New System.Windows.Forms.PictureBox()
        Me.MyContextMenuStrip.SuspendLayout()
        CType(Me.picBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'openFileDlg
        '
        Me.openFileDlg.FileName = "OpenFileDialog1"
        '
        'MyContextMenuStrip
        '
        Me.MyContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.ToolStripMenuItemFileInfo, Me.ToolStripMenuItemAbout, Me.ToolStripSeparator1, Me.ToolStripMenuItemOriginalSize, Me.ToolStripMenuItem50Pct, Me.ToolStripMenuItem80Pct, Me.ToolStripMenuItem120Pct, Me.ToolStripMenuItemFullscreen, Me.ToolStripSeparator2, Me.ToolStripMenuItemBorderless, Me.ToolStripMenuItemPin})
        Me.MyContextMenuStrip.Name = "MyContextMenuStrip"
        Me.MyContextMenuStrip.Size = New System.Drawing.Size(153, 258)
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.OpenToolStripMenuItem.Text = "File Open..."
        '
        'ToolStripMenuItemFileInfo
        '
        Me.ToolStripMenuItemFileInfo.Name = "ToolStripMenuItemFileInfo"
        Me.ToolStripMenuItemFileInfo.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripMenuItemFileInfo.Text = "File Info..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(149, 6)
        '
        'ToolStripMenuItemOriginalSize
        '
        Me.ToolStripMenuItemOriginalSize.Name = "ToolStripMenuItemOriginalSize"
        Me.ToolStripMenuItemOriginalSize.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripMenuItemOriginalSize.Text = "Original Size"
        '
        'ToolStripMenuItem50Pct
        '
        Me.ToolStripMenuItem50Pct.Name = "ToolStripMenuItem50Pct"
        Me.ToolStripMenuItem50Pct.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripMenuItem50Pct.Text = "50%"
        '
        'ToolStripMenuItem80Pct
        '
        Me.ToolStripMenuItem80Pct.Name = "ToolStripMenuItem80Pct"
        Me.ToolStripMenuItem80Pct.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripMenuItem80Pct.Text = "80%"
        '
        'ToolStripMenuItem120Pct
        '
        Me.ToolStripMenuItem120Pct.Name = "ToolStripMenuItem120Pct"
        Me.ToolStripMenuItem120Pct.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripMenuItem120Pct.Text = "120%"
        '
        'ToolStripMenuItemFullscreen
        '
        Me.ToolStripMenuItemFullscreen.Name = "ToolStripMenuItemFullscreen"
        Me.ToolStripMenuItemFullscreen.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripMenuItemFullscreen.Text = "Fullscreen"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(149, 6)
        '
        'ToolStripMenuItemBorderless
        '
        Me.ToolStripMenuItemBorderless.Name = "ToolStripMenuItemBorderless"
        Me.ToolStripMenuItemBorderless.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripMenuItemBorderless.Text = "Borderless"
        '
        'ToolStripMenuItemPin
        '
        Me.ToolStripMenuItemPin.Name = "ToolStripMenuItemPin"
        Me.ToolStripMenuItemPin.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripMenuItemPin.Text = "Pin"
        '
        'ToolStripMenuItemAbout
        '
        Me.ToolStripMenuItemAbout.Name = "ToolStripMenuItemAbout"
        Me.ToolStripMenuItemAbout.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripMenuItemAbout.Text = "About..."
        '
        'picBox
        '
        Me.picBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.picBox.ContextMenuStrip = Me.MyContextMenuStrip
        Me.picBox.Location = New System.Drawing.Point(0, 0)
        Me.picBox.Name = "picBox"
        Me.picBox.Size = New System.Drawing.Size(483, 276)
        Me.picBox.TabIndex = 1
        Me.picBox.TabStop = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(483, 276)
        Me.ContextMenuStrip = Me.MyContextMenuStrip
        Me.Controls.Add(Me.picBox)
        Me.Name = "frmMain"
        Me.Text = "PicViewer"
        Me.MyContextMenuStrip.ResumeLayout(False)
        CType(Me.picBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents openFileDlg As OpenFileDialog
    Friend WithEvents MyContextMenuStrip As ContextMenuStrip
    Friend WithEvents ToolStripMenuItemOriginalSize As ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem80Pct As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem120Pct As ToolStripMenuItem
    Friend WithEvents picBox As PictureBox
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem50Pct As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItemBorderless As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemFullscreen As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemPin As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemFileInfo As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemAbout As ToolStripMenuItem
End Class
