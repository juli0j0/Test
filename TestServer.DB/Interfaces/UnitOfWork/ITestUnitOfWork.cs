using TestServer.DTO.General;

namespace TestServer.DB.Interfaces.UnitOfWork
{
    public interface ITestUnitOfWork
    {
        IEnumerable<TestDTO> GetUsersTest(long id);
    }
}
