using MatrixOperations.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace MatrixCalculator.XamarinForms.ViewModels
{
    public class AdditionViewModel : BaseCalcutionViewModel
    {
        public override RealMatrix Calculate(RealMatrix matrix1, RealMatrix matrix2)
        {
            return matrix1 + matrix2;
        }
    }
}
