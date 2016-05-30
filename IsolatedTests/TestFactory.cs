using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sushi.IsolatedTests
{
    public sealed class TestFactory : IDisposable
    {
        private AppDomain appDomain;

        public TestFactory()
        {
            var appDomainSetup = new AppDomainSetup { ApplicationBase = AppDomain.CurrentDomain.BaseDirectory };

            this.appDomain = AppDomain.CreateDomain("Test Factory", null, appDomainSetup);
        }

        public TestBase CreateTest<T>() where T : TestBase
        {
            var type = typeof(T);
            return (TestBase)this.appDomain.CreateInstanceAndUnwrap(type.Assembly.FullName, type.FullName);
        }

        public void Dispose()
        {
            if (this.appDomain != null)
            {
                AppDomain.Unload(this.appDomain);
            }
        }
    }
}
