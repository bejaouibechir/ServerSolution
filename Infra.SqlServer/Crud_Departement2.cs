#define proc
//#define query
//#define prod
#define dev

using Microsoft.Data.SqlClient;
using Model;
using Model.Abstraction;
using Model.Version1;
using System.Data;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;

namespace Infra.SqlServer
{
    public partial class Crud
    {
       
        public void Add_Departement2(Departement2 dep)
        {
            try
            {

                #region paramètres 

                SqlParameter idparam = new SqlParameter("@id", SqlDbType.Int);
                idparam.Direction = ParameterDirection.Input;
                idparam.Value = dep.Id;

                SqlParameter labelparam = new SqlParameter("@label", SqlDbType.NVarChar);
                labelparam.Direction = ParameterDirection.Input;
                labelparam.Value = dep.Label;

                #endregion

#if query
                _query = "INSERT INTO [dbo].[Departement2]([Id],[Label]," +
                    $" [CreationDate]) VALUES(@id,@name,@salary,@daysoff,'{new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day)}')";
                _command = new SqlCommand(_query, _connection);
                _command.CommandType = CommandType.Text; //Pour représenter une requête 
                 _command.Parameters.AddRange(new SqlParameter[] {idparam,labelparam});
#endif
#if proc
                _query = "dbo.sp_adddepartement";
                _command = new SqlCommand(_query, _connection);
                _command.CommandType = CommandType.StoredProcedure; //Pour représenter une requête 
                _command.Parameters.AddRange(new SqlParameter[] {idparam,labelparam});
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

        public void Update_Departement2(int id, Departement2 new_dep)
        {
            try
            {

                #region paramètres 

                SqlParameter idparam = new SqlParameter("@id", SqlDbType.Int);
                idparam.Direction = ParameterDirection.Input;
                idparam.Value = new_dep.Id;

                SqlParameter labelparam = new SqlParameter("@label", SqlDbType.NVarChar);
                labelparam.Direction = ParameterDirection.Input;
                labelparam.Value = new_dep.Label;

                #endregion

#if query
                _query = "UPDATE [dbo].[Departement2] set [Label] = @label" +
                        $" where [Id] =@id )";
                _command = new SqlCommand(_query, _connection);
                _command.CommandType = CommandType.Text; //Pour représenter une requête 
                 _command.Parameters.AddRange(new SqlParameter[] {idparam,label});
#endif
#if proc
                _query = "dbo.sp_updatedepartement";
                _command = new SqlCommand(_query, _connection);
                _command.CommandType = CommandType.StoredProcedure; //Pour représenter une requête 
                _command.Parameters.AddRange(new SqlParameter[] {idparam,labelparam});
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

        public void Delete_Departement2(int id)
        {
            try
            {
                SqlParameter idparam = new SqlParameter("@id", SqlDbType.Int);
                idparam.Direction = ParameterDirection.Input;
                idparam.Value = id;

#if query
                _query = "DELETE dbo.Departement2 where id = @id";
                _command = new SqlCommand(_query, _connection);
                _command.CommandType = CommandType.Text; //Pour représenter une requête 
                 _command.Parameters.Add(idparam);
                _connection.Open();
                _command.ExecuteNonQuery();

#endif
#if proc
                _query = "dbo.sp_deleteemployee";
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

        public Departement2 Get_Departement2(int id) {

            try
            {
                SqlParameter idparam = new SqlParameter("@id", SqlDbType.Int);
                idparam.Direction = ParameterDirection.Input;
                idparam.Value = id;

                _query = "sp_getdepartement";
                _command = new SqlCommand(_query, _connection);
                _command.CommandType = CommandType.StoredProcedure; //Pour représenter une requête 
                _command.Parameters.Add(idparam);
                _connection.Open();
                _reader = _command.ExecuteReader();
                _reader.Read();

#pragma warning disable 8604, 8601
                Departement2 employee = new Departement2
                {
                    Id = int.Parse(_reader["Id"].ToString()),
                    Label = _reader[1].ToString(), 
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

        public List<IDepartement> List_Departement2() {
            List<Departement2> departementlist = new List<Departement2>();
            
            try
            {

                _query = "dbo.sp_getdepartementlist";
                _command = new SqlCommand(_query, _connection);
                _command.CommandType = CommandType.StoredProcedure; //Pour représenter une requête 
                _connection.Open();
                _reader = _command.ExecuteReader();
                while(_reader.Read())
                {
                    #pragma warning disable 8604, 8601
                    Departement2 departement = new Departement2
                    {
                        Id = int.Parse(_reader["Id"].ToString()),
                        Label = _reader[1].ToString(),
                    };
                    departementlist.Add(departement);  
                }
               return departementlist;

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


        public List<IDepartement> Filter_Departement2(Predicate<IDepartement> filter)
        {
            return List_Departement2().FindAll(filter);
        }
    }
}
