using System;
using Todo.Mobile.UITests.Views.Common;
using Todo.Mobile.UITests.Views.TodoList;

namespace Todo.Mobile.UITests.Views.TodoItem
{
    public class TodoItemView : BasicView
    {
        public TodoItemViewLocator Locate = new TodoItemViewLocator();
        public TodoItemView(AppUser appUser) : base(appUser)
        {
            Locate = new TodoItemViewLocator();
            Locate.CreateInstance(AppUser.Platform);
        }

        public TodoItemView EnterTaskName(string name = "Buy_orange")
        {
            App.WaitForElement(Locate.NameField, $"Timed out waiting for element {Locate.NameField}",
               TimeSpan.FromSeconds(60));
            App.ClearText(Locate.NameField);
            App.EnterText(Locate.NameField, name);
            return this;
        }

        public TodoItemView EnterTaskNotes(string notes = "Buy_orange_Notes")
        {
            App.ClearText(Locate.NotesField);
            App.EnterText(Locate.NotesField, notes);
            return this;
        }

        public TodoItemView SwitchOnDone()
        {
            App.Tap(Locate.DoneSwitch);
            return this;
        }

        public TodoListView TapOnSaveButtonAndGoToHome()
        {
            App.Tap(Locate.SaveButton);
            return new TodoListView(AppUser);
        }

        public TodoListView TapOnDeleteButtonAndGoToHome()
        {
            App.Tap(Locate.DeleteButton);
            return new TodoListView(AppUser);
        }

        public TodoItemView TapOnCancelButtonAndGoToHome()
        {
            App.Tap(Locate.CancelButton);
            return new TodoItemView(AppUser);
        }

    }
}
