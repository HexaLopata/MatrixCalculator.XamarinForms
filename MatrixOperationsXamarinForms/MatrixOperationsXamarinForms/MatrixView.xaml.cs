using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatrixView : ContentView
    {
        public static readonly BindableProperty WidthInCellsProperty = BindableProperty.Create("WidthInCells",
            typeof(int), typeof(MatrixView), 0);

        public static readonly BindableProperty HeightInCellsProperty = BindableProperty.Create("HeightInCells",
            typeof(int), typeof(MatrixView), 0);

        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create("ItemsSource",
            typeof(IEnumerable), typeof(MatrixView), new object[0, 0]);

        public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create("ItemTemplate",
            typeof(DataTemplate), typeof(MatrixView), new DataTemplate());

        public int WidthInCells
        {
            get { return (int)GetValue(WidthInCellsProperty); }
            set { SetValue(WidthInCellsProperty, value); }
        }

        public int HeightInCells
        {
            get { return (int)GetValue(HeightInCellsProperty); }
            set { SetValue(HeightInCellsProperty, value); }
        }

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        public MatrixView()
        {
            InitializeComponent();
            UpdateGrid();
            this.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(WidthInCells) || e.PropertyName == nameof(HeightInCells) ||
                    e.PropertyName == nameof(ItemsSource))
                    UpdateGrid();
            };
        }

        private void UpdateGrid()
        {
            if (HeightInCells != mainGrid.RowDefinitions.Count)
            {
                mainGrid.RowDefinitions.Clear();
                var rowDefinition = new RowDefinition() { Height = 40 };
                for (int i = 0; i < HeightInCells; i++)
                    mainGrid.RowDefinitions.Add(rowDefinition);
            }

            if (Width != mainGrid.ColumnDefinitions.Count)
            {
                mainGrid.ColumnDefinitions.Clear();
                var columnDefinition = new ColumnDefinition() { Width = 40 };
                for (int i = 0; i < WidthInCells; i++)
                    mainGrid.ColumnDefinitions.Add(columnDefinition);
            }

            mainGrid.Children.Clear();
            var x = 0;
            var y = 0;
            foreach (var item in ItemsSource)
            {
                var newItem = (View)ItemTemplate.CreateContent();
                newItem.BindingContext = item;
                newItem.SetValue(Grid.ColumnProperty, x);
                newItem.SetValue(Grid.RowProperty, y);
                mainGrid.Children.Add(newItem);
                x++;
                if (x == WidthInCells)
                {
                    x = 0;
                    y++;
                }
            }
        }
    }
}