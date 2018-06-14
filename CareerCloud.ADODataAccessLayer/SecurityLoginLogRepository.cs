using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    class SecurityLoginLogRepository : BaseADO, IDataRepository<SecurityLoginLogPoco>
    {
        public void Add(params SecurityLoginLogPoco[] items)
        {
            SqlConnection connection = new SqlConnection(_connString);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                foreach(SecurityLoginLogPoco poco in items)
                {
                    cmd.CommandText = @"insert into Security_Logins_Log(Id, Login, Source_IP,
                    Logon_Date,Is_Successful)
                    values (@Id, @Login, @Source_IP,@Logon_Date,@Is_Succesful)";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Login", poco.Login);
                    cmd.Parameters.AddWithValue("@Source", poco.SourceIP);
                    cmd.Parameters.AddWithValue("@Logon_Date", poco.LogonDate);
                    cmd.Parameters.AddWithValue("@Is_Succesful", poco.IsSuccesful);
                    
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }


            }
        }

       
        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SecurityLoginLogPoco> GetAll(params Expression<Func<SecurityLoginLogPoco, object>>[] navigationProperties)
        {
            SecurityLoginLogPoco[] pocos = new SecurityLoginLogPoco[1000];
            {
                SqlConnection connection = new SqlConnection(_connString);
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;

                    cmd.CommandText = @"select * from Security_Logins_Roles";
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    int position = 0;
                    while (reader.Read())
                    {
                        SecurityLoginLogPoco poco = new SecurityLoginLogPoco();
                        poco.Id = reader.GetGuid(0);
                        poco.Login = reader.GetGuid(1);
                        poco.SourceIP = reader.GetString(2);
                        poco.LogonDate = reader.GetDateTime(3);
                        poco.IsSuccesful = reader.GetBoolean(4);
                        pocos[position] = poco;
                        position++;
                    }
                    connection.Close();
                    return pocos.Where(p => p != null).ToList();

                }
            }
        }

        public IList<SecurityLoginLogPoco> GetList(Expression<Func<SecurityLoginLogPoco, bool>> where, params Expression<Func<SecurityLoginLogPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginLogPoco GetSingle(Expression<Func<SecurityLoginLogPoco, bool>> where, params Expression<Func<SecurityLoginLogPoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityLoginLogPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityLoginLogPoco[] items)
        {
            SqlConnection connection = new SqlConnection(_connString);
            using (connection)
            {
                foreach (SecurityLoginLogPoco poco in items)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = @"delete from Company_Logins_Log
                            where Id= @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void Update(params SecurityLoginLogPoco[] items)
        {
            SqlConnection connection = new SqlConnection(_connString);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                foreach (SecurityLoginLogPoco poco in items)
                {
                    cmd.CommandText = @"update Security_Logins_Log
                    set Login=@Registration_Date,
                    Source_IP=@Source_IP,
                    Logon_Date=@Logon_Date,
                    Is_Succesful=@Is_Succesful,
                    where Id = @Id";
                    cmd.Parameters.AddWithValue("@Login", poco.Login);
                    cmd.Parameters.AddWithValue("@Source_IP", poco.SourceIP);
                    cmd.Parameters.AddWithValue("@Logon_Date", poco.LogonDate);
                    cmd.Parameters.AddWithValue("@Is_Succesful", poco.IsSuccesful);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                }
            }

        }
    }
}
