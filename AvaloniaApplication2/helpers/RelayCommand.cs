using System;
using System.Windows.Input;

namespace CalculatorApp.Helpers
{
    public class RelayCommand<T> : System.Windows.Input.ICommand
    {
        private readonly Action<T> _execute;

#pragma warning disable CS8618 // ����, �� ����������� �������� NULL, ������ ��������� ��������, �������� �� NULL, ��� ������ �� ������������. ����������� ����������� ���������� ������������ "required" ��� ���������� ��������, ������������ �������� NULL.
        public RelayCommand(Action<T> execute)
#pragma warning restore CS8618 // ����, �� ����������� �������� NULL, ������ ��������� ��������, �������� �� NULL, ��� ������ �� ������������. ����������� ����������� ���������� ������������ "required" ��� ���������� ��������, ������������ �������� NULL.
        {
            _execute = execute;
        }

#pragma warning disable CS8612 // ������������ �������� NULL ��� ��������� ����� � ���� �� ��������� � ���� ������������� ������.
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS8612 // ������������ �������� NULL ��� ��������� ����� � ���� �� ��������� � ���� ������������� ������.

#pragma warning disable CS8767 // ������������ �������� NULL ��� ��������� ����� � ���� ��������� �� ������������� ������ �������������� �������� (��������, ��-�� ��������� ������������ �������� NULL).
        public bool CanExecute(object parameter) => true;
#pragma warning restore CS8767 // ������������ �������� NULL ��� ��������� ����� � ���� ��������� �� ������������� ������ �������������� �������� (��������, ��-�� ��������� ������������ �������� NULL).

#pragma warning disable CS8767 // ������������ �������� NULL ��� ��������� ����� � ���� ��������� �� ������������� ������ �������������� �������� (��������, ��-�� ��������� ������������ �������� NULL).
        public void Execute(object parameter)
#pragma warning restore CS8767 // ������������ �������� NULL ��� ��������� ����� � ���� ��������� �� ������������� ������ �������������� �������� (��������, ��-�� ��������� ������������ �������� NULL).
        {
            if (parameter is T value)
            {
                _execute(value);
            }
        }
    }
}

