namespace ScheduleApp
{
    public partial class AppShell : Shell
    {


        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Views.SetSchedule), typeof(Views.SetSchedule));

        }

        private async void SetSchedule(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(SetSchedule));
        }
    }
}
