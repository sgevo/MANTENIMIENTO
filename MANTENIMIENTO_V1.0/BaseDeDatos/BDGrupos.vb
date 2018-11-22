Imports System.Data.OleDb

Module BDGrupos

    Dim record As OleDbCommand
    Dim Consulta As OleDbDataReader

    Function ObtenerGrupos() As ArrayList
        'Dim Dato7 As Double
        'Dim Dato8 As Double
        Dim ArrayGrupos As New ArrayList()

        Try
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            record = New OleDbCommand("SELECT IdGrupos, Descripcion FROM SeguridadGrupos;", BDConexion)
            record.ExecuteNonQuery()

            Consulta = record.ExecuteReader

            While Consulta.Read()
                'Tengo que controlar si los campos numéricos son nulos
                'If IsDBNull(Consulta(7).ToString) Then
                '    Dato7 = 0
                'Else
                '    If IsNumeric(Consulta(7).ToString) Then
                '        Dato7 = Convert.ToDouble(Consulta(7).ToString)
                '    Else
                '        Dato7 = 0
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
                ArrayGrupos.Add(New Grupo(Convert.ToInt32(Consulta(0).ToString), Consulta(1).ToString))
            End While

            Consulta.Close()
            BD.Desconectar(BDConexion)

            Return (ArrayGrupos)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (ArrayGrupos)
        End Try

    End Function

    Function ObtenerUnGrupo(idGrupo As Long) As Grupo
        Dim objGrupo As Grupo

        Try
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            record = New OleDbCommand("SELECT IdGrupos, Descripcion FROM SeguridadGrupos Where IdGrupos = " & idGrupo & ";", BDConexion)
            record.ExecuteNonQuery()

            Consulta = record.ExecuteReader

            While Consulta.Read()
                'Tengo que controlar si los campos numéricos son nulos
                'If IsDBNull(Consulta(7).ToString) Then
                '    Dato7 = 0
                'Else
                '    If IsNumeric(Consulta(7).ToString) Then
                '        Dato7 = Convert.ToDouble(Consulta(7).ToString)
                '    Else
                '        Dato7 = 0
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
                objGrupo = New Grupo(Convert.ToInt32(Consulta(0).ToString), Consulta(1).ToString)
            End While

            Consulta.Close()
            BD.Desconectar(BDConexion)

            Return (objGrupo)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (objGrupo)
        End Try

    End Function

    Function GuardarGrupo(objGrupo As Grupo) As Grupo

        Dim BDConexion As OleDbConnection
        BDConexion = BD.Conectar()

        Dim query As String = " INSERT INTO SeguridadGrupos ( Descripcion) values (@Descripcion);"

        Using cmd As New OleDbCommand(query, BDConexion)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query

            cmd.Parameters.AddWithValue("@Descripciones", SqlDbType.VarChar).Value = objGrupo.Descripcion1

            Try
                cmd.ExecuteNonQuery()

                Dim query2 As String = "Select @@Identity"

                cmd.CommandText = query2

                objGrupo.Id1 = cmd.ExecuteScalar()
                BD.Desconectar(BDConexion)

                Return objGrupo
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString(), "Error Grupos")
            End Try

        End Using

    End Function

    Sub ModificarGrupo(objGrupo As Grupo)

        Dim BDConexion As OleDbConnection
        BDConexion = BD.Conectar()

        Dim query As String = " UPDATE SeguridadGrupos SET Descripcion = @p1 WHERE (IdGrupos=" & objGrupo.Id1 & ");"

        Using cmd As New OleDbCommand(query, BDConexion)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query

            cmd.Parameters.AddWithValue("@p1", SqlDbType.VarChar).Value = objGrupo.Descripcion1

            Try
                cmd.ExecuteNonQuery()

                BD.Desconectar(BDConexion)
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString(), "Error Grupos")
            End Try

        End Using

    End Sub

    Sub EliminarGrupo(objGrupo As Grupo)

        Dim BDConexion As OleDbConnection
        BDConexion = BD.Conectar()

        Dim query As String = " DELETE * FROM SeguridadGrupos WHERE (IdGrupos=" & objGrupo.Id1 & ");"

        Using cmd As New OleDbCommand(query, BDConexion)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query

            Try
                cmd.ExecuteNonQuery()

                BD.Desconectar(BDConexion)
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString(), "Error Grupos")
            End Try

        End Using

    End Sub

    Function ComprobarRepetidoGrupo(Tipo As String) As Boolean

        Dim Existe As Boolean
        Dim BDConexion As OleDbConnection
        Dim Consulta As OleDbDataReader

        Try
            BDConexion = BD.Conectar()

            Existe = False

            record = New OleDbCommand("SELECT Descripcion FROM SeguridadGrupos WHERE (Descripcion='" & Tipo & "');", BDConexion)

            record.ExecuteNonQuery()

            Consulta = record.ExecuteReader

            While Consulta.Read()
                Existe = True
            End While

            Return Existe

            BD.Desconectar(BDConexion)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error Grupos")
        End Try

    End Function

    Function GetGrupoUsuario(Lista As AxXtremeSuiteControls.AxComboBox) As AxXtremeSuiteControls.AxComboBox
        'Carga combo con los productos que tienen Versión
        Dim BDConexion As OleDbConnection
        Try
            BDConexion = BD.Conectar()

            record = New OleDbCommand("Select IdGrupos,Descripcion From SeguridadGrupos ORDER BY Descripcion ;", BDConexion)

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
            MessageBox.Show(ex.Message.ToString(), "Error Grupos")
        End Try

    End Function

End Module
