using System.Drawing;
using System.Windows.Forms;

namespace HoneyPotForms
{
    public partial class HexagonForm : Form
    {
        public HexagonForm(Bitmap hexagonBitmap)
        {
            InitializeComponent();
            pictureBox1.Image = hexagonBitmap;
        }
    }
}