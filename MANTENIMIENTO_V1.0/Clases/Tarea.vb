Public Class Tarea

    Private Id As Long
    Private IdMantenimiento As Long
    Private IdTecnicoGenerador As Long
    Private FechaCreacion As Date
    Private IdTecnico As Long
    Private IdCliente As Long
    Private Descripcion As String
    Private Estado As String
    Private FechaTerminacion As Date

    Public Sub New(IdMantenimiento As Long, idTecnicoG As Long, Fecha As Date, IdTecnico As Long, IdCliente As Long, Descripcion As String, Estado As String)
        Me.IdMantenimiento = IdMantenimiento
        Me.IdTecnicoGenerador = idTecnicoG
        Me.FechaCreacion = Fecha
        Me.IdTecnico = IdTecnico
        Me.IdCliente1 = IdCliente
        Me.Descripcion = Descripcion
        Me.Estado = Estado

    End Sub

    Public Sub New(Id As Long, IdMantenimiento As Long, idTecnicoG As Long, Fecha As Date, IdTecnico As Long, IdCliente As Long, Descripcion As String, Estado As String)
        Me.Id1 = Id
        Me.IdMantenimiento = IdMantenimiento
        Me.IdTecnicoGenerador = idTecnicoG
        Me.FechaCreacion = Fecha
        Me.IdTecnico = IdTecnico
        Me.IdCliente1 = IdCliente
        Me.Descripcion = Descripcion
        Me.Estado = Estado
    End Sub

    Public Property IdMantenimiento1 As Long
        Get
            Return IdMantenimiento
        End Get
        Set(value As Long)
            IdMantenimiento = value
        End Set
    End Property

    Public Property IdTecnicoGenerador1 As Long
        Get
            Return IdTecnicoGenerador
        End Get
        Set(value As Long)
            IdTecnicoGenerador = value
        End Set
    End Property

    Public Property FechaCreacion1 As Date
        Get
            Return FechaCreacion
        End Get
        Set(value As Date)
            FechaCreacion = value
        End Set
    End Property

    Public Property IdTecnico1 As Long
        Get
            Return IdTecnico
        End Get
        Set(value As Long)
            IdTecnico = value
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

    Public Property Estado1 As String
        Get
            Return Estado
        End Get
        Set(value As String)
            Estado = value
        End Set
    End Property

    Public Property FechaTerminacion1 As Date
        Get
            Return FechaTerminacion
        End Get
        Set(value As Date)
            FechaTerminacion = value
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

    Public Property Id1 As Long
        Get
            Return Id
        End Get
        Set(value As Long)
            Id = value
        End Set
    End Property
End Class
