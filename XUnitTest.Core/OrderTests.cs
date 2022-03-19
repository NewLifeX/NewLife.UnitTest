using System.Threading;
using NewLife.UnitTest;
using Xunit;

namespace XUnitTest
{
    [TestCaseOrderer("NewLife.UnitTest.TestOrderer", "NewLife.UnitTest")]
    public class OrderTests
    {
        [TestOrder(1)]
        [Fact]
        public void Test3() => Thread.Sleep(1000);

        [TestOrder(2)]
        [Fact]
        public void Test2() => Thread.Sleep(1000);

        [TestOrder(3)]
        [Fact]
        public void Test1() => Thread.Sleep(1000);

        [TestOrder(4)]
        [Fact]
        public void Test4() => Thread.Sleep(1000);
        
        [TestOrder(5)]
        [Fact]
        public void Test5() => Thread.Sleep(1000);
    }
}