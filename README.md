# AgentFire.Wpf.ValueConverters
Ultimate base class for WPF IValueConverter interface along with some useful implementations.

Usage:

Simple way:

```cs
using AgentFire.Wpf.ValueConverters;
using System.Windows;

class BooleanToVisibilityConverter : ValueConverterBase<bool, Visibility>
{
    protected override Visibility Convert(bool source)
    {
        return source ? Visibility.Visible : Visibility.Collpased;
    }
}
```
    
Advanced way:

```cs
using AgentFire.Wpf.ValueConverters;

class Foo
{
    public int Bar { get; set; }
}

// Create classes like this if you need a simple one-way or two-way conversion.
class FooToIntConverter : ValueConverterBase<Foo, int>
{
    // Abstract method - you have to override it.
    protected override int Convert(Foo source)
    {
        return source.Bar;
    }

    // Virtual method - overridance is not required.
    // The base implementation will throw a NotImplementedException, which means you should not leave it non-overridden when the binding might need a backwards conversion.
    protected override Foo ConvertBack(int source)
    {
        return new Foo() { Bar = source };
    }
}

// Create classeslikethis if you need a parametrized one- or two-way conversion.
class FooToIntConverter2 : ParameterizedValueConverterBase<Foo, int, double>
{
    protected override int Convert(Foo source, double parameter)
    {
        return (int)(source.Bar * parameter);
    }

    protected override Foo ConvertBack(int source, double parameter)
    {
        return new Foo() { Bar = (int)(source / parameter) };
    }
}
```
