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
    class CompanyJobEducationRepository : BaseADO,IDataRepository<CompanyJobEducationPoco>
    {
        public void Add(params CompanyJobEducationPoco[] items)
        {
            SqlConnection connection = new SqlConnection(_connString);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                foreach (CompanyJobEducationPoco poco in items)
                {
                    cmd.CommandText = @"insert into Company_Job_Educations
                (Id, Job, Major,Importance)
                values
                (@Id, @Job, @Major,@Importance)";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Job", poco.Job);
                    cmd.Parameters.AddWithValue("@Major", poco.Major);
                    cmd.Parameters.AddWithValue("@Importance", poco.Importance);

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

        public IList<CompanyJobEducationPoco> GetAll(params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            CompanyJobEducationPoco[] pocos = new CompanyJobEducationPoco[1000];
            SqlConnection connection = new SqlConnection(_connString);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"select* from Company_Job_Educations";
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int position = 0;
                while (reader.Read())
                {
                    CompanyJobEducationPoco poco = new CompanyJobEducationPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Job = reader.GetGuid(1);
                    poco.Major = reader.GetString(2);
                    poco.Importance = reader.GetInt16(3);
                    poco.TimeStamp = (Byte[])reader[4];
                    pocos[position] = poco;
                    position++;
                }
                connection.Close();
                return pocos.Where(p=> p!= null).ToList();
            }
        }

        public IList<CompanyJobEducationPoco> GetList(Expression<Func<CompanyJobEducationPoco, bool>> where, params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobEducationPoco GetSingle(Expression<Func<CompanyJobEducationPoco, bool>> where, params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobEducationPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyJobEducationPoco[] items)
        {
            SqlConnection connection = new SqlConnection(_connString);
            using (connection)
            {
                foreach (CompanyJobEducationPoco poco in items)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = @"delete from Company_Job_Educations
                            where ID= @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void Update(params CompanyJobEducationPoco[] items)
        {
            SqlConnection connection = new SqlConnection(_connString);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                foreach (CompanyJobEducationPoco poco in items)
                {
                    cmd.CommandText = @"update Company_Job_Educations
                    set Job=@Job,
                    Major=@Major,
                    Importance=@Importance
                    where Id = @Id";
                    cmd.Parameters.AddWithValue("@Job", poco.Job);
                    cmd.Parameters.AddWithValue("@Major", poco.Major);
                    cmd.Parameters.AddWithValue("@Importance", poco.Importance);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                }
            }

        }
    }
}
