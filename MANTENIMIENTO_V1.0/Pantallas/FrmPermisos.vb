Imports AxXtremeReportControl
Imports XtremeReportControl
Imports MantEvolution.DefinicionesMenus


Public Class FrmPermisos

    Const COL_ID = 0
    Const COL_IDGRUPO = 1
    Const COL_IDPANTALLA = 2
    Const COL_DESCRIPCION = 3
    Const COL_ACCESO = 4
    'Const COL_AÑADIR = 3

    Public Permisos As Long

    Dim ArrayGrupos As New ArrayList()
    Dim ArrayPantallas As New ArrayList()
    Dim ArrayPermisos As New ArrayList()

    Dim HayErrores As Boolean

    Dim idGrupo As Long

    Dim TabPantalla As XtremeCommandBars.RibbonTab = Nothing
    Dim GrupoPantalla As XtremeCommandBars.RibbonGroup = Nothing

    Private Sub FrmPermisos_Load(sender As Object, e As EventArgs) Handles Me.Load

        Debug.Print("---> Empiezo : " & DateAndTime.Now)

        With RCPantallas

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
        Debug.Print("---> Empiezo1: " & DateAndTime.Now)
        ArrayPantallas = ObtenerPantallas()
        ArrayPermisos = ObtenerPermisosTodos()
        Debug.Print("---> Empiezo2: " & DateAndTime.Now)
        CargarComboGrupos()

        RCPantallas.Icons = MDIPrincipal.ImageManager.Icons

        fPermisos = Me
        Debug.Print("Termino : " & DateAndTime.Now)

    End Sub

    Sub CargarComboGrupos()

        BDGrupos.GetGrupoUsuario(cbGrupos)
        If cbGrupos.ListCount > 0 Then
            cbGrupos.ListIndex = 0
        Else
            cbGrupos.ListIndex = -1
        End If

    End Sub

    Sub CargarColumnasReport()

        RCPantallas.PaintManager.ColumnStyle = XTPReportColumnStyle.xtpColumnResource

        RCPantallas.AllowEdit = True

        RCPantallas.Columns.Add(COL_ID, "Id", 100, True)
        RCPantallas.Columns.Add(COL_IDGRUPO, "Id", 100, True)
        RCPantallas.Columns.Add(COL_IDPANTALLA, "Id", 100, True)
        RCPantallas.Columns.Add(COL_DESCRIPCION, "Descripción", 400, True)
        RCPantallas.Columns.Add(COL_ACCESO, "Acceso", 150, True)
        RCPantallas.Columns.Column(COL_ACCESO).EditOptions.AddComboButton()
        RCPantallas.Columns.Column(COL_ACCESO).EditOptions.GetInplaceButton(0).InsideCellButton = True
        RCPantallas.Columns.Column(COL_ACCESO).EditOptions.ConstraintEdit = True
        RCPantallas.Columns.Column(COL_ACCESO).EditOptions.Constraints.DeleteAll()
        RCPantallas.Columns.Column(COL_ACCESO).EditOptions.Constraints.Add("Denegado", 0)
        RCPantallas.Columns.Column(COL_ACCESO).EditOptions.Constraints.Add("Sólo Lectura", 1)
        RCPantallas.Columns.Column(COL_ACCESO).EditOptions.Constraints.Add("Lectura y Escritura", 2)
        RCPantallas.Columns.Column(COL_ACCESO).EditOptions.ExpandOnSelect = True

        'RCPantallas.Columns.Add(COL_AÑADIR, "Editar", 48, True)

        RCPantallas.Populate()

        'Configuracion Final del report en cuanto a columnas
        RCPantallas.Columns.Find(COL_ID).Visible = False
        RCPantallas.Columns.Find(COL_IDGRUPO).Visible = False
        RCPantallas.Columns.Find(COL_IDPANTALLA).Visible = False

        RCPantallas.Columns.Find(COL_DESCRIPCION).EditOptions.AllowEdit = False
        'RCPantallas.Columns.Find(COL_DESCRIPCION).EditOptions.MaxLength = 100
        RCPantallas.Columns.Find(COL_ACCESO).EditOptions.SelectTextOnEdit = True
        'RCPantallas.Columns.Find(COL_ACCESO).EditOptions.MaxLength = 50

    End Sub

    Private Sub RCPantallas_PreviewKeyDownEvent(sender As Object, e As _DReportControlEvents_PreviewKeyDownEvent) Handles RCPantallas.PreviewKeyDownEvent
        Dim proximaColumna As Integer
        Dim esPies As Boolean

        esPies = False

        Select Case e.keyCode
            Case 13 'Enter

                If RCPantallas.FocusedRow.Section.Index = 2 Then
                    esPies = True
                End If

                proximaColumna = SiguienteColumnaEditable(RCPantallas, RCPantallas.FocusedColumn.Index, esPies)

                ' RCPantallas.Populate()
                If esPies = True Then
                    RCPantallas.Navigator.CurrentFocusInFootersRows = True
                End If

                RCPantallas.Navigator.MoveToColumn(proximaColumna, False)

                RCPantallas.Navigator.BeginEdit()

                'If RCPantallas.Columns(proximaColumna).ItemIndex = COL_AÑADIR Then
                '    '   RCPantallas.FooterRows(0).Record.Item(COL_AÑADIR)
                '    RCPantallas_ItemButtonClick()
                'End If

            Case 9 'Tab
                If e.shift = 1 Then
                    If RCPantallas.FocusedRow.Section.Index = 2 Then
                        esPies = True
                    End If

                    proximaColumna = AnteriorColumnaEditable(RCPantallas, RCPantallas.FocusedColumn.Index, esPies)

                    RCPantallas.Populate()
                    If esPies = True Then
                        RCPantallas.Navigator.CurrentFocusInFootersRows = True
                    End If

                    RCPantallas.Navigator.MoveToColumn(proximaColumna, False)

                    RCPantallas.Navigator.BeginEdit()

                    e.cancel = True
                Else
                    If RCPantallas.FocusedRow.Section.Index = 2 Then
                        esPies = True
                    End If

                    proximaColumna = SiguienteColumnaEditable(RCPantallas, RCPantallas.FocusedColumn.Index, esPies)

                    RCPantallas.Populate()
                    If esPies = True Then
                        RCPantallas.Navigator.CurrentFocusInFootersRows = True
                    End If

                    RCPantallas.Navigator.MoveToColumn(proximaColumna, False)

                    RCPantallas.Navigator.BeginEdit()
                    e.cancel = True
                End If

            Case 16
                e.cancel = True

            Case 38
                RCPantallas.Populate()
                RCPantallas.Navigator.MoveUp()
                RCPantallas.Navigator.BeginEdit()
                e.cancel = True

            Case 40
                RCPantallas.Populate()
                RCPantallas.Navigator.MoveDown()
                RCPantallas.Navigator.BeginEdit()
                e.cancel = True

        End Select

        If Not RCPantallas.FocusedColumn Is Nothing Then
            Select Case RCPantallas.FocusedColumn.ItemIndex
                'Case COL_PRECIO, COL_PRECIORED
                '    If e.keyCode = 110 Then e.keyCode = 188 '(si pulsa la tecla del punto en el teclado númerico, lo cambio por la coma)
                '    If e.keyCode = 190 Then e.keyCode = 188 '(si pulsa la tecla del punto del teclado normal, lo cambio por la coma)

            End Select
        End If

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

        RCPantallas.Left = cbGrupos.Left + cbGrupos.Width + 10
        RCPantallas.Width = Me.Width - cbGrupos.Width - 30

        RCPantallas.Top = Titulo.Height
        RCPantallas.Height = Me.Height - RCPantallas.Top - 20

    End Sub

    Public Sub AplicaEstilo()

        Dim X As Object

        For Each X In Me.Controls
            AplicaEstiloControl(X)
        Next X

    End Sub

    Private Sub FrmUsuarios_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        fPermisos = Nothing

        MDIPrincipal.RibbonBar.RemoveTab(DEFMENU.GRUPO_MAESTROS_PERMISOS)
        'MDIPrincipal.RibbonBar.Reset()
        MDIPrincipal.RibbonBar.RedrawBar()
        MDIPrincipal.RibbonBar.RecalcLayout()

        MDIPrincipal.RibbonBar.FindTab(DEFMENU.TAB_MAESTROS).Selected = True
        MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_MAESTROS_PERMISOS).Visible = False

    End Sub

    Sub ConstruirMenu()

        If MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_MAESTROS_PERMISOS) Is Nothing Then 'si no existe lo creo
            TabPantalla = MDIPrincipal.RibbonBar.InsertTab(DEFMENU.GRUPO_MAESTROS_PERMISOS, "&Permisos")
            TabPantalla.Id = DEFMENU.GRUPO_MAESTROS_PERMISOS

            'GrupoPantalla = TabPrincipal.Groups.AddGroup("&MANTE", 1001)
            'GrupoPantalla.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.PRINCIPAL_MANTENIMIENTO, "Mantenimiento", False, False)
            GrupoPantalla = TabPantalla.Groups.AddGroup("&PERMISOS", DEFMENU.GRUPO_MAESTROS_PERMISOS)
            GrupoPantalla.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_PERMISOS_IMPRIMIR, "Imprimir", False, False).IconId = 102
            GrupoPantalla.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_PERMISOS_SALIR, "Salir", False, False).IconId = 103
        End If

        MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_MAESTROS_PERMISOS).Visible = True
        MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_MAESTROS_PERMISOS).Selected = True

    End Sub

    Private Sub FrmUsuarios_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        ConstruirMenu()
    End Sub

    Sub Menu_Imprimir()
        RCPantallas.PrintOptions.Header.TextCenter = Me.Titulo.Caption
        RCPantallas.PrintOptions.Header.Font.Size = 18
        RCPantallas.PrintOptions.Header.Font.Bold = True
        'RCGrupos.PrintPreviewOptions.Title = Me.Titulo.Caption
        RCPantallas.PrintPreview(True)
    End Sub

    Private Sub cbGrupos_ClickEvent(sender As Object, e As EventArgs) Handles cbGrupos.ClickEvent

        Dim Record As XtremeReportControl.ReportRecord
        Dim objPermiso As Permiso
        Dim objPantallas As Pantalla
        Dim HeEncontrado As Boolean


        '        Debug.Print("---> Empiezo : " & DateAndTime.Now)

        idGrupo = cbGrupos.get_ItemData(cbGrupos.ListIndex)

        RCPantallas.Records.DeleteAll()

        'ArrayPantallas = ObtenerPantallas()

        For Each objPantallas In ArrayPantallas

            'objPermiso = ObtenerPermisos(objPantallas.Id1, idGrupo)
            Record = RCPantallas.Records.Add()
            HeEncontrado = False
            For Each objPermiso In ArrayPermisos
                If objPermiso.IdPantalla1 = objPantallas.Id1 And objPermiso.IdGrupo1 = idGrupo Then
                    HeEncontrado = True
                    'he encontrado el permiso de esa pantalla para ese grupo
                    Record.AddItem(objPermiso.Id1)
                    Record.AddItem(idGrupo)
                    Record.AddItem(objPantallas.Id1)
                    Record.AddItem(objPantallas.Descripcion1)
                    Record.AddItem(objPermiso.Acceso1) 'Acceso, esto está en permisos
                    Exit For
                End If
            Next
            If Not HeEncontrado Then
                Record.AddItem(0)
                Record.AddItem(idGrupo)
                Record.AddItem(objPantallas.Id1)
                Record.AddItem(objPantallas.Descripcion1)
                Record.AddItem(2) 'si no tiene nada, permiso total
            End If

        Next
        RCPantallas.Populate()

        '        Debug.Print("Termino : " & DateAndTime.Now)

    End Sub

    Private Sub RCPantallas_ValueChanged(sender As Object, e As _DReportControlEvents_ValueChangedEvent) Handles RCPantallas.ValueChanged
        Dim MiRow As ReportRow

        MiRow = RCPantallas.FocusedRow

        Dim ObjError As New Errores

        If Permisos <> 2 Then

            ObjError.Pantalla1 = Me
            ObjError.Tipo1 = 1 'Avisos

            ObjError.Titulo = "Permisos"

            ObjError.SetMensaje("No dispone de Permiso para Actualizar Permisos")

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

        If MiRow.Record.Item(COL_ID).Value <> 0 Then
            Dim objPermisos = New Permiso(MiRow.Record.Item(COL_ID).Value, MiRow.Record.Item(COL_ACCESO).Value, ObtenerUnGrupo(idGrupo), ObtenerUnaPantalla(MiRow.Record.Item(COL_IDPANTALLA).Value))
            ModificarPermiso(objPermisos)
        Else
            Dim objPermisos = New Permiso(MiRow.Record.Item(COL_ACCESO).Value, ObtenerUnGrupo(idGrupo), ObtenerUnaPantalla(MiRow.Record.Item(COL_IDPANTALLA).Value))
            GuardarPermiso(objPermisos)
        End If

    End Sub

End Class