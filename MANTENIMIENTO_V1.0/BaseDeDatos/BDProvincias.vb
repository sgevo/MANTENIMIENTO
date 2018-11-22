Imports System.Data.OleDb

Module BDProvincias

    Dim record As OleDbCommand
    Dim Consulta As OleDbDataReader

    Function ObtenerTodasLasProvincias() As ArrayList


        Dim ArrayProvincias As New ArrayList()

        Try
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            record = New OleDbCommand("SELECT Provincias.Id, Provincias.Provincia, Provincias.CP FROM Provincias;", BDConexion)
            record.ExecuteNonQuery()

            Consulta = record.ExecuteReader

            While Consulta.Read()
                'Tengo que controlar si los campos numéricos son nulos

                ArrayProvincias.Add(New Provincia(Consulta(0).ToString, Consulta(1).ToString, Consulta(2).ToString))
            End While

            Consulta.Close()
            BD.Desconectar(BDConexion)

            Return (ArrayProvincias)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (ArrayProvincias)
        End Try

    End Function

    Function obtenerUnaProvincia(IdProvincia As Long) As Provincia


        Dim ObjProvincia As Provincia

        Try
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            record = New OleDbCommand("SELECT Provincias.Id, Provincias.Provincia, Provincias.CP FROM Provincias WHERE (((Provincias.Id)=" & IdProvincia & "));", BDConexion)
            record.ExecuteNonQuery()

            Consulta = record.ExecuteReader

            While Consulta.Read()
                'Tengo que controlar si los campos numéricos son nulos

                ObjProvincia = New Provincia(Consulta(0).ToString, Consulta(1).ToString, Consulta(2).ToString)
            End While

            Consulta.Close()
            BD.Desconectar(BDConexion)

            Return (ObjProvincia)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (ObjProvincia)
        End Try

    End Function

End Module
