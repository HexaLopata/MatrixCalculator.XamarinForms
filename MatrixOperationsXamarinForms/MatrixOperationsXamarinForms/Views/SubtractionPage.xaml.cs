using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MatrixOperationsXamarinForms.ViewModels;

namespace MatrixOperationsXamarinForms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubtractionPage : ContentPage
    {
        public SubtractionPage()
        {
            InitializeComponent();
            BindingContext = new SubtractionViewModel();
        }
    }
}