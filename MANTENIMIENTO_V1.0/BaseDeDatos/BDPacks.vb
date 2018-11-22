Imports System.Data.OleDb

Module BDPacks
    Dim RecordV As OleDbCommand
    Dim ConsultaV As OleDbDataReader

    Function ObtenerPacks() As ArrayList
        ' Dim objVersiones As Pack
        Dim ArrayPacks As New ArrayList() 'si no le pongo New se le va la pinza
        Dim Dato2 As Double

        Try
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            RecordV = New OleDbCommand("SELECT IdPacks, Descripcion, Precio, IdProducto1, Red1, Mante1, Actualizar1, IdProducto2, Red2, Mante2, Actualizar2 FROM Packs ORDER BY Descripcion;", BDConexion)
            RecordV.ExecuteNonQuery()

            ConsultaV = RecordV.ExecuteReader

            While ConsultaV.Read()
                'Tengo que controlar si los campos numéricos son nulos
                If IsDBNull(ConsultaV(2).ToString) Then
                    Dato2 = 0
                Else
                    If IsNumeric(ConsultaV(2).ToString) Then
                        Dato2 = Convert.ToDouble(ConsultaV(2).ToString)
                    Else
                        Dato2 = 0
                    End If
                End If

                'If ConsultaV(7).ToString = "" Then
                'ArrayPacks.Add(New Pack(Convert.ToInt32(ConsultaV(0).ToString), ConsultaV(1).ToString, Dato2, Convert.ToBoolean(ConsultaV(4).ToString), Convert.ToBoolean(ConsultaV(5).ToString), Convert.ToBoolean(ConsultaV(6).ToString), ObtenerUnProducto(Convert.ToInt32(ConsultaV(3).ToString))))
                'Else
                'ArrayPacks.Add(New Pack(Convert.ToInt32(ConsultaV(0).ToString), ConsultaV(1).ToString, Dato2, Convert.ToBoolean(ConsultaV(4).ToString), Convert.ToBoolean(ConsultaV(5).ToString), Convert.ToBoolean(ConsultaV(6).ToString), Convert.ToBoolean(ConsultaV(8).ToString), Convert.ToBoolean(ConsultaV(9).ToString), Convert.ToBoolean(ConsultaV(10).ToString), ObtenerUnProducto(Convert.ToInt32(ConsultaV(3).ToString)), ObtenerUnProducto(Convert.ToInt32(ConsultaV(7).ToString))))
                ArrayPacks.Add(New Pack(Convert.ToInt32(ConsultaV(0).ToString), ConsultaV(1).ToString, Dato2, Convert.ToBoolean(ConsultaV(4).ToString), Convert.ToBoolean(ConsultaV(5).ToString), Convert.ToBoolean(ConsultaV(6).ToString), Convert.ToBoolean(ConsultaV(8).ToString), Convert.ToBoolean(ConsultaV(9).ToString), Convert.ToBoolean(ConsultaV(10).ToString), ((ConsultaV(3).ToString)), ((ConsultaV(7).ToString))))
                'End If
            End While

            ConsultaV.Close()
            BD.Desconectar(BDConexion)

            Return (ArrayPacks)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (ArrayPacks)
        End Try

    End Function

    Function ObtenerUnPack(idPack As Long) As Pack
        Dim objPack As Pack
        Dim ArrayPacks As New ArrayList() 'si no le pongo New se le va la pinza
        Dim Dato2 As Double

        Try
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            RecordV = New OleDbCommand("SELECT IdPacks, Descripcion, Precio, IdProducto1, Red1, Mante1, Actualizar1, IdProducto2, Red2, Mante2, Actualizar2 FROM Packs Where IdPacks = " & idPack & " ORDER BY Descripcion;", BDConexion)
            RecordV.ExecuteNonQuery()

            ConsultaV = RecordV.ExecuteReader

            While ConsultaV.Read()
                'Tengo que controlar si los campos numéricos son nulos
                If IsDBNull(ConsultaV(2).ToString) Then
                    Dato2 = 0
                Else
                    If IsNumeric(ConsultaV(2).ToString) Then
                        Dato2 = Convert.ToDouble(ConsultaV(2).ToString)
                    Else
                        Dato2 = 0
                    End If
                End If

                objPack = New Pack(Convert.ToInt32(ConsultaV(0).ToString), ConsultaV(1).ToString, Dato2, Convert.ToBoolean(ConsultaV(4).ToString), Convert.ToBoolean(ConsultaV(5).ToString), Convert.ToBoolean(ConsultaV(6).ToString), Convert.ToBoolean(ConsultaV(8).ToString), Convert.ToBoolean(ConsultaV(9).ToString), Convert.ToBoolean(ConsultaV(10).ToString), ((ConsultaV(3).ToString)), ((ConsultaV(7).ToString)))
            End While

            ConsultaV.Close()
            BD.Desconectar(BDConexion)

            Return (objPack)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (objPack)
        End Try

    End Function

    Function GuardarPack(objPack As Pack) As Pack

        Dim BDConexion As OleDbConnection
        BDConexion = BD.Conectar()

        Dim query As String = "INSERT INTO Packs (Descripcion, Precio, IdProducto1, Red1, Mante1, Actualizar1, IdProducto2, Red2, Mante2, Actualizar2) values (@Descripcion, @Precio, @IdProducto1,@Red1, @Mante1, @Actualizar1, @IdProducto2,@Red2, @Mante2, @Actualizar2);"

        Using cmd As New OleDbCommand(query, BDConexion)

            Try
                cmd.CommandType = CommandType.Text
                cmd.CommandText = query

                cmd.Parameters.AddWithValue("@Descripcion", SqlDbType.VarChar).Value = objPack.Descripcion1
                cmd.Parameters.AddWithValue("@Precio", SqlDbType.Int).Value = objPack.Precio1
                cmd.Parameters.AddWithValue("@IdProducto1", SqlDbType.Int).Value = objPack.objProducto11.Id1
                cmd.Parameters.AddWithValue("@Red1", SqlDbType.TinyInt).Value = objPack.Red11
                cmd.Parameters.AddWithValue("@Mante1", SqlDbType.TinyInt).Value = objPack.Mante11
                cmd.Parameters.AddWithValue("@Actualizar1", SqlDbType.TinyInt).Value = objPack.Actualizar11
                cmd.Parameters.AddWithValue("@IdProducto2", SqlDbType.Int).Value = objPack.objProducto21.Id1
                cmd.Parameters.AddWithValue("@Red2", SqlDbType.TinyInt).Value = objPack.Red21
                cmd.Parameters.AddWithValue("@Mante2", SqlDbType.TinyInt).Value = objPack.Mante21
                cmd.Parameters.AddWithValue("@Actualizar2", SqlDbType.TinyInt).Value = objPack.Actualizar21

                cmd.ExecuteNonQuery()

                Dim query2 As String = "Select @@Identity"

                cmd.CommandText = query2

                objPack.Id1 = cmd.ExecuteScalar()
                BD.Desconectar(BDConexion)

                Return objPack
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString(), "Error Packs")
                Return objPack
            End Try

        End Using

    End Function

    'Function GuardarPack1(objPack As Pack) As Pack

    '    Dim BDConexion As OleDbConnection
    '    BDConexion = BD.Conectar()

    '    Dim query As String = "INSERT INTO Packs (Descripcion, Precio, IdProducto1, Red1, Mante1, Actualizar1) values (@Descripcion, @Precio, @IdProducto1,@Red1, @Mante1, @Actualizar1);"

    '    Using cmd As New OleDbCommand(query, BDConexion)

    '        Try
    '            cmd.CommandType = CommandType.Text
    '            cmd.CommandText = query

    '            cmd.Parameters.AddWithValue("@Descripcion", SqlDbType.VarChar).Value = objPack.Descripcion1
    '            cmd.Parameters.AddWithValue("@Precio", SqlDbType.Int).Value = objPack.Precio1
    '            cmd.Parameters.AddWithValue("@IdProducto1", SqlDbType.Int).Value = objPack.objProducto11.Id1
    '            cmd.Parameters.AddWithValue("@Red1", SqlDbType.TinyInt).Value = objPack.Red11
    '            cmd.Parameters.AddWithValue("@Mante1", SqlDbType.TinyInt).Value = objPack.Mante11
    '            cmd.Parameters.AddWithValue("@Actualizar1", SqlDbType.TinyInt).Value = objPack.Actualizar11

    '            cmd.ExecuteNonQuery()

    '            Dim query2 As String = "Select @@Identity"

    '            cmd.CommandText = query2

    '            objPack.Id1 = cmd.ExecuteScalar()
    '            BD.Desconectar(BDConexion)

    '            Return objPack
    '        Catch ex As Exception
    '            MessageBox.Show(ex.Message.ToString(), "Error Packs")
    '            Return objPack
    '        End Try

    '    End Using

    'End Function

    Sub ModificarPack(objPack As Pack)

        Dim BDConexion As OleDbConnection
        BDConexion = BD.Conectar()

        Dim query As String = "UPDATE Packs Set Descripcion = @Descripcion, Precio = @Precio, IdProducto1 = @IdProducto1, Red1 = @Red1, Mante1 = @Mante1, Actualizar1 = @Actualizar1, IdProducto2 = @IdProducto2, Red2 = @Red2, Mante2 = @Mante2, Actualizar2 = @Actualizar2 WHERE (IdPacks=" & objPack.Id1 & ");"

        Using cmd As New OleDbCommand(query, BDConexion)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query

            cmd.Parameters.AddWithValue("@Descripcion", SqlDbType.VarChar).Value = objPack.Descripcion1
            cmd.Parameters.AddWithValue("@Precio", SqlDbType.Int).Value = objPack.Precio1
            cmd.Parameters.AddWithValue("@IdProducto1", SqlDbType.TinyInt).Value = objPack.objProducto11.Id1
            cmd.Parameters.AddWithValue("@Red1", SqlDbType.Decimal).Value = objPack.Red11
            cmd.Parameters.AddWithValue("@Mante1", SqlDbType.Decimal).Value = objPack.Mante11
            cmd.Parameters.AddWithValue("@Actualizar1", SqlDbType.Int).Value = objPack.Actualizar11
            cmd.Parameters.AddWithValue("@IdProducto2", SqlDbType.TinyInt).Value = objPack.objProducto21.Id1
            cmd.Parameters.AddWithValue("@Red2", SqlDbType.Decimal).Value = objPack.Red21
            cmd.Parameters.AddWithValue("@Mante2", SqlDbType.Decimal).Value = objPack.Mante21
            cmd.Parameters.AddWithValue("@Actualizar2", SqlDbType.Int).Value = objPack.Actualizar21

            Try
                cmd.ExecuteNonQuery()

                BD.Desconectar(BDConexion)
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString(), "Error Packs")
            End Try

        End Using

    End Sub

    Sub EliminarPack(objPack As Pack)

        Dim BDConexion As OleDbConnection
        BDConexion = BD.Conectar()

        Dim query As String = "DELETE * FROM Packs WHERE (IdPacks=" & objPack.Id1 & ");"

        Using cmd As New OleDbCommand(query, BDConexion)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query

            Try
                cmd.ExecuteNonQuery()

                BD.Desconectar(BDConexion)
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString(), "Error Packs")
            End Try

        End Using

    End Sub

    Function ComprobarRepetidoPack(Pack As String) As Boolean

        Dim Existe As Boolean
        Dim BDConexion As OleDbConnection
        Dim ConsultaV As OleDbDataReader

        Try
            BDConexion = BD.Conectar()

            Existe = False

            RecordV = New OleDbCommand("Select IdPacks, Descripcion FROM Packs WHERE (Descripcion='" & Pack & "');", BDConexion)

            RecordV.ExecuteNonQuery()

            ConsultaV = RecordV.ExecuteReader

            While ConsultaV.Read()
                Existe = True
            End While

            Return Existe

            BD.Desconectar(BDConexion)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error Packs")
        End Try

    End Function

End Module
