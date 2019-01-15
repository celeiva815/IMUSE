using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMUSE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        public void SetStatusX(string status)
        {
            labelStatusX.Invoke(new Action(() =>
            {
                labelStatusX.Text = status;
            }
           ));
        }

        public void SetStatusY(string status)
        {
            labelStatusY.Invoke(new Action(() =>
            {
                labelStatusY.Text = status;
            }
           ));
        }

        public void SetStatusZ(string status)
        {
            labelStatusZ.Invoke(new Action(() =>
            {
                labelStatusZ.Text = status;
            }
           ));
        }

        public void SetXMin(double d)
        {
            labelXMin.Invoke(new Action(() =>
            {
                labelXMin.Text = d.ToString();
            }
           ));
        }

        public void SetXMax(double d)
        {
            labelXMax.Invoke(new Action(() =>
            {
                labelXMax.Text = d.ToString();
            }
           ));
        }

        public void SetX(double d)
        {
            labelX.Invoke(new Action(() =>
            {
                labelX.Text = d.ToString();
            }
           ));
        }

        public void SetYMin(double d)
        {
            labelYMin.Invoke(new Action(() =>
            {
                labelYMin.Text = d.ToString();
            }
           ));
        }

        public void SetYMax(double d)
        {
            labelYMax.Invoke(new Action(() =>
            {
                labelYMax.Text = d.ToString();
            }
           ));
        }

        public void SetY(double d)
        {
            labelY.Invoke(new Action(() =>
            {
                labelY.Text = d.ToString();
            }
           ));
        }

        public void SetZMin(double d)
        {
            labelZMin.Invoke(new Action(() =>
            {
                labelZMin.Text = d.ToString();
            }
           ));
        }

        public void SetZMax(double d)
        {
            labelZMax.Invoke(new Action(() =>
            {
                labelZMax.Text = d.ToString();
            }
           ));
        }

        public void SetZ(double d)
        {
            labelZ.Invoke(new Action(() =>
            {
                labelZ.Text = d.ToString();
            }
           ));
        }

        public void SetProgress(int value)
        {
            progressBar1.Invoke(new Action(() =>
            {
                progressBar1.Value = value;
            }
           ));
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void labelZ_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
