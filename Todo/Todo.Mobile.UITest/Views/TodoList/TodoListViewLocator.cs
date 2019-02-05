using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Todo.Mobile.UITests.Views.TodoList
{
    public class TodoListViewLocator
    {
        public Func<AppQuery, AppQuery> AddButton { get; set; }
        public Func<AppQuery, AppQuery> TasksList { get; set; }
        public Func<AppQuery, AppQuery> TaskName { get; set; }
        public Func<AppQuery, AppQuery> DoneTask { get; set; }


        public TodoListViewLocator CreateInstance(Platform platform)
        {
            if (platform == Platform.Android)
            {

                AddButton = c => c.Id("NoResourceEntry-0");
                TasksList = c => c.Marked("TodoList_Container");
                TaskName = c => c.Marked("TodoItemName");
                DoneTask = c => c.Marked("TaskDone");
            }
            else
            {
                AddButton = c => c.Id("AddButton");
                TasksList = c => c.Id("TodoList");
                TaskName = c => c.Id("TodoItemName");
                DoneTask = c => c.Marked("TaskDone");
            }
            return this;
        }
    }
}
