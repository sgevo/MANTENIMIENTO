Imports System.Data.OleDb

Module BDProductosCliente
    Dim Record As OleDbCommand
    Dim Consulta As OleDbDataReader
    Dim RecordPyM As OleDbCommand
    Dim ConsultaPyM As OleDbDataReader

    Function ObtenerProductosCliente(idCliente As Long) As ArrayList
        Dim Dato2 As Double
        Dim Dato3 As Double
        Dim Dato8 As Double
        Dim Dato13 As Double
        Dim ArrayProductosCliente As New ArrayList() 'si no le pongo New se le va la pinza
        Dim objCliente As Cliente

        Try
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            Record = New OleDbCommand("SELECT IdProductosCliente, Tipo, IdProducto, IdPack, LicenciaProducto1, ClaveProducto1, Red1, Mantenimiento1, IdVersion1, LicenciaProducto2, ClaveProducto2, Red2, Mantenimiento2, IdVersion2, FechaAdquisicion, FechaInicioServicio, FechaFinServicio  FROM ProductosCliente Where idCliente = " & idCliente & ";", BDConexion)
            Record.ExecuteNonQuery()

            Consulta = Record.ExecuteReader

            objCliente = ObtenerUnCliente(idCliente)

            While Consulta.Read()
                'Tengo que controlar si los campos numéricos son nulos
                If IsDBNull(Consulta(2).ToString) Then
                    Dato2 = 0
                Else
                    If IsNumeric(Consulta(2).ToString) Then
                        Dato2 = Convert.ToDouble(Consulta(2).ToString)
                    Else
                        Dato2 = 0
                    End If
                End If
                If IsDBNull(Consulta(3).ToString) Then
                    Dato3 = 0
                Else
                    If IsNumeric(Consulta(3).ToString) Then
                        Dato3 = Convert.ToDouble(Consulta(3).ToString)
                    Else
                        Dato3 = 0
                    End If
                End If
                If IsDBNull(Consulta(8).ToString) Then
                    Dato8 = 0
                Else
                    If IsNumeric(Consulta(8).ToString) Then
                        Dato8 = Convert.ToDouble(Consulta(8).ToString)
                    Else
                        Dato8 = 0
                    End If
                End If
                If IsDBNull(Consulta(13).ToString) Then
                    Dato13 = 0
                Else
                    If IsNumeric(Consulta(13).ToString) Then
                        Dato13 = Convert.ToDouble(Consulta(13).ToString)
                    Else
                        Dato13 = 0
                    End If
                End If
                If Consulta(1).ToString = "0" Then 'Producto
                    ArrayProductosCliente.Add(New ProductosCliente(Convert.ToInt32(Consulta(0).ToString), idCliente, Consulta(1).ToString, Dato2, Dato3, Consulta(4).ToString, Consulta(5).ToString, Convert.ToBoolean(Consulta(6).ToString), Convert.ToBoolean(Consulta(7).ToString), Dato8, Consulta(9).ToString, Consulta(10).ToString, Convert.ToBoolean(Consulta(11).ToString), Convert.ToBoolean(Consulta(12).ToString), Dato13, Convert.ToDateTime(Consulta(14).ToString), objCliente))
                ElseIf Consulta(1).ToString = "1" Then 'Servicio
                    ArrayProductosCliente.Add(New ProductosCliente(Convert.ToInt32(Consulta(0).ToString), idCliente, Consulta(1).ToString, Dato2, Dato3, Consulta(4).ToString, Consulta(5).ToString, Convert.ToBoolean(Consulta(6).ToString), Convert.ToBoolean(Consulta(7).ToString), Dato8, Consulta(9).ToString, Consulta(10).ToString, Convert.ToBoolean(Consulta(11).ToString), Convert.ToBoolean(Consulta(12).ToString), Dato13, Convert.ToDateTime(Consulta(14).ToString), Convert.ToDateTime(Consulta(15).ToString), Convert.ToDateTime(Consulta(16).ToString), objCliente))
                ElseIf Consulta(1).ToString = "2" Then 'Pack
                    ArrayProductosCliente.Add(New ProductosCliente(Convert.ToInt32(Consulta(0).ToString), idCliente, Consulta(1).ToString, Dato2, Dato3, Consulta(4).ToString, Consulta(5).ToString, Convert.ToBoolean(Consulta(6).ToString), Convert.ToBoolean(Consulta(7).ToString), Dato8, Consulta(9).ToString, Consulta(10).ToString, Convert.ToBoolean(Consulta(11).ToString), Convert.ToBoolean(Consulta(12).ToString), Dato13, Convert.ToDateTime(Consulta(14).ToString), Convert.ToDateTime(Consulta(15).ToString), Convert.ToDateTime(Consulta(16).ToString), objCliente))
                End If
            End While

            Consulta.Close()
            BD.Desconectar(BDConexion)

            Return (ArrayProductosCliente)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (ArrayProductosCliente)
        End Try

    End Function

    Function ObtenerProductosTotalesTipo(Tipo As Long) As Long

        Dim Cuantos As Long

        'Tipo=0 Productos, =1 Mantes , =2 Packs

        Try
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            Record = New OleDbCommand("SELECT IdProductosCliente, Tipo, IdProducto, IdPack, LicenciaProducto1, ClaveProducto1, Red1, Mantenimiento1, IdVersion1, LicenciaProducto2, ClaveProducto2, Red2, Mantenimiento2, IdVersion2, FechaAdquisicion, FechaInicioServicio, FechaFinServicio  FROM ProductosCliente Where Tipo = '" & Tipo & "';", BDConexion)
            Record.ExecuteNonQuery()

            Consulta = Record.ExecuteReader

            Cuantos = 0

            While Consulta.Read()
                Cuantos = Cuantos + 1
            End While

            'While Consulta.Read()
            '    'Tengo que controlar si los campos numéricos son nulos
            '    If IsDBNull(Consulta(2).ToString) Then
            '        Dato2 = 0
            '    Else
            '        If IsNumeric(Consulta(2).ToString) Then
            '            Dato2 = Convert.ToDouble(Consulta(2).ToString)
            '        Else
            '            Dato2 = 0
            '        End If
            '    End If
            '    If IsDBNull(Consulta(3).ToString) Then
            '        Dato3 = 0
            '    Else
            '        If IsNumeric(Consulta(3).ToString) Then
            '            Dato3 = Convert.ToDouble(Consulta(3).ToString)
            '        Else
            '            Dato3 = 0
            '        End If
            '    End If
            '    If IsDBNull(Consulta(8).ToString) Then
            '        Dato8 = 0
            '    Else
            '        If IsNumeric(Consulta(8).ToString) Then
            '            Dato8 = Convert.ToDouble(Consulta(8).ToString)
            '        Else
            '            Dato8 = 0
            '        End If
            '    End If
            '    If IsDBNull(Consulta(13).ToString) Then
            '        Dato13 = 0
            '    Else
            '        If IsNumeric(Consulta(13).ToString) Then
            '            Dato13 = Convert.ToDouble(Consulta(13).ToString)
            '        Else
            '            Dato13 = 0
            '        End If
            '    End If
            '    If Consulta(1).ToString = "0" Then 'Producto
            '        ArrayProductosCliente.Add(New ProductosCliente(Convert.ToInt32(Consulta(0).ToString), idCliente, Consulta(1).ToString, Dato2, Dato3, Consulta(4).ToString, Consulta(5).ToString, Convert.ToBoolean(Consulta(6).ToString), Convert.ToBoolean(Consulta(7).ToString), Dato8, Consulta(9).ToString, Consulta(10).ToString, Convert.ToBoolean(Consulta(11).ToString), Convert.ToBoolean(Consulta(12).ToString), Dato13, Convert.ToDateTime(Consulta(14).ToString)))
            '    ElseIf Consulta(1).ToString = "1" Then 'Servicio
            '        ArrayProductosCliente.Add(New ProductosCliente(Convert.ToInt32(Consulta(0).ToString), idCliente, Consulta(1).ToString, Dato2, Dato3, Consulta(4).ToString, Consulta(5).ToString, Convert.ToBoolean(Consulta(6).ToString), Convert.ToBoolean(Consulta(7).ToString), Dato8, Consulta(9).ToString, Consulta(10).ToString, Convert.ToBoolean(Consulta(11).ToString), Convert.ToBoolean(Consulta(12).ToString), Dato13, Convert.ToDateTime(Consulta(14).ToString), Convert.ToDateTime(Consulta(15).ToString), Convert.ToDateTime(Consulta(16).ToString)))
            '    ElseIf Consulta(1).ToString = "2" Then 'Pack
            '        ArrayProductosCliente.Add(New ProductosCliente(Convert.ToInt32(Consulta(0).ToString), idCliente, Consulta(1).ToString, Dato2, Dato3, Consulta(4).ToString, Consulta(5).ToString, Convert.ToBoolean(Consulta(6).ToString), Convert.ToBoolean(Consulta(7).ToString), Dato8, Consulta(9).ToString, Consulta(10).ToString, Convert.ToBoolean(Consulta(11).ToString), Convert.ToBoolean(Consulta(12).ToString), Dato13, Convert.ToDateTime(Consulta(14).ToString), Convert.ToDateTime(Consulta(15).ToString), Convert.ToDateTime(Consulta(16).ToString)))
            '    End If
            'End While

            Consulta.Close()
            BD.Desconectar(BDConexion)

            Return (Cuantos)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (Cuantos)
        End Try

    End Function

    Function ObtenerClientesProductoTipo(Tipo As Long) As ArrayList

        Dim Cuantos As Long
        Dim ArrayClientes As New ArrayList()
        Dim ArrayClientesPyM As New ArrayList()
        Dim ArrayClientesTemp As New ArrayList()
        Dim Miro As Boolean

        Dim Sql As String

        'Tipo=0 Productos, =1 Mantes , =2 Packs, 3= pack y mantes, 4= Productos sin Pack ni Mante

        Try
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            If Tipo = 3 Then
                Sql = "Select IdCliente, Tipo FROM ProductosCliente Where Tipo = '1' OR Tipo='2' GROUP BY IdCliente,Tipo;"
                'Record = New OleDbCommand("SELECT IdCliente, Tipo FROM ProductosCliente Where Tipo = '1' OR Tipo='2' GROUP BY IdCliente,Tipo;", BDConexion)
            ElseIf Tipo = 4 Then
                Sql = "SELECT IdCliente, Tipo FROM ProductosCliente Where Tipo = '0' GROUP BY IdCliente,Tipo;"
                'Record = New OleDbCommand("SELECT IdCliente, Tipo FROM ProductosCliente Where Tipo = '0' GROUP BY IdCliente,Tipo;", BDConexion)
            Else
                Sql = "SELECT IdCliente, Tipo FROM ProductosCliente Where Tipo = '" & Tipo & "' GROUP BY IdCliente,Tipo;"
                'Record = New OleDbCommand("SELECT IdCliente, Tipo FROM ProductosCliente Where Tipo = '" & Tipo & "' GROUP BY IdCliente,Tipo;", BDConexion)
            End If

            Record = New OleDbCommand(Sql, BDConexion)
            Record.ExecuteNonQuery()

            Consulta = Record.ExecuteReader

            Cuantos = 0

            While Consulta.Read()
                Cuantos = Cuantos + 1
                If Tipo = 4 Then
                    ArrayClientesTemp.Add((Convert.ToDouble(Consulta(0).ToString)))
                Else
                    ArrayClientes.Add((Convert.ToDouble(Consulta(0).ToString)))
                End If

            End While

            If Tipo = 4 Then
                'aquí tengo que quitar los que tengan pack o mante, primero los busco
                RecordPyM = New OleDbCommand("SELECT IdCliente, Tipo FROM ProductosCliente Where Tipo = '1' OR Tipo='2' GROUP BY IdCliente,Tipo;", BDConexion)
                RecordPyM.ExecuteNonQuery()

                ConsultaPyM = RecordPyM.ExecuteReader

                While ConsultaPyM.Read()
                    ArrayClientesPyM.Add((Convert.ToDouble(ConsultaPyM(0).ToString)))
                End While

                For Each idClientes In ArrayClientesTemp
                    Miro = False
                    For Each idClientesPyM In ArrayClientesPyM
                        If idClientes = idClientesPyM Then
                            'este no
                            Miro = True
                            Exit For
                        End If
                    Next
                    If Not Miro Then 'no lo he encontrado, entonces lo pongo
                        ArrayClientes.Add(idClientes)
                    End If
                Next
                ConsultaPyM.Close()
            End If

            'While Consulta.Read()
            '    'Tengo que controlar si los campos numéricos son nulos
            '    If IsDBNull(Consulta(2).ToString) Then
            '        Dato2 = 0
            '    Else
            '        If IsNumeric(Consulta(2).ToString) Then
            '            Dato2 = Convert.ToDouble(Consulta(2).ToString)
            '        Else
            '            Dato2 = 0
            '        End If
            '    End If
            '    If IsDBNull(Consulta(3).ToString) Then
            '        Dato3 = 0
            '    Else
            '        If IsNumeric(Consulta(3).ToString) Then
            '            Dato3 = Convert.ToDouble(Consulta(3).ToString)
            '        Else
            '            Dato3 = 0
            '        End If
            '    End If
            '    If IsDBNull(Consulta(8).ToString) Then
            '        Dato8 = 0
            '    Else
            '        If IsNumeric(Consulta(8).ToString) Then
            '            Dato8 = Convert.ToDouble(Consulta(8).ToString)
            '        Else
            '            Dato8 = 0
            '        End If
            '    End If
            '    If IsDBNull(Consulta(13).ToString) Then
            '        Dato13 = 0
            '    Else
            '        If IsNumeric(Consulta(13).ToString) Then
            '            Dato13 = Convert.ToDouble(Consulta(13).ToString)
            '        Else
            '            Dato13 = 0
            '        End If
            '    End If
            '    If Consulta(1).ToString = "0" Then 'Producto
            '        ArrayProductosCliente.Add(New ProductosCliente(Convert.ToInt32(Consulta(0).ToString), idCliente, Consulta(1).ToString, Dato2, Dato3, Consulta(4).ToString, Consulta(5).ToString, Convert.ToBoolean(Consulta(6).ToString), Convert.ToBoolean(Consulta(7).ToString), Dato8, Consulta(9).ToString, Consulta(10).ToString, Convert.ToBoolean(Consulta(11).ToString), Convert.ToBoolean(Consulta(12).ToString), Dato13, Convert.ToDateTime(Consulta(14).ToString)))
            '    ElseIf Consulta(1).ToString = "1" Then 'Servicio
            '        ArrayProductosCliente.Add(New ProductosCliente(Convert.ToInt32(Consulta(0).ToString), idCliente, Consulta(1).ToString, Dato2, Dato3, Consulta(4).ToString, Consulta(5).ToString, Convert.ToBoolean(Consulta(6).ToString), Convert.ToBoolean(Consulta(7).ToString), Dato8, Consulta(9).ToString, Consulta(10).ToString, Convert.ToBoolean(Consulta(11).ToString), Convert.ToBoolean(Consulta(12).ToString), Dato13, Convert.ToDateTime(Consulta(14).ToString), Convert.ToDateTime(Consulta(15).ToString), Convert.ToDateTime(Consulta(16).ToString)))
            '    ElseIf Consulta(1).ToString = "2" Then 'Pack
            '        ArrayProductosCliente.Add(New ProductosCliente(Convert.ToInt32(Consulta(0).ToString), idCliente, Consulta(1).ToString, Dato2, Dato3, Consulta(4).ToString, Consulta(5).ToString, Convert.ToBoolean(Consulta(6).ToString), Convert.ToBoolean(Consulta(7).ToString), Dato8, Consulta(9).ToString, Consulta(10).ToString, Convert.ToBoolean(Consulta(11).ToString), Convert.ToBoolean(Consulta(12).ToString), Dato13, Convert.ToDateTime(Consulta(14).ToString), Convert.ToDateTime(Consulta(15).ToString), Convert.ToDateTime(Consulta(16).ToString)))
            '    End If
            'End While

            Consulta.Close()
            BD.Desconectar(BDConexion)

            Return (ArrayClientes)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (ArrayClientes)
        End Try

    End Function

    Function ObtenerClientesProducto(Producto As Long) As ArrayList

        Dim ArrayClientes As New ArrayList()

        'Tipo=0 Productos, =1 Mantes , =2 Packs

        Try
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            Record = New OleDbCommand("SELECT IdCliente, Tipo, IdProducto FROM ProductosCliente Where IdProducto = " & Producto & " GROUP BY IdCliente,Tipo,IdProducto;", BDConexion)
            Record.ExecuteNonQuery()

            Consulta = Record.ExecuteReader

            While Consulta.Read()

                ArrayClientes.Add((Convert.ToDouble(Consulta(0).ToString)))

                'Tengo que controlar si los campos numéricos son nulos

                'If IsDBNull(Consulta(2).ToString) Then
                '    Dato2 = 0
                'Else
                '    If IsNumeric(Consulta(2).ToString) Then
                '        Dato2 = Convert.ToDouble(Consulta(2).ToString)
                '    Else
                '        Dato2 = 0
                '    End If
                'End If
                'If IsDBNull(Consulta(3).ToString) Then
                '    Dato3 = 0
                'Else
                '    If IsNumeric(Consulta(3).ToString) Then
                '        Dato3 = Convert.ToDouble(Consulta(3).ToString)
                '    Else
                '        Dato3 = 0
                '    End If
                'End If
                'If IsDBNull(Consulta(8).ToString) Then
                '    Dato8 = 0
                'Else
                '    If IsNumeric(Consulta(8).ToString) Then
                '        Dato8 = Convert.ToDouble(Consulta(8).ToString)
                '    Else
                '        Dato8 = 0
                '    End If
                'End If
                'If IsDBNull(Consulta(13).ToString) Then
                '    Dato13 = 0
                'Else
                '    If IsNumeric(Consulta(13).ToString) Then
                '        Dato13 = Convert.ToDouble(Consulta(13).ToString)
                '    Else
                '        Dato13 = 0
                '    End If
                'End If

                'ArrayClientes.Add(New Cliente(Convert.ToDouble(Consulta(0).ToString)))

            End While

            Consulta.Close()
            BD.Desconectar(BDConexion)

            Return (ArrayClientes)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (ArrayClientes)
        End Try
    End Function

    Function ObtenerClientesPack(Pack As Long) As ArrayList

        Dim ArrayClientes As New ArrayList()

        'Tipo=0 Productos, =1 Mantes , =2 Packs

        Try
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            Record = New OleDbCommand("SELECT IdCliente, Tipo, IdPack FROM ProductosCliente Where IdPack = " & Pack & " GROUP BY IdCliente,Tipo,IdPack;", BDConexion)
            Record.ExecuteNonQuery()

            Consulta = Record.ExecuteReader

            While Consulta.Read()

                ArrayClientes.Add((Convert.ToDouble(Consulta(0).ToString)))

            End While

            Consulta.Close()
            BD.Desconectar(BDConexion)

            Return (ArrayClientes)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (ArrayClientes)
        End Try
    End Function

    Function ObtenerProductosClienteTipo(tipo As Long) As ArrayList
        Dim Dato2 As Double
        Dim Dato3 As Double
        Dim Dato8 As Double
        Dim Dato13 As Double
        Dim ArrayProductosCliente As New ArrayList() 'si no le pongo New se le va la pinza
        Dim objCliente As Cliente

        Dim ArrayTodosClientes As New ArrayList()
        Dim objTodosClientes As Cliente

        Try
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            Record = New OleDbCommand("SELECT IdProductosCliente, Tipo, IdProducto, IdPack, LicenciaProducto1, ClaveProducto1, Red1, Mantenimiento1, IdVersion1, LicenciaProducto2, ClaveProducto2, Red2, Mantenimiento2, IdVersion2, FechaAdquisicion, FechaInicioServicio, FechaFinServicio,IdCliente  FROM ProductosCliente Where Tipo = '" & tipo & "';", BDConexion)
            Record.ExecuteNonQuery()

            Consulta = Record.ExecuteReader

            ArrayTodosClientes = ObtenerTodosLosClientes()

            While Consulta.Read()
                'objCliente = ObtenerUnCliente(Convert.ToInt32(Consulta(17).ToString))

                For Each objTodosClientes In ArrayTodosClientes
                    If objTodosClientes.Id1 = Convert.ToInt32(Consulta(17).ToString) Then
                        objCliente = objTodosClientes
                        Exit For
                    End If
                Next

                'Tengo que controlar si los campos numéricos son nulos
                If IsDBNull(Consulta(2).ToString) Then
                    Dato2 = 0
                Else
                    If IsNumeric(Consulta(2).ToString) Then
                        Dato2 = Convert.ToDouble(Consulta(2).ToString)
                    Else
                        Dato2 = 0
                    End If
                End If
                If IsDBNull(Consulta(3).ToString) Then
                    Dato3 = 0
                Else
                    If IsNumeric(Consulta(3).ToString) Then
                        Dato3 = Convert.ToDouble(Consulta(3).ToString)
                    Else
                        Dato3 = 0
                    End If
                End If
                If IsDBNull(Consulta(8).ToString) Then
                    Dato8 = 0
                Else
                    If IsNumeric(Consulta(8).ToString) Then
                        Dato8 = Convert.ToDouble(Consulta(8).ToString)
                    Else
                        Dato8 = 0
                    End If
                End If
                If IsDBNull(Consulta(13).ToString) Then
                    Dato13 = 0
                Else
                    If IsNumeric(Consulta(13).ToString) Then
                        Dato13 = Convert.ToDouble(Consulta(13).ToString)
                    Else
                        Dato13 = 0
                    End If
                End If
                If Consulta(1).ToString = "0" Then 'Producto
                    ArrayProductosCliente.Add(New ProductosCliente(Convert.ToInt32(Consulta(0).ToString), Convert.ToInt32(Consulta(17).ToString), Consulta(1).ToString, Dato2, Dato3, Consulta(4).ToString, Consulta(5).ToString, Convert.ToBoolean(Consulta(6).ToString), Convert.ToBoolean(Consulta(7).ToString), Dato8, Consulta(9).ToString, Consulta(10).ToString, Convert.ToBoolean(Consulta(11).ToString), Convert.ToBoolean(Consulta(12).ToString), Dato13, Convert.ToDateTime(Consulta(14).ToString), objCliente))
                ElseIf Consulta(1).ToString = "1" Then 'Servicio
                    ArrayProductosCliente.Add(New ProductosCliente(Convert.ToInt32(Consulta(0).ToString), Convert.ToInt32(Consulta(17).ToString), Consulta(1).ToString, Dato2, Dato3, Consulta(4).ToString, Consulta(5).ToString, Convert.ToBoolean(Consulta(6).ToString), Convert.ToBoolean(Consulta(7).ToString), Dato8, Consulta(9).ToString, Consulta(10).ToString, Convert.ToBoolean(Consulta(11).ToString), Convert.ToBoolean(Consulta(12).ToString), Dato13, Convert.ToDateTime(Consulta(14).ToString), Convert.ToDateTime(Consulta(15).ToString), Convert.ToDateTime(Consulta(16).ToString), objCliente))
                ElseIf Consulta(1).ToString = "2" Then 'Pack
                    ArrayProductosCliente.Add(New ProductosCliente(Convert.ToInt32(Consulta(0).ToString), Convert.ToInt32(Consulta(17).ToString), Consulta(1).ToString, Dato2, Dato3, Consulta(4).ToString, Consulta(5).ToString, Convert.ToBoolean(Consulta(6).ToString), Convert.ToBoolean(Consulta(7).ToString), Dato8, Consulta(9).ToString, Consulta(10).ToString, Convert.ToBoolean(Consulta(11).ToString), Convert.ToBoolean(Consulta(12).ToString), Dato13, Convert.ToDateTime(Consulta(14).ToString), Convert.ToDateTime(Consulta(15).ToString), Convert.ToDateTime(Consulta(16).ToString), objCliente))
                End If
            End While

            Consulta.Close()
            BD.Desconectar(BDConexion)

            Return (ArrayProductosCliente)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (ArrayProductosCliente)
        End Try

    End Function

    Function ObtenerProductosClienteProducto(producto As Long) As ArrayList
        Dim Dato2 As Double
        Dim Dato3 As Double
        Dim Dato8 As Double
        Dim Dato13 As Double
        Dim ArrayProductosCliente As New ArrayList() 'si no le pongo New se le va la pinza
        Dim objCliente As Cliente

        Dim ArrayTodosClientes As New ArrayList()
        Dim objTodosClientes As Cliente

        Try
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            Record = New OleDbCommand("SELECT IdProductosCliente, Tipo, IdProducto, IdPack, LicenciaProducto1, ClaveProducto1, Red1, Mantenimiento1, IdVersion1, LicenciaProducto2, ClaveProducto2, Red2, Mantenimiento2, IdVersion2, FechaAdquisicion, FechaInicioServicio, FechaFinServicio,IdCliente  FROM ProductosCliente Where IdProducto = " & producto & ";", BDConexion)
            Record.ExecuteNonQuery()

            Consulta = Record.ExecuteReader

            ArrayTodosClientes = ObtenerTodosLosClientes()

            While Consulta.Read()
                'objCliente = ObtenerUnCliente(Convert.ToInt32(Consulta(17).ToString))

                For Each objTodosClientes In ArrayTodosClientes
                    If objTodosClientes.Id1 = Convert.ToInt32(Consulta(17).ToString) Then
                        objCliente = objTodosClientes
                        Exit For
                    End If
                Next

                'Tengo que controlar si los campos numéricos son nulos
                If IsDBNull(Consulta(2).ToString) Then
                    Dato2 = 0
                Else
                    If IsNumeric(Consulta(2).ToString) Then
                        Dato2 = Convert.ToDouble(Consulta(2).ToString)
                    Else
                        Dato2 = 0
                    End If
                End If
                If IsDBNull(Consulta(3).ToString) Then
                    Dato3 = 0
                Else
                    If IsNumeric(Consulta(3).ToString) Then
                        Dato3 = Convert.ToDouble(Consulta(3).ToString)
                    Else
                        Dato3 = 0
                    End If
                End If
                If IsDBNull(Consulta(8).ToString) Then
                    Dato8 = 0
                Else
                    If IsNumeric(Consulta(8).ToString) Then
                        Dato8 = Convert.ToDouble(Consulta(8).ToString)
                    Else
                        Dato8 = 0
                    End If
                End If
                If IsDBNull(Consulta(13).ToString) Then
                    Dato13 = 0
                Else
                    If IsNumeric(Consulta(13).ToString) Then
                        Dato13 = Convert.ToDouble(Consulta(13).ToString)
                    Else
                        Dato13 = 0
                    End If
                End If
                If Consulta(1).ToString = "0" Then 'Producto
                    ArrayProductosCliente.Add(New ProductosCliente(Convert.ToInt32(Consulta(0).ToString), Convert.ToInt32(Consulta(17).ToString), Consulta(1).ToString, Dato2, Dato3, Consulta(4).ToString, Consulta(5).ToString, Convert.ToBoolean(Consulta(6).ToString), Convert.ToBoolean(Consulta(7).ToString), Dato8, Consulta(9).ToString, Consulta(10).ToString, Convert.ToBoolean(Consulta(11).ToString), Convert.ToBoolean(Consulta(12).ToString), Dato13, Convert.ToDateTime(Consulta(14).ToString), objCliente))
                ElseIf Consulta(1).ToString = "1" Then 'Servicio
                    ArrayProductosCliente.Add(New ProductosCliente(Convert.ToInt32(Consulta(0).ToString), Convert.ToInt32(Consulta(17).ToString), Consulta(1).ToString, Dato2, Dato3, Consulta(4).ToString, Consulta(5).ToString, Convert.ToBoolean(Consulta(6).ToString), Convert.ToBoolean(Consulta(7).ToString), Dato8, Consulta(9).ToString, Consulta(10).ToString, Convert.ToBoolean(Consulta(11).ToString), Convert.ToBoolean(Consulta(12).ToString), Dato13, Convert.ToDateTime(Consulta(14).ToString), Convert.ToDateTime(Consulta(15).ToString), Convert.ToDateTime(Consulta(16).ToString), objCliente))
                ElseIf Consulta(1).ToString = "2" Then 'Pack
                    ArrayProductosCliente.Add(New ProductosCliente(Convert.ToInt32(Consulta(0).ToString), Convert.ToInt32(Consulta(17).ToString), Consulta(1).ToString, Dato2, Dato3, Consulta(4).ToString, Consulta(5).ToString, Convert.ToBoolean(Consulta(6).ToString), Convert.ToBoolean(Consulta(7).ToString), Dato8, Consulta(9).ToString, Consulta(10).ToString, Convert.ToBoolean(Consulta(11).ToString), Convert.ToBoolean(Consulta(12).ToString), Dato13, Convert.ToDateTime(Consulta(14).ToString), Convert.ToDateTime(Consulta(15).ToString), Convert.ToDateTime(Consulta(16).ToString), objCliente))
                End If
            End While

            Consulta.Close()
            BD.Desconectar(BDConexion)

            Return (ArrayProductosCliente)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (ArrayProductosCliente)
        End Try

    End Function

    Function ObtenerProductosClientePack(pack As Long) As ArrayList
        Dim Dato2 As Double
        Dim Dato3 As Double
        Dim Dato8 As Double
        Dim Dato13 As Double
        Dim ArrayProductosCliente As New ArrayList() 'si no le pongo New se le va la pinza
        Dim objCliente As Cliente

        Dim ArrayTodosClientes As New ArrayList()
        Dim objTodosClientes As Cliente

        Try
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            Record = New OleDbCommand("SELECT IdProductosCliente, Tipo, IdProducto, IdPack, LicenciaProducto1, ClaveProducto1, Red1, Mantenimiento1, IdVersion1, LicenciaProducto2, ClaveProducto2, Red2, Mantenimiento2, IdVersion2, FechaAdquisicion, FechaInicioServicio, FechaFinServicio,IdCliente  FROM ProductosCliente Where IdPack = " & pack & ";", BDConexion)
            Record.ExecuteNonQuery()

            Consulta = Record.ExecuteReader

            ArrayTodosClientes = ObtenerTodosLosClientes()

            While Consulta.Read()
                'objCliente = ObtenerUnCliente(Convert.ToInt32(Consulta(17).ToString))

                For Each objTodosClientes In ArrayTodosClientes
                    If objTodosClientes.Id1 = Convert.ToInt32(Consulta(17).ToString) Then
                        objCliente = objTodosClientes
                        Exit For
                    End If
                Next

                'Tengo que controlar si los campos numéricos son nulos
                If IsDBNull(Consulta(2).ToString) Then
                    Dato2 = 0
                Else
                    If IsNumeric(Consulta(2).ToString) Then
                        Dato2 = Convert.ToDouble(Consulta(2).ToString)
                    Else
                        Dato2 = 0
                    End If
                End If
                If IsDBNull(Consulta(3).ToString) Then
                    Dato3 = 0
                Else
                    If IsNumeric(Consulta(3).ToString) Then
                        Dato3 = Convert.ToDouble(Consulta(3).ToString)
                    Else
                        Dato3 = 0
                    End If
                End If
                If IsDBNull(Consulta(8).ToString) Then
                    Dato8 = 0
                Else
                    If IsNumeric(Consulta(8).ToString) Then
                        Dato8 = Convert.ToDouble(Consulta(8).ToString)
                    Else
                        Dato8 = 0
                    End If
                End If
                If IsDBNull(Consulta(13).ToString) Then
                    Dato13 = 0
                Else
                    If IsNumeric(Consulta(13).ToString) Then
                        Dato13 = Convert.ToDouble(Consulta(13).ToString)
                    Else
                        Dato13 = 0
                    End If
                End If
                If Consulta(1).ToString = "0" Then 'Producto
                    ArrayProductosCliente.Add(New ProductosCliente(Convert.ToInt32(Consulta(0).ToString), Convert.ToInt32(Consulta(17).ToString), Consulta(1).ToString, Dato2, Dato3, Consulta(4).ToString, Consulta(5).ToString, Convert.ToBoolean(Consulta(6).ToString), Convert.ToBoolean(Consulta(7).ToString), Dato8, Consulta(9).ToString, Consulta(10).ToString, Convert.ToBoolean(Consulta(11).ToString), Convert.ToBoolean(Consulta(12).ToString), Dato13, Convert.ToDateTime(Consulta(14).ToString), objCliente))
                ElseIf Consulta(1).ToString = "1" Then 'Servicio
                    ArrayProductosCliente.Add(New ProductosCliente(Convert.ToInt32(Consulta(0).ToString), Convert.ToInt32(Consulta(17).ToString), Consulta(1).ToString, Dato2, Dato3, Consulta(4).ToString, Consulta(5).ToString, Convert.ToBoolean(Consulta(6).ToString), Convert.ToBoolean(Consulta(7).ToString), Dato8, Consulta(9).ToString, Consulta(10).ToString, Convert.ToBoolean(Consulta(11).ToString), Convert.ToBoolean(Consulta(12).ToString), Dato13, Convert.ToDateTime(Consulta(14).ToString), Convert.ToDateTime(Consulta(15).ToString), Convert.ToDateTime(Consulta(16).ToString), objCliente))
                ElseIf Consulta(1).ToString = "2" Then 'Pack
                    ArrayProductosCliente.Add(New ProductosCliente(Convert.ToInt32(Consulta(0).ToString), Convert.ToInt32(Consulta(17).ToString), Consulta(1).ToString, Dato2, Dato3, Consulta(4).ToString, Consulta(5).ToString, Convert.ToBoolean(Consulta(6).ToString), Convert.ToBoolean(Consulta(7).ToString), Dato8, Consulta(9).ToString, Consulta(10).ToString, Convert.ToBoolean(Consulta(11).ToString), Convert.ToBoolean(Consulta(12).ToString), Dato13, Convert.ToDateTime(Consulta(14).ToString), Convert.ToDateTime(Consulta(15).ToString), Convert.ToDateTime(Consulta(16).ToString), objCliente))
                End If
            End While

            Consulta.Close()
            BD.Desconectar(BDConexion)

            Return (ArrayProductosCliente)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (ArrayProductosCliente)
        End Try

    End Function

End Module
