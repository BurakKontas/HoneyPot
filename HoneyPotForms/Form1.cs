using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using HoneyPotForms.Builders;
using HoneyPotForms.Entities;
using HoneyPotForms.Shapes;

namespace HoneyPotForms
{
    public partial class Form1 : Form
    {
        private HoneyPot? _honeyPot = null;
        private Image? _defaultImage = null;

        public Form1()
        {
            InitializeComponent();
        }

        private HoneyPot BuildHoneyPot(int width, int height, int hexPerRow)
        {
            HoneyPotBuilder builder = HoneyPotBuilder.Create();
            int hexWidth = width / (2 * hexPerRow + 1);
            int index = 1;

            for (int j = 0; j <= height / hexWidth + 2; j += 2)
            {
                for (int i = 0; i <= width / hexWidth + 2; i += 2)
                {
                    Hexagon hexagon;
                    if (j % 4 == 0)
                    {
                        hexagon = new Hexagon(
                            new Coordinate(i * hexWidth, (j - 1) * hexWidth),
                            hexWidth,
                            index++
                        );

                    }
                    else
                    {
                        hexagon = new Hexagon(
                            new Coordinate((i - 1) * hexWidth, (j - 1) * hexWidth),
                            hexWidth,
                            index++
                        );
                    }
                    builder.AddPot(hexagon);
                }
            }

            return builder.Build();
        }

        private void Draw_Button_Click(object sender, EventArgs e)
        {
            if (_defaultImage == null)
            {
                MessageBox.Show(@"Please upload an image first.");
                return;
            }

            Image? image = (Image?)_defaultImage?.Clone();

            int width = image.Width;
            int height = image.Height;
            int hexPerRow = (int)Hex_Per_Row.Value;
            _honeyPot = BuildHoneyPot(width, height, hexPerRow);

            using (Graphics g = Graphics.FromImage(image))
            {
                _honeyPot.Draw(g);
            }

            pictureBox1.Image = image;
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            UploadImage(pictureBox1);
            _defaultImage = (Image?)pictureBox1.Image.Clone();
        }


        private void PictureBox1_Click(object sender, EventArgs e)
        {
            if (_honeyPot == null)
            {
                //MessageBox.Show(@"Please draw the honey pot first.");
                return;
            }

            MouseEventArgs mouseEventArgs = (MouseEventArgs)e;
            int x = mouseEventArgs.X;
            int y = mouseEventArgs.Y;

            Hexagon closestPot = _honeyPot.FindHexagon(new Coordinate(x, y));

            Bitmap hexagonImage = CropHexagonFromImage((Bitmap)pictureBox1.Image, closestPot);
            HexagonForm hexagonForm = new HexagonForm(hexagonImage);
            hexagonForm.Show();
        }

        private Bitmap CropHexagonFromImage(Bitmap originalImage, Hexagon hexagon)
        {
            float minX = Math.Min(hexagon.Vertex1.X, Math.Min(hexagon.Vertex2.X, Math.Min(hexagon.Vertex3.X,
                Math.Min(hexagon.Vertex4.X, Math.Min(hexagon.Vertex5.X, hexagon.Vertex6.X)))));
            float minY = Math.Min(hexagon.Vertex1.Y, Math.Min(hexagon.Vertex2.Y, Math.Min(hexagon.Vertex3.Y,
                Math.Min(hexagon.Vertex4.Y, Math.Min(hexagon.Vertex5.Y, hexagon.Vertex6.Y)))));
            float maxX = Math.Max(hexagon.Vertex1.X, Math.Max(hexagon.Vertex2.X, Math.Max(hexagon.Vertex3.X,
                Math.Max(hexagon.Vertex4.X, Math.Max(hexagon.Vertex5.X, hexagon.Vertex6.X)))));
            float maxY = Math.Max(hexagon.Vertex1.Y, Math.Max(hexagon.Vertex2.Y, Math.Max(hexagon.Vertex3.Y,
                Math.Max(hexagon.Vertex4.Y, Math.Max(hexagon.Vertex5.Y, hexagon.Vertex6.Y)))));

            int width = (int)(maxX - minX);
            int height = (int)(maxY - minY);

            Bitmap croppedImage = new Bitmap(width, height);
            using Graphics g = Graphics.FromImage(croppedImage);
            g.Clear(Color.Transparent);

            PointF[] points = new PointF[]
            {
                new(hexagon.Vertex1.X - minX, hexagon.Vertex1.Y - minY),
                new(hexagon.Vertex2.X - minX, hexagon.Vertex2.Y - minY),
                new(hexagon.Vertex3.X - minX, hexagon.Vertex3.Y - minY),
                new(hexagon.Vertex4.X - minX, hexagon.Vertex4.Y - minY),
                new(hexagon.Vertex5.X - minX, hexagon.Vertex5.Y - minY),
                new(hexagon.Vertex6.X - minX, hexagon.Vertex6.Y - minY),
            };

            GraphicsPath path = new GraphicsPath();
            path.AddPolygon(points);

            g.SetClip(path);
            g.DrawImage(originalImage, new Rectangle(0, 0, width, height), minX, minY, width, height, GraphicsUnit.Pixel);

            return croppedImage;
        }


        private void UploadImage(PictureBox pictureBox, bool resizeBox = false)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.jpg, *.jpeg, *.png, *.gif, *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                var selectedFile = openFileDialog.FileName;

                pictureBox.Image = Image.FromFile(selectedFile);

                if (resizeBox) pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                else
                {
                    pictureBox.Size = pictureBox.Image.Size;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Resim yüklenirken bir hata oluþtu: " + ex.Message);
            }
        }
    }
}
