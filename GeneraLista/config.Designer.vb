<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class config
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(config))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.rtc = New System.Windows.Forms.RichTextBox()
        Me.Cerrar = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(138, 252)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Editar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'rtc
        '
        Me.rtc.Enabled = False
        Me.rtc.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtc.Location = New System.Drawing.Point(12, 15)
        Me.rtc.Name = "rtc"
        Me.rtc.Size = New System.Drawing.Size(352, 231)
        Me.rtc.TabIndex = 1
        Me.rtc.Text = ""
        '
        'Cerrar
        '
        Me.Cerrar.Location = New System.Drawing.Point(219, 252)
        Me.Cerrar.Name = "Cerrar"
        Me.Cerrar.Size = New System.Drawing.Size(75, 23)
        Me.Cerrar.TabIndex = 2
        Me.Cerrar.Text = "Cerrar"
        Me.Cerrar.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(61, 252)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(71, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Actualizar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'config
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(376, 282)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Cerrar)
        Me.Controls.Add(Me.rtc)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "config"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents rtc As RichTextBox
    Friend WithEvents Cerrar As Button
    Friend WithEvents Button2 As Button
End Class
