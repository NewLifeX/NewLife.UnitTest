using System.Threading;
using NewLife.UnitTest;
using Xunit;

namespace XUnitTest
{
    [TestCaseOrderer("NewLife.UnitTest.DefaultOrderer", "NewLife.UnitTest")]
    public class MethodOrderTests
    {
        [TestOrder(1)]
        [Fact]
        public void Test3() => Thread.Sleep(1000);

        [TestOrder(2)]
        [Fact]
        public void Test2() => Thread.Sleep(1000);

        [Fact]
        public void Test1() => Thread.Sleep(1000);

        [Fact]
        public void Test4() => Thread.Sleep(1000);
        
        [Fact]
        public void Test5() => Thread.Sleep(1000);
    }
}