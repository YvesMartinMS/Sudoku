Imports System.IO
Module Générateur

    Sub Générateur(ByRef Grille(,) As Integer,
                   ByRef nbVal As Integer,
                   ByRef NbLoop As Integer,
                   ByRef nbAppel As Integer)

        Dim i As Integer = 0
        Dim j As Integer = 0

        Dim candidats(8, 8, 8) As Integer ' La grille des candidats ( Valeurs au crayon)

        Dim nbTentatives As Integer
        Dim nbGrillePleines As Integer
        Dim tentativeGrille(8, 8) As Integer ' La grille de Sudoku
        Dim tentativeCandidats(8, 8, 8) As Integer ' La grille des candidats ( Valeurs au crayon)

        Dim l As Integer 'niveau de récursivité
        Dim nbc As Integer
        Dim r(Sudoku.ProfondeurPile) As Integer 'indice candidat à chaque niveau
        Dim seqCandidats(Sudoku.ProfondeurPile, 8) As Integer 'tableau des candidats sur 2 dimensions
        Dim seqi(Sudoku.ProfondeurPile) As Integer 'tableau des i à chaque niveau l
        Dim seqj(Sudoku.ProfondeurPile) As Integer 'tableau des j à chaque niveau l
        Dim nbrc(Sudoku.ProfondeurPile) As Integer 'nombre de candidats à chaque niveau l
        Dim nbrd(Sudoku.ProfondeurPile) As Integer

        Dim erreur As Boolean

        Dim erreurGrille(8, 8) As String 'affichage des cases en rouge
        Dim GrilleInitiale(8, 8) As Integer
        Dim GrillePleine As Boolean

        Dim T1SW As New Stopwatch
        Dim T2SW As New Stopwatch
        Dim T1 As String
        Dim T2 As String
        Dim nbSol As Integer
        Dim GrilleFinale(8, 8) As Integer ' La grille en fin de partie

        '============================================================================================================================================================
        '  Procédure principale
        '============================================================================================================================================================

        While Not GrillePleine

            nbTentatives += 1
            GrillePleine = False
            erreur = True
            While erreur

                nbVal = 0
                For i = 0 To 8
                    For j = 0 To 8
                        Grille(i, j) = "0"
                        erreurGrille(i, j) = " "
                    Next
                Next
                CalculCandidats(Grille, candidats)
                While nbVal < Sudoku.GrilleAléatoire

                    ChoisitCase(Grille, nbVal, i, j) ' choisit une case au hasard parmi celles qui sont libres
                    GénéCase(Grille, candidats, i, j, nbVal) 'affecte une valeur à la case choisie
                    ControleFB(erreur, Grille, i, j, Grille(i, j))

                    If Not erreur Then
                        RecalculCandidats(i, j, Grille, candidats) ' Efface les candidats éliminés par la case généréee 
                        GénéCase(Grille, candidats, 8 - i, j, nbVal) 'affecte une valeur à la case choisie
                        ControleFB(erreur, Grille, 8 - i, j, Grille(8 - i, j))
                    End If

                    If Not erreur Then
                        RecalculCandidats(8 - i, j, Grille, candidats) ' Efface les candidats éliminés par la case généréee 
                        GénéCase(Grille, candidats, i, 8 - j, nbVal) 'affecte une valeur à la case choisie
                        ControleFB(erreur, Grille, i, 8 - j, Grille(i, 8 - j))
                    End If

                    If Not erreur Then
                        RecalculCandidats(i, 8 - j, Grille, candidats) ' Efface les candidats éliminés par la case généréee 
                        GénéCase(Grille, candidats, 8 - i, 8 - j, nbVal) 'affecte une valeur à la case choisie
                        ControleFB(erreur, Grille, 8 - i, 8 - j, Grille(8 - i, 8 - j))
                    End If

                    If Not erreur Then
                        RecalculCandidats(8 - i, 8 - j, Grille, candidats) ' Efface les candidats éliminés par la case généréee 
                    End If

                    If erreur Then
                        Exit While
                    End If

                End While
                'CalculCandidats(Grille, candidats) 'Calcul candidat initial
                l = 0
                nbc = 0
                ' Compter les candidats
                For i = 0 To 8
                    For j = 0 To 8
                        If Grille(i, j) = "0" Then
                            seqi(l) = i
                            seqj(l) = j
                            r(l) = 0
                            For k = 0 To 8
                                If candidats(i, j, k) <> 0 Then
                                    nbc += 1
                                    r(l) += 1
                                End If
                            Next
                            If r(l) = 0 Then
                                erreur = True
                            End If
                            l += 1
                        End If
                    Next
                Next
            End While


            'For i = 0 To 8
            '    For j = 0 To 8
            '        g = (i * 9) + j + 1
            '        Grille(i, j) = Mid(Grillemodèle, g, 1)
            '        nbVal += 1
            '    Next
            'Next
            'CalculCandidats(Grille, Candidats)

            nbAppel += 1
            Array.Copy(Grille, GrilleInitiale, 81)
            Array.Copy(Grille, GrilleFinale, 81)

            ForceBrute.ForceBrute(GrilleFinale, nbSol, NbLoop, nbAppel)

            If nbSol > 0 Then
                ' If nbSol = 1 Then
                Array.Copy(GrilleFinale, Grille, 81)
                '       Array.Copy(GrilleInitiale, Grille, 81)
                GrillePleine = True
                nbGrillePleines += 1
            End If

        End While

    End Sub

    '============================================================================================================================================================
    '  Choisit une case libre dans la grille
    '============================================================================================================================================================

    Sub ChoisitCase(ByRef Grille(,) As Integer,
                    ByVal NbVal As Integer,
                    ByRef i As Integer,
                    ByRef j As Integer)

        Dim g As Integer
        Dim h As Integer

        g = GetRandom(0, 81 - NbVal - 17)
        h = 0

        For i = 0 To 8
            For j = 0 To 8
                If i <> 4 And j <> 4 Then
                    If Grille(i, j) = "0" Then
                        If g = h Then
                            Exit Sub
                        End If
                        h += 1
                    End If
                End If
            Next
        Next

    End Sub

    '============================================================================================================================================================
    '  Choisit un candidat dans une case libre de la grille
    '============================================================================================================================================================

    Sub GénéCase(ByRef Grille(,) As Integer,
                 ByRef Candidats(,,) As Integer,
                 ByVal i As Integer,
                 ByVal j As Integer,
                 ByRef NbVal As Integer)

        Dim k As Integer

        Dim iRandom As Integer
        Dim NombreCandidats As Integer
        Dim CompteurCandidat As Integer

        NombreCandidats = 0
        For k = 0 To 8
            If Candidats(i, j, k) <> 0 Then
                NombreCandidats += 1
            End If
        Next

        iRandom = GetRandom(0, NombreCandidats)

        CompteurCandidat = 0

        For k = 0 To 8
            If Candidats(i, j, k) <> 0 Then
                If CompteurCandidat = iRandom Then
                    Grille(i, j) = Candidats(i, j, k) 'affecte à la grille le candidat choisi aléatoirement
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
        '   Static Generator As System.Random = New System.Random()
        Return Sudoku.Generator.Next(Min, Max)

    End Function

End Module
