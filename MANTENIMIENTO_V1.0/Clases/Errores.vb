Public Class Errores


    Private Tipo As Long
    Private _titulo As String
    Private _arrayMensajes As New ArrayList()
    Private Foco As String
    Private Control As String
    Private Pantalla As Form
    Private Pie As Boolean

    Public Sub New()
    End Sub

    Public Sub New(tipo As Long, titulo As String)
        Me.Tipo = tipo
        Me.Titulo = titulo
    End Sub

    Public Property ArrayMensajes As ArrayList
        Get
            Return _arrayMensajes
        End Get
        Set(value As ArrayList)
            _arrayMensajes = value
        End Set
    End Property

    Public Property Titulo As String
        Get
            Return _titulo
        End Get
        Set(value As String)
            _titulo = value
        End Set
    End Property

    Public Property Tipo1 As Long
        Get
            Return Tipo
        End Get
        Set(value As Long)
            Tipo = value
        End Set
    End Property

    Public Property Foco1 As String
        Get
            Return Foco
        End Get
        Set(value As String)
            Foco = value
        End Set
    End Property

    Public Property Control1 As String
        Get
            Return Control
        End Get
        Set(value As String)
            Control = value
        End Set
    End Property

    Public Property Pantalla1 As Form
        Get
            Return Pantalla
        End Get
        Set(value As Form)
            Pantalla = value
        End Set
    End Property

    Public Property Pie1 As Boolean
        Get
            Return Pie
        End Get
        Set(value As Boolean)
            Pie = value
        End Set
    End Property

    Public Sub SetMensaje(Texto As String)

        ArrayMensajes.Add(Texto)
    End Sub

End Class
