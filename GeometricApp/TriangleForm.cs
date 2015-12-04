using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeometricApp
{
    public partial class TriangleForm : Form
    {
        Graphics g;
        int sideCounter;
        string alphabet = "abcdefghigklmnopqrstuvwxyz";
        Dictionary<int, double> sides, angles;
        
        Triangle trig;
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

        private void Calculate_Click(object sender, EventArgs e)
        {
            
            sides = new Dictionary<int, double>();
            angles = new Dictionary<int, double>();
            TextBox[] sidesArray = { aSide_textBox,bSide_textBox,cSide_textBox};
            TextBox[] anglesArray = { aAngle_textBox, bAngle_textBox, cAngle_textBox };
            for (int i = 0; i < 3; i++)
            {

                try
                {
                    if (sidesArray[i].Text != "")
                    {
                        sides.Add(i, double.Parse(sidesArray[i].Text));

                    }
                    if (anglesArray[i].Text != "")
                    {
                        angles.Add(i, double.Parse(anglesArray[i].Text));
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка приведения типа. Неверный воод параметров");
                    return;
                }
            }
            try
            {
                trig = new Triangle(sides, angles);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
                return;
            }
            ReturnedInfo(sidesArray,anglesArray);
        }

        private void TriangleForm_Load(object sender, EventArgs e)
        {
            
        }

        void ReturnedInfo(TextBox[] sidesArr,TextBox[] anglesArr)
        {
            for (int i = 0; i < 3; i++)
            {
                sidesArr[i].Text = trig.GetSides[i].ToString();
                anglesArr[i].Text = trig.GetAngles[i].ToString();
            }
            AreaTextbox.Text = trig.GetArea.ToString();
            PerimetrTextbox.Text = trig.GetPerimetr.ToString();           
        }
}
}
