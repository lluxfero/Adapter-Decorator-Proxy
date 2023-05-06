FahrenheitThermometer adaptee = new();
IRussianThermometer thermometer = new FromFahToCelAdapter(adaptee);

Console.WriteLine(thermometer.GetCelsius());


// Интерфейс, с которым может работать клиентский
public interface IRussianThermometer
{
    int GetCelsius();
}

// Адаптируемый класс
class FahrenheitThermometer
{
    public int GetFahrenheit()
    {
        //измерения
        Random random = new((int)DateTime.Now.Ticks);
        return random.Next(-60, 120);
    }
}

// Адаптер делает интерфейс Адаптируемого класса совместимым с целевым интерфейсом
class FromFahToCelAdapter : IRussianThermometer
{
    private readonly FahrenheitThermometer _adapteeFahrenheitThermometer;

    public FromFahToCelAdapter(FahrenheitThermometer adaptee)
    {
        this._adapteeFahrenheitThermometer = adaptee;
    }

    public int GetCelsius()
    {
        int value = this._adapteeFahrenheitThermometer.GetFahrenheit();
        Console.WriteLine($"* градусов в Фаренгейтах: {value}\n");
        return (int)Math.Round((value - 32) * 5 / (double)9);
    }
}

