'Imports WindowsApp1

Public Class Pack
    Private Id As Long
    Private Descripcion As String
    Private Precio As Double
    Private IdProducto1 As Long
    Private Red1 As Boolean
    Private Mante1 As Boolean
    Private Actualizar1 As Boolean
    Private IdProducto2 As Long
    Private Red2 As Boolean
    Private Mante2 As Boolean
    Private Actualizar2 As Boolean

    Private objProducto1 As Producto
    Private objProducto2 As Producto

    Public Sub New()

    End Sub

    Public Sub New(id As Long, descripcion As String, precio As Double, Red1 As Boolean, Mante1 As Boolean, Actualizar1 As Boolean, Red2 As Boolean, Mante2 As Boolean, Actualizar2 As Boolean, id_objProducto1 As String, id_objProducto2 As String)
        Me.Id = id
        Me.Descripcion = descripcion
        Me.Precio = precio
        Me.Red1 = Red1
        Me.Mante1 = Mante1
        Me.Actualizar1 = Actualizar1
        Me.Red2 = Red2
        Me.Mante2 = Mante2
        Me.Actualizar2 = Actualizar2
        'If id_objProducto1 <> 0 Then
        '    Me.objProducto1 = ObtenerUnProducto(Convert.ToInt32(id_objProducto1))
        'Else
        '    Me.objProducto1 = New Producto()
        'End If
        'If id_objProducto2 <> 0 Then
        '    Me.objProducto2 = ObtenerUnProducto(Convert.ToInt32(id_objProducto2))
        'Else
        '    Me.objProducto2 = New Producto()
        'End If
        Me.IdProducto1 = Convert.ToInt32(id_objProducto1)
        Me.IdProducto2 = Convert.ToInt32(id_objProducto2)
    End Sub

    Public Sub New(descripcion As String, precio As Double, Red1 As Boolean, Mante1 As Boolean, Actualizar1 As Boolean, Red2 As Boolean, Mante2 As Boolean, Actualizar2 As Boolean, ID_objProducto1 As String, ID_objProducto2 As String)
        Me.Descripcion = descripcion
        Me.Precio = precio
        Me.Red1 = Red1
        Me.Mante1 = Mante1
        Me.Actualizar1 = Actualizar1
        Me.Red2 = Red2
        Me.Mante2 = Mante2
        Me.Actualizar2 = Actualizar2
        'If ID_objProducto1 <> 0 Then
        '    Me.objProducto1 = ObtenerUnProducto(Convert.ToInt32(ID_objProducto1))
        'Else
        '    Me.objProducto1 = New Producto()
        'End If
        'If ID_objProducto2 <> 0 Then
        '    Me.objProducto2 = ObtenerUnProducto(Convert.ToInt32(ID_objProducto2))
        'Else
        '    Me.objProducto2 = New Producto()
        'End If
        Me.IdProducto1 = Convert.ToInt32(ID_objProducto1)
        Me.IdProducto2 = Convert.ToInt32(ID_objProducto2)
        'Me.objProducto1 = objProducto1
        'Me.objProducto2 = objProducto2
    End Sub

    Public Property Id1 As Long
        Get
            Return Id
        End Get
        Set(value As Long)
            Id = value
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

    Public Property Precio1 As String
        Get
            Return Format(Precio, FormatoImporte)
        End Get
        Set(value As String)
            Precio = Format(value, FormatoImporte)
        End Set

    End Property

    Public Property IdProducto11 As Long
        Get
            Return IdProducto1
        End Get
        Set(value As Long)
            IdProducto1 = value
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

    Public Property Actualizar11 As Boolean
        Get
            Return Actualizar1
        End Get
        Set(value As Boolean)
            Actualizar1 = value
        End Set
    End Property

    Public Property IdProducto21 As Long
        Get
            Return IdProducto2
        End Get
        Set(value As Long)
            IdProducto2 = value
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

    Public Property Actualizar21 As Boolean
        Get
            Return Actualizar2
        End Get
        Set(value As Boolean)
            Actualizar2 = value
        End Set
    End Property

    Public Property objProducto11 As Producto
        Get
            If IdProducto1 <> 0 Then
                Me.objProducto1 = ObtenerUnProducto(Convert.ToInt32(IdProducto1))
            Else
                Me.objProducto1 = New Producto()
            End If
            Return objProducto1
        End Get
        Set(value As Producto)
            objProducto1 = value
        End Set
    End Property

    Public Property objProducto21 As Producto
        Get
            If IdProducto2 <> 0 Then
                Me.objProducto2 = ObtenerUnProducto(Convert.ToInt32(IdProducto2))
            Else
                Me.objProducto2 = New Producto()
            End If
            Return objProducto2
        End Get
        Set(value As Producto)
            objProducto2 = value
        End Set
    End Property
End Class
