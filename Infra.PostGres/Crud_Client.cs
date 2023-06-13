#define dev
#define prod
#define query 
#define proc

using Model;
using Npgsql;
using System.Data;

using System.Diagnostics;

namespace Infra.Postgres
{
    public partial class Crud
    {
        public void Add_Client(Client cli)
        {
            try
            {

                #region paramètres 

                NpgsqlParameter idparam = new NpgsqlParameter("@id", SqlDbType.Int);
                idparam.Direction = ParameterDirection.Input;
                idparam.Value = cli.Id;

                NpgsqlParameter nameparam = new NpgsqlParameter("@name", SqlDbType.NVarChar);
                nameparam.Direction = ParameterDirection.Input;
                nameparam.Value = cli.Name;

                NpgsqlParameter historyparam = new NpgsqlParameter("@history", SqlDbType.Xml);
                historyparam.Direction = ParameterDirection.Input;
                historyparam.Value = cli.History;

                NpgsqlParameter employeeparam = new NpgsqlParameter("@employeeid", SqlDbType.Int);
                employeeparam.Direction = ParameterDirection.Input;
                employeeparam.Value = cli.EmployeeId;


                #endregion

#if query
                _query = "INSERT INTO [Client]([Id],[Name],[History]," +
                    $" [CreationDate],[EmployeeID]) VALUES(@id,@name,@history," +
                    $"'{new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)}',@employeeid)";
                _command = new NpgsqlCommand(_query, _connection);
                _command.CommandType = CommandType.Text; //Pour représenter une requête 
                _command.Parameters.AddRange(new NpgsqlParameter[] {idparam,nameparam,historyparam
                    ,employeeparam});
                _connection.Open();
                _command.ExecuteNonQuery();

#endif
#if proc
                _query = "sp_addclient";
                _command = new NpgsqlCommand(_query, _connection);
                _command.CommandType = CommandType.StoredProcedure; //Pour représenter une requête 
                _command.Parameters.AddRange(new NpgsqlParameter[] {idparam,nameparam,historyparam
                    ,employeeparam});
                _connection.Open();
                _command.ExecuteNonQuery();
#endif

            }
            catch (NpgsqlException ex)
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

                NpgsqlParameter idparam = new NpgsqlParameter("@id", SqlDbType.Int);
                idparam.Direction = ParameterDirection.Input;
                idparam.Value = new_cli.Id;

                NpgsqlParameter nameparam = new NpgsqlParameter("@name", SqlDbType.NVarChar);
                nameparam.Direction = ParameterDirection.Input;
                nameparam.Value = new_cli.Name;

                NpgsqlParameter historyparam = new NpgsqlParameter("@history", SqlDbType.Xml);
                historyparam.Direction = ParameterDirection.Input;
                historyparam.Value = new_cli.History;

                NpgsqlParameter employeeparam = new NpgsqlParameter("@employeeid", SqlDbType.Int);
                employeeparam.Direction = ParameterDirection.Input;
                employeeparam.Value = new_cli.EmployeeId;


                #endregion

#if query
                _query = "UPDATE [Client] set [Name]=@name,[History]=@history," +
                    $" [EmployeeID]=@employeeid where Id=@id" +
                    $"'{new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)}',@employeeid)";
                _command = new NpgsqlCommand(_query, _connection);
                _command.CommandType = CommandType.Text; //Pour représenter une requête 
                _command.Parameters.AddRange(new NpgsqlParameter[] {idparam,nameparam,historyparam
                    ,employeeparam});
                _connection.Open();
                _command.ExecuteNonQuery();

#endif
#if proc
                _query = "sp_updateclient";
                _command = new NpgsqlCommand(_query, _connection);
                _command.CommandType = CommandType.StoredProcedure; //Pour représenter une requête 
                _command.Parameters.AddRange(new NpgsqlParameter[] {idparam,nameparam,historyparam
                    ,employeeparam});
                _connection.Open();
                _command.ExecuteNonQuery();
#endif

            }
            catch (NpgsqlException ex)
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
                NpgsqlParameter idparam = new NpgsqlParameter("@id", SqlDbType.Int);
                idparam.Direction = ParameterDirection.Input;
                idparam.Value = id;

#if query
                _query = "DELETE Client where id = @id";
                _command = new NpgsqlCommand(_query, _connection);
                _command.CommandType = CommandType.Text; //Pour représenter une requête 
                _command.Parameters.AddRange(new NpgsqlParameter[] {idparam});
                _connection.Open();
                _command.ExecuteNonQuery();

#endif
#if proc
                _query = "sp_deleteclient";
                _command = new NpgsqlCommand(_query, _connection);
                _command.CommandType = CommandType.StoredProcedure; //Pour représenter une requête 
                _command.Parameters.Add(idparam);
                _connection.Open();
                _command.ExecuteNonQuery();
#endif
            }
            catch (NpgsqlException ex)
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
                NpgsqlParameter idparam = new NpgsqlParameter("@id", SqlDbType.Int);
                idparam.Direction = ParameterDirection.Input;
                idparam.Value = id;

                _query = "sp_getclient";
                _command = new NpgsqlCommand(_query, _connection);
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
            catch (NpgsqlException ex)
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
                _command = new NpgsqlCommand(_query, _connection);
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
            catch (NpgsqlException ex)
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
