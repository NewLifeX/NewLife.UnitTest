using System;

namespace NewLife.UnitTest
{
    /// <summary>测试顺序。升序</summary>
    /// <remarks>
    /// 提供测试用例排序支持：
    /// [TestCaseOrderer("NewLife.UnitTest.TestOrderer", "NewLife.UnitTest")]
    /// </remarks>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class TestOrderAttribute : Attribute
    {
        /// <summary>测试顺序。升序</summary>
        public Int32 Order { get; private set; }

        /// <summary>测试顺序。升序</summary>
        /// <param name="order"></param>
        public TestOrderAttribute(Int32 order) => Order = order;
    }
}