using NUnit.Framework;

namespace Todo.Mobile.UITests.Views.Common
{
    public class UITest
    {
        public AppUser App { get; private set; }

        [SetUp]
        public void BaseSetUp()
        {
            App = new AppUser();
        }
    }
}
