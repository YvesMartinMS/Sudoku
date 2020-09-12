Module Solveur
    '============================================================================================================================================================
    '
    '                                                    G E S T I O N    D E S   C A N D I D A T S 
    '
    '============================================================================================================================================================

    '============================================================================================================================================================
    '  Calcul complet des candidats
    '============================================================================================================================================================

    Sub CalculCandidats(ByRef _Grille(,) As Integer,
                        ByRef _Candidats(,,) As Integer)

        ' Initialise les candidats
        For _i = 0 To 8
            For _j = 0 To 8
                If _Grille(_i, _j) <> "0" Then
                    For _k = 0 To 8
                        _Candidats(_i, _j, _k) = 0
                    Next
                Else
                    For _k = 0 To 8
                        _Candidats(_i, _j, _k) = _k + 1
                    Next
                End If
            Next
        Next

        ' Efface les candidats dans les lignes
        For _i = 0 To 8
            GommeLigne(_Grille, _Candidats, _i)
        Next
        ' Efface les candidats dans les colonnes
        For _j = 0 To 8
            GommeColonne(_Grille, _Candidats, _j)
        Next
        ' Efface les candidats dans les régions
        For _r = 0 To 8
            GommeRégion(_Grille, _Candidats, _r)
        Next

    End Sub

    '============================================================================================================================================================
    '  Impacts sur les candidats de la saisie d'une case
    '============================================================================================================================================================

    Sub RecalculCandidats(ByVal _i As Integer,
                          ByVal _j As Integer,
                          ByRef _Grille(,) As Integer,
                          ByRef _Candidats(,,) As Integer)

        Dim _r As Integer

        For _k = 0 To 8
            _Candidats(_i, _j, _k) = 0  ' on enlève les candidats de la case qui vient d'être garnie
        Next

        ' Efface le candidat dans la ligne

        GommeLigne(_Grille, _Candidats, _i)

        ' Efface le candidat dans la colonne 

        GommeColonne(_Grille, _Candidats, _j)

        ' Efface le candidat dans la région 
        _r = ((_i \ 3) * 3) + (_j \ 3)  ' calcule la région d'après i et j
        GommeRégion(_Grille, _Candidats, _r)

    End Sub

    '============================================================================================================================================================
    '  Elimine les candidats dans une ligne
    '============================================================================================================================================================

    Sub GommeLigne(ByRef _Grille(,) As Integer,
                   ByRef _Candidats(,,) As Integer,
                   ByVal _i As Integer)

        Dim _g As Integer

        For _j = 0 To 8
            If _Grille(_i, _j) <> 0 Then
                For _k = 0 To 8
                    If Val(_k + 1) = _Grille(_i, _j) Then
                        _g = _k
                    End If
                Next
                For _jbis = 0 To 8
                    _Candidats(_i, _jbis, _g) = 0
                Next
            End If
        Next

    End Sub

    '============================================================================================================================================================
    '  Elimine les candidats dans une colonne
    '============================================================================================================================================================

    Sub GommeColonne(ByRef _Grille(,) As Integer,
                     ByRef _Candidats(,,) As Integer,
                     ByVal _j As Integer)

        Dim _g As Integer

        For _i = 0 To 8
            If _Grille(_i, _j) <> 0 Then
                For _k = 0 To 8
                    If Val(_k + 1) = _Grille(_i, _j) Then
                        _g = _k
                    End If
                Next
                For _ibis = 0 To 8
                    _Candidats(_ibis, _j, _g) = 0
                Next
            End If
        Next

    End Sub

    '============================================================================================================================================================
    '  Elimine les candidats dans une région
    '============================================================================================================================================================

    Sub GommeRégion(ByRef _Grille(,) As Integer,
                    ByRef _Candidats(,,) As Integer,
                    ByVal _r As Integer)

        Dim _csgi As Integer 'Coin supérieur gauche région
        Dim _csgj As Integer 'Coin supérieur gauche région
        Dim _g As Integer

        _csgi = (_r \ 3) * 3
        _csgj = (_r - _csgi) * 3
        For _i = _csgi To _csgi + 2
            For _j = _csgj To _csgj + 2
                If _Grille(_i, _j) <> "0" Then
                    For _k = 0 To 8
                        If Val(_k + 1) = _Grille(_i, _j) Then
                            _g = _k
                        End If
                    Next
                    For _ibis = _csgi To _csgi + 2
                        For _jbis = _csgj To _csgj + 2
                            _Candidats(_ibis, _jbis, _g) = 0
                        Next
                    Next
                End If
            Next
        Next

    End Sub

    '
    '============================================================================================================================================================
    '
    '                                                         C O N T R O L E S 
    '
    '============================================================================================================================================================

    ''============================================================================================================================================================
    '  Contrôle de la validité d'une grille
    '============================================================================================================================================================

    Sub ControleSaisie(ByRef _Erreur As Boolean,
                       ByRef _ErreurGrille(,) As String,
                       ByRef _Grille(,) As Integer,
                       ByRef _Candidats(,,) As Integer)
        ' Recherche d'erreurs sur les lignes
        ' case sans candidat ou deux fois la même valeur sur un segment

        ' Initialise _ErreurGrille
        For _ierr = 0 To 8
            For _jerr = 0 To 8
                _ErreurGrille(_ierr, _jerr) = " "
            Next
        Next
        _Erreur = False
        ' Recherche d'erreurs sur les lignes
        For _i = 0 To 8
            If Sudoku.mode <> "Saisie" Then
                ControleCandidat(_Erreur, _ErreurGrille, _Grille, _Candidats, _i)
            End If
            ControleLigne(_Erreur, _ErreurGrille, _Grille, _i)
        Next

        ' Recherche d'erreurs sur les colonnes
        For _j = 0 To 8
            ControleColonne(_Erreur, _ErreurGrille, _Grille, _j)
        Next

        ' Recherche d'erreurs sur les régions
        For _r = 0 To 8
            ControleRégion(_Erreur, _ErreurGrille, _Grille, _r)
        Next

    End Sub

    '============================================================================================================================================================
    '  Contrôle les doublons d'une ligne
    '============================================================================================================================================================

    Sub ControleLigne(ByRef _Erreur As Boolean,
                      ByRef _ErreurGrille(,) As String,
                      ByRef _Grille(,) As Integer,
                      ByVal _i As Integer)

        For _j = 0 To 7
            For _jbis = _j + 1 To 8
                If _Grille(_i, _j) = _Grille(_i, _jbis) And _Grille(_i, _j) <> "0" Then
                    _ErreurGrille(_i, _j) = "X"
                    _ErreurGrille(_i, _jbis) = "X"
                    _Erreur = True
                End If
            Next
        Next

    End Sub

    '============================================================================================================================================================
    '  Contrôle les doublons d'une colonne
    '============================================================================================================================================================

    Sub ControleColonne(ByRef _Erreur As Boolean,
                        ByRef _ErreurGrille(,) As String,
                        ByRef _Grille(,) As Integer,
                        ByVal _j As Integer)

        For _i = 0 To 7
            For _ibis = _i + 1 To 8
                If _Grille(_i, _j) = _Grille(_ibis, _j) And _Grille(_i, _j) <> "0" Then
                    _ErreurGrille(_i, _j) = "X"
                    _ErreurGrille(_ibis, _j) = "X"
                    _Erreur = True
                End If
            Next
        Next

    End Sub

    '============================================================================================================================================================
    '  Contrôle les doublons d'une région
    '============================================================================================================================================================

    Sub ControleRégion(ByRef _Erreur As Boolean,
                       ByRef _ErreurGrille(,) As String,
                       ByRef _Grille(,) As Integer,
                       ByVal _r As Integer)

        Dim _csgi As Integer 'Coin supérieur gauche région
        Dim _csgj As Integer 'Coin supérieur gauche région

        _csgi = (_r \ 3) * 3
        _csgj = (_r - _csgi) * 3
        For _i = _csgi To _csgi + 2
            For _j = _csgj To _csgj + 2
                For _ibis = _csgi To _csgi + 2
                    For _jbis = _csgj To _csgj + 2
                        If _i <> _ibis And _j <> _jbis Then
                            If _Grille(_i, _j) = _Grille(_ibis, _jbis) And _Grille(_i, _j) <> "0" Then
                                _ErreurGrille(_i, _j) = "X"
                                _ErreurGrille(_ibis, _jbis) = "X"
                                _Erreur = True
                            End If
                        End If
                    Next
                Next
            Next
        Next

    End Sub

    '============================================================================================================================================================
    ' Vérifie que pour une case non occupée il existe au moins un candidat
    '============================================================================================================================================================

    Sub ControleCandidat(ByRef _Erreur As Boolean,
                         ByRef _ErreurGrille(,) As String,
                         ByRef _Grille(,) As Integer,
                         ByRef _Candidats(,,) As Integer,
                         ByVal _i As Integer)

        Dim _ErreurCandidat(8, 8)

        For _j = 0 To 8
            If _Grille(_i, _j) = "0" Then
                _ErreurCandidat(_i, _j) = "X"
                For _k = 0 To 8
                    If _Candidats(_i, _j, _k) <> 0 Then
                        _ErreurCandidat(_i, _j) = " "
                    End If
                Next
                If _ErreurCandidat(_i, _j) = "X" Then
                    _ErreurGrille(_i, _j) = "X"
                    _Erreur = True
                End If
            End If
        Next
    End Sub

    '
    '============================================================================================================================================================
    '
    '                                                         M O T E U R
    '
    '============================================================================================================================================================
    '

    Sub RechercheSolution(ByRef _Grille(,) As Integer,
                         ByRef _Candidats(,,) As Integer,
                         ByRef _Qsol As Queue(Of Sudoku.StrSolution),
                         ByRef _NbrSmp As Integer,
                         ByRef _TSmp() As Sudoku.StrSmp,
                         ByVal _NbVal As Integer)

        '
        ' On ne touche pas aux candidats, c'est l'application d'une solution ou d'une technique de simplification qui modifie les candidats  
        '

        Dim _opk(8, 8) As Integer ' Candidats par case
        Dim _nuplet(8, 8) As String ' Candidats agrégés
        Dim _AnlLig(8, 8) As Sudoku.StrAnalyse ' (i,k)
        Dim _AnlCol(8, 8) As Sudoku.StrAnalyse ' (j,k)
        Dim _AnlReg(8, 8) As Sudoku.StrAnalyse ' (r,k)

        'Mise à jour du tableau des occurrences par case
        AnalyseCase(_Candidats, _opk, _nuplet)

        'Mise à jour du tableau des occurrences par ligne
        AnalyseLigne(_Candidats, _AnlLig)

        'Mise à jour du tableau des occurrences par colonne
        AnalyseColonne(_Candidats, _AnlCol, _NbVal)

        'Mise à jour du tableau des occurrences par région
        AnalyseRégion(_Candidats, _AnlReg)

        SeulDansUneCase(_Candidats, _opk, _Qsol)
        SeulDansUneLigne(_AnlLig, _Qsol)
        SeulDansUneColonne(_AnlCol, _Qsol)
        SeulDansUneRégion(_AnlReg, _Qsol)

        If _Qsol.Count = 0 Then

            PaireNueLig(_Candidats, _NbrSmp, _TSmp, _opk, _nuplet)
            PaireNueCol(_Candidats, _NbrSmp, _TSmp, _opk, _nuplet)
            PaireNueReg(_Candidats, _NbrSmp, _TSmp, _opk, _nuplet)

            CandidatVérouilléLig(_Candidats, _AnlLig, _AnlReg, _NbrSmp, _TSmp, _opk)
            CandidatVérouilléCol(_Candidats, _AnlCol, _AnlReg, _NbrSmp, _TSmp, _opk)

            AnalyseTrpLig(_Candidats, _NbrSmp, _TSmp, _opk)
            AnalyseTrpCol(_Candidats, _NbrSmp, _TSmp, _opk)
            AnalyseTrpReg(_Candidats, _NbrSmp, _TSmp, _opk)

            XYWingLigCol(_Candidats, _NbrSmp, _TSmp, _opk, _nuplet)
            XYWingRegLig(_Candidats, _NbrSmp, _TSmp, _opk, _nuplet)
            XYWingRegCol(_Candidats, _NbrSmp, _TSmp, _opk, _nuplet)

            XWingLig(_Candidats, _NbrSmp, _TSmp, _AnlLig, _Grille, _NbVal)
            XWingCol(_Candidats, _NbrSmp, _TSmp, _AnlCol, _Grille, _NbVal)

            PaireCachéeLig(_Candidats, _NbrSmp, _TSmp, _AnlLig, _opk, _NbVal)
            PaireCachéeCol(_Candidats, _NbrSmp, _TSmp, _AnlCol, _opk, _NbVal)
            PaireCachéeReg(_Candidats, _NbrSmp, _TSmp, _AnlReg, _opk)

            If _NbrSmp = 0 Then
                SwordFishLig(_Candidats, _NbrSmp, _TSmp, _AnlLig)
            End If

            If _NbrSmp = 0 Then
                SwordFishCol(_Candidats, _NbrSmp, _TSmp, _AnlCol)
            End If

            If _NbrSmp = 0 Then
                ChaîneFortementLiée(_Candidats, _NbrSmp, _TSmp, _AnlLig, _AnlCol, _AnlReg)
            End If

        End If

    End Sub


    '============================================================================================================================================================
    ' Recherche de solution 
    ' Détermine s'il n'y a plus qu'un candidat dans la case 
    '============================================================================================================================================================

    Sub AnalyseCase(ByRef _Candidats(,,) As Integer,
                    ByRef _opk(,) As Integer,
                    ByRef _nuplet(,) As String)
        ' détermine le nombre de valeurs possibles par case

        For _i = 0 To 8
            For _j = 0 To 8
                _opk(_i, _j) = 0
                _nuplet(_i, _j) = ""
                For _k = 0 To 8
                    If _Candidats(_i, _j, _k) <> 0 Then
                        _opk(_i, _j) += 1
                        _nuplet(_i, _j) = _nuplet(_i, _j) & _Candidats(_i, _j, _k).ToString
                    End If
                Next
            Next
        Next

    End Sub

    '============================================================================================================================================================
    ' Recherche de solution 
    ' Détermine le nombre d'occurrences de chaque candidat par ligne
    ' S'il n'y a qu'une occurrence c'est la solution retenue 
    '============================================================================================================================================================

    Sub AnalyseLigne(ByRef _Candidats(,,) As Integer,
                     ByRef _AnlLig(,) As Sudoku.StrAnalyse)
        ' - Détermine le nombre d'occurrences de chaque candidat par ligne
        ' - Détermine la position d'un candidat seul sur une ligne

        For _i = 0 To 8
            For _k = 0 To 8
                _AnlLig(_i, _k).n = 0
                For _j = 0 To 8
                    If _Candidats(_i, _j, _k) <> 0 Then
                        _AnlLig(_i, _k).n += 1
                        _AnlLig(_i, _k).i = _i
                        _AnlLig(_i, _k).j = _j
                        _AnlLig(_i, _k).k = _k
                    End If
                Next
            Next
        Next

    End Sub

    '============================================================================================================================================================
    ' Recherche de solution 
    ' Détermine le nombre d'occurrences de chaque candidat par colonne
    ' S'il n'y a qu'une occurrence c'est la solution retenue 
    '============================================================================================================================================================

    Sub AnalyseColonne(ByRef _Candidats(,,) As Integer,
                       ByRef _AnlCol(,) As Sudoku.StrAnalyse,
                       ByVal _nbval As Integer)
        ' - Détermine le nombre d'occurrences de chaque candidat par colonne
        ' - Détermine la position d'un candidat seul sur une colonne

        For _j = 0 To 8
            For _k = 0 To 8
                _AnlCol(_j, _k).n = 0
                For _i = 0 To 8
                    If _Candidats(_i, _j, _k) <> 0 Then
                        _AnlCol(_j, _k).n += 1
                        _AnlCol(_j, _k).i = _i
                        _AnlCol(_j, _k).j = _j
                        _AnlCol(_j, _k).k = _k
                    End If
                Next
            Next
        Next

    End Sub

    '============================================================================================================================================================
    ' Recherche de solution 
    ' Détermine le nombre d'occurrences de chaque candidat par région
    ' S'il n'y a qu'une occurrence c'est la solution retenue 
    '============================================================================================================================================================

    Sub AnalyseRégion(ByRef _Candidats(,,) As Integer,
                      ByRef _AnlReg(,) As Sudoku.StrAnalyse)

        ' - Détermine le nombre d'occurrences de chaque candidat par région
        ' - Détermine la position d'un candidat seul sur une région

        Dim _csgi As Integer 'Coin supérieur gauche région
        Dim _csgj As Integer 'Coin supérieur gauche région

        ' - Initialise le nombre d'occurrences de k par région
        For _r = 0 To 8
            For _k = 0 To 8
                _AnlReg(_r, _k).n = 0
            Next
        Next

        ' - Détermine le nombre d'occurrences de k par région
        For _r = 0 To 8
            _csgi = (_r \ 3) * 3
            _csgj = (_r - _csgi) * 3
            For _i = _csgi To _csgi + 2
                For _j = _csgj To _csgj + 2
                    For _k = 0 To 8
                        If _Candidats(_i, _j, _k) <> 0 Then
                            _AnlReg(_r, _k).n += 1
                            _AnlReg(_r, _k).i = _i
                            _AnlReg(_r, _k).j = _j
                            _AnlReg(_r, _k).k = _k
                        End If
                    Next
                Next
            Next
        Next

    End Sub

    '============================================================================================================================================================
    ' Recherche de solution 
    ' Balaye la table opk - candidats par case - pour alimenter la table des solutions à proposer
    '============================================================================================================================================================

    Sub SeulDansUneCase(ByRef _Candidats(,,) As Integer,
                        ByRef _opk(,) As Integer,
                        ByRef _Qsol As Queue(Of Sudoku.StrSolution))

        Dim _New_Solution As Sudoku.StrSolution

        For _i = 0 To 8
            For _j = 0 To 8
                If _opk(_i, _j) = 1 Then
                    For _k = 0 To 8
                        If _Candidats(_i, _j, _k) <> 0 Then
                            _New_Solution.i = _i
                            _New_Solution.j = _j
                            _New_Solution.v = _k + 1
                            _New_Solution.m = "Ligne " & _New_Solution.i + 1 & " Colonne " & _New_Solution.j + 1 & " : " & "seul candidat dans cette case : [" & _New_Solution.v & "]"
                            _New_Solution.b = Sudoku.BarèmeSeulDansUneCase
                            EnqueueSol(_New_Solution, _Qsol)
                        End If
                    Next
                End If
            Next
        Next

    End Sub

    '============================================================================================================================================================
    ' Recherche de solution 
    ' Balaye la table opl - possibilités par ligne - pour alimenter la table des solutions à proposer
    '============================================================================================================================================================

    Sub SeulDansUneLigne(ByRef _AnlLig(,) As Sudoku.StrAnalyse,
                         ByRef _Qsol As Queue(Of Sudoku.StrSolution))

        Dim _New_Solution As Sudoku.StrSolution

        ' - Détermine la position d'une occurrence seule sur une ligne

        For _i = 0 To 8
            For _k = 0 To 8
                If _AnlLig(_i, _k).n = 1 Then
                    _New_Solution.i = _AnlLig(_i, _k).i
                    _New_Solution.j = _AnlLig(_i, _k).j
                    _New_Solution.v = _AnlLig(_i, _k).k + 1
                    _New_Solution.m = "Ligne " & _New_Solution.i + 1 & " Colonne " & _New_Solution.j + 1 & " : " & "seul [" & _New_Solution.v & "] candidat dans cette ligne"
                    _New_Solution.b = Sudoku.BarèmeSeulDansUneLigne
                    EnqueueSol(_New_Solution, _Qsol)
                End If
            Next
        Next

    End Sub

    '============================================================================================================================================================
    ' Recherche de solution 
    ' Balaye la table opc - possibilités par colonne - pour alimenter la table des solutions à proposer
    '============================================================================================================================================================

    Sub SeulDansUneColonne(ByRef _AnlCol(,) As Sudoku.StrAnalyse,
                           ByRef _Qsol As Queue(Of Sudoku.StrSolution))

        Dim _New_Solution As Sudoku.StrSolution

        ' - Détermine la position d'une occurrence seule sur une colonne

        For _j = 0 To 8
            For _k = 0 To 8
                If _AnlCol(_j, _k).n = 1 Then
                    _New_Solution.i = _AnlCol(_j, _k).i
                    _New_Solution.j = _AnlCol(_j, _k).j
                    _New_Solution.v = _AnlCol(_j, _k).k + 1
                    _New_Solution.m = "Ligne " & _New_Solution.i + 1 & " Colonne " & _New_Solution.j + 1 & " : " & "seul [" & _New_Solution.v & "] candidat dans cette colonne"
                    _New_Solution.b = Sudoku.BarèmeSeulDansUneColonne
                    EnqueueSol(_New_Solution, _Qsol)
                End If
            Next
        Next

    End Sub

    '============================================================================================================================================================
    ' Recherche de solution 
    ' Balaye la table opr - possibilités par région - pour alimenter la table des solutions à proposer
    '============================================================================================================================================================

    Sub SeulDansUneRégion(ByRef _AnlReg(,) As Sudoku.StrAnalyse,
                          ByRef _Qsol As Queue(Of Sudoku.StrSolution))

        Dim _New_Solution As Sudoku.StrSolution

        ' - Détermine la position d'une occurrence seule sur une région

        For _r = 0 To 8
            For _k = 0 To 8
                If _AnlReg(_r, _k).n = 1 Then
                    _New_Solution.i = _AnlReg(_r, _k).i
                    _New_Solution.j = _AnlReg(_r, _k).j
                    _New_Solution.v = _AnlReg(_r, _k).k + 1
                    _New_Solution.m = "Ligne " & _New_Solution.i + 1 & " Colonne " & _New_Solution.j + 1 & " : " & "seul [" & _New_Solution.v & "] candidat dans cette région"
                    _New_Solution.b = Sudoku.BarèmeSeulDansUneRégion
                    EnqueueSol(_New_Solution, _Qsol)
                End If
            Next
        Next

    End Sub

    '============================================================================================================================================================
    ' Recherche de solution 
    ' Ajoute une entrée dans la queue des solutions, en évitant les doublons
    '============================================================================================================================================================

    Sub EnqueueSol(ByVal _New_Solution As Sudoku.StrSolution,
                   ByRef _Qsol As Queue(Of Sudoku.StrSolution))

        Dim _doublon As Boolean
        _doublon = False
        For Each Solution As Sudoku.StrSolution In _Qsol
            If Solution.i = _New_Solution.i And Solution.j = _New_Solution.j Then
                _doublon = True
            End If
        Next
        If Not _doublon Then
            _Qsol.Enqueue(_New_Solution)
        End If

    End Sub

    '============================================================================================================================================================
    ' Techniques d'élimination de candidats 
    ' Recense les paires nues par lignes
    '============================================================================================================================================================

    Sub PaireNueLig(ByRef _Candidats(,,) As Integer,
                    ByRef _NbrSmp As Integer,
                    ByRef _TSmp() As Sudoku.StrSmp,
                    ByRef _opk(,) As Integer,
                    ByRef _nuplet(,) As String)

        ' - recense les paires et la position de la dernière paire une ligne

        Dim _k0 As Integer
        Dim _k1 As Integer
        Dim _Smp As Sudoku.StrSmp

        _Smp = NewSmp()

        For _i = 0 To 8
            ' appariement
            For _j = 0 To 7
                If _opk(_i, _j) = 2 Then
                    For _jbis = _j + 1 To 8
                        If _opk(_i, _jbis) = 2 Then
                            If _nuplet(_i, _j) = _nuplet(_i, _jbis) Then
                                'Recherche si les paires sont actives (s'il y a des candidats à effacer)
                                _Smp.ne = 0
                                For _jter = 0 To 8
                                    If _jter <> _j And _jter <> _jbis Then
                                        For _k = 0 To 8
                                            If _Candidats(_i, _jter, _k) = Mid(_nuplet(_i, _j), 1, 1) Then
                                                _Smp.act = True
                                                _Smp.CE.i(_Smp.ne) = _i
                                                _Smp.CE.j(_Smp.ne) = _jter
                                                _Smp.CE.k(_Smp.ne) = _k
                                                _Smp.CE.v(_Smp.ne) = _k + 1
                                                _Smp.ne += 1
                                            End If
                                            If _Candidats(_i, _jter, _k) = Mid(_nuplet(_i, _j), 2, 1) Then
                                                _Smp.act = True
                                                _Smp.CE.i(_Smp.ne) = _i
                                                _Smp.CE.j(_Smp.ne) = _jter
                                                _Smp.CE.k(_Smp.ne) = _k
                                                _Smp.CE.v(_Smp.ne) = _k + 1
                                                _Smp.ne += 1
                                            End If
                                        Next
                                    End If
                                Next
                                If _Smp.act = True Then
                                    _Smp.nr = 2
                                    _Smp.CR.i(0) = _i
                                    _Smp.CR.j(0) = _j
                                    _Smp.CR.k(0) = _k0
                                    _Smp.CR.v(0) = CInt(Mid(_nuplet(_i, _j), 1, 1))
                                    _Smp.CR.i(1) = _i
                                    _Smp.CR.j(1) = _jbis
                                    _Smp.CR.k(1) = _k1
                                    _Smp.CR.v(1) = CInt(Mid(_nuplet(_i, _j), 2, 1))
                                    _Smp.motif = "Paires nues : [" & _nuplet(_i, _j) & "] dans les cases L" & _i + 1 & "C" & _j + 1 & "-L" & _i + 1 & "C" & _jbis + 1

                                    If _Smp.ne > 0 Then
                                        _TSmp(_NbrSmp) = _Smp
                                        _NbrSmp += 1
                                        _Smp = NewSmp()
                                    End If

                                    Exit For
                                End If
                            End If
                        End If
                    Next
                End If
            Next
        Next

    End Sub

    '============================================================================================================================================================
    ' Techniques d'élimination de candidats
    ' Recense les paires nues par colonnes
    '============================================================================================================================================================

    Sub PaireNueCol(ByRef _Candidats(,,) As Integer,
                    ByRef _NbrSmp As Integer,
                    ByRef _TSmp() As Sudoku.StrSmp,
                    ByRef _opk(,) As Integer,
                    ByRef _nuplet(,) As String)
        ' - recense les paires et la position de la dernière paire une ligne

        Dim _k0 As Integer
        Dim _k1 As Integer
        Dim _Smp As Sudoku.StrSmp

        _Smp = NewSmp()

        For _j = 0 To 8
            ' appariement
            For _i = 0 To 7
                If _opk(_i, _j) = 2 Then
                    For _ibis = _i + 1 To 8
                        If _opk(_ibis, _j) = 2 Then
                            If _nuplet(_i, _j) = _nuplet(_ibis, _j) Then
                                'Recherche si les paires sont actives (s'il y a des candidats à effacer)
                                _Smp.ne = 0
                                For _iter = 0 To 8
                                    If _iter <> _i And _iter <> _ibis Then
                                        For _k = 0 To 8
                                            If _Candidats(_iter, _j, _k) = Mid(_nuplet(_i, _j), 1, 1) Then
                                                _Smp.act = True
                                                _Smp.CE.i(_Smp.ne) = _iter
                                                _Smp.CE.j(_Smp.ne) = _j
                                                _Smp.CE.k(_Smp.ne) = _k
                                                _Smp.CE.v(_Smp.ne) = _k + 1
                                                _Smp.ne += 1
                                            End If
                                            If _Candidats(_iter, _j, _k) = Mid(_nuplet(_i, _j), 2, 1) Then
                                                _Smp.act = True
                                                _Smp.CE.i(_Smp.ne) = _iter
                                                _Smp.CE.j(_Smp.ne) = _j
                                                _Smp.CE.k(_Smp.ne) = _k
                                                _Smp.CE.v(_Smp.ne) = _k + 1
                                                _Smp.ne += 1
                                            End If
                                        Next
                                    End If
                                Next

                                If _Smp.act = True Then
                                    _Smp.nr = 2
                                    _Smp.CR.i(0) = _i
                                    _Smp.CR.j(0) = _j
                                    _Smp.CR.k(0) = _k0
                                    _Smp.CR.v(0) = CInt(Mid(_nuplet(_i, _j), 1, 1))
                                    _Smp.CR.i(1) = _ibis
                                    _Smp.CR.j(1) = _j
                                    _Smp.CR.k(1) = _k1
                                    _Smp.CR.v(1) = CInt(Mid(_nuplet(_i, _j), 2, 1))
                                    _Smp.motif = "Paires nues : [" & _nuplet(_i, _j) & "] dans les cases L" & _i + 1 & "C" & _j + 1 & "-L" & _ibis + 1 & "C" & _j + 1

                                    If _Smp.ne > 0 Then
                                        _TSmp(_NbrSmp) = _Smp
                                        _NbrSmp += 1
                                        _Smp = NewSmp()
                                    End If

                                    Exit For
                                End If
                            End If
                        End If
                    Next
                End If
            Next
        Next

    End Sub

    '============================================================================================================================================================
    ' Techniques d'élimination de candidats 
    ' Recense les paires nues par régions
    '============================================================================================================================================================


    Sub PaireNueReg(ByRef _Candidats(,,) As Integer,
                    ByRef _NbrSmp As Integer,
                    ByRef _TSmp() As Sudoku.StrSmp,
                    ByRef _opk(,) As Integer,
                    ByRef _nuplet(,) As String)

        ' - recense les paires et la position de la dernière paire une ligne

        Dim _k0 As Integer
        Dim _k1 As Integer
        Dim _Smp As Sudoku.StrSmp
        Dim _csgi As Integer 'Coin supérieur gauche région
        Dim _csgj As Integer 'Coin supérieur gauche région
        Dim _r As Integer
        Dim _g As Integer
        Dim _gbis As Integer

        _Smp = NewSmp()

        For _r = 0 To 8
            _csgi = (_r \ 3) * 3 'calcul coin supérieur gauche d'une région
            _csgj = (_r - _csgi) * 3 'calcul coin supérieur gauche d'une région
            For _i = _csgi To _csgi + 2 'parcours de l'élément 1
                For _j = _csgj To _csgj + 2 'parcours de l'élément 1
                    ' appariement
                    If _opk(_i, _j) = 2 Then 'si l'élément 1 est une paire
                        For _ibis = _csgi To _csgi + 2 'parcours de l'élément 2
                            For _jbis = _csgj To _csgj + 2 'parcours de l'élément 2
                                _g = (_i * 9) + _j
                                _gbis = (_ibis * 9) + _jbis
                                If _g < _gbis Then ' on ne compare que dans un sens (élément 2 tjrs > élément 1) 
                                    If _opk(_ibis, _jbis) = 2 Then 'si l'élément 2 est une paire
                                        If _nuplet(_i, _j) = _nuplet(_ibis, _jbis) Then 'on compare les 2 paires
                                            'Recherche si les paires sont actives (s'il y a des candidats à effacer)
                                            _Smp.ne = 0
                                            For _iter = _csgi To _csgi + 2
                                                For _jter = _csgj To _csgj + 2
                                                    If Not (_iter = _i And _jter = _j) And Not (_iter = _ibis And _jter = _jbis) Then
                                                        For _k = 0 To 8
                                                            If _Candidats(_iter, _jter, _k) = Mid(_nuplet(_i, _j), 1, 1) Then
                                                                _Smp.act = True
                                                                _Smp.CE.i(_Smp.ne) = _iter
                                                                _Smp.CE.j(_Smp.ne) = _jter
                                                                _Smp.CE.k(_Smp.ne) = _k
                                                                _Smp.CE.v(_Smp.ne) = _k + 1
                                                                _Smp.ne += 1
                                                            End If
                                                            If _Candidats(_iter, _jter, _k) = Mid(_nuplet(_i, _j), 2, 1) Then
                                                                _Smp.act = True
                                                                _Smp.CE.i(_Smp.ne) = _iter
                                                                _Smp.CE.j(_Smp.ne) = _jter
                                                                _Smp.CE.k(_Smp.ne) = _k
                                                                _Smp.CE.v(_Smp.ne) = _k + 1
                                                                _Smp.ne += 1
                                                            End If
                                                        Next
                                                    End If
                                                Next
                                            Next
                                            If _Smp.act = True Then
                                                _Smp.nr = 2
                                                _Smp.CR.i(0) = _i
                                                _Smp.CR.j(0) = _j
                                                _Smp.CR.k(0) = _k0
                                                _Smp.CR.v(0) = CInt(Mid(_nuplet(_i, _j), 1, 1))
                                                _Smp.CR.i(1) = _ibis
                                                _Smp.CR.j(1) = _jbis
                                                _Smp.CR.k(1) = _k1
                                                _Smp.CR.v(1) = CInt(Mid(_nuplet(_i, _j), 2, 1))
                                                _Smp.motif = "Paires nues : [" & _nuplet(_i, _j) & "] dans les cases L" & _i + 1 & "C" & _j + 1 & "-L" & _ibis + 1 & "C" & _jbis + 1

                                                If _Smp.ne > 0 Then
                                                    _TSmp(_NbrSmp) = _Smp
                                                    _NbrSmp += 1
                                                    _Smp = NewSmp()
                                                End If

                                                Exit For

                                            End If
                                        End If
                                    End If
                                End If
                            Next
                        Next
                    End If
                Next
            Next
        Next

    End Sub

    '============================================================================================================================================================
    ' Techniques d'élimination de candidats
    ' Candidats verrouillés en ligne (communs à une région et une ligne)
    '============================================================================================================================================================

    Sub CandidatVérouilléLig(ByRef _Candidats(,,) As Integer,
                             ByRef _AnlLig(,) As Sudoku.StrAnalyse,
                             ByRef _AnlReg(,) As Sudoku.StrAnalyse,
                             ByRef _NbrSmp As Integer,
                             ByRef _TSmp() As Sudoku.StrSmp,
                             ByRef _opk(,) As Integer)


        Dim _csgi As Integer 'Coin supérieur gauche région
        Dim _csgj As Integer 'Coin supérieur gauche région
        Dim _ir As Integer 'indice de ligne limité à l'intérieur d'une région
        Dim _AnlLigReg(2, 8) As Sudoku.StrAnalyse ' (i,k)
        Dim _Smp As Sudoku.StrSmp

        _Smp = NewSmp()

        For _r = 0 To 8
            _csgi = (_r \ 3) * 3 'calcul du coin supérieur gauche d'une région
            _csgj = (_r - _csgi) * 3 'calcul du coin supérieur gauche d'une région
            For _i = _csgi To _csgi + 2
                _ir = _i - _csgi 'ligne  de la région (de 0 à 2)
                ' - Détermine le nombre d'occurrences de k par ligne dans la région
                For _k = 0 To 8
                    _AnlLigReg(_ir, _k).n = 0
                Next
                For _j = _csgj To _csgj + 2
                    If _opk(_i, _j) > 0 Then
                        For _k = 0 To 8
                            If _Candidats(_i, _j, _k) <> 0 Then
                                _AnlLigReg(_ir, _k).n += 1
                                _AnlLigReg(_ir, _k).i = _i
                                _AnlLigReg(_ir, _k).j = _j
                                _AnlLigReg(_ir, _k).k = _k
                            End If
                        Next
                    End If
                Next

                '
                For _k = 0 To 8
                    ' Si on a au moins 2 k dans la ligne de la la région
                    ' si il y a autant de k dans dans la région entière que la ligne de la région
                    ' si il y a plus de k dans la ligne de la région que dans la ligne entière 
                    If _AnlLigReg(_ir, _k).n > 1 And _AnlReg(_r, _k).n = _AnlLigReg(_ir, _k).n And _AnlLig(_i, _k).n > _AnlLigReg(_ir, _k).n Then

                        'candidats retenus (vérouillés)
                        _Smp.nr = -0 'nombre de candidats retenus (indice base 0)
                        For _j = _csgj To _csgj + 2
                            If _Candidats(_i, _j, _k) <> 0 Then
                                _Smp.CR.i(_Smp.nr) = _i
                                _Smp.CR.j(_Smp.nr) = _j
                                _Smp.CR.k(_Smp.nr) = _k
                                _Smp.CR.v(_Smp.nr) = Val(_k + 1)
                                _Smp.nr += 1
                            End If
                        Next

                        'candidats éliminés ligne
                        _Smp.ne = 0 'nombre de candidats éliminés (indice base 0)
                        For _jrej = 0 To 8
                            If _jrej < _csgj Or _jrej > _csgj + 2 Then
                                If _Candidats(_i, _jrej, _k) <> 0 Then
                                    _Smp.CE.i(_Smp.ne) = _i
                                    _Smp.CE.j(_Smp.ne) = _jrej
                                    _Smp.CE.k(_Smp.ne) = _k
                                    _Smp.CE.v(_Smp.ne) = Val(_k + 1)
                                    _Smp.ne += 1
                                End If
                            End If
                        Next

                        _Smp.motif = "Candidat vérouillé : " & Val(_k + 1) & " - Région " & _r + 1 & " - Ligne " & _i + 1 & " LL"

                        If _Smp.ne > 0 Then
                            _TSmp(_NbrSmp) = _Smp
                            _NbrSmp += 1
                            _Smp = NewSmp()
                        End If

                    End If

                    ' Si on a au moins 2 k dans la ligne de la la région
                    ' si il y a plus de k dans dans la région entière que la ligne de la région
                    ' si il y a autant de k dans la ligne de la région que dans la ligne entière 
                    If _AnlLigReg(_ir, _k).n > 1 And _AnlReg(_r, _k).n > _AnlLigReg(_ir, _k).n And _AnlLig(_i, _k).n = _AnlLigReg(_ir, _k).n Then
                        'candidats retenus (vérouillés)
                        _Smp.nr = 0 'nombre de candidats retenus (indice base 0)
                        For _j = _csgj To _csgj + 2
                            If _Candidats(_i, _j, _k) <> 0 Then
                                _Smp.CR.i(_Smp.nr) = _i
                                _Smp.CR.j(_Smp.nr) = _j
                                _Smp.CR.k(_Smp.nr) = _k
                                _Smp.CR.v(_Smp.nr) = Val(_k + 1)
                                _Smp.nr += 1
                            End If
                        Next

                        'candidats éliminés région
                        _Smp.ne = 0 'nombre de candidats éliminés (indice base 0)
                        For _irej = _csgi To _csgi + 2
                            For _jrej = _csgj To _csgj + 2
                                If _irej <> _i Then
                                    If _Candidats(_irej, _jrej, _k) <> 0 Then
                                        _Smp.CE.i(_Smp.ne) = _irej
                                        _Smp.CE.j(_Smp.ne) = _jrej
                                        _Smp.CE.k(_Smp.ne) = _k
                                        _Smp.CE.v(_Smp.ne) = Val(_k + 1)
                                        _Smp.ne += 1
                                    End If
                                End If
                            Next
                        Next

                        _Smp.motif = "Candidat vérouillé : [" & Val(_k + 1) & "] - Région " & _r + 1 & " - Ligne " & _i + 1 & " LR"

                        If _Smp.ne > 0 Then
                            _TSmp(_NbrSmp) = _Smp
                            _NbrSmp += 1
                            _Smp = NewSmp()
                        End If
                    End If
                Next
            Next
        Next

    End Sub

    '============================================================================================================================================================
    ' Techniques d'élimination de candidats
    ' Candidats verrouillés en colonne (communs à une région et une colonne)
    '============================================================================================================================================================

    Sub CandidatVérouilléCol(ByRef _Candidats(,,) As Integer,
                             ByRef _AnlCol(,) As Sudoku.StrAnalyse,
                             ByRef _AnlReg(,) As Sudoku.StrAnalyse,
                             ByRef _NbrSmp As Integer,
                             ByRef _TSmp() As Sudoku.StrSmp,
                             ByRef _opk(,) As Integer)

        Dim _csgi As Integer 'Coin supérieur gauche région
        Dim _csgj As Integer 'Coin supérieur gauche région
        Dim _jr As Integer 'indice de colonne limité à l'intérieur d'une région
        Dim _AnlLigReg(2, 8) As Sudoku.StrAnalyse ' (i,k)
        Dim _Smp As Sudoku.StrSmp

        _Smp = NewSmp()

        For _r = 0 To 8
            _csgi = (_r \ 3) * 3 'calcul coin supérieur gauche d'une région
            _csgj = (_r - _csgi) * 3 'calcul coin supérieur gauche d'une région
            For _j = _csgj To _csgj + 2
                _jr = _j - _csgj
                For _k = 0 To 8
                    _AnlLigReg(_jr, _k).n = 0
                Next
                ' - Détermine le nombre d'occurrences de k par Colonne dans la région
                For _i = _csgi To _csgi + 2
                    If _opk(_i, _j) > 0 Then
                        For _k = 0 To 8
                            If _Candidats(_i, _j, _k) <> 0 Then
                                _AnlLigReg(_jr, _k).n += 1
                                _AnlLigReg(_jr, _k).i = _i
                                _AnlLigReg(_jr, _k).j = _j
                                _AnlLigReg(_jr, _k).k = _k
                            End If
                        Next
                    End If
                Next
                '
                For _k = 0 To 8
                    ' Si on a au moins 2 k dans la colonne de la la région
                    ' si il y a autant de k dans dans la région entière que la colonne de la région
                    ' si il y a plus de k dans la colonne de la région que dans la colonne entière 
                    If _AnlLigReg(_jr, _k).n > 1 And _AnlReg(_r, _k).n = _AnlLigReg(_jr, _k).n And _AnlCol(_j, _k).n > _AnlLigReg(_jr, _k).n Then
 _                        'candidats retenus (vérouillés)
                        _Smp.nr = 0 'nombre de candidats retenus (indice base 0)
                        For _i = _csgi To _csgi + 2
                            If _Candidats(_i, _j, _k) <> 0 Then
                                _Smp.CR.i(_Smp.nr) = _i
                                _Smp.CR.j(_Smp.nr) = _j
                                _Smp.CR.k(_Smp.nr) = _k
                                _Smp.CR.v(_Smp.nr) = Val(_k + 1)
                                _Smp.nr += 1
                            End If
                        Next

                        'candidats rejetés colonne
                        _Smp.ne = 0 'nombre de candidats éliminés (indice base 0)
                        For _irej = 0 To 8
                            If _irej < _csgi Or _irej > _csgi + 2 Then
                                If _Candidats(_irej, _j, _k) <> 0 Then 'i  = 9
                                    _Smp.CE.i(_Smp.ne) = _irej
                                    _Smp.CE.j(_Smp.ne) = _j
                                    _Smp.CE.k(_Smp.ne) = _k
                                    _Smp.CE.v(_Smp.ne) = Val(_k + 1)
                                    _Smp.ne += 1
                                End If
                            End If
                        Next

                        _Smp.motif = "Candidat vérouillé : [" & Val(_k + 1) & "] - Région " & _r + 1 & " - Colonne " & _j + 1 & " CC"

                        If _Smp.ne > 0 Then
                            _TSmp(_NbrSmp) = _Smp
                            _NbrSmp += 1
                            _Smp = NewSmp()
                        End If

                    End If

                    ' Si on a au moins 2 k dans la colonne de la la région
                    ' si il y a plus de k dans dans la région entière que la ligne de la région
                    ' si il y a autant de k dans la ligne de la région que dans la ligne entière 
                    If _AnlLigReg(_jr, _k).n > 1 And _AnlReg(_r, _k).n > _AnlLigReg(_jr, _k).n And _AnlCol(_j, _k).n = _AnlLigReg(_jr, _k).n Then
                        'candidats retenus (vérouillés)
                        _Smp.nr = 0 'nombre de candidats retenus (indice base 0)
                        For _i = _csgi To _csgi + 2
                            If _Candidats(_i, _j, _k) <> 0 Then
                                _Smp.CR.i(_Smp.nr) = _i
                                _Smp.CR.j(_Smp.nr) = _j
                                _Smp.CR.k(_Smp.nr) = _k
                                _Smp.CR.v(_Smp.nr) = Val(_k + 1)
                                _Smp.nr += 1
                            End If
                        Next

                        'candidats rejetés région
                        _Smp.ne = 0 'nombre de candidats éliminés (indice base 0)
                        For _irej = _csgi To _csgi + 2
                            For _jrej = _csgj To _csgj + 2
                                If _jrej <> _j Then
                                    If _Candidats(_irej, _jrej, _k) <> 0 Then
                                        _Smp.CE.i(_Smp.ne) = _irej
                                        _Smp.CE.j(_Smp.ne) = _jrej
                                        _Smp.CE.k(_Smp.ne) = _k
                                        _Smp.CE.v(_Smp.ne) = Val(_k + 1)
                                        _Smp.ne += 1
                                    End If
                                End If
                            Next
                        Next

                        _Smp.motif = "Candidat vérouillé : [" & Val(_k + 1) & "] - Région " & _r + 1 & " - Colonne " & _j + 1 & " CR"

                        If _Smp.ne > 0 Then
                            _TSmp(_NbrSmp) = _Smp
                            _NbrSmp += 1
                            _Smp = NewSmp()
                        End If

                    End If
                Next
            Next
        Next

    End Sub

    '============================================================================================================================================================
    ' Techniques d'élimination de candidats
    ' Analyse des tripets par Ligne
    '============================================================================================================================================================

    Sub AnalyseTrpLig(ByRef _Candidats(,,) As Integer,
                      ByRef _NbrSmp As Integer,
                      ByRef _TSmp() As Sudoku.StrSmp,
                      ByRef _opk(,) As Integer)

        ' - Détermine le nombre d'occurrences de chaque candidat par ligne
        ' - Détermine la position d'un candidat seul sur une ligne

        Dim _AnlTrp(8) As Sudoku.AnlTrp
        Dim _cmax As Integer
        Dim _c0 As Integer
        Dim _c1 As Integer
        Dim _c2 As Integer
        Dim _c3 As Integer
        Dim _nbk0 As Integer
        Dim _nbk1 As Integer
        Dim _nbk2 As Integer
        Dim _tv0(8) As Integer
        Dim _tv1(8) As Integer
        Dim _tv2(8) As Integer
        Dim _completed As Boolean
        Dim _i0 As Integer
        Dim _j0 As Integer
        Dim _k0 As Integer
        Dim _v0 As Integer = 0
        Dim _i1 As Integer
        Dim _j1 As Integer
        Dim _k1 As Integer
        Dim _v1 As Integer = 0
        Dim _i2 As Integer
        Dim _j2 As Integer
        Dim _k2 As Integer
        Dim _v2 As Integer = 0
        Dim _tk(2) As Integer
        Dim _tv(2) As Integer
        Dim _ej As Integer
        Dim _Smp As Sudoku.StrSmp

        _Smp = NewSmp()

        For _i = 0 To 8
            _completed = False
            ' Collecte les cellules de paires ou triplet d'une ligne
            For _c0 = 0 To 8
                ReDim _AnlTrp(_c0).v(8)
                For _k = 0 To 8
                    _AnlTrp(_c0).v(_k) = 0
                Next
            Next
            _c0 = 0
            For _j = 0 To 8
                If _opk(_i, _j) = 2 Or _opk(_i, _j) = 3 Then
                    _AnlTrp(_c0).i = _i
                    _AnlTrp(_c0).j = _j
                    For _k = 0 To 8
                        _AnlTrp(_c0).v(_k) = _Candidats(_i, _j, _k)
                    Next
                    _c0 += 1
                End If
            Next

            ' Cherche Les paires ou triplets avec pas plus de 3 valeurs différentes en tout

            _cmax = _c0 - 1

            If _cmax > 1 Then

                ' premier terme
                For _k = 0 To 8
                    _tv0(_k) = 0
                Next
                For _c0 = 0 To _cmax - 2
                    _nbk0 = 0
                    For _k = 0 To 8
                        If _AnlTrp(_c0).v(_k) <> 0 Then
                            _tv0(_k) = _AnlTrp(_c0).v(_k)
                            _nbk0 += 1
                        End If
                    Next
                    _i0 = _AnlTrp(_c0).i
                    _j0 = _AnlTrp(_c0).j
                    ' deuxième  terme
                    For _c1 = _c0 + 1 To _cmax - 1
                        For _k = 0 To 8
                            _tv1(_k) = _tv0(_k)
                        Next
                        For _k = 0 To 8
                            If _AnlTrp(_c1).v(_k) <> 0 Then
                                _tv1(_k) = _AnlTrp(_c1).v(_k)
                            End If
                        Next
                        _nbk1 = 0
                        For _k = 0 To 8
                            If _tv1(_k) <> 0 Then
                                _nbk1 += 1
                            End If
                        Next
                        If _nbk1 < 4 Then
                            _i1 = _AnlTrp(_c1).i
                            _j1 = _AnlTrp(_c1).j
                            ' troisième terme
                            For _c2 = _c1 + 1 To _cmax
                                For _k = 0 To 8
                                    _tv2(_k) = _tv1(_k)
                                Next
                                For _k = 0 To 8
                                    If _AnlTrp(_c2).v(_k) <> 0 Then
                                        _tv2(_k) = _AnlTrp(_c2).v(_k)
                                    End If
                                Next
                                _nbk2 = 0
                                For _k = 0 To 8
                                    If _tv2(_k) <> 0 Then
                                        _nbk2 += 1
                                    End If
                                Next
                                If _nbk2 < 4 Then
                                    _i2 = _AnlTrp(_c2).i
                                    _j2 = _AnlTrp(_c2).j
                                    _c3 = 0
                                    For _k = 0 To 8
                                        If _tv2(_k) <> 0 Then
                                            _tk(_c3) = _k
                                            _tv(_c3) = _tv2(_k)
                                            _c3 += 1
                                        End If
                                    Next
                                    _v0 = _tv(0)
                                    _v1 = _tv(1)
                                    _v2 = _tv(2)
                                    _k0 = _tk(0)
                                    _k1 = _tk(1)
                                    _k2 = _tk(2)
                                    _completed = True
                                    Exit For
                                End If
                                'fin troisième terme
                            Next
                        End If
                        If _completed Then
                            Exit For
                        End If
                    Next
                    ' fin deuxième terme
                    If _completed Then
                        Exit For
                    End If
                Next
                ' fin premier terme
            End If

            If _completed Then
                _Smp.nr = 3
                _Smp.CR.i(0) = _i0
                _Smp.CR.j(0) = _j0
                _Smp.CR.k(0) = _k0
                _Smp.CR.v(0) = _v0
                _Smp.CR.i(1) = _i1
                _Smp.CR.j(1) = _j1
                _Smp.CR.k(1) = _k1
                _Smp.CR.v(1) = _v1
                _Smp.CR.i(2) = _i2
                _Smp.CR.j(2) = _j2
                _Smp.CR.k(2) = _k2
                _Smp.CR.v(2) = _v2

                _Smp.motif = "Triplet nu : [" & _v0 & _v1 & _v2 & "] dans les cases L" & _i0 + 1 & "C" & _j0 + 1 & "-L" & _i1 + 1 & "C" & _j1 + 1 & "-L" & _i2 + 1 & "C" & _j2 + 1

                'Liste des candidats éliminés
                _Smp.ne = 0
                For _ej = 0 To 8
                    If _ej <> _j0 And _ej <> _j1 And _ej <> _j2 Then
                        If _Candidats(_i, _ej, _k0) = _v0 Then
                            _Smp.CE.i(_Smp.ne) = _i
                            _Smp.CE.j(_Smp.ne) = _ej
                            _Smp.CE.k(_Smp.ne) = _k0
                            _Smp.CE.v(_Smp.ne) = _v0
                            _Smp.ne += 1
                        End If
                        If _Candidats(_i, _ej, _k1) = _v1 Then
                            _Smp.CE.i(_Smp.ne) = _i
                            _Smp.CE.j(_Smp.ne) = _ej
                            _Smp.CE.k(_Smp.ne) = _k1
                            _Smp.CE.v(_Smp.ne) = _v1
                            _Smp.ne += 1
                        End If
                        If _Candidats(_i, _ej, _k2) = _v2 Then
                            _Smp.CE.i(_Smp.ne) = _i
                            _Smp.CE.j(_Smp.ne) = _ej
                            _Smp.CE.k(_Smp.ne) = _k2
                            _Smp.CE.v(_Smp.ne) = _v2
                            _Smp.ne += 1
                        End If
                    End If
                Next

                If _Smp.ne > 0 Then
                    _TSmp(_NbrSmp) = _Smp
                    _NbrSmp += 1
                    _Smp = NewSmp()
                End If

            End If
        Next

    End Sub

    '============================================================================================================================================================
    ' Techniques d'élimination de candidats
    ' Analyse des tripets par colonne
    '============================================================================================================================================================

    Sub AnalyseTrpCol(ByRef _Candidats(,,) As Integer,
                      ByRef _NbrSmp As Integer,
                      ByRef _TSmp() As Sudoku.StrSmp,
                      ByRef _opk(,) As Integer)

        ' - Détermine le nombre d'occurrences de chaque candidat par ligne
        ' - Détermine la position d'un candidat seul sur une ligne

        Dim _AnlTrp(8) As Sudoku.AnlTrp
        Dim _cmax As Integer
        Dim _c0 As Integer
        Dim _c1 As Integer
        Dim _c2 As Integer
        Dim _c3 As Integer
        Dim _nbk0 As Integer
        Dim _nbk1 As Integer
        Dim _nbk2 As Integer
        Dim _tv0(8) As Integer
        Dim _tv1(8) As Integer
        Dim _tv2(8) As Integer
        Dim _completed As Boolean
        Dim _i0 As Integer
        Dim _j0 As Integer
        Dim _k0 As Integer
        Dim _v0 As Integer = 0
        Dim _i1 As Integer
        Dim _j1 As Integer
        Dim _k1 As Integer
        Dim _v1 As Integer = 0
        Dim _i2 As Integer
        Dim _j2 As Integer
        Dim _k2 As Integer
        Dim _v2 As Integer = 0
        Dim _tk(2) As Integer
        Dim _tv(2) As Integer
        Dim _ei As Integer
        Dim _Smp As Sudoku.StrSmp

        _Smp = NewSmp()

        For _j = 0 To 8
            _completed = False
            ' Collecte les cellules de paires ou triplet d'une colonne
            For _c0 = 0 To 8
                ReDim _AnlTrp(_c0).v(8)
                For _k = 0 To 8
                    _AnlTrp(_c0).v(_k) = 0
                Next
            Next
            _c0 = 0
            For _i = 0 To 8
                If _opk(_i, _j) = 2 Or _opk(_i, _j) = 3 Then
                    _AnlTrp(_c0).i = _i
                    _AnlTrp(_c0).j = _j
                    For _k = 0 To 8
                        _AnlTrp(_c0).v(_k) = _Candidats(_i, _j, _k)
                    Next
                    _c0 += 1
                End If
            Next

            ' Cherche Les paires ou triplets avec pas plus de 3 valeurs différentes en tout

            _cmax = _c0 - 1

            If _cmax > 1 Then

                ' premier terme
                For _k = 0 To 8
                    _tv0(_k) = 0
                Next
                For _c0 = 0 To _cmax - 2
                    _nbk0 = 0
                    For _k = 0 To 8
                        If _AnlTrp(_c0).v(_k) <> 0 Then
                            _tv0(_k) = _AnlTrp(_c0).v(_k)
                            _nbk0 += 1
                        End If
                    Next
                    _i0 = _AnlTrp(_c0).i
                    _j0 = _AnlTrp(_c0).j
                    ' deuxième  terme
                    For _c1 = _c0 + 1 To _cmax - 1
                        For _k = 0 To 8
                            _tv1(_k) = _tv0(_k)
                        Next
                        For _k = 0 To 8
                            If _AnlTrp(_c1).v(_k) <> 0 Then
                                _tv1(_k) = _AnlTrp(_c1).v(_k)
                            End If
                        Next
                        _nbk1 = 0
                        For _k = 0 To 8
                            If _tv1(_k) <> 0 Then
                                _nbk1 += 1
                            End If
                        Next
                        If _nbk1 < 4 Then
                            _i1 = _AnlTrp(_c1).i
                            _j1 = _AnlTrp(_c1).j
                            ' troisième terme
                            For _c2 = _c1 + 1 To _cmax
                                For _k = 0 To 8
                                    _tv2(_k) = _tv1(_k)
                                Next
                                For _k = 0 To 8
                                    If _AnlTrp(_c2).v(_k) <> 0 Then
                                        _tv2(_k) = _AnlTrp(_c2).v(_k)
                                    End If
                                Next
                                _nbk2 = 0
                                For _k = 0 To 8
                                    If _tv2(_k) <> 0 Then
                                        _nbk2 += 1
                                    End If
                                Next
                                If _nbk2 < 4 Then
                                    _i2 = _AnlTrp(_c2).i
                                    _j2 = _AnlTrp(_c2).j
                                    _c3 = 0
                                    For _k = 0 To 8
                                        If _tv2(_k) <> 0 Then
                                            _tk(_c3) = _k
                                            _tv(_c3) = _tv2(_k)
                                            _c3 += 1
                                        End If
                                    Next
                                    _v0 = _tv(0)
                                    _v1 = _tv(1)
                                    _v2 = _tv(2)
                                    _k0 = _tk(0)
                                    _k1 = _tk(1)
                                    _k2 = _tk(2)
                                    _completed = True
                                    Exit For
                                End If
                                'fin troisième terme
                            Next
                        End If
                        If _completed Then
                            Exit For
                        End If
                    Next
                    ' fin deuxième terme
                    If _completed Then
                        Exit For
                    End If
                Next
                ' fin premier terme
            End If

            If _completed Then
                _Smp.nr = 3
                _Smp.CR.i(0) = _i0
                _Smp.CR.j(0) = _j0
                _Smp.CR.k(0) = _k0
                _Smp.CR.v(0) = _v0
                _Smp.CR.i(1) = _i1
                _Smp.CR.j(1) = _j1
                _Smp.CR.k(1) = _k1
                _Smp.CR.v(1) = _v1
                _Smp.CR.i(2) = _i2
                _Smp.CR.j(2) = _j2
                _Smp.CR.k(2) = _k2
                _Smp.CR.v(2) = _v2

                _Smp.motif = "Triplet nu : [" & _v0 & _v1 & _v2 & "] dans les cases L" & _i0 + 1 & "C" & _j0 + 1 & "-L" & _i1 + 1 & "C" & _j1 + 1 & "-L" & _i2 + 1 & "C" & _j2 + 1

                'Liste des candidats éliminés
                _Smp.ne = 0
                For _ei = 0 To 8
                    If _ei <> _i0 And _ei <> _i1 And _ei <> _i2 Then
                        If _Candidats(_ei, _j, _k0) = _v0 Then
                            _Smp.CE.i(_Smp.ne) = _ei
                            _Smp.CE.j(_Smp.ne) = _j
                            _Smp.CE.k(_Smp.ne) = _k0
                            _Smp.CE.v(_Smp.ne) = _v0
                            _Smp.ne += 1
                        End If
                        If _Candidats(_ei, _j, _k1) = _v1 Then
                            _Smp.CE.i(_Smp.ne) = _ei
                            _Smp.CE.j(_Smp.ne) = _j
                            _Smp.CE.k(_Smp.ne) = _k1
                            _Smp.CE.v(_Smp.ne) = _v1
                            _Smp.ne += 1
                        End If
                        If _Candidats(_ei, _j, _k2) = _v2 Then
                            _Smp.CE.i(_Smp.ne) = _ei
                            _Smp.CE.j(_Smp.ne) = _j
                            _Smp.CE.k(_Smp.ne) = _k2
                            _Smp.CE.v(_Smp.ne) = _v2
                            _Smp.ne += 1
                        End If
                    End If
                Next

                If _Smp.ne > 0 Then
                    _TSmp(_NbrSmp) = _Smp
                    _NbrSmp += 1
                    _Smp = NewSmp()
                End If

            End If
        Next

    End Sub

    '============================================================================================================================================================
    ' Techniques d'élimination de candidats
    ' Analyse des tripets par région
    '============================================================================================================================================================

    Sub AnalyseTrpReg(ByRef _Candidats(,,) As Integer,
                      ByRef _NbrSmp As Integer,
                      ByRef _TSmp() As Sudoku.StrSmp,
                      ByRef _opk(,) As Integer)

        ' - Détermine le nombre d'occurrences de chaque candidat par ligne
        ' - Détermine la position d'un candidat seul sur une ligne

        Dim _r As Integer
        Dim _csgi As Integer
        Dim _csgj As Integer

        Dim _AnlTrp(8) As Sudoku.AnlTrp
        Dim _cmax As Integer
        Dim _c0 As Integer
        Dim _c1 As Integer
        Dim _c2 As Integer
        Dim _c3 As Integer
        Dim _nbk0 As Integer
        Dim _nbk1 As Integer
        Dim _nbk2 As Integer
        Dim _tv0(8) As Integer
        Dim _tv1(8) As Integer
        Dim _tv2(8) As Integer
        Dim _completed As Boolean
        Dim _i0 As Integer
        Dim _j0 As Integer
        Dim _k0 As Integer
        Dim _v0 As Integer = 0
        Dim _i1 As Integer
        Dim _j1 As Integer
        Dim _k1 As Integer
        Dim _v1 As Integer = 0
        Dim _i2 As Integer
        Dim _j2 As Integer
        Dim _k2 As Integer
        Dim _v2 As Integer = 0
        Dim _tk(2) As Integer
        Dim _tv(2) As Integer
        Dim _ei As Integer
        Dim _ej As Integer
        Dim _Smp As Sudoku.StrSmp

        _Smp = NewSmp()

        For _r = 0 To 8
            _csgi = (_r \ 3) * 3 'calcul coin supérieur gauche d'une région
            _csgj = (_r - _csgi) * 3 'calcul coin supérieur gauche d'une région

            _completed = False
            ' Collecte les cellules de paires ou triplet d'une région
            For _c0 = 0 To 8
                ReDim _AnlTrp(_c0).v(8)
                For _k = 0 To 8
                    _AnlTrp(_c0).v(_k) = 0
                Next
            Next
            _c0 = 0
            For _i = _csgi To _csgi + 2
                For _j = _csgj To _csgj + 2
                    If _opk(_i, _j) = 2 Or _opk(_i, _j) = 3 Then
                        _AnlTrp(_c0).i = _i
                        _AnlTrp(_c0).j = _j
                        For _k = 0 To 8
                            _AnlTrp(_c0).v(_k) = _Candidats(_i, _j, _k)
                        Next
                        _c0 += 1
                    End If
                Next
            Next

            ' Cherche Les paires ou triplets avec pas plus de 3 valeurs différentes en tout

            _cmax = _c0 - 1

            If _cmax > 1 Then
                ' premier terme
                For _k = 0 To 8
                    _tv0(_k) = 0
                Next
                For _c0 = 0 To _cmax - 2
                    _nbk0 = 0
                    For _k = 0 To 8
                        If _AnlTrp(_c0).v(_k) <> 0 Then
                            _tv0(_k) = _AnlTrp(_c0).v(_k)
                            _nbk0 += 1
                        End If
                    Next
                    _i0 = _AnlTrp(_c0).i
                    _j0 = _AnlTrp(_c0).j
                    ' deuxième  terme
                    For _c1 = _c0 + 1 To _cmax - 1
                        For _k = 0 To 8
                            _tv1(_k) = _tv0(_k)
                        Next
                        For _k = 0 To 8
                            If _AnlTrp(_c1).v(_k) <> 0 Then
                                _tv1(_k) = _AnlTrp(_c1).v(_k)
                            End If
                        Next
                        _nbk1 = 0
                        For _k = 0 To 8
                            If _tv1(_k) <> 0 Then
                                _nbk1 += 1
                            End If
                        Next
                        If _nbk1 < 4 Then
                            _i1 = _AnlTrp(_c1).i
                            _j1 = _AnlTrp(_c1).j
                            ' troisième terme
                            For _c2 = _c1 + 1 To _cmax
                                For _k = 0 To 8
                                    _tv2(_k) = _tv1(_k)
                                Next
                                For _k = 0 To 8
                                    If _AnlTrp(_c2).v(_k) <> 0 Then
                                        _tv2(_k) = _AnlTrp(_c2).v(_k)
                                    End If
                                Next
                                _nbk2 = 0
                                For _k = 0 To 8
                                    If _tv2(_k) <> 0 Then
                                        _nbk2 += 1
                                    End If
                                Next
                                If _nbk2 < 4 Then
                                    _i2 = _AnlTrp(_c2).i
                                    _j2 = _AnlTrp(_c2).j
                                    _c3 = 0
                                    For _k = 0 To 8
                                        If _tv2(_k) <> 0 Then
                                            _tk(_c3) = _k
                                            _tv(_c3) = _tv2(_k)
                                            _c3 += 1
                                        End If
                                    Next
                                    _v0 = _tv(0)
                                    _v1 = _tv(1)
                                    _v2 = _tv(2)
                                    _k0 = _tk(0)
                                    _k1 = _tk(1)
                                    _k2 = _tk(2)
                                    _completed = True
                                    Exit For
                                End If
                                'fin troisième terme
                            Next
                        End If
                        If _completed Then
                            Exit For
                        End If
                    Next
                    ' fin deuxième terme
                    If _completed Then
                        Exit For
                    End If
                Next
                ' fin premier terme
            End If

            If _completed Then
                _Smp.nr = 3
                _Smp.CR.i(0) = _i0
                _Smp.CR.j(0) = _j0
                _Smp.CR.k(0) = _k0
                _Smp.CR.v(0) = _v0
                _Smp.CR.i(1) = _i1
                _Smp.CR.j(1) = _j1
                _Smp.CR.k(1) = _k1
                _Smp.CR.v(1) = _v1
                _Smp.CR.i(2) = _i2
                _Smp.CR.j(2) = _j2
                _Smp.CR.k(2) = _k2
                _Smp.CR.v(2) = _v2

                _Smp.motif = "Triplet nu : [" & _v0 & _v1 & _v2 & "] dans les cases L" & _i0 + 1 & "C" & _j0 + 1 & "-L" & _i1 + 1 & "C" & _j1 + 1 & "-L" & _i2 + 1 & "C" & _j2 + 1

                'Liste des candidats éliminés
                _Smp.ne = 0
                For _ei = _csgi To _csgi + 2
                    For _ej = _csgj To _csgj + 2

                        If Not (_ei = _i0 And _ej = _j0) And Not (_ei = _i1 And _ej = _j1) And Not (_ei = _i2 And _ej = _j2) Then
                            If _Candidats(_ei, _ej, _k0) = _v0 Then
                                _Smp.CE.i(_Smp.ne) = _ei
                                _Smp.CE.j(_Smp.ne) = _ej
                                _Smp.CE.k(_Smp.ne) = _k0
                                _Smp.CE.v(_Smp.ne) = _v0
                                _Smp.ne += 1
                            End If
                            If _Candidats(_ei, _ej, _k1) = _v1 Then
                                _Smp.CE.i(_Smp.ne) = _ei
                                _Smp.CE.j(_Smp.ne) = _ej
                                _Smp.CE.k(_Smp.ne) = _k1
                                _Smp.CE.v(_Smp.ne) = _v1
                                _Smp.ne += 1
                            End If
                            If _Candidats(_ei, _ej, _k2) = _v2 Then
                                _Smp.CE.i(_Smp.ne) = _ei
                                _Smp.CE.j(_Smp.ne) = _ej
                                _Smp.CE.k(_Smp.ne) = _k2
                                _Smp.CE.v(_Smp.ne) = _v2
                                _Smp.ne += 1
                            End If
                        End If
                    Next
                Next

                If _Smp.ne > 0 Then
                    _TSmp(_NbrSmp) = _Smp
                    _NbrSmp += 1
                    _Smp = NewSmp()
                End If
            End If
        Next

    End Sub

    '============================================================================================================================================================
    ' Techniques d'élimination de candidats
    ' XY-Wing Ligne - Colonne
    '============================================================================================================================================================

    Sub XYWingLigCol(ByRef _Candidats(,,) As Integer,
                     ByRef _NbrSmp As Integer,
                     ByRef _TSmp() As Sudoku.StrSmp,
                     ByRef _opk(,) As Integer,
                     ByRef _nuplet(,) As String)

        Dim _aile_hor As String
        Dim _aile_hor_i As Integer
        Dim _aile_hor_j As Integer
        Dim _sommet As String
        Dim _sommet_i As Integer
        Dim _sommet_j As Integer
        Dim _aile_ver As String
        Dim _aile_ver_i As Integer
        Dim _aile_ver_j As Integer
        Dim _exclu As String
        Dim _exclu_i As Integer
        Dim _exclu_j As Integer
        Dim _exclu_k As Integer
        Dim _completed As Boolean
        Dim _commun As Boolean
        Dim _Smp As Sudoku.StrSmp

        _Smp = NewSmp()

        For _i = 0 To 8
            For _j = 0 To 7
                If _opk(_i, _j) = 2 Then
                    For _jbis = _j + 1 To 8
                        If _opk(_i, _jbis) = 2 Then
                            CommunIni(_nuplet(_i, _j), _nuplet(_i, _jbis), _commun)
                            If _commun Then
                                For _ibis = 0 To 8
                                    If _i <> _ibis Then
                                        _exclu = Nothing
                                        _completed = False
                                        _aile_ver = Nothing
                                        _aile_hor = Nothing
                                        _sommet = Nothing

                                        If _opk(_ibis, _j) = 2 Then
                                            _sommet = _nuplet(_i, _j)
                                            _sommet_i = _i
                                            _sommet_j = _j
                                            _aile_ver = _nuplet(_ibis, _j)
                                            _aile_ver_i = _ibis
                                            _aile_ver_j = _j
                                            _aile_hor = _nuplet(_i, _jbis)
                                            _aile_hor_i = _i
                                            _aile_hor_j = _jbis
                                            _exclu_i = _ibis
                                            _exclu_j = _jbis
                                            CommunIni(_aile_ver, _sommet, _commun)
                                            CommunSuite(_sommet, _aile_hor, _commun)
                                            XYWing(_completed, _aile_ver, _aile_hor, _exclu)
                                            _exclu_k = _exclu - 1
                                        End If

                                        If _opk(_ibis, _jbis) = 2 Then
                                            _sommet = _nuplet(_i, _jbis)
                                            _sommet_i = _i
                                            _sommet_j = _jbis
                                            _aile_ver = _nuplet(_ibis, _jbis)
                                            _aile_ver_i = _ibis
                                            _aile_ver_j = _jbis
                                            _aile_hor = _nuplet(_i, _j)
                                            _aile_hor_i = _i
                                            _aile_hor_j = _j
                                            _exclu_i = _ibis
                                            _exclu_j = _j
                                            CommunIni(_aile_ver, _sommet, _commun)
                                            CommunSuite(_sommet, _aile_hor, _commun)
                                            XYWing(_completed, _aile_ver, _aile_hor, _exclu)
                                            _exclu_k = _exclu - 1
                                        End If

                                        If _completed Then
                                            _Smp.nr = 3
                                            _Smp.CR.i(0) = CInt(_aile_ver_i)
                                            _Smp.CR.j(0) = CInt(_aile_ver_j)
                                            _Smp.CR.k(0) = _exclu_k
                                            _Smp.CR.v(0) = CInt(_aile_ver)
                                            _Smp.CR.i(1) = CInt(_sommet_i)
                                            _Smp.CR.j(1) = _sommet_j
                                            _Smp.CR.k(1) = _exclu_k
                                            _Smp.CR.v(1) = _sommet
                                            _Smp.CR.i(2) = CInt(_aile_hor_i)
                                            _Smp.CR.j(2) = CInt(_aile_hor_j)
                                            _Smp.CR.k(2) = _exclu_k
                                            _Smp.CR.v(2) = CInt(_aile_hor)

                                            _Smp.motif = "XY-Wing [" & _exclu & "] dans les cases L" & _aile_ver_i + 1 & "C" & _aile_ver_i + 1 & "-L" & _sommet_i + 1 & "C" & _sommet_j + 1 & "-L" & _aile_hor_i + 1 & "C" & _aile_hor_j + 1

                                            For k = 0 To 8
                                                If _Candidats(_exclu_i, _exclu_j, _exclu_k) = _exclu Then
                                                    _Smp.CE.i(_Smp.ne) = _exclu_i
                                                    _Smp.CE.j(_Smp.ne) = _exclu_j
                                                    _Smp.CE.k(_Smp.ne) = _exclu_k
                                                    _Smp.CE.v(_Smp.ne) = _exclu
                                                    _Smp.ne += 1
                                                End If
                                            Next
                                            If _Smp.ne > 0 Then
                                                _TSmp(_NbrSmp) = _Smp
                                                _NbrSmp += 1
                                                _Smp = NewSmp()
                                            End If

                                        End If
                                    End If
                                Next
                            End If
                        End If
                    Next
                End If
            Next
        Next

    End Sub

    '============================================================================================================================================================
    ' Techniques d'élimination de candidats 
    ' XY-Wing Région - Ligne
    '============================================================================================================================================================

    Sub XYWingRegLig(ByRef _Candidats(,,) As Integer,
                     ByRef _NbrSmp As Integer,
                     ByRef _TSmp() As Sudoku.StrSmp,
                     ByRef _opk(,) As Integer,
                     ByRef _nuplet(,) As String)

        Dim _r As Integer 'indice région
        Dim _csgi As Integer 'Coin supérieur gauche région
        Dim _csgj As Integer 'Coin supérieur gauche région
        Dim _i As Integer
        Dim _j As Integer
        Dim _ibis As Integer
        Dim _jbis As Integer
        Dim _jter As Integer
        Dim _aile_int As String    'aile intérieure à la région
        Dim _aile_int_i As Integer 'aile intérieure à la région
        Dim _aile_int_j As Integer 'aile intérieure à la région
        Dim _sommet As String
        Dim _sommet_i As Integer
        Dim _sommet_j As Integer
        Dim _aile_ext As String    'aile extérieure à la région
        Dim _aile_ext_i As Integer 'aile extérieure à la région
        Dim _aile_ext_j As Integer 'aile extérieure à la région
        Dim _aej As Integer      'calcul départ j aile extérieure à la région
        Dim _exclu As String
        Dim _exclu_k As Integer
        Dim _completed As Boolean
        Dim _Smp As Sudoku.StrSmp
        Dim _commun As Boolean

        _Smp = NewSmp()

        For _r = 0 To 8
            _csgi = (_r \ 3) * 3 'calcul du coin supérieur gauche d'une région
            _csgj = (_r - _csgi) * 3 'calcul du coin supérieur gauche d'une région
            For _i = _csgi To _csgi + 2
                For _j = _csgj To _csgj + 2
                    If _opk(_i, _j) = 2 Then
                        _sommet = _nuplet(_i, _j)
                        _sommet_i = _i
                        _sommet_j = _j

                        For _ibis = _csgi To _csgi + 2
                            If _ibis <> _i Then
                                For _jbis = _csgj To _csgj + 2
                                    If _opk(_ibis, _jbis) = 2 Then
                                        _aile_int = _nuplet(_ibis, _jbis)
                                        _aile_int_i = _ibis
                                        _aile_int_j = _jbis
                                        CommunIni(_aile_int, _sommet, _commun)
                                        If _commun Then
                                            For _jter = 0 To 8
                                                If _jter < _csgj Or _jter > _csgj + 2 Then
                                                    If _opk(_i, _jter) = 2 Then
                                                        _aile_ext = _nuplet(_i, _jter)
                                                        _aile_ext_i = _i
                                                        _aile_ext_j = _jter
                                                        CommunSuite(_sommet, _aile_ext, _commun)
                                                        If _commun Then
                                                            _exclu = " "
                                                            XYWing(_completed, _aile_int, _aile_ext, _exclu)

                                                            If _completed Then
                                                                _exclu_k = _exclu - 1
                                                                _Smp.nr = 3
                                                                _Smp.CR.i(0) = CInt(_aile_int_i)
                                                                _Smp.CR.j(0) = CInt(_aile_int_j)
                                                                _Smp.CR.k(0) = _exclu_k
                                                                _Smp.CR.v(0) = _exclu
                                                                _Smp.CR.i(1) = CInt(_sommet_i)
                                                                _Smp.CR.j(1) = CInt(_sommet_j)
                                                                _Smp.CR.k(1) = _exclu_k
                                                                _Smp.CR.v(1) = _exclu
                                                                _Smp.CR.i(2) = CInt(_aile_ext_i)
                                                                _Smp.CR.j(2) = CInt(_aile_ext_j)
                                                                _Smp.CR.k(2) = _exclu_k
                                                                _Smp.CR.v(2) = _exclu
                                                                _Smp.motif = "XY-Wing [" & _exclu & "] dans les cases L" & _aile_int_i + 1 & "C" & _aile_int_j + 1 & "-L" & _sommet_i + 1 & "C" & _sommet_j + 1 & "-L" & _aile_ext_i + 1 & "C" & _aile_ext_j + 1

                                                                ' Intersection à l'intérieur de la région 
                                                                For _ej = _csgj To _csgj + 2
                                                                    If _ej <> _sommet_j Then
                                                                        If _Candidats(_i, _ej, _exclu_k) = _exclu Then
                                                                            _Smp.CE.i(_Smp.ne) = _i
                                                                            _Smp.CE.j(_Smp.ne) = _ej
                                                                            _Smp.CE.k(_Smp.ne) = _exclu_k
                                                                            _Smp.CE.v(_Smp.ne) = _exclu
                                                                            _Smp.ne += 1
                                                                        End If
                                                                    End If
                                                                Next

                                                                ' Intersection à l'extérieur de la région
                                                                _aej = (_aile_ext_j \ 3) * 3 'calcul du départ de _j de l'aile exérieure

                                                                For _ej = _aej To _aej + 2
                                                                    If _Candidats(_aile_int_i, _ej, _exclu_k) = _exclu Then
                                                                        _Smp.CE.i(_Smp.ne) = _aile_int_i
                                                                        _Smp.CE.j(_Smp.ne) = _ej
                                                                        _Smp.CE.k(_Smp.ne) = _exclu_k
                                                                        _Smp.CE.v(_Smp.ne) = _exclu
                                                                        _Smp.ne += 1
                                                                    End If
                                                                Next

                                                                If _Smp.ne > 0 Then
                                                                    _TSmp(_NbrSmp) = _Smp
                                                                    _NbrSmp += 1
                                                                    _Smp = NewSmp()
                                                                End If

                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            Next
                                        End If
                                    End If
                                Next
                            End If
                        Next
                    End If
                Next
            Next
        Next

    End Sub

    '============================================================================================================================================================
    ' Techniques d'élimination de candidats 
    ' XY-Wing Région - Colonne
    '============================================================================================================================================================

    Sub XYWingRegCol(ByRef _Candidats(,,) As Integer,
                     ByRef _NbrSmp As Integer,
                     ByRef _TSmp() As Sudoku.StrSmp,
                     ByRef _opk(,) As Integer,
                     ByRef _nuplet(,) As String)

        Dim _r As Integer 'indice région
        Dim _csgi As Integer 'Coin supérieur gauche région
        Dim _csgj As Integer 'Coin supérieur gauche région
        Dim _i As Integer
        Dim _j As Integer
        Dim _ibis As Integer
        Dim _iter As Integer
        Dim _jbis As Integer
        Dim _aile_int As String    'aile intérieure à la région
        Dim _aile_int_i As Integer 'aile intérieure à la région
        Dim _aile_int_j As Integer 'aile intérieure à la région
        Dim _sommet As String
        Dim _sommet_i As Integer
        Dim _sommet_j As Integer
        Dim _aile_ext As String    'aile extérieure à la région
        Dim _aile_ext_i As Integer 'aile extérieure à la région
        Dim _aile_ext_j As Integer 'aile extérieure à la région
        Dim _aei As Integer      'calcul départ i aile extérieure à la région
        Dim _exclu As String
        Dim _exclu_k As Integer
        Dim _completed As Boolean
        Dim _Smp As Sudoku.StrSmp
        Dim _commun As Integer

        _Smp = NewSmp()

        For _r = 0 To 8
            _csgi = (_r \ 3) * 3 'calcul du coin supérieur gauche d'une région
            _csgj = (_r - _csgi) * 3 'calcul du coin supérieur gauche d'une région
            For _j = _csgj To _csgj + 2
                For _i = _csgi To _csgi + 2
                    If _opk(_i, _j) = 2 Then
                        _sommet = _nuplet(_i, _j)
                        _sommet_i = _i
                        _sommet_j = _j

                        For _jbis = _csgj To _csgj + 2
                            If _jbis <> _j Then
                                For _ibis = _csgi To _csgi + 2
                                    If _opk(_ibis, _jbis) = 2 Then
                                        _aile_int = _nuplet(_ibis, _jbis)
                                        _aile_int_i = _ibis
                                        _aile_int_j = _jbis
                                        CommunIni(_aile_int, _sommet, _commun)
                                        If _commun Then
                                            For _iter = 0 To 8
                                                If _iter < _csgi Or _iter > _csgi + 2 Then
                                                    If _opk(_iter, _j) = 2 Then
                                                        _aile_ext = _nuplet(_iter, _j)
                                                        _aile_ext_i = _iter
                                                        _aile_ext_j = _j
                                                        CommunSuite(_sommet, _aile_ext, _commun)
                                                        If _commun Then
                                                            _exclu = " "
                                                            _completed = False
                                                            XYWing(_completed, _aile_int, _aile_ext, _exclu)

                                                            If _completed Then
                                                                _exclu_k = _exclu - 1
                                                                _Smp.nr = 3
                                                                _Smp.CR.i(0) = CInt(_aile_int_i)
                                                                _Smp.CR.j(0) = CInt(_aile_int_j)
                                                                _Smp.CR.k(0) = _exclu_k
                                                                _Smp.CR.v(0) = _exclu
                                                                _Smp.CR.i(1) = CInt(_sommet_i)
                                                                _Smp.CR.j(1) = CInt(_sommet_j)
                                                                _Smp.CR.k(1) = _exclu_k
                                                                _Smp.CR.v(1) = _exclu
                                                                _Smp.CR.i(2) = CInt(_aile_ext_i)
                                                                _Smp.CR.j(2) = CInt(_aile_ext_j)
                                                                _Smp.CR.k(2) = _exclu_k
                                                                _Smp.CR.v(2) = _exclu
                                                                _Smp.motif = "XY-Wing [" & _exclu & "] dans les cases L" & _aile_int_i + 1 & "C" & _aile_int_j + 1 & "-L" & _sommet_i + 1 & "C" & _sommet_j + 1 & "-L" & _aile_ext_i + 1 & "C" & _aile_ext_j + 1

                                                                ' Intersection à l'intérieur de la région 
                                                                For _ei = _csgi To _csgi + 2
                                                                    If _ei <> _sommet_i Then
                                                                        If _Candidats(_ei, _j, _exclu_k) = _exclu Then
                                                                            _Smp.CE.i(_Smp.ne) = _ei
                                                                            _Smp.CE.j(_Smp.ne) = _j
                                                                            _Smp.CE.k(_Smp.ne) = _exclu_k
                                                                            _Smp.CE.v(_Smp.ne) = _exclu
                                                                            _Smp.ne += 1
                                                                        End If
                                                                    End If
                                                                Next

                                                                ' Intersection à l'extérieur de la région
                                                                _aei = (_aile_ext_i \ 3) * 3 'calcul du départ de _i de l'aile exérieure

                                                                For _ei = _aei To _aei + 2
                                                                    If _Candidats(_ei, _aile_int_j, _exclu_k) = _exclu Then
                                                                        _Smp.CE.i(_Smp.ne) = _ei
                                                                        _Smp.CE.j(_Smp.ne) = CInt(_aile_int_j)
                                                                        _Smp.CE.k(_Smp.ne) = _exclu_k
                                                                        _Smp.CE.v(_Smp.ne) = _exclu
                                                                        _Smp.ne += 1
                                                                    End If
                                                                Next

                                                                If _Smp.ne > 0 Then
                                                                    _TSmp(_NbrSmp) = _Smp
                                                                    _NbrSmp += 1
                                                                    _Smp = NewSmp()
                                                                End If

                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            Next
                                        End If
                                    End If
                                Next
                            End If
                        Next
                    End If
                Next
            Next
        Next

    End Sub

    '============================================================================================================================================================
    ' Techniques d'élimination de candidats 
    ' Analyse XY-Wing 
    '============================================================================================================================================================

    Sub XYWing(ByRef _completed As Boolean, ByVal _aile_g As String, ByVal _aile_d As String, ByRef _exclu As String)

        _completed = False

        If Mid(_aile_g, 1, 1) = Mid(_aile_d, 2, 1) Then
            _completed = True
            _exclu = Mid(_aile_g, 1, 1)
        End If


    End Sub

    '============================================================================================================================================================
    ' Techniques d'élimination de candidats
    ' X-Wing en ligne
    '============================================================================================================================================================

    Sub XWingLig(ByRef _Candidats(,,) As Integer,
                       ByRef _NbrSmp As Integer,
                       ByRef _TSmp() As Sudoku.StrSmp,
                       ByRef _AnlLig(,) As Sudoku.StrAnalyse,
                       ByRef _Grille(,) As Integer,
                       ByVal _nbVal As Integer)

        Dim _isup As Integer ' indice i ligne supérieure 
        Dim _iinf As Integer ' indice i ligne inférieure 
        Dim _jgau As Integer ' indice j colonne gauche
        Dim _jdrt As Integer ' indice j colonne droite
        Dim _k As Integer
        Dim _actif As Boolean
        Dim _Smp As Sudoku.StrSmp

        _Smp = NewSmp()

        For _isup = 0 To 7
            For _k = 0 To 8
                If _AnlLig(_isup, _k).n = 2 Then
                    For _iinf = _isup + 1 To 8
                        If _AnlLig(_iinf, _k).n = 2 Then
                            For _jgau = 0 To 7
                                If _Candidats(_isup, _jgau, _k) <> 0 And _Candidats(_isup, _jgau, _k) = _Candidats(_iinf, _jgau, _k) Then
                                    For _jdrt = _jgau + 1 To 8
                                        If _Candidats(_isup, _jdrt, _k) <> 0 And _Candidats(_isup, _jdrt, _k) = _Candidats(_iinf, _jdrt, _k) Then
                                            ' on tient un X-Wing
                                            _Smp.ne = 0
                                            _actif = False
                                            For _i = 0 To 8
                                                If _i <> _isup And _i <> _iinf Then
                                                    If _Grille(_i, _jgau) = "0" Then
                                                        If _Candidats(_i, _jgau, _k) = _k + 1 Then
                                                            _actif = True
                                                            _Smp.CE.i(_Smp.ne) = _i
                                                            _Smp.CE.j(_Smp.ne) = _jgau
                                                            _Smp.CE.k(_Smp.ne) = _k
                                                            _Smp.CE.v(_Smp.ne) = _Candidats(_i, _jgau, _k)
                                                            _Smp.ne += 1
                                                        End If
                                                    End If
                                                    If _Grille(_i, _jdrt) = "0" Then
                                                        If _Candidats(_i, _jdrt, _k) = _k + 1 Then
                                                            _actif = True
                                                            _Smp.CE.i(_Smp.ne) = _i
                                                            _Smp.CE.j(_Smp.ne) = _jdrt
                                                            _Smp.CE.k(_Smp.ne) = _k
                                                            _Smp.CE.v(_Smp.ne) = _Candidats(_i, _jdrt, _k)
                                                            _Smp.ne += 1
                                                        End If
                                                    End If
                                                End If
                                            Next

                                            If _actif Then
                                                _Smp.nr = 4
                                                _Smp.CR.i(0) = _isup
                                                _Smp.CR.j(0) = _jgau
                                                _Smp.CR.k(0) = _k
                                                _Smp.CR.v(0) = _Smp.CE.v(0)
                                                _Smp.CR.i(1) = _isup
                                                _Smp.CR.j(1) = _jdrt
                                                _Smp.CR.k(1) = _k
                                                _Smp.CR.v(1) = _Smp.CE.v(0)
                                                _Smp.CR.i(2) = _iinf
                                                _Smp.CR.j(2) = _jdrt
                                                _Smp.CR.k(2) = _k
                                                _Smp.CR.v(2) = _Smp.CE.v(0)
                                                _Smp.CR.i(3) = _iinf
                                                _Smp.CR.j(3) = _jgau
                                                _Smp.CR.k(3) = _k
                                                _Smp.CR.v(3) = _Smp.CE.v(0)

                                                _Smp.motif = "X-Wing [" & _Smp.CE.v(0) & "] trouvé dans les cellules : L" & _isup + 1 & "C" & _jgau + 1 & "-L" & _isup + 1 & "C" & _jdrt + 1 & "-L" & _iinf + 1 & "C" & _jgau + 1 & "-L" & _iinf + 1 & "C" & _jdrt + 1

                                                If _Smp.ne > 0 Then
                                                    _TSmp(_NbrSmp) = _Smp
                                                    _NbrSmp += 1
                                                    _Smp = NewSmp()
                                                End If

                                            End If
                                        End If
                                    Next
                                End If
                            Next
                        End If
                    Next
                End If
            Next
        Next

    End Sub

    '============================================================================================================================================================
    ' Techniques d'élimination de candidats
    ' X-Wing en colonne
    '============================================================================================================================================================

    Sub XWingCol(ByRef _Candidats(,,) As Integer,
                       ByRef _NbrSmp As Integer,
                       ByRef _TSmp() As Sudoku.StrSmp,
                       ByRef _AnlCol(,) As Sudoku.StrAnalyse,
                       ByRef _Grille(,) As Integer,
                       ByVal _nbVal As Integer)

        Dim _isup As Integer ' indice i ligne supérieure 
        Dim _iinf As Integer ' indice i ligne inférieure 
        Dim _jgau As Integer ' indice j colonne gauche
        Dim _jdrt As Integer ' indice j colonne droite
        Dim _k As Integer
        Dim _actif As Boolean
        Dim _Smp As Sudoku.StrSmp

        _Smp = NewSmp()

        For _jgau = 0 To 7
            For _k = 0 To 8
                If _AnlCol(_jgau, _k).n = 2 Then
                    For _jdrt = _jgau + 1 To 8
                        If _AnlCol(_jdrt, _k).n = 2 Then
                            For _isup = 0 To 7
                                If _Candidats(_isup, _jgau, _k) <> 0 And _Candidats(_isup, _jgau, _k) = _Candidats(_isup, _jdrt, _k) Then
                                    For _iinf = _isup + 1 To 8
                                        If _Candidats(_iinf, _jgau, _k) <> 0 And _Candidats(_iinf, _jgau, _k) = _Candidats(_iinf, _jdrt, _k) Then
                                            ' on tient un X-Wing
                                            _Smp.ne = 0
                                            _actif = False
                                            For _j = 0 To 8
                                                If _j <> _jgau And _j <> _jdrt Then
                                                    If _Grille(_isup, _j) = "0" Then
                                                        If _Candidats(_isup, _j, _k) = _k + 1 Then
                                                            _actif = True
                                                            _Smp.CE.i(_Smp.ne) = _isup
                                                            _Smp.CE.j(_Smp.ne) = _j
                                                            _Smp.CE.k(_Smp.ne) = _k
                                                            _Smp.CE.v(_Smp.ne) = _Candidats(_isup, _j, _k)
                                                            _Smp.ne += 1
                                                        End If
                                                    End If
                                                    If _Grille(_iinf, _j) = "0" Then
                                                        If _Candidats(_iinf, _j, _k) = _k + 1 Then
                                                            _actif = True
                                                            _Smp.CE.i(_Smp.ne) = _iinf
                                                            _Smp.CE.j(_Smp.ne) = _j
                                                            _Smp.CE.k(_Smp.ne) = _k
                                                            _Smp.CE.v(_Smp.ne) = _Candidats(_iinf, _j, _k)
                                                            _Smp.ne += 1
                                                        End If
                                                    End If
                                                End If
                                            Next

                                            If _actif Then
                                                _Smp.nr = 4
                                                _Smp.CR.i(0) = _isup
                                                _Smp.CR.j(0) = _jgau
                                                _Smp.CR.k(0) = _k
                                                _Smp.CR.v(0) = _Smp.CE.v(0)
                                                _Smp.CR.i(1) = _isup
                                                _Smp.CR.j(1) = _jdrt
                                                _Smp.CR.k(1) = _k
                                                _Smp.CR.v(1) = _Smp.CE.v(0)
                                                _Smp.CR.i(2) = _iinf
                                                _Smp.CR.j(2) = _jdrt
                                                _Smp.CR.k(2) = _k
                                                _Smp.CR.v(2) = _Smp.CE.v(0)
                                                _Smp.CR.i(3) = _iinf
                                                _Smp.CR.j(3) = _jgau
                                                _Smp.CR.k(3) = _k
                                                _Smp.CR.v(3) = _Smp.CE.v(0)

                                                _Smp.motif = "X-Wing [" & _Smp.CE.v(0) & "] trouvé dans les cellules : L" & _isup + 1 & "C" & _jgau + 1 & "-L" & _isup + 1 & "C" & _jdrt + 1 & "-L" & _iinf + 1 & "C" & _jgau + 1 & "-L" & _iinf + 1 & "C" & _jdrt + 1

                                                If _Smp.ne > 0 Then
                                                    _TSmp(_NbrSmp) = _Smp
                                                    _NbrSmp += 1
                                                    _Smp = NewSmp()
                                                End If

                                            End If
                                        End If
                                    Next
                                End If
                            Next
                        End If
                    Next
                End If
            Next
        Next

    End Sub

    '============================================================================================================================================================
    ' Techniques d'élimination de candidats
    ' Paire cachée en ligne
    '============================================================================================================================================================

    Sub PaireCachéeLig(ByRef _Candidats(,,) As Integer,
                       ByRef _NbrSmp As Integer,
                       ByRef _TSmp() As Sudoku.StrSmp,
                       ByRef _AnlLig(,) As Sudoku.StrAnalyse,
                       ByRef _opk(,) As Integer,
                       ByVal _nbval As Integer)

        Dim _i As Integer
        Dim _j As Integer
        Dim _jbis As Integer
        Dim _k0 As Integer
        Dim _k1 As Integer
        Dim _kbis As Integer
        Dim _Smp As Sudoku.StrSmp

        _Smp = NewSmp()

        For _i = 0 To 8
            For _k0 = 0 To 8
                If _AnlLig(_i, _k0).n = 2 Then ' recherche de la première paire de la ligne
                    For _k1 = _k0 + 1 To 8
                        If _AnlLig(_i, _k1).n = 2 Then ' recherche de la deuxième paire de la ligne
                            For _j = 0 To 7
                                If _Candidats(_i, _j, _k0) <> 0 And _Candidats(_i, _j, _k1) <> 0 Then 'localisation de la première paire sur la ligne
                                    For _jbis = _j + 1 To 8
                                        If _Candidats(_i, _jbis, _k0) <> 0 And _Candidats(_i, _jbis, _k1) <> 0 Then 'localisation de la deuxième paire sur la ligne
                                            If _opk(_i, _j) > 2 Or _opk(_i, _jbis) > 2 Then 'défini s'il y a des candidats à éliminer
                                                _Smp.ne = 0
                                                For _kbis = 0 To 8
                                                    If _k0 <> _kbis And _k1 <> _kbis Then
                                                        If _Candidats(_i, _j, _kbis) <> 0 Then
                                                            _Smp.CE.i(_Smp.ne) = _i
                                                            _Smp.CE.j(_Smp.ne) = _j
                                                            _Smp.CE.k(_Smp.ne) = _kbis
                                                            _Smp.CE.v(_Smp.ne) = _Candidats(_i, _j, _kbis)
                                                            _Smp.ne += 1
                                                        End If
                                                        If _Candidats(_i, _jbis, _kbis) <> 0 Then
                                                            _Smp.CE.i(_Smp.ne) = _i
                                                            _Smp.CE.j(_Smp.ne) = _jbis
                                                            _Smp.CE.k(_Smp.ne) = _kbis
                                                            _Smp.CE.v(_Smp.ne) = _Candidats(_i, _jbis, _kbis)
                                                            _Smp.ne += 1
                                                        End If
                                                    End If
                                                Next

                                                _Smp.nr = 2
                                                _Smp.CR.i(0) = _i
                                                _Smp.CR.j(0) = _j
                                                _Smp.CR.k(0) = _k0
                                                _Smp.CR.v(0) = _Candidats(_i, _j, _k0)
                                                _Smp.CR.i(1) = _i
                                                _Smp.CR.j(1) = _jbis
                                                _Smp.CR.k(1) = _k1
                                                _Smp.CR.v(1) = _Candidats(_i, _j, _k0)

                                                _Smp.motif = "Paire cachée [" & _k0 + 1 & _k1 + 1 & "] trouvé dans les cases : L" & _i + 1 & "C" & _j + 1 & "-L" & _i + 1 & "C" & _jbis + 1

                                                If _Smp.ne > 0 Then
                                                    _TSmp(_NbrSmp) = _Smp
                                                    _NbrSmp += 1
                                                    _Smp = NewSmp()
                                                End If
                                            End If
                                        End If
                                    Next
                                End If
                            Next
                        End If
                    Next
                End If
            Next
        Next

    End Sub

    '============================================================================================================================================================
    ' Techniques d'élimination de candidats
    ' Paire cachée en colonne
    '============================================================================================================================================================

    Sub PaireCachéeCol(ByRef _Candidats(,,) As Integer,
                       ByRef _NbrSmp As Integer,
                       ByRef _TSmp() As Sudoku.StrSmp,
                       ByRef _AnlCol(,) As Sudoku.StrAnalyse,
                       ByRef _opk(,) As Integer,
                       ByVal _nbval As Integer)

        Dim _i As Integer
        Dim _j As Integer
        Dim _ibis As Integer
        Dim _k0 As Integer
        Dim _k1 As Integer
        Dim _kbis As Integer
        Dim _Smp As Sudoku.StrSmp

        _Smp = NewSmp()

        For _j = 0 To 8
            For _k0 = 0 To 8
                If _AnlCol(_j, _k0).n = 2 Then ' recherche de la première paire de la colonne
                    For _k1 = _k0 + 1 To 8
                        If _AnlCol(_j, _k1).n = 2 Then ' recherche de la deuxième paire de la colonne
                            For _i = 0 To 7
                                If _Candidats(_i, _j, _k0) <> 0 And _Candidats(_i, _j, _k1) <> 0 Then 'localisation de la première paire sur la colonne
                                    For _ibis = _i + 1 To 8
                                        If _Candidats(_ibis, _j, _k0) <> 0 And _Candidats(_ibis, _j, _k1) <> 0 Then 'localisation de la deuxième paire sur la colonne
                                            If _opk(_i, _j) > 2 Or _opk(_ibis, _j) > 2 Then 'défini s'il y a des candidats à éliminer
                                                _Smp.ne = 0
                                                For _kbis = 0 To 8
                                                    If _k0 <> _kbis And _k1 <> _kbis Then
                                                        If _Candidats(_i, _j, _kbis) <> 0 Then
                                                            _Smp.CE.i(_Smp.ne) = _i
                                                            _Smp.CE.j(_Smp.ne) = _j
                                                            _Smp.CE.k(_Smp.ne) = _kbis
                                                            _Smp.CE.v(_Smp.ne) = _Candidats(_i, _j, _kbis)
                                                            _Smp.ne += 1
                                                        End If
                                                        If _Candidats(_ibis, _j, _kbis) <> 0 Then
                                                            _Smp.CE.i(_Smp.ne) = _ibis
                                                            _Smp.CE.j(_Smp.ne) = _j
                                                            _Smp.CE.k(_Smp.ne) = _kbis
                                                            _Smp.CE.v(_Smp.ne) = _Candidats(_ibis, _j, _kbis)
                                                            _Smp.ne += 1
                                                        End If
                                                    End If
                                                Next

                                                _Smp.nr = 2
                                                _Smp.CR.i(0) = _i
                                                _Smp.CR.j(0) = _j
                                                _Smp.CR.k(0) = _k0
                                                _Smp.CR.v(0) = _Candidats(_i, _j, _k0)
                                                _Smp.CR.i(1) = _ibis
                                                _Smp.CR.j(1) = _j
                                                _Smp.CR.k(1) = _k1
                                                _Smp.CR.v(1) = _Candidats(_i, _j, _k0)

                                                _Smp.motif = "Paire cachée [" & _k0 + 1 & _k1 + 1 & "] trouvé dans les cases : L" & _i + 1 & "C" & _j + 1 & "-L" & _ibis + 1 & "C" & _j + 1

                                                If _Smp.ne > 0 Then
                                                    _TSmp(_NbrSmp) = _Smp
                                                    _NbrSmp += 1
                                                    _Smp = NewSmp()
                                                End If
                                            End If
                                        End If
                                    Next
                                End If
                            Next
                        End If
                    Next
                End If
            Next
        Next

    End Sub

    '============================================================================================================================================================
    ' Techniques d'élimination de candidats
    ' Paire cachée en région
    '============================================================================================================================================================

    Sub PaireCachéeReg(ByRef _Candidats(,,) As Integer,
                       ByRef _NbrSmp As Integer,
                       ByRef _TSmp() As Sudoku.StrSmp,
                       ByRef _AnlReg(,) As Sudoku.StrAnalyse,
                       ByRef _opk(,) As Integer)

        Dim _k0 As Integer
        Dim _k1 As Integer
        Dim _kbis As Integer
        Dim _csgi As Integer 'Coin supérieur gauche région
        Dim _csgj As Integer 'Coin supérieur gauche région
        Dim _g As Integer
        Dim _gbis As Integer
        Dim _Smp As Sudoku.StrSmp

        _Smp = NewSmp()

        For _r = 0 To 8
            _csgi = (_r \ 3) * 3
            _csgj = (_r - _csgi) * 3

            For _k0 = 0 To 8
                If _AnlReg(_r, _k0).n = 2 Then ' recherche de la première paire de la région
                    For _k1 = _k0 + 1 To 8
                        If _AnlReg(_r, _k1).n = 2 Then ' recherche de la deuxième paire de la région
                            For _i = _csgi To _csgi + 2 'parcours de l'élément 1
                                For _j = _csgj To _csgj + 2 'parcours de l'élément 1
                                    If _Candidats(_i, _j, _k0) <> 0 And _Candidats(_i, _j, _k1) <> 0 Then 'localisation de la première paire de la région
                                        For _ibis = _csgi To _csgi + 2 'parcours de l'élément 2
                                            For _jbis = _csgj To _csgj + 2 'parcours de l'élément 2
                                                _g = (_i * 3) + _j
                                                _gbis = (_ibis * 3) + _jbis
                                                If _g < _gbis Then ' on ne cherche que dans un sens (élément 2 tjrs > élément 1) 
                                                    If _Candidats(_ibis, _jbis, _k0) <> 0 And _Candidats(_ibis, _jbis, _k1) <> 0 Then 'localisation de la deuxième paire de la région
                                                        If _opk(_i, _j) > 2 Or _opk(_ibis, _jbis) > 2 Then 'défini s'il y a des candidats à éliminer
                                                            _Smp.ne = 0
                                                            For _kbis = 0 To 8
                                                                If _k0 <> _kbis And _k1 <> _kbis Then
                                                                    If _Candidats(_i, _j, _kbis) <> 0 Then
                                                                        _Smp.CE.i(_Smp.ne) = _i
                                                                        _Smp.CE.j(_Smp.ne) = _j
                                                                        _Smp.CE.k(_Smp.ne) = _kbis
                                                                        _Smp.CE.v(_Smp.ne) = _Candidats(_i, _j, _kbis)
                                                                        _Smp.ne += 1
                                                                    End If
                                                                    If _Candidats(_ibis, _jbis, _kbis) <> 0 Then
                                                                        _Smp.CE.i(_Smp.ne) = _ibis
                                                                        _Smp.CE.j(_Smp.ne) = _jbis
                                                                        _Smp.CE.k(_Smp.ne) = _kbis
                                                                        _Smp.CE.v(_Smp.ne) = _Candidats(_ibis, _jbis, _kbis)
                                                                        _Smp.ne += 1
                                                                    End If
                                                                End If
                                                            Next

                                                            _Smp.nr = 2
                                                            _Smp.CR.i(0) = _i
                                                            _Smp.CR.j(0) = _j
                                                            _Smp.CR.k(0) = _k0
                                                            _Smp.CR.v(0) = _Candidats(_i, _j, _k0)
                                                            _Smp.CR.i(1) = _ibis
                                                            _Smp.CR.j(1) = _jbis
                                                            _Smp.CR.k(1) = _k1
                                                            _Smp.CR.v(1) = _Candidats(_ibis, _jbis, _k1)

                                                            _Smp.motif = "Paire cachée [" & _k0 + 1 & _k1 + 1 & "] trouvé dans les cases : L" & _i + 1 & "C" & _j + 1 & "-L" & _ibis + 1 & "C" & _jbis + 1

                                                            If _Smp.ne > 0 Then
                                                                _TSmp(_NbrSmp) = _Smp
                                                                _NbrSmp += 1
                                                                _Smp = NewSmp()
                                                            End If

                                                        End If
                                                    End If
                                                End If
                                            Next
                                        Next
                                    End If
                                Next
                            Next
                        End If
                    Next
                End If
            Next
        Next

    End Sub

    '============================================================================================================================================================
    ' Techniques d'élimination de candidats
    ' SwordFish en ligne
    '============================================================================================================================================================

    Sub SwordFishLig(ByRef _Candidats(,,) As Integer,
                       ByRef _NbrSmp As Integer,
                       ByRef _TSmp() As Sudoku.StrSmp,
                       ByRef _AnlLig(,) As Sudoku.StrAnalyse)

        Dim _swi(8) As Integer
        Dim _isw As Integer
        Dim _nbj As Integer
        Dim _ind1 As Integer
        Dim _ind2 As Integer
        Dim _ind3 As Integer
        Dim _i1 As Integer
        Dim _i2 As Integer
        Dim _i3 As Integer
        Dim _j1 As Integer
        Dim _j11 As Integer
        Dim _j12 As Integer
        Dim _j2 As Integer
        Dim _j21 As Integer
        Dim _j22 As Integer
        Dim _j3 As Integer
        Dim _j31 As Integer
        Dim _j32 As Integer
        Dim _tj(8) As Integer
        Dim _imax1 As Integer
        Dim _imax2 As Integer
        Dim _imax3 As Integer
        Dim _Smp As Sudoku.StrSmp

        _Smp = NewSmp()

        For _k = 0 To 8
            ' Recherches des lignes (3 ou +) du SwordFish
            _isw = 0
            For _i = 0 To 8
                If _AnlLig(_i, _k).n = 2 Then
                    _swi(_isw) = _i
                    _isw += 1
                End If
            Next
            _isw -= 1
            If _isw > 2 Then
                _imax1 = _isw - 2
                _imax2 = _isw - 1
                _imax3 = _isw

                _ind1 = 0
                _ind2 = 1
                _ind3 = 2
                Do
                    _i1 = _swi(_ind1)
                    _i2 = _swi(_ind2)
                    _i3 = _swi(_ind3)
                    ' Recherche des 3 colonnes du SwordFish
                    For _j = 0 To 8
                        _tj(_j) = 9
                    Next
                    _j1 = 0
                    _j2 = 0
                    _j3 = 0
                    For _j = 0 To 8
                        If _Candidats(_i1, _j, _k) = _k + 1 Then
                            _tj(_j) = _j
                            If _j1 = 0 Then
                                _j11 = _j
                            Else
                                _j12 = _j
                            End If
                            _j1 += 1
                        End If
                        If _Candidats(_i2, _j, _k) = _k + 1 Then
                            _tj(_j) = _j
                            If _j2 = 0 Then
                                _j21 = _j
                            Else
                                _j22 = _j
                            End If
                            _j2 += 1
                        End If
                        If _Candidats(_i3, _j, _k) = _k + 1 Then
                            _tj(_j) = _j
                            If _j3 = 0 Then
                                _j31 = _j
                            Else
                                _j32 = _j
                            End If
                            _j3 += 1
                        End If
                    Next
                    _nbj = 0
                    For _j = 0 To 8
                        If _tj(_j) <> 9 Then
                            _nbj += 1
                        End If
                    Next
                    If _nbj = 3 Then ' On tient un SwordFish
                        _Smp.ne = 0
                        For _j = 0 To 8
                            If _tj(_j) <> 9 Then
                                For _i = 0 To 8
                                    If _i <> _i1 And _i <> _i2 And _i <> _i3 Then
                                        If _Candidats(_i, _tj(_j), _k) = _k + 1 Then
                                            _Smp.CE.i(_Smp.ne) = _i
                                            _Smp.CE.j(_Smp.ne) = _tj(_j)
                                            _Smp.CE.k(_Smp.ne) = _k
                                            _Smp.CE.v(_Smp.ne) = _Candidats(_i, _tj(_j), _k)
                                            _Smp.ne += 1
                                        End If
                                    End If
                                Next
                            End If
                        Next
                        If _Smp.ne > 0 Then
                            _Smp.nr = 6
                            _Smp.CR.i(0) = _i1
                            _Smp.CR.j(0) = _j11
                            _Smp.CR.k(0) = _k
                            _Smp.CR.v(0) = _Candidats(_i1, _j11, _k)
                            _Smp.CR.i(1) = _i1
                            _Smp.CR.j(1) = _j12
                            _Smp.CR.k(1) = _k
                            _Smp.CR.v(1) = _Candidats(_i1, _j12, _k)
                            _Smp.CR.i(2) = _i2
                            _Smp.CR.j(2) = _j21
                            _Smp.CR.k(2) = _k
                            _Smp.CR.v(2) = _Candidats(_i2, _j21, _k)
                            _Smp.CR.i(3) = _i2
                            _Smp.CR.j(3) = _j22
                            _Smp.CR.k(3) = _k
                            _Smp.CR.v(3) = _Candidats(_i2, _j22, _k)
                            _Smp.CR.i(4) = _i3
                            _Smp.CR.j(4) = _j31
                            _Smp.CR.k(4) = _k
                            _Smp.CR.v(4) = _Candidats(_i3, _j31, _k)
                            _Smp.CR.i(5) = _i3
                            _Smp.CR.j(5) = _j32
                            _Smp.CR.k(5) = _k
                            _Smp.CR.v(5) = _Candidats(_i3, _j32, _k)
                            _Smp.motif = "Swordfish [" & _k + 1 & "] trouvé dans les cases : L" & _i1 + 1 & "C" & _j11 + 1 & "-L" & _i1 + 1 & "C" & _j12 + 1 & "-L" & _i2 + 1 & "C" & _j21 + 1 & "-L" & _i2 + 1 & "C" & _j22 + 1 & "-L" & _i3 + 1 & "C" & _j31 + 1 & "-L" & _i3 + 1 & "C" & _j32 + 1

                            _TSmp(_NbrSmp) = _Smp
                            _NbrSmp += 1
                            _Smp = NewSmp()

                        End If
                    End If

                    ' S'il y a plus de 3 lignes de 2 candidats k il faut gérer toutes les combinaisons
                    If _ind3 < _imax3 Then
                        _ind3 += 1
                    Else
                        If _ind2 < _imax2 Then
                            _ind2 += 1
                            _ind3 = _ind2 + 1
                        Else
                            _ind1 += 1
                            _ind2 = _ind1 + 1
                            _ind3 = _ind2 + 1
                        End If
                    End If
                Loop While _ind1 < _imax1 Or _ind2 < _imax2 Or _ind3 < _imax3
            End If
        Next

    End Sub

    '============================================================================================================================================================
    ' Techniques d'élimination de candidats
    ' SwordFish en colonne
    '============================================================================================================================================================

    Sub SwordFishCol(ByRef _Candidats(,,) As Integer,
                       ByRef _NbrSmp As Integer,
                       ByRef _TSmp() As Sudoku.StrSmp,
                       ByRef _AnlCol(,) As Sudoku.StrAnalyse)

        Dim _swj(8) As Integer
        Dim _jsw As Integer
        Dim _nbi As Integer
        Dim _ind1 As Integer
        Dim _ind2 As Integer
        Dim _ind3 As Integer
        Dim _j1 As Integer
        Dim _j2 As Integer
        Dim _j3 As Integer
        Dim _i1 As Integer
        Dim _i11 As Integer
        Dim _i12 As Integer
        Dim _i2 As Integer
        Dim _i21 As Integer
        Dim _i22 As Integer
        Dim _i3 As Integer
        Dim _i31 As Integer
        Dim _i32 As Integer
        Dim _ti(8) As Integer
        Dim _jmax1 As Integer
        Dim _jmax2 As Integer
        Dim _jmax3 As Integer
        Dim _Smp As Sudoku.StrSmp

        _Smp = NewSmp()

        For _k = 0 To 8
            ' Recherches des colonnes (3 ou +) du SwordFish
            _jsw = 0
            For _j = 0 To 8
                If _AnlCol(_j, _k).n = 2 Then
                    _swj(_jsw) = _j
                    _jsw += 1
                End If
            Next
            _jsw -= 1
            If _jsw > 2 Then
                _jmax1 = _jsw - 2
                _jmax2 = _jsw - 1
                _jmax3 = _jsw

                _ind1 = 0
                _ind2 = 1
                _ind3 = 2
                Do
                    _j1 = _swj(_ind1)
                    _j2 = _swj(_ind2)
                    _j3 = _swj(_ind3)
                    ' Recherche des 3 colonnes du SwordFish
                    For _i = 0 To 8
                        _ti(_i) = 9
                    Next
                    _i1 = 0
                    _i2 = 0
                    _i3 = 0
                    For _i = 0 To 8
                        If _Candidats(_i, _j1, _k) = _k + 1 Then
                            _ti(_i) = _i
                            If _i1 = 0 Then
                                _i11 = _i
                            Else
                                _i12 = _i
                            End If
                            _i1 += 1
                        End If
                        If _Candidats(_i, _j2, _k) = _k + 1 Then
                            _ti(_i) = _i
                            If _i2 = 0 Then
                                _i21 = _i
                            Else
                                _i22 = _i
                            End If
                            _i2 += 1
                        End If
                        If _Candidats(_i, _j3, _k) = _k + 1 Then
                            _ti(_i) = _i
                            If _i3 = 0 Then
                                _i31 = _i
                            Else
                                _i32 = _i
                            End If
                            _i3 += 1
                        End If
                    Next
                    _nbi = 0
                    For _i = 0 To 8
                        If _ti(_i) <> 9 Then
                            _nbi += 1
                        End If
                    Next
                    If _nbi = 3 Then ' On tient un SwordFish
                        _Smp.ne = 0
                        For _i = 0 To 8
                            If _ti(_i) <> 9 Then
                                For _j = 0 To 8
                                    If _j <> _j1 And _j <> _j2 And _j <> _j3 Then
                                        If _Candidats(_ti(_i), _j, _k) = _k + 1 Then
                                            _Smp.CE.i(_Smp.ne) = _ti(_i)
                                            _Smp.CE.j(_Smp.ne) = _j
                                            _Smp.CE.k(_Smp.ne) = _k
                                            _Smp.CE.v(_Smp.ne) = _Candidats(_ti(_i), _j, _k)
                                            _Smp.ne += 1
                                        End If
                                    End If
                                Next
                            End If
                        Next
                        If _Smp.ne > 0 Then
                            _Smp.nr = 6
                            _Smp.CR.i(0) = _i11
                            _Smp.CR.j(0) = _j1
                            _Smp.CR.k(0) = _k
                            _Smp.CR.v(0) = _Candidats(_i11, _j1, _k)
                            _Smp.CR.i(1) = _i12
                            _Smp.CR.j(1) = _j1
                            _Smp.CR.k(1) = _k
                            _Smp.CR.v(1) = _Candidats(_i12, _j1, _k)
                            _Smp.CR.i(2) = _i21
                            _Smp.CR.j(2) = _j2
                            _Smp.CR.k(2) = _k
                            _Smp.CR.v(2) = _Candidats(_i21, _j2, _k)
                            _Smp.CR.i(3) = _i22
                            _Smp.CR.j(3) = _j2
                            _Smp.CR.k(3) = _k
                            _Smp.CR.v(3) = _Candidats(_i22, _j2, _k)
                            _Smp.CR.i(4) = _i31
                            _Smp.CR.j(4) = _j3
                            _Smp.CR.k(4) = _k
                            _Smp.CR.v(4) = _Candidats(_i31, _j3, _k)
                            _Smp.CR.i(5) = _i32
                            _Smp.CR.j(5) = _j3
                            _Smp.CR.k(5) = _k
                            _Smp.CR.v(5) = _Candidats(_i32, _j3, _k)
                            _Smp.motif = "Swordfish [" & _k + 1 & "] trouvé dans les cases : L" & _i11 + 1 & "C" & _j1 + 1 & "-L" & _i12 + 1 & "C" & _j1 + 1 & "-L" & _i21 + 1 & "C" & _j2 + 1 & "-L" & _i22 + 1 & "C" & _j2 + 1 & "-L" & _i31 + 1 & "C" & _j3 + 1 & "-L" & _i32 + 1 & "C" & _j3 + 1

                            _TSmp(_NbrSmp) = _Smp
                            _NbrSmp += 1
                            _Smp = NewSmp()

                        End If
                    End If

                    ' S'il y a plus de 3 lignes de 2 candidats k il faut gérer toutes les combinaisons
                    If _ind3 < _jmax3 Then
                        _ind3 += 1
                    Else
                        If _ind2 < _jmax2 Then
                            _ind2 += 1
                            _ind3 = _ind2 + 1
                        Else
                            _ind1 += 1
                            _ind2 = _ind1 + 1
                            _ind3 = _ind2 + 1
                        End If
                    End If
                Loop While _ind1 < _jmax1 Or _ind2 < _jmax2 Or _ind3 < _jmax3
            End If
        Next

    End Sub



    '============================================================================================================================================================
    '============================================================================================================================================================
    ' Applique Une solution & la grille de sudoku
    '============================================================================================================================================================
    '============================================================================================================================================================

    Sub AppliqueUneSolution(ByRef _Qsol As Queue(Of Sudoku.StrSolution),
                            ByRef _Grille(,) As Integer,
                            ByRef _Candidats(,,) As Integer,
                            ByRef _NbVal As Integer,
                            ByRef _NbvalMax As Integer,
                            ByRef _i As Integer,
                            ByRef _j As Integer,
                            ByRef _v As Integer)

        Dim _Solution As Sudoku.StrSolution

        _Solution = _Qsol.Dequeue()
        _i = _Solution.i
        _j = _Solution.j
        _v = _Solution.v
        _Grille(_i, _j) = _v

        Sudoku.Historique(_NbVal).i = _Solution.i
        Sudoku.Historique(_NbVal).j = _Solution.j
        Sudoku.Historique(_NbVal).v = _Solution.v
        _NbVal += 1

        RecalculCandidats(_i, _j, _Grille, _Candidats) ' Efface les candidats éliminés par la solution appliquée 

        If _NbVal > _NbvalMax Then
            _NbvalMax = _NbVal
        End If

    End Sub

    '============================================================================================================================================================
    '============================================================================================================================================================
    ' Suppression de candidats dans la grille
    ' Applique et retire une Maille de chaîne
    '============================================================================================================================================================
    '============================================================================================================================================================

    Sub AppliqueUneMaille(ByRef _Grille(,) As Integer,
                          ByRef _Candidats(,,) As Integer,
                          ByRef _NbVal As Integer,
                          ByRef _NbvalMax As Integer,
                          ByVal _i As Integer,
                          ByVal _j As Integer,
                          ByVal _v As Integer)

        _Grille(_i, _j) = _v

        Sudoku.Historique(_NbVal).i = _i
        Sudoku.Historique(_NbVal).j = _j
        Sudoku.Historique(_NbVal).v = _v
        _NbVal += 1

        RecalculCandidats(_i, _j, _Grille, _Candidats) ' Efface les candidats éliminés par la solution appliquée 

        If _NbVal > _NbvalMax Then
            _NbvalMax = _NbVal
        End If

    End Sub

    '============================================================================================================================================================
    '============================================================================================================================================================
    ' Suppression de candidats dans la grille
    ' Applique et retire une occurrence de la table des simplifications
    '============================================================================================================================================================
    '============================================================================================================================================================

    Sub AppliqueUneSimplification(ByRef _NbrSmp As Integer,
                                  ByRef _TSmp() As Sudoku.StrSmp,
                                  ByRef _Candidats(,,) As Integer)

        Dim _s As Integer
        Dim _i As Integer
        Dim _j As Integer
        Dim _k As Integer
        Dim _Smp As Sudoku.StrSmp

        _Smp = _TSmp(0)

        For _s = 0 To _Smp.ne - 1
            _i = _Smp.CE.i(_s)
            _j = _Smp.CE.j(_s)
            _k = _Smp.CE.k(_s)
            _Candidats(_i, _j, _k) = 0
        Next

        For s = 0 To _NbrSmp - 1
            _TSmp(_NbrSmp) = _TSmp(_NbrSmp + 1)
        Next

        _TSmp(_NbrSmp) = NewSmp()

        _NbrSmp -= 1

    End Sub

    '============================================================================================================================================================
    ' Remise à zéro de la table des simplifications
    '============================================================================================================================================================

    Sub TsmpClear(ByRef _NbrSmp As Integer,
                  ByRef _TSmp() As Sudoku.StrSmp)

        Dim _t As Integer

        For _t = 0 To 80
            _TSmp(_t) = NewSmp()
        Next

        _NbrSmp = 0

    End Sub


    '============================================================================================================================================================
    '  Fonctions & subroutines accessoires
    '============================================================================================================================================================

    '============================================================================================================================================================
    ' Fait une rotation des paires en carré
    '============================================================================================================================================================
    Sub RotationCarré(ByRef _cv() As Integer,
                      ByRef _ci() As Integer,
                      ByRef _cj() As Integer)

        Dim _tc As Integer
        Dim _ti As Integer
        Dim _tj As Integer
        Dim _r As Integer

        _tc = _cv(0)
        _ti = _ci(0)
        _tj = _cj(0)
        For _r = 0 To 2
            _cv(_r) = _cv(_r + 1)
            _ci(_r) = _ci(_r + 1)
            _cj(_r) = _cj(_r + 1)
        Next
        _cv(3) = _tc
        _ci(3) = _ti
        _cj(3) = _tj

    End Sub

    '============================================================================================================================================================
    ' Détermine si 2 paires ont une valeur en commun et Oriente les paires 1 & 2
    '============================================================================================================================================================

    Sub CommunIni(ByRef _paire1 As String,
               ByRef _paire2 As String,
               ByRef _commun As Boolean)

        Dim _permut As String

        _commun = False

        If Mid(_paire1, 1, 1) = Mid(_paire2, 1, 1) Then
            _permut = Mid(_paire1, 2, 1) & Mid(_paire1, 1, 1)
            _paire1 = _permut
            _commun = True
        Else
            If Mid(_paire1, 1, 1) = Mid(_paire2, 2, 1) Then
                _permut = Mid(_paire1, 2, 1) & Mid(_paire1, 1, 1)
                _paire1 = _permut
                _permut = Mid(_paire2, 2, 1) & Mid(_paire2, 1, 1)
                _paire2 = _permut
                _commun = True
            Else
                If Mid(_paire1, 2, 1) = Mid(_paire2, 1, 1) Then
                    _commun = True
                Else
                    If Mid(_paire1, 2, 1) = Mid(_paire2, 2, 1) Then
                        _permut = Mid(_paire2, 2, 1) & Mid(_paire2, 1, 1)
                        _paire2 = _permut
                        _commun = True
                    End If
                End If
            End If
        End If

    End Sub

    '============================================================================================================================================================
    ' Détermine si 2 paires ont une valeur en commun et Oriente la paire 2
    '============================================================================================================================================================

    Sub CommunSuite(ByVal _paire1 As String,
               ByRef _paire2 As String,
               ByRef _commun As Boolean)

        Dim _permut As String

        _commun = False

        If Mid(_paire1, 2, 1) = Mid(_paire2, 1, 1) Then
            _commun = True
        Else
            If Mid(_paire1, 2, 1) = Mid(_paire2, 2, 1) Then
                _permut = Mid(_paire2, 2, 1) & Mid(_paire2, 1, 1)
                _paire2 = _permut
                _commun = True
            End If
        End If

    End Sub


    '============================================================================================================================================================
    ' Initialise une structure Smp avec les dimensionnements de tableaux
    '============================================================================================================================================================

    Function NewSmp()

        Dim _Newsmp As Sudoku.StrSmp
        Dim _t As Integer

        ReDim _Newsmp.CR.i(20)
        ReDim _Newsmp.CR.j(20)
        ReDim _Newsmp.CR.k(20)
        ReDim _Newsmp.CR.v(20)
        ReDim _Newsmp.CE.i(20)
        ReDim _Newsmp.CE.j(20)
        ReDim _Newsmp.CE.k(20)
        ReDim _Newsmp.CE.v(20)

        _Newsmp.motif = " "
        _Newsmp.act = False
        _Newsmp.nr = 0

        For _t = 0 To 3
            _Newsmp.CR.i(_t) = 0
            _Newsmp.CR.j(_t) = 0
            _Newsmp.CR.k(_t) = 0
            _Newsmp.CR.v(_t) = 0
        Next
        _Newsmp.ne = 0

        For _t = 0 To 20
            _Newsmp.CE.i(_t) = 0
            _Newsmp.CE.j(_t) = 0
            _Newsmp.CE.k(_t) = 0
            _Newsmp.CE.v(_t) = 0
        Next

        _Newsmp.MultiSol = False

        Return _Newsmp

    End Function

End Module
