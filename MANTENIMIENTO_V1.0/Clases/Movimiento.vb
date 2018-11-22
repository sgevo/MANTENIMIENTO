Imports MantEvolution

Public Class Movimiento
    Private Id As Long
    Private Tipo As String
    Private Fecha As Date
    Private objCliente As Cliente
    Private id_Producto As Long
    Private objProducto As Producto
    Private id_Version As Long
    Private objVersion As Version
    Private id_Pack As Long
    Private objPack As Pack

    Private Licencia As String
    Private Clave As String
    Private Red As Boolean

    Public Sub New(id As Long, tipo As String, fecha As Date, id_objCliente As String, id_objProducto As String, id_objVersion As String, id_objPack As String, licencia As String, clave As String, red As Boolean)
        Me.Id1 = id
        Me.Tipo1 = tipo
        Me.Fecha1 = fecha
        '    Me.ObjCliente1 = ObtenerUnCliente(Convert.ToInt32(id_objCliente))
        'If id_objProducto <> 0 Then
        '    Me.ObjProducto1 = ObtenerUnProducto(Convert.ToInt32(id_objProducto))
        'Else
        '    Me.ObjProducto1 = New Producto()
        'End If
        If id_objProducto <> "" Then
            Me.Id_Producto1 = (Convert.ToInt32(id_objProducto))
        End If

        'Me.ObjVersion1 = objVersion
        'If id_objVersion <> 0 Then
        '    Me.ObjVersion1 = ObtenerUnaVersion(Convert.ToInt32(id_objVersion))
        'Else
        '    Me.ObjVersion1 = New Version()
        'End If
        If id_objVersion <> "" Then
            Me.Id_Version1 = (Convert.ToInt32(id_objVersion))
        End If

        'Me.ObjPack1 = objPack
        'If id_objPack <> "" Then
        '    Me.ObjPack1 = ObtenerUnPack(Convert.ToInt32(id_objPack))
        'Else
        '    Me.ObjPack1 = New Pack()
        'End If
        If id_objPack <> "" Then
            Me.Id_Pack1 = (Convert.ToInt32(id_objPack))
        End If

        Me.Licencia1 = licencia
        Me.Clave1 = clave
        Me.Red1 = red
    End Sub

    Public Property Id1 As Long
        Get
            Return Id
        End Get
        Set(value As Long)
            Id = value
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

    Public Property Fecha1 As Date
        Get
            Return Fecha
        End Get
        Set(value As Date)
            Fecha = value
        End Set
    End Property

    Public Property ObjCliente1 As Cliente
        Get
            Return objCliente
        End Get
        Set(value As Cliente)
            objCliente = value
        End Set
    End Property

    Public Property ObjProducto1 As Producto
        Get
            If Me.Id_Producto1 <> 0 Then
                Me.ObjProducto1 = ObtenerUnProducto(Convert.ToInt32(id_Producto))
            Else
                Me.ObjProducto1 = New Producto()
            End If
            Return objProducto
        End Get
        Set(value As Producto)
            objProducto = value
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

    Public Property ObjVersion1 As Version
        Get
            If Me.Id_Version1 <> 0 Then
                Me.ObjVersion1 = ObtenerUnaVersion(Convert.ToInt32(id_Version))
            Else
                Me.ObjVersion1 = New Version()
            End If
            Return objVersion
        End Get
        Set(value As Version)
            objVersion = value
        End Set
    End Property

    Public Property Id_Version1 As Long
        Get
            Return id_Version
        End Get
        Set(value As Long)
            id_Version = value
        End Set
    End Property

    Public Property ObjPack1 As Pack
        Get
            If Me.Id_Pack1 <> 0 Then
                Me.ObjPack1 = ObtenerUnPack(Convert.ToInt32(id_Pack))
            Else
                Me.ObjPack1 = New Pack()
            End If
            Return objPack
        End Get
        Set(value As Pack)
            objPack = value
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

    Public Property Licencia1 As String
        Get
            Return Licencia
        End Get
        Set(value As String)
            Licencia = value
        End Set
    End Property

    Public Property Clave1 As String
        Get
            Return Clave
        End Get
        Set(value As String)
            Clave = value
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
End Class
