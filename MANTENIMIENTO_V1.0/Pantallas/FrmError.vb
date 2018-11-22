Imports AxXtremeSuiteControls

Public Class FrmError

    Public ObjError As Errores

    Public pantalla As Form

    Private Sub FrmError_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim Texto As String
        L1.CtlAutoSize = False
        LTitulo.Caption = ObjError.Titulo
        L1.Caption = ""

        For Each Texto In ObjError.ArrayMensajes
            If L1.Caption = "" Then
                L1.Caption = Texto.ToString
            Else
                L1.Caption = L1.Caption + vbCr + Texto.ToString
            End If
        Next

        If ObjError.Tipo1 = 1 Then 'Errores, STOP
            BtnAceptar.Visible = False
            BtnCancelar.Visible = False
            BtnOk.Visible = True
            BtnOk.Select()
            Me.BackColor = Color.Crimson
            PictureBox1.Visible = True
            PictureBox2.Visible = False
            PictureBox3.Visible = False
        ElseIf ObjError.Tipo1 = 2 Then 'Mensajes con opción, INTERROGANTE
            'Else
            BtnAceptar.Visible = True
            BtnCancelar.Visible = True
            BtnCancelar.Select()
            BtnOk.Visible = False
            Me.BackColor = Color.Blue
            PictureBox1.Visible = False
            PictureBox2.Visible = True
            PictureBox3.Visible = False
        ElseIf ObjError.Tipo1 = 3 Then 'Mensajes con solo ok, INFO
            BtnAceptar.Visible = False
            BtnCancelar.Visible = False
            BtnOk.Visible = True
            BtnOk.Select()
            Me.BackColor = Color.DarkGreen
            PictureBox1.Visible = False
            PictureBox2.Visible = False
            PictureBox3.Visible = True
        End If

        Redimensionar()

    End Sub

    Sub Redimensionar()

        Dim Total As Long

        'L1.CtlAutoSize = True

        BtnOk.Top = L1.Height + L1.Top + 25
        BtnAceptar.Top = L1.Height + L1.Top + 25
        BtnCancelar.Top = L1.Height + L1.Top + 25

        Total = Me.Width

        BtnCancelar.Left = (Total - (BtnAceptar.Width * 2)) / 3
        BtnAceptar.Left = (BtnCancelar.Left * 2) + BtnCancelar.Width

        AxGroupBox1.Height = BtnOk.Top + BtnOk.Height + 10
        Me.Height = AxGroupBox1.Top + AxGroupBox1.Height + 5
        If ObjError.Tipo1 = 2 Then
            L1.Height = Me.Height - L1.Top - 50 - BtnOk.Height
        Else
            L1.Height = Me.Height - L1.Top - 50
        End If

    End Sub

    Private Sub BtnOk_ClickEvent(sender As Object, e As EventArgs) Handles BtnOk.ClickEvent
        Me.DialogResult = DialogResult.OK
        'Me.Dispose()
    End Sub

    Private Sub BtnOk_KeyPressEvent(sender As Object, e As _DPushButtonEvents_KeyPressEvent) Handles BtnOk.KeyPressEvent

        If e.keyAscii = 13 Then
            Me.DialogResult = DialogResult.OK
            'Me.Dispose()
        End If

    End Sub

    Private Sub BtnAceptar_KeyPressEvent(sender As Object, e As _DPushButtonEvents_KeyPressEvent) Handles BtnAceptar.KeyPressEvent
        If e.keyAscii = 13 Then
            Me.DialogResult = DialogResult.Yes
            '    Me.Dispose()
        End If
    End Sub

    Private Sub BtnCancelar_KeyPressEvent(sender As Object, e As _DPushButtonEvents_KeyPressEvent) Handles BtnCancelar.KeyPressEvent
        If e.keyAscii = 13 Then
            Me.DialogResult = DialogResult.Cancel
            '    Me.Dispose()
        End If
    End Sub

    Private Sub BtnAceptar_ClickEvent(sender As Object, e As EventArgs) Handles BtnAceptar.ClickEvent
        Me.DialogResult = DialogResult.Yes
        'Me.Dispose()
    End Sub

    Private Sub BtnCancelar_ClickEvent(sender As Object, e As EventArgs) Handles BtnCancelar.ClickEvent
        Me.DialogResult = DialogResult.Cancel
        'Me.Dispose()
    End Sub
End Class