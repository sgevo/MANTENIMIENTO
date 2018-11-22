Imports AxXtremeReportControl
Imports XtremeReportControl
Imports MantEvolution.DefinicionesMenus
Imports AxXtremeSuiteControls
Imports AxXtremeShortcutBar
Imports System.ComponentModel

Public Class FrmEstadisticasVentas
    Public Permisos As Long

    Const COL_ID = 0
    Const COL_RAZONSOCIAL = 1
    Const COL_NOMBRECOMERCIAL = 2
    Const COL_CIF = 3
    Const COL_DIRECCION = 4
    Const COL_CP = 5
    Const COL_POBLACION = 6
    Const COL_TELEFONO1 = 7
    Const COL_TELEFONO2 = 8
    Const COL_MOVIL = 9
    Const COL_EMAIL1 = 10
    Const COL_EMAIL2 = 11
    Const COL_EMAIL3 = 12
    Const COL_EMAIL4 = 13

    Const COL_TOTIMP = 0
    Const COL_TOTUNI = 1
    Const COL_ENEIMP = 2
    Const COL_ENEUNI = 3
    Const COL_FEBIMP = 4
    Const COL_FEBUNI = 5
    Const COL_MARIMP = 6
    Const COL_MARUNI = 7
    Const COL_ABRIMP = 8
    Const COL_ABRUNI = 9
    Const COL_MAYIMP = 10
    Const COL_MAYUNI = 11
    Const COL_JUNIMP = 12
    Const COL_JUNUNI = 13
    Const COL_JULIMP = 14
    Const COL_JULUNI = 15
    Const COL_AGOIMP = 16
    Const COL_AGOUNI = 17
    Const COL_SEPIMP = 18
    Const COL_SEPUNI = 19
    Const COL_OCTIMP = 20
    Const COL_OCTUNI = 21
    Const COL_NOVIMP = 22
    Const COL_NOVUNI = 23
    Const COL_DICIMP = 24
    Const COL_DICUNI = 25

    Dim HayErrores As Boolean

    Dim tabVentasImporte(13) As Double
    Dim tabVentasUnidades(13) As Double

    Dim TabPantalla As XtremeCommandBars.RibbonTab = Nothing
    Dim GroupFile As XtremeCommandBars.RibbonGroup = Nothing


    Sub ConfigurarPantalla()
        Titulo.Top = 0
        Titulo.Left = 0
        Titulo.Width = Me.Width

        cbTipoProductos.Left = 10
        lblcbTipo.Left = cbTipoProductos.Left
        cbProductos.Left = cbTipoProductos.Left + cbTipoProductos.Width + 10
        lblcbProducto.Left = cbProductos.Left

        cbEnviar.Left = 10
        lblEnviar.Left = 10

        cbTelefono.Left = 10
        lblCbTelefono.Left = cbTelefono.Left
        cbMail.Left = cbTelefono.Left + cbTelefono.Width + 10
        lblCbMail.Left = cbMail.Left

        chSinPyM.Left = lblcbProducto.Left

        RCClientes.Left = cbProductos.Left + cbProductos.Width + 10
        RCClientes.Width = Me.Width - RCClientes.Left - 20
        lblClientes.Left = RCClientes.Left

        RCVentasMes.Left = RCClientes.Left
        RCVentasMes.Width = RCClientes.Width
        lblVentas.Left = RCClientes.Left

        lblPacks.Left = 10
        lblProductos.Left = 10
        lblMantes.Left = 10

        lblClientesPack.Left = 10
        lblClientesProducto.Left = 10
        lblClientesMante.Left = 10

        'scMovimientos.Left = lblProductos.Width + 20
        'scMovimientos.Width = Me.Width - lblProductos.Width - 40

        'RCMovimientos.Left = lblProductos.Width + 20
        'RCMovimientos.Width = Me.Width - lblProductos.Width - 40
        'RCProductos.Left = lblProductos.Width + 20
        'RCProductos.Width = Me.Width - lblProductos.Width - 40

        'RCProductos.Top = Titulo.Height
        'RCProductos.Height = Me.Height - RCProductos.Top - 20

    End Sub

    Public Sub AplicaEstilo()

        Dim X As Object

        For Each X In Me.Controls
            AplicaEstiloControl(X)
        Next X

    End Sub

    Private Sub FrmEstadisticasVentas_Load(sender As Object, e As EventArgs) Handles Me.Load

        cbTipoProductos.ReCreateReparented = True 'Esto es necesario porque si no los eventos no van
        cbProductos.ReCreateReparented = True 'Esto es necesario porque si no los eventos no van

        With RCClientes
            .PaintManager.CaptionFont.Name = "Tahoma"
            .PaintManager.CaptionFont.Bold = True

            .PaintManager.TextFont.Name = "Tahoma"

            .PaintManager.UseAlternativeBackground = True
            .PaintManager.AlternativeBackgroundColor = CUInt(RGB(242, 242, 242))

            .PaintManager.FreezeColsDividerColor = CUInt(RGB(0, 0, 0))
            .PaintManager.NoItemsText = "No hay elementos que mostrar"
            .FullColumnScrolling = True
            .AutoColumnSizing = False

            .FocusSubItems = False
            .PaintManager.ShowNonActiveInPlaceButton = True

            .ScrollModeH = XTPReportScrollMode.xtpReportScrollModeSmooth
            .ScrollModeV = XTPReportScrollMode.xtpReportScrollModeSmooth

            .AllowSort = False
            .Records.DeleteAll()
            .Columns.DeleteAll()

            .Populate()
            .Navigator.MoveLastRow()
        End With

        With RCVentasMes
            .PaintManager.CaptionFont.Name = "Tahoma"
            .PaintManager.CaptionFont.Bold = True

            .PaintManager.TextFont.Name = "Tahoma"

            .PaintManager.UseAlternativeBackground = True
            .PaintManager.AlternativeBackgroundColor = CUInt(RGB(242, 242, 242))

            .PaintManager.FreezeColsDividerColor = CUInt(RGB(0, 0, 0))
            .PaintManager.NoItemsText = "No hay elementos que mostrar"
            .FullColumnScrolling = True
            .AutoColumnSizing = False

            .FocusSubItems = False
            .PaintManager.ShowNonActiveInPlaceButton = True

            .ScrollModeH = XTPReportScrollMode.xtpReportScrollModeSmooth
            .ScrollModeV = XTPReportScrollMode.xtpReportScrollModeSmooth

            .AllowSort = False
            .Records.DeleteAll()
            .Columns.DeleteAll()

            .Populate()
            .Navigator.MoveLastRow()
        End With

        '''''''''''
        RCClientes.PaintManager.ColumnStyle = XTPReportColumnStyle.xtpColumnResource
        RCClientes.AllowEdit = False
        RCClientes.Columns.Add(COL_ID, "Cod. Cliente", 100, True)
        RCClientes.Columns.Add(COL_RAZONSOCIAL, "Razón Social", 250, True)
        RCClientes.Columns.Add(COL_NOMBRECOMERCIAL, "Nombre Comercial", 250, True)
        RCClientes.Columns.Add(COL_CIF, "CIF / NIF", 60, True)
        RCClientes.Columns.Add(COL_DIRECCION, "Dirección", 150, True)
        RCClientes.Columns.Add(COL_CP, "CP", 50, True)
        RCClientes.Columns.Add(COL_POBLACION, "Población", 100, True)
        RCClientes.Columns.Add(COL_TELEFONO1, "Teléf 1", 100, True)
        RCClientes.Columns.Add(COL_TELEFONO2, "Teléf 2", 100, True)
        RCClientes.Columns.Add(COL_MOVIL, "Movil", 100, True)
        RCClientes.Columns.Add(COL_EMAIL1, "Email 1", 100, True)
        RCClientes.Columns.Add(COL_EMAIL2, "Email 2", 100, True)
        RCClientes.Columns.Add(COL_EMAIL3, "Email 3", 100, True)
        RCClientes.Columns.Add(COL_EMAIL4, "Email 4", 100, True)

        RCVentasMes.PaintManager.ColumnStyle = XTPReportColumnStyle.xtpColumnResource
        RCVentasMes.AllowEdit = False
        RCVentasMes.Columns.Add(COL_TOTIMP, "TOTAL", 60, True)
        RCVentasMes.Columns.Add(COL_TOTUNI, "", 40, True)
        RCVentasMes.Columns.Add(COL_ENEIMP, "ENERO", 60, True)
        RCVentasMes.Columns.Add(COL_ENEUNI, "", 40, True)
        RCVentasMes.Columns.Add(COL_FEBIMP, "FEBRERO", 60, True)
        RCVentasMes.Columns.Add(COL_FEBUNI, "", 40, True)
        RCVentasMes.Columns.Add(COL_MARIMP, "MARZO", 60, True)
        RCVentasMes.Columns.Add(COL_MARUNI, "", 40, True)
        RCVentasMes.Columns.Add(COL_ABRIMP, "ABRIL", 60, True)
        RCVentasMes.Columns.Add(COL_ABRUNI, "", 40, True)
        RCVentasMes.Columns.Add(COL_MAYIMP, "MAYO", 60, True)
        RCVentasMes.Columns.Add(COL_MAYUNI, "", 40, True)
        RCVentasMes.Columns.Add(COL_JUNIMP, "JUNIO", 60, True)
        RCVentasMes.Columns.Add(COL_JUNUNI, "", 40, True)
        RCVentasMes.Columns.Add(COL_JULIMP, "JULIO", 60, True)
        RCVentasMes.Columns.Add(COL_JULUNI, "", 40, True)
        RCVentasMes.Columns.Add(COL_AGOIMP, "AGOSTO", 60, True)
        RCVentasMes.Columns.Add(COL_AGOUNI, "", 40, True)
        RCVentasMes.Columns.Add(COL_SEPIMP, "SEPTIEMBRE", 60, True)
        RCVentasMes.Columns.Add(COL_SEPUNI, "", 40, True)
        RCVentasMes.Columns.Add(COL_OCTIMP, "OCTUBRE", 60, True)
        RCVentasMes.Columns.Add(COL_OCTUNI, "", 40, True)
        RCVentasMes.Columns.Add(COL_NOVIMP, "NOVIEMBRE", 60, True)
        RCVentasMes.Columns.Add(COL_NOVUNI, "", 40, True)
        RCVentasMes.Columns.Add(COL_DICIMP, "DICIEMBRE", 60, True)
        RCVentasMes.Columns.Add(COL_DICUNI, "", 40, True)


        cbTipoProductos.AddItem("PACKS")
        cbTipoProductos.AddItem("MANTENIMIENTOS")
        cbTipoProductos.AddItem("PRODUCTOS")
        cbTipoProductos.AddItem("PACKS y MANTES")

        cbTelefono.AddItem("(todos)")
        cbTelefono.AddItem("Sin Teléfono")
        cbTelefono.AddItem("Con Teléfono")
        cbTelefono.ListIndex = 0

        cbMail.AddItem("(todos)")
        cbMail.AddItem("Sin Mail")
        cbMail.AddItem("Con Mail")
        cbMail.ListIndex = 0

        cbEnviar.AddItem("(todos)")
        cbEnviar.AddItem("Marcados")
        cbEnviar.ListIndex = 1

        lblPacks.Caption = "Packs Totales: " & CStr(ObtenerProductosTotalesTipo(2))
        lblProductos.Caption = "Productos Totales: " & CStr(ObtenerProductosTotalesTipo(0))
        lblMantes.Caption = "Mantenimientos Totales: " & CStr(ObtenerProductosTotalesTipo(1))

        lblClientesPack.Caption = "Clientes con Pack: " & CStr(ObtenerClientesProductoTipo(2).Count)
        lblClientesProducto.Caption = "Clientes con Producto: " & CStr(ObtenerClientesProductoTipo(0).Count)
        lblClientesMante.Caption = "Clientes con Mantenimiento: " & CStr(ObtenerClientesProductoTipo(1).Count)

        fEstadisticasVentas = Me
    End Sub

    Private Sub FrmEstadisticasVentas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        fEstadisticasVentas = Nothing

        MDIPrincipal.RibbonBar.RemoveTab(DEFMENU.GRUPO_ESTADIS_VENTAS)
        'MDIPrincipal.RibbonBar.Reset()
        MDIPrincipal.RibbonBar.RedrawBar()
        MDIPrincipal.RibbonBar.RecalcLayout()

        MDIPrincipal.RibbonBar.FindTab(DEFMENU.TAB_PRINCIPAL).Selected = True
        MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_ESTADIS_VENTAS).Visible = False
    End Sub

    Sub ConstruirMenu()

        If MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_ESTADIS_VENTAS) Is Nothing Then 'si no existe lo creo
            TabPantalla = MDIPrincipal.RibbonBar.InsertTab(DEFMENU.GRUPO_ESTADIS_VENTAS, "&Estad.Ventas")
            TabPantalla.Id = DEFMENU.GRUPO_ESTADIS_VENTAS

            'GroupFile = TabPrincipal.Groups.AddGroup("&MANTE", 1001)
            'GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.PRINCIPAL_MANTENIMIENTO, "Mantenimiento", False, False)
            GroupFile = TabPantalla.Groups.AddGroup("&ESTAD.VENTAS", DEFMENU.GRUPO_ESTADIS_VENTAS)
            GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.ESTADIS_VENTAS_IMPRIMIR, "Imprimir", False, False).IconId = 102
            GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.ESTADIS_VENTAS_EXCEL_CLIENTES, "Excel Clientes", False, False).IconId = 104
            GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.ESTADIS_VENTAS_EXCEL_VENTAS, "Excel Ventas", False, False).IconId = 104
            GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.ESTADIS_VENTAS_SALIR, "Salir", False, False).IconId = 103
        End If

        MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_ESTADIS_VENTAS).Visible = True
        MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_ESTADIS_VENTAS).Selected = True

    End Sub

    Sub Menu_Imprimir()

    End Sub

    Sub Menu_ExcelClientes()
        ExportToExcel(RCClientes,, "")
    End Sub

    Sub Menu_ExcelVentas()
        ExportToExcel(RCVentasMes,, "001,002,003,004,005,006,007,008,009,010,011,012,013,014,015,016,017,018,019,020,021,022,023,024,025,026")
    End Sub

    Private Sub FrmEstadisticasVentas_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        ConstruirMenu()
    End Sub

    Private Sub FrmEstadisticasVentas_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        ConfigurarPantalla()
    End Sub

    Private Sub cbTipoProductos_ClickEvent(sender As Object, e As EventArgs) Handles cbTipoProductos.ClickEvent
        Dim arrayProductos As New ArrayList
        Dim objProductosCliente As Producto
        Dim arrayPacks As New ArrayList
        Dim objPacks As Pack
        Dim i As Integer

        lblClientes.Caption = "Clientes por Producto "
        RCClientes.Records.DeleteAll()
        RCClientes.Populate()
        RCVentasMes.Records.DeleteAll()
        RCVentasMes.Populate()

        cbProductos.Clear()
        cbProductos.AddItem("(todos)")
        If cbTipoProductos.ListIndex = 0 Then 'packs
            lblVentas.Visible = True
            RCVentasMes.Visible = True
            chSinPyM.Visible = False
            cbProductos.Enabled = True
            txtVariacion.Enabled = True
            upVariacion.Enabled = True
            btnActualiza.Enabled = True
            arrayPacks = ObtenerPacks()
            i = 1 'tengo ya metido (todos)
            For Each objPacks In arrayPacks
                cbProductos.AddItem(objPacks.Descripcion1, objPacks, objPacks)
                cbProductos.set_ItemData(i, objPacks)
                i = i + 1
            Next
        ElseIf cbTipoProductos.ListIndex = 1 Then 'mantes
            lblVentas.Visible = True
            RCVentasMes.Visible = True
            chSinPyM.Visible = False
            cbProductos.Enabled = True
            txtVariacion.Enabled = True
            upVariacion.Enabled = True
            btnActualiza.Enabled = True
            arrayProductos = ObtenerProductosTipo(2)
            For Each objProductos In arrayProductos
                cbProductos.AddItem(objProductos.Codigo1, objProductos, objProductos)
            Next
        ElseIf cbTipoProductos.ListIndex = 2 Then 'productos
            lblVentas.Visible = False
            RCVentasMes.Visible = False
            chSinPyM.Visible = True
            cbProductos.Enabled = True
            txtVariacion.Enabled = False
            upVariacion.Enabled = False
            btnActualiza.Enabled = False
            arrayProductos = ObtenerProductosTipo(0)
            i = 1 'tengo ya metido (todos)
            For Each objProductos In arrayProductos
                cbProductos.AddItem(objProductos.Codigo1)
                cbProductos.set_ItemData(i, objProductos)
                i = i + 1
            Next
        ElseIf cbTipoProductos.ListIndex = 3 Then 'packs y mantes
            lblVentas.Visible = True
            RCVentasMes.Visible = True
            chSinPyM.Visible = False
            cbProductos.Enabled = False
            txtVariacion.Enabled = True
            upVariacion.Enabled = True
            btnActualiza.Enabled = True
            CargarClientes()
            CargarVentas()
        End If
    End Sub

    Private Sub cbProductos_ClickEvent(sender As Object, e As EventArgs) Handles cbProductos.ClickEvent
        RCClientes.Records.DeleteAll()
        RCClientes.Populate()
        RCVentasMes.Records.DeleteAll()
        RCVentasMes.Populate()
        CargarClientes()
        CargarVentas()
    End Sub

    Sub CargarClientes()
        Dim MiProducto As Producto
        Dim MiPack As Pack
        Dim ArrayClientes As ArrayList
        Dim idClientes As Long
        Dim ElCliente As Cliente
        Dim x As Long

        Dim Record As ReportRecord

        Dim ArrayMail() As String

        If cbTipoProductos.ListIndex = 0 Then 'Packs
            MiPack = cbProductos.get_ItemData(cbProductos.ListIndex)

            If cbProductos.ListIndex = 0 Then
                'he seleccionado todos, tengo que buscar por tipo
                ArrayClientes = ObtenerClientesProductoTipo(2) 'Packs
            Else
                ArrayClientes = ObtenerClientesPack(MiPack.Id1)
            End If

            lblClientes.Caption = "Clientes y Distribuidores con Pack: " & ArrayClientes.Count
        ElseIf cbTipoProductos.ListIndex <> 3 Then
            MiProducto = cbProductos.get_ItemData(cbProductos.ListIndex)

            If cbProductos.ListIndex = 0 Then
                'he seleccionado todos, tengo que buscar por tipo
                If cbTipoProductos.ListIndex = 1 Then
                    ArrayClientes = ObtenerClientesProductoTipo(1) 'Mantes
                ElseIf cbTipoProductos.ListIndex = 2 Then
                    If chSinPyM.Value = XtremeSuiteControls.CheckBoxValue.xtpUnchecked Then
                        ArrayClientes = ObtenerClientesProductoTipo(0) 'Productos Todos
                    Else
                        ArrayClientes = ObtenerClientesProductoTipo(4) 'Productos Sin Pack ni Mante
                    End If
                End If
            Else
                ArrayClientes = ObtenerClientesProducto(MiProducto.Id1)
            End If
            If cbTipoProductos.ListIndex = 1 Then
                lblClientes.Caption = "Clientes y Distribuidores con Mantenimiento: " & ArrayClientes.Count
            Else
                lblClientes.Caption = "Clientes y Distribuidores con Producto: " & ArrayClientes.Count
            End If
        Else 'packs y mantes
            ArrayClientes = ObtenerClientesProductoTipo(3) 'Packs y Mantes 
            lblClientes.Caption = "Clientes y Distribuidores Pack y Mante: " & ArrayClientes.Count
        End If


        RCClientes.Records.DeleteAll()
        RCClientes.Populate()

        If ArrayClientes.Count > 50 Then
            Dim response = MsgBox("Hay " & ArrayClientes.Count & " Clientes, desea visualizarlos? " & Chr(13) & "Este proceso puede ser largo.", MsgBoxStyle.YesNo)
            If response = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        Debug.Print("Empiezo: " & Now)

        Dim ArrayTodosClientes As New ArrayList()
        Dim objTodosClientes As Cliente
        ArrayTodosClientes = ObtenerTodosLosClientes()

        For Each idClientes In ArrayClientes

            'Esto es muyyyyy lento
            'ElCliente = ObtenerUnCliente(idClientes)
            'Debug.Print(idClientes)

            For Each objTodosClientes In ArrayTodosClientes
                If objTodosClientes.Id1 = idClientes Then
                    ElCliente = objTodosClientes
                    Exit For
                End If
            Next

            If Not IsNothing(ElCliente) Then
                'aqui tengo que quitar o dejar los clientes con telefono o mail según selección
                'Los combos.listindex=0 todos, =1 sin, =2 con
                'Busco clientes con telefono                
                If cbTelefono.ListIndex = 2 And ((ElCliente.Telefono1 = "" And ElCliente.Telefono21 = "" And ElCliente.Movil1 = "")) Then
                    'busco clientes sin telefono
                ElseIf cbTelefono.ListIndex = 1 And (ElCliente.Telefono1 <> "" Or ElCliente.Telefono21 <> "" Or ElCliente.Movil1 <> "") Then
                    'busco clientes con mail
                ElseIf cbMail.ListIndex = 2 And ElCliente.Email1 = "" Then
                    'busco clientes sin mail
                ElseIf cbMail.ListIndex = 1 And ElCliente.Email1 <> "" Then
                    'busco clientes no enviar informacion
                ElseIf cbEnviar.ListIndex = 1 And ElCliente.EnviarInfo1 = False Then
                Else
                    Record = RCClientes.Records.Add()

                    Record.AddItem(ElCliente.Id1)
                    Record.AddItem(ElCliente.NombreComercial1)
                    Record.AddItem(ElCliente.RazonSocial1)
                    Record.AddItem(ElCliente.Cif1)
                    Record.AddItem(ElCliente.Direccion1)
                    Record.AddItem(ElCliente.CP1)
                    Record.AddItem(ElCliente.Poblacion1)
                    Record.AddItem(ElCliente.Telefono1)
                    Record.AddItem(ElCliente.Telefono21)
                    Record.AddItem(ElCliente.Movil1)

                    ArrayMail = Split(ElCliente.Email1, ";")
                    For x = 0 To ArrayMail.Count - 1
                        Record.AddItem(ArrayMail(x))
                    Next x
                    For x = ArrayMail.Count To 3
                        Record.AddItem("")
                    Next

                End If

            End If

        Next
        Debug.Print("Termino: " & Now)

        RCClientes.Populate()

        MsgBox("Clientes seleccionados: " & RCClientes.Records.Count)
    End Sub

    Sub CargarVentas()
        Dim Record As ReportRecord
        Dim x As Long
        Dim Variacion As Double

        Variacion = CDbl(Microsoft.VisualBasic.Left(txtVariacion.Text, Len(txtVariacion.Text) - 1))
        If Variacion <> 0 Then
            Variacion = (100 + Variacion) / 100
            'ElseIf Variacion <0 Then
            '    Variacion = (100 - Variacion) / 100
        Else
            Variacion = 1 'si variacion es 0%
        End If

        RCVentasMes.Records.DeleteAll()
        For x = 0 To 12
            tabVentasImporte(x) = 0
            tabVentasUnidades(x) = 0
        Next

        If cbTipoProductos.ListIndex = 2 Then 'Con los Productos no calcula
            Exit Sub
        End If

        Record = RCVentasMes.Records.Add()

        Record.AddItem("Importe")
        Record.AddItem("Unid.")
        Record.AddItem("Importe")
        Record.AddItem("Unid.")
        Record.AddItem("Importe")
        Record.AddItem("Unid.")
        Record.AddItem("Importe")
        Record.AddItem("Unid.")
        Record.AddItem("Importe")
        Record.AddItem("Unid.")
        Record.AddItem("Importe")
        Record.AddItem("Unid.")
        Record.AddItem("Importe")
        Record.AddItem("Unid.")
        Record.AddItem("Importe")
        Record.AddItem("Unid.")
        Record.AddItem("Importe")
        Record.AddItem("Unid.")
        Record.AddItem("Importe")
        Record.AddItem("Unid.")
        Record.AddItem("Importe")
        Record.AddItem("Unid.")
        Record.AddItem("Importe")
        Record.AddItem("Unid.")
        Record.AddItem("Importe")
        Record.AddItem("Unid.")

        RCVentasMes.Populate()

        Dim ArrayProductos As New ArrayList
        Dim ArrayPacks As New ArrayList
        Dim objProducto As Producto
        Dim objProductoCliente As ProductosCliente

        Dim objPack As Pack

        Dim ArrayMaestroProductos As ArrayList
        Dim CadaProducto As Producto
        Dim CadaPack As Pack

        If cbTipoProductos.ListIndex = 0 Then 'PACKS
            objPack = cbProductos.get_ItemData(cbProductos.ListIndex)

            If cbProductos.ListIndex = 0 Then
                '    'he seleccionado todos, tengo que buscar por tipo
                '    ArrayClientes = ObtenerClientesProductoTipo(2) 'Packs
                ArrayProductos = ObtenerProductosClienteTipo(2) 'Mantes, ProductosCliente
            Else
                ArrayProductos = ObtenerProductosClientePack(objPack.Id1)
            End If

            'lblClientes.Caption = "Clientes por Pack: " & ArrayClientes.Count

            ArrayPacks = ObtenerPacks()
            'lblClientes.Caption = "Clientes por Producto: " & ArrayClientes.Count

            For Each objProductoCliente In ArrayProductos
                tabVentasUnidades(0) = tabVentasUnidades(0) + 1 'Total de unidades
                tabVentasUnidades(Month(objProductoCliente.FechaInicioServicio1)) = tabVentasUnidades(Month(objProductoCliente.FechaInicioServicio1)) + 1 'Total de cada mes
                For Each CadaPack In ArrayPacks
                    If CadaPack.Id1 = objProductoCliente.Id_Pack1 Then
                        If Month(objProductoCliente.FechaInicioServicio1) = 7 Then
                            Debug.Print("Cliente: " & objProductoCliente.objCliente1.Id1)
                        End If
                        tabVentasImporte(0) = tabVentasImporte(0) + (CadaPack.Precio1 * Variacion)
                        tabVentasImporte(Month(objProductoCliente.FechaInicioServicio1)) = tabVentasImporte(Month(objProductoCliente.FechaInicioServicio1)) + (CadaPack.Precio1 * Variacion)
                        Exit For
                    End If
                Next
            Next

        End If

        If cbTipoProductos.ListIndex = 1 Then 'MANTES
            objProducto = cbProductos.get_ItemData(cbProductos.ListIndex)

            If cbProductos.ListIndex = 0 Then
                'he seleccionado todos, tengo que buscar por tipo
                If cbTipoProductos.ListIndex = 1 Then
                    ArrayProductos = ObtenerProductosClienteTipo(1) 'Mantes, ProductosCliente
                ElseIf cbTipoProductos.ListIndex = 2 Then
                    ArrayProductos = ObtenerProductosClienteTipo(0) 'Productos
                End If
            Else
                ArrayProductos = ObtenerProductosClienteProducto(objProducto.Id1)
            End If

            ArrayMaestroProductos = ObtenerProductosTipo(2) 'Estos son los Mantes en la tabla de Productos
            'lblClientes.Caption = "Clientes por Producto: " & ArrayClientes.Count

            For Each objProductoCliente In ArrayProductos
                tabVentasUnidades(0) = tabVentasUnidades(0) + 1 'Total de unidades
                tabVentasUnidades(Month(objProductoCliente.FechaInicioServicio1)) = tabVentasUnidades(Month(objProductoCliente.FechaInicioServicio1)) + 1 'Total de cada mes
                For Each CadaProducto In ArrayMaestroProductos
                    If CadaProducto.Id1 = objProductoCliente.Id_Producto1 Then
                        If Month(objProductoCliente.FechaInicioServicio1) = 9 Then
                            Debug.Print("Cliente: " & objProductoCliente.objCliente1.Id1)
                        End If
                        If objProductoCliente.Red11 = False Then
                            tabVentasImporte(0) = tabVentasImporte(0) + (CadaProducto.Precio1 * Variacion)
                            tabVentasImporte(Month(objProductoCliente.FechaInicioServicio1)) = tabVentasImporte(Month(objProductoCliente.FechaInicioServicio1)) + (CadaProducto.Precio1 * Variacion)
                        Else
                            tabVentasImporte(0) = tabVentasImporte(0) + (CadaProducto.PrecioRed1 * Variacion)
                            tabVentasImporte(Month(objProductoCliente.FechaInicioServicio1)) = tabVentasImporte(Month(objProductoCliente.FechaInicioServicio1)) + (CadaProducto.PrecioRed1 * Variacion)
                        End If
                        Exit For
                    End If
                Next
            Next

        End If

        If cbTipoProductos.ListIndex = 3 Then 'PACKS y MANTES
            'PACKS
            objPack = cbProductos.get_ItemData(cbProductos.ListIndex)

            ArrayProductos = ObtenerProductosClienteTipo(2) 'Mantes, ProductosCliente

            ArrayPacks = ObtenerPacks()

            For Each objProductoCliente In ArrayProductos
                tabVentasUnidades(0) = tabVentasUnidades(0) + 1 'Total de unidades
                tabVentasUnidades(Month(objProductoCliente.FechaInicioServicio1)) = tabVentasUnidades(Month(objProductoCliente.FechaInicioServicio1)) + 1 'Total de cada mes
                For Each CadaPack In ArrayPacks
                    If CadaPack.Id1 = objProductoCliente.Id_Pack1 Then
                        If Month(objProductoCliente.FechaInicioServicio1) = 7 Then
                            Debug.Print("Cliente: " & objProductoCliente.objCliente1.Id1)
                        End If
                        tabVentasImporte(0) = tabVentasImporte(0) + (CadaPack.Precio1 * Variacion)
                        tabVentasImporte(Month(objProductoCliente.FechaInicioServicio1)) = tabVentasImporte(Month(objProductoCliente.FechaInicioServicio1)) + (CadaPack.Precio1 * Variacion)
                        Exit For
                    End If
                Next
            Next

            'MANTES
            objProducto = cbProductos.get_ItemData(cbProductos.ListIndex)

            ArrayProductos = ObtenerProductosClienteTipo(1) 'Mantes, ProductosCliente

            ArrayMaestroProductos = ObtenerProductosTipo(2) 'Estos son los Mantes en la tabla de Productos

            For Each objProductoCliente In ArrayProductos
                tabVentasUnidades(0) = tabVentasUnidades(0) + 1 'Total de unidades
                tabVentasUnidades(Month(objProductoCliente.FechaInicioServicio1)) = tabVentasUnidades(Month(objProductoCliente.FechaInicioServicio1)) + 1 'Total de cada mes
                For Each CadaProducto In ArrayMaestroProductos
                    If CadaProducto.Id1 = objProductoCliente.Id_Producto1 Then
                        If Month(objProductoCliente.FechaInicioServicio1) = 9 Then
                            Debug.Print("Cliente: " & objProductoCliente.objCliente1.Id1)
                        End If
                        If objProductoCliente.Red11 = False Then
                            tabVentasImporte(0) = tabVentasImporte(0) + (CadaProducto.Precio1 * Variacion)
                            tabVentasImporte(Month(objProductoCliente.FechaInicioServicio1)) = tabVentasImporte(Month(objProductoCliente.FechaInicioServicio1)) + (CadaProducto.Precio1 * Variacion)
                        Else
                            tabVentasImporte(0) = tabVentasImporte(0) + (CadaProducto.PrecioRed1 * Variacion)
                            tabVentasImporte(Month(objProductoCliente.FechaInicioServicio1)) = tabVentasImporte(Month(objProductoCliente.FechaInicioServicio1)) + (CadaProducto.PrecioRed1 * Variacion)
                        End If
                        Exit For
                    End If
                Next
            Next

        End If

        Record = RCVentasMes.Records.Add()
        Record.AddItem(Format(tabVentasImporte(0), "#,##0.00"))
        Record.AddItem(tabVentasUnidades(0))
        Record.AddItem(Format(tabVentasImporte(1), "#,##0.00"))
        Record.AddItem(tabVentasUnidades(1))
        Record.AddItem(Format(tabVentasImporte(2), "#,##0.00"))
        Record.AddItem(tabVentasUnidades(2))
        Record.AddItem(Format(tabVentasImporte(3), "#,##0.00"))
        Record.AddItem(tabVentasUnidades(3))
        Record.AddItem(Format(tabVentasImporte(4), "#,##0.00"))
        Record.AddItem(tabVentasUnidades(4))
        Record.AddItem(Format(tabVentasImporte(5), "#,##0.00"))
        Record.AddItem(tabVentasUnidades(5))
        Record.AddItem(Format(tabVentasImporte(6), "#,##0.00"))
        Record.AddItem(tabVentasUnidades(6))
        Record.AddItem(Format(tabVentasImporte(7), "#,##0.00"))
        Record.AddItem(tabVentasUnidades(7))
        Record.AddItem(Format(tabVentasImporte(8), "#,##0.00"))
        Record.AddItem(tabVentasUnidades(8))
        Record.AddItem(Format(tabVentasImporte(9), "#,##0.00"))
        Record.AddItem(tabVentasUnidades(9))
        Record.AddItem(Format(tabVentasImporte(10), "#,##0.00"))
        Record.AddItem(tabVentasUnidades(10))
        Record.AddItem(Format(tabVentasImporte(11), "#,##0.00"))
        Record.AddItem(tabVentasUnidades(11))
        Record.AddItem(Format(tabVentasImporte(12), "#,##0.00"))
        Record.AddItem(tabVentasUnidades(12))

        RCVentasMes.Populate()

    End Sub

    Private Sub upVariacion_UpClick(sender As Object, e As EventArgs) Handles upVariacion.UpClick
        txtVariacion.Text = Format(CDbl(Microsoft.VisualBasic.Left(txtVariacion.Text, Len(txtVariacion.Text) - 1) + 1), "#0.00") & "%"
    End Sub

    Private Sub upVariacion_DownClick(sender As Object, e As EventArgs) Handles upVariacion.DownClick
        txtVariacion.Text = Format(CDbl(Microsoft.VisualBasic.Left(txtVariacion.Text, Len(txtVariacion.Text) - 1) - 1), "#0.00") & "%"
    End Sub

    Private Sub txtVariacion_GotFocus(sender As Object, e As EventArgs) Handles txtVariacion.GotFocus
        txtVariacion.SelStart = 0
        txtVariacion.SelLength = Len(txtVariacion.Text)
    End Sub

    Private Sub txtVariacion_KeyPressEvent(sender As Object, e As _DFlatEditEvents_KeyPressEvent) Handles txtVariacion.KeyPressEvent
        Retorno(e.keyAscii)
    End Sub

    Private Sub txtVariacion_LostFocus(sender As Object, e As EventArgs) Handles txtVariacion.LostFocus
        If Microsoft.VisualBasic.Right(txtVariacion.Text, 1) <> "%" Then
            txtVariacion.Text = txtVariacion.Text & "%"
        End If
        CargarVentas()
    End Sub

    Private Sub btnActualiza_ClickEvent(sender As Object, e As EventArgs) Handles btnActualiza.ClickEvent
        CargarVentas()
    End Sub

    Private Sub chSinPyM_ClickEvent(sender As Object, e As EventArgs) Handles chSinPyM.ClickEvent
        If cbTipoProductos.ListIndex <> -1 And cbProductos.ListIndex <> -1 Then
            CargarClientes()
        End If
    End Sub

    Private Sub cbTelefono_ClickEvent(sender As Object, e As EventArgs) Handles cbTelefono.ClickEvent
        If cbProductos.ListIndex <> -1 And cbTipoProductos.ListIndex <> -1 Then
            RCClientes.Records.DeleteAll()
            RCClientes.Populate()
            RCVentasMes.Records.DeleteAll()
            RCVentasMes.Populate()
            CargarClientes()
            CargarVentas()
        End If
    End Sub

    Private Sub cbMail_ClickEvent(sender As Object, e As EventArgs) Handles cbMail.ClickEvent
        If cbProductos.ListIndex <> -1 And cbTipoProductos.ListIndex <> -1 Then
            RCClientes.Records.DeleteAll()
            RCClientes.Populate()
            RCVentasMes.Records.DeleteAll()
            RCVentasMes.Populate()
            CargarClientes()
            CargarVentas()
        End If
    End Sub

    Private Sub cbEnviar_ClickEvent(sender As Object, e As EventArgs) Handles cbEnviar.ClickEvent
        If cbProductos.ListIndex <> -1 And cbTipoProductos.ListIndex <> -1 Then
            RCClientes.Records.DeleteAll()
            RCClientes.Populate()
            RCVentasMes.Records.DeleteAll()
            RCVentasMes.Populate()
            CargarClientes()
            CargarVentas()
        End If
    End Sub
End Class