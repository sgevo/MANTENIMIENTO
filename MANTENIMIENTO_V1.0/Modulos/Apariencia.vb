Imports XtremeCommandBars
Imports XtremeReportControl
Imports XtremeShortcutBar
Imports XtremeSuiteControls

Module Aparicencia

    Dim xtpAppearanceResource As Long = 7
    Dim xtpSeparatorAppearanceResource As Long = 6
    Dim xtpCalendarThemeResource As Long = 4
    Dim xtpTabAppearancePropertyPageAccess2007 As Long = 11
    Dim xtpColumnResource As Long = 4
    Dim xtpGridSolid As Long = 4
    Dim xtpReportFreezeColsDividerBold As Long = 2
    Dim xtpReportScrollModeSmooth As Long = 2
    Dim ThemeResource As Long = 10
    Dim xtpReportThemeResource As Long = 10
    Dim xtpCustomBeforeDrawRow As Long = 4
    Dim xtpGridThemeResource As Long = 8
    Dim xtpShortcutThemeResource As Long = 3

    Public Sub AplicaEstiloControl(ctrl As Object)

        If TypeOf ctrl Is XtremeSuiteControls.PushButton Then
            ctrl.Appearance = xtpAppearanceResource
        ElseIf TypeOf ctrl Is XtremeSuiteControls.RadioButton Then
            ctrl.Appearance = xtpAppearanceResource
        ElseIf TypeOf ctrl Is XtremeSuiteControls.ComboBox Then
            ctrl.Appearance = xtpAppearanceResource
        ElseIf TypeOf ctrl Is XtremeSuiteControls.TreeView Then
            ctrl.Appearance = xtpAppearanceResource
        ElseIf TypeOf ctrl Is XtremeSuiteControls.CheckBox Then
            ctrl.Appearance = xtpAppearanceResource
        ElseIf TypeOf ctrl Is XtremeSuiteControls.FlatEdit Then
            ctrl.Appearance = xtpAppearanceResource

        ElseIf TypeOf ctrl Is XtremeCommandBars.BackstageSeparator Then
            ctrl.Appearance = xtpSeparatorAppearanceResource
        ElseIf TypeOf ctrl Is XtremeCommandBars.CommandBars Then
            ctrl.VisualTheme = MDIPrincipal.CommandBars.VisualTheme
            ctrl.RecalcLayout

            'ElseIf TypeOf ctrl Is XtremeCalendarControl.DatePicker Then
            '    ctrl.VisualTheme = xtpCalendarThemeResource
            'ElseIf TypeOf ctrl Is XtremeDockingPane.DockingPane Then
            '    ctrl.VisualTheme = ThemeResource
            '    ctrl.PanelPaintManager.Appearance = xtpTabAppearancePropertyPageAccess2007
            '    ctrl.RecalcLayout

        ElseIf TypeOf ctrl Is XtremeReportControl.ReportControl Then
            ctrl.VisualTheme = xtpReportThemeResource
            ctrl.PaintManager.ColumnStyle = xtpColumnResource
            ctrl.PaintManager.CaptionFont.Name = "Tahoma"
            ctrl.PaintManager.CaptionFont.Bold = True
            ctrl.PaintManager.TextFont.Name = "Tahoma"
            ctrl.PaintManager.NoGroupByText = "Suba aquí las cabeceras de las columnas por las que quiera agrupar."
            ctrl.PaintManager.NoFieldsAvailableText = "No hay campos disponibles"
            ctrl.PaintManager.NoItemsText = "No hay elementos que mostrar"
            ctrl.PaintManager.HorizontalGridStyle = xtpGridSolid
            ctrl.PaintManager.VerticalGridStyle = xtpGridSolid
            ctrl.PaintManager.UseAlternativeBackground = True
            ctrl.PaintManager.AlternativeBackgroundColor = RGB(242, 242, 242)
            ctrl.PaintManager.FreezeColsDividerStyle = xtpReportFreezeColsDividerBold
            ctrl.PaintManager.FreezeColsDividerColor = RGB(0, 0, 0)
            ctrl.FullColumnScrolling = True
            ctrl.AutoColumnSizing = False
            ctrl.ScrollModeH = xtpReportScrollModeSmooth
            ctrl.ScrollModeV = xtpReportScrollModeSmooth
            ctrl.SetCustomDraw(xtpCustomBeforeDrawRow)

            'ElseIf TypeOf ctrl Is XtremePropertyGrid.PropertyGrid Then
            '    ctrl.VisualTheme = xtpGridThemeResource

        ElseIf TypeOf ctrl Is XtremeShortcutBar.ShortcutCaption Then
            ctrl.VisualTheme = xtpShortcutThemeResource

        ElseIf TypeOf ctrl Is XtremeSuiteControls.GroupBox Then
            ctrl.Appearance = xtpAppearanceResource

        End If

    End Sub

End Module

