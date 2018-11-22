Imports System.Data.OleDb

Module BDUsuarios
    Dim record As OleDbCommand
    Dim Consulta As OleDbDataReader

    Function ObtenerUsuarios(IdGrupo As Long) As ArrayList
        ' Dim objVersiones As Version
        Dim ArrayUsuarios As New ArrayList() 'si no le pongo New se le va la pinza
        Dim Dato2 As String
        'Dim Dato3 As String

        Try
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            record = New OleDbCommand("SELECT IdUsuarios, Nombre, Contraseña, Configuracion, IdGrupo FROM SeguridadUsuarios WHERE IdGrupo=" & IdGrupo & " ORDER BY Nombre;", BDConexion)
            record.ExecuteNonQuery()

            Consulta = record.ExecuteReader

            While Consulta.Read()
                'Tengo que controlar si los campos numéricos son nulos
                If IsDBNull(Consulta(2).ToString) Then
                    Dato2 = ""
                Else
                    Dato2 = Consulta(2).ToString
                End If

                ArrayUsuarios.Add(New Usuario(Convert.ToInt32(Consulta(0).ToString), Consulta(1).ToString, Dato2))

            End While

            Consulta.Close()
            BD.Desconectar(BDConexion)

            Return (ArrayUsuarios)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (ArrayUsuarios)
        End Try

    End Function

    Function ObtenerTodosUsuarios() As ArrayList
        ' Dim objVersiones As Version
        Dim ArrayUsuarios As New ArrayList() 'si no le pongo New se le va la pinza
        Dim Dato2 As String
        'Dim Dato3 As String

        Try
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            record = New OleDbCommand("SELECT IdUsuarios, Nombre, Contraseña, Configuracion, IdGrupo FROM SeguridadUsuarios ORDER BY Nombre;", BDConexion)
            record.ExecuteNonQuery()

            Consulta = record.ExecuteReader

            While Consulta.Read()
                'Tengo que controlar si los campos numéricos son nulos
                If IsDBNull(Consulta(2).ToString) Then
                    Dato2 = ""
                Else
                    Dato2 = Consulta(2).ToString
                End If

                ArrayUsuarios.Add(New Usuario(Convert.ToInt32(Consulta(0).ToString), Consulta(1).ToString, Dato2))

            End While

            Consulta.Close()
            BD.Desconectar(BDConexion)

            Return (ArrayUsuarios)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (ArrayUsuarios)
        End Try

    End Function

    Function ObtenerUnUsuario(IdUsuario As Long) As Usuario
        Dim objUsuario As Usuario
        Dim ArrayUsuarios As New ArrayList() 'si no le pongo New se le va la pinza
        Dim Dato2 As String
        'Dim Dato3 As String

        Try
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            record = New OleDbCommand("SELECT IdUsuarios, Nombre, Contraseña, Configuracion, IdGrupo FROM SeguridadUsuarios WHERE IdUsuarios=" & IdUsuario & " ORDER BY Nombre;", BDConexion)
            record.ExecuteNonQuery()

            Consulta = record.ExecuteReader

            While Consulta.Read()
                'Tengo que controlar si los campos numéricos son nulos
                If IsDBNull(Consulta(2).ToString) Then
                    Dato2 = ""
                Else
                    Dato2 = Consulta(2).ToString
                End If

                objUsuario = New Usuario(Convert.ToInt32(Consulta(0).ToString), Consulta(1).ToString, Dato2)

            End While

            Consulta.Close()
            BD.Desconectar(BDConexion)

            Return (objUsuario)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (objUsuario)
        End Try

    End Function

    Function GuardarUsuario(objUsuario As Usuario) As Usuario

        Dim BDConexion As OleDbConnection
        BDConexion = BD.Conectar()

        Dim query As String = "INSERT INTO SeguridadUsuarios (Nombre, Contraseña, IdGrupo) values (@Nombre, @Contraseña, @IdGrupo);"

        Using cmd As New OleDbCommand(query, BDConexion)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query

            cmd.Parameters.AddWithValue("@Nombre", SqlDbType.VarChar).Value = objUsuario.Nombre1
            cmd.Parameters.AddWithValue("@Contraseña", SqlDbType.VarChar).Value = objUsuario.Contraseña1
            cmd.Parameters.AddWithValue("@IdGrupo", SqlDbType.Int).Value = objUsuario.ObjGrupo1.Id1

            Try
                cmd.ExecuteNonQuery()

                Dim query2 As String = "Select @@Identity"

                cmd.CommandText = query2

                objUsuario.Id1 = cmd.ExecuteScalar()
                BD.Desconectar(BDConexion)

                Return objUsuario
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString(), "Error Usuarios")
                Return objUsuario
            End Try

        End Using

    End Function

    Sub ModificarUsuario(objUsuario As Usuario)

        Dim BDConexion As OleDbConnection
        BDConexion = BD.Conectar()

        Dim query As String = "UPDATE SeguridadUsuarios Set Nombre = @p1, Contraseña = @p2 WHERE (IdUsuarios=" & objUsuario.Id1 & ");"

        Using cmd As New OleDbCommand(query, BDConexion)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query

            cmd.Parameters.AddWithValue("@p1", SqlDbType.VarChar).Value = objUsuario.Nombre1
            cmd.Parameters.AddWithValue("@p2", SqlDbType.Decimal).Value = objUsuario.Contraseña1

            Try
                cmd.ExecuteNonQuery()

                BD.Desconectar(BDConexion)
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString(), "Error Usuarios")
            End Try

        End Using

    End Sub

    Sub EliminarUsuario(objUsuario As Usuario)

        Dim BDConexion As OleDbConnection
        BDConexion = BD.Conectar()

        Dim query As String = " DELETE * FROM SeguridadUsuarios WHERE (IdUsuarios=" & objUsuario.Id1 & ");"

        Using cmd As New OleDbCommand(query, BDConexion)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query

            Try
                cmd.ExecuteNonQuery()

                BD.Desconectar(BDConexion)
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString(), "Error Usuarios")
            End Try

        End Using

    End Sub

    Function ComprobarRepetidoUsuario(Usuario As String) As Boolean

        Dim Existe As Boolean
        Dim BDConexion As OleDbConnection
        Dim Consulta As OleDbDataReader

        Try

            BDConexion = BD.Conectar()

            Existe = False

            record = New OleDbCommand("Select IdUsuarios, Nombre, IdGrupo FROM SeguridadUsuarios WHERE (Nombre='" & Usuario & "');", BDConexion)

            record.ExecuteNonQuery()

            Consulta = record.ExecuteReader

            While Consulta.Read()
                Existe = True
            End While

            Return Existe

            BD.Desconectar(BDConexion)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error Usuarios")
        End Try

    End Function

    Function GetUsuarios(Lista As AxXtremeSuiteControls.AxComboBox)
        'Carga combo con los productos que tienen Versión
        Dim BDConexion As OleDbConnection

        Try
            BDConexion = BD.Conectar()

            record = New OleDbCommand("Select IdUsuarios, Nombre From SeguridadUsuarios ORDER BY Nombre;", BDConexion)

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
            MessageBox.Show(ex.Message.ToString(), "Error Usuarios")
        End Try

    End Function

    Function GetContraseña(idUsuario As Long) As String

        Dim BDConexion As OleDbConnection
        Dim LaContra As String

        Try
            BDConexion = BD.Conectar()

            record = New OleDbCommand("Select IdUsuarios, Contraseña From SeguridadUsuarios WHERE IdUsuarios=" & idUsuario & " ;", BDConexion)

            record.ExecuteNonQuery()

            Consulta = record.ExecuteReader

            While Consulta.Read()

                LaContra = Consulta(1).ToString
            End While

            Consulta.Close()
            BD.Desconectar(BDConexion)

            Return LaContra
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error Usuarios")
        End Try

    End Function

    Function GetGrupo(idUsuario As Long) As Long

        Dim BDConexion As OleDbConnection
        Dim ElGrupo As String

        Try
            BDConexion = BD.Conectar()

            record = New OleDbCommand("Select IdUsuarios, IdGrupo From SeguridadUsuarios WHERE IdUsuarios=" & idUsuario & " ;", BDConexion)

            record.ExecuteNonQuery()

            Consulta = record.ExecuteReader

            While Consulta.Read()
                ElGrupo = Consulta(1).ToString
            End While

            Consulta.Close()
            BD.Desconectar(BDConexion)

            Return ElGrupo
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error Usuarios")
        End Try

    End Function

End Module
