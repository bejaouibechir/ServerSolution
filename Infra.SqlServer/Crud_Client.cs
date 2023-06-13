#define dev
#define prod
#define query 
#define proc

using Microsoft.Data.SqlClient;
using Model;
using System.Data;

using System.Diagnostics;

namespace Infra.SqlServer
{
    public partial class Crud
    {
        public void Add_Client(Client cli)
        {
            try
            {

                #region paramètres 

                SqlParameter idparam = new SqlParameter("@id", SqlDbType.Int);
                idparam.Direction = ParameterDirection.Input;
                idparam.Value = cli.Id;

                SqlParameter nameparam = new SqlParameter("@name", SqlDbType.NVarChar);
                nameparam.Direction = ParameterDirection.Input;
                nameparam.Value = cli.Name;

                SqlParameter historyparam = new SqlParameter("@history", SqlDbType.Xml);
                historyparam.Direction = ParameterDirection.Input;
                historyparam.Value = cli.History;

                SqlParameter employeeparam = new SqlParameter("@employeeid", SqlDbType.Int);
                employeeparam.Direction = ParameterDirection.Input;
                employeeparam.Value = cli.EmployeeId;


                #endregion

#if query
                _query = "INSERT INTO [dbo].[Client]([Id],[Name],[History]," +
                    $" [CreationDate],[EmployeeID]) VALUES(@id,@name,@history," +
                    $"'{new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)}',@employeeid)";
                _command = new SqlCommand(_query, _connection);
                _command.CommandType = CommandType.Text; //Pour représenter une requête 
                _command.Parameters.AddRange(new SqlParameter[] {idparam,nameparam,historyparam
                    ,employeeparam});
                _connection.Open();
                _command.ExecuteNonQuery();

#endif
#if proc
                _query = "dbo.sp_addclient";
                _command = new SqlCommand(_query, _connection);
                _command.CommandType = CommandType.StoredProcedure; //Pour représenter une requête 
                _command.Parameters.AddRange(new SqlParameter[] {idparam,nameparam,historyparam
                    ,employeeparam});
                _connection.Open();
                _command.ExecuteNonQuery();
#endif

            }
            catch (SqlException ex)
            {

#if dev
                Debug.WriteLine(ex.Message);
#endif
#if prod
                EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error);
#endif
                throw;
            }
            finally
            {
                _connection.Close();
            }
        }

