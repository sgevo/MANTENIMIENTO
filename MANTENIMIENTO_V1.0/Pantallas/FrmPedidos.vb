Public Class FrmPedidos




    Sub ConfigurarPantalla()

        Titulo.Top = 0
        Titulo.Left = 0
        Titulo.Width = Me.Width


        RCPedido.Left = 10
        RCPedido.Width = Me.Width - 20

        'RCPedido.Top = Titulo.Height
        'RCPedido.Height = Me.Height - RCPedido.Top - 20

    End Sub

    Private Sub FrmPedidos_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        ConfigurarPantalla()
    End Sub
End Class