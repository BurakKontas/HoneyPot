using HoneyPotForms.Interfaces;

namespace HoneyPotForms.Entities;

public class HoneyPot(IEnumerable<ICentroidCalculable> pots)
{
    public IReadOnlyCollection<ICentroidCalculable> Pots { get; } = pots.ToList().AsReadOnly();

    public void Draw(Graphics g)
    {
        foreach (var pot in Pots)
        {
            if (pot is IShape shape)
            {
                shape.Draw(g);
            }
        }
    }
}