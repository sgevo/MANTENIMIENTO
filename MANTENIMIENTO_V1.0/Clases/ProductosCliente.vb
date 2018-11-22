Public Class ProductosCliente
    Private Id As Long
    Private IdCliente As Long
    Private Tipo As String 'Si es un producto (PR) o si es un pack (PA) o un mante (MA)

    Private id_Producto As Long
    Private id_Pack As Long

    Private Licencia1 As String
    Private Clave1 As String
    Private id_Version1 As Long
    Private Red1 As Boolean
    Private Mante1 As Boolean

    'Si tiene pack, puede ser del Wonta y del Ges
    Private Licencia2 As String
    Private Clave2 As String
    Private id_Version2 As Long
    Private Red2 As Boolean
    Private Mante2 As Boolean

    Private FechaAdquisicion As Date
    Private FechaInicioServicio As Date
    Private FechaFinServicio As Date

    Private objCliente As Cliente

    Public Sub New(id As Long, idcliente As Long, tipo As String, id_Producto As Long, id_Pack As Long, licencia1 As String, clave1 As String, red1 As Boolean, mante1 As Boolean, id_Version1 As Long, licencia2 As String, clave2 As String, red2 As Boolean, mante2 As Boolean, id_Version2 As Long, fechaadquisicion As Date, fechainicioservicio As Date, fechafinservicio As Date, cliente As Cliente)
        Me.Id1 = id
        Me.Tipo1 = tipo

        'If id_objProducto <> "" Then
        Me.Id_Producto1 = (Convert.ToInt32(id_Producto))
        'End If

        Me.Id_Pack1 = Convert.ToInt32(id_Pack)

        Me.Licencia11 = licencia1
        Me.Clave11 = clave1
        Me.Red11 = red1
        Me.Mante1 = mante1

        Me.Id_Version11 = (Convert.ToInt32(id_Version1))

        Me.Licencia21 = licencia2
        Me.Clave21 = clave2
        Me.Red21 = red2
        Me.Mante2 = mante2


        Me.Id_Version21 = (Convert.ToInt32(id_Version2))

        Me.FechaAdquisicion1 = fechaadquisicion
        Me.FechaInicioServicio1 = fechainicioservicio
        Me.FechaFinServicio1 = fechafinservicio
        Me.objCliente1 = cliente

    End Sub

    Public Sub New(id As Long, idcliente As Long, tipo As String, id_Producto As Long, id_Pack As Long, licencia1 As String, clave1 As String, red1 As Boolean, mante1 As Boolean, id_Version1 As Long, licencia2 As String, clave2 As String, red2 As Boolean, mante2 As Boolean, id_Version2 As Long, fechaadquisicion As Date, cliente As Cliente)
        Me.Id1 = id
        Me.Tipo1 = tipo

        'If id_objProducto <> "" Then
        Me.Id_Producto1 = (Convert.ToInt32(id_Producto))
        'End If

        Me.Id_Pack1 = Convert.ToInt32(id_Pack)

        Me.Licencia11 = licencia1
        Me.Clave11 = clave1
        Me.Red11 = red1
        Me.Mante1 = mante1

        Me.Id_Version11 = (Convert.ToInt32(id_Version1))

        Me.Licencia21 = licencia2
        Me.Clave21 = clave2
        Me.Red21 = red2
        Me.Mante2 = mante2

        Me.Id_Version21 = (Convert.ToInt32(id_Version2))

        Me.FechaAdquisicion1 = fechaadquisicion
        Me.objCliente1 = cliente
    End Sub

    Public Property Id1 As Long
        Get
            Return Id
        End Get
        Set(value As Long)
            Id = value
        End Set
    End Property

    Public Property IdCliente1 As Long
        Get
            Return IdCliente
        End Get
        Set(value As Long)
            IdCliente = value
        End Set
    End Property

    Public Property Tipo1 As String
        Get
            Return Tipo
        End Get
        Set(value As String)
            Tipo = value
        End Set
    End Property

    Public Property Id_Producto1 As Long
        Get
            Return id_Producto
        End Get
        Set(value As Long)
            id_Producto = value
        End Set
    End Property

    Public Property Id_Pack1 As Long
        Get
            Return id_Pack
        End Get
        Set(value As Long)
            id_Pack = value
        End Set
    End Property

    Public Property Licencia11 As String
        Get
            Return Licencia1
        End Get
        Set(value As String)
            Licencia1 = value
        End Set
    End Property

    Public Property Clave11 As String
        Get
            Return Clave1
        End Get
        Set(value As String)
            Clave1 = value
        End Set
    End Property

    Public Property Id_Version11 As Long
        Get
            Return id_Version1
        End Get
        Set(value As Long)
            id_Version1 = value
        End Set
    End Property

    Public Property Red11 As Boolean
        Get
            Return Red1
        End Get
        Set(value As Boolean)
            Red1 = value
        End Set
    End Property

    Public Property Mante11 As Boolean
        Get
            Return Mante1
        End Get
        Set(value As Boolean)
            Mante1 = value
        End Set
    End Property

    Public Property Licencia21 As String
        Get
            Return Licencia2
        End Get
        Set(value As String)
            Licencia2 = value
        End Set
    End Property

    Public Property Clave21 As String
        Get
            Return Clave2
        End Get
        Set(value As String)
            Clave2 = value
        End Set
    End Property

    Public Property Id_Version21 As Long
        Get
            Return id_Version2
        End Get
        Set(value As Long)
            id_Version2 = value
        End Set
    End Property

    Public Property Red21 As Boolean
        Get
            Return Red2
        End Get
        Set(value As Boolean)
            Red2 = value
        End Set
    End Property

    Public Property Mante21 As Boolean
        Get
            Return Mante2
        End Get
        Set(value As Boolean)
            Mante2 = value
        End Set
    End Property

    Public Property FechaAdquisicion1 As Date
        Get
            Return FechaAdquisicion
        End Get
        Set(value As Date)
            FechaAdquisicion = value
        End Set
    End Property

    Public Property FechaInicioServicio1 As Date
        Get
            Return FechaInicioServicio
        End Get
        Set(value As Date)
            FechaInicioServicio = value
        End Set
    End Property

    Public Property FechaFinServicio1 As Date
        Get
            Return FechaFinServicio
        End Get
        Set(value As Date)
            FechaFinServicio = value
        End Set
    End Property

    Public Property objCliente1 As Cliente
        Get
            Return objCliente
        End Get
        Set(value As Cliente)
            objCliente = value
        End Set
    End Property
End Class
