Imports System.Data.OleDb
Imports MantEvolution

Public Class Pedido



    Private Id As Long 'Antiguo codigo

    Private Numero As String
    Private Fecha As String

    Public ObjCliente As Cliente

    Private Base As String
    Private Iva As String
    Private Total As String

    Private ObjFormaPago As FormaPago

    Private Observaciones As String

    Private Estado As Integer

    Private IdFactura As Long


    Private Mes As Integer
    Private Trimestre As Integer

    Private arrayPedidosLineas As New ArrayList()

    Public Sub New(id As Long, numero As String, fecha As String, idCliente As String, base As String, iva As String, total As String, observaciones As String, estado As String, BDCONEXION As OleDbConnection)

        Me.Id = id
        Me.Numero = numero
        Me.Fecha = fecha
        '   Me.ObjCliente = obtenerUnCliente2(CLng(idCliente))
        Me.Base = base
        Me.Iva = iva
        Me.Total = total
        '  Me.ObjFormaPago = ObjFormaPago
        Me.Observaciones = observaciones
        '  Me.Estado = Convert.ToInt32(estado)
        Me.Mes = Month(Convert.ToDateTime(fecha))
        Select Case Month(Convert.ToDateTime(fecha))
            Case 1 To 3
                Me.Trimestre = 1
            Case 4 To 6
                Me.Trimestre = 2
            Case 7 To 9
                Me.Trimestre = 3
            Case 10 To 12
                Me.Trimestre = 4
        End Select
    End Sub


    'Public Property ObjProvincia1 As Provincia
    '    Get
    '        Return ObjProvincia
    '    End Get
    '    Set(value As Provincia)
    '        ObjProvincia = value
    '    End Set
    'End Property

    Public Property ObjCliente1 As Cliente
        Get
            Return ObjCliente
        End Get
        Set(value As Cliente)
            ObjCliente = value
        End Set
    End Property

    Public Property ObjClienteAñadir(idCli As Long) As Cliente
        Get
            Return ObjCliente
        End Get
        Set(value As Cliente)
            ObjCliente = value
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

    Public Property Numero1 As String
        Get
            Return Numero
        End Get
        Set(value As String)
            Numero = value
        End Set
    End Property

    Public Property Fecha1 As String
        Get
            Return Fecha
        End Get
        Set(value As String)
            Fecha = value
        End Set
    End Property

    Public Property Base1 As String
        Get
            Return Base
        End Get
        Set(value As String)
            Base = value
        End Set
    End Property

    Public Property Iva1 As String
        Get
            Return Iva
        End Get
        Set(value As String)
            Iva = value
        End Set
    End Property

    Public Property Total1 As String
        Get
            Return Total
        End Get
        Set(value As String)
            Total = value
        End Set
    End Property

    Public Property Observaciones1 As String
        Get
            Return Observaciones
        End Get
        Set(value As String)
            Observaciones = value
        End Set
    End Property

    Public Property Estado1 As Integer
        Get
            Return Estado
        End Get
        Set(value As Integer)
            Estado = value
        End Set
    End Property

    Public Property Mes1 As Integer
        Get
            Return Mes
        End Get
        Set(value As Integer)
            Mes = value
        End Set
    End Property

    Public Property Trimestre1 As Integer
        Get
            Return Trimestre
        End Get
        Set(value As Integer)
            Trimestre = value
        End Set
    End Property
End Class
