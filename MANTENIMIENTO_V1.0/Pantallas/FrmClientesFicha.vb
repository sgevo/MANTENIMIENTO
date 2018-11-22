Imports AxXtremeReportControl
Imports XtremeReportControl
Imports MantEvolution.DefinicionesMenus

Public Class FrmClientesFicha

    Const COL_CAMPO_ID = 0
    Const COL_CAMPO_DESC = 1
    Const COL_VALOR = 2


    Const CAT_DATOSGENERALES = 100
    Const CAT_DATCONTACTO = 101
    Const CAT_USUARIO1 = 102
    Const CAT_USUARIO2 = 103
    Const CAT_USUARIO3 = 104
    Const CAT_USUARIO4 = 105
    Const CAT_DATVARIOS = 106
    Const CAT_DATTIENEASESOR = 107
    Const CAT_DATCOBRO = 108


    'Datos Identificativos

    Const CAMP_ID = 0
    Const CAMP_CIF = 1
    Const CAMP_RAZONSOCIAL = 2
    Const CAMP_NOMBRECOMERCIAL = 3
    Const CAMP_DIRECCION = 4
    Const CAMP_CP = 5
    Const CAMP_POBLACION = 6
    Const CAMP_PROVINCIA = 7
    Const CAMP_WEB = 8
    Const CAMP_TELF1 = 9
    Const CAMP_TELF2 = 10
    Const CAMP_FAX = 11


    'Datos de Contacto

    Const CAMP_GERENTE = 12

    Const CAMP_NOMBREUSUARIO1 = 13
    Const CAMP_TELEFONOUSUARIO1 = 14
    Const CAMP_EMAILUSUARIO1 = 15

    Const CAMP_NOMBREUSUARIO2 = 16
    Const CAMP_TELEFONOUSUARIO2 = 17
    Const CAMP_EMAILUSUARIO2 = 18

    Const CAMP_NOMBREUSUARIO3 = 19
    Const CAMP_TELEFONOUSUARIO3 = 20
    Const CAMP_EMAILUSUARIO3 = 21

    Const CAMP_NOMBREUSUARIO4 = 22
    Const CAMP_TELEFONOUSUARIO4 = 23
    Const CAMP_EMAILUSUARIO4 = 24


    'Datos Generales
    Const CAMP_ESTADO = 25
    Const CAMP_ESASESOR = 26

    Const CAMP_ENVIOINFORMACION = 27
    Const CAMP_LLAMADASEGUIMIENTO = 28
    Const CAMP_RUTABD = 29

    'Tiene Asesor
    Const CAMP_ASESORID = 30
    Const CAMP_ASESORCODIGO = 31

    Const CAMP_ASESORRAZONSOCIAL = 32
    Const CAMP_ASESORESCLIENTE = 33


    'Datos bancarios 
    Const CAMP_FORMAPAGO = 34
    Const CAMP_FORMAPAGOPAIS = 35
    Const CAMP_FORMAPAGODC = 36
    Const CAMP_FORMAPAGOCUENTA = 37




    Public ObjCliente As Cliente
    Dim TabPantalla As XtremeCommandBars.RibbonTab = Nothing
    Dim GroupFile As XtremeCommandBars.RibbonGroup = Nothing


    Private Sub FrmClientesFicha_Load(sender As Object, e As EventArgs) Handles Me.Load


        With RCClientes

            .PaintManager.ColumnStyle = XtremeReportControl.XTPReportColumnStyle.xtpColumnResource
            .PaintManager.CaptionFont.Name = "Tahoma"
            .PaintManager.CaptionFont.Bold = True
            '.PaintManager.CaptionFont.Size = CurrentFont + 2
            .PaintManager.TextFont.Name = "Tahoma"
            .PaintManager.NoItemsText = "No hay elementos que mostrar"
            '.PaintManager.TextFont.Size = CurrentFont + 2
            '.PaintManager.HorizontalGridStyle = xtpGridSolid
            .PaintManager.VerticalGridStyle = XTPReportGridStyle.xtpGridSolid

            'Esto es para quitar las cabeceras
            .ShowHeader = False

            .PaintManager.FixedRowHeight = False

            .FullColumnScrolling = True


            .Columns.DeleteAll()

            .Columns.Add(COL_CAMPO_ID, "CAMPO_ID", 100, True)
            .Columns.Add(COL_CAMPO_DESC, "CAMPO_DESC", 50, True)
            .Columns.Add(COL_VALOR, "VALOR", 100, True)


            .Columns.Find(COL_CAMPO_ID).Visible = False

            .Columns.Find(COL_CAMPO_DESC).TreeColumn = True
            .Columns.Find(COL_CAMPO_DESC).Editable = False

            .Columns.Find(COL_VALOR).Editable = True
            .Columns.Find(COL_VALOR).EditOptions.SelectTextOnEdit = True

            .Populate()

        End With


        With RCClientes2

            .PaintManager.ColumnStyle = XtremeReportControl.XTPReportColumnStyle.xtpColumnResource
            .PaintManager.CaptionFont.Name = "Tahoma"
            .PaintManager.CaptionFont.Bold = True
            '.PaintManager.CaptionFont.Size = CurrentFont + 2
            .PaintManager.TextFont.Name = "Tahoma"
            .PaintManager.NoItemsText = "No hay elementos que mostrar"

            .PaintManager.VerticalGridStyle = XTPReportGridStyle.xtpGridSolid

            .PaintManager.FixedRowHeight = False

            .FullColumnScrolling = True


            'Esto es para quitar las cabeceras
            .ShowHeader = False



            .Columns.DeleteAll()

            .Columns.Add(COL_CAMPO_ID, "CAMPO_ID", 100, True)
            .Columns.Add(COL_CAMPO_DESC, "CAMPO_DESC", 50, True)
            .Columns.Add(COL_VALOR, "VALOR", 100, True)


            .Columns.Find(COL_CAMPO_ID).Visible = False

            .Columns.Find(COL_CAMPO_DESC).TreeColumn = True
            .Columns.Find(COL_CAMPO_DESC).Editable = False

            .Columns.Find(COL_VALOR).Editable = True
            .Columns.Find(COL_VALOR).EditOptions.SelectTextOnEdit = True

            .Populate()

        End With

        CargarColumnasReport()

        CargaReport()

        fClientesFicha = Me


    End Sub


    Sub CargaReport()


        setValor(RCClientes, CAMP_ID, Valor:=ObjCliente.Id1)

        setValor(RCClientes, CAMP_CIF, Valor:=ObjCliente.Cif1)
        setValor(RCClientes, CAMP_RAZONSOCIAL, Valor:=ObjCliente.RazonSocial1)
        setValor(RCClientes, CAMP_NOMBRECOMERCIAL, Valor:=ObjCliente.NombreComercial1)
        setValor(RCClientes, CAMP_DIRECCION, Valor:=ObjCliente.Direccion1)
        setValor(RCClientes, CAMP_CP, Valor:=ObjCliente.CP1)
        setValor(RCClientes, CAMP_POBLACION, Valor:=ObjCliente.Poblacion1)

        setValor(RCClientes, CAMP_PROVINCIA, Valor:=ObjCliente.IdProvincia1)
        setValor(RCClientes, CAMP_WEB, Valor:=ObjCliente.Web1)
        setValor(RCClientes, CAMP_TELF1, Valor:=ObjCliente.Telefono1)
        setValor(RCClientes, CAMP_TELF2, Valor:=ObjCliente.Telefono21)
        setValor(RCClientes, CAMP_FAX, Valor:=ObjCliente.Fax1)

        setValor(RCClientes, CAMP_GERENTE, Valor:=ObjCliente.GerenteNombre1)


        setValor(RCClientes, CAMP_NOMBREUSUARIO1, Valor:=ObjCliente.UsuarioNombre11)
        setValor(RCClientes, CAMP_TELEFONOUSUARIO1, Valor:=ObjCliente.UsuarioTelefono11)
        setValor(RCClientes, CAMP_EMAILUSUARIO1, Valor:=ObjCliente.UsuarioEmail11)


        setValor(RCClientes, CAMP_NOMBREUSUARIO2, Valor:=ObjCliente.UsuarioNombre21)
        setValor(RCClientes, CAMP_TELEFONOUSUARIO2, Valor:=ObjCliente.UsuarioTelefono21)
        setValor(RCClientes, CAMP_EMAILUSUARIO2, Valor:=ObjCliente.UsuarioEmail21)

        setValor(RCClientes, CAMP_NOMBREUSUARIO3, Valor:=ObjCliente.UsuarioNombre31)
        setValor(RCClientes, CAMP_TELEFONOUSUARIO3, Valor:=ObjCliente.UsuarioTelefono31)
        setValor(RCClientes, CAMP_EMAILUSUARIO3, Valor:=ObjCliente.UsuarioEmail31)

        setValor(RCClientes, CAMP_NOMBREUSUARIO4, Valor:=ObjCliente.UsuarioNombre41)
        setValor(RCClientes, CAMP_TELEFONOUSUARIO4, Valor:=ObjCliente.UsuarioTelefono41)
        setValor(RCClientes, CAMP_EMAILUSUARIO4, Valor:=ObjCliente.UsuarioEmail41)




        'Tiene Asesor
        '    setValor(RCClientes2, CAMP_ASESORID, Valor:=ObjCliente.)
        'setValor(RCClientes2, CAMP_ASESORCODIGO, Valor:=ObjCliente.UsuarioTelefono21)
        'setValor(RCClientes2, CAMP_ASESORRAZONSOCIAL, Valor:=ObjCliente.UsuarioEmail21)
        'setValor(RCClientes2, CAMP_ASESORESCLIENTE, Valor:=ObjCliente.UsuarioNombre31)

        setValor(RCClientes2, CAMP_ENVIOINFORMACION, Valor:=ObjCliente.EnviarInfo1)


        setValor(RCClientes2, CAMP_FORMAPAGO, Valor:=ObjCliente.FormaPago1)



        setValor(RCClientes2, CAMP_FORMAPAGOPAIS, Valor:=ObjCliente.IbanPais1)
        setValor(RCClientes2, CAMP_FORMAPAGODC, Valor:=ObjCliente.IbanDc1)
        setValor(RCClientes2, CAMP_FORMAPAGOCUENTA, Valor:=ObjCliente.IbanCuenta1)



        'Const CAMP_ASESORID = 30
        'Const CAMP_ASESORCODIGO = 31

        'Const CAMP_ASESORRAZONSOCIAL = 32
        'Const CAMP_ASESORESCLIENTE = 33


        ''Datos bancarios 
        'Const CAMP_FORMAPAGO = 34
        'Const CAMP_FORMAPAGOPAIS = 35
        'Const CAMP_FORMAPAGODC = 36
        'Const CAMP_FORMAPAGOCUENTA = 37


        '     RCClientes.Rows(CAMP_ID).Item(COL_VALOR).Value = ObjCliente.Id1
        '  RCClientes.Rows(CAMP_GERENTE).Record.Item(COL_VALOR).Value = ObjCliente.GerenteNombre1
        '   RCClientes.Rows(CAMP_NOMBREUSUARIO1).Record.Item(COL_VALOR).Value = ObjCliente.UsuarioNombre11

        '  RCClientes.Populate()

        '  Debug.Print(RCClientes.Records(CAMP_NOMBREUSUARIO1).Index)

    End Sub




    Private Sub FrmClientesFicha_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        ConfigurarPantalla()
    End Sub

    Sub ConfigurarPantalla()

        Titulo.Top = 0
        Titulo.Left = 0
        Titulo.Width = Me.Width

        RCClientes.Left = 10
        RCClientes.Width = (Me.Width - 20) / 2

        RCClientes.Top = Titulo.Height
        RCClientes.Height = Me.Height - RCClientes.Top - 20


        RCClientes2.Left = RCClientes.Left + RCClientes.Width
        RCClientes2.Width = (Me.Width - 20) / 2

        RCClientes2.Top = Titulo.Height
        RCClientes2.Height = Me.Height - RCClientes.Top - 20

    End Sub




    Sub CargarColumnasReport()

        Dim Cat_Desc As String
        Dim Cat_Record As ReportRecord
        Dim Camp_Record As ReportRecord
        Dim Camp_RecordPadre As ReportRecord

        RCClientes.Records.DeleteAll()
        RCClientes.PaintManager.AllowMergeCells = True

        RCClientes2.PaintManager.AllowMergeCells = True

        'Cabecera de datos generales
        Cat_Desc = "Datos Generales"
        Cat_Record = AddCategoria(CAT_DATOSGENERALES, Cat_Desc)
        RCClientes.Records.MergeItems(RCClientes.Records.Count - 1, RCClientes.Records.Count - 1, COL_CAMPO_DESC, COL_VALOR)
        Cat_Record.Expanded = True


        Camp_Record = AddFila(Cat_Record, CAMP_ID, "Código Cliente", "")
        Camp_Record(COL_CAMPO_DESC).Bold = True
        Camp_Record(COL_VALOR).CreateEditOptions()
        Camp_Record(COL_VALOR).EditOptions.MaxLength = 9

        'CIF
        Camp_Record = AddFila(Cat_Record, CAMP_CIF, "CIF / NIF", "")
        Camp_Record(COL_CAMPO_DESC).Bold = True
        Camp_Record(COL_VALOR).EditOptions.MaxLength = 20

        'RAZON SOCIAL
        Camp_Record = AddFila(Cat_Record, CAMP_RAZONSOCIAL, "Razon Social", "")
        Camp_Record(COL_CAMPO_DESC).Bold = True
        Camp_Record(COL_VALOR).EditOptions.MaxLength = 50

        'NOMBRE COMERCIAL
        Camp_Record = AddFila(Cat_Record, CAMP_NOMBRECOMERCIAL, "Nombre Comercial", "")
        Camp_Record(COL_CAMPO_DESC).Bold = True
        Camp_Record(COL_VALOR).EditOptions.MaxLength = 50


        'DIRECCION
        Camp_Record = AddFila(Cat_Record, CAMP_DIRECCION, "Dirección", "")
        Camp_Record(COL_CAMPO_DESC).Bold = True
        Camp_Record(COL_VALOR).EditOptions.MaxLength = 50

        'CP
        Camp_Record = AddFila(Cat_Record, CAMP_CP, "Codigo Postal", "")
        Camp_Record(COL_CAMPO_DESC).Bold = True
        Camp_Record(COL_VALOR).EditOptions.MaxLength = 5


        'Población
        Camp_Record = AddFila(Cat_Record, CAMP_POBLACION, "Población", "")
        Camp_Record(COL_CAMPO_DESC).Bold = True
        Camp_Record(COL_VALOR).EditOptions.MaxLength = 50

        'Provincia
        Camp_Record = AddFila(Cat_Record, CAMP_PROVINCIA, "Provincia", "")
        Camp_Record(COL_CAMPO_DESC).Bold = True
        PonCombo(Camp_Record(COL_VALOR))
        Dim ArrayProvincias As New ArrayList()
        Dim ObjProvincia As Provincia
        ArrayProvincias = ObtenerTodasLasProvincias()

        For Each ObjProvincia In ArrayProvincias

            Camp_Record(COL_VALOR).EditOptions.Constraints.Add(ObjProvincia.Provincia1, ObjProvincia.Id1)

        Next




        'WEB
        Camp_Record = AddFila(Cat_Record, CAMP_WEB, "Web", "")
        Camp_Record(COL_CAMPO_DESC).Bold = True
        Camp_Record(COL_VALOR).EditOptions.MaxLength = 50


        'Telefono 1
        Camp_Record = AddFila(Cat_Record, CAMP_TELF1, "Telefono 1", "")
        Camp_Record(COL_CAMPO_DESC).Bold = True
        Camp_Record(COL_VALOR).EditOptions.MaxLength = 25


        'Telefono 2
        Camp_Record = AddFila(Cat_Record, CAMP_TELF2, "Telefono 2", "")
        Camp_Record(COL_CAMPO_DESC).Bold = True
        Camp_Record(COL_VALOR).EditOptions.MaxLength = 25

        'Fax
        Camp_Record = AddFila(Cat_Record, CAMP_FAX, "Fax", "")
        Camp_Record(COL_CAMPO_DESC).Bold = True
        Camp_Record(COL_VALOR).EditOptions.MaxLength = 25




        'CABECERA DE DATOS DE CONTACTO


        Cat_Desc = "Datos De Contacto"
        Cat_Record = AddCategoria(CAT_DATCONTACTO, Cat_Desc)
        RCClientes.Records.MergeItems(RCClientes.Records.Count - 1, RCClientes.Records.Count - 1, COL_CAMPO_DESC, COL_VALOR)
        Cat_Record.Expanded = True

        'Gerente
        Camp_Record = AddFila(Cat_Record, CAMP_GERENTE, "Gerente", "")
        Camp_Record(COL_CAMPO_DESC).Bold = True
        Camp_Record(COL_VALOR).EditOptions.MaxLength = 50


        'Cat Usuario 1
        Camp_RecordPadre = AddFila(Cat_Record, CAT_USUARIO1, "Usuario 1", "")
        Camp_RecordPadre(COL_CAMPO_DESC).Bold = True
        Camp_RecordPadre.Records.MergeItems(Camp_RecordPadre.Records.Count - 1, Camp_RecordPadre.Records.Count - 1, COL_CAMPO_DESC, COL_VALOR)
        Camp_RecordPadre.Expanded = True
        Camp_RecordPadre(COL_VALOR).Editable = False
        Camp_Record(COL_VALOR).EditOptions.MaxLength = 50

        'Nombre Usu 1
        Camp_Record = AddFila(Camp_RecordPadre, CAMP_NOMBREUSUARIO1, "Nombre", "")
        Camp_Record(COL_CAMPO_DESC).Bold = True
        Camp_Record(COL_VALOR).EditOptions.MaxLength = 50

        Camp_Record = AddFila(Camp_RecordPadre, CAMP_TELEFONOUSUARIO1, "Telefono", "")
        Camp_Record(COL_CAMPO_DESC).Bold = True
        Camp_Record(COL_VALOR).EditOptions.MaxLength = 50

        Camp_Record = AddFila(Camp_RecordPadre, CAMP_EMAILUSUARIO1, "Email", "")
        Camp_Record(COL_CAMPO_DESC).Bold = True
        Camp_Record(COL_VALOR).EditOptions.MaxLength = 50



        'Cat Usuario 2
        Camp_RecordPadre = AddFila(Cat_Record, CAT_USUARIO2, "Usuario 2", "")
        Camp_RecordPadre(COL_CAMPO_DESC).Bold = True
        Camp_RecordPadre.Records.MergeItems(Camp_RecordPadre.Records.Count - 1, Camp_RecordPadre.Records.Count - 1, COL_CAMPO_DESC, COL_VALOR)
        Camp_RecordPadre.Expanded = True
        Camp_RecordPadre(COL_VALOR).Editable = False

        'Nombre Usu 2
        Camp_Record = AddFila(Camp_RecordPadre, CAMP_NOMBREUSUARIO2, "Nombre", "")
        Camp_Record(COL_CAMPO_DESC).Bold = True
        Camp_Record(COL_VALOR).EditOptions.MaxLength = 50

        Camp_Record = AddFila(Camp_RecordPadre, CAMP_TELEFONOUSUARIO2, "Telefono", "")
        Camp_Record(COL_CAMPO_DESC).Bold = True
        Camp_Record(COL_VALOR).EditOptions.MaxLength = 50

        Camp_Record = AddFila(Camp_RecordPadre, CAMP_EMAILUSUARIO2, "Email", "")
        Camp_Record(COL_CAMPO_DESC).Bold = True
        Camp_Record(COL_VALOR).EditOptions.MaxLength = 50



        'Cat Usuario 3
        Camp_RecordPadre = AddFila(Cat_Record, CAT_USUARIO3, "Usuario 3", "")
        Camp_RecordPadre(COL_CAMPO_DESC).Bold = True
        Camp_RecordPadre.Records.MergeItems(Camp_RecordPadre.Records.Count - 1, Camp_RecordPadre.Records.Count - 1, COL_CAMPO_DESC, COL_VALOR)
        Camp_RecordPadre.Expanded = True
        Camp_RecordPadre(COL_VALOR).Editable = False


        'Nombre Usu 3
        Camp_Record = AddFila(Camp_RecordPadre, CAMP_NOMBREUSUARIO3, "Nombre", "")
        Camp_Record(COL_CAMPO_DESC).Bold = True
        Camp_Record(COL_VALOR).EditOptions.MaxLength = 50

        Camp_Record = AddFila(Camp_RecordPadre, CAMP_TELEFONOUSUARIO3, "Telefono", "")
        Camp_Record(COL_CAMPO_DESC).Bold = True
        Camp_Record(COL_VALOR).EditOptions.MaxLength = 50

        Camp_Record = AddFila(Camp_RecordPadre, CAMP_EMAILUSUARIO3, "Email", "")
        Camp_Record(COL_CAMPO_DESC).Bold = True
        Camp_Record(COL_VALOR).EditOptions.MaxLength = 50


        'Cat Usuario 4
        Camp_RecordPadre = AddFila(Cat_Record, CAT_USUARIO4, "Usuario 4", "")

        Camp_RecordPadre(COL_CAMPO_DESC).Bold = True
        Camp_RecordPadre.Records.MergeItems(Camp_RecordPadre.Records.Count - 1, Camp_RecordPadre.Records.Count - 1, COL_CAMPO_DESC, COL_VALOR)
        Camp_RecordPadre.Expanded = True
        Camp_RecordPadre(COL_VALOR).Editable = False


        'Nombre Usu 4
        Camp_Record = AddFila(Camp_RecordPadre, CAMP_NOMBREUSUARIO4, "Nombre", "")
        Camp_Record(COL_CAMPO_DESC).Bold = True
        Camp_Record(COL_VALOR).EditOptions.MaxLength = 50

        Camp_Record = AddFila(Camp_RecordPadre, CAMP_TELEFONOUSUARIO4, "Telefono", "")
        Camp_Record(COL_CAMPO_DESC).Bold = True
        Camp_Record(COL_VALOR).EditOptions.MaxLength = 50

        Camp_Record = AddFila(Camp_RecordPadre, CAMP_EMAILUSUARIO4, "Email", "")
        Camp_Record(COL_CAMPO_DESC).Bold = True
        Camp_Record(COL_VALOR).EditOptions.MaxLength = 50




        ''CATEGORIA VARIOS

        Cat_Desc = "Datos Varios"
        Cat_Record = AddCategoria2(CAT_DATVARIOS, Cat_Desc)
        RCClientes2.Records.MergeItems(RCClientes2.Records.Count - 1, RCClientes2.Records.Count - 1, COL_CAMPO_DESC, COL_VALOR)
        Cat_Record.Expanded = True

        'estado
        Camp_Record = AddFila(Cat_Record, CAMP_ESTADO, "Estado", "")
        Camp_Record(COL_CAMPO_DESC).Bold = True

        'Gerente
        Camp_Record = AddFila(Cat_Record, CAMP_ESASESOR, "Es Asesor", "")
        Camp_Record(COL_CAMPO_DESC).Bold = True
        PonCheckbox(Camp_Record(COL_VALOR))

        'Gerente
        Camp_Record = AddFila(Cat_Record, CAMP_ENVIOINFORMACION, "Envio de Información", "")
        Camp_Record(COL_CAMPO_DESC).Bold = True
        PonCheckbox(Camp_Record(COL_VALOR))
        'Gerente
        Camp_Record = AddFila(Cat_Record, CAMP_LLAMADASEGUIMIENTO, "Llamada de Seguimiento", "")
        Camp_Record(COL_CAMPO_DESC).Bold = True

        'Gerente
        Camp_Record = AddFila(Cat_Record, CAMP_RUTABD, "Ruta de BD", "")
        Camp_Record(COL_CAMPO_DESC).Bold = True

        Cat_Desc = "Tiene Asesor"
        Cat_Record = AddCategoria2(CAT_DATTIENEASESOR, Cat_Desc)
        RCClientes2.Records.MergeItems(RCClientes2.Records.Count - 1, RCClientes2.Records.Count - 1, COL_CAMPO_DESC, COL_VALOR)
        Cat_Record.Expanded = True


        'estado
        Camp_Record = AddFila(Cat_Record, CAMP_ASESORID, "ID ASESOR", "")
        Camp_Record(COL_CAMPO_DESC).Bold = True
        Camp_Record.Visible = False

        Camp_Record = AddFila(Cat_Record, CAMP_ASESORCODIGO, "Codigo Asesor", "")
        Camp_Record(COL_CAMPO_DESC).Bold = True

        Camp_Record = AddFila(Cat_Record, CAMP_ASESORRAZONSOCIAL, "Razon Social", "")
        Camp_Record(COL_CAMPO_DESC).Bold = True

        Camp_Record = AddFila(Cat_Record, CAMP_ASESORESCLIENTE, "Es el Asesor Cliente", "")
        Camp_Record(COL_CAMPO_DESC).Bold = True
        PonCheckbox(Camp_Record(COL_VALOR))

        ''DATOS COBRO

        Cat_Desc = "Datos Bancarios"
        Cat_Record = AddCategoria2(CAT_DATCOBRO, Cat_Desc)
        RCClientes2.Records.MergeItems(RCClientes2.Records.Count - 1, RCClientes2.Records.Count - 1, COL_CAMPO_DESC, COL_VALOR)
        Cat_Record.Expanded = True

        Camp_Record = AddFila(Cat_Record, CAMP_FORMAPAGO, "Forma de Pago", "")
        Camp_Record(COL_CAMPO_DESC).Bold = True
        PonCombo(Camp_Record(COL_VALOR))
        Dim ArrayFormasPagos As New ArrayList()
        Dim ObjFormaPago As FormaPago
        ArrayFormasPagos = ObtenerTodasFormasPagos()

        For Each ObjFormaPago In ArrayFormasPagos

            Camp_Record(COL_VALOR).EditOptions.Constraints.Add(ObjFormaPago.Descripcion1, ObjFormaPago.Id1)

        Next


        Camp_Record = AddFila(Cat_Record, CAMP_FORMAPAGOPAIS, "Cuenta Pais", "")
        Camp_Record(COL_CAMPO_DESC).Bold = True

        Camp_Record = AddFila(Cat_Record, CAMP_FORMAPAGODC, "Cuenta DC", "")
        Camp_Record(COL_CAMPO_DESC).Bold = True

        Camp_Record = AddFila(Cat_Record, CAMP_FORMAPAGOCUENTA, "Cuenta", "")
        Camp_Record(COL_CAMPO_DESC).Bold = True




        RCClientes.Populate()
        RCClientes2.Populate()




    End Sub



    Function AddCategoria(Cat_ID As Integer, Cat_Desc As String)

        Dim Cat_Record As ReportRecord
        Dim Item As ReportRecordItem

        Cat_Record = RCClientes.Records.Add
        Item = Cat_Record.AddItem(Cat_ID)
        'Item.Focusable = False
        Item = Cat_Record.AddItem(Cat_Desc)
        Item.Editable = False
        Item.Focusable = False
        Item.BackColor = RCClientes.PaintManager.GroupBoxBackColor
        Item.Bold = True
        Item = Cat_Record.AddItem("")
        Item.Focusable = False
        Item.Editable = False

        AddCategoria = Cat_Record

    End Function

    Function AddCategoria2(Cat_ID As Integer, Cat_Desc As String)

        Dim Cat_Record As ReportRecord
        Dim Item As ReportRecordItem

        Cat_Record = RCClientes2.Records.Add
        Item = Cat_Record.AddItem(Cat_ID)
        'Item.Focusable = False
        Item = Cat_Record.AddItem(Cat_Desc)
        Item.Editable = False
        Item.Focusable = False
        Item.BackColor = RCClientes2.PaintManager.GroupBoxBackColor
        Item.Bold = True
        Item = Cat_Record.AddItem("")
        Item.Focusable = False
        Item.Editable = False

        AddCategoria2 = Cat_Record

    End Function


    Function AddFila(Cat_Rd As ReportRecord, Campo_ID As Byte, Campo_Desc As String, Valor As Object) As ReportRecord

        Dim Record As ReportRecord
        Dim Item As ReportRecordItem

        Record = Cat_Rd.Childs.Add

        Item = Record.AddItem(Campo_ID)
        Item = Record.AddItem(Campo_Desc)
        Item.Alignment = XTPColumnAlignment.xtpAlignmentVCenter
        Item = Record.AddItem(Valor)
        Item.CreateEditOptions()
        Item.EditOptions.SelectTextOnEdit = True

        AddFila = Record

    End Function

    Sub PonCombo(Item As ReportRecordItem)

        Item.CreateEditOptions()
        Item.EditOptions.EditControlStyle = XTPReportEditStyle.xtpEditStyleUppercase
        Item.EditOptions.AddComboButton()
        Item.EditOptions.GetInplaceButton(0).InsideCellButton = True
        Item.EditOptions.ConstraintEdit = True
        Item.EditOptions.Constraints.DeleteAll()

    End Sub

    Sub PonCheckbox(Item As ReportRecordItem)

        Item.Value = ""
        Item.HasCheckbox = True
        Item.Alignment = XTPColumnAlignment.xtpAlignmentIconCenter

    End Sub

    Private Sub RCClientes2_ValueChanged(sender As Object, e As _DReportControlEvents_ValueChangedEvent) Handles RCClientes2.ValueChanged




    End Sub

    Private Sub RCClientes_ValueChanging(sender As Object, e As _DReportControlEvents_ValueChangingEvent) Handles RCClientes.ValueChanging




        Select Case CInt(e.item.Record(COL_CAMPO_ID).Value)
            Case CAMP_ID
                ObjCliente.Id1 = CLng(e.newValue)

            Case CAMP_CIF
                ObjCliente.Cif1 = CType(e.newValue, String)

            Case CAMP_RAZONSOCIAL
                ObjCliente.RazonSocial1 = CType(e.newValue, String)

            Case CAMP_NOMBRECOMERCIAL
                ObjCliente.NombreComercial1 = CType(e.newValue, String)

            Case CAMP_DIRECCION
                ObjCliente.Direccion1 = CType(e.newValue, String)

            Case CAMP_CP
                ObjCliente.CP1 = CType(e.newValue, String)

            Case CAMP_POBLACION
                ObjCliente.Poblacion1 = CType(e.newValue, String)

            Case CAMP_PROVINCIA
                ObjCliente.IdProvincia1 = CLng(e.newValue)

            Case CAMP_WEB
                ObjCliente.Web1 = CType(e.newValue, String)

            Case CAMP_TELF1
                ObjCliente.Telefono1 = CType(e.newValue, String)
            Case CAMP_TELF2
                ObjCliente.Telefono21 = CType(e.newValue, String)
            Case CAMP_FAX
                ObjCliente.Fax1 = CType(e.newValue, String)

            Case CAMP_GERENTE
                ObjCliente.GerenteNombre1 = CType(e.newValue, String)

            Case CAMP_NOMBREUSUARIO1
                ObjCliente.UsuarioNombre11 = CType(e.newValue, String)

            Case CAMP_TELEFONOUSUARIO1
                ObjCliente.UsuarioTelefono11 = CType(e.newValue, String)

            Case CAMP_EMAILUSUARIO1
                ObjCliente.UsuarioEmail11 = CType(e.newValue, String)

            Case CAMP_NOMBREUSUARIO2
                ObjCliente.UsuarioNombre21 = CType(e.newValue, String)

            Case CAMP_TELEFONOUSUARIO2
                ObjCliente.UsuarioTelefono21 = CType(e.newValue, String)

            Case CAMP_EMAILUSUARIO2
                ObjCliente.UsuarioEmail21 = CType(e.newValue, String)

            Case CAMP_NOMBREUSUARIO3
                ObjCliente.UsuarioNombre31 = CType(e.newValue, String)

            Case CAMP_TELEFONOUSUARIO3
                ObjCliente.UsuarioTelefono31 = CType(e.newValue, String)

            Case CAMP_EMAILUSUARIO3
                ObjCliente.UsuarioEmail31 = CType(e.newValue, String)

            Case CAMP_NOMBREUSUARIO4
                ObjCliente.UsuarioNombre41 = CType(e.newValue, String)

            Case CAMP_TELEFONOUSUARIO4
                ObjCliente.UsuarioTelefono41 = CType(e.newValue, String)

            Case CAMP_EMAILUSUARIO4
                ObjCliente.UsuarioEmail41 = CType(e.newValue, String)



        End Select






    End Sub





    Private Sub RCClientes_PreviewKeyDownEvent(sender As Object, e As _DReportControlEvents_PreviewKeyDownEvent) Handles RCClientes.PreviewKeyDownEvent
        Dim proximaFila As Integer
        Dim esPies As Boolean

        esPies = False

        Select Case e.keyCode
            Case 13 'Enter


                proximaFila = SiguienteFilaEditable(RCClientes, RCClientes.FocusedRow.Index)

                RCClientes.Navigator.MoveToRow(proximaFila, False)
                RCClientes.Navigator.MoveToColumn(2, False)
                RCClientes.Navigator.BeginEdit()


            Case 9 'Tab
                If e.shift = 1 Then


                    proximaFila = AnteriorFilaEditable(RCClientes, RCClientes.FocusedRow.Index)
                    RCClientes.Navigator.MoveToRow(proximaFila, False)
                    RCClientes.Navigator.MoveToColumn(2, False)
                    RCClientes.Navigator.BeginEdit()



                    e.cancel = True
                Else
                    proximaFila = SiguienteFilaEditable(RCClientes, RCClientes.FocusedRow.Index)

                    RCClientes.Navigator.MoveToRow(proximaFila, False)
                    RCClientes.Navigator.MoveToColumn(2, False)
                    RCClientes.Navigator.BeginEdit()
                    e.cancel = True
                End If

                '    Case 16
                '        e.cancel = True

            Case 38
                proximaFila = AnteriorFilaEditable(RCClientes, RCClientes.FocusedRow.Index)
                RCClientes.Navigator.MoveToRow(proximaFila, False)
                RCClientes.Navigator.MoveToColumn(2, False)
                RCClientes.Navigator.BeginEdit()



                e.cancel = True

            Case 40
                proximaFila = SiguienteFilaEditable(RCClientes, RCClientes.FocusedRow.Index)

                RCClientes.Navigator.MoveToRow(proximaFila, False)
                RCClientes.Navigator.MoveToColumn(2, False)
                RCClientes.Navigator.BeginEdit()

                e.cancel = True


                'End Select

                'If Not RCProductos.FocusedColumn Is Nothing Then
                '    Select Case RCProductos.FocusedColumn.ItemIndex
                '        Case COL_PRECIO, COL_PRECIORED
                '            If e.keyCode = 110 Then e.keyCode = 188 '(si pulsa la tecla del punto en el teclado númerico, lo cambio por la coma)
                '            If e.keyCode = 190 Then e.keyCode = 188 '(si pulsa la tecla del punto del teclado normal, lo cambio por la coma)

            Case Else
        End Select

    End Sub

    Private Sub RCClientes2_PreviewKeyDownEvent(sender As Object, e As _DReportControlEvents_PreviewKeyDownEvent) Handles RCClientes2.PreviewKeyDownEvent
        Dim proximaFila As Integer
        Dim esPies As Boolean

        esPies = False

        Select Case e.keyCode
            Case 13 'Enter


                proximaFila = SiguienteFilaEditable(RCClientes2, RCClientes2.FocusedRow.Index)

                RCClientes2.Navigator.MoveToRow(proximaFila, False)
                RCClientes2.Navigator.MoveToColumn(2, False)
                RCClientes2.Navigator.BeginEdit()


            Case 9 'Tab
                If e.shift = 1 Then


                    proximaFila = AnteriorFilaEditable(RCClientes2, RCClientes2.FocusedRow.Index)
                    RCClientes2.Navigator.MoveToRow(proximaFila, False)
                    RCClientes2.Navigator.MoveToColumn(2, False)
                    RCClientes2.Navigator.BeginEdit()



                    e.cancel = True
                Else
                    proximaFila = SiguienteFilaEditable(RCClientes2, RCClientes2.FocusedRow.Index)

                    RCClientes2.Navigator.MoveToRow(proximaFila, False)
                    RCClientes2.Navigator.MoveToColumn(2, False)
                    RCClientes2.Navigator.BeginEdit()
                    e.cancel = True
                End If

                '    Case 16
                '        e.cancel = True

            Case 38
                proximaFila = AnteriorFilaEditable(RCClientes2, RCClientes2.FocusedRow.Index)
                RCClientes2.Navigator.MoveToRow(proximaFila, False)
                RCClientes2.Navigator.MoveToColumn(2, False)
                RCClientes2.Navigator.BeginEdit()



                e.cancel = True

            Case 40
                proximaFila = SiguienteFilaEditable(RCClientes2, RCClientes2.FocusedRow.Index)

                RCClientes2.Navigator.MoveToRow(proximaFila, False)
                RCClientes2.Navigator.MoveToColumn(2, False)
                RCClientes2.Navigator.BeginEdit()

                e.cancel = True


                'End Select

                'If Not RCProductos.FocusedColumn Is Nothing Then
                '    Select Case RCProductos.FocusedColumn.ItemIndex
                '        Case COL_PRECIO, COL_PRECIORED
                '            If e.keyCode = 110 Then e.keyCode = 188 '(si pulsa la tecla del punto en el teclado númerico, lo cambio por la coma)
                '            If e.keyCode = 190 Then e.keyCode = 188 '(si pulsa la tecla del punto del teclado normal, lo cambio por la coma)

        End Select

    End Sub

    Private Sub AxReportControl1_ColumnClick(sender As Object, e As _DReportControlEvents_ColumnClickEvent)

    End Sub


    Sub ConstruirMenu()

        If MDIPrincipal.RibbonBar.FindTab(DEFMENU.MAESTROS_CLIENTES_FICHA) Is Nothing Then 'si no existe lo creo
            TabPantalla = MDIPrincipal.RibbonBar.InsertTab(DEFMENU.MAESTROS_CLIENTES_FICHA, "&CLIENTES")
            TabPantalla.Id = DEFMENU.MAESTROS_CLIENTES_FICHA

            'GroupFile = TabPrincipal.Groups.AddGroup("&MANTE", 1001)
            'GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.PRINCIPAL_MANTENIMIENTO, "Mantenimiento", False, False)
            GroupFile = TabPantalla.Groups.AddGroup("&CLIENTES", DEFMENU.MAESTROS_CLIENTES_FICHA)
            GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_CLIENTES_FICHA_NUEVO, "Nuevo", False, False).IconId = 100
            GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_CLIENTES_FICHA_GUARDAR, "Guardar", False, False).IconId = 100
            GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_CLIENTES_FICHA_ELIMINAR, "Eliminar", False, False).IconId = 100
            GroupFile.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DEFMENU.MAESTROS_CLIENTES_FICHA_SALIR, "Salir", False, False).IconId = 100
        End If

        MDIPrincipal.RibbonBar.FindTab(DEFMENU.MAESTROS_CLIENTES_FICHA).Visible = True
        MDIPrincipal.RibbonBar.FindTab(DEFMENU.MAESTROS_CLIENTES_FICHA).Selected = True

    End Sub

    Private Sub FrmClientesFicha_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        ConstruirMenu()
    End Sub



    Private Sub FrmClientesFicha_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        fClientesFicha = Nothing


        MDIPrincipal.RibbonBar.RemoveTab(DEFMENU.MAESTROS_CLIENTES_FICHA)
        'MDIPrincipal.RibbonBar.Reset()
        MDIPrincipal.RibbonBar.RedrawBar()
        MDIPrincipal.RibbonBar.RecalcLayout()

        'MDIPrincipal.RibbonBar.FindTab(DEFMENU.MAESTROS_CLIENTES_FICHA).Visible = False


        MDIPrincipal.RibbonBar.FindTab(DEFMENU.GRUPO_MAESTROS_CLIENTES).Selected = True
        MDIPrincipal.RibbonBar.FindTab(DEFMENU.MAESTROS_CLIENTES_FICHA).Visible = False


        fClientesFichero.Visible = True

    End Sub


    Sub Guardar()
        Dim texto As String
        Dim ObjError As New Errores

        RCClientes.Populate()
        RCClientes2.Populate()

        If Comprobaciones() = False Then
            texto = GuardarFichaClientes(ObjCliente)

            ObjError.Titulo = "Ficha Clientes"

            If Text = "" Then
                ObjError.SetMensaje("El proceso a fallado.")
                ObjError.Pantalla1 = Me
                ObjError.Tipo1 = 1 'Errores
                ObjError.Pie1 = False
            Else
                ObjError.SetMensaje(texto)
                ObjError.Pantalla1 = Me
                ObjError.Tipo1 = 3 'Errores
                ObjError.Pie1 = False
            End If

            FrmError.ObjError = ObjError
            FrmError.ShowDialog()
            If FrmError.DialogResult = DialogResult.OK Then
                FrmError.Dispose()
            End If

            ActualizarClientesFichero


        End If

    End Sub


    Sub ActualizarClientesFichero()
        Dim RCFichero As AxXtremeReportControl.AxReportControl
        RCFichero = CType(fClientesFichero.RCClientes, AxXtremeReportControl.AxReportControl)

        For x = 0 To RCFichero.Records.Count - 1
            If RCFichero.Records(x).Item(0).Value = ObjCliente.Id1 Then
                fClientesFichero.ActualizarRegistro(RCFichero.Records(x), ObjCliente)
                Exit Sub
            End If
        Next

        fClientesFichero.AñadirRegistro(ObjCliente)



    End Sub

    Private Sub RCClientes2_ValueChanging(sender As Object, e As _DReportControlEvents_ValueChangingEvent) Handles RCClientes2.ValueChanging




        'Const CAMP_RUTABD = 29

        ''Tiene Asesor
        'Const CAMP_ASESORID = 30
        'Const CAMP_ASESORCODIGO = 31

        'Const CAMP_ASESORRAZONSOCIAL = 32
        'Const CAMP_ASESORESCLIENTE = 33


        ''Datos bancarios 
        'Const CAMP_FORMAPAGO = 34
        'Const CAMP_FORMAPAGOPAIS = 35
        'Const CAMP_FORMAPAGODC = 36
        'Const CAMP_FORMAPAGOCUENTA = 37

        Select Case CInt(e.item.Record(COL_CAMPO_ID).Value)
            Case CAMP_ESTADO
                ObjCliente.ProximoEstado1 = CLng(e.newValue)

            Case CAMP_ESASESOR
                ObjCliente.CodigoAsesor1 = CType(e.newValue, String)

            Case CAMP_ENVIOINFORMACION
                ObjCliente.EnviarInfo1 = CBool(e.newValue)

            Case CAMP_LLAMADASEGUIMIENTO
                ObjCliente.LlamadaSegui1 = CType(e.newValue, String)

            'Case CAMP_RUTABD
            '    ObjCliente. = CType(e.newValue, String)

            Case CAMP_ASESORID
                ObjCliente.CodigoAsesor1 = CType(e.newValue, String)

            Case CAMP_FORMAPAGO
                ObjCliente.FormaPago1 = CType(e.newValue, String)





        End Select
    End Sub


    Public Function Comprobaciones() As Boolean
        Dim HayErrores As Boolean

        Dim ObjError As New Errores

        HayErrores = False
        ObjError.Pantalla1 = Me
        ObjError.Tipo1 = 1 'Errores
        ObjError.Pie1 = False

        ObjError.Titulo = "Comprobaciones"

        'Columna Tipo esta vacia
        If getValor(RCClientes, CAMP_ID) = "" Then

            ObjError.SetMensaje("CÓDIGO de cliente no puede estar vacio")

            If ObjError.Control1 = "" Then
                ObjError.Control1 = "ReportControl"
                'ObjError.Pie1 = True
                ObjError.Foco1 = CAMP_ID
            End If

            HayErrores = True

        End If

        If getValor(RCClientes2, CAMP_FORMAPAGO) = 0 Then

            ObjError.SetMensaje("La Forma de pago no se puede dejar vacia")

            If ObjError.Control1 = "" Then
                ObjError.Control1 = "ReportControl"
                'ObjError.Pie1 = True
                ObjError.Foco1 = CAMP_FORMAPAGO
            End If

            HayErrores = True
        End If

        'If RCProductos.FocusedRow.Record.Item(COL_VERSIONES).Caption = "" Then

        '    ObjError.SetMensaje("VERSIÓN no se puede dejar vacia")

        '    If ObjError.Control1 = "" Then
        '        ObjError.Control1 = "ReportControl"
        '        'ObjError.Pie1 = True
        '        ObjError.Foco1 = COL_VERSIONES
        '    End If

        '    HayErrores = True
        'End If
        'If RCProductos.FocusedRow.Record.Item(COL_MANTENIMIENTO).Caption = "" Then

        '    ObjError.SetMensaje("MANTENIMIENTO no se puede dejar vacio")

        '    If ObjError.Control1 = "" Then
        '        ObjError.Control1 = "ReportControl"
        '        'ObjError.Pie1 = True
        '        ObjError.Foco1 = COL_MANTENIMIENTO
        '    End If

        '    HayErrores = True
        'End If
        'If RCProductos.FocusedRow.Record.Item(COL_RED).Caption = "" Then

        '    ObjError.SetMensaje("RED no se puede dejar vacia")

        '    If ObjError.Control1 = "" Then
        '        ObjError.Control1 = "ReportControl"
        '        'ObjError.Pie1 = True
        '        ObjError.Foco1 = COL_RED
        '    End If

        '    HayErrores = True
        'End If
        'If RCProductos.FocusedRow.Record.Item(COL_TEMPORAL).Caption = "" Then

        '    ObjError.SetMensaje("TEMPORAL no se puede dejar vacia")

        '    If ObjError.Control1 = "" Then
        '        ObjError.Control1 = "ReportControl"
        '        'ObjError.Pie1 = True
        '        ObjError.Foco1 = COL_TEMPORAL
        '    End If

        '    HayErrores = True
        'End If
        'If RCProductos.FocusedRow.Record.Item(COL_PRECIO).Caption = "" Then

        '    ObjError.SetMensaje("PRECIO no se puede dejar vacio")

        '    If ObjError.Control1 = "" Then
        '        ObjError.Control1 = "ReportControl"
        '        'ObjError.Pie1 = True
        '        ObjError.Foco1 = COL_PRECIO
        '    End If

        '    HayErrores = True
        'End If
        'If RCProductos.FocusedRow.Record.Item(COL_PRECIORED).Caption = "" Then

        '    ObjError.SetMensaje("PRECIO RED no se puede dejar vacio")

        '    If ObjError.Control1 = "" Then
        '        ObjError.Control1 = "ReportControl"
        '        ObjError.Pie1 = True
        '        ObjError.Foco1 = COL_PRECIORED
        '    End If

        '    HayErrores = True
        'End If

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


            'RCClientes.Navigator.MoveToColumn(RCProductos.Columns.Find(objError.foco1).Index, False)
            'RCProductos.Navigator.BeginEdit()
        End If

    End Sub
End Class