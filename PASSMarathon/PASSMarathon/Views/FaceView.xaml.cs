using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PASSMarathon.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FaceView : ContentPage
    {
        public FaceView()
        {
            InitializeComponent();

            BindingContext = new ViewModels.FaceViewModel();
        }
    }
}