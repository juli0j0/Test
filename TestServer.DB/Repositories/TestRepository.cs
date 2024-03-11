using Microsoft.Data.SqlClient;
using TestServer.DB.Interfaces.Repositories;
using TestServer.DTO.General;

namespace TestServer.DB.Repositories
{
    internal class TestRepository : ITestRepository
    {
        private readonly string database = "Test_General";
        private readonly string userTestTable = "UserTestState";
        private readonly string testTable = "Tests";
        private readonly string connectionString = @$"Data Source=DESKTOP-8MEAJAS;Initial Catalog=Test_General;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
        private readonly string usersTestQuery = $"SELECT * FROM [{{0}}].[dbo].[{{1}}] T INNER JOIN [{{0}}].[dbo].[{{2}}] UTS ON T.Id = UTS.TestId WHERE UTS.UserId = {{3}};";

        public IEnumerable<TestDTO> GetUsersTest(long id)
        {
            List<TestDTO> tests = new List<TestDTO>();  
            string connString = string.Format(connectionString, database);
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    
                    string query = string.Format(usersTestQuery, database, testTable, userTestTable, id);
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tests.Add(new TestDTO
                                {
                                    Id = reader.IsDBNull(reader.GetOrdinal("Id")) ? null : Convert.ToInt64(reader["Id"]),
                                    Name = reader.IsDBNull(reader.GetOrdinal("Name")) ? null : Convert.ToString(reader["Name"])
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return tests;
        }

    }
}
