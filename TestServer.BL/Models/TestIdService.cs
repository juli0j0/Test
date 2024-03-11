using Ninject;
using TestServer.BL.Interfaces;
using TestServer.BL.NInject;
using TestServer.DB.Interfaces.UnitOfWork;
using TestServer.DTO;

namespace TestServer.BL.Models
{
    public class TestIdService : ITestIdService
    {
        private readonly ITestIdUnitOfWork _unitOfWork;

        public TestIdService()
        {
            var module = new TestIdModule();
            var kernel = new StandardKernel(module);

            _unitOfWork = kernel.Get<ITestIdUnitOfWork>();
        }
        public IEnumerable<TestIdDTO> GetTest(long id)
        {
           return _unitOfWork.GetTest(id);
        }
    }
}
