namespace HoneyPotForms.Entities;
public record Coordinate(float X, float Y)
{
    public float Distance(Coordinate other) => MathF.Sqrt(MathF.Pow(X - other.X, 2) + MathF.Pow(Y - other.Y, 2));
}