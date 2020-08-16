Imports System.IO
Public Class Sudoku
    '============================================================================================================================================================
    '
    ' Rappel Doc Microsoft : L’argument de tableau doit être transmis selon sa référence (ByRef) !!!
    '
    '============================================================================================================================================================

#Region " Déclarations"

    '============================================================================================================================================================
    '                                                             D E C L A R A T I O N S  
    '============================================================================================================================================================

    Dim BT(8, 8) As Button
    Dim iBT As Integer
    Dim jBT As Integer
    Dim BTC(9) As Button
    Dim valSaisie As String
    Dim iValSaisie As Integer = 0

    Dim i As Integer = 0
    Dim j As Integer = 0
    Dim v As String
    Dim k As Integer = 0
    Dim g As Integer = 0

    Dim Grille(8, 8) As String ' La grille de Sudoku
    Dim GrilleInitiale(8, 8) As String ' La grille en début de partie
    Public GrilleFinale(8, 8) As String ' La grille en fin de partie
    Dim SolutionExiste As Boolean
    Dim opk(8, 8) As Integer ' Nombre de candidats de k par case
    Dim nuplet(8, 8) As String 'Candidats agrégés

    Dim Candidats(8, 8, 8) As String ' La grille des candidats ( Valeurs au crayon)
    Dim NbVal As Integer = 0
    Dim NbValInitial As Integer = 0

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
        Dim b As Integer 'Barème
    End Structure

    Public Solution As New Sudoku.StrSolution
    Public QSol As Queue(Of Sudoku.StrSolution) = New Queue(Of Sudoku.StrSolution)

    Structure CandidatsRetenus
        Dim i() As Integer
        Dim j() As Integer
        Dim k() As Integer
        Dim v() As String
    End Structure

    Structure CandidatsEliminés
        Dim i() As Integer
        Dim j() As Integer
        Dim k() As Integer
        Dim v() As String
    End Structure

    Structure StrSmp ' Simplification 
        Dim motif As String 'Motif
        Dim act As Boolean
        'candidats retenus (ReDim 3) 
        Dim nr As Integer 'nombre de candidats retenus
        Dim CR As CandidatsRetenus
        'candidats éliminés (ReDim 20)
        Dim ne As Integer 'nombre de candidats éliminés
        Dim CE As CandidatsEliminés
    End Structure

    Public TSmp(80) As Sudoku.StrSmp
    Public NbrSmp As Integer
    Dim Smp As Sudoku.StrSmp


    Structure AnlTrp 'Analyse triplet
        Dim i As Integer
        Dim j As Integer
        Dim v() As String
    End Structure

    Dim Libel As String
    Public myFileNname As String
    Dim Erreur As Boolean
    Dim ErreurGrille(8, 8) As String
    Dim SegmentCandidats(8, 8) As String


    Public pileGrilles(81, 8, 8) As String ' La grille de Sudoku à chaque tour
    Public Val As String() = {"1", "2", "3", "4", "5", "6", "7", "8", "9"}
    Public mode As String
    Public modeCandidat As Boolean
    Dim stepByStepApply As Boolean

    Public taille As Integer = 18
    Public BarèmeSeulDansUneCase As Integer = 1
    Public BarèmeSeulDansUneLigne As Integer = 1
    Public BarèmeSeulDansUneColonne As Integer = 1
    Public BarèmeSeulDansUneRégion As Integer = 1

    Public ChiffreOffColor As Color = Color.LightSkyBlue
    Public ChiffreOnColor As Color = Color.AliceBlue
    Public petiteFont As Font = New Font("Courier New", 9, FontStyle.Regular, GraphicsUnit.Point)
    Public grandeFont As Font = New Font("Microsoft Sans Serif", 18, FontStyle.Regular, GraphicsUnit.Point)
    Dim colorIni(8, 8) As Color

    Dim typeGrille As String = "Sym"
    ' Grilles pour le dev
    ReadOnly sudo_Modèle As String = "8 1    45      7 6 56   8   9 7  1      8       2  538    4  8 427    1     9   4" 'Grille modèle
    ReadOnly sudoTestLig As String = "8 11   45      7 6 56   8   9 7  1  8   8       2  538    4  8 427    1     9   4"
    ReadOnly sudoTestCol As String = "8 1    45      7 6 56   8   9 7  1      8       2  538    4  8 427    1     9   4"
    ReadOnly sudoTestReg As String = "8 1    45      7 6 56   8   9 7  1      8       2  538    4  81427    1     9   4"
    ReadOnly sudoDifficile As String = " 9 8 2     79  1 36   7 5   7    9 2         9 3    6   6 1   42 8  43     2 6 7 "
    ReadOnly SudopairCol As String = " 132    6 52  97    7 61      91  3    7 8    8  23      19 4    48  67 9    751 " ' ok
    ReadOnly SudopairReg As String = "  7 2 53 82   9  4  3       3 87     6     4     32 5       6  9  6   17 76 5 4  "
    ReadOnly SodiCVL1zzz As String = "    1  8 1 4   2    97 4    78 9 3  3       2  2 6 84    1 86    5   1 3 1  7    "
    ' 2 paires nues + cancdidats véroullés + triplet nus
    ReadOnly SudopairLig As String = "   3    1 13 8 97  6 17    7 9    1     4     8    4 2    93 2  91 2 78 2    5   " ' 
    ' 2 pairesnues 
    ReadOnly Sudo0010000 As String = "9  3     8   9 42   362     78   5 9  2 7 6  5 9   37     132   51 4   7     6  1"
    ReadOnly Tripletnu02 As String = " 8 5297  9          6 3    8    4 9  7298364  4 7    8    6 9          6  6498 2 " 'en colonne cassé?
    'triplets nus en ligne et en région
    ReadOnly Tripletnu03 As String = " 8         29  4 1  14   6 8   6  2   57189   9  3   5 6   13  9 3  25         9 "
    'XY-Wing ligne et colonne
    ReadOnly S04XYWingLC As String = "  9  27  12  8   5    46   87     16  1   4  24     39   86    4   7  68  62  1  "
    'XY-Wing ligne et région
    ReadOnly S05XYWingLR As String = "   21 34   2    5   5 349 72    8 1     6     5 3    97 982 4   2    8   63 57   "
    'XY-Wing Colonne et région
    ReadOnly S006XYWingCR As String = "809     5  3   6  5 7  8   67 3 5     1   2     8 1 36   4  3 7  4   1  7     5 8"
    ReadOnly S007XWingCC As String = "     3  4 95  1   71     89   3 76   6  2  3   75 9   64     57   4  96 2  7     "
    ReadOnly S008XWingLL As String = " 3 4     8 5    34 12 85   2   4   1 98   34 6   7   2   52 41 58    9 3     9 5 "
    'Paire cachée ligne
    ReadOnly S101PcacheL As String = "7943 6    28  5    5      6     1 6  76 5 48  4 6     8      1    1  94    9 3675"
    ReadOnly jauge______ As String = "123456789123456789123456789123456789123456789123456789123456789123456789123456789"
    Dim TextSudoku As String = "                                                                                 "


