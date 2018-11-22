Module Formatos

    Public FormatoPrecio As String
    Public FormatoCantidad As String
    Public Const FormatoImporte = "#,###,###,##0.#0;;;0.#0"
    Public Const FormatoPorcentaje = "##0.#0;;;0.#0"

    Sub FormatoTipoCantidad(DecimalesCant As Byte)

        Dim DesdeComa As String

        If DecimalesCant > 0 Then
            DesdeComa = New String("#", DecimalesCant - 1) & "0"
            FormatoCantidad = "#,##0." & DesdeComa & ";;;" & "0." & DesdeComa
            ' FormatoCantidadLL = "---,---,--&." & String(DecimalesCant, "-")
        Else
            FormatoCantidad = "#,##0" & ";;;" & "0"
            '  FormatoCantidadLL = "---,---,---"
        End If

    End Sub

    Sub FormatoTipoPrecio(DecimalesPrecio As Byte)

        Dim DesdeComa As String

        If DecimalesPrecio > 0 Then
            DesdeComa = New String("#", DecimalesPrecio - 1) & "0"
            FormatoPrecio = "#,##0." & DesdeComa & ";;;" & "0." & DesdeComa
            '  FormatoPrecioLL = "---,---,--&." & String(DecimalesPrecio, "-")
        Else
            FormatoPrecio = "#,##0" & ";;;" & "0"
            ' FormatoPrecioLL = "---,---,---"
        End If

    End Sub

    Sub Retorno(KeyAscii As Long)

        Select Case KeyAscii
            Case 10
                SendKeys.Send("{TAB}")
                KeyAscii = 0
            Case 13
                SendKeys.Send("{TAB}")
                KeyAscii = 0
        End Select

    End Sub

End Module
