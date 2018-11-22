Imports System.Data.OleDb

Module BDProductos

    Dim record As OleDbCommand
    Dim Consulta As OleDbDataReader

    Function ObtenerProductos() As ArrayList
        Dim Dato8 As Double
        Dim Dato9 As Double
        Dim ArrayProductos As New ArrayList()

        Try
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            record = New OleDbCommand("SELECT IdProductos, Codigo, Descripcion, Tipo, Versiones, Mantenimiento, Red, Temporal, Precio, PrecioRed FROM Productos;", BDConexion)
            record.ExecuteNonQuery()

            Consulta = record.ExecuteReader

            While Consulta.Read()
                'Tengo que controlar si los campos numéricos son nulos
                If IsDBNull(Consulta(8).ToString) Then
                    Dato8 = 0
                Else
                    If IsNumeric(Consulta(8).ToString) Then
                        Dato8 = Convert.ToDouble(Consulta(8).ToString)
                    Else
                        Dato8 = 0
                    End If
                End If
                If IsDBNull(Consulta(9).ToString) Then
                    Dato9 = 0
                Else
                    If IsNumeric(Consulta(9).ToString) Then
                        Dato9 = Convert.ToDouble(Consulta(9).ToString)
                    Else
                        Dato9 = 0
                    End If
                End If
                ArrayProductos.Add(New Producto(Convert.ToInt32(Consulta(0).ToString), Consulta(1).ToString, Consulta(2).ToString, Consulta(3).ToString, Convert.ToBoolean(Consulta(4).ToString), Convert.ToBoolean(Consulta(5).ToString), Convert.ToBoolean(Consulta(6).ToString), Convert.ToBoolean(Consulta(7).ToString), Convert.ToDouble(Dato8), Convert.ToDouble(Dato9)))
            End While

            Consulta.Close()
            BD.Desconectar(BDConexion)

            Return (ArrayProductos)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (ArrayProductos)
        End Try

    End Function

    Function ObtenerProductosTipo(tipo As Long) As ArrayList
        Dim Dato8 As Double
        Dim Dato9 As Double
        Dim ArrayProductos As New ArrayList()
        'tipo=0 productos, 1=servicios, 2=mantenimientos
        Try
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            record = New OleDbCommand("SELECT IdProductos, Codigo, Descripcion, Tipo, Versiones, Mantenimiento, Red, Temporal, Precio, PrecioRed FROM Productos WHERE Tipo='" & tipo & "';", BDConexion)
            record.ExecuteNonQuery()

            Consulta = record.ExecuteReader

            While Consulta.Read()
                'Tengo que controlar si los campos numéricos son nulos
                If IsDBNull(Consulta(8).ToString) Then
                    Dato8 = 0
                Else
                    If IsNumeric(Consulta(8).ToString) Then
                        Dato8 = Convert.ToDouble(Consulta(8).ToString)
                    Else
                        Dato8 = 0
                    End If
                End If
                If IsDBNull(Consulta(9).ToString) Then
                    Dato9 = 0
                Else
                    If IsNumeric(Consulta(9).ToString) Then
                        Dato9 = Convert.ToDouble(Consulta(9).ToString)
                    Else
                        Dato9 = 0
                    End If
                End If
                ArrayProductos.Add(New Producto(Convert.ToInt32(Consulta(0).ToString), Consulta(1).ToString, Consulta(2).ToString, Consulta(3).ToString, Convert.ToBoolean(Consulta(4).ToString), Convert.ToBoolean(Consulta(5).ToString), Convert.ToBoolean(Consulta(6).ToString), Convert.ToBoolean(Consulta(7).ToString), Convert.ToDouble(Dato8), Convert.ToDouble(Dato9)))
            End While

            Consulta.Close()
            BD.Desconectar(BDConexion)

            Return (ArrayProductos)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (ArrayProductos)
        End Try

    End Function

    Function ObtenerUnProducto(idProducto As Long) As Producto
        Dim Dato8 As Double
        Dim Dato9 As Double
        Dim objProducto As Producto

        Try
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            record = New OleDbCommand("SELECT IdProductos, Codigo, Descripcion, Tipo, Versiones, Mantenimiento, Red, Temporal, Precio, PrecioRed FROM Productos Where idProductos = " & idProducto & ";", BDConexion)
            record.ExecuteNonQuery()

            Consulta = record.ExecuteReader

            While Consulta.Read()
                'Tengo que controlar si los campos numéricos son nulos
                If IsDBNull(Consulta(8).ToString) Then
                    Dato8 = 0
                Else
                    If IsNumeric(Consulta(8).ToString) Then
                        Dato8 = Convert.ToDouble(Consulta(8).ToString)
                    Else
                        Dato8 = 0
                    End If
                End If
                If IsDBNull(Consulta(9).ToString) Then
                    Dato9 = 0
                Else
                    If IsNumeric(Consulta(9).ToString) Then
                        Dato9 = Convert.ToDouble(Consulta(9).ToString)
                    Else
                        Dato9 = 0
                    End If
                End If
                objProducto = New Producto(Convert.ToInt32(Consulta(0).ToString), Consulta(1).ToString, Consulta(2).ToString, Consulta(3).ToString, Convert.ToBoolean(Consulta(4).ToString), Convert.ToBoolean(Consulta(5).ToString), Convert.ToBoolean(Consulta(6).ToString), Convert.ToBoolean(Consulta(7).ToString), Dato8, Dato9)
            End While

            Consulta.Close()
            BD.Desconectar(BDConexion)

            Return (objProducto)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (objProducto)
        End Try

    End Function

    Function GuardarProducto(objProducto As Producto) As Producto

        Dim BDConexion As OleDbConnection
        BDConexion = BD.Conectar()

        Dim query As String = " INSERT INTO Productos ( Codigo, Descripcion, Tipo, Versiones, Mantenimiento, Red, Temporal, Precio, PrecioRed ) values (@Codigo, @Descripcion, @Versiones, @Mantenimiento, @Red, @Temporal, @Precio, @PrecioRed);"

        Using cmd As New OleDbCommand(query, BDConexion)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query
            ''  cmd.Parameters.Add("@IdProvincia", SqlDbType.VarChar).Value = objProvincia.

            cmd.Parameters.AddWithValue("@Codigo", SqlDbType.VarChar).Value = objProducto.Codigo1
            cmd.Parameters.AddWithValue("@Descripciones", SqlDbType.VarChar).Value = objProducto.Descripcion1
            cmd.Parameters.AddWithValue("@Tipo", SqlDbType.VarChar).Value = objProducto.Tipo1
            cmd.Parameters.AddWithValue("@Versiones", SqlDbType.TinyInt).Value = objProducto.Versiones1
            cmd.Parameters.AddWithValue("@Mantenimiento", SqlDbType.TinyInt).Value = objProducto.Mantenimiento1
            cmd.Parameters.AddWithValue("@Red", SqlDbType.TinyInt).Value = objProducto.Red1
            cmd.Parameters.AddWithValue("@Temporal", SqlDbType.TinyInt).Value = objProducto.Temporal1
            cmd.Parameters.AddWithValue("@Precio", SqlDbType.Decimal).Value = objProducto.Precio1
            cmd.Parameters.AddWithValue("@PrecioRed", SqlDbType.Decimal).Value = objProducto.PrecioRed1

            Try
                cmd.ExecuteNonQuery()

                Dim query2 As String = "Select @@Identity"

                cmd.CommandText = query2

                objProducto.Id1 = cmd.ExecuteScalar()
                BD.Desconectar(BDConexion)

                Return objProducto
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString(), "Error Productos")
            End Try

        End Using

    End Function

    Sub ModificarProducto(objProducto As Producto)

        Dim BDConexion As OleDbConnection
        BDConexion = BD.Conectar()

        Dim query As String = " UPDATE Productos SET Codigo = @p1 , Descripcion = @p2, Tipo = @p3, Versiones = @p4, Mantenimiento = @p5, Red = @p6 , Temporal = @p7, Precio = @p8, PrecioRed = @p9 WHERE ((IdProductos=" & objProducto.Id1 & "));"

        Using cmd As New OleDbCommand(query, BDConexion)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query

            cmd.Parameters.AddWithValue("@p1", SqlDbType.VarChar).Value = objProducto.Codigo1
            cmd.Parameters.AddWithValue("@p2", SqlDbType.VarChar).Value = objProducto.Descripcion1
            cmd.Parameters.AddWithValue("@p3", SqlDbType.TinyInt).Value = objProducto.Tipo1
            cmd.Parameters.AddWithValue("@p4", SqlDbType.TinyInt).Value = objProducto.Versiones1
            cmd.Parameters.AddWithValue("@p5", SqlDbType.TinyInt).Value = objProducto.Mantenimiento1
            cmd.Parameters.AddWithValue("@p6", SqlDbType.TinyInt).Value = objProducto.Red1
            cmd.Parameters.AddWithValue("@p7", SqlDbType.TinyInt).Value = objProducto.Temporal1
            cmd.Parameters.AddWithValue("@p8", SqlDbType.Decimal).Value = objProducto.Precio1
            cmd.Parameters.AddWithValue("@p9", SqlDbType.Decimal).Value = objProducto.PrecioRed1

            Try
                cmd.ExecuteNonQuery()

                BD.Desconectar(BDConexion)
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString(), "Error Productos")
            End Try

        End Using

    End Sub

    Sub EliminarProducto(objProducto As Producto)

        Dim BDConexion As OleDbConnection
        BDConexion = BD.Conectar()

        Dim query As String = " DELETE * FROM Productos WHERE (IdProductos=" & objProducto.Id1 & ");"

        Using cmd As New OleDbCommand(query, BDConexion)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query

            Try
                cmd.ExecuteNonQuery()

                BD.Desconectar(BDConexion)
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString(), "Error Productos")
            End Try

        End Using

    End Sub

    Function ComprobarRepetidoProducto(Tipo As String) As Boolean

        Dim Existe As Boolean
        Dim BDConexion As OleDbConnection
        Dim Consulta As OleDbDataReader

        Try
            BDConexion = BD.Conectar()

            Existe = False

            record = New OleDbCommand("SELECT IdProductos, Codigo FROM Productos WHERE (((Codigo)='" & Tipo & "'));", BDConexion)

            record.ExecuteNonQuery()

            Consulta = record.ExecuteReader

            While Consulta.Read()
                Existe = True
            End While

            Return Existe

            BD.Desconectar(BDConexion)

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error Productos")
        End Try

    End Function

    Function GetProductosVersion(Lista As AxXtremeSuiteControls.AxComboBox)
        'Carga combo con los productos que tienen Versión
        Dim BDConexion As OleDbConnection

        Try

            BDConexion = BD.Conectar()

            record = New OleDbCommand("Select IdProductos,Codigo From Productos WHERE Versiones =True ;", BDConexion)

            record.ExecuteNonQuery()

            Consulta = record.ExecuteReader
            Dim Index As Integer

            While Consulta.Read()

                Lista.AddItem(Consulta(1).ToString, Index, Consulta(0).ToString)
                Index = Index + 1
            End While

            Consulta.Close()
            BD.Desconectar(BDConexion)
            Return Lista

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error Productos")
        End Try

    End Function

End Module
