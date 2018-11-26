Namespace DefinicionesMenus

    Public Class DEFMENU

        Public Const TAB_PRINCIPAL As Integer = 0
        Public Const TAB_MAESTROS As Integer = 1
        Public Const TAB_VENTAS As Integer = 2
        Public Const TAB_FACTURACION As Integer = 3
        Public Const TAB_ESTADISTICAS As Integer = 4
        Public Const TAB_INFORMES As Integer = 5

        Public Const GRUPO_PRINCIPAL As Integer = 100000
        Public Const PRINCIPAL_MANTENIMIENTO As Integer = 10
        Public Const PRINCIPAL_SALIR As Integer = 99

        Public Const GRUPO_MAESTROS As Integer = 110000
        Public Const MAESTROS_GRUPOS As Integer = 11
        Public Const MAESTROS_USUARIOS As Integer = 12
        Public Const MAESTROS_PRODUCTOS As Integer = 13
        Public Const MAESTROS_VERSIONES As Integer = 14
        Public Const MAESTROS_PACKS As Integer = 15
        Public Const MAESTROS_ASESORES As Integer = 16
        Public Const MAESTROS_CLIENTES As Integer = 17
        Public Const MAESTROS_PERMISOS As Integer = 18
        Public Const MAESTROS_FPAGO As Integer = 19





        Public Const GRUPO_VENTAS As Integer = 120000
        Public Const VENTAS_TARIFAS As Integer = 20
        Public Const VENTAS_TARIFAS_SALIR As Integer = 2099

        Public Const VENTAS_PEDIDOS_FICHERO As Integer = 21
        Public Const VENTAS_PEDIDOS_FICHERO_AÑADIR As Integer = 2101
        Public Const VENTAS_PEDIDOS_FICHERO_MODIFICAR As Integer = 2102
        Public Const VENTAS_PEDIDOS_FICHERO_ELIMINAR As Integer = 2103
        Public Const VENTAS_PEDIDOS_FICHERO_SALIR As Integer = 2199


        Public Const VENTAS_FACTURAS_FICHERO As Integer = 22
        Public Const VENTAS_VENCIMIENTOS As Integer = 23
        Public Const VENTAS_REMESAS As Integer = 24

        Public Const GRUPO_FACTURAR As Integer = 130000
        Public Const FACTURAR_PEDIDOS As Integer = 25
        Public Const FACTURAR_MANTES As Integer = 26
        Public Const FACTURAR_RECIBOS As Integer = 27

        Public Const GRUPO_ESTADIS As Integer = 140000
        Public Const ESTADIS_LLAMADAS As Integer = 28
        Public Const ESTADIS_EOAF As Integer = 29
        Public Const ESTADIS_VENTAS As Integer = 30
        Public Const ESTADIS_MOROSOS As Integer = 31

        Public Const GRUPO_INFORMES As Integer = 150000
        Public Const INFORMES_ETITRANSPORTE As Integer = 32
        Public Const INFORMES_ETICLIENTES As Integer = 33
        Public Const INFORMES_CARTASMANTE As Integer = 34

        ''' '''''''''''''''''''

        Public Const GRUPO_MAESTROS_PRODUCTOS As Integer = 160000
        Public Const MAESTROS_PRODUCTOS_NUEVO As Integer = 1300
        Public Const MAESTROS_PRODUCTOS_ELIMINAR As Integer = 1301
        Public Const MAESTROS_PRODUCTOS_IMPRIMIR As Integer = 1302
        Public Const MAESTROS_PRODUCTOS_SALIR As Integer = 1399

        Public Const GRUPO_MAESTROS_VERSIONES As Integer = 170000
        Public Const MAESTROS_VERSIONES_NUEVO As Integer = 1400
        Public Const MAESTROS_VERSIONES_ELIMINAR As Integer = 1401
        Public Const MAESTROS_VERSIONES_IMPRIMIR As Integer = 1402
        Public Const MAESTROS_VERSIONES_SALIR As Integer = 1499

        Public Const GRUPO_MAESTROS_PACKS As Integer = 180000
        Public Const MAESTROS_PACKS_NUEVO As Integer = 1500
        Public Const MAESTROS_PACKS_ELIMINAR As Integer = 1501
        Public Const MAESTROS_PACKS_IMPRIMIR As Integer = 1502
        Public Const MAESTROS_PACKS_SALIR As Integer = 1599

        Public Const GRUPO_MAESTROS_GRUPOS As Integer = 190000
        Public Const MAESTROS_GRUPOS_NUEVO As Integer = 1100
        Public Const MAESTROS_GRUPOS_ELIMINAR As Integer = 1101
        Public Const MAESTROS_GRUPOS_IMPRIMIR As Integer = 1102
        Public Const MAESTROS_GRUPOS_SALIR As Integer = 1199

        Public Const GRUPO_MAESTROS_USUARIOS As Integer = 200000
        Public Const MAESTROS_USUARIOS_NUEVO As Integer = 1200
        Public Const MAESTROS_USUARIOS_ELIMINAR As Integer = 1201
        Public Const MAESTROS_USUARIOS_IMPRIMIR As Integer = 1202
        Public Const MAESTROS_USUARIOS_SALIR As Integer = 1299

        Public Const GRUPO_MAESTROS_PERMISOS As Integer = 210000
        Public Const MAESTROS_PERMISOS_IMPRIMIR As Integer = 1800
        Public Const MAESTROS_PERMISOS_SALIR As Integer = 1899

        Public Const GRUPO_MAESTROS_CLIENTES As Integer = 220000
        Public Const MAESTROS_CLIENTES_NUEVO As Integer = 1700
        Public Const MAESTROS_CLIENTES_ELIMINAR As Integer = 1701
        Public Const MAESTROS_CLIENTES_IMPRIMIR As Integer = 1702
        Public Const MAESTROS_CLIENTES_MODIFICAR As Integer = 1703
        Public Const MAESTROS_CLIENTES_FILTROFILA As Integer = 1704
        Public Const MAESTROS_CLIENTES_FILTROAVANZADO As Integer = 1705
        Public Const MAESTROS_CLIENTES_QUITARFILTRO As Integer = 1706
        Public Const MAESTROS_CLIENTES_VISTAS As Integer = 1707
        Public Const MAESTROS_CLIENTES_SALIR As Integer = 1799

        Public Const MAESTROS_CLIENTES_FICHA As Integer = 17000
        Public Const MAESTROS_CLIENTES_FICHA_NUEVO As Integer = 17001
        Public Const MAESTROS_CLIENTES_FICHA_GUARDAR As Integer = 17002
        Public Const MAESTROS_CLIENTES_FICHA_ELIMINAR As Integer = 17003
        Public Const MAESTROS_CLIENTES_FICHA_SALIR As Integer = 17099

        Public Const GRUPO_PRINCIPAL_MANTENIMIENTO As Integer = 230000
        Public Const PRINCIPAL_MANTENIMIENTO_IMPRIMIR As Integer = 1000
        Public Const PRINCIPAL_MANTENIMIENTO_SALIR As Integer = 1099

        Public Const GRUPO_ESTADIS_VENTAS As Integer = 240000
        Public Const ESTADIS_VENTAS_IMPRIMIR As Integer = 3000
        Public Const ESTADIS_VENTAS_EXCEL_CLIENTES As Integer = 3001
        Public Const ESTADIS_VENTAS_EXCEL_VENTAS As Integer = 3002
        Public Const ESTADIS_VENTAS_SALIR As Integer = 3099

        Public Const GRUPO_INFORMES_CARTASMANTE As Integer = 250000
        Public Const INFORMES_CARTASMANTE_IMPRIMIR As Integer = 3400
        Public Const INFORMES_CARTASMANTE_EXCEL_CLIENTES As Integer = 3401
        Public Const INFORMES_CARTASMANTE_SALIR As Integer = 3499

        Public Const GRUPO_MAESTROS_FPAGO As Integer = 260000
        Public Const MAESTROS_FPAGO_NUEVO As Integer = 1900
        Public Const MAESTROS_FPAGO_ELIMINAR As Integer = 1901
        Public Const MAESTROS_FPAGO_IMPRIMIR As Integer = 1902
        Public Const MAESTROS_FPAGO_SALIR As Integer = 1999

        Public Const STYLEBLUE As Integer = 3000
        Public Const STYLEBLACK As Integer = 3001
        Public Const STYLEAQUA As Integer = 3002
        Public Const RTL As Integer = 3003
        Public Const ANIMATION As Integer = 3004
        Public Const STYLESILVER As Integer = 3005
        Public Const STYLESCENIC As Integer = 3006
        Public Const STYLEOFFICE2010SILVER As Integer = 3007
        Public Const STYLEOFFCIE2010BLUE As Integer = 3008
        Public Const STYLEOFFCIE2010BLACK As Integer = 3009
        Public Const STYLEOFFCIE2013WHITE As Integer = 3010
        Public Const STYLESYSTEM As Integer = 3011


        'Public Const FSHIFT As Integer = 4
        'Public Const FCONTROL As Integer = 8
        'Public Const FALT As Integer = 16

        'Public Const VK_BACK As Integer = &H8
        'Public Const VK_TAB As Integer = &H9
        'Public Const VK_ESCAPE As Integer = &H1B
        'Public Const VK_SPACE As Integer = &H20
        'Public Const VK_PRIOR As Integer = &H21
        'Public Const VK_NEXT As Integer = &H22
        'Public Const VK_END As Integer = &H23
        'Public Const VK_HOME As Integer = &H24
        'Public Const VK_LEFT As Integer = &H25
        'Public Const VK_UP As Integer = &H26
        'Public Const VK_RIGHT As Integer = &H27
        'Public Const VK_DOWN As Integer = &H28
        'Public Const VK_INSERT As Integer = &H2D
        'Public Const VK_DELETE As Integer = &H2E
        'Public Const VK_MULTIPLY As Integer = &H6A
        'Public Const VK_ADD As Integer = &H6B
        'Public Const VK_SEPARATOR As Integer = &H6C
        'Public Const VK_SUBTRACT As Integer = &H6D
        'Public Const VK_DECIMAL As Integer = &H6E
        'Public Const VK_DIVIDE As Integer = &H6F
        'Public Const VK_F1 As Integer = &H70
        'Public Const VK_F2 As Integer = &H71
        'Public Const VK_F3 As Integer = &H72
        'Public Const VK_F4 As Integer = &H73
        'Public Const VK_F5 As Integer = &H74
        'Public Const VK_F6 As Integer = &H75
        'Public Const VK_F7 As Integer = &H76
        'Public Const VK_F8 As Integer = &H77
        'Public Const VK_F9 As Integer = &H78
        'Public Const VK_F10 As Integer = &H79
        'Public Const VK_F11 As Integer = &H7A
        'Public Const VK_F12 As Integer = &H7B
    End Class
End Namespace 'end of root namespace
