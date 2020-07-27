<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Simplifications
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
        Me.ListSimplifications = New System.Windows.Forms.ListView()
        Me.Technique = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.i1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.j1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.v1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.i2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.j2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.v2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.i3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.j3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.v3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.z = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BT_Fermer_Smp = New System.Windows.Forms.Button()
        Me.ei1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ej1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ev1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ei2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ej2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ev2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ei3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ej3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ev3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'ListSimplifications
        '
        Me.ListSimplifications.BackColor = System.Drawing.Color.Gainsboro
        Me.ListSimplifications.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Technique, Me.i1, Me.j1, Me.v1, Me.i2, Me.j2, Me.v2, Me.i3, Me.j3, Me.v3, Me.z, Me.ei1, Me.ej1, Me.ev1, Me.ei2, Me.ej2, Me.ev2, Me.ei3, Me.ej3, Me.ev3})
        Me.ListSimplifications.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.ListSimplifications.HideSelection = False
        Me.ListSimplifications.Location = New System.Drawing.Point(13, 51)
        Me.ListSimplifications.Name = "ListSimplifications"
        Me.ListSimplifications.Size = New System.Drawing.Size(1116, 518)
        Me.ListSimplifications.TabIndex = 0
        Me.ListSimplifications.UseCompatibleStateImageBehavior = False
        Me.ListSimplifications.View = System.Windows.Forms.View.Details
        '
        'Technique
        '
        Me.Technique.Text = "Technique"
        Me.Technique.Width = 270
        '
        'i1
        '
        Me.i1.Text = "i1"
        Me.i1.Width = 25
        '
        'j1
        '
        Me.j1.Text = "j1"
        Me.j1.Width = 25
        '
        'v1
        '
        Me.v1.Text = "v1"
        Me.v1.Width = 25
        '
        'i2
        '
        Me.i2.Text = "i2"
        Me.i2.Width = 25
        '
        'j2
        '
        Me.j2.Text = "j2"
        Me.j2.Width = 25
        '
        'v2
        '
        Me.v2.Text = "v2"
        Me.v2.Width = 25
        '
        'i3
        '
        Me.i3.Text = "i3"
        Me.i3.Width = 25
        '
        'j3
        '
        Me.j3.Text = "j3"
        Me.j3.Width = 25
        '
        'v3
        '
        Me.v3.Text = "v3"
        Me.v3.Width = 25
        '
        'z
        '
        Me.z.Text = "|"
        Me.z.Width = 25
        '
        'BT_Fermer_Smp
        '
        Me.BT_Fermer_Smp.Location = New System.Drawing.Point(13, 22)
        Me.BT_Fermer_Smp.Name = "BT_Fermer_Smp"
        Me.BT_Fermer_Smp.Size = New System.Drawing.Size(96, 23)
        Me.BT_Fermer_Smp.TabIndex = 1
        Me.BT_Fermer_Smp.Text = "Fermer"
        Me.BT_Fermer_Smp.UseVisualStyleBackColor = True
        '
        'ei1
        '
        Me.ei1.Text = "i1"
        Me.ei1.Width = 25
        '
        'ej1
        '
        Me.ej1.Text = "j1"
        Me.ej1.Width = 25
        '
        'ev1
        '
        Me.ev1.Text = "v1"
        Me.ev1.Width = 25
        '
        'ei2
        '
        Me.ei2.Text = "i2"
        Me.ei2.Width = 25
        '
        'ej2
        '
        Me.ej2.Text = "j2"
        Me.ej2.Width = 25
        '
        'ev2
        '
        Me.ev2.Text = "v2"
        Me.ev2.Width = 25
        '
        'ei3
        '
        Me.ei3.Text = "i3"
        Me.ei3.Width = 25
        '
        'ej3
        '
        Me.ej3.Text = "j3"
        Me.ej3.Width = 25
        '
        'ev3
        '
        Me.ev3.Text = "v3"
        Me.ev3.Width = 25
        '
        'Simplifications
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(1140, 656)
        Me.Controls.Add(Me.BT_Fermer_Smp)
        Me.Controls.Add(Me.ListSimplifications)
        Me.Name = "Simplifications"
        Me.Text = "Simplifications"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ListSimplifications As ListView
    Friend WithEvents BT_Fermer_Smp As Button
    Friend WithEvents Technique As ColumnHeader
    Friend WithEvents i1 As ColumnHeader
    Friend WithEvents j1 As ColumnHeader
    Friend WithEvents v1 As ColumnHeader
    Friend WithEvents i2 As ColumnHeader
    Friend WithEvents j2 As ColumnHeader
    Friend WithEvents v2 As ColumnHeader
    Friend WithEvents i3 As ColumnHeader
    Friend WithEvents j3 As ColumnHeader
    Friend WithEvents v3 As ColumnHeader
    Friend WithEvents z As ColumnHeader
    Friend WithEvents ei1 As ColumnHeader
    Friend WithEvents ej1 As ColumnHeader
    Friend WithEvents ev1 As ColumnHeader
    Friend WithEvents ei2 As ColumnHeader
    Friend WithEvents ej2 As ColumnHeader
    Friend WithEvents ev2 As ColumnHeader
    Friend WithEvents ei3 As ColumnHeader
    Friend WithEvents ej3 As ColumnHeader
    Friend WithEvents ev3 As ColumnHeader
End Class
