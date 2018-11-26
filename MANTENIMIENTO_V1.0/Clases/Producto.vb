Public Class Producto

    Private Id As Long
    Private Codigo As String
    Private Descripcion As String
    Private Tipo As String
    Private Versiones As Boolean
    Private IdMantenimiento As Long
    Private Red As Boolean
    Private Temporal As Boolean
    Private Precio As Double
    Private PrecioRed As Double

    Private arrayVersiones As New ArrayList()
    Private arrayPacks As New ArrayList()

    Public Sub New()

    End Sub

    Public Sub New(id As Long, codigo As String, descripcion As String, tipo As String, versiones As Boolean, mantenimiento As Long, red As Boolean, temporal As Boolean, precio As Double, precioRed As Double)
        Me.Id = id
        Me.Codigo = codigo
        Me.Descripcion = descripcion
        Me.Tipo = tipo
        Me.Versiones = versiones
        Me.IdMantenimiento = mantenimiento
        Me.Red = red
        Me.Temporal = temporal
        Me.Precio = precio
        Me.PrecioRed = precioRed
        Me.arrayVersiones = ObtenerVersiones(id)
    End Sub

    Public Property Id1 As Long
        Get
            Return Id
        End Get
        Set(value As Long)
            Id = value
        End Set
    End Property

    Public Property Codigo1 As String
        Get
            Return Codigo
        End Get
        Set(value As String)
            Codigo = value
        End Set
    End Property

    Public Property Descripcion1 As String
        Get
            Return Descripcion
        End Get
        Set(value As String)
            Descripcion = value
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

    Public Property Versiones1 As Boolean
        Get
            Return Versiones
        End Get
        Set(value As Boolean)
            Versiones = value
        End Set
    End Property

    Public Property Red1 As Boolean
        Get
            Return Red
        End Get
        Set(value As Boolean)
            Red = value
        End Set
    End Property

    Public Property Temporal1 As Boolean
        Get
            Return Temporal
        End Get
        Set(value As Boolean)
            Temporal = value
        End Set
    End Property

    Public Property Precio1 As String
        Get
            Return Format(Precio, FormatoImporte)
        End Get
        Set(value As String)
            Precio = Format(value, FormatoImporte)
        End Set
    End Property

    Public Property PrecioRed1 As String
        Get
            Return Format(PrecioRed, FormatoImporte)
        End Get
        Set(value As String)
            PrecioRed = Format(value, FormatoImporte)
        End Set
    End Property

    Public Property ArrayVersiones1 As ArrayList
        Get
            Return arrayVersiones
        End Get
        Set(value As ArrayList)
            arrayVersiones = value
        End Set
    End Property

    Public Property ArrayPacks1 As ArrayList
        Get
            Return arrayPacks
        End Get
        Set(value As ArrayList)
            arrayPacks = value
        End Set
    End Property

    Public Property IdMantenimiento1 As Long
        Get
            Return IdMantenimiento
        End Get
        Set(value As Long)
            IdMantenimiento = value
        End Set
    End Property
End Class
