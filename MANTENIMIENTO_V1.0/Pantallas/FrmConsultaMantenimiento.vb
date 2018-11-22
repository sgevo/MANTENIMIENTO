Imports AxXtremeCommandBars
Imports AxXtremeReportControl
Imports AxXtremeShortcutBar
Imports AxXtremeSuiteControls
Imports MantEvolution.DefinicionesMenus
Imports XtremeReportControl

Public Class FrmConsultaMantenimiento

    Const COL_IDM = 0
    Const COL_FECHAM = 1
    Const COL_CLIENTEM = 2
    Const COL_TECNICOM = 3
    Const COL_MEDIOM = 4
    Const COL_TIPOM = 5
    Const COL_TEMAM = 6
    Const COL_PRODUCTOM = 7
    Const COL_TRABAJOM = 8
    Const COL_SUBTRABAJOM = 9
    Const COL_DONDEM = 10
    Const COL_ASIGNADOM = 11
    Const COL_REALIZADOM = 12
    Const COL_SUGERIDOM = 13


    Dim ArrayMantenimientos As New ArrayList()

    Dim InicioPantalla As Boolean = True

    Dim Margen As Long 'de la pantalla

    Dim Columna As ReportColumn

    Private Sub FrmConsultaMantenimiento_Load(sender As Object, e As EventArgs) Handles Me.Load

        InicioPantalla = True

        With RCMantenimientos

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

        GrupoCbTema.AddItem("[TODOS]")
        GrupoCbTema.AddItem("INCIDENCIA")
        GrupoCbTema.AddItem("CONSULTA")
        GrupoCbTema.AddItem("COMERCIAL")

        GrupoCbProducto.AddItem("[TODOS]")
        GrupoCbProducto.AddItem("WontaW")
        GrupoCbProducto.AddItem("WontaGes")
        GrupoCbProducto.AddItem("Todos")
        GrupoCbProducto.AddItem("Mante")
        GrupoCbProducto.AddItem("B.Datos")


        GrupoCbTema.ListIndex = 0
        GrupoCbProducto.ListIndex = 0
        '        GrupoCbTrabajo.ListIndex = 0

        'fMantenimiento = Me
    End Sub

    Sub CargarColumnasReport()

        RCMantenimientos.PaintManager.ColumnStyle = XTPReportColumnStyle.xtpColumnResource

        RCMantenimientos.AllowEdit = False

        RCMantenimientos.Columns.Add(COL_IDM, "Id", 100, True)
        RCMantenimientos.Columns.Add(COL_FECHAM, "Fecha/Hora", 110, True)
        RCMantenimientos.Columns.Add(COL_CLIENTEM, "Cliente", 70, True)
        RCMantenimientos.Columns.Add(COL_TECNICOM, "Técnico", 70, True)
        RCMantenimientos.Columns.Add(COL_MEDIOM, "Medio", 70, True)
        RCMantenimientos.Columns.Add(COL_TIPOM, "Tipo", 70, True)
        RCMantenimientos.Columns.Add(COL_TEMAM, "Tema", 70, True)
        RCMantenimientos.Columns.Add(COL_PRODUCTOM, "Producto", 70, True)
        RCMantenimientos.Columns.Add(COL_TRABAJOM, "Trabajo", 160, True)
        RCMantenimientos.Columns.Add(COL_SUBTRABAJOM, "Subtrabajo", 160, True)
        RCMantenimientos.Columns.Add(COL_DONDEM, "Donde", 80, True)
        RCMantenimientos.Columns.Add(COL_ASIGNADOM, "Asignado", 70, True)
        RCMantenimientos.Columns.Add(COL_REALIZADOM, "Realizado", 140, True)
        RCMantenimientos.Columns.Add(COL_SUGERIDOM, "Sugerido", 60, True)

        RCMantenimientos.Columns.Find(COL_MEDIOM).Visible = False
        RCMantenimientos.Columns.Find(COL_TIPOM).Visible = False
        '        RCMantenimientos.Columns.Find(COL_REALIZADOM).Visible = False
        RCMantenimientos.Columns.Find(COL_SUGERIDOM).Visible = False
        RCMantenimientos.Columns.Find(COL_IDM).Visible = False

    End Sub

    Private Sub FrmConsultaMantenimiento_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        'ConstruirMenu()
        If InicioPantalla Then
            'Debug.Print("Activated2: " & Now)
            Reposiciona()
            CargarCombos()
            InicioPantalla = False
        End If
    End Sub

    Sub Reposiciona()

        Dim MiTop0 As Long
        Dim MiTop1 As Long
        Dim MiLeft As Long
        Dim MiAncho As Long
        Dim MiAlto As Long

        'MiTop0 = RCMantenimientos.Top + RCMantenimientos.Height + 10

        MiAncho = Me.Width
        MiAlto = Me.Height

        gbTodo.Width = MiAncho - 4
        gbTodo.Height = MiAlto - 4
        gbTodo.Left = 2
        gbTodo.Top = 2


        MiTop1 = Titulo.Top + Titulo.Height + 10
        MiLeft = RCMantenimientos.Left

        btnBuscar.Top = MiTop1
        btnBuscar.Left = (MiAncho - MiLeft) * 4 / 5
        btnSalir.Top = MiTop1
        btnSalir.Left = btnBuscar.Left + btnBuscar.Width + 20



        '        RCMantenimientos.Top = MiTop1
        '        RCMantenimientos.Height = (MiAlto - MiTop1) / 2

        'MiTop1 = MiTop1 + ((MiAlto - MiTop1) / 2) + 10

        RCMantenimientos.Visible = True
        RCMantenimientos.Height = 300

        GrupoLblTema.Top = MiTop1
        GrupoLblProducto.Top = MiTop1
        GrupoLblTrabajo.Top = MiTop1
        GrupoLblSubtrabajo.Top = MiTop1
        GrupoLblDonde.Top = MiTop1
        GrupoLblTema.Left = MiLeft
        GrupoLblProducto.Left = GrupoLblTema.Left + 96
        GrupoLblTrabajo.Left = GrupoLblProducto.Left + 96
        GrupoLblSubtrabajo.Left = GrupoLblTrabajo.Left + 196
        GrupoLblDonde.Left = GrupoLblSubtrabajo.Left + 196
        GrupoCbTema.Top = MiTop1 + 24
        GrupoCbProducto.Top = MiTop1 + 24
        GrupoCbTrabajo.Top = MiTop1 + 24
        GrupoTxtSubtrabajo.Top = MiTop1 + 24
        GrupoTxtDonde.Top = MiTop1 + 24
        GrupoCbTema.Left = GrupoLblTema.Left
        GrupoCbProducto.Left = GrupoLblProducto.Left
        GrupoCbTrabajo.Left = GrupoLblTrabajo.Left
        GrupoTxtSubtrabajo.Left = GrupoLblSubtrabajo.Left
        GrupoTxtDonde.Left = GrupoLblDonde.Left

        GrupoLblRealizado.Top = RCMantenimientos.Top + RCMantenimientos.Height + 30
        GrupoLblRealizado.Left = MiLeft
        GrupoLblRealizado.Width = (MiAncho - MiLeft) * 2 / 3
        GrupoTxtRealizado.Top = GrupoLblRealizado.Top + 24
        GrupoTxtRealizado.Left = GrupoLblRealizado.Left
        GrupoTxtRealizado.Width = RCMantenimientos.Width

    End Sub

    Public Sub CargarCombos()

        'GrupoCbAsignar.AddItem("[TERMINADO]")
        'BDUsuarios.GetUsuarios(GrupoCbAsignar)
        'GrupoCbAsignar.ListIndex = GrupoCbAsignar.ListCount - 1

        BDTrabajos.GetTrabajosTodos(GrupoCbTrabajo)
        GrupoCbTrabajo.ListIndex = 0
    End Sub

    Sub ConfigurarPantalla()

        'Debug.Print("ConfigurarPantalla: " & Now)

        Margen = 20 ''a partir de este valor se define todo

        'btnSalir.Icon  = MDIPrincipal.ImageManager.Icons.GetImage(103, 32)
        Titulo.Top = 0
        Titulo.Left = 0
        Titulo.Width = Me.Width

        RCMantenimientos.Top = Titulo.Top + Titulo.Height + 80
        RCMantenimientos.Left = Margen
        RCMantenimientos.Width = Me.Width - Margen - 20

    End Sub

    Public Sub AplicaEstilo()

        Dim X As Object

        For Each X In Me.Controls
            AplicaEstiloControl(X)
        Next X

    End Sub

    Private Sub FrmConsultaMantenimiento_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        ConfigurarPantalla()
        If Not InicioPantalla Then
            'Debug.Print("Resize2: " & Now & InicioPantalla)
            Reposiciona()
        End If
    End Sub

    Private Sub btnSalir_ClickEvent(sender As Object, e As EventArgs) Handles btnSalir.ClickEvent
        Me.Dispose()
    End Sub

    Private Sub GrupoTxtDonde_KeyPressEvent(sender As Object, e As _DFlatEditEvents_KeyPressEvent) Handles GrupoTxtDonde.KeyPressEvent
        Retorno(e.keyAscii)
    End Sub

    Private Sub GrupoTxtSubtrabajo_KeyPressEvent(sender As Object, e As _DFlatEditEvents_KeyPressEvent) Handles GrupoTxtSubtrabajo.KeyPressEvent
        Retorno(e.keyAscii)
    End Sub

    Private Sub GrupoCbTrabajo_KeyPressEvent(sender As Object, e As _DComboBoxEvents_KeyPressEvent) Handles GrupoCbTrabajo.KeyPressEvent
        Retorno(e.keyAscii)
    End Sub

    Private Sub GrupoCbTema_KeyPressEvent(sender As Object, e As _DComboBoxEvents_KeyPressEvent) Handles GrupoCbTema.KeyPressEvent
        Retorno(e.keyAscii)
    End Sub

    Private Sub GrupoCbProducto_KeyPressEvent(sender As Object, e As _DComboBoxEvents_KeyPressEvent) Handles GrupoCbProducto.KeyPressEvent
        Retorno(e.keyAscii)
    End Sub

    Sub CargarMantenimientos()

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

        Dim Texto As String

        Texto = ""

        If GrupoCbTema.ListIndex > 0 Then
            Texto = Texto & "Tema Like '%" & GrupoCbTema.Text & "%' AND "
        End If
        If GrupoCbProducto.ListIndex > 0 Then
            Texto = Texto & "Producto Like '%" & GrupoCbProducto.Text & "%' AND "
        End If
        If GrupoCbTrabajo.ListIndex > 0 Then
            Texto = Texto & "Idtrabajo =" & Convert.ToInt32(GrupoCbTrabajo.get_ItemData(GrupoCbTrabajo.ListIndex)) & " AND "
        End If
        If GrupoTxtSubtrabajo.Text <> "" Then
            'Texto = Texto & "Subtrabajo Like '" & GrupoTxtSubtrabajo.Text & "' AND "
            Texto = Texto & "Subtrabajo Like '%" & GrupoTxtSubtrabajo.Text & "%' AND "

        End If

        If Len(Texto) > 0 Then
            Texto = Microsoft.VisualBasic.Left(Texto, Len(Texto) - 4)
        End If

        RCMantenimientos.Records.DeleteAll()
        TengoTecnico = False
        TengoTrabajo = False

        'If IsNothing(objCliente) Then Exit Sub

        'Debug.Print("Mantes 01:" & Now)
        ArrayMantenimientos = SeleccionarMantenimientos(Texto)
        'ArrayMantenimientos = SeleccionarMantenimientosA(Texto)

        'ArrayMantenimientos = SeleccionarMantenimientosX(Texto)
        'Debug.Print("Mantes 02:" & Now)

        ArrayTrabajos = ObtenerTodosTrabajos()
        ArrayUsuarios = ObtenerTodosUsuarios()
        Debug.Print("Mantes 03:" & Now & "-" & ArrayMantenimientos.Count)

        For Each ObjMantenimiento In ArrayMantenimientos

            Record = RCMantenimientos.Records.Add()

            Record.AddItem(ObjMantenimiento.Id1)
            Record.AddItem(ObjMantenimiento.Fecha1)
            Record.AddItem(ObjMantenimiento.Id_Cliente1)

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

        Debug.Print("Mantes 04:" & Now)

        RCMantenimientos.Populate()
        Columna = RCMantenimientos.Columns.Find(COL_FECHAM)

        OrdenarReport(RCMantenimientos, Columna, 1)

        RCMantenimientos.Navigator.MoveLastRow()
        Debug.Print("Mantes 05:" & Now)

    End Sub

    Private Sub btnBuscar_ClickEvent(sender As Object, e As EventArgs) Handles btnBuscar.ClickEvent
        CargarMantenimientos()
    End Sub

    Private Sub RCMantenimientos_SelectionChanged(sender As Object, e As EventArgs) Handles RCMantenimientos.SelectionChanged
        If RCMantenimientos.FocusedRow Is Nothing Then Exit Sub
        GrupoTxtRealizado.Text = RCMantenimientos.FocusedRow.Record.Item(COL_REALIZADOM).Value
    End Sub

    Private Sub btnBuscar_KeyPressEvent(sender As Object, e As _DBackstageButtonEvents_KeyPressEvent) Handles btnBuscar.KeyPressEvent
        If e.keyAscii = 13 Then
            CargarMantenimientos()
        End If
    End Sub
End Class