<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFormasPagos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFormasPagos))
        Me.RCFormasPagos = New AxXtremeReportControl.AxReportControl()
        Me.Titulo = New AxXtremeShortcutBar.AxShortcutCaption()
        CType(Me.RCFormasPagos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Titulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RCFormasPagos
        '
        Me.RCFormasPagos.Location = New System.Drawing.Point(319, 96)
        Me.RCFormasPagos.Name = "RCFormasPagos"
        Me.RCFormasPagos.OcxState = CType(resources.GetObject("RCFormasPagos.OcxState"), System.Windows.Forms.AxHost.State)
        Me.RCFormasPagos.Size = New System.Drawing.Size(305, 246)
        Me.RCFormasPagos.TabIndex = 17
        '
        'Titulo
        '
        Me.Titulo.Enabled = True
        Me.Titulo.Location = New System.Drawing.Point(76, 75)
        Me.Titulo.Name = "Titulo"
        Me.Titulo.OcxState = CType(resources.GetObject("Titulo.OcxState"), System.Windows.Forms.AxHost.State)
        Me.Titulo.Size = New System.Drawing.Size(203, 46)
        Me.Titulo.TabIndex = 16
        '
        'FrmFormasPagos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.RCFormasPagos)
        Me.Controls.Add(Me.Titulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmFormasPagos"
        Me.Text = "Formas de Pagos"
        CType(Me.RCFormasPagos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Titulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RCFormasPagos As AxXtremeReportControl.AxReportControl
    Friend WithEvents Titulo As AxXtremeShortcutBar.AxShortcutCaption
End Class