#End Region
    '============================================================================================================================================================
    '                                                             L O A D E R 
    '============================================================================================================================================================
    '

    Private Sub Sudoku_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim c As Integer

        InitBT()
        For i = 0 To 8
            For j = 0 To 8
                BT(i, j).Text = ""
                BT(i, j).Font = grandeFont
                BT(i, j).ForeColor = Color.Black
                BT(i, j).Enabled = False
                c = (i * 9) + j
                Select Case c
                    Case 3, 4, 5, 12, 13, 14, 21, 22, 23, 27, 28, 29, 33, 34, 35, 36, 37, 38, 42, 43, 44, 45, 46, 47, 51, 52, 53, 57, 58, 59, 66, 67, 68, 75, 76, 77
                        colorIni(i, j) = Color.LightCyan
                    Case Else
                        colorIni(i, j) = Color.Azure
                End Select
            Next
        Next

    End Sub

#Region "Initialisations"
    Sub InitBT()
        '============================================================================================================================================================
        '                                                             T E X T B O X E S  
        '============================================================================================================================================================
        Dim i As Integer
        Dim j As Integer

        BT(0, 0) = Me.BT00
        BT(0, 1) = Me.BT01
        BT(0, 2) = Me.BT02
        BT(0, 3) = Me.BT03
        BT(0, 4) = Me.BT04
        BT(0, 5) = Me.BT05
        BT(0, 6) = Me.BT06
        BT(0, 7) = Me.BT07
        BT(0, 8) = Me.BT08
        BT(1, 0) = Me.BT09
        BT(1, 1) = Me.BT10
        BT(1, 2) = Me.BT11
        BT(1, 3) = Me.BT12
        BT(1, 4) = Me.BT13
        BT(1, 5) = Me.BT14
        BT(1, 6) = Me.BT15
        BT(1, 7) = Me.BT16
        BT(1, 8) = Me.BT17
        BT(2, 0) = Me.BT18
        BT(2, 1) = Me.BT19
        BT(2, 2) = Me.BT20
        BT(2, 3) = Me.BT21
        BT(2, 4) = Me.BT22
        BT(2, 5) = Me.BT23
        BT(2, 6) = Me.BT24
        BT(2, 7) = Me.BT25
        BT(2, 8) = Me.BT26
        BT(3, 0) = Me.BT27
        BT(3, 1) = Me.BT28
        BT(3, 2) = Me.BT29
        BT(3, 3) = Me.BT30
        BT(3, 4) = Me.BT31
        BT(3, 5) = Me.BT32
        BT(3, 6) = Me.BT33
        BT(3, 7) = Me.BT34
        BT(3, 8) = Me.BT35
        BT(4, 0) = Me.Bt36
        BT(4, 1) = Me.BT37
        BT(4, 2) = Me.BT38
        BT(4, 3) = Me.BT39
        BT(4, 4) = Me.BT40
        BT(4, 5) = Me.BT41
        BT(4, 6) = Me.BT42
        BT(4, 7) = Me.BT43
        BT(4, 8) = Me.BT44
        BT(5, 0) = Me.BT45
        BT(5, 1) = Me.BT46
        BT(5, 2) = Me.BT47
        BT(5, 3) = Me.BT48
        BT(5, 4) = Me.BT49
        BT(5, 5) = Me.BT50
        BT(5, 6) = Me.BT51
        BT(5, 7) = Me.BT52
        BT(5, 8) = Me.BT53
        BT(6, 0) = Me.BT54
        BT(6, 1) = Me.BT55
        BT(6, 2) = Me.BT56
        BT(6, 3) = Me.BT57
        BT(6, 4) = Me.BT58
        BT(6, 5) = Me.Bt59
        BT(6, 6) = Me.BT60
        BT(6, 7) = Me.BT61
        BT(6, 8) = Me.BT62
        BT(7, 0) = Me.BT63
        BT(7, 1) = Me.BT64
        BT(7, 2) = Me.BT65
        BT(7, 3) = Me.BT66
        BT(7, 4) = Me.BT67
        BT(7, 5) = Me.BT68
        BT(7, 6) = Me.BT69
        BT(7, 7) = Me.BT70
        BT(7, 8) = Me.BT71
        BT(8, 0) = Me.BT72
        BT(8, 1) = Me.BT73
        BT(8, 2) = Me.BT74
        BT(8, 3) = Me.BT75
        BT(8, 4) = Me.BT76
        BT(8, 5) = Me.BT77
        BT(8, 6) = Me.BT78
        BT(8, 7) = Me.BT79
        BT(8, 8) = Me.BT80

        BTC(0) = BT_1
        BTC(1) = BT_2
        BTC(2) = BT_3
        BTC(3) = BT_4
        BTC(4) = BT_5
        BTC(5) = BT_6
        BTC(6) = BT_7
        BTC(7) = BT_8
        BTC(8) = BT_9
        BTC(9) = BT_Clear

        For i = 0 To 8
            For j = 0 To 8
                With Me.BT(i, j)
                    .ForeColor = Color.Black
                    .Text = " "
                End With
            Next
        Next

        For i = 0 To 8
            With Me.BTC(i)
                .BackColor = ChiffreOffColor
                .ForeColor = Color.Black
            End With
        Next

        QSol.Clear()
        TsmpClear(NbrSmp, TSmp)

    End Sub

    Sub TextSudokuToGrille(TextSudoku As String)

        ' Remplace le module de saisie
        NbVal = 0
        g = 0
        For i = 0 To 8
            For j = 0 To 8
                g = (i * 9) + j
                If TextSudoku(g) <> " " Then
                    Grille(i, j) = TextSudoku(g)
                    With Me.BT(i, j)
                        .Text = TextSudoku(g)
                        .Font = grandeFont
                        .ForeColor = Color.Black
                        .BackColor = colorIni(i, j)
                        .Enabled = False
                    End With
                    NbVal += 1
                    LBL_nbVal.Text = NbVal.ToString
                Else
                    Grille(i, j) = "0"
                    With Me.BT(i, j)
                        .Text = TextSudoku(g)
                        .Font = grandeFont
                        .ForeColor = Color.Black
                        .BackColor = colorIni(i, j)
                        .Enabled = True
                    End With
                End If
            Next
        Next

    End Sub

