Imports AxXtremeReportControl
Imports XtremeReportControl
Imports MantEvolution.DefinicionesMenus


Public Class FrmProductos

    Const COL_ID = 0
    Const COL_CODIGO = 1
    Const COL_DESCRIPCION = 2
    Const COL_TIPO = 3
    Const COL_VERSIONES = 4
    Const COL_MANTENIMIENTO = 5
    Const COL_RED = 6
    Const COL_TEMPORAL = 7
    Const COL_PRECIO = 8
    Const COL_PRECIORED = 9
    Const COL_AÑADIR = 10

    Public Permisos As Long

    Dim ArrayProductos As New ArrayList()

    Dim HayErrores As Boolean

    Dim TabPantalla As XtremeCommandBars.RibbonTab = Nothing
    Dim GroupFile As XtremeCommandBars.RibbonGroup = Nothing

    Private Sub FrmProductos_Load(sender As Object, e As EventArgs) Handles Me.Load

        With RCProductos

            .PaintManager.CaptionFont.Name = "Tahoma"
            .PaintManager.CaptionFont.Bold = True

            .PaintManager.TextFont.Name = "Tahoma"

            ' .PaintManager.UseAlternativeBackground = True
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

        CargarProductos()

        'Esta linea hace falta para que funcione el rc_beforedrawrow
        'Aunque el formato se puede poner directamente en la Clase del objeto, mejor
        'RCProductos.SetCustomDraw(XtremeReportControl.XTPReportCustomDraw.xtpCustomBeforeDrawRow)

        RCProductos.Icons = MDIPrincipal.ImageManager.Icons

        fProductos = Me

    End Sub

    Sub CargarProductos()

        Dim Record As XtremeReportControl.ReportRecord
        Dim ObjProducto As Producto

        ArrayProductos = ObtenerProductos()

        For Each ObjProducto In ArrayProductos

            Record = RCProductos.Records.Add()

            Record.AddItem(ObjProducto.Id1)
            Record.AddItem(ObjProducto.Codigo1)
            Record.AddItem(ObjProducto.Descripcion1)
            Record.AddItem(ObjProducto.Tipo1)
            Record.AddItem(ObjProducto.Versiones1)
            Record.AddItem(ObjProducto.IdMantenimiento1)
            Record.AddItem(ObjProducto.Red1)
            Record.AddItem(ObjProducto.Temporal1)
            Record.AddItem(ObjProducto.Precio1)
            Record.AddItem(ObjProducto.PrecioRed1)

            Record.AddItem("") 'Añadir

        Next

        RCProductos.Populate()

    End Sub

    Sub CargarColumnasReport()

        Dim FilaPie As ReportRecord

        RCProductos.PaintManager.ColumnStyle = XTPReportColumnStyle.xtpColumnResource

        RCProductos.AllowEdit = True

        RCProductos.Columns.Add(COL_ID, "IdALMACEN", 100, True)
        RCProductos.Columns.Add(COL_CODIGO, "Codigo", 100, True)
        RCProductos.Columns.Add(COL_DESCRIPCION, "Descripción", 250, True)
        RCProductos.Columns.Add(COL_TIPO, "Tipo", 90, True)
        RCProductos.Columns.Column(COL_TIPO).EditOptions.AddComboButton()
        RCProductos.Columns.Column(COL_TIPO).EditOptions.GetInplaceButton(0).InsideCellButton = True
        RCProductos.Columns.Column(COL_TIPO).EditOptions.ConstraintEdit = True
        RCProductos.Columns.Column(COL_TIPO).EditOptions.Constraints.DeleteAll()
        RCProductos.Columns.Column(COL_TIPO).EditOptions.Constraints.Add("Producto", 0)
        RCProductos.Columns.Column(COL_TIPO).EditOptions.Constraints.Add("Servicio", 1)
        RCProductos.Columns.Column(COL_TIPO).EditOptions.Constraints.Add("Mantenimiento", 2)
        RCProductos.Columns.Column(COL_TIPO).EditOptions.ExpandOnSelect = True
        RCProductos.Columns.Add(COL_VERSIONES, "Versiones", 60, True)
        RCProductos.Columns.Column(COL_VERSIONES).EditOptions.AddComboButton()
        RCProductos.Columns.Column(COL_VERSIONES).EditOptions.GetInplaceButton(0).InsideCellButton = True
        RCProductos.Columns.Column(COL_VERSIONES).EditOptions.ConstraintEdit = True
        RCProductos.Columns.Column(COL_VERSIONES).EditOptions.Constraints.DeleteAll()
        RCProductos.Columns.Column(COL_VERSIONES).EditOptions.Constraints.Add("Sí", -1)
        RCProductos.Columns.Column(COL_VERSIONES).EditOptions.Constraints.Add("No", 0)
        RCProductos.Columns.Column(COL_VERSIONES).EditOptions.ExpandOnSelect = True
        RCProductos.Columns.Add(COL_MANTENIMIENTO, "Mante", 60, True)
        RCProductos.Columns.Column(COL_MANTENIMIENTO).EditOptions.AddComboButton()
        RCProductos.Columns.Column(COL_MANTENIMIENTO).EditOptions.GetInplaceButton(0).InsideCellButton = True
        RCProductos.Columns.Column(COL_MANTENIMIENTO).EditOptions.ConstraintEdit = True
        RCProductos.Columns.Column(COL_MANTENIMIENTO).EditOptions.Constraints.DeleteAll()
        RCProductos.Columns.Column(COL_MANTENIMIENTO).EditOptions.Constraints.Add("Sí", -1)
        RCProductos.Columns.Column(COL_MANTENIMIENTO).EditOptions.Constraints.Add("No", 0)
        RCProductos.Columns.Column(COL_MANTENIMIENTO).EditOptions.ExpandOnSelect = True
        RCProductos.Columns.Add(COL_RED, "Red", 60, True)
        RCProductos.Columns.Column(COL_RED).EditOptions.AddComboButton()
        RCProductos.Columns.Column(COL_RED).EditOptions.GetInplaceButton(0).InsideCellButton = True
        RCProductos.Columns.Column(COL_RED).EditOptions.ConstraintEdit = True
        RCProductos.Columns.Column(COL_RED).EditOptions.Constraints.DeleteAll()
        RCProductos.Columns.Column(COL_RED).EditOptions.Constraints.Add("Sí", -1)
        RCProductos.Columns.Column(COL_RED).EditOptions.Constraints.Add("No", 0)
        RCProductos.Columns.Column(COL_RED).EditOptions.ExpandOnSelect = True
        RCProductos.Columns.Add(COL_TEMPORAL, "Temporal", 60, True)
        RCProductos.Columns.Column(COL_TEMPORAL).EditOptions.AddComboButton()
        RCProductos.Columns.Column(COL_TEMPORAL).EditOptions.GetInplaceButton(0).InsideCellButton = True
        RCProductos.Columns.Column(COL_TEMPORAL).EditOptions.ConstraintEdit = True
        RCProductos.Columns.Column(COL_TEMPORAL).EditOptions.Constraints.DeleteAll()
        RCProductos.Columns.Column(COL_TEMPORAL).EditOptions.Constraints.Add("Sí", -1)
        RCProductos.Columns.Column(COL_TEMPORAL).EditOptions.Constraints.Add("No", 0)
        RCProductos.Columns.Column(COL_TEMPORAL).EditOptions.ExpandOnSelect = True
        RCProductos.Columns.Add(COL_PRECIO, "Precio", 100, True)
        RCProductos.Columns.Add(COL_PRECIORED, "Precio Red", 100, True)
        RCProductos.Columns.Add(COL_AÑADIR, "Añadir", 48, True)

        FilaPie = RCProductos.FooterRecords.Add

        Dim x As Integer
        Dim item As ReportRecordItem

        For x = 0 To RCProductos.Columns.Count - 1
            If x = COL_AÑADIR Then
                item = FilaPie.AddItem("")
                'item.ItemControls.AddButton("0")
                ''    item.ItemControls(0).Alignment = xtpReportItemControlUnknown
                'item.ItemControls(0).Themed = True
                'item.ItemControls(0).SetSize(48, 48)
                'item.ItemControls(0).Enable = True
                'item.ItemControls(0).SetIconIndex(0, 1)

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

        RCProductos.PopulateFooterRows()
        RCProductos.Populate()

        'Configuracion Final del report en cuanto a columnas
        RCProductos.Columns.Find(COL_ID).Visible = False
        RCProductos.Columns.Find(COL_VERSIONES).Alignment = XTPColumnAlignment.xtpAlignmentCenter
        RCProductos.Columns.Find(COL_MANTENIMIENTO).Alignment = XTPColumnAlignment.xtpAlignmentCenter
        RCProductos.Columns.Find(COL_RED).Alignment = XTPColumnAlignment.xtpAlignmentCenter
        RCProductos.Columns.Find(COL_TEMPORAL).Alignment = XTPColumnAlignment.xtpAlignmentCenter
        RCProductos.Columns.Find(COL_PRECIO).Alignment = XTPColumnAlignment.xtpAlignmentRight
        RCProductos.Columns.Find(COL_PRECIORED).Alignment = XTPColumnAlignment.xtpAlignmentRight
        RCProductos.Columns.Find(COL_CODIGO).EditOptions.SelectTextOnEdit = True
        RCProductos.Columns.Find(COL_CODIGO).EditOptions.MaxLength = 15
        RCProductos.Columns.Find(COL_DESCRIPCION).EditOptions.SelectTextOnEdit = True
        RCProductos.Columns.Find(COL_DESCRIPCION).EditOptions.MaxLength = 100
        RCProductos.Columns.Find(COL_PRECIO).EditOptions.SelectTextOnEdit = True
        RCProductos.Columns.Find(COL_PRECIO).EditOptions.MaxLength = 15
        RCProductos.Columns.Find(COL_PRECIORED).EditOptions.SelectTextOnEdit = True
        RCProductos.Columns.Find(COL_PRECIORED).EditOptions.MaxLength = 15



        'RCProductos.FooterRecords(0).Item(COL_PRECIO).Value = "0,00"


    End Sub

    Private Sub FrmProductos_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        ConfigurarPantalla()
    End Sub

    Sub ConfigurarPantalla()

        Titulo.Top = 0
        Titulo.Left = 0
        Titulo.Width = Me.Width

        RCProductos.Left = 10
        RCProductos.Width = Me.Width - 20

        RCProductos.Top = Titulo.Height
        RCProductos.Height = Me.Height - RCProductos.Top - 20

    End Sub

    Public Sub AplicaEstilo()

        Dim X As Object

        For Each X In Me.Controls
            AplicaEstiloControl(X)
        Next X

    End Sub

    Sub AñadirLineaReport(objProducto As Producto)

        Dim registro As ReportRecord

        registro = RCProductos.Records.Add()

        registro.AddItem(objProducto.Id1)
        registro.AddItem(objProducto.Codigo1)
        registro.AddItem(objProducto.Descripcion1)
        registro.AddItem(objProducto.Tipo1)
        registro.AddItem(objProducto.Versiones1)
        registro.AddItem(objProducto.IdMantenimiento1)
        registro.AddItem(objProducto.Red1)
        registro.AddItem(objProducto.Temporal1)
        registro.AddItem(objProducto.Precio1)
        registro.AddItem(objProducto.PrecioRed1)
        registro.AddItem("")

        registro.Item(COL_AÑADIR).Editable = False
        RCProductos.Populate()

    End Sub

    Sub Subirlinea()

        'Dim objProducto = New Producto(RCProductos.FooterRows(0).Record.Item(COL_ID).Value, RCProductos.FooterRows(0).Record.Item(COL_CODIGO).Value, RCProductos.FooterRows(0).Record.Item(COL_DESCRIPCION).Value, RCProductos.FooterRows(0).Record.Item(COL_VERSIONES).Value, RCProductos.FooterRows(0).Record.Item(COL_MANTENIMIENTO).Value, RCProductos.FooterRows(0).Record.Item(COL_RED).Value, RCProductos.FooterRows(0).Record.Item(COL_TEMPORAL).Value, RCProductos.FooterRows(0).Record.Item(COL_PRECIO).Value, RCProductos.FooterRows(0).Record.Item(COL_PRECIORED).Value)
        'Como es un registro nuevo, el campo Id=0
        Dim objProducto = New Producto(0, RCProductos.FooterRows(0).Record.Item(COL_CODIGO).Value, RCProductos.FooterRows(0).Record.Item(COL_DESCRIPCION).Value, RCProductos.FooterRows(0).Record.Item(COL_TIPO).Value, RCProductos.FooterRows(0).Record.Item(COL_VERSIONES).Value, RCProductos.FooterRows(0).Record.Item(COL_MANTENIMIENTO).Value, RCProductos.FooterRows(0).Record.Item(COL_RED).Value, RCProductos.FooterRows(0).Record.Item(COL_TEMPORAL).Value, RCProductos.FooterRows(0).Record.Item(COL_PRECIO).Value, RCProductos.FooterRows(0).Record.Item(COL_PRECIORED).Value)

        Dim proximaColumna As Integer

        GuardarProducto(objProducto)

        AñadirLineaReport(objProducto)

        BorraPie()
        RCProductos.Navigator.CurrentFocusInFootersRows = True

        proximaColumna = SiguienteColumnaEditable(RCProductos, -1, True)

        RCProductos.Navigator.MoveToColumn(proximaColumna)

    End Sub

    Sub BorraPie()
        RCProductos.FooterRows(0).Record.Item(COL_ID).Value = ""
        RCProductos.FooterRows(0).Record.Item(COL_CODIGO).Value = ""
        RCProductos.FooterRows(0).Record.Item(COL_DESCRIPCION).Value = ""
        RCProductos.FooterRows(0).Record.Item(COL_TIPO).Value = ""
        RCProductos.FooterRows(0).Record.Item(COL_VERSIONES).Value = ""
        RCProductos.FooterRows(0).Record.Item(COL_MANTENIMIENTO).Value = ""
        RCProductos.FooterRows(0).Record.Item(COL_RED).Value = ""
        RCProductos.FooterRows(0).Record.Item(COL_TEMPORAL).Value = ""
        RCProductos.FooterRows(0).Record.Item(COL_PRECIO).Value = ""
        RCProductos.FooterRows(0).Record.Item(COL_PRECIORED).Value = ""
    End Sub

    Private Sub RCProductos_ItemButtonClick() Handles RCProductos.ItemButtonClick

        Dim MiRow As ReportRow
        Dim ObjError As New Errores

        MiRow = RCProductos.FocusedRow

        If Permisos <> 2 Then
            ObjError.Pantalla1 = Me
            ObjError.Tipo1 = 1 'Avisos

            ObjError.Titulo = "Productos"

            ObjError.SetMensaje("No dispone de Permiso para Actualizar Productos")

            ObjError.Control1 = "ReportControl"
            ObjError.Pie1 = True
            ObjError.Foco1 = COL_CODIGO

            FrmError.ObjError = ObjError
            FrmError.ShowDialog()
            If FrmError.DialogResult = DialogResult.OK Then
                FrmError.Dispose()
                Exit Sub
            End If
        End If

        If RCProductos.FocusedRow.Section.Index = 1 Then 'Lineas de Detalle
            If Comprobaciones(False) = False Then
                Dim objProducto = New Producto(MiRow.Record.Item(COL_ID).Value, MiRow.Record.Item(COL_CODIGO).Value, MiRow.Record.Item(COL_DESCRIPCION).Value, MiRow.Record.Item(COL_TIPO).Value, MiRow.Record.Item(COL_VERSIONES).Value, MiRow.Record.Item(COL_MANTENIMIENTO).Value, MiRow.Record.Item(COL_RED).Value, MiRow.Record.Item(COL_TEMPORAL).Value, MiRow.Record.Item(COL_PRECIO).Value, MiRow.Record.Item(COL_PRECIORED).Value)
                ModificarProducto(objProducto)

                ObjError.Pantalla1 = Me
                ObjError.Tipo1 = 3 'Avisos

                ObjError.Titulo = "Productos"

                ObjError.SetMensaje("Producto actualizado")

                ObjError.Control1 = "ReportControl"
                ObjError.Pie1 = False
                ObjError.Foco1 = COL_CODIGO

                FrmError.ObjError = ObjError
                FrmError.ShowDialog()
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
        If RCProductos.FocusedRow.Record.Item(COL_CODIGO).Caption = "" Then

            ObjError.SetMensaje("CÓDIGO no se puede dejar vacio")

            If ObjError.Control1 = "" Then
                ObjError.Control1 = "ReportControl"
                'ObjError.Pie1 = True
                ObjError.Foco1 = COL_CODIGO
            End If

            HayErrores = True
        Else ' Columna tipo no se puede repetir

            If EnPie Then
                If ComprobarRepetidoProducto(RCProductos.FocusedRow.Record.Item(COL_CODIGO).Value) = True Then
                    ObjError.SetMensaje("CÓDIGO no puede estar repetido")

                    If ObjError.Control1 = "" Then
                        ObjError.Control1 = "ReportControl"
                        'ObjError.Pie1 = True
                        ObjError.Foco1 = COL_CODIGO
                    End If

                    HayErrores = True
                End If
            End If
        End If

        If RCProductos.FocusedRow.Record.Item(COL_DESCRIPCION).Caption = "" Then

            ObjError.SetMensaje("DESCRIPCIÓN no se puede dejar vacia")

            If ObjError.Control1 = "" Then
                ObjError.Control1 = "ReportControl"
                'ObjError.Pie1 = True
                ObjError.Foco1 = COL_DESCRIPCION
            End If

            HayErrores = True
        End If

        If RCProductos.FocusedRow.Record.Item(COL_TIPO).Caption = "" Then

            ObjError.SetMensaje("TIPO no se puede dejar vacio")

            If ObjError.Control1 = "" Then
                ObjError.Control1 = "ReportControl"
                'ObjError.Pie1 = True
                ObjError.Foco1 = COL_TIPO
            End If

            HayErrores = True
        End If

        If RCProductos.FocusedRow.Record.Item(COL_VERSIONES).Caption = "" Then

            ObjError.SetMensaje("VERSIÓN no se puede dejar vacia")

            If ObjError.Control1 = "" Then
                ObjError.Control1 = "ReportControl"
                'ObjError.Pie1 = True
                ObjError.Foco1 = COL_VERSIONES
            End If

            HayErrores = True
        End If
        If RCProductos.FocusedRow.Record.Item(COL_MANTENIMIENTO).Caption = "" Then

            ObjError.SetMensaje("MANTENIMIENTO no se puede dejar vacio")

            If ObjError.Control1 = "" Then
                ObjError.Control1 = "ReportControl"
                'ObjError.Pie1 = True
                ObjError.Foco1 = COL_MANTENIMIENTO
            End If

            HayErrores = True
        End If
        If RCProductos.FocusedRow.Record.Item(COL_RED).Caption = "" Then

            ObjError.SetMensaje("RED no se puede dejar vacia")

            If ObjError.Control1 = "" Then
                ObjError.Control1 = "ReportControl"
                'ObjError.Pie1 = True
                ObjError.Foco1 = COL_RED
            End If

            HayErrores = True
        End If
        If RCProductos.FocusedRow.Record.Item(COL_TEMPORAL).Caption = "" Then

            ObjError.SetMensaje("TEMPORAL no se puede dejar vacia")

            If ObjError.Control1 = "" Then
                ObjError.Control1 = "ReportControl"
                'ObjError.Pie1 = True
                ObjError.Foco1 = COL_TEMPORAL
            End If

            HayErrores = True
        End If
        If RCProductos.FocusedRow.Record.Item(COL_PRECIO).Caption = "" Then

            ObjError.SetMensaje("PRECIO no se puede dejar vacio")

            If ObjError.Control1 = "" Then
                ObjError.Control1 = "ReportControl"
                'ObjError.Pie1 = True
                ObjError.Foco1 = COL_PRECIO
            End If

            HayErrores = True
        End If
        If RCProductos.FocusedRow.Record.Item(COL_PRECIORED).Caption = "" Then

            ObjError.SetMensaje("PRECIO RED no se puede dejar vacio")

            If ObjError.Control1 = "" Then
                ObjError.Control1 = "ReportControl"
                ObjError.Pie1 = True
                ObjError.Foco1 = COL_PRECIORED
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

    Public Sub ControlErrores(objError As Errores)

        If objError.Control1.ToString = "ReportControl" Then
            If objError.Pie1 = True Then
                RCProductos.Navigator.CurrentFocusInFootersRows = True
            End If

            RCProductos.Navigator.MoveToColumn(RCProductos.Columns.Find(objError.Foco1).Index, False)
            RCProductos.Navigator.BeginEdit()
        End If

    End Sub

    Private Sub RCProductos_PreviewKeyDownEvent(sender As Object, e As _DReportControlEvents_PreviewKeyDownEvent) Handles RCProductos.PreviewKeyDownEvent
        Dim proximaColumna As Integer
        Dim esPies As Boolean

        esPies = False

        Select Case e.keyCode
            Case 13 'Enter

                If RCProductos.FocusedRow.Section.Index = 2 Then
                    esPies = True
                End If

                proximaColumna = SiguienteColumnaEditable(RCProductos, RCProductos.FocusedColumn.Index, esPies)

                ' RCProductos.Populate()
                If esPies = True Then
                    RCProductos.Navigator.CurrentFocusInFootersRows = True
                End If

                RCProductos.Navigator.MoveToColumn(proximaColumna, False)

                RCProductos.Navigator.BeginEdit()

                If RCProductos.Columns(proximaColumna).ItemIndex = COL_AÑADIR Then
                    '   RCProductos.FooterRows(0).Record.Item(COL_AÑADIR)
                    RCProductos_ItemButtonClick()
                End If

            Case 9 'Tab
                If e.shift = 1 Then
                    If RCProductos.FocusedRow.Section.Index = 2 Then
                        esPies = True
                    End If

                    proximaColumna = AnteriorColumnaEditable(RCProductos, RCProductos.FocusedColumn.Index, esPies)

                    RCProductos.Populate()
                    If esPies = True Then
                        RCProductos.Navigator.CurrentFocusInFootersRows = True
                    End If

                    RCProductos.Navigator.MoveToColumn(proximaColumna, False)

                    RCProductos.Navigator.BeginEdit()

                    e.cancel = True
                Else
                    If RCProductos.FocusedRow.Section.Index = 2 Then
                        esPies = True
                    End If

                    proximaColumna = SiguienteColumnaEditable(RCProductos, RCProductos.FocusedColumn.Index, esPies)

                    RCProductos.Populate()
                    If esPies = True Then
                        RCProductos.Navigator.CurrentFocusInFootersRows = True
                    End If

                    RCProductos.Navigator.MoveToColumn(proximaColumna, False)

                    RCProductos.Navigator.BeginEdit()
                    e.cancel = True
                End If

            Case 16
                e.cancel = True

            Case 38
                RCProductos.Populate()
                RCProductos.Navigator.MoveUp()
                RCProductos.Navigator.BeginEdit()
                e.cancel = True

            Case 40
                RCProductos.Populate()
                RCProductos.Navigator.MoveDown()
                RCProductos.Navigator.BeginEdit()
                e.cancel = True

        End Select

        If Not RCProductos.FocusedColumn Is Nothing Then
            Select Case RCProductos.FocusedColumn.ItemIndex
                Case COL_PRECIO, COL_PRECIORED
                    If e.keyCode = 110 Then e.keyCode = 188 '(si pulsa la tecla del punto en el teclado númerico, lo cambio por la coma)
                    If e.keyCode = 190 Then e.keyCode = 188 '(si pulsa la tecla del punto del teclado normal, lo cambio por la coma)

            End Select
        End If

    End Sub

    Private Sub RCProductos_ValueChanging(sender As Object, e As _DReportControlEvents_ValueChangingEvent) Handles RCProductos.ValueChanging

        Dim ObjError As New Errores

        HayErrores = False
        ObjError.Pantalla1 = Me
        ObjError.Tipo1 = 1 'Alertas

        Select Case e.column.ItemIndex
            Case COL_PRECIO
                e.newValue = Format(CDbl(e.newValue), FormatoImporte)

            Case COL_PRECIORED
                e.newValue = Format(CDbl(e.newValue), FormatoImporte)

        End Select

        'Select Case e.column.ItemIndex
        '    Case COL_IVA
        '        If e.newValue >= 100 Then
        '            ObjError.SetMensaje(GetTextoIdioma(11122))
        '            ObjError.Titulo = "IVA"
        '            ObjError.Control1 = "ReportControl"
        '            ObjError.Pie1 = True
        '            ObjError.Foco1 = COL_IVA
        '            HayErrores = True
        '        Else
        '            e.newValue = Format(CDbl(e.newValue), FormatoPorcentaje)
        '        End If
        '    Case COL_RE
        '        If e.newValue >= 100 Then
        '            ObjError.SetMensaje(GetTextoIdioma(11122))
        '            ObjError.Titulo = "RE"
        '            ObjError.Control1 = "ReportControl"
        '            ObjError.Pie1 = True
        '            ObjError.Foco1 = COL_RE
        '            HayErrores = True
        '        Else
        '            e.newValue = Format(CDbl(e.newValue), FormatoPorcentaje)
        '        End If
        'End Select

        If e.row.Section.Index = 1 Then
            Select Case e.column.ItemIndex
                Case COL_CODIGO
                    If e.newValue = "" Then
                        ObjError.SetMensaje("Código no se puede dejar vacio")
                        ObjError.Control1 = "ReportControl"
                        ObjError.Pie1 = True
                        ObjError.Foco1 = COL_CODIGO
                        HayErrores = True
                        'Else
                        '    If ComprobarRepetidoProducto(e.newValue) = True Then
                        '        ObjError.SetMensaje("Código no puede estar repetido")
                        '        ObjError.Control1 = "ReportControl"
                        '        ObjError.Pie1 = True
                        '        ObjError.Foco1 = COL_CODIGO
                        '        HayErrores = True
                        '    End If
                    End If

                Case COL_DESCRIPCION
                    If e.newValue = "" Then
                        ObjError.SetMensaje("Descripción no se puede dejar vacia")
                        ObjError.Control1 = "ReportControl"
                        ObjError.Pie1 = True
                        ObjError.Foco1 = COL_DESCRIPCION

                        HayErrores = True
                    End If

                Case COL_TIPO
                    If e.newValue = "" Then
                        ObjError.SetMensaje("TIPO no se puede dejar vacio")
                        ObjError.Control1 = "ReportControl"
                        ObjError.Pie1 = True
                        ObjError.Foco1 = COL_TIPO

                        HayErrores = True
                    End If

            End Select

        End If

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

    Private Sub FrmProductos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        fProductos = Nothing

        MDIPrincipal.RibbonBar.RemoveTab(DEFMENU.GRUPO_MAESTROS_PRODUCTOS)
        'MDIPrincipal.RibbonBar.Reset()
        MDIPrincipal.RibbonBar.RedrawBar()
        MDIPrincipal.RibbonBar.RecalcLayout()

        MDIPrincipal.RibbonBar.FindTab(DEFMENU.TAB_MAESTROS).Selected = True
        MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_MAESTROS_PRODUCTOS).Visible = False

    End Sub

    Sub ConstruirMenu()

        If MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_MAESTROS_PRODUCTOS) Is Nothing Then 'si no existe lo creo
            TabPantalla = MDIPrincipal.RibbonBar.InsertTab(DEFMENU.GRUPO_MAESTROS_PRODUCTOS, "&Productos")
            TabPantalla.Id = DEFMENU.GRUPO_MAESTROS_PRODUCTOS

            'GroupFile = TabPrincipal.Groups.AddGroup("&MANTE", 1001)
            'GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.PRINCIPAL_MANTENIMIENTO, "Mantenimiento", False, False)
            GroupFile = TabPantalla.Groups.AddGroup("&PRODUCTOS", DEFMENU.GRUPO_MAESTROS_PRODUCTOS)
            GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_PRODUCTOS_NUEVO, "Nuevo", False, False).IconId = 100
            GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_PRODUCTOS_ELIMINAR, "Eliminar", False, False).IconId = 101
            GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_PRODUCTOS_IMPRIMIR, "Imprimir", False, False).IconId = 102
            GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_PRODUCTOS_SALIR, "Salir", False, False).IconId = 103
        End If

        MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_MAESTROS_PRODUCTOS).Visible = True
        MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_MAESTROS_PRODUCTOS).Selected = True

    End Sub

    Private Sub FrmProductos_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        ConstruirMenu()
    End Sub

    Sub Menu_Nuevo()
        Dim proximaColumna As Integer

        RCProductos.Navigator.CurrentFocusInFootersRows = True
        proximaColumna = SiguienteColumnaEditable(RCProductos, -1, True)
        RCProductos.Navigator.MoveToColumn(proximaColumna)
        RCProductos.Navigator.BeginEdit()
    End Sub

    Sub Menu_Eliminar()

        Dim ObjError As New Errores

        If RCProductos.FocusedRow.Section.Index <> 1 Then Exit Sub

        If Permisos <> 2 Then
            ObjError.Pantalla1 = Me
            ObjError.Tipo1 = 1 'Avisos

            ObjError.Titulo = "Productos"

            ObjError.SetMensaje("No dispone de Permiso para Eliminar Productos")

            ObjError.Control1 = "ReportControl"
            ObjError.Pie1 = True
            ObjError.Foco1 = COL_CODIGO

            FrmError.ObjError = ObjError
            FrmError.ShowDialog()
            If FrmError.DialogResult = DialogResult.OK Then
                FrmError.Dispose()
                Exit Sub
            End If
        End If

        If ComprobarRelaciones() Then
            ObjError.Pantalla1 = Me
            ObjError.Tipo1 = 1 'Avisos

            ObjError.Titulo = "Productos"

            ObjError.SetMensaje("Este Producto tiene registros relacionados," & Chr(13) & "elimínelos antes.")

            ObjError.Control1 = "ReportControl"
            ObjError.Pie1 = True
            ObjError.Foco1 = COL_CODIGO

            FrmError.ObjError = ObjError
            FrmError.ShowDialog()
            If FrmError.DialogResult = DialogResult.OK Then
                FrmError.Dispose()
                Exit Sub
            End If
        End If

        ObjError.Pantalla1 = Me
        ObjError.Tipo1 = 2 'Mensajes

        ObjError.Titulo = "Productos"

        ObjError.SetMensaje("¿Desea eliminar el Producto seleccionado?")

        ObjError.Control1 = ""
        ObjError.Pie1 = True
        ObjError.Foco1 = COL_CODIGO

        FrmError.ObjError = ObjError
        FrmError.ShowDialog()
        'ControlErrores(ObjError)

        If FrmError.DialogResult = DialogResult.Yes Then
            FrmError.Dispose()
            Dim E As ReportRow
            E = RCProductos.FocusedRow
            Dim objProducto = New Producto(E.Record.Item(COL_ID).Value, E.Record.Item(COL_CODIGO).Value, E.Record.Item(COL_DESCRIPCION).Value, E.Record.Item(COL_TIPO).Value, E.Record.Item(COL_VERSIONES).Value, E.Record.Item(COL_MANTENIMIENTO).Value, E.Record.Item(COL_RED).Value, E.Record.Item(COL_TEMPORAL).Value, E.Record.Item(COL_PRECIO).Value, E.Record.Item(COL_PRECIORED).Value)
            EliminarProducto(objProducto)
            RCProductos.RemoveRowEx(RCProductos.FocusedRow)
        ElseIf FrmError.DialogResult = DialogResult.Cancel Then
            FrmError.Dispose()
        End If
    End Sub

    Sub Menu_Imprimir()
        RCProductos.PrintOptions.Header.TextCenter = Me.Titulo.Caption
        RCProductos.PrintOptions.Header.Font.Size = 18
        RCProductos.PrintOptions.Header.Font.Bold = True
        'RCProductos.PrintPreviewOptions.Title = Me.Titulo.Caption
        RCProductos.PrintPreview(True)
    End Sub

    Function ComprobarRelaciones() As Boolean
        'Miro si hay algún registro relacionado en tabla Versiones
        ComprobarRelaciones = False
        Dim E As ReportRow
        E = RCProductos.FocusedRow
        Dim objProducto = New Producto(E.Record.Item(COL_ID).Value, E.Record.Item(COL_CODIGO).Value, E.Record.Item(COL_DESCRIPCION).Value, E.Record.Item(COL_TIPO).Value, E.Record.Item(COL_VERSIONES).Value, E.Record.Item(COL_MANTENIMIENTO).Value, E.Record.Item(COL_RED).Value, E.Record.Item(COL_TEMPORAL).Value, E.Record.Item(COL_PRECIO).Value, E.Record.Item(COL_PRECIORED).Value)
        If objProducto.ArrayVersiones1.Count > 0 Then
            ComprobarRelaciones = True
        End If

        'También habrá que mirar si tiene movimientos o está en packs o en productosclientes

    End Function

    Private Sub RCProductos_InplaceEditChanging(sender As Object, e As _DReportControlEvents_InplaceEditChangingEvent) Handles RCProductos.InplaceEditChanging
        Select Case e.column.ItemIndex
            Case COL_PRECIO, COL_PRECIORED

                If Len(e.newValue) > 0 Then
                    If e.newValue <> "-" Then
                        e.cancel = Not IsNumeric(e.newValue)
                    End If
                End If

        End Select
    End Sub

    Private Sub RCProductos_GotFocus(sender As Object, e As EventArgs) Handles RCProductos.GotFocus
        Dim MiItem As XtremeReportControl.ReportRecordItem

        MiItem = RCProductos.FocusedRow.Record.Item(COL_AÑADIR)
        MiItem.ItemControls.AddButton(0)
        MiItem.ItemControls(0).SetSize(48, 48)
        MiItem.ItemControls(0).Themed = True
        MiItem.ItemControls(0).SetIconIndex(0, 2)
        MiItem.Alignment = XTPColumnAlignment.xtpAlignmentCenter
    End Sub

    Private Sub RCProductos_FocusChanging(sender As Object, e As _DReportControlEvents_FocusChangingEvent) Handles RCProductos.FocusChanging
        Dim X As Long
        For X = 0 To RCProductos.Rows.Count - 1
            RCProductos.Rows(X).Record.Item(COL_AÑADIR).ItemControls.RemoveAll()
        Next X

        RCProductos.FooterRows(0).Record.Item(COL_AÑADIR).ItemControls.RemoveAll()

        Dim MiItem As XtremeReportControl.ReportRecordItem
        MiItem = e.newRow.Record.Item(COL_AÑADIR)
        MiItem.ItemControls.AddButton(0)
        MiItem.ItemControls(0).SetSize(48, 48)
        MiItem.ItemControls(0).Themed = True
        If e.newRow.Section.Index = 1 Then
            MiItem.ItemControls(0).SetIconIndex(0, 2)
        Else
            MiItem.ItemControls(0).SetIconIndex(0, 1)
        End If
        MiItem.Alignment = XTPColumnAlignment.xtpAlignmentCenter
    End Sub

    Private Sub FrmProductos_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp

    End Sub
End Class