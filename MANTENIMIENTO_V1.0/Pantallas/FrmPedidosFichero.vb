Imports MantEvolution.DefinicionesMenus
Imports XtremeReportControl

Public Class FrmPedidosFichero

    Const COL_ID = 0
    Const COL_NUMERO = 1
    Const COL_FECHA = 2
    Const COL_IDCLIENTE = 3

    Const COL_CLIENTE = 4
    Const COL_NOMBRECOMERCIAL = 5
    Const COL_BASE = 6
    Const COL_IVA = 7
    Const COL_TOTAL = 8
    Const COL_NFACTURA = 9
    Const COL_FORMAPAGO = 10
    Const COL_ESTADO = 11

    Const COL_MES = 12
    Const COL_TRIMESTRE = 13

    Dim ArrayPedidos As New ArrayList()
    Dim TabPantalla As XtremeCommandBars.RibbonTab = Nothing
    Dim GroupFile As XtremeCommandBars.RibbonGroup = Nothing


    Private Sub FrmPedidosFichero_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        ConfigurarPantalla()
    End Sub


    Sub ConfigurarPantalla()

        Titulo.Top = 0
        Titulo.Left = 0
        Titulo.Width = Me.Width

        gbFiltro.Left = 10
        gbFiltro.Top = Titulo.Height

        RCPedidos.Left = gbFiltro.Left + gbFiltro.Width + 10
        RCPedidos.Width = Me.Width - gbFiltro.Width - gbFiltro.Left - 20

        RCPedidos.Top = Titulo.Height
        RCPedidos.Height = Me.Height - RCPedidos.Top - 20

    End Sub


    Sub CargarColumnasReport()


        RCPedidos.PaintManager.ColumnStyle = XTPReportColumnStyle.xtpColumnResource

        RCPedidos.AllowEdit = False


        RCPedidos.Columns.Add(COL_ID, "Id", 100, True)

        RCPedidos.Columns.Add(COL_NUMERO, "Numero XXX", 100, True)
        RCPedidos.Columns.Add(COL_FECHA, "Fecha", 250, True)
        RCPedidos.Columns.Add(COL_IDCLIENTE, "idCliente", 60, True)
        RCPedidos.Columns.Add(COL_CLIENTE, "Cliente", 100, True)
        RCPedidos.Columns.Add(COL_NOMBRECOMERCIAL, "Nombre comercial", 100, True)
        RCPedidos.Columns.Add(COL_BASE, "Base", 250, True)
        RCPedidos.Columns.Add(COL_IVA, "Iva", 60, True)
        RCPedidos.Columns.Add(COL_TOTAL, "Total", 100, True)
        RCPedidos.Columns.Add(COL_NFACTURA, "N. Factura", 250, True)
        RCPedidos.Columns.Add(COL_FORMAPAGO, "Forma Pago", 60, True)
        RCPedidos.Columns.Add(COL_ESTADO, "Estado", 60, True)
        RCPedidos.Columns.Add(COL_MES, "Mes", 60, True)
        RCPedidos.Columns.Add(COL_TRIMESTRE, "Trimestre", 60, True)



    End Sub


    Sub ObterPedidosFecha()

        Dim fecha As String
        fecha = cbAños.Text
        Application.DoEvents()
        ArrayPedidos = ObtenerPedidosAño(fecha)
        Debug.Print(" Carga array fin " & DateTime.Now)

        CargarPedidosRC()
    End Sub


    Public Sub CargarPedidosRC()

        RCPedidos.Records.DeleteAll()

        Dim contador As Long

        Dim Record As ReportRecord
        Dim ObjPedido As Pedido

        Application.DoEvents()
        For Each ObjPedido In ArrayPedidos
            If Not IsNothing(ObjPedido.ObjCliente) Then
                'Dim id1 As Long = ObjPedido.ObjCliente.Id1
                '  Debug.Print(Conversion.Str(id1))
                Record = RCPedidos.Records.Add()

                Record.AddItem(ObjPedido.Id1)
                Record.AddItem(ObjPedido.Numero1)
                Record.AddItem(ObjPedido.Fecha1)
                Record.AddItem(ObjPedido.ObjCliente1.Id1) 'id Cliente sin poner
                Record.AddItem(ObjPedido.ObjCliente1.Id1)  ' Cliente codigo sin poner
                Record.AddItem(ObjPedido.ObjCliente1.NombreComercial1) ' Cliente Nombre Comercial sin poner
                Record.AddItem(ObjPedido.Base1)

                Record.AddItem(ObjPedido.Iva1)
                Record.AddItem(ObjPedido.Total1)
                Record.AddItem(ObjPedido.Id1) 'id Factura sin poner
                Record.AddItem(ObjPedido.Id1) 'id forma Pago sin poner
                Record.AddItem(ObjPedido.Id1) 'Estado sin poner
                '  Record.AddItem("") 'Añadir

                Record.AddItem(ObjPedido.Mes1) 'id forma Pago sin poner
                Record.AddItem(ObjPedido.Trimestre1)

                contador = contador + 1


                If Int(contador / 400) * 400 = contador Then
                    Application.DoEvents()
                End If
                If contador = 1000 Then
                    RCPedidos.Populate()
                End If
            End If
        Next



        RCPedidos.Populate()
        '   RCClientes.Navigator.MoveLastRow()


        Debug.Print("Fin Carga " & DateTime.Now)






    End Sub

    Private Sub FrmPedidosFichero_Load(sender As Object, e As EventArgs) Handles Me.Load

        cbAños.ReCreateReparented = True
        CargarColumnasReport()


        fPedidosFichero = Me
    End Sub

    Sub CargarComboAños()


        cbAños.AddItem(Convert.ToString(Year(Now)))
        cbAños.AddItem(Convert.ToString(Year(Now) - 1))
        cbAños.AddItem(Convert.ToString(Year(Now) - 2))
        cbAños.AddItem(Convert.ToString(Year(Now) - 3))
        cbAños.AddItem(Convert.ToString(Year(Now) - 4))



    End Sub

    Sub ConstruirMenu()

        If MDIPrincipal.RibbonBar.FindTab(DEFMENU.VENTAS_PEDIDOS_FICHERO) Is Nothing Then 'si no existe lo creo
            TabPantalla = MDIPrincipal.RibbonBar.InsertTab(DEFMENU.VENTAS_PEDIDOS_FICHERO, "&PEDIDOS")
            TabPantalla.Id = DEFMENU.VENTAS_PEDIDOS_FICHERO

            'GroupFile = TabPrincipal.Groups.AddGroup("&MANTE", 1001)
            'GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.PRINCIPAL_MANTENIMIENTO, "Mantenimiento", False, False)
            GroupFile = TabPantalla.Groups.AddGroup("&PEDIDOS", DEFMENU.MAESTROS_CLIENTES)
            GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.VENTAS_PEDIDOS_FICHERO_AÑADIR, "Nuevo", False, False).IconId = 100
            GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.VENTAS_PEDIDOS_FICHERO_MODIFICAR, "Modificar", False, False).IconId = 102
            GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.VENTAS_PEDIDOS_FICHERO_ELIMINAR, "Eliminar", False, False).IconId = 102
            'GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_CLIENTES_IMPRIMIR, "Imprimir", False, False).IconId = 112
            'GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_CLIENTES_FILTROFILA, "Filtro", False, False).IconId = 111
            'GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_CLIENTES_FILTROAVANZADO, "Filtro Avanzado", False, False).IconId = 111
            'GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_CLIENTES_QUITARFILTRO, "Quitar Filtro", False, False).IconId = 111
            'GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_CLIENTES_VISTAS, "Vistas", False, False).IconId = 111
            GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.VENTAS_PEDIDOS_FICHERO_SALIR, "Salir", False, False).IconId = 103
        End If

        MDIPrincipal.RibbonBar.FindTab(DEFMENU.VENTAS_PEDIDOS_FICHERO).Visible = True
        MDIPrincipal.RibbonBar.FindTab(DEFMENU.VENTAS_PEDIDOS_FICHERO).Selected = True

        'If MDIPrincipal.RibbonBar.FindTab(DEFMENU.MAESTROS_CLIENTES_FICHA) Is Nothing = False Then
        '    MDIPrincipal.RibbonBar.FindTab(DEFMENU.MAESTROS_CLIENTES_FICHA).Visible = False
        'End If


    End Sub

    Private Sub FrmPedidosFichero_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        ConstruirMenu()
        CargarComboAños()

    End Sub


    Sub Nuevo()

        Dim Form3 As FrmPedidos = New FrmPedidos With {
        .MdiParent = MDIPrincipal}
        '  Form3.ObjCliente = New Cliente()
        Form3.Show()

        Me.Visible = False

        '  MDIPrincipal.RibbonBar.FindTab(DEFMENU.TAB_MAESTROS).Selected = True
        '   MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_MAESTROS_CLIENTES).Visible = False

    End Sub

    Private Sub cbAños_ClickEvent(sender As Object, e As EventArgs) Handles cbAños.ClickEvent
        ObterPedidosFecha()
    End Sub



    Private Sub mes1_ClickEvent(sender As Object, e As EventArgs) Handles mes1.ClickEvent
        FiltrarMes(RCPedidos, COL_MES, 1)
    End Sub

    Private Sub mes2_ClickEvent(sender As Object, e As EventArgs) Handles mes2.ClickEvent
        FiltrarMes(RCPedidos, COL_MES, 2)
    End Sub

    Private Sub mes3_ClickEvent(sender As Object, e As EventArgs) Handles mes3.ClickEvent
        FiltrarMes(RCPedidos, COL_MES, 3)
    End Sub

    Private Sub mes4_ClickEvent(sender As Object, e As EventArgs) Handles mes4.ClickEvent
        FiltrarMes(RCPedidos, COL_MES, 4)
    End Sub

    Private Sub mes5_ClickEvent(sender As Object, e As EventArgs) Handles mes5.ClickEvent
        FiltrarMes(RCPedidos, COL_MES, 5)
    End Sub

    Private Sub mes6_ClickEvent(sender As Object, e As EventArgs) Handles mes6.ClickEvent
        FiltrarMes(RCPedidos, COL_MES, 6)
    End Sub

    Private Sub mes7_ClickEvent(sender As Object, e As EventArgs) Handles mes7.ClickEvent
        FiltrarMes(RCPedidos, COL_MES, 7)
    End Sub

    Private Sub mes8_ClickEvent(sender As Object, e As EventArgs) Handles mes8.ClickEvent
        FiltrarMes(RCPedidos, COL_MES, 8)
    End Sub

    Private Sub mes9_ClickEvent(sender As Object, e As EventArgs) Handles mes9.ClickEvent
        FiltrarMes(RCPedidos, COL_MES, 9)
    End Sub

    Private Sub mes10_ClickEvent(sender As Object, e As EventArgs) Handles mes10.ClickEvent
        FiltrarMes(RCPedidos, COL_MES, 10)
    End Sub

    Private Sub mes11_ClickEvent(sender As Object, e As EventArgs) Handles mes11.ClickEvent
        FiltrarMes(RCPedidos, COL_MES, 11)
    End Sub

    Private Sub mes12_ClickEvent(sender As Object, e As EventArgs) Handles mes12.ClickEvent
        FiltrarMes(RCPedidos, COL_MES, 12)
    End Sub


End Class