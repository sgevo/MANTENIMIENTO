Public Class Trabajo
    Private Id As Long
    Private Trabajo As String

    Public Sub New(Trabajo As String)
        Me.Trabajo1 = Trabajo
    End Sub

    Public Sub New(Id As Long, Trabajo As String)
        Me.Id1 = Id
        Me.Trabajo1 = Trabajo
    End Sub

    Public Property Id1 As Long
        Get
            Return Id
        End Get
        Set(value As Long)
            Id = value
        End Set
    End Property

    Public Property Trabajo1 As String
        Get
            Return Trabajo
        End Get
        Set(value As String)
            Trabajo = value
        End Set
    End Property
End Class
