using HoneyPotForms.Entities;
using HoneyPotForms.Interfaces;

namespace HoneyPotForms.Builders;

public class HoneyPotBuilder
{
    private readonly List<ICentroidCalculable> _pots = new();
    public static HoneyPotBuilder Create() => new();
    public HoneyPotBuilder AddPot(ICentroidCalculable pot)
    {
        _pots.Add(pot);
        return this;
    }

    public HoneyPot Build() => new(_pots);
}