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

//creator class
public abstract class Dashboard
{
    //factory method: CreateDiagram
    public abstract Diagram CreateDiagram();

    //Share is a functionality to share the dashboard with another person.
    public void Share()
    {
        var diagram = CreateDiagram();

        var relevantData = diagram.GetDiagramData();

        //do something with the relevant        
    }
}

public class EmailDashboard : Dashboard
{
    public override Diagram CreateDiagram()
    {
        return new EmailsDiagram();
    }
}

public class ApplicationAlertsDashboard : Dashboard
{
    public override Diagram CreateDiagram()
    {
        return new ErrorDiagram();
    }
}

public class LogsDashboard : Dashboard
{
    public override Diagram CreateDiagram()
    {
        return new LogsDiagram();
    }
}

public interface Diagram
{
    object GetDiagramData();
}

public class LogsDiagram : Diagram
{
    public object GetDiagramData()
    {
        {
            return "[Some XML/JSON/etc. with relevant data]";
        }
    }
}

public class ErrorDiagram : Diagram
{
    public object GetDiagramData()
    {
        return "Some information about errors here";
    }
}

public class EmailsDiagram : Diagram
{
    public object GetDiagramData()
    {
        return "Some diagram showing a chart of emails sent through a given period";
    }
}

// OOP Factory
public class ShapeFactory : Factory
{
    public override string GetPatternOutput()
    {
        return GetShape(nameof(Rectangle)).GetType().FullName;
    }

    //sample factory method to get a shape
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