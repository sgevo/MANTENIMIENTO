Imports XtremeReportControl
Imports AxXtremeReportControl

Module RC

    Function SiguienteColumnaEditable(RC As AxXtremeReportControl.AxReportControl, Columna As Integer, esPie As Boolean) As Integer
        'Para considerar que es no editable se tiene en cuenta la comumna no el item

        Dim x As Integer

        'For x = 0 To RCIvas.Columns.Count - 1
        '    Debug.Print("Columna " & RCIvas.Columns(x).Index)
        '    Debug.Print("Find " & RCIvas.Columns.Find(x).Index)
        'Next

        For x = 0 To RC.Columns.Count - 1

            If x > Columna Then
                If RC.Columns(x).Visible = True Then
                    If RC.Columns(x).Editable = True Then
                        Return x
                        Exit Function
                    End If
                End If
            End If
        Next

        Return Columna

    End Function

    Function AnteriorColumnaEditable(RC As AxXtremeReportControl.AxReportControl, Columna As Integer, esPie As Boolean) As Integer
        'Para considerar que es no editable se tiene en cuenta la comumna no el item

        Dim x As Integer

        'For x = 0 To RCIvas.Columns.Count - 1
        '    Debug.Print("Columna " & RCIvas.Columns(x).Index)
        '    Debug.Print("Find " & RCIvas.Columns.Find(x).Index)
        'Next

        For x = RC.Columns.Count To 0 Step -1

            If x < Columna Then
                If RC.Columns(x).Visible = True Then
                    If RC.Columns(x).Editable = True Then

                        Return x
                        Exit Function
                    End If
                End If
            End If
        Next

        Return Columna

    End Function

    Function SiguienteFilaEditable(RC As AxXtremeReportControl.AxReportControl, fila As Integer) As Integer

        For x = 0 To RC.Rows.Count - 1

            If x > fila Then

                If RC.Rows.Row(x).Record.Item(2).Editable = True Then
                    Return x
                    Exit Function

                End If
            End If
        Next

        Return fila

    End Function

    Function AnteriorFilaEditable(RC As AxXtremeReportControl.AxReportControl, fila As Integer) As Integer
        'Para considerar que es no editable se tiene en cuenta la comumna no el item

        Dim x As Integer

        For x = RC.Rows.Count To 0 Step -1

            If x < fila Then

                If RC.Rows.Row(x).Record.Item(2).Editable = True Then

                    Return x
                    Exit Function
                End If

            End If
        Next

        Return fila

    End Function

    Sub setValor(Report12 As AxXtremeReportControl.AxReportControl, Campo As Integer, Valor As Object)

        Dim xReportRow As ReportRecord


        Dim filas As ReportRecords
        Dim index As Integer
        Dim Continuar As Boolean
        filas = Report12.Records
        index = 0
        Continuar = True
        While Continuar
            xReportRow = filas(index)
            If xReportRow.Childs.Count <> 0 Then
                index = 0
                filas = xReportRow.Childs(index).Records
            Else
                index = index + 1
                If xReportRow.ParentRecord.Childs.Count = index Then
                    If Convert.ToInt32(xReportRow.Item(0).Value) = Campo Then
                        If xReportRow.Item(2).HasCheckbox = True Then
                            xReportRow.Item(2).Checked = CBool(Valor)
                        Else
                            xReportRow.Item(2).Value = Valor
                        End If
                        Continuar = False
                    End If

                    filas = xReportRow.ParentRecord.Records
                    index = xReportRow.ParentRecord.Index + 1

                Else
                    If Convert.ToInt32(xReportRow.Item(0).Value) = Campo Then
                        If xReportRow.Item(2).HasCheckbox = True Then
                            xReportRow.Item(2).Checked = CBool(Valor)
                        Else
                            xReportRow.Item(2).Value = Valor
                        End If

                        Continuar = False
                    End If


                End If

            End If
        End While

    End Sub


    Function getValor(Report12 As AxXtremeReportControl.AxReportControl, Campo As Integer) As String

        Dim xReportRow As ReportRecord


        Dim filas As ReportRecords
        Dim index As Integer
        Dim Continuar As Boolean
        filas = Report12.Records
        index = 0
        Continuar = True
        While Continuar
            xReportRow = filas(index)
            If xReportRow.Childs.Count <> 0 Then
                index = 0
                filas = xReportRow.Childs(index).Records
            Else
                index = index + 1
                If xReportRow.ParentRecord.Childs.Count = index Then
                    If Convert.ToInt32(xReportRow.Item(0).Value) = Campo Then
                        If xReportRow.Item(2).HasCheckbox = True Then
                            Return xReportRow.Item(2).Checked
                        Else
                            Return xReportRow.Item(2).Value
                        End If
                        Continuar = False
                    End If

                    filas = xReportRow.ParentRecord.Records
                    index = xReportRow.ParentRecord.Index + 1

                Else
                    If Convert.ToInt32(xReportRow.Item(0).Value) = Campo Then
                        If xReportRow.Item(2).HasCheckbox = True Then
                            Return xReportRow.Item(2).Checked
                        Else
                            Return xReportRow.Item(2).Value
                        End If

                        Continuar = False
                    End If


                End If

            End If
        End While

    End Function


    Public Sub ExportToExcel(rpc As AxReportControl, Optional ExportOnlySelected As Boolean = False, Optional NumerCols As String = vbNullString)
        'En esta rutina se puede decir que solo saque los registros seleccionados con ExportOnlySelected y
        'le podemos decir las columnas que tiene que formatear como numéricas, se pueden poner varias como "001,005,008"
        'Las columnas hay que ponerlas con 3 digitos para que no encuentre el 2 dentro del 21 por ejemplo.

        Dim record As ReportRecord
        Dim MiRow As ReportRow

        Dim GroupRow As ReportGroupRow
        Dim MiTitulo As String
        'Dim xlsApp As Excel.Application
        'Dim xlsWSheet As Excel.Worksheet
        Dim i As Long, j As Long, x As Long, z As Long, ZR As Long


        Dim xlsApp As Object
        Dim xlsBook As Object
        Dim xlsWSheet As Object

        On Error Resume Next

        ' Create the WorkSheet

        xlsApp = CreateObject("Excel.Application")
        xlsBook = xlsApp.Workbooks.Add
        xlsWSheet = xlsBook.Worksheets(1)


        With xlsWSheet

            ' Export Data from the ReportControl
            If ExportOnlySelected Then 'solo cogería los registros seleccionados
                '-----------> esto hay que retocarlo según está en el "else", si se va a utilizar <------------
                '            x = 1
                '
                '            For i = 0 To rpc.Records.Count - 1
                '                If rpc.Rows(i).Selected Then
                '                    x = x + 1
                '                    Z = 1
                '
                '                    Set Record = rpc.Records.Record(i)
                '                    For j = 1 To rpc.Columns.Count
                '                        If Not InStr(NumerCols, CStr(j - 1), ",") Then
                '                            .Cells(x, Z) = Record.Item(j - 1).Value
                '                            .Cells(x, Z) = IIf(Len(Record.Item(j - 1).Value) = 6, "01/" & Format$(CStr(Record.Item(j - 1).Value), "mm/yyyy"), CStr(Record.Item(j - 1).Value))
                '
                '                            If Trim$(CStr(Record.Item(j - 1).Value)) = vbNullString And Record.Item(j - 1).Icon > -1 Then
                '                                .Cells(x, Z) = CStr(Record.Item(j - 1).Tag)
                '                            End If
                '
                '                            ' Format the Cell, if the value is a number then format as such otherwise format as text
                '                            Select Case IsNumeric(Record.Item(j - 1).Value)
                '                                Case False
                '                                    Select Case IsDate(Record.Item(j - 1).Value)
                '                                        Case False
                '                                            .Cells(x, Z).NumberFormat = "@"
                '                                        Case True
                '                                            If Len(Record.Item(j - 1).Value) = 6 Then
                '                                                .Cells(i + 2, Z).NumberFormat = "@"
                '                                                .Cells(i + 2, Z) = CStr(Record.Item(j - 1).Value)
                '                                            Else
                '                                                .Cells(i + 2, Z).NumberFormat = "dd/mm/yyyy"
                '                                                .Cells(i + 2, Z) = Format$(.Cells(i + 2, Z), "dd/mm/yyyy")
                '                                            End If
                '                                    End Select
                '                                Case True
                '                                    .Cells(x, Z).NumberFormat = "#,##0"
                '                            End Select
                '                        End If
                '
                '                        Z = Z + 1
                '                    Next
                '                End If
                '            Next
            Else
                ZR = 1
                'For i = 0 To rpc.Records.Count - 1
                For i = 0 To rpc.Rows.Count - 1
                    z = 1
                    'Set Record = rpc.Records.Record(i)
                    If rpc.Rows.Row(i).GroupRow Then 'es una agrupación de Row

                        GroupRow = rpc.Rows(i)

                        'If GroupRow.GroupFormula = "" Then
                        'en GroupRow.GroupCaption tengo la descripción del grupo y los valores de la fórmula entre []
                        'Hay que quitarlos
                        If InStr(GroupRow.GroupCaption, "[") = 0 Then
                            MiTitulo = GroupRow.GroupCaption
                        Else
                            MiTitulo = Left$(GroupRow.GroupCaption, InStr(GroupRow.GroupCaption, "[") - 1)
                        End If
                        .Cells(ZR + 1, 1) = MiTitulo
                        ZR = ZR + 1
                    Else
                        record = rpc.Rows.Row(i).Record
                        If rpc.Rows.Row(i).Record.Visible = True Then
                            For j = 0 To rpc.Columns.Count - 1
                                If rpc.Columns(j).Visible = True Then
                                    If InStr(NumerCols, Right$("000" & CStr(rpc.Columns(j).ItemIndex), 3)) Then

                                        ' Format the Cell, if the value is a number then format as such otherwise format as text
                                        Select Case IsNumeric(record.Item(rpc.Columns(j).ItemIndex).Value)
                                            Case False
                                                '''
                                            Case True
                                                .Cells(ZR + 1, z) = CDbl((record.Item(rpc.Columns(j).ItemIndex).Value))

                                                If Trim$(CStr(record.Item(rpc.Columns(j).ItemIndex).Value)) = vbNullString And record.Item(rpc.Columns(j).ItemIndex).Icon > -1 Then
                                                    .Cells(ZR + 1, z) = CStr(record.Item(rpc.Columns(j).ItemIndex).Tag)
                                                End If
                                                .Cells(ZR + 1, z).NumberFormat = "#,##0.00"
                                        End Select
                                    Else
                                        .Cells(ZR + 1, z) = (record.Item(rpc.Columns(j).ItemIndex).Value)

                                        If Trim$(CStr(record.Item(rpc.Columns(j).ItemIndex).Value)) = vbNullString And record.Item(rpc.Columns(j).ItemIndex).Icon > -1 Then
                                            .Cells(ZR + 1, z) = CStr(record.Item(rpc.Columns(j).ItemIndex).Tag)
                                        End If                                ' Format the Cell, if the value is a number then format as such otherwise format as text
                                        Select Case IsNumeric(record.Item(rpc.Columns(j).ItemIndex).Value)
                                            Case False
                                                Select Case IsDate(record.Item(rpc.Columns(j).ItemIndex).Value)
                                                    Case False
                                                        .Cells(ZR + 1, z).NumberFormat = "@"
                                                    Case True
                                                        If Len(record.Item(rpc.Columns(j).ItemIndex).Value) = 6 Then
                                                            .Cells(ZR + 1, z).NumberFormat = "@"
                                                            .Cells(ZR + 1, z) = CStr(record.Item(rpc.Columns(j).ItemIndex).Value)
                                                        Else
                                                            If Len(Trim(record.Item(rpc.Columns(j).ItemIndex).Value)) > 7 Then


                                                                .Cells(ZR + 1, z).NumberFormat = "dd/mm/yyyy"
                                                                '.Cells(ZR + 1, Z) = Format$(.Cells(I + 2, Z), "dd/mm/yyyy")
                                                                '  .Cells(ZR + 1, Z) = Format$(.Cells(ZR + 1, Z), "dd/mm/yyyy")
                                                            End If
                                                        End If
                                                End Select
                                            Case True
                                                '''
                                        End Select

                                    End If

                                    z = z + 1
                                End If 'columna visible
                            Next j 'J
                            ZR = ZR + 1
                        End If 'Registro visible
                    End If 'Agrupación de Row
                Next i 'i
            End If
            'DoEvents
            ' Format the Columns
            z = 0
            For i = 0 To rpc.Columns.Count - 1
                If rpc.Columns(i).Visible = True Then

                    ' Export ColumnHeaders & set as bold
                    .Cells(1, z + 1) = rpc.Columns(i).Caption
                    .Cells(1, z + 1).Font.Bold = True

                    ' Autofit column headers
                    .Columns(z + 1).AutoFit

                    ' Format the Column Alignments
                    Select Case rpc.Columns.Column(i).Alignment
                        'Case xtpAlignmentCenter
                        '    .Columns(z + 1).HorizontalAlignment = xlCenter
                        'Case xtpAlignmentRight
                        '    .Columns(z + 1).HorizontalAlignment = xlRight
                        'Case Else
                        '   .Columns(z + 1).HorizontalAlignment = xlLeft
                    End Select

                    z = z + 1
                End If
            Next

            ' Move to first cell to unselect
            .Range("A1").Select
        End With

        ' Show the Excel Window
        With xlsApp
            .ActiveWindow.SplitRow = 1
            .Windows(1).FreezePanes = True
            .visible = True
        End With

        xlsApp = Nothing
        xlsWSheet = Nothing
    End Sub

    Public Sub OrdenarReport(RC As AxXtremeReportControl.AxReportControl, columna As ReportColumn, SORT_BY_COLUMN As Byte)

        If columna Is Nothing Then Exit Sub

        If SORT_BY_COLUMN <> 0 Then
            If SORT_BY_COLUMN = 1 Then
                columna.SortAscending = True
            Else
                columna.SortAscending = False
            End If
            RC.SortOrder.DeleteAll()
            RC.SortOrder.Add(RC.Columns.Find(columna.ItemIndex))

            RC.Populate()
            RC.Navigator.MoveFirstRow()
            RC.Navigator.MoveFirstVisibleRow()
            RC.Redraw()
        End If

    End Sub

    Sub LimpiarLineafiltro(RC As AxXtremeReportControl.AxReportControl, columna As Integer)

        Dim i As Integer
        Dim Record As ReportRecord

        Record = RC.HeaderRecords(0)

        For i = 0 To Record.ItemCount - 1
            If columna <> i Then
                Record.Item(i).Value = ""
            End If
        Next

        'Report.Populate
        RC.PopulateHeaderRows()

    End Sub


    Sub Filtrar(RC As AxXtremeReportControl.AxReportControl, nColIdx As Integer)
        Dim Record As ReportRecord

        Dim Value As String
        Dim FilterValue As String

        FilterValue = RC.HeaderRecords(0).Item(nColIdx).Value
        For i = 0 To RC.Records.Count - 1

            Record = RC.Records(i)

            If Record.Item(nColIdx).HasCheckbox Then
                'If FilterValue = "Sí" Then FilterValue2 = 1 Else FilterValue2 = 0
                'Value = record.Item(nColIdx).CheckboxState
                'If Value <> CDbl(FilterValue2) Then
                '    record.visible = False
                ' End If
            Else
                Value = Record.Item(nColIdx).Value
                If InStr(UCase(CStr(Value)), UCase(FilterValue)) = 0 Then
                    Record.Visible = False
                Else
                    Record.Visible = True
                End If
            End If

        Next

    End Sub

    Sub FiltrarMes(RC As AxXtremeReportControl.AxReportControl, columna As Integer, indice As Integer)

        For i = 0 To RC.Records.Count - 1
            If Convert.ToInt32(RC.Records(i).Item(columna).Value) = indice Then
                RC.Records(i).Visible = True
            Else
                RC.Records(i).Visible = False
            End If
        Next
        RC.Populate()
    End Sub
End Module
