using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace calc.Views
{
    public partial class MainWindow : Window
    {
        private readonly IDisplayErrorService _errorService;
        public string _currentInput = ""; // Текущая строка ввода
        public string _operation = "";    // Операция (+, -, *, /)
        public double _firstNumber = 0;   // Первое число

        public MainWindow(IDisplayErrorService errorService)
        {
            _errorService = errorService;
            InitializeComponent();
        }

            public MainWindow()
        {
            
            InitializeComponent();
        }

        // Обработчик для кнопок

        private void OnButtonClick(object? sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Content is string buttonContent)
            {
                ButtonClick(buttonContent);
            }
        }

        // Логика обработки кнопок
        public void ButtonClick(string buttonContent)
        {
            // Если нажата кнопка с цифрой
            if (double.TryParse(buttonContent, out _))
            {
                _currentInput += buttonContent;
                UpdateDisplay();
            }
            // Если нажата кнопка ","
            else if (buttonContent == ",")
            {
                if (!_currentInput.Contains(","))
                {
                    _currentInput += string.IsNullOrEmpty(_currentInput) ? "0," : ",";
                    UpdateDisplay();
                }
            }
            // Если нажата кнопка операции
            else if (buttonContent == "+" || buttonContent == "-" || buttonContent == "*" || buttonContent == "/")
            {
                if (!string.IsNullOrEmpty(_currentInput))
                {
                    _firstNumber = double.Parse(_currentInput);  // Заменяем запятую на точку
                    _operation = buttonContent;
                    _currentInput = "";
                }
            }
            // Если нажата кнопка "="
            else if (buttonContent == "=")
            {
                
                if (!string.IsNullOrEmpty(_currentInput) && !string.IsNullOrEmpty(_operation))
                {
                    double secondNumber = double.Parse(_currentInput);  // Заменяем запятую на точку
                    try
                    {
                        
                        double result = _operation switch
                        {
                            "+" => _firstNumber + secondNumber,
                            "-" => _firstNumber - secondNumber,
                            "*" => _firstNumber * secondNumber,
                            "/" => Math.Abs(secondNumber) < 1e-8 ? throw new ArithmeticException("Невозможно делить на число, меньшее 10e-8.") :  _firstNumber / secondNumber,
                            _ => 0
                        };
                        _currentInput = result.ToString();  // Заменяем точку на запятую для вывода
                        _operation = ""; // Сбрасываем операцию

                    }
                    catch (ArithmeticException ex)
                    {
                        // Выводим ошибку в поле ввода
                        _currentInput = ex.Message;
                        _errorService.DisplayError(ex.Message);
                    }
                }

            }
            // Если нажата кнопка "C" (очистка)
            else if (buttonContent == "C")
            {
                _currentInput = "";
                _firstNumber = 0;
                _operation = "";
                UpdateDisplay();
            }
            UpdateDisplay();
        }

        // Обновление поля ввода (TextBox)
        private void UpdateDisplay()
        {
            var display = this.FindControl<TextBox>("Display");
            if (display != null)
            {
                display.Text = _currentInput;
            }
        }
    }
    public interface IDisplayErrorService
    {
        void DisplayError(string message);
    }
}
