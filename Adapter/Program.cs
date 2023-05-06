FahrenheitThermometer adaptee = new();
IRussianThermometer thermometer = new FromFahToCelAdapter(adaptee);

Console.WriteLine(thermometer.GetCelsius());


// Интерфейс, с которым может работать клиент
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
        return (int)Math.Round((this._adapteeFahrenheitThermometer.GetFahrenheit() - 32) * 5 / (double)9);
    }
}