#End Region


#Region "Affichages"

    '============================================================================================================================================================
    '
    '                                                             A F F I C H A G E S 
    '
    '============================================================================================================================================================

    Sub Affichage()

        For i = 0 To 8
            For j = 0 To 8
                With Me.BT(i, j)
                    .BackColor = colorIni(i, j)
                End With
                If ErreurGrille(i, j) = "X" Or ErreurGrille(i, j) = "Y" Then
                    With Me.BT(i, j)
                        .Text = Grille(i, j)
                        .Font = grandeFont
                        .ForeColor = Color.Black
                        .BackColor = Color.Red
                    End With
                Else
                    If Grille(i, j) = "0" Then
                        If modeCandidat Then
                            With Me.BT(i, j)
                                .Text =
                            Candidats(i, j, 0) & " " & Candidats(i, j, 1) & " " & Candidats(i, j, 2) & Environment.NewLine &
                            Candidats(i, j, 3) & " " & Candidats(i, j, 4) & " " & Candidats(i, j, 5) & Environment.NewLine &
                            Candidats(i, j, 6) & " " & Candidats(i, j, 7) & " " & Candidats(i, j, 8)
                                .Font = petiteFont
                                .ForeColor = Color.Black
                                .BackColor = colorIni(i, j)
                                .Enabled = True
                            End With
                        Else
                            With Me.BT(i, j)
                                .Text = " "
                                .Font = grandeFont
                                .ForeColor = Color.Black
                                .BackColor = colorIni(i, j)
                                .Enabled = True
                            End With
                        End If
                    Else
                        With Me.BT(i, j)
                            .Text = Grille(i, j)
                            .Font = grandeFont
                            .ForeColor = Color.Black
                            .BackColor = colorIni(i, j)
                            .Enabled = True
                        End With
                    End If
                End If
            Next
        Next

        LBL_nbVal.Text = "Cases remplies : " & NbVal.ToString

    End Sub

    '============================================================================================================================================================
    ' Pour afficher tous les candidats         
    '============================================================================================================================================================

    Sub RaffraichiGrille()

        For i = 0 To 8
            For j = 0 To 8
                If Grille(i, j) = "0" Then
                    AfficheCandidats(i, j)
                End If
            Next
        Next

    End Sub

    Sub AfficheCandidats(i, j)

        With Me.BT(i, j)
            .Text =
                            Candidats(i, j, 0) & " " & Candidats(i, j, 1) & " " & Candidats(i, j, 2) & Environment.NewLine &
                            Candidats(i, j, 3) & " " & Candidats(i, j, 4) & " " & Candidats(i, j, 5) & Environment.NewLine &
                            Candidats(i, j, 6) & " " & Candidats(i, j, 7) & " " & Candidats(i, j, 8)
            .Font = petiteFont
            .ForeColor = Color.Black
            .BackColor = colorIni(i, j)
            .Enabled = True
        End With

    End Sub

#End Region

