Public Class Simplifications
    Private Sub BT_Fermer_Smp_Click(sender As Object, e As EventArgs) Handles BT_Fermer_Smp.Click
        Me.Close()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListSimplifications.SelectedIndexChanged
        For Each Smp As Sudoku.StrSmp In Sudoku.Qsmp
            Dim Element As New ListViewItem
            Element.Text = Smp.m
            'Dim m As String 'Motif
            'Dim act As Boolean
            ''candidats retenus (ReDim 2) 
            'Dim nr As Integer 'nombre de cancidats éliminés
            'Dim cri() As Integer
            'Dim crj() As Integer
            'Dim crk() As Integer
            'Dim crv() As String 'Valeur
            ''candidats éliminés (ReDim 20)
            'Dim ne As Integer 'nombre de cancidats éliminés
            'Dim cei() As Integer
            'Dim cej() As Integer
            'Dim cek() As Integer
            'Dim cev() As String 'Valeur
            ListSimplifications.Items.Add(Element)
        Next
    End Sub
End Class