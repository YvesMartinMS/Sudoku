Imports System.IO
Module Problème
    Sub Problème(ByVal typeGrille As String,
                 ByRef NbVal As Integer,
                 ByRef Grille(,) As String,
                 ByRef Candidats(,,) As String)

        Dim i As Integer
        Dim j As Integer
        Dim v As String
        Dim g As Integer
        Dim NbSol As Integer

        Dim QSol As Queue(Of Sudoku.StrSolution) = New Queue(Of Sudoku.StrSolution)
        Dim TSmp(80) As Sudoku.StrSmp
        Dim NbrSmp As Integer

        Dim opk(8, 8) As Integer ' Candidats par case
        Dim nuplet(8, 8) As String ' Candidats agrégés

        Dim Eval As Integer
        Dim EvalMin As Integer = 1
        Dim EvalMax As Integer = 999
        Dim GrilleFinale(8, 8) As String
        Dim GrilleTentative(8, 8) As String
        Dim GrilleFB(8, 8) As String
        Dim TentativeOk As Boolean
        Dim TbNbrSmp(80) As Integer
        Dim Tbi(80) As Integer
        Dim Tbj(80) As Integer
        Dim Tbv(80) As String
        Dim TbQSolCount(80) As Integer
        Dim previousCase As String
        Dim ok As Boolean = True
        Dim Grillemodèle As String = "578314296136298475294675381653149728721863954849527613367981542412756839985432167"
        Dim wMsgBox As String

        NbVal = 81
        For i = 0 To 8
            For j = 0 To 8
                For k = 0 To 8
                    Candidats(i, j, k) = " "
                Next
                '          g = (i * 9) + j
                '           Grille(i, j) = Mid(Grillemodèle, g + 1, 1)
            Next
        Next

        Array.Copy(Grille, GrilleFinale, 81)

        While NbVal > 30 ' And ok
            '     While (Eval < EvalMin Or Eval > EvalMax) And nbVal > 60

            Array.Copy(Grille, GrilleTentative, 81)
            TentativeOk = False
            While TentativeOk = False
                ChoisitCase(GrilleTentative, NbVal, i, j)
                previousCase = Grille(i, j)
                Grille(i, j) = "0"

                Array.Copy(Grille, GrilleFB, 81)
                ForceBrute.ForceBrute(GrilleFB, NbSol)

                If NbSol = 0 Then
                    wMsgBox = "Pas de Solution !"
                    Grille(i, j) = previousCase
                    GrilleTentative(i, j) = "X"
                End If

                If NbSol > 1 Then
                    wMsgBox = "Solution multiple !"
                    Grille(i, j) = previousCase
                    GrilleTentative(i, j) = "X"
                End If

                If NbSol = 1 Then
                    CalculCandidats(Grille, Candidats)
                    AnalyseCase(Candidats, opk, nuplet)
                    RechercheSolution(Grille, Candidats, QSol, NbrSmp, TSmp, NbVal)
                    If QSol.Count = 0 And NbrSmp = 0 Then
                        TentativeOk = False ' Pas dans les capacités du solveur
                    Else
                        NbVal -= 1
                        TbNbrSmp(NbVal) = NbrSmp
                        Tbi(NbVal) = i
                        Tbj(NbVal) = j
                        Tbv(NbVal) = previousCase
                        TbQSolCount(NbVal) = QSol.Count
                        TentativeOk = True
                    End If
                End If

                'If Not ok Then
                '    MsgBox(NbVal & " enlevé un " & previousCase & " en " & i & ";" & j & " nb Solutions : ;" & QSol.Count)
                'End If

            End While
        End While

    End Sub

    Sub ChoisitCase(ByRef Grille(,) As String,
                    ByVal nbVal As Integer,
                    ByRef i As Integer,
                    ByRef j As Integer)

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




    Sub EnpileGrille(ByRef Grille(,) As String,
                     ByVal nbVal As Integer)

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
