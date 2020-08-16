<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Sudoku
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sudoku))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FichierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SauvegarderUneGrilleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PartieToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaisieToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PaireNueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PaireNueEnLigneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PaireNueEnColonneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnRégionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.XYwingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.XYWingEnLigneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.XWingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.XWingEnLigneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.XWingEnColonneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TripletNuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TripletNuEnLigneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GénérerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuitterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GrilleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AfficherLesCandidatsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EffacerLesCandidatsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LBL_Conseil = New System.Windows.Forms.Label()
        Me.BT_Solutions = New System.Windows.Forms.Button()
        Me.BT_Smp = New System.Windows.Forms.Button()
        Me.BT_1 = New System.Windows.Forms.Button()
        Me.BT_2 = New System.Windows.Forms.Button()
        Me.BT_3 = New System.Windows.Forms.Button()
        Me.BT_4 = New System.Windows.Forms.Button()
        Me.BT_5 = New System.Windows.Forms.Button()
        Me.BT_6 = New System.Windows.Forms.Button()
        Me.BT_7 = New System.Windows.Forms.Button()
        Me.BT_8 = New System.Windows.Forms.Button()
        Me.BT_9 = New System.Windows.Forms.Button()
        Me.BT_Clear = New System.Windows.Forms.Button()
        Me.BT00 = New System.Windows.Forms.Button()
        Me.BT01 = New System.Windows.Forms.Button()
        Me.BT02 = New System.Windows.Forms.Button()
        Me.BT03 = New System.Windows.Forms.Button()
        Me.BT04 = New System.Windows.Forms.Button()
        Me.BT05 = New System.Windows.Forms.Button()
        Me.BT08 = New System.Windows.Forms.Button()
        Me.BT07 = New System.Windows.Forms.Button()
        Me.BT06 = New System.Windows.Forms.Button()
        Me.BT17 = New System.Windows.Forms.Button()
        Me.BT16 = New System.Windows.Forms.Button()
        Me.BT15 = New System.Windows.Forms.Button()
        Me.BT14 = New System.Windows.Forms.Button()
        Me.BT13 = New System.Windows.Forms.Button()
        Me.BT12 = New System.Windows.Forms.Button()
        Me.BT11 = New System.Windows.Forms.Button()
        Me.BT10 = New System.Windows.Forms.Button()
        Me.BT09 = New System.Windows.Forms.Button()
        Me.BT26 = New System.Windows.Forms.Button()
        Me.BT25 = New System.Windows.Forms.Button()
        Me.BT24 = New System.Windows.Forms.Button()
        Me.BT23 = New System.Windows.Forms.Button()
        Me.BT22 = New System.Windows.Forms.Button()
        Me.BT21 = New System.Windows.Forms.Button()
        Me.BT20 = New System.Windows.Forms.Button()
        Me.BT19 = New System.Windows.Forms.Button()
        Me.BT18 = New System.Windows.Forms.Button()
        Me.BT32 = New System.Windows.Forms.Button()
        Me.BT31 = New System.Windows.Forms.Button()
        Me.BT30 = New System.Windows.Forms.Button()
        Me.BT29 = New System.Windows.Forms.Button()
        Me.BT28 = New System.Windows.Forms.Button()
        Me.BT27 = New System.Windows.Forms.Button()
        Me.BT35 = New System.Windows.Forms.Button()
        Me.BT34 = New System.Windows.Forms.Button()
        Me.BT33 = New System.Windows.Forms.Button()
        Me.BT44 = New System.Windows.Forms.Button()
        Me.BT43 = New System.Windows.Forms.Button()
        Me.BT42 = New System.Windows.Forms.Button()
        Me.BT41 = New System.Windows.Forms.Button()
        Me.BT40 = New System.Windows.Forms.Button()
        Me.BT39 = New System.Windows.Forms.Button()
        Me.BT38 = New System.Windows.Forms.Button()
        Me.BT37 = New System.Windows.Forms.Button()
        Me.Bt36 = New System.Windows.Forms.Button()
        Me.BT53 = New System.Windows.Forms.Button()
        Me.BT52 = New System.Windows.Forms.Button()
        Me.BT51 = New System.Windows.Forms.Button()
        Me.BT50 = New System.Windows.Forms.Button()
        Me.BT49 = New System.Windows.Forms.Button()
        Me.BT48 = New System.Windows.Forms.Button()
        Me.BT47 = New System.Windows.Forms.Button()
        Me.BT46 = New System.Windows.Forms.Button()
        Me.BT45 = New System.Windows.Forms.Button()
        Me.BT80 = New System.Windows.Forms.Button()
        Me.BT79 = New System.Windows.Forms.Button()
        Me.BT78 = New System.Windows.Forms.Button()
        Me.BT77 = New System.Windows.Forms.Button()
        Me.BT76 = New System.Windows.Forms.Button()
        Me.BT75 = New System.Windows.Forms.Button()
        Me.BT74 = New System.Windows.Forms.Button()
        Me.BT73 = New System.Windows.Forms.Button()
        Me.BT72 = New System.Windows.Forms.Button()
        Me.BT71 = New System.Windows.Forms.Button()
        Me.BT70 = New System.Windows.Forms.Button()
        Me.BT69 = New System.Windows.Forms.Button()
        Me.BT68 = New System.Windows.Forms.Button()
        Me.BT67 = New System.Windows.Forms.Button()
        Me.BT66 = New System.Windows.Forms.Button()
        Me.BT65 = New System.Windows.Forms.Button()
        Me.BT64 = New System.Windows.Forms.Button()
        Me.BT63 = New System.Windows.Forms.Button()
        Me.BT62 = New System.Windows.Forms.Button()
        Me.BT61 = New System.Windows.Forms.Button()
        Me.BT60 = New System.Windows.Forms.Button()
        Me.Bt59 = New System.Windows.Forms.Button()
        Me.BT58 = New System.Windows.Forms.Button()
        Me.BT57 = New System.Windows.Forms.Button()
        Me.BT56 = New System.Windows.Forms.Button()
        Me.BT55 = New System.Windows.Forms.Button()
        Me.BT54 = New System.Windows.Forms.Button()
        Me.BTSolution = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.GénérerToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.OuvrirToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.EnregistrerToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SaisirToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.JouerToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.RecommencerToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.BTStepByStep = New System.Windows.Forms.Button()
        Me.LBL_nbVal = New System.Windows.Forms.Label()
        Me.nomFichierOuvert = New System.Windows.Forms.Label()
        Me.BTForceBrute = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FichierToolStripMenuItem, Me.PartieToolStripMenuItem, Me.GrilleToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(10, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1184, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FichierToolStripMenuItem
        '
        Me.FichierToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChToolStripMenuItem, Me.SauvegarderUneGrilleToolStripMenuItem})
        Me.FichierToolStripMenuItem.Name = "FichierToolStripMenuItem"
        Me.FichierToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.FichierToolStripMenuItem.Text = "Fichier"
        '
        'ChToolStripMenuItem
        '
        Me.ChToolStripMenuItem.Name = "ChToolStripMenuItem"
        Me.ChToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.ChToolStripMenuItem.Text = "Charger une Grille"
        '
        'SauvegarderUneGrilleToolStripMenuItem
        '
        Me.SauvegarderUneGrilleToolStripMenuItem.Name = "SauvegarderUneGrilleToolStripMenuItem"
        Me.SauvegarderUneGrilleToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.SauvegarderUneGrilleToolStripMenuItem.Text = "Sauvegarder une Grille"
        '
        'PartieToolStripMenuItem
        '
        Me.PartieToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaisieToolStripMenuItem1, Me.TestToolStripMenuItem1, Me.GénérerToolStripMenuItem, Me.QuitterToolStripMenuItem})
        Me.PartieToolStripMenuItem.Name = "PartieToolStripMenuItem"
        Me.PartieToolStripMenuItem.Size = New System.Drawing.Size(49, 20)
        Me.PartieToolStripMenuItem.Text = "Partie"
        '
        'SaisieToolStripMenuItem1
        '
        Me.SaisieToolStripMenuItem1.Name = "SaisieToolStripMenuItem1"
        Me.SaisieToolStripMenuItem1.Size = New System.Drawing.Size(153, 22)
        Me.SaisieToolStripMenuItem1.Text = "Saisie"
        '
        'TestToolStripMenuItem1
        '
        Me.TestToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PaireNueToolStripMenuItem, Me.XYwingToolStripMenuItem, Me.XWingToolStripMenuItem, Me.TripletNuToolStripMenuItem})
        Me.TestToolStripMenuItem1.Name = "TestToolStripMenuItem1"
        Me.TestToolStripMenuItem1.Size = New System.Drawing.Size(153, 22)
        Me.TestToolStripMenuItem1.Text = "Démonstration"
        '
        'PaireNueToolStripMenuItem
        '
        Me.PaireNueToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PaireNueEnLigneToolStripMenuItem, Me.PaireNueEnColonneToolStripMenuItem, Me.EnRégionToolStripMenuItem})
        Me.PaireNueToolStripMenuItem.Name = "PaireNueToolStripMenuItem"
        Me.PaireNueToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.PaireNueToolStripMenuItem.Text = "Paire nue"
        '
        'PaireNueEnLigneToolStripMenuItem
        '
        Me.PaireNueEnLigneToolStripMenuItem.Name = "PaireNueEnLigneToolStripMenuItem"
        Me.PaireNueEnLigneToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.PaireNueEnLigneToolStripMenuItem.Text = "En ligne"
        '
        'PaireNueEnColonneToolStripMenuItem
        '
        Me.PaireNueEnColonneToolStripMenuItem.Name = "PaireNueEnColonneToolStripMenuItem"
        Me.PaireNueEnColonneToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.PaireNueEnColonneToolStripMenuItem.Text = "En Colonne"
        '
        'EnRégionToolStripMenuItem
        '
        Me.EnRégionToolStripMenuItem.Name = "EnRégionToolStripMenuItem"
        Me.EnRégionToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.EnRégionToolStripMenuItem.Text = "En Région"
        '
        'XYwingToolStripMenuItem
        '
        Me.XYwingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.XYWingEnLigneToolStripMenuItem})
        Me.XYwingToolStripMenuItem.Name = "XYwingToolStripMenuItem"
        Me.XYwingToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.XYwingToolStripMenuItem.Text = "XY-wing"
        '
        'XYWingEnLigneToolStripMenuItem
        '
        Me.XYWingEnLigneToolStripMenuItem.Name = "XYWingEnLigneToolStripMenuItem"
        Me.XYWingEnLigneToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.XYWingEnLigneToolStripMenuItem.Text = "En Ligne"
        '
        'XWingToolStripMenuItem
        '
        Me.XWingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.XWingEnLigneToolStripMenuItem, Me.XWingEnColonneToolStripMenuItem})
        Me.XWingToolStripMenuItem.Name = "XWingToolStripMenuItem"
        Me.XWingToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.XWingToolStripMenuItem.Text = "X-Wing"
        '
        'XWingEnLigneToolStripMenuItem
        '
        Me.XWingEnLigneToolStripMenuItem.Name = "XWingEnLigneToolStripMenuItem"
        Me.XWingEnLigneToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.XWingEnLigneToolStripMenuItem.Text = "En ligne"
        '
        'XWingEnColonneToolStripMenuItem
        '
        Me.XWingEnColonneToolStripMenuItem.Name = "XWingEnColonneToolStripMenuItem"
        Me.XWingEnColonneToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.XWingEnColonneToolStripMenuItem.Text = "En colonne"
        '
        'TripletNuToolStripMenuItem
        '
        Me.TripletNuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TripletNuEnLigneToolStripMenuItem})
        Me.TripletNuToolStripMenuItem.Name = "TripletNuToolStripMenuItem"
        Me.TripletNuToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.TripletNuToolStripMenuItem.Text = "Triplet nu"
        '
        'TripletNuEnLigneToolStripMenuItem
        '
        Me.TripletNuEnLigneToolStripMenuItem.Name = "TripletNuEnLigneToolStripMenuItem"
        Me.TripletNuEnLigneToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.TripletNuEnLigneToolStripMenuItem.Text = "En ligne"
        '
        'GénérerToolStripMenuItem
        '
        Me.GénérerToolStripMenuItem.Name = "GénérerToolStripMenuItem"
        Me.GénérerToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.GénérerToolStripMenuItem.Text = "Générer"
        '
        'QuitterToolStripMenuItem
        '
        Me.QuitterToolStripMenuItem.Name = "QuitterToolStripMenuItem"
        Me.QuitterToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.QuitterToolStripMenuItem.Text = "Quitter"
        '
        'GrilleToolStripMenuItem
        '
        Me.GrilleToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AfficherLesCandidatsToolStripMenuItem, Me.EffacerLesCandidatsToolStripMenuItem})
        Me.GrilleToolStripMenuItem.Name = "GrilleToolStripMenuItem"
        Me.GrilleToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.GrilleToolStripMenuItem.Text = "Grille"
        '
        'AfficherLesCandidatsToolStripMenuItem
        '
        Me.AfficherLesCandidatsToolStripMenuItem.Name = "AfficherLesCandidatsToolStripMenuItem"
        Me.AfficherLesCandidatsToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.AfficherLesCandidatsToolStripMenuItem.Text = "Afficher les candidats"
        '
        'EffacerLesCandidatsToolStripMenuItem
        '
        Me.EffacerLesCandidatsToolStripMenuItem.Name = "EffacerLesCandidatsToolStripMenuItem"
        Me.EffacerLesCandidatsToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.EffacerLesCandidatsToolStripMenuItem.Text = "Effacer les candidats"
        '
        'LBL_Conseil
        '
        Me.LBL_Conseil.AutoSize = True
        Me.LBL_Conseil.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_Conseil.Location = New System.Drawing.Point(347, 715)
        Me.LBL_Conseil.Name = "LBL_Conseil"
        Me.LBL_Conseil.Size = New System.Drawing.Size(60, 25)
        Me.LBL_Conseil.TabIndex = 1002
        Me.LBL_Conseil.Text = "Label"
        '
        'BT_Solutions
        '
        Me.BT_Solutions.Location = New System.Drawing.Point(50, 150)
        Me.BT_Solutions.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BT_Solutions.Name = "BT_Solutions"
        Me.BT_Solutions.Size = New System.Drawing.Size(123, 35)
        Me.BT_Solutions.TabIndex = 1004
        Me.BT_Solutions.Text = "Solutions"
        Me.BT_Solutions.UseVisualStyleBackColor = True
        '
        'BT_Smp
        '
        Me.BT_Smp.Location = New System.Drawing.Point(50, 210)
        Me.BT_Smp.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BT_Smp.Name = "BT_Smp"
        Me.BT_Smp.Size = New System.Drawing.Size(123, 37)
        Me.BT_Smp.TabIndex = 1005
        Me.BT_Smp.Text = "Simplifications"
        Me.BT_Smp.UseVisualStyleBackColor = True
        '
        'BT_1
        '
        Me.BT_1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.BT_1.Location = New System.Drawing.Point(50, 74)
        Me.BT_1.Name = "BT_1"
        Me.BT_1.Size = New System.Drawing.Size(45, 45)
        Me.BT_1.TabIndex = 1083
        Me.BT_1.Text = "1"
        Me.BT_1.UseVisualStyleBackColor = False
        '
        'BT_2
        '
        Me.BT_2.BackColor = System.Drawing.Color.LightSkyBlue
        Me.BT_2.Location = New System.Drawing.Point(101, 74)
        Me.BT_2.Name = "BT_2"
        Me.BT_2.Size = New System.Drawing.Size(45, 45)
        Me.BT_2.TabIndex = 1084
        Me.BT_2.Text = "2"
        Me.BT_2.UseVisualStyleBackColor = False
        '
        'BT_3
        '
        Me.BT_3.BackColor = System.Drawing.Color.LightSkyBlue
        Me.BT_3.Location = New System.Drawing.Point(150, 74)
        Me.BT_3.Name = "BT_3"
        Me.BT_3.Size = New System.Drawing.Size(45, 45)
        Me.BT_3.TabIndex = 1085
        Me.BT_3.Text = "3"
        Me.BT_3.UseVisualStyleBackColor = False
        '
        'BT_4
        '
        Me.BT_4.BackColor = System.Drawing.Color.LightSkyBlue
        Me.BT_4.Location = New System.Drawing.Point(200, 74)
        Me.BT_4.Name = "BT_4"
        Me.BT_4.Size = New System.Drawing.Size(45, 45)
        Me.BT_4.TabIndex = 1086
        Me.BT_4.Text = "4"
        Me.BT_4.UseVisualStyleBackColor = False
        '
        'BT_5
        '
        Me.BT_5.BackColor = System.Drawing.Color.LightSkyBlue
        Me.BT_5.Location = New System.Drawing.Point(250, 74)
        Me.BT_5.Name = "BT_5"
        Me.BT_5.Size = New System.Drawing.Size(45, 45)
        Me.BT_5.TabIndex = 1087
        Me.BT_5.Text = "5"
        Me.BT_5.UseVisualStyleBackColor = False
        '
        'BT_6
        '
        Me.BT_6.BackColor = System.Drawing.Color.LightSkyBlue
        Me.BT_6.Location = New System.Drawing.Point(300, 74)
        Me.BT_6.Name = "BT_6"
        Me.BT_6.Size = New System.Drawing.Size(45, 45)
        Me.BT_6.TabIndex = 1088
        Me.BT_6.Text = "6"
        Me.BT_6.UseVisualStyleBackColor = False
        '
        'BT_7
        '
        Me.BT_7.BackColor = System.Drawing.Color.LightSkyBlue
        Me.BT_7.Location = New System.Drawing.Point(350, 74)
        Me.BT_7.Name = "BT_7"
        Me.BT_7.Size = New System.Drawing.Size(45, 45)
        Me.BT_7.TabIndex = 1089
        Me.BT_7.Text = "7"
        Me.BT_7.UseVisualStyleBackColor = False
        '
        'BT_8
        '
        Me.BT_8.BackColor = System.Drawing.Color.LightSkyBlue
        Me.BT_8.Location = New System.Drawing.Point(400, 74)
        Me.BT_8.Name = "BT_8"
        Me.BT_8.Size = New System.Drawing.Size(45, 45)
        Me.BT_8.TabIndex = 1090
        Me.BT_8.Text = "8"
        Me.BT_8.UseVisualStyleBackColor = False
        '
        'BT_9
        '
        Me.BT_9.BackColor = System.Drawing.Color.LightSkyBlue
        Me.BT_9.Location = New System.Drawing.Point(450, 74)
        Me.BT_9.Name = "BT_9"
        Me.BT_9.Size = New System.Drawing.Size(45, 45)
        Me.BT_9.TabIndex = 1091
        Me.BT_9.Text = "9"
        Me.BT_9.UseVisualStyleBackColor = False
        '
        'BT_Clear
        '
        Me.BT_Clear.BackColor = System.Drawing.Color.LightSkyBlue
        Me.BT_Clear.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_Clear.Location = New System.Drawing.Point(500, 74)
        Me.BT_Clear.Name = "BT_Clear"
        Me.BT_Clear.Size = New System.Drawing.Size(45, 45)
        Me.BT_Clear.TabIndex = 1092
        Me.BT_Clear.Text = "Effacer"
        Me.BT_Clear.UseVisualStyleBackColor = False
        '
        'BT00
        '
        Me.BT00.BackColor = System.Drawing.Color.Azure
        Me.BT00.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT00.Location = New System.Drawing.Point(350, 150)
        Me.BT00.Name = "BT00"
        Me.BT00.Size = New System.Drawing.Size(57, 57)
        Me.BT00.TabIndex = 100
        Me.BT00.Text = "1"
        Me.BT00.UseVisualStyleBackColor = False
        '
        'BT01
        '
        Me.BT01.BackColor = System.Drawing.Color.Azure
        Me.BT01.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT01.Location = New System.Drawing.Point(410, 150)
        Me.BT01.Name = "BT01"
        Me.BT01.Size = New System.Drawing.Size(57, 57)
        Me.BT01.TabIndex = 101
        Me.BT01.Text = "1"
        Me.BT01.UseVisualStyleBackColor = False
        '
        'BT02
        '
        Me.BT02.BackColor = System.Drawing.Color.Azure
        Me.BT02.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT02.Location = New System.Drawing.Point(470, 150)
        Me.BT02.Name = "BT02"
        Me.BT02.Size = New System.Drawing.Size(57, 57)
        Me.BT02.TabIndex = 102
        Me.BT02.Text = "1"
        Me.BT02.UseVisualStyleBackColor = False
        '
        'BT03
        '
        Me.BT03.BackColor = System.Drawing.Color.LightCyan
        Me.BT03.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT03.Location = New System.Drawing.Point(530, 150)
        Me.BT03.Name = "BT03"
        Me.BT03.Size = New System.Drawing.Size(57, 57)
        Me.BT03.TabIndex = 103
        Me.BT03.Text = "1"
        Me.BT03.UseVisualStyleBackColor = False
        '
        'BT04
        '
        Me.BT04.BackColor = System.Drawing.Color.LightCyan
        Me.BT04.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT04.Location = New System.Drawing.Point(590, 150)
        Me.BT04.Name = "BT04"
        Me.BT04.Size = New System.Drawing.Size(57, 57)
        Me.BT04.TabIndex = 104
        Me.BT04.Text = "1"
        Me.BT04.UseVisualStyleBackColor = False
        '
        'BT05
        '
        Me.BT05.BackColor = System.Drawing.Color.LightCyan
        Me.BT05.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT05.Location = New System.Drawing.Point(650, 150)
        Me.BT05.Name = "BT05"
        Me.BT05.Size = New System.Drawing.Size(57, 57)
        Me.BT05.TabIndex = 105
        Me.BT05.Text = "1"
        Me.BT05.UseVisualStyleBackColor = False
        '
        'BT08
        '
        Me.BT08.BackColor = System.Drawing.Color.Azure
        Me.BT08.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT08.Location = New System.Drawing.Point(830, 150)
        Me.BT08.Name = "BT08"
        Me.BT08.Size = New System.Drawing.Size(57, 57)
        Me.BT08.TabIndex = 108
        Me.BT08.Text = "1"
        Me.BT08.UseVisualStyleBackColor = False
        '
        'BT07
        '
        Me.BT07.BackColor = System.Drawing.Color.Azure
        Me.BT07.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT07.Location = New System.Drawing.Point(770, 150)
        Me.BT07.Name = "BT07"
        Me.BT07.Size = New System.Drawing.Size(57, 57)
        Me.BT07.TabIndex = 107
        Me.BT07.Text = "1"
        Me.BT07.UseVisualStyleBackColor = False
        '
        'BT06
        '
        Me.BT06.BackColor = System.Drawing.Color.Azure
        Me.BT06.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT06.Location = New System.Drawing.Point(710, 150)
        Me.BT06.Name = "BT06"
        Me.BT06.Size = New System.Drawing.Size(57, 57)
        Me.BT06.TabIndex = 106
        Me.BT06.Text = "1"
        Me.BT06.UseVisualStyleBackColor = False
        '
        'BT17
        '
        Me.BT17.BackColor = System.Drawing.Color.Azure
        Me.BT17.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT17.Location = New System.Drawing.Point(830, 210)
        Me.BT17.Name = "BT17"
        Me.BT17.Size = New System.Drawing.Size(57, 57)
        Me.BT17.TabIndex = 117
        Me.BT17.Text = "1"
        Me.BT17.UseVisualStyleBackColor = False
        '
        'BT16
        '
        Me.BT16.BackColor = System.Drawing.Color.Azure
        Me.BT16.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT16.Location = New System.Drawing.Point(770, 210)
        Me.BT16.Name = "BT16"
        Me.BT16.Size = New System.Drawing.Size(57, 57)
        Me.BT16.TabIndex = 116
        Me.BT16.Text = "1"
        Me.BT16.UseVisualStyleBackColor = False
        '
        'BT15
        '
        Me.BT15.BackColor = System.Drawing.Color.Azure
        Me.BT15.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT15.Location = New System.Drawing.Point(710, 210)
        Me.BT15.Name = "BT15"
        Me.BT15.Size = New System.Drawing.Size(57, 57)
        Me.BT15.TabIndex = 115
        Me.BT15.Text = "1"
        Me.BT15.UseVisualStyleBackColor = False
        '
        'BT14
        '
        Me.BT14.BackColor = System.Drawing.Color.LightCyan
        Me.BT14.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT14.Location = New System.Drawing.Point(650, 210)
        Me.BT14.Name = "BT14"
        Me.BT14.Size = New System.Drawing.Size(57, 57)
        Me.BT14.TabIndex = 114
        Me.BT14.Text = "1"
        Me.BT14.UseVisualStyleBackColor = False
        '
        'BT13
        '
        Me.BT13.BackColor = System.Drawing.Color.LightCyan
        Me.BT13.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT13.Location = New System.Drawing.Point(590, 210)
        Me.BT13.Name = "BT13"
        Me.BT13.Size = New System.Drawing.Size(57, 57)
        Me.BT13.TabIndex = 113
        Me.BT13.Text = "1"
        Me.BT13.UseVisualStyleBackColor = False
        '
        'BT12
        '
        Me.BT12.BackColor = System.Drawing.Color.LightCyan
        Me.BT12.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT12.Location = New System.Drawing.Point(530, 210)
        Me.BT12.Name = "BT12"
        Me.BT12.Size = New System.Drawing.Size(57, 57)
        Me.BT12.TabIndex = 112
        Me.BT12.Text = "1"
        Me.BT12.UseVisualStyleBackColor = False
        '
        'BT11
        '
        Me.BT11.BackColor = System.Drawing.Color.Azure
        Me.BT11.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT11.Location = New System.Drawing.Point(470, 210)
        Me.BT11.Name = "BT11"
        Me.BT11.Size = New System.Drawing.Size(57, 57)
        Me.BT11.TabIndex = 111
        Me.BT11.Text = "1"
        Me.BT11.UseVisualStyleBackColor = False
        '
        'BT10
        '
        Me.BT10.BackColor = System.Drawing.Color.Azure
        Me.BT10.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT10.Location = New System.Drawing.Point(410, 210)
        Me.BT10.Name = "BT10"
        Me.BT10.Size = New System.Drawing.Size(57, 57)
        Me.BT10.TabIndex = 110
        Me.BT10.Text = "1"
        Me.BT10.UseVisualStyleBackColor = False
        '
        'BT09
        '
        Me.BT09.BackColor = System.Drawing.Color.Azure
        Me.BT09.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT09.Location = New System.Drawing.Point(350, 210)
        Me.BT09.Name = "BT09"
        Me.BT09.Size = New System.Drawing.Size(57, 57)
        Me.BT09.TabIndex = 109
        Me.BT09.Text = "1"
        Me.BT09.UseVisualStyleBackColor = False
        '
        'BT26
        '
        Me.BT26.BackColor = System.Drawing.Color.Azure
        Me.BT26.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT26.Location = New System.Drawing.Point(830, 270)
        Me.BT26.Name = "BT26"
        Me.BT26.Size = New System.Drawing.Size(57, 57)
        Me.BT26.TabIndex = 126
        Me.BT26.Text = "1"
        Me.BT26.UseVisualStyleBackColor = False
        '
        'BT25
        '
        Me.BT25.BackColor = System.Drawing.Color.Azure
        Me.BT25.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT25.Location = New System.Drawing.Point(770, 270)
        Me.BT25.Name = "BT25"
        Me.BT25.Size = New System.Drawing.Size(57, 57)
        Me.BT25.TabIndex = 125
        Me.BT25.Text = "1"
        Me.BT25.UseVisualStyleBackColor = False
        '
        'BT24
        '
        Me.BT24.BackColor = System.Drawing.Color.Azure
        Me.BT24.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT24.Location = New System.Drawing.Point(710, 270)
        Me.BT24.Name = "BT24"
        Me.BT24.Size = New System.Drawing.Size(57, 57)
        Me.BT24.TabIndex = 124
        Me.BT24.Text = "1"
        Me.BT24.UseVisualStyleBackColor = False
        '
        'BT23
        '
        Me.BT23.BackColor = System.Drawing.Color.LightCyan
        Me.BT23.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT23.Location = New System.Drawing.Point(650, 270)
        Me.BT23.Name = "BT23"
        Me.BT23.Size = New System.Drawing.Size(57, 57)
        Me.BT23.TabIndex = 123
        Me.BT23.Text = "1"
        Me.BT23.UseVisualStyleBackColor = False
        '
        'BT22
        '
        Me.BT22.BackColor = System.Drawing.Color.LightCyan
        Me.BT22.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT22.Location = New System.Drawing.Point(590, 270)
        Me.BT22.Name = "BT22"
        Me.BT22.Size = New System.Drawing.Size(57, 57)
        Me.BT22.TabIndex = 122
        Me.BT22.Text = "1"
        Me.BT22.UseVisualStyleBackColor = False
        '
        'BT21
        '
        Me.BT21.BackColor = System.Drawing.Color.LightCyan
        Me.BT21.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT21.Location = New System.Drawing.Point(530, 270)
        Me.BT21.Name = "BT21"
        Me.BT21.Size = New System.Drawing.Size(57, 57)
        Me.BT21.TabIndex = 121
        Me.BT21.Text = "1"
        Me.BT21.UseVisualStyleBackColor = False
        '
        'BT20
        '
        Me.BT20.BackColor = System.Drawing.Color.Azure
        Me.BT20.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT20.Location = New System.Drawing.Point(470, 270)
        Me.BT20.Name = "BT20"
        Me.BT20.Size = New System.Drawing.Size(57, 57)
        Me.BT20.TabIndex = 120
        Me.BT20.Text = "1"
        Me.BT20.UseVisualStyleBackColor = False
        '
        'BT19
        '
        Me.BT19.BackColor = System.Drawing.Color.Azure
        Me.BT19.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT19.Location = New System.Drawing.Point(410, 270)
        Me.BT19.Name = "BT19"
        Me.BT19.Size = New System.Drawing.Size(57, 57)
        Me.BT19.TabIndex = 119
        Me.BT19.Text = "1"
        Me.BT19.UseVisualStyleBackColor = False
        '
        'BT18
        '
        Me.BT18.BackColor = System.Drawing.Color.Azure
        Me.BT18.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT18.Location = New System.Drawing.Point(350, 270)
        Me.BT18.Name = "BT18"
        Me.BT18.Size = New System.Drawing.Size(57, 57)
        Me.BT18.TabIndex = 118
        Me.BT18.Text = "1"
        Me.BT18.UseVisualStyleBackColor = False
        '
        'BT32
        '
        Me.BT32.BackColor = System.Drawing.Color.Azure
        Me.BT32.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT32.Location = New System.Drawing.Point(650, 330)
        Me.BT32.Name = "BT32"
        Me.BT32.Size = New System.Drawing.Size(57, 57)
        Me.BT32.TabIndex = 132
        Me.BT32.Text = "1"
        Me.BT32.UseVisualStyleBackColor = False
        '
        'BT31
        '
        Me.BT31.BackColor = System.Drawing.Color.Azure
        Me.BT31.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT31.Location = New System.Drawing.Point(590, 330)
        Me.BT31.Name = "BT31"
        Me.BT31.Size = New System.Drawing.Size(57, 57)
        Me.BT31.TabIndex = 131
        Me.BT31.Text = "1"
        Me.BT31.UseVisualStyleBackColor = False
        '
        'BT30
        '
        Me.BT30.BackColor = System.Drawing.Color.Azure
        Me.BT30.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT30.Location = New System.Drawing.Point(530, 330)
        Me.BT30.Name = "BT30"
        Me.BT30.Size = New System.Drawing.Size(57, 57)
        Me.BT30.TabIndex = 130
        Me.BT30.Text = "1"
        Me.BT30.UseVisualStyleBackColor = False
        '
        'BT29
        '
        Me.BT29.BackColor = System.Drawing.Color.LightCyan
        Me.BT29.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT29.Location = New System.Drawing.Point(470, 330)
        Me.BT29.Name = "BT29"
        Me.BT29.Size = New System.Drawing.Size(57, 57)
        Me.BT29.TabIndex = 129
        Me.BT29.Text = "1"
        Me.BT29.UseVisualStyleBackColor = False
        '
        'BT28
        '
        Me.BT28.BackColor = System.Drawing.Color.LightCyan
        Me.BT28.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT28.Location = New System.Drawing.Point(410, 330)
        Me.BT28.Name = "BT28"
        Me.BT28.Size = New System.Drawing.Size(57, 57)
        Me.BT28.TabIndex = 128
        Me.BT28.Text = "1"
        Me.BT28.UseVisualStyleBackColor = False
        '
        'BT27
        '
        Me.BT27.BackColor = System.Drawing.Color.LightCyan
        Me.BT27.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT27.Location = New System.Drawing.Point(350, 330)
        Me.BT27.Name = "BT27"
        Me.BT27.Size = New System.Drawing.Size(57, 57)
        Me.BT27.TabIndex = 127
        Me.BT27.Text = "1"
        Me.BT27.UseVisualStyleBackColor = False
        '
        'BT35
        '
        Me.BT35.BackColor = System.Drawing.Color.LightCyan
        Me.BT35.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT35.Location = New System.Drawing.Point(830, 330)
        Me.BT35.Name = "BT35"
        Me.BT35.Size = New System.Drawing.Size(57, 57)
        Me.BT35.TabIndex = 135
        Me.BT35.Text = "1"
        Me.BT35.UseVisualStyleBackColor = False
        '
        'BT34
        '
        Me.BT34.BackColor = System.Drawing.Color.LightCyan
        Me.BT34.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT34.Location = New System.Drawing.Point(770, 330)
        Me.BT34.Name = "BT34"
        Me.BT34.Size = New System.Drawing.Size(57, 57)
        Me.BT34.TabIndex = 134
        Me.BT34.Text = "1"
        Me.BT34.UseVisualStyleBackColor = False
        '
        'BT33
        '
        Me.BT33.BackColor = System.Drawing.Color.LightCyan
        Me.BT33.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT33.Location = New System.Drawing.Point(710, 330)
        Me.BT33.Name = "BT33"
        Me.BT33.Size = New System.Drawing.Size(57, 57)
        Me.BT33.TabIndex = 133
        Me.BT33.Text = "1"
        Me.BT33.UseVisualStyleBackColor = False
        '
        'BT44
        '
        Me.BT44.BackColor = System.Drawing.Color.LightCyan
        Me.BT44.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT44.Location = New System.Drawing.Point(830, 390)
        Me.BT44.Name = "BT44"
        Me.BT44.Size = New System.Drawing.Size(57, 57)
        Me.BT44.TabIndex = 144
        Me.BT44.Text = "1"
        Me.BT44.UseVisualStyleBackColor = False
        '
        'BT43
        '
        Me.BT43.BackColor = System.Drawing.Color.LightCyan
        Me.BT43.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT43.Location = New System.Drawing.Point(770, 390)
        Me.BT43.Name = "BT43"
        Me.BT43.Size = New System.Drawing.Size(57, 57)
        Me.BT43.TabIndex = 143
        Me.BT43.Text = "1"
        Me.BT43.UseVisualStyleBackColor = False
        '
        'BT42
        '
        Me.BT42.BackColor = System.Drawing.Color.LightCyan
        Me.BT42.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT42.Location = New System.Drawing.Point(710, 390)
        Me.BT42.Name = "BT42"
        Me.BT42.Size = New System.Drawing.Size(57, 57)
        Me.BT42.TabIndex = 142
        Me.BT42.Text = "1"
        Me.BT42.UseVisualStyleBackColor = False
        '
        'BT41
        '
        Me.BT41.BackColor = System.Drawing.Color.Azure
        Me.BT41.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT41.Location = New System.Drawing.Point(650, 390)
        Me.BT41.Name = "BT41"
        Me.BT41.Size = New System.Drawing.Size(57, 57)
        Me.BT41.TabIndex = 141
        Me.BT41.Text = "1"
        Me.BT41.UseVisualStyleBackColor = False
        '
        'BT40
        '
        Me.BT40.BackColor = System.Drawing.Color.Azure
        Me.BT40.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT40.Location = New System.Drawing.Point(590, 390)
        Me.BT40.Name = "BT40"
        Me.BT40.Size = New System.Drawing.Size(57, 57)
        Me.BT40.TabIndex = 140
        Me.BT40.Text = "1"
        Me.BT40.UseVisualStyleBackColor = False
        '
        'BT39
        '
        Me.BT39.BackColor = System.Drawing.Color.Azure
        Me.BT39.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT39.Location = New System.Drawing.Point(530, 390)
        Me.BT39.Name = "BT39"
        Me.BT39.Size = New System.Drawing.Size(57, 57)
        Me.BT39.TabIndex = 139
        Me.BT39.Text = "1"
        Me.BT39.UseVisualStyleBackColor = False
        '
        'BT38
        '
        Me.BT38.BackColor = System.Drawing.Color.LightCyan
        Me.BT38.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT38.Location = New System.Drawing.Point(470, 390)
        Me.BT38.Name = "BT38"
        Me.BT38.Size = New System.Drawing.Size(57, 57)
        Me.BT38.TabIndex = 138
        Me.BT38.Text = "1"
        Me.BT38.UseVisualStyleBackColor = False
        '
        'BT37
        '
        Me.BT37.BackColor = System.Drawing.Color.LightCyan
        Me.BT37.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT37.Location = New System.Drawing.Point(410, 390)
        Me.BT37.Name = "BT37"
        Me.BT37.Size = New System.Drawing.Size(57, 57)
        Me.BT37.TabIndex = 137
        Me.BT37.Text = "1"
        Me.BT37.UseVisualStyleBackColor = False
        '
        'Bt36
        '
        Me.Bt36.BackColor = System.Drawing.Color.LightCyan
        Me.Bt36.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt36.Location = New System.Drawing.Point(350, 390)
        Me.Bt36.Name = "Bt36"
        Me.Bt36.Size = New System.Drawing.Size(57, 57)
        Me.Bt36.TabIndex = 136
        Me.Bt36.Text = "1"
        Me.Bt36.UseVisualStyleBackColor = False
        '
        'BT53
        '
        Me.BT53.BackColor = System.Drawing.Color.LightCyan
        Me.BT53.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT53.Location = New System.Drawing.Point(830, 450)
        Me.BT53.Name = "BT53"
        Me.BT53.Size = New System.Drawing.Size(57, 57)
        Me.BT53.TabIndex = 153
        Me.BT53.Text = "1"
        Me.BT53.UseVisualStyleBackColor = False
        '
        'BT52
        '
        Me.BT52.BackColor = System.Drawing.Color.LightCyan
        Me.BT52.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT52.Location = New System.Drawing.Point(770, 450)
        Me.BT52.Name = "BT52"
        Me.BT52.Size = New System.Drawing.Size(57, 57)
        Me.BT52.TabIndex = 152
        Me.BT52.Text = "1"
        Me.BT52.UseVisualStyleBackColor = False
        '
        'BT51
        '
        Me.BT51.BackColor = System.Drawing.Color.LightCyan
        Me.BT51.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT51.Location = New System.Drawing.Point(713, 450)
        Me.BT51.Name = "BT51"
        Me.BT51.Size = New System.Drawing.Size(57, 57)
        Me.BT51.TabIndex = 151
        Me.BT51.Text = "1"
        Me.BT51.UseVisualStyleBackColor = False
        '
        'BT50
        '
        Me.BT50.BackColor = System.Drawing.Color.Azure
        Me.BT50.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT50.Location = New System.Drawing.Point(650, 450)
        Me.BT50.Name = "BT50"
        Me.BT50.Size = New System.Drawing.Size(57, 57)
        Me.BT50.TabIndex = 150
        Me.BT50.Text = "1"
        Me.BT50.UseVisualStyleBackColor = False
        '
        'BT49
        '
        Me.BT49.BackColor = System.Drawing.Color.Azure
        Me.BT49.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT49.Location = New System.Drawing.Point(590, 450)
        Me.BT49.Name = "BT49"
        Me.BT49.Size = New System.Drawing.Size(57, 57)
        Me.BT49.TabIndex = 149
        Me.BT49.Text = "1"
        Me.BT49.UseVisualStyleBackColor = False
        '
        'BT48
        '
        Me.BT48.BackColor = System.Drawing.Color.Azure
        Me.BT48.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT48.Location = New System.Drawing.Point(530, 450)
        Me.BT48.Name = "BT48"
        Me.BT48.Size = New System.Drawing.Size(57, 57)
        Me.BT48.TabIndex = 148
        Me.BT48.Text = "1"
        Me.BT48.UseVisualStyleBackColor = False
        '
        'BT47
        '
        Me.BT47.BackColor = System.Drawing.Color.LightCyan
        Me.BT47.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT47.Location = New System.Drawing.Point(470, 450)
        Me.BT47.Name = "BT47"
        Me.BT47.Size = New System.Drawing.Size(57, 57)
        Me.BT47.TabIndex = 147
        Me.BT47.Text = "1"
        Me.BT47.UseVisualStyleBackColor = False
        '
        'BT46
        '
        Me.BT46.BackColor = System.Drawing.Color.LightCyan
        Me.BT46.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT46.Location = New System.Drawing.Point(410, 450)
        Me.BT46.Name = "BT46"
        Me.BT46.Size = New System.Drawing.Size(57, 57)
        Me.BT46.TabIndex = 146
        Me.BT46.Text = "1"
        Me.BT46.UseVisualStyleBackColor = False
        '
        'BT45
        '
        Me.BT45.BackColor = System.Drawing.Color.LightCyan
        Me.BT45.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT45.Location = New System.Drawing.Point(350, 450)
        Me.BT45.Name = "BT45"
        Me.BT45.Size = New System.Drawing.Size(57, 57)
        Me.BT45.TabIndex = 145
        Me.BT45.Text = "1"
        Me.BT45.UseVisualStyleBackColor = False
        '
        'BT80
        '
        Me.BT80.BackColor = System.Drawing.Color.Azure
        Me.BT80.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT80.Location = New System.Drawing.Point(830, 630)
        Me.BT80.Name = "BT80"
        Me.BT80.Size = New System.Drawing.Size(57, 57)
        Me.BT80.TabIndex = 180
        Me.BT80.Text = "1"
        Me.BT80.UseVisualStyleBackColor = False
        '
        'BT79
        '
        Me.BT79.BackColor = System.Drawing.Color.Azure
        Me.BT79.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT79.Location = New System.Drawing.Point(770, 630)
        Me.BT79.Name = "BT79"
        Me.BT79.Size = New System.Drawing.Size(57, 57)
        Me.BT79.TabIndex = 179
        Me.BT79.Text = "1"
        Me.BT79.UseVisualStyleBackColor = False
        '
        'BT78
        '
        Me.BT78.BackColor = System.Drawing.Color.Azure
        Me.BT78.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT78.Location = New System.Drawing.Point(710, 630)
        Me.BT78.Name = "BT78"
        Me.BT78.Size = New System.Drawing.Size(57, 57)
        Me.BT78.TabIndex = 178
        Me.BT78.Text = "1"
        Me.BT78.UseVisualStyleBackColor = False
        '
        'BT77
        '
        Me.BT77.BackColor = System.Drawing.Color.LightCyan
        Me.BT77.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT77.Location = New System.Drawing.Point(650, 630)
        Me.BT77.Name = "BT77"
        Me.BT77.Size = New System.Drawing.Size(57, 57)
        Me.BT77.TabIndex = 177
        Me.BT77.Text = "1"
        Me.BT77.UseVisualStyleBackColor = False
        '
        'BT76
        '
        Me.BT76.BackColor = System.Drawing.Color.LightCyan
        Me.BT76.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT76.Location = New System.Drawing.Point(590, 630)
        Me.BT76.Name = "BT76"
        Me.BT76.Size = New System.Drawing.Size(57, 57)
        Me.BT76.TabIndex = 176
        Me.BT76.Text = "1"
        Me.BT76.UseVisualStyleBackColor = False
        '
        'BT75
        '
        Me.BT75.BackColor = System.Drawing.Color.LightCyan
        Me.BT75.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT75.Location = New System.Drawing.Point(530, 630)
        Me.BT75.Name = "BT75"
        Me.BT75.Size = New System.Drawing.Size(57, 57)
        Me.BT75.TabIndex = 175
        Me.BT75.Text = "1"
        Me.BT75.UseVisualStyleBackColor = False
        '
        'BT74
        '
        Me.BT74.BackColor = System.Drawing.Color.Azure
        Me.BT74.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT74.Location = New System.Drawing.Point(470, 630)
        Me.BT74.Name = "BT74"
        Me.BT74.Size = New System.Drawing.Size(57, 57)
        Me.BT74.TabIndex = 174
        Me.BT74.Text = "1"
        Me.BT74.UseVisualStyleBackColor = False
        '
        'BT73
        '
        Me.BT73.BackColor = System.Drawing.Color.Azure
        Me.BT73.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT73.Location = New System.Drawing.Point(410, 630)
        Me.BT73.Name = "BT73"
        Me.BT73.Size = New System.Drawing.Size(57, 57)
        Me.BT73.TabIndex = 173
        Me.BT73.Text = "1"
        Me.BT73.UseVisualStyleBackColor = False
        '
        'BT72
        '
        Me.BT72.BackColor = System.Drawing.Color.Azure
        Me.BT72.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT72.Location = New System.Drawing.Point(350, 630)
        Me.BT72.Name = "BT72"
        Me.BT72.Size = New System.Drawing.Size(57, 57)
        Me.BT72.TabIndex = 172
        Me.BT72.Text = "1"
        Me.BT72.UseVisualStyleBackColor = False
        '
        'BT71
        '
        Me.BT71.BackColor = System.Drawing.Color.Azure
        Me.BT71.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT71.Location = New System.Drawing.Point(830, 570)
        Me.BT71.Name = "BT71"
        Me.BT71.Size = New System.Drawing.Size(57, 57)
        Me.BT71.TabIndex = 171
        Me.BT71.Text = "1"
        Me.BT71.UseVisualStyleBackColor = False
        '
        'BT70
        '
        Me.BT70.BackColor = System.Drawing.Color.Azure
        Me.BT70.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT70.Location = New System.Drawing.Point(770, 570)
        Me.BT70.Name = "BT70"
        Me.BT70.Size = New System.Drawing.Size(57, 57)
        Me.BT70.TabIndex = 170
        Me.BT70.Text = "1"
        Me.BT70.UseVisualStyleBackColor = False
        '
        'BT69
        '
        Me.BT69.BackColor = System.Drawing.Color.Azure
        Me.BT69.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT69.Location = New System.Drawing.Point(710, 570)
        Me.BT69.Name = "BT69"
        Me.BT69.Size = New System.Drawing.Size(57, 57)
        Me.BT69.TabIndex = 169
        Me.BT69.Text = "1"
        Me.BT69.UseVisualStyleBackColor = False
        '
        'BT68
        '
        Me.BT68.BackColor = System.Drawing.Color.LightCyan
        Me.BT68.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT68.Location = New System.Drawing.Point(650, 570)
        Me.BT68.Name = "BT68"
        Me.BT68.Size = New System.Drawing.Size(57, 57)
        Me.BT68.TabIndex = 168
        Me.BT68.Text = "1"
        Me.BT68.UseVisualStyleBackColor = False
        '
        'BT67
        '
        Me.BT67.BackColor = System.Drawing.Color.LightCyan
        Me.BT67.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT67.Location = New System.Drawing.Point(590, 570)
        Me.BT67.Name = "BT67"
        Me.BT67.Size = New System.Drawing.Size(57, 57)
        Me.BT67.TabIndex = 167
        Me.BT67.Text = "1"
        Me.BT67.UseVisualStyleBackColor = False
        '
        'BT66
        '
        Me.BT66.BackColor = System.Drawing.Color.LightCyan
        Me.BT66.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT66.Location = New System.Drawing.Point(530, 570)
        Me.BT66.Name = "BT66"
        Me.BT66.Size = New System.Drawing.Size(57, 57)
        Me.BT66.TabIndex = 166
        Me.BT66.Text = "1"
        Me.BT66.UseVisualStyleBackColor = False
        '
        'BT65
        '
        Me.BT65.BackColor = System.Drawing.Color.Azure
        Me.BT65.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT65.Location = New System.Drawing.Point(470, 570)
        Me.BT65.Name = "BT65"
        Me.BT65.Size = New System.Drawing.Size(57, 57)
        Me.BT65.TabIndex = 165
        Me.BT65.Text = "1"
        Me.BT65.UseVisualStyleBackColor = False
        '
        'BT64
        '
        Me.BT64.BackColor = System.Drawing.Color.Azure
        Me.BT64.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT64.Location = New System.Drawing.Point(410, 570)
        Me.BT64.Name = "BT64"
        Me.BT64.Size = New System.Drawing.Size(57, 57)
        Me.BT64.TabIndex = 164
        Me.BT64.Text = "1"
        Me.BT64.UseVisualStyleBackColor = False
        '
        'BT63
        '
        Me.BT63.BackColor = System.Drawing.Color.Azure
        Me.BT63.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT63.Location = New System.Drawing.Point(350, 570)
        Me.BT63.Name = "BT63"
        Me.BT63.Size = New System.Drawing.Size(57, 57)
        Me.BT63.TabIndex = 163
        Me.BT63.Text = "1"
        Me.BT63.UseVisualStyleBackColor = False
        '
        'BT62
        '
        Me.BT62.BackColor = System.Drawing.Color.Azure
        Me.BT62.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT62.Location = New System.Drawing.Point(830, 510)
        Me.BT62.Name = "BT62"
        Me.BT62.Size = New System.Drawing.Size(57, 57)
        Me.BT62.TabIndex = 162
        Me.BT62.Text = "1"
        Me.BT62.UseVisualStyleBackColor = False
        '
        'BT61
        '
        Me.BT61.BackColor = System.Drawing.Color.Azure
        Me.BT61.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT61.Location = New System.Drawing.Point(770, 510)
        Me.BT61.Name = "BT61"
        Me.BT61.Size = New System.Drawing.Size(57, 57)
        Me.BT61.TabIndex = 161
        Me.BT61.Text = "1"
        Me.BT61.UseVisualStyleBackColor = False
        '
        'BT60
        '
        Me.BT60.BackColor = System.Drawing.Color.Azure
        Me.BT60.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT60.Location = New System.Drawing.Point(710, 510)
        Me.BT60.Name = "BT60"
        Me.BT60.Size = New System.Drawing.Size(57, 57)
        Me.BT60.TabIndex = 160
        Me.BT60.Text = "1"
        Me.BT60.UseVisualStyleBackColor = False
        '
        'Bt59
        '
        Me.Bt59.BackColor = System.Drawing.Color.LightCyan
        Me.Bt59.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt59.Location = New System.Drawing.Point(650, 510)
        Me.Bt59.Name = "Bt59"
        Me.Bt59.Size = New System.Drawing.Size(57, 57)
        Me.Bt59.TabIndex = 159
        Me.Bt59.Text = "1"
        Me.Bt59.UseVisualStyleBackColor = False
        '
        'BT58
        '
        Me.BT58.BackColor = System.Drawing.Color.LightCyan
        Me.BT58.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT58.Location = New System.Drawing.Point(590, 510)
        Me.BT58.Name = "BT58"
        Me.BT58.Size = New System.Drawing.Size(57, 57)
        Me.BT58.TabIndex = 158
        Me.BT58.Text = "1"
        Me.BT58.UseVisualStyleBackColor = False
        '
        'BT57
        '
        Me.BT57.BackColor = System.Drawing.Color.LightCyan
        Me.BT57.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT57.Location = New System.Drawing.Point(530, 510)
        Me.BT57.Name = "BT57"
        Me.BT57.Size = New System.Drawing.Size(57, 57)
        Me.BT57.TabIndex = 157
        Me.BT57.Text = "1"
        Me.BT57.UseVisualStyleBackColor = False
        '
        'BT56
        '
        Me.BT56.BackColor = System.Drawing.Color.Azure
        Me.BT56.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT56.Location = New System.Drawing.Point(470, 510)
        Me.BT56.Name = "BT56"
        Me.BT56.Size = New System.Drawing.Size(57, 57)
        Me.BT56.TabIndex = 156
        Me.BT56.Text = "1"
        Me.BT56.UseVisualStyleBackColor = False
        '
        'BT55
        '
        Me.BT55.BackColor = System.Drawing.Color.Azure
        Me.BT55.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT55.Location = New System.Drawing.Point(410, 510)
        Me.BT55.Name = "BT55"
        Me.BT55.Size = New System.Drawing.Size(57, 57)
        Me.BT55.TabIndex = 155
        Me.BT55.Text = "1"
        Me.BT55.UseVisualStyleBackColor = False
        '
        'BT54
        '
        Me.BT54.BackColor = System.Drawing.Color.Azure
        Me.BT54.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT54.Location = New System.Drawing.Point(350, 510)
        Me.BT54.Name = "BT54"
        Me.BT54.Size = New System.Drawing.Size(57, 57)
        Me.BT54.TabIndex = 154
        Me.BT54.Text = "1"
        Me.BT54.UseVisualStyleBackColor = False
        '
        'BTSolution
        '
        Me.BTSolution.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BTSolution.ForeColor = System.Drawing.Color.Black
        Me.BTSolution.Location = New System.Drawing.Point(830, 74)
        Me.BTSolution.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTSolution.Name = "BTSolution"
        Me.BTSolution.Size = New System.Drawing.Size(117, 45)
        Me.BTSolution.TabIndex = 1093
        Me.BTSolution.Text = "Solution"
        Me.BTSolution.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GénérerToolStripButton, Me.OuvrirToolStripButton1, Me.EnregistrerToolStripButton, Me.SaisirToolStripButton, Me.JouerToolStripButton1, Me.RecommencerToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1184, 25)
        Me.ToolStrip1.TabIndex = 1094
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'GénérerToolStripButton
        '
        Me.GénérerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.GénérerToolStripButton.Image = CType(resources.GetObject("GénérerToolStripButton.Image"), System.Drawing.Image)
        Me.GénérerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GénérerToolStripButton.Name = "GénérerToolStripButton"
        Me.GénérerToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.GénérerToolStripButton.Text = "Générer"
        '
        'OuvrirToolStripButton1
        '
        Me.OuvrirToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OuvrirToolStripButton1.Image = CType(resources.GetObject("OuvrirToolStripButton1.Image"), System.Drawing.Image)
        Me.OuvrirToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OuvrirToolStripButton1.Name = "OuvrirToolStripButton1"
        Me.OuvrirToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.OuvrirToolStripButton1.Text = "Ouvrir"
        '
        'EnregistrerToolStripButton
        '
        Me.EnregistrerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.EnregistrerToolStripButton.Image = CType(resources.GetObject("EnregistrerToolStripButton.Image"), System.Drawing.Image)
        Me.EnregistrerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EnregistrerToolStripButton.Name = "EnregistrerToolStripButton"
        Me.EnregistrerToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.EnregistrerToolStripButton.Text = "Enregistrer"
        '
        'SaisirToolStripButton
        '
        Me.SaisirToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaisirToolStripButton.Image = CType(resources.GetObject("SaisirToolStripButton.Image"), System.Drawing.Image)
        Me.SaisirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaisirToolStripButton.Name = "SaisirToolStripButton"
        Me.SaisirToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SaisirToolStripButton.Text = "Saisir"
        '
        'JouerToolStripButton1
        '
        Me.JouerToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.JouerToolStripButton1.Image = CType(resources.GetObject("JouerToolStripButton1.Image"), System.Drawing.Image)
        Me.JouerToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.JouerToolStripButton1.Name = "JouerToolStripButton1"
        Me.JouerToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.JouerToolStripButton1.Text = "Jouer"
        '
        'RecommencerToolStripButton
        '
        Me.RecommencerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.RecommencerToolStripButton.Enabled = False
        Me.RecommencerToolStripButton.Image = CType(resources.GetObject("RecommencerToolStripButton.Image"), System.Drawing.Image)
        Me.RecommencerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RecommencerToolStripButton.Name = "RecommencerToolStripButton"
        Me.RecommencerToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.RecommencerToolStripButton.Text = "Recommencer"
        '
        'BTStepByStep
        '
        Me.BTStepByStep.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BTStepByStep.ForeColor = System.Drawing.Color.Black
        Me.BTStepByStep.Location = New System.Drawing.Point(650, 73)
        Me.BTStepByStep.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTStepByStep.Name = "BTStepByStep"
        Me.BTStepByStep.Size = New System.Drawing.Size(117, 45)
        Me.BTStepByStep.TabIndex = 1095
        Me.BTStepByStep.Text = "Pas à pas"
        Me.BTStepByStep.UseVisualStyleBackColor = False
        '
        'LBL_nbVal
        '
        Me.LBL_nbVal.AutoSize = True
        Me.LBL_nbVal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_nbVal.Location = New System.Drawing.Point(50, 715)
        Me.LBL_nbVal.Name = "LBL_nbVal"
        Me.LBL_nbVal.Size = New System.Drawing.Size(0, 25)
        Me.LBL_nbVal.TabIndex = 1096
        '
        'nomFichierOuvert
        '
        Me.nomFichierOuvert.AutoSize = True
        Me.nomFichierOuvert.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nomFichierOuvert.Location = New System.Drawing.Point(350, 761)
        Me.nomFichierOuvert.Name = "nomFichierOuvert"
        Me.nomFichierOuvert.Size = New System.Drawing.Size(77, 25)
        Me.nomFichierOuvert.TabIndex = 1097
        Me.nomFichierOuvert.Text = "Fichier"
        '
        'BTForceBrute
        '
        Me.BTForceBrute.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BTForceBrute.ForeColor = System.Drawing.Color.Black
        Me.BTForceBrute.Location = New System.Drawing.Point(1000, 74)
        Me.BTForceBrute.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTForceBrute.Name = "BTForceBrute"
        Me.BTForceBrute.Size = New System.Drawing.Size(117, 45)
        Me.BTForceBrute.TabIndex = 1098
        Me.BTForceBrute.Text = "Force Brute"
        Me.BTForceBrute.UseVisualStyleBackColor = False
        '
        'Sudoku
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1184, 810)
        Me.Controls.Add(Me.BTForceBrute)
        Me.Controls.Add(Me.nomFichierOuvert)
        Me.Controls.Add(Me.LBL_nbVal)
        Me.Controls.Add(Me.BTStepByStep)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.BTSolution)
        Me.Controls.Add(Me.BT80)
        Me.Controls.Add(Me.BT79)
        Me.Controls.Add(Me.BT78)
        Me.Controls.Add(Me.BT77)
        Me.Controls.Add(Me.BT76)
        Me.Controls.Add(Me.BT75)
        Me.Controls.Add(Me.BT74)
        Me.Controls.Add(Me.BT73)
        Me.Controls.Add(Me.BT72)
        Me.Controls.Add(Me.BT71)
        Me.Controls.Add(Me.BT70)
        Me.Controls.Add(Me.BT69)
        Me.Controls.Add(Me.BT68)
        Me.Controls.Add(Me.BT67)
        Me.Controls.Add(Me.BT66)
        Me.Controls.Add(Me.BT65)
        Me.Controls.Add(Me.BT64)
        Me.Controls.Add(Me.BT63)
        Me.Controls.Add(Me.BT62)
        Me.Controls.Add(Me.BT61)
        Me.Controls.Add(Me.BT60)
        Me.Controls.Add(Me.Bt59)
        Me.Controls.Add(Me.BT58)
        Me.Controls.Add(Me.BT57)
        Me.Controls.Add(Me.BT56)
        Me.Controls.Add(Me.BT55)
        Me.Controls.Add(Me.BT54)
        Me.Controls.Add(Me.BT53)
        Me.Controls.Add(Me.BT52)
        Me.Controls.Add(Me.BT51)
        Me.Controls.Add(Me.BT50)
        Me.Controls.Add(Me.BT49)
        Me.Controls.Add(Me.BT48)
        Me.Controls.Add(Me.BT47)
        Me.Controls.Add(Me.BT46)
        Me.Controls.Add(Me.BT45)
        Me.Controls.Add(Me.BT44)
        Me.Controls.Add(Me.BT43)
        Me.Controls.Add(Me.BT42)
        Me.Controls.Add(Me.BT41)
        Me.Controls.Add(Me.BT40)
        Me.Controls.Add(Me.BT39)
        Me.Controls.Add(Me.BT38)
        Me.Controls.Add(Me.BT37)
        Me.Controls.Add(Me.Bt36)
        Me.Controls.Add(Me.BT35)
        Me.Controls.Add(Me.BT34)
        Me.Controls.Add(Me.BT33)
        Me.Controls.Add(Me.BT32)
        Me.Controls.Add(Me.BT31)
        Me.Controls.Add(Me.BT30)
        Me.Controls.Add(Me.BT29)
        Me.Controls.Add(Me.BT28)
        Me.Controls.Add(Me.BT27)
        Me.Controls.Add(Me.BT26)
        Me.Controls.Add(Me.BT25)
        Me.Controls.Add(Me.BT24)
        Me.Controls.Add(Me.BT23)
        Me.Controls.Add(Me.BT22)
        Me.Controls.Add(Me.BT21)
        Me.Controls.Add(Me.BT20)
        Me.Controls.Add(Me.BT19)
        Me.Controls.Add(Me.BT18)
        Me.Controls.Add(Me.BT17)
        Me.Controls.Add(Me.BT16)
        Me.Controls.Add(Me.BT15)
        Me.Controls.Add(Me.BT14)
        Me.Controls.Add(Me.BT13)
        Me.Controls.Add(Me.BT12)
        Me.Controls.Add(Me.BT11)
        Me.Controls.Add(Me.BT10)
        Me.Controls.Add(Me.BT09)
        Me.Controls.Add(Me.BT08)
        Me.Controls.Add(Me.BT07)
        Me.Controls.Add(Me.BT06)
        Me.Controls.Add(Me.BT05)
        Me.Controls.Add(Me.BT04)
        Me.Controls.Add(Me.BT03)
        Me.Controls.Add(Me.BT02)
        Me.Controls.Add(Me.BT01)
        Me.Controls.Add(Me.BT00)
        Me.Controls.Add(Me.BT_Clear)
        Me.Controls.Add(Me.BT_9)
        Me.Controls.Add(Me.BT_8)
        Me.Controls.Add(Me.BT_7)
        Me.Controls.Add(Me.BT_6)
        Me.Controls.Add(Me.BT_5)
        Me.Controls.Add(Me.BT_4)
        Me.Controls.Add(Me.BT_3)
        Me.Controls.Add(Me.BT_2)
        Me.Controls.Add(Me.BT_1)
        Me.Controls.Add(Me.BT_Smp)
        Me.Controls.Add(Me.BT_Solutions)
        Me.Controls.Add(Me.LBL_Conseil)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Sudoku"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sudoku"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents PartieToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LBL_Conseil As Label
    Friend WithEvents BT_Solutions As Button
    Friend WithEvents BT_Smp As Button
    Friend WithEvents TestToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents GénérerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QuitterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaisieToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents BT_1 As Button
    Friend WithEvents BT_2 As Button
    Friend WithEvents BT_3 As Button
    Friend WithEvents BT_4 As Button
    Friend WithEvents BT_5 As Button
    Friend WithEvents BT_6 As Button
    Friend WithEvents BT_7 As Button
    Friend WithEvents BT_8 As Button
    Friend WithEvents BT_9 As Button
    Friend WithEvents BT_Clear As Button
    Friend WithEvents BT00 As Button
    Friend WithEvents BT01 As Button
    Friend WithEvents BT02 As Button
    Friend WithEvents BT03 As Button
    Friend WithEvents BT04 As Button
    Friend WithEvents BT05 As Button
    Friend WithEvents BT08 As Button
    Friend WithEvents BT07 As Button
    Friend WithEvents BT06 As Button
    Friend WithEvents BT17 As Button
    Friend WithEvents BT16 As Button
    Friend WithEvents BT15 As Button
    Friend WithEvents BT14 As Button
    Friend WithEvents BT13 As Button
    Friend WithEvents BT12 As Button
    Friend WithEvents BT11 As Button
    Friend WithEvents BT10 As Button
    Friend WithEvents BT09 As Button
    Friend WithEvents BT26 As Button
    Friend WithEvents BT25 As Button
    Friend WithEvents BT24 As Button
    Friend WithEvents BT23 As Button
    Friend WithEvents BT22 As Button
    Friend WithEvents BT21 As Button
    Friend WithEvents BT20 As Button
    Friend WithEvents BT19 As Button
    Friend WithEvents BT18 As Button
    Friend WithEvents BT32 As Button
    Friend WithEvents BT31 As Button
    Friend WithEvents BT30 As Button
    Friend WithEvents BT29 As Button
    Friend WithEvents BT28 As Button
    Friend WithEvents BT27 As Button
    Friend WithEvents BT35 As Button
    Friend WithEvents BT34 As Button
    Friend WithEvents BT33 As Button
    Friend WithEvents BT44 As Button
    Friend WithEvents BT43 As Button
    Friend WithEvents BT42 As Button
    Friend WithEvents BT41 As Button
    Friend WithEvents BT40 As Button
    Friend WithEvents BT39 As Button
    Friend WithEvents BT38 As Button
    Friend WithEvents BT37 As Button
    Friend WithEvents Bt36 As Button
    Friend WithEvents BT53 As Button
    Friend WithEvents BT52 As Button
    Friend WithEvents BT51 As Button
    Friend WithEvents BT50 As Button
    Friend WithEvents BT49 As Button
    Friend WithEvents BT48 As Button
    Friend WithEvents BT47 As Button
    Friend WithEvents BT46 As Button
    Friend WithEvents BT45 As Button
    Friend WithEvents BT80 As Button
    Friend WithEvents BT79 As Button
    Friend WithEvents BT78 As Button
    Friend WithEvents BT77 As Button
    Friend WithEvents BT76 As Button
    Friend WithEvents BT75 As Button
    Friend WithEvents BT74 As Button
    Friend WithEvents BT73 As Button
    Friend WithEvents BT72 As Button
    Friend WithEvents BT71 As Button
    Friend WithEvents BT70 As Button
    Friend WithEvents BT69 As Button
    Friend WithEvents BT68 As Button
    Friend WithEvents BT67 As Button
    Friend WithEvents BT66 As Button
    Friend WithEvents BT65 As Button
    Friend WithEvents BT64 As Button
    Friend WithEvents BT63 As Button
    Friend WithEvents BT62 As Button
    Friend WithEvents BT61 As Button
    Friend WithEvents BT60 As Button
    Friend WithEvents Bt59 As Button
    Friend WithEvents BT58 As Button
    Friend WithEvents BT57 As Button
    Friend WithEvents BT56 As Button
    Friend WithEvents BT55 As Button
    Friend WithEvents BT54 As Button
    Friend WithEvents PaireNueToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PaireNueEnLigneToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PaireNueEnColonneToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EnRégionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BTSolution As Button
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents GénérerToolStripButton As ToolStripButton
    Friend WithEvents OuvrirToolStripButton1 As ToolStripButton
    Friend WithEvents EnregistrerToolStripButton As ToolStripButton
    Friend WithEvents JouerToolStripButton1 As ToolStripButton
    Friend WithEvents SaisirToolStripButton As ToolStripButton
    Friend WithEvents GrilleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AfficherLesCandidatsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EffacerLesCandidatsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BTStepByStep As Button
    Friend WithEvents LBL_nbVal As Label
    Friend WithEvents XYwingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents XYWingEnLigneToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents XWingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents XWingEnColonneToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents XWingEnLigneToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TripletNuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TripletNuEnLigneToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FichierToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SauvegarderUneGrilleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents nomFichierOuvert As Label
    Friend WithEvents RecommencerToolStripButton As ToolStripButton
    Friend WithEvents BTForceBrute As Button
End Class
