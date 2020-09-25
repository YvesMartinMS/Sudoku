Imports System.IO
Module ForceBrute
    Sub ForceBrute(ByRef Grille(,) As Integer,
                   ByRef nbSol As Integer,
                   ByRef nbLoop As Integer,
                   ByRef NbAppel As Integer)

        Dim i As Integer
        Dim j As Integer
        Dim l As Integer 'niveau de récursivité
        Dim lmax As Integer
        Dim nbc As Integer
        Dim r(Sudoku.ProfondeurPile) As Integer 'indice candidat à chaque niveau
        Dim Candidats(8, 8, 8) As Integer
        Dim seqCandidats(Sudoku.ProfondeurPile, 8) As Integer 'tableau des candidats sur 2 dimensions
        Dim seqi(Sudoku.ProfondeurPile) As Integer 'tableau des i à chaque niveau l
        Dim seqj(Sudoku.ProfondeurPile) As Integer 'tableau des j à chaque niveau l
        Dim nbrc(Sudoku.ProfondeurPile) As Integer 'nombre de candidats à chaque niveau l
        Dim nbrd(Sudoku.ProfondeurPile) As Integer
        Dim GrilleFinale(8, 8) As Integer
        Dim T1SW As New Stopwatch
        Dim T2SW As New Stopwatch
        Dim T1 As String
        Dim T2 As String
        nbSol = 0
        nbLoop = 0

        T1SW.Start()
        For i = 0 To 8
            For j = 0 To 8
                For k = 0 To 8
                    Candidats(i, j, k) = 0
                Next
            Next
        Next

        CalculCandidats(Grille, Candidats) 'Calcul candidat initial
        l = 0
        ' Création du tableau des candidats
        For i = 0 To 8
            For j = 0 To 8
                If Grille(i, j) = "0" Then
                    seqi(l) = i
                    seqj(l) = j
                    r(l) = 0
                    For k = 0 To 8
                        If Candidats(i, j, k) <> 0 Then
                            seqCandidats(l, r(l)) = Candidats(i, j, k)
                            nbrc(l) = r(l)
                            r(l) += 1
                            nbc += 1
                        End If
                    Next
                    l += 1
                End If
            Next
        Next

        lmax = l - 1
        l = 0

        If lmax < 0 Then ' au cas où on charge une grille pleine
            nbSol = 1
        Else
            AvanceUneCase(l, lmax, seqi, seqj, seqCandidats, Grille, GrilleFinale, nbrc, nbrd, nbSol, nbLoop, T2SW)
        End If

        T1SW.Stop()
        T1 = T1SW.ElapsedMilliseconds.ToString & " milliseconde(s)"
        T2 = T2SW.ElapsedMilliseconds.ToString & " milliseconde(s)"

        If nbSol > 0 Then
            Array.Copy(GrilleFinale, Grille, 81)
        End If

    End Sub

    '============================================================================================================================================================
    '  Teste les possiblités de la case suivante <=> Descend d'un niveau dans la pile
    '============================================================================================================================================================

    Sub AvanceUneCase(ByRef l As Integer,
                      ByRef lmax As Integer,
                      ByRef seqi() As Integer,
                      ByRef seqj() As Integer,
                      ByRef seqCandidats(,) As Integer,
                      ByRef Grille(,) As Integer,
                      ByRef GrilleFinale(,) As Integer,
                      ByRef nbrc() As Integer,
                      ByRef nbrd() As Integer,
                      ByRef nbSol As Integer,
                      ByRef nbLoop As Integer,
                      ByRef T2SW As Stopwatch
                      )
        Dim i As Integer
        Dim j As Integer
        Dim BreakLoop As Integer
        Dim Erreur As Boolean

        i = seqi(l)
        j = seqj(l)
        For r = 0 To nbrc(l)
            nbLoop += 1
            BreakLoop = nbLoop Mod 100000
            If BreakLoop = 0 Then
                BreakLoop += 0
            End If

            Grille(i, j) = seqCandidats(l, r)
            nbrd(l) = r

            T2SW.Start()
            Erreur = False
            '  Recherche d'erreurs sur les lignes

            ControleFB(Erreur, Grille, i, j, Grille(i, j))

            T2SW.Stop()

            If Not Erreur Then 'Le candidat est possible
                If l = lmax Then
                    ' Grille Complète
                    nbSol += 1
                    If nbSol = 1 Then
                        Array.Copy(Grille, GrilleFinale, 81)
                    End If
                Else
                    ' On vient de placer un candidat, on essaie les candidats de la case libre suivante
                    l += 1
                    AvanceUneCase(l, lmax, seqi, seqj, seqCandidats, Grille, GrilleFinale, nbrc, nbrd, nbSol, nbLoop, T2SW)
                End If
            End If
            If nbSol > 1 Then
                Exit For
            End If
        Next
        Grille(i, j) = 0
        nbrd(l) = 0
        l -= 1

    End Sub

    '============================================================================================================================================================
    '  Contrôle les doublons d'une ligne
    '============================================================================================================================================================

    Sub ControleFB(ByRef _Erreur As Boolean,
                        ByRef _Grille(,) As Integer,
                        ByVal _i As Integer,
                        ByVal _j As Integer,
                        ByVal _k As Integer)

        Dim _csgi As Integer 'Coin supérieur gauche région
        Dim _csgj As Integer 'Coin supérieur gauche région
        Dim _r As Integer 'Région
        _Erreur = False

        For _jbis = 0 To 8
            If _jbis <> _j Then
                If _Grille(_i, _j) = _Grille(_i, _jbis) And _Grille(_i, _j) <> 0 Then
                    _Erreur = True
                End If
            End If
        Next

        If Not _Erreur Then
            For _ibis = 0 To 8
                If _ibis <> _i Then
                    If _Grille(_i, _j) = _Grille(_ibis, _j) And _Grille(_i, _j) <> 0 Then
                        _Erreur = True
                    End If
                End If
            Next
        End If

        If Not _Erreur Then
            _r = ((_i \ 3) * 3) + (_j \ 3)  ' calcule la région d'après i et j
            _csgi = (_r \ 3) * 3 'coin supérieur gauche région
            _csgj = (_r - _csgi) * 3 'coin supérieur gauche région

            For _ibis = _csgi To _csgi + 2
                For _jbis = _csgj To _csgj + 2
                    If _i <> _ibis Or _j <> _jbis Then
                        If _Grille(_i, _j) = _Grille(_ibis, _jbis) And _Grille(_i, _j) <> 0 Then
                            _Erreur = True
                        End If
                    End If
                Next
            Next
        End If
    End Sub



End Module
