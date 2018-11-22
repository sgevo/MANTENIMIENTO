<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmVersiones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmVersiones))
        Me.RCVersiones = New AxXtremeReportControl.AxReportControl()
        Me.cbProductos = New AxXtremeSuiteControls.AxComboBox()
        Me.lblProductos = New AxXtremeSuiteControls.AxLabel()
        Me.Titulo = New AxXtremeShortcutBar.AxShortcutCaption()
        CType(Me.RCVersiones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Titulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RCVersiones
        '
        Me.RCVersiones.Location = New System.Drawing.Point(400, 215)
        Me.RCVersiones.Name = "RCVersiones"
        Me.RCVersiones.OcxState = CType(resources.GetObject("RCVersiones.OcxState"), System.Windows.Forms.AxHost.State)
        Me.RCVersiones.Size = New System.Drawing.Size(213, 140)
        Me.RCVersiones.TabIndex = 0
        '
        'cbProductos
        '
        Me.cbProductos.Location = New System.Drawing.Point(145, 347)
        Me.cbProductos.Name = "cbProductos"
        Me.cbProductos.OcxState = CType(resources.GetObject("cbProductos.OcxState"), System.Windows.Forms.AxHost.State)
        Me.cbProductos.Size = New System.Drawing.Size(178, 24)
        Me.cbProductos.TabIndex = 7
        '
        'lblProductos
        '
        Me.lblProductos.Location = New System.Drawing.Point(145, 307)
        Me.lblProductos.Name = "lblProductos"
        Me.lblProductos.OcxState = CType(resources.GetObject("lblProductos.OcxState"), System.Windows.Forms.AxHost.State)
        Me.lblProductos.Size = New System.Drawing.Size(185, 25)
        Me.lblProductos.TabIndex = 8
        '
        'Titulo
        '
        Me.Titulo.Enabled = True
        Me.Titulo.Location = New System.Drawing.Point(420, 124)
        Me.Titulo.Name = "Titulo"
        Me.Titulo.OcxState = CType(resources.GetObject("Titulo.OcxState"), System.Windows.Forms.AxHost.State)
        Me.Titulo.Size = New System.Drawing.Size(148, 46)
        Me.Titulo.TabIndex = 9
        '
        'FrmVersiones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Titulo)
        Me.Controls.Add(Me.lblProductos)
        Me.Controls.Add(Me.cbProductos)
        Me.Controls.Add(Me.RCVersiones)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmVersiones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Versiones"
        CType(Me.RCVersiones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Titulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RCVersiones As AxXtremeReportControl.AxReportControl
    'Friend WithEvents Titulo As AxXtremeShortcutBar.AxShortcutCaption
    Friend WithEvents cbProductos As AxXtremeSuiteControls.AxComboBox
    Friend WithEvents lblProductos As AxXtremeSuiteControls.AxLabel
    Friend WithEvents Titulo As AxXtremeShortcutBar.AxShortcutCaption
End Class
