<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        TextBox1 = New TextBox()
        TextBox2 = New TextBox()
        TextBox3 = New TextBox()
        Label5 = New Label()
        TextBox5 = New TextBox()
        Button1 = New Button()
        Button2 = New Button()
        Button3 = New Button()
        GroupBox1 = New GroupBox()
        Button5 = New Button()
        ComboBox1 = New ComboBox()
        Button4 = New Button()
        Label6 = New Label()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(45, 38)
        Label1.Name = "Label1"
        Label1.Size = New Size(57, 25)
        Label1.TabIndex = 0
        Label1.Text = "Bill ID"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(45, 102)
        Label2.Name = "Label2"
        Label2.Size = New Size(142, 25)
        Label2.TabIndex = 1
        Label2.Text = "Bill Holder name"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(45, 162)
        Label3.Name = "Label3"
        Label3.Size = New Size(95, 25)
        Label3.TabIndex = 2
        Label3.Text = "Units used"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(45, 234)
        Label4.Name = "Label4"
        Label4.Size = New Size(100, 25)
        Label4.TabIndex = 3
        Label4.Text = "Area Name"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(208, 35)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(232, 31)
        TextBox1.TabIndex = 4
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(208, 100)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(232, 31)
        TextBox2.TabIndex = 5
        ' 
        ' TextBox3
        ' 
        TextBox3.Location = New Point(208, 162)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(232, 31)
        TextBox3.TabIndex = 6
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(45, 329)
        Label5.Name = "Label5"
        Label5.Size = New Size(116, 25)
        Label5.TabIndex = 9
        Label5.Text = "Total amount"
        ' 
        ' TextBox5
        ' 
        TextBox5.Font = New Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        TextBox5.Location = New Point(208, 323)
        TextBox5.Name = "TextBox5"
        TextBox5.Size = New Size(232, 37)
        TextBox5.TabIndex = 10
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(45, 375)
        Button1.Name = "Button1"
        Button1.Size = New Size(112, 63)
        Button1.TabIndex = 11
        Button1.Text = "Save and Print"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button2.Location = New Point(186, 375)
        Button2.Name = "Button2"
        Button2.Size = New Size(112, 63)
        Button2.TabIndex = 12
        Button2.Text = "Clear"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Font = New Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button3.Location = New Point(328, 375)
        Button3.Name = "Button3"
        Button3.Size = New Size(112, 63)
        Button3.TabIndex = 13
        Button3.Text = "Back"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = Color.DarkGray
        GroupBox1.Controls.Add(Button5)
        GroupBox1.Controls.Add(ComboBox1)
        GroupBox1.Controls.Add(Button3)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(Button2)
        GroupBox1.Controls.Add(Button1)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(TextBox5)
        GroupBox1.Controls.Add(TextBox1)
        GroupBox1.Controls.Add(Label5)
        GroupBox1.Controls.Add(TextBox2)
        GroupBox1.Controls.Add(TextBox3)
        GroupBox1.Location = New Point(229, 74)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(500, 453)
        GroupBox1.TabIndex = 14
        GroupBox1.TabStop = False
        ' 
        ' Button5
        ' 
        Button5.BackColor = Color.LawnGreen
        Button5.Font = New Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button5.Location = New Point(261, 275)
        Button5.Name = "Button5"
        Button5.Size = New Size(112, 34)
        Button5.TabIndex = 14
        Button5.Text = "Calculate"
        Button5.UseVisualStyleBackColor = False
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(208, 231)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(232, 33)
        ComboBox1.TabIndex = 11
        ' 
        ' Button4
        ' 
        Button4.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        Button4.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button4.Location = New Point(817, 12)
        Button4.Name = "Button4"
        Button4.Size = New Size(123, 68)
        Button4.TabIndex = 14
        Button4.Text = "Area Wise Calculation"
        Button4.UseVisualStyleBackColor = False
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(345, 12)
        Label6.Name = "Label6"
        Label6.Size = New Size(285, 48)
        Label6.TabIndex = 15
        Label6.Text = "Bill Generation"
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources._360_F_299237262_Cj3wYz3HK7Aak1qNW4biP268qL1wphOr
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(952, 573)
        Controls.Add(Label6)
        Controls.Add(Button4)
        Controls.Add(GroupBox1)
        Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Name = "Form2"
        Text = "boxx"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Label6 As Label
End Class
