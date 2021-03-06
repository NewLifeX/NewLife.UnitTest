using System;
using System.Collections.Generic;
using System.Linq;
using NewLife.Log;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace NewLife.UnitTest
{
    /// <summary>优先级顺序测试排序器</summary>
    /// <remarks>
    /// 提供测试用例排序支持：
    /// [TestCaseOrderer("NewLife.UnitTest.PriorityOrderer", "NewLife.UnitTest")]
    /// </remarks>
    public class PriorityOrderer : ITestCaseOrderer
    {
        /// <summary>对测试用例进行排序</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="testCases"></param>
        /// <returns></returns>
        public IEnumerable<T> OrderTestCases<T>(IEnumerable<T> testCases) where T : ITestCase
        {
            // 所有测试用例
            var ts = testCases.ToList();
            var dic2 = new SortedDictionary<Int32, List<T>>();

            // 借助反射，拿到方法列表，此时为方法在源码中出现顺序。
            // 需要注意，方法对象不唯一，需要拼接名称字符串
            var types = new List<String>();
            foreach (var item in ts)
            {
                var cls = item.TestMethod?.TestClass?.Class;
                if (cls != null && !types.Contains(cls.Name))
                {
                    types.Add(cls.Name);
                }
            }

            XTrace.WriteLine("使用[PriorityOrderer/优先级顺序]测试: {0}, 用例：{1}", types.Join(), ts.Count);

            var assemblyName = typeof(TestOrderAttribute).AssemblyQualifiedName!;
            var dic = new SortedDictionary<Int32, List<T>>();
            foreach (var testCase in testCases)
            {
                var priority = 0;
                var atts = testCase.TestMethod.Method.GetCustomAttributes(assemblyName).ToList();
                foreach (var att in atts)
                {
                    var n = att.GetNamedArgument<Int32>(nameof(TestOrderAttribute.Priority));
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