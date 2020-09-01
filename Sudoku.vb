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
    Dim valSaisie As Integer
    Dim iValSaisie As Integer = 0

    Dim i As Integer = 0
    Dim j As Integer = 0
    Dim v As Integer
    Dim k As Integer = 0
    Dim g As Integer = 0

    Dim Grille(8, 8) As Integer ' La grille de Sudoku
    Dim GrilleInitiale(8, 8) As Integer ' La grille en début de partie
    Public GrilleFinale(8, 8) As Integer ' La grille en fin de partie
    Dim SolutionExiste As Boolean
    Dim opk(8, 8) As Integer ' Nombre de candidats de k par case
    Dim nuplet(8, 8) As String 'Candidats agrégés

    Dim Candidats(8, 8, 8) As Integer ' La grille des candidats ( Valeurs au crayon)
    Dim NbVal As Integer = 0
    Dim NbValInitial As Integer = 0
    Dim NbvalMax As Integer = 0

    Structure StrHistorique
        Dim i As Integer
        Dim j As Integer
        Dim v As Integer
    End Structure

    Public Historique(80) As StrHistorique

    Structure StrAnalyse
        Dim n As Integer ' occurrences par case
        Dim i As Integer
        Dim j As Integer
        Dim k As Integer
        Dim v As Integer
    End Structure

    Structure StrSolution
        Dim i As Integer
        Dim j As Integer
        Dim v As Integer 'Valeur
        Dim m As String 'Motif
        Dim b As Integer 'Barème
    End Structure

    Public Solution As New Sudoku.StrSolution
    Public QSol As Queue(Of Sudoku.StrSolution) = New Queue(Of Sudoku.StrSolution)

    Structure CandidatsRetenus
        Dim i() As Integer
        Dim j() As Integer
        Dim k() As Integer
        Dim v() As Integer
    End Structure

    Structure CandidatsEliminés
        Dim i() As Integer
        Dim j() As Integer
        Dim k() As Integer
        Dim v() As Integer
    End Structure

    Structure StrSmp ' Simplification 
        Dim motif As String 'Motif
        Dim act As Boolean
        'candidats retenus (ReDim 20) 
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
        Dim v() As Integer
    End Structure

    Dim Libel As String
    Public myFileNname As String
    Dim Erreur As Boolean
    Dim ErreurGrille(8, 8) As String
    Dim SegmentCandidats(8, 8) As String
    Dim NbSol As Integer
    Dim NbrLoop As Integer

    Public pileGrilles(81, 8, 8) As Integer ' La grille de Sudoku à chaque tour

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
    Dim CaseCandidats As String
    Dim TextSudoku As String = "                                                                                 "

    Public Generator As System.Random = New System.Random()


#End Region
    '============================================================================================================================================================
    '                                                             L O A D E R 
    '============================================================================================================================================================
    '

    Private Sub Sudoku_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim c As Integer

        BTForceBrute.Enabled = False
        BTStepByStep.Enabled = False
        BTPossibilités.Enabled = False
        BTEnregistrer.Enabled = False
        BTRecommencer.Enabled = False
        BTPrécédent.Enabled = False
        BTSuivant.Enabled = False
        BTTerminé.Enabled = False
        Me.KeyPreview = True
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
        BT(6, 5) = Me.BT59
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

#End Region


