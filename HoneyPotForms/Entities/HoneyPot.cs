using HoneyPotForms.Shapes;

namespace HoneyPotForms.Entities;

public class HoneyPot(IEnumerable<Hexagon> pots)
{
    public IReadOnlyCollection<Hexagon> Pots { get; } = pots.ToList().AsReadOnly();

    public void Draw(Graphics g)
    {
        foreach (Hexagon pot in Pots)
        {
            if (pot is Hexagon shape)
            {
                shape.Draw(g);
            }
        }
    }

    public Hexagon FindHexagon(Coordinate coords)
    {
        Hexagon closestPot = null;

        foreach (Hexagon pot in Pots)
        {
            if (closestPot == null)
            {
                closestPot = pot;
            }
            else
            {
                var closestDistance = Math.Sqrt(
                    Math.Pow(coords.X - closestPot.FindCentroid().X, 2) +
                    Math.Pow(coords.Y - closestPot.FindCentroid().Y, 2)
                );

                var currentDistance = Math.Sqrt(
                    Math.Pow(coords.X - pot.FindCentroid().X, 2) +
                    Math.Pow(coords.Y - pot.FindCentroid().Y, 2)
                );

                if (currentDistance < closestDistance)
                {
                    closestPot = pot;
                }
            }
        }

        return closestPot;
    }
}