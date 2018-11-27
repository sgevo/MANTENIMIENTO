Imports AxXtremeReportControl
Imports AxXtremeShortcutBar
Imports AxXtremeSuiteControls
Imports MantEvolution.DefinicionesMenus
Imports XtremeReportControl

Public Class FrmMantenimiento

    Const COL_ID = 0
    Const COL_FECHA = 1
    Const COL_TIPO = 2
    Const COL_PRODUCTO = 3
    Const COL_VERSION = 4
    Const COL_LICENCIA = 5
    Const COL_CLAVE = 6
    Const COL_RED = 7


    Const COL_IDP = 0
    Const COL_TIPOP = 1
    Const COL_PACKP = 2
    Const COL_FECHAADQ = 3
    Const COL_FECHAINI = 4
    Const COL_FECHAFIN = 5
    Const COL_PRODUCTOP1 = 6
    Const COL_VERSIONP1 = 7
    Const COL_LICENCIAP1 = 8
    Const COL_CLAVEP1 = 9
    Const COL_REDP1 = 10
    Const COL_MANTEP1 = 11
    Const COL_PRODUCTOP2 = 12
    Const COL_VERSIONP2 = 13
    Const COL_LICENCIAP2 = 14
    Const COL_CLAVEP2 = 15
    Const COL_REDP2 = 16
    Const COL_MANTEP2 = 17

    Const COL_IDM = 0
    Const COL_FECHAM = 1
    Const COL_TECNICOM = 2
    Const COL_MEDIOM = 3
    Const COL_TIPOM = 4
    Const COL_TEMAM = 5
    Const COL_PRODUCTOM = 6
    Const COL_TRABAJOM = 7
    Const COL_SUBTRABAJOM = 8
    Const COL_DONDEM = 9
    Const COL_ASIGNADOM = 10
    Const COL_REALIZADOM = 11
    Const COL_SUGERIDOM = 12

    Const COL_IDT = 0
    Const COL_IDMANTET = 1
    Const COL_IDTECNICOGT = 2
    Const COL_FECHAT = 3
    Const COL_IDTECNICOT = 4
    Const COL_IDCLIENTET = 5
    Const COL_DESCRIPCIONT = 6
    Const COL_ESTADOT = 7
    Const COL_FECHAFINT = 8


    Public Permisos As Long

    Dim ArrayMovimientos As New ArrayList()
    Dim ArrayMantenimientos As New ArrayList()

    Dim HayErrores As Boolean

    Dim InicioPantalla As Boolean = True

    Dim TabPantalla As XtremeCommandBars.RibbonTab = Nothing
    Dim GroupFile As XtremeCommandBars.RibbonGroup = Nothing

    Dim EstadoProductos As Long '0=sin mante, 1=con mante, 2=con pack

    Dim objCliente As Cliente

    Dim arrayProductos As New ArrayList
    Dim arrayVersiones As New ArrayList
    Dim arrayPacks As New ArrayList

    Dim IdManteActual As Long

    Dim IdManteTarea As Long
    Dim IdClienteTarea As Long
    Dim IdTareaActiva As Long

    Dim EstadoRegMante As Long 'Estado del registro visualizado, =0 Visualizado, =1 Editado, =2 Nuevo

    Dim Margen As Long

    Private Sub FrmMantenimiento_Load(sender As Object, e As EventArgs) Handles Me.Load

        '        Debug.Print("---> Empiezo : " & DateAndTime.Now)
        InicioPantalla = True

        With RCMovimientos

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

        With RCTareas

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

        '        Debug.Print("---> Empiezo1: " & DateAndTime.Now)

        arrayProductos = ObtenerProductos()
        '        Debug.Print("---> Empiezo2: " & DateAndTime.Now)
        arrayVersiones = ObtenerTodasVersiones()
        '        Debug.Print("---> Empiezo3: " & DateAndTime.Now)
        arrayPacks = ObtenerPacks()

        'CargarProductos()

        'Esta linea hace falta para que funcione el rc_beforedrawrow
        'Aunque el formato se puede poner directamente en la Clase del objeto, mejor
        'RCProductos.SetCustomDraw(XtremeReportControl.XTPReportCustomDraw.xtpCustomBeforeDrawRow)

        RCMovimientos.Icons = MDIPrincipal.ImageManager.Icons

        '       Debug.Print("Termino : " & DateAndTime.Now)

        RCMovimientos.Visible = False

        GrupoCbMedio.AddItem("LLAMADA")
        GrupoCbMedio.AddItem("E-MAIL")
        GrupoCbMedio.AddItem("CARTA")

        GrupoCbTipo.AddItem("ENTRANTE")
        GrupoCbTipo.AddItem("SALIENTE")

        GrupoCbTema.AddItem("INCIDENCIA")
        GrupoCbTema.AddItem("CONSULTA")
        GrupoCbTema.AddItem("COMERCIAL")

        GrupoCbProducto.AddItem("WontaW")
        GrupoCbProducto.AddItem("WontaGes")
        GrupoCbProducto.AddItem("Todos")
        GrupoCbProducto.AddItem("Mante")
        GrupoCbProducto.AddItem("B.Datos")

        GrupoCbMedio.ListIndex = 0
        GrupoCbTipo.ListIndex = 0
        GrupoCbTema.ListIndex = 0
        GrupoCbProducto.ListIndex = 0
        GrupoCbTrabajo.ListIndex = -1

        CargarTareas()

        fMantenimiento = Me
    End Sub

    Sub CargarColumnasReport()

        Dim FilaPie As ReportRecord

        RCMovimientos.PaintManager.ColumnStyle = XTPReportColumnStyle.xtpColumnResource

        RCMovimientos.AllowEdit = False

        RCMovimientos.Columns.Add(COL_ID, "Id", 100, True)
        RCMovimientos.Columns.Add(COL_FECHA, "Fecha", 80, True)
        RCMovimientos.Columns.Add(COL_TIPO, "Tipo", 80, True)
        RCMovimientos.Columns.Add(COL_PRODUCTO, "Producto", 100, True)
        RCMovimientos.Columns.Add(COL_VERSION, "Versión", 80, True)
        RCMovimientos.Columns.Add(COL_LICENCIA, "Licencia", 80, True)
        RCMovimientos.Columns.Add(COL_CLAVE, "Clave", 80, True)
        RCMovimientos.Columns.Add(COL_RED, "Red", 60, True)
        RCMovimientos.Columns.Column(COL_RED).EditOptions.AddComboButton()
        RCMovimientos.Columns.Column(COL_RED).EditOptions.GetInplaceButton(0).InsideCellButton = True
        RCMovimientos.Columns.Column(COL_RED).EditOptions.ConstraintEdit = True
        RCMovimientos.Columns.Column(COL_RED).EditOptions.Constraints.DeleteAll()
        RCMovimientos.Columns.Column(COL_RED).EditOptions.Constraints.Add("Sí", -1)
        RCMovimientos.Columns.Column(COL_RED).EditOptions.Constraints.Add("No", 0)
        RCMovimientos.Columns.Column(COL_RED).EditOptions.ExpandOnSelect = True


        'Configuracion Final del report en cuanto a columnas
        RCMovimientos.Columns.Find(COL_ID).Visible = False
        'RCProductos.Columns.Find(COL_VERSIONES).Alignment = XTPColumnAlignment.xtpAlignmentCenter
        'RCProductos.Columns.Find(COL_MANTENIMIENTO).Alignment = XTPColumnAlignment.xtpAlignmentCenter
        'RCProductos.Columns.Find(COL_RED).Alignment = XTPColumnAlignment.xtpAlignmentCenter
        'RCProductos.Columns.Find(COL_TEMPORAL).Alignment = XTPColumnAlignment.xtpAlignmentCenter
        'RCProductos.Columns.Find(COL_PRECIO).Alignment = XTPColumnAlignment.xtpAlignmentRight
        'RCProductos.Columns.Find(COL_PRECIORED).Alignment = XTPColumnAlignment.xtpAlignmentRight
        'RCProductos.Columns.Find(COL_CODIGO).EditOptions.SelectTextOnEdit = True
        'RCProductos.Columns.Find(COL_CODIGO).EditOptions.MaxLength = 15
        'RCProductos.Columns.Find(COL_DESCRIPCION).EditOptions.SelectTextOnEdit = True
        'RCProductos.Columns.Find(COL_DESCRIPCION).EditOptions.MaxLength = 100
        'RCProductos.Columns.Find(COL_PRECIO).EditOptions.SelectTextOnEdit = True
        'RCProductos.Columns.Find(COL_PRECIO).EditOptions.MaxLength = 15
        'RCProductos.Columns.Find(COL_PRECIORED).EditOptions.SelectTextOnEdit = True
        'RCProductos.Columns.Find(COL_PRECIORED).EditOptions.MaxLength = 15

        RCProductos.PaintManager.ColumnStyle = XTPReportColumnStyle.xtpColumnResource

        RCProductos.AllowEdit = False


        RCProductos.Columns.Add(COL_IDP, "Id", 100, True)
        RCProductos.Columns.Add(COL_TIPOP, "Tipo", 75, True)
        RCProductos.Columns.Column(COL_TIPOP).EditOptions.AddComboButton()
        RCProductos.Columns.Column(COL_TIPOP).EditOptions.GetInplaceButton(0).InsideCellButton = True
        RCProductos.Columns.Column(COL_TIPOP).EditOptions.ConstraintEdit = True
        RCProductos.Columns.Column(COL_TIPOP).EditOptions.Constraints.DeleteAll()
        RCProductos.Columns.Column(COL_TIPOP).EditOptions.Constraints.Add("PRODUCTO", 0)
        RCProductos.Columns.Column(COL_TIPOP).EditOptions.Constraints.Add("SERVICIO", 1)
        RCProductos.Columns.Column(COL_TIPOP).EditOptions.Constraints.Add("PACK", 2)
        RCProductos.Columns.Column(COL_TIPOP).EditOptions.ExpandOnSelect = True
        RCProductos.Columns.Add(COL_PACKP, "Nombre", 80, True)
        RCProductos.Columns.Add(COL_FECHAADQ, "Fecha Adq.", 80, True)
        RCProductos.Columns.Add(COL_FECHAINI, "Fecha Inicio", 80, True)
        RCProductos.Columns.Add(COL_FECHAFIN, "Fecha Fin", 80, True)
        RCProductos.Columns.Add(COL_PRODUCTOP1, "Producto", 100, True)
        RCProductos.Columns.Add(COL_VERSIONP1, "Versión", 60, True)
        RCProductos.Columns.Add(COL_LICENCIAP1, "Licencia", 80, True)
        RCProductos.Columns.Add(COL_CLAVEP1, "Clave", 80, True)
        RCProductos.Columns.Add(COL_REDP1, "Red", 40, True)
        RCProductos.Columns.Column(COL_REDP1).EditOptions.AddComboButton()
        RCProductos.Columns.Column(COL_REDP1).EditOptions.GetInplaceButton(0).InsideCellButton = True
        RCProductos.Columns.Column(COL_REDP1).EditOptions.ConstraintEdit = True
        RCProductos.Columns.Column(COL_REDP1).EditOptions.Constraints.DeleteAll()
        RCProductos.Columns.Column(COL_REDP1).EditOptions.Constraints.Add("Sí", -1)
        RCProductos.Columns.Column(COL_REDP1).EditOptions.Constraints.Add("No", 0)
        RCProductos.Columns.Column(COL_REDP1).EditOptions.ExpandOnSelect = True
        RCProductos.Columns.Add(COL_MANTEP1, "Mante", 40, True)
        RCProductos.Columns.Column(COL_MANTEP1).EditOptions.AddComboButton()
        RCProductos.Columns.Column(COL_MANTEP1).EditOptions.GetInplaceButton(0).InsideCellButton = True
        RCProductos.Columns.Column(COL_MANTEP1).EditOptions.ConstraintEdit = True
        RCProductos.Columns.Column(COL_MANTEP1).EditOptions.Constraints.DeleteAll()
        RCProductos.Columns.Column(COL_MANTEP1).EditOptions.Constraints.Add("Sí", -1)
        RCProductos.Columns.Column(COL_MANTEP1).EditOptions.Constraints.Add("No", 0)
        RCProductos.Columns.Column(COL_MANTEP1).EditOptions.ExpandOnSelect = True

        RCProductos.Columns.Add(COL_PRODUCTOP2, "Producto 2", 100, True)
        RCProductos.Columns.Add(COL_VERSIONP2, "Versión 2", 60, True)
        RCProductos.Columns.Add(COL_LICENCIAP2, "Licencia 2", 80, True)
        RCProductos.Columns.Add(COL_CLAVEP2, "Clave 2", 80, True)
        RCProductos.Columns.Add(COL_REDP2, "Red 2", 40, True)
        RCProductos.Columns.Column(COL_REDP2).EditOptions.AddComboButton()
        RCProductos.Columns.Column(COL_REDP2).EditOptions.GetInplaceButton(0).InsideCellButton = True
        RCProductos.Columns.Column(COL_REDP2).EditOptions.ConstraintEdit = True
        RCProductos.Columns.Column(COL_REDP2).EditOptions.Constraints.DeleteAll()
        RCProductos.Columns.Column(COL_REDP2).EditOptions.Constraints.Add("Sí", -1)
        RCProductos.Columns.Column(COL_REDP2).EditOptions.Constraints.Add("No", 0)
        RCProductos.Columns.Column(COL_REDP2).EditOptions.ExpandOnSelect = True
        RCProductos.Columns.Add(COL_MANTEP2, "Mante 2", 40, True)
        RCProductos.Columns.Column(COL_MANTEP2).EditOptions.AddComboButton()
        RCProductos.Columns.Column(COL_MANTEP2).EditOptions.GetInplaceButton(0).InsideCellButton = True
        RCProductos.Columns.Column(COL_MANTEP2).EditOptions.ConstraintEdit = True
        RCProductos.Columns.Column(COL_MANTEP2).EditOptions.Constraints.DeleteAll()
        RCProductos.Columns.Column(COL_MANTEP2).EditOptions.Constraints.Add("Sí", -1)
        RCProductos.Columns.Column(COL_MANTEP2).EditOptions.Constraints.Add("No", 0)
        RCProductos.Columns.Column(COL_MANTEP2).EditOptions.ExpandOnSelect = True

        RCProductos.Columns.Find(COL_IDP).Visible = False


        RCMantenimientos.PaintManager.ColumnStyle = XTPReportColumnStyle.xtpColumnResource

        RCMantenimientos.AllowEdit = False

        RCMantenimientos.Columns.Add(COL_IDM, "Id", 100, True)
        RCMantenimientos.Columns.Add(COL_FECHAM, "Fecha/Hora", 100, True)
        RCMantenimientos.Columns.Add(COL_TECNICOM, "Técnico", 70, True)
        RCMantenimientos.Columns.Add(COL_MEDIOM, "Medio", 70, True)
        RCMantenimientos.Columns.Add(COL_TIPOM, "Tipo", 70, True)
        RCMantenimientos.Columns.Add(COL_TEMAM, "Tema", 70, True)
        RCMantenimientos.Columns.Add(COL_PRODUCTOM, "Producto", 70, True)
        RCMantenimientos.Columns.Add(COL_TRABAJOM, "Trabajo", 160, True)
        RCMantenimientos.Columns.Add(COL_SUBTRABAJOM, "Subtrabajo", 160, True)
        RCMantenimientos.Columns.Add(COL_DONDEM, "Donde", 80, True)
        RCMantenimientos.Columns.Add(COL_ASIGNADOM, "Asignado", 70, True)
        RCMantenimientos.Columns.Add(COL_REALIZADOM, "Realizado", 80, True)
        RCMantenimientos.Columns.Add(COL_SUGERIDOM, "Sugerido", 60, True)

        RCMantenimientos.Columns.Find(COL_REALIZADOM).Visible = False
        RCMantenimientos.Columns.Find(COL_SUGERIDOM).Visible = False
        RCMantenimientos.Columns.Find(COL_IDM).Visible = False


        RCTareas.PaintManager.ColumnStyle = XTPReportColumnStyle.xtpColumnResource

        RCTareas.AllowEdit = False

        Const COL_IDT = 0
        Const COL_IDMANTET = 1
        Const COL_IDTECNICOGT = 2
        Const COL_FECHAT = 3
        Const COL_IDTECNICOT = 4
        Const COL_IDCLIENTET = 5
        Const COL_DESCRIPCIONT = 6
        Const COL_ESTADOT = 7
        Const COL_FECHAFINT = 8

        RCTareas.Columns.Add(COL_IDT, "Id", 100, True)
        RCTareas.Columns.Add(COL_IDMANTET, "IdMante", 100, True)
        RCTareas.Columns.Add(COL_IDTECNICOGT, "De Técnico", 70, True)
        RCTareas.Columns.Add(COL_FECHAT, "Fecha", 120, True)
        RCTareas.Columns.Add(COL_IDTECNICOT, "IdTecnico", 70, True)
        RCTareas.Columns.Add(COL_IDCLIENTET, "Cliente", 60, True)
        RCTareas.Columns.Add(COL_DESCRIPCIONT, "Descripción", 190, True)
        RCTareas.Columns.Add(COL_ESTADOT, "Estado", 60, True)
        RCTareas.Columns.Add(COL_FECHAFINT, "Fecha Fin", 70, True)

        RCTareas.Columns.Find(COL_IDT).Visible = False
        RCTareas.Columns.Find(COL_IDMANTET).Visible = False
        RCTareas.Columns.Find(COL_IDTECNICOT).Visible = False
        RCTareas.Columns.Find(COL_FECHAFINT).Visible = False

    End Sub

    Private Sub FrmProductos_Resize(sender As Object, e As EventArgs) Handles Me.Resize

        'Debug.Print("Resize: " & Now & InicioPantalla)

        ConfigurarPantalla()
        If Not InicioPantalla Then
            'Debug.Print("Resize2: " & Now & InicioPantalla)
            Reposiciona()
        End If
    End Sub

    Sub ConfigurarPantalla()

        'Debug.Print("ConfigurarPantalla: " & Now)

        Margen = 70 ''a partir de este valor se define todo

        Titulo.Top = 0
        Titulo.Left = 0
        Titulo.Width = Me.Width

        lblDatos.Left = 10
        'lblProductos.Left = 10

        lblEstado.Left = lblCliente.Left + lblCliente.Width + 20
        lblEstado.Width = Me.Width - (lblEstado.Left) - 10

        scMovimientos.Left = Margen
        scMovimientos.Width = Me.Width - Margen - 20

        scProductos.Left = Margen
        scProductos.Width = Me.Width - Margen - 20

        RCMovimientos.Left = Margen
        RCMovimientos.Width = Me.Width - Margen - 20
        RCProductos.Left = RCMovimientos.Left
        RCProductos.Width = RCMovimientos.Width

        'GrupoSeparador.Left = RCMovimientos.Left
        'GrupoSeparador.Width = RCMovimientos.Width


        'Reposiciona()


        'RCProductos.Top = Titulo.Height
        'RCProductos.Height = Me.Height - RCProductos.Top - 20

    End Sub

    Public Sub AplicaEstilo()

        Dim X As Object

        For Each X In Me.Controls
            AplicaEstiloControl(X)
        Next X

    End Sub

    Private Sub FrmMantenimiento_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        fMantenimiento = Nothing

        MDIPrincipal.RibbonBar.RemoveTab(DEFMENU.GRUPO_PRINCIPAL_MANTENIMIENTO)
        'MDIPrincipal.RibbonBar.Reset()
        MDIPrincipal.RibbonBar.RedrawBar()
        MDIPrincipal.RibbonBar.RecalcLayout()

        MDIPrincipal.RibbonBar.FindTab(DEFMENU.TAB_PRINCIPAL).Selected = True
        MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_PRINCIPAL_MANTENIMIENTO).Visible = False
    End Sub

    Sub ConstruirMenu()

        If MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_PRINCIPAL_MANTENIMIENTO) Is Nothing Then 'si no existe lo creo
            TabPantalla = MDIPrincipal.RibbonBar.InsertTab(DEFMENU.GRUPO_PRINCIPAL_MANTENIMIENTO, "&Mantenimiento")
            TabPantalla.Id = DEFMENU.GRUPO_PRINCIPAL_MANTENIMIENTO

            'GroupFile = TabPrincipal.Groups.AddGroup("&MANTE", 1001)
            'GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.PRINCIPAL_MANTENIMIENTO, "Mantenimiento", False, False)
            GroupFile = TabPantalla.Groups.AddGroup("&MANTENIMIENTO", DEFMENU.GRUPO_PRINCIPAL_MANTENIMIENTO)
            GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.PRINCIPAL_MANTENIMIENTO_IMPRIMIR, "Imprimir", False, False).IconId = 102
            GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.PRINCIPAL_MANTENIMIENTO_SALIR, "Salir", False, False).IconId = 103
        End If

        MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_PRINCIPAL_MANTENIMIENTO).Visible = True
        MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_PRINCIPAL_MANTENIMIENTO).Selected = True

    End Sub

    Sub Menu_Imprimir()
        RCMovimientos.PrintOptions.Header.TextCenter = Me.Titulo.Caption
        RCMovimientos.PrintOptions.Header.Font.Size = 18
        RCMovimientos.PrintOptions.Header.Font.Bold = True
        'RCProductos.PrintPreviewOptions.Title = Me.Titulo.Caption
        RCMovimientos.PrintPreview(True)
    End Sub

    Private Sub FrmMantenimiento_Activated(sender As Object, e As EventArgs) Handles Me.Activated

        'Debug.Print("Activated: " & Now)

        ConstruirMenu()
        If InicioPantalla Then
            '   Debug.Print("Activated2: " & Now)
            Reposiciona()
            CargarCombos()
            InicioPantalla = False
        End If
    End Sub

    Private Sub txtCliente_KeyPressEvent(sender As Object, e As _DFlatEditEvents_KeyPressEvent) Handles txtCliente.KeyPressEvent
        Retorno(e.keyAscii)
        'EsNumero KeyAscii, teHasta.Text
    End Sub

    Private Sub txtCliente_GotFocus(sender As Object, e As EventArgs) Handles txtCliente.GotFocus
        LimpiaPantalla()

        txtCliente.SelStart = 0
        txtCliente.SelLength = Len(txtCliente.Text)
    End Sub

    Private Sub txtLicencia_KeyPressEvent(sender As Object, e As _DFlatEditEvents_KeyPressEvent) Handles txtLicencia.KeyPressEvent
        Retorno(e.keyAscii)
        'EsNumero KeyAscii, teHasta.Text
    End Sub

    Private Sub txtLicencia_GotFocus(sender As Object, e As EventArgs) Handles txtLicencia.GotFocus
        txtLicencia.SelStart = 0
        txtLicencia.SelLength = Len(txtLicencia.Text)
    End Sub

    Private Sub txtCliente_LostFocus(sender As Object, e As EventArgs) Handles txtCliente.LostFocus
        If txtCliente.Text <> "" Then
            CargarMovimientos()
            CargarProductos()
            CargarMantenimientos(0)
        End If
    End Sub

    Sub CargarMovimientos()

        Dim Record As XtremeReportControl.ReportRecord
        Dim ObjMovimiento As Movimiento
        Dim CuentoObjetos As Long
        Dim objProductos As Producto
        Dim objVersiones As Version
        Dim objPacks As Pack
        Dim ObjError As New Errores

        RCMovimientos.Records.DeleteAll()

        '        Debug.Print("---> Empiezo " & txtCliente.Text & ": " & DateAndTime.Now)

        'Dim objCliente As Cliente

        objCliente = ObtenerUnCliente(txtCliente.Text)
        If Not IsNothing(objCliente) Then
            txtLicencia.Text = ""
            lblNComercial.Caption = objCliente.NombreComercial1
            lblRSocial.Caption = objCliente.RazonSocial1
            lblUsuario.Caption = objCliente.UsuarioNombre11
            lblMail.Caption = objCliente.Email1
            lblTelef1.Caption = objCliente.Telefono1
            lblTelef2.Caption = objCliente.Telefono21
            lblTelefMovil.Caption = objCliente.Movil1
            lblDirDatos.Caption = objCliente.Web1
        Else
            ObjError.Pantalla1 = Me
            ObjError.Tipo1 = 3 'Info

            ObjError.Titulo = "Clientes"

            ObjError.SetMensaje("No existe el cliente " & txtCliente.Text)

            ObjError.Control1 = ""
            ObjError.Pie1 = False
            ObjError.Foco1 = txtCliente.Text

            FrmError.ObjError = ObjError
            FrmError.ShowDialog()
            If FrmError.DialogResult = DialogResult.OK Then
                FrmError.Dispose()
                Exit Sub
            End If
        End If

        ArrayMovimientos = objCliente.ArrayMovimientos1

        For Each ObjMovimiento In ArrayMovimientos
            'If CuentoObjetos = 1 Then
            '    'Cada movimiento tiene cargado el cliente, y eso que me ahorro
            '    lblNComercial.Caption = ObjMovimiento.ObjCliente1.NombreComercial1
            '    lblRSocial.Caption = ObjMovimiento.ObjCliente1.RazonSocial1
            '    lblUsuario.Caption = ObjMovimiento.ObjCliente1.UsuarioNombre11
            '    lblMail.Caption = ObjMovimiento.ObjCliente1.Email1
            '    lblTelef1.Caption = ObjMovimiento.ObjCliente1.Telefono1
            '    lblTelef2.Caption = ObjMovimiento.ObjCliente1.Telefono21
            '    lblTelefMovil.Caption = ObjMovimiento.ObjCliente1.Movil1
            '    lblDatos.Caption = ObjMovimiento.ObjCliente1.Web1
            'End If

            Record = RCMovimientos.Records.Add()

            Record.AddItem(ObjMovimiento.Id1)
            Record.AddItem(ObjMovimiento.Fecha1)
            Record.AddItem(ObjMovimiento.Tipo1)

            CuentoObjetos = 0
            For Each objProductos In arrayProductos
                If objProductos.Id1 = ObjMovimiento.Id_Producto1 Then
                    CuentoObjetos = 1
                    Record.AddItem(objProductos.Codigo1)
                    Exit For
                End If
            Next
            If CuentoObjetos = 0 Then Record.AddItem("") 'si no ha encontrado nada, tengo que meter algo
            'Record.AddItem(ObjMovimiento.ObjProducto1.Codigo1)

            CuentoObjetos = 0
            For Each objVersiones In arrayVersiones
                If objVersiones.Id1 = ObjMovimiento.Id_Version1 Then
                    CuentoObjetos = 1
                    Record.AddItem(objVersiones.Version1)
                    Exit For
                End If
            Next
            If CuentoObjetos = 0 Then Record.AddItem("") 'si no ha encontrado nada, tengo que meter algo
            'Record.AddItem(ObjMovimiento.ObjVersion1.Version1)

            Record.AddItem(ObjMovimiento.Licencia1)
            Record.AddItem(ObjMovimiento.Clave1)
            Record.AddItem(ObjMovimiento.Red1)

        Next

        'If CuentoObjetos = 0 Then
        '    'Cargo datos del cliente solo si no tiene ningún movimiento
        '    Dim objCliente As Cliente

        '    objCliente = ObtenerUnCliente(txtCliente.Text)
        '    If Not IsNothing(objCliente) Then

        '        lblNComercial.Caption = objCliente.NombreComercial1
        '        lblRSocial.Caption = objCliente.RazonSocial1
        '        lblUsuario.Caption = objCliente.UsuarioNombre11
        '        lblMail.Caption = objCliente.Email1
        '        lblTelef1.Caption = objCliente.Telefono1
        '        lblTelef2.Caption = objCliente.Telefono21
        '        lblTelefMovil.Caption = objCliente.Movil1
        '        lblDatos.Caption = objCliente.Web1
        '    End If
        'End If

        RCMovimientos.Populate()
        RCMovimientos.Navigator.MoveLastRow()

        '        Debug.Print("Termino: " & DateAndTime.Now)


    End Sub

    Sub CargarMantenimientos(ElMante As Long)

        Dim Record As XtremeReportControl.ReportRecord
        Dim ObjMantenimiento As Mantenimiento
        Dim objTecnicos As Usuario
        Dim TengoTecnico As Boolean
        'Dim objTecnicosAsigno As Usuario
        Dim objTrabajos As Trabajo
        Dim TengoTrabajo As Boolean
        Dim ObjError As New Errores

        Dim ArrayTrabajos As New ArrayList
        Dim ArrayUsuarios As New ArrayList

        Dim laRow As Long


        RCMantenimientos.Records.DeleteAll()
        TengoTecnico = False
        TengoTrabajo = False

        If IsNothing(objCliente) Then Exit Sub

        ArrayMantenimientos = objCliente.ArrayMantenimientos1

        ArrayTrabajos = ObtenerTodosTrabajos()
        ArrayUsuarios = ObtenerTodosUsuarios()

        For Each ObjMantenimiento In ArrayMantenimientos

            Record = RCMantenimientos.Records.Add()

            If ElMante > 0 And ObjMantenimiento.Id1 = ElMante Then
                laRow = Record.Index
            End If

            Record.AddItem(ObjMantenimiento.Id1)
            Record.AddItem(ObjMantenimiento.Fecha1)

            For Each objTecnicos In ArrayUsuarios
                If objTecnicos.Id1 = ObjMantenimiento.Id_Tecnico1 Then
                    TengoTecnico = True
                    Exit For
                End If
            Next
            If TengoTecnico Then
                Record.AddItem(objTecnicos.Nombre1)
            Else
                Record.AddItem("")
            End If

            Record.AddItem(ObjMantenimiento.Medio1)
            Record.AddItem(ObjMantenimiento.Tipo1)
            Record.AddItem(ObjMantenimiento.Tema1)
            Record.AddItem(ObjMantenimiento.Producto1)

            For Each objTrabajos In ArrayTrabajos
                If objTrabajos.Id1 = ObjMantenimiento.Id_Trabajo1 Then
                    TengoTrabajo = True
                    Exit For
                End If
            Next
            If TengoTrabajo Then
                Record.AddItem(objTrabajos.Trabajo1)
            Else
                Record.AddItem("")
            End If

            Record.AddItem(ObjMantenimiento.Subtrabajo1)
            Record.AddItem(ObjMantenimiento.Donde1)

            TengoTecnico = False
            For Each objTecnicos In ArrayUsuarios
                If objTecnicos.Id1 = ObjMantenimiento.Id_Tecnico_Asignar1 Then
                    TengoTecnico = True
                    Exit For
                End If
            Next
            If TengoTecnico Then
                Record.AddItem(objTecnicos.Nombre1)
            Else
                Record.AddItem("[TERMINADO]")
            End If

            Record.AddItem(ObjMantenimiento.Realizado1)
            Record.AddItem(ObjMantenimiento.Sugerido1)

        Next

        RCMantenimientos.Populate()

        If laRow <> 0 Then
            RCMantenimientos.Navigator.MoveToRow(laRow)
        Else
            RCMantenimientos.Navigator.MoveLastRow()
        End If

    End Sub

    Sub CargarTareas()

        Dim Record As XtremeReportControl.ReportRecord
        Dim objTecnicos As Usuario
        Dim TengoTecnico As Boolean
        'Dim objTecnicosAsigno As Usuario
        Dim ObjError As New Errores

        Dim ObjTarea As Tarea
        Dim ArrayTareas As ArrayList

        Dim ArrayUsuarios As New ArrayList

        RCTareas.Records.DeleteAll()
        TengoTecnico = False

        If IsNothing(UsuarioId) Then Exit Sub

        'ArrayMantenimientos = objCliente.ArrayMantenimientos1

        ArrayTareas = ObtenerTareasActivas(UsuarioId)
        ArrayUsuarios = ObtenerTodosUsuarios()

        For Each ObjTarea In ArrayTareas

            Record = RCTareas.Records.Add()

            Record.AddItem(ObjTarea.Id1)
            Record.AddItem(ObjTarea.IdMantenimiento1)

            For Each objTecnicos In ArrayUsuarios
                If objTecnicos.Id1 = ObjTarea.IdTecnicoGenerador1 Then
                    TengoTecnico = True
                    Exit For
                End If
            Next
            If TengoTecnico Then
                Record.AddItem(objTecnicos.Nombre1)
            Else
                Record.AddItem("")
            End If
            Record.AddItem(ObjTarea.FechaCreacion1)
            Record.AddItem(ObjTarea.IdTecnico1)
            Record.AddItem(ObjTarea.IdCliente1)
            Record.AddItem(ObjTarea.Descripcion1)
            Record.AddItem(ObjTarea.Estado1)

            Record.AddItem(ObjTarea.FechaTerminacion1)

        Next

        RCTareas.Populate()
        RCTareas.Navigator.MoveLastRow()

    End Sub

    Sub CargarProductos()

        Dim Record As XtremeReportControl.ReportRecord
        Dim ObjMovimiento As Movimiento
        Dim CuentoObjetos As Long
        Dim objProductosCliente As ProductosCliente
        Dim objVersiones As Version
        Dim objPacks As Pack
        Dim TipoPacks As Boolean 'true tengo packs, false no
        Dim CualProducto As String
        Dim HayServicio As Boolean

        Dim ArrayProductosCliente As ArrayList

        RCProductos.Records.DeleteAll()
        TipoPacks = False

        If txtCliente.Text = "" Then Exit Sub

        CualProducto = ""

        ArrayProductosCliente = ObtenerProductosCliente(txtCliente.Text)

        For Each objProductosCliente In ArrayProductosCliente

            HayServicio = False

            If objProductosCliente.Tipo1 = 0 Or objProductosCliente.Tipo1 = 1 Then 'Productos o Servicios

                Record = RCProductos.Records.Add()

                Record.AddItem(objProductosCliente.Id1)
                Record.AddItem(objProductosCliente.Tipo1)
                Record.AddItem("") 'Nombre del pack
                Record.AddItem(objProductosCliente.FechaAdquisicion1)
                If objProductosCliente.Tipo1 = 0 Then 'Producto
                    Record.AddItem("")
                    Record.AddItem("")
                Else 'Servicio
                    Record.AddItem(objProductosCliente.FechaInicioServicio1)
                    Record.AddItem(objProductosCliente.FechaFinServicio1)
                    If (EstadoProductos = 0 And objProductosCliente.FechaFinServicio1 > Now) Then
                        EstadoProductos = 1
                    End If
                    If (objProductosCliente.FechaFinServicio1 > Now) Then
                        HayServicio = True
                    End If
                End If

                CuentoObjetos = 0
                For Each objProductos In arrayProductos
                    If objProductos.Id1 = objProductosCliente.Id_Producto1 Then
                        CuentoObjetos = 1
                        Record.AddItem(objProductos.Codigo1)
                        If HayServicio Then
                            CualProducto = CualProducto & objProductos.codigo1 & ", "
                        End If
                        Exit For
                    End If
                Next
                If CuentoObjetos = 0 Then Record.AddItem("") 'si no ha encontrado nada, tengo que meter algo
                'Record.AddItem(ObjMovimiento.ObjProducto1.Codigo1)

                CuentoObjetos = 0
                For Each objVersiones In arrayVersiones
                    If objVersiones.Id1 = objProductosCliente.Id_Version11 Then
                        CuentoObjetos = 1
                        Record.AddItem(objVersiones.Version1)
                        Exit For
                    End If
                Next
                If CuentoObjetos = 0 Then Record.AddItem("") 'si no ha encontrado nada, tengo que meter algo
                'Record.AddItem(ObjMovimiento.ObjVersion1.Version1)

                Record.AddItem(objProductosCliente.Licencia11)
                Record.AddItem(objProductosCliente.Clave11)
                Record.AddItem(objProductosCliente.Red11)
                Record.AddItem("") 'mante
                'Record.AddItem(objProductosCliente.Mante11)

                Record.AddItem("")
                Record.AddItem("")
                Record.AddItem("")
                Record.AddItem("")
                Record.AddItem("")
                Record.AddItem("")

            ElseIf objProductosCliente.Tipo1 = 2 Then 'Packs
                'Si es pack tengo que leer la tabla de packs para ver los productos que tiene el pack
                TipoPacks = True
                objPacks = ObtenerUnPack(objProductosCliente.Id_Pack1)
                Record = RCProductos.Records.Add()

                Record.AddItem(objProductosCliente.Id1)
                Record.AddItem(objProductosCliente.Tipo1)
                Record.AddItem(objPacks.Descripcion1)
                Record.AddItem(objProductosCliente.FechaAdquisicion1)

                Record.AddItem(objProductosCliente.FechaInicioServicio1)
                Record.AddItem(objProductosCliente.FechaFinServicio1)

                If (EstadoProductos = 0 And objProductosCliente.FechaFinServicio1 > Now) Then
                    EstadoProductos = 2
                End If
                If (objProductosCliente.FechaFinServicio1 > Now) Then
                    HayServicio = True
                End If

                CuentoObjetos = 0
                For Each objProductos In arrayProductos
                    If objProductos.Id1 = objPacks.IdProducto11 Then
                        CuentoObjetos = 1
                        Record.AddItem(objProductos.Codigo1)
                        If HayServicio Then
                            CualProducto = CualProducto & objProductos.codigo1 & ", "
                        End If
                        Exit For
                    End If
                Next
                If CuentoObjetos = 0 Then Record.AddItem("") 'si no ha encontrado nada, tengo que meter algo
                'Record.AddItem(ObjMovimiento.ObjProducto1.Codigo1)

                CuentoObjetos = 0
                For Each objVersiones In arrayVersiones
                    If objVersiones.Id1 = objProductosCliente.Id_Version11 Then
                        CuentoObjetos = 1
                        Record.AddItem(objVersiones.Version1)
                        Exit For
                    End If
                Next
                If CuentoObjetos = 0 Then Record.AddItem("") 'si no ha encontrado nada, tengo que meter algo
                'Record.AddItem(ObjMovimiento.ObjVersion1.Version1)

                Record.AddItem(objProductosCliente.Licencia11)
                Record.AddItem(objProductosCliente.Clave11)
                Record.AddItem(objPacks.Red11)
                Record.AddItem(objPacks.Mante11)

                If objPacks.IdProducto21 <> 0 Then
                    CuentoObjetos = 0
                    For Each objProductos In arrayProductos
                        If objProductos.Id1 = objPacks.IdProducto21 Then
                            CuentoObjetos = 1
                            Record.AddItem(objProductos.Codigo1)
                            If HayServicio Then
                                CualProducto = CualProducto & objProductos.codigo1 & ", "
                            End If
                            Exit For
                        End If
                    Next
                    If CuentoObjetos = 0 Then Record.AddItem("") 'si no ha encontrado nada, tengo que meter algo
                    'Record.AddItem(ObjMovimiento.ObjProducto1.Codigo1)

                    CuentoObjetos = 0
                    For Each objVersiones In arrayVersiones
                        If objVersiones.Id1 = objProductosCliente.Id_Version21 Then
                            CuentoObjetos = 1
                            Record.AddItem(objVersiones.Version1)
                            Exit For
                        End If
                    Next
                    If CuentoObjetos = 0 Then Record.AddItem("") 'si no ha encontrado nada, tengo que meter algo
                    'Record.AddItem(ObjMovimiento.ObjVersion1.Version1)

                    Record.AddItem(objProductosCliente.Licencia21)
                    Record.AddItem(objProductosCliente.Clave21)
                    Record.AddItem(objPacks.Red21)
                    Record.AddItem(objPacks.Mante21)

                Else
                    Record.AddItem("")
                    Record.AddItem("")
                    Record.AddItem("")
                    Record.AddItem("")
                    Record.AddItem("")
                    Record.AddItem("")
                End If

            End If

        Next

        If TipoPacks Then
            RCProductos.Columns.Find(COL_PACKP).Visible = True
            RCProductos.Columns.Find(COL_MANTEP1).Visible = True
            RCProductos.Columns.Find(COL_PRODUCTOP2).Visible = True
            RCProductos.Columns.Find(COL_VERSIONP2).Visible = True
            RCProductos.Columns.Find(COL_LICENCIAP2).Visible = True
            RCProductos.Columns.Find(COL_CLAVEP2).Visible = True
            RCProductos.Columns.Find(COL_REDP2).Visible = True
            RCProductos.Columns.Find(COL_MANTEP2).Visible = True
        Else
            RCProductos.Columns.Find(COL_PACKP).Visible = False
            RCProductos.Columns.Find(COL_MANTEP1).Visible = False
            RCProductos.Columns.Find(COL_PRODUCTOP2).Visible = False
            RCProductos.Columns.Find(COL_VERSIONP2).Visible = False
            RCProductos.Columns.Find(COL_LICENCIAP2).Visible = False
            RCProductos.Columns.Find(COL_CLAVEP2).Visible = False
            RCProductos.Columns.Find(COL_REDP2).Visible = False
            RCProductos.Columns.Find(COL_MANTEP2).Visible = False
        End If

        RCProductos.Populate()
        RCProductos.Navigator.MoveLastRow()
        If CualProducto <> "" Then
            CualProducto = Microsoft.VisualBasic.Left(CualProducto, Len(CualProducto) - 2) 'quito la ultima coma
        End If
        lblEstado.Visible = True
        If EstadoProductos = 0 Then
            lblEstado.Caption = "SIN MANTENIMIENTO"
            lblEstado.ForeColor = ColorTranslator.FromHtml("#CC0000")
        ElseIf EstadoProductos = 1 Then
            lblEstado.Caption = "MANTENIMIENTO: " & CualProducto
            lblEstado.ForeColor = ColorTranslator.FromHtml("#00AA00")
        ElseIf EstadoProductos = 2 Then
            lblEstado.Caption = "PACK: " & CualProducto
            lblEstado.ForeColor = ColorTranslator.FromHtml("#00AA00")
        End If

    End Sub

    Private Sub txtLicencia_LostFocus(sender As Object, e As EventArgs) Handles txtLicencia.LostFocus

        Dim ObjError As New Errores


        If txtLicencia.Text <> "" Then
            LimpiaPantalla()

            txtCliente.Text = ObtenerClienteDeLicencia(txtLicencia.Text)
            If txtCliente.Text = "0" Then
                txtCliente.Text = ""

                ObjError.Pantalla1 = Me
                ObjError.Tipo1 = 3 'Info

                ObjError.Titulo = "Clientes"

                ObjError.SetMensaje("No existe la Licencia " & txtLicencia.Text)

                txtLicencia.Text = ""

                ObjError.Control1 = ""
                ObjError.Pie1 = False
                ObjError.Foco1 = txtLicencia.Text

                FrmError.ObjError = ObjError
                FrmError.ShowDialog()
                If FrmError.DialogResult = DialogResult.OK Then
                    FrmError.Dispose()
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Sub LimpiaPantalla()
        RCMovimientos.Records.DeleteAll()
        RCMovimientos.Populate()
        RCProductos.Records.DeleteAll()
        RCProductos.Populate()
        RCMantenimientos.Records.DeleteAll()
        RCMantenimientos.Populate()
        lblDirDatos.Caption = ""
        lblMail.Caption = ""
        lblNComercial.Caption = ""
        lblRSocial.Caption = ""
        lblTelef1.Caption = ""
        lblTelef2.Caption = ""
        lblTelefMovil.Caption = ""
        lblUsuario.Caption = ""
        lblEstado.Visible = False

        EstadoProductos = 0

        IdClienteTarea = 0
        IdManteTarea = 0
        IdTareaActiva = 0

        LimpiarDetalle()

    End Sub

    Sub LimpiarDetalle()
        GrupoCbMedio.ListIndex = 0
        GrupoCbTipo.ListIndex = 0
        GrupoCbTema.ListIndex = 0
        GrupoCbProducto.ListIndex = 0
        GrupoCbTrabajo.ListIndex = -1
        GrupoTxtSubtrabajo.Text = ""
        GrupoTxtDonde.Text = ""
        GrupoCbAsignar.ListIndex = -1
        GrupoTxtRealizado.Text = ""
        GrupoTxtSugerido.Text = ""
        IdManteActual = 0

        PonerEstado()

    End Sub

    Sub PonerEstado()
        If EstadoRegMante = 0 Then
            lblDetalleMante.Caption = "VISUALIZACIÓN"
            lblDetalleMante.ForeColor = ColorTranslator.FromHtml("#0000AA")
        ElseIf EstadoRegMante = 1 Then
            lblDetalleMante.Caption = "EDICIÓN"
            lblDetalleMante.ForeColor = ColorTranslator.FromHtml("#CC0000")
        ElseIf EstadoRegMante = 2 Then
            lblDetalleMante.Caption = "NUEVO"
            lblDetalleMante.ForeColor = ColorTranslator.FromHtml("#00AA00")
        End If
    End Sub

    Private Sub scMovimientos_MouseUpEvent(sender As Object, e As _DShortcutCaptionEvents_MouseUpEvent) Handles scMovimientos.MouseUpEvent
        scMovimientos.Expanded = Not scMovimientos.Expanded
        Debug.Print("scMovimientos: " & Now)
        Reposiciona()
    End Sub

    Sub Reposiciona()

        Dim MiTop0 As Long
        Dim MiTop1 As Long
        Dim MiLeft As Long
        Dim MiAncho As Long
        Dim MiAlto As Long

        'Debug.Print("Reposiciona: " & Now & InicioPantalla)

        If scProductos.Expanded Then
            RCProductos.Visible = True
            RCProductos.Height = 80
        Else
            RCProductos.Visible = False
            RCProductos.Height = 0
        End If

        MiTop0 = RCProductos.Top + RCProductos.Height + 10

        scMovimientos.Top = MiTop0
        RCMovimientos.Top = MiTop0 + 29

        If scMovimientos.Expanded Then
            RCMovimientos.Visible = True
            RCMovimientos.Height = 120
        Else
            RCMovimientos.Visible = False
            RCMovimientos.Height = 0
        End If

        MiAncho = fMantenimiento.Width
        MiAlto = fMantenimiento.Height
        MiTop1 = RCMovimientos.Top + RCMovimientos.Height + 10
        MiLeft = RCMovimientos.Left

        RCTareas.Left = lblTelef1.Left + lblTelef1.Width + 20
        RCTareas.Width = MiAncho - RCTareas.Left - 20

        lblTareas.Left = RCTareas.Left

        RCMantenimientos.Left = RCMovimientos.Left
        RCMantenimientos.Width = RCMovimientos.Width
        RCMantenimientos.Top = MiTop1
        RCMantenimientos.Height = (MiAlto - MiTop1) / 2

        MiTop1 = MiTop1 + ((MiAlto - MiTop1) / 2) + 10

        GrupoLblMedio.Top = MiTop1
        GrupoLblTipo.Top = MiTop1
        GrupoLblTema.Top = MiTop1
        GrupoLblProducto.Top = MiTop1
        GrupoLblTrabajo.Top = MiTop1
        GrupoLblSubtrabajo.Top = MiTop1
        GrupoLblDonde.Top = MiTop1
        GrupoLblAsignar.Top = MiTop1
        GrupoLblMedio.Left = MiLeft
        GrupoLblTipo.Left = GrupoLblMedio.Left + 80
        GrupoLblTema.Left = GrupoLblTipo.Left + 96
        GrupoLblProducto.Left = GrupoLblTema.Left + 96
        GrupoLblTrabajo.Left = GrupoLblProducto.Left + 96
        GrupoLblSubtrabajo.Left = GrupoLblTrabajo.Left + 196
        GrupoLblDonde.Left = GrupoLblSubtrabajo.Left + 196
        GrupoLblAsignar.Left = GrupoLblDonde.Left + 126

        GrupoCbMedio.Top = MiTop1 + 24
        GrupoCbTipo.Top = MiTop1 + 24
        GrupoCbTema.Top = MiTop1 + 24
        GrupoCbProducto.Top = MiTop1 + 24
        GrupoCbTrabajo.Top = MiTop1 + 24
        GrupoTxtSubtrabajo.Top = MiTop1 + 24
        GrupoTxtDonde.Top = MiTop1 + 24
        GrupoCbAsignar.Top = MiTop1 + 24
        lblDetalleMante.Top = MiTop1 + 24
        GrupoCbMedio.Left = GrupoLblMedio.Left
        GrupoCbTipo.Left = GrupoLblTipo.Left
        GrupoCbTema.Left = GrupoLblTema.Left
        GrupoCbProducto.Left = GrupoLblProducto.Left
        GrupoCbTrabajo.Left = GrupoLblTrabajo.Left
        GrupoTxtSubtrabajo.Left = GrupoLblSubtrabajo.Left
        GrupoTxtDonde.Left = GrupoLblDonde.Left
        GrupoCbAsignar.Left = GrupoLblAsignar.Left
        lblDetalleMante.Left = GrupoCbAsignar.Left + GrupoCbAsignar.Width + 5

        GrupoLblRealizado.Top = MiTop1 + 54
        GrupoLblSugerido.Top = MiTop1 + 54
        GrupoLblRealizado.Left = MiLeft
        GrupoLblRealizado.Width = (MiAncho - MiLeft) * 2 / 3
        GrupoLblSugerido.Left = GrupoLblRealizado.Left + GrupoLblRealizado.Width + 5
        GrupoTxtRealizado.Top = MiTop1 + 78
        GrupoTxtSugerido.Top = MiTop1 + 78
        GrupoTxtRealizado.Left = GrupoLblRealizado.Left
        GrupoTxtSugerido.Left = GrupoLblSugerido.Left
        GrupoTxtRealizado.Width = GrupoLblRealizado.Width
        GrupoTxtSugerido.Width = MiAncho - GrupoTxtSugerido.Left - 20

        'btnBuscar.Top = lblNComercial.Top
        'btnBuscar.Left = (MiAncho - MiLeft) * 5 / 6
        btnBuscar.Top = MiTop1 - 5
        btnBuscar.Left = lblDetalleMante.Left

    End Sub

    Private Sub GrupoCbMedio_KeyPressEvent(sender As Object, e As _DComboBoxEvents_KeyPressEvent) Handles GrupoCbMedio.KeyPressEvent
        Retorno(e.keyAscii)
    End Sub

    Private Sub GrupoCbProducto_KeyPressEvent(sender As Object, e As _DComboBoxEvents_KeyPressEvent) Handles GrupoCbProducto.KeyPressEvent
        Retorno(e.keyAscii)
    End Sub

    Private Sub GrupoCbSubTrabajo_KeyPressEvent(sender As Object, e As _DComboBoxEvents_KeyPressEvent) Handles GrupoCbAsignar.KeyPressEvent
        Retorno(e.keyAscii)
    End Sub

    Private Sub GrupoCbTema_KeyPressEvent(sender As Object, e As _DComboBoxEvents_KeyPressEvent) Handles GrupoCbTema.KeyPressEvent
        Retorno(e.keyAscii)
    End Sub

    Private Sub GrupoCbTipo_KeyPressEvent(sender As Object, e As _DComboBoxEvents_KeyPressEvent) Handles GrupoCbTipo.KeyPressEvent
        Retorno(e.keyAscii)
    End Sub

    Private Sub GrupoCbTrabajo_KeyPressEvent(sender As Object, e As _DComboBoxEvents_KeyPressEvent) Handles GrupoCbTrabajo.KeyPressEvent
        Retorno(e.keyAscii)
    End Sub

    Private Sub GrupoTxtDonde_GotFocus(sender As Object, e As EventArgs) Handles GrupoTxtDonde.GotFocus
        GrupoTxtDonde.SelStart = 0
        GrupoTxtDonde.SelLength = Len(GrupoTxtDonde.Text)
        If IdManteActual <> 0 And EstadoRegMante = 2 Then
            'Estoy editando
            LimpiarDetalle()
        End If

    End Sub

    Private Sub GrupoTxtSubtrabajo_GotFocus(sender As Object, e As EventArgs) Handles GrupoTxtSubtrabajo.GotFocus
        GrupoTxtSubtrabajo.SelStart = 0
        GrupoTxtSubtrabajo.SelLength = Len(GrupoTxtSubtrabajo.Text)
        If IdManteActual <> 0 And EstadoRegMante = 2 Then
            'Estoy editando
            LimpiarDetalle()
        End If

    End Sub

    Private Sub GrupoTxtDonde_KeyPressEvent(sender As Object, e As _DFlatEditEvents_KeyPressEvent) Handles GrupoTxtDonde.KeyPressEvent
        Retorno(e.keyAscii)
    End Sub

    Private Sub GrupoTxtSubtrabajo_KeyPressEvent(sender As Object, e As _DFlatEditEvents_KeyPressEvent) Handles GrupoTxtSubtrabajo.KeyPressEvent
        Retorno(e.keyAscii)
    End Sub

    Private Sub GrupoTxtRealizado_KeyPressEvent(sender As Object, e As _DFlatEditEvents_KeyPressEvent) Handles GrupoTxtRealizado.KeyPressEvent
        'Con los controles multiline no funciona SendKeys
        If e.keyAscii = 13 Then
            e.keyAscii = 0
            GrupoTxtSugerido.Select()
        End If
    End Sub

    Private Sub GrupoTxtSugerido_KeyPressEvent(sender As Object, e As _DFlatEditEvents_KeyPressEvent) Handles GrupoTxtSugerido.KeyPressEvent
        'Con los controles multiline no funciona SendKeys
        If e.keyAscii = 13 Then
            e.keyAscii = 0
            'aquí tengo que grabar el registro de mante y subirlo al RC
            GrabarMantenimiento()
        End If
    End Sub

    Private Sub GrupoTxtRealizado_GotFocus(sender As Object, e As EventArgs) Handles GrupoTxtRealizado.GotFocus
        GrupoTxtRealizado.SelStart = 0
        GrupoTxtRealizado.SelLength = Len(GrupoTxtRealizado.Text)
        If IdManteActual <> 0 And EstadoRegMante = 2 Then
            'Estoy editando
            LimpiarDetalle()
        End If

    End Sub

    Private Sub GrupoTxtSugerido_GotFocus(sender As Object, e As EventArgs) Handles GrupoTxtSugerido.GotFocus
        GrupoTxtSugerido.SelStart = 0
        GrupoTxtSugerido.SelLength = Len(GrupoTxtSugerido.Text)
        If IdManteActual <> 0 And EstadoRegMante = 2 Then
            'Estoy editando
            LimpiarDetalle()
        End If

    End Sub

    Public Sub CargarCombos()

        GrupoCbAsignar.AddItem("[TERMINADO]")
        BDUsuarios.GetUsuarios(GrupoCbAsignar)
        GrupoCbAsignar.ListIndex = GrupoCbAsignar.ListCount - 1

        BDTrabajos.GetTrabajos(GrupoCbTrabajo)
    End Sub

    Private Sub scProductos_MouseUpEvent(sender As Object, e As _DShortcutCaptionEvents_MouseUpEvent) Handles scProductos.MouseUpEvent
        scProductos.Expanded = Not scProductos.Expanded
        'Debug.Print("scProductos: " & Now)
        Reposiciona()
    End Sub

    Private Sub RCMantenimientos_SelectionChanged(sender As Object, e As EventArgs) Handles RCMantenimientos.SelectionChanged
        If RCMantenimientos.FocusedRow Is Nothing Then Exit Sub
        'Debug.Print("SC:" & RCMantenimientos.FocusedRow.Record.Item(COL_FECHAM).Caption)
        EstadoRegMante = 0 'Solo visualizo
        CargarDetalleMantenimiento(RCMantenimientos.FocusedRow.Record.Item(COL_IDM).Value)


    End Sub

    Sub CargarDetalleMantenimiento(id As Long)
        IdManteActual = id

        GrupoCbMedio.Text = RCMantenimientos.FocusedRow.Record.Item(COL_MEDIOM).Caption
        GrupoCbTipo.Text = RCMantenimientos.FocusedRow.Record.Item(COL_TIPOM).Caption
        GrupoCbTema.Text = RCMantenimientos.FocusedRow.Record.Item(COL_TEMAM).Caption
        GrupoCbProducto.Text = RCMantenimientos.FocusedRow.Record.Item(COL_PRODUCTOM).Caption
        GrupoCbTrabajo.Text = RCMantenimientos.FocusedRow.Record.Item(COL_TRABAJOM).Caption
        GrupoTxtSubtrabajo.Text = RCMantenimientos.FocusedRow.Record.Item(COL_SUBTRABAJOM).Caption
        GrupoTxtDonde.Text = RCMantenimientos.FocusedRow.Record.Item(COL_DONDEM).Caption
        GrupoCbAsignar.Text = RCMantenimientos.FocusedRow.Record.Item(COL_ASIGNADOM).Caption
        GrupoTxtRealizado.Text = RCMantenimientos.FocusedRow.Record.Item(COL_REALIZADOM).Caption
        GrupoTxtSugerido.Text = RCMantenimientos.FocusedRow.Record.Item(COL_SUGERIDOM).Caption

        PonerEstado()

    End Sub

    Private Sub GrupoTxtSugerido_LostFocus(sender As Object, e As EventArgs) Handles GrupoTxtSugerido.LostFocus
        'aquí tengo que grabar el registro de mante y subirlo al RC
        'GrabarMantenimiento()

    End Sub

    Sub GrabarMantenimiento()

        Dim ObjError As New Errores

        Dim MiFecha As String

        If txtCliente.Text = "" Then Exit Sub

        If Permisos <> 2 Then
            ObjError.Pantalla1 = Me
            ObjError.Tipo1 = 1 'Avisos

            ObjError.Titulo = "Mantenimiento"

            ObjError.SetMensaje("No dispone de Permiso para Actualizar Mantenimientos")

            ObjError.Control1 = "ReportControl"
            ObjError.Pie1 = True
            ObjError.Foco1 = COL_FECHAM

            FrmError.ObjError = ObjError
            FrmError.ShowDialog()
            If FrmError.DialogResult = DialogResult.OK Then
                FrmError.Dispose()
                Exit Sub
            End If
        End If

        If EstadoRegMante = 0 Then
            ObjError.Pantalla1 = Me
            ObjError.Tipo1 = 1 'Avisos

            ObjError.Titulo = "Mantenimiento"

            ObjError.SetMensaje("No se puede grabar un Registro sin editarlo")

            ObjError.Control1 = "ReportControl"
            ObjError.Pie1 = True
            ObjError.Foco1 = COL_FECHAM

            FrmError.ObjError = ObjError
            FrmError.ShowDialog()
            If FrmError.DialogResult = DialogResult.OK Then
                FrmError.Dispose()
                IdManteActual = 0
                LimpiarDetalle()
                Exit Sub
            End If
        End If

        Dim Record As XtremeReportControl.ReportRecord
        'Dim ObjMantenimiento As Mantenimiento
        Dim objTecnicos As Usuario
        Dim TengoTecnico As Boolean
        'Dim objTecnicosAsigno As Usuario
        Dim objTrabajos As Trabajo
        Dim TengoTrabajo As Boolean

        Dim ArrayTrabajos As New ArrayList
        Dim ArrayUsuarios As New ArrayList

        ArrayTrabajos = ObtenerTodosTrabajos()
        ArrayUsuarios = ObtenerTodosUsuarios()

        Dim MiRow As ReportRow

        MiRow = RCMantenimientos.FocusedRow
        'Al convertir la fecha con Now, si tiene formato AM/PM, las 13:25 lo graba como 01:25, formato HH:mm:ss
        MiFecha = Format(Now, "dd/MM/yyyy") & " "
        MiFecha = MiFecha & Format(Now, "HH:mm:ss")

        If IdManteActual = 0 Then
            ''Al convertir la fecha con Now, si tiene formato AM/PM, las 13:25 lo graba como 01:25, formato HH:mm:ss
            'MiFecha = Format(Now, "dd/MM/yyyy") & " "
            'MiFecha = MiFecha & Format(Now, "HH:mm:ss")
            Dim objMantenimiento = New Mantenimiento(Convert.ToInt32(txtCliente.Text), Convert.ToDateTime(MiFecha), Convert.ToInt32(UsuarioId), GrupoCbMedio.Text, GrupoCbTipo.Text, GrupoCbTema.Text, GrupoCbProducto.Text, Convert.ToInt32(GrupoCbTrabajo.get_ItemData(GrupoCbTrabajo.ListIndex)), GrupoTxtSubtrabajo.Text, GrupoTxtDonde.Text, Convert.ToInt32(GrupoCbAsignar.get_ItemData(GrupoCbAsignar.ListIndex)), GrupoTxtRealizado.Text, GrupoTxtSugerido.Text)
            GuardarMantenimiento(objMantenimiento)
            IdManteActual = objMantenimiento.Id1

            If IdTareaActiva = 0 Then
                If objMantenimiento.Id_Tecnico_Asignar1 <> 0 Then 'Asignamos una nueva tarea a alguien
                    Dim objTarea = New Tarea(IdManteActual, UsuarioId, Convert.ToDateTime(MiFecha), Convert.ToInt32(GrupoCbAsignar.get_ItemData(GrupoCbAsignar.ListIndex)), Convert.ToInt32(txtCliente.Text), GrupoTxtSubtrabajo.Text, "ABIERTA")
                    GuardarTarea(objTarea)
                End If
            Else
                If objMantenimiento.Id_Tecnico_Asignar1 <> 0 Then 'reasignamos una tarea a alguien
                    Dim objTarea = New Tarea(IdTareaActiva, IdManteActual, UsuarioId, Convert.ToDateTime(MiFecha), Convert.ToInt32(GrupoCbAsignar.get_ItemData(GrupoCbAsignar.ListIndex)), Convert.ToInt32(txtCliente.Text), GrupoTxtSubtrabajo.Text, "ABIERTA")
                    ModificarTarea(objTarea)
                Else 'Cerramos una tarea asignada
                    Dim objTarea = New Tarea(IdTareaActiva, IdManteActual, UsuarioId, Convert.ToDateTime(MiFecha), Convert.ToInt32(GrupoCbAsignar.get_ItemData(GrupoCbAsignar.ListIndex)), Convert.ToInt32(txtCliente.Text), GrupoTxtSubtrabajo.Text, "CERRADA")
                    ModificarTarea(objTarea)
                End If
                CargarTareas()
            End If
            'Grabo registro en RC
            Record = RCMantenimientos.Records.Add()

            Record.AddItem(objMantenimiento.Id1)
            Record.AddItem(objMantenimiento.Fecha1)

            For Each objTecnicos In ArrayUsuarios
                If objTecnicos.Id1 = objMantenimiento.Id_Tecnico1 Then
                    TengoTecnico = True
                    Exit For
                End If
            Next
            If TengoTecnico Then
                Record.AddItem(objTecnicos.Nombre1)
            Else
                Record.AddItem("")
            End If

            Record.AddItem(objMantenimiento.Medio1)
            Record.AddItem(objMantenimiento.Tipo1)
            Record.AddItem(objMantenimiento.Tema1)
            Record.AddItem(objMantenimiento.Producto1)

            For Each objTrabajos In ArrayTrabajos
                If objTrabajos.Id1 = objMantenimiento.Id_Trabajo1 Then
                    TengoTrabajo = True
                    Exit For
                End If
            Next
            If TengoTrabajo Then
                Record.AddItem(objTrabajos.Trabajo1)
            Else
                Record.AddItem("")
            End If

            Record.AddItem(objMantenimiento.Subtrabajo1)
            Record.AddItem(objMantenimiento.Donde1)

            TengoTecnico = False
            For Each objTecnicos In ArrayUsuarios
                If objTecnicos.Id1 = objMantenimiento.Id_Tecnico_Asignar1 Then
                    TengoTecnico = True
                    Exit For
                End If
            Next
            If TengoTecnico Then
                Record.AddItem(objTecnicos.Nombre1)
            Else
                Record.AddItem("[TERMINADO]")
            End If

            Record.AddItem(objMantenimiento.Realizado1)
            Record.AddItem(objMantenimiento.Sugerido1)

        Else
            Dim MiIdTecnico As Long
            TengoTecnico = False
            For Each objTecnicos In ArrayUsuarios
                If objTecnicos.Nombre1 = MiRow.Record.Item(COL_TECNICOM).Value Then
                    TengoTecnico = True
                    Exit For
                End If
            Next
            If TengoTecnico Then
                MiIdTecnico = objTecnicos.Id1
            Else
                MiIdTecnico = 0
            End If

            Dim objMantenimiento = New Mantenimiento(Convert.ToInt32(IdManteActual), Convert.ToInt32(txtCliente.Text), Convert.ToDateTime(MiRow.Record.Item(COL_FECHAM).Caption), MiIdTecnico, GrupoCbMedio.Text, GrupoCbTipo.Text, GrupoCbTema.Text, GrupoCbProducto.Text, Convert.ToInt32(GrupoCbTrabajo.get_ItemData(GrupoCbTrabajo.ListIndex)), GrupoTxtSubtrabajo.Text, GrupoTxtDonde.Text, Convert.ToInt32(GrupoCbAsignar.get_ItemData(GrupoCbAsignar.ListIndex)), GrupoTxtRealizado.Text, GrupoTxtSugerido.Text)
            ModificarMantenimiento(objMantenimiento)

            If IdTareaActiva = 0 Then
                If objMantenimiento.Id_Tecnico_Asignar1 <> 0 Then 'Asignamos una nueva tarea a alguien
                    Dim objTarea = New Tarea(IdManteActual, UsuarioId, Convert.ToDateTime(MiFecha), Convert.ToInt32(GrupoCbAsignar.get_ItemData(GrupoCbAsignar.ListIndex)), Convert.ToInt32(txtCliente.Text), GrupoTxtSubtrabajo.Text, "ABIERTA")
                    GuardarTarea(objTarea)
                End If
            Else
                If objMantenimiento.Id_Tecnico_Asignar1 <> 0 Then 'reasignamos una tarea a alguien
                    Dim objTarea = New Tarea(IdTareaActiva, IdManteActual, UsuarioId, Convert.ToDateTime(MiFecha), Convert.ToInt32(GrupoCbAsignar.get_ItemData(GrupoCbAsignar.ListIndex)), Convert.ToInt32(txtCliente.Text), GrupoTxtSubtrabajo.Text, "ABIERTA")
                    ModificarTarea(objTarea)
                Else 'Cerramos una tarea asignada
                    Dim objTarea = New Tarea(IdTareaActiva, IdManteActual, UsuarioId, Convert.ToDateTime(MiFecha), Convert.ToInt32(GrupoCbAsignar.get_ItemData(GrupoCbAsignar.ListIndex)), Convert.ToInt32(txtCliente.Text), GrupoTxtSubtrabajo.Text, "CERRADA")
                    ModificarTarea(objTarea)
                End If
                CargarTareas()
            End If

            'aqui tengo que actualizar RC
            MiRow.Record.Item(COL_MEDIOM).Caption = GrupoCbMedio.Text
            MiRow.Record.Item(COL_TIPOM).Caption = GrupoCbTipo.Text
            MiRow.Record.Item(COL_TEMAM).Caption = GrupoCbTema.Text
            MiRow.Record.Item(COL_PRODUCTOM).Caption = GrupoCbProducto.Text
            MiRow.Record.Item(COL_TRABAJOM).Caption = GrupoCbTrabajo.Text
            MiRow.Record.Item(COL_SUBTRABAJOM).Caption = GrupoTxtSubtrabajo.Text
            MiRow.Record.Item(COL_DONDEM).Caption = GrupoTxtDonde.Text
            MiRow.Record.Item(COL_ASIGNADOM).Caption = GrupoCbAsignar.Text
            MiRow.Record.Item(COL_REALIZADOM).Caption = GrupoTxtRealizado.Text
            MiRow.Record.Item(COL_SUGERIDOM).Caption = GrupoTxtSugerido.Text
        End If

        RCMantenimientos.Populate()
        RCMantenimientos.Navigator.MoveLastRow()

        'IdManteActual = 0
        LimpiarDetalle()

        RCMantenimientos.Select()
    End Sub

    Private Sub GrupoCbMedio_GotFocus(sender As Object, e As EventArgs) Handles GrupoCbMedio.GotFocus
        If IdManteActual <> 0 And EstadoRegMante = 2 Then
            'Estoy editando
            LimpiarDetalle()
        End If
    End Sub

    Private Sub GrupoCbProducto_GotFocus(sender As Object, e As EventArgs) Handles GrupoCbProducto.GotFocus
        If IdManteActual <> 0 And EstadoRegMante = 2 Then
            'Estoy editando
            LimpiarDetalle()
        End If
    End Sub

    Private Sub GrupoCbTema_GotFocus(sender As Object, e As EventArgs) Handles GrupoCbTema.GotFocus
        If IdManteActual <> 0 And EstadoRegMante = 2 Then
            'Estoy editando
            LimpiarDetalle()
        End If
    End Sub

    Private Sub GrupoCbTipo_GotFocus(sender As Object, e As EventArgs) Handles GrupoCbTipo.GotFocus
        If IdManteActual <> 0 And EstadoRegMante = 2 Then
            'Estoy editando
            LimpiarDetalle()
        End If
    End Sub

    Private Sub GrupoCbTrabajo_GotFocus(sender As Object, e As EventArgs) Handles GrupoCbTrabajo.GotFocus
        If IdManteActual <> 0 And EstadoRegMante = 2 Then
            'Estoy editando
            LimpiarDetalle()
        End If
    End Sub

    Private Sub GrupoCbAsignar_GotFocus(sender As Object, e As EventArgs) Handles GrupoCbAsignar.GotFocus
        If IdManteActual <> 0 And EstadoRegMante = 2 Then
            'Estoy editando
            LimpiarDetalle()
        End If
    End Sub

    Private Sub RCMantenimientos_KeyDownEvent(sender As Object, e As _DReportControlEvents_KeyDownEvent) Handles RCMantenimientos.KeyDownEvent
        'If e.keyCode = 13 Or e.keyCode = 9 Then
        '    GrupoCbMedio.Select()
        'End If
    End Sub

    Private Sub RCMantenimientos_PreviewKeyDownEvent(sender As Object, e As _DReportControlEvents_PreviewKeyDownEvent) Handles RCMantenimientos.PreviewKeyDownEvent
        If e.keyCode = 13 Or e.keyCode = 9 Then
            e.keyCode = 0
            EstadoRegMante = 2 'Nuevo Mantenimiento
            GrupoCbMedio.Select()
        End If
    End Sub

    Private Sub RCMantenimientos_RowDblClick(sender As Object, e As _DReportControlEvents_RowDblClickEvent) Handles RCMantenimientos.RowDblClick
        EstadoRegMante = 1 'Edito registro
        CargarDetalleMantenimiento(RCMantenimientos.FocusedRow.Record.Item(COL_IDM).Value)

    End Sub

    Private Sub RCMantenimientos_GotFocus(sender As Object, e As EventArgs) Handles RCMantenimientos.GotFocus
        If Not IsNothing(RCMantenimientos.FocusedRow) Then
            IdManteActual = RCMantenimientos.FocusedRow.Record.Item(COL_IDM).Value
        End If
    End Sub

    Private Sub btnBuscar_ClickEvent(sender As Object, e As EventArgs) Handles btnBuscar.ClickEvent
        FrmConsultaMantenimiento.Show(Me)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        CargarTareas()
    End Sub

    Private Sub RCTareas_RowDblClick(sender As Object, e As _DReportControlEvents_RowDblClickEvent) Handles RCTareas.RowDblClick
        If Not IsNothing(RCTareas.FocusedRow) Then
            IdManteTarea = RCTareas.FocusedRow.Record.Item(COL_IDMANTET).Value
            IdClienteTarea = RCTareas.FocusedRow.Record.Item(COL_IDCLIENTET).Value
            IdTareaActiva = RCTareas.FocusedRow.Record.Item(COL_IDT).Value
            txtCliente.Text = RCTareas.FocusedRow.Record.Item(COL_IDCLIENTET).Value
            If txtCliente.Text <> "" Then
                CargarMovimientos()
                CargarProductos()
                CargarMantenimientos(IdManteTarea)
                If IdManteTarea<>0 Then
                    EstadoRegMante = 1 'Edito registro
                    CargarDetalleMantenimiento(RCMantenimientos.FocusedRow.Record.Item(COL_IDM).Value)
                    GrupoCbMedio.Select()
                End If
            End If

        End If
    End Sub
End Class