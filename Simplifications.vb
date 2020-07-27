Public Class Simplifications
    Private Sub Simplifications_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim _t As Integer
        For _t = 0 To Sudoku.NbrSmp - 1

            Dim Element As New ListViewItem
            Element.Text = Sudoku.TSmp(_t).motif
            Element.SubItems.Add(Sudoku.TSmp(_t).CR.i(0))
            Element.SubItems.Add(Sudoku.TSmp(_t).CR.j(0))
            Element.SubItems.Add(Sudoku.TSmp(_t).CR.v(0))
            Element.SubItems.Add(Sudoku.TSmp(_t).CR.i(1))
            Element.SubItems.Add(Sudoku.TSmp(_t).CR.j(1))
            Element.SubItems.Add(Sudoku.TSmp(_t).CR.v(1))
            Element.SubItems.Add(Sudoku.TSmp(_t).CR.i(2))
            Element.SubItems.Add(Sudoku.TSmp(_t).CR.j(2))
            Element.SubItems.Add(Sudoku.TSmp(_t).CR.v(2))
            Element.SubItems.Add("|")
            Element.SubItems.Add(Sudoku.TSmp(_t).CE.i(0))
            Element.SubItems.Add(Sudoku.TSmp(_t).CE.j(0))
            Element.SubItems.Add(Sudoku.TSmp(_t).CE.v(0))
            Element.SubItems.Add(Sudoku.TSmp(_t).CE.i(1))
            Element.SubItems.Add(Sudoku.TSmp(_t).CE.j(1))
            Element.SubItems.Add(Sudoku.TSmp(_t).CE.v(1))
            Element.SubItems.Add(Sudoku.TSmp(_t).CE.i(2))
            Element.SubItems.Add(Sudoku.TSmp(_t).CE.j(2))
            Element.SubItems.Add(Sudoku.TSmp(_t).CE.v(2))
            ListSimplifications.Items.Add(Element)
        Next
    End Sub

    Private Sub BT_Fermer_Smp_Click(sender As Object, e As EventArgs) Handles BT_Fermer_Smp.Click
        Me.Close()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListSimplifications.SelectedIndexChanged


    End Sub
End Class