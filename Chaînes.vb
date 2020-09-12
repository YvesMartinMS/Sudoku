Module Chaînes

    '============================================================================================================================================================
    ' Techniques d'élimination de candidats
    ' Chaîne fortement liée - Contradiction (chaîne paire) ou Double exclusion (Chaîne impaire)
    '============================================================================================================================================================

    Sub ChaîneFortementLiée(ByRef _Candidats(,,) As Integer,
                            ByRef _NbrSmp As Integer,
                            ByRef _Tsmp() As Sudoku.StrSmp,
                            ByVal _AnlLig(,) As Sudoku.StrAnalyse,
                            ByVal _AnlCol(,) As Sudoku.StrAnalyse,
                            ByVal _AnlReg(,) As Sudoku.StrAnalyse)


        Dim _tLiens(Sudoku.MaxLiens) As Sudoku.strLien
        Dim _NbLiens As Integer
        Dim _tChaînePaire(Sudoku.MaxChn) As Sudoku.strChaîne
        Dim _tChaîneImpaire(Sudoku.MaxChn) As Sudoku.strChaîne

        Dim _LngChP As Integer = 0
        Dim _LngChI As Integer = 0

        Dim _NbChi As Integer = 0
        Dim _Généré As Boolean = False

        For _k = 0 To 8
            CollecteLiens(_Candidats, _tLiens, _NbLiens, _AnlLig, _AnlCol, _AnlReg, _k)
            If _NbLiens > 2 Then
                CréeChaîneForte(_Candidats, _k, _tLiens, _NbLiens, _tChaînePaire, _LngChP, _tChaîneImpaire, _LngChI, _AnlLig, _AnlCol, _AnlReg)
                If _LngChP > 0 Then
                    Contradiction(_tChaînePaire, _LngChP, _NbrSmp, _Tsmp, _k, _Généré)
                    If _Généré Then
                        Exit Sub
                    End If
                End If
                If _NbrSmp = 0 And _LngChI > 0 Then
                    DoubleExclusion(_Candidats, _tChaîneImpaire, _LngChI, _NbChi, _NbrSmp, _Tsmp, _k, _Généré)
                    If _Généré Then
                        Exit Sub
                    End If
                End If
            End If
        Next

    End Sub

    '============================================================================================================================================================
    ' Techniques d'élimination de candidats
    ' Contradiction (chaîne fortement liée paire) 
    ' Préparation de l'affichage et de l'application de la solution Contradiction 
    '============================================================================================================================================================

    Sub Contradiction(ByVal _tChaînePaire() As Sudoku.strChaîne,
                      ByVal _LngChP As Integer,
                      ByRef _NbrSmp As Integer,
                      ByRef _Tsmp() As Sudoku.StrSmp,
                      ByVal _k As Integer,
                      ByRef _Généré As Boolean)

        Dim _m As String
        Dim _c As Integer
        Dim _Smp As Sudoku.StrSmp

        _Smp = NewSmp()

        _m = "Contradiction [" & _k + 1 & "]  dans les cellules L" & _tChaînePaire(0).i1 + 1 & "C" & _tChaînePaire(0).j1 + 1 & " et L" & _tChaînePaire(_LngChP).i2 + 1 & "C" & _tChaînePaire(_LngChP).j2 + 1 & " de la chaîne fortement liée : " & vbCrLf &
                            "L" & _tChaînePaire(0).i1 + 1 & "C" & _tChaînePaire(0).j1 + 1
        For _c = 0 To _LngChP
            _m = _m & "-L" & _tChaînePaire(_c).i2 + 1 & "C" & _tChaînePaire(_c).j2 + 1
        Next

        _Smp.nr = 0
        _Smp.ne = 0
        _Smp.motif = _m

        _Smp.CE.i(_Smp.ne) = _tChaînePaire(0).i1
        _Smp.CE.j(_Smp.ne) = _tChaînePaire(0).j1
        _Smp.CE.k(_Smp.ne) = _k
        _Smp.CE.v(_Smp.ne) = _k + 1
        _Smp.ne += 1


        For _c = 0 To _LngChP
            If _c Mod 2 = 0 Then
                _Smp.CR.i(_Smp.nr) = _tChaînePaire(_c).i2
                _Smp.CR.j(_Smp.nr) = _tChaînePaire(_c).j2
                _Smp.CR.k(_Smp.nr) = _k
                _Smp.CR.v(_Smp.nr) = _k + 1
                _Smp.nr += 1
            Else
                _Smp.CE.i(_Smp.ne) = _tChaînePaire(_c).i2
                _Smp.CE.j(_Smp.ne) = _tChaînePaire(_c).j2
                _Smp.CE.k(_Smp.ne) = _k
                _Smp.CE.v(_Smp.ne) = _k + 1
                _Smp.ne += 1
            End If
        Next

        _Smp.MultiSol = True

        If _Smp.ne > 0 Then
            _Tsmp(_NbrSmp) = _Smp
            _NbrSmp += 1
            _Smp = NewSmp()
        End If

    End Sub

    '============================================================================================================================================================
    ' Techniques d'élimination de candidats
    ' Double Exclusion (chaîne fortement liée paire) 
    '============================================================================================================================================================

    Sub DoubleExclusion(ByVal _Candidats As Integer(,,),
                        ByVal _tChaîneImpaire() As Sudoku.strChaîne,
                        ByVal _LngChI As Integer,
                        ByVal _NbChi As Integer,
                        ByRef _NbrSmp As Integer,
                        ByRef _Tsmp() As Sudoku.StrSmp,
                        ByVal _k As Integer,
                        ByRef _Généré As Boolean)

        Dim _i As Integer
        Dim _j As Integer
        Dim _c As Integer
        Dim _p As Integer
        Dim _i0 As Integer
        Dim _ip As Integer
        Dim _j0 As Integer
        Dim _jp As Integer
        Dim _r0 As Integer
        Dim _rp As Integer
        Dim _csgi0 As Integer
        Dim _csgip As Integer
        Dim _csgj0 As Integer
        Dim _csgjp As Integer
        Dim _Smp As Sudoku.StrSmp
        _Smp = NewSmp()

        _p = _LngChI
        ' coordonnées fin de chaîne
        _i0 = _tChaîneImpaire(0).i1
        _j0 = _tChaîneImpaire(0).j1
        _r0 = _tChaîneImpaire(0).r1
        ' coordonnées fin de chaîne
        _ip = _tChaîneImpaire(_p).i2
        _jp = _tChaîneImpaire(_p).j2
        _rp = _tChaîneImpaire(_p).r2
        _csgi0 = (_r0 \ 3) * 3
        _csgj0 = (_r0 - _csgi0) * 3
        _csgip = (_rp \ 3) * 3
        _csgjp = (_rp - _csgip) * 3

        _Smp.ne = 0
        ' test d'une intersection ligne colonne
        If (_i0 <> _ip And _j0 <> _jp) Then ' ni sur la même ligne ni sur la même colonne
            If _Candidats(_i0, _jp, _k) = _k + 1 Then
                _Smp.CE.i(_Smp.ne) = _i0
                _Smp.CE.j(_Smp.ne) = _jp
                _Smp.CE.k(_Smp.ne) = _k
                _Smp.CE.v(_Smp.ne) = _k + 1
                _Smp.ne += 1
                GénéDoubleExclusion(_tChaîneImpaire, _LngChI, _NbrSmp, _Tsmp, _Smp, _c, _k)
                Exit Sub
            End If
            If _Candidats(_ip, _j0, _k) = _k + 1 Then
                _Smp.CE.i(_Smp.ne) = _ip
                _Smp.CE.j(_Smp.ne) = _j0
                _Smp.CE.k(_Smp.ne) = _k
                _Smp.CE.v(_Smp.ne) = _k + 1
                _Smp.ne += 1
                GénéDoubleExclusion(_tChaîneImpaire, _LngChI, _NbrSmp, _Tsmp, _Smp, _c, _k)
                Exit Sub
            End If
        End If

        If (_r0 <> _rp) Then ' pas dans la même région

            ' test d'une intersection ligne région
            If (_i0 <> _ip) Then ' pas sur la la même ligne
                If (_i0 >= _csgip) And (_i0 <= _csgip + 2) Then ' mais une ligne commune avec la région
                    If (_Candidats(_i0, _csgjp, _k) = _k + 1) Or (_Candidats(_i0, _csgjp + 1, _k) = _k + 1) Or (_Candidats(_i0, _csgjp + 2, _k) = _k + 1) Then
                        If (_Candidats(_i0, _csgjp, _k) = _k + 1) Then
                            _Smp.CE.i(_Smp.ne) = _i0
                            _Smp.CE.j(_Smp.ne) = _csgjp
                            _Smp.CE.k(_Smp.ne) = _k
                            _Smp.CE.v(_Smp.ne) = _k + 1
                            _Smp.ne += 1
                        End If
                        If (_Candidats(_i0, _csgjp + 1, _k) = _k + 1) Then
                            _Smp.CE.i(_Smp.ne) = _i0
                            _Smp.CE.j(_Smp.ne) = _csgjp + 1
                            _Smp.CE.k(_Smp.ne) = _k
                            _Smp.CE.v(_Smp.ne) = _k + 1
                            _Smp.ne += 1
                        End If
                        If (_Candidats(_i0, _csgjp + 2, _k) = _k + 1) Then
                            _Smp.CE.i(_Smp.ne) = _i0
                            _Smp.CE.j(_Smp.ne) = _csgjp + 2
                            _Smp.CE.k(_Smp.ne) = _k
                            _Smp.CE.v(_Smp.ne) = _k + 1
                            _Smp.ne += 1
                        End If
                        GénéDoubleExclusion(_tChaîneImpaire, _LngChI, _NbrSmp, _Tsmp, _Smp, _c, _k)
                        Exit Sub
                    End If
                End If
                If (_ip >= _csgi0) And (_ip <= _csgi0 + 2) Then ' mais une ligne commune avec la région
                    If (_Candidats(_ip, _csgj0, _k) = _k + 1) Or (_Candidats(_ip, _csgj0 + 1, _k) = _k + 1) Or (_Candidats(_ip, _csgj0 + 2, _k) = _k + 1) Then
                        If (_Candidats(_i0, _csgj0, _k) = _k + 1) Then
                            _Smp.CE.i(_Smp.ne) = _ip
                            _Smp.CE.j(_Smp.ne) = _csgj0
                            _Smp.CE.k(_Smp.ne) = _k
                            _Smp.CE.v(_Smp.ne) = _k + 1
                            _Smp.ne += 1
                        End If
                        If (_Candidats(_i0, _csgj0 + 1, _k) = _k + 1) Then
                            _Smp.CE.i(_Smp.ne) = _ip
                            _Smp.CE.j(_Smp.ne) = _csgj0 + 1
                            _Smp.CE.k(_Smp.ne) = _k
                            _Smp.CE.v(_Smp.ne) = _k + 1
                            _Smp.ne += 1
                        End If
                        If (_Candidats(_i0, _csgj0 + 2, _k) = _k + 1) Then
                            _Smp.CE.i(_Smp.ne) = _ip
                            _Smp.CE.j(_Smp.ne) = _csgj0 + 2
                            _Smp.CE.k(_Smp.ne) = _k
                            _Smp.CE.v(_Smp.ne) = _k + 1
                            _Smp.ne += 1
                        End If
                        GénéDoubleExclusion(_tChaîneImpaire, _LngChI, _NbrSmp, _Tsmp, _Smp, _c, _k)
                        Exit Sub
                    End If
                End If
            End If

            ' test d'une intersection colonne région
            If (_j0 <> _jp) Then ' pas sur la la même colonne
                If (_j0 >= _csgjp) And (_j0 <= _csgjp + 2) Then ' mais une colonne commune avec la région
                    If (_Candidats(_csgip, _j0, _k) = _k + 1) Or (_Candidats(_csgip + 1, _j0, _k) = _k + 1) Or (_Candidats(_csgip + 2, _j0, _k) = _k + 1) Then
                        If (_Candidats(_csgip, _j0, _k) = _k + 1) Then
                            _Smp.CE.i(_Smp.ne) = _csgip
                            _Smp.CE.j(_Smp.ne) = _j0
                            _Smp.CE.k(_Smp.ne) = _k
                            _Smp.CE.v(_Smp.ne) = _k + 1
                            _Smp.ne += 1
                        End If
                        If (_Candidats(_csgip + 1, _j0, _k) = _k + 1) Then
                            _Smp.CE.i(_Smp.ne) = _csgip + 1
                            _Smp.CE.j(_Smp.ne) = _j0
                            _Smp.CE.k(_Smp.ne) = _k
                            _Smp.CE.v(_Smp.ne) = _k + 1
                            _Smp.ne += 1
                        End If
                        If (_Candidats(_csgip + 2, _j0, _k) = _k + 1) Then
                            _Smp.CE.i(_Smp.ne) = _csgip + 2
                            _Smp.CE.j(_Smp.ne) = _j0
                            _Smp.CE.k(_Smp.ne) = _k
                            _Smp.CE.v(_Smp.ne) = _k + 1
                            _Smp.ne += 1
                        End If
                        GénéDoubleExclusion(_tChaîneImpaire, _LngChI, _NbrSmp, _Tsmp, _Smp, _c, _k)
                        Exit Sub
                    End If
                End If
                If (_jp >= _csgj0) And (_jp <= _csgj0 + 2) Then ' mais une colonne commune avec la région
                    If (_Candidats(_csgi0, _jp, _k) = _k + 1) Or (_Candidats(_csgi0 + 1, _jp, _k) = _k + 1) Or (_Candidats(_csgi0 + 2, _jp, _k) = _k + 1) Then
                        If (_Candidats(_csgi0, _jp, _k) = _k + 1) Then
                            _Smp.CE.i(_Smp.ne) = _csgi0
                            _Smp.CE.j(_Smp.ne) = _jp
                            _Smp.CE.k(_Smp.ne) = _k
                            _Smp.CE.v(_Smp.ne) = _k + 1
                            _Smp.ne += 1
                        End If
                        If (_Candidats(_csgi0 + 1, _jp, _k) = _k + 1) Then
                            _Smp.CE.i(_Smp.ne) = _csgi0 + 1
                            _Smp.CE.j(_Smp.ne) = _jp
                            _Smp.CE.k(_Smp.ne) = _k
                            _Smp.CE.v(_Smp.ne) = _k + 1
                            _Smp.ne += 1
                        End If
                        If (_Candidats(_csgi0 + 2, _jp, _k) = _k + 1) Then
                            _Smp.CE.i(_Smp.ne) = _csgi0 + 2
                            _Smp.CE.j(_Smp.ne) = _jp
                            _Smp.CE.k(_Smp.ne) = _k
                            _Smp.CE.v(_Smp.ne) = _k + 1
                            _Smp.ne += 1
                        End If
                        GénéDoubleExclusion(_tChaîneImpaire, _LngChI, _NbrSmp, _Tsmp, _Smp, _c, _k)
                        Exit Sub
                    End If
                End If
            End If
        End If
    End Sub

    '============================================================================================================================================================
    ' Techniques d'élimination de candidats
    ' Préparation de l'affichage et de l'application de la solution Contradiction 
    '============================================================================================================================================================

    Sub GénéDoubleExclusion(ByRef _tChaîneImpaire() As Sudoku.strChaîne,
                            ByVal _LngChI As Integer,
                            ByRef _NbrSmp As Integer,
                            ByRef _Tsmp() As Sudoku.StrSmp,
                            ByVal _Smp As Sudoku.StrSmp,
                            ByVal _c As Integer,
                            ByVal _k As Integer)

        Dim _m As String

        _m = "Double Exclusion [" & _k + 1 & "] grâce à la chaîne fortement liée : " & vbCrLf &
                            "L" & _tChaîneImpaire(0).i1 + 1 & "C" & _tChaîneImpaire(0).j1 + 1
        For _l = 0 To _LngChI
            _m = _m & "-L" & _tChaîneImpaire(_l).i2 + 1 & "C" & _tChaîneImpaire(_l).j2 + 1
        Next

        _Smp.nr = 0
        _Smp.motif = _m

        _Smp.CR.i(_Smp.nr) = _tChaîneImpaire(0).i1
        _Smp.CR.j(_Smp.nr) = _tChaîneImpaire(0).j1
        _Smp.CR.k(_Smp.nr) = _k
        _Smp.CR.v(_Smp.nr) = _k + 1
        _Smp.nr += 1

        For _l = 0 To _LngChI
            _Smp.CR.i(_Smp.nr) = _tChaîneImpaire(_l).i2
            _Smp.CR.j(_Smp.nr) = _tChaîneImpaire(_l).j2
            _Smp.CR.k(_Smp.nr) = _k
            _Smp.CR.v(_Smp.nr) = _k + 1
            _Smp.nr += 1
        Next

        If _Smp.ne > 0 Then
            _Tsmp(_NbrSmp) = _Smp
            _NbrSmp += 1
        End If

    End Sub

    '============================================================================================================================================================
    ' Techniques d'élimination de candidats
    ' Constitution d'une chaîne fortement liée 
    ' Le principe est d'explorer un arbre de factorielle ( combinaisons de _NbPai parmi _NbPai) en testant les liens à chaque niveau 
    '                                                    pour éviter d'exporer tout l'arbre 
    '============================================================================================================================================================

    Sub CréeChaîneForte(ByVal _Candidats(,,) As Integer,
                        ByVal _k As Integer,
                        ByRef _tLiens() As Sudoku.strLien,
                        ByRef _NbLiens As Integer,
                        ByRef _tChaînePaire() As Sudoku.strChaîne,
                        ByRef _LngChP As Integer,
                        ByRef _tChaîneImpaire() As Sudoku.strChaîne,
                        ByRef _LngChI As Integer,
                        ByVal _AnlLig(,) As Sudoku.StrAnalyse,
                        ByVal _AnlCol(,) As Sudoku.StrAnalyse,
                        ByVal _AnlReg(,) As Sudoku.StrAnalyse)

        'Initialisation des variables
        Dim TC() As Integer 'représente le lien - tableau statique, contient les valeurs de 1 à _NbLiens + 1
        ' remplacé par la structure du lien au moment deconstituer la chaîne
        Dim c(,) As Boolean ' tableau des liens (TC) consommés ou disponibles par niveau de récursivité et rang dans la chaîne

        Dim AF() As Integer 'Combinaison constituée des id (numéro d'ordre) des paires - vision verticale de l'arbre factoriel

        Dim n As Integer = _NbLiens
        Dim p As Integer ' p indique le niveau de la pile de récursivité - soit la longueur de la chaîne (à chaque niveau on cherche un élément de la chaine) 

        ' chaque niveau est une réplication du niveau précédent auquel on ajoute l'indice traité à ce niveau
        Dim _tChaîne(Sudoku.MaxChn) As Sudoku.strChaîne
        Dim nbIter As Integer = 0

        ReDim TC(_NbLiens)
        ReDim AF(_NbLiens)
        ReDim c(_NbLiens, _NbLiens)

        _LngChP = 0
        _LngChI = 0

        For _b = 0 To Sudoku.MaxChn
            _tChaîne(_b).nat = " "
            _tChaîne(_b).f = False
            _tChaîne(_b).i1 = 0
            _tChaîne(_b).j1 = 0
            _tChaîne(_b).r1 = 0
            _tChaîne(_b).i1 = 0
            _tChaîne(_b).i2 = 0
            _tChaîne(_b).r2 = 0
            _tChaînePaire(_b).nat = " "
            _tChaînePaire(_b).f = False
            _tChaînePaire(_b).i1 = 0
            _tChaînePaire(_b).j1 = 0
            _tChaînePaire(_b).r1 = 0
            _tChaînePaire(_b).i1 = 0
            _tChaînePaire(_b).i2 = 0
            _tChaînePaire(_b).r2 = 0
            _tChaîneImpaire(_b).nat = " "
            _tChaîneImpaire(_b).f = False
            _tChaîneImpaire(_b).i1 = 0
            _tChaîneImpaire(_b).j1 = 0
            _tChaîneImpaire(_b).r1 = 0
            _tChaîneImpaire(_b).i1 = 0
            _tChaîneImpaire(_b).i2 = 0
            _tChaîneImpaire(_b).r2 = 0
        Next

        ' préparation du parcours de l'arborescence
        For p = 0 To n
            For r = 0 To n
                c(p, r) = False
            Next
            TC(p) = p
            AF(p) = 99 'représente une valeur nulle
        Next

        p = 0 ' racine de l'arborescence

        Enchaînement(_Candidats, _k, p, n, c, AF, TC, nbIter, _tChaîne, _tChaînePaire, _LngChP, _tChaîneImpaire, _LngChI, _tLiens) 'Niveau p = 0 de récursivité


    End Sub

    '============================================================================================================================================================
    ' Exploration de l'arbre de factorielle ( combinaisons de _NbPai parmi _NbPai) en testant les liens à chaque niveau 
    '                                         pour éviter d'exporer tout l'arbre 
    '============================================================================================================================================================

    Sub Enchaînement(ByVal _Candidats As Integer(,,),
                     ByVal _k As Integer,
                     ByRef p As Integer,
                     ByRef n As Integer,
                     ByRef c(,) As Boolean,
                     ByRef AF() As Integer,
                     ByVal TC() As Integer,
                     ByRef nbiter As Integer,
                     ByRef _tChaîne() As Sudoku.strChaîne,
                     ByRef _tChaînePaire() As Sudoku.strChaîne,
                     ByRef _LngChP As Integer,
                     ByRef _tChaîneImpaire() As Sudoku.strChaîne,
                     ByRef _LngChI As Integer,
                     ByVal _tLiens() As Sudoku.strLien)

        Dim _select As Boolean
        Dim _i As Integer
        Dim _j As Integer
        Dim _c As Integer
        Dim _i0 As Integer
        Dim _ip As Integer
        Dim _j0 As Integer
        Dim _jp As Integer
        Dim _r0 As Integer
        Dim _rp As Integer
        Dim _csgi0 As Integer
        Dim _csgip As Integer
        Dim _csgj0 As Integer
        Dim _csgjp As Integer
        Dim _Intersection As Boolean = False
        'Dim _PAi1 As Integer
        'Dim _PAj1 As Integer
        'Dim _PAi2 As Integer
        'Dim _PAj2 As Integer
        'Dim _PJi1 As Integer
        'Dim _PJj1 As Integer
        'Dim _PJi2 As Integer
        'Dim _PJj2 As Integer
        Dim _C0i1 As Integer
        Dim _C0j1 As Integer
        Dim _C0r1 As Integer
        Dim _CIi2 As Integer
        Dim _CIj2 As Integer
        Dim _CIr2 As Integer

        If p > 0 Then
            For r = 0 To n 'réplication des paires utilisée sur le niveau inférieur
                c(p, r) = c(p - 1, r)
            Next
        End If

        For r = 0 To n
            If c(p, r) = False Then ' on utilise une paire disponible
                _select = True
                AF(p) = TC(r)
                'If i > 0 Then
                '    _PAi1 = _tLiens(A(i - 1)).i1
                '    _PAj1 = _tLiens(A(i - 1)).j1
                '    _PAi2 = _tLiens(A(i - 1)).i2
                '    _PAj2 = _tLiens(A(i - 1)).j2
                '    _PJi1 = _tLiens(P(j)).i1
                '    _PJj1 = _tLiens(P(j)).j1
                '    _PJi2 = _tLiens(P(j)).i2
                '    _PJj2 = _tLiens(P(j)).j2
                'End If

                If p = 1 Then
                    ' Amorçage de la chaîne - on utilise les paires identifiées par les numéros d'ordre dans A qui représentent la combinaison courante
                    If (_tLiens(AF(p - 1)).i2 = _tLiens(TC(r)).i1) And (_tLiens(AF(p - 1)).j2 = _tLiens(TC(r)).j1) _
                        And (_tLiens(AF(p - 1)).i1 <> _tLiens(TC(r)).i2) And (_tLiens(AF(p - 1)).j1 <> _tLiens(TC(r)).j2) Then   'pour ne pas enchaîner sur la paire symétrique
                        _tChaîne(0).nat = _tLiens(AF(1)).nat
                        _tChaîne(0).f = _tLiens(AF(0)).f
                        _tChaîne(0).i1 = _tLiens(AF(0)).i1
                        _tChaîne(0).j1 = _tLiens(AF(0)).j1
                        _tChaîne(0).r1 = _tLiens(AF(0)).r1
                        _tChaîne(0).i2 = _tLiens(AF(0)).i2
                        _tChaîne(0).j2 = _tLiens(AF(0)).j2
                        _tChaîne(0).r2 = _tLiens(AF(0)).r2
                        _tChaîne(p).nat = _tLiens(TC(r)).nat
                        _tChaîne(p).f = _tLiens(TC(r)).f
                        _tChaîne(p).i1 = _tLiens(TC(r)).i1
                        _tChaîne(p).j1 = _tLiens(TC(r)).j1
                        _tChaîne(p).r1 = _tLiens(TC(r)).r1
                        _tChaîne(p).i2 = _tLiens(TC(r)).i2
                        _tChaîne(p).j2 = _tLiens(TC(r)).j2
                        _tChaîne(p).r2 = _tLiens(TC(r)).r2
                    Else
                        _select = False
                    End If
                End If

                If p > 1 Then
                    ' Suite de la chaîne
                    If (_tLiens(AF(p - 1)).i2 = _tLiens(TC(r)).i1) And (_tLiens(AF(p - 1)).j2 = _tLiens(TC(r)).j1) Then
                        For b = 0 To p - 1
                            If (_tLiens(AF(b)).i1 = _tLiens(TC(r)).i2) And (_tLiens(AF(b)).j1 = _tLiens(TC(r)).j2) Then
                                ' pour ne pas générer de boucle
                                _select = False
                            End If
                        Next
                        If _select Then
                            _tChaîne(p).nat = _tLiens(TC(r)).nat
                            _tChaîne(p).f = _tLiens(TC(r)).f
                            _tChaîne(p).i1 = _tLiens(TC(r)).i1
                            _tChaîne(p).j1 = _tLiens(TC(r)).j1
                            _tChaîne(p).r1 = _tLiens(TC(r)).r1
                            _tChaîne(p).i2 = _tLiens(TC(r)).i2
                            _tChaîne(p).j2 = _tLiens(TC(r)).j2
                            _tChaîne(p).r2 = _tLiens(TC(r)).r2
                        End If
                    Else
                        _select = False
                    End If
                End If

                If _select = True Then
                    ' On descend d'un niveau
                    c(p, r) = True
                    If p < n Then
                        p += 1
                        'Niveau p de récursivité
                        Enchaînement(_Candidats, _k, p, n, c, AF, TC, nbiter, _tChaîne, _tChaînePaire, _LngChP, _tChaîneImpaire, _LngChI, _tLiens)
                        c(p, r) = False
                    End If
                End If

            End If
            nbiter += 1 ' pour connaître la charge de travail
        Next

        For j = 0 To n
            c(p, j) = False ' on nettoie le tableau au niveau i avant de remonter d'un niveau
        Next
        AF(p) = 99
        p -= 1

        If p > 1 Then ' on enregistre une chaîne qui a atteint une longueur de 3 ou plus 
            ' test d'un lien faible pur boucler la chaîne
            _C0i1 = _tChaîne(0).i1
            _C0j1 = _tChaîne(0).j1
            _C0r1 = _tChaîne(0).r1
            _CIi2 = _tChaîne(p).i2
            _CIj2 = _tChaîne(p).j2
            _CIr2 = _tChaîne(p).r2

            If p Mod 2 = 1 Then ' une chaîne paire (nombre impair base 0) génère une contradiction
                If (_tChaîne(0).i1 = _tChaîne(p).i2) Or (_tChaîne(0).j1 = _tChaîne(p).j2) Or (_tChaîne(0).r1 = _tChaîne(p).r2) Then
                    'on a un maillon faible pour boucler la chaîne fortement liée
                    If _LngChP < p Then
                        _LngChP = p
                        For t = 0 To p
                            _tChaînePaire(t).nat = _tChaîne(t).nat
                            _tChaînePaire(t).f = _tChaîne(t).f
                            _tChaînePaire(t).i1 = _tChaîne(t).i1
                            _tChaînePaire(t).j1 = _tChaîne(t).j1
                            _tChaînePaire(t).r1 = _tChaîne(t).r1
                            _tChaînePaire(t).i2 = _tChaîne(t).i2
                            _tChaînePaire(t).j2 = _tChaîne(t).j2
                            _tChaînePaire(t).r2 = _tChaîne(t).r2
                        Next
                    End If
                End If

            Else
                ' une chaîne impaire (nombre pair base 0) est candidate pour une double exclusion

                ' coordonnées début de chaîne
                _i0 = _tChaîne(0).i1
                _j0 = _tChaîne(0).j1
                _r0 = _tChaîne(0).r1
                ' coordonnées fin de chaîne
                _ip = _tChaîne(p).i2
                _jp = _tChaîne(p).j2
                _rp = _tChaîne(p).r2
                _csgi0 = (_r0 \ 3) * 3
                _csgj0 = (_r0 - _csgi0) * 3
                _csgip = (_rp \ 3) * 3
                _csgjp = (_rp - _csgip) * 3

                ' test d'une intersection ligne colonne
                If (_i0 <> _ip And _j0 <> _jp) Then ' ni sur la même ligne ni sur la même colonne
                    If _Candidats(_i0, _jp, _k) = _k + 1 Then
                        _Intersection = True
                    End If
                    If _Candidats(_ip, _j0, _k) = _k + 1 Then
                        _Intersection = True
                    End If
                End If

                If (_r0 <> _rp) Then ' pas dans la même région

                    ' test d'une intersection ligne région
                    If (_i0 <> _ip) Then ' pas sur la la même ligne
                        If (_i0 >= _csgip) And (_i0 <= _csgip + 2) Then ' mais une ligne commune avec la région
                            If (_Candidats(_i0, _csgjp, _k) = _k + 1) Or (_Candidats(_i0, _csgjp + 1, _k) = _k + 1) Or (_Candidats(_i0, _csgjp + 2, _k) = _k + 1) Then
                                _Intersection = True
                            End If
                        End If
                        If (_ip >= _csgi0) And (_ip <= _csgi0 + 2) Then ' mais une ligne commune avec la région
                            If (_Candidats(_ip, _csgj0, _k) = _k + 1) Or (_Candidats(_ip, _csgj0 + 1, _k) = _k + 1) Or (_Candidats(_ip, _csgj0 + 2, _k) = _k + 1) Then
                            End If
                        End If
                    End If

                    ' test d'une intersection colonne région
                    If (_j0 <> _jp) Then ' pas sur la la même colonne
                        If (_j0 >= _csgjp) And (_j0 <= _csgjp + 2) Then ' mais une colonne commune avec la région
                            If (_Candidats(_csgip, _j0, _k) = _k + 1) Or (_Candidats(_csgip + 1, _j0, _k) = _k + 1) Or (_Candidats(_csgip + 2, _j0, _k) = _k + 1) Then
                                _Intersection = True
                            End If
                        End If
                        If (_jp >= _csgj0) And (_jp <= _csgj0 + 2) Then ' mais une colonne commune avec la région
                            If (_Candidats(_csgi0, _jp, _k) = _k + 1) Or (_Candidats(_csgi0 + 1, _jp, _k) = _k + 1) Or (_Candidats(_csgi0 + 2, _jp, _k) = _k + 1) Then
                                _Intersection = True
                            End If
                        End If
                    End If
                End If

                If _Intersection Then
                    If _LngChI = 0 Or _LngChI > p Then
                        _LngChI = p
                        For t = 0 To p
                            _tChaîneImpaire(t).nat = _tChaîne(t).nat
                            _tChaîneImpaire(t).f = _tChaîne(t).f
                            _tChaîneImpaire(t).i1 = _tChaîne(t).i1
                            _tChaîneImpaire(t).j1 = _tChaîne(t).j1
                            _tChaîneImpaire(t).r1 = _tChaîne(t).r1
                            _tChaîneImpaire(t).i2 = _tChaîne(t).i2
                            _tChaîneImpaire(t).j2 = _tChaîne(t).j2
                            _tChaîneImpaire(t).r2 = _tChaîne(t).r2
                        Next
                    End If
                End If

            End If
        End If
        'On prépare la tentative de chaîne suivante
        _tChaîne(p + 1).nat = " "
        _tChaîne(p + 1).f = False
        _tChaîne(p + 1).i1 = 0
        _tChaîne(p + 1).j1 = 0
        _tChaîne(p + 1).r1 = 0
        _tChaîne(p + 1).i2 = 0
        _tChaîne(p + 1).j2 = 0
        _tChaîne(p + 1).r2 = 0
    End Sub

    '============================================================================================================================================================
    ' Techniques d'élimination de candidats
    ' Collecte des liens de k comme éléments de base d'une chaïne
    '============================================================================================================================================================

    Sub CollecteLiens(ByRef _Candidats(,,) As Integer,
                       ByRef _tLiens() As Sudoku.strLien,
                       ByRef _NbLiens As Integer,
                       ByVal _AnlLig(,) As Sudoku.StrAnalyse,
                       ByVal _AnlCol(,) As Sudoku.StrAnalyse,
                       ByVal _AnlReg(,) As Sudoku.StrAnalyse,
                       ByVal _k As Integer)

        Dim _p As Integer
        Dim _csgi As Integer 'Coin supérieur gauche région
        Dim _csgj As Integer 'Coin supérieur gauche région
        Dim _g As Integer
        Dim _gbis As Integer

        For _p = 0 To Sudoku.MaxLiens
            _tLiens(_p).nat = " "
            _tLiens(_p).i1 = 0
            _tLiens(_p).j1 = 0
            _tLiens(_p).i1 = 0
            _tLiens(_p).j1 = 0
        Next

        _p = 0
        ' liens en ligne
        For _i = 0 To 8
            If _AnlLig(_i, _k).n = 2 Then
                For _j = 0 To 7
                    If _Candidats(_i, _j, _k) = _k + 1 Then
                        _tLiens(_p).i1 = _i
                        _tLiens(_p).j1 = _j
                        _tLiens(_p).r1 = ((_i \ 3) * 3) + (_j \ 3)
                        For _jbis = _j + 1 To 8
                            If _Candidats(_i, _jbis, _k) = _k + 1 Then
                                _tLiens(_p).i2 = _i
                                _tLiens(_p).j2 = _jbis
                                _tLiens(_p).r2 = ((_i \ 3) * 3) + (_jbis \ 3)
                                _tLiens(_p).nat = "L"
                                _p += 1
                                _tLiens(_p).i1 = _tLiens(_p - 1).i2
                                _tLiens(_p).j1 = _tLiens(_p - 1).j2
                                _tLiens(_p).r1 = _tLiens(_p - 1).r2
                                _tLiens(_p).i2 = _tLiens(_p - 1).i1
                                _tLiens(_p).j2 = _tLiens(_p - 1).j1
                                _tLiens(_p).r2 = _tLiens(_p - 1).r1
                                _tLiens(_p).nat = _tLiens(_p - 1).nat
                                _tLiens(_p).f = True
                                _p += 1
                            End If
                        Next
                    End If
                Next
            End If
        Next
        ' liens en colonne
        For _j = 0 To 8
            If _AnlCol(_j, _k).n = 2 Then
                For _i = 0 To 7
                    If _Candidats(_i, _j, _k) = _k + 1 Then
                        _tLiens(_p).i1 = _i
                        _tLiens(_p).j1 = _j
                        _tLiens(_p).r1 = ((_i \ 3) * 3) + (_j \ 3)
                        For _ibis = _i + 1 To 8
                            If _Candidats(_ibis, _j, _k) = _k + 1 Then
                                _tLiens(_p).i2 = _ibis
                                _tLiens(_p).j2 = _j
                                _tLiens(_p).r2 = ((_ibis \ 3) * 3) + (_j \ 3)
                                _tLiens(_p).nat = "C"
                                _p += 1
                                _tLiens(_p).i1 = _tLiens(_p - 1).i2
                                _tLiens(_p).j1 = _tLiens(_p - 1).j2
                                _tLiens(_p).r1 = _tLiens(_p - 1).r2
                                _tLiens(_p).i2 = _tLiens(_p - 1).i1
                                _tLiens(_p).j2 = _tLiens(_p - 1).j1
                                _tLiens(_p).r2 = _tLiens(_p - 1).r1
                                _tLiens(_p).nat = _tLiens(_p - 1).nat
                                _tLiens(_p).f = True
                                _p += 1
                            End If
                        Next
                    End If
                Next

            End If
        Next
        ' liens en régions
        For _r = 0 To 8
            _csgi = (_r \ 3) * 3
            _csgj = (_r - _csgi) * 3
            If _AnlReg(_r, _k).n = 2 Then
                For _i = _csgi To _csgi + 2 'parcours de l'élément 1
                    For _j = _csgj To _csgj + 2 'parcours de l'élément 1
                        If _Candidats(_i, _j, _k) = _k + 1 Then
                            _tLiens(_p).i1 = _i
                            _tLiens(_p).j1 = _j
                            _tLiens(_p).r1 = ((_i \ 3) * 3) + (_j \ 3)
                            For _ibis = _csgi To _csgi + 2 'parcours de l'élément 2
                                For _jbis = _csgj To _csgj + 2 'parcours de l'élément 2
                                    _g = (_i * 3) + _j
                                    _gbis = (_ibis * 3) + _jbis
                                    If _g < _gbis Then ' on ne cherche que dans un sens (élément 2 tjrs > élément 1) 
                                        If _Candidats(_ibis, _jbis, _k) = _k + 1 Then
                                            If _i <> _ibis And _j <> _jbis Then ' Pour ne pas reprendre des paires en ligne ou en colonne
                                                _tLiens(_p).i2 = _ibis
                                                _tLiens(_p).j2 = _jbis
                                                _tLiens(_p).r2 = ((_ibis \ 3) * 3) + (_jbis \ 3)
                                                _tLiens(_p).nat = "R"
                                                _tLiens(_p).f = True
                                                _p += 1
                                                _tLiens(_p).i1 = _tLiens(_p - 1).i2
                                                _tLiens(_p).j1 = _tLiens(_p - 1).j2
                                                _tLiens(_p).r1 = _tLiens(_p - 1).r2
                                                _tLiens(_p).i2 = _tLiens(_p - 1).i1
                                                _tLiens(_p).j2 = _tLiens(_p - 1).j1
                                                _tLiens(_p).r2 = _tLiens(_p - 1).r1
                                                _tLiens(_p).nat = _tLiens(_p - 1).nat
                                                _tLiens(_p).f = True
                                                _p += 1
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

        _NbLiens = _p - 1

    End Sub

End Module