#Region "Affichages"

    '============================================================================================================================================================
    '
    '                                                             A F F I C H A G E S 
    '
    '============================================================================================================================================================

    Sub Affichage()

        If NbVal > NbValInitial Then
            BTPrécédent.Enabled = True
        Else
            BTPrécédent.Enabled = False
        End If

        If NbVal >= NbvalMax Then
            BTSuivant.Enabled = False
        Else
            BTSuivant.Enabled = True
        End If

        For i = 0 To 8
            For j = 0 To 8
                With Me.BT(i, j)
                    .BackColor = colorIni(i, j)
                End With
                If ErreurGrille(i, j) = "X" Or ErreurGrille(i, j) = "Y" Then
                    With Me.BT(i, j)
                        .Text = Grille(i, j).ToString
                        .Font = grandeFont
                        .ForeColor = Color.Black
                        .BackColor = Color.Red
                    End With
                Else
                    If Grille(i, j) = "0" Then
                        If modeCandidat Then
                            With Me.BT(i, j)
                                CaseCandidats =
                            Candidats(i, j, 0).ToString & " " & Candidats(i, j, 1).ToString & " " & Candidats(i, j, 2).ToString & Environment.NewLine &
                            Candidats(i, j, 3).ToString & " " & Candidats(i, j, 4).ToString & " " & Candidats(i, j, 5).ToString & Environment.NewLine &
                            Candidats(i, j, 6).ToString & " " & Candidats(i, j, 7).ToString & " " & Candidats(i, j, 8).ToString
                                CaseCandidats = CaseCandidats.Replace("0", " ")
                                .Text = CaseCandidats
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
                            .Text = Grille(i, j).ToString
                            .Font = grandeFont
                            .ForeColor = Color.Black
                            .BackColor = colorIni(i, j)
                            If GrilleInitiale(i, j) = 0 Or mode = "Saisie" Then
                                .Enabled = True
                            Else
                                .Enabled = False
                            End If
                        End With
                    End If
                End If
            Next
        Next

        LBL_nbVal.Text = "Cases remplies : " & NbVal.ToString
        Boucles.Text = "Nombre de boucles : " & NbrLoop.ToString

    End Sub

    '============================================================================================================================================================
    ' Pour afficher tous les candidats         
    '============================================================================================================================================================

    Sub RaffraichiGrille()

        For i = 0 To 8
            For j = 0 To 8
                If Grille(i, j) = 0 Then
                    AfficheCandidats(i, j)
                End If
            Next
        Next

    End Sub

    Sub AfficheCandidats(i, j)

        With Me.BT(i, j)
            CaseCandidats =
                            Candidats(i, j, 0).ToString & " " & Candidats(i, j, 1).ToString & " " & Candidats(i, j, 2).ToString & Environment.NewLine &
                            Candidats(i, j, 3).ToString & " " & Candidats(i, j, 4).ToString & " " & Candidats(i, j, 5).ToString & Environment.NewLine &
                            Candidats(i, j, 6).ToString & " " & Candidats(i, j, 7).ToString & " " & Candidats(i, j, 8).ToString
            CaseCandidats = CaseCandidats.Replace("0", " ")
            .Text = CaseCandidats
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
    ' -  M E N U   Q U I T T E R 
    '============================================================================================================================================================

    Private Sub QuitterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitterToolStripMenuItem.Click

        Me.Close()

    End Sub

    '============================================================================================================================================================
    ' -  M E N U   O U V R I R   F I C H I E R  - voir toolstrip
    '============================================================================================================================================================

    Private Sub ChToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChToolStripMenuItem.Click

        mode = "Charger"
        FonctionOuvrirFichier()

    End Sub

    '============================================================================================================================================================
    ' -  M E N U   E N R E G I S T R E R   F I C H I E R  - voir toolstrip
    '============================================================================================================================================================

    Private Sub SauvegarderUneGrilleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SauvegarderUneGrilleToolStripMenuItem.Click

        FonctionSauvegarderFichier()

    End Sub

    '============================================================================================================================================================
    ' -  M E N U   S A I S I E - voir toolstrip
    '============================================================================================================================================================

    Private Sub SaisieToolStripMenuItem1_Click_1(sender As Object, e As EventArgs) Handles SaisieToolStripMenuItem1.Click

        FonctionSaisie()

    End Sub

    '============================================================================================================================================================
    ' -  M E N U   G E N E R E R  - voir toolstrip
    '============================================================================================================================================================

    Private Sub GénérerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GénérerToolStripMenuItem.Click

        FonctionGénérer()

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
    ' -  T O O L S T R I P   S A I S I E 
    '============================================================================================================================================================

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
                Grille(i, j) = 0
                For k = 0 To 8
                    Candidats(i, j, k) = 0
                Next
            Next
        Next

        NbVal = 0

    End Sub

    '============================================================================================================================================================
    ' -  T O O L S T R I P   G E N E R E R  
    '============================================================================================================================================================

    Private Sub GénérerToolStripButton_Click(sender As Object, e As EventArgs) Handles GénérerToolStripButton.Click

        FonctionGénérer()

    End Sub


    Sub FonctionGénérer()

        mode = "Générer"
        NbrLoop = 0
        Générateur.Générateur(Grille, NbrLoop)
        '    Problème.Problème(typeGrille, NbVal, Grille, Candidats, NbrLoop)

        Affichage()
        FonctionJouer()

    End Sub

    '============================================================================================================================================================
    ' -  T O O L S T R I P   O U V R I R   F I C H I E R   -   C H A R G E R   U N E   G R I L L E
    '============================================================================================================================================================

    Private Sub OuvrirToolStripButton_Click(sender As Object, e As EventArgs) Handles OuvrirToolStripButton.Click

        mode = "Ouvrir"
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
            LectureGrille(Grille, fichierCorrrect)
            If fichierCorrrect Then
            Else
                MsgBox("Fichier corrompu ou format invalide")
                Exit Sub
            End If

        End If
        NbVal = 0
        For i = 0 To 8
            For j = 0 To 8
                If Grille(i, j) = 0 Then
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

        CalculCandidats(Grille, Candidats)
        ControleSaisie(Erreur, ErreurGrille, Grille, Candidats) 'Vérifie la validité de la grille
        LBL_Conseil.Text = ""
        Affichage()
        FonctionJouer()


    End Sub

    '============================================================================================================================================================
    ' -  T O O L S T R I P   S A U V E G A R D E R    F I C H I E R 
    '============================================================================================================================================================

    Private Sub EnregistrerToolStripButton_Click_1(sender As Object, e As EventArgs) Handles BTEnregistrer.Click

        FonctionSauvegarderFichier()

    End Sub

    Sub FonctionSauvegarderFichier()

        Array.Copy(Grille, GrilleFinale, 81)
        ForceBrute.ForceBrute(GrilleFinale, NbSol, nbrLoop)

        If NbSol = 1 Then
            ' Grille valide
        Else
            If NbSol = 0 Then
                MsgBox("Cette grille n'a pas de solution")
            Else
                MsgBox("Cette grille admet plusieurs solutions")
            End If
            Exit Sub
        End If


        Dim fichierCorrrect As Boolean
        'Boîte de dialogue de sauvegarde de fichier
        ' avec limitation dans les extensions de fichier
        Dim SaveFileDialog As New SaveFileDialog With {
            .Filter = "Fichier sudoku (*.sud)|*.sud",
            .FileName = myFileNname,
            .RestoreDirectory = True
        }


        If SaveFileDialog.ShowDialog() = DialogResult.OK Then
            myFileNname = SaveFileDialog.FileName
            EcritureGrille(GrilleInitiale, fichierCorrrect)
            If fichierCorrrect Then
            Else
                MsgBox("Echec de l'écriture du fichier")
                Exit Sub
            End If
        End If

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
                If Grille(i, j) <> 0 Then
                    With Me.BT(i, j)
                        .Enabled = False
                    End With
                End If
            Next
        Next

        For i = 0 To 80
            Historique(i).i = iBT
            Historique(i).j = jBT
            Historique(i).v = 0
        Next

        Array.Copy(Grille, GrilleInitiale, 81)
        NbValInitial = NbVal

        NbrLoop = 0
        Array.Copy(Grille, GrilleFinale, 81)
        ForceBrute.ForceBrute(GrilleFinale, NbSol, NbrLoop)

        If NbSol = 1 Then
            BTForceBrute.Enabled = True
            BTStepByStep.Enabled = True
            BTPossibilités.Enabled = True
            BTRecommencer.Enabled = True
            BTEnregistrer.Enabled = True
            BTPrécédent.Enabled = True
            BTSuivant.Enabled = True
            BTTerminé.Enabled = True
            CalculCandidats(Grille, Candidats)
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
    ' -  T O O L S T R I P    R E C O M M E N C E R 
    '============================================================================================================================================================

    Private Sub RecommencerToolStripButton_Click(sender As Object, e As EventArgs) Handles BTRecommencer.Click

        Dim Msg, Style, Title, Response
        Msg = "Etes vous sûr de vouloir recommencer la partie ?"  ' Define message.
        Style = vbYesNo + vbQuestion + vbDefaultButton2    ' Define buttons.
        Title = ""    ' Define title.


        Response = MsgBox(Msg, Style, Title)

        If Response = vbNo Then    ' User chose No.
            Exit Sub
        End If

        Array.Copy(GrilleInitiale, Grille, 81)
        NbVal = NbValInitial

        CalculCandidats(Grille, Candidats)
        ControleSaisie(Erreur, ErreurGrille, Grille, Candidats) 'Vérifie la validité de la grille
        LBL_Conseil.Text = ""
        modeCandidat = False

        FonctionJouer()

    End Sub

    '============================================================================================================================================================
    ' -  T O O L S T R I P   P R E C E D E N T   
    '============================================================================================================================================================

    Private Sub BTPrécédent_Click(sender As Object, e As EventArgs) Handles BTPrécédent.Click

        If NbVal > NbValInitial Then
            i = Historique(NbVal).i
            j = Historique(NbVal).j
            Grille(i, j) = 0
            CalculCandidats(Grille, Candidats)
            NbVal -= 1
            Affichage()
        End If

    End Sub

    '============================================================================================================================================================
    ' -  T O O L S T R I P   S U I V A N T
    '============================================================================================================================================================

    Private Sub BTSuivant_Click(sender As Object, e As EventArgs) Handles BTSuivant.Click

        If NbVal < NbvalMax Then
            NbVal += 1
            i = Historique(NbVal).i
            j = Historique(NbVal).j
            Grille(i, j) = Historique(NbVal).v
            RecalculCandidats(iBT, jBT, Grille, Candidats) ' Efface les candidats éliminés par la solution appliquée 
            Affichage()
        End If

    End Sub
    '============================================================================================================================================================
    ' -  T O O L S T R I P   G R I L L E   T E R M I N E E  
    '============================================================================================================================================================

    Private Sub BTTerminé_Click(sender As Object, e As EventArgs) Handles BTTerminé.Click

        Dim Msg, Style, Title, Response
        Msg = "Etes vous sûr de vouloir révéler la solution ?"  ' Define message.
        Style = vbYesNo + vbQuestion + vbDefaultButton2    ' Define buttons.
        Title = ""    ' Define title.

        Response = MsgBox(Msg, Style, Title)

        If Response = vbNo Then    ' User chose No.
            Exit Sub
        End If

        Array.Copy(Grille, GrilleFinale, 81)
        ForceBrute.ForceBrute(GrilleFinale, NbSol, NbrLoop)

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


#End Region

