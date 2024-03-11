using Ninject;
using TestServer.DB.Interfaces.Repositories;
using TestServer.DB.Interfaces.UnitOfWork;
using TestServer.DB.NInject;
using TestServer.DTO.General;

namespace TestServer.DB.UnitOfWork
{
    public class TestUnitOfWork : ITestUnitOfWork
    {
        private ITestRepository _repository;

        public TestUnitOfWork()
        {
            var module = new TestModule();
            var kernel = new StandardKernel(module);

            _repository = kernel.Get<ITestRepository>();
        }
        public IEnumerable<TestDTO> GetUsersTest(long id)
        {
            return _repository.GetUsersTest(id);
        }
    }
}
