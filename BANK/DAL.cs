using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using System.Globalization;
using System.IO;
using System.Configuration;
using System.Windows.Forms;

namespace BANK
{
    class DAL
    {
        //строка соединения с БД...
        //string connectionString = @"Data Source=DELL;Initial Catalog=BANK;Integrated Security=True;";
        public string connectionString = ConfigurationManager.ConnectionStrings["BANKConnectionString"].ConnectionString;

        public ArrayList GetAllDebitors()
        {
            ArrayList allDebitors = new ArrayList();
            using (SqlConnection con = new SqlConnection(connectionString))
            { 
                SqlCommand com = new SqlCommand("SELECT * FROM Debitors ORDER BY Name", con); //создали объект команды
                try
                {
                    con.Open(); //открыли соединение с бд
                    SqlDataReader dr = com.ExecuteReader();

                    if (dr.HasRows)
                        foreach (DbDataRecord result in dr)
                            allDebitors.Add(result);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return allDebitors;
        }

        internal ArrayList SearchDebitors(string name, string postNumber, string phoneNumber)
        {
            ArrayList SearchDebitors = new ArrayList();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand com = new SqlCommand("SearchDebitor", con); //вместо текста команды-запроса передали процедуру dbo.SearchDebitor
                com.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@name";
                param.Value = name;
                param.SqlDbType = SqlDbType.NVarChar;
                param.Direction = ParameterDirection.Input;
                com.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@postNumber";
                param.Value = postNumber;
                param.SqlDbType = SqlDbType.NVarChar;
                param.Direction = ParameterDirection.Input;
                com.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@phoneNumber";
                param.Value = phoneNumber;
                param.SqlDbType = SqlDbType.NVarChar;
                param.Direction = ParameterDirection.Input;
                com.Parameters.Add(param);

                try
                {
                    con.Open();
                    SqlDataReader dr = com.ExecuteReader();

                    if (dr.HasRows)
                        foreach (DbDataRecord result in dr)
                            SearchDebitors.Add(result);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return SearchDebitors;
        }

        internal ArrayList GetAllCreditsForDebitor(string debitorID)
        {
            ArrayList allCredits = new ArrayList();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //string query = String.Format("select * from Credits where DebitorID = '{0}' order by OpenDate", debitorID);

                SqlCommand com = new SqlCommand("GetCreditsForDebitor", con); //вместо текста команды-запроса передали процедуру dbo.GetCreditsForDebitor
                com.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@debitorID";
                param.Value = new Guid(debitorID);
                param.SqlDbType = SqlDbType.UniqueIdentifier;
                param.Direction = ParameterDirection.Input;
                com.Parameters.Add(param);

                try
                {
                    con.Open();
                    SqlDataReader dr = com.ExecuteReader();

                    if (dr.HasRows)
                        foreach (DbDataRecord result in dr)
                            allCredits.Add(result);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return allCredits;
        }

        internal ArrayList GetAllPaymentsForCredit(string creditID)
        {
            ArrayList allPayments = new ArrayList();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = String.Format("select * from Payments where CreditsID = '{0}' order by PaymentDate", creditID);
                SqlCommand com = new SqlCommand(query, con);

                try
                {
                    con.Open();
                    SqlDataReader dr = com.ExecuteReader();

                    if (dr.HasRows)
                        foreach (DbDataRecord result in dr)
                            allPayments.Add(result);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return allPayments;
        }

        public bool SaveNewDebitor(string ID, string Name, string PostNumber, string PhoneNumber)
        {
            bool flagResult = false;

            string query = string.Format("insert into Debitors " + 
                "([ID], [Name], [PostNumber], [PhoneNumber]) " + 
                "values ('{0}', '{1}', '{2}', '{3}')", 
                ID, Name, PostNumber, (PhoneNumber != String.Empty) ? PhoneNumber : null);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand com = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    if (com.ExecuteNonQuery() == 1)
                        flagResult = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return flagResult;     
        }

        public bool SaveNewCredit(Guid ID, Guid debitorID, int amount, int balance, DateTime openDate)
        { 
            string query = String.Format("insert into Credits (ID, DebitorID, Amount, Balance, OpenDate) " + 
                "VALUES(@ID, @DebitorID, @Amount, @Balance, @OpenDate)"); //запрос с параметрами

            bool flagResult = false;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand com = new SqlCommand(query, con);

                SqlParameter param = new SqlParameter("@ID", ID); //можно также значение параметров передавать в одну из перегрузок конструктора при создании нового параметра типа SqlParameter
                //param.ParameterName = "@ID";
                //param.Value = ID;
                param.SqlDbType = System.Data.SqlDbType.UniqueIdentifier;
                com.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@DebitorID";
                param.Value = debitorID;
                param.SqlDbType = System.Data.SqlDbType.UniqueIdentifier;
                com.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Amount";
                param.Value = amount;
                param.SqlDbType = System.Data.SqlDbType.Money;
                com.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Balance";
                param.Value = balance;
                param.SqlDbType = System.Data.SqlDbType.Money;
                com.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@OpenDate";
                param.Value = openDate;
                param.SqlDbType = System.Data.SqlDbType.Date;
                com.Parameters.Add(param);

                try
                {
                    con.Open();
                    if (com.ExecuteNonQuery() == 1)
                        flagResult = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return flagResult;
        }

        public bool SaveNewPayment(Guid ID, Guid creditID, decimal paymentAmount, DateTime paymentDate)
        {
            bool flag = true;

            using (SqlConnection con = new SqlConnection(connectionString))
            { 
                con.Open(); //открываем соединение
                SqlTransaction sqlTransact = con.BeginTransaction(); //создаем транзакцию
                SqlCommand com = con.CreateCommand(); //создаем объект - команду
                com.Transaction = sqlTransact; //назначаем данному объекту (команда) свойство Transaction, в что говорит о том, что команда будет выполнена в режиме транзакции

                try
                {
                    string payAmount = paymentAmount.ToString(CultureInfo.InvariantCulture.NumberFormat);

                    string query = string.Format("insert into Payments (ID, CreditsID, Amount, PaymentDate) " +
                        "values ('{0}', '{1}', '{2}', '{3}')",
                        ID, creditID, payAmount, paymentDate.ToString("dd.MM.yyyy"));
                    com.CommandText = query;
                    com.ExecuteNonQuery();

                    query = string.Format("update Credits set Balance = (Balance - '{0}') where ID = '{1}'", 
                        payAmount, creditID);
                    com.CommandText = query;
                    com.ExecuteNonQuery();

                    sqlTransact.Commit();
                }
                catch(Exception)
                { 
                    sqlTransact.Rollback();
                    flag = false;
                }
                finally
                { 
                    if(con.State == System.Data.ConnectionState.Open)
                        con.Dispose();
                }
            }
            return flag;
        }

        internal bool SaveDBToLocalFile()
        {
            bool result = true;

            StreamWriter file;

            string query;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    file = new StreamWriter(new FileStream("Debitors.csv", FileMode.Create), Encoding.GetEncoding(1251));

                    query = "select * from Debitors";
                    SqlCommand com = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader reader = com.ExecuteReader();


                    file.WriteLine("Start of file");
                    //file.WriteLine(@"""ID"";""Name"";""PostNumber"";""PhoneNumber""");
                    file.WriteLine("Id; Name; PostNumber; PhoneNumber");

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //file.WriteLine(@"""" + reader.GetValue(0).ToString() +
                            //    @""";""" + reader.GetString(1) +
                            //    @""";""" + reader[2].ToString() +
                            //    @""";""" + reader[3].ToString() +
                            //    @"""", Encoding.ASCII);
                            file.WriteLine(reader[0].ToString()+";"+
                                           reader[1].ToString()+";"+
                                           reader[2].ToString()+";"+
                                           reader[3].ToString() +";");
                        }
                    }
                    else
                    {
                        file.WriteLine("No one row to save");
                    }
                    file.WriteLine("End of file");
                    result = true;
                    file.Dispose();
                }
                catch
                {
                    result = false;
                    return result;
                }
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    file = new StreamWriter(new FileStream("Credits.csv", FileMode.Create),
                        Encoding.GetEncoding(1251));

                    query = "select * from Credits";
                    SqlCommand com = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader reader = com.ExecuteReader();

                    file.WriteLine("Start of file");
                    file.WriteLine(@"""ID"";""DebitorID"";""Amount"";""Balance"";""OpenDate""");

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            file.WriteLine(@"""" + reader[0].ToString() +
                                @""";""" + reader[1].ToString() +
                                @""";""" + reader[2].ToString() +
                                @""";""" + reader[3].ToString() +
                                @""";""" + reader[4].ToString() +
                                @"""", Encoding.ASCII);
                        }
                    }
                    else
                    {
                        file.WriteLine("No one row to save");
                    }
                    file.WriteLine("End of file");
                    result = true;
                    file.Dispose();
                }
                catch
                {
                    result = false;
                    return result;
                }
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    file = new StreamWriter(new FileStream("Payments.csv", FileMode.Create),
                        Encoding.GetEncoding(1251));

                    query = "select * from Payments";
                    SqlCommand com = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader reader = com.ExecuteReader();

                    file.WriteLine("Start of file");
                    file.WriteLine(@"""ID"";""CreditsID"";""Amount"";""PaymentDate""");

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            file.WriteLine(@"""" + reader[0].ToString() +
                                @""";""" + reader[1].ToString() +
                                @""";""" + reader[2].ToString() +
                                @""";""" + reader[3].ToString() +
                                @"""", Encoding.ASCII);
                        }
                    }
                    else
                    {
                        file.WriteLine("No one row to save");
                    }
                    file.WriteLine("End of file");
                    result = true;
                    file.Dispose();
                }
                catch
                {
                    result = false;
                    return result;
                }
            }

            return result;

        }
    }
}
