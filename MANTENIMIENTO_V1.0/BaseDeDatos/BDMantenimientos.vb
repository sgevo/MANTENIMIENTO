Imports System.Data.OleDb
Imports System.Data.Odbc


Module BDMantenimientos


    Dim RecordV As OleDbCommand
    Dim ConsultaV As OleDbDataReader
    Dim RecordO As OdbcCommand
    Dim ConsultaO As OdbcDataReader

    Function ObtenerMantenimientos(idCliente As Long) As ArrayList

        Dim ArrayMantenimientos As New ArrayList() 'si no le pongo New se le va la pinza
        Dim Dato3 As Long
        Dim Dato8 As Long

        Try
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            RecordV = New OleDbCommand("SELECT Id, IdCliente, Fecha, IdTecnico, Medio, Tipo, Tema, Producto, IdTrabajo, Subtrabajo, Donde, IdTecnicoAsignar, Realizado, Sugerido FROM Mantenimientos Where IdCliente = " & idCliente & " ORDER BY Fecha, Producto;", BDConexion)
            'RecordV.ExecuteNonQuery() 'Esto lo que hace es contar cuantos hay

            ConsultaV = RecordV.ExecuteReader(CommandBehavior.SingleResult)

            While ConsultaV.Read()
                'Tengo que controlar si los campos numéricos son nulos
                If IsDBNull(ConsultaV(3).ToString) Then
                    Dato3 = 0
                Else
                    If IsNumeric(ConsultaV(3).ToString) Then
                        Dato3 = Convert.ToInt32(ConsultaV(3).ToString)
                    Else
                        Dato3 = 0
                    End If
                End If
                If IsDBNull(ConsultaV(8).ToString) Then
                    Dato8 = 0
                Else
                    If IsNumeric(ConsultaV(8).ToString) Then
                        Dato8 = Convert.ToInt32(ConsultaV(8).ToString)
                    Else
                        Dato8 = 0
                    End If
                End If
                ArrayMantenimientos.Add(New Mantenimiento(Convert.ToInt32(ConsultaV(0).ToString), Convert.ToInt32(ConsultaV(1).ToString), Convert.ToDateTime(ConsultaV(2).ToString), Dato3, ConsultaV(4).ToString, ConsultaV(5).ToString, ConsultaV(6).ToString, ConsultaV(7).ToString, Dato8, ConsultaV(9).ToString, ConsultaV(10).ToString, Convert.ToInt32(ConsultaV(11).ToString), ConsultaV(12).ToString, ConsultaV(13).ToString))
            End While

            ConsultaV.Close()
            BD.Desconectar(BDConexion)

            Return (ArrayMantenimientos)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (ArrayMantenimientos)
        End Try

    End Function

    Function GuardarMantenimiento(objMantenimiento As Mantenimiento) As Mantenimiento

        Dim BDConexion As OleDbConnection
        BDConexion = BD.Conectar()

        Dim query As String = "INSERT INTO Mantenimientos (IdCliente, Fecha, IdTecnico, Medio, Tipo, Tema, Producto, IdTrabajo, Subtrabajo, Donde, IdTecnicoAsignar, Realizado, Sugerido) values (@IdCliente, @Fecha, @IdTecnico, @Medio, @Tipo, @Tema, @Producto, @IdTrabajo, @Subtrabajo, @Donde, @IdTecnicoAsignar, @Realizado, @Sugerido);"

        Using cmd As New OleDbCommand(query, BDConexion)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query

            cmd.Parameters.AddWithValue("@IdCliente", SqlDbType.Int).Value = objMantenimiento.Id_Cliente1
            cmd.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = Format(objMantenimiento.Fecha1, "MM/dd/yyyy hh:mm:ss")
            cmd.Parameters.AddWithValue("@IdTecnico", SqlDbType.Int).Value = objMantenimiento.Id_Tecnico1
            cmd.Parameters.AddWithValue("@Medio", SqlDbType.VarChar).Value = objMantenimiento.Medio1
            cmd.Parameters.AddWithValue("@Tipo", SqlDbType.VarChar).Value = objMantenimiento.Tipo1
            cmd.Parameters.AddWithValue("@Tema", SqlDbType.VarChar).Value = objMantenimiento.Tema1
            cmd.Parameters.AddWithValue("@Producto", SqlDbType.VarChar).Value = objMantenimiento.Producto1
            cmd.Parameters.AddWithValue("@IdTrabajo", SqlDbType.Int).Value = objMantenimiento.Id_Trabajo1
            cmd.Parameters.AddWithValue("@Subtrabajo", SqlDbType.VarChar).Value = objMantenimiento.Subtrabajo1
            cmd.Parameters.AddWithValue("@Donde", SqlDbType.VarChar).Value = objMantenimiento.Donde1
            cmd.Parameters.AddWithValue("@IdTecnicoAsignar", SqlDbType.Int).Value = objMantenimiento.Id_Tecnico_Asignar1
            cmd.Parameters.AddWithValue("@Realizado", SqlDbType.VarChar).Value = objMantenimiento.Realizado1
            cmd.Parameters.AddWithValue("@Sugerido", SqlDbType.VarChar).Value = objMantenimiento.Sugerido1

            Try
                cmd.ExecuteNonQuery()

                Dim query2 As String = "Select @@Identity"

                cmd.CommandText = query2

                objMantenimiento.Id1 = CLng(cmd.ExecuteScalar())
                BD.Desconectar(BDConexion)

                Return objMantenimiento
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString(), "Error Mantenimientos")
                Return objMantenimiento
            End Try

        End Using

    End Function

    Sub ModificarMantenimiento(objMantenimiento As Mantenimiento)

        Dim BDConexion As OleDbConnection
        BDConexion = BD.Conectar()

        Dim query As String = "UPDATE Mantenimientos Set IdCliente = @p1, Fecha = @p2, IdTecnico = @p3, Medio = @p4, Tipo = @p5, Tema = @p6, Producto = @p7, IdTrabajo = @p8, Subtrabajo = @p9, Donde = @p10, IdTecnicoAsignar = @p11, Realizado = @p12, Sugerido = @p13 WHERE (Id=" & objMantenimiento.Id1 & ");"

        Using cmd As New OleDbCommand(query, BDConexion)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query

            cmd.Parameters.AddWithValue("@p1", SqlDbType.Int).Value = objMantenimiento.Id_Cliente1
            cmd.Parameters.AddWithValue("@p2", SqlDbType.DateTime).Value = Format(objMantenimiento.Fecha1, "MM/dd/yyyy HH:mm:ss")
            cmd.Parameters.AddWithValue("@p3", SqlDbType.Int).Value = objMantenimiento.Id_Tecnico1
            If Not IsNothing(objMantenimiento.Medio1) Then
                cmd.Parameters.AddWithValue("@p4", SqlDbType.VarChar).Value = objMantenimiento.Medio1
            Else
                cmd.Parameters.AddWithValue("@p4", SqlDbType.VarChar).Value = ""
            End If
            If Not IsNothing(objMantenimiento.Tipo1) Then
                cmd.Parameters.AddWithValue("@p5", SqlDbType.VarChar).Value = objMantenimiento.Tipo1
            Else
                cmd.Parameters.AddWithValue("@p5", SqlDbType.VarChar).Value = ""
            End If
            If Not IsNothing(objMantenimiento.Tema1) Then
                cmd.Parameters.AddWithValue("@p6", SqlDbType.VarChar).Value = objMantenimiento.Tema1
            Else
                cmd.Parameters.AddWithValue("@p6", SqlDbType.VarChar).Value = ""
            End If
            If Not IsNothing(objMantenimiento.Producto1) Then
                cmd.Parameters.AddWithValue("@p7", SqlDbType.VarChar).Value = objMantenimiento.Producto1
            Else
                cmd.Parameters.AddWithValue("@p7", SqlDbType.VarChar).Value = ""
            End If
            cmd.Parameters.AddWithValue("@p8", SqlDbType.Int).Value = objMantenimiento.Id_Trabajo1
            If Not IsNothing(objMantenimiento.Subtrabajo1) Then
                cmd.Parameters.AddWithValue("@p9", SqlDbType.VarChar).Value = objMantenimiento.Subtrabajo1
            Else
                cmd.Parameters.AddWithValue("@p9", SqlDbType.VarChar).Value = ""
            End If
            If Not IsNothing(objMantenimiento.Donde1) Then
                cmd.Parameters.AddWithValue("@p10", SqlDbType.VarChar).Value = objMantenimiento.Donde1
            Else
                cmd.Parameters.AddWithValue("@p10", SqlDbType.VarChar).Value = ""
            End If
            cmd.Parameters.AddWithValue("@p11", SqlDbType.Int).Value = objMantenimiento.Id_Tecnico_Asignar1
            If Not IsNothing(objMantenimiento.Realizado1) Then
                cmd.Parameters.AddWithValue("@p12", SqlDbType.VarChar).Value = objMantenimiento.Realizado1
            Else
                cmd.Parameters.AddWithValue("@p12", SqlDbType.VarChar).Value = ""
            End If
            If Not IsNothing(objMantenimiento.Sugerido1) Then
                cmd.Parameters.AddWithValue("@p13", SqlDbType.VarChar).Value = objMantenimiento.Sugerido1
            Else
                cmd.Parameters.AddWithValue("@p13", SqlDbType.VarChar).Value = ""
            End If

            Try
                cmd.ExecuteNonQuery()

                BD.Desconectar(BDConexion)
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString(), "Error Mantenimientos")
            End Try

        End Using

    End Sub

    Function SeleccionarMantenimientos(Texto As String) As ArrayList

        Dim ArrayMantenimientos As New ArrayList() 'si no le pongo New se le va la pinza
        Dim Dato3 As Long
        Dim Dato8 As Long
        Dim Sql As String

        Dim cuento As Long = 0

        Try
            'Debug.Print("BD01:" & Now)
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()


            If Len(Texto) > 0 Then
                'Sql = "Select Id, IdCliente, Fecha, IdTecnico, Medio, Tipo, Tema, Producto, IdTrabajo, Subtrabajo, Donde, IdTecnicoAsignar, Realizado, Sugerido FROM Mantenimientos Where " & Texto & "ORDER BY Fecha;"
                Sql = "Select Id, IdCliente, Fecha, IdTecnico, Medio, Tipo, Tema, Producto, IdTrabajo, Subtrabajo, Donde, IdTecnicoAsignar, Realizado, Sugerido FROM Mantenimientos Where " & Texto & ";"
            Else
                'Sql = "Select Id, IdCliente, Fecha, IdTecnico, Medio, Tipo, Tema, Producto, IdTrabajo, Subtrabajo, Donde, IdTecnicoAsignar, Realizado, Sugerido FROM Mantenimientos ORDER BY Fecha;"
                Sql = "Select Id, IdCliente, Fecha, IdTecnico, Medio, Tipo, Tema, Producto, IdTrabajo, Subtrabajo, Donde, IdTecnicoAsignar, Realizado, Sugerido FROM Mantenimientos;"

            End If
            'Debug.Print("BDMante:" & Sql)

            RecordV = New OleDbCommand(Sql, BDConexion)
            '   Debug.Print("BD001:" & Now)
            'RecordV.ExecuteNonQuery()

            ConsultaV = RecordV.ExecuteReader()
            '   Debug.Print("BD02:" & Now)

            While ConsultaV.Read()
                'Debug.Print("BD002:" & Now)
                'Tengo que controlar si los campos numéricos son nulos
                If IsDBNull(ConsultaV(3).ToString) Then
                    Dato3 = 0
                Else
                    If IsNumeric(ConsultaV(3).ToString) Then
                        Dato3 = Convert.ToInt32(ConsultaV(3).ToString)
                    Else
                        Dato3 = 0
                    End If
                End If
                If IsDBNull(ConsultaV(8).ToString) Then
                    Dato8 = 0
                Else
                    If IsNumeric(ConsultaV(8).ToString) Then
                        Dato8 = Convert.ToInt32(ConsultaV(8).ToString)
                    Else
                        Dato8 = 0
                    End If
                End If
                ArrayMantenimientos.Add(New Mantenimiento(Convert.ToInt32(ConsultaV(0).ToString), Convert.ToInt32(ConsultaV(1).ToString), Convert.ToDateTime(ConsultaV(2).ToString), Dato3, ConsultaV(4).ToString, ConsultaV(5).ToString, ConsultaV(6).ToString, ConsultaV(7).ToString, Dato8, ConsultaV(9).ToString, ConsultaV(10).ToString, Convert.ToInt32(ConsultaV(11).ToString), ConsultaV(12).ToString, ConsultaV(13).ToString))
                cuento = cuento + 1
            End While
            Debug.Print("BD03:" & Now & "---" & cuento)

            ConsultaV.Close()
            BD.Desconectar(BDConexion)

            Return (ArrayMantenimientos)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (ArrayMantenimientos)
        End Try

    End Function

    Function SeleccionarMantenimientosO(Texto As String) As ArrayList

        Dim ArrayMantenimientos As New ArrayList() 'si no le pongo New se le va la pinza
        Dim Dato3 As Double
        Dim Dato8 As Double
        Dim Sql As String

        Dim cuento As Long = 0


        Try
            Debug.Print("BDO 01:" & Now)
            'Dim BDConexion As OleDbConnection
            'BDConexion = BD.Conectar()

            Dim BDConexion As OdbcConnection
            BDConexion = BD.ConectarOdbc()
            If Len(Texto) > 0 Then
                'Tarda mucho la sentencia si tiene ORDER BY
                'Si le pones un LIKE y texto con %, practicamente igual
                '                Sql = "Select Id, IdCliente, Fecha, IdTecnico, Medio, Tipo, Tema, Producto, IdTrabajo, Subtrabajo, Donde, IdTecnicoAsignar, Realizado, Sugerido FROM Mantenimientos Where " & Texto & "ORDER BY Fecha;"
                Sql = "Select Id, IdCliente, Fecha, IdTecnico, Medio, Tipo, Tema, Producto, IdTrabajo, Subtrabajo, Donde, IdTecnicoAsignar, Realizado, Sugerido FROM Mantenimientos Where " & Texto & ";"
            Else
                Sql = "Select Id, IdCliente, Fecha, IdTecnico, Medio, Tipo, Tema, Producto, IdTrabajo, Subtrabajo, Donde, IdTecnicoAsignar, Realizado, Sugerido FROM Mantenimientos ORDER BY Fecha;"
            End If
            Debug.Print("BDMante:" & Sql)
            'RecordV = New OleDbCommand(Sql, BDConexion)
            RecordO = New OdbcCommand(Sql, BDConexion)
            'RecordV.ExecuteNonQuery()
            RecordO.ExecuteNonQuery()

            'ConsultaV = RecordV.ExecuteReader
            ConsultaO = RecordO.ExecuteReader
            Debug.Print("BDO 02:" & Now)

            While ConsultaO.Read()
                ''Tengo que controlar si los campos numéricos son nulos
                ''Esto no le cuesta nada de tiempo
                'If IsDBNull(ConsultaO(3).ToString) Then
                '    Dato3 = 0
                'Else
                '    If IsNumeric(ConsultaO(3).ToString) Then
                '        Dato3 = Convert.ToDouble(ConsultaO(3).ToString)
                '    Else
                '        Dato3 = 0
                '    End If
                'End If
                'If IsDBNull(ConsultaO(8).ToString) Then
                '    Dato8 = 0
                'Else
                '    If IsNumeric(ConsultaO(8).ToString) Then
                '        Dato8 = Convert.ToDouble(ConsultaO(8).ToString)
                '    Else
                '        Dato8 = 0
                '    End If
                'End If
                ''Aquí pierde mucho tiempo
                ''Los Convert.ToInt32() no influyen
                ''Aun quitando varios campos en ArrayMantenimientos, le cuesta casi lo mismo
                ''Realmente lo que cuesta tiempo es el bucle de lectura en sí, da igual que quite todo le cuesta 15 segundos con 500 registros

                'ArrayMantenimientos.Add(New Mantenimiento(Convert.ToInt32(ConsultaO(0).ToString), Convert.ToInt32(ConsultaO(1).ToString), Convert.ToDateTime(ConsultaO(2).ToString), Dato3, ConsultaO(4).ToString, ConsultaO(5).ToString, ConsultaO(6).ToString, ConsultaO(7).ToString, Dato8, ConsultaO(9).ToString, ConsultaO(10).ToString, Convert.ToInt32(ConsultaO(11).ToString), ConsultaO(12).ToString, ConsultaO(13).ToString))
                ''ArrayMantenimientos.Add(New Mantenimiento(Convert.ToInt32(ConsultaO(0).ToString)))
                cuento = cuento + 1
            End While
            Debug.Print("BDO 03:" & Now & "---" & cuento)

            ConsultaO.Close()
            'BD.Desconectar(BDConexion)

            BDConexion.Close()

            Return (ArrayMantenimientos)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (ArrayMantenimientos)
        End Try

    End Function

    Function SeleccionarMantenimientosX(Texto As String) As ArrayList

        'Ejemplo

        Dim RecordX As OdbcCommand
        Dim ConsultaX As OdbcDataReader

        Dim ArrayMantenimientos As New ArrayList() 'si no le pongo New se le va la pinza
        Dim Sql As String

        Dim cuento As Long = 0

        Try
            Debug.Print("SMX 01:" & Now)
            Dim BDConexion As OdbcConnection
            BDConexion = BD.ConectarOdbc()
            Sql = "Select Id, IdCliente, Fecha, IdTecnico, Medio, Tipo, Tema, Producto, IdTrabajo, Subtrabajo, Donde, IdTecnicoAsignar, Realizado, Sugerido FROM Mantenimientos Where " & Texto & ";"
            'Debug.Print("BDMante:" & Sql)
            RecordX = New OdbcCommand(Sql, BDConexion)
            RecordX.ExecuteNonQuery()

            ConsultaX = RecordX.ExecuteReader
            Debug.Print("SMX 02:" & Now)

            While ConsultaX.Read()
                cuento = cuento + 1
            End While
            Debug.Print("SMX 03:" & Now & "---" & cuento)

            ConsultaX.Close()

            BDConexion.Close()

            Return (ArrayMantenimientos)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (ArrayMantenimientos)
        End Try

    End Function

    Function SeleccionarMantenimientosA(Texto As String) As ArrayList

        Dim ArrayMantenimientos As New ArrayList() 'si no le pongo New se le va la pinza
        Dim Dato3 As Long
        Dim Dato8 As Long
        Dim Sql As String

        Dim cuento As Long = 0

        Try
            Debug.Print("BDA 01:" & Now)
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()

            Dim ds As New DataSet
            Dim dt As New DataTable
            ds.Tables.Add(dt)
            Dim da As New OleDbDataAdapter


            If Len(Texto) > 0 Then
                'Sql = "Select Id, IdCliente, Fecha, IdTecnico, Medio, Tipo, Tema, Producto, IdTrabajo, Subtrabajo, Donde, IdTecnicoAsignar, Realizado, Sugerido FROM Mantenimientos Where " & Texto & "ORDER BY Fecha;"
                Sql = "Select Id, IdCliente, Fecha, IdTecnico, Medio, Tipo, Tema, Producto, IdTrabajo, Subtrabajo, Donde, IdTecnicoAsignar, Realizado, Sugerido FROM Mantenimientos Where " & Texto & ";"
            Else
                'Sql = "Select Id, IdCliente, Fecha, IdTecnico, Medio, Tipo, Tema, Producto, IdTrabajo, Subtrabajo, Donde, IdTecnicoAsignar, Realizado, Sugerido FROM Mantenimientos ORDER BY Fecha;"
                Sql = "Select Id, IdCliente, Fecha, IdTecnico, Medio, Tipo, Tema, Producto, IdTrabajo, Subtrabajo, Donde, IdTecnicoAsignar, Realizado, Sugerido FROM Mantenimientos;"

            End If
            'Debug.Print("BDMante:" & Sql)

            'RecordV = New OleDbCommand(Sql, BDConexion)

            da = New OleDbDataAdapter(Sql, BDConexion)
            Debug.Print("BDA 001:" & Now)

            da.Fill(dt)

            'RecordV.ExecuteNonQuery()

            'ConsultaV = RecordV.ExecuteReader()
            Debug.Print("BDA 02:" & Now)
            Dim x As Long

            For x = 0 To dt.Rows.Count - 1
                'Debug.Print("BDA 002:" & Now)
                'While ConsultaV.Read()
                'Tengo que controlar si los campos numéricos son nulos
                If IsDBNull(dt.Rows(x).Item(3).ToString) Then
                    Dato3 = 0
                Else
                    If IsNumeric(dt.Rows(x).Item(3).ToString) Then
                        Dato3 = Convert.ToInt32(dt.Rows(x).Item(3).ToString)
                    Else
                        Dato3 = 0
                    End If
                End If
                If IsDBNull(dt.Rows(x).Item(8).ToString) Then
                    Dato8 = 0
                Else
                    If IsNumeric(dt.Rows(x).Item(8).ToString) Then
                        Dato8 = Convert.ToInt32(dt.Rows(x).Item(8).ToString)
                    Else
                        Dato8 = 0
                    End If
                End If
                ArrayMantenimientos.Add(New Mantenimiento(Convert.ToInt32(dt.Rows(x).Item(0).ToString), Convert.ToInt32(dt.Rows(x).Item(1).ToString), Convert.ToDateTime(dt.Rows(x).Item(2).ToString), Dato3, dt.Rows(x).Item(4).ToString, dt.Rows(x).Item(5).ToString, dt.Rows(x).Item(6).ToString, dt.Rows(x).Item(7).ToString, Dato8, dt.Rows(x).Item(9).ToString, dt.Rows(x).Item(10).ToString, Convert.ToInt32(dt.Rows(x).Item(11).ToString), dt.Rows(x).Item(12).ToString, dt.Rows(x).Item(13).ToString))
                cuento = cuento + 1
                'End While
            Next
            Debug.Print("BDA 03:" & Now & "---" & cuento)

            'ConsultaV.Close()
            BD.Desconectar(BDConexion)

            Return (ArrayMantenimientos)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (ArrayMantenimientos)
        End Try

    End Function
End Module
