#define dev
//#define prod

//#define query
#define proc

using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Abstractions;
using Model;
using System.Data;
using System.Diagnostics;

namespace Infra.SqlServer
{
    //Data Source=PC2023\PC2023;Initial Catalog=EntrepriseDB;Integrated Security=True
    public partial class Crud
    {

        SqlConnection _connection;
        SqlCommand _command;
        SqlDataReader _reader;
        string _connection_string;
        string _query;

        public Crud()
        {
            _connection_string = "Data Source=PC2023\\PC2023;TrustServerCertificate=true;Initial Catalog=EntrepriseDB;Integrated Security=True";
            _connection = new SqlConnection(_connection_string);
        }

        public void Add_Employee(Employee emp)
        {
            try
            {

                #region paramètres 
                
                SqlParameter idparam = new SqlParameter("@id", SqlDbType.Int);
                idparam.Direction = ParameterDirection.Input;
                idparam.Value = emp.Id;

                SqlParameter nameparam = new SqlParameter("@name", SqlDbType.NVarChar);
                nameparam.Direction = ParameterDirection.Input;
                nameparam.Value = emp.Name;

                SqlParameter salaryparam = new SqlParameter("@salary", SqlDbType.Money);
                salaryparam.Direction = ParameterDirection.Input;
                salaryparam.Value = emp.Salary;

                SqlParameter daysoffparam = new SqlParameter("@daysoff", SqlDbType.Int);
                daysoffparam.Direction = ParameterDirection.Input;
                daysoffparam.Value = emp.DaysOff;

                #endregion

#if query
                _query = "INSERT INTO [dbo].[Employee]([Id],[Name],[Salary],[DaysOff]," +
                    $" [CreationDate]) VALUES(@id,@name,@salary,@daysoff,'{new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day)}')";
                _command = new SqlCommand(_query, _connection);
                _command.CommandType = CommandType.Text; //Pour représenter une requête 
                 _command.Parameters.AddRange(new SqlParameter[] {idparam,nameparam,salaryparam
                    ,daysoffparam});
#endif
#if proc
                _query = "dbo.sp_addemployee";
                _command = new SqlCommand(_query, _connection);
                _command.CommandType = CommandType.StoredProcedure; //Pour représenter une requête 
                _command.Parameters.AddRange(new SqlParameter[] {idparam,nameparam,salaryparam
                    ,daysoffparam});
#endif     
                _connection.Open();
                _command.ExecuteNonQuery();
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

        public void Update_Employee(int id, Employee new_emp)
        {
            try
            {
                #region paramètres

                SqlParameter idparam = new SqlParameter("@id", SqlDbType.Int);
                idparam.Direction = ParameterDirection.Input;
                idparam.Value = new_emp.Id;

                SqlParameter nameparam = new SqlParameter("@name", SqlDbType.NVarChar);
                nameparam.Direction = ParameterDirection.Input;
                nameparam.Value = new_emp.Name;

                SqlParameter salaryparam = new SqlParameter("@salary", SqlDbType.Money);
                salaryparam.Direction = ParameterDirection.Input;
                salaryparam.Value = new_emp.Salary;

                SqlParameter daysoffparam = new SqlParameter("@daysoff", SqlDbType.Int);
                daysoffparam.Direction = ParameterDirection.Input;
                daysoffparam.Value = new_emp.DaysOff;

                SqlParameter depidparam = new SqlParameter("@depid", SqlDbType.Int);
                depidparam.Direction = ParameterDirection.Input;
                depidparam.Value = new_emp.DaysOff;

                #endregion

#if query
                _query = "INSERT INTO [dbo].[Employee]([Id],[Name],[Salary],[DaysOff]," +
                    $" [CreationDate]) VALUES(@id,@name,@salary,@daysoff,'{new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day)}')";
                _command = new SqlCommand(_query, _connection);
                _command.CommandType = CommandType.Text; //Pour représenter une requête 
                 _command.Parameters.AddRange(new SqlParameter[] {idparam,nameparam,salaryparam
                    ,daysoffparam});
                    _connection.Open();
                _command.ExecuteNonQuery();
#endif
#if proc
                _query = "sp_updateemployee";
                _command = new SqlCommand(_query, _connection);
                _command.CommandType = CommandType.StoredProcedure; //Pour représenter une requête 
                _command.Parameters.AddRange(new SqlParameter[] {idparam,nameparam,salaryparam
                    ,daysoffparam,depidparam});
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

        public void Delete_Employee(int id)
        {
            try
            {
                SqlParameter idparam = new SqlParameter("@id", SqlDbType.Int);
                idparam.Direction = ParameterDirection.Input;
                idparam.Value = id;

#if query
                _query = "DELETE dbo.Employee where id = @id";
                _command = new SqlCommand(_query, _connection);
                _command.CommandType = CommandType.Text; //Pour représenter une requête 
                 _command.Parameters.AddRange(new SqlParameter[] {idparam,nameparam,salaryparam
                    ,daysoffparam});
                _connection.Open();
                _command.ExecuteNonQuery();

#endif
#if proc
                _query = "sp_deleteemployee";
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

        public Employee Get_Employee(int id) 
        {

            try
            {
                SqlParameter idparam = new SqlParameter("@id", SqlDbType.Int);
                idparam.Direction = ParameterDirection.Input;
                idparam.Value = id;

                _query = "sp_getemployee";
                _command = new SqlCommand(_query, _connection);
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

        public List<Employee> List_Employee() 
        {
            List<Employee> employeelist = new List<Employee>();

            try
            {
               
                _query = "sp_getemployeelist";
                _command = new SqlCommand(_query, _connection);
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


        public List<Employee> Filter_Employee(Predicate<Employee> filter)
        {
            return List_Employee().FindAll(filter);
        }
    }
}
