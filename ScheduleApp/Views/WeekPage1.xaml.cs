using System.Diagnostics;

namespace ScheduleApp.Views;

public partial class WeekPage1 : ContentPage
{
	public WeekPage1()
	{
        InitializeComponent();

        BindingContext = new Models.Week1();

    }

    protected override void OnAppearing()
    {
        ((Models.Week1)BindingContext).LoadData();
    }


}