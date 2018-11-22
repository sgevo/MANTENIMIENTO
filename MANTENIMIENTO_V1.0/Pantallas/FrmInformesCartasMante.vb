Imports AxXtremeReportControl
Imports XtremeReportControl
Imports MantEvolution.DefinicionesMenus
Imports AxXtremeSuiteControls
Imports AxXtremeShortcutBar
Imports System.ComponentModel

Public Class FrmInformesCartasMante
    Public Permisos As Long

    Const COL_ID = 0
    Const COL_RAZONSOCIAL = 1
    Const COL_NOMBRECOMERCIAL = 2
    Const COL_VENTAS = 3
    Const COL_PRODUCTO = 4
    Const COL_CIF = 5
    Const COL_DIRECCION = 6
    Const COL_CP = 7
    Const COL_POBLACION = 8
    Const COL_TELEFONO1 = 9
    Const COL_TELEFONO2 = 10
    Const COL_MOVIL = 11
    Const COL_EMAIL1 = 12
    Const COL_EMAIL2 = 13
    Const COL_EMAIL3 = 14
    Const COL_EMAIL4 = 15

    Dim VentasImporte As Double
    Dim VentasUnidades As Double

    Dim TabPantalla As XtremeCommandBars.RibbonTab = Nothing
    Dim GroupFile As XtremeCommandBars.RibbonGroup = Nothing


    Sub ConfigurarPantalla()
        Titulo.Top = 0
        Titulo.Left = 0
        Titulo.Width = Me.Width

        cbMes.Left = 10
        lblcbMes.Left = cbMes.Left
        'cbProductos.Left = cbTipoProductos.Left + cbTipoProductos.Width + 10
        'lblcbProducto.Left = cbProductos.Left

        'cbEnviar.Left = 10
        'lblEnviar.Left = 10

        'cbTelefono.Left = 10
        'lblCbTelefono.Left = cbTelefono.Left
        'cbMail.Left = cbTelefono.Left + cbTelefono.Width + 10
        'lblCbMail.Left = cbMail.Left

        'chSinPyM.Left = lblcbProducto.Left

        RCClientes.Left = cbMes.Left + cbMes.Width + 10
        RCClientes.Width = Me.Width - RCClientes.Left - 20
        lblClientes.Left = RCClientes.Left
        lblTotal.Left = RCClientes.Left

        'RCVentasMes.Left = RCClientes.Left
        'RCVentasMes.Width = RCClientes.Width
        'lblVentas.Left = RCClientes.Left

        'lblPacks.Left = 10
        'lblProductos.Left = 10
        'lblMantes.Left = 10

        'lblClientesPack.Left = 10
        'lblClientesProducto.Left = 10
        'lblClientesMante.Left = 10

    End Sub

    Public Sub AplicaEstilo()

        Dim X As Object

        For Each X In Me.Controls
            AplicaEstiloControl(X)
        Next X

    End Sub

    Private Sub FrmInformesCartasMante_Load(sender As Object, e As EventArgs) Handles Me.Load
        cbMes.ReCreateReparented = True 'Esto es necesario porque si no los eventos no van
        'cbProductos.ReCreateReparented = True 'Esto es necesario porque si no los eventos no van

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

        '''''''''''
        RCClientes.PaintManager.ColumnStyle = XTPReportColumnStyle.xtpColumnResource
        RCClientes.AllowEdit = False
        RCClientes.Columns.Add(COL_ID, "Cod. Cliente", 100, True)
        RCClientes.Columns.Add(COL_RAZONSOCIAL, "Razón Social", 250, True)
        RCClientes.Columns.Add(COL_NOMBRECOMERCIAL, "Nombre Comercial", 250, True)
        RCClientes.Columns.Add(COL_VENTAS, "Importe", 60, True)
        RCClientes.Columns.Add(COL_PRODUCTO, "Producto", 100, True)
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

        RCClientes.Columns.Find(COL_VENTAS).Alignment = XTPColumnAlignment.xtpAlignmentRight
        'cbMes.AddItem("[TODOS]")
        'cbMes.AddItem("Enero")
        'cbMes.AddItem("Febrero")
        'cbMes.AddItem("Marzo")
        'cbMes.AddItem("Abril")
        'cbMes.AddItem("Mayo")
        'cbMes.AddItem("Junio")
        'cbMes.AddItem("Julio")
        'cbMes.AddItem("Agosto")
        'cbMes.AddItem("Septiembre")
        'cbMes.AddItem("Octubre")
        'cbMes.AddItem("Noviembre")
        'cbMes.AddItem("Diciembre")

        fInformesCartasMante = Me
    End Sub

    Private Sub FrmInformesCartasMante_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        fInformesCartasMante = Nothing

        MDIPrincipal.RibbonBar.RemoveTab(DEFMENU.GRUPO_INFORMES_CARTASMANTE)
        'MDIPrincipal.RibbonBar.Reset()
        MDIPrincipal.RibbonBar.RedrawBar()
        MDIPrincipal.RibbonBar.RecalcLayout()

        MDIPrincipal.RibbonBar.FindTab(DEFMENU.TAB_PRINCIPAL).Selected = True
        MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_INFORMES_CARTASMANTE).Visible = False

    End Sub

    Sub ConstruirMenu()

        If MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_INFORMES_CARTASMANTE) Is Nothing Then 'si no existe lo creo
            TabPantalla = MDIPrincipal.RibbonBar.InsertTab(DEFMENU.GRUPO_INFORMES_CARTASMANTE, "&Cartas Mante")
            TabPantalla.Id = DEFMENU.GRUPO_INFORMES_CARTASMANTE

            'GroupFile = TabPrincipal.Groups.AddGroup("&MANTE", 1001)
            'GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.PRINCIPAL_MANTENIMIENTO, "Mantenimiento", False, False)
            GroupFile = TabPantalla.Groups.AddGroup("&CARTAS MANTENIMIENTO", DEFMENU.GRUPO_INFORMES_CARTASMANTE)
            GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.INFORMES_CARTASMANTE_IMPRIMIR, "Imprimir", False, False).IconId = 102
            GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.INFORMES_CARTASMANTE_EXCEL_CLIENTES, "Excel Clientes", False, False).IconId = 104
            '            GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.ESTADIS_VENTAS_EXCEL_VENTAS, "Excel Ventas", False, False).IconId = 104
            GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.INFORMES_CARTASMANTE_SALIR, "Salir", False, False).IconId = 103
        End If

        MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_INFORMES_CARTASMANTE).Visible = True
        MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_INFORMES_CARTASMANTE).Selected = True

    End Sub

    Sub Menu_Imprimir()

    End Sub

    Sub Menu_ExcelClientes()
        ExportToExcel(RCClientes,, "003")
    End Sub

    Private Sub FrmInformesCartasMante_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        ConstruirMenu()

        cbMes.Clear()
        cbMes.AddItem("[TODOS]")
        cbMes.AddItem("Enero")
        cbMes.AddItem("Febrero")
        cbMes.AddItem("Marzo")
        cbMes.AddItem("Abril")
        cbMes.AddItem("Mayo")
        cbMes.AddItem("Junio")
        cbMes.AddItem("Julio")
        cbMes.AddItem("Agosto")
        cbMes.AddItem("Septiembre")
        cbMes.AddItem("Octubre")
        cbMes.AddItem("Noviembre")
        cbMes.AddItem("Diciembre")
    End Sub

    Private Sub FrmInformesCartasMante_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        ConfigurarPantalla()
    End Sub

    Sub CargarVentas()
        'Dim Record As ReportRecord
        Dim x As Long
        Dim Variacion As Double

        Dim MesBusco As Long

        Dim Ventas As Double

        Variacion = 0.8 'Variación del precio para los Packs


        VentasUnidades = 0
        VentasImporte = 0

        If cbMes.ListIndex = -1 Then 'Si no hay mes no calcula
            Exit Sub
        End If

        MesBusco = cbMes.ListIndex 'Mes que busco. Si=0 saco todos

        Dim ArrayProductos As New ArrayList
        Dim ArrayPacks As New ArrayList
        Dim objProducto As Producto
        Dim objProductoCliente As ProductosCliente

        Dim objPack As Pack

        Dim ArrayMaestroProductos As ArrayList
        Dim CadaProducto As Producto
        Dim CadaPack As Pack

        Dim ElCliente As Cliente

        RCClientes.Records.DeleteAll()

        'PACKS
        'objPack = cbProductos.get_ItemData(cbProductos.ListIndex)
        ArrayProductos = ObtenerProductosClienteTipo(2) 'Mantes, ProductosCliente

        ArrayPacks = ObtenerPacks()

        For Each objProductoCliente In ArrayProductos
            If MesBusco = 0 Or MesBusco = Month(objProductoCliente.FechaInicioServicio1) Then
                ElCliente = objProductoCliente.objCliente1
                VentasUnidades = VentasUnidades + 1
                For Each CadaPack In ArrayPacks
                    If CadaPack.Id1 = objProductoCliente.Id_Pack1 Then
                        If Month(objProductoCliente.FechaInicioServicio1) = 7 Then
                            Debug.Print("Cliente: " & ElCliente.NombreComercial1)
                        End If
                        Ventas = (CadaPack.Precio1 * Variacion)
                        VentasImporte = VentasImporte + Ventas
                        Exit For
                    End If
                Next
                CargarCliente(ElCliente, Ventas, CadaPack.Descripcion1)
            End If
        Next

        'MANTES
        'objProducto = cbProductos.get_ItemData(cbProductos.ListIndex)
        ArrayProductos = ObtenerProductosClienteTipo(1) 'Mantes, ProductosCliente

        ArrayMaestroProductos = ObtenerProductosTipo(2) 'Estos son los Mantes en la tabla de Productos

        For Each objProductoCliente In ArrayProductos
            If MesBusco = 0 Or MesBusco = Month(objProductoCliente.FechaInicioServicio1) Then
                ElCliente = objProductoCliente.objCliente1
                VentasUnidades = VentasUnidades + 1
                For Each CadaProducto In ArrayMaestroProductos
                    If CadaProducto.Id1 = objProductoCliente.Id_Producto1 Then
                        If Month(objProductoCliente.FechaInicioServicio1) = 7 Then
                            Debug.Print("Cliente: " & ElCliente.NombreComercial1)
                        End If
                        If objProductoCliente.Red11 = False Then
                            Ventas = (CadaProducto.Precio1)
                            VentasImporte = VentasImporte + Ventas
                        Else
                            Ventas = (CadaProducto.PrecioRed1)
                            VentasImporte = VentasImporte + Ventas
                        End If
                        Exit For
                    End If
                Next
                CargarCliente(ElCliente, Ventas, CadaProducto.Descripcion1)
            End If
        Next

        Debug.Print(VentasUnidades & ": " & VentasImporte)

        lblTotal.Caption = "Importe Total: " & Format(VentasImporte, FormatoImporte) & "  --  " & "Unidades: " & Format(VentasUnidades, FormatoImporte)

        RCClientes.Populate()

    End Sub

    Private Sub cbMes_ClickEvent(sender As Object, e As EventArgs) Handles cbMes.ClickEvent
        CargarVentas()
    End Sub

    Sub CargarCliente(ElCliente As Cliente, AcumVentas As Double, Producto As String)

        Dim Record As ReportRecord
        Dim ArrayMail() As String

        If Not IsNothing(ElCliente) Then

            Record = RCClientes.Records.Add()

            Record.AddItem(ElCliente.Id1)
            Record.AddItem(ElCliente.NombreComercial1)
            Record.AddItem(ElCliente.RazonSocial1)
            Record.AddItem(Format(AcumVentas, FormatoImporte))
            Record.AddItem(Producto)
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

    End Sub


End Class