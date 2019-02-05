using System;
using System.Linq;
using Todo.Mobile.UITests.Views.Common;
using Todo.Mobile.UITests.Views.TodoItem;

namespace Todo.Mobile.UITests.Views.TodoList
{
    public class TodoListView : BasicView
    {
        public TodoListViewLocator Locate;

        public TodoListView(AppUser appUser) : base(appUser)
        {
            Locate = new TodoListViewLocator();
            Locate.CreateInstance(AppUser.Platform);
        }
        public TodoItemView TapOnCreateTask()
        {
            App.WaitForElement(Locate.AddButton, $"Timed out waiting for element {Locate.AddButton}",
                 TimeSpan.FromSeconds(60));
            App.Tap(Locate.AddButton);
            return new TodoItemView(AppUser);
        }

        public TodoItemView TapOnPreviousTaskCreated(string name)
        {
            App.WaitForElement(Locate.TasksList, $"Timed out waiting for element {Locate.TasksList}",
                TimeSpan.FromSeconds(60));
            var appResult = App.Query(Locate.TaskName).ToList();
            var elem = appResult.FirstOrDefault(c => c.Text == name);
            App.Tap(elem.Id);
            return new TodoItemView(AppUser);
        }

        public TodoListViewChecker Verify()
        {
            return new TodoListViewChecker(AppUser);
        }

    }
}
