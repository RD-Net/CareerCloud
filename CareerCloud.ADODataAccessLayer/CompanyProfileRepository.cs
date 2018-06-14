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
    class CompanyProfileRepository : BaseADO, IDataRepository<CompanyProfilePoco>
    {
        public void Add(params CompanyProfilePoco[] items)
        {
            SqlConnection connection = new SqlConnection(_connString);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                foreach (CompanyProfilePoco poco in items)
                {
                    cmd.CommandText = @"insert into Company_Profiles
                (Id, Registration_date, Company_Website, Contact_Phone, Contact_Name, Company_Logo)
                values
                (@Id, @Registration_date, @Company_Website, @Contact_Phone, @Contact_Name, @Company_Logo)";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Registration_Date", poco.RegistrationDate);
                    cmd.Parameters.AddWithValue("@Company_Website", poco.CompanyWebsite);
                    cmd.Parameters.AddWithValue("@Contact_Phone", poco.ContactPhone);
                    cmd.Parameters.AddWithValue("@Contact_Name", poco.ContactName);
                    cmd.Parameters.AddWithValue("@Company_Logo", poco.CompanyLogo);

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

        public IList<CompanyProfilePoco> GetAll(params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            SqlConnection connection = new SqlConnection(_connString);
            CompanyProfilePoco[] pocos = new CompanyProfilePoco[1000];
            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"select* from Company_Profiles";
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int position = 0;
                while (reader.Read())
                {
                    CompanyProfilePoco poco = new CompanyProfilePoco();
                    poco.Id = reader.GetGuid(0);
                    poco.RegistrationDate = reader.GetDateTime(1);
                    poco.CompanyWebsite = reader.GetString(2);
                    poco.ContactPhone = reader.GetString(3);
                    poco.ContactName = reader.GetString(4);
                    poco.CompanyLogo = (Byte[])reader[5];
                    poco.TimeStamp = (Byte[])reader[6];
                    pocos[position] = poco;
                    position++;
                }
                connection.Close();
                return pocos.Where(p => p != null).ToList();
            }
        }

        public IList<CompanyProfilePoco> GetList(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyProfilePoco GetSingle(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyProfilePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyProfilePoco[] items)
        {
            SqlConnection connection = new SqlConnection(_connString);
            using (connection)
            {
                foreach (CompanyProfilePoco poco in items)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = @"delete from Company_Profiles
                            where Id= @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void Update(params CompanyProfilePoco[] items)
        {
            SqlConnection connection = new SqlConnection(_connString);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                foreach (CompanyProfilePoco poco in items)
                {
                    cmd.CommandText = @"update Company_Profiles
                    set Registration_Date=@Registration_Date,
                    Company_Website=@Company_Website,
                    Contact_Phone=@Contact_Phone,
                    Contact_Name=@Contact_Name,
                    Company_Logo=@Company_Logo
                    where Id = @Id";
                    cmd.Parameters.AddWithValue("@Registration_Date", poco.RegistrationDate);
                    cmd.Parameters.AddWithValue("@Company_Website", poco.CompanyWebsite);
                    cmd.Parameters.AddWithValue("@Contact_Phone", poco.ContactPhone);
                    cmd.Parameters.AddWithValue("@Contact_Name", poco.ContactName);
                    cmd.Parameters.AddWithValue("@Company_Logo", poco.CompanyLogo);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                }
            }

        }
    }
}
