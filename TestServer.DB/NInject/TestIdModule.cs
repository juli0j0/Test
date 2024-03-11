using Ninject.Modules;
using TestServer.DB.Interfaces.Repositories;
using TestServer.DB.Repositories;

namespace TestServer.DB.NInject
{
    internal class TestIdModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ITestIdRepository>().To<TestIdRepository>();
        }
    }
}
