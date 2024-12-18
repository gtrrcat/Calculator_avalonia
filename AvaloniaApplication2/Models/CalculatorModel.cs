namespace CalculatorApp.Models
{
    public class CalculatorModel
    {
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }
        public string Operation { get; set; } = "";

        // Поле для текущего ввода (включая числа с точкой)
        public string CurrentInput { get; private set; } = "";

        /// <summary>
        /// Добавляет цифру или точку в текущий ввод.
        /// </summary>
        /// <param name="input">Ввод пользователя (цифра или ".").</param>
        public void AppendToInput(string input)
        {
            if (input == ".")
            {
                // Если точки ещё нет, добавляем её
                if (!CurrentInput.Contains("."))
                {
                    CurrentInput += string.IsNullOrEmpty(CurrentInput) ? "0." : ".";
                }
            }
            else
            {
                // Добавляем цифры
                CurrentInput += input;
            }
        }

        /// <summary>
        /// Сбрасывает текущий ввод и операции.
        /// </summary>
        public void Clear()
        {
            CurrentInput = "";
            FirstNumber = 0;
            SecondNumber = 0;
            Operation = "";
        }

        /// <summary>
        /// Устанавливает текущую операцию и сохраняет первое число.
        /// </summary>
        /// <param name="operation">Операция (+, -, *, /).</param>
        public void SetOperation(string operation)
        {
            if (!string.IsNullOrEmpty(CurrentInput))
            {
                FirstNumber = double.Parse(CurrentInput);
                Operation = operation;
                CurrentInput = "";
            }
        }

        /// <summary>
        /// Выполняет вычисление на основе текущей операции.
        /// </summary>
        /// <returns>Результат вычисления.</returns>
        public double Calculate()
        {
            if (!string.IsNullOrEmpty(CurrentInput))
            {
                SecondNumber = double.Parse(CurrentInput);
            }

            return Operation switch
            {
                "+" => FirstNumber + SecondNumber,
                "-" => FirstNumber - SecondNumber,
                "*" => FirstNumber * SecondNumber,
                "/" => SecondNumber != 0 ? FirstNumber / SecondNumber : double.NaN,
                _ => 0
            };
        }
    }
}
