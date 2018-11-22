Imports System.Data.OleDb

Module BDPedidos


    Dim record As OleDbCommand
    Dim Consulta As OleDbDataReader



    Function ObtenerPedidosAño(Año As String) As ArrayList
        Dim ArrayPedidos As New ArrayList()
        Dim ArrayProvincias As New ArrayList()
        'ArrayProvincias = ObtenerTodasLasProvincias()
        '    Dim ArrayPedidos As ArrayList = NewMethod()
        Dim dtClientes As New DataTable
        Dim objCliente As Cliente
        dtClientes = ObtenerTodosLosClientesTabla()
        Dim x As Integer
        Try
            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            Dim ds As New DataSet
            Dim dt As New DataTable
            ds.Tables.Add(dt)
            Dim da As New OleDbDataAdapter

            da = New OleDbDataAdapter("SELECT Pedidos.Id, Pedidos.Numero, Pedidos.Fecha, Pedidos.idCliente, Pedidos.Base, Pedidos.Iva, Pedidos.Total, Pedidos.FormaPago, Pedidos.Observaciones FROM Pedidos WHERE ((Year([Fecha])=" & Año & "));", BDConexion)
            da.Fill(dt)

            For x = 0 To dt.Rows.Count - 1

                ArrayPedidos.Add(New Pedido(Convert.ToInt64(dt.Rows(x).Item(0).ToString), dt.Rows(x).Item(1).ToString, dt.Rows(x).Item(2).ToString, dt.Rows(x).Item(3).ToString, dt.Rows(x).Item(4).ToString, dt.Rows(x).Item(5).ToString, dt.Rows(x).Item(6).ToString, dt.Rows(x).Item(7).ToString, dt.Rows(x).Item(8).ToString, BDConexion))
                For y = 0 To dtClientes.Rows.Count - 1
                    If dtClientes.Rows(y).Item(0).ToString = dt.Rows(x).Item(3).ToString Then
                        objCliente = New Cliente(dtClientes.Rows(y).Item(0).ToString, dtClientes.Rows(y).Item(1).ToString, dtClientes.Rows(y).Item(2).ToString, dtClientes.Rows(y).Item(3).ToString, dtClientes.Rows(y).Item(4).ToString, dtClientes.Rows(y).Item(5).ToString, dtClientes.Rows(y).Item(6).ToString, dtClientes.Rows(y).Item(7).ToString, dtClientes.Rows(y).Item(8).ToString, dtClientes.Rows(y).Item(9).ToString, dtClientes.Rows(y).Item(10).ToString, dtClientes.Rows(y).Item(11).ToString, dtClientes.Rows(y).Item(12).ToString, dtClientes.Rows(y).Item(13).ToString, dtClientes.Rows(y).Item(14).ToString, dtClientes.Rows(y).Item(15).ToString, dtClientes.Rows(y).ToString, dtClientes.Rows(y).Item(17).ToString, dtClientes.Rows(y).Item(18).ToString, dtClientes.Rows(y).Item(19).ToString, dtClientes.Rows(y).Item(20).ToString, dtClientes.Rows(y).Item(21).ToString, dtClientes.Rows(y).Item(22).ToString, dtClientes.Rows(y).Item(23).ToString, dtClientes.Rows(y).Item(24).ToString, dtClientes.Rows(y).Item(25).ToString, dtClientes.Rows(y).Item(26).ToString, dtClientes.Rows(y).Item(27).ToString, dtClientes.Rows(y).Item(28).ToString, dtClientes.Rows(y).Item(29).ToString, dtClientes.Rows(y).Item(30).ToString, dtClientes.Rows(y).Item(31).ToString, dtClientes.Rows(y).Item(32).ToString, dtClientes.Rows(y).Item(33).ToString, dtClientes.Rows(y).Item(34).ToString, dtClientes.Rows(y).Item(35).ToString, dtClientes.Rows(y).Item(36).ToString, ArrayProvincias)
                        ArrayPedidos(x).ObjCliente1 = objCliente
                        Exit For
                    End If
                Next
            Next


                'record = New OleDbCommand("SELECT Pedidos.Id, Pedidos.Numero, Pedidos.Fecha, Pedidos.idCliente, Pedidos.Base, Pedidos.Iva, Pedidos.Total, Pedidos.FormaPago, Pedidos.Observaciones FROM Pedidos WHERE ((Year([Fecha])=" & Año & "));", BDConexion)
                ''    record.ExecuteNonQuery()

                'Consulta = record.ExecuteReader
                'Debug.Print("consulata fin  " & DateTime.Now)
                'While Consulta.Read()
                '    'Tengo que controlar si los campos numéricos son nulos

                '    ArrayPedidos.Add(New Pedido(Convert.ToInt64(Consulta(0).ToString), Consulta(1).ToString, Consulta(2).ToString, Consulta(3).ToString, Consulta(4).ToString, Consulta(5).ToString, Consulta(6).ToString, Consulta(7).ToString, Consulta(8).ToString, BDConexion))

                'End While
                'Debug.Print("Carga Array bd fin  " & DateTime.Now)
                'Consulta.Close()

                BD.Desconectar(BDConexion)

            Return (ArrayPedidos)

        Catch ex As Exception

            MsgBox(ex)
            Return (ArrayPedidos)
        End Try

    End Function

    Private Function NewMethod() As ArrayList
        Dim ArrayPedidos As New ArrayList()
        Return ArrayPedidos
    End Function
End Module
