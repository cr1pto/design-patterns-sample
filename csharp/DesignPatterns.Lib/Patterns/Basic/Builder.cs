namespace DesignPatterns.Lib.Patterns.Basic;

public class BuilderExample : IDesignPattern
{
    public string GetPatternOutput()
    {
        var result = new Director(new CarBuilder());

        var car = result.MakeCar(new CarBuilder());

        return car.GetType().FullName;
    }
}

//Use a builder when you have a super complex object that could end up 
// creating an unknown number of sub-classes
public interface Builder
{
    void Reset();
    T Build<T>() where T : class;

}

public class Director
{
    private Builder builder;

    public Director(Builder builder)
    {

    }

    public void ChangeBuilder(Builder builder)
    {

    }

    public Car MakeCar(CarBuilder carBuilder)
    {
        carBuilder.Reset();

        return carBuilder.Build<Car>();
    }
}

public class Car
{
}

public class Manual
{

}

public class CarBuilder : Builder
{
    private Car car;

    public T Build<T>() where T : class
    {
        return car as T;
    }

    public void Reset()
    {
        this.car = new Car();
    }
}

public class CarManualBuilder : Builder
{
    private Manual manual;

    public void Reset()
    {
        this.manual = new Manual();
    }

    public T Build<T>() where T : class
    {
        return manual as T;
    }
}

