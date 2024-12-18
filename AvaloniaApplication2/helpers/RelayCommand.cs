using System;
using System.Windows.Input;

namespace CalculatorApp.Helpers
{
    public class RelayCommand<T> : System.Windows.Input.ICommand
    {
        private readonly Action<T> _execute;

#pragma warning disable CS8618 // ѕоле, не допускающее значени€ NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. –ассмотрите возможность добавлени€ модификатора "required" или объ€влени€ значени€, допускающего значение NULL.
        public RelayCommand(Action<T> execute)
#pragma warning restore CS8618 // ѕоле, не допускающее значени€ NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. –ассмотрите возможность добавлени€ модификатора "required" или объ€влени€ значени€, допускающего значение NULL.
        {
            _execute = execute;
        }

#pragma warning disable CS8612 // ƒопустимость значени€ NULL дл€ ссылочных типов в типе не совпадает с €вно реализованным членом.
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS8612 // ƒопустимость значени€ NULL дл€ ссылочных типов в типе не совпадает с €вно реализованным членом.

#pragma warning disable CS8767 // ƒопустимость значений NULL дл€ ссылочных типов в типе параметра не соответствует не€вно реализованному элементу (возможно, из-за атрибутов допустимости значений NULL).
        public bool CanExecute(object parameter) => true;
#pragma warning restore CS8767 // ƒопустимость значений NULL дл€ ссылочных типов в типе параметра не соответствует не€вно реализованному элементу (возможно, из-за атрибутов допустимости значений NULL).

#pragma warning disable CS8767 // ƒопустимость значений NULL дл€ ссылочных типов в типе параметра не соответствует не€вно реализованному элементу (возможно, из-за атрибутов допустимости значений NULL).
        public void Execute(object parameter)
#pragma warning restore CS8767 // ƒопустимость значений NULL дл€ ссылочных типов в типе параметра не соответствует не€вно реализованному элементу (возможно, из-за атрибутов допустимости значений NULL).
        {
            if (parameter is T value)
            {
                _execute(value);
            }
        }
    }
}

