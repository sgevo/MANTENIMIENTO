Imports XtremeReportControl
Imports MantEvolution.DefinicionesMenus
Imports AxXtremeReportControl

Public Class FrmClientesFichero


    Const COL_ID = 0
    Const COL_RAZONSOCIAL = 1
    Const COL_NOMBRECOMERCIAL = 2
    Const COL_CIF = 3

    Const COL_CP = 4
    Const COL_POBLACION = 5
    Const COL_PROVINCIA = 6
    Const COL_TELEFONO = 7
    Const COL_EMAIL = 8
    Const COL_IBAN = 9
    Const COL_ESTADO = 10

    Dim Arrayclientes As New ArrayList()

    Dim TabPantalla As XtremeCommandBars.RibbonTab = Nothing
    Dim GroupFile As XtremeCommandBars.RibbonGroup = Nothing


    Private Sub FrmClientesFichero_Load(sender As Object, e As EventArgs) Handles Me.Load


        With RCClientes

            '    .PaintManager.CaptionFont.Name = "Tahoma"
            '    .PaintManager.CaptionFont.Bold = True

            '    .PaintManager.TextFont.Name = "Tahoma"

            '    .PaintManager.UseAlternativeBackground = True
            '    .PaintManager.AlternativeBackgroundColor = CUInt(RGB(242, 242, 242))

            '    .PaintManager.FreezeColsDividerColor = CUInt(RGB(0, 0, 0))
            '    .PaintManager.NoItemsText = "No hay elementos que mostrar"
            '    .FullColumnScrolling = True
            '    .AutoColumnSizing = False

            '    .FocusSubItems = True
            '    .PaintManager.ShowNonActiveInPlaceButton = True

            '    'Configuramos la zona de fila de pie
            '    '.SetImageList(ImageList1)

            '    '.SetImageList(AxImageList1)
            '    .ScrollModeH = XTPReportScrollMode.xtpReportScrollModeSmooth
            '    .ScrollModeV = XTPReportScrollMode.xtpReportScrollModeSmooth

            '    .AllowSort = False
            '    .Records.DeleteAll()
            '    .Columns.DeleteAll()
            ' .ShowGroupBox = True

            '   .AllowGroup = True
            '    '.ShowHeaderRows = True
            '    '.HeaderRowsAllowEdit = True
            '    .Populate()
            '    .Navigator.MoveLastRow()

        End With



        CargarColumnasReport()

        CargarComboProvincias()

        CargarComboVistas("MAESTROS: CLIENTES")

        '     CargarClientes()

        'Esta linea hace falta para que funcione el rc_beforedrawrow
        'Aunque el formato se puede poner directamente en la Clase del objeto, mejor
        'RCProductos.SetCustomDraw(XtremeReportControl.XTPReportCustomDraw.xtpCustomBeforeDrawRow)

        'RCProductos.Icons = MDIPrincipal.ImageManager.Icons
        btnRestaurar_ClickEvent()


        ' btnRestaurar_DropDown()

        fClientesFichero = Me


    End Sub

    Sub CargarComboProvincias()
        Dim ArrayProvincias As New ArrayList()
        Dim ObjProvincia As Provincia
        Dim item As ReportColumn
        ArrayProvincias = ObtenerTodasLasProvincias()

        item = RCClientes.Columns(COL_PROVINCIA)

        item.EditOptions.AddComboButton()
        item.EditOptions.GetInplaceButton(0).InsideCellButton = True
        'item.EditOptions.Constraints.
        item.EditOptions.ConstraintEdit = True
        item.EnsureVisible()
        '    item.EditOptions.Constraints.DeleteAll()
        For Each ObjProvincia In ArrayProvincias

            item.EditOptions.Constraints.Add(ObjProvincia.Provincia1, ObjProvincia.Id1)

        Next

    End Sub


    Public Sub CargarClientes()

        Dim contador As Long

        Dim Record As XtremeReportControl.ReportRecord
        Dim ObjClientes As Cliente
        Application.DoEvents()
        Arrayclientes = ObtenerTodosLosClientes()
        Debug.Print(" Carga array fin " & DateTime.Now)
        Application.DoEvents()
        For Each ObjClientes In Arrayclientes

            Record = RCClientes.Records.Add()

            Record.AddItem(ObjClientes.Id1)
            Record.AddItem(ObjClientes.RazonSocial1)
            Record.AddItem(ObjClientes.NombreComercial1)
            Record.AddItem(ObjClientes.Cif1)
            Record.AddItem(ObjClientes.CP1)
            Record.AddItem(ObjClientes.Poblacion1)
            Record.AddItem(ObjClientes.IdProvincia1)

            Record.AddItem(ObjClientes.Telefono1)
            Record.AddItem(ObjClientes.Email1)
            Record.AddItem(ObjClientes.IbanCuenta1)
            Record.AddItem(ObjClientes.Movil1)
            Record.AddItem("") 'Añadir

            contador = contador + 1


            If Int(contador / 400) * 400 = contador Then
                Application.DoEvents()
            End If
            If contador = 1000 Then
                RCClientes.Populate()
            End If

        Next

        RCClientes.Populate()
        '   RCClientes.Navigator.MoveLastRow()


        Debug.Print("Fin Carga " & DateTime.Now)


        'Dim Record As XtremeReportControl.ReportRecord

        'RCClientes.Redraw()


        ''   RCClientes.SetVirtualMode(Arrayclientes.Count, RCClientes.Columns.Count - 1)
        'RCClientes.SetVirtualMode(Arrayclientes.Count, 0)

        'Record = RCClientes.Records(0)
        'Record.AddItem("")
        'Record.AddItem("")
        'Record.AddItem("")
        'Record.AddItem("")
        'Record.AddItem("")
        'Record.AddItem("")
        'Record.AddItem("")
        'Record.AddItem("")
        'Record.AddItem("")
        'Record.AddItem("")
        'Record.AddItem("")

        'Record.AddItem("")

        'Record.Item(COL_PROVINCIA).CreateEditOptions()
        'Record.Item(COL_PROVINCIA).EditOptions.EditControlStyle = XTPReportEditStyle.xtpEditStyleUppercase
        'Record.Item(COL_PROVINCIA).EditOptions.AddComboButton()
        'Record.Item(COL_PROVINCIA).EditOptions.GetInplaceButton(0).InsideCellButton = True
        'Record.Item(COL_PROVINCIA).EditOptions.ConstraintEdit = True
        'Record.Item(COL_PROVINCIA).EditOptions.Constraints.DeleteAll()

        'Dim ArrayProvincias As New ArrayList()
        'Dim ObjProvincia As Provincia
        'ArrayProvincias = ObtenerTodasLasProvincias()

        'For Each ObjProvincia In ArrayProvincias

        '    Record.Item(COL_PROVINCIA).EditOptions.Constraints.Add(ObjProvincia.Provincia1, ObjProvincia.Id1)

        'Next


        'RCClientes.Populate()

        'RCClientes.SetCustomDraw(XtremeReportControl.XTPReportCustomDraw.xtpCustomBeforeDrawRow)

    End Sub

    Private Sub FrmClientesFicheros_Resize(sender As Object, e As EventArgs) Handles Me.Resize

        If gbFiltroAvanzado.Visible = True Then
            ConfigurarPantalla2()
        Else
            ConfigurarPantalla()
        End If
    End Sub

    Sub ConfigurarPantalla()

        Titulo.Top = 0
        Titulo.Left = 0
        Titulo.Width = Me.Width

        RCClientes.Left = 10
        RCClientes.Width = Me.Width - 20

        RCClientes.Top = Titulo.Height
        RCClientes.Height = Me.Height - RCClientes.Top - 20

    End Sub

    Sub ConfigurarPantalla2()
        gbVistas.Visible = False
        Titulo.Top = 0
        Titulo.Left = 0
        Titulo.Width = Me.Width

        RCClientes.Left = 10
        RCClientes.Width = Me.Width - 20

        gbFiltroAvanzado.Top = Titulo.Height

        RCClientes.Top = gbFiltroAvanzado.Top + gbFiltroAvanzado.Height
        RCClientes.Height = Me.Height - RCClientes.Top - 20
    End Sub

    Sub ConfigurarPantalla3()
        gbFiltroAvanzado.Visible = False
        Titulo.Top = 0
        Titulo.Left = 0
        Titulo.Width = Me.Width

        RCClientes.Left = 10
        RCClientes.Width = Me.Width - 20

        gbVistas.Top = Titulo.Height

        RCClientes.Top = gbVistas.Top + gbVistas.Height
        RCClientes.Height = Me.Height - RCClientes.Top - 20
    End Sub

    Sub CargarColumnasReport()

        RCClientes.PaintManager.ColumnStyle = XTPReportColumnStyle.xtpColumnResource

        RCClientes.AllowEdit = False


        RCClientes.Columns.Add(COL_ID, "C. Cliente", 100, True)
        RCClientes.Columns.Add(COL_RAZONSOCIAL, "Razón Social", 100, True)
        RCClientes.Columns.Add(COL_NOMBRECOMERCIAL, "Nombre Comercial", 250, True)
        RCClientes.Columns.Add(COL_CIF, "CIF / NIF", 60, True)
        RCClientes.Columns.Add(COL_CP, "CP", 100, True)
        RCClientes.Columns.Add(COL_POBLACION, "Población", 100, True)
        RCClientes.Columns.Add(COL_PROVINCIA, "Provincia", 250, True)
        RCClientes.Columns.Add(COL_TELEFONO, "Telefono", 60, True)
        RCClientes.Columns.Add(COL_EMAIL, "Email", 100, True)
        RCClientes.Columns.Add(COL_IBAN, "IBAN", 250, True)
        RCClientes.Columns.Add(COL_ESTADO, "Estado", 60, True)



        '     RCClientes.LoadSettings("PLNKAPPAKCAAAAAALAAAAAAAAAAAAAAAAABAAAAAAABAAAAAAAAAAAAAAAEGAAAAAAEGAAAAAAPPPPPPPPPPPPPPPPAAAAAAAAAAAAAAAAPPPPPPPPAAAAAAAABAAAAAAAAABAAAAAAABAAAAAAAAAAAAAAAEGAAAAAAEGAAAAAAPPPPPPPPPPPPPPPPAAAAAAAAAAAAAAAAPPPPPPPPAAAAAAAACAAAAAAAAABAAAAAAABAAAAAAAAAAAAAAAKPAAAAAAKPAAAAAAPPPPPPPPPPPPPPPPAAAAAAAAAAAAAAAAPPPPPPPPAAAAAAAADAAAAAAAAABAAAAAAABAAAAAAAAAAAAAAAMDAAAAAAMDAAAAAAPPPPPPPPPPPPPPPPAAAAAAAAAAAAAAAAPPPPPPPPAAAAAAAAEAAAAAAAAABAAAAAAABAAAAAAAAAAAAAAAEGAAAAAAEGAAAAAAPPPPPPPPPPPPPPPPAAAAAAAAAAAAAAAAPPPPPPPPAAAAAAAAFAAAAAAAAABAAAAAAABAAAAAAAAAAAAAAAEGAAAAAAEGAAAAAAPPPPPPPPPPPPPPPPAAAAAAAAAAAAAAAAPPPPPPPPAAAAAAAAGAAAAAAAAABAAAAAAABAAAAAAAAAAAAAAAKPAAAAAAKPAAAAAAPPPPPPPPPPPPPPPPAAAAAAAAAAAAAAAAPPPPPPPPAAAAAAAAHAAAAAAAAABAAAAAAABAAAAAAAAAAAAAAAMDAAAAAAMDAAAAAAPPPPPPPPPPPPPPPPAAAAAAAAAAAAAAAAPPPPPPPPAAAAAAAAIAAAAAAAAABAAAAAAABAAAAAAAAAAAAAAAEGAAAAAAEGAAAAAAPPPPPPPPPPPPPPPPAAAAAAAAAAAAAAAAPPPPPPPPAAAAAAAAJAAAAAAAAABAAAAAAABAAAAAAAAAAAAAAAKPAAAAAAKPAAAAAAPPPPPPPPPPPPPPPPAAAAAAAAAAAAAAAAPPPPPPPPAAAAAAAAKAAAAAAAAABAAAAAAABAAAAAAAAAAAAAAAMDAAAAAAMDAAAAAAPPPPPPPPPPPPPPPPAAAAAAAAAAAAAAAAPPPPPPPPAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAHAAAAAAAAAAAAAAAAAAAAAAABAAAAAAAAAAAAAAAAAAAAAAABAAAAAAAAAAAAAAABAAAAAAABAAAAAAABAAAAAAABAAAAAAAAAAAAAAAAAAAAAAAPLNKAPPAKCAAAAAAAAAAAAAA")


        'Record = RCClientes.HeaderRecords.Add()

        'For i = 0 To RCClientes.Columns.Count - 1
        '    Record.AddItem("")
        'Next i

        'RCClientes.Sections.Section(0).AllowEdit = True
        '  RCClientes.Sections.Section(1).AllowEdit = True

        '.FocusSubItems = True 'Si es verdadero, cuando se hace clic en un "ReportRecordItem", aparecerá seleccionada toda la fila, excepto el elemento individual ("Item") en el que se hizo clic.


        'RCClientes.PaintManager.HeaderRowsDividerStyle = XTPReportFixedRowsDividerStyle.xtpReportFixedRowsDividerBold
        'RCClientes.ShowHeaderRows = True
        ''
        'RCClientes.HeaderRowsAllowEdit = True
        'RCClientes.HeaderRowsAllowAccess = True
        ' RCClientes.PopulateHeaderRows()




    End Sub

    Sub ConstruirMenu()

        If MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_MAESTROS_CLIENTES) Is Nothing Then 'si no existe lo creo
            TabPantalla = MDIPrincipal.RibbonBar.InsertTab(DEFMENU.GRUPO_MAESTROS_CLIENTES, "&Clientes")
            TabPantalla.Id = DEFMENU.GRUPO_MAESTROS_CLIENTES

            'GroupFile = TabPrincipal.Groups.AddGroup("&MANTE", 1001)
            'GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.PRINCIPAL_MANTENIMIENTO, "Mantenimiento", False, False)
            GroupFile = TabPantalla.Groups.AddGroup("&CLIENTES", DEFMENU.MAESTROS_CLIENTES)
            GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_CLIENTES_NUEVO, "Nuevo", False, False).IconId = 100
            GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_CLIENTES_IMPRIMIR, "Eliminar", False, False).IconId = 101
            GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_CLIENTES_IMPRIMIR, "Imprimir", False, False).IconId = 102
            GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_CLIENTES_FILTROFILA, "Filtro", False, False).IconId = 100
            GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_CLIENTES_FILTROAVANZADO, "Filtro Avanzado", False, False).IconId = 100
            GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_CLIENTES_QUITARFILTRO, "Quitar Filtro", False, False).IconId = 100
            GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_CLIENTES_VISTAS, "Vistas", False, False).IconId = 100
            GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_CLIENTES_SALIR, "Salir", False, False).IconId = 103
        End If

        MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_MAESTROS_CLIENTES).Visible = True
        MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_MAESTROS_CLIENTES).Selected = True

        If MDIPrincipal.RibbonBar.FindTab(DEFMENU.MAESTROS_CLIENTES_FICHA) Is Nothing = False Then
            MDIPrincipal.RibbonBar.FindTab(DEFMENU.MAESTROS_CLIENTES_FICHA).Visible = False
        End If


    End Sub

    Private Sub FrmClientesFichero_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        ConstruirMenu()
    End Sub

    Private Sub RCClientes_BeforeDrawRow(sender As Object, e As _DReportControlEvents_BeforeDrawRowEvent)
        'Dim objCliente As Cliente
        'If e.row.Section.Index = 0 Then
        '    e.metrics.Text = "f"
        'ElseIf e.row.Section.Index = 1 Then
        '    objCliente = CType(Arrayclientes(e.row.Index), Cliente)
        '    Select Case e.item.Index
        '        Case COL_ID
        '            'Displays data for the ITEM_NUMBER column
        '            'Displays the current row number, this corresponds to an element in OwnArray
        '            e.metrics.Text = CType(objCliente.Id1, String)

        '        Case COL_RAZONSOCIAL
        '            'Displays data for the LIST_PRICE column
        '            e.metrics.Text = CType(objCliente.RazonSocial1, String)
        '        Case COL_NOMBRECOMERCIAL
        '            'Displays data for the SALE_PRICE column
        '            e.metrics.Text = CType(objCliente.NombreComercial1, String)
        '        Case COL_CIF
        '            'Displays data for the SAVINGS column
        '            e.metrics.Text = CType(objCliente.Cif1, String)
        '        Case COL_CP
        '            'Displays data for the SAVINGS column
        '            e.metrics.Text = CType(objCliente.CP1, String)
        '        Case COL_POBLACION
        '            'Displays data for the ITEM_NUMBER column
        '            'Displays the current row number, this corresponds to an element in OwnArray
        '            e.metrics.Text = CType(objCliente.Poblacion1, String)
        '        Case COL_PROVINCIA
        '            'Displays data for the LIST_PRICE column
        '            e.metrics.Text = CType(objCliente.ObjProvincia1.Id1, String)
        '        Case COL_TELEFONO
        '            'Displays data for the SALE_PRICE column
        '            e.metrics.Text = CType(objCliente.Telefono1, String)
        '        Case COL_EMAIL
        '            'Displays data for the SAVINGS column
        '            e.metrics.Text = CType(objCliente.Email1, String)
        '        Case COL_IBAN
        '            'Displays data for the SAVINGS column
        '            e.metrics.Text = CType(objCliente.IbanDc1, String)
        '        Case COL_ESTADO
        '            'Displays data for the SAVINGS column
        '            e.metrics.Text = CType(objCliente.ProximoEstado1, String)
        '    End Select

        'End If

    End Sub

    Private Sub FrmClientesFichero_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub RCClientes_RowDblClick(sender As Object, e As _DReportControlEvents_RowDblClickEvent) Handles RCClientes.RowDblClick



        Dim Form3 As FrmClientesFicha = New FrmClientesFicha With {
             .MdiParent = MDIPrincipal}
        Form3.ObjCliente = Arrayclientes(e.row.Record.Index)
        Form3.Show()


        ' TabPantalla.Visible = False
        Me.Visible = False

        '  MDIPrincipal.RibbonBar.FindTab(DEFMENU.TAB_MAESTROS).Selected = True
        MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_MAESTROS_CLIENTES).Visible = False

    End Sub

    Sub Modificar()

        Dim Form3 As FrmClientesFicha = New FrmClientesFicha With {
         .MdiParent = MDIPrincipal}
        Form3.ObjCliente = Arrayclientes(RCClientes.FocusedRow.Record.Index)
        Form3.Show()


        ' TabPantalla.Visible = False
        Me.Visible = False

        '  MDIPrincipal.RibbonBar.FindTab(DEFMENU.TAB_MAESTROS).Selected = True
        MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_MAESTROS_CLIENTES).Visible = False

    End Sub



    Sub ImprimirReport()


        'Impresion1.Visible = True

        'Impresion1.PrintView = CType(RCClientes.CreatePrintView, IPrintView)
        'Impresion1.Show()


        'Dim Form3 As FrmImpresion = New FrmImpresion With {
        ' .MdiParent = MDIPrincipal}
        'Form3.RC1 = RCClientes
        'Form3.Show()


        '' TabPantalla.Visible = False
        'Me.Visible = False

        ''  MDIPrincipal.RibbonBar.FindTab(DEFMENU.TAB_MAESTROS).Selected = True
        'MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_MAESTROS_CLIENTES).Visible = False

        ''  PrintPreview1.PrintView = CType(RCClientes.CreatePrintView, IPrintView)
        'PrintPreview1.Title = "CCXZCZ"
        'PrintPreview1.

        'PrintPreview1.ShowPrintDialog()
        '     PrintPreview1.Show()

        '   PrintPreview1.PrintView = RCClientes.CreatePrintView.ToString
        'PrintPreview1.PrintView = PrintPreview1.CreateMarkupPrintView(RCClientes.CreatePrintView.ToString)
        'PrintPreview1.Show()


        'Me.RCClientes.PrintOptions.Landscape = True
        'Me.VistaPrevia.PrintView = RCClientes.CreatePrintView()


        'FrmImpresion.AxPrintPreview1.PrintView = CType(RCClientes.CreatePrintView(), IPrintView)
        'FrmImpresion.Show()

    End Sub




    Private Sub FrmClientesFichero_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        fClientesFichero = Nothing

        '  RCClientes.Dispose()
        'RCClientes.SetVirtualMode(0)
        '  Arrayclientes = Nothing
        'RCClientes = Nothing
        ' RCClientes.SetVirtualMode(0)
        MDIPrincipal.RibbonBar.RemoveTab(DEFMENU.GRUPO_MAESTROS_CLIENTES)
        'MDIPrincipal.RibbonBar.Reset()
        MDIPrincipal.RibbonBar.RedrawBar()
        MDIPrincipal.RibbonBar.RecalcLayout()

        '   MDIPrincipal.RibbonBar.FindTab(DEFMENU.TAB_MAESTROS).Selected = True
        MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_MAESTROS_CLIENTES).Visible = False
        '  Me.Dispose()
    End Sub


    Sub Nuevo()

        Dim Form3 As FrmClientesFicha = New FrmClientesFicha With {
        .MdiParent = MDIPrincipal}
        Form3.ObjCliente = New Cliente()
        Form3.Show()

        Me.Visible = False

        '  MDIPrincipal.RibbonBar.FindTab(DEFMENU.TAB_MAESTROS).Selected = True
        MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_MAESTROS_CLIENTES).Visible = False

    End Sub


    Sub ActualizarRegistro(Registro As ReportRecord, objCliente As Cliente)


        Registro.Item(COL_ID).Value = objCliente.Id1
        Registro.Item(COL_RAZONSOCIAL).Value = objCliente.RazonSocial1
        Registro.Item(COL_NOMBRECOMERCIAL).Value = objCliente.NombreComercial1
        Registro.Item(COL_CIF).Value = objCliente.Cif1
        Registro.Item(COL_CP).Value = objCliente.CP1
        Registro.Item(COL_POBLACION).Value = objCliente.Poblacion1
        Registro.Item(COL_PROVINCIA).Value = objCliente.IdProvincia1

        Registro.Item(COL_TELEFONO).Value = objCliente.Telefono1
        Registro.Item(COL_EMAIL).Value = objCliente.Email1
        Registro.Item(COL_IBAN).Value = objCliente.IbanCuenta1
        Registro.Item(COL_ESTADO).Value = objCliente.Movil1


        RCClientes.Populate()

    End Sub

    Sub AñadirRegistro(objCliente As Cliente)

        Dim Record As XtremeReportControl.ReportRecord

        Record = RCClientes.Records.Add()

        Record.AddItem(objCliente.Id1)
        Record.AddItem(objCliente.RazonSocial1)
        Record.AddItem(objCliente.NombreComercial1)
        Record.AddItem(objCliente.Cif1)
        Record.AddItem(objCliente.CP1)
        Record.AddItem(objCliente.Poblacion1)
        Record.AddItem(objCliente.IdProvincia1)

        Record.AddItem(objCliente.Telefono1)
        Record.AddItem(objCliente.Email1)
        Record.AddItem(objCliente.IbanCuenta1)
        Record.AddItem(objCliente.Movil1)
        Record.AddItem("") 'Añadir

        RCClientes.Populate()

    End Sub

    Sub FiltroFila()

        RCClientes.Populate()
        Dim Record As ReportRecord
        Dim i As Integer
        If RCClientes.HeaderRecords.Count = 0 Then

            RCClientes.PaintManager.HeaderRowsDividerStyle = XTPReportFixedRowsDividerStyle.xtpReportFixedRowsDividerBold
            RCClientes.ShowHeaderRows = True
            RCClientes.HeaderRowsAllowEdit = True

            Record = RCClientes.HeaderRecords.Add()

            For i = 0 To RCClientes.Columns.Count - 1
                Record.AddItem("")
            Next i

            'Aplicar cambios
            RCClientes.PopulateHeaderRows()
            RCClientes.Populate()
        Else

            RCClientes.AllowColumnRemove = True

            RCClientes.PaintManager.HeaderRowsDividerStyle = XTPReportFixedRowsDividerStyle.xtpReportFixedRowsDividerThin
            RCClientes.ShowHeaderRows = False
            RCClientes.HeaderRowsAllowEdit = False

            RCClientes.HeaderRecords.DeleteAll()


            For i = 0 To RCClientes.Records.Count - 1
                RCClientes.Records(i).Visible = True
            Next i
            RCClientes.Populate()
        End If
    End Sub

    Sub FiltroAvanzado()
        Dim x As Long
        If gbFiltroAvanzado.Visible = False Then
            gbFiltroAvanzado.Visible = True
            ConfigurarPantalla2()

        Else
            gbFiltroAvanzado.Visible = False
            ConfigurarPantalla()


        End If
    End Sub

    Private Sub RCClientes_ValueChanged(sender As Object, e As _DReportControlEvents_ValueChangedEvent) Handles RCClientes.ValueChanged

        If e.row.Section.Index = 0 Then

            'Si el filtro está activo, borro el filtro de todas las columnas, menos el de la que estoy
            LimpiarLineafiltro(RCClientes, e.column.ItemIndex)

            Filtrar(RCClientes, e.column.ItemIndex)

            RCClientes.Populate()

        End If

    End Sub

    Private Sub btnRestaurar_ClickEvent() Handles btnRestaurar.ClickEvent
        tbClienteDesde.Text = 0
        tbClienteHasta.Text = 999999
    End Sub

    Private Sub tbClienteDesde_Change(sender As Object, e As EventArgs) Handles tbClienteDesde.Change

    End Sub

    Private Sub tbClienteDesde_GotFocus(sender As Object, e As EventArgs) Handles tbClienteDesde.GotFocus
        tbClienteDesde.SelStart = 0
        tbClienteDesde.SelLength = Len(tbClienteDesde.Text)

    End Sub


    Private Sub tbClienteHasta_GotFocus(sender As Object, e As EventArgs) Handles tbClienteHasta.GotFocus

        tbClienteHasta.SelStart = 0
        tbClienteHasta.SelLength = Len(tbClienteHasta.Text)

    End Sub

    Private Sub tbClienteDesde_KeyPressEvent(sender As Object, e As _DFlatEditEvents_KeyPressEvent) Handles tbClienteDesde.KeyPressEvent
        Retorno(e.keyAscii)
    End Sub


    Private Sub tbClienteHasta_KeyPressEvent(sender As Object, e As _DFlatEditEvents_KeyPressEvent) Handles tbClienteHasta.KeyPressEvent
        Retorno(e.keyAscii)
    End Sub

    Private Sub btnAplicarFiltro_ClickEvent(sender As Object, e As EventArgs) Handles btnAplicarFiltro.ClickEvent
        AplicarFiltroAvanzado
    End Sub


    Sub AplicarFiltroAvanzado()
        Dim estado As Boolean
        Dim x As Integer

        For x = 0 To RCClientes.Records.Count - 1
            estado = True

            If CInt(RCClientes.Records(x).Item(COL_ID).Value) < CInt(tbClienteDesde.Text) Or CInt(RCClientes.Records(x).Item(COL_ID).Value) > CInt(tbClienteHasta.Text) Then
                estado = False
            End If

            RCClientes.Records(x).Visible = estado

        Next
        RCClientes.Populate()

    End Sub


    Sub Vistas()
        Dim x As Long
        If gbVistas.Visible = False Then
            gbVistas.Visible = True
            ConfigurarPantalla3()
        Else
            gbVistas.Visible = False
            ConfigurarPantalla()
        End If
    End Sub


    Sub CargarComboVistas(Pantalla As String)

        'Dim ArrayVistas As New ArrayList
        'Dim ObjVistas As Vistas

        'ArrayVistas = ObtenerVistas(Pantalla)

        'cbVistas.Clear()

        'For Each ObjVistas In ArrayVistas
        '    cbVistas.AddItem(ObjVistas.Nombre1, ObjVistas.Id1, ObjVistas.Id1)
        'Next

        'If cbVistas.ListCount = 0 Then
        '    cbVistas.Text = "Sin Vistas"
        'Else
        '    cbVistas.ListIndex = 0
        'End If

    End Sub



    Private Sub RCClientes_ColumnOrderChangedEx(sender As Object, e As _DReportControlEvents_ColumnOrderChangedExEvent) Handles RCClientes.ColumnOrderChangedEx
        RCClientes.Redraw()
    End Sub

    Private Sub FrmClientesFichero_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter

    End Sub
End Class