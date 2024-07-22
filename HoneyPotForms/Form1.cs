using HoneyPotForms.Builders;
using HoneyPotForms.Entities;
using HoneyPotForms.Shapes;

namespace HoneyPotForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private HoneyPot BuildHoneyPot(int width, int height, int hexPerRow)
        {
            var hexWidth = width / (2 * hexPerRow + 1);

            var builder = HoneyPotBuilder.Create();
            for (var j = 0; j <= height / hexWidth; j++)
            {
                for (var i = 0; i <= width / hexWidth; i++)
                {
                    if (j == 0)
                    {
                        if (i == 0)
                        {
                            var triangle = new Triangle(
                                new Coordinate(0, 0),
                                new Coordinate(0, hexWidth),
                                new Coordinate(hexWidth, 0)
                            );

                            builder.AddPot(triangle);
                        }
                        else if (i % 2 == 0)
                        {
                            var triangle = new Triangle(
                                new Coordinate((i - 1) * hexWidth, j * hexWidth),
                                new Coordinate(i * hexWidth, (j + 1) * hexWidth),
                                new Coordinate((i + 1) * hexWidth, j * hexWidth)
                            );

                            builder.AddPot(triangle);
                        }
                    }
                    if (i == width / hexWidth)
                    {
                        if (j % 2 == 1)
                        {
                            if (j % 3 == 0 || j == height / hexWidth) continue;
                            var trapezoid = new Trapezoid(
                                new Coordinate(i * hexWidth, (j - 1) * hexWidth),
                                new Coordinate((i - 1) * hexWidth, j * hexWidth),
                                new Coordinate((i - 1) * hexWidth, (j + 1) * hexWidth),
                                new Coordinate(i * hexWidth, (j + 2) * hexWidth)
                            );

                            builder.AddPot(trapezoid);
                        }
                    }
                    else
                    {
                        if (j % 3 == 0 && j < height / hexWidth)
                        {
                            if (j % 2 == 1 && i % 2 == 0)
                            {
                                if (i == 0)
                                {
                                    var trapezoid = new Trapezoid(
                                        new Coordinate(i * hexWidth, (j - 1) * hexWidth),
                                        new Coordinate(i * hexWidth, (j + 2) * hexWidth),
                                        new Coordinate((i + 1) * hexWidth, (j + 1) * hexWidth),
                                        new Coordinate((i + 1) * hexWidth, j * hexWidth)
                                    );

                                    builder.AddPot(trapezoid);
                                }
                                else
                                {
                                    var hexagon = new Hexagon(
                                        new Coordinate(i * hexWidth, (j - 1) * hexWidth),
                                        new Coordinate((i - 1) * hexWidth, j * hexWidth),
                                        new Coordinate((i - 1) * hexWidth, (j + 1) * hexWidth),
                                        new Coordinate(i * hexWidth, (j + 2) * hexWidth),
                                        new Coordinate((i + 1) * hexWidth, (j + 1) * hexWidth),
                                        new Coordinate((i + 1) * hexWidth, j * hexWidth)
                                    );

                                    builder.AddPot(hexagon);
                                }
                            }
                        }
                        else
                        {
                            if (j % 2 == 1 && i % 2 == 1 && j != height / hexWidth)
                            {
                                var hexagon = new Hexagon(
                                    new Coordinate(i * hexWidth, (j - 1) * hexWidth),
                                    new Coordinate((i - 1) * hexWidth, j * hexWidth),
                                    new Coordinate((i - 1) * hexWidth, (j + 1) * hexWidth),
                                    new Coordinate(i * hexWidth, (j + 2) * hexWidth),
                                    new Coordinate((i + 1) * hexWidth, (j + 1) * hexWidth),
                                    new Coordinate((i + 1) * hexWidth, j * hexWidth)
                                );

                                builder.AddPot(hexagon);
                            }
                        }
                    }

                    if (j != height / hexWidth) continue;
                    
                    if (i == 0)
                    {
                        var triangle = new Triangle(
                            new Coordinate(0, (j - 1) * hexWidth),
                            new Coordinate(0, j * hexWidth),
                            new Coordinate((i + 1) * hexWidth, j * hexWidth)
                        );

                        builder.AddPot(triangle);
                    }
                    else if (i % 2 == 0)
                    {
                        var triangle = new Triangle(
                            new Coordinate((i - 1) * hexWidth, j * hexWidth),
                            new Coordinate((i + 1) * hexWidth, j * hexWidth),
                            new Coordinate(i * hexWidth, (j - 1) * hexWidth)
                        );

                        builder.AddPot(triangle);
                    }
                    
                }
            }

            return builder.Build();
        }

        private void Draw_Button_Click(object sender, EventArgs e)
        {
            // ratio:perRow 9:4:8 9:7:4 30:7:16 26:6:14 7:2:12
            var width = 90 * 10;
            var height = 40 * 10;
            var hexPerRow = 8;
            var honeyPot = BuildHoneyPot(width, height, hexPerRow);

            var originalBitmap = new Bitmap(width * 2, height * 2);
            using (var g = Graphics.FromImage(originalBitmap))
            {
                honeyPot.Draw(g);
            }

            pictureBox1.Image = originalBitmap;
        }
    }
}
