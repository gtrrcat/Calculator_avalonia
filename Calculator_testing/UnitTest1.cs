using Avalonia.Controls;
using Avalonia.ReactiveUI;
using Avalonia.Headless;
using Moq;
using Xunit;
using calc.Views;
using Avalonia.Headless.XUnit;
using System.Globalization;

public class MainWindowTests
{
    
    
    [AvaloniaFact]
    public void ButtonClick_ShouldTriggerDisplayError_WhenDivisionByZero()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
       
        // Создаем мок-сервис для отображения ошибок
        var mockErrorService = new Mock<IDisplayErrorService>();

        // Создаем экземпляр MainWindow
        var mainWindow = new MainWindow(mockErrorService.Object);
       // mainWindow.Show();
        mainWindow.ButtonClick("1");
        mainWindow.ButtonClick("/");
        mainWindow.ButtonClick("0");
        mainWindow.ButtonClick("=");
        Console.WriteLine(mainWindow._currentInput);
        Assert.Equal("Невозможно делить на число, меньшее 10e-8.", mainWindow._currentInput);
        


    }
    [AvaloniaFact]
    public void ButtonClick_Multiply()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Создаем мок-сервис для отображения ошибок
        var mockErrorService = new Mock<IDisplayErrorService>();

        // Создаем экземпляр MainWindow
        var mainWindow = new MainWindow(mockErrorService.Object);
        // mainWindow.Show();
        mainWindow.ButtonClick("42");
        mainWindow.ButtonClick("*");
        mainWindow.ButtonClick("3");
        mainWindow.ButtonClick("=");
        Console.WriteLine(mainWindow._currentInput);
        Assert.Equal("126", mainWindow._currentInput);



    }
    [AvaloniaFact]
    public void ButtonClick_Comma()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Создаем мок-сервис для отображения ошибок
        var mockErrorService = new Mock<IDisplayErrorService>();

        // Создаем экземпляр MainWindow
        var mainWindow = new MainWindow(mockErrorService.Object);
        // mainWindow.Show();
        mainWindow.ButtonClick("2,");
        mainWindow.ButtonClick("*");
        mainWindow.ButtonClick("3");
        mainWindow.ButtonClick("=");
        Console.WriteLine(mainWindow._currentInput);
        Assert.Equal("6", mainWindow._currentInput);



    }
    [AvaloniaFact]
    public void ButtonClick_C()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Создаем мок-сервис для отображения ошибок
        var mockErrorService = new Mock<IDisplayErrorService>();

        // Создаем экземпляр MainWindow
        var mainWindow = new MainWindow(mockErrorService.Object);
        // mainWindow.Show();
        mainWindow.ButtonClick("2,2131");
        mainWindow.ButtonClick("*");
        mainWindow.ButtonClick("C");
        Console.WriteLine(mainWindow._currentInput);
        Assert.Equal("", mainWindow._currentInput);



    }
    [AvaloniaFact]
    public void ButtonClick_Void()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Создаем мок-сервис для отображения ошибок
        var mockErrorService = new Mock<IDisplayErrorService>();

        // Создаем экземпляр MainWindow
        var mainWindow = new MainWindow(mockErrorService.Object);
        // mainWindow.Show();
        mainWindow.ButtonClick("+");
        mainWindow.ButtonClick("=");
        Console.WriteLine(mainWindow._currentInput);
        Assert.Equal("", mainWindow._currentInput);



    }
}
