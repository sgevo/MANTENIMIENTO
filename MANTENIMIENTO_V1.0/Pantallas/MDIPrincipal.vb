
Imports MantEvolution.DefinicionesMenus
Imports AxXtremeCommandBars
Imports System.Windows

Public Class MDIPrincipal

    Dim TabPrincipal As XtremeCommandBars.RibbonTab = Nothing
    Dim TabMaestros As XtremeCommandBars.RibbonTab = Nothing
    Dim TabVentas As XtremeCommandBars.RibbonTab = Nothing
    Dim TabFacturacion As XtremeCommandBars.RibbonTab = Nothing
    Dim TabEstadisticas As XtremeCommandBars.RibbonTab = Nothing
    Dim TabInformes As XtremeCommandBars.RibbonTab = Nothing
    Dim GroupFile As XtremeCommandBars.RibbonGroup = Nothing
    Dim GroupClipboard As XtremeCommandBars.RibbonGroup = Nothing
    Dim GroupEditing As XtremeCommandBars.RibbonGroup = Nothing
    Dim GroupShowHide As XtremeCommandBars.RibbonGroup = Nothing
    Dim GroupDocumentViews As XtremeCommandBars.RibbonGroup = Nothing
    Dim GroupWindow As XtremeCommandBars.RibbonGroup = Nothing
    Dim GroupPrint As XtremeCommandBars.RibbonGroup = Nothing
    Dim GroupPageSetup As XtremeCommandBars.RibbonGroup = Nothing
    Dim GroupZoom As XtremeCommandBars.RibbonGroup = Nothing
    Dim GroupPreview As XtremeCommandBars.RibbonGroup = Nothing
    Dim ControlSaveAs As XtremeCommandBars.CommandBarPopup = Nothing
    Dim ControlPrint As XtremeCommandBars.CommandBarPopup = Nothing
    Dim Control As XtremeCommandBars.CommandBarControl = Nothing
    Dim ControlPaste As XtremeCommandBars.CommandBarPopup = Nothing
    Dim ControlSelect As XtremeCommandBars.CommandBarPopup = Nothing
    Dim ControlPopup As XtremeCommandBars.CommandBarPopup = Nothing
    Dim ControlMargins As XtremeCommandBars.CommandBarPopup = Nothing
    Dim ControlOrientation As XtremeCommandBars.CommandBarPopup = Nothing
    Dim ControlSize As XtremeCommandBars.CommandBarPopup = Nothing
    Dim ControlOptions As XtremeCommandBars.CommandBarPopup = Nothing

    Public RibbonBar As XtremeCommandBars.RibbonBar = Nothing

    Public CommandBarsGlobalSettings As XtremeCommandBars.CommandBarsGlobalSettings
    ' Public WithEvents CommandBars As AxXtremeCommandBars.AxCommandBars
    Public ControlFile As XtremeCommandBars.CommandBarPopup

    Public BackstageView As XtremeCommandBars.RibbonBackstageView

    Public ID_THEME_CURRENT As Integer

    Public WithEvents Workspace As XtremeCommandBars.TabWorkspace

    Private Sub MDIPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CommandBarsGlobalSettings = New XtremeCommandBars.CommandBarsGlobalSettings
        CommandBarsGlobalSettings.ResourceImages.LoadFromFile(GetFolderPath("Styles") + "Office2013.dll", "Office2013White.ini")


        RibbonBar = CommandBars.AddRibbonBar("La Barra")
        RibbonBar.EnableDocking(XtremeCommandBars.XTPToolBarFlags.xtpFlagStretched)
        CommandBars.VisualTheme = XtremeCommandBars.XTPVisualTheme.xtpThemeOffice2013

        ControlOptions = RibbonBar.Controls.Add(XtremeCommandBars.XTPControlType.xtpControlPopup, 0, "Opciones", -1, False)
        ControlOptions.Flags = XtremeCommandBars.XTPControlFlags.xtpFlagRightAlign

        ControlPopup = ControlOptions.CommandBar.Controls.Add(XtremeCommandBars.XTPControlType.xtpControlPopup, 0, "Estilos", -1, False)
        ControlPopup.CommandBar.Controls.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.STYLEBLUE, "Office 2007 Blue", -1, False)
        ControlPopup.CommandBar.Controls.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.STYLEBLACK, "Office 2007 Black", -1, False)
        ControlPopup.CommandBar.Controls.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.STYLESILVER, "Office 2007 Silver", -1, False)
        ControlPopup.CommandBar.Controls.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.STYLEAQUA, "Office 2007 Aqua", -1, False)
        ControlPopup.CommandBar.Controls.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.STYLEOFFICE2010SILVER, "Office 2010 Silver", -1, False)
        ControlPopup.CommandBar.Controls.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.STYLEOFFCIE2010BLUE, "Office 2010 Blue", -1, False)
        ControlPopup.CommandBar.Controls.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.STYLEOFFCIE2010BLACK, "Office 2010 Black", -1, False)
        ControlPopup.CommandBar.Controls.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.STYLESCENIC, "Windows 7 Scenic", -1, False)
        ControlPopup.CommandBar.Controls.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.STYLEOFFCIE2013WHITE, "Office 2013", -1, False)
        ControlPopup.CommandBar.Controls.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.STYLESYSTEM, "System Theme", -1, False)

        '' CommandBars.EnableCustomization((True))

        ConstruirMenu()

        CommandBars.ShowTabWorkspace(True)
        ''
        'Con esto pone de fondo la imagen que se ponga en MDIPpal.Picture
        'CommandBars.TabWorkspace.ThemedBackColor = False

        Dim ctrl As Control 'Esto necesario para que salga el menu cuando es MDI
        For Each ctrl In Controls
            If (ctrl.GetType Is GetType(System.Windows.Forms.MdiClient)) Then
                CommandBars.SetMDIClient(ctrl.Handle.ToInt32)
            End If
        Next

        CommandBars.TabWorkspace.PaintManager.ShowTabs = True
        Workspace = CommandBars.ShowTabWorkspace(True)
        Workspace.EnableGroups()
        Workspace.Flags = XtremeCommandBars.XTPWorkspaceButtons.xtpWorkspaceShowCloseTab

        CommandBars.EnableCustomization(True)
        CommandBars.StatusBar.Visible = True

        'Con esto coje los iconos para el menu, el Id del imagemanager es el del campo del menu en el commandbars
        CommandBars.Icons = ImageManager.Icons

        Me.Text = "Sistema de Gestión Integrada   -   " & UsuarioNombre
        UsuarioGrupo = GetGrupo(UsuarioId) 'Este es el Grupo del usuario, y me marca los permisos que tiene en cada pantalla



    End Sub

    Function GetFolderPath(ByVal strFolder As String) As String
        Dim strExePath As String
        strExePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath)

        If (System.IO.Directory.Exists(strExePath + "\\..\\..\\..\\..\\" + strFolder)) Then Return strExePath + "\\..\\..\\..\\..\\" + strFolder + "\\"

        If (System.IO.Directory.Exists(strExePath + "\\..\\..\\..\\..\\..\\" + strFolder)) Then Return strExePath + "\\..\\..\\..\\..\\..\\" + strFolder + "\\"

        If (System.IO.Directory.Exists(strExePath + "\\..\\..\\..\\..\\..\\..\\" + strFolder)) Then Return strExePath + "\\..\\..\\..\\..\\..\\..\\" + strFolder + "\\"

        Return strExePath + "\\..\\..\\..\\" + strFolder + "\\"
    End Function

    Sub ConstruirMenu()

        TabPrincipal = RibbonBar.InsertTab(DEFMENU.TAB_PRINCIPAL, "&Principal")
        TabPrincipal.Id = DEFMENU.TAB_PRINCIPAL

        GroupFile = TabPrincipal.Groups.AddGroup("&MANTE", DEFMENU.GRUPO_PRINCIPAL)
        GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.PRINCIPAL_MANTENIMIENTO, "Mantenimiento", False, False)
        GroupFile = TabPrincipal.Groups.AddGroup("&SALIR", 1002)
        GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.PRINCIPAL_SALIR, "Salir", False, False)

        TabMaestros = RibbonBar.InsertTab(DEFMENU.TAB_MAESTROS, "&Maestros")
        TabMaestros.Id = DEFMENU.TAB_MAESTROS
        GroupFile = TabMaestros.Groups.AddGroup("&SEGURIDAD", 1101)
        GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_GRUPOS, "Grupos", False, False).IconId = 20
        GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_USUARIOS, "Usuarios", False, False).IconId = 21
        GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_PERMISOS, "Permisos", False, False).IconId = 27
        GroupFile = TabMaestros.Groups.AddGroup("&PRODUCTOS", 1102)
        GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_PRODUCTOS, "Productos", False, False).IconId = 22
        GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_VERSIONES, "Versiones", False, False).IconId = 23
        GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_PACKS, "Packs", False, False).IconId = 24
        GroupFile = TabMaestros.Groups.AddGroup("&CLIENTES", 1103)
        GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_ASESORES, "Asesores", False, False).IconId = 25
        GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_CLIENTES, "Clientes", False, False).IconId = 26
        GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_FPAGO, "Formas Pago", False, False).IconId = 28

        TabVentas = RibbonBar.InsertTab(DEFMENU.TAB_VENTAS, "&Ventas")
        TabVentas.Id = DEFMENU.TAB_VENTAS
        GroupFile = TabVentas.Groups.AddGroup("&TARIFAS", 1201)
        GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.VENTAS_TARIFAS, "Tarifas", False, False).IconId = 30
        GroupFile = TabVentas.Groups.AddGroup("&VENTAS", 1202)
        GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.VENTAS_PEDIDOS_FICHERO, "Pedidos", False, False).IconId = 31
        GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.VENTAS_FACTURAS_FICHERO, "Facturas", False, False).IconId = 32
        GroupFile = TabVentas.Groups.AddGroup("&CARTERA", 1203)
        GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.VENTAS_VENCIMIENTOS, "Vencimientos", False, False).IconId = 33
        GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.VENTAS_REMESAS, "Remesas", False, False).IconId = 34

        TabFacturacion = RibbonBar.InsertTab(DEFMENU.TAB_FACTURACION, "&Facturación")
        TabFacturacion.Id = DEFMENU.TAB_FACTURACION
        GroupFile = TabFacturacion.Groups.AddGroup("&FACTURAR", 1301)
        GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.FACTURAR_PEDIDOS, "Pedidos", False, False).IconId = 40
        GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.FACTURAR_MANTES, "Mantenimientos", False, False).IconId = 41
        'GroupFile = TabFacturacion.Groups.AddGroup("&RECIBOS", 1302)
        'GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.FACTURAR_RECIBOS, "Recibos", False, False)

        TabEstadisticas = RibbonBar.InsertTab(DEFMENU.TAB_ESTADISTICAS, "&Estadísticas")
        TabEstadisticas.Id = DEFMENU.TAB_ESTADISTICAS
        GroupFile = TabEstadisticas.Groups.AddGroup("&ESTADISTICA", 1401)
        GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.ESTADIS_LLAMADAS, "Llamadas", False, False).IconId = 50
        GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.ESTADIS_EOAF, "EOAF", False, False).IconId = 51
        GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.ESTADIS_VENTAS, "Ventas", False, False).IconId = 52
        GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.ESTADIS_MOROSOS, "Morosos", False, False).IconId = 53

        TabInformes = RibbonBar.InsertTab(DEFMENU.TAB_INFORMES, "&Informes")
        TabInformes.Id = DEFMENU.TAB_INFORMES
        GroupFile = TabInformes.Groups.AddGroup("&ETIQUETAS", 1501)
        GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.INFORMES_ETITRANSPORTE, "Transporte", False, False).IconId = 60
        GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.INFORMES_ETICLIENTES, "Clientes", False, False).IconId = 61
        GroupFile = TabInformes.Groups.AddGroup("&CARTAS", 1502)
        GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.INFORMES_CARTASMANTE, "Mantenimientos", False, False).IconId = 62

    End Sub

    Private Sub CommandBars_Execute(sender As Object, eventArgs As _DCommandBarsEvents_ExecuteEvent) Handles CommandBars.Execute

        Dim ObjError As New Errores 'Pantalla de mensajes
        Dim ElPermiso As Long
        ElPermiso = 2

        Select Case eventArgs.control.Id
            Case CInt(XtremeCommandBars.XTPCommandBarsSpecialCommands.XTP_ID_RIBBONCUSTOMIZE)
                CommandBars.ShowCustomizeDialog(3)
           ' Case ID.ID_APP_ABOUT
           '   '  CommandBars.ShowAboutBox()
           ' Case ID.ID_FILE_NEW
           '     'Form2.ParentForm. = Me
           '     ''  Form2.MdiParent = Me
           '     ''Form2.Activate()
           '     ''Form2.Enabled = True
           '     'Form2.Show()
           '     '  Form3.Parent = Me
           '     Dim Form2 As FrmIvas = New FrmIvas With {
           '         .MdiParent = Me
           '     }
           '     ''frmDocument.MdiParent.Enabled = True
           '     Form2.Show()
           '     ''frmDocument.CreateControl()
           '     'Form3.Show()
           '     'Me.Refresh()
           '     ''Dim frmDocument As Form2 = New Form2
           '     'frmDocument.MdiParent = Me 'Para que salga en forma de pestañas
           '     'frmDocument.Show()
           '     '   MenuClientes()
           '  '   LoadNewDoc()

            Case DEFMENU.MAESTROS_FPAGO


                Dim Form2 As FrmFormasPagos = New FrmFormasPagos With {
                      .MdiParent = Me}

                Form2.Show()

            Case DEFMENU.VENTAS_PEDIDOS_FICHERO
                Dim Form2 As FrmPedidosFichero = New FrmPedidosFichero With {
              .MdiParent = Me}
                Form2.Show()
                Form2.cbAños.ListIndex = 0

            Case DEFMENU.VENTAS_PEDIDOS_FICHERO_AÑADIR
                fPedidosFichero.Nuevo()


            Case DEFMENU.MAESTROS_GRUPOS
                Select Case ObtenerPermisosPantalla(ObtenerIdUnaPantalla(eventArgs.control.Id), UsuarioGrupo)
                    Case 0
                        ElPermiso = 0
                        ObjError.Pantalla1 = Me
                        ObjError.Tipo1 = 1 'Avisos
                        ObjError.Titulo = "SEGURIDAD"
                        ObjError.SetMensaje("No tiene Permiso para acceder a esta pantalla.")
                        ObjError.Control1 = ""
                        ObjError.Pie1 = False
                        ObjError.Foco1 = 0
                        FrmError.ObjError = ObjError
                        FrmError.ShowDialog()
                        If FrmError.DialogResult = DialogResult.OK Then
                            FrmError.Dispose()
                            Exit Sub
                        End If
                    Case 1
                        ElPermiso = 1
                        ObjError.Pantalla1 = Me
                        ObjError.Tipo1 = 3 'Avisos
                        ObjError.Titulo = "SEGURIDAD"
                        ObjError.SetMensaje("No tiene Permiso para realizar cambios en esta pantalla.")
                        ObjError.Control1 = ""
                        ObjError.Pie1 = False
                        ObjError.Foco1 = 0
                        FrmError.ObjError = ObjError
                        FrmError.ShowDialog()
                        If FrmError.DialogResult = DialogResult.OK Then
                            FrmError.Dispose()
                        End If
                End Select

                If Not fGrupos Is Nothing Then
                    CommandBars.TabWorkspace.FindItem(fGrupos.Handle).Selected = True
                    Exit Sub
                End If

                Dim Form2 As FrmGrupos = New FrmGrupos With {
                   .MdiParent = Me}

                Form2.Permisos = ElPermiso
                Form2.Show()

            Case DEFMENU.MAESTROS_GRUPOS_NUEVO
                If Not fGrupos Is Nothing Then
                    fGrupos.Menu_Nuevo()
                End If
            Case DEFMENU.MAESTROS_GRUPOS_ELIMINAR

                If Not fGrupos Is Nothing Then
                    fGrupos.Menu_Eliminar()
                End If
            Case DEFMENU.MAESTROS_GRUPOS_IMPRIMIR
                If Not fGrupos Is Nothing Then
                    fGrupos.Menu_Imprimir()
                End If
            Case DEFMENU.MAESTROS_GRUPOS_SALIR
                If Not fGrupos Is Nothing Then
                    fGrupos.Close()
                End If

            Case DEFMENU.MAESTROS_USUARIOS
                Select Case ObtenerPermisosPantalla(ObtenerIdUnaPantalla(eventArgs.control.Id), UsuarioGrupo)
                    Case 0
                        ElPermiso = 0
                        ObjError.Pantalla1 = Me
                        ObjError.Tipo1 = 1 'Avisos
                        ObjError.Titulo = "SEGURIDAD"
                        ObjError.SetMensaje("No tiene Permiso para acceder a esta pantalla.")
                        ObjError.Control1 = ""
                        ObjError.Pie1 = False
                        ObjError.Foco1 = 0
                        FrmError.ObjError = ObjError
                        FrmError.ShowDialog()
                        If FrmError.DialogResult = DialogResult.OK Then
                            FrmError.Dispose()
                            Exit Sub
                        End If
                    Case 1
                        ElPermiso = 1
                        ObjError.Pantalla1 = Me
                        ObjError.Tipo1 = 3 'Avisos
                        ObjError.Titulo = "SEGURIDAD"
                        ObjError.SetMensaje("No tiene Permiso para realizar cambios en esta pantalla.")
                        ObjError.Control1 = ""
                        ObjError.Pie1 = False
                        ObjError.Foco1 = 0
                        FrmError.ObjError = ObjError
                        FrmError.ShowDialog()
                        If FrmError.DialogResult = DialogResult.OK Then
                            FrmError.Dispose()
                        End If
                End Select

                'If Not (EstableceAccesoSinMsg(ID_BANCOS)) Then
                '    MessageBox Me.hWnd, "Acceso no permitido. Consulte con su Administrador", Me.Caption, vbOKOnly + vbCritical
                '    Exit Sub
                'End If

                If Not fUsuarios Is Nothing Then
                    CommandBars.TabWorkspace.FindItem(fUsuarios.Handle).Selected = True
                    Exit Sub
                End If

                Dim Form2 As FrmUsuarios = New FrmUsuarios With {
                       .MdiParent = Me}
                Form2.Permisos = ElPermiso
                Form2.Show()
                Form2.CargarComboGrupos()'Esto hay que cargarlo desde fuera, porque si no no va

            Case DEFMENU.MAESTROS_USUARIOS_NUEVO
                If Not fUsuarios Is Nothing Then
                    fUsuarios.Menu_Nuevo()
                End If
            Case DEFMENU.MAESTROS_USUARIOS_ELIMINAR

                If Not fUsuarios Is Nothing Then
                    fUsuarios.Menu_Eliminar()
                End If
            Case DEFMENU.MAESTROS_USUARIOS_IMPRIMIR
                If Not fUsuarios Is Nothing Then
                    fUsuarios.Menu_Imprimir()
                End If
            Case DEFMENU.MAESTROS_USUARIOS_SALIR
                If Not fUsuarios Is Nothing Then
                    fUsuarios.Close()
                End If


            Case DEFMENU.MAESTROS_PERMISOS

                Select Case ObtenerPermisosPantalla(ObtenerIdUnaPantalla(eventArgs.control.Id), UsuarioGrupo)
                    Case 0
                        ElPermiso = 0
                        ObjError.Pantalla1 = Me
                        ObjError.Tipo1 = 1 'Avisos
                        ObjError.Titulo = "SEGURIDAD"
                        ObjError.SetMensaje("No tiene Permiso para acceder a esta pantalla.")
                        ObjError.Control1 = ""
                        ObjError.Pie1 = False
                        ObjError.Foco1 = 0
                        FrmError.ObjError = ObjError
                        FrmError.ShowDialog()
                        If FrmError.DialogResult = DialogResult.OK Then
                            FrmError.Dispose()
                            Exit Sub
                        End If
                    Case 1
                        ElPermiso = 1
                        ObjError.Pantalla1 = Me
                        ObjError.Tipo1 = 3 'Avisos
                        ObjError.Titulo = "SEGURIDAD"
                        ObjError.SetMensaje("No tiene Permiso para realizar cambios en esta pantalla.")
                        ObjError.Control1 = ""
                        ObjError.Pie1 = False
                        ObjError.Foco1 = 0
                        FrmError.ObjError = ObjError
                        FrmError.ShowDialog()
                        If FrmError.DialogResult = DialogResult.OK Then
                            FrmError.Dispose()
                        End If
                End Select

                'If Not (EstableceAccesoSinMsg(ID_BANCOS)) Then
                '    MessageBox Me.hWnd, "Acceso no permitido. Consulte con su Administrador", Me.Caption, vbOKOnly + vbCritical
                '    Exit Sub
                'End If

                If Not fPermisos Is Nothing Then
                    CommandBars.TabWorkspace.FindItem(fPermisos.Handle).Selected = True
                    Exit Sub
                End If

                Dim Form2 As FrmPermisos = New FrmPermisos With {
                       .MdiParent = Me}
                Form2.Permisos = ElPermiso
                Form2.Show()

            Case DEFMENU.MAESTROS_PERMISOS_IMPRIMIR
                If Not fPermisos Is Nothing Then
                    fPermisos.Menu_Imprimir()
                End If
            Case DEFMENU.MAESTROS_PERMISOS_SALIR
                If Not fPermisos Is Nothing Then
                    fPermisos.Close()
                End If


            Case DEFMENU.MAESTROS_PRODUCTOS
                Select Case ObtenerPermisosPantalla(ObtenerIdUnaPantalla(eventArgs.control.Id), UsuarioGrupo)
                    Case 0
                        ElPermiso = 0
                        ObjError.Pantalla1 = Me
                        ObjError.Tipo1 = 1 'Avisos
                        ObjError.Titulo = "SEGURIDAD"
                        ObjError.SetMensaje("No tiene Permiso para acceder a esta pantalla.")
                        ObjError.Control1 = ""
                        ObjError.Pie1 = False
                        ObjError.Foco1 = 0
                        FrmError.ObjError = ObjError
                        FrmError.ShowDialog()
                        If FrmError.DialogResult = DialogResult.OK Then
                            FrmError.Dispose()
                            Exit Sub
                        End If
                    Case 1
                        ElPermiso = 1
                        ObjError.Pantalla1 = Me
                        ObjError.Tipo1 = 3 'Avisos
                        ObjError.Titulo = "SEGURIDAD"
                        ObjError.SetMensaje("No tiene Permiso para realizar cambios en esta pantalla.")
                        ObjError.Control1 = ""
                        ObjError.Pie1 = False
                        ObjError.Foco1 = 0
                        FrmError.ObjError = ObjError
                        FrmError.ShowDialog()
                        If FrmError.DialogResult = DialogResult.OK Then
                            FrmError.Dispose()
                        End If
                End Select

                'If Not (EstableceAccesoSinMsg(ID_BANCOS)) Then
                '    MessageBox Me.hWnd, "Acceso no permitido. Consulte con su Administrador", Me.Caption, vbOKOnly + vbCritical
                '    Exit Sub
                'End If

                If Not fProductos Is Nothing Then
                    CommandBars.TabWorkspace.FindItem(fProductos.Handle).Selected = True
                    Exit Sub
                End If

                Dim Form2 As FrmProductos = New FrmProductos With {
                       .MdiParent = Me}
                Form2.Permisos = ElPermiso
                Form2.Show()

            Case DEFMENU.MAESTROS_PRODUCTOS_NUEVO
                If Not fProductos Is Nothing Then
                    fProductos.Menu_Nuevo()
                End If
            Case DEFMENU.MAESTROS_PRODUCTOS_ELIMINAR
                If Not fProductos Is Nothing Then
                    fProductos.Menu_Eliminar()
                End If
            Case DEFMENU.MAESTROS_PRODUCTOS_IMPRIMIR
                If Not fProductos Is Nothing Then
                    fProductos.Menu_Imprimir()
                End If
            Case DEFMENU.MAESTROS_PRODUCTOS_SALIR
                If Not fProductos Is Nothing Then
                    fProductos.Close()
                End If

            Case DEFMENU.MAESTROS_VERSIONES
                Select Case ObtenerPermisosPantalla(ObtenerIdUnaPantalla(eventArgs.control.Id), UsuarioGrupo)
                    Case 0
                        ElPermiso = 0
                        ObjError.Pantalla1 = Me
                        ObjError.Tipo1 = 1 'Avisos
                        ObjError.Titulo = "SEGURIDAD"
                        ObjError.SetMensaje("No tiene Permiso para acceder a esta pantalla.")
                        ObjError.Control1 = ""
                        ObjError.Pie1 = False
                        ObjError.Foco1 = 0
                        FrmError.ObjError = ObjError
                        FrmError.ShowDialog()
                        If FrmError.DialogResult = DialogResult.OK Then
                            FrmError.Dispose()
                            Exit Sub
                        End If
                    Case 1
                        ElPermiso = 1
                        ObjError.Pantalla1 = Me
                        ObjError.Tipo1 = 3 'Avisos
                        ObjError.Titulo = "SEGURIDAD"
                        ObjError.SetMensaje("No tiene Permiso para realizar cambios en esta pantalla.")
                        ObjError.Control1 = ""
                        ObjError.Pie1 = False
                        ObjError.Foco1 = 0
                        FrmError.ObjError = ObjError
                        FrmError.ShowDialog()
                        If FrmError.DialogResult = DialogResult.OK Then
                            FrmError.Dispose()
                        End If
                End Select
                'If Not (EstableceAccesoSinMsg(ID_BANCOS)) Then
                '    MessageBox Me.hWnd, "Acceso no permitido. Consulte con su Administrador", Me.Caption, vbOKOnly + vbCritical
                '    Exit Sub
                'End If

                If Not fVersiones Is Nothing Then
                    CommandBars.TabWorkspace.FindItem(fVersiones.Handle).Selected = True
                    Exit Sub
                End If

                Dim Form2 As FrmVersiones = New FrmVersiones With {
                       .MdiParent = Me}
                'Form2.MdiParent.Name
                Form2.Permisos = ElPermiso
                Form2.Show()
                Form2.CargarComboProductos()'Esto hay que cargarlo desde fuera, porque si no no va

            Case DEFMENU.MAESTROS_VERSIONES_NUEVO
                If Not fVersiones Is Nothing Then
                    fVersiones.Menu_Nuevo()
                End If
            Case DEFMENU.MAESTROS_VERSIONES_ELIMINAR
                If Not fVersiones Is Nothing Then
                    fVersiones.Menu_Eliminar()
                End If
            Case DEFMENU.MAESTROS_VERSIONES_IMPRIMIR
                If Not fVersiones Is Nothing Then
                    fVersiones.Menu_Imprimir()
                End If
            Case DEFMENU.MAESTROS_VERSIONES_SALIR
                If Not fVersiones Is Nothing Then
                    fVersiones.Close()
                End If


            Case DEFMENU.MAESTROS_PACKS
                Select Case ObtenerPermisosPantalla(ObtenerIdUnaPantalla(eventArgs.control.Id), UsuarioGrupo)
                    Case 0
                        ElPermiso = 0
                        ObjError.Pantalla1 = Me
                        ObjError.Tipo1 = 1 'Avisos
                        ObjError.Titulo = "SEGURIDAD"
                        ObjError.SetMensaje("No tiene Permiso para acceder a esta pantalla.")
                        ObjError.Control1 = ""
                        ObjError.Pie1 = False
                        ObjError.Foco1 = 0
                        FrmError.ObjError = ObjError
                        FrmError.ShowDialog()
                        If FrmError.DialogResult = DialogResult.OK Then
                            FrmError.Dispose()
                            Exit Sub
                        End If
                    Case 1
                        ElPermiso = 1
                        ObjError.Pantalla1 = Me
                        ObjError.Tipo1 = 3 'Avisos
                        ObjError.Titulo = "SEGURIDAD"
                        ObjError.SetMensaje("No tiene Permiso para realizar cambios en esta pantalla.")
                        ObjError.Control1 = ""
                        ObjError.Pie1 = False
                        ObjError.Foco1 = 0
                        FrmError.ObjError = ObjError
                        FrmError.ShowDialog()
                        If FrmError.DialogResult = DialogResult.OK Then
                            FrmError.Dispose()
                        End If
                End Select

                If Not fPacks Is Nothing Then
                    CommandBars.TabWorkspace.FindItem(fPacks.Handle).Selected = True
                    Exit Sub
                End If

                Dim Form2 As FrmPacks = New FrmPacks With {
                       .MdiParent = Me}
                Form2.Permisos = ElPermiso
                Form2.Show()
                Me.Refresh()

            Case DEFMENU.MAESTROS_PACKS_NUEVO
                If Not fPacks Is Nothing Then
                    fPacks.Menu_Nuevo()
                End If
            Case DEFMENU.MAESTROS_PACKS_ELIMINAR
                If Not fPacks Is Nothing Then
                    fPacks.Menu_Eliminar()
                End If
            Case DEFMENU.MAESTROS_PACKS_IMPRIMIR
                If Not fPacks Is Nothing Then
                    fPacks.Menu_Imprimir()
                End If
            Case DEFMENU.MAESTROS_PACKS_SALIR
                If Not fPacks Is Nothing Then
                    'fPacks.Dispose()
                    fPacks.Close()
                End If


            Case DEFMENU.MAESTROS_CLIENTES
                Select Case ObtenerPermisosPantalla(ObtenerIdUnaPantalla(eventArgs.control.Id), UsuarioGrupo)
                    Case 0
                        ElPermiso = 0
                        ObjError.Pantalla1 = Me
                        ObjError.Tipo1 = 1 'Avisos
                        ObjError.Titulo = "SEGURIDAD"
                        ObjError.SetMensaje("No tiene Permiso para acceder a esta pantalla.")
                        ObjError.Control1 = ""
                        ObjError.Pie1 = False
                        ObjError.Foco1 = 0
                        FrmError.ObjError = ObjError
                        FrmError.ShowDialog()
                        If FrmError.DialogResult = DialogResult.OK Then
                            FrmError.Dispose()
                            Exit Sub
                        End If
                    Case 1
                        ElPermiso = 1
                        ObjError.Pantalla1 = Me
                        ObjError.Tipo1 = 3 'Avisos
                        ObjError.Titulo = "SEGURIDAD"
                        ObjError.SetMensaje("No tiene Permiso para realizar cambios en esta pantalla.")
                        ObjError.Control1 = ""
                        ObjError.Pie1 = False
                        ObjError.Foco1 = 0
                        FrmError.ObjError = ObjError
                        FrmError.ShowDialog()
                        If FrmError.DialogResult = DialogResult.OK Then
                            FrmError.Dispose()
                        End If
                End Select

                If Not fClientesFichero Is Nothing Then
                    CommandBars.TabWorkspace.FindItem(fPacks.Handle).Selected = True
                    Exit Sub
                End If

                Dim Form2 As FrmClientesFichero = New FrmClientesFichero With {
                       .MdiParent = Me}
                'Form2.Permisos = ElPermiso
                Form2.Show()
                Form2.CargarClientes()
                Me.Refresh()

            Case DEFMENU.MAESTROS_CLIENTES_NUEVO

                fClientesFichero.Nuevo()

            Case DEFMENU.MAESTROS_CLIENTES_FILTROFILA
                fClientesFichero.FiltroFila()

            Case DEFMENU.MAESTROS_CLIENTES_FILTROAVANZADO
                fClientesFichero.FiltroAvanzado()
            Case DEFMENU.MAESTROS_CLIENTES_MODIFICAR
                '  fClientesFichero.Modificar(CType(fClientesFichero.RCClientes.SelectedRows, _DReportControlEvents_RowDblClickEvent))

                fClientesFichero.Modificar()


            Case DEFMENU.MAESTROS_CLIENTES_IMPRIMIR

                fClientesFichero.ImprimirReport()

            Case DEFMENU.MAESTROS_CLIENTES_SALIR
                If Not fClientesFichero Is Nothing Then
                    fClientesFichero.Close()
                End If

            Case DEFMENU.MAESTROS_CLIENTES_FICHA_SALIR
                If Not fClientesFicha Is Nothing Then
                    fClientesFicha.Close()
                End If

            Case DEFMENU.MAESTROS_CLIENTES_FICHA_GUARDAR

                fClientesFicha.Guardar()

            Case DEFMENU.PRINCIPAL_MANTENIMIENTO
                Select Case ObtenerPermisosPantalla(ObtenerIdUnaPantalla(eventArgs.control.Id), UsuarioGrupo)
                    Case 0
                        ElPermiso = 0
                        ObjError.Pantalla1 = Me
                        ObjError.Tipo1 = 1 'Avisos
                        ObjError.Titulo = "SEGURIDAD"
                        ObjError.SetMensaje("No tiene Permiso para acceder a esta pantalla.")
                        ObjError.Control1 = ""
                        ObjError.Pie1 = False
                        ObjError.Foco1 = 0
                        FrmError.ObjError = ObjError
                        FrmError.ShowDialog()
                        If FrmError.DialogResult = DialogResult.OK Then
                            FrmError.Dispose()
                            Exit Sub
                        End If
                    Case 1
                        ElPermiso = 1
                        ObjError.Pantalla1 = Me
                        ObjError.Tipo1 = 3 'Avisos
                        ObjError.Titulo = "SEGURIDAD"
                        ObjError.SetMensaje("No tiene Permiso para realizar cambios en esta pantalla.")
                        ObjError.Control1 = ""
                        ObjError.Pie1 = False
                        ObjError.Foco1 = 0
                        FrmError.ObjError = ObjError
                        FrmError.ShowDialog()
                        If FrmError.DialogResult = DialogResult.OK Then
                            FrmError.Dispose()
                        End If
                End Select

                If Not fMantenimiento Is Nothing Then
                    CommandBars.TabWorkspace.FindItem(fMantenimiento.Handle).Selected = True
                    Exit Sub
                End If

                Dim Form2 As FrmMantenimiento = New FrmMantenimiento With {
                       .MdiParent = Me}
                Form2.Permisos = ElPermiso
                Form2.Show()
                Me.Refresh()

            'Case DEFMENU.MAESTROS_PACKS_NUEVO
            '    If Not fPacks Is Nothing Then
            '        fPacks.Menu_Nuevo()
            '    End If
            'Case DEFMENU.MAESTROS_PACKS_ELIMINAR
            '    If Not fPacks Is Nothing Then
            '        fPacks.Menu_Eliminar()
            '    End If
            Case DEFMENU.PRINCIPAL_MANTENIMIENTO_IMPRIMIR
                If Not fMantenimiento Is Nothing Then
                    fMantenimiento.Menu_Imprimir()
                End If
            Case DEFMENU.PRINCIPAL_MANTENIMIENTO_SALIR
                If Not fMantenimiento Is Nothing Then
                    fMantenimiento.Close()
                End If


            Case DEFMENU.ESTADIS_VENTAS
                Select Case ObtenerPermisosPantalla(ObtenerIdUnaPantalla(eventArgs.control.Id), UsuarioGrupo)
                    Case 0
                        ElPermiso = 0
                        ObjError.Pantalla1 = Me
                        ObjError.Tipo1 = 1 'Avisos
                        ObjError.Titulo = "SEGURIDAD"
                        ObjError.SetMensaje("No tiene Permiso para acceder a esta pantalla.")
                        ObjError.Control1 = ""
                        ObjError.Pie1 = False
                        ObjError.Foco1 = 0
                        FrmError.ObjError = ObjError
                        FrmError.ShowDialog()
                        If FrmError.DialogResult = DialogResult.OK Then
                            FrmError.Dispose()
                            Exit Sub
                        End If
                    Case 1
                        ElPermiso = 1
                        ObjError.Pantalla1 = Me
                        ObjError.Tipo1 = 3 'Avisos
                        ObjError.Titulo = "SEGURIDAD"
                        ObjError.SetMensaje("No tiene Permiso para realizar cambios en esta pantalla.")
                        ObjError.Control1 = ""
                        ObjError.Pie1 = False
                        ObjError.Foco1 = 0
                        FrmError.ObjError = ObjError
                        FrmError.ShowDialog()
                        If FrmError.DialogResult = DialogResult.OK Then
                            FrmError.Dispose()
                        End If
                End Select

                If Not fEstadisticasVentas Is Nothing Then
                    CommandBars.TabWorkspace.FindItem(fEstadisticasVentas.Handle).Selected = True
                    Exit Sub
                End If

                Dim Form2 As FrmEstadisticasVentas = New FrmEstadisticasVentas With {
                       .MdiParent = Me}
                Form2.Permisos = ElPermiso
                Form2.Show()
                Me.Refresh()

            Case DEFMENU.ESTADIS_VENTAS_IMPRIMIR
                If Not fEstadisticasVentas Is Nothing Then
                    fEstadisticasVentas.Menu_Imprimir()
                End If
            Case DEFMENU.ESTADIS_VENTAS_EXCEL_CLIENTES
                If Not fEstadisticasVentas Is Nothing Then
                    fEstadisticasVentas.Menu_ExcelClientes()
                End If
            Case DEFMENU.ESTADIS_VENTAS_EXCEL_VENTAS
                If Not fEstadisticasVentas Is Nothing Then
                    fEstadisticasVentas.Menu_ExcelVentas()
                End If
            Case DEFMENU.ESTADIS_VENTAS_SALIR
                If Not fEstadisticasVentas Is Nothing Then
                    fEstadisticasVentas.Close()
                End If



            Case DEFMENU.INFORMES_CARTASMANTE
                Select Case ObtenerPermisosPantalla(ObtenerIdUnaPantalla(eventArgs.control.Id), UsuarioGrupo)
                    Case 0
                        ElPermiso = 0
                        ObjError.Pantalla1 = Me
                        ObjError.Tipo1 = 1 'Avisos
                        ObjError.Titulo = "SEGURIDAD"
                        ObjError.SetMensaje("No tiene Permiso para acceder a esta pantalla.")
                        ObjError.Control1 = ""
                        ObjError.Pie1 = False
                        ObjError.Foco1 = 0
                        FrmError.ObjError = ObjError
                        FrmError.ShowDialog()
                        If FrmError.DialogResult = DialogResult.OK Then
                            FrmError.Dispose()
                            Exit Sub
                        End If
                    Case 1
                        ElPermiso = 1
                        ObjError.Pantalla1 = Me
                        ObjError.Tipo1 = 3 'Avisos
                        ObjError.Titulo = "SEGURIDAD"
                        ObjError.SetMensaje("No tiene Permiso para realizar cambios en esta pantalla.")
                        ObjError.Control1 = ""
                        ObjError.Pie1 = False
                        ObjError.Foco1 = 0
                        FrmError.ObjError = ObjError
                        FrmError.ShowDialog()
                        If FrmError.DialogResult = DialogResult.OK Then
                            FrmError.Dispose()
                        End If
                End Select

                If Not fInformesCartasMante Is Nothing Then
                    CommandBars.TabWorkspace.FindItem(fInformesCartasMante.Handle).Selected = True
                    Exit Sub
                End If

                Dim Form2 As FrmInformesCartasMante = New FrmInformesCartasMante With {
                       .MdiParent = Me}
                Form2.Permisos = ElPermiso
                Form2.Show()
                Me.Refresh()

            Case DEFMENU.INFORMES_CARTASMANTE_IMPRIMIR
                If Not fInformesCartasMante Is Nothing Then
                    fInformesCartasMante.Menu_Imprimir()
                End If
            Case DEFMENU.INFORMES_CARTASMANTE_EXCEL_CLIENTES
                If Not fInformesCartasMante Is Nothing Then
                    fInformesCartasMante.Menu_ExcelClientes()
                End If
            Case DEFMENU.INFORMES_CARTASMANTE_SALIR
                If Not fInformesCartasMante Is Nothing Then
                    fInformesCartasMante.Close()
                End If



            Case DEFMENU.PRINCIPAL_SALIR
                'Me.ActiveMdiChild.Close()
                Me.Dispose()
                End


           ' Case ID.ID_APP_EXIT
           '     Me.Close()
           ' Case CInt(XtremeCommandBars.XTPCommandBarsSpecialCommands.XTP_ID_RIBBONCONTROLTAB)
           '     System.Diagnostics.Debug.WriteLine("Selected Tab has Changed")
           ' Case ID.ID_FILE_PRINT_PREVIEW
           '   '  LoadPrintPreview()
           ' Case ID.ID_VIEW_STATUS_BAR
           '     CommandBars.StatusBar.Visible = Not CommandBars.StatusBar.Visible
           '     CommandBars.RecalcLayout()
           ' Case ID.ID_VIEW_WORKSPACE
           '     eventArgs.control.Checked = Not eventArgs.control.Checked
           '     CommandBars.ShowTabWorkspace(eventArgs.control.Checked)
           ' Case ID.ID_WINDOW_ARRANGE
           '     Me.LayoutMdi(MdiLayout.ArrangeIcons)
           ' Case ID.ID_WINDOW_NEW
           '    ' LoadNewDoc("")
           ' Case ID.ID_PREVIEW_PREVIEW_CLOSE
           '     RibbonBar().FindTab(ID.ID_TAB_PRINT_PREVIEW).Visible = False
           '     RibbonBar().FindTab(ID.ID_TAB_HOME).Visible = True
           '     RibbonBar().FindTab(ID.ID_TAB_EDIT).Visible = True
           '     RibbonBar().FindTab(ID.ID_TAB_VIEW).Visible = True
           '     Me.ActiveMdiChild.Close()
           '     If RibbonBar().FindControl(XtremeCommandBars.XTPControlType.xtpControlCheckBox, ID.ID_VIEW_WORKSPACE, False, True).Checked Then
           '         CommandBars.ShowTabWorkspace(True)
           '     Else
           '         Me.ActiveMdiChild.WindowState = FormWindowState.Normal
           '     End If
           '     RibbonBar().FindTab(ID.ID_TAB_HOME).Selected = True

            'Case ID.ID_FILE_CLOSE
            '    Me.ActiveMdiChild.Close()

            'Case ID.ID_EDIT_SELECT_ALL, ID.ID_EDIT_SELECT
            '    Dim rtfText As System.Windows.Forms.RichTextBox = CType(Me.ActiveMdiChild.Controls(0), System.Windows.Forms.RichTextBox)
            '    rtfText.SelectAll()
            'Case ID.ID_EDIT_UNDO
            '    Dim rtfText As System.Windows.Forms.RichTextBox = CType(Me.ActiveMdiChild.Controls(0), System.Windows.Forms.RichTextBox)
            '    rtfText.Undo()
            'Case ID.ID_EDIT_CUT
            '    Dim rtfText As System.Windows.Forms.RichTextBox = CType(Me.ActiveMdiChild.Controls(0), System.Windows.Forms.RichTextBox)
            '    rtfText.Cut()
            'Case ID.ID_EDIT_COPY
            '    Dim rtfText As System.Windows.Forms.RichTextBox = CType(Me.ActiveMdiChild.Controls(0), System.Windows.Forms.RichTextBox)
            '    rtfText.Copy()
            'Case ID.ID_EDIT_PASTE
            '    Dim rtfText As System.Windows.Forms.RichTextBox = CType(Me.ActiveMdiChild.Controls(0), System.Windows.Forms.RichTextBox)
            '    rtfText.Paste()
            Case DEFMENU.STYLEBLACK
                CommandBarsGlobalSettings = New XtremeCommandBars.CommandBarsGlobalSettings
                CommandBarsGlobalSettings.ResourceImages.LoadFromFile(GetFolderPath("Styles") + "Office2007.dll", "Office2007Black.ini")
                CommandBars.VisualTheme = XtremeCommandBars.XTPVisualTheme.xtpThemeRibbon
                CommandBars.ToolTipContext.Style = XtremeCommandBars.XTPToolTipStyle.xtpToolTipResource
                '    ControlFile.Style = XtremeCommandBars.XTPButtonStyle.xtpButtonAutomatic
                CommandBars.PaintManager.RefreshMetrics()
                CommandBars.RecalcLayout()
                AplicaEstilo()
            Case DEFMENU.STYLEBLUE
                CommandBarsGlobalSettings = New XtremeCommandBars.CommandBarsGlobalSettings
                CommandBarsGlobalSettings.ResourceImages.LoadFromFile(GetFolderPath("Styles") + "Office2007.dll", "Office2007Blue.ini")
                CommandBars.VisualTheme = XtremeCommandBars.XTPVisualTheme.xtpThemeRibbon
                CommandBars.ToolTipContext.Style = XtremeCommandBars.XTPToolTipStyle.xtpToolTipResource
                '    ControlFile.Style = XtremeCommandBars.XTPButtonStyle.xtpButtonAutomatic
                CommandBars.PaintManager.RefreshMetrics()
                CommandBars.RecalcLayout()
                AplicaEstilo()
            Case DEFMENU.STYLEAQUA
                CommandBarsGlobalSettings = New XtremeCommandBars.CommandBarsGlobalSettings
                CommandBarsGlobalSettings.ResourceImages.LoadFromFile(GetFolderPath("Styles") + "Office2007.dll", "Office2007Aqua.ini")
                CommandBars.VisualTheme = XtremeCommandBars.XTPVisualTheme.xtpThemeRibbon
                CommandBars.ToolTipContext.Style = XtremeCommandBars.XTPToolTipStyle.xtpToolTipResource
                '  ControlFile.Style = XtremeCommandBars.XTPButtonStyle.xtpButtonAutomatic
                CommandBars.PaintManager.RefreshMetrics()
                CommandBars.RecalcLayout()
                AplicaEstilo()
            Case DEFMENU.STYLESILVER
                CommandBarsGlobalSettings = New XtremeCommandBars.CommandBarsGlobalSettings
                CommandBarsGlobalSettings.ResourceImages.LoadFromFile(GetFolderPath("Styles") + "Office2007.dll", "Office2007Silver.ini")
                CommandBars.VisualTheme = XtremeCommandBars.XTPVisualTheme.xtpThemeRibbon
                CommandBars.ToolTipContext.Style = XtremeCommandBars.XTPToolTipStyle.xtpToolTipResource
                '     ControlFile.Style = XtremeCommandBars.XTPButtonStyle.xtpButtonAutomatic
                CommandBars.PaintManager.RefreshMetrics()
                CommandBars.RecalcLayout()
                AplicaEstilo()
            Case DEFMENU.STYLEOFFCIE2010BLUE
                CommandBarsGlobalSettings = New XtremeCommandBars.CommandBarsGlobalSettings
                CommandBarsGlobalSettings.ResourceImages.LoadFromFile(GetFolderPath("Styles") + "Office2010.dll", "Office2010Blue.ini")
                CommandBars.VisualTheme = XtremeCommandBars.XTPVisualTheme.xtpThemeRibbon
                CommandBars.ToolTipContext.Style = XtremeCommandBars.XTPToolTipStyle.xtpToolTipResource
                '     ControlFile.Style = XtremeCommandBars.XTPButtonStyle.xtpButtonCaption
                CommandBars.PaintManager.RefreshMetrics()
                CommandBars.RecalcLayout()
                AplicaEstilo()
            Case DEFMENU.STYLEOFFICE2010SILVER
                CommandBarsGlobalSettings = New XtremeCommandBars.CommandBarsGlobalSettings
                CommandBarsGlobalSettings.ResourceImages.LoadFromFile(GetFolderPath("Styles") + "Office2010.dll", "Office2010Silver.ini")
                CommandBars.VisualTheme = XtremeCommandBars.XTPVisualTheme.xtpThemeRibbon
                CommandBars.ToolTipContext.Style = XtremeCommandBars.XTPToolTipStyle.xtpToolTipResource
                'ControlFile.Style = XtremeCommandBars.XTPButtonStyle.xtpButtonCaption
                CommandBars.PaintManager.RefreshMetrics()
                CommandBars.RecalcLayout()
                AplicaEstilo()
            Case DEFMENU.STYLEOFFCIE2010BLACK
                CommandBarsGlobalSettings = New XtremeCommandBars.CommandBarsGlobalSettings
                CommandBarsGlobalSettings.ResourceImages.LoadFromFile(GetFolderPath("Styles") + "Office2010.dll", "Office2010Black.ini")
                CommandBars.VisualTheme = XtremeCommandBars.XTPVisualTheme.xtpThemeRibbon
                CommandBars.ToolTipContext.Style = XtremeCommandBars.XTPToolTipStyle.xtpToolTipResource
                'ControlFile.Style = XtremeCommandBars.XTPButtonStyle.xtpButtonCaption
                CommandBars.PaintManager.RefreshMetrics()
                CommandBars.RecalcLayout()
                AplicaEstilo()
            Case DEFMENU.STYLEOFFCIE2013WHITE
                CommandBarsGlobalSettings = New XtremeCommandBars.CommandBarsGlobalSettings
                CommandBarsGlobalSettings.ResourceImages.LoadFromFile(GetFolderPath("Styles") + "Office2013.dll", "Office2013White.ini")
                CommandBars.VisualTheme = XtremeCommandBars.XTPVisualTheme.xtpThemeOffice2013
                CommandBars.ToolTipContext.Style = XtremeCommandBars.XTPToolTipStyle.xtpToolTipOffice2013
                '     ControlFile.Style = XtremeCommandBars.XTPButtonStyle.xtpButtonCaption
                CommandBars.PaintManager.RefreshMetrics()
                CommandBars.RecalcLayout()
                AplicaEstilo()
            Case DEFMENU.STYLESCENIC
                CommandBarsGlobalSettings = New XtremeCommandBars.CommandBarsGlobalSettings
                CommandBarsGlobalSettings.ResourceImages.LoadFromFile(GetFolderPath("Styles") + "Windows7.dll", "Windows7Blue.ini")
                CommandBars.VisualTheme = XtremeCommandBars.XTPVisualTheme.xtpThemeRibbon
                CommandBars.ToolTipContext.Style = XtremeCommandBars.XTPToolTipStyle.xtpToolTipResource
                'ControlFile.Style = XtremeCommandBars.XTPButtonStyle.xtpButtonCaption
                CommandBars.PaintManager.RefreshMetrics()
                CommandBars.RecalcLayout()
                AplicaEstilo()
            Case DEFMENU.STYLESYSTEM
                CommandBars.VisualTheme = XtremeCommandBars.XTPVisualTheme.xtpThemeOfficeXP
                CommandBars.ToolTipContext.Style = XtremeCommandBars.XTPToolTipStyle.xtpToolTipStandard
                CommandBars.Options.UseFadedIcons = False
                CommandBars.Options.IconsWithShadow = False
                'ControlFile.Style = XtremeCommandBars.XTPButtonStyle.xtpButtonAutomatic
                CommandBars.PaintManager.RefreshMetrics()
                CommandBars.RecalcLayout()
                AplicaEstilo()
                ID_THEME_CURRENT = eventArgs.control.Id
                'Case Else
                '    MessageBox.Show(eventArgs.control.Caption & " clicked", "Button Clicked")
                '    Exit Select
        End Select

        Me.Refresh()

        'If (eventArgs.control.Id >= ID.ID_OPTIONS_STYLEBLUE And eventArgs.control.Id <= ID.ID_OPTIONS_STYLEOFFCIE2013WHITE) Then

        '    ID_THEME_CURRENT = eventArgs.control.Id

        '    CommandBars.EnableOffice2007Frame(False)

        '    Select Case (CommandBars.VisualTheme)

        '        Case XtremeCommandBars.XTPVisualTheme.xtpThemeResource
        '        Case XtremeCommandBars.XTPVisualTheme.xtpThemeRibbon
        '            CommandBars.AllowFrameTransparency(True)
        '            CommandBars.EnableOffice2007Frame(True)
        '            CommandBars.SetAllCaps(False)
        '            CommandBars.StatusBar.SetAllCaps(False)
        '        Case XtremeCommandBars.XTPVisualTheme.xtpThemeOffice2013
        '            CommandBars.PaintManager.LoadFrameIcon(Process.GetCurrentProcess().Handle.ToInt32(), GetFolderPath("Helpers\\Icons") + "CjSample.ico", 20, 20)
        '            CommandBars.AllowFrameTransparency(False)
        '            CommandBars.EnableOffice2007Frame(True)
        '            CommandBars.SetAllCaps(True)
        '            CommandBars.StatusBar.SetAllCaps(True)
        '        Case Else
        '            CommandBars.AllowFrameTransparency(True)
        '            CommandBars.EnableOffice2007Frame(False)
        '            CommandBars.SetAllCaps(False)
        '            CommandBars.StatusBar.SetAllCaps(False)
        '    End Select

        'End If

        ' Dim i As Integer

        'For i = 0 To CommandBars.TabWorkspace.ItemCount
        'If (eventArgs.control.Id >= ID.ID_OPTIONS_STYLEBLUE And eventArgs.control.Id <= ID.ID_OPTIONS_STYLEOFFCIE2013WHITE) Then
        '    CommandBars.DisableOffice2007FrameHandle(CommandBars.TabWorkspace.Item(i).Handle)
        '    CommandBars.EnableOffice2007FrameHandle(CommandBars.TabWorkspace.Item(i).Handle)
        'End If
        'Next i
    End Sub

    Sub AplicaEstilo()

        Dim LosFrms As Form
        Dim X As Object

        For Each LosFrms In Me.MdiChildren
            If LosFrms.IsMdiChild = True Then
                For Each X In LosFrms.Controls
                    AplicaEstiloControl(X)
                Next X
            End If
        Next
    End Sub

End Class
