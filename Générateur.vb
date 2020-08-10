Imports System.IO
Module Générateur

    Sub Générateur(ByRef TextSudoku As String)

        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim g As Integer

        Dim nbVal As Integer = 0
        Dim Grille(8, 8) As String ' La grille de Sudoku
        Dim Candidats(8, 8, 8) As String ' La grille des candidats ( Valeurs au crayon)
        Dim Solution As Sudoku.StrSolution

        Dim NbTentatives As Integer
        Dim NbRéussi As Integer
        Dim TentativeGrille(8, 8) As String ' La grille de Sudoku
        Dim TentativeCandidats(8, 8, 8) As String ' La grille des candidats ( Valeurs au crayon)

        Dim Erreur As Boolean
        Dim NbErreur As Integer
        Dim ErreurGrille(8, 8) As String 'affichage des cases en rouge
        Dim QSol As Queue(Of Sudoku.StrSolution) = New Queue(Of Sudoku.StrSolution)

        Dim Impasse As Boolean
        Dim NbImpasse As Integer
        Dim Réussi As Boolean

        Dim TSmp(80) As Sudoku.StrSmp
        Dim NbrSmp As Integer

        Dim TSIni As String = "                                                                                 "
        Dim TS As String = "                                                                                 "

        Dim SW As New Stopwatch
        Dim TSW As String

        '============================================================================================================================================================
        '  Procédure principale
        '============================================================================================================================================================

        SW.Start()

        While NbTentatives < 200 And Not Réussi

            NbTentatives += 1
            Réussi = False
            TS = TSIni
            TextSudoku = TSIni

            For i = 0 To 8
                For j = 0 To 8
                    Grille(i, j) = "0"
                    ErreurGrille(i, j) = " "
                Next
            Next
            Erreur = False
            CalculCandidats(Grille, Candidats)
            nbVal = 0

            While nbVal < 25 And Not Erreur

                If QSol.Count = 0 Then
                    ChoisitCase(Grille, nbVal, i, j) ' choisit une case au hasard parmi celles qui sont libres
                    GénéCase(Grille, Candidats, i, j, nbVal, TextSudoku) 'affecte une valeur à la case choisie
                    RecalculCandidats(i, j, Grille, Candidats) ' Efface les candidats éliminés par la case généréee 
                    ControleSaisie(Erreur, ErreurGrille, Grille, Candidats) 'Vérifie la validité de la grille
                    'Génération symétrique
                    If i <> 4 Or j <> 4 Then
                        i = 8 - i
                        j = 8 - j
                        GénéCase(Grille, Candidats, i, j, nbVal, TextSudoku) 'affecte une valeur à la case choisie
                        RecalculCandidats(i, j, Grille, Candidats) ' Efface les candidats éliminés par la case généréee  
                        ControleSaisie(Erreur, ErreurGrille, Grille, Candidats) 'Vérifie la validité de la grille
                    End If

                End If

            End While

            Impasse = False
            While nbVal < 81 And Not Erreur And Not Impasse And Not Réussi
                ' à partir de là on essaie de résoudre la grille générée aléatoirement par les routines du solveur 

                RechercheSolution(Grille, Candidats, QSol, NbrSmp, TSmp) 'Recherche de toutes les solutions possibles
                If QSol.Count = 0 And NbrSmp = 0 Then
                    If Not Erreur Then
                        Impasse = True
                        NbImpasse += 1
                    End If
                Else
                    While QSol.Count > 0  'Tant que la queue des solutions n'est pas vide
                        Solution = QSol.Dequeue()
                        i = Solution.i
                        j = Solution.j
                        Grille(i, j) = Solution.v

                        g = (i * 9) + j
                        Select Case g
                            Case 0
                                TS = Grille(i, j) & Mid(TextSudoku, 2, 80)
                            Case 80
                                TS = Mid(TextSudoku, 1, 80) & Grille(i, j)
                            Case Else
                                TS = Mid(TextSudoku, 1, g) & Grille(i, j) & Mid(TextSudoku, g + 2, 82 - g)
                        End Select
                        TextSudoku = TS
                        RecalculCandidats(i, j, Grille, Candidats) ' Retire la valeur saisie des groupes auxquels la case appartient
                        ControleSaisie(Erreur, ErreurGrille, Grille, Candidats)
                        nbVal += 1

                    End While

                    While NbrSmp > 0
                        AppliqueUneSimplification(NbrSmp, TSmp, Candidats)
                    End While

                End If
            End While

            If Erreur Then
                TextSudoku = TSIni
                NbErreur += 1
            End If

            If nbVal = 81 Then
                Réussi = True
                NbRéussi += 1
            End If

            '    System.Threading.Thread.Sleep(50)

        End While

        SW.Stop()
        TSW = SW.ElapsedMilliseconds.ToString & " milliseconde(s)"

    End Sub

    '============================================================================================================================================================
    '  Choisit une case libre dahs la grille
    '============================================================================================================================================================

    Sub ChoisitCase(ByVal Grille(,) As String, ByVal NbVal As Integer, ByRef i As Integer, ByRef j As Integer)

        Dim g As Integer
        Dim h As Integer
        g = GetRandom(0, 81 - NbVal)
        h = 0

        For i = 0 To 8
            For j = 0 To 8
                If Grille(i, j) = "0" Then
                    If g = h Then
                        Exit Sub
                    End If
                    h += 1
                End If
            Next
        Next
    End Sub

    '============================================================================================================================================================
    '  Choisit un candidat dans une case libre de la grille
    '============================================================================================================================================================

    Sub GénéCase(ByRef Grille(,) As String, ByRef Candidats(,,) As String, i As Integer, j As Integer, ByRef NbVal As Integer, ByRef TextSudoku As String)

        Dim k As Integer
        Dim g As Integer
        Dim r As Integer

        Dim iRandom As Integer
        Dim NombreCandidats As Integer
        Dim CompteurCandidat As Integer

        Dim TS As String

        NombreCandidats = 0
        For k = 0 To 8
            If Candidats(i, j, k) <> " " Then
                NombreCandidats += 1
            End If
        Next

        iRandom = GetRandom(0, NombreCandidats)

        CompteurCandidat = 0

        For k = 0 To 8
            If Candidats(i, j, k) <> " " Then
                If CompteurCandidat = iRandom Then
                    Grille(i, j) = Candidats(i, j, k) 'affecte à la grille le candidat choisi aléatoirement
                    g = (i * 9) + j
                    Select Case g
                        Case 0
                            TS = Grille(i, j) & Mid(TextSudoku, 2, 80)
                        Case 80
                            TS = Mid(TextSudoku, 1, 80) & Grille(i, j)
                        Case Else
                            TS = Mid(TextSudoku, 1, g) & Grille(i, j) & Mid(TextSudoku, g + 2, 82 - g)
                    End Select
                    TextSudoku = TS
                    NbVal += 1

                End If
                CompteurCandidat += 1
            End If
        Next

    End Sub

    '============================================================================================================================================================
    '  Choisit un nombre aléatoire entre 0 et Max
    '============================================================================================================================================================

    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer

        ' by making Generator static, we preserve the same instance '
        ' (i.e., do not create new instances with the same seed over and over) '
        ' between calls '
        Static Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)

    End Function

End Module
