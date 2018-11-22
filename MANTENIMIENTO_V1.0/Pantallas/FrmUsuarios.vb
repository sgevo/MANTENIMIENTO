Imports AxXtremeReportControl
Imports XtremeReportControl
Imports MantEvolution.DefinicionesMenus


Public Class FrmUsuarios

    Const COL_ID = 0
    Const COL_NOMBRE = 1
    Const COL_CONTRASEÑA = 2
    Const COL_AÑADIR = 3

    Public Permisos As Long

    Dim ArrayGrupos As New ArrayList()

    Dim HayErrores As Boolean

    Dim idGrupo As Long

    Dim TabPantalla As XtremeCommandBars.RibbonTab = Nothing
    Dim GrupoPantalla As XtremeCommandBars.RibbonGroup = Nothing

    Private Sub FrmVersiones_Load(sender As Object, e As EventArgs) Handles Me.Load

        cbGrupos.ReCreateReparented = True 'Esto es necesario porque si no los eventos no van

        With RCUsuarios

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

        'CargarComboGrupos()

        RCUsuarios.Icons = MDIPrincipal.ImageManager.Icons

        fUsuarios = Me

    End Sub

    Public Sub CargarComboGrupos()

        BDGrupos.GetGrupoUsuario(cbGrupos)
        If cbGrupos.ListCount > 0 Then
            cbGrupos.ListIndex = 0
        Else
            cbGrupos.ListIndex = -1
        End If

    End Sub

    Sub CargarColumnasReport()

        Dim FilaPie As ReportRecord

        RCUsuarios.PaintManager.ColumnStyle = XTPReportColumnStyle.xtpColumnResource

        RCUsuarios.AllowEdit = True

        RCUsuarios.Columns.Add(COL_ID, "Id", 100, True)
        RCUsuarios.Columns.Add(COL_NOMBRE, "Nombre", 200, True)
        RCUsuarios.Columns.Add(COL_CONTRASEÑA, "Contraseña", 100, True)

        RCUsuarios.Columns.Add(COL_AÑADIR, "Editar", 48, True)

        FilaPie = RCUsuarios.FooterRecords.Add

        Dim x As Integer
        Dim item As ReportRecordItem

        For x = 0 To RCUsuarios.Columns.Count - 1
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

        RCUsuarios.PopulateFooterRows()
        RCUsuarios.Populate()

        'Configuracion Final del report en cuanto a columnas
        RCUsuarios.Columns.Find(COL_ID).Visible = False
        'RCUsuarios.Columns.Find(COL_VERSION).Alignment = XTPColumnAlignment.xtpAlignmentCenter
        'RCUsuarios.Columns.Find(COL_ULTIMA).Alignment = XTPColumnAlignment.xtpAlignmentCenter
        'RCUsuarios.Columns.Find(COL_ORDEN).Alignment = XTPColumnAlignment.xtpAlignmentCenter
        'RCUsuarios.Columns.Find(COL_PRECIO).Alignment = XTPColumnAlignment.xtpAlignmentRight
        'RCUsuarios.Columns.Find(COL_PRECIORED).Alignment = XTPColumnAlignment.xtpAlignmentRight

        RCUsuarios.Columns.Find(COL_NOMBRE).EditOptions.SelectTextOnEdit = True
        RCUsuarios.Columns.Find(COL_NOMBRE).EditOptions.MaxLength = 100
        RCUsuarios.Columns.Find(COL_CONTRASEÑA).EditOptions.SelectTextOnEdit = True
        RCUsuarios.Columns.Find(COL_CONTRASEÑA).EditOptions.MaxLength = 50

    End Sub

    Private Sub RCUsuarios_GotFocus(sender As Object, e As EventArgs) Handles RCUsuarios.GotFocus

        Dim MiItem As XtremeReportControl.ReportRecordItem

        If RCUsuarios.Records.Count = 0 Then Exit Sub

        MiItem = RCUsuarios.FocusedRow.Record.Item(COL_AÑADIR)
        MiItem.ItemControls.AddButton(0)
        MiItem.ItemControls(0).SetSize(48, 48)
        MiItem.ItemControls(0).Themed = True
        MiItem.ItemControls(0).SetIconIndex(0, 2)
        MiItem.Alignment = XTPColumnAlignment.xtpAlignmentCenter

    End Sub

    Private Sub RCUsuarios_FocusChanging(sender As Object, e As _DReportControlEvents_FocusChangingEvent) Handles RCUsuarios.FocusChanging

        Dim X As Long
        For X = 0 To RCUsuarios.Rows.Count - 1
            RCUsuarios.Rows(X).Record.Item(COL_AÑADIR).ItemControls.RemoveAll()
        Next X

        RCUsuarios.FooterRows(0).Record.Item(COL_AÑADIR).ItemControls.RemoveAll()

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

    Private Sub RCUsuarios_ItemButtonClick() Handles RCUsuarios.ItemButtonClick

        Dim MiRow As ReportRow
        Dim ObjError As New Errores

        MiRow = RCUsuarios.FocusedRow

        If Permisos <> 2 Then
            ObjError.Pantalla1 = Me
            ObjError.Tipo1 = 1 'Avisos

            ObjError.Titulo = "Usuarios"

            ObjError.SetMensaje("No dispone de Permiso para Actualizar Usuarios")

            ObjError.Control1 = "ReportControl"
            ObjError.Pie1 = True
            ObjError.Foco1 = COL_NOMBRE

            FrmError.ObjError = ObjError
            FrmError.ShowDialog()
            If FrmError.DialogResult = DialogResult.OK Then
                FrmError.Dispose()
                Exit Sub
            End If
        End If

        If RCUsuarios.FocusedRow.Section.Index = 1 Then 'Lineas de Detalle
            If Comprobaciones(False) = False Then
                Dim objUsuario = New Usuario(MiRow.Record.Item(COL_ID).Value, MiRow.Record.Item(COL_NOMBRE).Value, MiRow.Record.Item(COL_CONTRASEÑA).Value)
                ModificarUsuario(objUsuario)

                ObjError.Pantalla1 = Me
                ObjError.Tipo1 = 3 'Avisos
                ObjError.Titulo = "Usuarios"
                ObjError.SetMensaje("Usuario actualizado")
                ObjError.Control1 = "ReportControl"
                ObjError.Pie1 = False
                ObjError.Foco1 = COL_NOMBRE

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

    Private Sub RCUsuarios_PreviewKeyDownEvent(sender As Object, e As _DReportControlEvents_PreviewKeyDownEvent) Handles RCUsuarios.PreviewKeyDownEvent
        Dim proximaColumna As Integer
        Dim esPies As Boolean

        esPies = False

        Select Case e.keyCode
            Case 13 'Enter

                If RCUsuarios.FocusedRow.Section.Index = 2 Then
                    esPies = True
                End If

                proximaColumna = SiguienteColumnaEditable(RCUsuarios, RCUsuarios.FocusedColumn.Index, esPies)

                ' RCUsuarios.Populate()
                If esPies = True Then
                    RCUsuarios.Navigator.CurrentFocusInFootersRows = True
                End If

                RCUsuarios.Navigator.MoveToColumn(proximaColumna, False)

                RCUsuarios.Navigator.BeginEdit()

                If RCUsuarios.Columns(proximaColumna).ItemIndex = COL_AÑADIR Then
                    '   RCUsuarios.FooterRows(0).Record.Item(COL_AÑADIR)
                    RCUsuarios_ItemButtonClick()
                End If

            Case 9 'Tab
                If e.shift = 1 Then
                    If RCUsuarios.FocusedRow.Section.Index = 2 Then
                        esPies = True
                    End If

                    proximaColumna = AnteriorColumnaEditable(RCUsuarios, RCUsuarios.FocusedColumn.Index, esPies)

                    RCUsuarios.Populate()
                    If esPies = True Then
                        RCUsuarios.Navigator.CurrentFocusInFootersRows = True
                    End If

                    RCUsuarios.Navigator.MoveToColumn(proximaColumna, False)

                    RCUsuarios.Navigator.BeginEdit()

                    e.cancel = True
                Else
                    If RCUsuarios.FocusedRow.Section.Index = 2 Then
                        esPies = True
                    End If

                    proximaColumna = SiguienteColumnaEditable(RCUsuarios, RCUsuarios.FocusedColumn.Index, esPies)

                    RCUsuarios.Populate()
                    If esPies = True Then
                        RCUsuarios.Navigator.CurrentFocusInFootersRows = True
                    End If

                    RCUsuarios.Navigator.MoveToColumn(proximaColumna, False)

                    RCUsuarios.Navigator.BeginEdit()
                    e.cancel = True
                End If

            Case 16
                e.cancel = True

            Case 38
                RCUsuarios.Populate()
                RCUsuarios.Navigator.MoveUp()
                RCUsuarios.Navigator.BeginEdit()
                e.cancel = True

            Case 40
                RCUsuarios.Populate()
                RCUsuarios.Navigator.MoveDown()
                RCUsuarios.Navigator.BeginEdit()
                e.cancel = True

        End Select

        If Not RCUsuarios.FocusedColumn Is Nothing Then
            Select Case RCUsuarios.FocusedColumn.ItemIndex
                'Case COL_PRECIO, COL_PRECIORED
                '    If e.keyCode = 110 Then e.keyCode = 188 '(si pulsa la tecla del punto en el teclado númerico, lo cambio por la coma)
                '    If e.keyCode = 190 Then e.keyCode = 188 '(si pulsa la tecla del punto del teclado normal, lo cambio por la coma)

            End Select
        End If

    End Sub

    Private Sub RCUsuarios_ValueChanging(sender As Object, e As _DReportControlEvents_ValueChangingEvent) Handles RCUsuarios.ValueChanging

        Dim ObjError As New Errores

        'Select Case e.column.ItemIndex
        '    Case COL_PRECIO
        '        e.newValue = Format(CDbl(e.newValue), FormatoImporte)
        '    Case COL_PRECIORED
        '        e.newValue = Format(CDbl(e.newValue), FormatoImporte)
        'End Select

        HayErrores = False
        ObjError.Pantalla1 = Me
        ObjError.Tipo1 = 1 'Alertas

        If e.row.Section.Index = 1 Then
            Select Case e.column.ItemIndex
                Case COL_NOMBRE
                    If e.newValue = "" Then
                        ObjError.SetMensaje("Nombre no se puede dejar vacio")
                        ObjError.Control1 = "ReportControl"
                        ObjError.Pie1 = True
                        ObjError.Foco1 = COL_NOMBRE
                        HayErrores = True
                        'Else
                        '    If ComprobarRepetidoUsuario(e.newValue) = True Then
                        '        ObjError.SetMensaje("Nombre no puede estar repetido")
                        '        ObjError.Control1 = "ReportControl"
                        '        ObjError.Pie1 = True
                        '        ObjError.Foco1 = COL_NOMBRE
                        '        HayErrores = True
                        '    End If
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

    Private Sub RCUsuarios_InplaceEditChanging(sender As Object, e As _DReportControlEvents_InplaceEditChangingEvent) Handles RCUsuarios.InplaceEditChanging
        'Select Case e.column.ItemIndex
        '    Case COL_PRECIO, COL_PRECIORED, COL_ORDEN

        '        If Len(e.newValue) > 0 Then
        '            If e.newValue <> "-" Then
        '                e.cancel = Not IsNumeric(e.newValue)
        '            End If
        '        End If
        'End Select
    End Sub

    Private Sub FrmProductos_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        ConfigurarPantalla()
    End Sub

    Sub ConfigurarPantalla()

        Titulo.Top = 0
        Titulo.Left = 0
        Titulo.Width = Me.Width

        lblGrupos.Left = 10
        lblGrupos.Top = Titulo.Height + 10

        cbGrupos.Left = 10
        cbGrupos.Top = Titulo.Height + lblGrupos.Height + 10

        RCUsuarios.Left = cbGrupos.Left + cbGrupos.Width + 10
        RCUsuarios.Width = Me.Width - cbGrupos.Width - 30

        RCUsuarios.Top = Titulo.Height
        RCUsuarios.Height = Me.Height - RCUsuarios.Top - 20

    End Sub

    Public Sub AplicaEstilo()

        Dim X As Object

        For Each X In Me.Controls
            AplicaEstiloControl(X)
        Next X

    End Sub

    Sub AñadirLineaReport(objUsuario As Usuario)

        Dim registro As ReportRecord

        registro = RCUsuarios.Records.Add()

        registro.AddItem(objUsuario.Id1)
        registro.AddItem(objUsuario.Nombre1)
        registro.AddItem(objUsuario.Contraseña1)
        registro.AddItem("")

        registro.Item(COL_AÑADIR).Editable = False
        RCUsuarios.Populate()

    End Sub

    Sub Subirlinea()

        '        Dim objProducto = New Producto(RCUsuarios.FooterRows(0).Record.Item(COL_ID).Value, RCUsuarios.FooterRows(0).Record.Item(COL_CODIGO).Value, RCUsuarios.FooterRows(0).Record.Item(COL_DESCRIPCION).Value, RCUsuarios.FooterRows(0).Record.Item(COL_VERSIONES).Value, RCUsuarios.FooterRows(0).Record.Item(COL_MANTENIMIENTO).Value, RCUsuarios.FooterRows(0).Record.Item(COL_RED).Value, RCUsuarios.FooterRows(0).Record.Item(COL_TEMPORAL).Value, RCUsuarios.FooterRows(0).Record.Item(COL_PRECIO).Value, RCUsuarios.FooterRows(0).Record.Item(COL_PRECIORED).Value)
        'Como es un registro nuevo, el campo Id=0
        Dim objUsuario = New Usuario(idGrupo, RCUsuarios.FooterRows(0).Record.Item(COL_NOMBRE).Value, RCUsuarios.FooterRows(0).Record.Item(COL_CONTRASEÑA).Value, ObtenerUnGrupo(idGrupo))

        Dim proximaColumna As Integer

        Dim ObjError As New Errores
        If Permisos <> 2 Then
            ObjError.Pantalla1 = Me
            ObjError.Tipo1 = 1 'Avisos

            ObjError.Titulo = "Usuarios"

            ObjError.SetMensaje("No dispone de Permiso para Crear Usuarios")

            ObjError.Control1 = "ReportControl"
            ObjError.Pie1 = True
            ObjError.Foco1 = COL_NOMBRE

            FrmError.ObjError = ObjError
            FrmError.ShowDialog()
            If FrmError.DialogResult = DialogResult.OK Then
                FrmError.Dispose()
                Exit Sub
            End If
        End If

        GuardarUsuario(objUsuario)

        AñadirLineaReport(objUsuario)

        ''Si es última entonces cambio todas las demás versiones a N
        'Dim MisVersiones As Long
        'If RCUsuarios.FooterRows(0).Record.Item(COL_ULTIMA).Value = -1 Then
        '    MisVersiones = 0
        '    While MisVersiones < RCUsuarios.Records.Count - 1
        '        If RCUsuarios.Records.Record(MisVersiones).Item(COL_ULTIMA).Value = True Then
        '            RCUsuarios.Records.Record(MisVersiones).Item(COL_ULTIMA).Value = False
        '            Dim objVersion2 = New Usuario(RCUsuarios.Records.Record(MisVersiones).Item(COL_ID).Value, RCUsuarios.Records.Record(MisVersiones).Item(COL_VERSION).Value, RCUsuarios.Records.Record(MisVersiones).Item(COL_ORDEN).Value, RCUsuarios.Records.Record(MisVersiones).Item(COL_ULTIMA).Value, RCUsuarios.Records.Record(MisVersiones).Item(COL_PRECIO).Value, RCUsuarios.Records.Record(MisVersiones).Item(COL_PRECIORED).Value)
        '            ModificarVersion(objVersion2)
        '        End If
        '        MisVersiones = MisVersiones + 1
        '    End While
        'End If

        BorraPie()

        RCUsuarios.Navigator.CurrentFocusInFootersRows = True

        proximaColumna = SiguienteColumnaEditable(RCUsuarios, -1, True)

        RCUsuarios.Navigator.MoveToColumn(proximaColumna)

    End Sub

    Sub BorraPie()
        RCUsuarios.FooterRows(0).Record.Item(COL_ID).Value = ""
        RCUsuarios.FooterRows(0).Record.Item(COL_NOMBRE).Value = ""
        RCUsuarios.FooterRows(0).Record.Item(COL_CONTRASEÑA).Value = ""
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
        'If RCUsuarios.FooterRows(0).Record.Item(COL_VERSION).Value = "" Then
        If RCUsuarios.FocusedRow.Record.Item(COL_NOMBRE).Value = "" Then

            ObjError.SetMensaje("NOMBRE no se puede dejar vacio")

            If ObjError.Control1 = "" Then
                ObjError.Control1 = "ReportControl"
                'ObjError.Pie1 = True
                ObjError.Foco1 = COL_NOMBRE
            End If

            HayErrores = True
        Else ' Columna tipo no se puede repetir
            If EnPie Then
                If ComprobarRepetidoUsuario(RCUsuarios.FocusedRow.Record.Item(COL_NOMBRE).Value) = True Then
                    ObjError.SetMensaje("NOMBRE no puede estar repetido")

                    If ObjError.Control1 = "" Then
                        ObjError.Control1 = "ReportControl"
                        'ObjError.Pie1 = True
                        ObjError.Foco1 = COL_NOMBRE
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
                RCUsuarios.Navigator.CurrentFocusInFootersRows = True
            End If

            RCUsuarios.Navigator.MoveToColumn(RCUsuarios.Columns.Find(objError.Foco1).Index, False)
            RCUsuarios.Navigator.BeginEdit()
        End If

    End Sub

    Private Sub FrmUsuarios_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        fUsuarios = Nothing

        MDIPrincipal.RibbonBar.RemoveTab(DEFMENU.GRUPO_MAESTROS_USUARIOS)
        'MDIPrincipal.RibbonBar.Reset()
        MDIPrincipal.RibbonBar.RedrawBar()
        MDIPrincipal.RibbonBar.RecalcLayout()

        MDIPrincipal.RibbonBar.FindTab(DEFMENU.TAB_MAESTROS).Selected = True
        MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_MAESTROS_USUARIOS).Visible = False

    End Sub

    Sub ConstruirMenu()

        If MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_MAESTROS_USUARIOS) Is Nothing Then 'si no existe lo creo
            TabPantalla = MDIPrincipal.RibbonBar.InsertTab(DEFMENU.GRUPO_MAESTROS_USUARIOS, "&Usuarios")
            TabPantalla.Id = DEFMENU.GRUPO_MAESTROS_USUARIOS

            'GrupoPantalla = TabPrincipal.Groups.AddGroup("&MANTE", 1001)
            'GrupoPantalla.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.PRINCIPAL_MANTENIMIENTO, "Mantenimiento", False, False)
            GrupoPantalla = TabPantalla.Groups.AddGroup("&USUARIOS", DEFMENU.GRUPO_MAESTROS_USUARIOS)
            GrupoPantalla.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_USUARIOS_NUEVO, "Nuevo", False, False).IconId = 100
            GrupoPantalla.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_USUARIOS_ELIMINAR, "Eliminar", False, False).IconId = 101
            GrupoPantalla.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_USUARIOS_IMPRIMIR, "Imprimir", False, False).IconId = 102
            GrupoPantalla.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_USUARIOS_SALIR, "Salir", False, False).IconId = 103
        End If

        MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_MAESTROS_USUARIOS).Visible = True
        MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_MAESTROS_USUARIOS).Selected = True

    End Sub

    Private Sub FrmUsuarios_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        ConstruirMenu()
    End Sub

    Sub Menu_Nuevo()
        Dim proximaColumna As Integer

        RCUsuarios.Navigator.CurrentFocusInFootersRows = True
        proximaColumna = SiguienteColumnaEditable(RCUsuarios, -1, True)
        RCUsuarios.Navigator.MoveToColumn(proximaColumna)
        RCUsuarios.Navigator.BeginEdit()
    End Sub

    Sub Menu_Eliminar()

        Dim ObjError As New Errores

        If RCUsuarios.FocusedRow.Section.Index <> 1 Then Exit Sub

        If Permisos <> 2 Then
            ObjError.Pantalla1 = Me
            ObjError.Tipo1 = 1 'Avisos

            ObjError.Titulo = "Usuarios"

            ObjError.SetMensaje("No dispone de Permiso para Eliminar Usuarios")

            ObjError.Control1 = "ReportControl"
            ObjError.Pie1 = True
            ObjError.Foco1 = COL_NOMBRE

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

            ObjError.Titulo = "Usuarios"

            ObjError.SetMensaje("Este Usuario tiene registros relacionados," & Chr(13) & "elimínelos antes.")

            ObjError.Control1 = "ReportControl"
            ObjError.Pie1 = True
            ObjError.Foco1 = COL_NOMBRE

            FrmError.ObjError = ObjError
            FrmError.ShowDialog()
            If FrmError.DialogResult = DialogResult.OK Then
                FrmError.Dispose()
                Exit Sub
            End If
        End If

        ObjError.Pantalla1 = Me
        ObjError.Tipo1 = 2 'Mensajes

        ObjError.Titulo = "Usuarios"

        ObjError.SetMensaje("¿Desea eliminar el Usuario seleccionado?")

        ObjError.Control1 = ""
        ObjError.Pie1 = True
        ObjError.Foco1 = COL_NOMBRE

        FrmError.ObjError = ObjError
        FrmError.ShowDialog()
        'ControlErrores(ObjError)

        If FrmError.DialogResult = DialogResult.Yes Then
            FrmError.Dispose()
            Dim E As ReportRow
            E = RCUsuarios.FocusedRow
            Dim objUsuario = New Usuario(E.Record.Item(COL_ID).Value, E.Record.Item(COL_NOMBRE).Value, E.Record.Item(COL_CONTRASEÑA).Value)
            EliminarUsuario(objUsuario)
            RCUsuarios.RemoveRowEx(RCUsuarios.FocusedRow)
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
        RCUsuarios.PrintOptions.Header.TextCenter = Me.Titulo.Caption & "  -  " & cbGrupos.Text
        RCUsuarios.PrintOptions.Header.Font.Size = 18
        RCUsuarios.PrintOptions.Header.Font.Bold = True
        'RCGrupos.PrintPreviewOptions.Title = Me.Titulo.Caption
        RCUsuarios.PrintPreview(True)
    End Sub

    Private Sub cbGrupos_ClickEvent(sender As Object, e As EventArgs) Handles cbGrupos.ClickEvent

        If cbGrupos.Text <> "" Then
            RCUsuarios.Records.DeleteAll()
            idGrupo = cbGrupos.get_ItemData(cbGrupos.ListIndex)
            Dim Record As ReportRecord
            'Dim x As Integer
            Dim objGrupos As Grupo
            Dim ArrayUsuarios As New ArrayList()
            objGrupos = BDGrupos.ObtenerUnGrupo(idGrupo)
            ArrayUsuarios = objGrupos.ArrayUsuarios1

            If Not IsNothing(ArrayUsuarios) Then
                For Each objUsuario In ArrayUsuarios

                    Record = RCUsuarios.Records.Add()

                    Record.AddItem(objUsuario.Id1)
                    Record.AddItem(objUsuario.nombre1)
                    Record.AddItem(objUsuario.contraseña1)

                    Record.AddItem("")

                    'If objUsuario.GetObligatorio1 = True Then
                    '    For x = 0 To RCUsuarios.Columns.Count - 1
                    '        Record.Item(x).Editable = False
                    '        Record.Item(x).Focusable = True
                    '    Next
                    'End If
                    Record.Item(COL_AÑADIR).Editable = False
                Next

                RCUsuarios.Populate()
            End If

        End If

    End Sub

End Class