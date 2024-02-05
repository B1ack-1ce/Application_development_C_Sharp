using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HomeWork_05_W_P_F
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Calculator calculator;
        public MainWindow()
        {
            InitializeComponent();
            calculator = new Calculator();
            calculator.EventResult += CalculatorResult;
        }
        private void CalculatorResult(object? sender, CalculatorArgs e)
        {
            Answer.Content = e.Answer;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string input = InputText.Text;
            StringBuilder res = new StringBuilder();

            foreach (char c in input)
            {
                if (c >= '0' && c <= '9')
                    res.Append(c);
            }
            int value = 0;
            if(res.Length > 0)
                int.TryParse(res.ToString(), out value);

            string? name = (e.Source as FrameworkElement)?.Name;
            switch (name)
            {
                case "Add":
                    calculator.Add(value);
                    InputText.Text = string.Empty;
                    break;
                case "Sub":
                    calculator.Sub(value);
                    InputText.Text = string.Empty;
                    break;
                case "Multi":
                    calculator.Multi(value);
                    InputText.Text = string.Empty;
                    break;
                case "Div":
                    calculator.Div(value);
                    InputText.Text = string.Empty;
                    break;
                case "Cancel":
                    calculator.Cancel();
                    InputText.Text = string.Empty;
                    break;
                case "Reset":
                    calculator.Reset();
                    InputText.Text = string.Empty;
                    break;
                default:
                    MessageBox.Show($"Неизвестная операция: {name}", "Ошибка ввода");
                    break;
            }
        }

        
    }
}