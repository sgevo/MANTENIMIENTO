Imports System.Data.OleDb

Module BDTareas

    Dim RecordV As OleDbCommand
    Dim ConsultaV As OleDbDataReader

    Function ObtenerTareasActivas(idTecnico As Long) As ArrayList

        Dim ArrayTareas As New ArrayList() 'si no le pongo New se le va la pinza
        Dim Dato0 As Long
        Dim Dato1 As Long
        Dim Dato2 As Long
        Dim Dato4 As Long
        Dim Dato5 As Long

        Try
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            RecordV = New OleDbCommand("SELECT Id, IdMantenimiento, IdTecnicoGenerador, FechaCreacion, IdTecnico, IdCliente, Descripcion, Estado FROM Tareas Where IdTecnico = " & idTecnico & " AND Estado='ABIERTA' ORDER BY FechaCreacion;", BDConexion)
            'RecordV.ExecuteNonQuery() 'Esto lo que hace es contar cuantos hay

            ConsultaV = RecordV.ExecuteReader()

            While ConsultaV.Read()
                'Tengo que controlar si los campos numéricos son nulos
                If IsDBNull(ConsultaV(0).ToString) Then
                    Dato0 = 0
                Else
                    If IsNumeric(ConsultaV(0).ToString) Then
                        Dato0 = Convert.ToInt32(ConsultaV(0).ToString)
                    Else
                        Dato0 = 0
                    End If
                End If
                If IsDBNull(ConsultaV(1).ToString) Then
                    Dato1 = 0
                Else
                    If IsNumeric(ConsultaV(1).ToString) Then
                        Dato1 = Convert.ToInt32(ConsultaV(1).ToString)
                    Else
                        Dato1 = 0
                    End If
                End If
                If IsDBNull(ConsultaV(2).ToString) Then
                    Dato2 = 0
                Else
                    If IsNumeric(ConsultaV(2).ToString) Then
                        Dato2 = Convert.ToInt32(ConsultaV(2).ToString)
                    Else
                        Dato2 = 0
                    End If
                End If
                If IsDBNull(ConsultaV(4).ToString) Then
                    Dato4 = 0
                Else
                    If IsNumeric(ConsultaV(4).ToString) Then
                        Dato4 = Convert.ToInt32(ConsultaV(4).ToString)
                    Else
                        Dato4 = 0
                    End If
                End If

                If IsDBNull(ConsultaV(5).ToString) Then
                    Dato5 = 0
                Else
                    If IsNumeric(ConsultaV(5).ToString) Then
                        Dato5 = Convert.ToInt32(ConsultaV(5).ToString)
                    Else
                        Dato5 = 0
                    End If
                End If
                ArrayTareas.Add(New Tarea(Dato0, Dato1, Dato2, Convert.ToDateTime(ConsultaV(3).ToString), Dato4, dato5, ConsultaV(6).ToString, ConsultaV(7).ToString))
            End While

            ConsultaV.Close()
            BD.Desconectar(BDConexion)

            Return (ArrayTareas)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (ArrayTareas)
        End Try

    End Function

    Function GuardarTarea(objTarea As Tarea) As Tarea

        Dim BDConexion As OleDbConnection
        BDConexion = BD.Conectar()

        Dim query As String = "INSERT INTO Tareas (IdMantenimiento, IdTecnicoGenerador, FechaCreacion, IdCliente, IdTecnico, Descripcion, Estado) values (@Mante, @IdTecnicoG, @Fecha, @IdCliente, @IdTecnico, @Descripcion, @Estado);"

        Using cmd As New OleDbCommand(query, BDConexion)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query

            cmd.Parameters.AddWithValue("@Mante", SqlDbType.VarChar).Value = objTarea.IdMantenimiento1
            cmd.Parameters.AddWithValue("@IdTecnicoG", SqlDbType.Int).Value = objTarea.IdTecnicoGenerador1
            cmd.Parameters.AddWithValue("@Fecha", SqlDbType.DateTime).Value = Format(objTarea.FechaCreacion1, "MM/dd/yyyy HH:mm:ss")
            cmd.Parameters.AddWithValue("@IdCliente", SqlDbType.Int).Value = objTarea.IdCliente1
            cmd.Parameters.AddWithValue("@IdTecnico", SqlDbType.VarChar).Value = objTarea.IdTecnico1
            cmd.Parameters.AddWithValue("@Descripcion", SqlDbType.VarChar).Value = objTarea.Descripcion1
            cmd.Parameters.AddWithValue("@Estado", SqlDbType.VarChar).Value = "ABIERTA"
            'cmd.Parameters.AddWithValue("@FechaFin", SqlDbType.Int).Value = ""

            Try
                cmd.ExecuteNonQuery()

                Dim query2 As String = "Select @@Identity"

                cmd.CommandText = query2

                objTarea.Id1 = CLng(cmd.ExecuteScalar())
                BD.Desconectar(BDConexion)

                Return objTarea
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString(), "Error Tareas")
                Return objTarea
            End Try

        End Using

    End Function

    Sub ModificarTarea(objTarea As Tarea)

        Dim BDConexion As OleDbConnection
        BDConexion = BD.Conectar()

        Dim query As String = "UPDATE Tareas Set IdMantenimiento = @p1, IdTecnicoGenerador = @p2, FechaCreacion = @p3, IdCliente = @p4, IdTecnico = @p5, Descripcion = @p6, Estado = @p7, FechaTerminacion = @p8 WHERE (Id=" & objTarea.Id1 & ");"

        Using cmd As New OleDbCommand(query, BDConexion)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query

            cmd.Parameters.AddWithValue("@p1", SqlDbType.Int).Value = objTarea.IdMantenimiento1
            cmd.Parameters.AddWithValue("@p2", SqlDbType.Int).Value = objTarea.IdTecnicoGenerador1
            cmd.Parameters.AddWithValue("@p3", SqlDbType.DateTime).Value = Format(objTarea.FechaCreacion1, "MM/dd/yyyy HH:mm:ss")
            cmd.Parameters.AddWithValue("@p4", SqlDbType.Int).Value = objTarea.IdCliente1
            cmd.Parameters.AddWithValue("@p5", SqlDbType.Int).Value = objTarea.IdTecnico1
            If Not IsNothing(objTarea.Descripcion1) Then
                cmd.Parameters.AddWithValue("@p6", SqlDbType.VarChar).Value = objTarea.Descripcion1
            Else
                cmd.Parameters.AddWithValue("@p6", SqlDbType.VarChar).Value = ""
            End If
            If Not IsNothing(objTarea.Estado1) Then
                cmd.Parameters.AddWithValue("@p7", SqlDbType.VarChar).Value = objTarea.Estado1
            Else
                cmd.Parameters.AddWithValue("@p7", SqlDbType.VarChar).Value = ""
            End If
            cmd.Parameters.AddWithValue("@p8", SqlDbType.DateTime).Value = Format(objTarea.FechaTerminacion1, "MM/dd/yyyy HH:mm:ss")

            Try
                cmd.ExecuteNonQuery()

                BD.Desconectar(BDConexion)
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString(), "Error Tareas")
            End Try

        End Using

    End Sub

End Module
