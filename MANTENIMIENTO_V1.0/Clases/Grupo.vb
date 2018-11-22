Public Class Grupo

    Private Id As Long
    Private Descripcion As String

    Private arrayUsuarios As New ArrayList()
    Private arrayPermisos As New ArrayList()

    Public Sub New(id As Long, descripcion As String)
        Me.Id = id
        Me.Descripcion = descripcion
        Me.arrayUsuarios = ObtenerUsuarios(id)
        Me.arrayPermisos = ObtenerPermisosGrupo(id)
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

    Public Property ArrayUsuarios1 As ArrayList
        Get
            Return arrayUsuarios
        End Get
        Set(value As ArrayList)
            arrayUsuarios = value
        End Set
    End Property

    Public Property ArrayPermisos1 As ArrayList
        Get
            Return arrayPermisos
        End Get
        Set(value As ArrayList)
            arrayPermisos = value
        End Set
    End Property
End Class
