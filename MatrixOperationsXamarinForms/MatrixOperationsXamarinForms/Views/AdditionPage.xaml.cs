using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinTest.ViewModels;

namespace XamarinTest.Views
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