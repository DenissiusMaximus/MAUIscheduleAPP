using ScheduleApp.Models;
using System.ComponentModel;
using CommunityToolkit.Maui.Alerts;

namespace ScheduleApp.Views
{
    public partial class SetSchedule : ContentPage, INotifyPropertyChanged
    {
        private const string TextEditorKey = "TextEditorContent";

        public SetSchedule()
        {
            InitializeComponent();
            BindingContext = this;

            TextEditor.Text = Preferences.Get(TextEditorKey, string.Empty);
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var text = TextEditor.Text;
            try
            {
                var toast = Toast.Make("Паршу... Секунду...");
                await toast.Show();
                ScrapSchedule.saveToJson(text);

                Preferences.Set(TextEditorKey, text);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }

            
            await Shell.Current.GoToAsync("..");
        }

        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }

    }
}