using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualTriangle
{
    public partial class TriangleForm : Form
    {
        Graphics g;
        int sideCounter;
        string alphabet = "abcdefghigklmnopqrstuvwxyz";
        public TriangleForm()
        {
            InitializeComponent();
            g = pictureBox.CreateGraphics();
            sideCounter = 3;
        }

        private void AddHight_Button_Click(object sender, EventArgs e)
        {
            SideOrAnglePanel sidePanel = new SideOrAnglePanel(alphabet[sideCounter].ToString() + "=", alphabet[sideCounter] + "Angle_textBox");
            sideCounter++;
            sides_flowLayoutPanel.Controls.Add(sidePanel);
        }

        private void Redraw_Button_Click(object sender, EventArgs e)
        {

        }
    }
}
