namespace DesignPatterns.Lib.Patterns.Basic;

public class FactoryExample
{
    private readonly Factory factory;
    public FactoryExample()
    {
        factory = new ShapeFactory();
    }

    public Factory GetFactory() => factory;
}

public abstract class Factory : IDesignPattern
{
    public abstract string GetPatternOutput();
}

public class ShapeFactory : Factory
{
    public override string GetPatternOutput()
    {
        return GetShape(nameof(Rectangle)).GetType().FullName;
    }

    public IShape GetShape(string shapeType)
    {
        if (shapeType == null)
        {
            return null;
        }

        if (shapeType.Equals(nameof(Circle)))
        {
            return new Circle();
        }

        if (shapeType.Equals(nameof(Rectangle)))
        {
            return new Rectangle();
        }

        if (shapeType.Equals(nameof(Square)))
        {
            return new Square();
        }

        return new DefaultShape();
    }
}

public interface IShape
{
    void Draw();
}

public class DefaultShape : Circle
{

}

public class Circle : IShape
{
    public void Draw()
    {
        //draw a circle
    }
}

public class Square : IShape
{
    public void Draw()
    {
        //draw a square
    }
}

public class Rectangle : IShape
{
    public void Draw()
    {
        //draw a square
    }
}