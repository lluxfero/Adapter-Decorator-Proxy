RealImage realImage = new();
realImage.Display();
Console.WriteLine();

ProxyImage proxyImage = new(realImage);
proxyImage.Display();


public interface IImage
{
    void Display();
}

// Реальный Субъект
class RealImage : IImage
{
    public void Display()
    {
        Console.WriteLine("Отображение RealImage..");
    }
}

class ProxyImage : IImage
{
    private RealImage _realImage;

    public ProxyImage(RealImage realImage)
    {
        this._realImage = realImage;
    }

    public void Display()
    {
        this._realImage.Display();
        this.Logging();
    }

    public void Logging()
    {
        Console.WriteLine($"{DateTime.Now}: RealImage было отображено");
    }
}