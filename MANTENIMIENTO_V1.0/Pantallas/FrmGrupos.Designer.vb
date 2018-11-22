<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmGrupos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGrupos))
        Me.Titulo = New AxXtremeShortcutBar.AxShortcutCaption()
        Me.RCGrupos = New AxXtremeReportControl.AxReportControl()
        CType(Me.Titulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RCGrupos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Titulo
        '
        Me.Titulo.Enabled = True
        Me.Titulo.Location = New System.Drawing.Point(91, 215)
        Me.Titulo.Name = "Titulo"
        Me.Titulo.OcxState = CType(resources.GetObject("Titulo.OcxState"), System.Windows.Forms.AxHost.State)
        Me.Titulo.Size = New System.Drawing.Size(100, 50)
        Me.Titulo.TabIndex = 1
        '
        'RCGrupos
        '
        Me.RCGrupos.Location = New System.Drawing.Point(293, 133)
        Me.RCGrupos.Name = "RCGrupos"
        Me.RCGrupos.OcxState = CType(resources.GetObject("RCGrupos.OcxState"), System.Windows.Forms.AxHost.State)
        Me.RCGrupos.Size = New System.Drawing.Size(214, 185)
        Me.RCGrupos.TabIndex = 13
        '
        'FrmGrupos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.RCGrupos)
        Me.Controls.Add(Me.Titulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmGrupos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Grupos"
        CType(Me.Titulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RCGrupos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Titulo As AxXtremeShortcutBar.AxShortcutCaption
    Friend WithEvents RCGrupos As AxXtremeReportControl.AxReportControl
End Class
