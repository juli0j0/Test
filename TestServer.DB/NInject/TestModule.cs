using Ninject.Modules;
using TestServer.DB.Interfaces.Repositories;
using TestServer.DB.Repositories;

namespace TestServer.DB.NInject
{
    internal class TestModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ITestRepository>().To<TestRepository>();
        }
    }
}
