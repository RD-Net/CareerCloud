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
    class ApplicantWorkHistoryRepository : BaseADO, IDataRepository<ApplicantWorkHistoryPoco>
    {
        public void Add(params ApplicantWorkHistoryPoco[] items)
        {
            SqlConnection connection = new SqlConnection(_connString);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                foreach (ApplicantWorkHistoryPoco poco in items)
                {
                    cmd.CommandText = @"insert into Applicant_Work_History 
                (Id, Applicant, Company_Name,Country_Code, Location, Job_title, Job_Description
                Start_Month,Start_Year, End_Month, End_Year)
                values
                (@Id, @Applicant, @Company_Name,@Country_Code, @Location, @Job_title, @Job_Description,
                @Start_Month, @Start_Year, @End_Month, @End_Year)";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    cmd.Parameters.AddWithValue("@Company_Name", poco.CompanyName);
                    cmd.Parameters.AddWithValue("@Country_Code", poco.CountryCode);
                    cmd.Parameters.AddWithValue("@Location", poco.Location);
                    cmd.Parameters.AddWithValue("@Job_Title", poco.JobTitle);
                    cmd.Parameters.AddWithValue("@Job_Description", poco.JobDescription);
                    cmd.Parameters.AddWithValue("@Start_Month", poco.StartMonth);
                    cmd.Parameters.AddWithValue("@Start_Year", poco.StartYear);
                    cmd.Parameters.AddWithValue("@End_Month", poco.EndMonth);
                    cmd.Parameters.AddWithValue("@End_Year", poco.EndYear);

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

        public IList<ApplicantWorkHistoryPoco> GetAll(params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            ApplicantWorkHistoryPoco[] pocos = new ApplicantWorkHistoryPoco[1000];
            SqlConnection connection = new SqlConnection(_connString);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"select* from Applicant_Work_History";
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int position = 0;
                while (reader.Read())
                {
                    ApplicantWorkHistoryPoco poco = new ApplicantWorkHistoryPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Applicant = reader.GetGuid(1);
                    poco.CompanyName = reader.GetString(2);
                    poco.CountryCode = reader.GetString(3);
                    poco.Location = reader.GetString(4);
                    poco.JobTitle = reader.GetString(5);
                    poco.JobDescription = reader.GetString(6);
                    poco.StartMonth = reader.GetByte(4);
                    poco.StartYear = reader.GetInt32(5);
                    poco.EndMonth = reader.GetByte(6);
                    poco.EndYear = reader.GetInt32(7);
                    poco.TimeStamp = (Byte[])reader[8];

                    pocos[position] = poco;
                    position++;
                }
                connection.Close();
                return pocos.Where(p=>p!=null).ToList();


            }
        }


        public IList<ApplicantWorkHistoryPoco> GetList(Expression<Func<ApplicantWorkHistoryPoco, bool>> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantWorkHistoryPoco GetSingle(Expression<Func<ApplicantWorkHistoryPoco, bool>> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantWorkHistoryPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }


        public void Remove(params ApplicantWorkHistoryPoco[] items)
        {
            SqlConnection connection = new SqlConnection(_connString);
            using (connection)
            {
                foreach (ApplicantWorkHistoryPoco poco in items)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = @"delete from Applicant_Work_History
                            where ID= @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void Update(params ApplicantWorkHistoryPoco[] items)
        {
            SqlConnection connection = new SqlConnection(_connString);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                foreach (ApplicantWorkHistoryPoco poco in items)
                {
                    cmd.CommandText = @"update Applicant_Work_History
                    set Applicant=@Applicant,
                    Company_Name=@Skill,
                    Country_Code=@Skill_Level,
                    Location=@Location,
                    Job_Title=@Job_Title,
                    Job_Description=@Job_Description,
                    Start_Month=@Start_Month,
                    End_month=@End_month,
                    Start_Year=@Start_Year,              
                    End_Year=@End_Year
                    where Id = @Id";
                    cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    cmd.Parameters.AddWithValue("@Company_Name", poco.CompanyName);
                    cmd.Parameters.AddWithValue("@Country_Code", poco.CountryCode);
                    cmd.Parameters.AddWithValue("@Location", poco.Location);
                    cmd.Parameters.AddWithValue("@Job_Title", poco.JobTitle);
                    cmd.Parameters.AddWithValue("@Job_Description", poco.JobDescription);
                    cmd.Parameters.AddWithValue("@Start_Month", poco.StartMonth);
                    cmd.Parameters.AddWithValue("@Start_Year", poco.StartYear); ;
                    cmd.Parameters.AddWithValue("@End_Month", poco.EndMonth);
                    cmd.Parameters.AddWithValue("@End_Year", poco.EndYear);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                }
            }

        }
    }
}
