<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPedidosFichero
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPedidosFichero))
        Me.Titulo = New AxXtremeShortcutBar.AxShortcutCaption()
        Me.RCPedidos = New AxXtremeReportControl.AxReportControl()
        Me.gbFiltro = New System.Windows.Forms.GroupBox()
        Me.cbAños = New AxXtremeSuiteControls.AxComboBox()
        Me.mes7 = New AxXtremeSuiteControls.AxPushButton()
        Me.mes12 = New AxXtremeSuiteControls.AxPushButton()
        Me.mes11 = New AxXtremeSuiteControls.AxPushButton()
        Me.mes10 = New AxXtremeSuiteControls.AxPushButton()
        Me.mes9 = New AxXtremeSuiteControls.AxPushButton()
        Me.mes8 = New AxXtremeSuiteControls.AxPushButton()
        Me.mes1 = New AxXtremeSuiteControls.AxPushButton()
        Me.mes6 = New AxXtremeSuiteControls.AxPushButton()
        Me.mes5 = New AxXtremeSuiteControls.AxPushButton()
        Me.mes4 = New AxXtremeSuiteControls.AxPushButton()
        Me.mes3 = New AxXtremeSuiteControls.AxPushButton()
        Me.mes2 = New AxXtremeSuiteControls.AxPushButton()
        CType(Me.Titulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RCPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFiltro.SuspendLayout()
        CType(Me.cbAños, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mes7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mes12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mes11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mes10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mes9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mes8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mes1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mes6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mes5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mes4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mes3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mes2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Titulo
        '
        Me.Titulo.Enabled = True
        Me.Titulo.Location = New System.Drawing.Point(157, 56)
        Me.Titulo.Name = "Titulo"
        Me.Titulo.OcxState = CType(resources.GetObject("Titulo.OcxState"), System.Windows.Forms.AxHost.State)
        Me.Titulo.Size = New System.Drawing.Size(712, 54)
        Me.Titulo.TabIndex = 3
        '
        'RCPedidos
        '
        Me.RCPedidos.Location = New System.Drawing.Point(157, 145)
        Me.RCPedidos.Name = "RCPedidos"
        Me.RCPedidos.OcxState = CType(resources.GetObject("RCPedidos.OcxState"), System.Windows.Forms.AxHost.State)
        Me.RCPedidos.Size = New System.Drawing.Size(712, 328)
        Me.RCPedidos.TabIndex = 2
        '
        'gbFiltro
        '
        Me.gbFiltro.BackColor = System.Drawing.SystemColors.Control
        Me.gbFiltro.Controls.Add(Me.cbAños)
        Me.gbFiltro.Controls.Add(Me.mes7)
        Me.gbFiltro.Controls.Add(Me.mes12)
        Me.gbFiltro.Controls.Add(Me.mes11)
        Me.gbFiltro.Controls.Add(Me.mes10)
        Me.gbFiltro.Controls.Add(Me.mes9)
        Me.gbFiltro.Controls.Add(Me.mes8)
        Me.gbFiltro.Controls.Add(Me.mes1)
        Me.gbFiltro.Controls.Add(Me.mes6)
        Me.gbFiltro.Controls.Add(Me.mes5)
        Me.gbFiltro.Controls.Add(Me.mes4)
        Me.gbFiltro.Controls.Add(Me.mes3)
        Me.gbFiltro.Controls.Add(Me.mes2)
        Me.gbFiltro.Location = New System.Drawing.Point(12, 12)
        Me.gbFiltro.Name = "gbFiltro"
        Me.gbFiltro.Size = New System.Drawing.Size(108, 566)
        Me.gbFiltro.TabIndex = 4
        Me.gbFiltro.TabStop = False
        '
        'cbAños
        '
        Me.cbAños.Location = New System.Drawing.Point(6, 516)
        Me.cbAños.Name = "cbAños"
        Me.cbAños.OcxState = CType(resources.GetObject("cbAños.OcxState"), System.Windows.Forms.AxHost.State)
        Me.cbAños.Size = New System.Drawing.Size(96, 21)
        Me.cbAños.TabIndex = 13
        '
        'mes7
        '
        Me.mes7.Location = New System.Drawing.Point(6, 253)
        Me.mes7.Name = "mes7"
        Me.mes7.OcxState = CType(resources.GetObject("mes7.OcxState"), System.Windows.Forms.AxHost.State)
        Me.mes7.Size = New System.Drawing.Size(96, 33)
        Me.mes7.TabIndex = 12
        '
        'mes12
        '
        Me.mes12.Location = New System.Drawing.Point(6, 448)
        Me.mes12.Name = "mes12"
        Me.mes12.OcxState = CType(resources.GetObject("mes12.OcxState"), System.Windows.Forms.AxHost.State)
        Me.mes12.Size = New System.Drawing.Size(96, 33)
        Me.mes12.TabIndex = 11
        '
        'mes11
        '
        Me.mes11.Location = New System.Drawing.Point(6, 409)
        Me.mes11.Name = "mes11"
        Me.mes11.OcxState = CType(resources.GetObject("mes11.OcxState"), System.Windows.Forms.AxHost.State)
        Me.mes11.Size = New System.Drawing.Size(96, 33)
        Me.mes11.TabIndex = 10
        '
        'mes10
        '
        Me.mes10.Location = New System.Drawing.Point(6, 370)
        Me.mes10.Name = "mes10"
        Me.mes10.OcxState = CType(resources.GetObject("mes10.OcxState"), System.Windows.Forms.AxHost.State)
        Me.mes10.Size = New System.Drawing.Size(96, 33)
        Me.mes10.TabIndex = 9
        '
        'mes9
        '
        Me.mes9.Location = New System.Drawing.Point(6, 331)
        Me.mes9.Name = "mes9"
        Me.mes9.OcxState = CType(resources.GetObject("mes9.OcxState"), System.Windows.Forms.AxHost.State)
        Me.mes9.Size = New System.Drawing.Size(96, 33)
        Me.mes9.TabIndex = 8
        '
        'mes8
        '
        Me.mes8.Location = New System.Drawing.Point(6, 292)
        Me.mes8.Name = "mes8"
        Me.mes8.OcxState = CType(resources.GetObject("mes8.OcxState"), System.Windows.Forms.AxHost.State)
        Me.mes8.Size = New System.Drawing.Size(96, 33)
        Me.mes8.TabIndex = 7
        '
        'mes1
        '
        Me.mes1.Location = New System.Drawing.Point(6, 19)
        Me.mes1.Name = "mes1"
        Me.mes1.OcxState = CType(resources.GetObject("mes1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.mes1.Size = New System.Drawing.Size(96, 33)
        Me.mes1.TabIndex = 6
        '
        'mes6
        '
        Me.mes6.Location = New System.Drawing.Point(6, 214)
        Me.mes6.Name = "mes6"
        Me.mes6.OcxState = CType(resources.GetObject("mes6.OcxState"), System.Windows.Forms.AxHost.State)
        Me.mes6.Size = New System.Drawing.Size(96, 33)
        Me.mes6.TabIndex = 5
        '
        'mes5
        '
        Me.mes5.Location = New System.Drawing.Point(6, 175)
        Me.mes5.Name = "mes5"
        Me.mes5.OcxState = CType(resources.GetObject("mes5.OcxState"), System.Windows.Forms.AxHost.State)
        Me.mes5.Size = New System.Drawing.Size(96, 33)
        Me.mes5.TabIndex = 4
        '
        'mes4
        '
        Me.mes4.Location = New System.Drawing.Point(6, 136)
        Me.mes4.Name = "mes4"
        Me.mes4.OcxState = CType(resources.GetObject("mes4.OcxState"), System.Windows.Forms.AxHost.State)
        Me.mes4.Size = New System.Drawing.Size(96, 33)
        Me.mes4.TabIndex = 3
        '
        'mes3
        '
        Me.mes3.Location = New System.Drawing.Point(6, 97)
        Me.mes3.Name = "mes3"
        Me.mes3.OcxState = CType(resources.GetObject("mes3.OcxState"), System.Windows.Forms.AxHost.State)
        Me.mes3.Size = New System.Drawing.Size(96, 33)
        Me.mes3.TabIndex = 2
        '
        'mes2
        '
        Me.mes2.Location = New System.Drawing.Point(6, 58)
        Me.mes2.Name = "mes2"
        Me.mes2.OcxState = CType(resources.GetObject("mes2.OcxState"), System.Windows.Forms.AxHost.State)
        Me.mes2.Size = New System.Drawing.Size(96, 33)
        Me.mes2.TabIndex = 1
        '
        'FrmPedidosFichero
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1061, 590)
        Me.Controls.Add(Me.gbFiltro)
        Me.Controls.Add(Me.Titulo)
        Me.Controls.Add(Me.RCPedidos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmPedidosFichero"
        Me.Text = "FrmPedidosFichero"
        CType(Me.Titulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RCPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFiltro.ResumeLayout(False)
        CType(Me.cbAños, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mes7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mes12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mes11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mes10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mes9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mes8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mes1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mes6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mes5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mes4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mes3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mes2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Titulo As AxShortcutCaption
    Friend WithEvents RCPedidos As AxReportControl
    Friend WithEvents gbFiltro As Windows.Forms.GroupBox
    Friend WithEvents mes2 As AxPushButton
    Friend WithEvents mes3 As AxPushButton
    Friend WithEvents mes1 As AxPushButton
    Friend WithEvents mes6 As AxPushButton
    Friend WithEvents mes5 As AxPushButton
    Friend WithEvents mes4 As AxPushButton
    Friend WithEvents mes7 As AxPushButton
    Friend WithEvents mes12 As AxPushButton
    Friend WithEvents mes11 As AxPushButton
    Friend WithEvents mes10 As AxPushButton
    Friend WithEvents mes9 As AxPushButton
    Friend WithEvents mes8 As AxPushButton
    Friend WithEvents cbAños As AxComboBox
End Class
