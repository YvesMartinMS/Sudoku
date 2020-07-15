Imports System.IO
Module Générateur

    Function Générateur(ByVal typeGrille As String)
        Const PATHFICHIER As String = "Sudoku.txt"
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim k As Integer = 0
        Dim g As Integer = 0
        Dim h As Integer = 0
        Dim r As Integer = 0
        Dim s As Integer = 0
        Dim z As String = 0

        Dim Grille(8, 8) As String ' La grille de Sudoku
        Dim Candidats(8, 8, 8) As String ' La grille des candidats ( Valeurs au crayon)
        Dim NbVal As Integer = 0

        Dim cpk(8, 8) As Integer ' Candidats par case
        Dim cpl(8, 8) As Integer ' Candidats par ligne
        Dim cpli(8, 8) As Integer
        Dim cplj(8, 8) As Integer
        Dim cplk(8, 8) As Integer
        Dim cpc(8, 8) As Integer ' Candidats par colonne
        Dim cpci(8, 8) As Integer
        Dim cpcj(8, 8) As Integer
        Dim cpck(8, 8) As Integer
        Dim cpr(8, 8) As Integer ' Candidats par région
        Dim cpri(8, 8) As Integer
        Dim cprj(8, 8) As Integer
        Dim cprk(8, 8) As Integer

        Dim Segment(8) As String
        Dim _ErreurSegment(8) As String
        Dim SegmentCandidats(8, 8) As String

        Dim Erreur As Boolean
        Dim ErreurGrille(8, 8) As String


        Dim GTabSolution(80) As Sudoku.Solution
        Dim GNbSol As Integer = 0 'Nombre solutions en réserve
        Dim TextSudoku As String = "                                                                                 "
        ' Dim TextSudoku As String = "123456789012345678901234567890123456789012345678901234567890123456789012345678901"

        Dim ModeDebug As Boolean = False

        Dim f As Integer = 0
        Dim it As String
        Dim jt As String
        Dim pil(3) As String
        Dim pili As String = "                                                                                 "
        Dim pilj As String = "                                                                                 "
        Dim pilv As String = "                                                                                 "
        Dim pilr As String = "                                                                                 "
        Dim TS As String

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

        For i = 0 To 8
            For j = 0 To 8
                Grille(i, j) = "0"
            Next
        Next

        initialisations(Grille, Candidats, cpk, cpl, cpc, cpr)

        'While NbVal < 80 And Not Erreur
        While NbVal < 80 And Not Erreur

            ' choisit une case au hasard parmi celles qui sont libres
            If GNbSol = 0 Then

                ChoisitCase(Grille, NbVal, i, j)
                If ModeDebug Then
                    it = pili(NbVal)
                    i = CInt(it)
                    jt = pilj(NbVal)
                    j = CInt(jt)
                End If
                généCase(Grille, Candidats, i, j, NbVal, TextSudoku, pili, pilj, pilv, pilr, ModeDebug)
                Recalcul_Candidats(i, j, Grille, Candidats) ' Retire la valeur saisie des groupes auxquels la case appartient 
                ControleGénération(Erreur, ErreurGrille, Grille, Candidats)
                If typeGrille = "Sym" Then
                    If i <> 4 Or j <> 4 Then
                        i = 8 - i
                        j = 8 - j
                        généCase(Grille, Candidats, i, j, NbVal, TextSudoku, pili, pilj, pilv, pilr, ModeDebug)
                        Recalcul_Candidats(i, j, Grille, Candidats) ' Retire la valeur saisie des groupes auxquels la case appartient 
                        ControleGénération(Erreur, ErreurGrille, Grille, Candidats)
                    End If
                End If

            End If

            If NbVal > 25 Then

                GNbSol = 0

                Calcul_Candidats(Grille, Segment, Candidats, SegmentCandidats, cpk, cpl, cpli, cplj, cplk, cpc, cpci, cpcj, cpck, cpr, cpri, cprj, cprk, GTabSolution, GNbSol)

                If GNbSol > 0 Then

                    i = GTabSolution(0).i
                    j = GTabSolution(0).j
                    Grille(i, j) = GTabSolution(0).k
                    z = GTabSolution(0).k
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
                    Recalcul_Candidats(i, j, Grille, Candidats) ' Retire la valeur saisie des groupes auxquels la case appartient
                    ControleGénération(Erreur, ErreurGrille, Grille, Candidats)
                    SupprSolution(GTabSolution, GNbSol)
                    NbVal += 1
                    Exit While  ' pour test provoque la sortie à la premiere solution calculée 
                End If
            End If

        End While

        If ModeDebug Then
        Else
            File.AppendAllText(PATHFICHIER, pili & Chr(13))
            File.AppendAllText(PATHFICHIER, pilj & Chr(13))
            File.AppendAllText(PATHFICHIER, pilv & Chr(13))
            File.AppendAllText(PATHFICHIER, pilr & Chr(13))
        End If
        Return TextSudoku

    End Function

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

    ' Sub généCase(ByRef Grille(,) As String, ByRef Candidats(,,) As String, i As Integer, j As Integer, ByRef NbVal As Integer, ByRef TextSudoku As String)
    Sub généCase(ByRef Grille(,) As String, ByRef Candidats(,,) As String, i As Integer, j As Integer, ByRef NbVal As Integer, ByRef TextSudoku As String, ByRef pili As String, ByRef pilj As String, ByRef pilv As String, ByRef pilr As String, ByVal ModeDebug As Boolean)

        Dim k As Integer = 0
        Dim g As Integer = 0
        Dim r As Integer = 0
        Dim c As Integer = 0

        Dim iRandom As Integer
        Dim NombreCandidats As Integer
        Dim CompteurCandidat As Integer
        Dim ConvertIrnd As String
        Dim TS As String

        Dim attribué As Boolean


        NombreCandidats = 0
        For k = 0 To 8
            If Candidats(i, j, k) <> " " Then
                NombreCandidats += 1
            End If
        Next

        iRandom = GetRandom(0, NombreCandidats)

        If ModeDebug Then
            ConvertIrnd = pilr(NbVal)
            iRandom = CInt(ConvertIrnd)
        End If
        CompteurCandidat = 0
        attribué = False
        For k = 0 To 8
            If Candidats(i, j, k) <> " " Then
                If CompteurCandidat = iRandom Then
                    Grille(i, j) = Candidats(i, j, k)
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
                    attribué = True
                End If
                CompteurCandidat += 1
            End If
        Next

    End Sub

    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        ' by making Generator static, we preserve the same instance '
        ' (i.e., do not create new instances with the same seed over and over) '
        ' between calls '
        Static Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function
End Module
