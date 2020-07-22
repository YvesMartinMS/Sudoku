﻿Public Class Sudoku

#Region " Déclarations"

    '============================================================================================================================================================
    '                                                             D E C L A R A T I O N S  
    '============================================================================================================================================================

    Dim TB(8, 8) As TextBox
    Dim TBini(8, 8) As TextBox
    Dim i As Integer = 0
    Dim j As Integer = 0
    Dim k As Integer = 0
    Dim g As Integer = 0

    Dim Grille(8, 8) As String ' La grille de Sudoku
    Dim opk(8, 8) As Integer ' Occurrences de k par case
    Dim nuplet(8, 8) As String 'Candidats agrégés

    Dim Candidats(8, 8, 8) As String ' La grille des candidats ( Valeurs au crayon)
    Dim NbVal As Integer = 0

    Structure StrAnalyse
        Dim n As Integer ' occurrences par case
        Dim i As Integer
        Dim j As Integer
        Dim k As Integer
        Dim v As String
    End Structure

    Structure StrSolution
        Dim i As Integer
        Dim j As Integer
        Dim v As String 'Valeur
        Dim m As String 'Motif
    End Structure

    Structure StrSimplification
        Dim n As Integer
        Dim i() As Integer
        Dim j() As Integer
        Dim k() As Integer
        Dim v() As String 'Valeur
        Dim m As String 'Motif
        Dim act As Boolean
    End Structure

    Structure Contexte
        Dim NbVal As Integer
        Dim i As Integer
        Dim j As Integer
        Dim v As Integer
        Dim Grille(,) As String ' La grille de Sudoku
        Dim Candidats(,,) As String ' La grille des candidats ( Valeurs au crayon)
    End Structure

    Dim Erreur As Boolean
    Dim ErreurGrille(8, 8) As String
    Dim SegmentCandidats(8, 8) As String

    Public TabSolution(80) As Sudoku.StrSolution
    Public NbSol As Integer = 0 'Nombre solutions en réserve

    Public Simplification(20) As Sudoku.StrSimplification
    Public NbSmp As Integer = 0 'Nombre de simplifications en réserve

    Public Val As String() = {"1", "2", "3", "4", "5", "6", "7", "8", "9"}

    ' Dim MyFont As Font = New Font("Arial", 12, FontStyle.Regular)
    Dim MyFont As Font = New Font("Courier New", 6, FontStyle.Regular)

    Dim msg As String
    Dim Mode As String = "Géné"
    Dim typeGrille As String = "Sym"
    ' Grilles pour le dev
    Dim sudo_Modèle As String = "8 1    45      7 6 56   8   9 7  1      8       2  538    4  8 427    1     9   4" 'Grille modèle
    Dim sudoTestLig As String = "8 11   45      7 6 56   8   9 7  1  8   8       2  538    4  8 427    1     9   4"
    Dim sudoTestCol As String = "8 1    45      7 6 56   8   9 7  1      8       2  538    4  8 427    1     9   4"
    Dim sudoTestReg As String = "8 1    45      7 6 56   8   9 7  1      8       2  538    4  81427    1     9   4"
    Dim sudoDifficile As String = " 9 8 2     79  1 36   7 5   7    9 2         9 3    6   6 1   42 8  43     2 6 7 "
    Dim SudopairLig As String = "   3    1 13 8 97  6 17    7 9    1     4     8    4 2    93 2  91 2 78 2    5   "
    Dim SudopairCol As String = " 132    6 52  97    7 61      91  3    7 8    8  23      19 4    48  67 9    751 "
    Dim SodiCVL1___ As String = "    1  8 1 4   2    97 4    78 9 3  3       2  2 6 84    1 86    5   1 3 1  7    "
    Dim jauge______ As String = "123456789123456789123456789123456789123456789123456789123456789123456789123456789"
    Dim TextSudoku As String = "                                                                                 "


