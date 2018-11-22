Imports System.Data.OleDb

Module BDVersiones
    Dim RecordV As OleDbCommand
    Dim ConsultaV As OleDbDataReader

    Function ObtenerTodasVersiones() As ArrayList
        ' Dim objVersiones As Version
        Dim ArrayVersiones As New ArrayList() 'si no le pongo New se le va la pinza
        Dim Dato4 As Double
        Dim Dato5 As Double

        Try
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            RecordV = New OleDbCommand("SELECT IdVersiones, Version, Orden, Ultima, Precio, PrecioRed, IdProductos FROM Versiones ORDER BY Orden;", BDConexion)
            RecordV.ExecuteNonQuery()

            ConsultaV = RecordV.ExecuteReader

            While ConsultaV.Read()
                'Tengo que controlar si los campos numéricos son nulos
                If IsDBNull(ConsultaV(4).ToString) Then
                    Dato4 = 0
                Else
                    If IsNumeric(ConsultaV(4).ToString) Then
                        Dato4 = Convert.ToDouble(ConsultaV(4).ToString)
                    Else
                        Dato4 = 0
                    End If
                End If
                If IsDBNull(ConsultaV(5).ToString) Then
                    Dato5 = 0
                Else
                    If IsNumeric(ConsultaV(5).ToString) Then
                        Dato5 = Convert.ToDouble(ConsultaV(5).ToString)
                    Else
                        Dato5 = 0
                    End If
                End If
                ArrayVersiones.Add(New Version(Convert.ToInt32(ConsultaV(0).ToString), ConsultaV(1).ToString, Convert.ToInt32(ConsultaV(2).ToString), Convert.ToBoolean(ConsultaV(3).ToString), Dato4, Dato5))

            End While

            ConsultaV.Close()
            BD.Desconectar(BDConexion)

            Return (ArrayVersiones)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (ArrayVersiones)
        End Try

    End Function

    Function ObtenerVersiones(IdProducto As Long) As ArrayList
        ' Dim objVersiones As Version
        Dim ArrayVersiones As New ArrayList() 'si no le pongo New se le va la pinza
        Dim Dato4 As Double
        Dim Dato5 As Double

        Try
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            RecordV = New OleDbCommand("SELECT IdVersiones, Version, Orden, Ultima, Precio, PrecioRed, IdProductos FROM Versiones WHERE IdProductos=" & IdProducto & " ORDER BY Orden;", BDConexion)
            RecordV.ExecuteNonQuery()

            ConsultaV = RecordV.ExecuteReader

            While ConsultaV.Read()
                'Tengo que controlar si los campos numéricos son nulos
                If IsDBNull(ConsultaV(4).ToString) Then
                    Dato4 = 0
                Else
                    If IsNumeric(ConsultaV(4).ToString) Then
                        Dato4 = Convert.ToDouble(ConsultaV(4).ToString)
                    Else
                        Dato4 = 0
                    End If
                End If
                If IsDBNull(ConsultaV(5).ToString) Then
                    Dato5 = 0
                Else
                    If IsNumeric(ConsultaV(5).ToString) Then
                        Dato5 = Convert.ToDouble(ConsultaV(5).ToString)
                    Else
                        Dato5 = 0
                    End If
                End If
                ArrayVersiones.Add(New Version(Convert.ToInt32(ConsultaV(0).ToString), ConsultaV(1).ToString, Convert.ToInt32(ConsultaV(2).ToString), Convert.ToBoolean(ConsultaV(3).ToString), Dato4, Dato5))

            End While

            ConsultaV.Close()
            BD.Desconectar(BDConexion)

            Return (ArrayVersiones)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (ArrayVersiones)
        End Try

    End Function

    Function ObtenerUnaVersion(IdVersion As Long) As Version
        Dim objVersiones As Version
        Dim ArrayVersiones As New ArrayList() 'si no le pongo New se le va la pinza
        Dim Dato4 As Double
        Dim Dato5 As Double

        Try
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            RecordV = New OleDbCommand("SELECT IdVersiones, Version, Orden, Ultima, Precio, PrecioRed, IdProductos FROM Versiones WHERE IdVersiones=" & IdVersion & " ORDER BY Orden;", BDConexion)
            RecordV.ExecuteNonQuery()

            ConsultaV = RecordV.ExecuteReader

            While ConsultaV.Read()
                'Tengo que controlar si los campos numéricos son nulos
                If IsDBNull(ConsultaV(4).ToString) Then
                    Dato4 = 0
                Else
                    If IsNumeric(ConsultaV(4).ToString) Then
                        Dato4 = Convert.ToDouble(ConsultaV(4).ToString)
                    Else
                        Dato4 = 0
                    End If
                End If
                If IsDBNull(ConsultaV(5).ToString) Then
                    Dato5 = 0
                Else
                    If IsNumeric(ConsultaV(5).ToString) Then
                        Dato5 = Convert.ToDouble(ConsultaV(5).ToString)
                    Else
                        Dato5 = 0
                    End If
                End If
                objVersiones = New Version(Convert.ToInt32(ConsultaV(0).ToString), ConsultaV(1).ToString, Convert.ToInt32(ConsultaV(2).ToString), Convert.ToBoolean(ConsultaV(3).ToString), Dato4, Dato5)

            End While

            ConsultaV.Close()
            BD.Desconectar(BDConexion)

            Return (objVersiones)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (objVersiones)
        End Try

    End Function

    Function GuardarVersion(objVersion As Version) As Version

        Dim BDConexion As OleDbConnection
        BDConexion = BD.Conectar()

        Dim query As String = "INSERT INTO Versiones (Version, Orden, Ultima, Precio, PrecioRed, IdProductos) values (@Version, @Ultima, @Orden,@Precio, @PrecioRed, @IdProduc);"

        Using cmd As New OleDbCommand(query, BDConexion)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query

            cmd.Parameters.AddWithValue("@Version", SqlDbType.VarChar).Value = objVersion.Version1
            cmd.Parameters.AddWithValue("@Orden", SqlDbType.Int).Value = objVersion.Orden1
            cmd.Parameters.AddWithValue("@Ultima", SqlDbType.TinyInt).Value = objVersion.Ultima1
            cmd.Parameters.AddWithValue("@Precio", SqlDbType.Decimal).Value = objVersion.Precio1
            cmd.Parameters.AddWithValue("@PrecioRed", SqlDbType.Decimal).Value = objVersion.PrecioRed1
            cmd.Parameters.AddWithValue("@IdProduc", SqlDbType.Int).Value = objVersion.ObjProducto1.Id1

            Try
                cmd.ExecuteNonQuery()

                Dim query2 As String = "Select @@Identity"

                cmd.CommandText = query2

                objVersion.Id1 = cmd.ExecuteScalar()
                BD.Desconectar(BDConexion)

                Return objVersion
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString(), "Error Versiones")
                Return objVersion
            End Try

        End Using

    End Function

    Sub ModificarVersion(objVersion As Version)

        Dim BDConexion As OleDbConnection
        BDConexion = BD.Conectar()

        Dim query As String = "UPDATE Versiones Set Version = @p1, Orden = @p2, Ultima = @p3, Precio = @p4, PrecioRed = @p5 WHERE (IdVersiones=" & objVersion.Id1 & ");"

        Using cmd As New OleDbCommand(query, BDConexion)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query

            cmd.Parameters.AddWithValue("@p1", SqlDbType.VarChar).Value = objVersion.Version1
            cmd.Parameters.AddWithValue("@p2", SqlDbType.Decimal).Value = objVersion.Orden1
            cmd.Parameters.AddWithValue("@p3", SqlDbType.TinyInt).Value = objVersion.Ultima1
            cmd.Parameters.AddWithValue("@p4", SqlDbType.Decimal).Value = objVersion.Precio1
            cmd.Parameters.AddWithValue("@p5", SqlDbType.Decimal).Value = objVersion.PrecioRed1

            Try
                cmd.ExecuteNonQuery()

                BD.Desconectar(BDConexion)
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString(), "Error Versiones")
            End Try

        End Using

    End Sub

    Sub EliminarVersion(objVersion As Version)

        Dim BDConexion As OleDbConnection
        BDConexion = BD.Conectar()

        Dim query As String = " DELETE * FROM Versiones WHERE (IdVersiones=" & objVersion.Id1 & ");"

        Using cmd As New OleDbCommand(query, BDConexion)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query

            Try
                cmd.ExecuteNonQuery()

                BD.Desconectar(BDConexion)
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString(), "Error Versiones")
            End Try

        End Using

    End Sub

    Function ComprobarRepetidoVersion(Version As String, Producto As Long) As Boolean

        Dim Existe As Boolean
        Dim BDConexion As OleDbConnection
        Dim ConsultaV As OleDbDataReader

        Try

            BDConexion = BD.Conectar()

            Existe = False

            RecordV = New OleDbCommand("Select IdVersiones, Version, IdProductos FROM Versiones WHERE (Version='" & Version & "' AND IdProductos=" & Producto & ");", BDConexion)

            RecordV.ExecuteNonQuery()

            ConsultaV = RecordV.ExecuteReader

            While ConsultaV.Read()
                Existe = True
            End While

            Return Existe

            BD.Desconectar(BDConexion)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error Versiones")
        End Try

    End Function

End Module
