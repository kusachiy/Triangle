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
    public partial class Form1 : Form
    {
        ForTriangle fTrig;
        Dictionary<int,double> sides;
        Dictionary<int,double> angles;
        Triangle trig;

        public Form1()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {                        
            sides = new Dictionary<int, double>();
            angles = new Dictionary<int, double>();            
            fTrig = new ForTriangle();
            fTrig.ShowDialog();
            string[] array = fTrig.GetTextboxValues();
            for (int i = 0; i < 3; i++)
            {

                try
                {
                    if (array[i] != "")
                    {
                        sides.Add(i,double.Parse(array[i]));
                        
                    }
                    if (array[i + 3] != "")
                    {
                        angles.Add(i,double.Parse(array[i + 3]));                        
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
            catch(Exception E)
            {
                MessageBox.Show(E.Message);
                return;
            }
            ReturnedInfo();           
        }

        void ReturnedInfo()
        {
            double[] args = new double[8];
            for (int i = 0; i < 3; i++)
            {
                args[i] = trig.GetSides[i];
                args[i + 3] = trig.GetAngles[i];
            }            
            args[7] = trig.GetArea;
            args[6] = trig.GetPerimetr;
            fTrig.SetTextboxValues(args);
            fTrig.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double[] sides = new double[3];
        }      

    }
}
