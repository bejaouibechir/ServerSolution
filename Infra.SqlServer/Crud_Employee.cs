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
        SqlDataAdapter _adapter;
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

                

#if query
                _query = "INSERT INTO [dbo].[Employee]([Id],[Name],[Salary],[DaysOff]," +
                    $" [CreationDate]) VALUES(@id,@name,@salary,@daysoff,'{new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day)}')";
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

        }

        public void Delete_Employee(int id)
        {

        }

        public Employee Get_Employee(int id) {

            return null;
        }

        public List<Employee> List_Employee() {
            return null;
        }


        public List<Employee> Filter_Employee(Predicate<Employee> filter)
        {
            return null;  
        }
    }
}
