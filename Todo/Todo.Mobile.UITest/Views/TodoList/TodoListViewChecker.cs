using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Todo.Mobile.UITests.Views.Common;

namespace Todo.Mobile.UITests.Views.TodoList
{
    public class TodoListViewChecker : BasicViewChecker
    {
        public TodoListViewLocator Locate;

        public TodoListViewChecker(AppUser appUser) : base(appUser)
        {
            Locate = new TodoListViewLocator();
            Locate.CreateInstance(AppUser.Platform);
        }

        public TodoListViewChecker YourRecentlyTaskIsShown(string name = "Buy_orange")
        {
            App.WaitForElement(Locate.TaskName, $"Timed out waiting for element {Locate.TaskName}",
                TimeSpan.FromSeconds(60));
            var appResult = App.Query(Locate.TaskName).First();
            Assert.AreEqual(appResult.Text, name);
            return this;
        }

        public TodoListViewChecker YourRecentlyTaskIsNOTShown(string name = "Buy_orange")
        {
            App.WaitForElement(Locate.TasksList, $"Timed out waiting for element {Locate.TasksList}",
                TimeSpan.FromSeconds(60));
            var appResult = App.Query(Locate.TaskName).ToList();
            var elem = appResult.FirstOrDefault(c => c.Text == name);
            Assert.IsTrue(elem == null);
            return this;
        }

        public TodoListViewChecker YourAllRecentlyTasksAreShown(List<string> tasks)
        {
            App.WaitForElement(Locate.TasksList, $"Timed out waiting for element {Locate.TasksList}",
                TimeSpan.FromSeconds(60));
            var appResult = App.Query(Locate.TaskName).ToList();
            var list = appResult.Where(l => tasks.ToList().Contains(l.Text));
            Assert.IsTrue(list.Count().Equals(tasks.Count()));
            return this;
        }

        public TodoListViewChecker YourRecentlyTaskIsDone()
        {
            App.WaitForElement(Locate.TasksList, $"Timed out waiting for element {Locate.TasksList}",
                TimeSpan.FromSeconds(60));
            var appResult = App.Query(Locate.DoneTask).ToList();
            Assert.IsTrue(appResult.Count() == 1);
            return this;
        }

    }
}
