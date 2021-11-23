using MatrixOperations.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MatrixOperationsXamarinForms.ViewModels
{
    public abstract class BaseCalcutionViewModel : BaseViewModel
    {
        private Matrix<BindingContainer<double>> _matrix1;
        private Matrix<BindingContainer<double>> _matrix2;
        private Matrix<BindingContainer<double>> _resultMatrix;

        public ICommand CalculateCommand { get; private set; }
        public ICommand SetMatrix1SizeCommand { get; private set; }
        public ICommand SetMatrix2SizeCommand { get; private set; }

        public Matrix<BindingContainer<double>> Matrix1
        {
            get => _matrix1;
            set { SetProperty(ref _matrix1, value); }
        }

        public Matrix<BindingContainer<double>> Matrix2
        {
            get => _matrix2;
            set { SetProperty(ref _matrix2, value); }
        }

        public Matrix<BindingContainer<double>> ResultMatrix
        {
            get => _resultMatrix;
            set { SetProperty(ref _resultMatrix, value); }
        }

        public BindingContainer<int> WidthOfFirst { get; set; } = new BindingContainer<int>(3);
        public BindingContainer<int> WidthOfSecond { get; set; } = new BindingContainer<int>(3);
        public BindingContainer<int> HeightOfFirst { get; set; } = new BindingContainer<int>(3);
        public BindingContainer<int> HeightOfSecond { get; set; } = new BindingContainer<int>(3);

        public BaseCalcutionViewModel()
        {
            Matrix1 = new Matrix<BindingContainer<double>>(3, 3, new BindingContainer<double>[9].Select(e => new BindingContainer<double>()));
            Matrix2 = new Matrix<BindingContainer<double>>(3, 3, new BindingContainer<double>[9].Select(e => new BindingContainer<double>()));
            ResultMatrix = new Matrix<BindingContainer<double>>(0, 0);

            CalculateCommand = new Command(() =>
                {

                    var matrix1 = new RealMatrix(_matrix1.Width, _matrix1.Height, _matrix1.Select(e => e.Value));
                    var matrix2 = new RealMatrix(_matrix2.Width, _matrix2.Height, _matrix2.Select(e => e.Value));
                    RealMatrix resultMatrix = Calculate(matrix1, matrix2);

                    ResultMatrix = new Matrix<BindingContainer<double>>(
                           resultMatrix.Width,
                           resultMatrix.Height,
                           resultMatrix.Select(e => new BindingContainer<double>() { Value = e }));
                    OnPropertyChanged(nameof(ResultMatrix.Width));
                    OnPropertyChanged(nameof(ResultMatrix.Height));
                    OnPropertyChanged(nameof(ResultMatrix));

                }
            );

            SetMatrix1SizeCommand = new Command(() =>
                {
                    SetMatrixSize(ref _matrix1, WidthOfFirst.Value, HeightOfFirst.Value);
                    OnPropertyChanged(nameof(Matrix1));
                    OnPropertyChanged(nameof(Matrix1.Width));
                    OnPropertyChanged(nameof(Matrix1.Height));
                }
            );

            SetMatrix2SizeCommand = new Command(() =>
                {
                    SetMatrixSize(ref _matrix2, WidthOfSecond.Value, HeightOfSecond.Value);
                    OnPropertyChanged(nameof(Matrix2));
                    OnPropertyChanged(nameof(Matrix2.Width));
                    OnPropertyChanged(nameof(Matrix2.Height));
                }
           );
        }

        public abstract RealMatrix Calculate(RealMatrix matrix1, RealMatrix matrix2);

        private void SetMatrixSize(ref Matrix<BindingContainer<double>> matrix, int width, int height)
        {
            matrix = new Matrix<BindingContainer<double>>(width, height, new BindingContainer<double>[width * height].Select(e => new BindingContainer<double>()));
        }
    }
}
