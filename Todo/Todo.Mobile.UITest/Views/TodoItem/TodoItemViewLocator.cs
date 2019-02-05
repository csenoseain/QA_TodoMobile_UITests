using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Todo.Mobile.UITests.Views.TodoItem
{
    public class TodoItemViewLocator
    {
        public Func<AppQuery, AppQuery> NameText { get; set; }
        public Func<AppQuery, AppQuery> NameField { get; set; }

        public Func<AppQuery, AppQuery> NotesText { get; set; }
        public Func<AppQuery, AppQuery> NotesField { get; set; }
        public Func<AppQuery, AppQuery> DoneSwitch { get; set; }


        public Func<AppQuery, AppQuery> SaveButton { get; set; }
        public Func<AppQuery, AppQuery> DeleteButton { get; set; }
        public Func<AppQuery, AppQuery> CancelButton { get; set; }

        public TodoItemViewLocator CreateInstance(Platform platform)
        {
            if (platform == Platform.Android)
            {

                NameText = c => c.Marked("NameText_Container");
                NameField = c => c.Marked("NameField_Container");
                NotesText = c => c.Marked("NotesField_Container");
                NotesField = c => c.Marked("NotesField_Container");
                DoneSwitch = c => c.Marked("DoneToggle_Container");
                SaveButton = c => c.Marked("SaveButton_Container");
                DeleteButton = c => c.Marked("DeleteButton_Container");
                CancelButton = c => c.Marked("CancelButton_Container");
            }
            else
            {
                NameText = c => c.Text("Name");
                NameField = c => c.Id("NameField");
                NotesText = c => c.Text("Note");
                NotesField = c => c.Id("NotesField");
                DoneSwitch = c => c.Id("DoneToggle");
                SaveButton = c => c.Id("SaveButton");
                DeleteButton = c => c.Id("DeleteButton");
                CancelButton = c => c.Id("CancelButton");
            }
            return this;
        }
    }
}
