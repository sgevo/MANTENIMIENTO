Imports System.Data.OleDb
Module BDTrabajos
    Dim record As OleDbCommand
    Dim Consulta As OleDbDataReader

    Function GetTrabajos(Lista As AxXtremeSuiteControls.AxComboBox)
        'Carga combo con los trabajos
        Dim BDConexion As OleDbConnection

        Try
            BDConexion = BD.Conectar()

            record = New OleDbCommand("Select Id, Trabajo From Trabajos ORDER BY Trabajo;", BDConexion)

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
            MessageBox.Show(ex.Message.ToString(), "Error Trabajos")
        End Try

    End Function

    Function GetTrabajosTodos(Lista As AxXtremeSuiteControls.AxComboBox)
        'Carga combo con los trabajos y añado [TODOS]
        Dim BDConexion As OleDbConnection

        Try
            BDConexion = BD.Conectar()

            record = New OleDbCommand("Select Id, Trabajo From Trabajos ORDER BY Trabajo;", BDConexion)

            record.ExecuteNonQuery()

            Consulta = record.ExecuteReader
            Dim Index As Integer

            Lista.AddItem("[TODOS]", 0, 0)
            Index = 1
            While Consulta.Read()

                Lista.AddItem(Consulta(1).ToString, Index, Consulta(0).ToString)
                Index = Index + 1
            End While

            Consulta.Close()
            BD.Desconectar(BDConexion)
            Return Lista

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Error Trabajos")
        End Try

    End Function

    Function ObtenerUnTrabajo(IdTrabajo As Long) As Trabajo

        Dim objTrabajo As Trabajo

        Try

            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            record = New OleDbCommand("SELECT Id, Trabajo FROM Trabajos WHERE (Id=" & IdTrabajo & ")", BDConexion)
            record.ExecuteNonQuery()

            Consulta = record.ExecuteReader
            '            Debug.Print("consulta fin  " & DateTime.Now)
            While Consulta.Read()
                'Tengo que controlar si los campos numéricos son nulos

                objTrabajo = New Trabajo(Consulta(1).ToString)
            End While
            '            Debug.Print("Carga Array bd fin  " & DateTime.Now)
            Consulta.Close()
            BD.Desconectar(BDConexion)

            Return (objTrabajo)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (objTrabajo)
        End Try

    End Function

    Function ObtenerTodosTrabajos() As ArrayList

        Dim ArrayTrabajos As New ArrayList

        Try

            Dim BDConexion As OleDbConnection
            BDConexion = BD.Conectar()
            record = New OleDbCommand("SELECT Id, Trabajo FROM Trabajos ", BDConexion)
            record.ExecuteNonQuery()

            Consulta = record.ExecuteReader
            '            Debug.Print("consulta fin  " & DateTime.Now)
            While Consulta.Read()
                'Tengo que controlar si los campos numéricos son nulos

                ArrayTrabajos.Add(New Trabajo(Convert.ToInt32(Consulta(0).ToString), Consulta(1).ToString))
            End While
            '            Debug.Print("Carga Array bd fin  " & DateTime.Now)
            Consulta.Close()
            BD.Desconectar(BDConexion)

            Return (ArrayTrabajos)

        Catch ex As Exception

            MsgBox(ex.Message)
            Return (ArrayTrabajos)
        End Try

    End Function

End Module
