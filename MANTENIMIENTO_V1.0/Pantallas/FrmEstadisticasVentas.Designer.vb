<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEstadisticasVentas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEstadisticasVentas))
        Me.lblProductos = New AxXtremeSuiteControls.AxLabel()
        Me.lblPacks = New AxXtremeSuiteControls.AxLabel()
        Me.Titulo = New AxXtremeShortcutBar.AxShortcutCaption()
        Me.lblMantes = New AxXtremeSuiteControls.AxLabel()
        Me.lblClientesMante = New AxXtremeSuiteControls.AxLabel()
        Me.lblClientesProducto = New AxXtremeSuiteControls.AxLabel()
        Me.lblClientesPack = New AxXtremeSuiteControls.AxLabel()
        Me.lblcbTipo = New AxXtremeSuiteControls.AxLabel()
        Me.cbTipoProductos = New AxXtremeSuiteControls.AxComboBox()
        Me.RCClientes = New AxXtremeReportControl.AxReportControl()
        Me.lblClientes = New AxXtremeSuiteControls.AxLabel()
        Me.cbProductos = New AxXtremeSuiteControls.AxComboBox()
        Me.lblcbProducto = New AxXtremeSuiteControls.AxLabel()
        Me.lblVentas = New AxXtremeSuiteControls.AxLabel()
        Me.RCVentasMes = New AxXtremeReportControl.AxReportControl()
        Me.upVariacion = New AxXtremeSuiteControls.AxUpDown()
        Me.lblPrevision = New AxXtremeSuiteControls.AxLabel()
        Me.txtVariacion = New AxXtremeSuiteControls.AxFlatEdit()
        Me.btnActualiza = New AxXtremeSuiteControls.AxPushButton()
        Me.chSinPyM = New AxXtremeSuiteControls.AxCheckBox()
        Me.cbMail = New AxXtremeSuiteControls.AxComboBox()
        Me.lblCbMail = New AxXtremeSuiteControls.AxLabel()
        Me.cbTelefono = New AxXtremeSuiteControls.AxComboBox()
        Me.lblCbTelefono = New AxXtremeSuiteControls.AxLabel()
        Me.cbEnviar = New AxXtremeSuiteControls.AxComboBox()
        Me.lblEnviar = New AxXtremeSuiteControls.AxLabel()
        'CType(Me.lblProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblPacks, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.Titulo, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblMantes, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblClientesMante, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblClientesProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblClientesPack, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblcbTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.cbTipoProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.RCClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.cbProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblcbProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.RCVentasMes, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.upVariacion, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblPrevision, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.txtVariacion, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.btnActualiza, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.chSinPyM, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.cbMail, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblCbMail, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.cbTelefono, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblCbTelefono, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.cbEnviar, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.lblEnviar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblProductos
        '
        Me.lblProductos.Location = New System.Drawing.Point(1, 296)
        Me.lblProductos.Name = "lblProductos"
        Me.lblProductos.OcxState = CType(resources.GetObject("lblProductos.OcxState"), System.Windows.Forms.AxHost.State)
        Me.lblProductos.Size = New System.Drawing.Size(299, 20)
        Me.lblProductos.TabIndex = 46
        '
        'lblPacks
        '
        Me.lblPacks.Location = New System.Drawing.Point(1, 212)
        Me.lblPacks.Name = "lblPacks"
        Me.lblPacks.OcxState = CType(resources.GetObject("lblPacks.OcxState"), System.Windows.Forms.AxHost.State)
        Me.lblPacks.Size = New System.Drawing.Size(299, 20)
        Me.lblPacks.TabIndex = 45
        '
        'Titulo
        '
        Me.Titulo.Enabled = True
        Me.Titulo.Location = New System.Drawing.Point(392, 12)
        Me.Titulo.Name = "Titulo"
        Me.Titulo.OcxState = CType(resources.GetObject("Titulo.OcxState"), System.Windows.Forms.AxHost.State)
        Me.Titulo.Size = New System.Drawing.Size(100, 50)
        Me.Titulo.TabIndex = 44
        '
        'lblMantes
        '
        Me.lblMantes.Location = New System.Drawing.Point(1, 254)
        Me.lblMantes.Name = "lblMantes"
        Me.lblMantes.OcxState = CType(resources.GetObject("lblMantes.OcxState"), System.Windows.Forms.AxHost.State)
        Me.lblMantes.Size = New System.Drawing.Size(330, 20)
        Me.lblMantes.TabIndex = 47
        '
        'lblClientesMante
        '
        Me.lblClientesMante.Location = New System.Drawing.Point(1, 275)
        Me.lblClientesMante.Name = "lblClientesMante"
        Me.lblClientesMante.OcxState = CType(resources.GetObject("lblClientesMante.OcxState"), System.Windows.Forms.AxHost.State)
        Me.lblClientesMante.Size = New System.Drawing.Size(291, 20)
        Me.lblClientesMante.TabIndex = 50
        '
        'lblClientesProducto
        '
        Me.lblClientesProducto.Location = New System.Drawing.Point(1, 317)
        Me.lblClientesProducto.Name = "lblClientesProducto"
        Me.lblClientesProducto.OcxState = CType(resources.GetObject("lblClientesProducto.OcxState"), System.Windows.Forms.AxHost.State)
        Me.lblClientesProducto.Size = New System.Drawing.Size(291, 20)
        Me.lblClientesProducto.TabIndex = 49
        '
        'lblClientesPack
        '
        Me.lblClientesPack.Location = New System.Drawing.Point(1, 233)
        Me.lblClientesPack.Name = "lblClientesPack"
        Me.lblClientesPack.OcxState = CType(resources.GetObject("lblClientesPack.OcxState"), System.Windows.Forms.AxHost.State)
        Me.lblClientesPack.Size = New System.Drawing.Size(291, 20)
        Me.lblClientesPack.TabIndex = 48
        '
        'lblcbTipo
        '
        Me.lblcbTipo.Location = New System.Drawing.Point(1, 71)
        Me.lblcbTipo.Name = "lblcbTipo"
        Me.lblcbTipo.OcxState = CType(resources.GetObject("lblcbTipo.OcxState"), System.Windows.Forms.AxHost.State)
        Me.lblcbTipo.Size = New System.Drawing.Size(185, 25)
        Me.lblcbTipo.TabIndex = 53
        '
        'cbTipoProductos
        '
        Me.cbTipoProductos.Location = New System.Drawing.Point(1, 91)
        Me.cbTipoProductos.Name = "cbTipoProductos"
        Me.cbTipoProductos.OcxState = CType(resources.GetObject("cbTipoProductos.OcxState"), System.Windows.Forms.AxHost.State)
        Me.cbTipoProductos.Size = New System.Drawing.Size(131, 24)
        Me.cbTipoProductos.TabIndex = 52
        '
        'RCClientes
        '
        Me.RCClientes.Location = New System.Drawing.Point(298, 96)
        Me.RCClientes.Name = "RCClientes"
        Me.RCClientes.OcxState = CType(resources.GetObject("RCClientes.OcxState"), System.Windows.Forms.AxHost.State)
        Me.RCClientes.Size = New System.Drawing.Size(462, 236)
        Me.RCClientes.TabIndex = 51
        '
        'lblClientes
        '
        Me.lblClientes.Location = New System.Drawing.Point(298, 71)
        Me.lblClientes.Name = "lblClientes"
        Me.lblClientes.OcxState = CType(resources.GetObject("lblClientes.OcxState"), System.Windows.Forms.AxHost.State)
        Me.lblClientes.Size = New System.Drawing.Size(420, 25)
        Me.lblClientes.TabIndex = 54
        '
        'cbProductos
        '
        Me.cbProductos.Location = New System.Drawing.Point(138, 91)
        Me.cbProductos.Name = "cbProductos"
        Me.cbProductos.OcxState = CType(resources.GetObject("cbProductos.OcxState"), System.Windows.Forms.AxHost.State)
        Me.cbProductos.Size = New System.Drawing.Size(131, 24)
        Me.cbProductos.TabIndex = 55
        '
        'lblcbProducto
        '
        Me.lblcbProducto.Location = New System.Drawing.Point(138, 71)
        Me.lblcbProducto.Name = "lblcbProducto"
        Me.lblcbProducto.OcxState = CType(resources.GetObject("lblcbProducto.OcxState"), System.Windows.Forms.AxHost.State)
        Me.lblcbProducto.Size = New System.Drawing.Size(185, 25)
        Me.lblcbProducto.TabIndex = 56
        '
        'lblVentas
        '
        Me.lblVentas.Location = New System.Drawing.Point(298, 351)
        Me.lblVentas.Name = "lblVentas"
        Me.lblVentas.OcxState = CType(resources.GetObject("lblVentas.OcxState"), System.Windows.Forms.AxHost.State)
        Me.lblVentas.Size = New System.Drawing.Size(287, 25)
        Me.lblVentas.TabIndex = 58
        '
        'RCVentasMes
        '
        Me.RCVentasMes.Location = New System.Drawing.Point(298, 378)
        Me.RCVentasMes.Name = "RCVentasMes"
        Me.RCVentasMes.OcxState = CType(resources.GetObject("RCVentasMes.OcxState"), System.Windows.Forms.AxHost.State)
        Me.RCVentasMes.Size = New System.Drawing.Size(462, 106)
        Me.RCVentasMes.TabIndex = 57
        '
        'upVariacion
        '
        Me.upVariacion.Location = New System.Drawing.Point(188, 424)
        Me.upVariacion.Name = "upVariacion"
        Me.upVariacion.OcxState = CType(resources.GetObject("upVariacion.OcxState"), System.Windows.Forms.AxHost.State)
        Me.upVariacion.Size = New System.Drawing.Size(17, 29)
        Me.upVariacion.TabIndex = 59
        '
        'lblPrevision
        '
        Me.lblPrevision.Location = New System.Drawing.Point(12, 414)
        Me.lblPrevision.Name = "lblPrevision"
        Me.lblPrevision.OcxState = CType(resources.GetObject("lblPrevision.OcxState"), System.Windows.Forms.AxHost.State)
        Me.lblPrevision.Size = New System.Drawing.Size(170, 51)
        Me.lblPrevision.TabIndex = 60
        '
        'txtVariacion
        '
        Me.txtVariacion.Location = New System.Drawing.Point(203, 424)
        Me.txtVariacion.Name = "txtVariacion"
        Me.txtVariacion.OcxState = CType(resources.GetObject("txtVariacion.OcxState"), System.Windows.Forms.AxHost.State)
        Me.txtVariacion.Size = New System.Drawing.Size(66, 29)
        Me.txtVariacion.TabIndex = 61
        '
        'btnActualiza
        '
        Me.btnActualiza.Location = New System.Drawing.Point(203, 459)
        Me.btnActualiza.Name = "btnActualiza"
        Me.btnActualiza.OcxState = CType(resources.GetObject("btnActualiza.OcxState"), System.Windows.Forms.AxHost.State)
        Me.btnActualiza.Size = New System.Drawing.Size(66, 22)
        Me.btnActualiza.TabIndex = 62
        '
        'chSinPyM
        '
        Me.chSinPyM.Location = New System.Drawing.Point(138, 119)
        Me.chSinPyM.Name = "chSinPyM"
        Me.chSinPyM.OcxState = CType(resources.GetObject("chSinPyM.OcxState"), System.Windows.Forms.AxHost.State)
        Me.chSinPyM.Size = New System.Drawing.Size(131, 50)
        Me.chSinPyM.TabIndex = 63
        '
        'cbMail
        '
        Me.cbMail.Location = New System.Drawing.Point(138, 185)
        Me.cbMail.Name = "cbMail"
        Me.cbMail.OcxState = CType(resources.GetObject("cbMail.OcxState"), System.Windows.Forms.AxHost.State)
        Me.cbMail.Size = New System.Drawing.Size(131, 24)
        Me.cbMail.TabIndex = 66
        '
        'lblCbMail
        '
        Me.lblCbMail.Location = New System.Drawing.Point(138, 165)
        Me.lblCbMail.Name = "lblCbMail"
        Me.lblCbMail.OcxState = CType(resources.GetObject("lblCbMail.OcxState"), System.Windows.Forms.AxHost.State)
        Me.lblCbMail.Size = New System.Drawing.Size(131, 25)
        Me.lblCbMail.TabIndex = 67
        '
        'cbTelefono
        '
        Me.cbTelefono.Location = New System.Drawing.Point(1, 185)
        Me.cbTelefono.Name = "cbTelefono"
        Me.cbTelefono.OcxState = CType(resources.GetObject("cbTelefono.OcxState"), System.Windows.Forms.AxHost.State)
        Me.cbTelefono.Size = New System.Drawing.Size(131, 24)
        Me.cbTelefono.TabIndex = 64
        '
        'lblCbTelefono
        '
        Me.lblCbTelefono.Location = New System.Drawing.Point(1, 165)
        Me.lblCbTelefono.Name = "lblCbTelefono"
        Me.lblCbTelefono.OcxState = CType(resources.GetObject("lblCbTelefono.OcxState"), System.Windows.Forms.AxHost.State)
        Me.lblCbTelefono.Size = New System.Drawing.Size(150, 25)
        Me.lblCbTelefono.TabIndex = 65
        '
        'cbEnviar
        '
        Me.cbEnviar.Location = New System.Drawing.Point(1, 135)
        Me.cbEnviar.Name = "cbEnviar"
        Me.cbEnviar.OcxState = CType(resources.GetObject("cbEnviar.OcxState"), System.Windows.Forms.AxHost.State)
        Me.cbEnviar.Size = New System.Drawing.Size(131, 24)
        Me.cbEnviar.TabIndex = 68
        '
        'lblEnviar
        '
        Me.lblEnviar.Location = New System.Drawing.Point(1, 115)
        Me.lblEnviar.Name = "lblEnviar"
        Me.lblEnviar.OcxState = CType(resources.GetObject("lblEnviar.OcxState"), System.Windows.Forms.AxHost.State)
        Me.lblEnviar.Size = New System.Drawing.Size(131, 25)
        Me.lblEnviar.TabIndex = 69
        '
        'FrmEstadisticasVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 540)
        Me.Controls.Add(Me.cbEnviar)
        Me.Controls.Add(Me.lblEnviar)
        Me.Controls.Add(Me.cbMail)
        Me.Controls.Add(Me.lblCbMail)
        Me.Controls.Add(Me.cbTelefono)
        Me.Controls.Add(Me.lblCbTelefono)
        Me.Controls.Add(Me.chSinPyM)
        Me.Controls.Add(Me.btnActualiza)
        Me.Controls.Add(Me.txtVariacion)
        Me.Controls.Add(Me.lblPrevision)
        Me.Controls.Add(Me.upVariacion)
        Me.Controls.Add(Me.lblVentas)
        Me.Controls.Add(Me.RCVentasMes)
        Me.Controls.Add(Me.lblClientes)
        Me.Controls.Add(Me.cbProductos)
        Me.Controls.Add(Me.lblcbProducto)
        Me.Controls.Add(Me.cbTipoProductos)
        Me.Controls.Add(Me.lblcbTipo)
        Me.Controls.Add(Me.RCClientes)
        Me.Controls.Add(Me.lblClientesMante)
        Me.Controls.Add(Me.lblClientesProducto)
        Me.Controls.Add(Me.lblClientesPack)
        Me.Controls.Add(Me.lblMantes)
        Me.Controls.Add(Me.lblProductos)
        Me.Controls.Add(Me.lblPacks)
        Me.Controls.Add(Me.Titulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmEstadisticasVentas"
        Me.Text = "Estadísticas"
        'CType(Me.lblProductos, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lblPacks, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.Titulo, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lblMantes, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lblClientesMante, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lblClientesProducto, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lblClientesPack, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lblcbTipo, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.cbTipoProductos, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.RCClientes, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lblClientes, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.cbProductos, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lblcbProducto, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lblVentas, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.RCVentasMes, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.upVariacion, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lblPrevision, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.txtVariacion, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.btnActualiza, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.chSinPyM, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.cbMail, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lblCbMail, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.cbTelefono, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lblCbTelefono, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.cbEnviar, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.lblEnviar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblProductos As AxXtremeSuiteControls.AxLabel
    Friend WithEvents lblPacks As AxXtremeSuiteControls.AxLabel
    Friend WithEvents Titulo As AxXtremeShortcutBar.AxShortcutCaption
    Friend WithEvents lblMantes As AxXtremeSuiteControls.AxLabel
    Friend WithEvents lblClientesMante As AxXtremeSuiteControls.AxLabel
    Friend WithEvents lblClientesProducto As AxXtremeSuiteControls.AxLabel
    Friend WithEvents lblClientesPack As AxXtremeSuiteControls.AxLabel
    Friend WithEvents lblcbTipo As AxXtremeSuiteControls.AxLabel
    Friend WithEvents RCClientes As AxXtremeReportControl.AxReportControl
    Friend WithEvents lblClientes As AxXtremeSuiteControls.AxLabel
    Friend WithEvents lblcbProducto As AxXtremeSuiteControls.AxLabel
    Friend WithEvents lblVentas As AxXtremeSuiteControls.AxLabel
    Friend WithEvents RCVentasMes As AxXtremeReportControl.AxReportControl
    Friend WithEvents upVariacion As AxXtremeSuiteControls.AxUpDown
    Friend WithEvents lblPrevision As AxXtremeSuiteControls.AxLabel
    Friend WithEvents txtVariacion As AxXtremeSuiteControls.AxFlatEdit
    Friend WithEvents btnActualiza As AxXtremeSuiteControls.AxPushButton
    Public WithEvents cbTipoProductos As AxXtremeSuiteControls.AxComboBox
    Public WithEvents cbProductos As AxXtremeSuiteControls.AxComboBox
    Friend WithEvents chSinPyM As AxXtremeSuiteControls.AxCheckBox
    Public WithEvents cbMail As AxXtremeSuiteControls.AxComboBox
    Friend WithEvents lblCbMail As AxXtremeSuiteControls.AxLabel
    Public WithEvents cbTelefono As AxXtremeSuiteControls.AxComboBox
    Friend WithEvents lblCbTelefono As AxXtremeSuiteControls.AxLabel
    Public WithEvents cbEnviar As AxXtremeSuiteControls.AxComboBox
    Friend WithEvents lblEnviar As AxXtremeSuiteControls.AxLabel
End Class
