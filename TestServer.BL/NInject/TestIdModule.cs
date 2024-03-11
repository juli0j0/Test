using Ninject.Modules;
using TestServer.DB.Interfaces.UnitOfWork;
using TestServer.DB.UnitOfWork;

namespace TestServer.BL.NInject
{
    internal class TestIdModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITestIdUnitOfWork>().To<TestIdUnitofWork>();
        }
    }
}
