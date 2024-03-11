using Ninject;
using TestServer.DB.Interfaces.Repositories;
using TestServer.DB.Interfaces.UnitOfWork;
using TestServer.DB.NInject;
using TestServer.DTO;

namespace TestServer.DB.UnitOfWork
{
    public class TestIdUnitofWork : ITestIdUnitOfWork
    {
        private ITestIdRepository _repository;

        public TestIdUnitofWork()
        {
            var module = new TestIdModule();
            var kernel = new StandardKernel(module);

            _repository = kernel.Get<ITestIdRepository>();
        }
        public IEnumerable<TestIdDTO> GetTest(long id)
        {
            return _repository.GetTest(id);
        }
    }
}
