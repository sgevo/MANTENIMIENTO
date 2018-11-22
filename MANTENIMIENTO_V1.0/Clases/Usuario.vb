'Imports MantEvolution

Public Class Usuario
    Private Id As Long
    Private Nombre As String
    Private Contraseña As String
    Private Configuracion As String
    Private objGrupo As Grupo

    Public Sub New(id As Long, nombre As String, contraseña As String, configuracion As String, objGrupo As Grupo)
        Me.Id = id
        Me.Nombre = nombre
        Me.Contraseña = contraseña
        Me.Configuracion = configuracion
        Me.objGrupo = objGrupo
    End Sub

    Public Sub New(id As Long, nombre As String, contraseña As String, objGrupo As Grupo)
        Me.Id = id
        Me.Nombre = nombre
        Me.Contraseña = contraseña
        Me.objGrupo = objGrupo
    End Sub

    Public Sub New(id As Long, nombre As String, contraseña As String)
        Me.Id = id
        Me.Nombre = nombre
        Me.Contraseña = contraseña
    End Sub

    Public Property Id1 As Long
        Get
            Return Id
        End Get
        Set(value As Long)
            Id = value
        End Set
    End Property

    Public Property Nombre1 As String
        Get
            Return Nombre
        End Get
        Set(value As String)
            Nombre = value
        End Set
    End Property

    Public Property Contraseña1 As String
        Get
            Return Contraseña
        End Get
        Set(value As String)
            Contraseña = value
        End Set
    End Property

    Public Property Configuracion1 As String
        Get
            Return Configuracion
        End Get
        Set(value As String)
            Configuracion = value
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

End Class
