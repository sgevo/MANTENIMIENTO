<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsultaMantenimiento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConsultaMantenimiento))
        Me.RCMantenimientos = New AxXtremeReportControl.AxReportControl()
        Me.GrupoTxtRealizado = New AxXtremeSuiteControls.AxFlatEdit()
        Me.GrupoLblDonde = New AxXtremeSuiteControls.AxLabel()
        Me.GrupoTxtDonde = New AxXtremeSuiteControls.AxFlatEdit()
        Me.GrupoTxtSubtrabajo = New AxXtremeSuiteControls.AxFlatEdit()
        Me.GrupoLblSubtrabajo = New AxXtremeSuiteControls.AxLabel()
        Me.GrupoLblTrabajo = New AxXtremeSuiteControls.AxLabel()
        Me.GrupoLblProducto = New AxXtremeSuiteControls.AxLabel()
        Me.GrupoCbTema = New AxXtremeSuiteControls.AxComboBox()
        Me.GrupoCbProducto = New AxXtremeSuiteControls.AxComboBox()
        Me.GrupoCbTrabajo = New AxXtremeSuiteControls.AxComboBox()
        Me.GrupoLblTema = New AxXtremeSuiteControls.AxLabel()
        Me.Titulo = New AxXtremeShortcutBar.AxShortcutCaption()
        Me.GrupoLblRealizado = New AxXtremeSuiteControls.AxLabel()
        Me.btnSalir = New AxXtremeCommandBars.AxBackstageButton()
        Me.gbTodo = New AxXtremeSuiteControls.AxGroupBox()
        Me.btnBuscar = New AxXtremeCommandBars.AxBackstageButton()
        CType(Me.RCMantenimientos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrupoTxtRealizado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrupoLblDonde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrupoTxtDonde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrupoTxtSubtrabajo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrupoLblSubtrabajo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrupoLblTrabajo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrupoLblProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrupoCbTema, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrupoCbProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrupoCbTrabajo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrupoLblTema, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Titulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrupoLblRealizado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSalir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbTodo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnBuscar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RCMantenimientos
        '
        Me.RCMantenimientos.Location = New System.Drawing.Point(303, 200)
        Me.RCMantenimientos.Name = "RCMantenimientos"
        Me.RCMantenimientos.OcxState = CType(resources.GetObject("RCMantenimientos.OcxState"), System.Windows.Forms.AxHost.State)
        Me.RCMantenimientos.Size = New System.Drawing.Size(308, 93)
        Me.RCMantenimientos.TabIndex = 65
        Me.RCMantenimientos.Visible = False
        '
        'GrupoTxtRealizado
        '
        Me.GrupoTxtRealizado.CausesValidation = False
        Me.GrupoTxtRealizado.Location = New System.Drawing.Point(146, 452)
        Me.GrupoTxtRealizado.Name = "GrupoTxtRealizado"
        Me.GrupoTxtRealizado.OcxState = CType(resources.GetObject("GrupoTxtRealizado.OcxState"), System.Windows.Forms.AxHost.State)
        Me.GrupoTxtRealizado.Size = New System.Drawing.Size(465, 82)
        Me.GrupoTxtRealizado.TabIndex = 71
        '
        'GrupoLblDonde
        '
        Me.GrupoLblDonde.Location = New System.Drawing.Point(709, 337)
        Me.GrupoLblDonde.Name = "GrupoLblDonde"
        Me.GrupoLblDonde.OcxState = CType(resources.GetObject("GrupoLblDonde.OcxState"), System.Windows.Forms.AxHost.State)
        Me.GrupoLblDonde.Size = New System.Drawing.Size(72, 22)
        Me.GrupoLblDonde.TabIndex = 77
        '
        'GrupoTxtDonde
        '
        Me.GrupoTxtDonde.Location = New System.Drawing.Point(709, 365)
        Me.GrupoTxtDonde.Name = "GrupoTxtDonde"
        Me.GrupoTxtDonde.OcxState = CType(resources.GetObject("GrupoTxtDonde.OcxState"), System.Windows.Forms.AxHost.State)
        Me.GrupoTxtDonde.Size = New System.Drawing.Size(125, 24)
        Me.GrupoTxtDonde.TabIndex = 4
        '
        'GrupoTxtSubtrabajo
        '
        Me.GrupoTxtSubtrabajo.Location = New System.Drawing.Point(508, 365)
        Me.GrupoTxtSubtrabajo.Name = "GrupoTxtSubtrabajo"
        Me.GrupoTxtSubtrabajo.OcxState = CType(resources.GetObject("GrupoTxtSubtrabajo.OcxState"), System.Windows.Forms.AxHost.State)
        Me.GrupoTxtSubtrabajo.Size = New System.Drawing.Size(195, 24)
        Me.GrupoTxtSubtrabajo.TabIndex = 3
        '
        'GrupoLblSubtrabajo
        '
        Me.GrupoLblSubtrabajo.Location = New System.Drawing.Point(508, 337)
        Me.GrupoLblSubtrabajo.Name = "GrupoLblSubtrabajo"
        Me.GrupoLblSubtrabajo.OcxState = CType(resources.GetObject("GrupoLblSubtrabajo.OcxState"), System.Windows.Forms.AxHost.State)
        Me.GrupoLblSubtrabajo.Size = New System.Drawing.Size(72, 22)
        Me.GrupoLblSubtrabajo.TabIndex = 76
        '
        'GrupoLblTrabajo
        '
        Me.GrupoLblTrabajo.Location = New System.Drawing.Point(307, 337)
        Me.GrupoLblTrabajo.Name = "GrupoLblTrabajo"
        Me.GrupoLblTrabajo.OcxState = CType(resources.GetObject("GrupoLblTrabajo.OcxState"), System.Windows.Forms.AxHost.State)
        Me.GrupoLblTrabajo.Size = New System.Drawing.Size(49, 22)
        Me.GrupoLblTrabajo.TabIndex = 75
        '
        'GrupoLblProducto
        '
        Me.GrupoLblProducto.Location = New System.Drawing.Point(222, 337)
        Me.GrupoLblProducto.Name = "GrupoLblProducto"
        Me.GrupoLblProducto.OcxState = CType(resources.GetObject("GrupoLblProducto.OcxState"), System.Windows.Forms.AxHost.State)
        Me.GrupoLblProducto.Size = New System.Drawing.Size(72, 22)
        Me.GrupoLblProducto.TabIndex = 74
        '
        'GrupoCbTema
        '
        Me.GrupoCbTema.Location = New System.Drawing.Point(137, 365)
        Me.GrupoCbTema.Name = "GrupoCbTema"
        Me.GrupoCbTema.OcxState = CType(resources.GetObject("GrupoCbTema.OcxState"), System.Windows.Forms.AxHost.State)
        Me.GrupoCbTema.Size = New System.Drawing.Size(95, 24)
        Me.GrupoCbTema.TabIndex = 0
        '
        'GrupoCbProducto
        '
        Me.GrupoCbProducto.Location = New System.Drawing.Point(222, 365)
        Me.GrupoCbProducto.Name = "GrupoCbProducto"
        Me.GrupoCbProducto.OcxState = CType(resources.GetObject("GrupoCbProducto.OcxState"), System.Windows.Forms.AxHost.State)
        Me.GrupoCbProducto.Size = New System.Drawing.Size(95, 24)
        Me.GrupoCbProducto.TabIndex = 1
        '
        'GrupoCbTrabajo
        '
        Me.GrupoCbTrabajo.Location = New System.Drawing.Point(307, 365)
        Me.GrupoCbTrabajo.Name = "GrupoCbTrabajo"
        Me.GrupoCbTrabajo.OcxState = CType(resources.GetObject("GrupoCbTrabajo.OcxState"), System.Windows.Forms.AxHost.State)
        Me.GrupoCbTrabajo.Size = New System.Drawing.Size(195, 24)
        Me.GrupoCbTrabajo.TabIndex = 2
        '
        'GrupoLblTema
        '
        Me.GrupoLblTema.Location = New System.Drawing.Point(137, 337)
        Me.GrupoLblTema.Name = "GrupoLblTema"
        Me.GrupoLblTema.OcxState = CType(resources.GetObject("GrupoLblTema.OcxState"), System.Windows.Forms.AxHost.State)
        Me.GrupoLblTema.Size = New System.Drawing.Size(72, 22)
        Me.GrupoLblTema.TabIndex = 73
        '
        'Titulo
        '
        Me.Titulo.Enabled = True
        Me.Titulo.Location = New System.Drawing.Point(17, 60)
        Me.Titulo.Name = "Titulo"
        Me.Titulo.OcxState = CType(resources.GetObject("Titulo.OcxState"), System.Windows.Forms.AxHost.State)
        Me.Titulo.Size = New System.Drawing.Size(100, 50)
        Me.Titulo.TabIndex = 72
        '
        'GrupoLblRealizado
        '
        Me.GrupoLblRealizado.Location = New System.Drawing.Point(146, 424)
        Me.GrupoLblRealizado.Name = "GrupoLblRealizado"
        Me.GrupoLblRealizado.OcxState = CType(resources.GetObject("GrupoLblRealizado.OcxState"), System.Windows.Forms.AxHost.State)
        Me.GrupoLblRealizado.Size = New System.Drawing.Size(395, 22)
        Me.GrupoLblRealizado.TabIndex = 78
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(812, 126)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.OcxState = CType(resources.GetObject("btnSalir.OcxState"), System.Windows.Forms.AxHost.State)
        Me.btnSalir.Size = New System.Drawing.Size(59, 52)
        Me.btnSalir.TabIndex = 79
        '
        'gbTodo
        '
        Me.gbTodo.Location = New System.Drawing.Point(442, 37)
        Me.gbTodo.Name = "gbTodo"
        Me.gbTodo.OcxState = CType(resources.GetObject("gbTodo.OcxState"), System.Windows.Forms.AxHost.State)
        Me.gbTodo.Size = New System.Drawing.Size(233, 122)
        Me.gbTodo.TabIndex = 80
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(737, 218)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.OcxState = CType(resources.GetObject("btnBuscar.OcxState"), System.Windows.Forms.AxHost.State)
        Me.btnBuscar.Size = New System.Drawing.Size(59, 52)
        Me.btnBuscar.TabIndex = 5
        '
        'FrmConsultaMantenimiento
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(1002, 602)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.GrupoLblRealizado)
        Me.Controls.Add(Me.RCMantenimientos)
        Me.Controls.Add(Me.GrupoTxtRealizado)
        Me.Controls.Add(Me.GrupoLblDonde)
        Me.Controls.Add(Me.GrupoTxtDonde)
        Me.Controls.Add(Me.GrupoTxtSubtrabajo)
        Me.Controls.Add(Me.GrupoLblSubtrabajo)
        Me.Controls.Add(Me.GrupoLblTrabajo)
        Me.Controls.Add(Me.GrupoLblProducto)
        Me.Controls.Add(Me.GrupoCbTema)
        Me.Controls.Add(Me.GrupoCbProducto)
        Me.Controls.Add(Me.GrupoCbTrabajo)
        Me.Controls.Add(Me.GrupoLblTema)
        Me.Controls.Add(Me.Titulo)
        Me.Controls.Add(Me.gbTodo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmConsultaMantenimiento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        CType(Me.RCMantenimientos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrupoTxtRealizado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrupoLblDonde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrupoTxtDonde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrupoTxtSubtrabajo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrupoLblSubtrabajo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrupoLblTrabajo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrupoLblProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrupoCbTema, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrupoCbProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrupoCbTrabajo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrupoLblTema, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Titulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrupoLblRealizado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSalir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbTodo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnBuscar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RCMantenimientos As AxXtremeReportControl.AxReportControl
    Friend WithEvents GrupoTxtRealizado As AxXtremeSuiteControls.AxFlatEdit
    Friend WithEvents GrupoLblDonde As AxXtremeSuiteControls.AxLabel
    Friend WithEvents GrupoTxtDonde As AxXtremeSuiteControls.AxFlatEdit
    Friend WithEvents GrupoTxtSubtrabajo As AxXtremeSuiteControls.AxFlatEdit
    Friend WithEvents GrupoLblSubtrabajo As AxXtremeSuiteControls.AxLabel
    Friend WithEvents GrupoLblTrabajo As AxXtremeSuiteControls.AxLabel
    Friend WithEvents GrupoLblProducto As AxXtremeSuiteControls.AxLabel
    Friend WithEvents GrupoCbTema As AxXtremeSuiteControls.AxComboBox
    Friend WithEvents GrupoCbProducto As AxXtremeSuiteControls.AxComboBox
    Friend WithEvents GrupoCbTrabajo As AxXtremeSuiteControls.AxComboBox
    Friend WithEvents GrupoLblTema As AxXtremeSuiteControls.AxLabel
    Friend WithEvents Titulo As AxXtremeShortcutBar.AxShortcutCaption
    Friend WithEvents GrupoLblRealizado As AxXtremeSuiteControls.AxLabel
    Friend WithEvents btnSalir As AxXtremeCommandBars.AxBackstageButton
    Friend WithEvents gbTodo As AxXtremeSuiteControls.AxGroupBox
    Friend WithEvents btnBuscar As AxXtremeCommandBars.AxBackstageButton
End Class
