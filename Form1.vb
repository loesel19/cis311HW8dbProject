Imports System.Data.SqlClient
Public Class Form1

    Public Const gstrDBOwner As String = "C:\Users\jzpbqq\source\repos\dbo.Owners.mdf"
    Public Const gstrDBVehicle As String = "C:\Users\jzpbqq\source\repos\dbo.Vehicles.mdf"
    Public Const gstrConnStringOwner As String = "Server=(localdb)\MSSQLLocalDB;" &
             "Database=Owners;Integrated Security=SSPI;AttachDbFileName=" &
             gstrDBOwner
    Public Const gstrConnStringVehicle As String = "Server=(localdb)\MSSQLLocalDB;" &
             "Database=Vehicles;Integrated Security=SSPI;AttachDbFileName=" &
             gstrDBVehicle

    Private Sub navigationButtons_Click(sender As Object, e As EventArgs) Handles btnFirst.Click, btnLast.Click, btnPrevious.Click, btnNext.Click
        Dim intTUID As Integer
        Dim intEntries As Integer
        Try
            intTUID = CInt(txtID.Text)
        Catch ex As Exception
            'nothing in textbox as of yet, we want to set it to the first entry
            intTUID = 1
        End Try

        Dim DBConn As SqlConnection
        Dim DBCommand As New SqlCommand
        Dim dsOwners As New DataSet
        Dim DBAdapter As New SqlDataAdapter
        DBConn = New SqlConnection(gstrDBOwner)

        Try
            DBConn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.StackTrace)
            Exit Sub
        End Try

        DBAdapter = New SqlDataAdapter("Select * From Owners", gstrConnStringOwner)
        DBAdapter.Fill(dsOwners, "Owners")
        'get the number of entries
        intEntries = dsOwners.Tables("Owners").Rows.Count
        'see which button fired the event
        If sender.Equals(btnFirst) Then
            intTUID = 1
        ElseIf sender.Equals(btnLast) Then
            intTUID = intEntries
        ElseIf sender.Equals(btnPrevious) Then
            If intTUID > 1 Then
                intTUID -= 1
            Else
                'do nothing cant go back further
            End If
        Else
            If intTUID + 1 > intEntries Then
                'do nothing there is not a next entry
            Else
                intTUID += 1
            End If
        End If

        DBAdapter = New SqlDataAdapter(String.Format("Select * From Owners Where TUID = %n", intTUID), gstrConnStringOwner)
        DBAdapter.Fill(dsOwners, "Owners")

        txtFName.DataBindings.Add(New Binding("Text", dsOwners, "Owners.FirstName"))
        txtLName.DataBindings.Add(New Binding("Text", dsOwners, "Owners.LastName"))
        txtAddress.DataBindings.Add(New Binding("Text", dsOwners, "Owners.StreetAddress"))
        txtCity.DataBindings.Add(New Binding("Text", dsOwners, "Owners.City"))
        txtState.DataBindings.Add(New Binding("Text", dsOwners, "Owners.State"))
        txtZip.DataBindings.Add(New Binding("Text", dsOwners, "Owners.ZipCode"))
        txtID.DataBindings.Add(New Binding("Text", dsOwners, "Owners.TUID"))

        DBConn.Close()



    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'click the first button to load up the first owners data
        btnFirst.PerformClick()
    End Sub


End Class
