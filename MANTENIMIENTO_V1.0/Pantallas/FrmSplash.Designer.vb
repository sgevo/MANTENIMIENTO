<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSplash
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSplash))
        Me.cbUsuarios = New AxXtremeSuiteControls.AxComboBox()
        Me.lblUsuario = New AxXtremeSuiteControls.AxLabel()
        Me.lblContraseña = New AxXtremeSuiteControls.AxLabel()
        Me.txtContraseña = New AxXtremeSuiteControls.AxFlatEdit()
        Me.btnCancel = New AxXtremeCommandBars.AxBackstageButton()
        Me.btnOK = New AxXtremeCommandBars.AxBackstageButton()
        Me.lblMante = New AxXtremeSuiteControls.AxLabel()
        CType(Me.cbUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblContraseña, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtContraseña, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnOK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMante, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbUsuarios
        '
        Me.cbUsuarios.Location = New System.Drawing.Point(508, 251)
        Me.cbUsuarios.Name = "cbUsuarios"
        Me.cbUsuarios.OcxState = CType(resources.GetObject("cbUsuarios.OcxState"), System.Windows.Forms.AxHost.State)
        Me.cbUsuarios.Size = New System.Drawing.Size(235, 24)
        Me.cbUsuarios.TabIndex = 0
        '
        'lblUsuario
        '
        Me.lblUsuario.Location = New System.Drawing.Point(507, 226)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.OcxState = CType(resources.GetObject("lblUsuario.OcxState"), System.Windows.Forms.AxHost.State)
        Me.lblUsuario.Size = New System.Drawing.Size(233, 28)
        Me.lblUsuario.TabIndex = 1
        Me.lblUsuario.TabStop = False
        '
        'lblContraseña
        '
        Me.lblContraseña.Location = New System.Drawing.Point(508, 293)
        Me.lblContraseña.Name = "lblContraseña"
        Me.lblContraseña.OcxState = CType(resources.GetObject("lblContraseña.OcxState"), System.Windows.Forms.AxHost.State)
        Me.lblContraseña.Size = New System.Drawing.Size(231, 27)
        Me.lblContraseña.TabIndex = 20
        Me.lblContraseña.TabStop = False
        '
        'txtContraseña
        '
        Me.txtContraseña.Location = New System.Drawing.Point(507, 316)
        Me.txtContraseña.Name = "txtContraseña"
        Me.txtContraseña.OcxState = CType(resources.GetObject("txtContraseña.OcxState"), System.Windows.Forms.AxHost.State)
        Me.txtContraseña.Size = New System.Drawing.Size(232, 30)
        Me.txtContraseña.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(508, 376)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.OcxState = CType(resources.GetObject("btnCancel.OcxState"), System.Windows.Forms.AxHost.State)
        Me.btnCancel.Size = New System.Drawing.Size(88, 55)
        Me.btnCancel.TabIndex = 3
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(655, 376)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.OcxState = CType(resources.GetObject("btnOK.OcxState"), System.Windows.Forms.AxHost.State)
        Me.btnOK.Size = New System.Drawing.Size(88, 55)
        Me.btnOK.TabIndex = 2
        '
        'lblMante
        '
        Me.lblMante.Location = New System.Drawing.Point(270, 75)
        Me.lblMante.Name = "lblMante"
        Me.lblMante.OcxState = CType(resources.GetObject("lblMante.OcxState"), System.Windows.Forms.AxHost.State)
        Me.lblMante.Size = New System.Drawing.Size(453, 84)
        Me.lblMante.TabIndex = 21
        Me.lblMante.TabStop = False
        '
        'frmSplash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.lblMante)
        Me.Controls.Add(Me.txtContraseña)
        Me.Controls.Add(Me.cbUsuarios)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lblContraseña)
        Me.Controls.Add(Me.lblUsuario)
        Me.Name = "frmSplash"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MANTENIMIENTO EVO"
        CType(Me.cbUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblContraseña, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtContraseña, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnOK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMante, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cbUsuarios As AxXtremeSuiteControls.AxComboBox
    Friend WithEvents lblUsuario As AxXtremeSuiteControls.AxLabel
    Friend WithEvents lblContraseña As AxXtremeSuiteControls.AxLabel
    Friend WithEvents txtContraseña As AxXtremeSuiteControls.AxFlatEdit
    Friend WithEvents btnCancel As AxXtremeCommandBars.AxBackstageButton
    Friend WithEvents btnOK As AxXtremeCommandBars.AxBackstageButton
    Friend WithEvents lblMante As AxXtremeSuiteControls.AxLabel
End Class
