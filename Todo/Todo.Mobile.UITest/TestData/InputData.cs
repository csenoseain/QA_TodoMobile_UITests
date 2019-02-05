using System.Collections.Generic;
using NUnit.Framework;

namespace Todo.Mobile.UITests.TestData
{
    public class InputData
    {
        public static IEnumerable<TestCaseData> FormData()
        {
            yield return new TestCaseData("Buy_orange", "Buy_orange_notes");
            yield return new TestCaseData("Buy_apples", "Buy_apples_notes");
            yield return new TestCaseData("Buy_milk", "Buy_milk_notes");
        }
    }
}
