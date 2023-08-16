namespace Tutorial_EventDerivedClass;

//파생 클래스에서 기본 클래스 이벤트를 발생하는 방법
//https://docs.microsoft.com/ko-kr/dotnet/csharp/programming-guide/events/how-to-raise-base-class-events-in-derived-classes


// 이벤트 정보를 담을 클래스 정의
public class ShapeEventArgs
{
    public ShapeEventArgs(double area)
    {
        NewArea = area;
    }

    public double NewArea { get; }
}

// 이벤트를 발행하는 클래스
public abstract class Shape
{
    protected double _area;

    public double Area
    {
        get => _area;
        set => _area = value;
    }

    public event EventHandler<ShapeEventArgs> ShapeChanged;

    public abstract void Draw();

    protected virtual void OnShapeChanged(ShapeEventArgs e)
    {
        ShapeChanged?.Invoke(this, e);
    }
}

public class Circle : Shape
{
    private double _radius;

    public Circle(double radius)
    {
        _radius = radius;
        _area = 3.14 * _radius * _radius;
    }

    public void Update(double d)
    {
        _radius = d;
        _area = 3.14 * _radius * _radius;
        OnShapeChanged(new ShapeEventArgs(_area));
    }

    protected override void OnShapeChanged(ShapeEventArgs e)
    {
        base.OnShapeChanged(e);
    }

    public override void Draw()
    {
        Console.WriteLine("Drawing a circle");
    }
}

public class Rectangle : Shape
{
    private double _length;
    private double _width;

    public Rectangle(double length, double width)
    {
        _length = length;
        _width = width;
        _area = _length * _width;
    }

    public void Update(double length, double width)
    {
        _length = length;
        _width = width;
        _area = _length * _width;
        OnShapeChanged(new ShapeEventArgs(_area));
    }

    protected override void OnShapeChanged(ShapeEventArgs e)
    {
        base.OnShapeChanged(e);
    }

    public override void Draw()
    {
        Console.WriteLine("Drawing a rectangle");
    }
}

// 이벤트 구독 클래스
public class ShapeContainer
{
    private readonly List<Shape> _list;

    public ShapeContainer()
    {
        _list = new List<Shape>();
    }

    public void AddShape(Shape shape)
    {
        _list.Add(shape);

        // shape.ShapeChanged 이벤트에 이벤트 핸들러(HandleShapeChanged 메서드)를 구독
        shape.ShapeChanged += HandleShapeChanged;
    }

    private void HandleShapeChanged(object sender, ShapeEventArgs e)
    {
        if (sender is Shape shape)
        {
            Console.WriteLine($"Received event. Shape area is now {e.NewArea}");

            shape.Draw();
        }
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        //Create the event publishers and subscriber
        var circle = new Circle(54);
        var rectangle = new Rectangle(12, 9);
        var container = new ShapeContainer();

        // Add the shapes to the container.
        container.AddShape(circle);
        container.AddShape(rectangle);

        // Cause some events to be raised.
        circle.Update(57);
        rectangle.Update(7, 7);

        // Keep the console window open in debug mode.
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }



}
