var announcement1 = new FireSafetyAnnouncement();
Console.WriteLine(announcement1.Hang()); 
// Повешены правила "О пожарной безопасности.."
Console.WriteLine();

RedFrameAnnouncementDecorator decorator1 = new(announcement1);
A4SheetAnnouncementDecorator decorator2 = new(decorator1);
Console.WriteLine(decorator2.Hang()); 
// Повешены правила "О пожарной безопасности.." в красной рамке формата А4

var announcement2 = new AlarmAnnouncement();
A4SheetAnnouncementDecorator decorator3 = new(announcement2);
Console.WriteLine(decorator3.Hang()); 
// Повешено объявление "Проверка сигнализации.." формата А4


// Базовый интерфейс Компонента определяет поведение, которое изменяется декораторами
public abstract class Announcement
{
    public string Name { get; set; }
    public Announcement(string t)
    {
        this.Name = t;
    }
    public abstract string Hang();
}

// Конкретные Компоненты предоставляют реализации поведения по умолчанию.
// Может быть несколько вариаций этих классов.
class FireSafetyAnnouncement : Announcement
{
    public FireSafetyAnnouncement() : base("О пожарной безопасности..")
    { }
    public override string Hang()
    {
        return $"Повешены правила \"{Name}\"";
    }
}
class AlarmAnnouncement : Announcement
{
    public AlarmAnnouncement() : base("Проверка сигнализации..")
    { }
    public override string Hang()
    {
        return $"Повешено объявление \"{Name}\"";
    }
}
// Базовый класс Декоратора следует тому же интерфейсу, что и другие
// компоненты. Основная цель этого класса - определить интерфейс обёртки для
// всех конкретных декораторов. Реализация кода обёртки по умолчанию может
// включать в себя поле для хранения завёрнутого компонента и средства его
// инициализации.
abstract class Decorator : Announcement
{
    protected Announcement _component;

    public Decorator(Announcement component) : base(component.Name)
    {
        this._component = component;
    }

    // Декоратор делегирует всю работу обёрнутому компоненту.
    public override string Hang()
    {
        return this._component.Hang();
    }
}

// Конкретные Декораторы вызывают обёрнутый объект и изменяют его результат
// некоторым образом.
class RedFrameAnnouncementDecorator : Decorator
{
    public RedFrameAnnouncementDecorator(Announcement component) : base(component)
    {
    }

    public override string Hang()
    {
        return $"{base.Hang()} в красной рамке";
    }
}

class A4SheetAnnouncementDecorator : Decorator
{
    public A4SheetAnnouncementDecorator(Announcement component) : base(component)
    {
    }

    public override string Hang()
    {
        return $"{base.Hang()} формата А4";
    }
}
