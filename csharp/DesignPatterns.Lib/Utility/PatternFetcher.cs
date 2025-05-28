using DesignPatterns.Lib.Patterns.Basic;

namespace DesignPatterns.Lib.Utility;

public interface IPatternFetcher
{
    object FetchPattern(string name);
}
public class PatternFetcher : IPatternFetcher
{
    public object FetchPattern(string name)
    {
        var processed = string.IsNullOrWhiteSpace(name) ? "" : name.ToUpper();

        if (processed == nameof(Factory).ToUpper())
        {
            return new FactoryExample().GetFactory().GetPatternOutput();
        }

        if (processed == nameof(Adapter).ToUpper())
        {
            return new AdapterExample();
        }

        return new FactoryExample();
    }
}