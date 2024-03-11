using TestServer.DTO;

namespace TestServer.DB.Interfaces.Repositories
{
    public interface ITestIdRepository
    {
        public IEnumerable<TestIdDTO> GetTest(long id);
        public bool SendAnswers(IEnumerable<UserIdTestIdDTO> answer);
    }
}