#End Region
    '============================================================================================================================================================
    '                                                             L O A D E R 
    '============================================================================================================================================================
    '
    ' Fabrication de la grille qui peut être
    '    - un cas de test en mémoire
    '    - de la saise (à developper)
    '    - une grille générée

    Private Sub Sudoku_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        InitTB()
        For i = 0 To 8
            For j = 0 To 8
                TBini(i, j) = TB(i, j)
            Next
        Next
        Mode = "Test"
        Select Case Mode
            Case "Test"
                TextSudoku = sudo_Modèle
                TextSudoku = Sudopairlig
                InitTest()
                Initialisations(Grille, Candidats)
                Contrôle_Saisie()
            Case "Géné"
                Générateur.Générateur(typeGrille, TextSudoku)
                InitTest()
                Initialisations(Grille, Candidats)
                Contrôle_Saisie()
        End Select

        '     i = 0

    End Sub
#Region "Initialisations"
    Sub InitTB()
        '============================================================================================================================================================
        '                                                             T E X T B O X E S  
        '============================================================================================================================================================
        TB(0, 0) = Me.TB_01
        TB(0, 1) = Me.TB_02
        TB(0, 2) = Me.TB_03
        TB(0, 3) = Me.TB_04
        TB(0, 4) = Me.TB_05
        TB(0, 5) = Me.TB_06
        TB(0, 6) = Me.TB_07
        TB(0, 7) = Me.TB_08
        TB(0, 8) = Me.TB_09
        TB(1, 0) = Me.TB_10
        TB(1, 1) = Me.TB_11
        TB(1, 2) = Me.TB_12
        TB(1, 3) = Me.TB_13
        TB(1, 4) = Me.TB_14
        TB(1, 5) = Me.TB_15
        TB(1, 6) = Me.TB_16
        TB(1, 7) = Me.TB_17
        TB(1, 8) = Me.TB_18
        TB(2, 0) = Me.TB_19
        TB(2, 1) = Me.TB_20
        TB(2, 2) = Me.TB_21
        TB(2, 3) = Me.TB_22
        TB(2, 4) = Me.TB_23
        TB(2, 5) = Me.TB_24
        TB(2, 6) = Me.TB_25
        TB(2, 7) = Me.TB_26
        TB(2, 8) = Me.TB_27
        TB(3, 0) = Me.TB_28
        TB(3, 1) = Me.TB_29
        TB(3, 2) = Me.TB_30
        TB(3, 3) = Me.TB_31
        TB(3, 4) = Me.TB_32
        TB(3, 5) = Me.TB_33
        TB(3, 6) = Me.TB_34
        TB(3, 7) = Me.TB_35
        TB(3, 8) = Me.TB_36
        TB(4, 0) = Me.TB_37
        TB(4, 1) = Me.TB_38
        TB(4, 2) = Me.TB_39
        TB(4, 3) = Me.TB_40
        TB(4, 4) = Me.TB_41
        TB(4, 5) = Me.TB_42
        TB(4, 6) = Me.TB_43
        TB(4, 7) = Me.TB_44
        TB(4, 8) = Me.TB_45
        TB(5, 0) = Me.TB_46
        TB(5, 1) = Me.TB_47
        TB(5, 2) = Me.TB_48
        TB(5, 3) = Me.TB_49
        TB(5, 4) = Me.TB_50
        TB(5, 5) = Me.TB_51
        TB(5, 6) = Me.TB_52
        TB(5, 7) = Me.TB_53
        TB(5, 8) = Me.TB_54
        TB(6, 0) = Me.TB_55
        TB(6, 1) = Me.TB_56
        TB(6, 2) = Me.TB_57
        TB(6, 3) = Me.TB_58
        TB(6, 4) = Me.TB_59
        TB(6, 5) = Me.TB_60
        TB(6, 6) = Me.TB_61
        TB(6, 7) = Me.TB_62
        TB(6, 8) = Me.TB_63
        TB(7, 0) = Me.TB_64
        TB(7, 1) = Me.TB_65
        TB(7, 2) = Me.TB_66
        TB(7, 3) = Me.TB_67
        TB(7, 4) = Me.TB_68
        TB(7, 5) = Me.TB_69
        TB(7, 6) = Me.TB_70
        TB(7, 7) = Me.TB_71
        TB(7, 8) = Me.TB_72
        TB(8, 0) = Me.TB_73
        TB(8, 1) = Me.TB_74
        TB(8, 2) = Me.TB_75
        TB(8, 3) = Me.TB_76
        TB(8, 4) = Me.TB_77
        TB(8, 5) = Me.TB_78
        TB(8, 6) = Me.TB_79
        TB(8, 7) = Me.TB_80
        TB(8, 8) = Me.TB_81

    End Sub

    Sub InitTest()
        ' Remplace le module de saisie

        g = 0
        For i = 0 To 8
            For j = 0 To 8
                g = (i * 9) + j
                k = TextSudoku.Length
                TB(i, j).Text = TextSudoku(g)
                TB(i, j).Font = TB_grand_modele.Font
                TBini(i, j) = TB(i, j)
                If TextSudoku(g) <> " " Then
                    TB(i, j).Enabled = False
                    Grille(i, j) = TextSudoku(g)
                    NbVal += 1
                Else
                    TB(i, j).ForeColor = Color.BlueViolet
                    TB(i, j).Enabled = True
                    Grille(i, j) = "0"
                End If
            Next
        Next
    End Sub

    Sub InitGéné()

        k = 0
        For i = 0 To 8
            For j = 0 To 8
                If Grille(i, j) = "0" Then
                    TB(i, j).Text = " "
                Else
                    TB(i, j).Text = Grille(i, j)
                End If
                TB(i, j).Font = TB_grand_modele.Font
                TBini(i, j) = TB(i, j)
                If Grille(i, j) <> "0" Then
                    TB(i, j).Enabled = False
                    NbVal += 1
                Else
                    TB(i, j).ForeColor = Color.BlueViolet
                    TB(i, j).Enabled = True
                End If
                k = k + 1
            Next
        Next
    End Sub
