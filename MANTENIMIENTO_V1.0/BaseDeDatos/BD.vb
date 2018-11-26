
Imports System.Data.OleDb
Imports System.Data.Odbc
Imports System

Module BD

    Function Conectar() As OleDbConnection

        Dim BDConexion As OleDbConnection
        Dim connectionString As String
        '        connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Y:\Tempo\MANTENIMIENTO EVO\Datos\MantenimientoEVO.mdb"
        connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Yoli\OneDrive\Documents\MantenimientoEVO.mdb"
        'connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\PROYECTOS MANTENIMIENTO\MANTENIMIENTO\Datos\MantenimientoEVO.mdb"
        BDConexion = New OleDbConnection(connectionString)

        BDConexion.Open()

        Return BDConexion
    End Function

    Function ConectarOdbc() As OdbcConnection

        Dim BDConexion As OdbcConnection
        'Dim myCommand As OleDbCommand
        Dim connectionString As String
        'Dim query As String
        'Debug.Print("Con01:" & Now)
        connectionString = "Driver={Microsoft Access Driver (*.mdb)};DBQ=Y:\Tempo\MANTENIMIENTO EVO\Datos\MantenimientoEVO.mdb"
        'Debug.Print("Con02:" & Now)
        BDConexion = New OdbcConnection(connectionString)

        BDConexion.Open()

        'Debug.Print("Con03:" & Now)
        Return BDConexion
    End Function

    Sub Desconectar(BDConexion As OleDbConnection)
        BDConexion.Close()
    End Sub

End Module




'        Dim myConnection As OleDbConnection
'13
'        Dim myCommand As OleDbCommand
'14
'        Dim connectionString As String
'15
'        Dim query As String
'16
'        Try
'17

'18
'            connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=d:\\test.mdb"
'19
'            myConnection = New OleDbConnection(connectionString)
'20
'            myConnection.Open()
'21
'            query = "insert into tt (t) VALUES (" & txt.text & ")"
'22
'            myCommand = New OleDbCommand()
'23

'24
'            myCommand.Connection = myConnection
'25
'            myCommand.CommandText = query
'26
'            bnmyCommand.ExecuteNonQuery()
'27

'28
'            myConnection.Close()
'29
'        Catch ex As Exception
'30
'            'MsgBox(ex.Message)
'31
'        End Try

'Otro coso
' Using cmd = new OleDbCommand("SELECT * FROM moviedb WHERE Title Like ?", con)Using cmd = new OleDbCommand("SELECT * FROM moviedb WHERE Title Like ?", con)

