using TestServer.DTO;

namespace TestServer.BL.Interfaces
{
    public interface ITestIdService
    {
        public IEnumerable<TestIdDTO> GetTest(long id);
    }
}