#Region "Menus"

    '============================================================================================================================================================
    '
    '                                                             M E N U S 
    '
    '============================================================================================================================================================


    '============================================================================================================================================================
    ' -  M E N U   S A I S I E 
    '============================================================================================================================================================

    Private Sub SaisieToolStripMenuItem1_Click_1(sender As Object, e As EventArgs) Handles SaisieToolStripMenuItem1.Click

        FonctionSaisie()

    End Sub

    Private Sub SaisirToolStripButton_Click(sender As Object, e As EventArgs) Handles SaisirToolStripButton.Click

        FonctionSaisie()

    End Sub

    Sub FonctionSaisie()

        mode = "Saisie"
        For i = 0 To 8
            For j = 0 To 8
                With Me.BT(i, j)
                    .Text = ""
                    .Font = grandeFont
                    .ForeColor = Color.Black
                    .BackColor = colorIni(i, j)
                    .Enabled = True
                End With
                Grille(i, j) = "0"
                For k = 0 To 8
                    Candidats(i, j, k) = " "
                Next
            Next
        Next

    End Sub

    '============================================================================================================================================================
    ' -  M E N U   G E N E R E R  
    '============================================================================================================================================================

    Private Sub GénérerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GénérerToolStripMenuItem.Click

        FonctionGénérer()
        FonctionJouer()
    End Sub

    Private Sub GénérerToolStripButton_Click(sender As Object, e As EventArgs) Handles GénérerToolStripButton.Click

        FonctionGénérer()
        FonctionJouer()

    End Sub


    Sub FonctionGénérer()

        mode = "Générer"

        Générateur.Générateur(Grille)
        ControleSaisie(Erreur, ErreurGrille, Grille, Candidats) 'Vérifie la validité de la grille

        'ViderPileGrille()
        'EnpileGrille(Grille, NbVal)
        'Problème.Problème(typeGrille, NbVal, Grille, Candidats)
        'ControleSaisie(Erreur, ErreurGrille, Grille, Candidats) 'Vérifie la validité de la grille
        Affichage()
        FonctionJouer()

    End Sub

    '============================================================================================================================================================
    ' -  M E N U   O U V R I R   F I C H I E R   -   C H A R G E R   U N E   G R I L L E
    '============================================================================================================================================================

    Private Sub OuvrirToolStripButton1_Click(sender As Object, e As EventArgs) Handles OuvrirToolStripButton1.Click

        mode = "Ouvrir"
        FonctionOuvrirFichier()
    End Sub


    Private Sub ChToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChToolStripMenuItem.Click

        mode = "Charger"
        FonctionOuvrirFichier()

    End Sub


    Sub FonctionOuvrirFichier()

        Dim fichierCorrrect As Boolean
        'Boîte de dialogue d'ouverture de fichier
        ' avec limitation dans les extensions de fichier
        Dim openFileDialog As New OpenFileDialog With {
            .Filter = "Fichier sudoku (*.sud)|*.sud|Tous les fichiers|*.*",
            .RestoreDirectory = True
        }

        If openFileDialog.ShowDialog() = DialogResult.OK Then

            myFileNname = openFileDialog.FileName
            nomFichierOuvert.Text = Path.GetFileName(openFileDialog.FileName)
            LectureGrille(myFileNname, Grille, fichierCorrrect)
            If fichierCorrrect Then
            Else
                MsgBox("Fichier corrompu ou format invalide")
                Exit Sub
            End If

        End If

        For i = 0 To 8
            For j = 0 To 8
                If Grille(i, j) = "0" Then
                    With Me.BT(i, j)
                        .Text = ""
                        .Font = grandeFont
                        .ForeColor = Color.Black
                        .BackColor = colorIni(i, j)
                        .Enabled = True
                    End With
                Else
                    With Me.BT(i, j)
                        .Text = TextSudoku(g)
                        .Font = grandeFont
                        .ForeColor = Color.Black
                        .BackColor = colorIni(i, j)
                        .Enabled = False
                    End With
                    NbVal += 1
                    LBL_nbVal.Text = NbVal.ToString
                End If
            Next
        Next

        nomFichierOuvert.Text = Path.GetFileName(openFileDialog.FileName)
        CalculCandidats(Grille, Candidats)
        ControleSaisie(Erreur, ErreurGrille, Grille, Candidats) 'Vérifie la validité de la grille
        LBL_Conseil.Text = ""
        Affichage()
        FonctionJouer()

    End Sub



    Private Sub SauvegarderUneGrilleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SauvegarderUneGrilleToolStripMenuItem.Click
        'Boîte de dialogue de sauvegarde de fichier
        ' avec limitation dans les extensions de fichier
        Dim SaveFileDialog1 As New SaveFileDialog With {
            .Filter = "Fichier texte (*.sud)|*.sud|Tous les fichiers|*.*",
            .FileName = myFileNname,
            .RestoreDirectory = True
        }

        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            'Ouvrez le fichier sélectionné dans le lecteur.
            ' on    ecrit le nom du fichier selectionné dans la variable "string" nomfic2
        End If
    End Sub

    '============================================================================================================================================================
    ' -  M E N U   E N R E G I S T R E R   F I C H I E R 
    '============================================================================================================================================================

    Private Sub EnregistrerToolStripButton_Click(sender As Object, e As EventArgs) Handles EnregistrerToolStripButton.Click

    End Sub

    '============================================================================================================================================================
    ' -  M E N U   J O U E R 
    '============================================================================================================================================================

    Private Sub JouerToolStripButton1_Click(sender As Object, e As EventArgs) Handles JouerToolStripButton1.Click

        FonctionJouer()

    End Sub

    Sub FonctionJouer()

        mode = "Jouer"
        modeCandidat = False

        For i = 0 To 8
            For j = 0 To 8
                If Grille(i, j) <> "0" Then
                    With Me.BT(i, j)
                        .Enabled = False
                    End With
                End If
            Next
        Next

        Array.Copy(Grille, GrilleInitiale, 81)
        NbValInitial = NbVal
        Array.Copy(Grille, GrilleFinale, 81)

        'SolutionGrille(GrilleFinale, NbVal, QSol, NbrSmp, TSmp, SolutionExiste)

        'If SolutionExiste Then
        'Else
        '    MsgBox("Désolé je n'ai pas trouvé de solution unique")
        'End If

        NbVal = NbValInitial
        RecommencerToolStripButton.Enabled = True

    End Sub

    '============================================================================================================================================================
    ' -  M E N U   R E C O M M E N C E R 
    '============================================================================================================================================================

    Private Sub RecommencerToolStripButton_Click(sender As Object, e As EventArgs) Handles RecommencerToolStripButton.Click

        Dim Msg, Style, Title, Response
        Msg = "Etes vous sûr de vouloir recommencer la partie ?"  ' Define message.
        Style = vbYesNo + vbQuestion + vbDefaultButton2    ' Define buttons.
        Title = "MsgBox Demonstration"    ' Define title.


        Response = MsgBox(Msg, Style, Title)

        If Response = vbNo Then    ' User chose Yes.
            Exit Sub
        End If

        Array.Copy(GrilleInitiale, Grille, 81)
        NbVal = NbValInitial

        CalculCandidats(Grille, Candidats)
        ControleSaisie(Erreur, ErreurGrille, Grille, Candidats) 'Vérifie la validité de la grille
        LBL_Conseil.Text = ""
        modeCandidat = False
        Affichage()
        FonctionJouer()

    End Sub

    '============================================================================================================================================================
    ' -  M E N U   A F F I C H E R   L E S   C A N D I D A T S  
    '============================================================================================================================================================

    Private Sub AfficherLesCandidatsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AfficherLesCandidatsToolStripMenuItem.Click

        modeCandidat = True
        Affichage()

    End Sub

    '============================================================================================================================================================
    ' -  M E N U   E F F A C E R    L E S   C A N D I D A T S  
    '============================================================================================================================================================

    Private Sub EffacerLesCandidatsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EffacerLesCandidatsToolStripMenuItem.Click

        modeCandidat = False
        Affichage()

    End Sub

    '============================================================================================================================================================
    ' -  M E N U   T E S T  
    '============================================================================================================================================================

    '============================================================================================================================================================
    ' -  M E N U   T E S T   Paire nue en ligne
    '============================================================================================================================================================

    Private Sub PaireNueEnLigneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PaireNueEnLigneToolStripMenuItem.Click

        TextSudoku = "49    3 5 2  7 94   3   7    1735               4286    2   4   34 6  2 1 9    76"
        FonctionDémo(TextSudoku)

    End Sub

    Private Sub PaireNueEnColonneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PaireNueEnColonneToolStripMenuItem.Click

    End Sub

    '============================================================================================================================================================
    ' -  M E N U   T E S T   Paire nue en région
    '============================================================================================================================================================

    Private Sub EnRégionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnRégionToolStripMenuItem.Click

        TextSudoku = "1  7 39        5   79 4  1 3 74 91  8       9  43 18 5 1  3 75   2        85 4  1"
        FonctionDémo(TextSudoku)

    End Sub

    '============================================================================================================================================================
    ' -  M E N U   T E S T   XY-WING En Ligne
    '============================================================================================================================================================

    Private Sub XYWingEnLigneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XYWingEnLigneToolStripMenuItem.Click

        TextSudoku = " 5  63  17    2   3    8 6 92   5  6  56 47  6  3   59 3 1    2   2    88  43  7 "
        FonctionDémo(TextSudoku)

    End Sub

    '============================================================================================================================================================
    ' -  M E N U   T E S T   X-WING En Ligne
    '============================================================================================================================================================

    Private Sub XWingEnLigneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XWingEnLigneToolStripMenuItem.Click
        TextSudoku = " 3495   616 24   7  5      2    7 4           7 4    9      6      92 713   7859 "
        FonctionDémo(TextSudoku)

    End Sub

    '============================================================================================================================================================
    ' -  M E N U   T E S T   X-WING En colonne
    '============================================================================================================================================================

    Private Sub XWingEnColonneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XWingEnColonneToolStripMenuItem.Click

        TextSudoku = "   451       7  8 3   98  1 9    14 74  2  35 86    2 8  91   3 7  4       587   "
        FonctionDémo(TextSudoku)

    End Sub

    '============================================================================================================================================================
    ' -  M E N U   T E S T   Triplet nu en ligne
    '============================================================================================================================================================

    Private Sub TripletNuEnLigneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TripletNuEnLigneToolStripMenuItem.Click

        TextSudoku = " 8         29  4 1  14   6 8   6  2   57189   9  3   5 6   13  9 3  25         9 "
        FonctionDémo(TextSudoku)

    End Sub

    Private Sub FonctionDémo(TextSudoku)

        modeCandidat = False
        mode = "démo"
        TextSudokuToGrille(TextSudoku)
        CalculCandidats(Grille, Candidats)
        ControleSaisie(Erreur, ErreurGrille, Grille, Candidats) 'Vérifie la validité de la grille
        LBL_Conseil.Text = ""
        nomFichierOuvert.Text = ""
        Affichage()
        FonctionJouer()

    End Sub
