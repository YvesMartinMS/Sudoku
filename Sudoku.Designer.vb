<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sudoku
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FichierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RésoudreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuitterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TB_grand_modele = New System.Windows.Forms.TextBox()
        Me.TB_petit_modele = New System.Windows.Forms.TextBox()
        Me.TB_01 = New System.Windows.Forms.TextBox()
        Me.TB_02 = New System.Windows.Forms.TextBox()
        Me.TB_03 = New System.Windows.Forms.TextBox()
        Me.TB_04 = New System.Windows.Forms.TextBox()
        Me.TB_05 = New System.Windows.Forms.TextBox()
        Me.TB_06 = New System.Windows.Forms.TextBox()
        Me.TB_07 = New System.Windows.Forms.TextBox()
        Me.TB_08 = New System.Windows.Forms.TextBox()
        Me.TB_09 = New System.Windows.Forms.TextBox()
        Me.TB_18 = New System.Windows.Forms.TextBox()
        Me.TB_17 = New System.Windows.Forms.TextBox()
        Me.TB_16 = New System.Windows.Forms.TextBox()
        Me.TB_15 = New System.Windows.Forms.TextBox()
        Me.TB_14 = New System.Windows.Forms.TextBox()
        Me.TB_13 = New System.Windows.Forms.TextBox()
        Me.TB_12 = New System.Windows.Forms.TextBox()
        Me.TB_11 = New System.Windows.Forms.TextBox()
        Me.TB_10 = New System.Windows.Forms.TextBox()
        Me.TB_36 = New System.Windows.Forms.TextBox()
        Me.TB_35 = New System.Windows.Forms.TextBox()
        Me.TB_34 = New System.Windows.Forms.TextBox()
        Me.TB_33 = New System.Windows.Forms.TextBox()
        Me.TB_32 = New System.Windows.Forms.TextBox()
        Me.TB_31 = New System.Windows.Forms.TextBox()
        Me.TB_30 = New System.Windows.Forms.TextBox()
        Me.TB_29 = New System.Windows.Forms.TextBox()
        Me.TB_28 = New System.Windows.Forms.TextBox()
        Me.TB_27 = New System.Windows.Forms.TextBox()
        Me.TB_26 = New System.Windows.Forms.TextBox()
        Me.TB_25 = New System.Windows.Forms.TextBox()
        Me.TB_24 = New System.Windows.Forms.TextBox()
        Me.TB_23 = New System.Windows.Forms.TextBox()
        Me.TB_22 = New System.Windows.Forms.TextBox()
        Me.TB_21 = New System.Windows.Forms.TextBox()
        Me.TB_20 = New System.Windows.Forms.TextBox()
        Me.TB_19 = New System.Windows.Forms.TextBox()
        Me.TB_72 = New System.Windows.Forms.TextBox()
        Me.TB_71 = New System.Windows.Forms.TextBox()
        Me.TB_70 = New System.Windows.Forms.TextBox()
        Me.TB_69 = New System.Windows.Forms.TextBox()
        Me.TB_68 = New System.Windows.Forms.TextBox()
        Me.TB_67 = New System.Windows.Forms.TextBox()
        Me.TB_66 = New System.Windows.Forms.TextBox()
        Me.TB_65 = New System.Windows.Forms.TextBox()
        Me.TB_64 = New System.Windows.Forms.TextBox()
        Me.TB_63 = New System.Windows.Forms.TextBox()
        Me.TB_62 = New System.Windows.Forms.TextBox()
        Me.TB_61 = New System.Windows.Forms.TextBox()
        Me.TB_60 = New System.Windows.Forms.TextBox()
        Me.TB_59 = New System.Windows.Forms.TextBox()
        Me.TB_58 = New System.Windows.Forms.TextBox()
        Me.TB_57 = New System.Windows.Forms.TextBox()
        Me.TB_56 = New System.Windows.Forms.TextBox()
        Me.TB_55 = New System.Windows.Forms.TextBox()
        Me.TB_54 = New System.Windows.Forms.TextBox()
        Me.TB_53 = New System.Windows.Forms.TextBox()
        Me.TB_52 = New System.Windows.Forms.TextBox()
        Me.TB_51 = New System.Windows.Forms.TextBox()
        Me.TB_50 = New System.Windows.Forms.TextBox()
        Me.TB_49 = New System.Windows.Forms.TextBox()
        Me.TB_48 = New System.Windows.Forms.TextBox()
        Me.TB_47 = New System.Windows.Forms.TextBox()
        Me.TB_46 = New System.Windows.Forms.TextBox()
        Me.TB_45 = New System.Windows.Forms.TextBox()
        Me.TB_44 = New System.Windows.Forms.TextBox()
        Me.TB_43 = New System.Windows.Forms.TextBox()
        Me.TB_42 = New System.Windows.Forms.TextBox()
        Me.TB_41 = New System.Windows.Forms.TextBox()
        Me.TB_40 = New System.Windows.Forms.TextBox()
        Me.TB_39 = New System.Windows.Forms.TextBox()
        Me.TB_38 = New System.Windows.Forms.TextBox()
        Me.TB_37 = New System.Windows.Forms.TextBox()
        Me.TB_81 = New System.Windows.Forms.TextBox()
        Me.TB_80 = New System.Windows.Forms.TextBox()
        Me.TB_79 = New System.Windows.Forms.TextBox()
        Me.TB_78 = New System.Windows.Forms.TextBox()
        Me.TB_77 = New System.Windows.Forms.TextBox()
        Me.TB_76 = New System.Windows.Forms.TextBox()
        Me.TB_75 = New System.Windows.Forms.TextBox()
        Me.TB_74 = New System.Windows.Forms.TextBox()
        Me.TB_73 = New System.Windows.Forms.TextBox()
        Me.BT_Resoudre = New System.Windows.Forms.Button()
        Me.LBL_Conseil = New System.Windows.Forms.Label()
        Me.BT_Suivant = New System.Windows.Forms.Button()
        Me.BT_Solutions = New System.Windows.Forms.Button()
        Me.BT_Smp = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FichierToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(764, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FichierToolStripMenuItem
        '
        Me.FichierToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RésoudreToolStripMenuItem, Me.QuitterToolStripMenuItem})
        Me.FichierToolStripMenuItem.Name = "FichierToolStripMenuItem"
        Me.FichierToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.FichierToolStripMenuItem.Text = "Fichier"
        '
        'RésoudreToolStripMenuItem
        '
        Me.RésoudreToolStripMenuItem.Name = "RésoudreToolStripMenuItem"
        Me.RésoudreToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.RésoudreToolStripMenuItem.Text = "Résoudre"
        '
        'QuitterToolStripMenuItem
        '
        Me.QuitterToolStripMenuItem.Name = "QuitterToolStripMenuItem"
        Me.QuitterToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.QuitterToolStripMenuItem.Text = "Quitter"
        '
        'TB_grand_modele
        '
        Me.TB_grand_modele.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_grand_modele.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_grand_modele.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_grand_modele.Location = New System.Drawing.Point(691, 532)
        Me.TB_grand_modele.Multiline = True
        Me.TB_grand_modele.Name = "TB_grand_modele"
        Me.TB_grand_modele.Size = New System.Drawing.Size(40, 40)
        Me.TB_grand_modele.TabIndex = 998
        Me.TB_grand_modele.Text = "1"
        Me.TB_grand_modele.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TB_grand_modele.Visible = False
        '
        'TB_petit_modele
        '
        Me.TB_petit_modele.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TB_petit_modele.Font = New System.Drawing.Font("Courier New", 7.75!)
        Me.TB_petit_modele.Location = New System.Drawing.Point(691, 593)
        Me.TB_petit_modele.Multiline = True
        Me.TB_petit_modele.Name = "TB_petit_modele"
        Me.TB_petit_modele.Size = New System.Drawing.Size(40, 40)
        Me.TB_petit_modele.TabIndex = 999
        Me.TB_petit_modele.Text = "    3" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "4 5 6" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "7 8 9"
        Me.TB_petit_modele.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TB_petit_modele.Visible = False
        '
        'TB_01
        '
        Me.TB_01.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_01.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_01.Location = New System.Drawing.Point(190, 155)
        Me.TB_01.Multiline = True
        Me.TB_01.Name = "TB_01"
        Me.TB_01.Size = New System.Drawing.Size(40, 40)
        Me.TB_01.TabIndex = 1
        Me.TB_01.TabStop = False
        Me.TB_01.Text = "1"
        Me.TB_01.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_02
        '
        Me.TB_02.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_02.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_02.Location = New System.Drawing.Point(235, 155)
        Me.TB_02.Multiline = True
        Me.TB_02.Name = "TB_02"
        Me.TB_02.Size = New System.Drawing.Size(40, 40)
        Me.TB_02.TabIndex = 2
        Me.TB_02.Text = "1"
        Me.TB_02.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_03
        '
        Me.TB_03.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_03.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_03.Location = New System.Drawing.Point(280, 155)
        Me.TB_03.Multiline = True
        Me.TB_03.Name = "TB_03"
        Me.TB_03.Size = New System.Drawing.Size(40, 40)
        Me.TB_03.TabIndex = 3
        Me.TB_03.Text = "1"
        Me.TB_03.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_04
        '
        Me.TB_04.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TB_04.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_04.Location = New System.Drawing.Point(325, 155)
        Me.TB_04.Multiline = True
        Me.TB_04.Name = "TB_04"
        Me.TB_04.Size = New System.Drawing.Size(40, 40)
        Me.TB_04.TabIndex = 4
        Me.TB_04.Text = "1"
        Me.TB_04.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_05
        '
        Me.TB_05.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TB_05.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_05.Location = New System.Drawing.Point(370, 155)
        Me.TB_05.Multiline = True
        Me.TB_05.Name = "TB_05"
        Me.TB_05.Size = New System.Drawing.Size(40, 40)
        Me.TB_05.TabIndex = 5
        Me.TB_05.Text = "1"
        Me.TB_05.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_06
        '
        Me.TB_06.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TB_06.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_06.Location = New System.Drawing.Point(415, 155)
        Me.TB_06.Multiline = True
        Me.TB_06.Name = "TB_06"
        Me.TB_06.Size = New System.Drawing.Size(40, 40)
        Me.TB_06.TabIndex = 6
        Me.TB_06.Text = "1"
        Me.TB_06.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_07
        '
        Me.TB_07.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_07.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_07.Location = New System.Drawing.Point(460, 155)
        Me.TB_07.Multiline = True
        Me.TB_07.Name = "TB_07"
        Me.TB_07.Size = New System.Drawing.Size(40, 40)
        Me.TB_07.TabIndex = 7
        Me.TB_07.Text = "1"
        Me.TB_07.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_08
        '
        Me.TB_08.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_08.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_08.Location = New System.Drawing.Point(505, 155)
        Me.TB_08.Multiline = True
        Me.TB_08.Name = "TB_08"
        Me.TB_08.Size = New System.Drawing.Size(40, 40)
        Me.TB_08.TabIndex = 8
        Me.TB_08.Text = "1"
        Me.TB_08.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_09
        '
        Me.TB_09.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_09.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_09.Location = New System.Drawing.Point(550, 155)
        Me.TB_09.Multiline = True
        Me.TB_09.Name = "TB_09"
        Me.TB_09.Size = New System.Drawing.Size(40, 40)
        Me.TB_09.TabIndex = 9
        Me.TB_09.Text = "1"
        Me.TB_09.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_18
        '
        Me.TB_18.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_18.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_18.Location = New System.Drawing.Point(550, 200)
        Me.TB_18.Multiline = True
        Me.TB_18.Name = "TB_18"
        Me.TB_18.Size = New System.Drawing.Size(40, 40)
        Me.TB_18.TabIndex = 18
        Me.TB_18.Text = "1"
        Me.TB_18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_17
        '
        Me.TB_17.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_17.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_17.Location = New System.Drawing.Point(505, 200)
        Me.TB_17.Multiline = True
        Me.TB_17.Name = "TB_17"
        Me.TB_17.Size = New System.Drawing.Size(40, 40)
        Me.TB_17.TabIndex = 17
        Me.TB_17.Text = "1"
        Me.TB_17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_16
        '
        Me.TB_16.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_16.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_16.Location = New System.Drawing.Point(460, 200)
        Me.TB_16.Multiline = True
        Me.TB_16.Name = "TB_16"
        Me.TB_16.Size = New System.Drawing.Size(40, 40)
        Me.TB_16.TabIndex = 16
        Me.TB_16.Text = "1"
        Me.TB_16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_15
        '
        Me.TB_15.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TB_15.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_15.Location = New System.Drawing.Point(415, 200)
        Me.TB_15.Multiline = True
        Me.TB_15.Name = "TB_15"
        Me.TB_15.Size = New System.Drawing.Size(40, 40)
        Me.TB_15.TabIndex = 15
        Me.TB_15.Text = "1"
        Me.TB_15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_14
        '
        Me.TB_14.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TB_14.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_14.Location = New System.Drawing.Point(370, 200)
        Me.TB_14.Multiline = True
        Me.TB_14.Name = "TB_14"
        Me.TB_14.Size = New System.Drawing.Size(40, 40)
        Me.TB_14.TabIndex = 14
        Me.TB_14.Text = "1"
        Me.TB_14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_13
        '
        Me.TB_13.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TB_13.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_13.Location = New System.Drawing.Point(325, 200)
        Me.TB_13.Multiline = True
        Me.TB_13.Name = "TB_13"
        Me.TB_13.Size = New System.Drawing.Size(40, 40)
        Me.TB_13.TabIndex = 13
        Me.TB_13.Text = "1"
        Me.TB_13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_12
        '
        Me.TB_12.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_12.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_12.Location = New System.Drawing.Point(280, 200)
        Me.TB_12.Multiline = True
        Me.TB_12.Name = "TB_12"
        Me.TB_12.Size = New System.Drawing.Size(40, 40)
        Me.TB_12.TabIndex = 12
        Me.TB_12.Text = "1"
        Me.TB_12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_11
        '
        Me.TB_11.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_11.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_11.Location = New System.Drawing.Point(235, 200)
        Me.TB_11.Multiline = True
        Me.TB_11.Name = "TB_11"
        Me.TB_11.Size = New System.Drawing.Size(40, 40)
        Me.TB_11.TabIndex = 11
        Me.TB_11.Text = "1"
        Me.TB_11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_10
        '
        Me.TB_10.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_10.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_10.Location = New System.Drawing.Point(190, 200)
        Me.TB_10.Multiline = True
        Me.TB_10.Name = "TB_10"
        Me.TB_10.Size = New System.Drawing.Size(40, 40)
        Me.TB_10.TabIndex = 10
        Me.TB_10.Text = "1"
        Me.TB_10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_36
        '
        Me.TB_36.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TB_36.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_36.Location = New System.Drawing.Point(550, 290)
        Me.TB_36.Multiline = True
        Me.TB_36.Name = "TB_36"
        Me.TB_36.Size = New System.Drawing.Size(40, 40)
        Me.TB_36.TabIndex = 36
        Me.TB_36.Text = "1"
        Me.TB_36.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_35
        '
        Me.TB_35.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TB_35.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_35.Location = New System.Drawing.Point(505, 290)
        Me.TB_35.Multiline = True
        Me.TB_35.Name = "TB_35"
        Me.TB_35.Size = New System.Drawing.Size(40, 40)
        Me.TB_35.TabIndex = 35
        Me.TB_35.Text = "1"
        Me.TB_35.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_34
        '
        Me.TB_34.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TB_34.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_34.Location = New System.Drawing.Point(460, 290)
        Me.TB_34.Multiline = True
        Me.TB_34.Name = "TB_34"
        Me.TB_34.Size = New System.Drawing.Size(40, 40)
        Me.TB_34.TabIndex = 34
        Me.TB_34.Text = "1"
        Me.TB_34.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_33
        '
        Me.TB_33.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_33.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_33.Location = New System.Drawing.Point(415, 290)
        Me.TB_33.Multiline = True
        Me.TB_33.Name = "TB_33"
        Me.TB_33.Size = New System.Drawing.Size(40, 40)
        Me.TB_33.TabIndex = 33
        Me.TB_33.Text = "1"
        Me.TB_33.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_32
        '
        Me.TB_32.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_32.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_32.Location = New System.Drawing.Point(370, 290)
        Me.TB_32.Multiline = True
        Me.TB_32.Name = "TB_32"
        Me.TB_32.Size = New System.Drawing.Size(40, 40)
        Me.TB_32.TabIndex = 32
        Me.TB_32.Text = "1"
        Me.TB_32.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_31
        '
        Me.TB_31.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_31.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_31.Location = New System.Drawing.Point(325, 290)
        Me.TB_31.Multiline = True
        Me.TB_31.Name = "TB_31"
        Me.TB_31.Size = New System.Drawing.Size(40, 40)
        Me.TB_31.TabIndex = 31
        Me.TB_31.Text = "1"
        Me.TB_31.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_30
        '
        Me.TB_30.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TB_30.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_30.Location = New System.Drawing.Point(280, 290)
        Me.TB_30.Multiline = True
        Me.TB_30.Name = "TB_30"
        Me.TB_30.Size = New System.Drawing.Size(40, 40)
        Me.TB_30.TabIndex = 30
        Me.TB_30.Text = "1"
        Me.TB_30.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_29
        '
        Me.TB_29.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TB_29.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_29.Location = New System.Drawing.Point(235, 290)
        Me.TB_29.Multiline = True
        Me.TB_29.Name = "TB_29"
        Me.TB_29.Size = New System.Drawing.Size(40, 40)
        Me.TB_29.TabIndex = 29
        Me.TB_29.Text = "1"
        Me.TB_29.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_28
        '
        Me.TB_28.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TB_28.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_28.Location = New System.Drawing.Point(190, 290)
        Me.TB_28.Multiline = True
        Me.TB_28.Name = "TB_28"
        Me.TB_28.Size = New System.Drawing.Size(40, 40)
        Me.TB_28.TabIndex = 28
        Me.TB_28.Text = "1"
        Me.TB_28.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_27
        '
        Me.TB_27.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_27.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_27.Location = New System.Drawing.Point(550, 245)
        Me.TB_27.Multiline = True
        Me.TB_27.Name = "TB_27"
        Me.TB_27.Size = New System.Drawing.Size(40, 40)
        Me.TB_27.TabIndex = 27
        Me.TB_27.Text = "1"
        Me.TB_27.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_26
        '
        Me.TB_26.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_26.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_26.Location = New System.Drawing.Point(505, 245)
        Me.TB_26.Multiline = True
        Me.TB_26.Name = "TB_26"
        Me.TB_26.Size = New System.Drawing.Size(40, 40)
        Me.TB_26.TabIndex = 26
        Me.TB_26.Text = "1"
        Me.TB_26.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_25
        '
        Me.TB_25.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_25.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_25.Location = New System.Drawing.Point(460, 245)
        Me.TB_25.Multiline = True
        Me.TB_25.Name = "TB_25"
        Me.TB_25.Size = New System.Drawing.Size(40, 40)
        Me.TB_25.TabIndex = 25
        Me.TB_25.Text = "1"
        Me.TB_25.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_24
        '
        Me.TB_24.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TB_24.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_24.Location = New System.Drawing.Point(415, 245)
        Me.TB_24.Multiline = True
        Me.TB_24.Name = "TB_24"
        Me.TB_24.Size = New System.Drawing.Size(40, 40)
        Me.TB_24.TabIndex = 24
        Me.TB_24.Text = "1"
        Me.TB_24.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_23
        '
        Me.TB_23.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TB_23.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_23.Location = New System.Drawing.Point(370, 245)
        Me.TB_23.Multiline = True
        Me.TB_23.Name = "TB_23"
        Me.TB_23.Size = New System.Drawing.Size(40, 40)
        Me.TB_23.TabIndex = 23
        Me.TB_23.Text = "1"
        Me.TB_23.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_22
        '
        Me.TB_22.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TB_22.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_22.Location = New System.Drawing.Point(325, 245)
        Me.TB_22.Multiline = True
        Me.TB_22.Name = "TB_22"
        Me.TB_22.Size = New System.Drawing.Size(40, 40)
        Me.TB_22.TabIndex = 22
        Me.TB_22.Text = "1"
        Me.TB_22.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_21
        '
        Me.TB_21.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_21.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_21.Location = New System.Drawing.Point(280, 245)
        Me.TB_21.Multiline = True
        Me.TB_21.Name = "TB_21"
        Me.TB_21.Size = New System.Drawing.Size(40, 40)
        Me.TB_21.TabIndex = 21
        Me.TB_21.Text = "1"
        Me.TB_21.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_20
        '
        Me.TB_20.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_20.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_20.Location = New System.Drawing.Point(235, 245)
        Me.TB_20.Multiline = True
        Me.TB_20.Name = "TB_20"
        Me.TB_20.Size = New System.Drawing.Size(40, 40)
        Me.TB_20.TabIndex = 20
        Me.TB_20.Text = "1"
        Me.TB_20.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_19
        '
        Me.TB_19.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_19.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_19.Location = New System.Drawing.Point(190, 245)
        Me.TB_19.Multiline = True
        Me.TB_19.Name = "TB_19"
        Me.TB_19.Size = New System.Drawing.Size(40, 40)
        Me.TB_19.TabIndex = 19
        Me.TB_19.Text = "1"
        Me.TB_19.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_72
        '
        Me.TB_72.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_72.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_72.Location = New System.Drawing.Point(550, 470)
        Me.TB_72.Multiline = True
        Me.TB_72.Name = "TB_72"
        Me.TB_72.Size = New System.Drawing.Size(40, 40)
        Me.TB_72.TabIndex = 72
        Me.TB_72.Text = "1"
        Me.TB_72.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_71
        '
        Me.TB_71.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_71.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_71.Location = New System.Drawing.Point(505, 470)
        Me.TB_71.Multiline = True
        Me.TB_71.Name = "TB_71"
        Me.TB_71.Size = New System.Drawing.Size(40, 40)
        Me.TB_71.TabIndex = 71
        Me.TB_71.Text = "1"
        Me.TB_71.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_70
        '
        Me.TB_70.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_70.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_70.Location = New System.Drawing.Point(460, 470)
        Me.TB_70.Multiline = True
        Me.TB_70.Name = "TB_70"
        Me.TB_70.Size = New System.Drawing.Size(40, 40)
        Me.TB_70.TabIndex = 70
        Me.TB_70.Text = "1"
        Me.TB_70.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_69
        '
        Me.TB_69.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TB_69.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_69.Location = New System.Drawing.Point(415, 470)
        Me.TB_69.Multiline = True
        Me.TB_69.Name = "TB_69"
        Me.TB_69.Size = New System.Drawing.Size(40, 40)
        Me.TB_69.TabIndex = 69
        Me.TB_69.Text = "1"
        Me.TB_69.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_68
        '
        Me.TB_68.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TB_68.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_68.Location = New System.Drawing.Point(370, 470)
        Me.TB_68.Multiline = True
        Me.TB_68.Name = "TB_68"
        Me.TB_68.Size = New System.Drawing.Size(40, 40)
        Me.TB_68.TabIndex = 68
        Me.TB_68.Text = "1"
        Me.TB_68.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_67
        '
        Me.TB_67.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TB_67.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_67.Location = New System.Drawing.Point(325, 470)
        Me.TB_67.Multiline = True
        Me.TB_67.Name = "TB_67"
        Me.TB_67.Size = New System.Drawing.Size(40, 40)
        Me.TB_67.TabIndex = 67
        Me.TB_67.Text = "1"
        Me.TB_67.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_66
        '
        Me.TB_66.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_66.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_66.Location = New System.Drawing.Point(280, 470)
        Me.TB_66.Multiline = True
        Me.TB_66.Name = "TB_66"
        Me.TB_66.Size = New System.Drawing.Size(40, 40)
        Me.TB_66.TabIndex = 66
        Me.TB_66.Text = "1"
        Me.TB_66.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_65
        '
        Me.TB_65.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_65.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_65.Location = New System.Drawing.Point(235, 470)
        Me.TB_65.Multiline = True
        Me.TB_65.Name = "TB_65"
        Me.TB_65.Size = New System.Drawing.Size(40, 40)
        Me.TB_65.TabIndex = 65
        Me.TB_65.Text = "1"
        Me.TB_65.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_64
        '
        Me.TB_64.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_64.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_64.Location = New System.Drawing.Point(190, 470)
        Me.TB_64.Multiline = True
        Me.TB_64.Name = "TB_64"
        Me.TB_64.Size = New System.Drawing.Size(40, 40)
        Me.TB_64.TabIndex = 64
        Me.TB_64.Text = "1"
        Me.TB_64.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_63
        '
        Me.TB_63.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_63.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_63.Location = New System.Drawing.Point(550, 425)
        Me.TB_63.Multiline = True
        Me.TB_63.Name = "TB_63"
        Me.TB_63.Size = New System.Drawing.Size(40, 40)
        Me.TB_63.TabIndex = 63
        Me.TB_63.Text = "1"
        Me.TB_63.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_62
        '
        Me.TB_62.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_62.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_62.Location = New System.Drawing.Point(505, 425)
        Me.TB_62.Multiline = True
        Me.TB_62.Name = "TB_62"
        Me.TB_62.Size = New System.Drawing.Size(40, 40)
        Me.TB_62.TabIndex = 62
        Me.TB_62.Text = "1"
        Me.TB_62.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_61
        '
        Me.TB_61.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_61.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_61.Location = New System.Drawing.Point(460, 425)
        Me.TB_61.Multiline = True
        Me.TB_61.Name = "TB_61"
        Me.TB_61.Size = New System.Drawing.Size(40, 40)
        Me.TB_61.TabIndex = 61
        Me.TB_61.Text = "1"
        Me.TB_61.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_60
        '
        Me.TB_60.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TB_60.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_60.Location = New System.Drawing.Point(415, 425)
        Me.TB_60.Multiline = True
        Me.TB_60.Name = "TB_60"
        Me.TB_60.Size = New System.Drawing.Size(40, 40)
        Me.TB_60.TabIndex = 60
        Me.TB_60.Text = "1"
        Me.TB_60.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_59
        '
        Me.TB_59.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TB_59.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_59.Location = New System.Drawing.Point(370, 425)
        Me.TB_59.Multiline = True
        Me.TB_59.Name = "TB_59"
        Me.TB_59.Size = New System.Drawing.Size(40, 40)
        Me.TB_59.TabIndex = 59
        Me.TB_59.Text = "1"
        Me.TB_59.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_58
        '
        Me.TB_58.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TB_58.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_58.Location = New System.Drawing.Point(325, 425)
        Me.TB_58.Multiline = True
        Me.TB_58.Name = "TB_58"
        Me.TB_58.Size = New System.Drawing.Size(40, 40)
        Me.TB_58.TabIndex = 58
        Me.TB_58.Text = "1"
        Me.TB_58.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_57
        '
        Me.TB_57.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_57.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_57.Location = New System.Drawing.Point(280, 425)
        Me.TB_57.Multiline = True
        Me.TB_57.Name = "TB_57"
        Me.TB_57.Size = New System.Drawing.Size(40, 40)
        Me.TB_57.TabIndex = 57
        Me.TB_57.Text = "1"
        Me.TB_57.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_56
        '
        Me.TB_56.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_56.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_56.Location = New System.Drawing.Point(235, 425)
        Me.TB_56.Multiline = True
        Me.TB_56.Name = "TB_56"
        Me.TB_56.Size = New System.Drawing.Size(40, 40)
        Me.TB_56.TabIndex = 56
        Me.TB_56.Text = "1"
        Me.TB_56.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_55
        '
        Me.TB_55.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_55.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_55.Location = New System.Drawing.Point(190, 425)
        Me.TB_55.Multiline = True
        Me.TB_55.Name = "TB_55"
        Me.TB_55.Size = New System.Drawing.Size(40, 40)
        Me.TB_55.TabIndex = 55
        Me.TB_55.Text = "1"
        Me.TB_55.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_54
        '
        Me.TB_54.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TB_54.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_54.Location = New System.Drawing.Point(550, 380)
        Me.TB_54.Multiline = True
        Me.TB_54.Name = "TB_54"
        Me.TB_54.Size = New System.Drawing.Size(40, 40)
        Me.TB_54.TabIndex = 54
        Me.TB_54.Text = "1"
        Me.TB_54.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_53
        '
        Me.TB_53.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TB_53.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_53.Location = New System.Drawing.Point(505, 380)
        Me.TB_53.Multiline = True
        Me.TB_53.Name = "TB_53"
        Me.TB_53.Size = New System.Drawing.Size(40, 40)
        Me.TB_53.TabIndex = 53
        Me.TB_53.Text = "1"
        Me.TB_53.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_52
        '
        Me.TB_52.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TB_52.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_52.Location = New System.Drawing.Point(460, 380)
        Me.TB_52.Multiline = True
        Me.TB_52.Name = "TB_52"
        Me.TB_52.Size = New System.Drawing.Size(40, 40)
        Me.TB_52.TabIndex = 52
        Me.TB_52.Text = "1"
        Me.TB_52.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_51
        '
        Me.TB_51.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_51.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_51.Location = New System.Drawing.Point(415, 380)
        Me.TB_51.Multiline = True
        Me.TB_51.Name = "TB_51"
        Me.TB_51.Size = New System.Drawing.Size(40, 40)
        Me.TB_51.TabIndex = 51
        Me.TB_51.Text = "1"
        Me.TB_51.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_50
        '
        Me.TB_50.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_50.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_50.Location = New System.Drawing.Point(370, 380)
        Me.TB_50.Multiline = True
        Me.TB_50.Name = "TB_50"
        Me.TB_50.Size = New System.Drawing.Size(40, 40)
        Me.TB_50.TabIndex = 50
        Me.TB_50.Text = "1"
        Me.TB_50.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_49
        '
        Me.TB_49.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_49.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_49.Location = New System.Drawing.Point(325, 380)
        Me.TB_49.Multiline = True
        Me.TB_49.Name = "TB_49"
        Me.TB_49.Size = New System.Drawing.Size(40, 40)
        Me.TB_49.TabIndex = 49
        Me.TB_49.Text = "1"
        Me.TB_49.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_48
        '
        Me.TB_48.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TB_48.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_48.Location = New System.Drawing.Point(280, 380)
        Me.TB_48.Multiline = True
        Me.TB_48.Name = "TB_48"
        Me.TB_48.Size = New System.Drawing.Size(40, 40)
        Me.TB_48.TabIndex = 48
        Me.TB_48.Text = "1"
        Me.TB_48.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_47
        '
        Me.TB_47.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TB_47.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_47.Location = New System.Drawing.Point(235, 380)
        Me.TB_47.Multiline = True
        Me.TB_47.Name = "TB_47"
        Me.TB_47.Size = New System.Drawing.Size(40, 40)
        Me.TB_47.TabIndex = 47
        Me.TB_47.Text = "1"
        Me.TB_47.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_46
        '
        Me.TB_46.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TB_46.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_46.Location = New System.Drawing.Point(190, 380)
        Me.TB_46.Multiline = True
        Me.TB_46.Name = "TB_46"
        Me.TB_46.Size = New System.Drawing.Size(40, 40)
        Me.TB_46.TabIndex = 46
        Me.TB_46.Text = "1"
        Me.TB_46.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_45
        '
        Me.TB_45.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TB_45.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_45.Location = New System.Drawing.Point(550, 335)
        Me.TB_45.Multiline = True
        Me.TB_45.Name = "TB_45"
        Me.TB_45.Size = New System.Drawing.Size(40, 40)
        Me.TB_45.TabIndex = 45
        Me.TB_45.Text = "1"
        Me.TB_45.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_44
        '
        Me.TB_44.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TB_44.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_44.Location = New System.Drawing.Point(505, 335)
        Me.TB_44.Multiline = True
        Me.TB_44.Name = "TB_44"
        Me.TB_44.Size = New System.Drawing.Size(40, 40)
        Me.TB_44.TabIndex = 44
        Me.TB_44.Text = "1"
        Me.TB_44.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_43
        '
        Me.TB_43.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TB_43.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_43.Location = New System.Drawing.Point(460, 335)
        Me.TB_43.Multiline = True
        Me.TB_43.Name = "TB_43"
        Me.TB_43.Size = New System.Drawing.Size(40, 40)
        Me.TB_43.TabIndex = 43
        Me.TB_43.Text = "1"
        Me.TB_43.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_42
        '
        Me.TB_42.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_42.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_42.Location = New System.Drawing.Point(415, 335)
        Me.TB_42.Multiline = True
        Me.TB_42.Name = "TB_42"
        Me.TB_42.Size = New System.Drawing.Size(40, 40)
        Me.TB_42.TabIndex = 42
        Me.TB_42.Text = "1"
        Me.TB_42.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_41
        '
        Me.TB_41.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_41.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_41.Location = New System.Drawing.Point(370, 335)
        Me.TB_41.Multiline = True
        Me.TB_41.Name = "TB_41"
        Me.TB_41.Size = New System.Drawing.Size(40, 40)
        Me.TB_41.TabIndex = 41
        Me.TB_41.Text = "1"
        Me.TB_41.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_40
        '
        Me.TB_40.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_40.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_40.Location = New System.Drawing.Point(325, 335)
        Me.TB_40.Multiline = True
        Me.TB_40.Name = "TB_40"
        Me.TB_40.Size = New System.Drawing.Size(40, 40)
        Me.TB_40.TabIndex = 40
        Me.TB_40.Text = "1"
        Me.TB_40.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_39
        '
        Me.TB_39.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TB_39.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_39.Location = New System.Drawing.Point(280, 335)
        Me.TB_39.Multiline = True
        Me.TB_39.Name = "TB_39"
        Me.TB_39.Size = New System.Drawing.Size(40, 40)
        Me.TB_39.TabIndex = 39
        Me.TB_39.Text = "1"
        Me.TB_39.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_38
        '
        Me.TB_38.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TB_38.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_38.Location = New System.Drawing.Point(235, 335)
        Me.TB_38.Multiline = True
        Me.TB_38.Name = "TB_38"
        Me.TB_38.Size = New System.Drawing.Size(40, 40)
        Me.TB_38.TabIndex = 38
        Me.TB_38.Text = "1"
        Me.TB_38.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_37
        '
        Me.TB_37.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TB_37.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_37.Location = New System.Drawing.Point(190, 335)
        Me.TB_37.Multiline = True
        Me.TB_37.Name = "TB_37"
        Me.TB_37.Size = New System.Drawing.Size(40, 40)
        Me.TB_37.TabIndex = 37
        Me.TB_37.Text = "1"
        Me.TB_37.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_81
        '
        Me.TB_81.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_81.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_81.Location = New System.Drawing.Point(550, 515)
        Me.TB_81.Multiline = True
        Me.TB_81.Name = "TB_81"
        Me.TB_81.Size = New System.Drawing.Size(40, 40)
        Me.TB_81.TabIndex = 81
        Me.TB_81.Text = "1"
        Me.TB_81.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_80
        '
        Me.TB_80.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_80.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_80.Location = New System.Drawing.Point(505, 515)
        Me.TB_80.Multiline = True
        Me.TB_80.Name = "TB_80"
        Me.TB_80.Size = New System.Drawing.Size(40, 40)
        Me.TB_80.TabIndex = 80
        Me.TB_80.Text = "1"
        Me.TB_80.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_79
        '
        Me.TB_79.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_79.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_79.Location = New System.Drawing.Point(460, 515)
        Me.TB_79.Multiline = True
        Me.TB_79.Name = "TB_79"
        Me.TB_79.Size = New System.Drawing.Size(40, 40)
        Me.TB_79.TabIndex = 79
        Me.TB_79.Text = "1"
        Me.TB_79.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_78
        '
        Me.TB_78.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TB_78.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_78.Location = New System.Drawing.Point(415, 515)
        Me.TB_78.Multiline = True
        Me.TB_78.Name = "TB_78"
        Me.TB_78.Size = New System.Drawing.Size(40, 40)
        Me.TB_78.TabIndex = 78
        Me.TB_78.Text = "1"
        Me.TB_78.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_77
        '
        Me.TB_77.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TB_77.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_77.Location = New System.Drawing.Point(370, 515)
        Me.TB_77.Multiline = True
        Me.TB_77.Name = "TB_77"
        Me.TB_77.Size = New System.Drawing.Size(40, 40)
        Me.TB_77.TabIndex = 77
        Me.TB_77.Text = "1"
        Me.TB_77.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_76
        '
        Me.TB_76.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TB_76.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_76.Location = New System.Drawing.Point(325, 515)
        Me.TB_76.Multiline = True
        Me.TB_76.Name = "TB_76"
        Me.TB_76.Size = New System.Drawing.Size(40, 40)
        Me.TB_76.TabIndex = 76
        Me.TB_76.Text = "1"
        Me.TB_76.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_75
        '
        Me.TB_75.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_75.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_75.Location = New System.Drawing.Point(280, 515)
        Me.TB_75.Multiline = True
        Me.TB_75.Name = "TB_75"
        Me.TB_75.Size = New System.Drawing.Size(40, 40)
        Me.TB_75.TabIndex = 75
        Me.TB_75.Text = "1"
        Me.TB_75.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_74
        '
        Me.TB_74.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_74.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_74.Location = New System.Drawing.Point(235, 515)
        Me.TB_74.Multiline = True
        Me.TB_74.Name = "TB_74"
        Me.TB_74.Size = New System.Drawing.Size(40, 40)
        Me.TB_74.TabIndex = 74
        Me.TB_74.Text = "1"
        Me.TB_74.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_73
        '
        Me.TB_73.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TB_73.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_73.Location = New System.Drawing.Point(190, 515)
        Me.TB_73.Multiline = True
        Me.TB_73.Name = "TB_73"
        Me.TB_73.Size = New System.Drawing.Size(40, 40)
        Me.TB_73.TabIndex = 73
        Me.TB_73.Text = "1"
        Me.TB_73.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BT_Resoudre
        '
        Me.BT_Resoudre.Location = New System.Drawing.Point(32, 155)
        Me.BT_Resoudre.Name = "BT_Resoudre"
        Me.BT_Resoudre.Size = New System.Drawing.Size(75, 23)
        Me.BT_Resoudre.TabIndex = 1000
        Me.BT_Resoudre.Text = "Résoudre"
        Me.BT_Resoudre.UseVisualStyleBackColor = True
        '
        'LBL_Conseil
        '
        Me.LBL_Conseil.AutoSize = True
        Me.LBL_Conseil.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_Conseil.Location = New System.Drawing.Point(190, 593)
        Me.LBL_Conseil.Name = "LBL_Conseil"
        Me.LBL_Conseil.Size = New System.Drawing.Size(0, 20)
        Me.LBL_Conseil.TabIndex = 1002
        '
        'BT_Suivant
        '
        Me.BT_Suivant.Location = New System.Drawing.Point(32, 200)
        Me.BT_Suivant.Name = "BT_Suivant"
        Me.BT_Suivant.Size = New System.Drawing.Size(75, 23)
        Me.BT_Suivant.TabIndex = 1003
        Me.BT_Suivant.Text = "Suivant"
        Me.BT_Suivant.UseVisualStyleBackColor = True
        '
        'BT_Solutions
        '
        Me.BT_Solutions.Location = New System.Drawing.Point(32, 425)
        Me.BT_Solutions.Name = "BT_Solutions"
        Me.BT_Solutions.Size = New System.Drawing.Size(75, 23)
        Me.BT_Solutions.TabIndex = 1004
        Me.BT_Solutions.Text = "Solutions"
        Me.BT_Solutions.UseVisualStyleBackColor = True
        '
        'BT_Smp
        '
        Me.BT_Smp.Location = New System.Drawing.Point(32, 470)
        Me.BT_Smp.Name = "BT_Smp"
        Me.BT_Smp.Size = New System.Drawing.Size(75, 25)
        Me.BT_Smp.TabIndex = 1005
        Me.BT_Smp.Text = "Simpifications"
        Me.BT_Smp.UseVisualStyleBackColor = True
        '
        'Sudoku
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(764, 661)
        Me.Controls.Add(Me.BT_Smp)
        Me.Controls.Add(Me.BT_Solutions)
        Me.Controls.Add(Me.BT_Suivant)
        Me.Controls.Add(Me.LBL_Conseil)
        Me.Controls.Add(Me.BT_Resoudre)
        Me.Controls.Add(Me.TB_81)
        Me.Controls.Add(Me.TB_80)
        Me.Controls.Add(Me.TB_79)
        Me.Controls.Add(Me.TB_78)
        Me.Controls.Add(Me.TB_77)
        Me.Controls.Add(Me.TB_76)
        Me.Controls.Add(Me.TB_75)
        Me.Controls.Add(Me.TB_74)
        Me.Controls.Add(Me.TB_73)
        Me.Controls.Add(Me.TB_72)
        Me.Controls.Add(Me.TB_71)
        Me.Controls.Add(Me.TB_70)
        Me.Controls.Add(Me.TB_69)
        Me.Controls.Add(Me.TB_68)
        Me.Controls.Add(Me.TB_67)
        Me.Controls.Add(Me.TB_66)
        Me.Controls.Add(Me.TB_65)
        Me.Controls.Add(Me.TB_64)
        Me.Controls.Add(Me.TB_63)
        Me.Controls.Add(Me.TB_62)
        Me.Controls.Add(Me.TB_61)
        Me.Controls.Add(Me.TB_60)
        Me.Controls.Add(Me.TB_59)
        Me.Controls.Add(Me.TB_58)
        Me.Controls.Add(Me.TB_57)
        Me.Controls.Add(Me.TB_56)
        Me.Controls.Add(Me.TB_55)
        Me.Controls.Add(Me.TB_54)
        Me.Controls.Add(Me.TB_53)
        Me.Controls.Add(Me.TB_52)
        Me.Controls.Add(Me.TB_51)
        Me.Controls.Add(Me.TB_50)
        Me.Controls.Add(Me.TB_49)
        Me.Controls.Add(Me.TB_48)
        Me.Controls.Add(Me.TB_47)
        Me.Controls.Add(Me.TB_46)
        Me.Controls.Add(Me.TB_45)
        Me.Controls.Add(Me.TB_44)
        Me.Controls.Add(Me.TB_43)
        Me.Controls.Add(Me.TB_42)
        Me.Controls.Add(Me.TB_41)
        Me.Controls.Add(Me.TB_40)
        Me.Controls.Add(Me.TB_39)
        Me.Controls.Add(Me.TB_38)
        Me.Controls.Add(Me.TB_37)
        Me.Controls.Add(Me.TB_36)
        Me.Controls.Add(Me.TB_35)
        Me.Controls.Add(Me.TB_34)
        Me.Controls.Add(Me.TB_33)
        Me.Controls.Add(Me.TB_32)
        Me.Controls.Add(Me.TB_31)
        Me.Controls.Add(Me.TB_30)
        Me.Controls.Add(Me.TB_29)
        Me.Controls.Add(Me.TB_28)
        Me.Controls.Add(Me.TB_27)
        Me.Controls.Add(Me.TB_26)
        Me.Controls.Add(Me.TB_25)
        Me.Controls.Add(Me.TB_24)
        Me.Controls.Add(Me.TB_23)
        Me.Controls.Add(Me.TB_22)
        Me.Controls.Add(Me.TB_21)
        Me.Controls.Add(Me.TB_20)
        Me.Controls.Add(Me.TB_19)
        Me.Controls.Add(Me.TB_18)
        Me.Controls.Add(Me.TB_17)
        Me.Controls.Add(Me.TB_16)
        Me.Controls.Add(Me.TB_15)
        Me.Controls.Add(Me.TB_14)
        Me.Controls.Add(Me.TB_13)
        Me.Controls.Add(Me.TB_12)
        Me.Controls.Add(Me.TB_11)
        Me.Controls.Add(Me.TB_10)
        Me.Controls.Add(Me.TB_09)
        Me.Controls.Add(Me.TB_08)
        Me.Controls.Add(Me.TB_07)
        Me.Controls.Add(Me.TB_06)
        Me.Controls.Add(Me.TB_05)
        Me.Controls.Add(Me.TB_04)
        Me.Controls.Add(Me.TB_03)
        Me.Controls.Add(Me.TB_02)
        Me.Controls.Add(Me.TB_01)
        Me.Controls.Add(Me.TB_petit_modele)
        Me.Controls.Add(Me.TB_grand_modele)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Sudoku"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sudoku"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FichierToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TB_grand_modele As TextBox
    Friend WithEvents TB_petit_modele As TextBox
    Friend WithEvents TB_01 As TextBox
    Friend WithEvents TB_02 As TextBox
    Friend WithEvents TB_03 As TextBox
    Friend WithEvents TB_04 As TextBox
    Friend WithEvents TB_05 As TextBox
    Friend WithEvents TB_06 As TextBox
    Friend WithEvents TB_07 As TextBox
    Friend WithEvents TB_08 As TextBox
    Friend WithEvents TB_09 As TextBox
    Friend WithEvents TB_18 As TextBox
    Friend WithEvents TB_17 As TextBox
    Friend WithEvents TB_16 As TextBox
    Friend WithEvents TB_15 As TextBox
    Friend WithEvents TB_14 As TextBox
    Friend WithEvents TB_13 As TextBox
    Friend WithEvents TB_12 As TextBox
    Friend WithEvents TB_11 As TextBox
    Friend WithEvents TB_10 As TextBox
    Friend WithEvents TB_36 As TextBox
    Friend WithEvents TB_35 As TextBox
    Friend WithEvents TB_34 As TextBox
    Friend WithEvents TB_33 As TextBox
    Friend WithEvents TB_32 As TextBox
    Friend WithEvents TB_31 As TextBox
    Friend WithEvents TB_30 As TextBox
    Friend WithEvents TB_29 As TextBox
    Friend WithEvents TB_28 As TextBox
    Friend WithEvents TB_27 As TextBox
    Friend WithEvents TB_26 As TextBox
    Friend WithEvents TB_25 As TextBox
    Friend WithEvents TB_24 As TextBox
    Friend WithEvents TB_23 As TextBox
    Friend WithEvents TB_22 As TextBox
    Friend WithEvents TB_21 As TextBox
    Friend WithEvents TB_20 As TextBox
    Friend WithEvents TB_19 As TextBox
    Friend WithEvents TB_72 As TextBox
    Friend WithEvents TB_71 As TextBox
    Friend WithEvents TB_70 As TextBox
    Friend WithEvents TB_69 As TextBox
    Friend WithEvents TB_68 As TextBox
    Friend WithEvents TB_67 As TextBox
    Friend WithEvents TB_66 As TextBox
    Friend WithEvents TB_65 As TextBox
    Friend WithEvents TB_64 As TextBox
    Friend WithEvents TB_63 As TextBox
    Friend WithEvents TB_62 As TextBox
    Friend WithEvents TB_61 As TextBox
    Friend WithEvents TB_60 As TextBox
    Friend WithEvents TB_59 As TextBox
    Friend WithEvents TB_58 As TextBox
    Friend WithEvents TB_57 As TextBox
    Friend WithEvents TB_56 As TextBox
    Friend WithEvents TB_55 As TextBox
    Friend WithEvents TB_54 As TextBox
    Friend WithEvents TB_53 As TextBox
    Friend WithEvents TB_52 As TextBox
    Friend WithEvents TB_51 As TextBox
    Friend WithEvents TB_50 As TextBox
    Friend WithEvents TB_49 As TextBox
    Friend WithEvents TB_48 As TextBox
    Friend WithEvents TB_47 As TextBox
    Friend WithEvents TB_46 As TextBox
    Friend WithEvents TB_45 As TextBox
    Friend WithEvents TB_44 As TextBox
    Friend WithEvents TB_43 As TextBox
    Friend WithEvents TB_42 As TextBox
    Friend WithEvents TB_41 As TextBox
    Friend WithEvents TB_40 As TextBox
    Friend WithEvents TB_39 As TextBox
    Friend WithEvents TB_38 As TextBox
    Friend WithEvents TB_37 As TextBox
    Friend WithEvents TB_81 As TextBox
    Friend WithEvents TB_80 As TextBox
    Friend WithEvents TB_79 As TextBox
    Friend WithEvents TB_78 As TextBox
    Friend WithEvents TB_77 As TextBox
    Friend WithEvents TB_76 As TextBox
    Friend WithEvents TB_75 As TextBox
    Friend WithEvents TB_74 As TextBox
    Friend WithEvents TB_73 As TextBox
    Friend WithEvents RésoudreToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QuitterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BT_Resoudre As Button
    Friend WithEvents LBL_Conseil As Label
    Friend WithEvents BT_Suivant As Button
    Friend WithEvents BT_Solutions As Button
    Friend WithEvents BT_Smp As Button
End Class
