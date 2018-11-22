Public Class Mantenimiento
    Private Id As Long
    Private Id_Cliente As Long
    Private Fecha As Date
    Private Id_Tecnico As Long
    Private Medio As String
    Private Tipo As String
    Private Tema As String
    Private Producto As String
    Private Id_Trabajo As Long
    Private Subtrabajo As String
    Private Donde As String
    Private Id_Tecnico_Asignar As Long
    Private Realizado As String
    Private Sugerido As String

    Public Sub New(id As Long, Cliente As Long, fecha As Date, idtecnico As Long, medio As String, tipo As String, tema As String, producto As String, idtrabajo As Long, subtrabajo As String, donde As String, idtecnicoasignar As Long, realizado As String, sugerido As String)
        Me.Id1 = id
        Me.Id_Cliente1 = Cliente
        Me.Fecha1 = fecha
        Me.Id_Tecnico1 = idtecnico
        Me.Medio1 = medio
        Me.Tipo1 = tipo
        Me.Tema1 = tema
        Me.Producto1 = producto
        Me.Id_Trabajo1 = idtrabajo
        Me.Subtrabajo1 = subtrabajo
        Me.Donde1 = donde
        Me.Id_Tecnico_Asignar1 = idtecnicoasignar
        Me.Realizado1 = realizado
        Me.Sugerido1 = sugerido
    End Sub

    Public Sub New(id As Long)
        Me.Id1 = id
        'Me.Id_Cliente1 = Cliente
        ' Me.Fecha1 = fecha
        'Me.Id_Tecnico1 = idtecnico
        'Me.Medio1 = medio
        'Me.Tipo1 = tipo
        'Me.Tema1 = tema
        'Me.Producto1 = producto
        'Me.Id_Trabajo1 = idtrabajo
        '        Me.Subtrabajo1 = subtrabajo
        '        Me.Donde1 = donde
        '        Me.Id_Tecnico_Asignar1 = idtecnicoasignar
        '        Me.Realizado1 = realizado
        '        Me.Sugerido1 = sugerido
    End Sub


    Public Sub New(Cliente As Long, fecha As Date, idtecnico As Long, medio As String, tipo As String, tema As String, producto As String, idtrabajo As Long, subtrabajo As String, donde As String, idtecnicoasignar As Long, realizado As String, sugerido As String)
        Me.Id_Cliente1 = Cliente
        Me.Fecha1 = fecha
        Me.Id_Tecnico1 = idtecnico
        Me.Medio1 = medio
        Me.Tipo1 = tipo
        Me.Tema1 = tema
        Me.Producto1 = producto
        Me.Id_Trabajo1 = idtrabajo
        Me.Subtrabajo1 = subtrabajo
        Me.Donde1 = donde
        Me.Id_Tecnico_Asignar1 = idtecnicoasignar
        Me.Realizado1 = realizado
        Me.Sugerido1 = sugerido
    End Sub

    Public Property Id_Cliente1 As Long
        Get
            Return Id_Cliente
        End Get
        Set(value As Long)
            Id_Cliente = value
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

    Public Property Id_Tecnico1 As Long
        Get
            Return Id_Tecnico
        End Get
        Set(value As Long)
            Id_Tecnico = value
        End Set
    End Property

    Public Property Medio1 As String
        Get
            Return Medio
        End Get
        Set(value As String)
            Medio = value
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

    Public Property Tema1 As String
        Get
            Return Tema
        End Get
        Set(value As String)
            Tema = value
        End Set
    End Property

    Public Property Producto1 As String
        Get
            Return Producto
        End Get
        Set(value As String)
            Producto = value
        End Set
    End Property

    Public Property Id_Trabajo1 As Long
        Get
            Return Id_Trabajo
        End Get
        Set(value As Long)
            Id_Trabajo = value
        End Set
    End Property

    Public Property Subtrabajo1 As String
        Get
            Return Subtrabajo
        End Get
        Set(value As String)
            Subtrabajo = value
        End Set
    End Property

    Public Property Donde1 As String
        Get
            Return Donde
        End Get
        Set(value As String)
            Donde = value
        End Set
    End Property

    Public Property Id_Tecnico_Asignar1 As Long
        Get
            Return Id_Tecnico_Asignar
        End Get
        Set(value As Long)
            Id_Tecnico_Asignar = value
        End Set
    End Property

    Public Property Realizado1 As String
        Get
            Return Realizado
        End Get
        Set(value As String)
            Realizado = value
        End Set
    End Property

    Public Property Sugerido1 As String
        Get
            Return Sugerido
        End Get
        Set(value As String)
            Sugerido = value
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
