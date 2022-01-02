using System;
using System.Collections.Generic;
using Xamarin.Forms;
using MatrixCalculator.XamarinForms.ViewModels;
using MatrixCalculator.XamarinForms.Views;

namespace MatrixCalculator.XamarinForms
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AdditionPage), typeof(AdditionPage));
        }
    }
}