#End Region
#Region "Controles préalables"
    Sub Contrôle_Saisie()

        ' Recherche de doublons sur les lignes
        For i = 0 To 8
            ControleLigne(Erreur, ErreurGrille, Grille, i)
        Next
        ' Recherche de doublons sur les colonnes
        For j = 0 To 8
            ControleColonne(Erreur, ErreurGrille, Grille, j)
        Next
        ' Recherche de doublons sur les régions
        For r = 0 To 8
            ControleRégion(Erreur, ErreurGrille, Grille, r)
        Next

        AfficheErreur()

#End Region
    End Sub

#Region "Affichages"

    '============================================================================================================================================================
    '                                                             A F F I C H A G E S 
    '============================================================================================================================================================

    Sub AfficheErreur()
        For i = 0 To 8
            For j = 0 To 8
                If ErreurGrille(i, j) = "X" Or ErreurGrille(i, j) = "Y" Then
                    TB(i, j).BackColor = Color.Red
                Else
                    TB(i, j).ForeColor = TBini(i, j).ForeColor
                End If
            Next
        Next
    End Sub

    Sub RaffraichiLigne(_i As Integer)
        ' pour afficherles candidats de la ligne
        Dim _j As Integer
        For _j = 0 To 8
            If Grille(_i, _j) = "0" Then
                AfficheCandidats(_i, _j)
            End If
        Next

    End Sub

    Sub RaffraichiColonne(_j As Integer)
        ' pour afficherles candidats de la colonne
        Dim _i As Integer
        For _i = 0 To 8
            If Grille(_i, _j) = "0" Then
                AfficheCandidats(_i, _j)
            End If
        Next

    End Sub

    Sub RaffraichiRégion(_i As Integer, _j As Integer)
        ' pour afficherles candidats de la région
        Dim _r As Integer
        Dim _ir As Integer
        Dim _jr As Integer
        _r = ((_i \ 3) * 3) + (_j \ 3)  ' calcule la région d'après i et j

        _ir = (_r \ 3) * 3
        _jr = (_r - _ir) * 3
        For _i = _ir To _ir + 2
            For _j = _jr To _jr + 2
                If Grille(_i, _j) = "0" Then
                    AfficheCandidats(_i, _j)
                End If
            Next
        Next

    End Sub

    Sub AfficheCandidats(_i, _j)

        TB(_i, _j).Font = TB_petit_modele.Font
        TB(_i, _j).Text =
                    Candidats(_i, _j, 0) & " " & Candidats(_i, _j, 1) & " " & Candidats(_i, _j, 2) & Environment.NewLine &
                    Candidats(_i, _j, 3) & " " & Candidats(_i, _j, 4) & " " & Candidats(_i, _j, 5) & Environment.NewLine &
                    Candidats(_i, _j, 6) & " " & Candidats(_i, _j, 7) & " " & Candidats(_i, _j, 8)

    End Sub

#End Region

