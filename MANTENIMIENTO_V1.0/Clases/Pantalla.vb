Public Class Pantalla

    Private Id As Long
    Private Codigo As Long
    Private Descripcion As String

    Public Sub New(id As Long, codigo As Long, descripcion As String)
        Me.Id1 = id
        Me.Codigo1 = codigo
        Me.Descripcion1 = descripcion
    End Sub

    Public Property Codigo1 As Long
        Get
            Return Codigo
        End Get
        Set(value As Long)
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

    Public Property Id1 As Long
        Get
            Return Id
        End Get
        Set(value As Long)
            Id = value
        End Set
    End Property
End Class
