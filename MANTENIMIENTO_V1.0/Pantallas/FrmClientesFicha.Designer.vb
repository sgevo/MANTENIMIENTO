<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmClientesFicha
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmClientesFicha))
        Me.Titulo = New AxXtremeShortcutBar.AxShortcutCaption()
        Me.RCClientes2 = New AxXtremeReportControl.AxReportControl()
        Me.RCClientes = New AxXtremeReportControl.AxReportControl()
        CType(Me.Titulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RCClientes2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RCClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Titulo
        '
        Me.Titulo.Enabled = True
        Me.Titulo.Location = New System.Drawing.Point(56, 31)
        Me.Titulo.Name = "Titulo"
        Me.Titulo.OcxState = CType(resources.GetObject("Titulo.OcxState"), System.Windows.Forms.AxHost.State)
        Me.Titulo.Size = New System.Drawing.Size(148, 46)
        Me.Titulo.TabIndex = 16
        '
        'RCClientes2
        '
        Me.RCClientes2.Location = New System.Drawing.Point(146, 56)
        Me.RCClientes2.Name = "RCClientes2"
        Me.RCClientes2.OcxState = CType(resources.GetObject("RCClientes2.OcxState"), System.Windows.Forms.AxHost.State)
        Me.RCClientes2.Size = New System.Drawing.Size(642, 427)
        Me.RCClientes2.TabIndex = 18
        '
        'RCClientes
        '
        Me.RCClientes.Location = New System.Drawing.Point(27, 12)
        Me.RCClientes.Name = "RCClientes"
        Me.RCClientes.OcxState = CType(resources.GetObject("RCClientes.OcxState"), System.Windows.Forms.AxHost.State)
        Me.RCClientes.Size = New System.Drawing.Size(642, 427)
        Me.RCClientes.TabIndex = 19
        '
        'FrmClientesFicha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.RCClientes)
        Me.Controls.Add(Me.RCClientes2)
        Me.Controls.Add(Me.Titulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmClientesFicha"
        Me.Text = "Clientes"
        CType(Me.Titulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RCClientes2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RCClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Titulo As AxXtremeShortcutBar.AxShortcutCaption
    Friend WithEvents RCClientes2 As AxXtremeReportControl.AxReportControl
    Public WithEvents RCClientes As AxXtremeReportControl.AxReportControl
End Class
