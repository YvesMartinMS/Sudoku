<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Simplifications
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
        Me.ListSimplifications = New System.Windows.Forms.ListView()
        Me.BT_Fermer_Smp = New System.Windows.Forms.Button()
        Me.Technique = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.i1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.j1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.v1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'ListSimplifications
        '
        Me.ListSimplifications.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Technique, Me.i1, Me.j1, Me.v1})
        Me.ListSimplifications.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.ListSimplifications.HideSelection = False
        Me.ListSimplifications.Location = New System.Drawing.Point(12, 67)
        Me.ListSimplifications.Name = "ListSimplifications"
        Me.ListSimplifications.Size = New System.Drawing.Size(480, 343)
        Me.ListSimplifications.TabIndex = 0
        Me.ListSimplifications.UseCompatibleStateImageBehavior = False
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
        'Simplifications
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(516, 450)
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
End Class
