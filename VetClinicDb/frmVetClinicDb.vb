'------------------------------------------------------------
'-               File Name: frmVetClinicDb.vb               -
'-                 Part of Project: Assign8                 -
'------------------------------------------------------------
'-                Written By: Elijah Wilson                 -
'-                  Written On: 03/28/2016                  -
'------------------------------------------------------------
'- File Purpose:                                            -
'-                                                          -
'- Main form file for the program. Contains the             -
'- frmVetClinicDb form class.                               -
'------------------------------------------------------------
'- Program Purpose:                                         -
'-                                                          -
'- To create, read, update and delete vet clinic records    -
'- from a database.                                         -
'------------------------------------------------------------
'- Global Variable Dictionary (alphabetically):             -
'- (None)                                                   -
'------------------------------------------------------------
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

    Private updatingId As String

    '------------------------------------------------------------
    '-           Subprogram Name: frmVetClinicDb_Load           -
    '------------------------------------------------------------
    '-                Written By: Elijah Wilson                 -
    '-                  Written On: 03/28/2016                  -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- Handles the form load event. Populates the database if   -
    '- necessary and binds the appropriate textboxes.           -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender - The object that raised the event                -
    '- e - The EventArgs sent with the event                    -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
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

    '------------------------------------------------------------
    '-             Subprogram Name: createDatabase              -
    '------------------------------------------------------------
    '-                Written By: Elijah Wilson                 -
    '-                  Written On: 03/28/2016                  -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- Creates a new database with Owners and Pets tables.      -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- (None)                                                   -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- DBCat - A Catalog object used to create the database     -
    '- DBCmd - The database command to be run                   -
    '- DBConn - The database connection                         -
    '------------------------------------------------------------
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

    '------------------------------------------------------------
    '-              Subprogram Name: InsertIntoDb               -
    '------------------------------------------------------------
    '-                Written By: Elijah Wilson                 -
    '-                  Written On: 03/28/2016                  -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- Run an insert command with the supplied string.          -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- insertStr - The SQL insert command to be run             -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- DbCmd - The database command to be run                   -
    '- DbConn - The database connection                         -
    '------------------------------------------------------------
    Private Sub InsertIntoDb(insertStr As String)
        Dim DbConn As New OleDbConnection(DB_CONN_STR)
        Dim DbCmd As New OleDbCommand

        DbConn.Open()

        DbCmd.CommandText = insertStr
        DbCmd.Connection = DbConn
        DbCmd.ExecuteNonQuery()

        DbConn.Close()
    End Sub

    '------------------------------------------------------------
    '-           Subprogram Name: populateOwnersTable           -
    '------------------------------------------------------------
    '-                Written By: Elijah Wilson                 -
    '-                  Written On: 03/28/2016                  -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- Populates the Owners table in the database.              -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- (None)                                                   -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub populateOwnersTable()
        insertOwner(1, "John Smith", "123 Elm", "Saginaw", "MI", "48604", "(989) 555-5555")
        insertOwner(2, "Sue Jones", "456 Oak", "Flint", "MI", "48502", "(810) 777-7777")
        insertOwner(3, "Phil Williams", "789 Pine", "Birch Run", "MI", "48415", "(989) 111-1111")
        insertOwner(4, "Ann Taylor", "654 Aspen", "Burt", "MI", "48417", "(989) 222-2222")
    End Sub

    '------------------------------------------------------------
    '-               Subprogram Name: insertOwner               -
    '------------------------------------------------------------
    '-                Written By: Elijah Wilson                 -
    '-                  Written On: 03/28/2016                  -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- Inserts an owner based on the parameters into the        -
    '- database                                                 -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- id - The id to be inserted                               -
    '- name - The name to be inserted                           -
    '- address - The name to be inserted                        -
    '- city - The city to be inserted                           -
    '- state - The state to be inserted                         -
    '- zipcode - The zipcode to be inserted                     -
    '- phoneNumber - The phone number to be inserted            -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub insertOwner(id As Integer, name As String, address As String, city As String,
                            state As String, zipcode As String, phoneNumber As String)
        InsertIntoDb(getOwnerInsert(id, name, address, city, state, zipcode, phoneNumber))
    End Sub

    '------------------------------------------------------------
    '-              Function Name: getOwnerInsert               -
    '------------------------------------------------------------
    '-                Written By: Elijah Wilson                 -
    '-                  Written On: 03/28/2016                  -
    '------------------------------------------------------------
    '- Function Purpose:                                        -
    '-                                                          -
    '- Generates an insert statement for the Owners table       -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- id - The id to be inserted                               -
    '- name - The name to be inserted                           -
    '- address - The address to be inserted                     -
    '- city - The city to be inserted                           -
    '- state - The state to be inserted                         -
    '- zipcode - The zipcode to be inserted                     -
    '- phoneNumber - The phone number to be inserted            -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    '- Returns:                                                 -
    '- String - The insert SQL statement for inserting an Owner -
    '------------------------------------------------------------
    Private Function getOwnerInsert(id As Integer, name As String, address As String, city As String,
                                    state As String, zipcode As String, phoneNumber As String) As String
        Return String.Format("INSERT INTO Owners (ID, OwnerName, OwnerAddress, OwnerCity, OwnerState, OwnerZipCode, OwnerPhoneNumber)" &
                             " VALUES ({0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", id, name, address, city, state, zipcode, phoneNumber)
    End Function

    '------------------------------------------------------------
    '-            Subprogram Name: populatePetsTable            -
    '------------------------------------------------------------
    '-                Written By: Elijah Wilson                 -
    '-                  Written On: 03/28/2016                  -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- Populates the Pets table with default data.              -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- (None)                                                   -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
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

    '------------------------------------------------------------
    '-                Subprogram Name: insertPet                -
    '------------------------------------------------------------
    '-                Written By: Elijah Wilson                 -
    '-                  Written On: 03/28/2016                  -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- Inserts a Pet into the database                          -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- id - The id to be inserted                               -
    '- name - The name to be inserted                           -
    '- species - The species to be inserted                     -
    '- birthdate - The birthdate to be inserted                 -
    '- lastVisit - The lastVisit to be inserted                 -
    '- ownerId - The ownerId to be inserted                     -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub insertPet(id As Integer, name As String, species As String,
                          birthdate As String, lastVisit As String, ownerId As Integer)
        InsertIntoDb(getPetInsert(id, name, species, birthdate, lastVisit, ownerId))
    End Sub

    '------------------------------------------------------------
    '-               Function Name: getPetInsert                -
    '------------------------------------------------------------
    '-                Written By: Elijah Wilson                 -
    '-                  Written On: 03/28/2016                  -
    '------------------------------------------------------------
    '- Function Purpose:                                        -
    '-                                                          -
    '- Generates an insert statement for a Pet                  -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- id - The id to be inserted                               -
    '- name - The name to be inserted                           -
    '- species - The species to be inserted                     -
    '- birthdate - The birthdate to be inserted                 -
    '- lastVisit - The lastVisit to be inserted                 -
    '- ownerId - The ownerId to be inserted                     -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    '- Returns:                                                 -
    '- String - The insert SQL statement for a Pet              -
    '------------------------------------------------------------
    Private Function getPetInsert(id As Integer, name As String, species As String,
                                  birthdate As String, lastVisit As String, ownerId As Integer) As String
        Return String.Format("INSERT INTO Pets (ID, PetName, PetSpecies, PetBirthdate, PetLastVisitDate, OwnerID)" &
                             " VALUES ({0}, '{1}', '{2}', '{3}', '{4}', {5})", id, name, species, birthdate, lastVisit, ownerId)
    End Function

    '------------------------------------------------------------
    '-             Subprogram Name: btnFirst_Click              -
    '------------------------------------------------------------
    '-                Written By: Elijah Wilson                 -
    '-                  Written On: 03/28/2016                  -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- Moves to the first owner record in the database          -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender - The object that raised the event                -
    '- e - The EventArgs sent with the event                    -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        BindingContext(dsOwners, "Owners").Position = 0
    End Sub

    '------------------------------------------------------------
    '-            Subprogram Name: btnPrevious_Click            -
    '------------------------------------------------------------
    '-                Written By: Elijah Wilson                 -
    '-                  Written On: 03/28/2016                  -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- Moves to the previous owner record in the database       -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender - The object that raised the event                -
    '- e - The EventArgs sent with the event                    -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        BindingContext(dsOwners, "Owners").Position = (BindingContext(dsOwners, "Owners").Position - 1)
    End Sub

    '------------------------------------------------------------
    '-             Subprogram Name: btnNext_Click               -
    '------------------------------------------------------------
    '-                Written By: Elijah Wilson                 -
    '-                  Written On: 03/28/2016                  -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- Moves to the next owner record in the database           -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender - The object that raised the event                -
    '- e - The EventArgs sent with the event                    -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        BindingContext(dsOwners, "Owners").Position = (BindingContext(dsOwners, "Owners").Position + 1)
    End Sub

    '------------------------------------------------------------
    '-              Subprogram Name: btnLast_Click              -
    '------------------------------------------------------------
    '-                Written By: Elijah Wilson                 -
    '-                  Written On: 03/28/2016                  -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- Moves to the last owner record in the database           -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender - The object that raised the event                -
    '- e - The EventArgs sent with the event                    -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        BindingContext(dsOwners, "Owners").Position = (dsOwners.Tables("Owners").Rows.Count - 1)
    End Sub

    '------------------------------------------------------------
    '-         Subprogram Name: txtIdNumber_TextChanged         -
    '------------------------------------------------------------
    '-                Written By: Elijah Wilson                 -
    '-                  Written On: 03/28/2016                  -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- Handles when the txtIdNumber textbox's text changes.     -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender - The object that raised the event                -
    '- e - The EventArgs sent with the event                    -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- query - The query to run in the database                 -
    '- reader - An OleDbDataReader object for the retrieved     -
    '-          data                                            -
    '------------------------------------------------------------
    Private Sub txtIdNumber_TextChanged(sender As Object, e As EventArgs) Handles txtIdNumber.TextChanged
        If Not String.IsNullOrEmpty(txtIdNumber.Text) And Not txtIdNumber.Enabled Then
            DbAdaptPets = New OleDbDataAdapter("SELECT * FROM Pets WHERE OwnerID = " & Trim(txtIdNumber.Text), DB_CONN_STR)
            dsPets.Clear()
            DbAdaptPets.Fill(dsPets, "Pets")

            dgPets.DataSource = dsPets
            dgPets.DataMember = "Pets"

            btnDelete.Enabled = True
            btnUpdate.Enabled = True
        ElseIf String.IsNullOrEmpty(txtIdNumber.Text) Then
            btnDelete.Enabled = False
            btnUpdate.Enabled = False
        ElseIf txtIdNumber.Enabled And Not String.IsNullOrEmpty(txtIdNumber.Text) Then
            Using conn As New OleDbConnection(DB_CONN_STR)
                conn.Open()

                Dim query As New OleDbCommand()
                Dim reader As OleDbDataReader

                query.CommandText = "SELECT * FROM Owners WHERE ID = " & txtIdNumber.Text
                query.Connection = conn
                reader = query.ExecuteReader()

                If reader.HasRows And Not txtIdNumber.Text = updatingId Then
                    errIdNumber.SetError(txtIdNumber, "ID already taken, please choose a different one.")
                Else
                    errIdNumber.SetError(txtIdNumber, Nothing)
                    btnDelete.Enabled = True
                    btnUpdate.Enabled = True
                End If
            End Using
        End If
    End Sub

    '------------------------------------------------------------
    '-          Subprogram Name: dgPets_CellBeginEdit           -
    '------------------------------------------------------------
    '-                Written By: Elijah Wilson                 -
    '-                  Written On: 03/28/2016                  -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- Handles when the datagridview has a cell that starts     -
    '- being edited. It enables the update pet info button if   -
    '- the current owner record is valid.                       -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender - The object that raised the event                -
    '- e - The DataGridViewCellCancelEventArgs sent with the    -
    '-     event                                                -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub dgPets_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgPets.CellBeginEdit
        If String.IsNullOrEmpty(txtIdNumber.Text) Then
            e.Cancel = True
        Else
            btnUpdatePetInfo.Visible = True
        End If
    End Sub

    '------------------------------------------------------------
    '-         Subprogram Name: btnUpdatePetInfo_Click          -
    '------------------------------------------------------------
    '-                Written By: Elijah Wilson                 -
    '-                  Written On: 03/28/2016                  -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- Saves all the pet information in the datagridview        -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender - The object that raised the event                -
    '- e - The EventArgs that were sent with the event          -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- cmdBuilder - A command builder object for inserting a    -
    '-              record in the database                      -
    '------------------------------------------------------------
    Private Sub btnUpdatePetInfo_Click(sender As Object, e As EventArgs) Handles btnUpdatePetInfo.Click
        Dim cmdBuilder As New OleDbCommandBuilder(DbAdaptPets)

        btnUpdatePetInfo.Visible = False

        Using conn As New OleDbConnection(DB_CONN_STR)
            conn.Open()
            DbAdaptPets.InsertCommand = cmdBuilder.GetInsertCommand
            DbAdaptPets.Update(dsPets, "Pets")
        End Using
    End Sub

    '------------------------------------------------------------
    '-              Subprogram Name: btnAdd_Click               -
    '------------------------------------------------------------
    '-                Written By: Elijah Wilson                 -
    '-                  Written On: 03/28/2016                  -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- Allows a user to create a new owner                      -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender - The object that raised the event                -
    '- e - The EventArgs sent with the event                    -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        toggleEditState(True)

        BindingContext(dsOwners, "Owners").EndCurrentEdit()
        BindingContext(dsOwners, "Owners").AddNew()

        dsPets.Clear()

        updatingId = Nothing
    End Sub

    '------------------------------------------------------------
    '-              Subprogram Name: btnSave_Click              -
    '------------------------------------------------------------
    '-                Written By: Elijah Wilson                 -
    '-                  Written On: 03/28/2016                  -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- Allows a user to create a new owner                      -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender - The object that raised the event                -
    '- e - The EventArgs that were sent to the event            -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- cmdBuilder - A command builder for creating the insert   -
    '-              command                                     -
    '------------------------------------------------------------
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim cmdBuilder As New OleDbCommandBuilder(DbAdaptOwners)

        toggleEditState(False)

        BindingContext(dsOwners, "Owners").EndCurrentEdit()

        Using conn As New OleDbConnection(DB_CONN_STR)
            conn.Open()
            DbAdaptOwners.InsertCommand = cmdBuilder.GetInsertCommand
            DbAdaptOwners.Update(dsOwners, "Owners")
        End Using

        dsOwners.AcceptChanges()

        updatingId = Nothing
        btnDelete.Enabled = True
        btnUpdate.Enabled = True
    End Sub

    '------------------------------------------------------------
    '-             Subprogram Name: toggleEditState             -
    '------------------------------------------------------------
    '-                Written By: Elijah Wilson                 -
    '-                  Written On: 03/28/2016                  -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- Changes the Enabled state of a lot of the textboxes and  -
    '- buttons on the form based on whether or not the form is  -
    '- in edit mode.                                            -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- canEdit - Whether or not certain fields should be        -
    '-           enabled based on whether the user is editing   -
    '-           an owner                                       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- textFields - An array of all the text boxes that their   -
    '-              enabled state should be toggled             -
    '------------------------------------------------------------
    Private Sub toggleEditState(canEdit As Boolean)
        Dim textFields As TextBox() = {txtName, txtAddressStreet, txtAddressCity, txtAddressState, txtAddressZipcode, txtPhone, txtIdNumber}

        For Each txtBox As TextBox In textFields
            txtBox.Enabled = canEdit
        Next

        btnAdd.Visible = Not canEdit
        btnDelete.Visible = Not canEdit
        btnUpdate.Visible = Not canEdit

        btnSave.Visible = canEdit
        btnCancel.Visible = canEdit

        toggleMoving(Not canEdit)
    End Sub

    '------------------------------------------------------------
    '-             Subprogram Name: btnCancel_Click             -
    '------------------------------------------------------------
    '-                Written By: Elijah Wilson                 -
    '-                  Written On: 03/28/2016                  -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- Cancels any current edits or creations                   -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender - The object that raised the Event                -
    '- e - The EventArgs sent with the event                    -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        updatingId = Nothing
        toggleEditState(False)
        BindingContext(dsOwners, "Owners").CancelCurrentEdit()
    End Sub

    '------------------------------------------------------------
    '-             Subprogram Name: btnDelete_Click             -
    '------------------------------------------------------------
    '-                Written By: Elijah Wilson                 -
    '-                  Written On: 03/28/2016                  -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- Deletes an Owner and their pets from the database        -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender - The object that raised the event                -
    '- e - The EventArgs sent with the event                    -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- dbCmd - The command to be run in the database            -
    '- ownerId - The id of the current owner                    -
    '------------------------------------------------------------
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not String.IsNullOrEmpty(txtIdNumber.Text) Then
            Dim dbCmd As OleDbCommand
            Dim ownerId As String = Trim(txtIdNumber.Text)

            BindingContext(dsOwners, "Owners").Position = (BindingContext(dsOwners, "Owners").Position + 1)

            Using conn As New OleDbConnection(DB_CONN_STR)
                conn.Open()

                dbCmd = New OleDbCommand("DELETE * FROM Pets WHERE OwnerID = " & ownerId, conn)
                dbCmd.ExecuteNonQuery()

                dsPets.Clear()

                dbCmd = New OleDbCommand("DELETE * FROM Owners WHERE ID = " & ownerId, conn)
                dbCmd.ExecuteNonQuery()
            End Using

            dsOwners.Clear()
            DbAdaptOwners = New OleDbDataAdapter("Select * From Owners", DB_CONN_STR)
            DbAdaptOwners.Fill(dsOwners, "Owners")
        End If
    End Sub

    '------------------------------------------------------------
    '-             Subprogram Name: btnUpdate_Click             -
    '------------------------------------------------------------
    '-                Written By: Elijah Wilson                 -
    '-                  Written On: 03/28/2016                  -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- Allows a user to update the current Owner.               -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender - The object that raised the event                -
    '- e - The EventArgs sent with the event                    -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        updatingId = txtIdNumber.Text
        toggleEditState(True)
    End Sub

    '------------------------------------------------------------
    '-              Subprogram Name: toggleMoving               -
    '------------------------------------------------------------
    '-                Written By: Elijah Wilson                 -
    '-                  Written On: 03/28/2016                  -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- Toggles the Enabled of the movement buttons              -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- canMove - Whether or not the user can move between       -
    '-           records                                        -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub toggleMoving(canMove As Boolean)
        btnFirst.Enabled = canMove
        btnPrevious.Enabled = canMove

        btnNext.Enabled = canMove
        btnLast.Enabled = canMove
    End Sub
End Class
