using Xamarin.Forms;

namespace Todo
{
	public class TodoItemPageCS : ContentPage
	{
		public TodoItemPageCS()
		{
			Title = "Todo Item";

			var nameEntry = new Entry();
            nameEntry.SetBinding(Entry.TextProperty, "Name");
            nameEntry.AutomationId = "NameField";

			var notesEntry = new Entry();
            notesEntry.SetBinding(Entry.TextProperty, "Notes");
            notesEntry.AutomationId = "NotesField";

			var doneSwitch = new Switch();
			doneSwitch.SetBinding(Switch.IsToggledProperty, "Done");
            doneSwitch.AutomationId = "DoneToggle";

			var saveButton = new Button { Text = "Save" , AutomationId = "SaveButton"};
			saveButton.Clicked += async (sender, e) =>
			{
				var todoItem = (TodoItem)BindingContext;
				await App.Database.SaveItemAsync(todoItem);
				await Navigation.PopAsync();
			};

			var deleteButton = new Button { Text = "Delete" , AutomationId = "DeleteButton"};
			deleteButton.Clicked += async (sender, e) =>
			{
				var todoItem = (TodoItem)BindingContext;
				await App.Database.DeleteItemAsync(todoItem);
				await Navigation.PopAsync();
			};

            var cancelButton = new Button { Text = "Cancel", AutomationId = "CancelButton" };
			cancelButton.Clicked += async (sender, e) =>
			{
				await Navigation.PopAsync();
			};

			var speakButton = new Button { Text = "Speak" };
			speakButton.Clicked += (sender, e) =>
			{
				var todoItem = (TodoItem)BindingContext;
				DependencyService.Get<ITextToSpeech>().Speak(todoItem.Name + " " + todoItem.Notes);
			};

			Content = new StackLayout
			{
				Margin = new Thickness(20),
				VerticalOptions = LayoutOptions.StartAndExpand,
				Children =
				{
					new Label { Text = "Name" },
					nameEntry,
					new Label { Text = "Notes" },
					notesEntry,
					new Label { Text = "Done" },
					doneSwitch,
					saveButton,
					deleteButton,
					cancelButton,
					speakButton
				}
			};
		}
	}
}
