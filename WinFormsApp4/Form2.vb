Imports System.Data.SqlClient
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Public Class Form2

    ' Insert values into the Area_table
    Dim connectionString As String = "Data Source=NEO\SQLEXPRESS;Initial Catalog='Electricity Bill Management System';Integrated Security=True;"

    Private Sub PrintBookingDetails()
        ' Retrieve data from the form controls
        Dim billID As String = TextBox1.Text
        Dim billHolderName As String = TextBox2.Text
        Dim unitsUsed As String = TextBox3.Text
        Dim areaName As String = ComboBox1.SelectedItem.ToString()
        Dim totalAmount As String = TextBox5.Text

        ' Check if all necessary fields are filled
        If Not String.IsNullOrWhiteSpace(billID) AndAlso
       Not String.IsNullOrWhiteSpace(billHolderName) AndAlso
       Not String.IsNullOrWhiteSpace(unitsUsed) AndAlso
       Not String.IsNullOrWhiteSpace(areaName) AndAlso
       Not String.IsNullOrWhiteSpace(totalAmount) Then

            ' Create a new PDF document
            Dim doc As New iTextSharp.text.Document()
            Dim directoryPath As String = "C:\PDF Generated"
            Dim fileName As String = $"BillDetails_{billID}.pdf"
            Dim filePath As String = Path.Combine(directoryPath, fileName)

            Try
                Dim writer As PdfWriter = PdfWriter.GetInstance(doc, New FileStream(filePath, FileMode.Create))
                doc.Open()

                ' Add content to the PDF document
                Dim para As New Paragraph()
                para.Add("Bill ID: " & billID & vbCrLf)
                para.Add("Bill Holder Name: " & billHolderName & vbCrLf)
                para.Add("Units Used: " & unitsUsed & vbCrLf)
                para.Add("Area Name: " & areaName & vbCrLf)
                para.Add("Total Amount: " & totalAmount & vbCrLf)

                doc.Add(para)
            Catch ex As Exception
                MessageBox.Show("Error creating PDF: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                doc.Close()
            End Try

        Else
        End If
    End Sub


    Private Function GenerateNextBillIDFromDatabase() As String
        Dim nextBillID As String = "1" ' Default value

        Try
            ' SQL query to get the last bill ID from the database
            Dim queryLastBillID As String = "SELECT TOP 1 bill_ID FROM Bill_table ORDER BY CAST(bill_ID AS INT) DESC"

            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(queryLastBillID, connection)
                    connection.Open()
                    Dim lastBillID As String = Convert.ToString(command.ExecuteScalar())

                    ' If there are records in the database, generate the next bill ID
                    If Not String.IsNullOrEmpty(lastBillID) Then
                        ' Convert the last bill ID to an integer and increment by 1
                        Dim lastNumericPart As Integer
                        If Integer.TryParse(lastBillID, lastNumericPart) Then
                            ' Increment the numeric part by 1
                            lastNumericPart += 1
                            ' Construct the next bill ID
                            nextBillID = lastNumericPart.ToString()
                        Else
                            ' If the conversion fails, increment the whole string value
                            nextBillID = (Convert.ToInt32(lastBillID) + 1).ToString()
                        End If
                    Else
                        ' If there are no records, set the default value to "1"
                        nextBillID = "1"
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error generating next bill ID: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return nextBillID
    End Function




    ' Check if any character, number, or special character is repeated more than once
    Private Function ContainsRepeatedCharacters(input As String) As Boolean
        Dim count As Integer = 1
        For i As Integer = 1 To input.Length - 1
            If input(i) = input(i - 1) Then
                count += 1
                If count > 2 Then
                    Return True
                End If
            Else
                count = 1
            End If
        Next
        Return False
    End Function

    Private Function ValidateInput() As Boolean

        ' Name Presence Check
        If String.IsNullOrWhiteSpace(TextBox2.Text) Then
            MessageBox.Show("Name cannot be blank.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Focus()
            Return False
        End If

        If Not TextBox2.Text.All(Function(c) Char.IsLetter(c) Or c = " ") Then
            MessageBox.Show("Invalid name", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Focus()
            Return False
        ElseIf ContainsRepeatedCharacters(TextBox2.Text) Then
            MessageBox.Show("Name should not contain repeated characters", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Focus()
            Return False
        End If

        ' Number of Units Presence Check and Validation
        Dim units As Double ' Change data type to Double to allow decimal numbers
        If String.IsNullOrWhiteSpace(TextBox3.Text) Then
            MessageBox.Show("Number of units cannot be blank.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox3.Focus()
            Return False

        ElseIf Not Double.TryParse(TextBox3.Text, units) Then ' Change TryParse to Double.TryParse
            MessageBox.Show("Number of units must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox3.Focus()
            Return False
        ElseIf units <= 0 Then
            MessageBox.Show("Number of units must be greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox3.Focus()
            Return False
        End If

        ' Check if ComboBox1 is selected
        If ComboBox1.SelectedIndex = -1 Then
            MessageBox.Show("Please select an area.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ComboBox1.Focus()
            Return False
        End If

        ' All validations passed
        Return True
    End Function

    Private Sub EnableAndClearControls()
        ' Enable controls
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        ComboBox1.Enabled = True

        ' Clear controls
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox5.Text = ""
        ComboBox1.SelectedIndex = -1 ' Clear the selection
    End Sub



    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TextBox1.Text = GenerateNextBillIDFromDatabase()

        ' Disable controls
        TextBox1.Enabled = False
        TextBox5.Enabled = False

        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList

        ' Add area names individually to the ComboBox
        ComboBox1.Items.Add("Bagalur")
        ComboBox1.Items.Add("Hennur")
        ComboBox1.Items.Add("Nagavara")
        ComboBox1.Items.Add("Kothanur")
        ComboBox1.Items.Add("Narayanpura")
        ComboBox1.Items.Add("Kannur")

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Close the current form (Form2) and open the first form (Form1) again
        Dim form1 As New Form1
        form1.Show()
        Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Enable and clear controls
        EnableAndClearControls()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' Close the current form (Form1) and open the first form (Form3) again
        Dim form3 As New Form3
        form3.Show()
        Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        ' Name Presence Check
        If String.IsNullOrWhiteSpace(TextBox2.Text) Then
            MessageBox.Show("Name cannot be blank.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Focus()
            Exit Sub
        End If

        If Not TextBox2.Text.All(Function(c) Char.IsLetter(c) Or c = " ") Then
            MessageBox.Show("Invalid name", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Focus()
            Exit Sub
        ElseIf ContainsRepeatedCharacters(TextBox2.Text) Then
            MessageBox.Show("Name should not contain repeated characters", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Focus()
            Exit Sub
        End If

        ' Number of Units Presence Check and Validation
        Dim units As Double ' Change data type to Double to allow decimal numbers
        If String.IsNullOrWhiteSpace(TextBox3.Text) Then
            MessageBox.Show("Number of units cannot be blank.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox3.Focus()
            Exit Sub
        ElseIf Not Double.TryParse(TextBox3.Text, units) Then ' Change TryParse to Double.TryParse
            MessageBox.Show("Number of units must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox3.Focus()
            Exit Sub
        ElseIf units <= 0 Then
            MessageBox.Show("Number of units must be greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox3.Focus()
            Exit Sub
        End If

        ' Check if ComboBox1 is selected
        If ComboBox1.SelectedIndex = -1 Then
            MessageBox.Show("Please select an area.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ComboBox1.Focus()
            Exit Sub
        End If

        ' Check if total amount is already calculated
        If String.IsNullOrWhiteSpace(TextBox5.Text) Then
            ' Total amount not calculated, prompt the user to calculate it
            MessageBox.Show("Please calculate the total amount first.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Dim query As String = "INSERT INTO [dbo].[Bill_table] ([bill_ID], [bh_name], [units], [a_name], [t_amt]) VALUES (@bill_ID, @bh_name, @units, @a_name, @t_amt)"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@bill_ID", TextBox1.Text)
                command.Parameters.AddWithValue("@bh_name", TextBox2.Text)
                command.Parameters.AddWithValue("@units", units)
                command.Parameters.AddWithValue("@a_name", ComboBox1.SelectedItem.ToString())
                command.Parameters.AddWithValue("@t_amt", Decimal.Parse(TextBox5.Text.Trim().Substring(3))) ' Remove "Rs " and parse as Decimal

                command.ExecuteNonQuery()

                ' Call the function to print booking details
                PrintBookingDetails()
            End Using
        End Using

        MessageBox.Show("Data saved successfully.Receipt Generated Successful")
        ' Enable and clear controls
        EnableAndClearControls()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ' Validate input
        If Not ValidateInput() Then
            ' Exit if validation fails
            Return
        End If

        ' Calculate total amount
        Dim units As Double
        If Not Double.TryParse(TextBox3.Text, units) Then
            MessageBox.Show("Number of units must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox3.Focus()
            Return
        End If

        ' Assuming rate per unit is Rs. 5, you can adjust this value accordingly
        Dim ratePerUnit As Double = 5.0
        Dim totalAmount As Double = units * ratePerUnit

        ' Display total amount in TextBox5
        TextBox5.Text = "Rs " & totalAmount.ToString()

        ' Disable controls
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox5.Enabled = False
        ComboBox1.Enabled = False
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        ' Check if TextBox1 is empty
        If String.IsNullOrEmpty(TextBox1.Text) Then
            ' Generate the next visitor ID
            TextBox1.Text = GenerateNextBillIDFromDatabase()

            ' Disable TextBox1 to prevent editing
            TextBox1.Enabled = False
        End If

    End Sub
End Class