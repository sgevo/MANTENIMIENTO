Imports AxXtremeReportControl
Imports XtremeReportControl
Imports MantEvolution.DefinicionesMenus


Public Class FrmPacks

    Const COL_ID = 0
    Const COL_DESCRIPCION = 1
    Const COL_PRECIO = 2
    Const COL_IDPRODUCTO1 = 3
    Const COL_PRODUCTO1 = 4
    Const COL_RED1 = 5
    Const COL_MANTE1 = 6
    Const COL_ACTUALIZAR1 = 7
    Const COL_IDPRODUCTO2 = 8
    Const COL_PRODUCTO2 = 9
    Const COL_RED2 = 10
    Const COL_MANTE2 = 11
    Const COL_ACTUALIZAR2 = 12

    Const COL_AÑADIR = 13

    Public Permisos As Long

    Dim ArrayPacks As New ArrayList()

    Dim HayErrores As Boolean

    Dim TabPantalla As XtremeCommandBars.RibbonTab = Nothing
    Dim GroupFile As XtremeCommandBars.RibbonGroup = Nothing
    Dim arrayProductos As New ArrayList

    Private Sub FrmPacks_Load(sender As Object, e As EventArgs) Handles Me.Load

        Debug.Print("---> Empiezo : " & DateAndTime.Now)
        arrayProductos = ObtenerProductos()
        Debug.Print("---> Empiezo 1: " & DateAndTime.Now)
        With RCPacks

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
        Debug.Print("---> Empiezo 2: " & DateAndTime.Now)
        CargarPacks()

        Debug.Print("---> Empiezo 3: " & DateAndTime.Now)

        'Esta linea hace falta para que funcione el rc_beforedrawrow
        'Aunque el formato se puede poner directamente en la Clase del objeto, mejor
        'RCProductos.SetCustomDraw(XtremeReportControl.XTPReportCustomDraw.xtpCustomBeforeDrawRow)

        RCPacks.Icons = MDIPrincipal.ImageManager.Icons

        Debug.Print("Termino : " & DateAndTime.Now)
        fPacks = Me

    End Sub

    Sub CargarPacks()

        Dim Record As XtremeReportControl.ReportRecord
        Dim objPack As Pack
        Dim CuentoObjetos As Long
        Dim objProductos As Producto

        ArrayPacks = ObtenerPacks()

        For Each objPack In ArrayPACKS

            Record = RCPacks.Records.Add()

            Record.AddItem(objPack.Id1)
            Record.AddItem(objPack.Descripcion1)
            Record.AddItem(objPack.Precio1)

            CuentoObjetos = 0
            For Each objProductos In arrayProductos
                If objProductos.Id1 = objPack.IdProducto11 Then
                    CuentoObjetos = 1
                    Record.AddItem(objProductos.Id1)
                    Record.AddItem(objProductos.Id1)
                    Exit For
                End If
            Next
            If CuentoObjetos = 0 Then Record.AddItem("0") : Record.AddItem("0") 'si no ha encontrado nada, tengo que meter algo       
            'Record.AddItem(objPack.objProducto11.Id1)
            'Record.AddItem(objPack.objProducto11.Id1)

            Record.AddItem(objPack.Red11)
            Record.AddItem(objPack.Mante11)
            Record.AddItem(objPack.Actualizar11)

            CuentoObjetos = 0
            For Each objProductos In arrayProductos
                If objProductos.Id1 = objPack.IdProducto21 Then
                    CuentoObjetos = 1
                    Record.AddItem(objProductos.Id1)
                    Record.AddItem(objProductos.Id1)
                    Exit For
                End If
            Next
            If CuentoObjetos = 0 Then Record.AddItem("0") : Record.AddItem("0") 'si no ha encontrado nada, tengo que meter algo       
            'Record.AddItem(objPack.objProducto21.Id1)
            'Record.AddItem(objPack.objProducto21.Id1)
            Record.AddItem(objPack.Red21)
            Record.AddItem(objPack.Mante21)
            Record.AddItem(objPack.Actualizar21)

            Record.AddItem("") 'Añadir

        Next

        RCPacks.Populate()

    End Sub

    Sub CargarColumnasReport()

        Dim FilaPie As ReportRecord
        Dim objProducto As Producto
        Dim ArrayProductos As ArrayList

        ArrayProductos = ObtenerProductos()

        RCPacks.PaintManager.ColumnStyle = XTPReportColumnStyle.xtpColumnResource

        RCPacks.AllowEdit = True

        RCPacks.Columns.Add(COL_ID, "IdPack", 100, True)
        RCPacks.Columns.Add(COL_DESCRIPCION, "Descripción", 100, True)
        RCPacks.Columns.Add(COL_PRECIO, "Precio", 100, True)
        RCPacks.Columns.Add(COL_IDPRODUCTO1, "", 250, True)
        RCPacks.Columns.Add(COL_PRODUCTO1, "Producto", 150, True)
        RCPacks.Columns.Column(COL_PRODUCTO1).EditOptions.AddComboButton()
        RCPacks.Columns.Column(COL_PRODUCTO1).EditOptions.GetInplaceButton(0).InsideCellButton = True
        RCPacks.Columns.Column(COL_PRODUCTO1).EditOptions.ConstraintEdit = True
        RCPacks.Columns.Column(COL_PRODUCTO1).EditOptions.Constraints.DeleteAll()
        RCPacks.Columns.Column(COL_PRODUCTO1).EditOptions.Constraints.Add("[Ninguno]", 0)
        For Each objProducto In ArrayProductos
            RCPacks.Columns.Column(COL_PRODUCTO1).EditOptions.Constraints.Add(objProducto.Codigo1, objProducto.Id1)
        Next
        RCPacks.Columns.Add(COL_RED1, "Red", 60, True)
        RCPacks.Columns.Column(COL_RED1).EditOptions.AddComboButton()
        RCPacks.Columns.Column(COL_RED1).EditOptions.GetInplaceButton(0).InsideCellButton = True
        RCPacks.Columns.Column(COL_RED1).EditOptions.ConstraintEdit = True
        RCPacks.Columns.Column(COL_RED1).EditOptions.Constraints.DeleteAll()
        RCPacks.Columns.Column(COL_RED1).EditOptions.Constraints.Add("Sí", -1)
        RCPacks.Columns.Column(COL_RED1).EditOptions.Constraints.Add("No", 0)
        RCPacks.Columns.Column(COL_RED1).EditOptions.ExpandOnSelect = True
        RCPacks.Columns.Add(COL_MANTE1, "Mantenimiento", 60, True)
        RCPacks.Columns.Column(COL_MANTE1).EditOptions.AddComboButton()
        RCPacks.Columns.Column(COL_MANTE1).EditOptions.GetInplaceButton(0).InsideCellButton = True
        RCPacks.Columns.Column(COL_MANTE1).EditOptions.ConstraintEdit = True
        RCPacks.Columns.Column(COL_MANTE1).EditOptions.Constraints.DeleteAll()
        RCPacks.Columns.Column(COL_MANTE1).EditOptions.Constraints.Add("Sí", -1)
        RCPacks.Columns.Column(COL_MANTE1).EditOptions.Constraints.Add("No", 0)
        RCPacks.Columns.Column(COL_MANTE1).EditOptions.ExpandOnSelect = True
        RCPacks.Columns.Add(COL_ACTUALIZAR1, "Actualización", 60, True)
        RCPacks.Columns.Column(COL_ACTUALIZAR1).EditOptions.AddComboButton()
        RCPacks.Columns.Column(COL_ACTUALIZAR1).EditOptions.GetInplaceButton(0).InsideCellButton = True
        RCPacks.Columns.Column(COL_ACTUALIZAR1).EditOptions.ConstraintEdit = True
        RCPacks.Columns.Column(COL_ACTUALIZAR1).EditOptions.Constraints.DeleteAll()
        RCPacks.Columns.Column(COL_ACTUALIZAR1).EditOptions.Constraints.Add("Sí", -1)
        RCPacks.Columns.Column(COL_ACTUALIZAR1).EditOptions.Constraints.Add("No", 0)
        RCPacks.Columns.Column(COL_ACTUALIZAR1).EditOptions.ExpandOnSelect = True
        RCPacks.Columns.Add(COL_IDPRODUCTO2, "", 48, True)
        RCPacks.Columns.Add(COL_PRODUCTO2, "Producto", 150, True)
        RCPacks.Columns.Column(COL_PRODUCTO2).EditOptions.AddComboButton()
        RCPacks.Columns.Column(COL_PRODUCTO2).EditOptions.GetInplaceButton(0).InsideCellButton = True
        RCPacks.Columns.Column(COL_PRODUCTO2).EditOptions.ConstraintEdit = True
        RCPacks.Columns.Column(COL_PRODUCTO2).EditOptions.Constraints.DeleteAll()
        RCPacks.Columns.Column(COL_PRODUCTO2).EditOptions.Constraints.Add("[Ninguno]", 0)
        For Each objproducto In ArrayProductos
            RCPacks.Columns.Column(COL_PRODUCTO2).EditOptions.Constraints.Add(objProducto.Codigo1, objProducto.Id1)
        Next
        'RCPacks.Columns.Column(COL_PRODUCTO2).EditOptions.ExpandOnSelect = True

        RCPacks.Columns.Add(COL_RED2, "Red", 60, True)
        RCPacks.Columns.Column(COL_RED2).EditOptions.AddComboButton()
        RCPacks.Columns.Column(COL_RED2).EditOptions.GetInplaceButton(0).InsideCellButton = True
        RCPacks.Columns.Column(COL_RED2).EditOptions.ConstraintEdit = True
        RCPacks.Columns.Column(COL_RED2).EditOptions.Constraints.DeleteAll()
        RCPacks.Columns.Column(COL_RED2).EditOptions.Constraints.Add("Sí", -1)
        RCPacks.Columns.Column(COL_RED2).EditOptions.Constraints.Add("No", 0)
        RCPacks.Columns.Column(COL_RED2).EditOptions.ExpandOnSelect = True
        RCPacks.Columns.Add(COL_MANTE2, "Mantenimiento", 60, True)
        RCPacks.Columns.Column(COL_MANTE2).EditOptions.AddComboButton()
        RCPacks.Columns.Column(COL_MANTE2).EditOptions.GetInplaceButton(0).InsideCellButton = True
        RCPacks.Columns.Column(COL_MANTE2).EditOptions.ConstraintEdit = True
        RCPacks.Columns.Column(COL_MANTE2).EditOptions.Constraints.DeleteAll()
        RCPacks.Columns.Column(COL_MANTE2).EditOptions.Constraints.Add("Sí", -1)
        RCPacks.Columns.Column(COL_MANTE2).EditOptions.Constraints.Add("No", 0)
        RCPacks.Columns.Column(COL_MANTE2).EditOptions.ExpandOnSelect = True
        RCPacks.Columns.Add(COL_ACTUALIZAR2, "Actualización", 60, True)
        RCPacks.Columns.Column(COL_ACTUALIZAR2).EditOptions.AddComboButton()
        RCPacks.Columns.Column(COL_ACTUALIZAR2).EditOptions.GetInplaceButton(0).InsideCellButton = True
        RCPacks.Columns.Column(COL_ACTUALIZAR2).EditOptions.ConstraintEdit = True
        RCPacks.Columns.Column(COL_ACTUALIZAR2).EditOptions.Constraints.DeleteAll()
        RCPacks.Columns.Column(COL_ACTUALIZAR2).EditOptions.Constraints.Add("Sí", -1)
        RCPacks.Columns.Column(COL_ACTUALIZAR2).EditOptions.Constraints.Add("No", 0)
        RCPacks.Columns.Column(COL_ACTUALIZAR2).EditOptions.ExpandOnSelect = True
        RCPacks.Columns.Add(COL_AÑADIR, "Añadir", 48, True)

        FilaPie = RCPacks.FooterRecords.Add

        Dim x As Integer
        Dim item As ReportRecordItem

        For x = 0 To RCPacks.Columns.Count - 1
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

        RCPacks.PopulateFooterRows()
        RCPacks.Populate()

        'Configuracion Final del report en cuanto a columnas
        RCPacks.Columns.Find(COL_ID).Visible = False
        RCPacks.Columns.Find(COL_DESCRIPCION).EditOptions.SelectTextOnEdit = True
        RCPacks.Columns.Find(COL_DESCRIPCION).EditOptions.MaxLength = 100
        RCPacks.Columns.Find(COL_IDPRODUCTO1).Visible = False
        RCPacks.Columns.Find(COL_IDPRODUCTO2).Visible = False


    End Sub

    Private Sub FrmPacks_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        ConfigurarPantalla()
    End Sub

    Sub ConfigurarPantalla()

        Titulo.Top = 0
        Titulo.Left = 0
        Titulo.Width = Me.Width

        RCPacks.Left = 10
        RCPacks.Width = Me.Width - 20

        RCPacks.Top = Titulo.Height
        RCPacks.Height = Me.Height - RCPacks.Top - 20

    End Sub

    Public Sub AplicaEstilo()

        Dim X As Object

        For Each X In Me.Controls
            AplicaEstiloControl(X)
        Next X

    End Sub

    Sub AñadirLineaReport(objPack As Pack)

        Dim registro As ReportRecord

        registro = RCPacks.Records.Add()

        registro.AddItem(objPack.Id1)
        registro.AddItem(objPack.Descripcion1)
        registro.AddItem(objPack.Precio1)
        registro.AddItem(objPack.objProducto11.Id1)
        registro.AddItem(objPack.objProducto11.Id1)
        registro.AddItem(objPack.Red11)
        registro.AddItem(objPack.Mante11)
        registro.AddItem(objPack.Actualizar11)
        registro.AddItem(objPack.objProducto21.Id1)
        registro.AddItem(objPack.objProducto21.Id1)
        registro.AddItem(objPack.Red21)
        registro.AddItem(objPack.Mante21)
        registro.AddItem(objPack.Actualizar21)
        'End If
        registro.AddItem("") 'Añadir

        'registro.Item(COL_AÑADIR).Editable = False
        RCPacks.Populate()

    End Sub

    Sub Subirlinea()

        Dim ElId1 As Long
        Dim Red1 As Boolean
        Dim Mante1 As Boolean
        Dim Actual1 As Boolean

        Dim ElId2 As Long
        Dim Red2 As Boolean
        Dim Mante2 As Boolean
        Dim Actual2 As Boolean

        If RCPacks.FooterRows(0).Record.Item(COL_PRODUCTO1).Value IsNot "" Then
            ElId1 = RCPacks.FooterRows(0).Record.Item(COL_PRODUCTO1).Value
            Red1 = RCPacks.FooterRows(0).Record.Item(COL_RED1).Value
            Mante1 = RCPacks.FooterRows(0).Record.Item(COL_MANTE1).Value
            Actual1 = RCPacks.FooterRows(0).Record.Item(COL_ACTUALIZAR1).Value
        Else
            ElId1 = 0
            Red1 = 0
            Mante1 = 0
            Actual1 = 0
        End If

        If RCPacks.FooterRows(0).Record.Item(COL_PRODUCTO2).Value IsNot "" Then
            ElId2 = RCPacks.FooterRows(0).Record.Item(COL_PRODUCTO2).Value
            Red2 = RCPacks.FooterRows(0).Record.Item(COL_RED2).Value
            Mante2 = RCPacks.FooterRows(0).Record.Item(COL_MANTE2).Value
            Actual2 = RCPacks.FooterRows(0).Record.Item(COL_ACTUALIZAR2).Value
        Else
            ElId2 = 0
            Red2 = 0
            Mante2 = 0
            Actual2 = 0
        End If

        Dim objPack = New Pack(0, RCPacks.FooterRows(0).Record.Item(COL_DESCRIPCION).Value, RCPacks.FooterRows(0).Record.Item(COL_PRECIO).Value, Red1, Mante1, Actual1, Red2, Mante2, Actual2, ElId1, ElId2)

        Dim proximaColumna As Integer

        GuardarPack(objPack)

        AñadirLineaReport(objPack)

        BorraPie()
        RCPacks.Navigator.CurrentFocusInFootersRows = True

        proximaColumna = SiguienteColumnaEditable(RCPacks, -1, True)

        RCPacks.Navigator.MoveToColumn(proximaColumna)

    End Sub

    Sub BorraPie()
        RCPacks.FooterRows(0).Record.Item(COL_ID).Value = ""
        RCPacks.FooterRows(0).Record.Item(COL_DESCRIPCION).Value = ""
        RCPacks.FooterRows(0).Record.Item(COL_PRECIO).Value = ""
        RCPacks.FooterRows(0).Record.Item(COL_IDPRODUCTO1).Value = ""
        RCPacks.FooterRows(0).Record.Item(COL_PRODUCTO1).Value = ""
        RCPacks.FooterRows(0).Record.Item(COL_RED1).Value = ""
        RCPacks.FooterRows(0).Record.Item(COL_MANTE1).Value = ""
        RCPacks.FooterRows(0).Record.Item(COL_ACTUALIZAR1).Value = ""
        RCPacks.FooterRows(0).Record.Item(COL_IDPRODUCTO2).Value = ""
        RCPacks.FooterRows(0).Record.Item(COL_PRODUCTO2).Value = ""
        RCPacks.FooterRows(0).Record.Item(COL_RED2).Value = ""
        RCPacks.FooterRows(0).Record.Item(COL_MANTE2).Value = ""
        RCPacks.FooterRows(0).Record.Item(COL_ACTUALIZAR2).Value = ""
        RCPacks.FooterRows(0).Record.Item(COL_AÑADIR).Value = ""
    End Sub

    Private Sub RCPacks_ItemButtonClick() Handles RCPacks.ItemButtonClick

        Dim MiRow As ReportRow
        Dim ObjError As New Errores

        MiRow = RCPacks.FocusedRow

        If Permisos <> 2 Then
            ObjError.Pantalla1 = Me
            ObjError.Tipo1 = 1 'Avisos

            ObjError.Titulo = "Packs"

            ObjError.SetMensaje("No dispone de Permiso para Actualizar Packs")

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

        If RCPacks.FocusedRow.Section.Index = 1 Then 'Lineas de Detalle
            If Comprobaciones(False) = False Then

                Dim objPack = New Pack(MiRow.Record.Item(COL_ID).Value, MiRow.Record.Item(COL_DESCRIPCION).Value, MiRow.Record.Item(COL_PRECIO).Value, MiRow.Record.Item(COL_RED1).Value, MiRow.Record.Item(COL_MANTE1).Value, MiRow.Record.Item(COL_ACTUALIZAR1).Value, MiRow.Record.Item(COL_RED2).Value, MiRow.Record.Item(COL_MANTE2).Value, MiRow.Record.Item(COL_ACTUALIZAR2).Value, MiRow.Record.Item(COL_PRODUCTO1).Value, MiRow.Record.Item(COL_PRODUCTO2).Value)
                ModificarPack(objPack)

                ObjError.Pantalla1 = Me
                ObjError.Tipo1 = 3 'Avisos

                ObjError.Titulo = "Packs"

                ObjError.SetMensaje("Pack actualizado")

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
        If RCPacks.FocusedRow.Record.Item(COL_DESCRIPCION).Caption = "" Then

            ObjError.SetMensaje("DESCRIPCIÓN no se puede dejar vacia")

            If ObjError.Control1 = "" Then
                ObjError.Control1 = "ReportControl"
                'ObjError.Pie1 = True
                ObjError.Foco1 = COL_DESCRIPCION
            End If

            HayErrores = True
        Else ' Columna tipo no se puede repetir
            If EnPie Then
                If ComprobarRepetidoPack(RCPacks.FocusedRow.Record.Item(COL_DESCRIPCION).Value) = True Then
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
        If RCPacks.FocusedRow.Record.Item(COL_PRODUCTO1).Caption = "" Then

            ObjError.SetMensaje("PRODUCTO 1 no se puede dejar vacio")

            If ObjError.Control1 = "" Then
                ObjError.Control1 = "ReportControl"
                'ObjError.Pie1 = True
                ObjError.Foco1 = COL_PRODUCTO1
            End If
            HayErrores = True
        End If
        If RCPacks.FocusedRow.Record.Item(COL_PRODUCTO2).Caption = "" Then

            ObjError.SetMensaje("PRODUCTO 2 no se puede dejar vacio")

            If ObjError.Control1 = "" Then
                ObjError.Control1 = "ReportControl"
                'ObjError.Pie1 = True
                ObjError.Foco1 = COL_PRODUCTO2
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
                RCPacks.Navigator.CurrentFocusInFootersRows = True
            End If

            RCPacks.Navigator.MoveToColumn(RCPacks.Columns.Find(objError.Foco1).Index, False)
            RCPacks.Navigator.BeginEdit()
        End If

    End Sub

    Private Sub RCPacks_PreviewKeyDownEvent(sender As Object, e As _DReportControlEvents_PreviewKeyDownEvent) Handles RCPacks.PreviewKeyDownEvent
        Dim proximaColumna As Integer
        Dim esPies As Boolean

        esPies = False

        Select Case e.keyCode
            Case 13 'Enter

                If RCPacks.FocusedRow.Section.Index = 2 Then
                    esPies = True
                End If

                proximaColumna = SiguienteColumnaEditable(RCPacks, RCPacks.FocusedColumn.Index, esPies)

                ' RCProductos.Populate()
                If esPies = True Then
                    RCPacks.Navigator.CurrentFocusInFootersRows = True
                End If

                RCPacks.Navigator.MoveToColumn(proximaColumna, False)

                RCPacks.Navigator.BeginEdit()

                If RCPacks.Columns(proximaColumna).ItemIndex = COL_AÑADIR Then
                    '   RCProductos.FooterRows(0).Record.Item(COL_AÑADIR)
                    RCPacks_ItemButtonClick()
                End If

            Case 9 'Tab
                If e.shift = 1 Then
                    If RCPacks.FocusedRow.Section.Index = 2 Then
                        esPies = True
                    End If

                    proximaColumna = AnteriorColumnaEditable(RCPacks, RCPacks.FocusedColumn.Index, esPies)

                    RCPacks.Populate()
                    If esPies = True Then
                        RCPacks.Navigator.CurrentFocusInFootersRows = True
                    End If

                    RCPacks.Navigator.MoveToColumn(proximaColumna, False)

                    RCPacks.Navigator.BeginEdit()

                    e.cancel = True
                Else
                    If RCPacks.FocusedRow.Section.Index = 2 Then
                        esPies = True
                    End If

                    proximaColumna = SiguienteColumnaEditable(RCPacks, RCPacks.FocusedColumn.Index, esPies)

                    RCPacks.Populate()
                    If esPies = True Then
                        RCPacks.Navigator.CurrentFocusInFootersRows = True
                    End If

                    RCPacks.Navigator.MoveToColumn(proximaColumna, False)

                    RCPacks.Navigator.BeginEdit()
                    e.cancel = True
                End If

            Case 16
                e.cancel = True

            Case 38
                RCPacks.Populate()
                RCPacks.Navigator.MoveUp()
                RCPacks.Navigator.BeginEdit()
                e.cancel = True

            Case 40
                RCPacks.Populate()
                RCPacks.Navigator.MoveDown()
                RCPacks.Navigator.BeginEdit()
                e.cancel = True

        End Select

        If Not RCPacks.FocusedColumn Is Nothing Then
            Select Case RCPacks.FocusedColumn.ItemIndex
                Case COL_PRECIO
                    If e.keyCode = 110 Then e.keyCode = 188 '(si pulsa la tecla del punto en el teclado númerico, lo cambio por la coma)
                    If e.keyCode = 190 Then e.keyCode = 188 '(si pulsa la tecla del punto del teclado normal, lo cambio por la coma)

            End Select
        End If

    End Sub

    Private Sub RCPacks_ValueChanging(sender As Object, e As _DReportControlEvents_ValueChangingEvent) Handles RCPacks.ValueChanging

        Dim ObjError As New Errores

        HayErrores = False
        ObjError.Pantalla1 = Me
        ObjError.Tipo1 = 1 'Alertas

        Select Case e.column.ItemIndex
            Case COL_PRECIO
                e.newValue = Format(CDbl(e.newValue), FormatoImporte)
        End Select

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

    Private Sub FrmPacks_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        fPacks = Nothing

        MDIPrincipal.RibbonBar.RemoveTab(DEFMENU.GRUPO_MAESTROS_PACKS)
        'MDIPrincipal.RibbonBar.Reset()
        MDIPrincipal.RibbonBar.RedrawBar()
        MDIPrincipal.RibbonBar.RecalcLayout()

        MDIPrincipal.RibbonBar.FindTab(DEFMENU.TAB_MAESTROS).Selected = True
        MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_MAESTROS_PACKS).Visible = False

    End Sub

    Sub ConstruirMenu()

        If MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_MAESTROS_PACKS) Is Nothing Then 'si no existe lo creo
            TabPantalla = MDIPrincipal.RibbonBar.InsertTab(DEFMENU.GRUPO_MAESTROS_PACKS, "&Packs")
            TabPantalla.Id = DEFMENU.GRUPO_MAESTROS_PACKS

            'GroupFile = TabPrincipal.Groups.AddGroup("&MANTE", 1001)
            'GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.PRINCIPAL_MANTENIMIENTO, "Mantenimiento", False, False)
            GroupFile = TabPantalla.Groups.AddGroup("&PACKS", DEFMENU.GRUPO_MAESTROS_PACKS)
            GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_PACKS_NUEVO, "Nuevo", False, False).IconId = 100
            GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_PACKS_ELIMINAR, "Eliminar", False, False).IconId = 101
            GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_PACKS_IMPRIMIR, "Imprimir", False, False).IconId = 102
            GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_PACKS_SALIR, "Salir", False, False).IconId = 103
        End If

        MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_MAESTROS_PACKS).Visible = True
        MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_MAESTROS_PACKS).Selected = True

    End Sub

    Private Sub FrmPacks_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        ConstruirMenu()
    End Sub

    Sub Menu_Nuevo()
        Dim proximaColumna As Integer

        RCPacks.Navigator.CurrentFocusInFootersRows = True
        proximaColumna = SiguienteColumnaEditable(RCPacks, -1, True)
        RCPacks.Navigator.MoveToColumn(proximaColumna)
        RCPacks.Navigator.BeginEdit()
    End Sub

    Sub Menu_Eliminar()

        Dim ObjError As New Errores

        If RCPacks.FocusedRow.Section.Index <> 1 Then Exit Sub

        If Permisos <> 2 Then
            ObjError.Pantalla1 = Me
            ObjError.Tipo1 = 1 'Avisos

            ObjError.Titulo = "Packs"

            ObjError.SetMensaje("No dispone de Permiso para Eliminar Packs")

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

            ObjError.Titulo = "Packs"

            ObjError.SetMensaje("Este Pack tiene registros relacionados," & Chr(13) & "elimínelos antes.")

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

        ObjError.Titulo = "Packs"

        ObjError.SetMensaje("¿Desea eliminar el Pack seleccionado?")

        ObjError.Control1 = ""
        ObjError.Pie1 = True
        ObjError.Foco1 = COL_DESCRIPCION

        FrmError.ObjError = ObjError
        FrmError.ShowDialog()
        'ControlErrores(ObjError)

        If FrmError.DialogResult = DialogResult.Yes Then
            FrmError.Dispose()
            Dim E As ReportRow
            E = RCPacks.FocusedRow
            Dim objPack = New Pack(E.Record.Item(COL_ID).Value, E.Record.Item(COL_DESCRIPCION).Value, E.Record.Item(COL_PRECIO).Value, E.Record.Item(COL_RED1).Value, E.Record.Item(COL_MANTE1).Value, E.Record.Item(COL_ACTUALIZAR1).Value, E.Record.Item(COL_RED2).Value, E.Record.Item(COL_MANTE2).Value, E.Record.Item(COL_ACTUALIZAR2).Value, (E.Record.Item(COL_IDPRODUCTO1).Value), (E.Record.Item(COL_IDPRODUCTO2).Value))
            EliminarPack(objPack)
            RCPacks.RemoveRowEx(RCPacks.FocusedRow)
        ElseIf FrmError.DialogResult = DialogResult.Cancel Then
            FrmError.Dispose()
        End If
    End Sub

    Sub Menu_Imprimir()
        RCPacks.PrintOptions.Header.TextCenter = Me.Titulo.Caption
        RCPacks.PrintOptions.Header.Font.Size = 18
        RCPacks.PrintOptions.Header.Font.Bold = True
        'RCPACKS.PrintPreviewOptions.Title = Me.Titulo.Caption
        RCPacks.PrintPreview(True)
    End Sub

    Function ComprobarRelaciones() As Boolean
        'Miro si hay algún registro relacionado en tabla Versiones
        ComprobarRelaciones = False
        Dim E As ReportRow
        E = RCPacks.FocusedRow
        'Dim objPack = New Pack(E.Record.Item(COL_ID).Value, E.Record.Item(COL_DESCRIPCION).Value)
        'If objPack.ArrayUsuarios1.Count > 0 Then
        '    ComprobarRelaciones = True
        'End If

        'También habrá que mirar si tiene movimientos o está en packs o en productosclientes

    End Function

    Private Sub RCPacks_InplaceEditChanging(sender As Object, e As _DReportControlEvents_InplaceEditChangingEvent) Handles RCPacks.InplaceEditChanging
        Select Case e.column.ItemIndex
            Case COL_PRECIO
                If Len(e.newValue) > 0 Then
                    If e.newValue <> "-" Then
                        e.cancel = Not IsNumeric(e.newValue)
                    End If
                End If

        End Select
    End Sub

    Private Sub RCPacks_GotFocus(sender As Object, e As EventArgs) Handles RCPacks.GotFocus
        Dim MiItem As XtremeReportControl.ReportRecordItem

        If RCPacks.Records.Count = 0 Then Exit Sub

        MiItem = RCPacks.FocusedRow.Record.Item(COL_AÑADIR)
        MiItem.ItemControls.AddButton(0)
        MiItem.ItemControls(0).SetSize(48, 48)
        MiItem.ItemControls(0).Themed = True
        MiItem.ItemControls(0).SetIconIndex(0, 2)
        MiItem.Alignment = XTPColumnAlignment.xtpAlignmentCenter
    End Sub

    Private Sub RCPacks_FocusChanging(sender As Object, e As _DReportControlEvents_FocusChangingEvent) Handles RCPacks.FocusChanging
        Dim X As Long
        For X = 0 To RCPacks.Rows.Count - 1
            RCPacks.Rows(X).Record.Item(COL_AÑADIR).ItemControls.RemoveAll()
        Next X

        RCPacks.FooterRows(0).Record.Item(COL_AÑADIR).ItemControls.RemoveAll()

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