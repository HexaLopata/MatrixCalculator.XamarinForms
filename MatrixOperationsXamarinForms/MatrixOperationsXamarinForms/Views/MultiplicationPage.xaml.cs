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
    public partial class MultiplicationPage : ContentPage
    {
        public MultiplicationPage()
        {
            InitializeComponent();
            BindingContext = new MultiplicationViewModel();
        }
    }
}