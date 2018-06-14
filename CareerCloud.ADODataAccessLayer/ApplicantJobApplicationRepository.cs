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
    class ApplicantJobApplicationRepository : BaseADO,IDataRepository<ApplicantJobApplicationPoco>
    {
        public void Add(params ApplicantJobApplicationPoco[] items)
        {
            SqlConnection connection = new SqlConnection(_connString);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                foreach (ApplicantJobApplicationPoco poco in items)
                {
                    cmd.CommandText = @"Insert into Applicant_Job_Applications
                (Id, Applicant, Job, Application_Date)
                   Values
                (@Id, @Applicant, @Job, @Application_Date)";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    cmd.Parameters.AddWithValue("@Job", poco.Job);
                    cmd.Parameters.AddWithValue("@Application_Date", poco.ApplicationDate);

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

        public IList<ApplicantJobApplicationPoco> GetAll(params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            ApplicantJobApplicationPoco[] pocos = new ApplicantJobApplicationPoco[1000];
            SqlConnection connection = new SqlConnection(_connString);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = @"select * from Applicant_Job_Educations";
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int position = 0;
                while (reader.Read())
                {
                    ApplicantJobApplicationPoco poco = new ApplicantJobApplicationPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Applicant = reader.GetGuid(1);
                    poco.Job = reader.GetGuid(2);
                    poco.ApplicationDate =reader.GetDateTime(3);
                    poco.TimeStamp = (Byte[])reader[4];
                    pocos[position] = poco;
                    position++;
                }
                connection.Close();
                return pocos;
            }
        }

        public IList<ApplicantJobApplicationPoco> GetList(Expression<Func<ApplicantJobApplicationPoco, bool>> where, params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantJobApplicationPoco GetSingle(Expression<Func<ApplicantJobApplicationPoco, bool>> where, params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantJobApplicationPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantJobApplicationPoco[] items)
        {
            SqlConnection connection = new SqlConnection(_connString);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                foreach (ApplicantJobApplicationPoco poco in items)
                {
                    cmd.CommandText = @"delete from Applicant_Job_Applications
                        where Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                }
            }

        }

                public void Update(params ApplicantJobApplicationPoco[] items)
                {
                SqlConnection connection = new SqlConnection(_connString);
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    foreach (ApplicantJobApplicationPoco poco in items)
                    {
                        cmd.CommandText = @"update Applicant_Educations
                    set Applicant=@Applicant,
                    Job=@Job,
                    Application_date=@Application_date,
                    where Id = @Id";
                        cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                        cmd.Parameters.AddWithValue("@Job", poco.Job);
                        cmd.Parameters.AddWithValue("@Applicationdate", poco.ApplicationDate);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();

                    }
                }
            }
    }
}
