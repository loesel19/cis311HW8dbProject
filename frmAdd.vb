﻿Imports System.Data.SqlClient
Public Class frmAdd
    '--------------------------------------------------------------------------------
    '-                      File Name: frmAdd                                       -
    '-                      Part of Project: Vehicle/ Owner Database (cis311 HW8)   -
    '--------------------------------------------------------------------------------
    '-                      Written By: Andrew A. Loesel                            -
    '-                      Written On: April 1, 2022                               -
    '--------------------------------------------------------------------------------
    '- File Purpose:                                                                -
    '-                                                                              -
    '- This File is not used in the current build of the program. This form was crea-
    '- ted when I had thought that we needed a form to display when the user clicked-
    '- the add or update buttons on the main form. This code will work for that purp-
    '- ose given that it is properly implemented in Form1. However, the problem     -
    '- description led me to believe that it should all be done on one form.        -
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
    '- None                                                                         -
    '--------------------------------------------------------------------------------
    Public Const gstrDBName As String = "C:\Users\jzpbqq\source\repos\cis311HW8dbProject\MSSQLLocalDB\HW8.mdf"

    Public Const gstrConnString As String = "Server=(localdb)\MSSQLLocalDB;" &
             "Database=hw8;Integrated Security=SSPI;AttachDbFileName=" &
             gstrDBName
    Private Sub frmAdd_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.Closing
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to cancel adding this Owner?", "Really Cancel?", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            'do Nothing
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim DBConn As SqlConnection
        Dim DBCommand As New SqlCommand
        DBConn = New SqlConnection(gstrConnString)

        Try
            DBConn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Could not open DataBase")
        End Try

        'create the sql command to insert
        DBCommand.CommandText = String.Format("INSERT INTO [dbo].[Owners] ([FirstName], [LastName], [StreetAddress], [City], [State], [ZipCode])" &
                                                    "VALUES (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}')",
                                                    txtFName.Text, txtLName.Text, txtAddress.Text, txtCity.Text, txtState.Text, txtZip.Text)
        'give the command the connection and execute the query
        DBCommand.Connection = DBConn
        Try
            DBCommand.ExecuteNonQuery()
            'getting here means we succesfully added the new owner, we want them to be displayed on the main form when we close this one
            'we can just pass the tuid of the new entry to the main form
            'Form1.gintAddedOwner = 1
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Failed to Execute NonQuery")
        End Try

        DBConn.Close()
        MessageBox.Show(String.Format("Entered {0} to Owners", txtFName.Text & " " & txtLName.Text))
        Me.Close()
    End Sub
End Class