<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmClientesFichero
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmClientesFichero))
        Me.RCClientes = New AxXtremeReportControl.AxReportControl()
        Me.Titulo = New AxXtremeShortcutBar.AxShortcutCaption()
        Me.gbFiltroAvanzado = New System.Windows.Forms.Panel()
        Me.btnAplicarFiltro = New AxXtremeSuiteControls.AxPushButton()
        Me.btnRestaurar = New AxXtremeSuiteControls.AxPushButton()
        Me.tbClienteHasta = New AxXtremeSuiteControls.AxFlatEdit()
        Me.AxLabel2 = New AxXtremeSuiteControls.AxLabel()
        Me.AxLabel1 = New AxXtremeSuiteControls.AxLabel()
        Me.tbClienteDesde = New AxXtremeSuiteControls.AxFlatEdit()
        Me.gbVistas = New System.Windows.Forms.Panel()
        Me.AxWebBrowser1 = New AxXtremeSuiteControls.AxWebBrowser()
        Me.AxPushButton4 = New AxXtremeSuiteControls.AxPushButton()
        Me.AxPushButton3 = New AxXtremeSuiteControls.AxPushButton()
        Me.AxLabel4 = New AxXtremeSuiteControls.AxLabel()
        Me.AxPushButton2 = New AxXtremeSuiteControls.AxPushButton()
        Me.AxLabel3 = New AxXtremeSuiteControls.AxLabel()
        Me.AxFlatEdit1 = New AxXtremeSuiteControls.AxFlatEdit()
        Me.AxPushButton1 = New AxXtremeSuiteControls.AxPushButton()
        Me.cbVistas = New AxXtremeSuiteControls.AxComboBox()
        CType(Me.RCClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Titulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFiltroAvanzado.SuspendLayout()
        CType(Me.btnAplicarFiltro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnRestaurar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbClienteHasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbClienteDesde, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbVistas.SuspendLayout()
        CType(Me.AxWebBrowser1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxPushButton4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxPushButton3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxPushButton2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxFlatEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxPushButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbVistas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RCClientes
        '
        Me.RCClientes.Location = New System.Drawing.Point(285, 248)
        Me.RCClientes.Name = "RCClientes"
        Me.RCClientes.OcxState = CType(resources.GetObject("RCClientes.OcxState"), System.Windows.Forms.AxHost.State)
        Me.RCClientes.Size = New System.Drawing.Size(458, 216)
        Me.RCClientes.TabIndex = 0
        '
        'Titulo
        '
        Me.Titulo.Enabled = True
        Me.Titulo.Location = New System.Drawing.Point(130, 128)
        Me.Titulo.Name = "Titulo"
        Me.Titulo.OcxState = CType(resources.GetObject("Titulo.OcxState"), System.Windows.Forms.AxHost.State)
        Me.Titulo.Size = New System.Drawing.Size(292, 54)
        Me.Titulo.TabIndex = 1
        '
        'gbFiltroAvanzado
        '
        Me.gbFiltroAvanzado.Controls.Add(Me.btnAplicarFiltro)
        Me.gbFiltroAvanzado.Controls.Add(Me.btnRestaurar)
        Me.gbFiltroAvanzado.Controls.Add(Me.tbClienteHasta)
        Me.gbFiltroAvanzado.Controls.Add(Me.AxLabel2)
        Me.gbFiltroAvanzado.Controls.Add(Me.AxLabel1)
        Me.gbFiltroAvanzado.Controls.Add(Me.tbClienteDesde)
        Me.gbFiltroAvanzado.Location = New System.Drawing.Point(29, 75)
        Me.gbFiltroAvanzado.Name = "gbFiltroAvanzado"
        Me.gbFiltroAvanzado.Size = New System.Drawing.Size(702, 66)
        Me.gbFiltroAvanzado.TabIndex = 2
        Me.gbFiltroAvanzado.Visible = False
        '
        'btnAplicarFiltro
        '
        Me.btnAplicarFiltro.Location = New System.Drawing.Point(558, 20)
        Me.btnAplicarFiltro.Name = "btnAplicarFiltro"
        Me.btnAplicarFiltro.OcxState = CType(resources.GetObject("btnAplicarFiltro.OcxState"), System.Windows.Forms.AxHost.State)
        Me.btnAplicarFiltro.Size = New System.Drawing.Size(100, 29)
        Me.btnAplicarFiltro.TabIndex = 2
        '
        'btnRestaurar
        '
        Me.btnRestaurar.Location = New System.Drawing.Point(437, 20)
        Me.btnRestaurar.Name = "btnRestaurar"
        Me.btnRestaurar.OcxState = CType(resources.GetObject("btnRestaurar.OcxState"), System.Windows.Forms.AxHost.State)
        Me.btnRestaurar.Size = New System.Drawing.Size(100, 29)
        Me.btnRestaurar.TabIndex = 3
        '
        'tbClienteHasta
        '
        Me.tbClienteHasta.Location = New System.Drawing.Point(284, 20)
        Me.tbClienteHasta.Name = "tbClienteHasta"
        Me.tbClienteHasta.OcxState = CType(resources.GetObject("tbClienteHasta.OcxState"), System.Windows.Forms.AxHost.State)
        Me.tbClienteHasta.Size = New System.Drawing.Size(104, 27)
        Me.tbClienteHasta.TabIndex = 1
        '
        'AxLabel2
        '
        Me.AxLabel2.Location = New System.Drawing.Point(251, 22)
        Me.AxLabel2.Name = "AxLabel2"
        Me.AxLabel2.OcxState = CType(resources.GetObject("AxLabel2.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxLabel2.Size = New System.Drawing.Size(17, 27)
        Me.AxLabel2.TabIndex = 2
        '
        'AxLabel1
        '
        Me.AxLabel1.Location = New System.Drawing.Point(19, 20)
        Me.AxLabel1.Name = "AxLabel1"
        Me.AxLabel1.OcxState = CType(resources.GetObject("AxLabel1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxLabel1.Size = New System.Drawing.Size(103, 27)
        Me.AxLabel1.TabIndex = 1
        '
        'tbClienteDesde
        '
        Me.tbClienteDesde.Location = New System.Drawing.Point(128, 20)
        Me.tbClienteDesde.Name = "tbClienteDesde"
        Me.tbClienteDesde.OcxState = CType(resources.GetObject("tbClienteDesde.OcxState"), System.Windows.Forms.AxHost.State)
        Me.tbClienteDesde.Size = New System.Drawing.Size(104, 27)
        Me.tbClienteDesde.TabIndex = 0
        '
        'gbVistas
        '
        Me.gbVistas.Controls.Add(Me.AxWebBrowser1)
        Me.gbVistas.Controls.Add(Me.AxPushButton4)
        Me.gbVistas.Controls.Add(Me.AxPushButton3)
        Me.gbVistas.Controls.Add(Me.AxLabel4)
        Me.gbVistas.Controls.Add(Me.AxPushButton2)
        Me.gbVistas.Controls.Add(Me.AxLabel3)
        Me.gbVistas.Controls.Add(Me.AxFlatEdit1)
        Me.gbVistas.Controls.Add(Me.AxPushButton1)
        Me.gbVistas.Controls.Add(Me.cbVistas)
        Me.gbVistas.Location = New System.Drawing.Point(12, 222)
        Me.gbVistas.Name = "gbVistas"
        Me.gbVistas.Size = New System.Drawing.Size(1102, 56)
        Me.gbVistas.TabIndex = 3
        Me.gbVistas.Visible = False
        '
        'AxWebBrowser1
        '
        Me.AxWebBrowser1.Enabled = True
        Me.AxWebBrowser1.Location = New System.Drawing.Point(483, 61)
        Me.AxWebBrowser1.Name = "AxWebBrowser1"
        Me.AxWebBrowser1.OcxState = CType(resources.GetObject("AxWebBrowser1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxWebBrowser1.Size = New System.Drawing.Size(100, 50)
        Me.AxWebBrowser1.TabIndex = 11
        '
        'AxPushButton4
        '
        Me.AxPushButton4.Location = New System.Drawing.Point(975, 16)
        Me.AxPushButton4.Name = "AxPushButton4"
        Me.AxPushButton4.OcxState = CType(resources.GetObject("AxPushButton4.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxPushButton4.Size = New System.Drawing.Size(100, 29)
        Me.AxPushButton4.TabIndex = 10
        '
        'AxPushButton3
        '
        Me.AxPushButton3.Location = New System.Drawing.Point(858, 16)
        Me.AxPushButton3.Name = "AxPushButton3"
        Me.AxPushButton3.OcxState = CType(resources.GetObject("AxPushButton3.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxPushButton3.Size = New System.Drawing.Size(100, 29)
        Me.AxPushButton3.TabIndex = 9
        '
        'AxLabel4
        '
        Me.AxLabel4.Location = New System.Drawing.Point(441, 16)
        Me.AxLabel4.Name = "AxLabel4"
        Me.AxLabel4.OcxState = CType(resources.GetObject("AxLabel4.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxLabel4.Size = New System.Drawing.Size(72, 24)
        Me.AxLabel4.TabIndex = 8
        '
        'AxPushButton2
        '
        Me.AxPushButton2.Location = New System.Drawing.Point(275, 16)
        Me.AxPushButton2.Name = "AxPushButton2"
        Me.AxPushButton2.OcxState = CType(resources.GetObject("AxPushButton2.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxPushButton2.Size = New System.Drawing.Size(100, 29)
        Me.AxPushButton2.TabIndex = 7
        '
        'AxLabel3
        '
        Me.AxLabel3.Location = New System.Drawing.Point(7, 16)
        Me.AxLabel3.Name = "AxLabel3"
        Me.AxLabel3.OcxState = CType(resources.GetObject("AxLabel3.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxLabel3.Size = New System.Drawing.Size(103, 24)
        Me.AxLabel3.TabIndex = 6
        '
        'AxFlatEdit1
        '
        Me.AxFlatEdit1.Location = New System.Drawing.Point(116, 16)
        Me.AxFlatEdit1.Name = "AxFlatEdit1"
        Me.AxFlatEdit1.OcxState = CType(resources.GetObject("AxFlatEdit1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxFlatEdit1.Size = New System.Drawing.Size(151, 27)
        Me.AxFlatEdit1.TabIndex = 5
        '
        'AxPushButton1
        '
        Me.AxPushButton1.Location = New System.Drawing.Point(717, 16)
        Me.AxPushButton1.Name = "AxPushButton1"
        Me.AxPushButton1.OcxState = CType(resources.GetObject("AxPushButton1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxPushButton1.Size = New System.Drawing.Size(100, 29)
        Me.AxPushButton1.TabIndex = 4
        '
        'cbVistas
        '
        Me.cbVistas.Location = New System.Drawing.Point(519, 16)
        Me.cbVistas.Name = "cbVistas"
        Me.cbVistas.OcxState = CType(resources.GetObject("cbVistas.OcxState"), System.Windows.Forms.AxHost.State)
        Me.cbVistas.Size = New System.Drawing.Size(192, 27)
        Me.cbVistas.TabIndex = 0
        '
        'FrmClientesFichero
        '
        Me.ClientSize = New System.Drawing.Size(1097, 512)
        Me.Controls.Add(Me.gbVistas)
        Me.Controls.Add(Me.gbFiltroAvanzado)
        Me.Controls.Add(Me.Titulo)
        Me.Controls.Add(Me.RCClientes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmClientesFichero"
        Me.Text = "Clientes"
        CType(Me.RCClientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Titulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFiltroAvanzado.ResumeLayout(False)
        CType(Me.btnAplicarFiltro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnRestaurar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbClienteHasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbClienteDesde, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbVistas.ResumeLayout(False)
        CType(Me.AxWebBrowser1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxPushButton4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxPushButton3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxPushButton2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxFlatEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxPushButton1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbVistas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Titulo As AxXtremeShortcutBar.AxShortcutCaption
    Friend WithEvents RCClientes As AXReportControl
    Friend WithEvents gbFiltroAvanzado As Panel
    Friend WithEvents btnAplicarFiltro As AxPushButton
    Friend WithEvents btnRestaurar As AxPushButton
    Friend WithEvents tbClienteHasta As AxFlatEdit
    Friend WithEvents AxLabel2 As AxLabel
    Friend WithEvents AxLabel1 As AxLabel
    Friend WithEvents tbClienteDesde As AxFlatEdit
    Friend WithEvents gbVistas As Panel
    Friend WithEvents AxPushButton2 As AxPushButton
    Friend WithEvents AxLabel3 As AxLabel
    Friend WithEvents AxFlatEdit1 As AxFlatEdit
    Friend WithEvents AxPushButton1 As AxPushButton
    Friend WithEvents cbVistas As AxComboBox
    Friend WithEvents AxLabel4 As AxLabel
    Friend WithEvents AxPushButton4 As AxPushButton
    Friend WithEvents AxPushButton3 As AxPushButton
    Friend WithEvents AxWebBrowser1 As AxWebBrowser
End Class
