Public Class Solutions
    Private Sub Solution_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        For Each Solution As Sudoku.StrSolution In Sudoku.QSol
            Dim Element As New ListViewItem
            Element.Text = Solution.i
            Element.SubItems.Add(Solution.j)
            Element.SubItems.Add(Solution.v)
            Element.SubItems.Add(Solution.m)
            ListSolution.Items.Add(Element)
        Next
    End Sub

    Private Sub BT_Fermer_Click(sender As Object, e As EventArgs) Handles BT_Fermer.Click
        Me.Close()
    End Sub

    Private Sub ListSolution_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListSolution.SelectedIndexChanged

    End Sub
End Class