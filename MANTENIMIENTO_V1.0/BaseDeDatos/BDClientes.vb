Imports System.Data.OleDb

Module BDClientes

    Dim record As OleDbCommand
    Dim Consulta As OleDbDataReader

    Function ObtenerTodosLosClientes() As ArrayList

        Dim ArrayProvincias As New ArrayList()
        ArrayProvincias = ObtenerTodasLasProvincias()
        Dim ArrayClientes As New ArrayList()

        Try

            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            record = New OleDbCommand("SELECT Clientes.Id, Clientes.NomComercial, Clientes.RazonSocial, Clientes.CIF, Clientes.DIRECCION, Clientes.CP, Clientes.POBLACION, Clientes.PROVINCIA, Clientes.TELEFONO, Clientes.TELEFONO2, Clientes.MOVIL, Clientes.FAX, Clientes.E_MAIL, Clientes.WEB, Clientes.GERENTENOMBRE, Clientes.USUARIONOMBRE1, Clientes.USUARIOTELEFONO1, Clientes.USUARIOEMAIL1, Clientes.USUARIONOMBRE2, Clientes.USUARIOTELEFONO2, Clientes.USUARIOEMAIL2, Clientes.USUARIONOMBRE3,  Clientes.USUARIOTELEFONO3, Clientes.USUARIOEMAIL3, Clientes.USUARIONOMBRE4,  Clientes.USUARIOTELEFONO4, Clientes.USUARIOEMAIL4, Clientes.FORMAPAGO, Clientes.IBAN_Pais, Clientes.IBAN_DC, Clientes.IBAN_Cuenta, Clientes.COD_DISTRIBUIDOR, Clientes.OBSERVACIONES, Clientes.ENVIAR_INFOR, Clientes.COD_ASESOR, Clientes.LLAMADA_SEGUI, Clientes.ProximoEstado FROM Clientes;", BDConexion)
            record.ExecuteNonQuery()

            Consulta = record.ExecuteReader
            Debug.Print("consulta fin  " & DateTime.Now)
            While Consulta.Read()
                'Tengo que controlar si los campos numéricos son nulos

                ArrayClientes.Add(New Cliente(Consulta(0).ToString, Consulta(1).ToString, Consulta(2).ToString, Consulta(3).ToString, Consulta(4).ToString, Consulta(5).ToString, Consulta(6).ToString, Consulta(7).ToString, Consulta(8).ToString, Consulta(9).ToString, Consulta(10).ToString, Consulta(11).ToString, Consulta(12).ToString, Consulta(13).ToString, Consulta(14).ToString, Consulta(15).ToString, Consulta(16).ToString, Consulta(17).ToString, Consulta(18).ToString, Consulta(19).ToString, Consulta(20).ToString, Consulta(21).ToString, Consulta(22).ToString, Consulta(23).ToString, Consulta(24).ToString, Consulta(25).ToString, Consulta(26).ToString, Consulta(27).ToString, Consulta(28).ToString, Consulta(29).ToString, Consulta(30).ToString, Consulta(31).ToString, Consulta(32).ToString, Consulta(33).ToString, Consulta(34).ToString, Consulta(35).ToString, Consulta(36).ToString, ArrayProvincias))
            End While
            Debug.Print("Carga Array bd fin  " & DateTime.Now)
            Consulta.Close()
            BD.Desconectar(BDConexion)

            Return (ArrayClientes)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (ArrayClientes)
        End Try

    End Function

    Function ObtenerTodosLosClientesTabla() As DataTable

        Dim ArrayProvincias As New ArrayList()
        ArrayProvincias = ObtenerTodasLasProvincias()

        '   Dim ArrayClientes As New ArrayList()

        Try

            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()


            Dim ds As New DataSet
            Dim dt As New DataTable
            ds.Tables.Add(dt)
            Dim da As New OleDbDataAdapter

            da = New OleDbDataAdapter("SELECT Clientes.Id, Clientes.NomComercial, Clientes.RazonSocial, Clientes.CIF, Clientes.DIRECCION, Clientes.CP, Clientes.POBLACION, Clientes.PROVINCIA, Clientes.TELEFONO, Clientes.TELEFONO2, Clientes.MOVIL, Clientes.FAX, Clientes.E_MAIL, Clientes.WEB, Clientes.GERENTENOMBRE, Clientes.USUARIONOMBRE1, Clientes.USUARIOTELEFONO1, Clientes.USUARIOEMAIL1, Clientes.USUARIONOMBRE2, Clientes.USUARIOTELEFONO2, Clientes.USUARIOEMAIL2, Clientes.USUARIONOMBRE3,  Clientes.USUARIOTELEFONO3, Clientes.USUARIOEMAIL3, Clientes.USUARIONOMBRE4,  Clientes.USUARIOTELEFONO4, Clientes.USUARIOEMAIL4, Clientes.FORMAPAGO, Clientes.IBAN_Pais, Clientes.IBAN_DC, Clientes.IBAN_Cuenta, Clientes.COD_DISTRIBUIDOR, Clientes.OBSERVACIONES, Clientes.ENVIAR_INFOR, Clientes.COD_ASESOR, Clientes.LLAMADA_SEGUI, Clientes.ProximoEstado FROM Clientes;", BDConexion)
            da.Fill(dt)

            'Dim x As Integer
            'For x = 0 To dt.Rows.Count - 1
            '    ArrayClientes.Add(New Cliente(dt.Rows(x).Item(0).ToString, dt.Rows(x).Item(1).ToString, dt.Rows(x).Item(2).ToString, dt.Rows(x).Item(3).ToString, dt.Rows(x).Item(4).ToString, dt.Rows(x).Item(5).ToString, dt.Rows(x).Item(6).ToString, dt.Rows(x).Item(7).ToString, dt.Rows(x).Item(8).ToString, dt.Rows(x).Item(9).ToString, dt.Rows(x).Item(10).ToString, dt.Rows(x).Item(11).ToString, dt.Rows(x).Item(12).ToString, dt.Rows(x).Item(13).ToString, dt.Rows(x).Item(14).ToString, dt.Rows(x).Item(15).ToString, dt.Rows(x).Item(16).ToString, dt.Rows(x).Item(17).ToString, dt.Rows(x).Item(18).ToString, dt.Rows(x).Item(19).ToString, dt.Rows(x).Item(20).ToString, dt.Rows(x).Item(21).ToString, dt.Rows(x).Item(22).ToString, dt.Rows(x).Item(23).ToString, dt.Rows(x).Item(24).ToString, dt.Rows(x).Item(25).ToString, dt.Rows(x).Item(26).ToString, dt.Rows(x).Item(27).ToString, dt.Rows(x).Item(28).ToString, dt.Rows(x).Item(29).ToString, dt.Rows(x).Item(30).ToString, dt.Rows(x).Item(31).ToString, dt.Rows(x).Item(32).ToString, dt.Rows(x).Item(33).ToString, dt.Rows(x).Item(34).ToString, dt.Rows(x).Item(35).ToString, dt.Rows(x).Item(36).ToString, ArrayProvincias))
            'Next


            '  Debug.Print("Carga Array bd fin  " & DateTime.Now)

            '   Debug.Print("I3:" & DateTime.Now)
            BD.Desconectar(BDConexion)
            Return (dt)
        Catch ex As Exception

            MsgBox(ex)
            ' Return ds
        End Try

        'Try

        '    Dim BDConexion As OleDbConnection
        '    BDConexion = BD.Conectar()
        '    record = New OleDbCommand("SELECT Clientes.Id, Clientes.NomComercial, Clientes.RazonSocial, Clientes.CIF, Clientes.DIRECCION, Clientes.CP, Clientes.POBLACION, Clientes.PROVINCIA, Clientes.TELEFONO, Clientes.TELEFONO2, Clientes.MOVIL, Clientes.FAX, Clientes.E_MAIL, Clientes.WEB, Clientes.GERENTENOMBRE, Clientes.USUARIONOMBRE1, Clientes.USUARIOTELEFONO1, Clientes.USUARIOEMAIL1, Clientes.USUARIONOMBRE2, Clientes.USUARIOTELEFONO2, Clientes.USUARIOEMAIL2, Clientes.USUARIONOMBRE3,  Clientes.USUARIOTELEFONO3, Clientes.USUARIOEMAIL3, Clientes.USUARIONOMBRE4,  Clientes.USUARIOTELEFONO4, Clientes.USUARIOEMAIL4, Clientes.FORMAPAGO, Clientes.IBAN_Pais, Clientes.IBAN_DC, Clientes.IBAN_Cuenta, Clientes.COD_DISTRIBUIDOR, Clientes.OBSERVACIONES, Clientes.ENVIAR_INFOR, Clientes.COD_ASESOR, Clientes.LLAMADA_SEGUI, Clientes.ProximoEstado FROM Clientes;", BDConexion)
        '    record.ExecuteNonQuery()

        '    Consulta = record.ExecuteReader
        '    Debug.Print("consulata fin  " & DateTime.Now)
        '    While Consulta.Read()
        '        'Tengo que controlar si los campos numéricos son nulos

        '        ArrayClientes.Add(New Cliente(Consulta(0).ToString, Consulta(1).ToString, Consulta(2).ToString, Consulta(3).ToString, Consulta(4).ToString, Consulta(5).ToString, Consulta(6).ToString, Consulta(7).ToString, Consulta(8).ToString, Consulta(9).ToString, Consulta(10).ToString, Consulta(11).ToString, Consulta(12).ToString, Consulta(13).ToString, Consulta(14).ToString, Consulta(15).ToString, Consulta(16).ToString, Consulta(17).ToString, Consulta(18).ToString, Consulta(19).ToString, Consulta(20).ToString, Consulta(21).ToString, Consulta(22).ToString, Consulta(23).ToString, Consulta(24).ToString, Consulta(25).ToString, Consulta(26).ToString, Consulta(27).ToString, Consulta(28).ToString, Consulta(29).ToString, Consulta(30).ToString, Consulta(31).ToString, Consulta(32).ToString, Consulta(33).ToString, Consulta(34).ToString, Consulta(35).ToString, Consulta(36).ToString, ArrayProvincias))
        '    End While
        '    Debug.Print("Carga Array bd fin  " & DateTime.Now)
        '    Consulta.Close()
        '    BD.Desconectar(BDConexion)

        '    Return (ArrayClientes)

        'Catch ex As Exception

        '    MsgBox(ex)
        '    Return (ArrayClientes)
        'End Try

    End Function

    Function ObtenerUnCliente(IdCliente As Long) As Cliente

        Dim ArrayProvincias As New ArrayList()
        ArrayProvincias = ObtenerTodasLasProvincias()

        Dim objClientes As Cliente

        Try

            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            record = New OleDbCommand("SELECT Clientes.Id, Clientes.NomComercial, Clientes.RazonSocial, Clientes.CIF, Clientes.DIRECCION, Clientes.CP, Clientes.POBLACION, Clientes.PROVINCIA, Clientes.TELEFONO, Clientes.TELEFONO2, Clientes.MOVIL, Clientes.FAX, Clientes.E_MAIL, Clientes.WEB, Clientes.GERENTENOMBRE, Clientes.USUARIONOMBRE1, Clientes.USUARIOTELEFONO1, Clientes.USUARIOEMAIL1, Clientes.USUARIONOMBRE2, Clientes.USUARIOTELEFONO2, Clientes.USUARIOEMAIL2, Clientes.USUARIONOMBRE3,  Clientes.USUARIOTELEFONO3, Clientes.USUARIOEMAIL3, Clientes.USUARIONOMBRE4,  Clientes.USUARIOTELEFONO4, Clientes.USUARIOEMAIL4, Clientes.FORMAPAGO, Clientes.IBAN_Pais, Clientes.IBAN_DC, Clientes.IBAN_Cuenta, Clientes.COD_DISTRIBUIDOR, Clientes.OBSERVACIONES, Clientes.ENVIAR_INFOR, Clientes.COD_ASESOR, Clientes.LLAMADA_SEGUI, Clientes.ProximoEstado FROM Clientes WHERE (Id=" & IdCliente & ")", BDConexion)
            record.ExecuteNonQuery()

            Consulta = record.ExecuteReader
            '            Debug.Print("consulta fin  " & DateTime.Now)
            While Consulta.Read()
                'Tengo que controlar si los campos numéricos son nulos

                objClientes = New Cliente(Consulta(0).ToString, Consulta(1).ToString, Consulta(2).ToString, Consulta(3).ToString, Consulta(4).ToString, Consulta(5).ToString, Consulta(6).ToString, Consulta(7).ToString, Consulta(8).ToString, Consulta(9).ToString, Consulta(10).ToString, Consulta(11).ToString, Consulta(12).ToString, Consulta(13).ToString, Consulta(14).ToString, Consulta(15).ToString, Consulta(16).ToString, Consulta(17).ToString, Consulta(18).ToString, Consulta(19).ToString, Consulta(20).ToString, Consulta(21).ToString, Consulta(22).ToString, Consulta(23).ToString, Consulta(24).ToString, Consulta(25).ToString, Consulta(26).ToString, Consulta(27).ToString, Consulta(28).ToString, Consulta(29).ToString, Consulta(30).ToString, Consulta(31).ToString, Consulta(32).ToString, Consulta(33).ToString, Consulta(34).ToString, Consulta(35).ToString, Consulta(36).ToString, ArrayProvincias)
            End While
            '            Debug.Print("Carga Array bd fin  " & DateTime.Now)
            Consulta.Close()
            BD.Desconectar(BDConexion)

            Return (objClientes)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (objClientes)
        End Try

    End Function


    Function NuevoNumCliente() As Long

        Dim numero As Long
        Try
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            record = New OleDbCommand("Select Max(Clientes.Id) As MáxDeId From Clientes;", BDConexion)
            record.ExecuteNonQuery()

            Consulta = record.ExecuteReader
            While Consulta.Read()
                numero = CLng(Consulta(0).ToString) + 1
            End While
            Consulta.Close()
            BD.Desconectar(BDConexion)
            Return numero

        Catch ex As Exception
            MsgBox(ex.Message)
            Return 0
        End Try



    End Function


    Function GuardarFichaClientes(objCliente As Cliente) As String
        Dim ProcesoTerminado As Boolean
        Dim texto As String

        If comprobarSiExisteCliente(objCliente) = False Then
            ProcesoTerminado = InsertarClienteNuevo(objCliente)
            If ProcesoTerminado = True Then
                texto = "El Cliente a sido introducido con exito."
            Else
                texto = ""
            End If
        Else
            ProcesoTerminado = ModificarCliente(objCliente)
            If ProcesoTerminado = True Then
                texto = "El Cliente a sido Guardado con exito."
            Else
                texto = ""
            End If
        End If


        Return texto


    End Function


    Function ModificarCliente(objCliente As Cliente) As Boolean
        Dim BDConexion As OleDbConnection
        BDConexion = BD.Conectar()
        Dim query As String

        query = " UPDATE Clientes SET  NomComercial = @NomComercial, RazonSocial = @RazonSocial, CIF = @CIF, DIRECCION = @DIRECCION , CP = @CP, POBLACION = @POBLACION, PROVINCIA = @PROVINCIA,  TELEFONO = @TELEFONO, TELEFONO2 = @TELEFONO2,  MOVIL = @MOVIL,  FAX = @FAX,  E_MAIL = @E_MAIL,  WEB = @WEB,  GERENTENOMBRE = @GERENTENOMBRE,  USUARIONOMBRE1 = @USUARIONOMBRE1,  USUARIOTELEFONO1 = @USUARIOTELEFONO1,  USUARIOEMAIL1 = @USUARIOEMAIL1,  USUARIONOMBRE2 = @USUARIONOMBRE2, USUARIOTELEFONO2 = @USUARIOTELEFONO2, USUARIOEMAIL2 = @USUARIOEMAIL2, USUARIONOMBRE3 = @USUARIONOMBRE3, USUARIOTELEFONO3 = @USUARIOTELEFONO3, USUARIOEMAIL3 = @USUARIOEMAIL3, USUARIONOMBRE4 = @USUARIONOMBRE4, USUARIOTELEFONO4 = @USUARIOTELEFONO4, USUARIOEMAIL4 = @USUARIOEMAIL4, FORMAPAGO = @FORMAPAGO, IBAN_Pais = @IBAN_Pais, IBAN_DC = @IBAN_DC, IBAN_Cuenta = @IBAN_Cuenta, COD_DISTRIBUIDOR = @COD_DISTRIBUIDOR, OBSERVACIONES = @OBSERVACIONES, ENVIAR_INFOR = @ENVIAR_INFOR, LLAMADA_SEGUI = @LLAMADA_SEGUI, ProximoEstado = @ProximoEstado, RUTABD = @RUTABD  WHERE (((Id)=" & objCliente.Id1 & "));"

        Using cmd As New OleDbCommand(query, BDConexion)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query
            ''  cmd.Parameters.Add("@IdProvincia", SqlDbType.VarChar).Value = objProvincia.

            '   cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = objCliente.Id1
            cmd.Parameters.AddWithValue("@NomComercial", SqlDbType.VarChar).Value = objCliente.NombreComercial1
            cmd.Parameters.AddWithValue("@RazonSocial", SqlDbType.VarChar).Value = objCliente.RazonSocial1
            cmd.Parameters.AddWithValue("@CIF", SqlDbType.VarChar).Value = objCliente.Cif1
            cmd.Parameters.AddWithValue("@DIRECCION", SqlDbType.VarChar).Value = objCliente.Direccion1
            cmd.Parameters.AddWithValue("@CP", SqlDbType.VarChar).Value = objCliente.CP1
            cmd.Parameters.AddWithValue("@POBLACION", SqlDbType.VarChar).Value = objCliente.Poblacion1
            cmd.Parameters.AddWithValue("@PROVINCIA", SqlDbType.Int).Value = objCliente.IdProvincia1


            cmd.Parameters.AddWithValue("@TELEFONO", SqlDbType.VarChar).Value = objCliente.Telefono1
            cmd.Parameters.AddWithValue("@TELEFONO2", SqlDbType.VarChar).Value = objCliente.Telefono21
            cmd.Parameters.AddWithValue("@MOVIL", SqlDbType.VarChar).Value = objCliente.Movil1
            cmd.Parameters.AddWithValue("@FAX", SqlDbType.VarChar).Value = objCliente.Fax1
            cmd.Parameters.AddWithValue("@E_MAIL", SqlDbType.VarChar).Value = objCliente.Email1
            cmd.Parameters.AddWithValue("@WEB", SqlDbType.VarChar).Value = objCliente.Web1
            cmd.Parameters.AddWithValue("@GERENTENOMBRE", SqlDbType.VarChar).Value = objCliente.GerenteNombre1

            cmd.Parameters.AddWithValue("@USUARIONOMBRE1", SqlDbType.VarChar).Value = objCliente.UsuarioNombre11
            cmd.Parameters.AddWithValue("@USUARIOTELEFONO1", SqlDbType.VarChar).Value = objCliente.UsuarioTelefono11
            cmd.Parameters.AddWithValue("@USUARIOEMAIL1", SqlDbType.VarChar).Value = objCliente.UsuarioEmail11

            cmd.Parameters.AddWithValue("@USUARIONOMBRE2", SqlDbType.VarChar).Value = objCliente.UsuarioEmail21
            cmd.Parameters.AddWithValue("@USUARIOTELEFONO2", SqlDbType.VarChar).Value = objCliente.UsuarioTelefono21
            cmd.Parameters.AddWithValue("@USUARIOEMAIL2", SqlDbType.VarChar).Value = objCliente.UsuarioEmail21

            cmd.Parameters.AddWithValue("@USUARIONOMBRE3", SqlDbType.VarChar).Value = objCliente.UsuarioEmail31
            cmd.Parameters.AddWithValue("@USUARIOTELEFONO3", SqlDbType.VarChar).Value = objCliente.UsuarioTelefono31
            cmd.Parameters.AddWithValue("@USUARIOEMAIL3", SqlDbType.VarChar).Value = objCliente.UsuarioEmail31

            cmd.Parameters.AddWithValue("@USUARIONOMBRE4", SqlDbType.VarChar).Value = objCliente.UsuarioEmail41
            cmd.Parameters.AddWithValue("@USUARIOTELEFONO4", SqlDbType.VarChar).Value = objCliente.UsuarioTelefono41
            cmd.Parameters.AddWithValue("@USUARIOEMAIL4", SqlDbType.VarChar).Value = objCliente.UsuarioEmail41


            cmd.Parameters.AddWithValue("@FormaPago", SqlDbType.Int).Value = objCliente.FormaPago1
            cmd.Parameters.AddWithValue("@IBAN_Pais", SqlDbType.VarChar).Value = objCliente.IbanPais1
            cmd.Parameters.AddWithValue("@IBAN_DC", SqlDbType.VarChar).Value = objCliente.IbanDc1
            cmd.Parameters.AddWithValue("@IBAN_Cuenta", SqlDbType.VarChar).Value = objCliente.IbanCuenta1

            '  cmd.Parameters.AddWithValue("@COD_DISTRIBUIDOR", SqlDbType.Int).Value = objCliente.CodDistribuidor1
            cmd.Parameters.AddWithValue("@COD_DISTRIBUIDOR", SqlDbType.Int).Value = 0
            cmd.Parameters.AddWithValue("@OBSERVACIONES", SqlDbType.VarChar).Value = "" ' Observaciones
            'cmd.Parameters.AddWithValue("@ENVIAR_INFOR", SqlDbType.TinyInt).Value = objCliente.EnviarInfo1
            cmd.Parameters.AddWithValue("@ENVIAR_INFOR", SqlDbType.TinyInt).Value = 0

            ' cmd.Parameters.AddWithValue("@COD_ASESOR", SqlDbType.Int).Value = objCliente.CodigoAsesor1
            cmd.Parameters.AddWithValue("@COD_ASESOR", SqlDbType.Int).Value = 0
            '  cmd.Parameters.AddWithValue("@LLAMADA_SEGUI", SqlDbType.TinyInt).Value = objCliente.LlamadaSegui1
            cmd.Parameters.AddWithValue("@LLAMADA_SEGUI", SqlDbType.TinyInt).Value = 0
            cmd.Parameters.AddWithValue("@ProximoEstado", SqlDbType.VarChar).Value = ""



            cmd.Parameters.AddWithValue("@RUTABD", SqlDbType.VarChar).Value = "" '


            Try
                cmd.ExecuteNonQuery()

                'Dim query2 As String = "Select @@Identity"

                'cmd.CommandText = query2

                'objCliente.Id1 = cmd.ExecuteScalar()
                BD.Desconectar(BDConexion)

                Return True
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString(), "Error Clientes")
                Return False
            End Try

        End Using

    End Function


    Function InsertarClienteNuevo(objCliente As Cliente) As Boolean
        Dim BDConexion As OleDbConnection
        BDConexion = BD.Conectar()
        Dim query As String

        query = "INSERT INTO Clientes (Id, NomComercial, RazonSocial, CIF, DIRECCION, CP, POBLACION, PROVINCIA, TELEFONO, TELEFONO2, MOVIL, FAX, E_MAIL, WEB, GERENTENOMBRE, USUARIONOMBRE1, USUARIOTELEFONO1, USUARIOEMAIL1, USUARIONOMBRE2, USUARIOTELEFONO2, USUARIOEMAIL2, USUARIONOMBRE3, USUARIOTELEFONO3, USUARIOEMAIL3, USUARIONOMBRE4, USUARIOTELEFONO4, USUARIOEMAIL4, FORMAPAGO, IBAN_Pais, IBAN_DC, IBAN_Cuenta, COD_DISTRIBUIDOR, OBSERVACIONES, ENVIAR_INFOR, COD_ASESOR, LLAMADA_SEGUI, ProximoEstado,  RUTABD ) values (@Id, @NomComercial, @RazonSocial, @CIF, @DIRECCION, @CP, @POBLACION, @PROVINCIA, @TELEFONO, @TELEFONO2, @MOVIL, @FAX, @E_MAIL, @WEB, @GERENTENOMBRE, @USUARIONOMBRE1, @USUARIOTELEFONO1, @USUARIOEMAIL1, @USUARIONOMBRE2, @USUARIOTELEFONO2, @USUARIOEMAIL2, @USUARIONOMBRE3, @USUARIOTELEFONO3, @USUARIOEMAIL3, @USUARIONOMBRE4, @USUARIOTELEFONO4, @USUARIOEMAIL4, @FORMAPAGO, @IBAN_Pais, @IBAN_DC, @IBAN_Cuenta, @COD_DISTRIBUIDOR, @OBSERVACIONES, @ENVIAR_INFOR, @COD_ASESOR, @LLAMADA_SEGUI, @ProximoEstado, @RUTABD );"
        Using cmd As New OleDbCommand(query, BDConexion)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query
            ''  cmd.Parameters.Add("@IdProvincia", SqlDbType.VarChar).Value = objProvincia.

            cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = objCliente.Id1
            cmd.Parameters.AddWithValue("@NomComercial", SqlDbType.VarChar).Value = objCliente.NombreComercial1
            cmd.Parameters.AddWithValue("@RazonSocial", SqlDbType.VarChar).Value = objCliente.RazonSocial1
            cmd.Parameters.AddWithValue("@CIF", SqlDbType.VarChar).Value = objCliente.Cif1
            cmd.Parameters.AddWithValue("@DIRECCION", SqlDbType.VarChar).Value = objCliente.Direccion1
            cmd.Parameters.AddWithValue("@CP", SqlDbType.VarChar).Value = objCliente.CP1
            cmd.Parameters.AddWithValue("@POBLACION", SqlDbType.VarChar).Value = objCliente.Poblacion1
            cmd.Parameters.AddWithValue("@PROVINCIA", SqlDbType.Int).Value = objCliente.IdProvincia1
            ' cmd.Parameters.AddWithValue("@PROVINCIA", SqlDbType.Int).Value = 131

            cmd.Parameters.AddWithValue("@TELEFONO", SqlDbType.VarChar).Value = objCliente.Telefono1
            cmd.Parameters.AddWithValue("@TELEFONO2", SqlDbType.VarChar).Value = objCliente.Telefono21
            cmd.Parameters.AddWithValue("@MOVIL", SqlDbType.VarChar).Value = objCliente.Movil1
            cmd.Parameters.AddWithValue("@FAX", SqlDbType.VarChar).Value = objCliente.Fax1
            cmd.Parameters.AddWithValue("@E_MAIL", SqlDbType.VarChar).Value = objCliente.Email1
            cmd.Parameters.AddWithValue("@WEB", SqlDbType.VarChar).Value = objCliente.Web1
            cmd.Parameters.AddWithValue("@GERENTENOMBRE", SqlDbType.VarChar).Value = objCliente.GerenteNombre1

            cmd.Parameters.AddWithValue("@USUARIONOMBRE1", SqlDbType.VarChar).Value = objCliente.UsuarioNombre11
            cmd.Parameters.AddWithValue("@USUARIOTELEFONO1", SqlDbType.VarChar).Value = objCliente.UsuarioTelefono11
            cmd.Parameters.AddWithValue("@USUARIOEMAIL1", SqlDbType.VarChar).Value = objCliente.UsuarioEmail11

            cmd.Parameters.AddWithValue("@USUARIONOMBRE2", SqlDbType.VarChar).Value = objCliente.UsuarioEmail21
            cmd.Parameters.AddWithValue("@USUARIOTELEFONO2", SqlDbType.VarChar).Value = objCliente.UsuarioTelefono21
            cmd.Parameters.AddWithValue("@USUARIOEMAIL2", SqlDbType.VarChar).Value = objCliente.UsuarioEmail21

            cmd.Parameters.AddWithValue("@USUARIONOMBRE3", SqlDbType.VarChar).Value = objCliente.UsuarioEmail31
            cmd.Parameters.AddWithValue("@USUARIOTELEFONO3", SqlDbType.VarChar).Value = objCliente.UsuarioTelefono31
            cmd.Parameters.AddWithValue("@USUARIOEMAIL3", SqlDbType.VarChar).Value = objCliente.UsuarioEmail31

            cmd.Parameters.AddWithValue("@USUARIONOMBRE4", SqlDbType.VarChar).Value = objCliente.UsuarioEmail41
            cmd.Parameters.AddWithValue("@USUARIOTELEFONO4", SqlDbType.VarChar).Value = objCliente.UsuarioTelefono41
            cmd.Parameters.AddWithValue("@USUARIOEMAIL4", SqlDbType.VarChar).Value = objCliente.UsuarioEmail41


            cmd.Parameters.AddWithValue("@FormaPago", SqlDbType.Int).Value = objCliente.FormaPago1
            cmd.Parameters.AddWithValue("@IBAN_Pais", SqlDbType.VarChar).Value = objCliente.IbanPais1
            cmd.Parameters.AddWithValue("@IBAN_DC", SqlDbType.VarChar).Value = objCliente.IbanDc1
            cmd.Parameters.AddWithValue("@IBAN_Cuenta", SqlDbType.VarChar).Value = objCliente.IbanCuenta1

            '  cmd.Parameters.AddWithValue("@COD_DISTRIBUIDOR", SqlDbType.Int).Value = objCliente.CodDistribuidor1
            cmd.Parameters.AddWithValue("@COD_DISTRIBUIDOR", SqlDbType.Int).Value = 0
            cmd.Parameters.AddWithValue("@OBSERVACIONES", SqlDbType.VarChar).Value = "" ' Observaciones
            'cmd.Parameters.AddWithValue("@ENVIAR_INFOR", SqlDbType.TinyInt).Value = objCliente.EnviarInfo1
            cmd.Parameters.AddWithValue("@ENVIAR_INFOR", SqlDbType.TinyInt).Value = 0

            ' cmd.Parameters.AddWithValue("@COD_ASESOR", SqlDbType.Int).Value = objCliente.CodigoAsesor1
            cmd.Parameters.AddWithValue("@COD_ASESOR", SqlDbType.Int).Value = 0
            '  cmd.Parameters.AddWithValue("@LLAMADA_SEGUI", SqlDbType.TinyInt).Value = objCliente.LlamadaSegui1
            cmd.Parameters.AddWithValue("@LLAMADA_SEGUI", SqlDbType.TinyInt).Value = 0
            cmd.Parameters.AddWithValue("@ProximoEstado", SqlDbType.VarChar).Value = ""



            cmd.Parameters.AddWithValue("@RUTABD", SqlDbType.VarChar).Value = "" '




            Try
                cmd.ExecuteNonQuery()

                'Dim query2 As String = "Select @@Identity"

                'cmd.CommandText = query2

                'objCliente.Id1 = cmd.ExecuteScalar()
                BD.Desconectar(BDConexion)
                Return True

            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString(), "Error Clientes")
                Return False
            End Try

        End Using

    End Function


    Function comprobarSiExisteCliente(objcliente As Cliente) As Boolean

        Dim numero As Long
        Try
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            record = New OleDbCommand("Select  Clientes.Id From Clientes Where (((Clientes.Id) = " & objcliente.Id1 & "));", BDConexion)
            record.ExecuteNonQuery()

            Consulta = record.ExecuteReader
            While Consulta.Read()
                Return True
                Exit Function
            End While
            Return False
        Catch ex As Exception

        End Try

    End Function


End Module
