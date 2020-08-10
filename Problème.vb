Imports System.IO
Module Problème
    Sub Problème(ByVal typeGrille As String, ByRef NbVal As Integer, ByRef Grille(,) As String, ByRef Candidats(,,) As String)

        Dim i As Integer
        Dim j As Integer
        Dim g As Integer
        Dim TS As String = "                                                                                 "
        Dim TextSudoku As String = "                                                                                 "

        Dim QSol As Queue(Of Sudoku.StrSolution) = New Queue(Of Sudoku.StrSolution)
        Dim TSmp(80) As Sudoku.StrSmp
        Dim NbrSmp As Integer

        Dim Eval As Integer
        Dim EvalMin As Integer = 1
        Dim EvalMax As Integer = 999
        Dim enreg As String
        Dim previousCase As String
        Dim ok As Boolean = True

        NbVal = 81
        For i = 0 To 8
            For j = 0 To 8
                For k = 0 To 8
                    Candidats(i, j, k) = " "
                Next
            Next
        Next

        File.WriteAllText(Sudoku.PATHFICHIER, "")
        While NbVal > 30 ' And ok
            '     While (Eval < EvalMin Or Eval > EvalMax) And nbVal > 60

            ChoisitCase(Grille, NbVal, i, j)
            previousCase = Grille(i, j)
            Grille(i, j) = "0"
            NbVal -= 1

            CalculCandidats(Grille, Candidats)
            'If opk(i, j) > 1 Then
            '    ' Vérifier les solutionsmultiples
            'End If
            RechercheSolution(Grille, Candidats, QSol, NbrSmp, TSmp)
            If QSol.Count = 0 And NbrSmp = 0 Then
                MsgBox("???")
            Else
                If NbrSmp = 0 Then
                    ok = False
                    For Each Solution As Sudoku.StrSolution In QSol
                        Eval = Eval + Solution.b
                        enreg = NbVal & ";" & previousCase & ";" & Solution.i & ";" & Solution.j & ";" & Solution.v & ";" & Solution.m & ";" & vbCrLf
                        File.AppendAllText(Sudoku.PATHFICHIER, enreg)
                        If Solution.i = i And Solution.j = j And previousCase = Solution.v Then
                            ok = True
                        End If
                    Next
                Else
                    ' Vérifier les solutionsmultiples
                    MsgBox("Solution multiple possible ?")
                End If
            End If
            'If Not ok Then
            '    MsgBox(NbVal & " enlevé un " & previousCase & " en " & i & ";" & j & " nb Solutions : ;" & QSol.Count)
            'End If
        End While

    End Sub

    Sub ChoisitCase(ByVal Grille(,) As String, ByVal nbVal As Integer, ByRef i As Integer, ByRef j As Integer)

        Dim g As Integer
        Dim h As Integer
        g = GetRandom(0, nbVal)
        h = 0

        For i = 0 To 8
            For j = 0 To 8
                If Grille(i, j) <> "0" Then
                    If g = h Then
                        Exit Sub
                    End If
                    h += 1
                End If
            Next
        Next
    End Sub

    Sub EnpileGrille(ByVal Grille(,) As String, ByVal nbVal As Integer)

        For i = 0 To 8
            For j = 0 To 8
                Sudoku.pileGrilles(nbVal, i, j) = Grille(i, j)
            Next
        Next

    End Sub

    Sub ViderPileGrille()

        For h = 0 To 80
            For i = 0 To 8
                For j = 0 To 8
                    Sudoku.pileGrilles(h, i, j) = " "
                Next
            Next
        Next

    End Sub
End Module
