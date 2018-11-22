<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmUsuarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUsuarios))
        Me.RCUsuarios = New AxXtremeReportControl.AxReportControl()
        Me.Titulo = New AxXtremeShortcutBar.AxShortcutCaption()
        Me.cbGrupos = New AxXtremeSuiteControls.AxComboBox()
        Me.lblGrupos = New AxXtremeSuiteControls.AxLabel()
        CType(Me.RCUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Titulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbGrupos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblGrupos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RCUsuarios
        '
        Me.RCUsuarios.Location = New System.Drawing.Point(400, 215)
        Me.RCUsuarios.Name = "RCUsuarios"
        Me.RCUsuarios.OcxState = CType(resources.GetObject("RCUsuarios.OcxState"), System.Windows.Forms.AxHost.State)
        Me.RCUsuarios.Size = New System.Drawing.Size(213, 140)
        Me.RCUsuarios.TabIndex = 0
        '
        'Titulo
        '
        Me.Titulo.Enabled = True
        Me.Titulo.Location = New System.Drawing.Point(85, 215)
        Me.Titulo.Name = "Titulo"
        Me.Titulo.OcxState = CType(resources.GetObject("Titulo.OcxState"), System.Windows.Forms.AxHost.State)
        Me.Titulo.Size = New System.Drawing.Size(160, 50)
        Me.Titulo.TabIndex = 1
        '
        'cbGrupos
        '
        Me.cbGrupos.Location = New System.Drawing.Point(145, 347)
        Me.cbGrupos.Name = "cbGrupos"
        Me.cbGrupos.OcxState = CType(resources.GetObject("cbGrupos.OcxState"), System.Windows.Forms.AxHost.State)
        Me.cbGrupos.Size = New System.Drawing.Size(178, 24)
        Me.cbGrupos.TabIndex = 7
        '
        'lblGrupos
        '
        Me.lblGrupos.Location = New System.Drawing.Point(145, 291)
        Me.lblGrupos.Name = "lblGrupos"
        Me.lblGrupos.OcxState = CType(resources.GetObject("lblGrupos.OcxState"), System.Windows.Forms.AxHost.State)
        Me.lblGrupos.Size = New System.Drawing.Size(100, 50)
        Me.lblGrupos.TabIndex = 8
        '
        'FrmUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.lblGrupos)
        Me.Controls.Add(Me.cbGrupos)
        Me.Controls.Add(Me.Titulo)
        Me.Controls.Add(Me.RCUsuarios)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmUsuarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Usuarios"
        CType(Me.RCUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Titulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbGrupos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblGrupos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RCUsuarios As AxXtremeReportControl.AxReportControl
    Friend WithEvents Titulo As AxXtremeShortcutBar.AxShortcutCaption
    Friend WithEvents cbGrupos As AxXtremeSuiteControls.AxComboBox
    Friend WithEvents lblGrupos As AxXtremeSuiteControls.AxLabel
End Class
