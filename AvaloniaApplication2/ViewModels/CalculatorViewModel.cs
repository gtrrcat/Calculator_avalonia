using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CalculatorApp.Models;
using CalculatorApp.Helpers;

namespace CalculatorApp.ViewModels
{
	
    public partial class CalculatorViewModel : INotifyPropertyChanged
    {
        private string _input = "";
        private CalculatorModel _calculator = new();
        private string _display = "0";

#pragma warning disable CS8612 // Допустимость значения NULL для ссылочных типов в типе не совпадает с явно реализованным членом.
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS8612 // Допустимость значения NULL для ссылочных типов в типе не совпадает с явно реализованным членом.

        // Команда для ввода
        public ICommand InputCommand { get; }
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Рассмотрите возможность добавления модификатора "required" или объявления значения, допускающего значение NULL.
        public CalculatorViewModel()
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Рассмотрите возможность добавления модификатора "required" или объявления значения, допускающего значение NULL.
        {
		    InputCommand = new RelayCommand<string>(Input);
		}

        // Отображаемое значение на экране
        public string Display
        {
            get => _display;
            set
            {
                _display = value;
                OnPropertyChanged();
            }
        }

        // Обработчик ввода кнопок
        public void Input(string value)
        {
            if (double.TryParse(value, out _))
            {
                _input += value;
                Display = _input;
            }
            else if (value == "C")
            {
                Clear();
            }
            else if (value == "=")
            {
                _calculator.SecondNumber = double.Parse(_input);
                Display = _calculator.Calculate().ToString();
                _input = "";
            }
            else // Это операция
            {
                _calculator.FirstNumber = double.Parse(_input);
                _calculator.Operation = value;
                _input = "";
            }
        }

        // Очистка
        private void Clear()
        {
            _input = "";
            _calculator = new CalculatorModel();
            Display = "0";
        }

        // Метод для уведомления об изменении свойств
#pragma warning disable CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
#pragma warning restore CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

