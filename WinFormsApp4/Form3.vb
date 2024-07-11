Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Public Class Form3

    Private Function RetrieveAreaDetails() As String
        Dim areaDetailsContent As New StringBuilder()

        Try
            ' Connect to the database
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                ' Retrieve data from Area_table
                Dim areaQuery As String = "SELECT * FROM Area_table"
                Dim areaAdapter As New SqlDataAdapter(areaQuery, connection)
                Dim areaTable As New DataTable()
                areaAdapter.Fill(areaTable)

                ' Format the report
                areaDetailsContent.AppendLine("Areawise Details:")
                areaDetailsContent.AppendLine()
                For Each row As DataRow In areaTable.Rows
                    areaDetailsContent.AppendLine($"Area Name: {row("a_name")}, Area ID: {row("area_ID")}, Total Units: {row("t_units")}, Total Amount: {row("t_amt")}")
                    areaDetailsContent.AppendLine() ' Add an extra line gap
                Next
            End Using

        Catch ex As Exception
            MessageBox.Show("Error retrieving area details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return areaDetailsContent.ToString()
    End Function


    ' Insert values into the Area_table
    Dim connectionString As String = "Data Source=NEO\SQLEXPRESS;Initial Catalog='Electricity Bill Management System';Integrated Security=True;"

    Private Function GetSumOfUnitsForArea(areaName As String) As Double
        Dim sumUnits As Double = 0

        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT SUM(units) FROM Bill_table WHERE a_name = @areaName"
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@areaName", areaName)
                    Dim result As Object = command.ExecuteScalar()
                    If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                        sumUnits = Convert.ToDouble(result)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching sum of units: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return sumUnits
    End Function



    Private Function GetAreaID(areaName As String) As String
        Select Case areaName
            Case "Bagalur"
                Return "001"
            Case "Hennur"
                Return "002"
            Case "Nagavara"
                Return "003"
            Case "Kothanur"
                Return "004"
            Case "Narayanpura"
                Return "005"
            Case "Kannur"
                Return "006"
                ' Add more cases as needed for other area names
            Case Else
                Return "" ' Return empty string if area name is not found
        End Select
    End Function


    Private Sub EnableAndClearControls()
        ' Enable controls
        ComboBox1.Enabled = True

        ' Clear controls
        TextBox1.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox1.SelectedIndex = -1 ' Clear the selection
    End Sub

    Private Function ValidateInput() As Boolean
        ' Check if ComboBox1 is selected
        If ComboBox1.SelectedIndex = -1 Then
            MessageBox.Show("Please select an area.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ComboBox1.Focus()
            Return False
        End If

        ' Area ID Presence Check
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MessageBox.Show("Area ID cannot be blank", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Focus()
            Return False
        End If

        ' Number of Units Presence Check and Validation
        Dim unitsText As String = TextBox3.Text.Replace(" Kwh", "") ' Remove " Kwh" suffix
        Dim units As Double

        If String.IsNullOrWhiteSpace(unitsText) Then
            MessageBox.Show("Number of units cannot be blank.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox3.Focus()
            Return False
        ElseIf Not Double.TryParse(unitsText, units) Then ' Parse unitsText into units variable
            MessageBox.Show("Number of units must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox3.Focus()
            Return False
        ElseIf units <= 0 Then
            MessageBox.Show("Number of units must be greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox3.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        ' Validate input before proceeding
        If Not ValidateInput() Then
            ' Exit if validation fails
            Return
        End If

        ' Extract the numeric value from TextBox3 by removing the " Kwh" suffix
        Dim unitsText As String = TextBox3.Text.Replace(" Kwh", "")

        ' Convert unitsText to a Double
        Dim units As Double
        If Not Double.TryParse(unitsText, units) Then
            MessageBox.Show("Number of units must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox3.Focus()
            Return
        End If

        ' Display total amount in TextBox4 with "Rs" before it
        Dim ratePerUnit As Double = 5.0 ' Assuming rate per unit is Rs. 5, adjust accordingly if needed
        Dim totalAmount As Double = units * ratePerUnit
        TextBox4.Text = "Rs " & totalAmount.ToString()

        ' Save data to the database
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Dim query As String = "INSERT INTO [dbo].[Area_table] ([a_name], [area_ID], [t_units], [t_amt]) VALUES (@a_name, @area_ID, @t_units, @t_amt)"
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@a_name", ComboBox1.SelectedItem.ToString())
                    command.Parameters.AddWithValue("@area_ID", TextBox1.Text)
                    command.Parameters.AddWithValue("@t_units", units) ' Use the retrieved units value
                    command.Parameters.AddWithValue("@t_amt", Decimal.Parse(TextBox4.Text.Trim().Substring(3))) ' Remove "Rs " and parse as Decimal

                    command.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Data saved successfully.")
            ' Enable and clear controls
            EnableAndClearControls()

            ComboBox1.Enabled = True

        Catch ex As Exception
            MessageBox.Show("Error saving data to database: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Close the current form (Form3) and open the first form (Form2) again
        Dim form2 As New Form2
        form2.Show()
        Close()
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Disable controls
        TextBox1.Enabled = False

        ' Disable controls
        TextBox3.Enabled = False

        ' Disable controls
        TextBox4.Enabled = False



        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList

        ' Add area names individually to the ComboBox
        ComboBox1.Items.Add("Bagalur")
        ComboBox1.Items.Add("Hennur")
        ComboBox1.Items.Add("Nagavara")
        ComboBox1.Items.Add("Kothanur")
        ComboBox1.Items.Add("Narayanpura")
        ComboBox1.Items.Add("Kannur")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Enable and clear controls
        EnableAndClearControls()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' Check if an item is selected in ComboBox1
        If ComboBox1.SelectedIndex <> -1 Then
            ' Determine the area name based on the selected item in ComboBox1
            Dim areaName As String = ComboBox1.SelectedItem.ToString()

            ' Fetch the area ID for the selected area
            Dim areaID As String = GetAreaID(areaName)

            ' Display the area ID in TextBox1
            TextBox1.Text = areaID

            ' Fetch the sum of units for the selected area
            Dim sumUnits As Double = GetSumOfUnitsForArea(areaName)

            ' Display the sum of units in TextBox3 with "Kwh" after the number
            TextBox3.Text = sumUnits.ToString() & " Kwh"
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' Validate input before proceeding
        If Not ValidateInput() Then
            ' Exit if validation fails
            Return
        End If

        ' Extract the numeric value from TextBox3 by removing the " Kwh" suffix
        Dim unitsText As String = TextBox3.Text.Replace(" Kwh", "")
        Dim units As Double

        If Not Double.TryParse(unitsText, units) Then
            MessageBox.Show("Number of units must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox3.Focus()
            Return
        End If

        ' Assuming rate per unit is Rs. 5, you can adjust this value accordingly
        Dim ratePerUnit As Double = 5.0
        Dim totalAmount As Double = units * ratePerUnit

        ' Display total amount in TextBox4 with "Rs" before it
        TextBox4.Text = "Rs " & totalAmount.ToString()

        ' Clear controls
        ' Enable controls
        ComboBox1.Enabled = False
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim areaDetails As String = RetrieveAreaDetails()
        MessageBox.Show(areaDetails, "Area Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class