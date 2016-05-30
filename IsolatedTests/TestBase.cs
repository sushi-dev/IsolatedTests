
namespace Sushi.IsolatedTests
{
    using System;
    using System.Diagnostics;

    public abstract class TestBase : MarshalByRefObject
    {
        public abstract void Execute();

        public TimeSpan RunTest()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            this.Execute();
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }
    }
}
