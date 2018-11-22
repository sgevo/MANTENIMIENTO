Imports AxXtremeReportControl
Imports XtremeReportControl

Public Class FrmFormasPagos


    Const COL_ID = 0
    Const COL_DESCRIPCION = 1
    Const COL_PLAZOS = 2
    Const COL_DIASENTREPALZOS = 3
    Const COL_PRIMERPAGO = 4
    Const COL_AÑADIR = 5

    Dim HayErrores As Boolean

    Dim ArrayFormasPagos As New ArrayList()

    Private Sub FrmFormasPagos_Load(sender As Object, e As EventArgs) Handles Me.Load
        With RCFormasPagos

            .PaintManager.CaptionFont.Name = "Tahoma"
            .PaintManager.CaptionFont.Bold = True

            .PaintManager.TextFont.Name = "Tahoma"

            .PaintManager.UseAlternativeBackground = True
            .PaintManager.AlternativeBackgroundColor = RGB(242, 242, 242)

            .PaintManager.FreezeColsDividerColor = RGB(0, 0, 0)
            .PaintManager.NoItemsText = "No hay elementos que mostrar"
            .FullColumnScrolling = True
            .AutoColumnSizing = False

            .FocusSubItems = True
            .PaintManager.ShowNonActiveInPlaceButton = True

            'Configuramos la zona de fila de pie
            '.SetImageList(ImageList1)

            '.SetImageList(AxImageList1)

            .ShowFooterRows = True
            .FooterRowsAllowEdit = True
            .FooterRowsAllowAccess = True


            .AllowSort = False
            .Records.DeleteAll()
            .Columns.DeleteAll()

            .Populate()
            .Navigator.MoveLastRow()

        End With

        CargarColumnasReport()
        CargarFormasPago()
        BorraPie()
        RCFormasPagos.Icons = MDIPrincipal.ImageManager.Icons

        fFormasPagos = Me

    End Sub



    Sub ConfigurarPantalla()

        Titulo.Top = 0
        Titulo.Left = 0
        Titulo.Width = Me.Width

        RCFormasPagos.Left = 10
        RCFormasPagos.Width = Me.Width - 20

        RCFormasPagos.Top = Titulo.Height
        RCFormasPagos.Height = Me.Height - RCFormasPagos.Top - 20

    End Sub



    Sub CargarColumnasReport()

        Dim FilaPie As ReportRecord

        RCFormasPagos.PaintManager.ColumnStyle = XTPReportColumnStyle.xtpColumnResource

        RCFormasPagos.AllowEdit = False

        RCFormasPagos.Columns.Add(COL_ID, "ID", 100, True)
        RCFormasPagos.Columns.Add(COL_DESCRIPCION, "Descripción", 250, True)
        RCFormasPagos.Columns.Find(COL_DESCRIPCION).EditOptions.SelectTextOnEdit = True
        RCFormasPagos.Columns.Add(COL_PLAZOS, "Plazos", 60, True)
        RCFormasPagos.Columns.Find(COL_PLAZOS).EditOptions.SelectTextOnEdit = True
        RCFormasPagos.Columns.Column(COL_PLAZOS).EditOptions.AddSpinButton()
        RCFormasPagos.Columns.Column(COL_PLAZOS).EditOptions.GetInplaceButton(0).InsideCellButton = True
        RCFormasPagos.Columns.Column(COL_PLAZOS).Alignment = XTPColumnAlignment.xtpAlignmentRight
        RCFormasPagos.Columns.Add(COL_DIASENTREPALZOS, "Dias Entre Plazos", 60, True)
        RCFormasPagos.Columns.Find(COL_DIASENTREPALZOS).EditOptions.SelectTextOnEdit = True
        RCFormasPagos.Columns.Column(COL_DIASENTREPALZOS).EditOptions.AddSpinButton()
        RCFormasPagos.Columns.Column(COL_DIASENTREPALZOS).EditOptions.GetInplaceButton(0).InsideCellButton = True
        RCFormasPagos.Columns.Column(COL_DIASENTREPALZOS).Alignment = XTPColumnAlignment.xtpAlignmentRight
        RCFormasPagos.Columns.Add(COL_PRIMERPAGO, "Primer Pago", 60, True)
        RCFormasPagos.Columns.Find(COL_PRIMERPAGO).EditOptions.SelectTextOnEdit = True
        RCFormasPagos.Columns.Column(COL_PRIMERPAGO).EditOptions.AddSpinButton()
        RCFormasPagos.Columns.Column(COL_PRIMERPAGO).EditOptions.GetInplaceButton(0).InsideCellButton = True
        RCFormasPagos.Columns.Column(COL_PRIMERPAGO).Alignment = XTPColumnAlignment.xtpAlignmentRight
        RCFormasPagos.Columns.Add(COL_AÑADIR, "", 50, True)


        FilaPie = RCFormasPagos.FooterRecords.Add

        Dim x As Integer
        Dim item As ReportRecordItem

        For x = 0 To RCFormasPagos.Columns.Count - 1
            If x = COL_AÑADIR Then
                item = FilaPie.AddItem("")
                item.ItemControls.AddButton("0")
                '    item.ItemControls(0).Alignment = xtpReportItemControlUnknown
                item.ItemControls(0).Themed = True
                item.ItemControls(0).SetSize(48, 48)
                item.ItemControls(0).Enable = True
                item.ItemControls(0).SetIconIndex(0, 1)

                item.BackColor = RGB(220, 232, 248)
                item.Editable = True
                item.Focusable = True
            Else
                FilaPie.AddItem("")

                FilaPie.Item(x).BackColor = RGB(220, 232, 248)
                FilaPie.Item(x).Editable = True
                FilaPie.Item(x).Focusable = True

            End If
        Next x

        RCFormasPagos.PopulateFooterRows()
        RCFormasPagos.Populate()




        ''Configuracion Final del report en cuanto a columnas
        RCFormasPagos.Columns.Find(COL_ID).Visible = False



        'RCProductos.FooterRecords(0).Item(COL_PRECIO).Value = "0,00"

    End Sub

    Private Sub FrmFormasPagos_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        ConfigurarPantalla()
    End Sub


    Sub CargarFormasPago()

        Dim Record As XtremeReportControl.ReportRecord
        Dim ObjFormaPago As FormaPago

        ArrayFormasPagos = ObtenerTodasFormasPagos()

        For Each ObjFormaPago In ArrayFormasPagos

            Record = RCFormasPagos.Records.Add()

            Record.AddItem(ObjFormaPago.Id1)
            Record.AddItem(ObjFormaPago.Descripcion1)
            Record.AddItem(ObjFormaPago.Plazos1)
            Record.AddItem(ObjFormaPago.DiasEntrePlazos1)
            Record.AddItem(ObjFormaPago.PrimerPago1)

            Record.AddItem("") 'Añadir

        Next

        RCFormasPagos.Populate()

    End Sub


    Sub BorraPie()
        RCFormasPagos.FooterRows(0).Record.Item(COL_ID).Value = ""
        RCFormasPagos.FooterRows(0).Record.Item(COL_DESCRIPCION).Value = ""
        RCFormasPagos.FooterRows(0).Record.Item(COL_PLAZOS).Value = 1
        RCFormasPagos.FooterRows(0).Record.Item(COL_DIASENTREPALZOS).Value = 0
        RCFormasPagos.FooterRows(0).Record.Item(COL_PRIMERPAGO).Value = 0


    End Sub

    Private Sub RCFormasPagos_PreviewKeyDownEvent(sender As Object, e As _DReportControlEvents_PreviewKeyDownEvent) Handles RCFormasPagos.PreviewKeyDownEvent
        Dim proximaColumna As Integer
        Dim esPies As Boolean

        esPies = False

        Select Case e.keyCode
            Case 13 'Enter

                If RCFormasPagos.FocusedRow.Section.Index = 2 Then
                    esPies = True
                End If

                proximaColumna = SiguienteColumnaEditable(RCFormasPagos, RCFormasPagos.FocusedColumn.Index, esPies)

                ' RCProductos.Populate()
                If esPies = True Then
                    RCFormasPagos.Navigator.CurrentFocusInFootersRows = True
                End If

                RCFormasPagos.Navigator.MoveToColumn(proximaColumna, False)

                RCFormasPagos.Navigator.BeginEdit()

                If RCFormasPagos.Columns(proximaColumna).ItemIndex = COL_AÑADIR Then
                    '   RCProductos.FooterRows(0).Record.Item(COL_AÑADIR)
                    RCFormasPagos_ItemButtonClick()
                End If

            Case 9 'Tab
                If e.shift = 1 Then
                    If RCFormasPagos.FocusedRow.Section.Index = 2 Then
                        esPies = True
                    End If

                    proximaColumna = AnteriorColumnaEditable(RCFormasPagos, RCFormasPagos.FocusedColumn.Index, esPies)

                    RCFormasPagos.Populate()
                    If esPies = True Then
                        RCFormasPagos.Navigator.CurrentFocusInFootersRows = True
                    End If

                    RCFormasPagos.Navigator.MoveToColumn(proximaColumna, False)

                    RCFormasPagos.Navigator.BeginEdit()

                    e.cancel = True
                Else
                    If RCFormasPagos.FocusedRow.Section.Index = 2 Then
                        esPies = True
                    End If

                    proximaColumna = SiguienteColumnaEditable(RCFormasPagos, RCFormasPagos.FocusedColumn.Index, esPies)

                    RCFormasPagos.Populate()
                    If esPies = True Then
                        RCFormasPagos.Navigator.CurrentFocusInFootersRows = True
                    End If

                    RCFormasPagos.Navigator.MoveToColumn(proximaColumna, False)

                    RCFormasPagos.Navigator.BeginEdit()
                    e.cancel = True
                End If

            Case 16
                e.cancel = True

            Case 38
                RCFormasPagos.Populate()
                RCFormasPagos.Navigator.MoveUp()
                RCFormasPagos.Navigator.BeginEdit()
                e.cancel = True

            Case 40
                RCFormasPagos.Populate()
                RCFormasPagos.Navigator.MoveDown()
                RCFormasPagos.Navigator.BeginEdit()
                e.cancel = True

        End Select

        If Not RCFormasPagos.FocusedColumn Is Nothing Then
            Select Case RCFormasPagos.FocusedColumn.ItemIndex
                'Case COL_PRECIO, COL_PRECIORED
                'If e.keyCode = 110 Then e.keyCode = 188 '(si pulsa la tecla del punto en el teclado númerico, lo cambio por la coma)
                'If e.keyCode = 190 Then e.keyCode = 188 '(si pulsa la tecla del punto del teclado normal, lo cambio por la coma)

            End Select
        End If

    End Sub

    Private Sub RCFormasPagos_ItemButtonClick() Handles RCFormasPagos.ItemButtonClick
        Dim MiRow As ReportRow
        Dim ObjError As New Errores

        MiRow = RCFormasPagos.FocusedRow

        If RCFormasPagos.FocusedRow.Section.Index = 1 Then 'Lineas de Detalle
            If Comprobaciones(False) = False Then
                'Dim objProducto = New Producto(MiRow.Record.Item(COL_ID).Value, MiRow.Record.Item(COL_CODIGO).Value, MiRow.Record.Item(COL_DESCRIPCION).Value, MiRow.Record.Item(COL_VERSIONES).Value, MiRow.Record.Item(COL_MANTENIMIENTO).Value, MiRow.Record.Item(COL_RED).Value, MiRow.Record.Item(COL_TEMPORAL).Value, MiRow.Record.Item(COL_PRECIO).Value, MiRow.Record.Item(COL_PRECIORED).Value)
                'ModificarProducto(objProducto)

                'ObjError.Pantalla1 = Me
                'ObjError.Tipo1 = 3 'Avisos

                'ObjError.Titulo = "Productos"

                'ObjError.SetMensaje("Producto actualizado")

                'ObjError.Control1 = "ReportControl"
                'ObjError.Pie1 = False
                'ObjError.Foco1 = COL_CODIGO

                'FrmError.ObjError = ObjError
                'FrmError.ShowDialog()
                If FrmError.DialogResult = DialogResult.OK Then
                    FrmError.Dispose()
                    Exit Sub
                End If
            End If
        Else

            If Comprobaciones(True) = False Then 'Pie
                Subirlinea()
            End If
        End If
    End Sub


    Function Comprobaciones(EnPie As Boolean) As Boolean
        Dim HayErrores As Boolean

        Dim ObjError As New Errores

        HayErrores = False
        ObjError.Pantalla1 = Me
        ObjError.Tipo1 = 1 'Errores
        ObjError.Pie1 = EnPie

        ObjError.Titulo = "Comprobaciones"

        'Columna Tipo esta vacia
        If RCFormasPagos.FocusedRow.Record.Item(COL_DESCRIPCION).Caption = "" Then

            ObjError.SetMensaje("La descripción no puede estar Vacia")

            If ObjError.Control1 = "" Then
                ObjError.Control1 = "ReportControl"
                'ObjError.Pie1 = True
                ObjError.Foco1 = COL_DESCRIPCION
            End If

            HayErrores = True
        Else ' Columna tipo no se puede repetir
            If EnPie Then
                If ComprobarFormaPagoRepetido(RCFormasPagos.FocusedRow.Record.Item(COL_DESCRIPCION).Value) = True Then
                    ObjError.SetMensaje("La descripción no puede estar Repetida")

                    If ObjError.Control1 = "" Then
                        ObjError.Control1 = "ReportControl"
                        'ObjError.Pie1 = True
                        ObjError.Foco1 = COL_DESCRIPCION
                    End If

                    HayErrores = True
                End If
            End If
        End If

        If RCFormasPagos.FocusedRow.Record.Item(COL_PLAZOS).Value < 1 Then

            ObjError.SetMensaje("El plazo no puede ser menor que 1")

            If ObjError.Control1 = "" Then
                ObjError.Control1 = "ReportControl"
                'ObjError.Pie1 = True
                ObjError.Foco1 = COL_PLAZOS
            End If

            HayErrores = True
        End If

        If RCFormasPagos.FocusedRow.Record.Item(COL_DIASENTREPALZOS).Caption < 0 Then

            ObjError.SetMensaje("Los dias entre plazos no pueden ser menores a 0")

            If ObjError.Control1 = "" Then
                ObjError.Control1 = "ReportControl"
                'ObjError.Pie1 = True
                ObjError.Foco1 = COL_DIASENTREPALZOS
            End If

            HayErrores = True
        End If

        If RCFormasPagos.FocusedRow.Record.Item(COL_PRIMERPAGO).Caption < 0 Then

            ObjError.SetMensaje("El primer pago no puede ser menor a 0")

            If ObjError.Control1 = "" Then
                ObjError.Control1 = "ReportControl"
                'ObjError.Pie1 = True
                ObjError.Foco1 = COL_PRIMERPAGO
            End If

            HayErrores = True
        End If

        If HayErrores = True Then
            FrmError.ObjError = ObjError
            FrmError.ShowDialog()
            If FrmError.DialogResult = DialogResult.OK Then
                FrmError.Dispose()
            End If
            ControlErrores(ObjError)
            Return True
        Else
            Return False
        End If

    End Function


    Public Sub ControlErrores(objError As Object)

        If objError.Control1.ToString = "ReportControl" Then
            If objError.pie1 = True Then
                RCFormasPagos.Navigator.CurrentFocusInFootersRows = True
            End If

            RCFormasPagos.Navigator.MoveToColumn(RCFormasPagos.Columns.Find(objError.foco1).Index, False)
            RCFormasPagos.Navigator.BeginEdit()
        End If

    End Sub

    Private Sub RCFormasPagos_ValueChanging(sender As Object, e As _DReportControlEvents_ValueChangingEvent) Handles RCFormasPagos.ValueChanging

        Dim ObjError As New Errores

        HayErrores = False
        ObjError.Pantalla1 = Me
        ObjError.Tipo1 = 1 'Alertas


        Select Case e.column.ItemIndex
            Case COL_DESCRIPCION
                If e.newValue = "" Then
                    ObjError.SetMensaje("La descripción no puede estar vacia.")
                    ObjError.Control1 = "ReportControl"
                    ObjError.Pie1 = True
                    ObjError.Foco1 = COL_DESCRIPCION
                    HayErrores = True

                End If

            Case COL_PLAZOS
                If e.newValue < 1 Then
                    ObjError.SetMensaje("Los Plazos no pueden ser menores que 1")
                    ObjError.Control1 = "ReportControl"
                    ObjError.Pie1 = True
                    ObjError.Foco1 = COL_PLAZOS

                    HayErrores = True
                End If
            Case COL_DIASENTREPALZOS
                If e.newValue < 0 Then
                    ObjError.SetMensaje("Los dias entre plazos no pueden ser menores que 0")
                    ObjError.Control1 = "ReportControl"
                    ObjError.Pie1 = True
                    ObjError.Foco1 = COL_DIASENTREPALZOS

                    HayErrores = True
                End If
            Case COL_PRIMERPAGO
                If e.newValue < 0 Then
                    ObjError.SetMensaje("El primer pago no puede ser menores que 0")
                    ObjError.Control1 = "ReportControl"
                    ObjError.Pie1 = True
                    ObjError.Foco1 = COL_PRIMERPAGO

                    HayErrores = True
                End If
        End Select



        If HayErrores = True Then

            FrmError.ObjError = ObjError
            FrmError.ShowDialog()
            If FrmError.DialogResult = DialogResult.OK Then
                FrmError.Dispose()
            End If
            ControlErrores(ObjError)
            e.cancel = True

        End If
    End Sub


    Sub Subirlinea()

        'Dim objProducto = New Producto(RCProductos.FooterRows(0).Record.Item(COL_ID).Value, RCProductos.FooterRows(0).Record.Item(COL_CODIGO).Value, RCProductos.FooterRows(0).Record.Item(COL_DESCRIPCION).Value, RCProductos.FooterRows(0).Record.Item(COL_VERSIONES).Value, RCProductos.FooterRows(0).Record.Item(COL_MANTENIMIENTO).Value, RCProductos.FooterRows(0).Record.Item(COL_RED).Value, RCProductos.FooterRows(0).Record.Item(COL_TEMPORAL).Value, RCProductos.FooterRows(0).Record.Item(COL_PRECIO).Value, RCProductos.FooterRows(0).Record.Item(COL_PRECIORED).Value)
        'Como es un registro nuevo, el campo Id=0
        Dim objFormaPago = New FormaPago(0, RCFormasPagos.FooterRows(0).Record.Item(COL_DESCRIPCION).Value, RCFormasPagos.FooterRows(0).Record.Item(COL_PLAZOS).Value, RCFormasPagos.FooterRows(0).Record.Item(COL_DIASENTREPALZOS).Value, RCFormasPagos.FooterRows(0).Record.Item(COL_PRIMERPAGO).Value)




        Dim proximaColumna As Integer

        GuardarformaPago(objFormaPago)

        AñadirLineaReport(objFormaPago)

        BorraPie()
        RCFormasPagos.Navigator.CurrentFocusInFootersRows = True

        proximaColumna = SiguienteColumnaEditable(RCFormasPagos, -1, True)

        RCFormasPagos.Navigator.MoveToColumn(proximaColumna)

    End Sub

    Sub AñadirLineaReport(objFormaPago As FormaPago)

        Dim registro As ReportRecord

        registro = RCFormasPagos.Records.Add()

        registro.AddItem(objFormaPago.Id1)
        registro.AddItem(objFormaPago.Descripcion1)
        registro.AddItem(objFormaPago.Plazos1)
        registro.AddItem(objFormaPago.DiasEntrePlazos1)
        registro.AddItem(objFormaPago.PrimerPago1)

        registro.AddItem("")

        registro.Item(COL_AÑADIR).Editable = False
        RCFormasPagos.Populate()

    End Sub

    Private Sub RCFormasPagos_ItemCheck(sender As Object, e As _DReportControlEvents_ItemCheckEvent) Handles RCFormasPagos.ItemCheck

    End Sub

    Private Sub RCFormasPagos_PreviewKeyDownV(sender As Object, e As _DReportControlEvents_PreviewKeyDownVEvent) Handles RCFormasPagos.PreviewKeyDownV

    End Sub

    Private Sub RCFormasPagos_ColumnClick(sender As Object, e As _DReportControlEvents_ColumnClickEvent) Handles RCFormasPagos.ColumnClick

    End Sub
End Class