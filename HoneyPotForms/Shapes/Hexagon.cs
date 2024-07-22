using System.Drawing;
using HoneyPotForms.Entities;
using HoneyPotForms.Interfaces;

namespace HoneyPotForms.Shapes;

public class Hexagon
    : ICentroidCalculable, IShape
{
    public Coordinate Vertex1 { get; }
    public Coordinate Vertex2 { get; }
    public Coordinate Vertex3 { get; }
    public Coordinate Vertex4 { get; }
    public Coordinate Vertex5 { get; }
    public Coordinate Vertex6 { get; }

    public Hexagon(
        Coordinate vertex1,
        Coordinate vertex2,
        Coordinate vertex3,
        Coordinate vertex4,
        Coordinate vertex5,
        Coordinate vertex6)
    {
        Vertex1 = vertex1;
        Vertex2 = vertex2;
        Vertex3 = vertex3;
        Vertex4 = vertex4;
        Vertex5 = vertex5;
        Vertex6 = vertex6;
    }

    public Hexagon(Coordinate centroid, int hexWidth)
    {
        var x = centroid.X;
        var y = centroid.Y;
        Vertex1 = new Coordinate(x, y - 3 * hexWidth / 2F);
        Vertex2 = new Coordinate(x - hexWidth, y - hexWidth / 2F);
        Vertex3 = new Coordinate(x - hexWidth, y + hexWidth / 2F);
        Vertex4 = new Coordinate(x, y + 3 * hexWidth / 2F);
        Vertex5 = new Coordinate(x + hexWidth, y + hexWidth / 2F);
        Vertex6 = new Coordinate(x + hexWidth, y - hexWidth / 2F);
    }

    public Coordinate FindCentroid()
    {
        float centroidX = (Vertex1.X + Vertex2.X + Vertex3.X + Vertex4.X + Vertex5.X + Vertex6.X) / 6;
        float centroidY = (Vertex1.Y + Vertex2.Y + Vertex3.Y + Vertex4.Y + Vertex5.Y + Vertex6.Y) / 6;
        return new Coordinate(centroidX, centroidY);
    }

    public void Draw(Graphics g)
    {
        using var pen = new Pen(Color.Black);
        g.DrawLine(pen, Vertex1.X, Vertex1.Y, Vertex2.X, Vertex2.Y);
        g.DrawLine(pen, Vertex2.X, Vertex2.Y, Vertex3.X, Vertex3.Y);
        g.DrawLine(pen, Vertex3.X, Vertex3.Y, Vertex4.X, Vertex4.Y);
        g.DrawLine(pen, Vertex4.X, Vertex4.Y, Vertex5.X, Vertex5.Y);
        g.DrawLine(pen, Vertex5.X, Vertex5.Y, Vertex6.X, Vertex6.Y);
        g.DrawLine(pen, Vertex6.X, Vertex6.Y, Vertex1.X, Vertex1.Y);
    }
}