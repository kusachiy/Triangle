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
    public partial class ForTriangle : Form
    {
        
        public ForTriangle()
        {
            InitializeComponent();
            textBox7.Visible = false;
            textBox8.Visible = false;
            label10.Visible = false;
            label9.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        public string[] GetTextboxValues()
        {
            string[] arr = new string[6];
            arr[0] = textBox1.Text;
            arr[1] = textBox2.Text;
            arr[2] = textBox3.Text;
            arr[3] = textBox4.Text;
            arr[4] = textBox5.Text;
            arr[5] = textBox6.Text;
            return arr;
        }

        public void SetTextboxValues(double[] args)
        {
            textBox7.Visible = true;
            textBox8.Visible = true;
            label10.Visible = true;
            label9.Visible = true;
            textBox1.Text = args[0].ToString();
            textBox2.Text = args[1].ToString();
            textBox3.Text = args[2].ToString();
            textBox4.Text = Math.Round(args[3],2).ToString();
            textBox5.Text = Math.Round(args[4],2).ToString();
            textBox6.Text = Math.Round(args[5],2).ToString();
            textBox7.Text = args[6].ToString();
            textBox8.Text = Math.Round(args[7],3).ToString();
        }

        private void ForTriangle_Load(object sender, EventArgs e)
        {

        }
    }
}
