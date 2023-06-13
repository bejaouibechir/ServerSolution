#define dev
//#define prod

//#define query
#define proc

using Model;
using System.Data;
using System.Diagnostics;
using Npgsql;

namespace Infra.Postgres
{
    //Server=localhost;Port=5432;Database=EntrepriseDB;User Id=postgres;Password=test;CommandTimeout=20;
    public partial class Crud
    {

        NpgsqlConnection _connection;
        NpgsqlCommand _command;
        NpgsqlDataReader _reader;
        string _connection_string;
        string _query;

        public Crud()
        {
            _connection_string = "Server=localhost;Port=5432;Database=EntrepriseDB;User Id=postgres;Password=test;CommandTimeout=20;";
            _connection = new NpgsqlConnection(_connection_string);
        }

        public void Add_Employee(Employee emp)
        {
            try
            {

                #region paramètres 
                
                NpgsqlParameter idparam = new NpgsqlParameter("@id", SqlDbType.Int);
                idparam.Direction = ParameterDirection.Input;
                idparam.Value = emp.Id;

                NpgsqlParameter nameparam = new NpgsqlParameter("@name", SqlDbType.NVarChar);
                nameparam.Direction = ParameterDirection.Input;
                nameparam.Value = emp.Name;

                NpgsqlParameter salaryparam = new NpgsqlParameter("@salary", SqlDbType.Money);
                salaryparam.Direction = ParameterDirection.Input;
                salaryparam.Value = emp.Salary;

                NpgsqlParameter daysoffparam = new NpgsqlParameter("@daysoff", SqlDbType.Int);
                daysoffparam.Direction = ParameterDirection.Input;
                daysoffparam.Value = emp.DaysOff;

                #endregion

#if query
                _query = "INSERT INTO [Employee]([Id],[Name],[Salary],[DaysOff]," +
                    $" [CreationDate]) VALUES(@id,@name,@salary,@daysoff,'{new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day)}')";
                _command = new NpgsqlCommand(_query, _connection);
                _command.CommandType = CommandType.Text; //Pour représenter une requête 
                 _command.Parameters.AddRange(new NpgsqlParameter[] {idparam,nameparam,salaryparam
                    ,daysoffparam});
#endif
#if proc
                _query = "sp_addemployee";
                _command = new NpgsqlCommand(_query, _connection);
                _command.CommandType = CommandType.StoredProcedure; //Pour représenter une requête 
                _command.Parameters.AddRange(new NpgsqlParameter[] {idparam,nameparam,salaryparam
                    ,daysoffparam});
#endif     
                _connection.Open();
                _command.ExecuteNonQuery();
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

        public void Update_Employee(int id, Employee new_emp)
        {
            try
            {
                #region paramètres

                NpgsqlParameter idparam = new NpgsqlParameter("@id", SqlDbType.Int);
                idparam.Direction = ParameterDirection.Input;
                idparam.Value = new_emp.Id;

                NpgsqlParameter nameparam = new NpgsqlParameter("@name", SqlDbType.NVarChar);
                nameparam.Direction = ParameterDirection.Input;
                nameparam.Value = new_emp.Name;

                NpgsqlParameter salaryparam = new NpgsqlParameter("@salary", SqlDbType.Money);
                salaryparam.Direction = ParameterDirection.Input;
                salaryparam.Value = new_emp.Salary;

                NpgsqlParameter daysoffparam = new NpgsqlParameter("@daysoff", SqlDbType.Int);
                daysoffparam.Direction = ParameterDirection.Input;
                daysoffparam.Value = new_emp.DaysOff;

                NpgsqlParameter depidparam = new NpgsqlParameter("@depid", SqlDbType.Int);
                depidparam.Direction = ParameterDirection.Input;
                depidparam.Value = new_emp.DaysOff;

                #endregion

#if query
                _query = "INSERT INTO [Employee]([Id],[Name],[Salary],[DaysOff]," +
                    $" [CreationDate]) VALUES(@id,@name,@salary,@daysoff,'{new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day)}')";
                _command = new NpgsqlCommand(_query, _connection);
                _command.CommandType = CommandType.Text; //Pour représenter une requête 
                 _command.Parameters.AddRange(new NpgsqlParameter[] {idparam,nameparam,salaryparam
                    ,daysoffparam});
                    _connection.Open();
                _command.ExecuteNonQuery();
#endif
#if proc
                _query = "sp_updateemployee";
                _command = new NpgsqlCommand(_query, _connection);
                _command.CommandType = CommandType.StoredProcedure; //Pour représenter une requête 
                _command.Parameters.AddRange(new NpgsqlParameter[] {idparam,nameparam,salaryparam
                    ,daysoffparam,depidparam});
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

        public void Delete_Employee(int id)
        {
            try
            {
                NpgsqlParameter idparam = new NpgsqlParameter("@id", SqlDbType.Int);
                idparam.Direction = ParameterDirection.Input;
                idparam.Value = id;

#if query
                _query = "DELETE Employee where id = @id";
                _command = new NpgsqlCommand(_query, _connection);
                _command.CommandType = CommandType.Text; //Pour représenter une requête 
                 _command.Parameters.AddRange(new NpgsqlParameter[] {idparam,nameparam,salaryparam
                    ,daysoffparam});
                _connection.Open();
                _command.ExecuteNonQuery();

#endif
#if proc
                _query = "sp_deleteemployee";
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

        public Employee Get_Employee(int id) 
        {

            try
            {
                NpgsqlParameter idparam = new NpgsqlParameter("@id", SqlDbType.Int);
                idparam.Direction = ParameterDirection.Input;
                idparam.Value = id;

                _query = "sp_getemployee";
                _command = new NpgsqlCommand(_query, _connection);
                _command.CommandType = CommandType.StoredProcedure; //Pour représenter une requête 
                _command.Parameters.Add(idparam);
                _connection.Open();
                _reader = _command.ExecuteReader();
                _reader.Read();

                int depid;
                int.TryParse(_reader[5].ToString(), out depid);

#pragma warning disable 8604, 8601
                Employee employee = new Employee
                {
                    Id = int.Parse(_reader["Id"].ToString()),
                    Name = _reader[1].ToString(),
                    Salary = decimal.Parse(_reader[2].ToString()),
                    DaysOff = int.Parse(_reader[3].ToString()),
                    CreationDate = DateTime.Parse(_reader[4].ToString()),
                    DepartementId = depid
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

        public List<Employee> List_Employee() 
        {
            List<Employee> employeelist = new List<Employee>();

            try
            {
               
                _query = "sp_getemployeelist";
                _command = new NpgsqlCommand(_query, _connection);
                _command.CommandType = CommandType.StoredProcedure; //Pour représenter une requête 
                _connection.Open();
                _reader = _command.ExecuteReader();

                while (_reader.Read())
                {
                    int depid;
                    int.TryParse(_reader[5].ToString(), out depid);

                  
                    Employee employee = new Employee
                    {
                        Id = int.Parse(_reader["Id"].ToString()),
                        Name = _reader[1].ToString(),
                        Salary = decimal.Parse(_reader[2].ToString()),
                        DaysOff = int.Parse(_reader[3].ToString()),
                        CreationDate = DateTime.Parse(_reader[4].ToString()),
                        DepartementId = depid
                    };
                    employeelist.Add(employee);
                }
                return employeelist;

#pragma warning disable 8604, 8601
               
                
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


        public List<Employee> Filter_Employee(Predicate<Employee> filter)
        {
            return List_Employee().FindAll(filter);
        }
    }
}
