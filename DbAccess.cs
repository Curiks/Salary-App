using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SalaryLibrary
{
    public class DbAccess : Salary
    {
        SqlConnection con;
        public static bool connected;
        public static int status;
        public static int curUserId;
        public static string curUserRole;

        public DbAccess()
        {
            con = DbConnection.GetConnection();
            connected = DbConnection.IsAvailable(con);
        }

        //SQL operation on table #region
        //Insert
        public void InsertUser(
            string name,
            string password,
            string nd,
            string na,
            string company,
            string email,
            bool active)
        {
            string commandText =
                "INSERT INTO UserInfo (Name, Password, NetworkDomain, NetworkAlias, Company, Email, Active)" +
                " VALUES (@name, @password, @nd, @na, @company, @email, @active)";

            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(DbConnection.conString))
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(commandText, connection);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@nd", nd);
                cmd.Parameters.AddWithValue("@na", na);
                cmd.Parameters.AddWithValue("@company", company);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@active", active);
                connection.Open();

                status = 0;
                status = cmd.ExecuteNonQuery();
            }
        }

        public void InsertRole(
            Enum value,
            string Description,
            int UserId)
        {
            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }

            SqlCommand cmd = con.CreateCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO UserAccess VALUES('"
                + value + "','"
                + Description + "','"
                + UserId + "')";

            status = 0;
            status = cmd.ExecuteNonQuery();
        }

        public void InsertParms(
            string Name,
            string DataArea,
            string Address,
            string RegNum,
            string TaxRegNum,
            string Phone,
            string Bank,
            int PaymentDay)
        {
            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }

            SqlCommand cmd = con.CreateCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO SysParameters (Name, DataArea, Address, RegNum, TaxRegNum, Phone, Bank, PaymentDay) VALUES('"
                + Name + "','"
                + DataArea + "','"
                + Address + "','"
                + RegNum + "','"
                + TaxRegNum + "','"
                + Phone + "','"
                + Bank + "','"
                + PaymentDay + "')";

            status = 0;
            status = cmd.ExecuteNonQuery();
        }

        public void InsertBankAcc(
            string accountID,
            string accountNum,
            string registrationNum,
            string name,
            string currencyCode)
        {
            string commandText =
                "INSERT INTO BankAccount" +
                " VALUES (@accountID, @accountNum, @registrationNum, @name, @currencyCode)";

            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(DbConnection.conString))
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(commandText, connection);
                cmd.Parameters.AddWithValue("@accountID", accountID);
                cmd.Parameters.AddWithValue("@accountNum", accountNum);
                cmd.Parameters.AddWithValue("@registrationNum", registrationNum);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@currencyCode", currencyCode);
                connection.Open();

                status = 0;
                status = cmd.ExecuteNonQuery();
            }
        }

        public void InsertEmployee(
            string firstName,
            string lastName,
            string persCode,
            string empStatus,
            DateTime startDate,
            DateTime endDate)
        {
            string commandText =
                "INSERT INTO Employee (FirstName, LastName, PersCode, EmpStatus, StartDate, EndDate)" +
                " VALUES (@firstName, @lastName, @persCode, @empSatus, @startDate, @endDate)";

            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(DbConnection.conString))
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(commandText, connection);
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@persCode", persCode);
                cmd.Parameters.AddWithValue("@empSatus", empStatus);
                cmd.Parameters.AddWithValue("@startDate", SqlDbType.Date).Value = startDate;
                cmd.Parameters.AddWithValue("@endDate", SqlDbType.Date).Value = endDate;
                connection.Open();

                status = 0;
                status = cmd.ExecuteNonQuery();
            }
        }

        public void InsertEmplBankAccount(
            string accountId,
            int employeeId,
            string name,
            bool mainAccount,
            string companyAccountId,
            string registrationNum,
            string accountNum)
        {
            string commandText =
                "INSERT INTO EmplBankAccount (AccountID, EmployeeId, Name, MainAccount, CompanyAccountId, RegistrationNum, AccountNum)" +
                " VALUES (@accountId, @employeeId, @name, @mainAccount, @companyAccountId, @registrationNum, @accountNum)";

            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(DbConnection.conString))
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(commandText, connection);
                cmd.Parameters.AddWithValue("@accountId", accountId);
                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@mainAccount", mainAccount);
                cmd.Parameters.AddWithValue("@companyAccountId", companyAccountId);
                cmd.Parameters.AddWithValue("@registrationNum", registrationNum);
                cmd.Parameters.AddWithValue("@accountNum", accountNum);
                connection.Open();

                status = 0;
                status = cmd.ExecuteNonQuery();
            }
        }

        public void InsertPaymTrans(
            string periodId,
            string paymentType,
            DateTime paymentDate,
            string paymentStatus,
            string bankId)
        {
            string commandText =
                "INSERT INTO PaymTrans (PeriodId, PaymentType, PaymentDate, PaymentStatus, CompanyBankAccountId)" +
                " VALUES (@periodId, @paymentType, @paymentDate, @paymentStatus, @companyBankAccountId)";

            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(DbConnection.conString))
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(commandText, connection);
                cmd.Parameters.AddWithValue("@periodId", periodId);
                cmd.Parameters.AddWithValue("@paymentType", paymentType);
                cmd.Parameters.AddWithValue("@paymentDate", SqlDbType.Date).Value = paymentDate;
                cmd.Parameters.AddWithValue("@paymentStatus", paymentStatus);
                cmd.Parameters.AddWithValue("@companyBankAccountId", bankId);
                connection.Open();

                status = 0;
                status = cmd.ExecuteNonQuery();
            }
        }

        public void InsertPaymTransLines(
            string employeeId,
            string firstName,
            string lastName,
            string periodId,
            decimal amount,
            string position,
            int paymentId)
        {
            string commandText =
                "INSERT INTO PaymTransLines (PaymentId, EmployeeId, FirstName, LastName, PeriodId, Amount, PositionName)" +
                " VALUES (@paymentId, @employeeId, @firstName, @lastName, @periodId, @amount, @position)";

            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(DbConnection.conString))
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(commandText, connection);
                cmd.Parameters.AddWithValue("@paymentId", paymentId);
                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@periodId", periodId);
                cmd.Parameters.AddWithValue("@amount", SqlDbType.Decimal).Value = amount;
                cmd.Parameters.AddWithValue("@position", position);
                connection.Open();

                status = 0;
                status = cmd.ExecuteNonQuery();
            }
        }
        //Insert

        //Update
        /*public void UpdateUser(
            string name,
            string password,
            string nd,
            string na,
            string company,
            string email,
            bool active,
            bool isAdmin,
            int primaryKeyValue)
        {
            string commandText =
                "UPDATE UserInfo SET Name = @name," +
                "Password = @password," +
                "NetworkDomain = @nd," +
                "NetworkAlias = @na," +
                "Company = @company," +
                "Email = @email," +
                "Active = @active," +
                "IsAdmin = @isAdmin " +
                "where Id = @primaryKeyValue";

            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(DbConnection.conString))
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(commandText, connection);
                cmd.Parameters.AddWithValue("@primaryKeyValue", primaryKeyValue);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@nd", nd);
                cmd.Parameters.AddWithValue("@na", na);
                cmd.Parameters.AddWithValue("@company", company);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@active", active);
                cmd.Parameters.AddWithValue("@isAdmin", isAdmin);
                connection.Open();

                status = 0;
                status = cmd.ExecuteNonQuery();
            }
        }*/

        public void UpdateParameters(
            string name,
            string dataArea,
            string address,
            string regNum,
            string taxRegNum,
            string phone,
            string bank,
            int paymentDay,
            int primaryKeyValue)
        {
            string commandText =
                "UPDATE SysParameters SET Name = @name," +
                "DataArea = @dataArea," +
                "Address = @address," +
                "RegNum = @regNum," +
                "TaxRegNum = @taxRegNum," +
                "Phone = @phone," +
                "Bank = @bank," +
                "PaymentDay = @paymentDay " +
                "where KeyId = @primaryKeyValue";

            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(DbConnection.conString))
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(commandText, connection);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@dataArea", dataArea);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@regNum", regNum);
                cmd.Parameters.AddWithValue("@taxRegNum", taxRegNum);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@bank", bank);
                cmd.Parameters.AddWithValue("@paymentDay", paymentDay);
                cmd.Parameters.AddWithValue("@primaryKeyValue", primaryKeyValue);
                connection.Open();

                status = 0;
                status = cmd.ExecuteNonQuery();
            }
        }

        public void UpdateBankAccount(
            string accountNum,
            string regNum,
            string name,
            string currency,
            string primaryKeyValue)
        {
            string commandText =
                "UPDATE BankAccount SET AccountNum = @accountNum," +
                "RegistrationNum = @regNum," +
                "Name = @name," +
                "CurrencyCode = @currency " +
                "where AccountID = @primaryKeyValue";

            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(DbConnection.conString))
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(commandText, connection);
                cmd.Parameters.AddWithValue("@accountNum", accountNum);
                cmd.Parameters.AddWithValue("@regNum", regNum);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@currency", currency);
                cmd.Parameters.AddWithValue("@primaryKeyValue", primaryKeyValue);
                connection.Open();

                status = 0;
                status = cmd.ExecuteNonQuery();
            }
        }

        public void UpdateEmployee(
            string firstName,
            string lastName,
            string persCode,
            string empStatus,
            DateTime startDate,
            DateTime endDate,
            int primaryKeyValue)
        {
            string commandText =
                "UPDATE Employee SET FirstName = @firstName," +
                "LastName = @lastName," +
                "PersCode = @persCode," +
                "EmpStatus = @empSatus," +
                "StartDate = @startDate," +
                "EndDate = @endDate " +
                "where EmployeeId = @primaryKeyValue";

            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(DbConnection.conString))
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(commandText, connection);
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@persCode", persCode);
                cmd.Parameters.AddWithValue("@empSatus", empStatus);
                cmd.Parameters.AddWithValue("@startDate", SqlDbType.Date).Value = startDate;
                cmd.Parameters.AddWithValue("@endDate", SqlDbType.Date).Value = endDate;
                cmd.Parameters.AddWithValue("@primaryKeyValue", primaryKeyValue);
                connection.Open();

                status = 0;
                status = cmd.ExecuteNonQuery();
            }
        }

        public void UpdatePaymTrans(
            string periodId,
            string paymentType,
            DateTime paymentDate,
            string paymentStatus,
            string bankId,
            int primaryKeyValue)
        {
            string commandText =
                "UPDATE PaymTrans SET PeriodId = @periodId," +
                "PaymentType = @paymentType," +
                "PaymentDate = @paymentDate," +
                "PaymentStatus = @paymentStatus," +
                "CompanyBankAccountId = @bankId " +
                "where PaymentId = @primaryKeyValue";

            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(DbConnection.conString))
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(commandText, connection);
                cmd.Parameters.AddWithValue("@periodId", periodId);
                cmd.Parameters.AddWithValue("@paymentType", paymentType);
                cmd.Parameters.AddWithValue("@paymentDate", SqlDbType.Date).Value = paymentDate;
                cmd.Parameters.AddWithValue("@paymentStatus", paymentStatus);
                cmd.Parameters.AddWithValue("@bankId", bankId);
                cmd.Parameters.AddWithValue("@primaryKeyValue", primaryKeyValue);
                connection.Open();

                status = 0;
                status = cmd.ExecuteNonQuery();
            }
        }
        //Update

        //Delete
        public void DeleteRecord(string commandText)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(DbConnection.conString))
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(commandText, connection);
                connection.Open();

                status = 0;
                status = cmd.ExecuteNonQuery();
            }
        }
        //Delete

        public DataTable GetEmplList()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("Employee");

            string commandText =
                "SELECT EmployeeId, FirstName, LastName FROM Employee WHERE EmpStatus = '" + "Active" + "'";

            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(DbConnection.conString))
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(commandText, connection);
                System.Data.SqlClient.SqlDataReader dr;
                connection.Open();
                dr = cmd.ExecuteReader();
                ds.Tables.Add(dt);
                ds.Load(dr, LoadOption.PreserveChanges, ds.Tables[0]);
                dr.Close();
            }

            return dt;
        }

        public bool ExistsUser(string name, string password)
        {
            bool ret = false;

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }

            SqlDataAdapter sda = new SqlDataAdapter("SELECT Id, Name FROM UserInfo WHERE Name = '" + name + "' AND Password = '" + password + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                curUserId = dt.Rows[0].Field<int>(0);
                ret = true;
            }

            return ret;
        }

        public DataSet ProcessRecord(string commandText, string tableName)
        {
            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }

            SqlCommand cmd = con.CreateCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = commandText;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            da.Fill(ds, tableName);
            con.Close();

            return ds;
        }

        public DataTable ProcessRecordFilter(string commandText, int filterValue)
        {
            DataTable dt = new DataTable();

            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(DbConnection.conString))
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(commandText, connection);
                System.Data.SqlClient.SqlDataAdapter da = new SqlDataAdapter(cmd);
                connection.Open();
                cmd.Parameters.AddWithValue("@EmployeeId", filterValue);
                da.Fill(dt);
            }

            return dt;
        }
        //SQL operation on table #endregion

        public bool isAdmin(string name, string password)
        {
            int recCount;

            string commandText =
                "SELECT count (*) FROM UserInfo WHERE Name = @name AND " +
                "Password = @password " +
                "AND IsAdmin = @isAdmin";

            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(DbConnection.conString))
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(commandText, connection);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@isAdmin", SqlDbType.Int).Value = 1;
                connection.Open();
                recCount = (int)cmd.ExecuteScalar();
            }

            return recCount > 0;
        }

        public int CountUser()
        {
            int userCount;

            string commandText =
                "SELECT count(*) FROM UserInfo";

            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(DbConnection.conString))
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(commandText, connection);
                connection.Open();
                userCount = (int)cmd.ExecuteScalar();
            }

            return userCount;
        }

        public int CountPaymTransLines(int paymentId)
        {
            int recCount;

            string commandText =
                "SELECT count(*) FROM PaymTransLines WHERE PaymentId = @paymentId";

            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(DbConnection.conString))
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(commandText, connection);
                cmd.Parameters.AddWithValue("@paymentId", paymentId);
                connection.Open();
                recCount = (int)cmd.ExecuteScalar();
            }

            return recCount;
        }

        public string GetUserRole()
        {
            string commandText =
                "SELECT Role FROM UserAccess WHERE UserId = @curUserId";

            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(DbConnection.conString))
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(commandText, connection);
                cmd.Parameters.AddWithValue("@curUserId", curUserId);
                connection.Open();
                curUserRole = (string)cmd.ExecuteScalar();
            }

            return curUserRole;
        }
    }
}
