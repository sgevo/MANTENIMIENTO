Public Class FormaPago

    Private Id As Long
    Private Descripcion As String
    Private Plazos As Integer
    Private DiasEntrePlazos As Integer
    Private PrimerPago As Integer

    Public Sub New(id As Long, descripcion As String, plazos As Integer, diasEntrePlazos As Integer, primerPago As Integer)
        Me.Id = id
        Me.Descripcion = descripcion
        Me.Plazos = plazos
        Me.DiasEntrePlazos = diasEntrePlazos
        Me.PrimerPago = primerPago
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

    Public Property Plazos1 As Integer
        Get
            Return Plazos
        End Get
        Set(value As Integer)
            Plazos = value
        End Set
    End Property

    Public Property DiasEntrePlazos1 As Integer
        Get
            Return DiasEntrePlazos
        End Get
        Set(value As Integer)
            DiasEntrePlazos = value
        End Set
    End Property

    Public Property PrimerPago1 As Integer
        Get
            Return PrimerPago
        End Get
        Set(value As Integer)
            PrimerPago = value
        End Set
    End Property
End Class
