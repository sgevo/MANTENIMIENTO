Imports MantEvolution

Public Class Cliente

    Private Id As Long 'Antiguo cod_cliente

    Private RazonSocial As String
    Private NombreComercial As String
    Private Cif As String

    Private Direccion As String
    Private CP As String
    Private Poblacion As String

    Private idProvincia As Long
    Private ObjProvincia As Provincia

    Private Telefono As String
    Private Telefono2 As String
    Private Movil As String
    Private Fax As String
    Private Email As String
    Private Web As String

    Private GerenteNombre As String


    Private UsuarioNombre1 As String
    Private UsuarioTelefono1 As String
    Private UsuarioEmail1 As String

    Private UsuarioNombre2 As String '20
    Private UsuarioTelefono2 As String
    Private UsuarioEmail2 As String

    Private UsuarioNombre3 As String
    Private UsuarioTelefono3 As String
    Private UsuarioEmail3 As String

    Private UsuarioNombre4 As String
    Private UsuarioTelefono4 As String '30
    Private UsuarioEmail4 As String

    Private FormaPago As String

    Private IbanPais As String
    Private IbanDc As String
    Private IbanCuenta As String '35

    Private CodDistribuidor As String
    Private Observaciones As String

    Private EnviarInfo As Boolean
    Private CodigoAsesor As String

    Private LlamadaSegui As String '40
    Private ProximoEstado As String   '41

    Private arrayMovimientos As New ArrayList()

    Private arrayMantenimientos As New ArrayList()

    Public Sub New()
        Me.Id = NuevoNumCliente()
        Me.RazonSocial = ""
        Me.NombreComercial = ""
        Me.Cif = ""
        Me.Direccion = ""
        Me.CP = ""
        Me.Poblacion = ""
        Me.idProvincia = "0"
        'If provincia <> "" Then
        '    For x = 0 To ArrayProvincias.Count - 1
        '        If ArrayProvincias(x).id1 = provincia Then
        '            Me.ObjProvincia = ArrayProvincias(x)
        '        End If
        '    Next
        '    ''  Me.ObjProvincia = obtenerUnaProvincia(CLng(provincia))
        'End If
        Me.Telefono = ""
        Me.Telefono2 = ""
        Me.Movil = ""    '10
        Me.Fax = ""
        Me.Email = ""
        Me.Web = ""
        Me.GerenteNombre = ""

        Me.UsuarioNombre1 = ""

        Me.UsuarioTelefono1 = ""
        Me.UsuarioEmail1 = ""
        Me.UsuarioNombre2 = "" '20

        Me.UsuarioTelefono2 = ""
        Me.UsuarioEmail2 = ""
        Me.UsuarioNombre3 = ""

        Me.UsuarioTelefono3 = ""
        Me.UsuarioEmail3 = ""
        Me.UsuarioNombre4 = ""

        Me.UsuarioTelefono4 = "" '30
        Me.UsuarioEmail4 = ""
        Me.FormaPago = 0
        Me.IbanPais = ""
        Me.IbanDc = ""
        Me.IbanCuenta = ""
        Me.CodDistribuidor = ""
        Me.Observaciones = ""
        Me.EnviarInfo = True
        Me.CodigoAsesor = ""
        Me.LlamadaSegui = "" '40
        Me.ProximoEstado = ""
    End Sub

    Public Sub New(id As Long, nombreComercial As String, razonSocial As String, cif As String, direccion As String, cP As String, poblacion As String, provincia As String, telefono As String, telefono2 As String, movil As String, fax As String, email As String, web As String, gerenteNombre As String, usuarioNombre1 As String, usuarioTelefono1 As String, usuarioEmail1 As String, usuarioNombre2 As String, usuarioTelefono2 As String, usuarioEmail2 As String, usuarioNombre3 As String, usuarioTelefono3 As String, usuarioEmail3 As String, usuarioNombre4 As String, usuarioTelefono4 As String, usuarioEmail4 As String, formaPago As String, ibanPais As String, ibanDc As String, ibanCuenta As String, codDistribuidor As String, observaciones As String, enviarInfo As String, codigoAsesor As String, llamadaSegui As String, proximoEstado As String, ArrayProvincias As ArrayList)
        Me.Id = id
        Me.RazonSocial = razonSocial
        Me.NombreComercial = nombreComercial
        Me.Cif = cif
        Me.Direccion = direccion
        Me.CP = cP
        Me.Poblacion = poblacion
        Me.idProvincia = CLng(provincia)
        'If provincia <> "" Then
        '    For x = 0 To ArrayProvincias.Count - 1
        '        If ArrayProvincias(x).id1 = provincia Then
        '            Me.ObjProvincia = ArrayProvincias(x)
        '        End If
        '    Next
        '    ''  Me.ObjProvincia = obtenerUnaProvincia(CLng(provincia))
        'End If
        Me.Telefono = telefono
        Me.Telefono2 = telefono2
        Me.Movil = movil    '10
        Me.Fax = fax
        Me.Email = email
        Me.Web = web
        Me.GerenteNombre = gerenteNombre

        Me.UsuarioNombre1 = usuarioNombre1

        Me.UsuarioTelefono1 = usuarioTelefono1
        Me.UsuarioEmail1 = usuarioEmail1
        Me.UsuarioNombre2 = usuarioNombre2 '20

        Me.UsuarioTelefono2 = usuarioTelefono2
        Me.UsuarioEmail2 = usuarioEmail2
        Me.UsuarioNombre3 = usuarioNombre3

        Me.UsuarioTelefono3 = usuarioTelefono3
        Me.UsuarioEmail3 = usuarioEmail3
        Me.UsuarioNombre4 = usuarioNombre4

        Me.UsuarioTelefono4 = usuarioTelefono4 '30
        Me.UsuarioEmail4 = usuarioEmail4
        Me.FormaPago = formaPago
        Me.IbanPais = ibanPais
        Me.IbanDc = ibanDc
        Me.IbanCuenta = ibanCuenta
        Me.CodDistribuidor = codDistribuidor
        Me.Observaciones = observaciones
        Me.EnviarInfo = enviarInfo
        Me.CodigoAsesor = codigoAsesor
        Me.LlamadaSegui = llamadaSegui '40
        Me.ProximoEstado = proximoEstado
    End Sub

    Public Property ArrayMovimientos1 As ArrayList
        Get
            If arrayMovimientos.Count = 0 Then
                arrayMovimientos = ObtenerMovimientos(Id1)
            End If

            Return arrayMovimientos
        End Get
        Set(arrayMovimientos As ArrayList)
            arrayMovimientos = arrayMovimientos
        End Set
    End Property

    Public Property ArrayMantenimientos1 As ArrayList
        Get
            If arrayMantenimientos.Count = 0 Then
                arrayMantenimientos = ObtenerMantenimientos(Id1)
            End If

            Return arrayMantenimientos
        End Get
        Set(ArrayMantenimientos As ArrayList)
            ArrayMantenimientos = ArrayMantenimientos
        End Set
    End Property

    Public Property Id1 As Long
        Get
            Return Id
        End Get
        Set(value As Long)
            Id = value
        End Set
    End Property

    Public Property RazonSocial1 As String
        Get
            Return RazonSocial
        End Get
        Set(value As String)
            RazonSocial = value
        End Set
    End Property

    Public Property NombreComercial1 As String
        Get
            Return NombreComercial
        End Get
        Set(value As String)
            NombreComercial = value
        End Set
    End Property

    Public Property Cif1 As String
        Get
            Return Cif
        End Get
        Set(value As String)
            Cif = value
        End Set
    End Property

    Public Property Direccion1 As String
        Get
            Return Direccion
        End Get
        Set(value As String)
            Direccion = value
        End Set
    End Property

    Public Property CP1 As String
        Get
            Return CP
        End Get
        Set(value As String)
            CP = value
        End Set
    End Property

    Public Property Poblacion1 As String
        Get
            Return Poblacion
        End Get
        Set(value As String)
            Poblacion = value
        End Set
    End Property



    Public Property Telefono1 As String
        Get
            Return Telefono
        End Get
        Set(value As String)
            Telefono = value
        End Set
    End Property

    Public Property Telefono21 As String
        Get
            Return Telefono2
        End Get
        Set(value As String)
            Telefono2 = value
        End Set
    End Property

    Public Property Movil1 As String
        Get
            Return Movil
        End Get
        Set(value As String)
            Movil = value
        End Set
    End Property

    Public Property Fax1 As String
        Get
            Return Fax
        End Get
        Set(value As String)
            Fax = value
        End Set
    End Property

    Public Property Email1 As String
        Get
            Return Email
        End Get
        Set(value As String)
            Email = value
        End Set
    End Property

    Public Property Web1 As String
        Get
            Return Web
        End Get
        Set(value As String)
            Web = value
        End Set
    End Property

    Public Property GerenteNombre1 As String
        Get
            Return GerenteNombre
        End Get
        Set(value As String)
            GerenteNombre = value
        End Set
    End Property


    Public Property UsuarioNombre11 As String
        Get
            Return UsuarioNombre1
        End Get
        Set(value As String)
            UsuarioNombre1 = value
        End Set
    End Property



    Public Property UsuarioTelefono11 As String
        Get
            Return UsuarioTelefono1
        End Get
        Set(value As String)
            UsuarioTelefono1 = value
        End Set
    End Property

    Public Property UsuarioEmail11 As String
        Get
            Return UsuarioEmail1
        End Get
        Set(value As String)
            UsuarioEmail1 = value
        End Set
    End Property

    Public Property UsuarioNombre21 As String
        Get
            Return UsuarioNombre2
        End Get
        Set(value As String)
            UsuarioNombre2 = value
        End Set
    End Property



    Public Property UsuarioTelefono21 As String
        Get
            Return UsuarioTelefono2
        End Get
        Set(value As String)
            UsuarioTelefono2 = value
        End Set
    End Property

    Public Property UsuarioEmail21 As String
        Get
            Return UsuarioEmail2
        End Get
        Set(value As String)
            UsuarioEmail2 = value
        End Set
    End Property

    Public Property UsuarioNombre31 As String
        Get
            Return UsuarioNombre3
        End Get
        Set(value As String)
            UsuarioNombre3 = value
        End Set
    End Property


    Public Property UsuarioTelefono31 As String
        Get
            Return UsuarioTelefono3
        End Get
        Set(value As String)
            UsuarioTelefono3 = value
        End Set
    End Property

    Public Property UsuarioEmail31 As String
        Get
            Return UsuarioEmail3
        End Get
        Set(value As String)
            UsuarioEmail3 = value
        End Set
    End Property

    Public Property UsuarioNombre41 As String
        Get
            Return UsuarioNombre4
        End Get
        Set(value As String)
            UsuarioNombre4 = value
        End Set
    End Property



    Public Property UsuarioTelefono41 As String
        Get
            Return UsuarioTelefono4
        End Get
        Set(value As String)
            UsuarioTelefono4 = value
        End Set
    End Property

    Public Property UsuarioEmail41 As String
        Get
            Return UsuarioEmail4
        End Get
        Set(value As String)
            UsuarioEmail4 = value
        End Set
    End Property

    Public Property FormaPago1 As String
        Get
            Return FormaPago
        End Get
        Set(value As String)
            FormaPago = value
        End Set
    End Property

    Public Property IbanPais1 As String
        Get
            Return IbanPais
        End Get
        Set(value As String)
            IbanPais = value
        End Set
    End Property

    Public Property IbanDc1 As String
        Get
            Return IbanDc
        End Get
        Set(value As String)
            IbanDc = value
        End Set
    End Property

    Public Property IbanCuenta1 As String
        Get
            Return IbanCuenta
        End Get
        Set(value As String)
            IbanCuenta = value
        End Set
    End Property

    Public Property CodDistribuidor1 As String
        Get
            Return CodDistribuidor
        End Get
        Set(value As String)
            CodDistribuidor = value
        End Set
    End Property

    Public Property Observaciones1 As String
        Get
            Return Observaciones
        End Get
        Set(value As String)
            Observaciones = value
        End Set
    End Property



    Public Property CodigoAsesor1 As String
        Get
            Return CodigoAsesor
        End Get
        Set(value As String)
            CodigoAsesor = value
        End Set
    End Property

    Public Property LlamadaSegui1 As String
        Get
            Return LlamadaSegui
        End Get
        Set(value As String)
            LlamadaSegui = value
        End Set
    End Property

    Public Property ProximoEstado1 As Byte
        Get
            Return ProximoEstado
        End Get
        Set(value As Byte)
            ProximoEstado = value
        End Set
    End Property

    Public Property ObjProvincia1 As Provincia
        Get
            Return ObjProvincia
        End Get
        Set(value As Provincia)
            ObjProvincia = value
        End Set
    End Property

    Public Property IdProvincia1 As Long
        Get
            Return idProvincia
        End Get
        Set(value As Long)
            idProvincia = value
        End Set
    End Property

    Public Property EnviarInfo1 As Boolean
        Get
            Return EnviarInfo
        End Get
        Set(value As Boolean)
            EnviarInfo = value
        End Set
    End Property
End Class
