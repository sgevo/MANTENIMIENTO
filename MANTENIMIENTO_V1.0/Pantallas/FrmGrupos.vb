Imports AxXtremeReportControl
Imports XtremeReportControl
Imports MantEvolution.DefinicionesMenus


Public Class FrmGrupos

    Const COL_ID = 0
    Const COL_DESCRIPCION = 1
    Const COL_AÑADIR = 2

    Public Permisos As Long

    Dim ArrayGrupos As New ArrayList()

    Dim HayErrores As Boolean

    Dim TabPantalla As XtremeCommandBars.RibbonTab = Nothing
    Dim GroupFile As XtremeCommandBars.RibbonGroup = Nothing

    Private Sub FrmGrupos_Load(sender As Object, e As EventArgs) Handles Me.Load

        With RCGrupos

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

        CargarGrupos()

        'Esta linea hace falta para que funcione el rc_beforedrawrow
        'Aunque el formato se puede poner directamente en la Clase del objeto, mejor
        'RCProductos.SetCustomDraw(XtremeReportControl.XTPReportCustomDraw.xtpCustomBeforeDrawRow)

        RCGrupos.Icons = MDIPrincipal.ImageManager.Icons

        fGrupos = Me

    End Sub

    Sub CargarGrupos()

        Dim Record As XtremeReportControl.ReportRecord
        Dim objGrupo As Grupo

        ArrayGrupos = ObtenerGrupos()

        For Each objGrupo In ArrayGrupos

            Record = RCGrupos.Records.Add()

            Record.AddItem(objGrupo.Id1)
            Record.AddItem(objGrupo.Descripcion1)

            Record.AddItem("") 'Añadir

        Next

        RCGrupos.Populate()

    End Sub

    Sub CargarColumnasReport()

        Dim FilaPie As ReportRecord

        RCGrupos.PaintManager.ColumnStyle = XTPReportColumnStyle.xtpColumnResource

        RCGrupos.AllowEdit = True

        RCGrupos.Columns.Add(COL_ID, "IdGrupo", 100, True)
        RCGrupos.Columns.Add(COL_DESCRIPCION, "Descripción", 250, True)
        RCGrupos.Columns.Add(COL_AÑADIR, "Añadir", 48, True)

        FilaPie = RCGrupos.FooterRecords.Add

        Dim x As Integer
        Dim item As ReportRecordItem

        For x = 0 To RCGrupos.Columns.Count - 1
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

        RCGrupos.PopulateFooterRows()
        RCGrupos.Populate()

        'Configuracion Final del report en cuanto a columnas
        RCGrupos.Columns.Find(COL_ID).Visible = False
        RCGrupos.Columns.Find(COL_DESCRIPCION).EditOptions.SelectTextOnEdit = True
        RCGrupos.Columns.Find(COL_DESCRIPCION).EditOptions.MaxLength = 50

    End Sub

    Private Sub FrmGrupos_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        ConfigurarPantalla()
    End Sub

    Sub ConfigurarPantalla()

        Titulo.Top = 0
        Titulo.Left = 0
        Titulo.Width = Me.Width

        RCGrupos.Left = 10
        RCGrupos.Width = Me.Width - 20

        RCGrupos.Top = Titulo.Height
        RCGrupos.Height = Me.Height - RCGrupos.Top - 20

    End Sub

    Public Sub AplicaEstilo()

        Dim X As Object

        For Each X In Me.Controls
            AplicaEstiloControl(X)
        Next X

    End Sub

    Sub AñadirLineaReport(objGrupo As Grupo)

        Dim registro As ReportRecord

        registro = RCGrupos.Records.Add()

        registro.AddItem(objGrupo.Id1)
        registro.AddItem(objGrupo.Descripcion1)
        registro.AddItem("")

        registro.Item(COL_AÑADIR).Editable = False
        RCGrupos.Populate()

    End Sub

    Sub Subirlinea()

        'Dim objGrupo = New Producto(RCProductos.FooterRows(0).Record.Item(COL_ID).Value, RCProductos.FooterRows(0).Record.Item(COL_CODIGO).Value, RCProductos.FooterRows(0).Record.Item(COL_DESCRIPCION).Value, RCProductos.FooterRows(0).Record.Item(COL_VERSIONES).Value, RCProductos.FooterRows(0).Record.Item(COL_MANTENIMIENTO).Value, RCProductos.FooterRows(0).Record.Item(COL_RED).Value, RCProductos.FooterRows(0).Record.Item(COL_TEMPORAL).Value, RCProductos.FooterRows(0).Record.Item(COL_PRECIO).Value, RCProductos.FooterRows(0).Record.Item(COL_PRECIORED).Value)
        'Como es un registro nuevo, el campo Id=0
        Dim objGrupo = New Grupo(0, RCGrupos.FooterRows(0).Record.Item(COL_DESCRIPCION).Value)

        Dim proximaColumna As Integer

        GuardarGrupo(objGrupo)

        AñadirLineaReport(objGrupo)

        BorraPie()
        RCGrupos.Navigator.CurrentFocusInFootersRows = True

        proximaColumna = SiguienteColumnaEditable(RCGrupos, -1, True)

        RCGrupos.Navigator.MoveToColumn(proximaColumna)

    End Sub

    Sub BorraPie()
        RCGrupos.FooterRows(0).Record.Item(COL_ID).Value = ""
        RCGrupos.FooterRows(0).Record.Item(COL_DESCRIPCION).Value = ""
    End Sub

    Private Sub RCGrupos_ItemButtonClick() Handles RCGrupos.ItemButtonClick

        Dim MiRow As ReportRow
        Dim ObjError As New Errores

        MiRow = RCGrupos.FocusedRow

        If Permisos <> 2 Then
            ObjError.Pantalla1 = Me
            ObjError.Tipo1 = 1 'Avisos

            ObjError.Titulo = "Grupos"

            ObjError.SetMensaje("No dispone de Permiso para Actualizar Grupos")

            ObjError.Control1 = "ReportControl"
            ObjError.Pie1 = True
            ObjError.Foco1 = COL_DESCRIPCION

            FrmError.ObjError = ObjError
            FrmError.ShowDialog()
            If FrmError.DialogResult = DialogResult.OK Then
                FrmError.Dispose()
                Exit Sub
            End If
        End If

        If RCGrupos.FocusedRow.Section.Index = 1 Then 'Lineas de Detalle
            If Comprobaciones(False) = False Then
                Dim objGrupo = New Grupo(MiRow.Record.Item(COL_ID).Value, MiRow.Record.Item(COL_DESCRIPCION).Value)
                ModificarGrupo(objGrupo)

                ObjError.Pantalla1 = Me
                ObjError.Tipo1 = 3 'Avisos

                ObjError.Titulo = "Grupos"

                ObjError.SetMensaje("Grupo actualizado")

                ObjError.Control1 = "ReportControl"
                ObjError.Pie1 = False
                ObjError.Foco1 = COL_DESCRIPCION

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
        If RCGrupos.FocusedRow.Record.Item(COL_DESCRIPCION).Caption = "" Then

            ObjError.SetMensaje("DESCRIPCIÓN no se puede dejar vacia")

            If ObjError.Control1 = "" Then
                ObjError.Control1 = "ReportControl"
                'ObjError.Pie1 = True
                ObjError.Foco1 = COL_DESCRIPCION
            End If

            HayErrores = True
        Else ' Columna tipo no se puede repetir
            If EnPie Then
                If ComprobarRepetidoGrupo(RCGrupos.FocusedRow.Record.Item(COL_DESCRIPCION).Value) = True Then
                    ObjError.SetMensaje("DESCRIPCIÓN no puede estar repetida")

                    If ObjError.Control1 = "" Then
                        ObjError.Control1 = "ReportControl"
                        'ObjError.Pie1 = True
                        ObjError.Foco1 = COL_DESCRIPCION
                    End If

                    HayErrores = True
                End If
            End If
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
                RCGrupos.Navigator.CurrentFocusInFootersRows = True
            End If

            RCGrupos.Navigator.MoveToColumn(RCGrupos.Columns.Find(objError.Foco1).Index, False)
            RCGrupos.Navigator.BeginEdit()
        End If

    End Sub

    Private Sub RCGruposs_PreviewKeyDownEvent(sender As Object, e As _DReportControlEvents_PreviewKeyDownEvent) Handles RCGrupos.PreviewKeyDownEvent
        Dim proximaColumna As Integer
        Dim esPies As Boolean

        esPies = False

        Select Case e.keyCode
            Case 13 'Enter

                If RCGrupos.FocusedRow.Section.Index = 2 Then
                    esPies = True
                End If

                proximaColumna = SiguienteColumnaEditable(RCGrupos, RCGrupos.FocusedColumn.Index, esPies)

                ' RCProductos.Populate()
                If esPies = True Then
                    RCGrupos.Navigator.CurrentFocusInFootersRows = True
                End If

                RCGrupos.Navigator.MoveToColumn(proximaColumna, False)

                RCGrupos.Navigator.BeginEdit()

                If RCGrupos.Columns(proximaColumna).ItemIndex = COL_AÑADIR Then
                    '   RCProductos.FooterRows(0).Record.Item(COL_AÑADIR)
                    RCGrupos_ItemButtonClick()
                End If

            Case 9 'Tab
                If e.shift = 1 Then
                    If RCGrupos.FocusedRow.Section.Index = 2 Then
                        esPies = True
                    End If

                    proximaColumna = AnteriorColumnaEditable(RCGrupos, RCGrupos.FocusedColumn.Index, esPies)

                    RCGrupos.Populate()
                    If esPies = True Then
                        RCGrupos.Navigator.CurrentFocusInFootersRows = True
                    End If

                    RCGrupos.Navigator.MoveToColumn(proximaColumna, False)

                    RCGrupos.Navigator.BeginEdit()

                    e.cancel = True
                Else
                    If RCGrupos.FocusedRow.Section.Index = 2 Then
                        esPies = True
                    End If

                    proximaColumna = SiguienteColumnaEditable(RCGrupos, RCGrupos.FocusedColumn.Index, esPies)

                    RCGrupos.Populate()
                    If esPies = True Then
                        RCGrupos.Navigator.CurrentFocusInFootersRows = True
                    End If

                    RCGrupos.Navigator.MoveToColumn(proximaColumna, False)

                    RCGrupos.Navigator.BeginEdit()
                    e.cancel = True
                End If

            Case 16
                e.cancel = True

            Case 38
                RCGrupos.Populate()
                RCGrupos.Navigator.MoveUp()
                RCGrupos.Navigator.BeginEdit()
                e.cancel = True

            Case 40
                RCGrupos.Populate()
                RCGrupos.Navigator.MoveDown()
                RCGrupos.Navigator.BeginEdit()
                e.cancel = True

        End Select

        If Not RCGrupos.FocusedColumn Is Nothing Then
            Select Case RCGrupos.FocusedColumn.ItemIndex
                'Case COL_PRECIO, COL_PRECIORED
                '    If e.keyCode = 110 Then e.keyCode = 188 '(si pulsa la tecla del punto en el teclado númerico, lo cambio por la coma)
                '    If e.keyCode = 190 Then e.keyCode = 188 '(si pulsa la tecla del punto del teclado normal, lo cambio por la coma)

            End Select
        End If

    End Sub

    Private Sub RCGrupos_ValueChanging(sender As Object, e As _DReportControlEvents_ValueChangingEvent) Handles RCGrupos.ValueChanging

        Dim ObjError As New Errores

        HayErrores = False
        ObjError.Pantalla1 = Me
        ObjError.Tipo1 = 1 'Alertas

        'Select Case e.column.ItemIndex
        '    Case COL_PRECIO
        '        e.newValue = Format(CDbl(e.newValue), FormatoImporte)

        '    Case COL_PRECIORED
        '        e.newValue = Format(CDbl(e.newValue), FormatoImporte)

        'End Select

        If e.row.Section.Index = 1 Then
            Select Case e.column.ItemIndex

                Case COL_DESCRIPCION
                    If e.newValue = "" Then
                        ObjError.SetMensaje("Descripción no se puede dejar vacia")
                        ObjError.Control1 = "ReportControl"
                        ObjError.Pie1 = True
                        ObjError.Foco1 = COL_DESCRIPCION

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

    Private Sub FrmGrupos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        fGrupos = Nothing

        MDIPrincipal.RibbonBar.RemoveTab(DEFMENU.GRUPO_MAESTROS_GRUPOS)
        'MDIPrincipal.RibbonBar.Reset()
        MDIPrincipal.RibbonBar.RedrawBar()
        MDIPrincipal.RibbonBar.RecalcLayout()

        MDIPrincipal.RibbonBar.FindTab(DEFMENU.TAB_MAESTROS).Selected = True
        MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_MAESTROS_GRUPOS).Visible = False

    End Sub

    Sub ConstruirMenu()

        If MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_MAESTROS_GRUPOS) Is Nothing Then 'si no existe lo creo
            TabPantalla = MDIPrincipal.RibbonBar.InsertTab(DEFMENU.GRUPO_MAESTROS_GRUPOS, "&Grupos")
            TabPantalla.Id = DEFMENU.GRUPO_MAESTROS_GRUPOS

            'GroupFile = TabPrincipal.Groups.AddGroup("&MANTE", 1001)
            'GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.PRINCIPAL_MANTENIMIENTO, "Mantenimiento", False, False)
            GroupFile = TabPantalla.Groups.AddGroup("&GRUPOS", DEFMENU.GRUPO_MAESTROS_GRUPOS)
            GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_GRUPOS_NUEVO, "Nuevo", False, False).IconId = 100
            GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_GRUPOS_ELIMINAR, "Eliminar", False, False).IconId = 101
            GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_GRUPOS_IMPRIMIR, "Imprimir", False, False).IconId = 102
            GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_GRUPOS_SALIR, "Salir", False, False).IconId = 103
        End If

        MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_MAESTROS_GRUPOS).Visible = True
        MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_MAESTROS_GRUPOS).Selected = True

    End Sub

    Private Sub FrmGrupos_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        ConstruirMenu()
    End Sub

    Sub Menu_Nuevo()
        Dim proximaColumna As Integer

        RCGrupos.Navigator.CurrentFocusInFootersRows = True
        proximaColumna = SiguienteColumnaEditable(RCGrupos, -1, True)
        RCGrupos.Navigator.MoveToColumn(proximaColumna)
        RCGrupos.Navigator.BeginEdit()
    End Sub

    Sub Menu_Eliminar()

        Dim ObjError As New Errores

        If RCGrupos.FocusedRow.Section.Index <> 1 Then Exit Sub

        If Permisos <> 2 Then
            ObjError.Pantalla1 = Me
            ObjError.Tipo1 = 1 'Avisos

            ObjError.Titulo = "Grupos"

            ObjError.SetMensaje("No dispone de Permiso para Eliminar Grupos")

            ObjError.Control1 = "ReportControl"
            ObjError.Pie1 = True
            ObjError.Foco1 = COL_DESCRIPCION

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

            ObjError.Titulo = "Grupos"

            ObjError.SetMensaje("Este Grupo tiene registros relacionados," & Chr(13) & "elimínelos antes.")

            ObjError.Control1 = "ReportControl"
            ObjError.Pie1 = True
            ObjError.Foco1 = COL_DESCRIPCION

            FrmError.ObjError = ObjError
            FrmError.ShowDialog()
            If FrmError.DialogResult = DialogResult.OK Then
                FrmError.Dispose()
                Exit Sub
            End If
        End If

        ObjError.Pantalla1 = Me
        ObjError.Tipo1 = 2 'Mensajes

        ObjError.Titulo = "Grupos"

        ObjError.SetMensaje("¿Desea eliminar el Grupo seleccionado?")

        ObjError.Control1 = ""
        ObjError.Pie1 = True
        ObjError.Foco1 = COL_DESCRIPCION

        FrmError.ObjError = ObjError
        FrmError.ShowDialog()
        'ControlErrores(ObjError)

        If FrmError.DialogResult = DialogResult.Yes Then
            FrmError.Dispose()
            Dim E As ReportRow
            E = RCGrupos.FocusedRow
            Dim objGrupo = New Grupo(E.Record.Item(COL_ID).Value, E.Record.Item(COL_DESCRIPCION).Value)
            EliminarGrupo(objGrupo)
            RCGrupos.RemoveRowEx(RCGrupos.FocusedRow)
        ElseIf FrmError.DialogResult = DialogResult.Cancel Then
            FrmError.Dispose()
        End If
    End Sub

    Sub Menu_Imprimir()
        RCGrupos.PrintOptions.Header.TextCenter = Me.Titulo.Caption
        RCGrupos.PrintOptions.Header.Font.Size = 18
        RCGrupos.PrintOptions.Header.Font.Bold = True
        'RCGrupos.PrintPreviewOptions.Title = Me.Titulo.Caption
        RCGrupos.PrintPreview(True)
    End Sub

    Function ComprobarRelaciones() As Boolean
        'Miro si hay algún registro relacionado en tabla Versiones
        ComprobarRelaciones = False
        Dim E As ReportRow
        E = RCGrupos.FocusedRow
        Dim objGrupo = New Grupo(E.Record.Item(COL_ID).Value, E.Record.Item(COL_DESCRIPCION).Value)
        If objGrupo.ArrayUsuarios1.Count > 0 Then
            ComprobarRelaciones = True
        End If

        'También habrá que mirar si tiene movimientos o está en packs o en productosclientes

    End Function

    Private Sub RCGrupos_InplaceEditChanging(sender As Object, e As _DReportControlEvents_InplaceEditChangingEvent) Handles RCGrupos.InplaceEditChanging
        'Select Case e.column.ItemIndex
        '    Case COL_PRECIO, COL_PRECIORED

        '        If Len(e.newValue) > 0 Then
        '            If e.newValue <> "-" Then
        '                e.cancel = Not IsNumeric(e.newValue)
        '            End If
        '        End If

        'End Select
    End Sub

    Private Sub RCGrupos_GotFocus(sender As Object, e As EventArgs) Handles RCGrupos.GotFocus
        Dim MiItem As XtremeReportControl.ReportRecordItem

        If RCGrupos.Records.Count = 0 Then Exit Sub

        MiItem = RCGrupos.FocusedRow.Record.Item(COL_AÑADIR)
        MiItem.ItemControls.AddButton(0)
        MiItem.ItemControls(0).SetSize(48, 48)
        MiItem.ItemControls(0).Themed = True
        MiItem.ItemControls(0).SetIconIndex(0, 2)
        MiItem.Alignment = XTPColumnAlignment.xtpAlignmentCenter
    End Sub

    Private Sub RCGrupos_FocusChanging(sender As Object, e As _DReportControlEvents_FocusChangingEvent) Handles RCGrupos.FocusChanging
        Dim X As Long
        For X = 0 To RCGrupos.Rows.Count - 1
            RCGrupos.Rows(X).Record.Item(COL_AÑADIR).ItemControls.RemoveAll()
        Next X

        RCGrupos.FooterRows(0).Record.Item(COL_AÑADIR).ItemControls.RemoveAll()

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
End Class