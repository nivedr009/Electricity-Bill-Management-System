Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar

Public Class Form1
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" AndAlso TextBox2.Text = "" Then
            ' Display a message indicating both fields are empty
            MessageBox.Show("Please enter username and password")
        ElseIf TextBox1.Text = "" Then
            ' Display a message indicating username is empty
            MessageBox.Show("Please enter username")
        ElseIf TextBox2.Text = "" Then
            ' Display a message indicating password is empty
            MessageBox.Show("Please enter password")
        ElseIf TextBox1.Text = "messi" AndAlso TextBox2.Text = "123" Then
            ' Simulate a login process (replace this with your actual login logic)
            Dim username As String = TextBox1.Text
            Dim password As String = TextBox2.Text

            ' Display a message indicating successful login
            MessageBox.Show("Login Successful")

            ' Open the next form
            Dim form2 As New Form2
            form2.Show()
            ' Close this form after the next form is closed
            Me.Hide()
        Else
            ' Display a message indicating unsuccessful login
            MessageBox.Show("Invalid username or password")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Application.Exit()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Clear the username and password fields
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Enable password masking for TextBox2
        TextBox2.UseSystemPasswordChar = True

    End Sub
End Class