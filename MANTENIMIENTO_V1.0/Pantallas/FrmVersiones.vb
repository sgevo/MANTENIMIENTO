Imports AxXtremeReportControl
Imports XtremeReportControl
Imports MantEvolution.DefinicionesMenus


Public Class FrmVersiones

    Const COL_ID = 0
    Const COL_VERSION = 1
    Const COL_ORDEN = 2
    Const COL_ULTIMA = 3
    Const COL_PRECIO = 4
    Const COL_PRECIORED = 5
    Const COL_AÑADIR = 6

    Public Permisos As Long

    Dim ArrayProductos As New ArrayList()

    Dim HayErrores As Boolean

    Dim idProducto As Long

    Dim TabPantalla As XtremeCommandBars.RibbonTab = Nothing
    Dim GrupoPantalla As XtremeCommandBars.RibbonGroup = Nothing

    Private Sub FrmVersiones_Load(sender As Object, e As EventArgs) Handles Me.Load

        cbProductos.ReCreateReparented = True 'Esto es necesario porque si no los eventos no van

        With RCVersiones

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
            '.SetImageList(ImageList8)

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

        'CargarComboProductos() 'lo saco fuera

        RCVersiones.Icons = MDIPrincipal.ImageManager.Icons

        fVersiones = Me

    End Sub

    Public Sub CargarComboProductos()

        BDProductos.GetProductosVersion(cbProductos)
        If cbProductos.ListCount > 0 Then
            cbProductos.ListIndex = 0
        Else
            cbProductos.ListIndex = -1
        End If

    End Sub

    Sub CargarColumnasReport()

        Dim FilaPie As ReportRecord

        RCVersiones.PaintManager.ColumnStyle = XTPReportColumnStyle.xtpColumnResource

        RCVersiones.AllowEdit = True

        RCVersiones.Columns.Add(COL_ID, "IdVersiones", 100, True)
        RCVersiones.Columns.Add(COL_VERSION, "Versión", 100, True)
        RCVersiones.Columns.Add(COL_ORDEN, "Orden", 100, True)
        RCVersiones.Columns.Add(COL_ULTIMA, "Última", 60, True)
        RCVersiones.Columns.Column(COL_ULTIMA).EditOptions.AddComboButton()
        RCVersiones.Columns.Column(COL_ULTIMA).EditOptions.GetInplaceButton(0).InsideCellButton = True
        RCVersiones.Columns.Column(COL_ULTIMA).EditOptions.ConstraintEdit = True
        RCVersiones.Columns.Column(COL_ULTIMA).EditOptions.Constraints.DeleteAll()
        RCVersiones.Columns.Column(COL_ULTIMA).EditOptions.Constraints.Add("Sí", -1)
        RCVersiones.Columns.Column(COL_ULTIMA).EditOptions.Constraints.Add("No", 0)
        RCVersiones.Columns.Column(COL_ULTIMA).EditOptions.ExpandOnSelect = True
        RCVersiones.Columns.Add(COL_PRECIO, "Precio", 100, True)
        RCVersiones.Columns.Add(COL_PRECIORED, "Precio Red", 100, True)
        RCVersiones.Columns.Add(COL_AÑADIR, "Editar", 48, True)

        FilaPie = RCVersiones.FooterRecords.Add

        Dim x As Integer
        Dim item As ReportRecordItem

        For x = 0 To RCVersiones.Columns.Count - 1
            If x = COL_AÑADIR Then
                item = FilaPie.AddItem("")
                item.ItemControls.AddButton("0")
                '    item.ItemControls(0).Alignment = xtpReportItemControlUnknown
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

        RCVersiones.PopulateFooterRows()
        RCVersiones.Populate()

        'Configuracion Final del report en cuanto a columnas
        RCVersiones.Columns.Find(COL_ID).Visible = False
        RCVersiones.Columns.Find(COL_VERSION).Alignment = XTPColumnAlignment.xtpAlignmentCenter
        RCVersiones.Columns.Find(COL_ULTIMA).Alignment = XTPColumnAlignment.xtpAlignmentCenter
        RCVersiones.Columns.Find(COL_ORDEN).Alignment = XTPColumnAlignment.xtpAlignmentCenter
        RCVersiones.Columns.Find(COL_PRECIO).Alignment = XTPColumnAlignment.xtpAlignmentRight
        RCVersiones.Columns.Find(COL_PRECIORED).Alignment = XTPColumnAlignment.xtpAlignmentRight

        RCVersiones.Columns.Find(COL_VERSION).EditOptions.SelectTextOnEdit = True
        RCVersiones.Columns.Find(COL_VERSION).EditOptions.MaxLength = 25
        RCVersiones.Columns.Find(COL_ORDEN).EditOptions.SelectTextOnEdit = True
        RCVersiones.Columns.Find(COL_ORDEN).EditOptions.MaxLength = 5
        RCVersiones.Columns.Find(COL_PRECIO).EditOptions.SelectTextOnEdit = True
        RCVersiones.Columns.Find(COL_PRECIO).EditOptions.MaxLength = 15
        RCVersiones.Columns.Find(COL_PRECIORED).EditOptions.SelectTextOnEdit = True
        RCVersiones.Columns.Find(COL_PRECIORED).EditOptions.MaxLength = 15

    End Sub

    Private Sub RCVersiones_GotFocus(sender As Object, e As EventArgs) Handles RCVersiones.GotFocus

        Dim MiItem As XtremeReportControl.ReportRecordItem

        If RCVersiones.Records.Count = 0 Then Exit Sub

        MiItem = RCVersiones.FocusedRow.Record.Item(COL_AÑADIR)
        MiItem.ItemControls.AddButton(0)
        MiItem.ItemControls(0).SetSize(48, 48)
        MiItem.ItemControls(0).Themed = True
        MiItem.ItemControls(0).SetIconIndex(0, 2)
        MiItem.Alignment = XTPColumnAlignment.xtpAlignmentCenter

    End Sub

    Private Sub RCVersiones_FocusChanging(sender As Object, e As _DReportControlEvents_FocusChangingEvent) Handles RCVersiones.FocusChanging

        Dim X As Long
        For X = 0 To RCVersiones.Rows.Count - 1
            RCVersiones.Rows(X).Record.Item(COL_AÑADIR).ItemControls.RemoveAll()
        Next X

        RCVersiones.FooterRows(0).Record.Item(COL_AÑADIR).ItemControls.RemoveAll()

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

    Private Sub RCVersiones_ItemButtonClick() Handles RCVersiones.ItemButtonClick

        Dim MiRow As ReportRow
        Dim ObjError As New Errores

        MiRow = RCVersiones.FocusedRow

        If Permisos <> 2 Then
            ObjError.Pantalla1 = Me
            ObjError.Tipo1 = 1 'Avisos

            ObjError.Titulo = "Versiones"

            ObjError.SetMensaje("No dispone de Permiso para Actualizar Versiones")

            ObjError.Control1 = "ReportControl"
            ObjError.Pie1 = True
            ObjError.Foco1 = COL_VERSION

            FrmError.ObjError = ObjError
            FrmError.ShowDialog()
            If FrmError.DialogResult = DialogResult.OK Then
                FrmError.Dispose()
                Exit Sub
            End If
        End If

        If RCVersiones.FocusedRow.Section.Index = 1 Then 'Lineas de Detalle
            If Comprobaciones(False) = False Then
                Dim objVersion = New Version(MiRow.Record.Item(COL_ID).Value, MiRow.Record.Item(COL_VERSION).Value, MiRow.Record.Item(COL_ORDEN).Value, MiRow.Record.Item(COL_ULTIMA).Value, MiRow.Record.Item(COL_PRECIO).Value, MiRow.Record.Item(COL_PRECIORED).Value)
                ModificarVersion(objVersion)

                'Si es última entonces cambio todas las demás versiones a N
                Dim MisVersiones As Long
                Dim Actual As Long
                If RCVersiones.FocusedRow.Record.Item(COL_ULTIMA).Value = True Then
                    MisVersiones = 0
                    Actual = RCVersiones.FocusedRow.Record.Index
                    While MisVersiones < RCVersiones.Records.Count
                        If Actual <> RCVersiones.Records.Record(MisVersiones).Index Then
                            If RCVersiones.Records.Record(MisVersiones).Item(COL_ULTIMA).Value = True Then
                                RCVersiones.Records.Record(MisVersiones).Item(COL_ULTIMA).Value = False
                                Dim objVersion2 = New Version(RCVersiones.Records.Record(MisVersiones).Item(COL_ID).Value, RCVersiones.Records.Record(MisVersiones).Item(COL_VERSION).Value, RCVersiones.Records.Record(MisVersiones).Item(COL_ORDEN).Value, RCVersiones.Records.Record(MisVersiones).Item(COL_ULTIMA).Value, RCVersiones.Records.Record(MisVersiones).Item(COL_PRECIO).Value, RCVersiones.Records.Record(MisVersiones).Item(COL_PRECIORED).Value)
                                ModificarVersion(objVersion2)
                            End If
                        End If
                        MisVersiones = MisVersiones + 1
                    End While
                End If

                ObjError.Pantalla1 = Me
                ObjError.Tipo1 = 3 'Avisos
                ObjError.Titulo = "Versiones"
                ObjError.SetMensaje("Versión actualizada")
                ObjError.Control1 = "ReportControl"
                ObjError.Pie1 = False
                ObjError.Foco1 = COL_VERSION

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

    Private Sub RCVersiones_PreviewKeyDownEvent(sender As Object, e As _DReportControlEvents_PreviewKeyDownEvent) Handles RCVersiones.PreviewKeyDownEvent
        Dim proximaColumna As Integer
        Dim esPies As Boolean

        esPies = False

        Select Case e.keyCode
            Case 13 'Enter

                If RCVersiones.FocusedRow.Section.Index = 2 Then
                    esPies = True
                End If

                proximaColumna = SiguienteColumnaEditable(RCVersiones, RCVersiones.FocusedColumn.Index, esPies)

                ' RCVersiones.Populate()
                If esPies = True Then
                    RCVersiones.Navigator.CurrentFocusInFootersRows = True
                End If

                RCVersiones.Navigator.MoveToColumn(proximaColumna, False)

                RCVersiones.Navigator.BeginEdit()

                If RCVersiones.Columns(proximaColumna).ItemIndex = COL_AÑADIR Then
                    '   RCVersiones.FooterRows(0).Record.Item(COL_AÑADIR)
                    RCVersiones_ItemButtonClick()
                End If

            Case 9 'Tab
                If e.shift = 1 Then
                    If RCVersiones.FocusedRow.Section.Index = 2 Then
                        esPies = True
                    End If

                    proximaColumna = AnteriorColumnaEditable(RCVersiones, RCVersiones.FocusedColumn.Index, esPies)

                    RCVersiones.Populate()
                    If esPies = True Then
                        RCVersiones.Navigator.CurrentFocusInFootersRows = True
                    End If

                    RCVersiones.Navigator.MoveToColumn(proximaColumna, False)

                    RCVersiones.Navigator.BeginEdit()

                    e.cancel = True
                Else
                    If RCVersiones.FocusedRow.Section.Index = 2 Then
                        esPies = True
                    End If

                    proximaColumna = SiguienteColumnaEditable(RCVersiones, RCVersiones.FocusedColumn.Index, esPies)

                    RCVersiones.Populate()
                    If esPies = True Then
                        RCVersiones.Navigator.CurrentFocusInFootersRows = True
                    End If

                    RCVersiones.Navigator.MoveToColumn(proximaColumna, False)

                    RCVersiones.Navigator.BeginEdit()
                    e.cancel = True
                End If

            Case 16
                e.cancel = True

            Case 38
                RCVersiones.Populate()
                RCVersiones.Navigator.MoveUp()
                RCVersiones.Navigator.BeginEdit()
                e.cancel = True

            Case 40
                RCVersiones.Populate()
                RCVersiones.Navigator.MoveDown()
                RCVersiones.Navigator.BeginEdit()
                e.cancel = True

        End Select

        If Not RCVersiones.FocusedColumn Is Nothing Then
            Select Case RCVersiones.FocusedColumn.ItemIndex
                Case COL_PRECIO, COL_PRECIORED
                    If e.keyCode = 110 Then e.keyCode = 188 '(si pulsa la tecla del punto en el teclado númerico, lo cambio por la coma)
                    If e.keyCode = 190 Then e.keyCode = 188 '(si pulsa la tecla del punto del teclado normal, lo cambio por la coma)

            End Select
        End If

    End Sub

    Private Sub RCVersiones_ValueChanging(sender As Object, e As _DReportControlEvents_ValueChangingEvent) Handles RCVersiones.ValueChanging

        Dim ObjError As New Errores

        Select Case e.column.ItemIndex
            Case COL_PRECIO
                e.newValue = Format(CDbl(e.newValue), FormatoImporte)

            Case COL_PRECIORED
                e.newValue = Format(CDbl(e.newValue), FormatoImporte)

        End Select

        HayErrores = False
        ObjError.Pantalla1 = Me
        ObjError.Tipo1 = 1 'Alertas

        If e.row.Section.Index = 1 Then
            Select Case e.column.ItemIndex
                Case COL_VERSION
                    If e.newValue = "" Then
                        ObjError.SetMensaje("Versión no se puede dejar vacia")
                        ObjError.Control1 = "ReportControl"
                        ObjError.Pie1 = True
                        ObjError.Foco1 = COL_VERSION
                        HayErrores = True
                    Else
                        'If ComprobarRepetidoVersion(e.newValue) = True Then
                        '    ObjError.SetMensaje("Versión no puede estar repetida")
                        '    ObjError.Control1 = "ReportControl"
                        '    ObjError.Pie1 = True
                        '    ObjError.Foco1 = COL_VERSION
                        '    HayErrores = True
                        'End If
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

    Private Sub RCVersiones_InplaceEditChanging(sender As Object, e As _DReportControlEvents_InplaceEditChangingEvent) Handles RCVersiones.InplaceEditChanging
        Select Case e.column.ItemIndex
            Case COL_PRECIO, COL_PRECIORED, COL_ORDEN

                If Len(e.newValue) > 0 Then
                    If e.newValue <> "-" Then
                        e.cancel = Not IsNumeric(e.newValue)
                    End If
                End If

        End Select
    End Sub

    Private Sub FrmVersiones_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        ConfigurarPantalla()
    End Sub

    Sub ConfigurarPantalla()

        Titulo.Top = 0
        Titulo.Left = 0
        Titulo.Width = Me.Width

        lblProductos.Left = 10
        lblProductos.Top = Titulo.Height + 10

        cbProductos.Left = 10
        cbProductos.Top = Titulo.Height + lblProductos.Height + 10

        RCVersiones.Left = cbProductos.Left + cbProductos.Width + 10
        RCVersiones.Width = Me.Width - cbProductos.Width - 30

        RCVersiones.Top = Titulo.Height
        RCVersiones.Height = Me.Height - RCVersiones.Top - 20

    End Sub

    Public Sub AplicaEstilo()

        Dim X As Object

        For Each X In Me.Controls
            AplicaEstiloControl(X)
        Next X

    End Sub

    Sub AñadirLineaReport(objVersion As Version)

        Dim registro As ReportRecord

        registro = RCVersiones.Records.Add()

        registro.AddItem(objVersion.Id1)
        registro.AddItem(objVersion.Version1)
        registro.AddItem(objVersion.Orden1)
        registro.AddItem(objVersion.Ultima1)
        registro.AddItem(objVersion.Precio1)
        registro.AddItem(objVersion.PrecioRed1)
        registro.AddItem("")

        registro.Item(COL_AÑADIR).Editable = False
        RCVersiones.Populate()

    End Sub

    Sub Subirlinea()

        '        Dim objProducto = New Producto(RCVersiones.FooterRows(0).Record.Item(COL_ID).Value, RCVersiones.FooterRows(0).Record.Item(COL_CODIGO).Value, RCVersiones.FooterRows(0).Record.Item(COL_DESCRIPCION).Value, RCVersiones.FooterRows(0).Record.Item(COL_VERSIONES).Value, RCVersiones.FooterRows(0).Record.Item(COL_MANTENIMIENTO).Value, RCVersiones.FooterRows(0).Record.Item(COL_RED).Value, RCVersiones.FooterRows(0).Record.Item(COL_TEMPORAL).Value, RCVersiones.FooterRows(0).Record.Item(COL_PRECIO).Value, RCVersiones.FooterRows(0).Record.Item(COL_PRECIORED).Value)
        'Como es un registro nuevo, el campo Id=0
        Dim objVersion = New Version(idProducto, RCVersiones.FooterRows(0).Record.Item(COL_VERSION).Value, RCVersiones.FooterRows(0).Record.Item(COL_ORDEN).Value, RCVersiones.FooterRows(0).Record.Item(COL_ULTIMA).Value, RCVersiones.FooterRows(0).Record.Item(COL_PRECIO).Value, RCVersiones.FooterRows(0).Record.Item(COL_PRECIORED).Value, ObtenerUnProducto(idProducto))

        Dim proximaColumna As Integer

        GuardarVersion(objVersion)

        AñadirLineaReport(objVersion)

        'Si es última entonces cambio todas las demás versiones a N
        Dim MisVersiones As Long
        If RCVersiones.FooterRows(0).Record.Item(COL_ULTIMA).Value = -1 Then
            MisVersiones = 0
            While MisVersiones < RCVersiones.Records.Count - 1
                If RCVersiones.Records.Record(MisVersiones).Item(COL_ULTIMA).Value = True Then
                    RCVersiones.Records.Record(MisVersiones).Item(COL_ULTIMA).Value = False
                    Dim objVersion2 = New Version(RCVersiones.Records.Record(MisVersiones).Item(COL_ID).Value, RCVersiones.Records.Record(MisVersiones).Item(COL_VERSION).Value, RCVersiones.Records.Record(MisVersiones).Item(COL_ORDEN).Value, RCVersiones.Records.Record(MisVersiones).Item(COL_ULTIMA).Value, RCVersiones.Records.Record(MisVersiones).Item(COL_PRECIO).Value, RCVersiones.Records.Record(MisVersiones).Item(COL_PRECIORED).Value)
                    ModificarVersion(objVersion2)
                End If
                MisVersiones = MisVersiones + 1
            End While
        End If

        BorraPie()

        RCVersiones.Navigator.CurrentFocusInFootersRows = True

        proximaColumna = SiguienteColumnaEditable(RCVersiones, -1, True)

        RCVersiones.Navigator.MoveToColumn(proximaColumna)

    End Sub

    Sub BorraPie()
        RCVersiones.FooterRows(0).Record.Item(COL_ID).Value = ""
        RCVersiones.FooterRows(0).Record.Item(COL_VERSION).Value = ""
        RCVersiones.FooterRows(0).Record.Item(COL_ORDEN).Value = ""
        RCVersiones.FooterRows(0).Record.Item(COL_ULTIMA).Value = ""
        RCVersiones.FooterRows(0).Record.Item(COL_PRECIO).Value = ""
        RCVersiones.FooterRows(0).Record.Item(COL_PRECIORED).Value = ""
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
        'If RCVersiones.FooterRows(0).Record.Item(COL_VERSION).Value = "" Then
        If RCVersiones.FocusedRow.Record.Item(COL_VERSION).Value = "" Then

            ObjError.SetMensaje("VERSIÓN no se puede dejar vacia")

            If ObjError.Control1 = "" Then
                ObjError.Control1 = "ReportControl"
                'ObjError.Pie1 = True
                ObjError.Foco1 = COL_VERSION
            End If

            HayErrores = True
        Else ' Columna tipo no se puede repetir
            If EnPie Then
                If ComprobarRepetidoVersion(RCVersiones.FocusedRow.Record.Item(COL_VERSION).Value, idProducto) = True Then
                    ObjError.SetMensaje("VERSIÓN no puede estar repetida")

                    If ObjError.Control1 = "" Then
                        ObjError.Control1 = "ReportControl"
                        'ObjError.Pie1 = True
                        ObjError.Foco1 = COL_VERSION
                    End If

                    HayErrores = True
                End If
            End If
        End If
        If (RCVersiones.FocusedRow.Record.Item(COL_ORDEN).Caption) = "" Then

            ObjError.SetMensaje("ORDEN no se puede dejar vacio")

            If ObjError.Control1 = "" Then
                ObjError.Control1 = "ReportControl"
                'ObjError.Pie1 = True
                ObjError.Foco1 = COL_ORDEN
            End If

            HayErrores = True
        End If
        If RCVersiones.FocusedRow.Record.Item(COL_ULTIMA).Caption = "" Then

            ObjError.SetMensaje("ÚLTIMA no se puede dejar vacio")

            If ObjError.Control1 = "" Then
                ObjError.Control1 = "ReportControl"
                'ObjError.Pie1 = True
                ObjError.Foco1 = COL_ULTIMA
            End If

            HayErrores = True
        End If
        If RCVersiones.FocusedRow.Record.Item(COL_PRECIO).Caption = "" Then

            ObjError.SetMensaje("PRECIO no se puede dejar vacio")

            If ObjError.Control1 = "" Then
                ObjError.Control1 = "ReportControl"
                'ObjError.Pie1 = True
                ObjError.Foco1 = COL_PRECIO
            End If

            HayErrores = True
        End If
        If RCVersiones.FocusedRow.Record.Item(COL_PRECIORED).Caption = "" Then

            ObjError.SetMensaje("PRECIO RED no se puede dejar vacio")

            If ObjError.Control1 = "" Then
                ObjError.Control1 = "ReportControl"
                'ObjError.Pie1 = True
                ObjError.Foco1 = COL_PRECIORED
            End If

            HayErrores = True
        End If

        If HayErrores = False Then
            'Además tengo que mirar si número de orden ya existe
            Dim MisVersiones As Long
            Dim ElOrden As Long
            ElOrden = RCVersiones.FocusedRow.Record.Item(COL_ORDEN).Value
            MisVersiones = 0
            While MisVersiones < RCVersiones.Records.Count
                If EnPie Then
                    If ElOrden = RCVersiones.Records.Record(MisVersiones).Item(COL_ORDEN).Value Then
                        ObjError.SetMensaje("ORDEN ya existe")
                        If ObjError.Control1 = "" Then
                            ObjError.Control1 = "ReportControl"
                            'ObjError.Pie1 = True
                            ObjError.Foco1 = COL_ORDEN
                        End If
                        HayErrores = True
                    End If
                Else
                    If RCVersiones.FocusedRow.Index <> RCVersiones.Records.Record(MisVersiones).Index Then
                        If ElOrden = RCVersiones.Records.Record(MisVersiones).Item(COL_ORDEN).Value Then
                            ObjError.SetMensaje("ORDEN ya existe")
                            If ObjError.Control1 = "" Then
                                ObjError.Control1 = "ReportControl"
                                'ObjError.Pie1 = True
                                ObjError.Foco1 = COL_ORDEN
                            End If
                            HayErrores = True
                        End If
                    End If
                End If
                MisVersiones = MisVersiones + 1
            End While

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
                RCVersiones.Navigator.CurrentFocusInFootersRows = True
            End If

            RCVersiones.Navigator.MoveToColumn(RCVersiones.Columns.Find(objError.Foco1).Index, False)
            RCVersiones.Navigator.BeginEdit()
        End If

    End Sub

    Private Sub FrmVersiones_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        fVersiones = Nothing

        MDIPrincipal.RibbonBar.RemoveTab(DEFMENU.GRUPO_MAESTROS_VERSIONES)
        'MDIPrincipal.RibbonBar.Reset()
        MDIPrincipal.RibbonBar.RedrawBar()
        MDIPrincipal.RibbonBar.RecalcLayout()

        MDIPrincipal.RibbonBar.FindTab(DEFMENU.TAB_MAESTROS).Selected = True
        MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_MAESTROS_VERSIONES).Visible = False

    End Sub

    Sub ConstruirMenu()

        If MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_MAESTROS_VERSIONES) Is Nothing Then 'si no existe lo creo
            TabPantalla = MDIPrincipal.RibbonBar.InsertTab(DEFMENU.GRUPO_MAESTROS_VERSIONES, "&Versiones")
            TabPantalla.Id = DEFMENU.GRUPO_MAESTROS_VERSIONES

            'GrupoPantalla = TabPrincipal.Groups.AddGroup("&MANTE", 1001)
            'GrupoPantalla.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.PRINCIPAL_MANTENIMIENTO, "Mantenimiento", False, False)
            GrupoPantalla = TabPantalla.Groups.AddGroup("&VERSIONES", DEFMENU.GRUPO_MAESTROS_VERSIONES)
            GrupoPantalla.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_VERSIONES_NUEVO, "Nuevo", False, False).IconId = 100
            GrupoPantalla.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_VERSIONES_ELIMINAR, "Eliminar", False, False).IconId = 101
            GrupoPantalla.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_VERSIONES_IMPRIMIR, "Imprimir", False, False).IconId = 102
            GrupoPantalla.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_VERSIONES_SALIR, "Salir", False, False).IconId = 103
        End If

        MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_MAESTROS_VERSIONES).Visible = True
        MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_MAESTROS_VERSIONES).Selected = True

    End Sub

    Private Sub FrmVersiones_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        ConstruirMenu()
        'CargarComboProductos()

    End Sub

    Sub Menu_Nuevo()
        Dim proximaColumna As Integer

        RCVersiones.Navigator.CurrentFocusInFootersRows = True
        proximaColumna = SiguienteColumnaEditable(RCVersiones, -1, True)
        RCVersiones.Navigator.MoveToColumn(proximaColumna)
        RCVersiones.Navigator.BeginEdit()
    End Sub

    Sub Menu_Eliminar()

        Dim ObjError As New Errores

        If RCVersiones.FocusedRow.Section.Index <> 1 Then Exit Sub

        If Permisos <> 2 Then
            ObjError.Pantalla1 = Me
            ObjError.Tipo1 = 1 'Avisos

            ObjError.Titulo = "Versiones"

            ObjError.SetMensaje("No dispone de Permiso para Eliminar Versiones")

            ObjError.Control1 = "ReportControl"
            ObjError.Pie1 = True
            ObjError.Foco1 = COL_VERSION

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

            ObjError.Titulo = "Versiones"

            ObjError.SetMensaje("Esta Versión tiene registros relacionados," & Chr(13) & "elimínelos antes.")

            ObjError.Control1 = "ReportControl"
            ObjError.Pie1 = True
            ObjError.Foco1 = COL_VERSION

            FrmError.ObjError = ObjError
            FrmError.ShowDialog()
            If FrmError.DialogResult = DialogResult.OK Then
                FrmError.Dispose()
                Exit Sub
            End If
        End If

        ObjError.Pantalla1 = Me
        ObjError.Tipo1 = 2 'Mensajes

        ObjError.Titulo = "Versiones"

        ObjError.SetMensaje("¿Desea eliminar la Versión seleccionada?")

        ObjError.Control1 = ""
        ObjError.Pie1 = True
        ObjError.Foco1 = COL_VERSION

        FrmError.ObjError = ObjError
        FrmError.ShowDialog()
        'ControlErrores(ObjError)

        If FrmError.DialogResult = DialogResult.Yes Then
            FrmError.Dispose()
            Dim E As ReportRow
            E = RCVersiones.FocusedRow
            Dim objVersion = New Version(E.Record.Item(COL_ID).Value, E.Record.Item(COL_VERSION).Value, E.Record.Item(COL_ORDEN).Value, E.Record.Item(COL_ULTIMA).Value, E.Record.Item(COL_PRECIO).Value, E.Record.Item(COL_PRECIORED).Value)
            EliminarVersion(objVersion)
            RCVersiones.RemoveRowEx(RCVersiones.FocusedRow)
        ElseIf FrmError.DialogResult = DialogResult.Cancel Then
            FrmError.Dispose()
        End If
    End Sub

    Function ComprobarRelaciones() As Boolean
        'Miro si hay algún registro relacionado en tabla Versiones
        ComprobarRelaciones = False
        'Dim E As ReportRow
        'E = RCProductos.FocusedRow
        'Dim objProducto = New Producto(E.Record.Item(COL_ID).Value, E.Record.Item(COL_CODIGO).Value, E.Record.Item(COL_DESCRIPCION).Value, E.Record.Item(COL_VERSIONES).Value, E.Record.Item(COL_MANTENIMIENTO).Value, E.Record.Item(COL_RED).Value, E.Record.Item(COL_TEMPORAL).Value, E.Record.Item(COL_PRECIO).Value, E.Record.Item(COL_PRECIORED).Value)
        'If objProducto.ArrayVersiones1.Count > 0 Then
        '    ComprobarRelaciones = True
        'End If

        'Habrá que mirar si tiene movimientos o está en packs o en productosclientes

    End Function

    Sub Menu_Imprimir()
        RCVersiones.PrintOptions.Header.TextCenter = Me.Titulo.Caption & "  -  " & cbProductos.Text
        RCVersiones.PrintOptions.Header.Font.Size = 18
        RCVersiones.PrintOptions.Header.Font.Bold = True
        'RCGrupos.PrintPreviewOptions.Title = Me.Titulo.Caption
        RCVersiones.PrintPreview(True)
    End Sub

    Private Sub cbProductos_ClickEvent(sender As Object, e As EventArgs) Handles cbProductos.ClickEvent

        If cbProductos.Text <> "" Then
            RCVersiones.Records.DeleteAll()
            idProducto = cbProductos.get_ItemData(cbProductos.ListIndex)
            Dim Record As ReportRecord
            'Dim x As Integer
            Dim objProductos As Producto
            Dim ArrayVersiones As New ArrayList()
            objProductos = BDProductos.ObtenerUnProducto(idProducto)
            ArrayVersiones = objProductos.ArrayVersiones1

            If Not IsNothing(ArrayVersiones) Then
                For Each ObjVersion In ArrayVersiones

                    Record = RCVersiones.Records.Add()

                    Record.AddItem(ObjVersion.Id1)
                    Record.AddItem(ObjVersion.Version1)
                    Record.AddItem(ObjVersion.Orden1)
                    Record.AddItem(ObjVersion.Ultima1)
                    Record.AddItem(ObjVersion.Precio1)
                    Record.AddItem(ObjVersion.PrecioRed1)
                    Record.AddItem("")

                    'If ObjVersion.GetObligatorio1 = True Then
                    '    For x = 0 To RCVersiones.Columns.Count - 1
                    '        Record.Item(x).Editable = False
                    '        Record.Item(x).Focusable = True
                    '    Next
                    'End If
                    Record.Item(COL_AÑADIR).Editable = False
                Next

                RCVersiones.Populate()
            End If

        End If

    End Sub

    Private Sub cbProductos_Change(sender As Object, e As EventArgs) Handles cbProductos.Change
        MsgBox("Change")
    End Sub

    Private Sub cbProductos_PaddingChanged(sender As Object, e As EventArgs) Handles cbProductos.PaddingChanged
        MsgBox("PaddingChanged")
    End Sub

End Class