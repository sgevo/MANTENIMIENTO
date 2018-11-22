Imports AxXtremeCommandBars
Imports AxXtremeSuiteControls

Public Class frmSplash

    Dim Empezando As Boolean = True

    Private Sub btnOK_ClickEvent(sender As Object, e As EventArgs) Handles btnOK.ClickEvent
        OK()
    End Sub

    Private Sub btnCancel_ClickEvent(sender As Object, e As EventArgs) Handles btnCancel.ClickEvent
        Me.Dispose()
        End
    End Sub

    Private Sub frmSplash_Load(sender As Object, e As EventArgs) Handles Me.Load
        BDUsuarios.GetUsuarios(cbUsuarios)
        If cbUsuarios.ListCount > 0 Then
            cbUsuarios.ListIndex = 0
        Else
            cbUsuarios.ListIndex = -1
        End If
        Empezando = False
    End Sub

    Private Sub txtContraseña_KeyPressEvent(sender As Object, e As _DFlatEditEvents_KeyPressEvent) Handles txtContraseña.KeyPressEvent
        Retorno(e.keyAscii)
    End Sub

    Private Sub txtContraseña_GotFocus(sender As Object, e As EventArgs) Handles txtContraseña.GotFocus
        txtContraseña.SelStart = 0
        txtContraseña.SelLength = Len(txtContraseña.Text)
    End Sub

    Private Sub btnOK_KeyPressEvent(sender As Object, e As _DBackstageButtonEvents_KeyPressEvent) Handles btnOK.KeyPressEvent
        If e.keyAscii = 13 Then
            OK()
        End If
    End Sub

    Sub OK()
        Dim ObjError As New Errores

        If cbUsuarios.Text = "" Then Exit Sub

        UsuarioNombre = cbUsuarios.Text
        UsuarioId = cbUsuarios.get_ItemData(cbUsuarios.ListIndex)

        If GetContraseña(UsuarioId) <> "" Then
            If GetContraseña(UsuarioId) <> txtContraseña.Text Then

                ObjError.Pantalla1 = Me
                ObjError.Tipo1 = 1 'Error
                ObjError.Titulo = "SEGURIDAD"
                ObjError.SetMensaje("Contraseña incorrecta")
                ObjError.Control1 = ""
                ObjError.Pie1 = False
                ObjError.Foco1 = 0
                FrmError.ObjError = ObjError
                FrmError.ShowDialog()
                If FrmError.DialogResult = DialogResult.OK Then
                    FrmError.Dispose()
                    Exit Sub
                End If
            End If
        End If

        MDIPrincipal.Show() ' si no lo hago directamente no van los menus
        Me.Close()
    End Sub

    Private Sub cbUsuarios_ClickEvent(sender As Object, e As EventArgs) Handles cbUsuarios.ClickEvent

        UsuarioId = cbUsuarios.get_ItemData(cbUsuarios.ListIndex)

        If GetContraseña(UsuarioId) <> "" Then
            txtContraseña.Visible = True
            lblContraseña.Visible = True
        Else
            txtContraseña.Visible = False
            lblContraseña.Visible = False
        End If

        If Empezando Then Exit Sub 'esto lo pongo para que no salte el evento antes de cargar la pantalla

        Retorno(13)
    End Sub

    Private Sub btnCancel_KeyPressEvent(sender As Object, e As _DBackstageButtonEvents_KeyPressEvent) Handles btnCancel.KeyPressEvent
        If e.keyAscii = 13 Then
            Me.Dispose()
            End
        End If
    End Sub
End Class