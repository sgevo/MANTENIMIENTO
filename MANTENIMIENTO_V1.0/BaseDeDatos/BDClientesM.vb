Imports System.Data.OleDb

Module BDClientes

    Dim record As OleDbCommand
    Dim Consulta As OleDbDataReader

    Function ObtenerTodosLosClientes(ArrayProvincias As ArrayList) As ArrayList


        Dim ArrayClientes As New ArrayList()

        Try



            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            record = New OleDbCommand("SELECT Clientes.Id, Clientes.NomComercial, Clientes.RazonSocial, Clientes.CIF, Clientes.DIRECCION, Clientes.CP, Clientes.POBLACION, Clientes.PROVINCIA, Clientes.TELEFONO, Clientes.TELEFONO2, Clientes.MOVIL, Clientes.FAX, Clientes.E_MAIL, Clientes.WEB, Clientes.GERENTENOMBRE, Clientes.USUARIONOMBRE1, Clientes.USUARIOTELEFONO1, Clientes.USUARIOEMAIL1, Clientes.USUARIONOMBRE2, Clientes.USUARIOTELEFONO2, Clientes.USUARIOEMAIL2, Clientes.USUARIONOMBRE3,  Clientes.USUARIOTELEFONO3, Clientes.USUARIOEMAIL3, Clientes.USUARIONOMBRE4,  Clientes.USUARIOTELEFONO4, Clientes.USUARIOEMAIL4, Clientes.FORMAPAGO, Clientes.IBAN_Pais, Clientes.IBAN_DC, Clientes.IBAN_Cuenta, Clientes.COD_DISTRIBUIDOR, Clientes.OBSERVACIONES, Clientes.ENVIAR_INFOR, Clientes.COD_ASESOR, Clientes.LLAMADA_SEGUI, Clientes.ProximoEstado FROM Clientes;", BDConexion)
            record.ExecuteNonQuery()

            Consulta = record.ExecuteReader

            While Consulta.Read()
                'Tengo que controlar si los campos numéricos son nulos

                ArrayClientes.Add(New Cliente(Consulta(0).ToString, Consulta(1).ToString, Consulta(2).ToString, Consulta(3).ToString, Consulta(4).ToString, Consulta(5).ToString, Consulta(6).ToString, Consulta(7).ToString, Consulta(8).ToString, Consulta(9).ToString, Consulta(10).ToString, Consulta(11).ToString, Consulta(12).ToString, Consulta(13).ToString, Consulta(14).ToString, Consulta(15).ToString, Consulta(16).ToString, Consulta(17).ToString, Consulta(18).ToString, Consulta(19).ToString, Consulta(20).ToString, Consulta(21).ToString, Consulta(22).ToString, Consulta(23).ToString, Consulta(24).ToString, Consulta(25).ToString, Consulta(26).ToString, Consulta(27).ToString, Consulta(28).ToString, Consulta(29).ToString, Consulta(30).ToString, Consulta(31).ToString, Consulta(32).ToString, Consulta(33).ToString, Consulta(34).ToString, Consulta(35).ToString, Consulta(36).ToString, ArrayProvincias))
            End While

            Consulta.Close()
            BD.Desconectar(BDConexion)

            Return (ArrayClientes)

        Catch ex As Exception

            MsgBox(ex)
            Return (ArrayClientes)
        End Try

    End Function

    Function ObtenerUnCliente(idCliente As Long) As Cliente

        Dim objCliente As Cliente

        Dim ArrayProvincias As New ArrayList()

        Try
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            record = New OleDbCommand("SELECT Clientes.Id, Clientes.NomComercial, Clientes.RazonSocial, Clientes.CIF, Clientes.DIRECCION, Clientes.CP, Clientes.POBLACION, Clientes.PROVINCIA, Clientes.TELEFONO, Clientes.TELEFONO2, Clientes.MOVIL, Clientes.FAX, Clientes.E_MAIL, Clientes.WEB, Clientes.GERENTENOMBRE, Clientes.USUARIONOMBRE1, Clientes.USUARIOTELEFONO1, Clientes.USUARIOEMAIL1, Clientes.USUARIONOMBRE2, Clientes.USUARIOTELEFONO2, Clientes.USUARIOEMAIL2, Clientes.USUARIONOMBRE3,  Clientes.USUARIOTELEFONO3, Clientes.USUARIOEMAIL3, Clientes.USUARIONOMBRE4,  Clientes.USUARIOTELEFONO4, Clientes.USUARIOEMAIL4, Clientes.FORMAPAGO, Clientes.IBAN_Pais, Clientes.IBAN_DC, Clientes.IBAN_Cuenta, Clientes.COD_DISTRIBUIDOR, Clientes.OBSERVACIONES, Clientes.ENVIAR_INFOR, Clientes.COD_ASESOR, Clientes.LLAMADA_SEGUI, Clientes.ProximoEstado FROM Clientes Where id = " & idCliente & ";", BDConexion)
            record.ExecuteNonQuery()

            Consulta = record.ExecuteReader

            While Consulta.Read()
                'Tengo que controlar si los campos numéricos son nulos

                objCliente = New Cliente(Consulta(0).ToString, Consulta(1).ToString, Consulta(2).ToString, Consulta(3).ToString, Consulta(4).ToString, Consulta(5).ToString, Consulta(6).ToString, Consulta(7).ToString, Consulta(8).ToString, Consulta(9).ToString, Consulta(10).ToString, Consulta(11).ToString, Consulta(12).ToString, Consulta(13).ToString, Consulta(14).ToString, Consulta(15).ToString, Consulta(16).ToString, Consulta(17).ToString, Consulta(18).ToString, Consulta(19).ToString, Consulta(20).ToString, Consulta(21).ToString, Consulta(22).ToString, Consulta(23).ToString, Consulta(24).ToString, Consulta(25).ToString, Consulta(26).ToString, Consulta(27).ToString, Consulta(28).ToString, Consulta(29).ToString, Consulta(30).ToString, Consulta(31).ToString, Consulta(32).ToString, Consulta(33).ToString, Consulta(34).ToString, Consulta(35).ToString, Consulta(36).ToString, ArrayProvincias)

            End While

            Consulta.Close()
            BD.Desconectar(BDConexion)

            Return (objCliente)

        Catch ex As Exception

            MsgBox(ex)
            Return (objCliente)
        End Try

    End Function
End Module
