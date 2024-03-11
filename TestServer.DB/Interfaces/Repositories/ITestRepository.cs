using TestServer.DTO.General;

namespace TestServer.DB.Interfaces.Repositories
{
    public interface ITestRepository
    {
        IEnumerable<TestDTO> GetUsersTest(long id);
    }
}
