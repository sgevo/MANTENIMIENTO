Imports MantEvolution.DefinicionesMenus

Public Class frmTarifas

    Public Permisos As Long

    Dim idProducto1 As Long = 0
    Dim idProducto2 As Long = 0

    Dim TabPantalla As XtremeCommandBars.RibbonTab = Nothing
    Dim GroupFile As XtremeCommandBars.RibbonGroup = Nothing

    Sub ConfigurarPantalla()

        Titulo.Top = 0
        Titulo.Left = 0
        Titulo.Width = Me.Width

        gbDescuento.Left = 10
        gbDescuento.Top = Titulo.Height + 20

        gbTarifas.Left = gbDescuento.Left + gbDescuento.Width + 20
        gbTarifas.Top = gbDescuento.Top

        'RCPedidos.Left = gbFiltro.Left + gbFiltro.Width + 10
        'RCPedidos.Width = Me.Width - gbFiltro.Width - gbFiltro.Left - 20

        'RCPedidos.Top = Titulo.Height
        'RCPedidos.Height = Me.Height - RCPedidos.Top - 20

    End Sub

    Private Sub frmTarifas_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        ConfigurarPantalla()
    End Sub

    Sub ConstruirMenu()

        If MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_VENTAS) Is Nothing Then 'si no existe lo creo
            TabPantalla = MDIPrincipal.RibbonBar.InsertTab(DEFMENU.GRUPO_VENTAS, "&Tarifas")
            TabPantalla.Id = DEFMENU.GRUPO_VENTAS

            'GroupFile = TabPrincipal.Groups.AddGroup("&MANTE", 1001)
            'GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.PRINCIPAL_MANTENIMIENTO, "Mantenimiento", False, False)
            GroupFile = TabPantalla.Groups.AddGroup("&TARIFAS", DEFMENU.GRUPO_VENTAS)
            'GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.VENTAS_PEDIDOS_FICHERO_AÑADIR, "Nuevo", False, False).IconId = 100
            'GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.VENTAS_PEDIDOS_FICHERO_MODIFICAR, "Modificar", False, False).IconId = 102
            'GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.VENTAS_PEDIDOS_FICHERO_ELIMINAR, "Eliminar", False, False).IconId = 102
            GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.VENTAS_TARIFAS_SALIR, "Salir", False, False).IconId = 103
        End If

        MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_VENTAS).Visible = True
        MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_VENTAS).Selected = True

        'If MDIPrincipal.RibbonBar.FindTab(DEFMENU.MAESTROS_CLIENTES_FICHA) Is Nothing = False Then
        '    MDIPrincipal.RibbonBar.FindTab(DEFMENU.MAESTROS_CLIENTES_FICHA).Visible = False
        'End If


    End Sub

    Private Sub frmTarifas_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        ConstruirMenu()
        CargarComboProductos()
    End Sub

    Private Sub frmTarifas_Load(sender As Object, e As EventArgs) Handles Me.Load

        cbProducto1.ReCreateReparented = True 'Esto es necesario porque si no los eventos no van
        cbProducto2.ReCreateReparented = True 'Esto es necesario porque si no los eventos no van
        cbTipoCliente.ReCreateReparented = True 'Esto es necesario porque si no los eventos no van

        fTarifas = Me
    End Sub

    Private Sub frmTarifas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        fTarifas = Nothing

        MDIPrincipal.RibbonBar.RemoveTab(DEFMENU.GRUPO_VENTAS)
        'MDIPrincipal.RibbonBar.Reset()
        MDIPrincipal.RibbonBar.RedrawBar()
        MDIPrincipal.RibbonBar.RecalcLayout()

        MDIPrincipal.RibbonBar.FindTab(DEFMENU.TAB_VENTAS).Selected = True
        MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_VENTAS).Visible = False
    End Sub

    Public Sub CargarComboProductos()

        BDProductos.GetProductos(cbProducto1)
        'If cbProducto1.ListCount > 0 Then
        'cbProducto1.ListIndex = 0
        'Else
        cbProducto1.ListIndex = -1
        cbProducto1.AddItem("[Ninguno]")
        'End If

        cbProducto2.AddItem("[Ninguno]")
        BDProductos.GetProductos(cbProducto2)
        'If cbProducto2.ListCount > 0 Then
        'cbProducto2.ListIndex = 0
        'Else
        cbProducto2.ListIndex = -1
        'End If

        cbTipoCliente.AddItem("Cliente Nuevo")
        cbTipoCliente.AddItem("Cliente Registrado")
        cbTipoCliente.AddItem("Cliente con Mantenimiento")

    End Sub

    Private Sub cbProducto1_ClickEvent(sender As Object, e As EventArgs) Handles cbProducto1.ClickEvent
        If cbProducto1.Text <> "" And cbProducto1.Text <> "[Ninguno]" Then
            'RCVersiones.Records.DeleteAll()
            idProducto1 = cbProducto1.get_ItemData(cbProducto1.ListIndex)
            'Dim Record As ReportRecord
            'Dim x As Integer
            Dim objProductos As Producto
            'Dim ArrayVersiones As New ArrayList()
            objProductos = BDProductos.ObtenerUnProducto(idProducto1)

            If objProductos.Red1 = True Then
                chkRed1.Enabled = True
            Else
                chkRed1.Enabled = False
                chkRed1.Value = XtremeSuiteControls.CheckBoxValue.xtpUnchecked
            End If
            If objProductos.IdMantenimiento1 = True Then
                chkMante1.Enabled = True
                chkActu1.Enabled = True
            Else
                chkMante1.Enabled = False
                chkMante1.Value = XtremeSuiteControls.CheckBoxValue.xtpUnchecked
                chkActu1.Enabled = False
                chkActu1.Value = XtremeSuiteControls.CheckBoxValue.xtpUnchecked
            End If

            'ArrayVersiones = objProductos.ArrayVersiones1

            'If Not IsNothing(ArrayVersiones) Then
            '    For Each ObjVersion In ArrayVersiones

            '        Record = RCVersiones.Records.Add()

            '        Record.AddItem(ObjVersion.Id1)
            '        Record.AddItem(ObjVersion.Version1)
            '        Record.AddItem(ObjVersion.Orden1)
            '        Record.AddItem(ObjVersion.Ultima1)
            '        Record.AddItem(ObjVersion.Precio1)
            '        Record.AddItem(ObjVersion.PrecioRed1)
            '        Record.AddItem("")

            '        'If ObjVersion.GetObligatorio1 = True Then
            '        '    For x = 0 To RCVersiones.Columns.Count - 1
            '        '        Record.Item(x).Editable = False
            '        '        Record.Item(x).Focusable = True
            '        '    Next
            '        'End If
            '        Record.Item(COL_AÑADIR).Editable = False
            '    Next

            '    RCVersiones.Populate()
            'End If
        Else
            idProducto1 = 0
        End If

        CalculaTarifa()
    End Sub

    Private Sub cbProducto2_ClickEvent(sender As Object, e As EventArgs) Handles cbProducto2.ClickEvent
        If cbProducto2.Text <> "" And cbProducto2.Text <> "[Ninguno]" Then
            'RCVersiones.Records.DeleteAll()
            idProducto2 = cbProducto2.get_ItemData(cbProducto2.ListIndex)
            'Dim Record As ReportRecord
            'Dim x As Integer
            Dim objProductos As Producto
            'Dim ArrayVersiones As New ArrayList()
            objProductos = BDProductos.ObtenerUnProducto(idProducto2)

            If objProductos.Red1 = True Then
                chkRed2.Enabled = True
            Else
                chkRed2.Enabled = False
                chkRed2.Value = XtremeSuiteControls.CheckBoxValue.xtpUnchecked
            End If
            If objProductos.IdMantenimiento1 = True Then
                chkMante2.Enabled = True
                chkActu2.Enabled = True
            Else
                chkMante2.Enabled = False
                chkMante2.Value = XtremeSuiteControls.CheckBoxValue.xtpUnchecked
                chkActu2.Enabled = False
                chkActu2.Value = XtremeSuiteControls.CheckBoxValue.xtpUnchecked
            End If

            'ArrayVersiones = objProductos.ArrayVersiones1

            'If Not IsNothing(ArrayVersiones) Then
            '    For Each ObjVersion In ArrayVersiones

            '        Record = RCVersiones.Records.Add()

            '        Record.AddItem(ObjVersion.Id1)
            '        Record.AddItem(ObjVersion.Version1)
            '        Record.AddItem(ObjVersion.Orden1)
            '        Record.AddItem(ObjVersion.Ultima1)
            '        Record.AddItem(ObjVersion.Precio1)
            '        Record.AddItem(ObjVersion.PrecioRed1)
            '        Record.AddItem("")

            '        'If ObjVersion.GetObligatorio1 = True Then
            '        '    For x = 0 To RCVersiones.Columns.Count - 1
            '        '        Record.Item(x).Editable = False
            '        '        Record.Item(x).Focusable = True
            '        '    Next
            '        'End If
            '        Record.Item(COL_AÑADIR).Editable = False
            '    Next

            '    RCVersiones.Populate()
            'End If

        Else
            idProducto2 = 0
        End If

        CalculaTarifa()
    End Sub

    Sub CalculaTarifa()

        Dim Precio1 As Double
        Dim Precio2 As Double
        Dim objProducto1 As Producto
        Dim NombreProducto1 As String
        Dim objProducto2 As Producto
        Dim NombreProducto2 As String

        'Para calcular las tarifas tengo que ver si son de pack o producto normal o mante sin mas
        'Los productos normales no tienen marcado chkActu y los packs sí.
        If idProducto1 <> 0 Then
            If chkActu1.Value = XtremeSuiteControls.CheckBoxValue.xtpUnchecked Then
                'No es pack, es producto
                objProducto1 = BDProductos.ObtenerUnProducto(idProducto1)
                NombreProducto1 = objProducto1.Codigo1
                If chkRed1.Value = XtremeSuiteControls.CheckBoxValue.xtpChecked Then
                    Precio1 = objProducto1.PrecioRed1
                Else
                    Precio1 = objProducto1.Precio1
                End If
            End If
        End If
        If idProducto2 <> 0 Then
            If chkActu2.Value = XtremeSuiteControls.CheckBoxValue.xtpUnchecked Then
                'No es pack, es producto
                objProducto2 = BDProductos.ObtenerUnProducto(idProducto2)
                NombreProducto2 = objProducto2.Codigo1
                If chkRed2.Value = XtremeSuiteControls.CheckBoxValue.xtpChecked Then
                    Precio2 = objProducto2.PrecioRed1
                Else
                    Precio2 = objProducto2.Precio1
                End If
            End If
        End If

        lblPrecio.Caption = Format(Precio1 + Precio2, FormatoImporte)
        lblPrecioIva.Caption = Format((Precio1 + Precio2) * 1.21, FormatoImporte)
    End Sub

    Private Sub chkRed1_ClickEvent(sender As Object, e As EventArgs) Handles chkRed1.ClickEvent
        CalculaTarifa()
    End Sub

    Private Sub chkRed2_ClickEvent(sender As Object, e As EventArgs) Handles chkRed2.ClickEvent
        CalculaTarifa()
    End Sub

    Private Sub chkMante1_ClickEvent(sender As Object, e As EventArgs) Handles chkMante1.ClickEvent
        CalculaTarifa()
    End Sub

    Private Sub chkMante2_ClickEvent(sender As Object, e As EventArgs) Handles chkMante2.ClickEvent
        CalculaTarifa()
    End Sub

    Private Sub chkActu1_ClickEvent(sender As Object, e As EventArgs) Handles chkActu1.ClickEvent
        CalculaTarifa()
    End Sub

    Private Sub chkActu2_ClickEvent(sender As Object, e As EventArgs) Handles chkActu2.ClickEvent
        CalculaTarifa()
    End Sub

    Private Sub cbTipoCliente_ClickEvent(sender As Object, e As EventArgs) Handles cbTipoCliente.ClickEvent
        CalculaTarifa()
    End Sub
End Class