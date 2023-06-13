#define proc
//#define query
//#define prod
#define dev

using Microsoft.Data.SqlClient;
using Model;
using System.Data;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;

namespace Infra.SqlServer
{
    public partial class Crud
    {
       
        public void Add(Departement dep)
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
                _query = "INSERT INTO [dbo].[Departement]([Id],[Label]," +
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

        public void Update(int id, Departement new_dep)
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
                _query = "UPDATE [dbo].[Departement] set [Label] = @label" +
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

        public void Delete_Departement(int id)
        {
            try
            {
                SqlParameter idparam = new SqlParameter("@id", SqlDbType.Int);
                idparam.Direction = ParameterDirection.Input;
                idparam.Value = id;

#if query
                _query = "DELETE dbo.Departement where id = @id";
                _command = new SqlCommand(_query, _connection);
                _command.CommandType = CommandType.Text; //Pour représenter une requête 
                 _command.Parameters.Add(idparam);
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

        public Departement Get_Departement(int id) {

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
                Departement employee = new Departement
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

        public List<Departement> List_Departement() {
            List<Departement> departementlist = new List<Departement>();
            
            try
            {

                _query = "sp_getdepartementlist";
                _command = new SqlCommand(_query, _connection);
                _command.CommandType = CommandType.StoredProcedure; //Pour représenter une requête 
                _connection.Open();
                _reader = _command.ExecuteReader();
                while(_reader.Read())
                {
                    #pragma warning disable 8604, 8601
                    Departement departement = new Departement
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


        public List<Departement> Filter_Departement(Predicate<Departement> filter)
        {
            return List_Departement().FindAll(filter);
        }
    }
}
