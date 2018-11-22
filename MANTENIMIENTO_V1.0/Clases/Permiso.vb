'Imports WindowsApp1

'Imports MantEvolution

Public Class Permiso
    Private Id As Long
    Private Acceso As Long
    Private IdGrupo As Long
    Private objGrupo As Grupo
    Private IdPantalla As Long
    Private objPantalla As Pantalla

    Public Sub New(id As Long, acceso As Long, idGrupo As Long, idPantalla As Long)
        Me.Id1 = id
        Me.Acceso1 = acceso
        Me.IdGrupo1 = idGrupo
        Me.IdPantalla1 = idPantalla
    End Sub

    Public Sub New(id As Long, acceso As Long, objGrupo As Grupo, objPantalla As Pantalla)
        Me.Id1 = id
        Me.Acceso1 = acceso
        Me.ObjGrupo1 = objGrupo
        Me.ObjPantalla1 = objPantalla
    End Sub

    Public Sub New(id As Long, acceso As Long)
        Me.Id1 = id
        Me.Acceso1 = acceso
        Me.ObjPantalla1 = objPantalla
    End Sub

    Public Sub New(acceso As Long, objGrupo As Grupo, objPantalla As Pantalla)
        Me.Id1 = Id
        Me.Acceso1 = acceso
        Me.ObjGrupo1 = objGrupo
        Me.ObjPantalla1 = objPantalla
    End Sub

    Public Property Acceso1 As Long
        Get
            Return Acceso
        End Get
        Set(value As Long)
            Acceso = value
        End Set
    End Property

    Public Property IdGrupo1 As Long
        Get
            Return IdGrupo
        End Get
        Set(value As Long)
            IdGrupo = value
        End Set
    End Property

    Public Property ObjGrupo1 As Grupo
        Get
            Return objGrupo
        End Get
        Set(value As Grupo)
            objGrupo = value
        End Set
    End Property

    Public Property IdPantalla1 As Long
        Get
            Return IdPantalla
        End Get
        Set(value As Long)
            IdPantalla = value
        End Set
    End Property

    Public Property ObjPantalla1 As Pantalla
        Get
            Return objPantalla
        End Get
        Set(value As Pantalla)
            objPantalla = value
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
