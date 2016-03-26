Imports System.IO
Imports System.Data.OleDb
Imports ADOX

Public Class frmVetClinicDb
    Private Const DATABASE_NAME As String = "vet_clinic.mdb"
    Private Const DB_CONN_STR As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & DATABASE_NAME

    Private dsOwners As New DataSet()
    Private dsPets As New DataSet()

    Private DbAdaptOwners As OleDbDataAdapter
    Private DbAdaptPets As OleDbDataAdapter

    Private Sub frmVetClinicDb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Delete database if it exists
        If File.Exists(DATABASE_NAME) Then
            File.Delete(DATABASE_NAME)
        End If

        ' create database
        createDatabase()

        ' populate database
        populateOwnersTable()
        populatePetsTable()

        ' set bindings
        DbAdaptOwners = New OleDbDataAdapter("Select * From Owners", DB_CONN_STR)
        DbAdaptOwners.Fill(dsOwners, "Owners")

        txtIdNumber.DataBindings.Add(New Binding("Text", dsOwners, "Owners.ID"))
        txtName.DataBindings.Add(New Binding("Text", dsOwners, "Owners.OwnerName"))
        txtAddressStreet.DataBindings.Add(New Binding("Text", dsOwners, "Owners.OwnerAddress"))
        txtAddressCity.DataBindings.Add(New Binding("Text", dsOwners, "Owners.OwnerCity"))
        txtAddressState.DataBindings.Add(New Binding("Text", dsOwners, "Owners.OwnerState"))
        txtAddressZipcode.DataBindings.Add(New Binding("Text", dsOwners, "Owners.OwnerZipCode"))
        txtPhone.DataBindings.Add(New Binding("Text", dsOwners, "Owners.OwnerPhoneNumber"))
    End Sub

    Private Sub createDatabase()
        Dim DBCat As New Catalog()
        Dim DBConn As OleDbConnection
        Dim DBCmd As New OleDbCommand()

        Try
            DBCat.Create(DB_CONN_STR)
        Catch ex As Exception
            Debug.WriteLine("Database already exists")
        End Try

        ' Build tables
        DBConn = New OleDbConnection(DB_CONN_STR)
        DBConn.Open()

        ' build owners table
        DBCmd.CommandText = "CREATE TABLE Owners (" &
                            "ID integer CONSTRAINT Owners_PK PRIMARY KEY, " &
                            "OwnerName varchar(50), " &
                            "OwnerAddress varchar(100), " &
                            "OwnerCity varchar(75), " &
                            "OwnerState varchar(2), " &
                            "OwnerZipCode varchar(10), " &
                            "OwnerPhoneNumber varchar(20))"

        DBCmd.Connection = DBConn
        Try
            DBCmd.ExecuteNonQuery()
        Catch ex As Exception
            Debug.WriteLine("Owners table already exists")
        End Try

        ' build Pets table
        DBCmd.CommandText = "CREATE TABLE Pets (" &
                            "ID integer CONSTRAINT Pets_PK PRIMARY KEY, " &
                            "PetName varchar(50), " &
                            "PetSpecies varchar(50), " &
                            "PetBirthdate varchar(20), " &
                            "PetLastVisitDate varchar(20), " &
                            "OwnerID integer)"
        DBCmd.Connection = DBConn

        Try
            DBCmd.ExecuteNonQuery()
        Catch ex As Exception
            Debug.WriteLine("Pets table already exists")
        End Try

        DBConn.Close()
    End Sub

    Private Sub InsertIntoDb(insertStr As String)
        Dim DbConn As New OleDbConnection(DB_CONN_STR)
        Dim DbCmd As New OleDbCommand

        DbConn.Open()

        DbCmd.CommandText = insertStr
        DbCmd.Connection = DbConn
        DbCmd.ExecuteNonQuery()

        DbConn.Close()
    End Sub

    Private Sub populateOwnersTable()
        insertOwner(1, "John Smith", "123 Elm", "Saginaw", "MI", "48604", "(989) 555-5555")
        insertOwner(2, "Sue Jones", "456 Oak", "Flint", "MI", "48502", "(810) 777-7777")
        insertOwner(3, "Phil Williams", "789 Pine", "Birch Run", "MI", "48415", "(989) 111-1111")
        insertOwner(4, "Ann Taylor", "654 Aspen", "Burt", "MI", "48417", "(989) 222-2222")
    End Sub

    Private Sub insertOwner(id As Integer, name As String, address As String, city As String,
                            state As String, zipcode As String, phoneNumber As String)
        InsertIntoDb(getOwnerInsert(id, name, address, city, state, zipcode, phoneNumber))
    End Sub

    Private Function getOwnerInsert(id As Integer, name As String, address As String, city As String,
                                    state As String, zipcode As String, phoneNumber As String) As String
        Return String.Format("INSERT INTO Owners (ID, OwnerName, OwnerAddress, OwnerCity, OwnerState, OwnerZipCode, OwnerPhoneNumber)" &
                             " VALUES ({0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", id, name, address, city, state, zipcode, phoneNumber)
    End Function

    Private Sub populatePetsTable()
        insertPet(1, "Zippy", "Turtle", "10/15/2015", "11/13/2015", 1)
        insertPet(2, "Tabby", "Calico Cat", "9/15/2014", "6/4/2015", 1)
        insertPet(3, "Fido", "Schnauzer", "4/4/2014", "8/7/2015", 2)
        insertPet(4, "Buddy", "Guinea Pig", "7/11/2015", "9/9/2015", 2)
        insertPet(5, "Sally", "Gold Fish", "10/12/2015", "10/15/2015", 3)
        insertPet(6, "Wilbur", "Pig", "1/4/2015", "6/30/2015", 4)
        insertPet(7, "Sam", "Flamingo", "11/15/2015", "11/30/2015", 4)
        insertPet(8, "Floyd", "Toad", "4/4/2015", "6/23/2015", 4)
        insertPet(9, "Davey", "Velociraptor", "2/24/2014", "5/6/2015", 4)
    End Sub

    Private Sub insertPet(id As Integer, name As String, species As String,
                          birthdate As String, lastVisit As String, ownerId As Integer)
        InsertIntoDb(getPetInsert(id, name, species, birthdate, lastVisit, ownerId))
    End Sub

    Private Function getPetInsert(id As Integer, name As String, species As String,
                                  birthdate As String, lastVisit As String, ownerId As Integer) As String
        Return String.Format("INSERT INTO Pets (ID, PetName, PetSpecies, PetBirthdate, PetLastVisitDate, OwnerID)" &
                             " VALUES ({0}, '{1}', '{2}', '{3}', '{4}', {5})", id, name, species, birthdate, lastVisit, ownerId)
    End Function

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        BindingContext(dsOwners, "Owners").Position = 0
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        BindingContext(dsOwners, "Owners").Position = (BindingContext(dsOwners, "Owners").Position - 1)
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        BindingContext(dsOwners, "Owners").Position = (BindingContext(dsOwners, "Owners").Position + 1)
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        BindingContext(dsOwners, "Owners").Position = (dsOwners.Tables("Owners").Rows.Count - 1)
    End Sub

    Private Sub txtIdNumber_TextChanged(sender As Object, e As EventArgs) Handles txtIdNumber.TextChanged
        If Not txtIdNumber.Enabled Then
            DbAdaptPets = New OleDbDataAdapter("SELECT * FROM Pets WHERE OwnerID = " & Trim(txtIdNumber.Text), DB_CONN_STR)
            dsPets.Clear()
            DbAdaptPets.Fill(dsPets, "Pets")

            dgPets.DataSource = dsPets
            dgPets.DataMember = "Pets"
        End If
    End Sub

    Private Sub dgPets_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgPets.CellBeginEdit
        btnUpdatePetInfo.Visible = True
    End Sub

    Private Sub btnUpdatePetInfo_Click(sender As Object, e As EventArgs) Handles btnUpdatePetInfo.Click
        Dim cmdBuilder As New OleDbCommandBuilder(DbAdaptPets)

        btnUpdatePetInfo.Visible = False

        Using conn As New OleDbConnection(DB_CONN_STR)
            conn.Open()
            DbAdaptPets.InsertCommand = cmdBuilder.GetInsertCommand
            DbAdaptPets.Update(dsPets, "Pets")
        End Using
    End Sub
End Class
