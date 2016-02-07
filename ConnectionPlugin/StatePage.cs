using Xamarin.Forms;

namespace ConnectionPlugin
{
    public class StatePage : ContentPage
    {
        Label connected;

        // always put anything to do with MessagingCenter in OnAppearing and OnDisappearing

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<App, string>(this, "Connection", (s, e) =>
            {
                // the message has been received, so change the text. It is on the UI thread not out of it.
                Device.BeginInvokeOnMainThread(() => connected.Text = e);
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<App, string>(this, "Connection");
        }

        public StatePage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            if (Device.OS == TargetPlatform.iOS)
                Padding = new Thickness(0, 20, 0, 0);

            var state = new Label
            {
                Text = "You are currently",
                FontSize = 18,
                TextColor = Color.Red
            };
            connected = new Label
            {
                Text = App.Self.IsConnected ? "Connected" : "Not Connected",
                FontSize = 18,
                TextColor = Color.Blue
            };

            Content = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Children = {
                    state, connected
                }
            };
        }
    }
}


