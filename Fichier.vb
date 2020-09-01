Imports System.IO
Module Fichier

    Sub LectureGrille(ByRef grille(,) As Integer,
                      ByRef fichierCorrrect As Boolean)

        Dim Enreg As String = ""
        Dim TextSudoku As String
        Dim g As Integer

        fichierCorrrect = True

        Try
            Enreg = File.ReadAllText(Sudoku.myFileNname)
        Catch ex As Exception
            fichierCorrrect = False
        Finally
            fichierCorrrect = True
        End Try

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
                            grille(i, j) = CInt(TextSudoku(g).ToString)
                        Else
                            fichierCorrrect = False
                            Exit Sub
                        End If
                    End If
                Next
            Next

        End If

    End Sub


    Sub EcritureGrille(ByRef grille(,) As Integer, ByRef fichierCorrrect As Boolean)

        Dim filename As String
        Dim TextSudoku As String = ""

        For i = 0 To 8
            For j = 0 To 8
                If grille(i, j) = "0" Then
                    TextSudoku &= "."
                Else
                    TextSudoku &= grille(i, j).ToString
                End If
            Next
            TextSudoku &= vbCrLf
        Next
        filename = Sudoku.myFileNname

        Try
            File.WriteAllText(Sudoku.myFileNname, TextSudoku)
        Catch ex As Exception
            fichierCorrrect = False
        Finally
            fichierCorrrect = True
        End Try
    End Sub

End Module
