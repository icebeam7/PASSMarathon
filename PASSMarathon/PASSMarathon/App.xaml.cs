using Xamarin.Forms;

namespace PASSMarathon
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.FaceView());
        }
    }
}
