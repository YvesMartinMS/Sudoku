Module Solveur

    Sub Initialisations(ByRef _Grille(,) As String, ByRef _Candidats(,,) As String)

        Dim _k As Integer

        ' Initialise les candidats
        For _i = 0 To 8
            For _j = 0 To 8
                If _Grille(_i, _j) <> "0" Then
                    For _k = 0 To 8
                        _Candidats(_i, _j, _k) = " "
                    Next
                Else
                    For _k = 0 To 8
                        _Candidats(_i, _j, _k) = _k + 1
                    Next
                End If
            Next
        Next

    End Sub

    Sub ControleLigne(ByRef _Erreur As Boolean, ByRef _ErreurGrille(,) As String, ByVal _Grille(,) As String, _i As Integer)

        ' Contrôle les doublons d'une ligne
        Dim _j As Integer
        Dim _jbis As Integer
        Dim _ierr As Integer
        Dim _jerr As Integer

        ' Initialise _ErreurGrille
        For _ierr = 0 To 8
            For _jerr = 0 To 8
                _ErreurGrille(_ierr, _jerr) = " "
            Next
        Next

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

    Sub ControleColonne(ByRef _Erreur As Boolean, ByRef _ErreurGrille(,) As String, ByVal _Grille(,) As String, _j As Integer)

        ' Contrôle les doublons d'une colonne
        Dim _i As Integer
        Dim _ibis As Integer

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

    Sub ControleRégion(ByRef _Erreur As Boolean, ByRef _ErreurGrille(,) As String, ByVal _Grille(,) As String, _r As Integer)

        ' Contrôle les doublons d'une région
        Dim _i As Integer
        Dim _j As Integer
        Dim _ibis As Integer
        Dim _jbis As Integer
        Dim _ir As Integer
        Dim _jr As Integer

        _ir = (_r \ 3) * 3
        _jr = (_r - _ir) * 3
        For _i = _ir To _ir + 2
            For _j = _jr To _jr + 2
                For _ibis = _ir To _ir + 2
                    For _jbis = _jr To _jr + 2
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

    Sub ControleCandidatLigne(ByRef _Erreur As Boolean, ByRef _ErreurGrille(,) As String, ByVal _Grille(,) As String, ByVal _Candidats(,,) As String, _i As Integer)

        ' vérifie que pour une case non occupée il existe au moins un candidat

        Dim _j As Integer
        Dim _k As Integer
        Dim _ErreurCandidat(8, 8)

        For _j = 0 To 8
            If _Grille(_i, _j) = "0" Then
                _ErreurCandidat(_i, _j) = "X"
                For _k = 0 To 8
                    If _Candidats(_i, _j, _k) <> " " Then
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

    Sub ControleCandidatColonne(ByRef _Erreur As Boolean, ByRef _ErreurGrille(,) As String, ByVal _Grille(,) As String, ByVal _Candidats(,,) As String, _j As Integer)

        ' vérifie que pour une case non occupée il existe au moins un candidat

        Dim _i As Integer
        Dim _k As Integer
        Dim _ErreurCandidat(8, 8)

        For _i = 0 To 8
            If _Grille(_i, _j) = "0" Then
                _ErreurCandidat(_i, _j) = "X"
                For _k = 0 To 8
                    If _Candidats(_i, _j, _k) <> " " Then
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

    Sub ControleCandidatRégion(ByRef _Erreur As Boolean, ByRef _ErreurGrille(,) As String, ByVal _Grille(,) As String, ByVal _Candidats(,,) As String, _r As Integer)

        Dim _i As Integer
        Dim _j As Integer
        Dim _ir As Integer
        Dim _jr As Integer
        Dim _k As Integer
        Dim _ErreurCandidat(8, 8)
        _ir = (_r \ 3) * 3
        _jr = (_r - _ir) * 3
        For _i = _ir To _ir + 2
            For _j = _jr To _jr + 2
                If _Grille(_i, _j) = "0" Then
                    _ErreurCandidat(_i, _j) = "X"
                    For _k = 0 To 8
                        If _Candidats(_i, _j, _k) <> " " Then
                            _ErreurCandidat(_i, _j) = " "
                        End If
                    Next
                    If _ErreurCandidat(_i, _j) = "X" Then
                        _ErreurGrille(_i, _j) = "X"
                        _Erreur = True
                    End If
                End If
            Next
        Next

    End Sub

    Sub ControleGénération(ByRef _Erreur As Boolean, ByRef _ErreurGrille(,) As String, ByVal _Grille(,) As String, ByVal _Candidats(,,) As String)
        ' Recherche d'erreurs sur les lignes
        ' case sans candidat ou deux fois la même valeur sur un segment
        Dim _i As Integer
        Dim _j As Integer
        Dim _r As Integer

        _Erreur = False
        ' Recherche d'erreurs sur les lignes
        For _i = 0 To 8
            ControleLigne(_Erreur, _ErreurGrille, _Grille, _i)
            ControleCandidatLigne(_Erreur, _ErreurGrille, _Grille, _Candidats, _i)
        Next

        ' Recherche d'erreurs sur les colonnes
        For _j = 0 To 8
            ControleColonne(_Erreur, _ErreurGrille, _Grille, _j)
            ControleCandidatColonne(_Erreur, _ErreurGrille, _Grille, _Candidats, _j)
        Next

        ' Recherche d'erreurs sur les régions
        For _r = 0 To 8
            ControleRégion(_Erreur, _ErreurGrille, _Grille, _r)
            ControleCandidatRégion(_Erreur, _ErreurGrille, _Grille, _Candidats, _r)
        Next

    End Sub
    '
    ' ============================================================================================================================================
    '
    '                                                         M O T E U R
    '
    '============================================================================================================================================
    '

    Sub Calcul_Candidats(ByRef _Grille(,) As String, ByRef _Candidats(,,) As String,
                         ByRef _TabSolution() As Sudoku.StrSolution, ByRef _NbSol As Integer,
                         _Simplification() As Sudoku.StrSimplification, ByRef _NbSmp As Integer)
        '
        ' Elimine les candidats dans les lignes colonnes et régions
        '
        Dim _i As Integer
        Dim _j As Integer
        Dim _r As Integer

        Dim _opk(8, 8) As Integer ' Candidats par case
        Dim _nuplet(8, 8) As String ' Candidats agrégés
        Dim _AnlLig(8, 8) As Sudoku.StrAnalyse
        Dim _AnlCol(8, 8) As Sudoku.StrAnalyse
        Dim _AnlReg(8, 8) As Sudoku.StrAnalyse

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

        'initialise les compteurs
        For _i = 0 To 8
            For _j = 0 To 8
                _opk(_i, _j) = 0
            Next
        Next

        'Mise à jour le tableau des occurrences par case
        AnalyseCase(_Candidats, _opk, _nuplet)

        'Mise à jour le tableau des occurrences par ligne
        AnalyseLigne(_Candidats, _AnlLig)

        'Mise à jour le tableau des occurrences par colonne
        AnalyseColonne(_Candidats, _AnlCol)

        'Mise à jour le tableau des occurrences par région
        AnalyseRégion(_Candidats, _AnlReg)

        _NbSol = 0
        SeulDansUneCase(_NbSol, _Candidats, _opk, _TabSolution)
        SeulDansUneLigne(_NbSol, _AnlLig, _TabSolution)
        SeulDansUneColonne(_NbSol, _AnlCol, _TabSolution)
        SeulDansUneRégion(_NbSol, _AnlReg, _TabSolution)

        'Dimentionnement du tableau dans la structure _ Initialisation de valeurs nulles

        For i = 0 To 20
            ReDim _Simplification(i).i(20)
            ReDim _Simplification(i).j(20)
            ReDim _Simplification(i).k(20)
            ReDim _Simplification(i).v(20)
            _Simplification(i).n = 0
            For j = 0 To 20
                _Simplification(i).i(j) = 0
                _Simplification(i).j(j) = 0
                _Simplification(i).k(j) = 0
                _Simplification(i).v(j) = " "
                _Simplification(i).m = " "
                _Simplification(i).act = False
            Next
        Next
        If _NbSol = 0 Then
            PaireNueLig(_Candidats, _Simplification, _NbSmp, _opk, _nuplet)
            PaireNueCol(_Candidats, _Simplification, _NbSmp, _opk, _nuplet)
            PaireNueReg(_Candidats, _Simplification, _NbSmp, _opk, _nuplet)
        End If

    End Sub

    Sub GommeLigne(ByVal Grille(,) As String, ByRef Candidats(,,) As String, _i As Integer)

        'Elimine les candidats dans une ligne

        Dim _j As Integer
        Dim _jbis As Integer
        Dim _k As Integer
        Dim _s As Integer

        For _j = 0 To 8
            If Grille(_i, _j) <> "0" Then
                For _k = 0 To 8
                    If Val(_k + 1) = Grille(_i, _j) Then
                        _s = _k
                    End If
                Next
                For _jbis = 0 To 8
                    Candidats(_i, _jbis, _s) = " "
                Next
            End If
        Next

    End Sub

    Sub GommeColonne(ByVal Grille(,) As String, ByRef Candidats(,,) As String, _j As Integer)

        'Elimine les candidats dans une colonne

        Dim _i As Integer
        Dim _ibis As Integer
        Dim _k As Integer
        Dim _s As Integer

        For _i = 0 To 8
            If Grille(_i, _j) <> "0" Then
                For _k = 0 To 8
                    If Val(_k + 1) = Grille(_i, _j) Then
                        _s = _k
                    End If
                Next
                For _ibis = 0 To 8
                    Candidats(_ibis, _j, _s) = " "
                Next
            End If
        Next

    End Sub

    Sub GommeRégion(ByVal Grille(,) As String, ByRef Candidats(,,) As String, _r As Integer)

        'Elimine les candidats dans une région

        Dim _i As Integer
        Dim _j As Integer
        Dim _ibis As Integer
        Dim _jbis As Integer
        Dim _ir As Integer
        Dim _jr As Integer
        Dim _k As Integer
        Dim _s As Integer

        _ir = (_r \ 3) * 3
        _jr = (_r - _ir) * 3
        For _i = _ir To _ir + 2
            For _j = _jr To _jr + 2
                If Grille(_i, _j) <> "0" Then
                    For _k = 0 To 8
                        If Val(_k + 1) = Grille(_i, _j) Then
                            _s = _k
                        End If
                    Next
                    For _ibis = _ir To _ir + 2
                        For _jbis = _jr To _jr + 2
                            Candidats(_ibis, _jbis, _s) = " "
                        Next
                    Next
                End If
            Next
        Next

    End Sub
    '============================================================================================================================================================
    '  Impacts sur les candidats de la saisie d'une case
    '============================================================================================================================================================

    Sub Recalcul_Candidats(ByRef _i As Integer, ByRef _j As Integer, ByRef _Grille(,) As String, ByRef _Candidats(,,) As String)

        Dim _k As Integer
        Dim _r As Integer

        For _k = 0 To 8
            _Candidats(_i, _j, _k) = " "  ' on enlève les candidats de la case qui vient d'être garnie
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
    ' Recherche de solution 
    ' Détermine s'il n'y a plus qu'un candidat dans la case 
    '============================================================================================================================================================

    Sub AnalyseCase(ByRef _Candidats(,,) As String, ByRef _opk(,) As Integer, ByRef _nuplet(,) As String)
        ' détermine le nombre de valeurs possibles par case
        Dim _i As Integer
        Dim _j As Integer
        Dim _k As Integer

        For _i = 0 To 8
            For _j = 0 To 8
                _opk(_i, _j) = 0
                _nuplet(_i, _j) = ""
                For _k = 0 To 8
                    If _Candidats(_i, _j, _k) <> " " Then
                        _opk(_i, _j) += 1
                        _nuplet(_i, _j) = _nuplet(_i, _j) & _Candidats(_i, _j, _k)
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

    Sub AnalyseLigne(ByRef _Candidats(,,) As String, ByRef _AnlLig(,) As Sudoku.StrAnalyse)
        ' - Détermine le nombre d'occurrences de chaque candidat par ligne
        ' - Détermine la position d'un candidat seul sur une ligne

        Dim _i As Integer
        Dim _j As Integer
        Dim _k As Integer

        ' - Détermine le nombre d'occurrences de k par ligne
        For _i = 0 To 8
            For _k = 0 To 8
                _AnlLig(_i, _k).n = 0
                For _j = 0 To 8
                    If _Candidats(_i, _j, _k) <> " " Then
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

    Sub AnalyseColonne(ByRef _Candidats(,,) As String, ByRef _AnlCol(,) As Sudoku.StrAnalyse)
        ' - Détermine le nombre d'occurrences de chaque candidat par colonne
        ' - Détermine la position d'un candidat seul sur une colonne

        Dim _i As Integer
        Dim _j As Integer
        Dim _k As Integer

        ' - Détermine le nombre d'occurrences de k par colonne
        For _j = 0 To 8
            For _k = 0 To 8
                _AnlCol(_j, _k).n = 0
                For _i = 0 To 8
                    If _Candidats(_i, _j, _k) <> " " Then
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

    Sub AnalyseRégion(ByRef _Candidats(,,) As String, ByRef _AnlReg(,) As Sudoku.StrAnalyse)

        ' - Détermine le nombre d'occurrences de chaque candidat par région
        ' - Détermine la position d'un candidat seul sur une région

        Dim _i As Integer
        Dim _j As Integer
        Dim _ir As Integer
        Dim _jr As Integer
        Dim _k As Integer
        Dim _r As Integer

        ' - Initialise le nombre d'occurrences de k par région
        For _r = 0 To 8
            For _k = 0 To 8
                _AnlReg(_r, _k).n = 0
            Next
        Next

        ' - Détermine le nombre d'occurrences de k par région
        For _r = 0 To 8
            _ir = (_r \ 3) * 3
            _jr = (_r - _ir) * 3
            For _i = _ir To _ir + 2
                For _j = _jr To _jr + 2
                    For _k = 0 To 8
                        If _Candidats(_i, _j, _k) <> " " Then
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
    ' Simplification des candidats 
    ' recense les paires nues d'une ligne
    '============================================================================================================================================================

    Sub PaireNueLig(ByRef _Candidats(,,) As String, ByRef _Simplification() As Sudoku.StrSimplification, ByRef _NbSmp As Integer, ByVal _opk(,) As Integer, _nuplet(,) As String)
        ' - recense les paires et la position de la dernière paire une ligne

        Dim _i As Integer
        Dim _j As Integer
        Dim _jbis As Integer
        Dim _k As Integer
        Dim _s As New Sudoku.StrSimplification

        _s = _Simplification(_NbSmp)

        For _i = 0 To 8
            ' appariement
            For _j = 0 To 7
                If _opk(_i, _j) = 2 Then
                    For _jbis = _j + 1 To 8
                        If _opk(_i, _jbis) = 2 Then
                            If _nuplet(_i, _j) = _nuplet(_i, _jbis) Then
                                'Recherche si les paires sont actives (s'il y a des candidats à effacer)
                                For _jter = 0 To 8
                                    If _jter <> _j And _jter <> _jbis Then
                                        For _k = 0 To 8
                                            If _Candidats(_i, _jter, _k) = Mid(_nuplet(_i, _j), 1, 1) Then
                                                _s.act = True
                                                _s.k(0) = _k
                                            End If
                                            If _Candidats(_i, _jter, _k) = Mid(_nuplet(_i, _j), 2, 1) Then
                                                _s.act = True
                                                _s.k(1) = _k
                                            End If
                                        Next
                                    End If
                                Next
                                If _s.act = True Then
                                    _s.n = 1
                                    _s.i(0) = _i
                                    _s.j(0) = _j
                                    _s.v(0) = Mid(_nuplet(_i, _j), 1, 1)
                                    _s.i(1) = _i
                                    _s.j(1) = _jbis
                                    _s.v(1) = Mid(_nuplet(_i, _j), 2, 1)
                                    _s.m = "Paire nue ligne"
                                    _Simplification(_NbSmp) = _s
                                    _NbSmp += 1
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
    ' Simplification des candidats 
    ' recense les paires nues d'une colonne
    '============================================================================================================================================================

    Sub PaireNueCol(ByRef _Candidats(,,) As String, ByRef _Simplification() As Sudoku.StrSimplification, ByRef _NbSmp As Integer, ByVal _opk(,) As Integer, _nuplet(,) As String)
        ' - recense les paires et la position de la dernière paire une ligne

        Dim _i As Integer
        Dim _j As Integer
        Dim _ibis As Integer
        Dim _iter As Integer
        Dim _k As Integer
        Dim _s As New Sudoku.StrSimplification

        _s = _Simplification(_NbSmp)

        For _j = 0 To 8
            ' appariement
            For _i = 0 To 8
                If _opk(_i, _j) = 2 Then
                    For _ibis = _i + 1 To 8
                        If _opk(_ibis, _j) = 2 Then
                            If _nuplet(_i, _j) = _nuplet(_ibis, _j) Then
                                'Recherche si les paires sont actives (s'il y a des candidats à effacer)
                                For _iter = 0 To 8
                                    If _iter <> _i And _iter <> _ibis Then
                                        For _k = 0 To 8
                                            If _Candidats(_iter, _j, _k) = Mid(_nuplet(_i, _j), 1, 1) Then
                                                _s.act = True
                                                _s.k(0) = _k
                                            End If
                                            If _Candidats(_iter, _j, _k) = Mid(_nuplet(_i, _j), 2, 1) Then
                                                _s.act = True
                                                _s.k(1) = _k
                                            End If
                                        Next
                                    End If
                                Next
                                If _s.act = True Then
                                    _s.n = 1
                                    _s.i(0) = _i
                                    _s.j(0) = _j
                                    _s.v(0) = Mid(_nuplet(_i, _j), 1, 1)
                                    _s.i(1) = _ibis
                                    _s.j(1) = _j
                                    _s.v(1) = Mid(_nuplet(_i, _j), 2, 1)
                                    _s.m = "Paire nue colonne"
                                    _Simplification(_NbSmp) = _s
                                    _NbSmp += 1
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
    ' Simplification des candidats 
    ' recense les paires nues d'une région
    '============================================================================================================================================================

    Sub PaireNueReg(ByRef _Candidats(,,) As String, ByRef _Simplification() As Sudoku.StrSimplification, ByRef _NbSmp As Integer, ByVal _opk(,) As Integer, _nuplet(,) As String)
        ' - recense les paires et la position de la dernière paire une ligne

        Dim _i As Integer
        Dim _j As Integer
        Dim _ibis As Integer
        Dim _jbis As Integer
        Dim _iter As Integer
        Dim _jter As Integer
        Dim _k As Integer
        Dim _ir As Integer
        Dim _jr As Integer
        Dim _r As Integer
        Dim _g As Integer
        Dim _gbis As Integer
        Dim _s As New Sudoku.StrSimplification

        _s = _Simplification(_NbSmp)

        For _r = 0 To 8
            _ir = (_r \ 3) * 3 'calcul coin supérieur gauche d'une région
            _jr = (_r - _ir) * 3 'calcul coin supérieur gauche d'une région
            For _i = _ir To _ir + 2 'parcour de l'élément 1
                For _j = _jr To _jr + 2 'parcours de l'élément 1
                    ' appariement
                    If _opk(_i, _j) = 2 Then 'si l'élément 1 est une paire
                        For _ibis = _ir To _ir + 2 'parcours de l'élément 2
                            For _jbis = _jr To _jr + 2 'parcours de l'élément 2
                                _g = (_i * 9) + _j
                                _gbis = (_ibis * 9) + _jbis
                                If _g < _gbis Then ' on ne compare que dans un sens (élément 2 tjrs > élément 1) 
                                    If _opk(_ibis, _jbis) = 2 Then 'si l'élément 2 est une paire
                                        If _nuplet(_i, _j) = _nuplet(_ibis, _jbis) Then 'on compare les 2 paires
                                            'Recherche si les paires sont actives (s'il y a des candidats à effacer)
                                            For _iter = _ir To _ir + 2
                                                For _jter = _jr To _jr + 2
                                                    If Not (_iter = _i And _iter = _j) And Not (_jter = _jbis And _jter = _jbis) Then
                                                        If _Candidats(_iter, _jter, _k) = Mid(_nuplet(_i, _j), 1, 1) Then
                                                            _s.act = True
                                                            _s.k(0) = _k
                                                        End If
                                                        If _Candidats(_iter, _jter, _k) = Mid(_nuplet(_i, _j), 2, 1) Then
                                                            _s.act = True
                                                            _s.k(1) = _k
                                                        End If
                                                    End If
                                                Next
                                            Next
                                        End If
                                    End If
                                End If
                            Next
                        Next
                        If _s.act = True Then
                            _s.n = 1
                            _s.i(0) = _i
                            _s.j(0) = _j
                            _s.v(0) = Mid(_nuplet(_i, _j), 1, 1)
                            _s.i(1) = _ibis
                            _s.j(1) = _j
                            _s.v(1) = Mid(_nuplet(_i, _j), 2, 1)
                            _s.m = "Paire nue région"
                            _Simplification(_NbSmp) = _s
                            _NbSmp += 1
                            Exit For
                        End If
                    End If
                Next
            Next
        Next

    End Sub
    '============================================================================================================================================================
    ' Recherche de solution 
    ' Balaye la table opk - candidats par case - pour alimenter la table des solutions à proposer
    '============================================================================================================================================================

    Sub SeulDansUneCase(ByRef _NbSol As Integer, _Candidats(,,) As String, _opk(,) As Integer, _TabSolution() As Sudoku.StrSolution)

        Dim _i As Integer
        Dim _j As Integer
        Dim _k As Integer
        Dim _New_Solution As Sudoku.StrSolution

        For _i = 0 To 8
            For _j = 0 To 8
                If _opk(_i, _j) = 1 Then
                    For _k = 0 To 8
                        If _Candidats(_i, _j, _k) <> " " Then
                            _New_Solution.i = _i
                            _New_Solution.j = _j
                            _New_Solution.v = Sudoku.Val(_k)
                            _New_Solution.m = "Seul candidat dans cette case"
                            AddSolution(_NbSol, _TabSolution, _New_Solution)
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

    Sub SeulDansUneLigne(ByRef _NbSol As Integer, ByRef _AnlLig(,) As Sudoku.StrAnalyse, _TabSolution() As Sudoku.StrSolution)

        Dim _i As Integer
        Dim _k As Integer
        Dim _New_Solution As Sudoku.StrSolution

        ' - Détermine la position d'une occurrence seule sur une ligne

        For _i = 0 To 8
            For _k = 0 To 8
                If _AnlLig(_i, _k).n = 1 Then
                    _New_Solution.i = _AnlLig(_i, _k).i
                    _New_Solution.j = _AnlLig(_i, _k).j
                    _New_Solution.v = Sudoku.Val(_AnlLig(_i, _k).k)
                    _New_Solution.m = "Seule présence dans cette ligne"
                    AddSolution(_NbSol, _TabSolution, _New_Solution)
                End If
            Next
        Next

        ' - recense les doublons et la position du dernier de chaque doublon sur une ligne
        ' - recense les triplets et la position du dernier de chaque triplet sur une ligne

    End Sub

    '============================================================================================================================================================
    ' Recherche de solution 
    ' Balaye la table opc - possibilités par colonne - pour alimenter la table des solutions à proposer
    '============================================================================================================================================================

    Sub SeulDansUneColonne(ByRef _NbSol As Integer, ByRef _AnlCol(,) As Sudoku.StrAnalyse, _TabSolution() As Sudoku.StrSolution)

        Dim _j As Integer
        Dim _k As Integer
        Dim _New_Solution As Sudoku.StrSolution

        ' - Détermine la position d'une occurrence seule sur une colonne

        For _j = 0 To 8
            For _k = 0 To 8
                If _AnlCol(_j, _k).n = 1 Then
                    _New_Solution.i = _AnlCol(_j, _k).i
                    _New_Solution.j = _AnlCol(_j, _k).j
                    _New_Solution.v = Sudoku.Val(_AnlCol(_j, _k).k)
                    _New_Solution.m = "Seule présence dans cette colonne"
                    AddSolution(_NbSol, _TabSolution, _New_Solution)
                End If
            Next
        Next

    End Sub

    '============================================================================================================================================================
    ' Recherche de solution 
    ' Balaye la table opr - possibilités par région - pour alimenter la table des solutions à proposer
    '============================================================================================================================================================

    Sub SeulDansUneRégion(ByRef _NbSol As Integer, ByRef _AnlReg(,) As Sudoku.StrAnalyse, _TabSolution() As Sudoku.StrSolution)

        Dim _r As Integer
        Dim _k As Integer
        Dim _New_Solution As Sudoku.StrSolution

        ' - Détermine la position d'une occurrence seule sur une région

        For _r = 0 To 8
            For _k = 0 To 8
                If _AnlReg(_r, _k).n = 1 Then
                    _New_Solution.i = _AnlReg(_r, _k).i
                    _New_Solution.j = _AnlReg(_r, _k).j
                    _New_Solution.v = Sudoku.Val(_AnlReg(_r, _k).k)
                    _New_Solution.m = "Seule présence dans cette région"
                    AddSolution(_NbSol, _TabSolution, _New_Solution)
                End If
            Next
        Next

    End Sub

    '============================================================================================================================================================
    ' Ajoute un poste dans la table des solutions 
    '============================================================================================================================================================

    Sub AddSolution(ByRef _NbSol As Integer, _TabSolution() As Sudoku.StrSolution, New_Solution As Sudoku.StrSolution)

        Dim _ExisteDeja As Boolean = False
        If _NbSol > 0 Then
            For _n = 0 To _NbSol - 1
                If _TabSolution(_n).i = New_Solution.i And _TabSolution(_n).j = New_Solution.j Then
                    _ExisteDeja = True
                End If
            Next
        End If
        If Not _ExisteDeja Then
            _TabSolution(_NbSol).i = New_Solution.i
            _TabSolution(_NbSol).j = New_Solution.j
            _TabSolution(_NbSol).v = New_Solution.v
            _TabSolution(_NbSol).m = New_Solution.m
            _NbSol += 1
        End If

    End Sub

    '============================================================================================================================================================
    ' Fait une rotation des postes de la table des solutions
    '============================================================================================================================================================

    Sub ProchaineSolution(ByRef _TabSolution() As Sudoku.StrSolution, ByRef _NbSol As Integer)

        Dim _Temp_Solution As Sudoku.StrSolution
        Dim _s As Integer
        _Temp_Solution = _TabSolution(0)
        For _s = 0 To _NbSol - 2
            _TabSolution(_s) = _TabSolution(_s + 1)
        Next
        _TabSolution(_NbSol - 1) = _Temp_Solution

    End Sub
    '============================================================================================================================================================
    ' retire une occurrence de la table des solutions
    '============================================================================================================================================================

    Sub SupprSolution(ByRef _TabSolution() As Sudoku.StrSolution, ByRef _NbSol As Integer)

        Dim _s As Integer

        For _s = 0 To _NbSol - 1
            _TabSolution(_s).i = "0"
            _TabSolution(_s).j = "0"
            _TabSolution(_s).v = ""
            _TabSolution(_s).m = ""
        Next

    End Sub
    '============================================================================================================================================================
    ' Suppression de candidats dans la grille
    '============================================================================================================================================================

    Sub SuppressionCandidats(ByRef _NbSmp As String, ByRef _Candidats(,,) As String, ByRef _Simplification() As Sudoku.StrSimplification, ByVal _opk(,) As Integer, _nuplet(,) As String)
        Select Case _Simplification(0).m
            Case "Paire nue ligne"
                SupPNL(_NbSmp, _Candidats, _Simplification, _opk, _nuplet)
            Case "Paire nue colonne"
                SupPNC(_NbSmp, _Candidats, _Simplification, _opk, _nuplet)
            Case "Paire nue région"
                SupPNC(_NbSmp, _Candidats, _Simplification, _opk, _nuplet)
        End Select
    End Sub

    '============================================================================================================================================================
    ' Suppression de candidats d'une ligne par une paire nue 
    '============================================================================================================================================================

    Sub SupPNL(ByRef NbSmp As String, ByRef _Candidats(,,) As String, ByRef _Simplification() As Sudoku.StrSimplification, ByVal _opk(,) As Integer, _nuplet(,) As String)

        Dim _i As Integer
        Dim _j As Integer
        Dim _k0 As Integer
        Dim _k1 As Integer
        Dim _s As Sudoku.StrSimplification

        _s = _Simplification(0)
        _i = _s.i(0)

        For _j = 0 To 8
            If _j <> _s.j(0) And _j <> _s.j(1) Then
                _k0 = _s.k(0)
                _k1 = _s.k(1)
                If _Candidats(_i, _j, _k0) = _s.v(0) Then
                    _Candidats(_i, _j, _k0) = " "
                End If
                If _Candidats(_i, _j, _k1) = _s.v(1) Then
                    _Candidats(_i, _j, _k1) = " "
                End If
            End If
        Next

    End Sub

    '============================================================================================================================================================
    ' Suppression de candidats d'une colonne par une paire nue 
    '============================================================================================================================================================

    Sub SupPNC(ByRef NbSmp As String, ByRef _Candidats(,,) As String, ByRef _Simplification() As Sudoku.StrSimplification, ByVal _opk(,) As Integer, _nuplet(,) As String)

        Dim _i As Integer
        Dim _j As Integer
        Dim _k0 As Integer
        Dim _k1 As Integer
        Dim _s As Sudoku.StrSimplification

        _s = _Simplification(0)
        _j = _s.j(0)

        For _i = 0 To 8
            If _i <> _s.i(0) And _i <> _s.i(1) Then
                _k0 = _s.k(0)
                _k1 = _s.k(1)
                If _Candidats(_i, _j, _k0) = _s.v(0) Then
                    _Candidats(_i, _j, _k0) = " "
                End If
                If _Candidats(_i, _j, _k1) = _s.v(1) Then
                    _Candidats(_i, _j, _k1) = " "
                End If
            End If
        Next

    End Sub

    '============================================================================================================================================================
    ' Suppression de candidats d'une région par une paire nue 
    '============================================================================================================================================================

    Sub SupPNR(ByRef NbSmp As String, ByRef _Candidats(,,) As String, ByRef _Simplification() As Sudoku.StrSimplification, ByVal _opk(,) As Integer, _nuplet(,) As String)

        Dim _i As Integer
        Dim _ir As Integer
        Dim _j As Integer
        Dim _jr As Integer

        Dim _k0 As Integer
        Dim _k1 As Integer
        Dim _s As Sudoku.StrSimplification

        _s = _Simplification(0)
        _ir = (_s.i(0) \ 3) * 3
        _jr = (_s.j(0) \ 3) * 3

        For _i = _ir To _ir + 2
            For _j = _jr To _jr + 2
                If Not (_i = _s.i(0) And _j = _s.j(0)) And Not (_i = _s.i(1) And _j = _s.j(1)) Then
                    _k0 = _s.k(0)
                    _k1 = _s.k(1)
                    If _Candidats(_i, _j, _k0) = _s.v(0) Then
                        _Candidats(_i, _j, _k0) = " "
                    End If
                    If _Candidats(_i, _j, _k1) = _s.v(1) Then
                        _Candidats(_i, _j, _k1) = " "
                    End If
                End If
            Next
        Next

    End Sub
End Module
