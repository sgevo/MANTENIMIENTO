<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MDIPrincipal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDIPrincipal))
        Me.CommandBars = New AxXtremeCommandBars.AxCommandBars()
        Me.ImageManager = New AxXtremeCommandBars.AxImageManager()
        Me.ImageList_RC = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList8 = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList16 = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList24 = New System.Windows.Forms.ImageList(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.CommandBars, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageManager, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CommandBars
        '
        Me.CommandBars.Enabled = True
        Me.CommandBars.Location = New System.Drawing.Point(377, 211)
        Me.CommandBars.Name = "CommandBars"
        Me.CommandBars.OcxState = CType(resources.GetObject("CommandBars.OcxState"), System.Windows.Forms.AxHost.State)
        Me.CommandBars.Size = New System.Drawing.Size(24, 24)
        Me.CommandBars.TabIndex = 1
        '
        'ImageManager
        '
        Me.ImageManager.Enabled = True
        Me.ImageManager.Location = New System.Drawing.Point(480, 223)
        Me.ImageManager.Name = "ImageManager"
        Me.ImageManager.OcxState = CType(resources.GetObject("ImageManager.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ImageManager.Size = New System.Drawing.Size(24, 24)
        Me.ImageManager.TabIndex = 3
        '
        'ImageList_RC
        '
        Me.ImageList_RC.ImageStream = CType(resources.GetObject("ImageList_RC.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList_RC.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList_RC.Images.SetKeyName(0, "betaadd_32.ico")
        Me.ImageList_RC.Images.SetKeyName(1, "betacheckmark_32.ico")
        '
        'ImageList8
        '
        Me.ImageList8.ImageStream = CType(resources.GetObject("ImageList8.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList8.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList8.Images.SetKeyName(0, "betaadd_32.ico")
        Me.ImageList8.Images.SetKeyName(1, "betacheckmark_32.ico")
        '
        'ImageList16
        '
        Me.ImageList16.ImageStream = CType(resources.GetObject("ImageList16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList16.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList16.Images.SetKeyName(0, "betaadd_32.ico")
        Me.ImageList16.Images.SetKeyName(1, "betacheckmark_32.ico")
        '
        'ImageList24
        '
        Me.ImageList24.ImageStream = CType(resources.GetObject("ImageList24.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList24.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList24.Images.SetKeyName(0, "betaadd_32.ico")
        Me.ImageList24.Images.SetKeyName(1, "betacheckmark_32.ico")
        '
        'Timer1
        '
        Me.Timer1.Interval = 3000
        '
        'MDIPrincipal
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ImageManager)
        Me.Controls.Add(Me.CommandBars)
        Me.IsMdiContainer = True
        Me.Name = "MDIPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sistema de Gestión Integrada"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.CommandBars, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageManager, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CommandBars As AxXtremeCommandBars.AxCommandBars
    Friend WithEvents ImageManager As AxXtremeCommandBars.AxImageManager
    Friend WithEvents ImageList_RC As ImageList
    Friend WithEvents ImageList16 As ImageList
    Friend WithEvents ImageList24 As ImageList
    Public WithEvents ImageList8 As ImageList
    Friend WithEvents Timer1 As Timer
End Class
