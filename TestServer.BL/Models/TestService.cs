using Ninject;
using TestServer.BL.Interfaces;
using TestServer.BL.NInject;
using TestServer.DB.Interfaces.UnitOfWork;
using TestServer.DTO.General;

namespace TestServer.BL.Models
{
    public class TestService : ITestService
    {
        private readonly ITestUnitOfWork _unitOfWork;

        public TestService() 
        {
            var module = new TestModule();
            var kernel = new StandardKernel(module);

            _unitOfWork = kernel.Get<ITestUnitOfWork>();
        }

        public IEnumerable<TestDTO> GetUsersTest(long id)
        {
            return _unitOfWork.GetUsersTest(id);
        }
    }
}
