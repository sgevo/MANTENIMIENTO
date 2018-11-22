Imports System.Data.OleDb

Module BDFormasPagos




    Dim record As OleDbCommand
    Dim Consulta As OleDbDataReader

    Function ObtenerTodasFormasPagos() As ArrayList

        Dim ArrayFormasDePagos As New ArrayList()

        Try
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            record = New OleDbCommand("SELECT FormaPago.Id, FormaPago.Descripcion, FormaPago.Plazos, FormaPago.DiasEntrePlazos, FormaPago.PrimerPago FROM FormaPago;", BDConexion)
            record.ExecuteNonQuery()

            Consulta = record.ExecuteReader

            While Consulta.Read()

                ArrayFormasDePagos.Add(New FormaPago(Convert.ToInt32(Consulta(0).ToString), Consulta(1).ToString, Consulta(2).ToString, Consulta(3).ToString, Consulta(4).ToString))
            End While

            Consulta.Close()
            BD.Desconectar(BDConexion)

            Return (ArrayFormasDePagos)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (ArrayFormasDePagos)
        End Try

    End Function


    Function GuardarFormaPago(objFormaPago As FormaPago)

        Dim BDConexion As OleDbConnection
        BDConexion = BD.Conectar()

        Dim query As String = " INSERT INTO FormaPago ( Descripcion,Plazos, DiasEntrePlazos, PrimerPago ) values (@Descripcion, @Plazos, @DiasEntrePlazos, @PrimerPago);"

        Using cmd As New OleDbCommand(query, BDConexion)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query
            ''  cmd.Parameters.Add("@IdProvincia", SqlDbType.VarChar).Value = objProvincia.

            cmd.Parameters.AddWithValue("@Descripcion", SqlDbType.VarChar).Value = objFormaPago.Descripcion1
            cmd.Parameters.AddWithValue("@Plazos", SqlDbType.Text).Value = objFormaPago.Plazos1
            cmd.Parameters.AddWithValue("@DiasEntrePlazos", SqlDbType.TinyInt).Value = objFormaPago.DiasEntrePlazos1
            cmd.Parameters.AddWithValue("@PrimerPago", SqlDbType.TinyInt).Value = objFormaPago.PrimerPago1


            Try
                cmd.ExecuteNonQuery()

                Dim query2 As String = "Select @@Identity"

                cmd.CommandText = query2

                objFormaPago.Id1 = cmd.ExecuteScalar()
                BD.Desconectar(BDConexion)

                Return objFormaPago
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString(), "Error Formas de Pagos")
            End Try

        End Using

    End Function



    Function ComprobarFormaPagoRepetido(Descripcion As String) As Boolean

        Dim Existe As Boolean
        Dim BDConexion As OleDbConnection
        Dim Consulta As OleDbDataReader

        BDConexion = BD.Conectar()

        Existe = False

        record = New OleDbCommand("SELECT Id, Descripcion FROM FormaPago WHERE (((Descripcion)='" & Descripcion & "'));", BDConexion)

        record.ExecuteNonQuery()

        Consulta = record.ExecuteReader

        While Consulta.Read()
            Existe = True
        End While

        Return Existe

        BD.Desconectar(BDConexion)
    End Function




















End Module
