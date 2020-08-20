<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Solutions
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
        Me.BT_Fermer = New System.Windows.Forms.Button()
        Me.ListSolution = New System.Windows.Forms.ListView()
        Me.m = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'BT_Fermer
        '
        Me.BT_Fermer.Location = New System.Drawing.Point(26, 13)
        Me.BT_Fermer.Name = "BT_Fermer"
        Me.BT_Fermer.Size = New System.Drawing.Size(75, 23)
        Me.BT_Fermer.TabIndex = 0
        Me.BT_Fermer.Text = "Fermer"
        Me.BT_Fermer.UseVisualStyleBackColor = True
        '
        'ListSolution
        '
        Me.ListSolution.BackColor = System.Drawing.Color.Gainsboro
        Me.ListSolution.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.m})
        Me.ListSolution.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.ListSolution.FullRowSelect = True
        Me.ListSolution.HideSelection = False
        Me.ListSolution.Location = New System.Drawing.Point(26, 42)
        Me.ListSolution.MultiSelect = False
        Me.ListSolution.Name = "ListSolution"
        Me.ListSolution.Size = New System.Drawing.Size(543, 385)
        Me.ListSolution.TabIndex = 1
        Me.ListSolution.UseCompatibleStateImageBehavior = False
        Me.ListSolution.View = System.Windows.Forms.View.Details
        '
        'm
        '
        Me.m.Text = "m"
        Me.m.Width = 335
        '
        'Solutions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(591, 450)
        Me.Controls.Add(Me.ListSolution)
        Me.Controls.Add(Me.BT_Fermer)
        Me.Name = "Solutions"
        Me.Text = "Solutions"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BT_Fermer As Button
    Friend WithEvents ListSolution As ListView
    Friend WithEvents m As ColumnHeader
End Class
