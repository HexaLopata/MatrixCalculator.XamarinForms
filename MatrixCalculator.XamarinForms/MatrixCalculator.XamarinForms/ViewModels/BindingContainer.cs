using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MatrixCalculator.XamarinForms.ViewModels
{
    public class BindingContainer<T> : BindableObject
    {
        public BindingContainer() { }

        public static readonly BindableProperty ValueProperty =
                               BindableProperty.Create("Value", typeof(T), typeof(BindingContainer<T>), default(T));
        public BindingContainer(T value)
        {
            Value = value;
        }

        public T Value
        {
            get { return (T)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
    }
}
