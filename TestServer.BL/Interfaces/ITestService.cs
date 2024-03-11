using TestServer.DTO.General;

namespace TestServer.BL.Interfaces
{
    public interface ITestService
    {
        public IEnumerable<TestDTO> GetUsersTest(long id);
    }
}
