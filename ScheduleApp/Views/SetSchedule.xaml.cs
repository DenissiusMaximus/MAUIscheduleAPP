using ScheduleApp.Models;

namespace ScheduleApp.Views;

public partial class SetSchedule : ContentPage
{

    public SetSchedule()
	{
		InitializeComponent();
	}

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync("..");
    }  
    
    private async void CancelButton_Clicked(object sender, EventArgs e)
    {
        

        await Shell.Current.GoToAsync("..");
    }
}