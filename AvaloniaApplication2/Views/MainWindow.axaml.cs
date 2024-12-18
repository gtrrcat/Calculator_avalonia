using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace calc.Views
{
    public partial class MainWindow : Window
    {
        private readonly IDisplayErrorService _errorService;
        public string _currentInput = ""; // ������� ������ �����
        public string _operation = "";    // �������� (+, -, *, /)
        public double _firstNumber = 0;   // ������ �����

        public MainWindow(IDisplayErrorService errorService)
        {
            _errorService = errorService;
            InitializeComponent();
        }

            public MainWindow()
        {
            
            InitializeComponent();
        }

        // ���������� ��� ������

        private void OnButtonClick(object? sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Content is string buttonContent)
            {
                ButtonClick(buttonContent);
            }
        }

        // ������ ��������� ������
        public void ButtonClick(string buttonContent)
        {
            // ���� ������ ������ � ������
            if (double.TryParse(buttonContent, out _))
            {
                _currentInput += buttonContent;
                UpdateDisplay();
            }
            // ���� ������ ������ ","
            else if (buttonContent == ",")
            {
                if (!_currentInput.Contains(","))
                {
                    _currentInput += string.IsNullOrEmpty(_currentInput) ? "0," : ",";
                    UpdateDisplay();
                }
            }
            // ���� ������ ������ ��������
            else if (buttonContent == "+" || buttonContent == "-" || buttonContent == "*" || buttonContent == "/")
            {
                if (!string.IsNullOrEmpty(_currentInput))
                {
                    _firstNumber = double.Parse(_currentInput);  // �������� ������� �� �����
                    _operation = buttonContent;
                    _currentInput = "";
                }
            }
            // ���� ������ ������ "="
            else if (buttonContent == "=")
            {
                
                if (!string.IsNullOrEmpty(_currentInput) && !string.IsNullOrEmpty(_operation))
                {
                    double secondNumber = double.Parse(_currentInput);  // �������� ������� �� �����
                    try
                    {
                        
                        double result = _operation switch
                        {
                            "+" => _firstNumber + secondNumber,
                            "-" => _firstNumber - secondNumber,
                            "*" => _firstNumber * secondNumber,
                            "/" => Math.Abs(secondNumber) < 1e-8 ? throw new ArithmeticException("���������� ������ �� �����, ������� 10e-8.") :  _firstNumber / secondNumber,
                            _ => 0
                        };
                        _currentInput = result.ToString();  // �������� ����� �� ������� ��� ������
                        _operation = ""; // ���������� ��������

                    }
                    catch (ArithmeticException ex)
                    {
                        // ������� ������ � ���� �����
                        _currentInput = ex.Message;
                        _errorService.DisplayError(ex.Message);
                    }
                }

            }
            // ���� ������ ������ "C" (�������)
            else if (buttonContent == "C")
            {
                _currentInput = "";
                _firstNumber = 0;
                _operation = "";
                UpdateDisplay();
            }
            UpdateDisplay();
        }

        // ���������� ���� ����� (TextBox)
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
