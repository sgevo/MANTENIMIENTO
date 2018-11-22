Imports System.Data.OleDb

Module BDPermisos
    Dim record As OleDbCommand
    Dim Consulta As OleDbDataReader

    Function ObtenerPermisosTodos() As ArrayList
        ' Dim objVersiones As Version
        Dim ArrayPermisos As New ArrayList() 'si no le pongo New se le va la pinza

        Try
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            record = New OleDbCommand("SELECT IdPermisos, Acceso, IdGrupo, IdPantalla FROM SeguridadPermisos ;", BDConexion)
            record.ExecuteNonQuery()

            Consulta = record.ExecuteReader

            While Consulta.Read()

                ArrayPermisos.Add(New Permiso(Convert.ToInt32(Consulta(0).ToString), Convert.ToInt32(Consulta(1).ToString), Convert.ToInt32(Consulta(2).ToString), Convert.ToInt32(Consulta(3).ToString)))

            End While

            Consulta.Close()
            BD.Desconectar(BDConexion)

            Return (ArrayPermisos)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (ArrayPermisos)
        End Try

    End Function

    Function ObtenerPermisosGrupo(IdGrupo As Long) As ArrayList
        ' Dim objVersiones As Version
        Dim ArrayPermisos As New ArrayList() 'si no le pongo New se le va la pinza

        Try
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            record = New OleDbCommand("SELECT IdPermisos, Acceso, IdPantalla FROM SeguridadPermisos WHERE IdGrupo=" & IdGrupo & ";", BDConexion)
            record.ExecuteNonQuery()

            Consulta = record.ExecuteReader

            While Consulta.Read()

                ArrayPermisos.Add(New Permiso(Convert.ToInt32(Consulta(0).ToString), Convert.ToInt32(Consulta(1).ToString)))

            End While

            Consulta.Close()
            BD.Desconectar(BDConexion)

            Return (ArrayPermisos)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (ArrayPermisos)
        End Try

    End Function

    Function ObtenerPermisosPantalla(IdPantalla As Long, IdGrupo As Long) As Long
        ' Dim objVersiones As Version
        Dim Acceso As New Long  'si no le pongo New se le va la pinza
        Acceso = 2

        Try
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            record = New OleDbCommand("SELECT IdPermisos, Acceso, IdPantalla FROM SeguridadPermisos WHERE IdGrupo=" & IdGrupo & " AND IdPantalla=" & IdPantalla & ";", BDConexion)
            record.ExecuteNonQuery()

            Consulta = record.ExecuteReader

            While Consulta.Read()

                Acceso = Convert.ToInt32(Consulta(1).ToString)

            End While

            Consulta.Close()
            BD.Desconectar(BDConexion)

            Return (Acceso)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (2) 'si no encuentra nada, doy permiso
        End Try

    End Function

    Function ObtenerPermisos(IdPantalla As Long, IdGrupo As Long) As Permiso
        ' Dim objVersiones As Version
        Dim objPermiso As Permiso
        'Dim ArrayPermisos As ArrayList

        Try
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            record = New OleDbCommand("SELECT IdPermisos, Acceso, IdGrupo, IdPantalla FROM SeguridadPermisos WHERE IdGrupo=" & IdGrupo & " AND IdPantalla=" & IdPantalla & ";", BDConexion)
            record.ExecuteNonQuery()

            Consulta = record.ExecuteReader

            While Consulta.Read()

                objPermiso = New Permiso(Convert.ToInt32(Consulta(0).ToString), Consulta(1).ToString)
                'ArrayPermisos.Add(New Permiso(Convert.ToInt32(Consulta(0).ToString), Consulta(1).ToString, ObtenerGrupos(Convert.ToInt32(Consulta(2).ToString)), ObtenerPantallas(Convert.ToInt32(Consulta(2).ToString))))

            End While

            Consulta.Close()
            BD.Desconectar(BDConexion)

            Return (objPermiso)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (objPermiso) 'si no encuentra nada, doy permiso
        End Try

    End Function

    Function GuardarPermiso(objPermiso As Permiso) As Permiso

        Dim BDConexion As OleDbConnection
        BDConexion = BD.Conectar()

        Dim query As String = "INSERT INTO SeguridadPermisos ( Acceso, IdPantalla, IdGrupo) values (@Acceso, @IdPantalla, @IdGrupo);"

        Using cmd As New OleDbCommand(query, BDConexion)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query

            cmd.Parameters.AddWithValue("@Version", SqlDbType.VarChar).Value = objPermiso.Acceso1
            cmd.Parameters.AddWithValue("@IdPantalla", SqlDbType.Int).Value = objPermiso.ObjPantalla1.Id1
            cmd.Parameters.AddWithValue("@IdGrupo", SqlDbType.Int).Value = objPermiso.ObjGrupo1.Id1

            Try
                cmd.ExecuteNonQuery()

                Dim query2 As String = "Select @@Identity"

                cmd.CommandText = query2

                objPermiso.Id1 = cmd.ExecuteScalar()
                BD.Desconectar(BDConexion)

                Return objPermiso
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString(), "Error Permisos")
                Return objPermiso
            End Try

        End Using

    End Function

    Sub ModificarPermiso(objPermiso As Permiso)

        Dim BDConexion As OleDbConnection
        BDConexion = BD.Conectar()

        Dim query As String = "UPDATE SeguridadPermisos Set Acceso = @p1 WHERE (IdPermisos=" & objPermiso.Id1 & ");"

        Using cmd As New OleDbCommand(query, BDConexion)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query

            cmd.Parameters.AddWithValue("@p1", SqlDbType.TinyInt).Value = objPermiso.Acceso1

            Try
                cmd.ExecuteNonQuery()

                BD.Desconectar(BDConexion)
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString(), "Error Permisos")
            End Try

        End Using

    End Sub

    Sub EliminarPermiso(objPermiso As Permiso)

        Dim BDConexion As OleDbConnection
        BDConexion = BD.Conectar()

        Dim query As String = " DELETE * FROM SeguridadPermisos WHERE (IdPermisos=" & objPermiso.Id1 & ");"

        Using cmd As New OleDbCommand(query, BDConexion)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query

            Try
                cmd.ExecuteNonQuery()

                BD.Desconectar(BDConexion)
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString(), "Error Permisos")
            End Try

        End Using

    End Sub

End Module
