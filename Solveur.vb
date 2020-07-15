Module Solveur



    Sub initialisations(ByRef _Grille(,) As String, ByRef _Candidats(,,) As String, ByRef _cpk(,) As Integer, ByRef _cpl(,) As Integer, ByRef _cpc(,) As Integer, ByRef _cpr(,) As Integer)

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
        'initialise les compteurs
        For _i = 0 To 8
            For _j = 0 To 8
                _cpk(_i, _j) = 0
                _cpl(_i, _j) = 0
                _cpc(_i, _j) = 0
                _cpr(_i, _j) = 0
            Next
        Next
    End Sub

    Sub ExtraitLig(ByRef _Segment() As String, ByRef _SegmentCandidats(,) As String, ByVal _Grille(,) As String, ByVal _Candidats(,,) As String, _i As Integer)

        ' extrait un segment et un segment candidats d'une ligne
        Dim _j As Integer
        Dim _k As Integer

        For _j = 0 To 8
            _Segment(_j) = _Grille(_i, _j)
            For _k = 0 To 8
                _SegmentCandidats(_j, _k) = _Candidats(_i, _j, _k)
            Next
        Next

    End Sub

    Sub ExtraitCol(ByRef _Segment() As String, ByRef _SegmentCandidats(,) As String, ByVal _Grille(,) As String, ByVal _Candidats(,,) As String, _j As Integer)

        ' extrait un segment et un segment candidats d'une colonne
        Dim _i As Integer
        Dim _k As Integer

        For _i = 0 To 8
            _Segment(_i) = _Grille(_i, _j)
            For _k = 0 To 8
                _SegmentCandidats(_i, _k) = _Candidats(_i, _j, _k)
            Next
        Next

    End Sub

    Sub ExtraitReg(ByRef _Segment() As String, ByRef _SegmentCandidats(,) As String, ByVal _Grille(,) As String, ByVal _Candidats(,,) As String, _r As Integer)

        ' extrait un segment et un segment candidats d'une région
        Dim _i As Integer
        Dim _j As Integer
        Dim _k As Integer
        Dim _ir As Integer
        Dim _jr As Integer
        Dim _g As Integer = 0

        _ir = (_r \ 3) * 3
        _jr = (_r - _ir) * 3
        For _i = _ir To _ir + 2
            For _j = _jr To _jr + 2
                _Segment(_g) = _Grille(_i, _j)
                For _k = 0 To 8
                    _SegmentCandidats(_g, _k) = _Candidats(_ir, _jr, _k)
                Next
                _g += 1
            Next
        Next

    End Sub



    Sub ControleSegment(ByRef _Erreur As Boolean, ByRef _ErreurSegment() As String, ByVal _Segment() As String, indice As Integer)

        Dim _i As Integer
        Dim _j As Integer
        For _i = 0 To 8
            _ErreurSegment(_i) = " "
        Next
        For _i = 0 To 7
            For _j = _i + 1 To 8
                If _Segment(_i) = _Segment(_j) And _Segment(_i) <> "0" Then
                    _ErreurSegment(_i) = "X"
                    _ErreurSegment(_j) = "X"
                    _Erreur = True
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

    Sub ControleCandidat(ByRef _Erreur As Boolean, ByRef _ErreurCandidat() As String, ByVal _Segment() As String, ByVal _SegmentCandidats(,) As String, TypeSegment As String, indice As Integer, ByVal _Candidats(,,) As String)

        Dim _s As Integer
        Dim _k As Integer
        For _s = 0 To 8
            _ErreurCandidat(_s) = " "
        Next
        For _s = 0 To 8
            If _Segment(_s) = "0" Then
                _ErreurCandidat(_s) = "X"
                For _k = 0 To 8
                    If _SegmentCandidats(_s, _k) <> " " Then
                        _ErreurCandidat(_s) = " "
                    End If
                Next
                If _ErreurCandidat(_s) = "X" Then
                    _Erreur = True
                End If
            End If
        Next

    End Sub

    Sub ControleCandidatLigne(ByRef _Erreur As Boolean, ByRef _ErreurGrille(,) As String, ByVal _Grille(,) As String, ByVal _Candidats(,,) As String, _i As Integer)

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

    ' Sub ControleGénération(ByRef _Segment() As String, ByRef _SegmentCandidats(,) As String, ByVal _Grille(,) As String, ByVal _Candidats(,,) As String, ByRef _ErreurSegment() As String, ByRef _ErreurCandidat() As String, ByRef _Erreur As Boolean)
    Sub ControleGénération(ByRef _Erreur As Boolean, ByRef _ErreurGrille(,) As String, ByVal _Grille(,) As String, ByVal _Candidats(,,) As String)
        ' Recherche d'erreurs sur les lignes
        Dim _i As Integer
        Dim _j As Integer
        Dim _r As Integer
        Dim TypeSegment As String
        _Erreur = False
        TypeSegment = "ligne"
        ' Recherche d'erreurs sur les lignes
        For _i = 0 To 8
            ControleLigne(_Erreur, _ErreurGrille, _Grille, _i)
            ControleCandidatLigne(_Erreur, _ErreurGrille, _Grille, _Candidats, _i)
        Next
        TypeSegment = "colonne"
        ' Recherche d'erreurs sur les colonnes
        For _j = 0 To 8
            ControleColonne(_Erreur, _ErreurGrille, _Grille, _j)
            ControleCandidatColonne(_Erreur, _ErreurGrille, _Grille, _Candidats, _j)
        Next
        TypeSegment = "région"
        ' Recherche d'erreurs sur les régions
        For _r = 0 To 8
            ControleRégion(_Erreur, _ErreurGrille, _Grille, _j)
            ControleCandidatColonne(_Erreur, _ErreurGrille, _Grille, _Candidats, _r)
        Next
    End Sub
    '
    ' ============================================================================================================================================
    '
    '                                                         M O T E U R
    '
    '============================================================================================================================================
    '

    Sub Calcul_Candidats(ByRef _Grille(,) As String, ByRef _Segment() As String, ByRef _Candidats(,,) As String,
                         ByRef _SegmentCandidats(,) As String, ByRef _cpk(,) As Integer,
                         ByRef _cpl(,) As Integer, ByRef _cpli(,) As Integer, _cplj(,) As Integer, ByRef _cplk(,) As Integer,
                         ByRef _cpc(,) As Integer, ByRef _cpci(,) As Integer, _cpcj(,) As Integer, ByRef _cpck(,) As Integer,
                         ByRef _cpr(,) As Integer, ByRef _cpri(,) As Integer, _cprj(,) As Integer, ByRef _cprk(,) As Integer,
                         ByRef _TabSolution() As Sudoku.Solution, ByRef _NbSol As Integer)
        '
        ' Elimine les candidats dans les lignes colonnes et régions
        '
        Dim _i As Integer
        Dim _j As Integer
        Dim _r As Integer
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

        'Mise à jour le tableau des possibilités par case
        génère_cpk(_Candidats, _cpk)

        'Mise à jour le tableau des possibilités par ligne
        génère_cpl(_Candidats, _cpl, _cpli, _cplj, _cplk)

        'Mise à jour le tableau des possibilités par colonne
        génère_cpc(_Candidats, _cpc, _cpci, _cpcj, _cpck)

        'Mise à jour le tableau des possibilités par région
        génère_cpr(_Candidats, _cpr, _cpri, _cprj, _cprk)

        _NbSol = 0
        _NbSol = SeulDansUneCase(_Candidats, _cpk, _TabSolution, _NbSol)
        _NbSol = SeulDansUneLigne(_cpl, _cpli, _cplj, _cplk, _TabSolution, _NbSol)
        _NbSol = SeulDansUneColonne(_cpc, _cpci, _cpcj, _cpck, _TabSolution, _NbSol)
        _NbSol = SeulDansUneRégion(_cpr, _cpri, _cprj, _cprk, _TabSolution, _NbSol)

    End Sub



    Sub GommeLigne(ByVal Grille(,) As String, ByRef Candidats(,,) As String, _i As Integer)

        'Elimine les candidats dans une ligne

        Dim _j As Integer
        Dim _jbis As Integer
        Dim _k As Integer
        Dim _s As Integer
        Dim Valeur As String


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
        Dim _Segment(8) As String
        Dim _SegmentCandidats(8, 8) As String

        For _k = 0 To 8
            _Candidats(_i, _j, _k) = " "  ' on enlève les candidats de la case qui vient d'être garnie
        Next

        ' Efface le candidat dans la ligne

        GommeLigne(_Grille, _Candidats, _i)

        ' Efface le candidat dans la colonne 

        GommeColonne(_Grille, _Candidats, _j)

        ' Efface le candidat dans la région 
        _r = ((_i \ 3) * 3) + (_j \ 3)  ' calcule la région d'après i et j
        GommeColonne(_Grille, _Candidats, _r)


    End Sub

    '============================================================================================================================================================
    ' Recherche de solution 
    ' Détermine s'il n'y a plus qu'un candidat dans la case 
    '============================================================================================================================================================

    Sub génère_cpk(ByRef _Candidats(,,) As String, ByRef _cpk(,) As Integer)
        ' détermine les possibilités par case
        Dim _i As Integer
        Dim _j As Integer
        Dim _k As Integer

        For _i = 0 To 8
            For _j = 0 To 8
                _cpk(_i, _j) = 0
                For _k = 0 To 8
                    If _Candidats(_i, _j, _k) <> " " Then
                        _cpk(_i, _j) += 1
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

    Sub génère_cpl(ByRef _Candidats(,,) As String, ByRef _cpl(,) As Integer, ByRef _cpli(,) As Integer, ByRef _cplj(,) As Integer, ByRef _cplk(,) As Integer)
        ' - Détermine le nombre d'occurrences par ligne
        ' - Détermine la position d'une occurrence seule sur une ligne
        ' - recense les doublons et la position du dernier de chaque doublon sur une ligne
        ' - recense les triplets et la position du dernier de chaque triplet sur une ligne

        Dim _i As Integer
        Dim _j As Integer
        Dim _k As Integer

        ' - Initialise le nombre d'occurrences de k par ligne
        For _i = 0 To 8
            For _k = 0 To 8
                _cpl(_i, _k) = 0
            Next
        Next

        ' - Détermine le nombre d'occurrences de k par ligne
        For _i = 0 To 8
            For _k = 0 To 8
                _cpl(_i, _k) = 0
                For _j = 0 To 8
                    If _Candidats(_i, _j, _k) <> " " Then
                        _cpl(_i, _k) += 1
                        _cpli(_i, _k) = _i
                        _cplj(_i, _k) = _j
                        _cplk(_i, _k) = _k
                    End If
                Next
            Next
        Next

        ' - recense les doublons et la position du dernier de chaque doublon sur une ligne
        ' - recense les triplets et la position du dernier de chaque triplet sur une ligne
    End Sub

    '============================================================================================================================================================
    ' Recherche de solution 
    ' Détermine le nombre d'occurrences de chaque candidat par colonne
    ' S'il n'y a qu'une occurrence c'est la solution retenue 
    '============================================================================================================================================================

    Sub génère_cpc(ByRef _Candidats(,,) As String, _cpc(,) As Integer, ByRef _cpci(,) As Integer, ByRef _cpcj(,) As Integer, ByRef _cpck(,) As Integer)
        ' - Détermine le nombre d'occurrences par colonne
        ' - Détermine la position d'une occurrence seule sur une colonne
        ' - recense les doublons et la position du dernier de chaque doublon sur une colonne
        ' - recense les triplets et la position du dernier de chaque triplet sur une colonne

        Dim _i As Integer
        Dim _j As Integer
        Dim _k As Integer

        ' - Initialise le nombre d'occurrences de k par colonne
        For _j = 0 To 8
            For _k = 0 To 8
                _cpc(_j, _k) = 0
            Next
        Next

        ' - Détermine le nombre d'occurrences de k par colonne
        For _j = 0 To 8
            For _k = 0 To 8
                _cpc(_j, _k) = 0
                For _i = 0 To 8
                    If _Candidats(_i, _j, _k) <> " " Then
                        _cpc(_j, _k) += 1
                        _cpci(_j, _k) = _i
                        _cpcj(_j, _k) = _j
                        _cpck(_j, _k) = _k
                    End If
                Next
            Next
        Next

        ' - recense les doublons et la position du dernier de chaque doublon sur une colonne
        ' - recense les triplets et la position du dernier de chaque triplet sur une colonne

    End Sub

    '============================================================================================================================================================
    ' Recherche de solution 
    ' Détermine le nombre d'occurrences de chaque candidat par région
    ' S'il n'y a qu'une occurrence c'est la solution retenue 
    '============================================================================================================================================================

    Sub génère_cpr(ByRef _Candidats(,,) As String, ByRef _cpr(,) As Integer, ByRef _cpri(,) As Integer, ByRef _cprj(,) As Integer, ByRef _cprk(,) As Integer)

        ' - Détermine le nombre d'occurrences par région
        ' - Détermine la position d'une occurrence seule sur une région
        ' - recense les doublons et la position du dernier de chaque doublon sur une région
        ' - recense les triplets et la position du dernier de chaque triplet sur une région

        Dim _i As Integer
        Dim _j As Integer
        Dim _ir As Integer
        Dim _jr As Integer
        Dim _k As Integer
        Dim _r As Integer

        ' - Initialise le nombre d'occurrences de k par région
        For _r = 0 To 8
            For _k = 0 To 8
                _cpr(_r, _k) = 0
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
                            _cpr(_r, _k) += 1
                            _cpri(_r, _k) = _i
                            _cprj(_r, _k) = _j
                            _cprk(_r, _k) = _k
                        End If
                    Next
                Next
            Next
        Next

        ' - recense les doublons et la position du dernier de chaque doublon sur une région
        ' - recense les triplets et la position du dernier de chaque triplet sur une région

    End Sub

    '============================================================================================================================================================
    ' Recherche de solution 
    ' Balaye la table cpk - candidats par case - pour alimenter la table des solutions à proposer
    '============================================================================================================================================================

    Function SeulDansUneCase(_Candidats(,,) As String, _cpk(,) As Integer, _TabSolution() As Sudoku.Solution, _NbSol As Integer)

        Dim _i As Integer
        Dim _j As Integer
        Dim _k As Integer
        Dim _New_Solution As Sudoku.Solution

        For _i = 0 To 8
            For _j = 0 To 8
                If _cpk(_i, _j) = 1 Then
                    For _k = 0 To 8
                        If _Candidats(_i, _j, _k) <> " " Then
                            _New_Solution.i = _i
                            _New_Solution.j = _j
                            _New_Solution.k = Sudoku.Val(_k)
                            _New_Solution.m = "Seul candidat dans cette case"
                            _NbSol = Add_Solution(_TabSolution, _New_Solution, _NbSol)
                        End If
                    Next
                End If
            Next
        Next
        Return _NbSol
    End Function

    ''============================================================================================================================================================
    '' Recherche de solution 
    '' Balaye la table cpl - possiblilités par ligne - pour alimenter la table des solutions à proposer
    ''============================================================================================================================================================

    'Function SeulDansUneLigne(_cpl(,) As Integer, _cpli(,) As Integer, _cplj(,) As Integer, _cplk(,) As Integer, _TabSolution() As Sudoku.Solution, _NbSol As Integer)

    '    Dim _i As Integer
    '    Dim _j As Integer
    '    Dim _k As Integer
    '    Dim _New_Solution As Sudoku.Solution

    '    ' - Détermine la position d'une occurrence seule sur une ligne

    '    For _i = 0 To 8
    '        For _k = 0 To 8
    '            If _cpl(_i, _k) = 1 Then
    '                _New_Solution.i = _cpli(_i, _k)
    '                _New_Solution.j = _cplj(_j, _k)
    '                _New_Solution.k = Sudoku.Val(_cplk(_i, _k))
    '                _New_Solution.m = "Seule présence dans cette ligne"
    '                _NbSol = Add_Solution(_TabSolution, _New_Solution, _NbSol)
    '            End If
    '        Next
    '    Next

    '    ' - recense les doublons et la position du dernier de chaque doublon sur une ligne
    '    ' - recense les triplets et la position du dernier de chaque triplet sur une ligne

    '    Return _NbSol

    'End Function

    ''============================================================================================================================================================
    '' Recherche de solution 
    '' Balaye la table cpc - possiblilités par colonne - pour alimenter la table des solutions à proposer
    ''============================================================================================================================================================

    'Function SeulDansUneColonne(_cpc(,) As Integer, _cpci(,) As Integer, _cpcj(,) As Integer, _cpck(,) As Integer, _TabSolution() As Sudoku.Solution, _NbSol As Integer)

    '    Dim _i As Integer
    '    Dim _j As Integer
    '    Dim _k As Integer
    '    Dim _New_Solution As Sudoku.Solution

    '    ' - Détermine la position d'une occurrence seule sur une colonne

    '    For _j = 0 To 8
    '        For _k = 0 To 8
    '            If _cpc(_j, _k) = 1 Then
    '                _New_Solution.i = _cpci(_i, _k)
    '                _New_Solution.j = _cpcj(_j, _k)
    '                _New_Solution.k = Sudoku.Val(_cpck(_j, _k))
    '                _New_Solution.m = "Seule présence dans cette colonne"
    '                _NbSol = Add_Solution(_TabSolution, _New_Solution, _NbSol)
    '            End If
    '        Next
    '    Next

    '    Return _NbSol

    'End Function


    '============================================================================================================================================================
    ' Recherche de solution 
    ' Balaye la table cpl - possiblilités par ligne - pour alimenter la table des solutions à proposer
    '============================================================================================================================================================

    Function SeulDansUneLigne(_cpl(,) As Integer, _cpli(,) As Integer, _cplj(,) As Integer, _cplk(,) As Integer, _TabSolution() As Sudoku.Solution, _NbSol As Integer)

        Dim _i As Integer

        Dim _k As Integer
        Dim _New_Solution As Sudoku.Solution

        ' - Détermine la position d'une occurrence seule sur une ligne

        For _i = 0 To 8
            For _k = 0 To 8
                If _cpl(_i, _k) = 1 Then
                    _New_Solution.i = _cpli(_i, _k)
                    _New_Solution.j = _cplj(_i, _k)
                    _New_Solution.k = Sudoku.Val(_cplk(_i, _k))
                    _New_Solution.m = "Seule présence dans cette ligne"
                    _NbSol = Add_Solution(_TabSolution, _New_Solution, _NbSol)
                End If
            Next
        Next

        ' - recense les doublons et la position du dernier de chaque doublon sur une ligne
        ' - recense les triplets et la position du dernier de chaque triplet sur une ligne

        Return _NbSol

    End Function

    '============================================================================================================================================================
    ' Recherche de solution 
    ' Balaye la table cpc - possiblilités par colonne - pour alimenter la table des solutions à proposer
    '============================================================================================================================================================

    Function SeulDansUneColonne(_cpc(,) As Integer, _cpci(,) As Integer, _cpcj(,) As Integer, _cpck(,) As Integer, _TabSolution() As Sudoku.Solution, _NbSol As Integer)


        Dim _j As Integer
        Dim _k As Integer
        Dim _New_Solution As Sudoku.Solution

        ' - Détermine la position d'une occurrence seule sur une colonne

        For _j = 0 To 8
            For _k = 0 To 8
                If _cpc(_j, _k) = 1 Then
                    _New_Solution.i = _cpci(_j, _k)
                    _New_Solution.j = _cpcj(_j, _k)
                    _New_Solution.k = Sudoku.Val(_cpck(_j, _k))
                    _New_Solution.m = "Seule présence dans cette colonne"
                    _NbSol = Add_Solution(_TabSolution, _New_Solution, _NbSol)
                End If
            Next
        Next

        Return _NbSol

    End Function

    '============================================================================================================================================================
    ' Recherche de solution 
    ' Balaye la table cpr - possiblilités par région - pour alimenter la table des solutions à proposer
    '============================================================================================================================================================

    Function SeulDansUneRégion(_cpr(,) As Integer, _cpri(,) As Integer, _cprj(,) As Integer, _cprk(,) As Integer, _TabSolution() As Sudoku.Solution, _NbSol As Integer)

        Dim _r As Integer
        Dim _k As Integer
        Dim _New_Solution As Sudoku.Solution

        ' - Détermine la position d'une occurrence seule sur une région

        For _r = 0 To 8
            For _k = 0 To 8
                If _cpr(_r, _k) = 1 Then
                    _New_Solution.i = _cpri(_r, _k)
                    _New_Solution.j = _cprj(_r, _k)
                    _New_Solution.k = Sudoku.Val(_cprk(_r, _k))
                    _New_Solution.m = "Seule présence dans cette région"
                    _NbSol = Add_Solution(_TabSolution, _New_Solution, _NbSol)
                End If
            Next
        Next

        Return _NbSol

    End Function

    '============================================================================================================================================================
    ' Ajoute un poste dans la table des solutions 
    '============================================================================================================================================================

    Function Add_Solution(_TabSolution() As Sudoku.Solution, New_Solution As Sudoku.Solution, _NbSol As Integer)

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
            _TabSolution(_NbSol).k = New_Solution.k
            _TabSolution(_NbSol).m = New_Solution.m
            _NbSol += 1
        End If
        Return _NbSol
    End Function

    '============================================================================================================================================================
    ' Fait une rotation des postes de la table des solutions
    '============================================================================================================================================================

    Sub ProchaineSolution(ByRef _TabSolution() As Sudoku.Solution, ByRef _NbSol As Integer)

        Dim _Temp_Solution As Sudoku.Solution
        Dim _s As Integer
        _Temp_Solution = _TabSolution(0)
        For _s = 0 To _NbSol - 2
            _TabSolution(_s) = _TabSolution(_s + 1)
        Next
        _TabSolution(_NbSol - 1) = _Temp_Solution

    End Sub

    Sub SupprSolution(ByRef _TabSolution() As Sudoku.Solution, ByRef _NbSol As Integer)

        Dim _s As Integer

        For _s = 0 To _NbSol - 1
            _TabSolution(_s).i = "0"
            _TabSolution(_s).j = "0"
            _TabSolution(_s).k = ""
            _TabSolution(_s).m = ""
        Next

    End Sub

End Module