        public void Update_Client(int id, Client new_cli)
        {
            try
            {

                #region paramètres 

                SqlParameter idparam = new SqlParameter("@id", SqlDbType.Int);
                idparam.Direction = ParameterDirection.Input;
                idparam.Value = new_cli.Id;

                SqlParameter nameparam = new SqlParameter("@name", SqlDbType.NVarChar);
                nameparam.Direction = ParameterDirection.Input;
                nameparam.Value = new_cli.Name;

                SqlParameter historyparam = new SqlParameter("@history", SqlDbType.Xml);
                historyparam.Direction = ParameterDirection.Input;
                historyparam.Value = new_cli.History;

                SqlParameter employeeparam = new SqlParameter("@employeeid", SqlDbType.Int);
                employeeparam.Direction = ParameterDirection.Input;
                employeeparam.Value = new_cli.EmployeeId;


                #endregion

#if query
                _query = "UPDATE [dbo].[Client] set [Name]=@name,[History]=@history," +
                    $" [EmployeeID]=@employeeid where Id=@id" +
                    $"'{new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)}',@employeeid)";
                _command = new SqlCommand(_query, _connection);
                _command.CommandType = CommandType.Text; //Pour représenter une requête 
                _command.Parameters.AddRange(new SqlParameter[] {idparam,nameparam,historyparam
                    ,employeeparam});
                _connection.Open();
                _command.ExecuteNonQuery();

#endif
#if proc
                _query = "dbo.sp_updateclient";
                _command = new SqlCommand(_query, _connection);
                _command.CommandType = CommandType.StoredProcedure; //Pour représenter une requête 
                _command.Parameters.AddRange(new SqlParameter[] {idparam,nameparam,historyparam
                    ,employeeparam});
                _connection.Open();
                _command.ExecuteNonQuery();
#endif

            }
            catch (SqlException ex)
            {

#if dev
                Debug.WriteLine(ex.Message);
#endif
#if prod
                EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error);
#endif
                throw;
            }
            finally
            {
                _connection.Close();
            }

        }

        public void Delete_Client(int id)
        {
            try
            {
                SqlParameter idparam = new SqlParameter("@id", SqlDbType.Int);
                idparam.Direction = ParameterDirection.Input;
                idparam.Value = id;

#if query
                _query = "DELETE dbo.Client where id = @id";
                _command = new SqlCommand(_query, _connection);
                _command.CommandType = CommandType.Text; //Pour représenter une requête 
                _command.Parameters.AddRange(new SqlParameter[] {idparam});
                _connection.Open();
                _command.ExecuteNonQuery();

#endif
#if proc
                _query = "sp_deleteclient";
                _command = new SqlCommand(_query, _connection);
                _command.CommandType = CommandType.StoredProcedure; //Pour représenter une requête 
                _command.Parameters.Add(idparam);
                _connection.Open();
                _command.ExecuteNonQuery();
#endif
            }
            catch (SqlException ex)
            {
#if dev
                Debug.WriteLine(ex.Message);
#endif
#if prod
                EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error);
#endif
                throw;
            }
        }

        public Client Get_Client(int id) {

            try
            {
                SqlParameter idparam = new SqlParameter("@id", SqlDbType.Int);
                idparam.Direction = ParameterDirection.Input;
                idparam.Value = id;

                _query = "sp_getclient";
                _command = new SqlCommand(_query, _connection);
                _command.CommandType = CommandType.StoredProcedure; //Pour représenter une requête 
                _command.Parameters.Add(idparam);
                _connection.Open();
                _reader = _command.ExecuteReader();
                _reader.Read();

                int empid;
                int.TryParse(_reader[5].ToString(), out empid);

#pragma warning disable 8604, 8601
                Client employee = new Client
                {
                    Id = int.Parse(_reader["Id"].ToString()),
                    Name = _reader[1].ToString(),
                    History =_reader[2].ToString(),
                    CreationDate = DateTime.Parse(_reader[4].ToString()),
                    EmployeeId = empid
                };
                return employee;
            }
            catch (SqlException ex)
            {
#if dev
                Debug.WriteLine(ex.Message);
#endif
#if prod
                EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error);
#endif
                return null;
            }
            finally
            {
                _connection.Close();
            }
        }

        public List<Client> List_Client() {
            List<Client> clientlist = new List<Client>();
            try
            {
                _query = "sp_getclient";
                _command = new SqlCommand(_query, _connection);
                _command.CommandType = CommandType.StoredProcedure; 
                _connection.Open();
                _reader = _command.ExecuteReader();
                while(_reader.Read())
                {
                 int empid;
                                int.TryParse(_reader[5].ToString(), out empid);

                #pragma warning disable 8604, 8601
                                Client client = new Client
                                {
                                    Id = int.Parse(_reader["Id"].ToString()),
                                    Name = _reader[1].ToString(),
                                    History = _reader[2].ToString(),
                                    CreationDate = DateTime.Parse(_reader[4].ToString()),
                                    EmployeeId = empid
                                };
                        clientlist.Add(client);
                }
                return clientlist;
               
            }
            catch (SqlException ex)
            {
#if dev
                Debug.WriteLine(ex.Message);
#endif
#if prod
                EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error);
#endif
                return null;
            }
            finally
            {
                _connection.Close();
            }
        }

        public List<Client> Filter_Client(Predicate<Client> filter)
        {
            return List_Client().FindAll(filter);
        }
    }
}
