Module Solveur

    Function NewSmp()

        Dim j As Integer
        Dim _Newsmp As Sudoku.StrSmp
        _Newsmp.m = " "
        _Newsmp.act = False
        ReDim _Newsmp.cri(2)
        ReDim _Newsmp.crj(2)
        ReDim _Newsmp.crk(2)
        ReDim _Newsmp.crv(2)
        ReDim _Newsmp.cei(20)
        ReDim _Newsmp.cej(20)
        ReDim _Newsmp.cek(20)
        ReDim _Newsmp.cev(20)
        _Newsmp.ne = 0
        For j = 0 To 2
            _Newsmp.cri(j) = 0
            _Newsmp.crj(j) = 0
            _Newsmp.crk(j) = 0
            _Newsmp.crv(j) = " "
        Next
        _Newsmp.nr = 0
        For j = 0 To 20
            _Newsmp.cei(j) = 0
            _Newsmp.cej(j) = 0
            _Newsmp.cek(j) = 0
            _Newsmp.cev(j) = 0
        Next

        Return _Newsmp

    End Function

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
        Dim _csgi As Integer 'Coin supérieur gauche région
        Dim _csgj As Integer 'Coin supérieur gauche région
        Dim _k As Integer
        Dim _ErreurCandidat(8, 8)
        _csgi = (_r \ 3) * 3
        _csgj = (_r - _csgi) * 3
        For _i = _csgi To _csgi + 2
            For _j = _csgj To _csgj + 2
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
                         ByRef _Qsol As Queue(Of Sudoku.StrSolution),
                         ByRef _QSmp As Queue(Of Sudoku.StrSmp))
        '
        ' Elimine les candidats dans les lignes colonnes et régions
        '
        Dim _i As Integer
        Dim _j As Integer
        Dim _r As Integer

        Dim _opk(8, 8) As Integer ' Candidats par case
        Dim _nuplet(8, 8) As String ' Candidats agrégés
        Dim _AnlLig(8, 8) As Sudoku.StrAnalyse ' (i,k)
        Dim _AnlCol(8, 8) As Sudoku.StrAnalyse ' (j,k)
        Dim _AnlReg(8, 8) As Sudoku.StrAnalyse ' (r,k)

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

        SeulDansUneCase(_Candidats, _opk, _Qsol)
        SeulDansUneLigne(_AnlLig, _Qsol)
        SeulDansUneColonne(_AnlCol, _Qsol)
        SeulDansUneRégion(_AnlReg, _Qsol)


        If _Qsol.Count = 0 Then
            PaireNueLig(_Candidats, _QSmp, _opk, _nuplet)
            PaireNueCol(_Candidats, _QSmp, _opk, _nuplet)
            PaireNueReg(_Candidats, _QSmp, _opk, _nuplet)
            CandidatVérouilléLig(_Candidats, _QSmp, _AnlLig, _AnlReg)
            CandidatVérouilléCol(_Candidats, _QSmp, _AnlReg, _AnlReg)
        End If

    End Sub

    Sub GommeLigne(ByVal Grille(,) As String, ByRef Candidats(,,) As String, _i As Integer)

        'Elimine les candidats dans une ligne

        Dim _j As Integer
        Dim _jbis As Integer
        Dim _k As Integer
        Dim _g As Integer

        For _j = 0 To 8
            If Grille(_i, _j) <> "0" Then
                For _k = 0 To 8
                    If Val(_k + 1) = Grille(_i, _j) Then
                        _g = _k
                    End If
                Next
                For _jbis = 0 To 8
                    Candidats(_i, _jbis, _g) = " "
                Next
            End If
        Next

    End Sub

    Sub GommeColonne(ByVal Grille(,) As String, ByRef Candidats(,,) As String, _j As Integer)

        'Elimine les candidats dans une colonne

        Dim _i As Integer
        Dim _ibis As Integer
        Dim _k As Integer
        Dim _g As Integer

        For _i = 0 To 8
            If Grille(_i, _j) <> "0" Then
                For _k = 0 To 8
                    If Val(_k + 1) = Grille(_i, _j) Then
                        _g = _k
                    End If
                Next
                For _ibis = 0 To 8
                    Candidats(_ibis, _j, _g) = " "
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
        Dim _csgi As Integer 'Coin supérieur gauche région
        Dim _csgj As Integer 'Coin supérieur gauche région
        Dim _k As Integer
        Dim _g As Integer

        _csgi = (_r \ 3) * 3
        _csgj = (_r - _csgi) * 3
        For _i = _csgi To _csgi + 2
            For _j = _csgj To _csgj + 2
                If Grille(_i, _j) <> "0" Then
                    For _k = 0 To 8
                        If Val(_k + 1) = Grille(_i, _j) Then
                            _g = _k
                        End If
                    Next
                    For _ibis = _csgi To _csgi + 2
                        For _jbis = _csgj To _csgj + 2
                            Candidats(_ibis, _jbis, _g) = " "
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
        Dim _csgi As Integer 'Coin supérieur gauche région
        Dim _csgj As Integer 'Coin supérieur gauche région
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
            _csgi = (_r \ 3) * 3
            _csgj = (_r - _csgi) * 3
            For _i = _csgi To _csgi + 2
                For _j = _csgj To _csgj + 2
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
    ' Recherche de solution 
    ' Balaye la table opk - candidats par case - pour alimenter la table des solutions à proposer
    '============================================================================================================================================================

    Sub SeulDansUneCase(_Candidats(,,) As String, _opk(,) As Integer, ByRef _Qsol As Queue(Of Sudoku.StrSolution))

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
                            _Qsol.Enqueue(_New_Solution)
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

    Sub SeulDansUneLigne(ByRef _AnlLig(,) As Sudoku.StrAnalyse, ByRef _Qsol As Queue(Of Sudoku.StrSolution))

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
                    _Qsol.Enqueue(_New_Solution)
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

    Sub SeulDansUneColonne(ByRef _AnlCol(,) As Sudoku.StrAnalyse, ByRef _Qsol As Queue(Of Sudoku.StrSolution))

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
                    _Qsol.Enqueue(_New_Solution)
                End If
            Next
        Next

    End Sub

    '============================================================================================================================================================
    ' Recherche de solution 
    ' Balaye la table opr - possibilités par région - pour alimenter la table des solutions à proposer
    '============================================================================================================================================================

    Sub SeulDansUneRégion(ByRef _AnlReg(,) As Sudoku.StrAnalyse, ByRef _Qsol As Queue(Of Sudoku.StrSolution))

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
                    _Qsol.Enqueue(_New_Solution)
                End If
            Next
        Next

    End Sub

    '============================================================================================================================================================
    ' Simplification des candidats 
    ' recense les paires nues d'une ligne
    '============================================================================================================================================================

    Sub PaireNueLig(ByRef _Candidats(,,) As String, ByRef _QSmp As Queue(Of Sudoku.StrSmp), ByVal _opk(,) As Integer, _nuplet(,) As String)
        ' - recense les paires et la position de la dernière paire une ligne

        Dim _i As Integer
        Dim _j As Integer
        Dim _ej As Integer
        Dim _jbis As Integer
        Dim _k As Integer
        Dim _k0 As Integer
        Dim _k1 As Integer
        Dim _Smp As New Sudoku.StrSmp

        _Smp = NewSmp()

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
                                                _smp.act = True
                                                _smp.crk(0) = _k
                                            End If
                                            If _Candidats(_i, _jter, _k) = Mid(_nuplet(_i, _j), 2, 1) Then
                                                _smp.act = True
                                                _smp.crk(1) = _k
                                            End If
                                        Next
                                    End If
                                Next
                                If _smp.act = True Then
                                    _smp.nr = 1
                                    _smp.cri(0) = _i
                                    _smp.crj(0) = _j
                                    _smp.crv(0) = Mid(_nuplet(_i, _j), 1, 1)
                                    _smp.cri(1) = _i
                                    _smp.crj(1) = _jbis
                                    _smp.crv(1) = Mid(_nuplet(_i, _j), 2, 1)
                                    _Smp.m = "Paires nues : [" & _nuplet(_i, _j) & "] dans les cases L" & _i + 1 & "C" & _j + 1 & "-L" & _i + 1 & "C" & _jbis + 1
                                    'Liste des candidats éliminés
                                    _Smp.ne = 0
                                    For _ej = 0 To 8
                                        If _ej <> _smp.crj(0) And _ej <> _smp.crj(1) Then
                                            _k0 = _smp.crk(0)
                                            _k1 = _smp.crk(1)
                                            If _Candidats(_i, _ej, _k0) = _smp.crv(0) Then
                                                _smp.cei(_smp.ne) = _i
                                                _smp.cej(_smp.ne) = _ej
                                                _smp.cek(_smp.ne) = _k0
                                                _smp.cev(_smp.ne) = Val(_k0 + 1)
                                                _smp.ne += 1
                                            End If
                                            If _Candidats(_i, _j, _k1) = _smp.crv(1) Then
                                                _smp.cei(_smp.ne) = _i
                                                _smp.cej(_smp.ne) = _ej
                                                _smp.cek(_smp.ne) = _k1
                                                _smp.cev(_smp.ne) = Val(_k1 + 1)
                                                _smp.ne += 1
                                            End If
                                        End If
                                    Next
                                    _QSmp.Enqueue(_smp)
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

    Sub PaireNueCol(ByRef _Candidats(,,) As String, ByRef _QSmp As Queue(Of Sudoku.StrSmp), ByVal _opk(,) As Integer, _nuplet(,) As String)
        ' - recense les paires et la position de la dernière paire une ligne

        Dim _i As Integer
        Dim _j As Integer
        Dim _ei As Integer
        Dim _ibis As Integer
        Dim _iter As Integer
        Dim _k As Integer
        Dim _k0 As Integer
        Dim _k1 As Integer
        Dim _Smp As New Sudoku.StrSmp

        _Smp = NewSmp()

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
                                                _smp.act = True
                                                _smp.crk(0) = _k
                                            End If
                                            If _Candidats(_iter, _j, _k) = Mid(_nuplet(_i, _j), 2, 1) Then
                                                _smp.act = True
                                                _smp.crk(1) = _k
                                            End If
                                        Next
                                    End If
                                Next
                                If _smp.act = True Then
                                    _smp.nr = 1
                                    _smp.cri(0) = _i
                                    _smp.crj(0) = _j
                                    _smp.crv(0) = Mid(_nuplet(_i, _j), 1, 1)
                                    _smp.cri(1) = _ibis
                                    _smp.crj(1) = _j
                                    _smp.crv(1) = Mid(_nuplet(_i, _j), 2, 1)
                                    _Smp.m = "Paires nues : [" & _nuplet(_i, _j) & "] dans les cases L" & _i + 1 & "C" & _j + 1 & "-L" & _ibis + 1 & "C" & _j + 1

                                    'Liste des candidats éliminés
                                    _Smp.ne = 0
                                    For _ei = 0 To 8
                                        If _ei <> _smp.cri(0) And _ei <> _smp.cri(1) Then
                                            _k0 = _smp.crk(0)
                                            _k1 = _smp.crk(1)
                                            If _Candidats(_ei, _j, _k0) = _smp.crv(0) Then
                                                _smp.cei(_smp.ne) = _ei
                                                _smp.cej(_smp.ne) = _j
                                                _smp.cek(_smp.ne) = _k0
                                                _smp.cev(_smp.ne) = Val(_k0 + 1)
                                                _smp.ne += 1
                                            End If
                                            If _Candidats(_i, _j, _k1) = _smp.crv(1) Then
                                                _smp.cei(_smp.ne) = _ei
                                                _smp.cej(_smp.ne) = _j
                                                _smp.cek(_smp.ne) = _k1
                                                _smp.cev(_smp.ne) = Val(_k1 + 1)
                                                _smp.ne += 1
                                            End If
                                        End If
                                    Next
                                    _QSmp.Enqueue(_smp)
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

    Sub PaireNueReg(ByRef _Candidats(,,) As String, ByRef _QSmp As Queue(Of Sudoku.StrSmp), ByVal _opk(,) As Integer, _nuplet(,) As String)
        ' - recense les paires et la position de la dernière paire une ligne

        Dim _i As Integer
        Dim _j As Integer
        Dim _ei As Integer
        Dim _ej As Integer
        Dim _ibis As Integer
        Dim _jbis As Integer
        Dim _iter As Integer
        Dim _jter As Integer
        Dim _k As Integer
        Dim _k0 As Integer
        Dim _k1 As Integer
        Dim _csgi As Integer 'Coin supérieur gauche région
        Dim _csgj As Integer 'Coin supérieur gauche région
        Dim _r As Integer
        Dim _g As Integer
        Dim _gbis As Integer
        Dim _Smp As New Sudoku.StrSmp

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
                                            For _iter = _csgi To _csgi + 2
                                                For _jter = _csgj To _csgj + 2
                                                    If Not (_iter = _i And _jter = _j) And Not (_jter = _jbis And _jter = _jbis) Then
                                                        For _k = 0 To 8
                                                            If _Candidats(_iter, _jter, _k) = Mid(_nuplet(_i, _j), 1, 1) Then
                                                                _smp.act = True
                                                                _smp.crk(0) = _k
                                                            End If
                                                            If _Candidats(_iter, _jter, _k) = Mid(_nuplet(_i, _j), 2, 1) Then
                                                                _smp.act = True
                                                                _smp.crk(1) = _k
                                                            End If
                                                        Next
                                                    End If
                                                Next
                                            Next
                                            If _smp.act = True Then
                                                _smp.ne = 1
                                                _smp.cri(0) = _i
                                                _smp.crj(0) = _j
                                                _smp.crv(0) = Mid(_nuplet(_i, _j), 1, 1)
                                                _smp.cri(1) = _ibis ' ???
                                                _smp.crj(1) = _jbis ' ???
                                                _smp.crv(1) = Mid(_nuplet(_i, _j), 2, 1)
                                                _Smp.m = _Smp.m = "Paires nues : [" & _nuplet(_i, _j) & "] dans les cases L" & _i + 1 & "C" & _j + 1 & "-L" & _ibis + 1 & "C" & _jbis + 1
                                                'Liste des candidats éliminés (parcours par _ei,_ej)
                                                _Smp.ne = 0
                                                For _ei = _csgi To _csgi + 2
                                                    For _ej = _csgj To _csgj + 2
                                                        If Not (_ei = _smp.cri(0) And _ej = _smp.crj(0)) And Not (_ei = _smp.cri(1) And _ej = _smp.crj(1)) Then
                                                            ' If Not (_iter = _i And _jter = _j) And Not (_jter = _jbis And _jter = _jbis) Then
                                                            _k0 = _smp.crk(0)
                                                            _k1 = _smp.crk(1)
                                                            If _Candidats(_ei, _ej, _k0) = _smp.crv(0) Then
                                                                _smp.cei(_smp.ne) = _ei
                                                                _smp.cej(_smp.ne) = _ej
                                                                _smp.cek(_smp.ne) = _k0
                                                                _smp.cev(_smp.ne) = Val(_k0 + 1)
                                                                _smp.ne += 1
                                                            End If
                                                            If _Candidats(_ei, _ej, _k1) = _smp.crv(1) Then
                                                                _smp.cei(_smp.ne) = _ei
                                                                _smp.cej(_smp.ne) = _ej
                                                                _smp.cek(_smp.ne) = _k1
                                                                _smp.cev(_smp.ne) = Val(_k1 + 1)
                                                                _smp.ne += 1
                                                            End If
                                                        End If
                                                    Next
                                                Next
                                                _QSmp.Enqueue(_smp)
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
    ' Simplification des candidats 
    ' Candidats verrouillés en ligne (communs à une région et une ligne)
    '============================================================================================================================================================

    Sub CandidatVérouilléLig(ByRef _Candidats(,,) As String, ByRef _QSmp As Queue(Of Sudoku.StrSmp), ByVal _AnlLig(,) As Sudoku.StrAnalyse, ByVal _AnlReg(,) As Sudoku.StrAnalyse)
        Dim _i As Integer
        Dim _j As Integer
        Dim _r As Integer
        Dim _csgi As Integer 'Coin supérieur gauche région
        Dim _csgj As Integer 'Coin supérieur gauche région
        Dim _ir As Integer 'indice de ligne limité à l'intérieur d'une région
        Dim _AnlLigReg(2, 8) As Sudoku.StrAnalyse ' (i,k)
        Dim _irej As Integer ' pour parcourir les candidats rejetés
        Dim _jrej As Integer ' pour parcourir les candidats rejetés
        Dim _Smp As New Sudoku.StrSmp

        _Smp = NewSmp()

        For _r = 0 To 8
            _csgi = (_r \ 3) * 3 'calcul coin supérieur gauche d'une région
            _csgj = (_r - _csgi) * 3 'calcul coin supérieur gauche d'une région
            For _i = _csgi To _csgi + 2
                _ir = _i - _csgi
                ' - Détermine le nombre d'occurrences de k par ligne
                For _k = 0 To 8
                    _AnlLigReg(_ir, _k).n = 0
                    For _j = _csgj To _csgj + 2
                        If _Candidats(_i, _j, _k) <> " " Then
                            _AnlLigReg(_ir, _k).n += 1
                            _AnlLigReg(_ir, _k).i = _i
                            _AnlLigReg(_ir, _k).j = _j
                            _AnlLigReg(_ir, _k).k = _k
                        End If
                    Next
                Next
                '
                For _k = 0 To 8
                    If _AnlLigReg(_ir, _k).n > 0 And _AnlReg(_r, _k).n = 0 And _AnlLig(_i, _k).n > _AnlLigReg(_ir, _k).n Then
                        'candidats retenus (vérouillés)
                        _smp.nr = 0
                        For _j = _j = _csgj To _csgj + 2
                            If _Candidats(_ir, _j, _k) <> " " Then
                                _smp.cri(_smp.nr) = _ir
                                _smp.crj(_smp.nr) = _j
                                _smp.crk(_smp.nr) = _k
                                _smp.crv(_smp.nr) = Val(_k + 1)
                                _smp.nr += 1
                            End If
                        Next
                        'candidats éliminés ligne
                        _smp.ne = 0
                        For _jrej = 0 To 8
                            If _jrej < _csgj Or _jrej > _csgj + 2 Then
                                If _Candidats(_ir, _j, _k) <> " " Then
                                    _smp.cei(_smp.ne) = _ir
                                    _smp.cej(_smp.ne) = _jrej
                                    _smp.cek(_smp.ne) = _k
                                    _smp.cev(_smp.ne) = Val(_k + 1)
                                    _smp.ne += 1
                                End If
                            End If
                        Next
                        _smp.m = "CV Ligne-Ligne "
                        _QSmp.Enqueue(_smp)
                    End If
                    If _AnlLigReg(_ir, _k).n > 0 And _AnlLig(_i, _k).n = 0 And _AnlReg(_r, _k).n > _AnlLigReg(_ir, _k).n Then
                        'candidats retenus (vérouillés)
                        _smp.nr = 0
                        For _j = _csgj To _csgj + 2
                            If _Candidats(_ir, _j, _k) <> " " Then
                                _smp.cri(_smp.nr) = _ir
                                _smp.crj(_smp.nr) = _j
                                _smp.crk(_smp.nr) = _k
                                _smp.crv(_smp.nr) = Val(_k + 1)
                                _smp.nr += 1
                            End If
                        Next
                        'candidats éliminés région
                        _smp.ne = 0
                        For _irej = _csgi To _csgi + 2
                            For _jrej = _csgj To _csgj + 2
                                If _irej <> _ir Then
                                    If _Candidats(_irej, _jrej, _k) <> " " Then
                                        _Smp.cei(_Smp.ne) = _irej
                                        _Smp.cej(_Smp.ne) = _jrej
                                        _Smp.cek(_Smp.ne) = _k
                                        _Smp.cev(_Smp.ne) = Val(_k + 1)
                                    End If
                                End If
                            Next
                        Next
                        _smp.m = "CV Ligne-Région "
                        _QSmp.Enqueue(_smp)
                    End If
                Next
                '
            Next
        Next

    End Sub

    '============================================================================================================================================================
    ' Simplification des candidats 
    ' Candidats verrouillés en colonne (communs à une région et une colonne)
    '============================================================================================================================================================

    Sub CandidatVérouilléCol(ByRef _Candidats(,,) As String, ByRef _QSmp As Queue(Of Sudoku.StrSmp), ByVal _AnlLig(,) As Sudoku.StrAnalyse, ByVal _AnlReg(,) As Sudoku.StrAnalyse)
        Dim _i As Integer
        Dim _j As Integer
        Dim _r As Integer
        Dim _csgi As Integer 'Coin supérieur gauche région
        Dim _csgj As Integer 'Coin supérieur gauche région
        Dim _jr As Integer 'indice de colonne limité à l'intérieur d'une région
        Dim _AnlLigReg(2, 8) As Sudoku.StrAnalyse ' (i,k)
        Dim _c As Integer 'curseur pour les tableaux de StrSimplification
        Dim _irej As Integer ' pour parcourir les candidats rejetés
        Dim _jrej As Integer ' pour parcourir les candidats rejetés
        Dim _Smp As New Sudoku.StrSmp

        _Smp = NewSmp()

        For _r = 0 To 8
            _csgi = (_r \ 3) * 3 'calcul coin supérieur gauche d'une région
            _csgj = (_r - _csgi) * 3 'calcul coin supérieur gauche d'une région
            For _j = _csgj To _csgj + 2
                _jr = _j - _csgj
                ' - Détermine le nombre d'occurrences de k par ligne
                For _k = 0 To 8
                    _AnlLigReg(_jr, _k).n = 0
                    For _i = _csgi To _csgi + 2
                        If _Candidats(_i, _j, _k) <> " " Then
                            _AnlLigReg(_jr, _k).n += 1
                            _AnlLigReg(_jr, _k).i = _i
                            _AnlLigReg(_jr, _k).j = _j
                            _AnlLigReg(_jr, _k).k = _k
                        End If
                    Next
                Next
                '
                For _k = 0 To 8
                    _c = 0
                    If _AnlLigReg(_jr, _k).n > 0 And _AnlReg(_r, _k).n = 0 And _AnlLig(_j, _k).n > _AnlLigReg(_jr, _k).n Then
 _                        'candidats retenus (vérouillés)
                        _smp.nr = 0
                        For _i = _csgj To _csgj + 2
                            If _Candidats(_i, _jr, _k) <> " " Then
                                _smp.cri(_smp.nr) = _i
                                _smp.crj(_smp.nr) = _jr
                                _smp.crk(_smp.nr) = _k
                                _smp.crv(_smp.nr) = Val(_k + 1)
                                _smp.nr += 1
                            End If
                        Next
                        'candidats rejetés colonne
                        _smp.ne = 0
                        For _irej = 0 To 8
                            If _irej < _csgi Or _irej > _csgi + 2 Then
                                If _Candidats(_i, _jr, _k) <> " " Then
                                    _Smp.cei(_Smp.ne) = _irej
                                    _Smp.cej(_Smp.ne) = _jr
                                    _Smp.cek(_Smp.ne) = _k
                                    _Smp.cev(_Smp.ne) = Val(_k + 1)
                                    _Smp.ne += 1
                                End If
                            End If
                        Next
                        _smp.m = "CV Ligne-Ligne "
                        _QSmp.Enqueue(_smp)
                    End If
                    If _AnlLigReg(_jr, _k).n > 0 And _AnlLig(_j, _k).n = 0 And _AnlReg(_r, _k).n > _AnlLigReg(_jr, _k).n Then
                        'candidats retenus (vérouillés)
                        _smp.nr = 0
                        For _i = _csgi To _csgi + 2
                            If _Candidats(_i, _jr, _k) <> " " Then
                                _smp.cri(_smp.nr) = _i
                                _smp.crj(_smp.nr) = _jr
                                _smp.crk(_smp.nr) = _k
                                _smp.crv(_smp.nr) = Val(_k + 1)
                                _smp.nr += 1
                            End If
                        Next
                        'candidats rejetés région
                        _smp.ne = 0
                        For _irej = _csgi To _csgi + 2
                            For _jrej = _csgj To _csgj + 2
                                If _jrej <> _jr Then
                                    If _Candidats(_irej, _jrej, _k) <> " " Then
                                        _Smp.cei(_Smp.ne) = _irej
                                        _Smp.cej(_Smp.ne) = _jrej
                                        _Smp.cek(_Smp.ne) = _k
                                        _Smp.cev(_Smp.ne) = Val(_k + 1)
                                        _Smp.ne += 1
                                    End If
                                End If
                            Next
                        Next
                        _smp.m = "CV Ligne-Région "
                        _QSmp.Enqueue(_smp)
                    End If
                Next
                '
            Next
        Next
    End Sub

    '============================================================================================================================================================
    ' Suppression de candidats dans la grille
    ' Applique et retire une occurrence de la table des simplifications
    '============================================================================================================================================================

    Sub AppliqueUneSimplification(ByRef _QSmp As Queue(Of Sudoku.StrSmp), ByRef _Candidats(,,) As String)

        Dim _s As Integer
        Dim _t As Integer
        Dim _i As Integer
        Dim _j As Integer
        Dim _k As Integer
        Dim _Smp As New Sudoku.StrSmp

        _Smp = _QSmp.Dequeue()

        'candidats rejetés
        For _s = 0 To _Smp.ne
            _i = _Smp.cei(_s)
            _j = _Smp.cej(_s)
            _k = _Smp.cek(_s)
            _Candidats(_i, _j, _k) = " "
        Next

    End Sub

    '============================================================================================================================================================
    ' Suppression de candidats dans la grille
    ' Retire toutes les occurrences de la table des simplifications
    '============================================================================================================================================================

    Sub SupprimeLesCandidat(ByRef _NbSmp As String, ByRef _TabSmp() As Sudoku.StrSmp, ByRef _Candidats(,,) As String)

        Dim _t As Integer
        Dim _Smp As New Sudoku.StrSmp

        For _t = 0 To _NbSmp
            _Smp = _TabSmp(_t)
            'candidats rejetés
            For s = 0 To _Smp.ne
                _Candidats(_Smp.cri(_Smp.ne), _Smp.crj(_Smp.ne), _Smp.crk(_Smp.ne)) = " "
            Next

            ' Efface l'occurrence t

            _TabSmp(_t).m = " "
            _TabSmp(_t).act = False
            _TabSmp(_t).nr = 0
            For j = 0 To 3
                _TabSmp(_t).cri(j) = 0
                _TabSmp(_t).crj(j) = 0
                _TabSmp(_t).crk(j) = 0
                _TabSmp(_t).crv(j) = " "
            Next
            _TabSmp(_t).ne = 0
            For j = 0 To 20
                _TabSmp(_t).cei(j) = 0
                _TabSmp(_t).cej(j) = 0
                _TabSmp(_t).cek(j) = 0
            Next
        Next

        _NbSmp -= 0

    End Sub
End Module
