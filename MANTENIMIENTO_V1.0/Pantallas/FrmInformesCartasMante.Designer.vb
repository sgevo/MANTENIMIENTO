<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInformesCartasMante
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInformesCartasMante))
        Me.lblClientes = New AxXtremeSuiteControls.AxLabel()
        Me.cbMes = New AxXtremeSuiteControls.AxComboBox()
        Me.lblcbMes = New AxXtremeSuiteControls.AxLabel()
        Me.RCClientes = New AxXtremeReportControl.AxReportControl()
        Me.Titulo = New AxXtremeShortcutBar.AxShortcutCaption()
        Me.lblTotal = New AxXtremeSuiteControls.AxLabel()
        CType(Me.lblClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblcbMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RCClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Titulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblClientes
        '
        Me.lblClientes.Location = New System.Drawing.Point(181, 68)
        Me.lblClientes.Name = "lblClientes"
        Me.lblClientes.OcxState = CType(resources.GetObject("lblClientes.OcxState"), System.Windows.Forms.AxHost.State)
        Me.lblClientes.Size = New System.Drawing.Size(420, 25)
        Me.lblClientes.TabIndex = 59
        '
        'cbMes
        '
        Me.cbMes.Location = New System.Drawing.Point(18, 91)
        Me.cbMes.Name = "cbMes"
        Me.cbMes.OcxState = CType(resources.GetObject("cbMes.OcxState"), System.Windows.Forms.AxHost.State)
        Me.cbMes.Size = New System.Drawing.Size(131, 24)
        Me.cbMes.TabIndex = 57
        '
        'lblcbMes
        '
        Me.lblcbMes.Location = New System.Drawing.Point(18, 71)
        Me.lblcbMes.Name = "lblcbMes"
        Me.lblcbMes.OcxState = CType(resources.GetObject("lblcbMes.OcxState"), System.Windows.Forms.AxHost.State)
        Me.lblcbMes.Size = New System.Drawing.Size(185, 25)
        Me.lblcbMes.TabIndex = 58
        '
        'RCClientes
        '
        Me.RCClientes.Location = New System.Drawing.Point(181, 91)
        Me.RCClientes.Name = "RCClientes"
        Me.RCClientes.OcxState = CType(resources.GetObject("RCClientes.OcxState"), System.Windows.Forms.AxHost.State)
        Me.RCClientes.Size = New System.Drawing.Size(587, 283)
        Me.RCClientes.TabIndex = 56
        '
        'Titulo
        '
        Me.Titulo.Enabled = True
        Me.Titulo.Location = New System.Drawing.Point(409, 12)
        Me.Titulo.Name = "Titulo"
        Me.Titulo.OcxState = CType(resources.GetObject("Titulo.OcxState"), System.Windows.Forms.AxHost.State)
        Me.Titulo.Size = New System.Drawing.Size(100, 50)
        Me.Titulo.TabIndex = 55
        '
        'lblTotal
        '
        Me.lblTotal.Location = New System.Drawing.Point(181, 395)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.OcxState = CType(resources.GetObject("lblTotal.OcxState"), System.Windows.Forms.AxHost.State)
        Me.lblTotal.Size = New System.Drawing.Size(420, 25)
        Me.lblTotal.TabIndex = 60
        '
        'FrmInformesCartasMante
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lblClientes)
        Me.Controls.Add(Me.cbMes)
        Me.Controls.Add(Me.lblcbMes)
        Me.Controls.Add(Me.RCClientes)
        Me.Controls.Add(Me.Titulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmInformesCartasMante"
        Me.Text = "Cartas de Mantenimiento"
        CType(Me.lblClientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblcbMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RCClientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Titulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblClientes As AxXtremeSuiteControls.AxLabel
    Public WithEvents cbMes As AxXtremeSuiteControls.AxComboBox
    Friend WithEvents lblcbMes As AxXtremeSuiteControls.AxLabel
    Friend WithEvents RCClientes As AxXtremeReportControl.AxReportControl
    Friend WithEvents Titulo As AxXtremeShortcutBar.AxShortcutCaption
    Friend WithEvents lblTotal As AxXtremeSuiteControls.AxLabel
End Class
