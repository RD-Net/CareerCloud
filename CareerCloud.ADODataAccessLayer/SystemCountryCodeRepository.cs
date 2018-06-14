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
    class SystemCountryCodeRepository : BaseADO, IDataRepository<SystemCountryCodePoco>
    {
        public void Add(params SystemCountryCodePoco[] items)
        {
            SqlConnection connection = new SqlConnection(_connString);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                foreach (SystemCountryCodePoco poco in items)
                {
                    cmd.CommandText = @"insert into Security_Logins_Log(Code, Name)
                    values (@Code, @Name)";
                    cmd.Parameters.AddWithValue("@Code", poco.Code);
                    cmd.Parameters.AddWithValue("@Name", poco.Name);
                    
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

        public IList<SystemCountryCodePoco> GetAll(params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            SystemCountryCodePoco[] pocos = new SystemCountryCodePoco[1000];
            {
                SqlConnection connection = new SqlConnection(_connString);
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;

                    cmd.CommandText = @"select * from System_Country_Codes";
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    int position = 0;
                    while (reader.Read())
                    {
                        SystemCountryCodePoco poco = new SystemCountryCodePoco();
                        poco.Code = reader.GetString(0);
                        poco.Name = reader.GetString(1);
                        pocos[position] = poco;
                        position++;
                    }
                    connection.Close();
                return pocos.Where(p => p != null).ToList();
                }
            }
        }

        public IList<SystemCountryCodePoco> GetList(Expression<Func<SystemCountryCodePoco, bool>> where, params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SystemCountryCodePoco GetSingle(Expression<Func<SystemCountryCodePoco, bool>> where, params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            IQueryable<SystemCountryCodePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SystemCountryCodePoco[] items)
        {
            SqlConnection connection = new SqlConnection(_connString);
            using (connection)
            {
                foreach (SystemCountryCodePoco poco in items)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = @"delete from System_Country_Codes
                            where Code= @Code";
                    cmd.Parameters.AddWithValue("@Code", poco.Code);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void Update(params SystemCountryCodePoco[] items)
        {
            SqlConnection connection = new SqlConnection(_connString);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                foreach (SystemCountryCodePoco poco in items)
                {
                    cmd.CommandText = @"update Security_Logins
                    set Name=@Name
                    where Code = @Code";
                    cmd.Parameters.AddWithValue("@Name", poco.Name);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                }
            }

        }
    }
}
