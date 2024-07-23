using HoneyPotForms.Entities;
using HoneyPotForms.Shapes;

namespace HoneyPotForms.Builders;

public class HoneyPotBuilder
{
    private readonly List<Hexagon> _pots = new();
    public static HoneyPotBuilder Create() => new();
    public HoneyPotBuilder AddPot(Hexagon pot)
    {
        _pots.Add(pot);
        return this;
    }

    public HoneyPot Build() => new(_pots);
}