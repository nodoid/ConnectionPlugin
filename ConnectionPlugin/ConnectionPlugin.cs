using Plugin.Connectivity.Abstractions;
using Xamarin.Forms;
using Plugin.Connectivity;

namespace ConnectionPlugin
{
    public class App : Application
    {
        public event ConnectivityChangedEventHandler ConnectivityChanged;

        public bool IsConnected { get; set; } = CrossConnectivity.Current.IsConnected;

        public static App Self { get; set; }

        public App()
        {
            App.Self = this;

            // as the connection needs to be handled at the "highest" point of the app, place the
            // event in the App singleton. In this example, I broadcast a message that anywhere in the app can hook into

            ConnectivityChanged += (object sender, ConnectivityChangedEventArgs e) =>
            {
                MessagingCenter.Send<App, string>(this, "Connection", e.IsConnected ? "Connected" : "Not connected");
            };

            MainPage = new NavigationPage(new StatePage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

