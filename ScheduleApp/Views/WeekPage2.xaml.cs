namespace ScheduleApp.Views;

public partial class WeekPage2 : ContentPage
{
	public WeekPage2()
    {
        InitializeComponent();

        BindingContext = new Models.Week2();

    }

    protected override void OnAppearing()
    {
        ((Models.Week2)BindingContext).LoadData();
    }
}