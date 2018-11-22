Imports System.Data.OleDb

Module BDMovimientos
    Dim RecordV As OleDbCommand
    Dim ConsultaV As OleDbDataReader

    Function ObtenerMovimientos(idCliente As Long) As ArrayList
        ' Dim objVersiones As Pack
        Dim ArrayMovimientos As New ArrayList() 'si no le pongo New se le va la pinza
        'Dim Dato2 As Double

        Try
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            RecordV = New OleDbCommand("SELECT Id, Tipo, Fecha, IdCliente, IdProducto, IdVersion, IdPack, Licencia, Clave, Red FROM Movimientos Where IdCliente = " & idCliente & " ORDER BY Fecha, IdProducto;", BDConexion)
            RecordV.ExecuteNonQuery()

            ConsultaV = RecordV.ExecuteReader

            While ConsultaV.Read()
                'Tengo que controlar si los campos numéricos son nulos
                'If IsDBNull(ConsultaV(2).ToString) Then
                '    Dato2 = 0
                'Else
                '    If IsNumeric(ConsultaV(2).ToString) Then
                '        Dato2 = Convert.ToDouble(ConsultaV(2).ToString)
                '    Else
                '        Dato2 = 0
                '    End If
                'End If

                ArrayMovimientos.Add(New Movimiento(Convert.ToInt32(ConsultaV(0).ToString), ConsultaV(1).ToString, Convert.ToDateTime(ConsultaV(2).ToString), ConsultaV(3).ToString, ConsultaV(4).ToString, ConsultaV(5).ToString, ConsultaV(6).ToString, ConsultaV(7).ToString, ConsultaV(8).ToString, Convert.ToBoolean(ConsultaV(9).ToString)))
            End While

            ConsultaV.Close()
            BD.Desconectar(BDConexion)

            Return (ArrayMovimientos)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (ArrayMovimientos)
        End Try

    End Function

    Function ObtenerClienteDeLicencia(Licencia As String) As Long

        Dim MiCliente As Long

        Try
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            RecordV = New OleDbCommand("SELECT LicenciaProducto1, LicenciaProducto2, IdCliente From ProductosCliente GROUP BY LicenciaProducto1, LicenciaProducto2, IdCliente Having LicenciaProducto1 = '" & Licencia & "' OR LicenciaProducto2 = '" & Licencia & "';", BDConexion)
            RecordV.ExecuteNonQuery()

            ConsultaV = RecordV.ExecuteReader

            While ConsultaV.Read()
                'Tengo que controlar si los campos numéricos son nulos
                'If IsDBNull(ConsultaV(2).ToString) Then
                '    Dato2 = 0
                'Else
                '    If IsNumeric(ConsultaV(2).ToString) Then
                '        Dato2 = Convert.ToDouble(ConsultaV(2).ToString)
                '    Else
                '        Dato2 = 0
                '    End If
                'End If

                MiCliente = Convert.ToInt32(ConsultaV(2).ToString)
            End While

            ConsultaV.Close()
            BD.Desconectar(BDConexion)

            Return (MiCliente)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (MiCliente)
        End Try

    End Function

End Module
