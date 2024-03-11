using Ninject.Modules;
using TestServer.DB.Interfaces.UnitOfWork;
using TestServer.DB.UnitOfWork;

namespace TestServer.BL.NInject
{
    internal class TestModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITestUnitOfWork>().To<TestUnitOfWork>();
        }
    }
}
