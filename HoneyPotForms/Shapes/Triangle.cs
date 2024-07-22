using System.Drawing;
using HoneyPotForms.Entities;
using HoneyPotForms.Interfaces;

namespace HoneyPotForms.Shapes;

public class Triangle(Coordinate vertex1, Coordinate vertex2, Coordinate vertex3) : ICentroidCalculable, IShape
{
    public Coordinate Vertex1 { get; set; } = vertex1;
    public Coordinate Vertex2 { get; set; } = vertex2;
    public Coordinate Vertex3 { get; set; } = vertex3;

    public Coordinate FindCentroid()
    {
        float centroidX = (Vertex1.X + Vertex2.X + Vertex3.X) / 3;
        float centroidY = (Vertex1.Y + Vertex2.Y + Vertex3.Y) / 3;
        return new Coordinate(centroidX, centroidY);
    }

    public void Draw(Graphics g)
    {
        using var pen = new Pen(Color.Black);
        g.DrawLine(pen, Vertex1.X, Vertex1.Y, Vertex2.X, Vertex2.Y);
        g.DrawLine(pen, Vertex2.X, Vertex2.Y, Vertex3.X, Vertex3.Y);
        g.DrawLine(pen, Vertex3.X, Vertex3.Y, Vertex1.X, Vertex1.Y);
    }
}