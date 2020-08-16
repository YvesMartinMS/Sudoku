Imports System.IO
Module Fichier
    'Const PATHFICHIER As String = "E:\Sudoku3D\Tripletnu002.sud"

    'Private Sub BT_ECRIRE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_ECRIRE.Click
    '    If Me.CHK_DEBUT.Checked Then
    '        'Depuis le début
    '        File.WriteAllText(PATHFICHIER, Me.TXT_ECRITURE.Text)
    '    Else
    '        'À la suite
    '        File.AppendAllText(PATHFICHIER, Me.TXT_ECRITURE.Text)
    '    End If

    'End Sub

    Sub LectureGrille(ByVal LectureGrille As String,
                      ByRef grille(,) As String,
                      ByRef fichierCorrrect As Boolean)

        Dim Enreg As String
        Dim TextSudoku As String
        Dim g As Integer

        fichierCorrrect = True
        Enreg = File.ReadAllText(Sudoku.myFileNname)

        If Enreg.Length <> 99 Then
            fichierCorrrect = False
        End If
        For i = 0 To 8
            If Mid(Enreg, (i * 11) + 10, 2) <> vbCrLf Then
                fichierCorrrect = False
                Exit Sub
            End If
        Next

        If fichierCorrrect Then

            TextSudoku = Mid(Enreg, 1, 9) & Mid(Enreg, 12, 9) & Mid(Enreg, 23, 9) & Mid(Enreg, 34, 9) & Mid(Enreg, 45, 9) & Mid(Enreg, 56, 9) & Mid(Enreg, 67, 9) & Mid(Enreg, 78, 9) & Mid(Enreg, 89, 9)

            For i = 0 To 8
                For j = 0 To 8
                    g = (i * 9) + j
                    If TextSudoku(g) = "." Then
                        grille(i, j) = "0"
                    Else
                        If IsNumeric(TextSudoku(g)) And TextSudoku(g) <> "0" Then
                            grille(i, j) = TextSudoku(g)
                        Else
                            fichierCorrrect = False
                            Exit Sub
                        End If
                    End If
                Next
            Next

        End If

    End Sub
End Module
