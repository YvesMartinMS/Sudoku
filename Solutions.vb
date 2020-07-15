Public Class Solutions
    Private Sub Solution_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i As Integer

        For i = 0 To Sudoku.NbSol - 1
            Dim Element As New ListViewItem
            Element.Text = Sudoku.TabSolution(i).i
            Element.SubItems.Add(Sudoku.TabSolution(i).j)
            Element.SubItems.Add(Sudoku.TabSolution(i).k)
            Element.SubItems.Add(Sudoku.TabSolution(i).m)
            ListSolution.Items.Add(Element)
        Next
    End Sub

    Private Sub BT_Fermer_Click(sender As Object, e As EventArgs) Handles BT_Fermer.Click
        Me.Close()
    End Sub

End Class