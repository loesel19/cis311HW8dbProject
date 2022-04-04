Imports System.Data.SqlClient
Public Class Form1
    '--------------------------------------------------------------------------------
    '-                      File Name: Form1                                        -
    '-                      Part of Project: Vehicle/ Owner Database (cis311 HW8)   -
    '--------------------------------------------------------------------------------
    '-                      Written By: Andrew A. Loesel                            -
    '-                      Written On: April 1, 2022                               -
    '--------------------------------------------------------------------------------
    '- File Purpose:                                                                -
    '-                                                                              -
    '- The purpose of this file is to act as the main form for our database         -
    '- application. We split the program flow into different subroutines to navigate-
    '- through Owner entries, Add, and delete and update Owner entries. All database-
    '- reads and writes are handled in this File.                                   -
    '--------------------------------------------------------------------------------
    '- Program Purpose:                                                             -
    '-                                                                              -
    '- The purpose of this program is to act as a databse front end. The database   -
    '- consists of a Vehicle table, which has information on certain Vehicles and   -
    '- which owner owns the vehicle, and an Owner table which has information about -
    '- the Owners such as names and addresses. The user will be able to perform all -
    '- of the CRUD operations on the database.                                      -
    '--------------------------------------------------------------------------------
    '- Global Variable Dictionary (alphabetically):                                 -
    '- gintCurrent - holds the current TUID of the owner being viewed during an add -
    '-               operation.                                                     -
    '- gstrCRUD - denotes whether we are in an Add or Update operation, N means     -
    '-            neither.                                                          -
    '--------------------------------------------------------------------------------

    'GLOBAL CONSTANTS GLOBAL CONSTANTS GLOBAL CONSTANTS GLOBAL CONSTANTS GLOBAL CONSTANTS
    'GLOBAL CONSTANTS GLOBAL CONSTANTS GLOBAL CONSTANTS GLOBAL CONSTANTS GLOBAL CONSTANTS
    ' the absolute path to the database
    Public Const gstrDBName As String = "C:\Users\jzpbqq\source\repos\cis311HW8dbProject\MSSQLLocalDB\HW8.mdf"
    'our database connection string
    Public Const gstrConnString As String = "Server=(localdb)\MSSQLLocalDB;" &
             "Database=hw8;Integrated Security=SSPI;AttachDbFileName=" &
             gstrDBName

    'GLOBAL VARIABLES GLOBAL VARIABLES GLOBAL VARIABLES GLOBAL VARIABLES GLOBAL VARIABLES
    'GLOBAL VARIABLES GLOBAL VARIABLES GLOBAL VARIABLES GLOBAL VARIABLES GLOBAL VARIABLES
    Private gintCurrent As Integer = -1
    Private gstrCRUD As String = "N"

    'SUBPROGRAMS SUBPROGRAMS SUBPROGRAMS SUBPROGRAMS SUBPROGRAMS SUBPROGRAMS SUBPROGRAMS SUBPROGRAMS
    'SUBPROGRAMS SUBPROGRAMS SUBPROGRAMS SUBPROGRAMS SUBPROGRAMS SUBPROGRAMS SUBPROGRAMS SUBPROGRAMS

    Private Sub clearDataBindings()
        '------------------------------------------------------------------------------
        '-                      Subprogram Name: clearDataBiindings                   -
        '------------------------------------------------------------------------------
        '-                      Written By: Andrew A. Loesel                          -
        '-                      Written On: April 1, 2022                             -
        '------------------------------------------------------------------------------
        '- Subprogram Purpose:                                                        -
        '-                                                                            -
        '- The purpose of this subprogram is to clear the dataBindings for all the    -
        '- textboxes so that they can be rebound.                                     -
        '------------------------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):                                 -
        '- None                                                                       -
        '------------------------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):                                -
        '- None                                                                       -
        '------------------------------------------------------------------------------
        txtFName.DataBindings.Clear()
        txtLName.DataBindings.Clear()
        txtAddress.DataBindings.Clear()
        txtCity.DataBindings.Clear()
        txtState.DataBindings.Clear()
        txtZip.DataBindings.Clear()
        txtID.DataBindings.Clear()
    End Sub

    Private Sub clearTextboxes()
        '------------------------------------------------------------------------------
        '-                      Subprogram Name: clearTextboxes                       -
        '------------------------------------------------------------------------------
        '-                      Written By: Andrew A. Loesel                          -
        '-                      Written On: April 1, 2022                             -
        '------------------------------------------------------------------------------
        '- Subprogram Purpose:                                                        -
        '-                                                                            -
        '- The purpose of this subprogram is to clear all the textboxes               -
        '------------------------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):                                 -
        '- None                                                                       -
        '------------------------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):                                -
        '- None                                                                       -
        '------------------------------------------------------------------------------
        txtLName.Clear()
        txtState.Clear()
        txtZip.Clear()
        txtID.Clear()
        txtFName.Clear()
        txtCity.Clear()
        txtAddress.Clear()
    End Sub
    Private Sub setTextBoxEnableSetting(blnEnable As Boolean)
        '------------------------------------------------------------------------------
        '-                      Subprogram Name: setTextboxEnableSetting              -
        '------------------------------------------------------------------------------
        '-                      Written By: Andrew A. Loesel                          -
        '-                      Written On: April 1, 2022                             -
        '------------------------------------------------------------------------------
        '- Subprogram Purpose:                                                        -
        '-                                                                            -
        '- The purpose of this subprogram is to either enable or disable the textboxes-
        '- depending on the boolean value of blnEnable.                               -
        '------------------------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):                                 -
        '- blnEnable - a boolean that will determine if the textboxes are enable or   -
        '-             disabled.                                                      -
        '------------------------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):                                -
        '- None                                                                       -
        '------------------------------------------------------------------------------
        txtFName.Enabled = blnEnable
        txtLName.Enabled = blnEnable
        txtAddress.Enabled = blnEnable
        txtCity.Enabled = blnEnable
        txtState.Enabled = blnEnable
        txtZip.Enabled = blnEnable
    End Sub
    Private Sub setNormalButtons(blnVisible As Boolean)
        '------------------------------------------------------------------------------
        '-                      Subprogram Name: setNormalButtons                     -
        '------------------------------------------------------------------------------
        '-                      Written By: Andrew A. Loesel                          -
        '-                      Written On: April 1, 2022                             -
        '------------------------------------------------------------------------------
        '- Subprogram Purpose:                                                        -
        '-                                                                            -
        '- The purpose of this subprogram is to set which of the buttons are visible  -
        '- depending on blnVisible.                                                   -
        '------------------------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):                                 -
        '- blnVisible - used to set the visible property of the buttons.              -
        '------------------------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):                                -
        '- None                                                                       -
        '------------------------------------------------------------------------------
        btnAdd.Visible = blnVisible
        btnUpdate.Visible = blnVisible
        btnDelete.Visible = blnVisible
        btnFirst.Visible = blnVisible
        btnPrevious.Visible = blnVisible
        btnNext.Visible = blnVisible
        btnLast.Visible = blnVisible
        btnSave.Visible = Not blnVisible
        btnCancel.Visible = Not blnVisible
    End Sub
    Private Sub updateVehicles(intOwner As Integer)
        '------------------------------------------------------------------------------
        '-                      Subprogram Name: updateVehicles                       -
        '------------------------------------------------------------------------------
        '-                      Written By: Andrew A. Loesel                          -
        '-                      Written On: April 1, 2022                             -
        '------------------------------------------------------------------------------
        '- Subprogram Purpose:                                                        -
        '-                                                                            -
        '- The purpose of this subroutine is to update which vehicles are being shown -
        '- in the datagridview. We take in an int corresponding to the TUID of the    -
        '- Owner. We then open up a connection to our database, and select certain    -
        '- columns from table Vehicles where OwnerID = intOwner. Lastly we bind the   -
        '- result of the query as a datasource for dgvVehicle
        '------------------------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):                                 -
        '- intOwner - an integer representing the TUID of the current displayed owner.-
        '------------------------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):                                -
        '- DBAdapter - this will work as an in between object to connect our program  -
        '-             to the database.                                               -
        '- DBCommand - This will be used to act as a SQL query object, allows us to   -
        '-             to set certain query statements against the database.          -
        '- DBConn - This acts as a connection object to our database.                 -
        '- dsVehicles - this will be set to the return of the SQL query we perform    -
        '-              against the database.                                         -
        '------------------------------------------------------------------------------
        Dim DBConn As SqlConnection
        Dim DBCommand As New SqlCommand
        Dim dsVehicles As New DataSet
        Dim DBAdapter As SqlDataAdapter

        DBConn = New SqlConnection(gstrConnString)

        Try
            DBConn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Could not open DataBase")
            Exit Sub
        End Try

        'clear the dataset of prior data
        dsVehicles.Clear()

        DBAdapter = New SqlDataAdapter(String.Format("Select Make, Model, Color, ModelYear, VIN From Vehicles Where OwnerID = {0}", intOwner), gstrConnString)
        DBAdapter.Fill(dsVehicles, "Vehicles")

        dgvVehicle.DataSource = dsVehicles.Tables("Vehicles")
        DBConn.Close()
    End Sub
    Private Sub btnFirst_Click(Sender As Object, e As EventArgs) Handles btnFirst.Click
        '------------------------------------------------------------------------------
        '-                      Subprogram Name: btnFirst_Click                       -
        '------------------------------------------------------------------------------
        '-                      Written By: Andrew A. Loesel                          -
        '-                      Written On: April 1, 2022                             -
        '------------------------------------------------------------------------------
        '- Subprogram Purpose:                                                        -
        '-                                                                            -
        '- The purpose of this subprogram is to display information on the first owner-
        '- in the database. We do this by opening all the required database connection-
        '- rescources. We then query against the database to return the TOP 1 owner   -
        '- based on the TUID sorted by Ascending order. This will give us the lowest  -
        '- TUID in the table. We then bind all of the returned columns data to the    -
        '- textboxes.                                                                 -
        '------------------------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):                                 -
        '- sender - identifies which control used the event.                          -
        '- e - Holds the EventArgs object sent to the routine.                        -
        '------------------------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):                                -
        '- DBAdapter - this will work as an in between object to connect our program  -
        '-             to the database.                                               -
        '- DBCommand - This will be used to act as a SQL query object, allows us to   -
        '-             to set certain query statements against the database.          -
        '- DBConn - This acts as a connection object to our database.                 -
        '- dsVehicles - this will be set to the return of the SQL query we perform    -
        '-              against the database.                                         -
        '------------------------------------------------------------------------------

        Dim DBConn As SqlConnection
        Dim DBCommand As New SqlCommand
        Dim dsOwners As New DataSet
        Dim DBAdapter As SqlDataAdapter
        DBConn = New SqlConnection(gstrConnString)

        Try
            DBConn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Could not open DataBase")
            Exit Sub
        End Try

        DBAdapter = New SqlDataAdapter(String.Format("Select TOP 1 * From Owners ORDER BY [TUID] ASC"), gstrConnString)
        DBAdapter.Fill(dsOwners, "Owners")

        'make sure we clear out our databindings since we will get an exception if we try to bind a different source to the same control
        clearDataBindings()


        txtFName.DataBindings.Add(New Binding("Text", dsOwners, "Owners.FirstName"))
        txtLName.DataBindings.Add(New Binding("Text", dsOwners, "Owners.LastName"))
        txtAddress.DataBindings.Add(New Binding("Text", dsOwners, "Owners.StreetAddress"))
        txtCity.DataBindings.Add(New Binding("Text", dsOwners, "Owners.City"))
        txtState.DataBindings.Add(New Binding("Text", dsOwners, "Owners.State"))
        txtZip.DataBindings.Add(New Binding("Text", dsOwners, "Owners.ZipCode"))
        txtID.DataBindings.Add(New Binding("Text", dsOwners, "Owners.TUID"))

        DBConn.Close()

        updateVehicles(CInt(txtID.Text))

    End Sub
    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        '------------------------------------------------------------------------------
        '-                      Subprogram Name: btnLast_Click                        -
        '------------------------------------------------------------------------------
        '-                      Written By: Andrew A. Loesel                          -
        '-                      Written On: April 1, 2022                             -
        '------------------------------------------------------------------------------
        '- Subprogram Purpose:                                                        -
        '-                                                                            -
        '- The purpose of this subroutine is to pull and display information about the-
        '- last user in the Owner table. We first set up all our database interfacing -
        '- objects, and then query against the database to select all information     -
        '- of the TOP 1 Owner by TUID in ascending order, which will give the highest -
        '- TUID in the table. We then bind all of our textboxes to the returned column-
        '- values.                                                                    -
        '------------------------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):                                 -
        '- sender - identifies which control used the event.                          -
        '- e - Holds the EventArgs object sent to the routine.                        -
        '------------------------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):                                -
        '- DBAdapter - this will work as an in between object to connect our program  -
        '-             to the database.                                               -
        '- DBCommand - This will be used to act as a SQL query object, allows us to   -
        '-             to set certain query statements against the database.          -
        '- DBConn - This acts as a connection object to our database.                 -
        '- dsVehicles - this will be set to the return of the SQL query we perform    -
        '-              against the database.                                         -
        '------------------------------------------------------------------------------
        Dim DBConn As SqlConnection
        Dim DBCommand As New SqlCommand
        Dim dsOwners As New DataSet
        Dim DBAdapter As New SqlDataAdapter
        DBConn = New SqlConnection(gstrConnString)

        Try
            DBConn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Could not open DataBase")
            Exit Sub
        End Try

        DBAdapter = New SqlDataAdapter(String.Format("Select TOP 1 * From Owners ORDER BY [TUID] DESC"), gstrConnString)
        DBAdapter.Fill(dsOwners, "Owners")

        'make sure we clear out our databindings since we will get an exception if we try to bind a different source to the same control
        clearDataBindings()


        txtFName.DataBindings.Add(New Binding("Text", dsOwners, "Owners.FirstName"))
        txtLName.DataBindings.Add(New Binding("Text", dsOwners, "Owners.LastName"))
        txtAddress.DataBindings.Add(New Binding("Text", dsOwners, "Owners.StreetAddress"))
        txtCity.DataBindings.Add(New Binding("Text", dsOwners, "Owners.City"))
        txtState.DataBindings.Add(New Binding("Text", dsOwners, "Owners.State"))
        txtZip.DataBindings.Add(New Binding("Text", dsOwners, "Owners.ZipCode"))
        txtID.DataBindings.Add(New Binding("Text", dsOwners, "Owners.TUID"))

        DBConn.Close()

        updateVehicles(CInt(txtID.Text))

    End Sub
    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        '------------------------------------------------------------------------------
        '-                      Subprogram Name: btnPrev_Click                        -
        '------------------------------------------------------------------------------
        '-                      Written By: Andrew A. Loesel                          -
        '-                      Written On: April 1, 2022                             -
        '------------------------------------------------------------------------------
        '- Subprogram Purpose:                                                        -
        '-                                                                            -
        '- The purpose of this subprogram is to display the information from the prior-
        '- entry in the owner table of our database. First we set up all of our       -
        '- database interface objects, we then query against the database to return   -
        '- The Top 1 Owner where the TUID is less than the current ID text value in   -
        '- descending order, which gives us the highest possible TUID lower than the  -
        '- Current. We then display all the information by binding the returned Owner -
        '- column data to our textboxes.                                              -
        '------------------------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):                                 -
        '- sender - identifies which control used the event.                          -
        '- e - Holds the EventArgs object sent to the routine.                        -
        '------------------------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):                                -
        '- DBAdapter - this will work as an in between object to connect our program  -
        '-             to the database.                                               -
        '- DBCommand - This will be used to act as a SQL query object, allows us to   -
        '-             to set certain query statements against the database.          -
        '- DBConn - This acts as a connection object to our database.                 -
        '- dsVehicles - this will be set to the return of the SQL query we perform    -
        '-              against the database.                                         -
        '------------------------------------------------------------------------------
        Dim DBConn As SqlConnection
        Dim DBCommand As New SqlCommand
        Dim dsOwners As New DataSet
        Dim DBAdapter As New SqlDataAdapter
        DBConn = New SqlConnection(gstrConnString)

        Try
            DBConn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Could not open DataBase")
            Exit Sub
        End Try

        DBAdapter = New SqlDataAdapter(String.Format("Select TOP 1 * From Owners Where [TUID] < {0} ORDER BY [TUID] DESC", txtID.Text), gstrConnString)
        DBAdapter.Fill(dsOwners, "Owners")
        'make sure we clear out our databindings since we will get an exception if we try to bind a different source to the same control
        clearDataBindings()


        txtFName.DataBindings.Add(New Binding("Text", dsOwners, "Owners.FirstName"))
        txtLName.DataBindings.Add(New Binding("Text", dsOwners, "Owners.LastName"))
        txtAddress.DataBindings.Add(New Binding("Text", dsOwners, "Owners.StreetAddress"))
        txtCity.DataBindings.Add(New Binding("Text", dsOwners, "Owners.City"))
        txtState.DataBindings.Add(New Binding("Text", dsOwners, "Owners.State"))
        txtZip.DataBindings.Add(New Binding("Text", dsOwners, "Owners.ZipCode"))
        txtID.DataBindings.Add(New Binding("Text", dsOwners, "Owners.TUID"))

        If txtID.Text = "" Then
            'there were no previous records, click the first button
            btnFirst.PerformClick()
        Else
            updateVehicles(CInt(txtID.Text))
        End If

        DBConn.Close()

    End Sub

    Private Sub btnNext_Click(Sender As Object, e As EventArgs) Handles btnNext.Click
        '------------------------------------------------------------------------------
        '-                      Subprogram Name: btnNext_Click                        -
        '------------------------------------------------------------------------------
        '-                      Written By: Andrew A. Loesel                          -
        '-                      Written On: April 1, 2022                             -
        '------------------------------------------------------------------------------
        '- Subprogram Purpose:                                                        -
        '-                                                                            -
        '- The purpose of this subprogram is to display the data from the next highest-
        '- owner in the Owners table. Our procedure is exactly the same as in btnPrev_-
        '- Click, except we query for TUID > current and sort by ascending.           -
        '------------------------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):                                 -
        '- sender - identifies which control used the event.                          -
        '- e - Holds the EventArgs object sent to the routine.                        -
        '------------------------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):                                -
        '- DBAdapter - this will work as an in between object to connect our program  -
        '-             to the database.                                               -
        '- DBCommand - This will be used to act as a SQL query object, allows us to   -
        '-             to set certain query statements against the database.          -
        '- DBConn - This acts as a connection object to our database.                 -
        '- dsVehicles - this will be set to the return of the SQL query we perform    -
        '-              against the database.                                         -
        '------------------------------------------------------------------------------
        Dim DBConn As SqlConnection
        Dim DBCommand As New SqlCommand
        Dim dsOwners As New DataSet
        Dim DBAdapter As New SqlDataAdapter
        DBConn = New SqlConnection(gstrConnString)

        Try
            DBConn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Could not open DataBase")
            Exit Sub
        End Try

        DBAdapter = New SqlDataAdapter(String.Format("Select TOP 1 * From Owners Where [TUID] > {0} ORDER BY [TUID] ASC", txtID.Text), gstrConnString)
        DBAdapter.Fill(dsOwners, "Owners")
        'make sure we clear out our databindings since we will get an exception if we try to bind a different source to the same control
        clearDataBindings()


        txtFName.DataBindings.Add(New Binding("Text", dsOwners, "Owners.FirstName"))
        txtLName.DataBindings.Add(New Binding("Text", dsOwners, "Owners.LastName"))
        txtAddress.DataBindings.Add(New Binding("Text", dsOwners, "Owners.StreetAddress"))
        txtCity.DataBindings.Add(New Binding("Text", dsOwners, "Owners.City"))
        txtState.DataBindings.Add(New Binding("Text", dsOwners, "Owners.State"))
        txtZip.DataBindings.Add(New Binding("Text", dsOwners, "Owners.ZipCode"))
        txtID.DataBindings.Add(New Binding("Text", dsOwners, "Owners.TUID"))

        If txtID.Text = "" Then
            'there were no previous records, click the first button
            btnLast.PerformClick()
        Else
            updateVehicles(CInt(txtID.Text))
        End If

        DBConn.Close()
    End Sub

    Private Sub addNewOwner(sender As Object, e As EventArgs) Handles btnAdd.Click
        '------------------------------------------------------------------------------
        '-                      Subprogram Name: addNewOwner                          -
        '------------------------------------------------------------------------------
        '-                      Written By: Andrew A. Loesel                          -
        '-                      Written On: April 1, 2022                             -
        '------------------------------------------------------------------------------
        '- Subprogram Purpose:                                                        -
        '-                                                                            -
        '- The purpose of this subprogram is to guide the UI for adding a new Owner to-
        '- the Owner table. We will set gstrCRUD to "C" for create. Then we set the   -
        '- global int gintCurrent to the value of txtID before we do anything. We will-
        '= then enable the textboxes so that they are editable and clear out the      -
        '- current text from them. We also unbind dgvVehicles datasource so that it   -
        '- may be rebound when we go back to normal navigation operations, and switch -
        '- which buttons are visible so that Save and Cancel are the only visible ones-
        '------------------------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):                                 -
        '- sender - identifies which control used the event.                          -
        '- e - Holds the EventArgs object sent to the routine.                        -
        '------------------------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):                                -
        '- None                                                                       -
        '------------------------------------------------------------------------------
        gstrCRUD = "C"
        'in case the add operation is cancelled we will want to save the current ID to display upon an add cancel
        gintCurrent = CInt(txtID.Text)
        'enable textboxes
        setTextBoxEnableSetting(True)
        'now we want to display no data in the textBoxes or dataGridView
        'our clearDataBindings method does not actually remove the text from the textBoxes so we will need a different sub for this
        clearTextboxes()
        dgvVehicle.DataSource = Nothing

        setNormalButtons(False)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        '------------------------------------------------------------------------------
        '-                      Subprogram Name: btnCancel_Click                      -
        '------------------------------------------------------------------------------
        '-                      Written By: Andrew A. Loesel                          -
        '-                      Written On: April 1, 2022                             -
        '------------------------------------------------------------------------------
        '- Subprogram Purpose:                                                        -
        '-                                                                            -
        '- The purpose of this subprogram is to return the form to allowing navigation-
        '- and normal data display when the user cancels either an ADD or Update. We  -
        '- first want to set the buttons back to normal, and disable the textboxes.   -
        '- then we make our database interface objects. We will then see if we are    -
        '- canceling an update or an add operation. If update we will have the TUID in-
        '- txtID so we just query the database to get all data corresponding to that  -
        '- if we are coming from an Add we will have the prior TUID in gintCurrent,   -
        '- and we can use that TUID to select from the table. We then set the         -
        '- textboxes to the returned Column values and update our datagridview. Lastly-
        '- we will set gstrCRUD to N so that any other part of the program will know  -
        '- that we are not doing a Update or Add operation.                           -
        '------------------------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):                                 -
        '- sender - identifies which control used the event.                          -
        '- e - Holds the EventArgs object sent to the routine.                        -
        '------------------------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):                                -
        '- DBAdapter - this will work as an in between object to connect our program  -
        '-             to the database.                                               -
        '- DBCommand - This will be used to act as a SQL query object, allows us to   -
        '-             to set certain query statements against the database.          -
        '- DBConn - This acts as a connection object to our database.                 -
        '- dsVehicles - this will be set to the return of the SQL query we perform    -
        '-              against the database.                                         -
        '------------------------------------------------------------------------------
        'we will want to display the owner with TUID = intCurrent, we can work around having to execute some SQL queries 
        'in this block by just navigating through the entries with our nav buttons
        setNormalButtons(True) 'if a button is not visible its click can not be performed
        'disable textboxes
        setTextBoxEnableSetting(False)
        Dim DBConn As SqlConnection
        Dim DBCommand As New SqlCommand
        Dim DBAdapter As New SqlDataAdapter
        Dim dsOwners As New DataSet

        DBConn = New SqlConnection(gstrConnString)
        Try
            DBConn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Could not open DataBase")
            Exit Sub
        End Try
        DBCommand.Connection = DBConn
        If gstrCRUD = "U" Then
            'We are in an updatre, so txtID will still hold the TUID
            DBCommand.CommandText = String.Format("SELECT * FROM Owners WHERE [TUID] = {0}", txtID.Text)
        Else
            'there will be no text in txtID since we are in an Add operation, but when add is clicked we had
            'saved the current TUID in a global int, so we can use that to find where we were and display that data
            DBCommand.CommandText = String.Format("SELECT * FROM Owners WHERE [TUID] = {0}", gintCurrent)
        End If

        DBAdapter = New SqlDataAdapter(DBCommand.CommandText, gstrConnString)
        DBAdapter.Fill(dsOwners, "Owners")
        'make sure we clear out our databindings since we will get an exception if we try to bind a different source to the same control
        clearDataBindings()


        txtFName.DataBindings.Add(New Binding("Text", dsOwners, "Owners.FirstName"))
        txtLName.DataBindings.Add(New Binding("Text", dsOwners, "Owners.LastName"))
        txtAddress.DataBindings.Add(New Binding("Text", dsOwners, "Owners.StreetAddress"))
        txtCity.DataBindings.Add(New Binding("Text", dsOwners, "Owners.City"))
        txtState.DataBindings.Add(New Binding("Text", dsOwners, "Owners.State"))
        txtZip.DataBindings.Add(New Binding("Text", dsOwners, "Owners.ZipCode"))
        txtID.DataBindings.Add(New Binding("Text", dsOwners, "Owners.TUID"))

        If gstrCRUD = "U" Then
            updateVehicles(CInt(txtID.Text))
        Else
            updateVehicles(CInt(gintCurrent))
        End If
        gstrCRUD = "N"

        DBConn.Close()
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        '------------------------------------------------------------------------------
        '-                      Subprogram Name: btnSave_Click                        -
        '------------------------------------------------------------------------------
        '-                      Written By: Andrew A. Loesel                          -
        '-                      Written On: April 1, 2022                             -
        '------------------------------------------------------------------------------
        '- Subprogram Purpose:                                                        -
        '-                                                                            -
        '- The purpose of this subprogram is to save an Update or Add operation to the-
        '- database. We will only need to interface with a Connection and a Command   -
        '- object here since we are not querying the database. We open those up, then -
        '- either set the command to an insert for add or update for update with the  -
        '- values of the textboxes. We then execute the non query on the database,    -
        '- return the buttons and textboxes to their navigation states, and if the    -
        '- operation was an add we click btnLast to take us to the new entry. Then we -
        '- set gstrCRUD to N.                                                         -
        '------------------------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):                                 -
        '- sender - identifies which control used the event.                          -
        '- e - Holds the EventArgs object sent to the routine.                        -
        '------------------------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):                                -
        '- DBCommand - This will be used to act as a SQL query object, allows us to   -
        '-             to set certain query statements against the database.          -
        '- DBConn - This acts as a connection object to our database.                 -
        '------------------------------------------------------------------------------
        Dim DBConn As SqlConnection
        Dim DBCommand As New SqlCommand
        DBConn = New SqlConnection(gstrConnString)

        Try
            DBConn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Could not open DataBase")
            gstrCRUD = "N"
            DBConn.Close()
        End Try

        If gstrCRUD = "C" Then
            'create the sql command to insert
            DBCommand.CommandText = String.Format("INSERT INTO [dbo].[Owners] ([FirstName], [LastName], [StreetAddress], [City], [State], [ZipCode])" &
                                                    "VALUES (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}')",
                                                    txtFName.Text, txtLName.Text, txtAddress.Text, txtCity.Text, txtState.Text, txtZip.Text)
        ElseIf gstrCRUD = "U" Then
            'create the sql command to Update
            DBCommand.CommandText = String.Format("UPDATE [Owners] SET [FirstName] = N'{0}', [LastName] = N'{1}', [StreetAddress] = N'{2}', [City] = N'{3}', " &
                                   "[State] = N'{4}', [ZipCode] = N'{5}' WHERE [TUID] = {6}", txtFName.Text, txtLName.Text, txtAddress.Text, txtCity.Text, txtState.Text, txtZip.Text, txtID.Text)
        End If
        'give the command the connection and execute the query
        DBCommand.Connection = DBConn
        Try
            DBCommand.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Failed to Execute NonQuery")
            gstrCRUD = "N"
            DBConn.Close()
            Exit Sub
        End Try

        DBConn.Close()
        MessageBox.Show(String.Format("Entered {0} to Owners", txtFName.Text & " " & txtLName.Text))
        'set normal buttons and disable textboxes
        setTextBoxEnableSetting(False)
        setNormalButtons(True)
        'click on the last button since we have auto increment for the TUID
        If gstrCRUD = "C" Then
            btnLast.PerformClick()
        End If
        gstrCRUD = "N"
    End Sub
    Private Sub deleteOwner(sender As Object, e As EventArgs) Handles btnDelete.Click
        '------------------------------------------------------------------------------
        '-                      Subprogram Name: deleteOwner                          -
        '------------------------------------------------------------------------------
        '-                      Written By: Andrew A. Loesel                          -
        '-                      Written On: April 1, 2022                             -
        '------------------------------------------------------------------------------
        '- Subprogram Purpose:                                                        -
        '-                                                                            -
        '- The purpose of this subprogram is to delete an owner from the table. We int-
        '- erface with the DB with a connection and command object. Then we set the   -
        '- command to delete from Vehicles where OwnerID = txtIDs text and ask the    -
        '- user if they would like to delete, if no we exit sub. If yes we can delete -
        '- any vehicles owned by the owner first, then we delete the owner, and we    -
        '- will then click btnFirst to display the first Owner in the table.          -
        '------------------------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):                                 -
        '- sender - identifies which control used the event.                          -
        '- e - Holds the EventArgs object sent to the routine.                        -
        '------------------------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):                                -
        '- DBCommand - This will be used to act as a SQL query object, allows us to   -
        '-             to set certain query statements against the database.          -
        '- DBConn - This acts as a connection object to our database.                 -
        '- result - the dialog result from our messagebox.                            -
        '------------------------------------------------------------------------------
        Dim DBConn As SqlConnection
        Dim DBCommand As New SqlCommand
        DBConn = New SqlConnection(gstrConnString)

        Try
            DBConn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Could not open DataBase")
            Exit Sub
        End Try
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delte this entry?", "Are you sure?", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then
            Exit Sub
        End If
        DBCommand.Connection = DBConn
        DBCommand.CommandText = String.Format("DELETE FROM Vehicles WHERE [OwnerID] = {0}", txtID.Text)
        Try
            DBCommand.ExecuteNonQuery()
        Catch Ex As Exception
            MessageBox.Show(Ex.ToString, "Failed to delete vehicles entry")
            Exit Sub
        End Try
        DBCommand.CommandText = String.Format("DELETE FROM Owners WHERE [TUID] = {0}", txtID.Text)

        Try
            DBCommand.ExecuteNonQuery()
        Catch Ex As Exception
            MessageBox.Show(Ex.ToString, "Failed to delete owners entry")
            Exit Sub
        End Try
        btnFirst.PerformClick()



    End Sub

    Private Sub updateOwner(sender As Object, e As EventArgs) Handles btnUpdate.Click
        '------------------------------------------------------------------------------
        '-                      Subprogram Name: updateOwner                          -
        '------------------------------------------------------------------------------
        '-                      Written By: Andrew A. Loesel                          -
        '-                      Written On: April 1, 2022                             -
        '------------------------------------------------------------------------------
        '- Subprogram Purpose:                                                        -
        '-                                                                            -
        '- The purpose of this subprogram is to set the form up for an update to the  -
        '- current owner record. We set the button visibility so that only save and   -
        '- cancel can be shown, and then we enable the textboxes. Lastly, we set      -
        '- gstrCRUD to U so that our save operation knows we are updating.            -
        '------------------------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):                                 -
        '- sender - identifies which control used the event.                          -
        '- e - Holds the EventArgs object sent to the routine.                        -
        '------------------------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):                                -
        '- None                                                                       -
        '------------------------------------------------------------------------------
        'set buttons to only show save and cancel, and allow textBox edit
        setNormalButtons(False)
        setTextBoxEnableSetting(True)
        gstrCRUD = "U"

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '------------------------------------------------------------------------------
        '-                      Subprogram Name: From1_Load                           -
        '------------------------------------------------------------------------------
        '-                      Written By: Andrew A. Loesel                          -
        '-                      Written On: April 1, 2022                             -
        '------------------------------------------------------------------------------
        '- Subprogram Purpose:                                                        -
        '-                                                                            -
        '- The purpose of this subprogram is to control the form when it is loaded. We-
        '- just want to display the first Owner record by clicking btnFirst.          -
        '------------------------------------------------------------------------------
        '- Parameter Dictionary (in parameter order):                                 -
        '- sender - identifies which control used the event.                          -
        '- e - Holds the EventArgs object sent to the routine.                        -
        '------------------------------------------------------------------------------
        '- Local Variable Dictionary (alphabetically):                                -
        '- None                                                                       -
        '------------------------------------------------------------------------------
        'click the first button to load up the first owners data
        btnFirst.PerformClick()
    End Sub


End Class
