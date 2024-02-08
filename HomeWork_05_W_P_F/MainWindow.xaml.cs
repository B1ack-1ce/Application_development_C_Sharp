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
            Answer.Content = 0;
        }
        private void CalculatorResult(object? sender, CalculatorArgs e)
        {
            
            if(e.Answer != (int)e.Answer)
            {
                e.Answer = Math.Round(e.Answer, 4);
            }
            Answer.Content = e.Answer;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Флаг для того, чтобы найти первый найденный символ точки или запятой.
            //Следом идущие символы игнорируются.
            bool isFound = false;
            var input = InputText.Text.Where(c => 
            {
                if(char.IsDigit(c))
                {
                    return true;
                }
                else if(c == ',' || c == '.' && !isFound) 
                {
                    isFound = true;
                    return true;
                }
                return false;
            });

            string res = string.Join("", input);

            //Заменяем точку, если она есть, на запятую для корректной работы с double
            if (res.Contains('.'))
                res = res.Replace('.', ',');

            string? name = (e.Source as FrameworkElement)?.Name;

            if(res.Length > 0)
            {
                //Убеждаемся, что знак стоит не в начале и не в конце
                if(res.StartsWith(',') || res.EndsWith(','))
                {
                    MessageBox.Show("Знак дробной части не может стоять в начале или в конце числа!");
                    InputText.Text = string.Empty;
                    return;
                }
            }
            else if(res.Equals("") && name != "Cancel" && name != "Reset")
            {
                MessageBox.Show("Некорректное значение!");
                InputText.Text = string.Empty;
                return;
            }

            double value = 0;
            double.TryParse(res, out value);

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