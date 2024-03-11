using TestServer.DTO;

namespace TestServer.DB.Interfaces.UnitOfWork
{
    public interface ITestIdUnitOfWork 
    {
        IEnumerable<TestIdDTO> GetTest(long id);
    }
}
