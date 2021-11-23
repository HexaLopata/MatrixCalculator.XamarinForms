using MatrixOperations.BL;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixOperationsXamarinForms.ViewModels
{
    public class SubtractionViewModel : BaseCalcutionViewModel
    {
        public override RealMatrix Calculate(RealMatrix matrix1, RealMatrix matrix2)
        {
            return matrix1 - matrix2;
        }
    }
}
