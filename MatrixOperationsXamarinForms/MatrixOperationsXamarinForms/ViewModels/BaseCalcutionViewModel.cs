using MatrixOperations.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinTest.ViewModels
{
    public abstract class BaseCalcutionViewModel : BaseViewModel
    {
        private Matrix<BindingContainer<int>> _matrix1;
        private Matrix<BindingContainer<int>> _matrix2;
        private Matrix<BindingContainer<int>> _resultMatrix;

        public ICommand CalculateCommand { get; private set; }
        public ICommand SetMatrix1SizeCommand { get; private set; }
        public ICommand SetMatrix2SizeCommand { get; private set; }

        public Matrix<BindingContainer<int>> Matrix1
        {
            get => _matrix1;
            set { SetProperty(ref _matrix1, value); }
        }

        public Matrix<BindingContainer<int>> Matrix2
        {
            get => _matrix2;
            set { SetProperty(ref _matrix2, value); }
        }

        public Matrix<BindingContainer<int>> ResultMatrix
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
            Matrix1 = new Matrix<BindingContainer<int>>(3, 3, new BindingContainer<int>[9].Select(e => new BindingContainer<int>()));
            Matrix2 = new Matrix<BindingContainer<int>>(3, 3, new BindingContainer<int>[9].Select(e => new BindingContainer<int>()));
            ResultMatrix = new Matrix<BindingContainer<int>>(0, 0);

            CalculateCommand = new Command(() =>
                {

                    var matrix1 = new IntMatrix(_matrix1.Width, _matrix1.Height, _matrix1.Select(e => e.Value));
                    var matrix2 = new IntMatrix(_matrix2.Width, _matrix2.Height, _matrix2.Select(e => e.Value));
                    IntMatrix resultMatrix = Calculate(matrix1, matrix2);

                    ResultMatrix = new Matrix<BindingContainer<int>>(
                           resultMatrix.Width,
                           resultMatrix.Height,
                           resultMatrix.Select(e => new BindingContainer<int>() { Value = e }));
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

        public abstract IntMatrix Calculate(IntMatrix matrix1, IntMatrix matrix2);

        private void SetMatrixSize(ref Matrix<BindingContainer<int>> matrix, int width, int height)
        {
            matrix = new Matrix<BindingContainer<int>>(width, height, new BindingContainer<int>[width * height].Select(e => new BindingContainer<int>()));
        }
    }
}
