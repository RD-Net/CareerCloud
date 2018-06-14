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
    class ApplicantProfileRepository : BaseADO, IDataRepository<ApplicantProfilePoco>
    {
        public void Add(params ApplicantProfilePoco[] items)
        {
            SqlConnection connection = new SqlConnection(_connString);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                foreach (ApplicantProfilePoco poco in items)
                {
                    cmd.CommandText = @"Insert into Applicant_Profiles
               (Id, Login, Current_Salary,Current_Rate, Currency, Country_Code,
                State_Province, Street_Address, City_Town, Zip_Postal_Code)
                Values
                (@Id, @Login, @Current_Salary, @Current_Rate, @Currency, @Country_Code,
                @State_Province, @Street_Address, @City_Town, @Zip_Postal_Code)";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Login", poco.Login);
                    cmd.Parameters.AddWithValue("@Current_Salary", poco.CurrentSalary);
                    cmd.Parameters.AddWithValue("@Id", poco.CurrentRate);
                    cmd.Parameters.AddWithValue("@Id", poco.Currency);
                    cmd.Parameters.AddWithValue("@Country_Code", poco.Country);
                    cmd.Parameters.AddWithValue("@State_Province", poco.Province);
                    cmd.Parameters.AddWithValue("@Street_Address", poco.Street);
                    cmd.Parameters.AddWithValue("@City_Town", poco.City);
                    cmd.Parameters.AddWithValue("@Zip_Postal_Code", poco.PostalCode);

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

        public IList<ApplicantProfilePoco> GetAll(params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            ApplicantProfilePoco[] pocos = new ApplicantProfilePoco[1000];
            SqlConnection connection = new SqlConnection(_connString);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"select* from Applicant_Profile";
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int position = 0;
                while (reader.Read())
                {
                    ApplicantProfilePoco poco = new ApplicantProfilePoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Login = reader.GetGuid(1);
                    poco.CurrentSalary = (Decimal?)reader[2];
                    poco.CurrentRate = (Decimal?)reader[3];
                    poco.Currency = reader.GetString(4);
                    poco.Country = reader.GetString(5);
                    poco.Province = reader.GetString(6);
                    poco.Street = reader.GetString(7);
                    poco.City = reader.GetString(8);
                    poco.PostalCode = reader.GetString(9);
                    poco.TimeStamp = (Byte[])reader[10];

                    pocos[position] = poco;
                    position++;
                }
                connection.Close();
                return pocos.Where(p => p != null).ToList(); ;
            }

        }
        public IList<ApplicantProfilePoco> GetList(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();

        }

        public ApplicantProfilePoco GetSingle(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantProfilePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantProfilePoco[] items)
        {
            SqlConnection connection = new SqlConnection(_connString);
            using (connection)
            {
                foreach (ApplicantProfilePoco poco in items)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = @"delete from Applicant_Profiles
                            where ID= @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void Update(params ApplicantProfilePoco[] items)
        {
            SqlConnection connection = new SqlConnection(_connString);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                foreach (ApplicantProfilePoco poco in items)
                {
                    cmd.CommandText = @"update Applicant_Profiles
                    set Login=@Login,
                    Current_salary=@Current_Salary,
                    Current_Rate=@Current_Rate,
                    Currency=@Currency,
                    Country_Code=@Country_Code,
                    State_Province=@State_Province,
                    Street_Address=@Street_Address,
                    City_Address=@City_Address,
                    Zip_Postal_Code=@Zip_Postal_Code,
                    Time_Stamp=@Time_Stamp
                    where Id = @Id";
                    cmd.Parameters.AddWithValue("@Login", poco.Login);
                    cmd.Parameters.AddWithValue("@Current_Salary", poco.CurrentSalary);
                    cmd.Parameters.AddWithValue("@Current_Rate", poco.CurrentRate);
                    cmd.Parameters.AddWithValue("@Currency", poco.Currency);
                    cmd.Parameters.AddWithValue("@Country_Code", poco.Country);
                    cmd.Parameters.AddWithValue("@State_Province", poco.Province);
                    cmd.Parameters.AddWithValue("@Street_Address", poco.Street);
                    cmd.Parameters.AddWithValue("@City_Town", poco.City);
                    cmd.Parameters.AddWithValue("@Zip_Postal_Code", poco.PostalCode);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                }
            }
        }


    }
}
