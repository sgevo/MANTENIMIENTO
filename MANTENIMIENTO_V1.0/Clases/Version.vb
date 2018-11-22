'Imports WindowsApp1

Public Class Version
    Private Id As Long
    Private Version As String
    Private Orden As Long
    Private Ultima As Boolean
    Private Precio As Double
    Private PrecioRed As Double
    Private objProducto As Producto

    Public Sub New()

    End Sub

    Public Sub New(id As Long, version As String, orden As Long, ultima As Boolean, Precio As Double, precioRed As Double, objProducto As Producto)
        Me.Id = id
        Me.Version = version
        Me.Orden = orden
        Me.Ultima = ultima
        Me.Precio = Precio
        Me.PrecioRed = precioRed
        Me.objProducto = objProducto
    End Sub

    Public Sub New(id As Long, version As String, orden As Long, ultima As Boolean, Precio As Double, precioRed As Double)
        Me.Id = id
        Me.Version = version
        Me.Orden = orden
        Me.Ultima = ultima
        Me.Precio = Precio
        Me.PrecioRed = precioRed
    End Sub

    Public Property Id1 As Long
        Get
            Return Id
        End Get
        Set(value As Long)
            Id = value
        End Set
    End Property

    Public Property Version1 As String
        Get
            Return Version
        End Get
        Set(value As String)
            Version = value
        End Set
    End Property

    Public Property Orden1 As Long
        Get
            Return Orden
        End Get
        Set(value As Long)
            Orden = value
        End Set
    End Property

    Public Property Ultima1 As Boolean
        Get
            Return Ultima
        End Get
        Set(value As Boolean)
            Ultima = value
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

    Public Property ObjProducto1 As Producto
        Get
            Return objProducto
        End Get
        Set(value As Producto)
            objProducto = value
        End Set
    End Property

End Class
