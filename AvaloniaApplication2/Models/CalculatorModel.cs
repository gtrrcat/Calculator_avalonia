namespace CalculatorApp.Models
{
    public class CalculatorModel
    {
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }
        public string Operation { get; set; } = "";

        // ���� ��� �������� ����� (������� ����� � ������)
        public string CurrentInput { get; private set; } = "";

        /// <summary>
        /// ��������� ����� ��� ����� � ������� ����.
        /// </summary>
        /// <param name="input">���� ������������ (����� ��� ".").</param>
        public void AppendToInput(string input)
        {
            if (input == ".")
            {
                // ���� ����� ��� ���, ��������� �
                if (!CurrentInput.Contains("."))
                {
                    CurrentInput += string.IsNullOrEmpty(CurrentInput) ? "0." : ".";
                }
            }
            else
            {
                // ��������� �����
                CurrentInput += input;
            }
        }

        /// <summary>
        /// ���������� ������� ���� � ��������.
        /// </summary>
        public void Clear()
        {
            CurrentInput = "";
            FirstNumber = 0;
            SecondNumber = 0;
            Operation = "";
        }

        /// <summary>
        /// ������������� ������� �������� � ��������� ������ �����.
        /// </summary>
        /// <param name="operation">�������� (+, -, *, /).</param>
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
        /// ��������� ���������� �� ������ ������� ��������.
        /// </summary>
        /// <returns>��������� ����������.</returns>
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
