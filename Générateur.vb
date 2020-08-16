Imports System.IO
Module Générateur

    Sub Générateur(ByRef Grille(,) As String)

        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim g As Integer

        Dim nbVal As Integer = 0
        Dim Candidats(8, 8, 8) As String ' La grille des candidats ( Valeurs au crayon)

        Dim NbTentatives As Integer
        Dim NbRéussi As Integer
        Dim TentativeGrille(8, 8) As String ' La grille de Sudoku
        Dim TentativeCandidats(8, 8, 8) As String ' La grille des candidats ( Valeurs au crayon)

        Dim Erreur As Boolean

        Dim ErreurGrille(8, 8) As String 'affichage des cases en rouge

        Dim Réussi As Boolean

        Dim TSIni As String = "                                                                                 "
        Dim TS As String

        Dim SW As New Stopwatch
        Dim TSW As String
        Dim NbSol As Integer
        Dim GrilleFinale(8, 8) As String ' La grille en fin de partie

        '============================================================================================================================================================
        '  Procédure principale
        '============================================================================================================================================================

        SW.Start()

        While Not Réussi

            NbTentatives += 1
            Réussi = False

            For i = 0 To 8
                For j = 0 To 8
                    Grille(i, j) = "0"
                    ErreurGrille(i, j) = " "
                Next
            Next
            Erreur = False
            CalculCandidats(Grille, Candidats)
            nbVal = 0

            While nbVal < 28 And Not Erreur

                ChoisitCase(Grille, nbVal, i, j) ' choisit une case au hasard parmi celles qui sont libres
                GénéCase(Grille, Candidats, i, j, nbVal) 'affecte une valeur à la case choisie
                    RecalculCandidats(i, j, Grille, Candidats) ' Efface les candidats éliminés par la case généréee 
                    ControleSaisie(Erreur, ErreurGrille, Grille, Candidats) 'Vérifie la validité de la grille
                    'Génération symétrique
                    If i <> 4 Or j <> 4 Then
                        i = 8 - i
                        j = 8 - j
                        GénéCase(Grille, Candidats, i, j, nbVal) 'affecte une valeur à la case choisie
                        RecalculCandidats(i, j, Grille, Candidats) ' Efface les candidats éliminés par la case généréee  
                        ControleSaisie(Erreur, ErreurGrille, Grille, Candidats) 'Vérifie la validité de la grille
                    End If

            End While

            Array.Copy(Grille, GrilleFinale, 81)
            ForceBrute.ForceBrute(GrilleFinale, NbSol)

            If NbSol > 0 Then
                Array.Copy(GrilleFinale, Grille, 81)
                Réussi = True
                NbRéussi += 1
            End If

        End While

        SW.Stop()
        TSW = SW.ElapsedMilliseconds.ToString & " milliseconde(s)"

    End Sub

    '============================================================================================================================================================
    '  Choisit une case libre dahs la grille
    '============================================================================================================================================================

    Sub ChoisitCase(ByRef Grille(,) As String,
                    ByVal NbVal As Integer,
                    ByRef i As Integer,
                    ByRef j As Integer)

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

    Sub GénéCase(ByRef Grille(,) As String,
                 ByRef Candidats(,,) As String,
                 ByVal i As Integer,
                 ByVal j As Integer, ByRef NbVal As Integer)

        Dim k As Integer
        Dim g As Integer

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
