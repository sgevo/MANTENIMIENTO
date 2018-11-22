<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.AxReportControl1 = New AxXtremeReportControl.AxReportControl()
        Me.AxPushButton1 = New AxXtremeSuiteControls.AxPushButton()
        Me.AxFlatEdit1 = New AxXtremeSuiteControls.AxFlatEdit()
        Me.AxLabel1 = New AxXtremeSuiteControls.AxLabel()
        Me.AxComboBox1 = New AxXtremeSuiteControls.AxComboBox()
        Me.AxWebBrowser1 = New AxXtremeSuiteControls.AxWebBrowser()
        CType(Me.AxReportControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxPushButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxFlatEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxWebBrowser1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AxReportControl1
        '
        Me.AxReportControl1.Location = New System.Drawing.Point(428, 142)
        Me.AxReportControl1.Name = "AxReportControl1"
        Me.AxReportControl1.OcxState = CType(resources.GetObject("AxReportControl1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxReportControl1.Size = New System.Drawing.Size(163, 126)
        Me.AxReportControl1.TabIndex = 0
        '
        'AxPushButton1
        '
        Me.AxPushButton1.Location = New System.Drawing.Point(319, 36)
        Me.AxPushButton1.Name = "AxPushButton1"
        Me.AxPushButton1.OcxState = CType(resources.GetObject("AxPushButton1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxPushButton1.Size = New System.Drawing.Size(100, 106)
        Me.AxPushButton1.TabIndex = 1
        '
        'AxFlatEdit1
        '
        Me.AxFlatEdit1.Location = New System.Drawing.Point(365, 307)
        Me.AxFlatEdit1.Name = "AxFlatEdit1"
        Me.AxFlatEdit1.OcxState = CType(resources.GetObject("AxFlatEdit1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxFlatEdit1.Size = New System.Drawing.Size(132, 69)
        Me.AxFlatEdit1.TabIndex = 2
        '
        'AxLabel1
        '
        Me.AxLabel1.Location = New System.Drawing.Point(490, 53)
        Me.AxLabel1.Name = "AxLabel1"
        Me.AxLabel1.OcxState = CType(resources.GetObject("AxLabel1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxLabel1.Size = New System.Drawing.Size(144, 72)
        Me.AxLabel1.TabIndex = 3
        '
        'AxComboBox1
        '
        Me.AxComboBox1.Location = New System.Drawing.Point(655, 209)
        Me.AxComboBox1.Name = "AxComboBox1"
        Me.AxComboBox1.OcxState = CType(resources.GetObject("AxComboBox1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxComboBox1.Size = New System.Drawing.Size(83, 21)
        Me.AxComboBox1.TabIndex = 4
        '
        'AxWebBrowser1
        '
        Me.AxWebBrowser1.Enabled = True
        Me.AxWebBrowser1.Location = New System.Drawing.Point(545, 307)
        Me.AxWebBrowser1.Name = "AxWebBrowser1"
        Me.AxWebBrowser1.OcxState = CType(resources.GetObject("AxWebBrowser1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxWebBrowser1.Size = New System.Drawing.Size(123, 97)
        Me.AxWebBrowser1.TabIndex = 5
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.AxWebBrowser1)
        Me.Controls.Add(Me.AxComboBox1)
        Me.Controls.Add(Me.AxLabel1)
        Me.Controls.Add(Me.AxFlatEdit1)
        Me.Controls.Add(Me.AxPushButton1)
        Me.Controls.Add(Me.AxReportControl1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.AxReportControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxPushButton1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxFlatEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxWebBrowser1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents AxReportControl1 As AxXtremeReportControl.AxReportControl
    Friend WithEvents AxPushButton1 As AxXtremeSuiteControls.AxPushButton
    Friend WithEvents AxFlatEdit1 As AxXtremeSuiteControls.AxFlatEdit
    Friend WithEvents AxLabel1 As AxXtremeSuiteControls.AxLabel
    Friend WithEvents AxComboBox1 As AxXtremeSuiteControls.AxComboBox
    Friend WithEvents AxWebBrowser1 As AxXtremeSuiteControls.AxWebBrowser
End Class
