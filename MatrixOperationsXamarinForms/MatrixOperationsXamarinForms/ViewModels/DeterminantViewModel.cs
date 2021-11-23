using MatrixOperations.BL;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixOperationsXamarinForms.ViewModels
{
    class DeterminantViewModel : BaseCalcutionViewModel
    {
        public override RealMatrix Calculate(RealMatrix matrix1, RealMatrix matrix2)
        {
            var det = matrix1.Determinant;
            var result = new RealMatrix(1, 1);
            result[0, 0] = det;
            return result;
        }
    }
}
