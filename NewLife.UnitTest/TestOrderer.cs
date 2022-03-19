using System;
using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace NewLife.UnitTest
{
    /// <summary>优先级顺序</summary>
    /// <remarks>
    /// 提供测试用例排序支持：
    /// [TestCaseOrderer("NewLife.UnitTest.TestOrderer", "NewLife.UnitTest")]
    /// </remarks>
    public class TestOrderer : ITestCaseOrderer
    {
        /// <summary>对测试用例进行排序</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="testCases"></param>
        /// <returns></returns>
        public IEnumerable<T> OrderTestCases<T>(IEnumerable<T> testCases) where T : ITestCase
        {
            var assemblyName = typeof(TestOrderAttribute).AssemblyQualifiedName!;
            var dic = new SortedDictionary<Int32, List<T>>();
            foreach (var testCase in testCases)
            {
                var priority = 0;
                var atts = testCase.TestMethod.Method.GetCustomAttributes(assemblyName).ToList();
                foreach (var att in atts)
                {
                    var n = att.GetNamedArgument<Int32>(nameof(TestOrderAttribute.Order));
                    if (n != 0) priority = n;
                }

                if (!dic.TryGetValue(priority, out var list)) list = dic[priority] = new List<T>();

                list.Add(testCase);
            }

            foreach (var testCase in dic.SelectMany(e => e.Value.OrderBy(x => x.TestMethod.Method.Name)))
            {
                yield return testCase;
            }
        }
    }
}