Public Class FrmPedidos

    Dim ObjPedido As Pedido

    Private arrayProductos As New ArrayList()
    Dim objProducto As Producto

    Sub ConfigurarPantalla()

        Titulo.Top = 0
        Titulo.Left = 0
        Titulo.Width = Me.Width


        RCPedido.Left = 10
        RCPedido.Width = Me.Width - 20

        'RCPedido.Top = Titulo.Height
        'RCPedido.Height = Me.Height - RCPedido.Top - 20

    End Sub

    Private Sub FrmPedidos_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        ConfigurarPantalla()
    End Sub

    Private Sub FrmPedidos_Load(sender As Object, e As EventArgs) Handles Me.Load
        cbTipo.ReCreateReparented = True
        cbProductos.ReCreateReparented = True

        LineaReiniciar()

        If IsNothing(ObjPedido) Then
            ObjPedido = New Pedido()
        Else
            Dim Accion As Integer
            Accion = 2  ' Modificar
            ObjPedido.Accion1 = Accion ' Modificar
        End If





    End Sub

    Private Sub FrmPedidos_Closed(sender As Object, e As EventArgs) Handles Me.Closed

    End Sub

    Private Sub FrmPedidos_Activated(sender As Object, e As EventArgs) Handles Me.Activated

        CagarCombos()

        If ObjPedido.Accion1 = 1 Then
            LLenarPantalla()
        End If



    End Sub


    Sub LLenarPantalla()

        tbNumero.Text = ObjPedido.Numero1
        tbFecha.Text = ObjPedido.Fecha1


        Select Case ObjPedido.Estado1
            Case 1
                tbEstado.Caption = "Pendiente"
            Case 2
                tbEstado.Caption = "Facturado"
        End Select





    End Sub


    Sub CagarCombos()
        cbTipo.Clear()
        cbTipo.AddItem("Productos", 0, 0)
        cbTipo.AddItem("Packs", 1, 1)
        cbTipo.AddItem("L. Libre", 2, 2)



    End Sub


    Private Sub txtLicencia_LostFocus(sender As Object, e As EventArgs) Handles txtLicencia.LostFocus

        Dim ObjError As New Errores


        If txtLicencia.Text <> "" Then
            '  LimpiaPantalla()

            txtCliente.Text = ObtenerClienteDeLicencia(txtLicencia.Text)
            If txtCliente.Text = "0" Then
                txtCliente.Text = ""

                ObjError.Pantalla1 = Me
                ObjError.Tipo1 = 3 'Info

                ObjError.Titulo = "Clientes"

                ObjError.SetMensaje("No existe la Licencia " & txtLicencia.Text)

                txtLicencia.Text = ""

                ObjError.Control1 = ""
                ObjError.Pie1 = False
                ObjError.Foco1 = txtLicencia.Text

                FrmError.ObjError = ObjError
                FrmError.ShowDialog()
                If FrmError.DialogResult = DialogResult.OK Then
                    FrmError.Dispose()
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub txtLicencia_KeyPressEvent(sender As Object, e As _DFlatEditEvents_KeyPressEvent) Handles txtLicencia.KeyPressEvent
        Retorno(e.keyAscii)
        'EsNumero KeyAscii, teHasta.Text
    End Sub

    Private Sub txtLicencia_GotFocus(sender As Object, e As EventArgs) Handles txtLicencia.GotFocus
        txtLicencia.SelStart = 0
        txtLicencia.SelLength = Len(txtLicencia.Text)
    End Sub


    Private Sub txtCliente_KeyPressEvent(sender As Object, e As _DFlatEditEvents_KeyPressEvent) Handles txtCliente.KeyPressEvent
        Retorno(e.keyAscii)
        'EsNumero KeyAscii, teHasta.Text
    End Sub

    Private Sub txtCliente_LostFocus(sender As Object, e As EventArgs) Handles txtCliente.LostFocus
        If txtCliente.Text <> "" Then
            ObjPedido.ObjCliente1 = ObtenerUnCliente(txtCliente.Text)
        End If

        CargarCliente()
    End Sub


    Sub CargarCliente()

        If Not IsNothing(ObjPedido.ObjCliente) Then
            txtLicencia.Text = ""
            lblNComercial.Caption = ObjPedido.ObjCliente.NombreComercial1
            lblRSocial.Caption = ObjPedido.ObjCliente.RazonSocial1
            lblUsuario.Caption = ObjPedido.ObjCliente.UsuarioNombre11
            lblMail.Caption = ObjPedido.ObjCliente.Email1
            lblTelef1.Caption = ObjPedido.ObjCliente.Telefono1
            lblTelef2.Caption = ObjPedido.ObjCliente.Telefono21
            lblTelefMovil.Caption = ObjPedido.ObjCliente.Movil1
            lblDirDatos.Caption = ObjPedido.ObjCliente.Web1
        End If

    End Sub

    Private Sub AxLabel24_Enter(sender As Object, e As EventArgs) Handles AxLabel24.Enter

    End Sub

    Private Sub cbTipo_ClickEvent(sender As Object, e As EventArgs) Handles cbTipo.ClickEvent

        cargarComboProductos()


    End Sub


    Sub cargarComboProductos()
        cbProductos.Clear()
        Dim ObjProducto As Producto

        Select Case cbTipo.ListIndex
            Case 0
                arrayProductos = ObtenerProductos()
                For Each ObjProducto In arrayProductos
                    cbProductos.AddItem(ObjProducto.Codigo1, 0, ObjProducto.Id1)
                Next
            Case 1
            Case 2
        End Select





    End Sub

    Private Sub cbProductos_ClickEvent(sender As Object, e As EventArgs) Handles cbProductos.ClickEvent
        Dim x As Integer
        Select Case cbTipo.ListIndex
            Case 0
                For x = 0 To arrayProductos.Count - 1
                    If arrayProductos(x).Id1 = cbProductos.get_ItemData(cbProductos.ListIndex) Then
                        objProducto = arrayProductos(x)
                    End If
                Next
                ProductoPrecios()
            Case 1
            Case 2
        End Select

    End Sub

    Sub ProductoPrecios()
        If Not IsNothing(objProducto) Then
            If ckRed.Value = False Then
                tbPrecio.Text = objProducto.Precio1
            Else
                tbPrecio.Text = objProducto.PrecioRed1
            End If
        End If

    End Sub


    Private Sub ckRed_ClickEvent(sender As Object, e As EventArgs) Handles ckRed.ClickEvent
        ProductoPrecios()
    End Sub


    Sub LineaReiniciar()
        tbCantidad.Text = Format(0, FormatoImporte)
        tbPrecio.Text = Format(0, FormatoImporte)
        tbDto.Text = Format(0, FormatoPorcentaje)
        tbImporte.Text = Format(0, FormatoImporte)
    End Sub



    Private Sub tbCantidad_KeyPressEvent(sender As Object, e As _DFlatEditEvents_KeyPressEvent) Handles tbCantidad.KeyPressEvent
        Retorno(e.keyAscii)
    End Sub

    Private Sub tbPrecio_KeyPressEvent(sender As Object, e As _DFlatEditEvents_KeyPressEvent) Handles tbPrecio.KeyPressEvent
        Retorno(e.keyAscii)
    End Sub

    Private Sub tbDto_KeyPressEvent(sender As Object, e As _DFlatEditEvents_KeyPressEvent) Handles tbDto.KeyPressEvent
        Retorno(e.keyAscii)
    End Sub

    Private Sub tbCantidad_LostFocus(sender As Object, e As EventArgs) Handles tbCantidad.LostFocus
        '   e.ToString =
        tbCantidad.Text = Format(tbCantidad.Text, FormatoImporte)

        FilaPiecalculos
    End Sub

    Sub FilaPiecalculos()

        tbImporte.Text = Convert.ToDouble(tbCantidad.Text) * Convert.ToDouble(tbPrecio.Text)

    End Sub




End Class