#Region "Boutons"

    '============================================================================================================================================================
    '                                                             B O U T O N S 
    '============================================================================================================================================================

    Private Sub QuitterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitterToolStripMenuItem.Click
        'Fermeture avec confirmation
        If MsgBox("Souhaitez-vous vraiment quitter ce magnifique programme ?", 36, "Quitter") = MsgBoxResult.Yes Then
            End
        End If
    End Sub


    Private Sub RésoudreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RésoudreToolStripMenuItem.Click
        Resoudre()
    End Sub

    Private Sub BT_Resoudre_Click(sender As Object, e As EventArgs) Handles BT_Resoudre.Click
        Resoudre()
    End Sub

    Private Sub Resoudre()

        Calcul_Candidats(Grille, Candidats, TabSolution, NbSol, Simplification, NbSmp)

        '
        ' Affiche les candidats dans la grille
        '
        For i = 0 To 8
            For j = 0 To 8
                If Grille(i, j) = "0" Then
                    TB(i, j).Font = TB_petit_modele.Font
                    TB(i, j).Text =
                            Candidats(i, j, 0) & " " & Candidats(i, j, 1) & " " & Candidats(i, j, 2) & Environment.NewLine &
                            Candidats(i, j, 3) & " " & Candidats(i, j, 4) & " " & Candidats(i, j, 5) & Environment.NewLine &
                            Candidats(i, j, 6) & " " & Candidats(i, j, 7) & " " & Candidats(i, j, 8)
                End If
            Next
        Next

        If NbSol > 0 Then
            LBL_Conseil.Text = "Ligne " & TabSolution(0).i + 1 & " colonne " & TabSolution(0).j + 1 & " " & TabSolution(0).m & " : " _
                             & TabSolution(0).v & " / " & NbSol & " / "
            '    ProchaineSolution(TabSolution, NbSol)
        Else
            MsgBox("On passe à la suite")
        End If


    End Sub

    'Private Sub BT_Suivant_Click(sender As Object, e As EventArgs) Handles BT_Suivant.Click

    '    If NbSol > 0 Then
    '        LBL_Conseil.Text = "Ligne " & TabSolution(0).i + 1 & " colonne " & TabSolution(0).j + 1 & " " & TabSolution(0).m & " : " _
    '                         & TabSolution(0).v & " / " & NbSol & " / "
    '        ProchaineSolution(TabSolution, NbSol)
    '    Else
    '        MsgBox("On passe à la suite")
    '    End If

    'End Sub

    Private Sub BT_Suivant_Click(sender As Object, e As EventArgs) Handles BT_Suivant.Click

        ' La dernière valeur proposée est à la fin du tableau des solutions

        ' s = GetRandom(0, GNbSol - 1)

        If NbSol > 0 Then

            i = TabSolution(NbSol - 1).i
            j = TabSolution(NbSol - 1).j
            TB(i, j).Text = TabSolution(NbSol - 1).v
            Grille(i, j) = TB(i, j).Text

            TB(i, j).Font = TB_grand_modele.Font
            TB(i, j).Enabled = False
            NbVal += 1

            Recalcul_Candidats(i, j, Grille, Candidats) ' Retire la valeur saisie des groupes auxquels la case appartient  

            RaffraichiLigne(i)
            RaffraichiColonne(j)
            RaffraichiRégion(i, j)

            TabSolution(NbSol - 1).i = "0"
            TabSolution(NbSol - 1).j = "0"
            TabSolution(NbSol - 1).v = ""
            TabSolution(NbSol - 1).m = ""
            NbSol -= 1
        Else
            If NbSmp > 0 Then
                SuppressionCandidats(NbSmp, Candidats, Simplification, opk, nuplet)
            End If
        End If

        Resoudre()

        If NbSol > 0 Then
            LBL_Conseil.Text = "Ligne " & TabSolution(0).i + 1 & " colonne " & TabSolution(0).j + 1 & " " & TabSolution(0).m & " : " _
                             & TabSolution(0).v & " / " & NbSol & " / "
            '   ProchaineSolution(TabSolution, NbSol)
        Else
            MsgBox("On passe à la suite")
        End If
    End Sub


    Private Sub BT_Solutions_Click(sender As Object, e As EventArgs) Handles BT_Solutions.Click

        Solutions.Show()

    End Sub

#End Region


End Class
