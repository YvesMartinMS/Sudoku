Imports System.IO
Module Générateur

    Sub Générateur(ByVal typeGrille As String, ByRef TextSudoku As String)
        Const PATHFICHIER As String = "Sudoku.txt"

        Dim Contexte As New Sudoku.Contexte
        Dim Pile As Stack = New Stack()

        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim k As Integer = 0
        Dim g As Integer = 0
        Dim h As Integer = 0
        Dim r As Integer = 0
        Dim s As Integer = 0
        Dim z As String = 0

        Dim NbVal As Integer = 0
        Dim Grille(8, 8) As String ' La grille de Sudoku
        Dim GCandidats(8, 8, 8) As String ' La grille des candidats ( Valeurs au crayon)

        Dim NbTentatives As Integer
        Dim NbValMax As Integer
        Dim TentativeGrille(8, 8) As String ' La grille de Sudoku
        Dim TentativeCandidats(8, 8, 8) As String ' La grille des candidats ( Valeurs au crayon)

        Dim Erreur As Boolean
        Dim NbErreur As Integer
        Dim ErreurGrille(8, 8) As String 'affichage des cases en rouge
        Dim GQSol As Queue(Of Sudoku.StrSolution) = New Queue(Of Sudoku.StrSolution)
        Dim GSolution As Sudoku.StrSolution
        Dim Impasse As Boolean
        Dim NbImpasse As Integer
        Dim Réussi As Boolean
        Dim lpv As Integer
        Dim ltv As Integer
        Dim d As Integer
        Dim debug_i(80) As Integer
        Dim debug_j(80) As Integer
        Dim debug_v(80) As String
        Dim debug_m(80) As String

        GSolution.i = 0
        GSolution.j = 0
        GSolution.v = 0
        GSolution.m = " "
        GQSol.Enqueue(GSolution)
        GSolution = GQSol.Dequeue()

        Dim GTSmp(80) As Sudoku.StrSmp
        Dim GNbrSmp As Integer

        Dim ModeDebug As Boolean = False ' pour reproduire un cas precis lors de la génération
        Dim f As Integer = 0

        Dim it As String
        Dim jt As String
        Dim pil(3) As String
        Dim pili As String = ""
        Dim pilj As String = ""
        Dim pilv As String = ""
        Dim pilr As String = ""
        Dim TSIni As String = "                                                                                 "
        Dim TS As String = "                                                                                 "

        Dim SW As New Stopwatch
        Dim TSW As String

        If ModeDebug Then
            ' pili = File.ReadAllText(PATHFICHIER)
            For Each line As String In File.ReadLines(PATHFICHIER)
                pil(f) = line
                f += 1
            Next
            pili = pil(0)
            pilj = pil(1)
            pilv = pil(2)
            pilr = pil(3)
        Else
            File.WriteAllText(PATHFICHIER, "")
        End If

        '============================================================================================================================================================
        '  Procédure principle
        '============================================================================================================================================================

        Réussi = False

        SW.Start()

        While NbTentatives < 1000 And Not Réussi

            NbTentatives += 1
            TS = TSIni
            TextSudoku = TSIni
            pili = ""
            pilj = ""
            pilv = ""
            pilr = ""
            For i = 0 To 8
                For j = 0 To 8
                    Grille(i, j) = "0"
                    ErreurGrille(i, j) = " "
                Next
            Next
            Erreur = False
            Initialisations(Grille, GCandidats)
            NbVal = 0
            GQSol.Clear()



            While NbVal < 25 And Not Erreur

                If GQSol.Count = 0 Then
                    ChoisitCase(Grille, NbVal, i, j) ' choisit une case au hasard parmi celles qui sont libres
                    If ModeDebug Then 'remplace la case aléatoire par le cas à étudier
                        it = pili(NbVal)
                        i = CInt(it)
                        jt = pilj(NbVal)
                        j = CInt(jt)
                    End If
                    GénéCase(Grille, GCandidats, i, j, NbVal, TextSudoku, pili, pilj, pilv, pilr, ModeDebug) 'affecte une valeur à la case choisie
                    Recalcul_Candidats(i, j, Grille, GCandidats) ' Efface les candidats éliminés par la case généréee 
                    ControleGénération(Erreur, ErreurGrille, Grille, GCandidats) 'Vérifie la validité de la grille
                    'Génération symétrique
                    If i <> 4 Or j <> 4 Then
                        i = 8 - i
                        j = 8 - j
                        GénéCase(Grille, GCandidats, i, j, NbVal, TextSudoku, pili, pilj, pilv, pilr, ModeDebug) 'affecte une valeur à la case choisie
                        Recalcul_Candidats(i, j, Grille, GCandidats) ' Efface les candidats éliminés par la case généréee  
                        ControleGénération(Erreur, ErreurGrille, Grille, GCandidats) 'Vérifie la validité de la grille
                    End If

                End If

            End While

            Impasse = False
            While NbVal < 81 And Not Erreur And Not Impasse And Not Réussi
                ' à partir de là on essaie de résoudre la grille générée aléatoirement par les routines du solveur 

                GQSol.Clear()
                TsmpClear(GNbrSmp, GTSmp)
                RechercheSolution(Grille, GCandidats, GQSol, GNbrSmp, GTSmp) 'Recherche de toutes les solutions possibles
                If GQSol.Count = 0 And GNbrSmp = 0 Then
                    If Not Erreur Then
                        Impasse = True
                        NbImpasse += 1
                    End If
                Else
                    For d = 0 To 80
                        debug_i(d) = Nothing
                        debug_j(d) = Nothing
                        debug_v(d) = Nothing
                        debug_m(d) = Nothing
                    Next
                    d = 0
                    For Each Solution As Sudoku.StrSolution In GQSol
                        debug_i(d) = Solution.i
                        debug_j(d) = Solution.j
                        debug_v(d) = Solution.v
                        debug_m(d) = Solution.m
                        d += 1
                    Next

                    While GQSol.Count > 0  'Tant que la queue des solutions n'est pas vide
                        GSolution = GQSol.Dequeue()
                        i = GSolution.i
                        j = GSolution.j
                        Grille(i, j) = GSolution.v

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
                        Recalcul_Candidats(i, j, Grille, GCandidats) ' Retire la valeur saisie des groupes auxquels la case appartient
                        ControleGénération(Erreur, ErreurGrille, Grille, GCandidats)
                        pili = pili.Substring(0, NbVal) & i & pili.Substring(NbVal)
                        pilj = pilj.Substring(0, NbVal) & j & pilj.Substring(NbVal)
                        pilv = pilv.Substring(0, NbVal) & Grille(i, j) & pilv.Substring(NbVal)
                        NbVal += 1

                    End While

                    While GNbrSmp > 0
                        AppliqueUneSimplification(GNbrSmp, GTSmp, GCandidats)
                    End While

                End If
            End While


            If Erreur Then
                TextSudoku = TSIni
                NbErreur += 1
            End If

            If NbVal = 81 Then
                SW.Stop()
                TSW = SW.ElapsedMilliseconds.ToString & " milliseconde(s)"
                Réussi = True
            End If

        End While

        If Erreur Then
            Contexte.NbVal = NbVal
            Contexte.i = i
            Contexte.j = j
            Contexte.v = Grille(i, j)
            Contexte.Grille = Grille
            Contexte.Candidats = GCandidats
            Pile.Push(Contexte)
        End If
        If ModeDebug Then
        Else
            File.AppendAllText(PATHFICHIER, pili & Chr(13))
            File.AppendAllText(PATHFICHIER, pilj & Chr(13))
            File.AppendAllText(PATHFICHIER, pilv & Chr(13))
            File.AppendAllText(PATHFICHIER, pilr & Chr(13))
        End If

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

    Sub GénéCase(ByRef Grille(,) As String, ByRef Candidats(,,) As String, i As Integer, j As Integer, ByRef NbVal As Integer, ByRef TextSudoku As String, ByRef pili As String, ByRef pilj As String, ByRef pilv As String, ByRef pilr As String, ByVal ModeDebug As Boolean)

        Dim k As Integer = 0
        Dim g As Integer = 0
        Dim r As Integer = 0
        Dim c As Integer = 0

        Dim iRandom As Integer
        Dim NombreCandidats As Integer
        Dim CompteurCandidat As Integer
        Dim ConvertIrnd As String
        Dim TS As String

        NombreCandidats = 0
        For k = 0 To 8
            If Candidats(i, j, k) <> " " Then
                NombreCandidats += 1
            End If
        Next

        iRandom = GetRandom(0, NombreCandidats)

        If ModeDebug Then
            ConvertIrnd = pilr(NbVal)
            iRandom = CInt(ConvertIrnd) 'remplace le candidat aléatoire par le cas à étudier
        End If

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
                    pili = pili.Substring(0, NbVal) & i & pili.Substring(NbVal)
                    pilj = pilj.Substring(0, NbVal) & j & pilj.Substring(NbVal)
                    pilv = pilv.Substring(0, NbVal) & Grille(i, j) & pilv.Substring(NbVal)
                    pilr = pilr.Substring(0, NbVal) & iRandom & pilr.Substring(NbVal)
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
