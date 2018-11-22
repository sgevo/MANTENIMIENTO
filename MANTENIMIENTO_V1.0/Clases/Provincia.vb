Public Class Provincia

    Private Id As Long 'Antiguo codigo
    Private Provincia As String
    Private CP As String

    Public Sub New(id As Long, provincia As String, cP As String)
        Me.Id1 = id
        Me.Provincia1 = provincia
        Me.CP1 = cP
    End Sub

    Public Sub New()

    End Sub

    Public Property Id1 As Long
        Get
            Return Id
        End Get
        Set(value As Long)
            Id = value
        End Set
    End Property

    Public Property Provincia1 As String
        Get
            Return Provincia
        End Get
        Set(value As String)
            Provincia = value
        End Set
    End Property

    Public Property CP1 As String
        Get
            Return CP
        End Get
        Set(value As String)
            CP = value
        End Set
    End Property
End Class