#Region "Boutons"

    '============================================================================================================================================================
    '
    '                                                             B O U T O N S 
    '
    '============================================================================================================================================================


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

                LBL_Conseil.Text = Solution.m

                With Me.BT(i, j)
                    .BackColor = Color.Plum
                End With

                If stepByStepApply Then
                    AppliqueUneSolution(QSol, Grille, Candidats, i, j, v, NbVal)
                    If NbVal > NbvalMax Then
                        NbvalMax = NbVal
                    End If
                    BTPrécédent.Enabled = True
                    With Me.BT(i, j)
                        .Text = v
                        .Font = grandeFont
                        .BackColor = Color.Plum
                        .Enabled = True
                    End With

                    LBL_nbVal.Text = "Cases remplies : " & NbVal.ToString
                Else
                    With Me.BT(i, j)
                        CaseCandidats =
                            Candidats(i, j, 0).ToString & " " & Candidats(i, j, 1).ToString & " " & Candidats(i, j, 2).ToString & Environment.NewLine &
                            Candidats(i, j, 3).ToString & " " & Candidats(i, j, 4).ToString & " " & Candidats(i, j, 5).ToString & Environment.NewLine &
                            Candidats(i, j, 6).ToString & " " & Candidats(i, j, 7).ToString & " " & Candidats(i, j, 8).ToString
                        CaseCandidats = CaseCandidats.Replace("0", " ")
                        .Text = CaseCandidats
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
                If Grille(i, j) = 0 Then
                    If modeCandidat Then
                        With Me.BT(i, j)
                            CaseCandidats =
                            Candidats(i, j, 0).ToString & " " & Candidats(i, j, 1).ToString & " " & Candidats(i, j, 2).ToString & Environment.NewLine &
                            Candidats(i, j, 3).ToString & " " & Candidats(i, j, 4).ToString & " " & Candidats(i, j, 5).ToString & Environment.NewLine &
                            Candidats(i, j, 6).ToString & " " & Candidats(i, j, 7).ToString & " " & Candidats(i, j, 8).ToString
                            CaseCandidats = CaseCandidats.Replace("0", " ")
                            .Text = CaseCandidats
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

    Private Sub BTForceBrute_Click(sender As Object, e As EventArgs) Handles BTForceBrute.Click

        Array.Copy(Grille, GrilleFinale, 81)
        ForceBrute.ForceBrute(GrilleFinale, NbSol, NbrLoop)

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
    '  - - Affichage des solutions
    '============================================================================================================================================================

    Private Sub BTPossibilités_Click(sender As Object, e As EventArgs) Handles BTPossibilités.Click

        QSol.Clear()
        TsmpClear(NbrSmp, TSmp)
        RechercheSolution(Grille, Candidats, QSol, NbrSmp, TSmp, NbVal)

        If QSol.Count > 0 Then
            Solutions.Show()
        End If

        If NbrSmp > 0 Then
            Simplifications.Show()
        End If

    End Sub


    '============================================================================================================================================================
    '
    '                                        B O U T O N S   D E   S A I S I E
    '
    '============================================================================================================================================================

    Private Sub BT_1_Click(sender As Object, e As EventArgs) Handles BT_1.Click

        If iValSaisie = 0 And valSaisie <> 0 Then
            BTC(iValSaisie).BackColor = ChiffreOffColor
            valSaisie = 0
        Else
            BTC(iValSaisie).BackColor = ChiffreOffColor
            iValSaisie = 0
            valSaisie = 1
            BTC(iValSaisie).BackColor = ChiffreOnColor
        End If

    End Sub

    Private Sub BT_2_Click(sender As Object, e As EventArgs) Handles BT_2.Click

        If iValSaisie = 1 And valSaisie <> 0 Then
            BTC(iValSaisie).BackColor = ChiffreOffColor
            valSaisie = 0
        Else
            BTC(iValSaisie).BackColor = ChiffreOffColor
            iValSaisie = 1
            valSaisie = 2
            BTC(iValSaisie).BackColor = ChiffreOnColor
        End If

    End Sub

    Private Sub BT_3_Click(sender As Object, e As EventArgs) Handles BT_3.Click

        If iValSaisie = 2 And valSaisie <> 0 Then
            BTC(iValSaisie).BackColor = ChiffreOffColor
            valSaisie = 0
        Else
            BTC(iValSaisie).BackColor = ChiffreOffColor
            iValSaisie = 2
            valSaisie = 3
            BTC(iValSaisie).BackColor = ChiffreOnColor
        End If

    End Sub

    Private Sub BT_4_Click(sender As Object, e As EventArgs) Handles BT_4.Click

        If iValSaisie = 3 And valSaisie <> 0 Then
            BTC(iValSaisie).BackColor = ChiffreOffColor
            valSaisie = 0
        Else
            BTC(iValSaisie).BackColor = ChiffreOffColor
            iValSaisie = 3
            valSaisie = 4
            BTC(iValSaisie).BackColor = ChiffreOnColor
        End If
    End Sub

    Private Sub BT_5_Click(sender As Object, e As EventArgs) Handles BT_5.Click

        If iValSaisie = 4 And valSaisie <> 0 Then
            BTC(iValSaisie).BackColor = ChiffreOffColor
            valSaisie = 0
        Else
            BTC(iValSaisie).BackColor = ChiffreOffColor
            iValSaisie = 4
            valSaisie = 5
            BTC(iValSaisie).BackColor = ChiffreOnColor
        End If

    End Sub

    Private Sub BT_6_Click(sender As Object, e As EventArgs) Handles BT_6.Click

        If iValSaisie = 5 And valSaisie <> 0 Then
            BTC(iValSaisie).BackColor = ChiffreOffColor
            valSaisie = 0
        Else
            BTC(iValSaisie).BackColor = ChiffreOffColor
            iValSaisie = 5
            valSaisie = 6
            BTC(iValSaisie).BackColor = ChiffreOnColor
        End If

    End Sub

    Private Sub BT_7_Click(sender As Object, e As EventArgs) Handles BT_7.Click

        If iValSaisie = 6 And valSaisie <> 0 Then
            BTC(iValSaisie).BackColor = ChiffreOffColor
            valSaisie = 0
        Else
            BTC(iValSaisie).BackColor = ChiffreOffColor
            iValSaisie = 6
            valSaisie = 7
            BTC(iValSaisie).BackColor = ChiffreOnColor
        End If

    End Sub

    Private Sub BT_8_Click(sender As Object, e As EventArgs) Handles BT_8.Click

        If iValSaisie = 7 And valSaisie <> 0 Then
            BTC(iValSaisie).BackColor = ChiffreOffColor
            valSaisie = 0
        Else
            BTC(iValSaisie).BackColor = ChiffreOffColor
            iValSaisie = 7
            valSaisie = 8
            BTC(iValSaisie).BackColor = ChiffreOnColor
        End If

    End Sub

    Private Sub BT_9_Click(sender As Object, e As EventArgs) Handles BT_9.Click

        If iValSaisie = 8 And valSaisie <> 0 Then
            BTC(iValSaisie).BackColor = ChiffreOffColor
            valSaisie = 0
        Else
            BTC(iValSaisie).BackColor = ChiffreOffColor
            iValSaisie = 8
            valSaisie = 9
            BTC(iValSaisie).BackColor = ChiffreOnColor
        End If

    End Sub

    Private Sub BT_Clear_Click(sender As Object, e As EventArgs) Handles BT_Clear.Click

        If iValSaisie = 9 And valSaisie <> 0 Then
            BTC(iValSaisie).BackColor = ChiffreOffColor
            valSaisie = 0
        Else
            BTC(iValSaisie).BackColor = ChiffreOffColor
            iValSaisie = 9
            valSaisie = 0
            BTC(iValSaisie).BackColor = ChiffreOnColor
        End If

    End Sub

    '============================================================================================================================================================
    '============================================================================================================================================================
    '
    '                                        B O U T O N S   D E   L A   G R I L L E   &   S O U R I S
    '
    '============================================================================================================================================================
    '============================================================================================================================================================

    Private Sub BT00_Click(sender As Object, e As EventArgs) Handles BT00.Click
        iBT = 0
        jBT = 0
        CtlBT()
    End Sub

    Private Sub BT00_MouseEnter(sender As Object, e As EventArgs) Handles BT00.MouseEnter
        iBT = 0
        jBT = 0
        EntréeSouris()
    End Sub

    Private Sub BT00_MouseLeave(sender As Object, e As EventArgs) Handles BT00.MouseLeave
        iBT = 0
        jBT = 0
        SortieSouris()
    End Sub

    Private Sub BT01_Click(sender As Object, e As EventArgs) Handles BT01.Click
        iBT = 0
        jBT = 1
        CtlBT()
    End Sub

    Private Sub BT01_MouseEnter(sender As Object, e As EventArgs) Handles BT01.MouseEnter
        iBT = 0
        jBT = 1
        EntréeSouris()
    End Sub

    Private Sub BT01_MouseLeave(sender As Object, e As EventArgs) Handles BT01.MouseLeave
        iBT = 0
        jBT = 1
        SortieSouris()
    End Sub

    Private Sub BT02_Click(sender As Object, e As EventArgs) Handles BT02.Click
        iBT = 0
        jBT = 2
        CtlBT()
    End Sub

    Private Sub BT02_MouseEnter(sender As Object, e As EventArgs) Handles BT02.MouseEnter
        iBT = 0
        jBT = 2
        EntréeSouris()
    End Sub

    Private Sub BT02_MouseLeave(sender As Object, e As EventArgs) Handles BT02.MouseLeave
        iBT = 0
        jBT = 2
        SortieSouris()
    End Sub

    Private Sub BT03_Click(sender As Object, e As EventArgs) Handles BT03.Click
        iBT = 0
        jBT = 3
        CtlBT()
    End Sub

    Private Sub BT03_MouseEnter(sender As Object, e As EventArgs) Handles BT03.MouseEnter
        iBT = 0
        jBT = 3
        EntréeSouris()
    End Sub

    Private Sub BT03_MouseLeave(sender As Object, e As EventArgs) Handles BT03.MouseLeave
        iBT = 0
        jBT = 3
        SortieSouris()
    End Sub

    Private Sub BT04_Click(sender As Object, e As EventArgs) Handles BT04.Click
        iBT = 0
        jBT = 4
        CtlBT()
    End Sub

    Private Sub BT04_MouseEnter(sender As Object, e As EventArgs) Handles BT04.MouseEnter
        iBT = 0
        jBT = 4
        EntréeSouris()
    End Sub

    Private Sub BT04_MouseLeave(sender As Object, e As EventArgs) Handles BT04.MouseLeave
        iBT = 0
        jBT = 4
        SortieSouris()
    End Sub

    Private Sub BT05_Click(sender As Object, e As EventArgs) Handles BT05.Click
        iBT = 0
        jBT = 5
        CtlBT()
    End Sub

    Private Sub BT05_MouseEnter(sender As Object, e As EventArgs) Handles BT05.MouseEnter
        iBT = 0
        jBT = 5
        EntréeSouris()
    End Sub

    Private Sub BT05_MouseLeave(sender As Object, e As EventArgs) Handles BT05.MouseLeave
        iBT = 0
        jBT = 5
        SortieSouris()
    End Sub

    Private Sub BT06_MouseEnter(sender As Object, e As EventArgs) Handles BT06.MouseEnter
        iBT = 0
        jBT = 6
        EntréeSouris()
    End Sub

    Private Sub BT06_MouseLeave(sender As Object, e As EventArgs) Handles BT06.MouseLeave
        iBT = 0
        jBT = 6
        SortieSouris()
    End Sub

    Private Sub BT06_Click(sender As Object, e As EventArgs) Handles BT06.Click
        iBT = 0
        jBT = 6
        CtlBT()
    End Sub

    Private Sub BT07_MouseEnter(sender As Object, e As EventArgs) Handles BT07.MouseEnter
        iBT = 0
        jBT = 7
        EntréeSouris()
    End Sub

    Private Sub BT07_MouseLeave(sender As Object, e As EventArgs) Handles BT07.MouseLeave
        iBT = 0
        jBT = 7
        SortieSouris()
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

    Private Sub BT08_MouseEnter(sender As Object, e As EventArgs) Handles BT08.MouseEnter
        iBT = 0
        jBT = 8
        EntréeSouris()
    End Sub

    Private Sub BT08_MouseLeave(sender As Object, e As EventArgs) Handles BT08.MouseLeave
        iBT = 0
        jBT = 8
        SortieSouris()
    End Sub

    Private Sub BT09_Click(sender As Object, e As EventArgs) Handles BT09.Click
        iBT = 1
        jBT = 0
        CtlBT()
    End Sub

    Private Sub BT09_MouseEnter(sender As Object, e As EventArgs) Handles BT09.MouseEnter
        iBT = 1
        jBT = 0
        EntréeSouris()
    End Sub

    Private Sub BT09_MouseLeave(sender As Object, e As EventArgs) Handles BT09.MouseLeave
        iBT = 1
        jBT = 0
        SortieSouris()
    End Sub

    Private Sub BT10_Click(sender As Object, e As EventArgs) Handles BT10.Click
        iBT = 1
        jBT = 1
        CtlBT()
    End Sub

    Private Sub BT10_MouseEnter(sender As Object, e As EventArgs) Handles BT10.MouseEnter
        iBT = 1
        jBT = 1
        EntréeSouris()
    End Sub

    Private Sub BT10_MouseLeave(sender As Object, e As EventArgs) Handles BT10.MouseLeave
        iBT = 1
        jBT = 1
        SortieSouris()
    End Sub

    Private Sub BT11_Click(sender As Object, e As EventArgs) Handles BT11.Click
        iBT = 1
        jBT = 2
        CtlBT()
    End Sub

    Private Sub BT11_MouseEnter(sender As Object, e As EventArgs) Handles BT11.MouseEnter
        iBT = 1
        jBT = 2
        EntréeSouris()
    End Sub

    Private Sub BT11_MouseLeave(sender As Object, e As EventArgs) Handles BT11.MouseLeave
        iBT = 1
        jBT = 2
        SortieSouris()
    End Sub

    Private Sub BT12_Click(sender As Object, e As EventArgs) Handles BT12.Click
        iBT = 1
        jBT = 3
        CtlBT()
    End Sub

    Private Sub BT12_MouseEnter(sender As Object, e As EventArgs) Handles BT12.MouseEnter
        iBT = 1
        jBT = 3
        EntréeSouris()
    End Sub

    Private Sub BT12_MouseLeave(sender As Object, e As EventArgs) Handles BT12.MouseLeave
        iBT = 1
        jBT = 3
        SortieSouris()
    End Sub

    Private Sub BT13_Click(sender As Object, e As EventArgs) Handles BT13.Click
        iBT = 1
        jBT = 4
        CtlBT()
    End Sub

    Private Sub BT13_MouseEnter(sender As Object, e As EventArgs) Handles BT13.MouseEnter
        iBT = 1
        jBT = 4
        EntréeSouris()
    End Sub

    Private Sub BT13_MouseLeave(sender As Object, e As EventArgs) Handles BT13.MouseLeave
        iBT = 1
        jBT = 4
        SortieSouris()
    End Sub

    Private Sub BT14_Click(sender As Object, e As EventArgs) Handles BT14.Click
        iBT = 1
        jBT = 5
        CtlBT()
    End Sub

    Private Sub BT14_MouseEnter(sender As Object, e As EventArgs) Handles BT14.MouseEnter
        iBT = 1
        jBT = 5
        EntréeSouris()
    End Sub

    Private Sub BT14_MouseLeave(sender As Object, e As EventArgs) Handles BT14.MouseLeave
        iBT = 1
        jBT = 5
        SortieSouris()
    End Sub

    Private Sub BT15_Click(sender As Object, e As EventArgs) Handles BT15.Click
        iBT = 1
        jBT = 6
        CtlBT()
    End Sub

    Private Sub BT15_MouseEnter(sender As Object, e As EventArgs) Handles BT15.MouseEnter
        iBT = 1
        jBT = 6
        EntréeSouris()
    End Sub

    Private Sub BT15_MouseLeave(sender As Object, e As EventArgs) Handles BT15.MouseLeave
        iBT = 1
        jBT = 6
        SortieSouris()
    End Sub

    Private Sub BT16_Click(sender As Object, e As EventArgs) Handles BT16.Click
        iBT = 1
        jBT = 7
        CtlBT()
    End Sub

    Private Sub BT16_MouseEnter(sender As Object, e As EventArgs) Handles BT16.MouseEnter
        iBT = 1
        jBT = 7
        EntréeSouris()
    End Sub

    Private Sub BT16_MouseLeave(sender As Object, e As EventArgs) Handles BT16.MouseLeave
        iBT = 1
        jBT = 7
        SortieSouris()
    End Sub

    Private Sub BT17_MouseEnter(sender As Object, e As EventArgs) Handles BT17.MouseEnter
        iBT = 1
        jBT = 8
        EntréeSouris()
    End Sub

    Private Sub BT17_MouseLeave(sender As Object, e As EventArgs) Handles BT17.MouseLeave
        iBT = 1
        jBT = 8
        SortieSouris()
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

    Private Sub BT18_MouseEnter(sender As Object, e As EventArgs) Handles BT18.MouseEnter
        iBT = 2
        jBT = 0
        EntréeSouris()
    End Sub

    Private Sub BT18_MouseLeave(sender As Object, e As EventArgs) Handles BT18.MouseLeave
        iBT = 2
        jBT = 0
        SortieSouris()
    End Sub

    Private Sub BT19_Click(sender As Object, e As EventArgs) Handles BT19.Click
        iBT = 2
        jBT = 1
        CtlBT()
    End Sub

    Private Sub BT19_MouseEnter(sender As Object, e As EventArgs) Handles BT19.MouseEnter
        iBT = 2
        jBT = 1
        EntréeSouris()
    End Sub

    Private Sub BT19_MouseLeave(sender As Object, e As EventArgs) Handles BT19.MouseLeave
        iBT = 2
        jBT = 1
        SortieSouris()
    End Sub

    Private Sub BT20_Click(sender As Object, e As EventArgs) Handles BT20.Click
        iBT = 2
        jBT = 2
        CtlBT()
    End Sub

    Private Sub BT20_MouseEnter(sender As Object, e As EventArgs) Handles BT20.MouseEnter
        iBT = 2
        jBT = 2
        EntréeSouris()
    End Sub

    Private Sub BT20_MouseLeave(sender As Object, e As EventArgs) Handles BT20.MouseLeave
        iBT = 2
        jBT = 2
        SortieSouris()
    End Sub

    Private Sub BT21_Click(sender As Object, e As EventArgs) Handles BT21.Click
        iBT = 2
        jBT = 3
        CtlBT()
    End Sub

    Private Sub BT21_MouseEnter(sender As Object, e As EventArgs) Handles BT21.MouseEnter
        iBT = 2
        jBT = 3
        EntréeSouris()
    End Sub

    Private Sub BT21_MouseLeave(sender As Object, e As EventArgs) Handles BT21.MouseLeave
        iBT = 2
        jBT = 3
        SortieSouris()
    End Sub

    Private Sub BT22_Click(sender As Object, e As EventArgs) Handles BT22.Click
        iBT = 2
        jBT = 4
        CtlBT()
    End Sub

    Private Sub BT22_MouseEnter(sender As Object, e As EventArgs) Handles BT22.MouseEnter
        iBT = 2
        jBT = 4
        EntréeSouris()
    End Sub

    Private Sub BT22_MouseLeave(sender As Object, e As EventArgs) Handles BT22.MouseLeave
        iBT = 2
        jBT = 4
        SortieSouris()
    End Sub

    Private Sub BT23_Click(sender As Object, e As EventArgs) Handles BT23.Click
        iBT = 2
        jBT = 5
        CtlBT()
    End Sub

    Private Sub BT23_MouseEnter(sender As Object, e As EventArgs) Handles BT23.MouseEnter
        iBT = 2
        jBT = 5
        EntréeSouris()
    End Sub

    Private Sub BT23_MouseLeave(sender As Object, e As EventArgs) Handles BT23.MouseLeave
        iBT = 2
        jBT = 5
        SortieSouris()
    End Sub

    Private Sub BT24_Click(sender As Object, e As EventArgs) Handles BT24.Click
        iBT = 2
        jBT = 6
        CtlBT()
    End Sub

    Private Sub BT24_MouseEnter(sender As Object, e As EventArgs) Handles BT24.MouseEnter
        iBT = 2
        jBT = 6
        EntréeSouris()
    End Sub

    Private Sub BT24_MouseLeave(sender As Object, e As EventArgs) Handles BT24.MouseLeave
        iBT = 2
        jBT = 6
        SortieSouris()
    End Sub

    Private Sub BT25_Click(sender As Object, e As EventArgs) Handles BT25.Click
        iBT = 2
        jBT = 7
        CtlBT()
    End Sub

    Private Sub BT25_MouseEnter(sender As Object, e As EventArgs) Handles BT25.MouseEnter
        iBT = 2
        jBT = 7
        EntréeSouris()
    End Sub

    Private Sub BT25_MouseLeave(sender As Object, e As EventArgs) Handles BT25.MouseLeave
        iBT = 2
        jBT = 7
        SortieSouris()
    End Sub

    Private Sub BT26_Click(sender As Object, e As EventArgs) Handles BT26.Click
        iBT = 2
        jBT = 8
        CtlBT()
    End Sub

    Private Sub BT26_MouseEnter(sender As Object, e As EventArgs) Handles BT26.MouseEnter
        iBT = 2
        jBT = 8
        EntréeSouris()
    End Sub

    Private Sub BT26_MouseLeave(sender As Object, e As EventArgs) Handles BT26.MouseLeave
        iBT = 2
        jBT = 8
        SortieSouris()
    End Sub

    Private Sub BT27_Click(sender As Object, e As EventArgs) Handles BT27.Click
        iBT = 3
        jBT = 0
        CtlBT()
    End Sub

    Private Sub BT27_MouseEnter(sender As Object, e As EventArgs) Handles BT27.MouseEnter
        iBT = 3
        jBT = 0
        EntréeSouris()
    End Sub

    Private Sub BT27_MouseLeave(sender As Object, e As EventArgs) Handles BT27.MouseLeave
        iBT = 3
        jBT = 0
        SortieSouris()
    End Sub

    Private Sub BT28_Click(sender As Object, e As EventArgs) Handles BT28.Click
        iBT = 3
        jBT = 1
        CtlBT()
    End Sub

    Private Sub BT28_MouseEnter(sender As Object, e As EventArgs) Handles BT28.MouseEnter
        iBT = 3
        jBT = 1
        EntréeSouris()
    End Sub

    Private Sub BT28_MouseLeave(sender As Object, e As EventArgs) Handles BT28.MouseLeave
        iBT = 3
        jBT = 1
        SortieSouris()
    End Sub

    Private Sub BT29_Click(sender As Object, e As EventArgs) Handles BT29.Click
        iBT = 3
        jBT = 2
        CtlBT()
    End Sub

    Private Sub BT29_MouseEnter(sender As Object, e As EventArgs) Handles BT29.MouseEnter
        iBT = 3
        jBT = 2
        EntréeSouris()
    End Sub

    Private Sub BT29_MouseLeave(sender As Object, e As EventArgs) Handles BT29.MouseLeave
        iBT = 3
        jBT = 2
        SortieSouris()
    End Sub

    Private Sub BT30_Click(sender As Object, e As EventArgs) Handles BT30.Click
        iBT = 3
        jBT = 3
        CtlBT()
    End Sub

    Private Sub BT30_MouseEnter(sender As Object, e As EventArgs) Handles BT30.MouseEnter
        iBT = 3
        jBT = 3
        EntréeSouris()
    End Sub

    Private Sub BT30_MouseLeave(sender As Object, e As EventArgs) Handles BT30.MouseLeave
        iBT = 3
        jBT = 3
        SortieSouris()
    End Sub

    Private Sub BT31_Click(sender As Object, e As EventArgs) Handles BT31.Click
        iBT = 3
        jBT = 4
        CtlBT()
    End Sub

    Private Sub BT31_MouseEnter(sender As Object, e As EventArgs) Handles BT31.MouseEnter
        iBT = 3
        jBT = 4
        EntréeSouris()
    End Sub

    Private Sub BT31_MouseLeave(sender As Object, e As EventArgs) Handles BT31.MouseLeave
        iBT = 3
        jBT = 4
        SortieSouris()
    End Sub

    Private Sub BT32_Click(sender As Object, e As EventArgs) Handles BT32.Click
        iBT = 3
        jBT = 5
        CtlBT()
    End Sub

    Private Sub BT32_MouseEnter(sender As Object, e As EventArgs) Handles BT32.MouseEnter
        iBT = 3
        jBT = 5
        EntréeSouris()
    End Sub

    Private Sub BT32_MouseLeave(sender As Object, e As EventArgs) Handles BT32.MouseLeave
        iBT = 3
        jBT = 5
        SortieSouris()
    End Sub

    Private Sub BT33_Click(sender As Object, e As EventArgs) Handles BT33.Click
        iBT = 3
        jBT = 6
        CtlBT()
    End Sub

    Private Sub BT33_MouseEnter(sender As Object, e As EventArgs) Handles BT33.MouseEnter
        iBT = 3
        jBT = 6
        EntréeSouris()
    End Sub

    Private Sub BT33_MouseLeave(sender As Object, e As EventArgs) Handles BT33.MouseLeave
        iBT = 3
        jBT = 6
        SortieSouris()
    End Sub

    Private Sub BT34_Click(sender As Object, e As EventArgs) Handles BT34.Click
        iBT = 3
        jBT = 7
        CtlBT()
    End Sub

    Private Sub BT34_MouseEnter(sender As Object, e As EventArgs) Handles BT34.MouseEnter
        iBT = 3
        jBT = 7
        EntréeSouris()
    End Sub

    Private Sub BT34_MouseLeave(sender As Object, e As EventArgs) Handles BT34.MouseLeave
        iBT = 3
        jBT = 7
        SortieSouris()
    End Sub

    Private Sub BT35_Click(sender As Object, e As EventArgs) Handles BT35.Click
        iBT = 3
        jBT = 8
        CtlBT()
    End Sub

    Private Sub BT35_MouseEnter(sender As Object, e As EventArgs) Handles BT35.MouseEnter
        iBT = 3
        jBT = 8
        EntréeSouris()
    End Sub

    Private Sub BT35_MouseLeave(sender As Object, e As EventArgs) Handles BT35.MouseLeave
        iBT = 3
        jBT = 8
        SortieSouris()
    End Sub

    Private Sub Bt36_Click(sender As Object, e As EventArgs) Handles Bt36.Click
        iBT = 4
        jBT = 0
        CtlBT()
    End Sub

    Private Sub BT36_MouseEnter(sender As Object, e As EventArgs) Handles Bt36.MouseEnter
        iBT = 4
        jBT = 0
        EntréeSouris()
    End Sub

    Private Sub BT36_MouseLeave(sender As Object, e As EventArgs) Handles Bt36.MouseLeave
        iBT = 4
        jBT = 0
        SortieSouris()
    End Sub

    Private Sub BT37_Click(sender As Object, e As EventArgs) Handles BT37.Click
        iBT = 4
        jBT = 1
        CtlBT()
    End Sub

    Private Sub BT37_MouseEnter(sender As Object, e As EventArgs) Handles BT37.MouseEnter
        iBT = 4
        jBT = 1
        EntréeSouris()
    End Sub

    Private Sub BT37_MouseLeave(sender As Object, e As EventArgs) Handles BT37.MouseLeave
        iBT = 4
        jBT = 1
        SortieSouris()
    End Sub

    Private Sub BT38_Click(sender As Object, e As EventArgs) Handles BT38.Click
        iBT = 4
        jBT = 2
        CtlBT()
    End Sub

    Private Sub BT38_MouseEnter(sender As Object, e As EventArgs) Handles BT38.MouseEnter
        iBT = 4
        jBT = 2
        EntréeSouris()
    End Sub

    Private Sub BT38_MouseLeave(sender As Object, e As EventArgs) Handles BT38.MouseLeave
        iBT = 4
        jBT = 2
        SortieSouris()
    End Sub

    Private Sub BT39_Click(sender As Object, e As EventArgs) Handles BT39.Click
        iBT = 4
        jBT = 3
        CtlBT()
    End Sub

    Private Sub BT39_MouseEnter(sender As Object, e As EventArgs) Handles BT39.MouseEnter
        iBT = 4
        jBT = 3
        EntréeSouris()
    End Sub

    Private Sub BT39_MouseLeave(sender As Object, e As EventArgs) Handles BT39.MouseLeave
        iBT = 4
        jBT = 3
        SortieSouris()
    End Sub

    Private Sub BT40_Click(sender As Object, e As EventArgs) Handles BT40.Click
        iBT = 4
        jBT = 4
        CtlBT()
    End Sub

    Private Sub BT40_MouseEnter(sender As Object, e As EventArgs) Handles BT40.MouseEnter
        iBT = 4
        jBT = 4
        EntréeSouris()
    End Sub

    Private Sub BT40_MouseLeave(sender As Object, e As EventArgs) Handles BT40.MouseLeave
        iBT = 4
        jBT = 4
        SortieSouris()
    End Sub

    Private Sub BT41_Click(sender As Object, e As EventArgs) Handles BT41.Click
        iBT = 4
        jBT = 5
        CtlBT()
    End Sub

    Private Sub BT41_MouseEnter(sender As Object, e As EventArgs) Handles BT41.MouseEnter
        iBT = 4
        jBT = 5
        EntréeSouris()
    End Sub

    Private Sub BT41_MouseLeave(sender As Object, e As EventArgs) Handles BT41.MouseLeave
        iBT = 4
        jBT = 5
        SortieSouris()
    End Sub

    Private Sub BT42_Click(sender As Object, e As EventArgs) Handles BT42.Click
        iBT = 4
        jBT = 6
        CtlBT()
    End Sub

    Private Sub BT42_MouseEnter(sender As Object, e As EventArgs) Handles BT42.MouseEnter
        iBT = 4
        jBT = 6
        EntréeSouris()
    End Sub

    Private Sub BT42_MouseLeave(sender As Object, e As EventArgs) Handles BT42.MouseLeave
        iBT = 4
        jBT = 6
        SortieSouris()
    End Sub

    Private Sub BT43_Click(sender As Object, e As EventArgs) Handles BT43.Click
        iBT = 4
        jBT = 7
        CtlBT()
    End Sub

    Private Sub BT43_MouseEnter(sender As Object, e As EventArgs) Handles BT43.MouseEnter
        iBT = 4
        jBT = 7
        EntréeSouris()
    End Sub

    Private Sub BT43_MouseLeave(sender As Object, e As EventArgs) Handles BT43.MouseLeave
        iBT = 4
        jBT = 7
        SortieSouris()
    End Sub

    Private Sub BT44_Click(sender As Object, e As EventArgs) Handles BT44.Click
        iBT = 4
        jBT = 8
        CtlBT()
    End Sub

    Private Sub BT44_MouseEnter(sender As Object, e As EventArgs) Handles BT44.MouseEnter
        iBT = 4
        jBT = 8
        EntréeSouris()
    End Sub

    Private Sub BT44_MouseLeave(sender As Object, e As EventArgs) Handles BT44.MouseLeave
        iBT = 4
        jBT = 8
        SortieSouris()
    End Sub

    Private Sub BT45_Click(sender As Object, e As EventArgs) Handles BT45.Click
        iBT = 5
        jBT = 0
        CtlBT()
    End Sub

    Private Sub BT45_MouseEnter(sender As Object, e As EventArgs) Handles BT45.MouseEnter
        iBT = 5
        jBT = 0
        EntréeSouris()
    End Sub

    Private Sub BT45_MouseLeave(sender As Object, e As EventArgs) Handles BT45.MouseLeave
        iBT = 5
        jBT = 0
        SortieSouris()
    End Sub

    Private Sub BT46_Click(sender As Object, e As EventArgs) Handles BT46.Click
        iBT = 5
        jBT = 1
        CtlBT()
    End Sub

    Private Sub BT46_MouseEnter(sender As Object, e As EventArgs) Handles BT46.MouseEnter
        iBT = 5
        jBT = 1
        EntréeSouris()
    End Sub

    Private Sub BT46_MouseLeave(sender As Object, e As EventArgs) Handles BT46.MouseLeave
        iBT = 5
        jBT = 1
        SortieSouris()
    End Sub

    Private Sub BT47_Click(sender As Object, e As EventArgs) Handles BT47.Click
        iBT = 5
        jBT = 2
        CtlBT()
    End Sub

    Private Sub BT47_MouseEnter(sender As Object, e As EventArgs) Handles BT47.MouseEnter
        iBT = 5
        jBT = 2
        EntréeSouris()
    End Sub

    Private Sub BT47_MouseLeave(sender As Object, e As EventArgs) Handles BT47.MouseLeave
        iBT = 5
        jBT = 2
        SortieSouris()
    End Sub

    Private Sub BT48_Click(sender As Object, e As EventArgs) Handles BT48.Click
        iBT = 5
        jBT = 3
        CtlBT()
    End Sub

    Private Sub BT48_MouseEnter(sender As Object, e As EventArgs) Handles BT48.MouseEnter
        iBT = 5
        jBT = 3
        EntréeSouris()
    End Sub

    Private Sub BT48_MouseLeave(sender As Object, e As EventArgs) Handles BT48.MouseLeave
        iBT = 5
        jBT = 3
        SortieSouris()
    End Sub

    Private Sub BT49_Click(sender As Object, e As EventArgs) Handles BT49.Click
        iBT = 5
        jBT = 4
        CtlBT()
    End Sub

    Private Sub BT49_MouseEnter(sender As Object, e As EventArgs) Handles BT49.MouseEnter
        iBT = 5
        jBT = 4
        EntréeSouris()
    End Sub

    Private Sub BT49_MouseLeave(sender As Object, e As EventArgs) Handles BT49.MouseLeave
        iBT = 5
        jBT = 4
        SortieSouris()
    End Sub

    Private Sub BT50_Click(sender As Object, e As EventArgs) Handles BT50.Click
        iBT = 5
        jBT = 5
        CtlBT()
    End Sub

    Private Sub BT50_MouseEnter(sender As Object, e As EventArgs) Handles BT50.MouseEnter
        iBT = 5
        jBT = 5
        EntréeSouris()
    End Sub

    Private Sub BT50_MouseLeave(sender As Object, e As EventArgs) Handles BT50.MouseLeave
        iBT = 5
        jBT = 5
        SortieSouris()
    End Sub

    Private Sub BT51_Click(sender As Object, e As EventArgs) Handles BT51.Click
        iBT = 5
        jBT = 6
        CtlBT()
    End Sub

    Private Sub BT51_MouseEnter(sender As Object, e As EventArgs) Handles BT51.MouseEnter
        iBT = 5
        jBT = 6
        EntréeSouris()
    End Sub

    Private Sub BT51_MouseLeave(sender As Object, e As EventArgs) Handles BT51.MouseLeave
        iBT = 5
        jBT = 6
        SortieSouris()
    End Sub

    Private Sub BT52_Click(sender As Object, e As EventArgs) Handles BT52.Click
        iBT = 5
        jBT = 7
        CtlBT()
    End Sub

    Private Sub BT52_MouseEnter(sender As Object, e As EventArgs) Handles BT52.MouseEnter
        iBT = 5
        jBT = 7
        EntréeSouris()
    End Sub

    Private Sub BT52_MouseLeave(sender As Object, e As EventArgs) Handles BT52.MouseLeave
        iBT = 5
        jBT = 7
        SortieSouris()
    End Sub

    Private Sub BT53_Click(sender As Object, e As EventArgs) Handles BT53.Click
        iBT = 5
        jBT = 8
        CtlBT()
    End Sub

    Private Sub BT53_MouseEnter(sender As Object, e As EventArgs) Handles BT53.MouseEnter
        iBT = 5
        jBT = 8
        EntréeSouris()
    End Sub

    Private Sub BT53_MouseLeave(sender As Object, e As EventArgs) Handles BT53.MouseLeave
        iBT = 5
        jBT = 8
        SortieSouris()
    End Sub

    Private Sub BT54_Click(sender As Object, e As EventArgs) Handles BT54.Click
        iBT = 6
        jBT = 0
        CtlBT()
    End Sub

    Private Sub BT54_MouseEnter(sender As Object, e As EventArgs) Handles BT54.MouseEnter
        iBT = 6
        jBT = 0
        EntréeSouris()
    End Sub

    Private Sub BT54_MouseLeave(sender As Object, e As EventArgs) Handles BT54.MouseLeave
        iBT = 6
        jBT = 0
        SortieSouris()
    End Sub

    Private Sub BT55_Click(sender As Object, e As EventArgs) Handles BT55.Click
        iBT = 6
        jBT = 1
        CtlBT()
    End Sub

    Private Sub BT55_MouseEnter(sender As Object, e As EventArgs) Handles BT55.MouseEnter
        iBT = 6
        jBT = 1
        EntréeSouris()
    End Sub

    Private Sub BT55_MouseLeave(sender As Object, e As EventArgs) Handles BT55.MouseLeave
        iBT = 6
        jBT = 1
        SortieSouris()
    End Sub

    Private Sub BT56_Click(sender As Object, e As EventArgs) Handles BT56.Click
        iBT = 6
        jBT = 2
        CtlBT()
    End Sub

    Private Sub BT56_MouseEnter(sender As Object, e As EventArgs) Handles BT56.MouseEnter
        iBT = 6
        jBT = 2
        EntréeSouris()
    End Sub

    Private Sub BT56_MouseLeave(sender As Object, e As EventArgs) Handles BT56.MouseLeave
        iBT = 6
        jBT = 2
        SortieSouris()
    End Sub

    Private Sub BT57_Click(sender As Object, e As EventArgs) Handles BT57.Click
        iBT = 6
        jBT = 3
        CtlBT()
    End Sub

    Private Sub BT57_MouseEnter(sender As Object, e As EventArgs) Handles BT57.MouseEnter
        iBT = 6
        jBT = 3
        EntréeSouris()
    End Sub

    Private Sub BT57_MouseLeave(sender As Object, e As EventArgs) Handles BT57.MouseLeave
        iBT = 6
        jBT = 3
        SortieSouris()
    End Sub

    Private Sub BT58_Click(sender As Object, e As EventArgs) Handles BT58.Click
        iBT = 6
        jBT = 4
        CtlBT()
    End Sub

    Private Sub BT58_MouseEnter(sender As Object, e As EventArgs) Handles BT58.MouseEnter
        iBT = 6
        jBT = 4
        EntréeSouris()
    End Sub

    Private Sub BT58_MouseLeave(sender As Object, e As EventArgs) Handles BT58.MouseLeave
        iBT = 6
        jBT = 4
        SortieSouris()
    End Sub

    Private Sub BT59_Click(sender As Object, e As EventArgs) Handles BT59.Click
        iBT = 6
        jBT = 5
        CtlBT()
    End Sub

    Private Sub BT59_MouseEnter(sender As Object, e As EventArgs) Handles BT59.MouseEnter
        iBT = 6
        jBT = 5
        EntréeSouris()
    End Sub

    Private Sub BT59_MouseLeave(sender As Object, e As EventArgs) Handles BT59.MouseLeave
        iBT = 6
        jBT = 5
        SortieSouris()
    End Sub

    Private Sub BT60_Click(sender As Object, e As EventArgs) Handles BT60.Click
        iBT = 6
        jBT = 6
        CtlBT()
    End Sub

    Private Sub BT60_MouseEnter(sender As Object, e As EventArgs) Handles BT60.MouseEnter
        iBT = 6
        jBT = 6
        EntréeSouris()
    End Sub

    Private Sub BT60_MouseLeave(sender As Object, e As EventArgs) Handles BT60.MouseLeave
        iBT = 6
        jBT = 6
        SortieSouris()
    End Sub

    Private Sub BT61_Click(sender As Object, e As EventArgs) Handles BT61.Click
        iBT = 6
        jBT = 7
        CtlBT()
    End Sub

    Private Sub BT61_MouseEnter(sender As Object, e As EventArgs) Handles BT61.MouseEnter
        iBT = 6
        jBT = 7
        EntréeSouris()
    End Sub

    Private Sub BT61_MouseLeave(sender As Object, e As EventArgs) Handles BT61.MouseLeave
        iBT = 6
        jBT = 7
        SortieSouris()
    End Sub

    Private Sub BT62_Click(sender As Object, e As EventArgs) Handles BT62.Click
        iBT = 6
        jBT = 8
        CtlBT()
    End Sub

    Private Sub BT62_MouseEnter(sender As Object, e As EventArgs) Handles BT62.MouseEnter
        iBT = 6
        jBT = 8
        EntréeSouris()
    End Sub

    Private Sub BT62_MouseLeave(sender As Object, e As EventArgs) Handles BT62.MouseLeave
        iBT = 6
        jBT = 8
        SortieSouris()
    End Sub

    Private Sub BT63_Click(sender As Object, e As EventArgs) Handles BT63.Click
        iBT = 7
        jBT = 0
        CtlBT()
    End Sub

    Private Sub BT63_MouseEnter(sender As Object, e As EventArgs) Handles BT63.MouseEnter
        iBT = 7
        jBT = 0
        EntréeSouris()
    End Sub

    Private Sub BT63_MouseLeave(sender As Object, e As EventArgs) Handles BT63.MouseLeave
        iBT = 7
        jBT = 0
        SortieSouris()
    End Sub

    Private Sub BT64_Click(sender As Object, e As EventArgs) Handles BT64.Click
        iBT = 7
        jBT = 1
        CtlBT()
    End Sub

    Private Sub BT64_MouseEnter(sender As Object, e As EventArgs) Handles BT64.MouseEnter
        iBT = 7
        jBT = 1
        EntréeSouris()
    End Sub

    Private Sub BT64_MouseLeave(sender As Object, e As EventArgs) Handles BT64.MouseLeave
        iBT = 7
        jBT = 1
        SortieSouris()
    End Sub

    Private Sub BT65_Click(sender As Object, e As EventArgs) Handles BT65.Click
        iBT = 7
        jBT = 2
        CtlBT()
    End Sub

    Private Sub BT65_MouseEnter(sender As Object, e As EventArgs) Handles BT65.MouseEnter
        iBT = 7
        jBT = 2
        EntréeSouris()
    End Sub

    Private Sub BT65_MouseLeave(sender As Object, e As EventArgs) Handles BT65.MouseLeave
        iBT = 7
        jBT = 2
        SortieSouris()
    End Sub

    Private Sub BT66_Click(sender As Object, e As EventArgs) Handles BT66.Click
        iBT = 7
        jBT = 3
        CtlBT()
    End Sub

    Private Sub BT66_MouseEnter(sender As Object, e As EventArgs) Handles BT66.MouseEnter
        iBT = 7
        jBT = 3
        EntréeSouris()
    End Sub

    Private Sub BT66_MouseLeave(sender As Object, e As EventArgs) Handles BT66.MouseLeave
        iBT = 7
        jBT = 3
        SortieSouris()
    End Sub

    Private Sub BT67_MouseEnter(sender As Object, e As EventArgs) Handles BT67.MouseEnter
        iBT = 7
        jBT = 4
        EntréeSouris()
    End Sub

    Private Sub BT67_MouseLeave(sender As Object, e As EventArgs) Handles BT67.MouseLeave
        iBT = 7
        jBT = 4
        SortieSouris()
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

    Private Sub BT68_MouseEnter(sender As Object, e As EventArgs) Handles BT68.MouseEnter
        iBT = 7
        jBT = 5
        EntréeSouris()
    End Sub

    Private Sub BT68_MouseLeave(sender As Object, e As EventArgs) Handles BT68.MouseLeave
        iBT = 7
        jBT = 5
        SortieSouris()
    End Sub

    Private Sub BT69_Click(sender As Object, e As EventArgs) Handles BT69.Click
        iBT = 7
        jBT = 6
        CtlBT()
    End Sub

    Private Sub BT69_MouseEnter(sender As Object, e As EventArgs) Handles BT69.MouseEnter
        iBT = 7
        jBT = 6
        EntréeSouris()
    End Sub

    Private Sub BT69_MouseLeave(sender As Object, e As EventArgs) Handles BT69.MouseLeave
        iBT = 7
        jBT = 6
        SortieSouris()
    End Sub

    Private Sub BT70_Click(sender As Object, e As EventArgs) Handles BT70.Click
        iBT = 7
        jBT = 7
        CtlBT()
    End Sub

    Private Sub BT70_MouseEnter(sender As Object, e As EventArgs) Handles BT70.MouseEnter
        iBT = 7
        jBT = 7
        EntréeSouris()
    End Sub

    Private Sub BT70_MouseLeave(sender As Object, e As EventArgs) Handles BT70.MouseLeave
        iBT = 7
        jBT = 7
        SortieSouris()
    End Sub

    Private Sub BT71_Click(sender As Object, e As EventArgs) Handles BT71.Click
        iBT = 7
        jBT = 8
        CtlBT()
    End Sub

    Private Sub BT71_MouseEnter(sender As Object, e As EventArgs) Handles BT71.MouseEnter
        iBT = 7
        jBT = 8
        EntréeSouris()
    End Sub

    Private Sub BT71_MouseLeave(sender As Object, e As EventArgs) Handles BT71.MouseLeave
        iBT = 7
        jBT = 8
        SortieSouris()
    End Sub

    Private Sub BT72_Click(sender As Object, e As EventArgs) Handles BT72.Click
        iBT = 8
        jBT = 0
        CtlBT()
    End Sub

    Private Sub BT72_MouseEnter(sender As Object, e As EventArgs) Handles BT72.MouseEnter
        iBT = 8
        jBT = 0
        EntréeSouris()
    End Sub

    Private Sub BT72_MouseLeave(sender As Object, e As EventArgs) Handles BT72.MouseLeave
        iBT = 8
        jBT = 0
        SortieSouris()
    End Sub

    Private Sub BT73_Click(sender As Object, e As EventArgs) Handles BT73.Click
        iBT = 8
        jBT = 1
        CtlBT()
    End Sub

    Private Sub BT73_MouseEnter(sender As Object, e As EventArgs) Handles BT73.MouseEnter
        iBT = 8
        jBT = 1
        EntréeSouris()
    End Sub

    Private Sub BT73_MouseLeave(sender As Object, e As EventArgs) Handles BT73.MouseLeave
        iBT = 8
        jBT = 1
        SortieSouris()
    End Sub

    Private Sub BT74_Click(sender As Object, e As EventArgs) Handles BT74.Click
        iBT = 8
        jBT = 2
        CtlBT()
    End Sub

    Private Sub BT74_MouseEnter(sender As Object, e As EventArgs) Handles BT74.MouseEnter
        iBT = 8
        jBT = 2
        EntréeSouris()
    End Sub

    Private Sub BT74_MouseLeave(sender As Object, e As EventArgs) Handles BT74.MouseLeave
        iBT = 8
        jBT = 2
        SortieSouris()
    End Sub

    Private Sub BT75_Click(sender As Object, e As EventArgs) Handles BT75.Click
        iBT = 8
        jBT = 3
        CtlBT()
    End Sub

    Private Sub BT75_MouseEnter(sender As Object, e As EventArgs) Handles BT75.MouseEnter
        iBT = 8
        jBT = 3
        EntréeSouris()
    End Sub

    Private Sub BT75_MouseLeave(sender As Object, e As EventArgs) Handles BT75.MouseLeave
        iBT = 8
        jBT = 3
        SortieSouris()
    End Sub

    Private Sub BT76_Click(sender As Object, e As EventArgs) Handles BT76.Click
        iBT = 8
        jBT = 4
        CtlBT()
    End Sub

    Private Sub BT76_MouseEnter(sender As Object, e As EventArgs) Handles BT76.MouseEnter
        iBT = 8
        jBT = 4
        EntréeSouris()
    End Sub

    Private Sub BT76_MouseLeave(sender As Object, e As EventArgs) Handles BT76.MouseLeave
        iBT = 8
        jBT = 4
        SortieSouris()
    End Sub

    Private Sub BT77_Click(sender As Object, e As EventArgs) Handles BT77.Click
        iBT = 8
        jBT = 5
        CtlBT()
    End Sub

    Private Sub BT77_MouseEnter(sender As Object, e As EventArgs) Handles BT77.MouseEnter
        iBT = 8
        jBT = 5
        EntréeSouris()
    End Sub

    Private Sub BT77_MouseLeave(sender As Object, e As EventArgs) Handles BT77.MouseLeave
        iBT = 8
        jBT = 5
        SortieSouris()
    End Sub

    Private Sub BT78_Click(sender As Object, e As EventArgs) Handles BT78.Click
        iBT = 8
        jBT = 6
        CtlBT()
    End Sub

    Private Sub BT78_MouseEnter(sender As Object, e As EventArgs) Handles BT78.MouseEnter
        iBT = 8
        jBT = 6
        EntréeSouris()
    End Sub

    Private Sub BT78_MouseLeave(sender As Object, e As EventArgs) Handles BT78.MouseLeave
        iBT = 8
        jBT = 6
        SortieSouris()
    End Sub

    Private Sub BT79_Click(sender As Object, e As EventArgs) Handles BT79.Click
        iBT = 8
        jBT = 7
        CtlBT()
    End Sub

    Private Sub BT79_MouseEnter(sender As Object, e As EventArgs) Handles BT79.MouseEnter
        iBT = 8
        jBT = 7
        EntréeSouris()
    End Sub

    Private Sub BT79_MouseLeave(sender As Object, e As EventArgs) Handles BT79.MouseLeave
        iBT = 8
        jBT = 7
        SortieSouris()
    End Sub

    Private Sub BT80_Click(sender As Object, e As EventArgs) Handles BT80.Click
        iBT = 8
        jBT = 8
        CtlBT()
    End Sub

    Private Sub BT80_MouseEnter(sender As Object, e As EventArgs) Handles BT80.MouseEnter
        iBT = 8
        jBT = 8
        EntréeSouris()
    End Sub

    Private Sub BT80_MouseLeave(sender As Object, e As EventArgs) Handles BT80.MouseLeave
        iBT = 8
        jBT = 8
        SortieSouris()
    End Sub

    Private Sub CtlBT()

        '   If valSaisie <> Nothing Then
        If mode = "Saisie" Or mode = "Jouer" Then
                For i = 0 To 8
                    For j = 0 To 8
                        BT(i, j).BackColor = colorIni(i, j)
                    Next
                Next

                If valSaisie = 0 Then 'On efface une case
                    If Grille(iBT, jBT) <> 0 Then
                        Historique(NbVal).i = 0
                        Historique(NbVal).j = 0
                        Historique(NbVal).v = 0
                        NbVal -= 1
                    End If
                    Grille(iBT, jBT) = 0
                Else
                    If Grille(iBT, jBT) = 0 Then ''On remplit une case
                        Historique(NbVal).i = iBT
                        Historique(NbVal).j = jBT
                        Historique(NbVal).v = Grille(iBT, jBT)
                        NbVal += 1
                    End If
                    Grille(iBT, jBT) = valSaisie
                End If

                ControleSaisie(Erreur, ErreurGrille, Grille, Candidats)
                RecalculCandidats(iBT, jBT, Grille, Candidats) ' Efface les candidats éliminés par la solution appliquée 
                Affichage()

                If NbVal > NbvalMax Then
                    NbvalMax = NbVal
                End If

            End If
        '  End If

    End Sub

    Private Sub EntréeSouris()

        If mode = "Saisie" Or mode = "Jouer" Then
            If valSaisie <> Nothing Then
                If Me.BT(iBT, jBT).Enabled Then
                    With Me.BT(iBT, jBT)
                        If valSaisie <> 0 Then
                            .Text = valSaisie.ToString
                        Else
                            If Grille(iBT, jBT) <> 0 Then
                                .Text = " "
                            End If
                        End If
                        .Font = grandeFont
                        .ForeColor = Color.Black
                        .BackColor = colorIni(iBT, jBT)
                    End With
                End If
            End If
        End If

    End Sub

    Private Sub SortieSouris()

        If mode = "Saisie" Or mode = "Jouer" Then
            If Me.BT(iBT, jBT).Enabled Then
                With Me.BT(iBT, jBT)
                    If Grille(iBT, jBT) = 0 Then
                        If modeCandidat Then
                            CaseCandidats =
                            Candidats(iBT, jBT, 0).ToString & " " & Candidats(iBT, jBT, 1).ToString & " " & Candidats(iBT, jBT, 2).ToString & Environment.NewLine &
                            Candidats(iBT, jBT, 3).ToString & " " & Candidats(iBT, jBT, 4).ToString & " " & Candidats(iBT, jBT, 5).ToString & Environment.NewLine &
                            Candidats(iBT, jBT, 6).ToString & " " & Candidats(iBT, jBT, 7).ToString & " " & Candidats(iBT, jBT, 8).ToString
                            CaseCandidats = CaseCandidats.Replace("0", " ")
                            .Text = CaseCandidats
                            .Font = petiteFont
                            .ForeColor = Color.Black
                            .BackColor = colorIni(iBT, jBT)
                            .Enabled = True
                        Else
                            .Text = " "
                            .Font = grandeFont
                            .ForeColor = Color.Black
                            .BackColor = colorIni(iBT, jBT)
                        End If
                    Else
                        .Text = Grille(iBT, jBT).ToString
                        .Font = grandeFont
                        .ForeColor = Color.Black
                        .BackColor = colorIni(iBT, jBT)
                    End If
                End With
            End If
        End If

    End Sub


    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        MsgBox(e.KeyCode.ToString)
        Select Case e.KeyValue
            Case 112 Or 113 ' F1
            Case 114 'F3
            Case 115 ' F4
            Case 116 'F5
            Case 117 ' F6
            Case 118 ' F7
            Case 119 ' F8
            Case 120 ' F9
            Case 121 ' F10
            Case 122 ' F11
            Case 123 ' F12
        End Select
    End Sub

    Private Sub PictureBox1_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox1.MouseEnter
        PictureBox1.BackColor = Color.Transparent
    End Sub

    Private Sub PictureBox1_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox1.MouseLeave
        PictureBox1.BackColor = Color.AntiqueWhite
    End Sub


    '============================================================================== F I N ===================================================================== 
#End Region


End Class
