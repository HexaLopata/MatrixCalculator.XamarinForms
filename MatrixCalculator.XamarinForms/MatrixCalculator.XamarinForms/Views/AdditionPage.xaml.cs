using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MatrixCalculator.XamarinForms.ViewModels;

namespace MatrixCalculator.XamarinForms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdditionPage : ContentPage
    {
        object context = new AdditionViewModel();
        public AdditionPage()
        {
            InitializeComponent();
            BindingContext = context;
        }
    }
}