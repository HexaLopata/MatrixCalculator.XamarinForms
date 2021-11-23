using System;
using System.Collections.Generic;
using Xamarin.Forms;
using MatrixOperationsXamarinForms.ViewModels;
using MatrixOperationsXamarinForms.Views;

namespace MatrixOperationsXamarinForms
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
