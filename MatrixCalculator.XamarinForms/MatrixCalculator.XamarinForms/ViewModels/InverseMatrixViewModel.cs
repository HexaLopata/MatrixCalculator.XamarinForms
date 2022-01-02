using MatrixOperations.BL;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixCalculator.XamarinForms.ViewModels
{
    public class InverseMatrixViewModel : BaseCalcutionViewModel
    {
        public override RealMatrix Calculate(RealMatrix matrix1, RealMatrix matrix2)
        {
            return matrix1.Inversed;
        }
    }
}
