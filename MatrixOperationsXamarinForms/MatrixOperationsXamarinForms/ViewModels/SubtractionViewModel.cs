using MatrixOperations.BL;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinTest.ViewModels
{
    public class SubtractionViewModel : BaseCalcutionViewModel
    {
        public override IntMatrix Calculate(IntMatrix matrix1, IntMatrix matrix2)
        {
            return matrix1 - matrix2;
        }
    }
}