#End Region

#Region "Boutons"

    '============================================================================================================================================================
    '
    '                                                             B O U T O N S 
    '
    '============================================================================================================================================================

    Private Sub QuitterToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'Fermeture avec confirmation
        If MsgBox("Souhaitez-vous vraiment quitter ce magnifique programme ?", 36, "Quitter") = MsgBoxResult.Yes Then
            End
        End If

    End Sub


    '============================================================================================================================================================
    '  - S O L U T I O N   P A S   A   P A S
    '============================================================================================================================================================

    Private Sub BTStepByStep_Click(sender As Object, e As EventArgs) Handles BTStepByStep.Click

        FonctionStepByStep()

    End Sub

    '============================================================================================================================================================
    '  - S O L U T I O N   P A S   A   P A S
    '============================================================================================================================================================

    Sub FonctionStepByStep()

        QSol.Clear()
        TsmpClear(NbrSmp, TSmp)
        RechercheSolution(Grille, Candidats, QSol, NbrSmp, TSmp, NbVal)

        For i = 0 To 8
            For j = 0 To 8
                With Me.BT(i, j)
                    .ForeColor = Color.Black
                    .BackColor = colorIni(i, j)
                End With
            Next
        Next

        If QSol.Count = 0 And NbrSmp = 0 Then
            If NbVal < 81 Then
                MsgBox("Plus de solution " & NbVal & "*")
            Else
                MsgBox("Bravo ! ")
            End If
        Else
            If QSol.Count > 0 Then

                Solution = QSol.Peek()
                i = Solution.i
                j = Solution.j

                LBL_Conseil.Text = "Ligne " & Solution.i + 1 & " Colonne " & Solution.j + 1 & " : " & Solution.m

                With Me.BT(i, j)
                    .BackColor = Color.Plum
                End With

                If stepByStepApply Then
                    AppliqueUneSolution(QSol, Grille, Candidats, i, j, v)
                    With Me.BT(i, j)
                        .Text = v
                        .Font = grandeFont
                        .BackColor = Color.Plum
                        .Enabled = True
                    End With
                    NbVal += 1
                    LBL_nbVal.Text = "Cases remplies : " & NbVal.ToString
                Else
                    With Me.BT(i, j)
                        .Text =
                            Candidats(i, j, 0) & " " & Candidats(i, j, 1) & " " & Candidats(i, j, 2) & Environment.NewLine &
                            Candidats(i, j, 3) & " " & Candidats(i, j, 4) & " " & Candidats(i, j, 5) & Environment.NewLine &
                            Candidats(i, j, 6) & " " & Candidats(i, j, 7) & " " & Candidats(i, j, 8)
                        .Font = petiteFont
                        .BackColor = Color.Plum
                        .Enabled = True
                    End With
                End If

            Else

                If NbrSmp > 0 Then
                    Smp = TSmp(0)
                    LBL_Conseil.Text = Smp.motif
                    modeCandidat = True

                    If Smp.ne > 0 Then
                        For s = 0 To Smp.ne - 1
                            i = Smp.CE.i(s)
                            j = Smp.CE.j(s)
                            With Me.BT(i, j)
                                .ForeColor = Color.Black
                                .BackColor = Color.Gold
                            End With
                        Next
                    End If
                    For s = 0 To Smp.nr - 1
                        i = Smp.CR.i(s)
                        j = Smp.CR.j(s)
                        With Me.BT(i, j)
                            .ForeColor = Color.Black
                            .BackColor = Color.Plum
                        End With
                    Next

                    If stepByStepApply Then
                        AppliqueUneSimplification(NbrSmp, TSmp, Candidats)
                    End If
                End If
            End If
        End If

        '
        ' Affiche les candidats dans la grille
        '

        For i = 0 To 8
            For j = 0 To 8
                If Grille(i, j) = "0" Then
                    If modeCandidat Then
                        With Me.BT(i, j)
                            .Text =
                                Candidats(i, j, 0) & " " & Candidats(i, j, 1) & " " & Candidats(i, j, 2) & Environment.NewLine &
                                Candidats(i, j, 3) & " " & Candidats(i, j, 4) & " " & Candidats(i, j, 5) & Environment.NewLine &
                                Candidats(i, j, 6) & " " & Candidats(i, j, 7) & " " & Candidats(i, j, 8)
                            .Font = petiteFont
                            .Enabled = True
                        End With
                    Else
                        With Me.BT(i, j)
                            .Text = " "
                            .Font = grandeFont
                            .Enabled = True
                        End With

                    End If
                End If
            Next
        Next

        If stepByStepApply Then
            stepByStepApply = False
        Else
            stepByStepApply = True
        End If

    End Sub

    '============================================================================================================================================================
    '  - S O L U T I O N   C O M P L E T E 
    '============================================================================================================================================================

    Private Sub BTSolution_Click(sender As Object, e As EventArgs) Handles BTSolution.Click

        QSol.Clear()
        TsmpClear(NbrSmp, TSmp)

        Array.Copy(Grille, GrilleFinale, 81)

        SolutionGrille(GrilleFinale, NbVal, QSol, NbrSmp, TSmp, SolutionExiste)
        If SolutionExiste Then
            Array.Copy(GrilleFinale, Grille, 81)
            Affichage()
        Else
            MsgBox("pas de solution")
        End If

    End Sub

    '============================================================================================================================================================
    '  - S O L U T I O N  F O R C E   B R U T E
    '============================================================================================================================================================

    Private Sub BTForceBrute_Click(sender As Object, e As EventArgs) Handles BTForceBrute.Click
        Dim NbSol As Integer
        Array.Copy(Grille, GrilleFinale, 81)
        ForceBrute.ForceBrute(GrilleFinale, NbSol)

        If NbSol = 1 Then
            Array.Copy(GrilleFinale, Grille, 81)
            Affichage()
        Else
            If NbSol = 0 Then
                MsgBox("Pas de solution")
            Else
                MsgBox("Cette grille admet plusieurs solutions")
            End If
        End If

    End Sub

    '============================================================================================================================================================
    '  - Affichage du Tableau des Solutions
    '============================================================================================================================================================


    Private Sub BT_Solutions_Click(sender As Object, e As EventArgs) Handles BT_Solutions.Click

        Solutions.Show()

    End Sub

    '============================================================================================================================================================
    '  - - Affichage du Tableau des Simplifications
    '============================================================================================================================================================

    Private Sub BT_Smp_Click(sender As Object, e As EventArgs) Handles BT_Smp.Click

        Simplifications.Show()

    End Sub

    Private Sub QuitterToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles QuitterToolStripMenuItem.Click

        Me.Close()

    End Sub
    '============================================================================================================================================================
    '
    '                                        B O U T O N S   D E   S A I S I E
    '
    '============================================================================================================================================================

    Private Sub BT_1_Click(sender As Object, e As EventArgs) Handles BT_1.Click
        BTC(iValSaisie).BackColor = ChiffreOffColor
        iValSaisie = 0
        valSaisie = "1"
        BTC(iValSaisie).BackColor = ChiffreOnColor

    End Sub

    Private Sub BT_2_Click(sender As Object, e As EventArgs) Handles BT_2.Click
        BTC(iValSaisie).BackColor = ChiffreOffColor
        iValSaisie = 1
        valSaisie = "2"
        BTC(iValSaisie).BackColor = ChiffreOnColor

    End Sub

    Private Sub BT_3_Click(sender As Object, e As EventArgs) Handles BT_3.Click

        BTC(iValSaisie).BackColor = ChiffreOffColor
        iValSaisie = 2
        valSaisie = "3"
        BTC(iValSaisie).BackColor = ChiffreOnColor

    End Sub

    Private Sub BT_4_Click(sender As Object, e As EventArgs) Handles BT_4.Click

        BTC(iValSaisie).BackColor = ChiffreOffColor
        iValSaisie = 3
        valSaisie = "4"
        BTC(iValSaisie).BackColor = ChiffreOnColor

    End Sub

    Private Sub BT_5_Click(sender As Object, e As EventArgs) Handles BT_5.Click

        BTC(iValSaisie).BackColor = ChiffreOffColor
        iValSaisie = 4
        valSaisie = "5"
        BTC(iValSaisie).BackColor = ChiffreOnColor

    End Sub

    Private Sub BT_6_Click(sender As Object, e As EventArgs) Handles BT_6.Click

        BTC(iValSaisie).BackColor = ChiffreOffColor
        iValSaisie = 5
        valSaisie = "6"
        BTC(iValSaisie).BackColor = ChiffreOnColor

    End Sub

    Private Sub BT_7_Click(sender As Object, e As EventArgs) Handles BT_7.Click

        BTC(iValSaisie).BackColor = ChiffreOffColor
        iValSaisie = 6
        valSaisie = "7"
        BTC(iValSaisie).BackColor = ChiffreOnColor

    End Sub

    Private Sub BT_8_Click(sender As Object, e As EventArgs) Handles BT_8.Click

        BTC(iValSaisie).BackColor = ChiffreOffColor
        iValSaisie = 7
        valSaisie = "8"
        BTC(iValSaisie).BackColor = ChiffreOnColor

    End Sub

    Private Sub BT_9_Click(sender As Object, e As EventArgs) Handles BT_9.Click

        BTC(iValSaisie).BackColor = ChiffreOffColor
        iValSaisie = 8
        valSaisie = "9"
        BTC(iValSaisie).BackColor = ChiffreOnColor

    End Sub

    Private Sub BT_Clear_Click(sender As Object, e As EventArgs) Handles BT_Clear.Click

        BTC(iValSaisie).BackColor = ChiffreOffColor
        iValSaisie = 9
        valSaisie = " "
        BTC(iValSaisie).BackColor = ChiffreOnColor

    End Sub

    '============================================================================================================================================================
    '
    '                                        B O U T O N S   D E   L A   G R I L L E
    '
    '============================================================================================================================================================

    Private Sub BT00_Click(sender As Object, e As EventArgs) Handles BT00.Click
        iBT = 0
        jBT = 0
        CtlBT()
    End Sub

    Private Sub BT01_Click(sender As Object, e As EventArgs) Handles BT01.Click
        iBT = 0
        jBT = 1
        CtlBT()
    End Sub

    Private Sub BT02_Click(sender As Object, e As EventArgs) Handles BT02.Click
        iBT = 0
        jBT = 2
        CtlBT()
    End Sub

    Private Sub BT03_Click(sender As Object, e As EventArgs) Handles BT03.Click
        iBT = 0
        jBT = 3
        CtlBT()
    End Sub

    Private Sub BT04_Click(sender As Object, e As EventArgs) Handles BT04.Click
        iBT = 0
        jBT = 4
        CtlBT()
    End Sub

    Private Sub BT05_Click(sender As Object, e As EventArgs) Handles BT05.Click
        iBT = 0
        jBT = 5
        CtlBT()
    End Sub

    Private Sub BT06_Click(sender As Object, e As EventArgs) Handles BT06.Click
        iBT = 0
        jBT = 6
        CtlBT()
    End Sub

    Private Sub BT07_Click(sender As Object, e As EventArgs) Handles BT07.Click
        iBT = 0
        jBT = 7
        CtlBT()
    End Sub

    Private Sub BT08_Click(sender As Object, e As EventArgs) Handles BT08.Click
        iBT = 0
        jBT = 8
        CtlBT()
    End Sub

    Private Sub BT09_Click(sender As Object, e As EventArgs) Handles BT09.Click
        iBT = 1
        jBT = 0
        CtlBT()
    End Sub

    Private Sub BT10_Click(sender As Object, e As EventArgs) Handles BT10.Click
        iBT = 1
        jBT = 1
        CtlBT()
    End Sub

    Private Sub BT11_Click(sender As Object, e As EventArgs) Handles BT11.Click
        iBT = 1
        jBT = 2
        CtlBT()
    End Sub

    Private Sub BT12_Click(sender As Object, e As EventArgs) Handles BT12.Click
        iBT = 1
        jBT = 3
        CtlBT()
    End Sub

    Private Sub BT13_Click(sender As Object, e As EventArgs) Handles BT13.Click
        iBT = 1
        jBT = 4
        CtlBT()
    End Sub

    Private Sub BT14_Click(sender As Object, e As EventArgs) Handles BT14.Click
        iBT = 1
        jBT = 5
        CtlBT()
    End Sub

    Private Sub BT15_Click(sender As Object, e As EventArgs) Handles BT15.Click
        iBT = 1
        jBT = 6
        CtlBT()
    End Sub

    Private Sub BT16_Click(sender As Object, e As EventArgs) Handles BT16.Click
        iBT = 1
        jBT = 7
        CtlBT()
    End Sub

    Private Sub BT17_Click(sender As Object, e As EventArgs) Handles BT17.Click
        iBT = 1
        jBT = 8
        CtlBT()
    End Sub

    Private Sub BT18_Click(sender As Object, e As EventArgs) Handles BT18.Click
        iBT = 2
        jBT = 0
        CtlBT()
    End Sub

    Private Sub BT19_Click(sender As Object, e As EventArgs) Handles BT19.Click
        iBT = 2
        jBT = 1
        CtlBT()
    End Sub

    Private Sub BT20_Click(sender As Object, e As EventArgs) Handles BT20.Click
        iBT = 2
        jBT = 2
        CtlBT()
    End Sub

    Private Sub BT21_Click(sender As Object, e As EventArgs) Handles BT21.Click
        iBT = 2
        jBT = 3
        CtlBT()
    End Sub

    Private Sub BT22_Click(sender As Object, e As EventArgs) Handles BT22.Click
        iBT = 2
        jBT = 4
        CtlBT()
    End Sub

    Private Sub BT23_Click(sender As Object, e As EventArgs) Handles BT23.Click
        iBT = 2
        jBT = 5
        CtlBT()
    End Sub

    Private Sub BT24_Click(sender As Object, e As EventArgs) Handles BT24.Click
        iBT = 2
        jBT = 6
        CtlBT()
    End Sub

    Private Sub BT25_Click(sender As Object, e As EventArgs) Handles BT25.Click
        iBT = 2
        jBT = 7
        CtlBT()
    End Sub

    Private Sub BT26_Click(sender As Object, e As EventArgs) Handles BT26.Click
        iBT = 2
        jBT = 8
        CtlBT()
    End Sub

    Private Sub BT27_Click(sender As Object, e As EventArgs) Handles BT27.Click
        iBT = 3
        jBT = 0
        CtlBT()
    End Sub

    Private Sub BT28_Click(sender As Object, e As EventArgs) Handles BT28.Click
        iBT = 3
        jBT = 1
        CtlBT()
    End Sub

    Private Sub BT29_Click(sender As Object, e As EventArgs) Handles BT29.Click
        iBT = 3
        jBT = 2
        CtlBT()
    End Sub

    Private Sub BT30_Click(sender As Object, e As EventArgs) Handles BT30.Click
        iBT = 3
        jBT = 3
        CtlBT()
    End Sub

    Private Sub BT31_Click(sender As Object, e As EventArgs) Handles BT31.Click
        iBT = 3
        jBT = 4
        CtlBT()
    End Sub

    Private Sub BT32_Click(sender As Object, e As EventArgs) Handles BT32.Click
        iBT = 3
        jBT = 5
        CtlBT()
    End Sub

    Private Sub BT33_Click(sender As Object, e As EventArgs) Handles BT33.Click
        iBT = 3
        jBT = 6
        CtlBT()
    End Sub

    Private Sub BT34_Click(sender As Object, e As EventArgs) Handles BT34.Click
        iBT = 3
        jBT = 7
        CtlBT()
    End Sub

    Private Sub BT35_Click(sender As Object, e As EventArgs) Handles BT35.Click
        iBT = 3
        jBT = 8
        CtlBT()
    End Sub

    Private Sub Bt36_Click(sender As Object, e As EventArgs) Handles Bt36.Click
        iBT = 4
        jBT = 0
        CtlBT()
    End Sub

    Private Sub BT37_Click(sender As Object, e As EventArgs) Handles BT37.Click
        iBT = 4
        jBT = 1
        CtlBT()
    End Sub

    Private Sub BT38_Click(sender As Object, e As EventArgs) Handles BT38.Click
        iBT = 4
        jBT = 2
        CtlBT()
    End Sub

    Private Sub BT39_Click(sender As Object, e As EventArgs) Handles BT39.Click
        iBT = 4
        jBT = 3
        CtlBT()
    End Sub

    Private Sub BT40_Click(sender As Object, e As EventArgs) Handles BT40.Click
        iBT = 4
        jBT = 4
        CtlBT()
    End Sub

    Private Sub BT41_Click(sender As Object, e As EventArgs) Handles BT41.Click
        iBT = 4
        jBT = 5
        CtlBT()
    End Sub

    Private Sub BT42_Click(sender As Object, e As EventArgs) Handles BT42.Click
        iBT = 4
        jBT = 6
        CtlBT()
    End Sub

    Private Sub BT43_Click(sender As Object, e As EventArgs) Handles BT43.Click
        iBT = 4
        jBT = 7
        CtlBT()
    End Sub

    Private Sub BT44_Click(sender As Object, e As EventArgs) Handles BT44.Click
        iBT = 4
        jBT = 8
        CtlBT()
    End Sub

    Private Sub BT45_Click(sender As Object, e As EventArgs) Handles BT45.Click
        iBT = 5
        jBT = 0
        CtlBT()
    End Sub

    Private Sub BT46_Click(sender As Object, e As EventArgs) Handles BT46.Click
        iBT = 5
        jBT = 1
        CtlBT()
    End Sub

    Private Sub BT47_Click(sender As Object, e As EventArgs) Handles BT47.Click
        iBT = 5
        jBT = 2
        CtlBT()
    End Sub

    Private Sub BT48_Click(sender As Object, e As EventArgs) Handles BT48.Click
        iBT = 5
        jBT = 3
        CtlBT()
    End Sub

    Private Sub BT49_Click(sender As Object, e As EventArgs) Handles BT49.Click
        iBT = 5
        jBT = 4
        CtlBT()
    End Sub

    Private Sub BT50_Click(sender As Object, e As EventArgs) Handles BT50.Click
        iBT = 5
        jBT = 5
        CtlBT()
    End Sub

    Private Sub BT51_Click(sender As Object, e As EventArgs) Handles BT51.Click
        iBT = 5
        jBT = 6
        CtlBT()
    End Sub

    Private Sub BT52_Click(sender As Object, e As EventArgs) Handles BT52.Click
        iBT = 5
        jBT = 7
        CtlBT()
    End Sub

    Private Sub BT53_Click(sender As Object, e As EventArgs) Handles BT53.Click
        iBT = 5
        jBT = 8
        CtlBT()
    End Sub

    Private Sub BT54_Click(sender As Object, e As EventArgs) Handles BT54.Click
        iBT = 6
        jBT = 0
        CtlBT()
    End Sub

    Private Sub BT55_Click(sender As Object, e As EventArgs) Handles BT55.Click
        iBT = 6
        jBT = 1
        CtlBT()
    End Sub

    Private Sub BT56_Click(sender As Object, e As EventArgs) Handles BT56.Click
        iBT = 6
        jBT = 2
        CtlBT()
    End Sub

    Private Sub BT57_Click(sender As Object, e As EventArgs) Handles BT57.Click
        iBT = 6
        jBT = 3
        CtlBT()
    End Sub

    Private Sub BT58_Click(sender As Object, e As EventArgs) Handles BT58.Click
        iBT = 6
        jBT = 4
        CtlBT()
    End Sub

    Private Sub Bt59_Click(sender As Object, e As EventArgs) Handles Bt59.Click
        iBT = 6
        jBT = 5
        CtlBT()
    End Sub

    Private Sub BT60_Click(sender As Object, e As EventArgs) Handles BT60.Click
        iBT = 6
        jBT = 6
        CtlBT()
    End Sub

    Private Sub BT61_Click(sender As Object, e As EventArgs) Handles BT61.Click
        iBT = 6
        jBT = 7
        CtlBT()
    End Sub

    Private Sub BT62_Click(sender As Object, e As EventArgs) Handles BT62.Click
        iBT = 6
        jBT = 8
        CtlBT()
    End Sub

    Private Sub BT63_Click(sender As Object, e As EventArgs) Handles BT63.Click
        iBT = 7
        jBT = 0
        CtlBT()
    End Sub

    Private Sub BT64_Click(sender As Object, e As EventArgs) Handles BT64.Click
        iBT = 7
        jBT = 1
        CtlBT()
    End Sub

    Private Sub BT65_Click(sender As Object, e As EventArgs) Handles BT65.Click
        iBT = 7
        jBT = 2
        CtlBT()
    End Sub

    Private Sub BT66_Click(sender As Object, e As EventArgs) Handles BT66.Click
        iBT = 7
        jBT = 3
        CtlBT()
    End Sub

    Private Sub BT67_Click(sender As Object, e As EventArgs) Handles BT67.Click
        iBT = 7
        jBT = 4
        CtlBT()
    End Sub

    Private Sub BT68_Click(sender As Object, e As EventArgs) Handles BT68.Click
        iBT = 7
        jBT = 5
        CtlBT()
    End Sub

    Private Sub BT69_Click(sender As Object, e As EventArgs) Handles BT69.Click
        iBT = 7
        jBT = 6
        CtlBT()
    End Sub

    Private Sub BT70_Click(sender As Object, e As EventArgs) Handles BT70.Click
        iBT = 7
        jBT = 7
        CtlBT()
    End Sub

    Private Sub BT71_Click(sender As Object, e As EventArgs) Handles BT71.Click
        iBT = 7
        jBT = 8
        CtlBT()
    End Sub

    Private Sub BT72_Click(sender As Object, e As EventArgs) Handles BT72.Click
        iBT = 8
        jBT = 0
        CtlBT()
    End Sub

    Private Sub BT73_Click(sender As Object, e As EventArgs) Handles BT73.Click
        iBT = 8
        jBT = 1
        CtlBT()
    End Sub

    Private Sub BT74_Click(sender As Object, e As EventArgs) Handles BT74.Click
        iBT = 8
        jBT = 2
        CtlBT()
    End Sub

    Private Sub BT75_Click(sender As Object, e As EventArgs) Handles BT75.Click
        iBT = 8
        jBT = 3
        CtlBT()
    End Sub

    Private Sub BT76_Click(sender As Object, e As EventArgs) Handles BT76.Click
        iBT = 8
        jBT = 4
        CtlBT()
    End Sub

    Private Sub BT77_Click(sender As Object, e As EventArgs) Handles BT77.Click
        iBT = 8
        jBT = 5
        CtlBT()
    End Sub

    Private Sub BT78_Click(sender As Object, e As EventArgs) Handles BT78.Click
        iBT = 8
        jBT = 6
        CtlBT()
    End Sub

    Private Sub BT79_Click(sender As Object, e As EventArgs) Handles BT79.Click
        iBT = 8
        jBT = 7
        CtlBT()
    End Sub

    Private Sub BT80_Click(sender As Object, e As EventArgs) Handles BT80.Click
        iBT = 8
        jBT = 8
        CtlBT()
    End Sub


    Private Sub CtlBT()
        If mode = "Saisie" Or mode = "Jouer" Then
            For i = 0 To 8
                For j = 0 To 8
                    BT(i, j).BackColor = colorIni(i, j)
                Next
            Next

            With Me.BT(iBT, jBT)
                .Text = valSaisie
                .Font = grandeFont
                .ForeColor = Color.Black
                .BackColor = colorIni(iBT, jBT)
                .Enabled = True
            End With
            If valSaisie = " " Then
                Grille(iBT, jBT) = "0"
            Else
                Grille(iBT, jBT) = valSaisie
            End If
            ControleSaisie(Erreur, ErreurGrille, Grille, Candidats)
            Affichage()
        End If

    End Sub

    '============================================================================== F I N ===================================================================== 
#End Region


End Class
