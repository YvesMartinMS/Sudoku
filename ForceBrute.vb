Imports System.IO
Module ForceBrute
    Sub ForceBrute(ByRef Grille(,) As Integer,
                   ByRef nbSol As Integer,
                   ByRef nbrLoop As Integer)

        Dim Erreur As Boolean
        Dim i As Integer
        Dim j As Integer
        Dim r As Integer
        Dim s As Integer
        Dim smax As Integer
        Dim c(80) As Integer
        Dim Candidats(8, 8, 8) As Integer
        Dim seqCandidats(80, 8) As Integer
        Dim seqi(80) As Integer
        Dim seqj(80) As Integer
        Dim nbrc(80) As Integer
        Dim GrilleFinale(8, 8) As Integer

        nbSol = 0

        For i = 0 To 8
            For j = 0 To 8
                For k = 0 To 8
                    Candidats(i, j, k) = 0
                Next
            Next
        Next

        CalculCandidats(Grille, Candidats) 'Calcul candidat initial

        For i = 0 To 8
            For j = 0 To 8
                If Grille(i, j) = "0" Then
                    seqi(s) = i
                    seqj(s) = j
                    c(s) = 0
                    For k = 0 To 8
                        If Candidats(i, j, k) <> 0 Then
                            seqCandidats(s, c(s)) = Candidats(i, j, k)
                            nbrc(s) = c(s)
                            c(s) += 1
                        End If
                    Next
                    s += 1
                End If
            Next
        Next
        smax = s - 1
        s = 0

        c(0) = 0
        If smax < 0 Then ' au cas où on charge une grille pleine
            nbSol = 1
        Else
            While nbSol < 2

                nbrLoop += 1
                i = seqi(s)
                j = seqj(s)
                Grille(i, j) = seqCandidats(s, c(s))

                Erreur = False
                '  Recherche d'erreurs sur les colonnes
                ControleLigneBF(Erreur, Grille, i)
                If Not Erreur Then
                    ' Recherche d'erreurs sur les colonnes
                    ControleColonneBF(Erreur, Grille, j)
                End If
                If Not Erreur Then
                    ' Recherche d'erreurs sur les régions
                    r = ((i \ 3) * 3) + (j \ 3)  ' calcule la région d'après i et j
                    ControleRégionBF(Erreur, Grille, r)
                End If

                If Not Erreur Then
                    If s = smax Then
                        ' Grille Complète
                        nbSol += 1
                        If nbSol > 1 Then
                            Exit While
                        End If
                        Array.Copy(Grille, GrilleFinale, 81)
                        'On recule d'une ou plusieurs cases pour chercher s'il y a plusieurs solutions
                        While c(s) = nbrc(s) And s > 0
                            c(s) = 0
                            Grille(i, j) = "0"
                            s -= 1
                            i = seqi(s)
                            j = seqj(s)
                        End While
                        ' Candidat suivant dans la case précédente
                        c(s) += 1
                    Else
                        ' On vient de placer un candidat, on va à la case libre suivante
                        s += 1
                        c(s) = 0
                    End If
                Else
                    If c(s) < nbrc(s) Then
                        ' Candidat suivant dans la même case
                        c(s) += 1
                    Else
                        'On recule jusqu'à une case où il y a encore un candidat à essayer
                        While c(s) = nbrc(s) And s > 0
                            c(s) = 0
                            Grille(i, j) = "0"
                            s -= 1
                            i = seqi(s)
                            j = seqj(s)
                        End While
                        ' Candidat suivant dans la case précédente
                        c(s) += 1
                    End If
                End If

                If c(0) > nbrc(0) Then
                    Exit While
                End If

            End While
        End If

        Array.Copy(GrilleFinale, Grille, 81)

    End Sub

    '============================================================================================================================================================
    '  Contrôle les doublons d'une ligne
    '============================================================================================================================================================

    Sub ControleLigneBF(ByRef _Erreur As Boolean,
                      ByRef _Grille(,) As Integer,
                      ByVal _i As Integer)

        For _j = 0 To 7
            For _jbis = _j + 1 To 8
                If _Grille(_i, _j) = _Grille(_i, _jbis) And _Grille(_i, _j) <> 0 Then
                    _Erreur = True
                End If
            Next
        Next

    End Sub

    '============================================================================================================================================================
    '  Contrôle les doublons d'une colonne
    '============================================================================================================================================================

    Sub ControleColonneBF(ByRef _Erreur As Boolean,
                        ByRef _Grille(,) As Integer,
                        ByVal _j As Integer)

        For _i = 0 To 7
            For _ibis = _i + 1 To 8
                If _Grille(_i, _j) = _Grille(_ibis, _j) And _Grille(_i, _j) <> 0 Then
                    _Erreur = True
                End If
            Next
        Next

    End Sub

    '============================================================================================================================================================
    '  Contrôle les doublons d'une région
    '============================================================================================================================================================

    Sub ControleRégionBF(ByRef _Erreur As Boolean,
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
                            If _Grille(_i, _j) = _Grille(_ibis, _jbis) And _Grille(_i, _j) <> 0 Then
                                _Erreur = True
                            End If
                        End If
                    Next
                Next
            Next
        Next

    End Sub

    Sub EcrireSolution(ByRef grille(,) As String, ByVal nbSol As Integer)

        Dim TextSudoku As String = ""
        Dim myFileNname As String
        Dim myFileNname1 As String = "E:\Sudoku3D\FoceBrute"
        Dim myFileNname2 As String = ".sud"
        Dim fichierCorrrect As Boolean


        myFileNname = myFileNname1 & nbSol & myFileNname2

        For i = 0 To 8
            For j = 0 To 8
                If grille(i, j) = "0" Then
                    TextSudoku &= "."
                Else
                    TextSudoku &= grille(i, j)
                End If
            Next
            TextSudoku &= vbCrLf
        Next

        Try
            File.WriteAllText(myFileNname, TextSudoku)
        Catch ex As Exception
            fichierCorrrect = False
        Finally
            fichierCorrrect = True
        End Try

    End Sub
End Module
