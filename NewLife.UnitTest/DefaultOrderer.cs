using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace NewLife.UnitTest
{
    /// <summary>默认顺序</summary>
    /// <remarks>
    /// 默认排序（按方法在类内出现的顺序）：
    /// [TestCaseOrderer("NewLife.UnitTest.DefaultOrderer", "NewLife.UnitTest")]
    /// </remarks>
    public class DefaultOrderer : ITestCaseOrderer
    {
        /// <summary>对测试用例进行排序</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="testCases"></param>
        /// <returns></returns>
        public IEnumerable<T> OrderTestCases<T>(IEnumerable<T> testCases) where T : ITestCase => testCases;
    }
}