Imports System.Data.OleDb

Module BDPantallas

    Dim record As OleDbCommand
    Dim Consulta As OleDbDataReader

    Function ObtenerPantallas() As ArrayList
        Dim ArrayPantallas As New ArrayList()

        Try
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            record = New OleDbCommand("SELECT IdPantallas, Codigo, Descripcion FROM SeguridadPantallas ORDER BY Descripcion;", BDConexion)
            record.ExecuteNonQuery()

            Consulta = record.ExecuteReader

            While Consulta.Read()
                ArrayPantallas.Add(New Pantalla(Convert.ToInt32(Consulta(0).ToString), Consulta(1).ToString, Consulta(2).ToString))
            End While

            Consulta.Close()
            BD.Desconectar(BDConexion)

            Return (ArrayPantallas)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (ArrayPantallas)
        End Try

    End Function

    Function ObtenerUnaPantalla(idPantalla As Long) As Pantalla
        Dim objPantalla As Pantalla

        Try
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            record = New OleDbCommand("SELECT IdPantallas, Codigo, Descripcion FROM SeguridadPantallas Where idPantallas = " & idPantalla & ";", BDConexion)
            record.ExecuteNonQuery()

            Consulta = record.ExecuteReader

            While Consulta.Read()
                objPantalla = New Pantalla(Convert.ToInt32(Consulta(0).ToString), Consulta(1).ToString, Consulta(2).ToString)
            End While

            Consulta.Close()
            BD.Desconectar(BDConexion)

            Return (objPantalla)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (objPantalla)
        End Try

    End Function

    Function ObtenerIdUnaPantalla(Pantalla As Long) As Long

        Dim IdUnaPantalla As Long

        Try
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            record = New OleDbCommand("SELECT IdPantallas, Codigo, Descripcion FROM SeguridadPantallas Where Codigo = " & Pantalla & ";", BDConexion)
            record.ExecuteNonQuery()

            Consulta = record.ExecuteReader

            While Consulta.Read()
                IdUnaPantalla = Consulta(0).ToString
            End While

            Consulta.Close()
            BD.Desconectar(BDConexion)

            Return (IdUnaPantalla)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (IdUnaPantalla)
        End Try

    End Function

    Function GuardarPantalla(objPantalla As Pantalla) As Pantalla

        Dim BDConexion As OleDbConnection
        BDConexion = BD.Conectar()

        Dim query As String = "INSERT INTO SeguridadPantallas (Codigo, Descripcion) values (@Codigo, @Descripcion);"

        Using cmd As New OleDbCommand(query, BDConexion)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query

            cmd.Parameters.AddWithValue("@Codigo", SqlDbType.TinyInt).Value = objPantalla.Codigo1
            cmd.Parameters.AddWithValue("@Descripciones", SqlDbType.VarChar).Value = objPantalla.Descripcion1
            Try
                cmd.ExecuteNonQuery()

                Dim query2 As String = "Select @@Identity"

                cmd.CommandText = query2

                objPantalla.Id1 = cmd.ExecuteScalar()
                BD.Desconectar(BDConexion)

                Return objPantalla
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString(), "Error Pantallas")
                Return objPantalla
            End Try

        End Using

    End Function

    Sub ModificarPantalla(objPantalla As Pantalla)

        Dim BDConexion As OleDbConnection
        BDConexion = BD.Conectar()

        Dim query As String = "UPDATE SeguridadPantallas SET Codigo = @p1, Descripcion = @p2 WHERE (IdPantallas=" & objPantalla.Id1 & ");"

        Using cmd As New OleDbCommand(query, BDConexion)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query

            cmd.Parameters.AddWithValue("@p1", SqlDbType.TinyInt).Value = objPantalla.Codigo1
            cmd.Parameters.AddWithValue("@p2", SqlDbType.VarChar).Value = objPantalla.Descripcion1

            Try
                cmd.ExecuteNonQuery()

                BD.Desconectar(BDConexion)
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString(), "Error Pantallas")
            End Try

        End Using

    End Sub

    Sub EliminarPantalla(objPantalla As Pantalla)

        Dim BDConexion As OleDbConnection
        BDConexion = BD.Conectar()

        Dim query As String = " DELETE * FROM SeguridadPantallas WHERE (IdPantallas=" & objPantalla.Id1 & ");"

        Using cmd As New OleDbCommand(query, BDConexion)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query

            Try
                cmd.ExecuteNonQuery()
                BD.Desconectar(BDConexion)
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString(), "Error Pantallas")
            End Try

        End Using

    End Sub

    'Function ComprobarRepetidoGrupo(Tipo As String) As Boolean

    '    Dim Existe As Boolean
    '    Dim BDConexion As OleDbConnection
    '    Dim Consulta As OleDbDataReader

    '    BDConexion = BD.Conectar()

    '    Existe = False

    '    record = New OleDbCommand("SELECT Descripcion FROM SeguridadPantallas WHERE (Descripcion='" & Tipo & "');", BDConexion)

    '    record.ExecuteNonQuery()

    '    Consulta = record.ExecuteReader

    '    While Consulta.Read()
    '        Existe = True
    '    End While

    '    Return Existe

    '    BD.Desconectar(BDConexion)
    'End Function

    'Function GetGrupoUsuario(Lista As AxXtremeSuiteControls.AxComboBox) As AxXtremeSuiteControls.AxComboBox
    '    'Carga combo con los productos que tienen Versión
    '    Dim BDConexion As OleDbConnection
    '    BDConexion = BD.Conectar()

    '    record = New OleDbCommand("Select IdGrupos,Descripcion From SeguridadGrupos ORDER BY Descripcion ;", BDConexion)

    '    record.ExecuteNonQuery()

    '    Consulta = record.ExecuteReader
    '    Dim Index As Integer

    '    While Consulta.Read()

    '        Lista.AddItem(Consulta(1).ToString, Index, Consulta(0).ToString)
    '        Index = Index + 1
    '    End While

    '    Consulta.Close()
    '    BD.Desconectar(BDConexion)
    '    Return Lista

    'End Function

End Module
