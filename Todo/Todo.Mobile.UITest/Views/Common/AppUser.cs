using System;
using System.Configuration;
using Todo.Mobile.UITests.Views.TodoList;
using Xamarin.UITest;

namespace Todo.Mobile.UITests.Views.Common
{
    public class AppUser
    {
        public AppUser()
        {
            Platform = GetSelectedPlatform();
            App = AppInitializer.StartApp(Platform);
        }

        public Platform Platform { get; }

        public IApp App { get; }

        public TodoListView VisitTodoView() => new TodoListView(this);

        private Platform GetSelectedPlatform()
        {
            if (!Enum.TryParse(ConfigurationManager.AppSettings["platform"], true, out Platform platform))
             {
                 throw new Exception("A platform must be specified in App.config");
             }
            return platform;
        }
    }
}
