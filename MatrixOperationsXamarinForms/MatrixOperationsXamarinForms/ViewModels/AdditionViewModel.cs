using MatrixOperations.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace XamarinTest.ViewModels
{
    public class AdditionViewModel : BaseCalcutionViewModel
    {
        public override IntMatrix Calculate(IntMatrix matrix1, IntMatrix matrix2)
        {
            return matrix1 + matrix2;
        }
    }
}
