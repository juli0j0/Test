using Microsoft.Data.SqlClient;
using TestServer.DTO;
using static System.Net.Mime.MediaTypeNames;
using TestServer.DTO.General;
using TestServer.DB.Interfaces.Repositories;

namespace TestServer.DB.Repositories
{
    public class TestIdRepository : ITestIdRepository
    {
        private readonly string databaseTest = "Test_Tests";
        private readonly string databaseUserTest = "Test_Users";
        private readonly string userTestTable = $"[{{0}}].[dbo].[User_{{1}}Test_{{2}}]";
        private readonly string testTable = $"[{{0}}].[dbo].[Test_{{1}}]";
        private readonly string connectionString = @$"Data Source=DESKTOP-8MEAJAS;Initial Catalog={{0}};Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
        private readonly string TestQuery = $"SELECT * FROM {{0}};";
        private readonly string CreateAnswer = $"CREATE TABLE {{0}} (NumberQuestion INT PRIMARY KEY, Answer NVARCHAR(MAX));";
        private readonly string AnswerQuery = $"INSERT INTO {{0}} (NumberQuestion, Answer) VALUES ({{1}}, '{{2}}');";
        public IEnumerable<TestIdDTO> GetTest(long id)
        {
            List<TestIdDTO> tests = new List<TestIdDTO>();
            string connString = string.Format(connectionString, databaseTest);
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string test = string.Format(testTable, databaseTest, id);
                    string query = string.Format(TestQuery, test);
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tests.Add(new TestIdDTO
                                {
                                    Number = reader.IsDBNull(reader.GetOrdinal("Number")) ? null : Convert.ToInt32(reader["Number"]),
                                    Text = reader.IsDBNull(reader.GetOrdinal("Text")) ? null : Convert.ToString(reader["Text"]),
                                    CorrectAnswer = reader.IsDBNull(reader.GetOrdinal("Text")) ? null : Convert.ToString(reader["Text"]),
                                    OtherAnswer = reader.IsDBNull(reader.GetOrdinal("Text")) ? null : Convert.ToString(reader["Text"]),
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

        public bool SendAnswers(IEnumerable<UserIdTestIdDTO> answer)
        {
            throw new NotImplementedException();
        }
    }
}
