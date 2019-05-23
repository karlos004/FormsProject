using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _111zal2
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void DoMath(int X)
        {
            double pow = Math.Pow(X, X);
            //Console.WriteLine(pow);
        }

        public double mat(double x, double y)
        {
            return x * y;
        }

        public void StartWork(IProgress<int> progress)
        {
            for (int j = 0; j < 1000000; j++)
            {
                DoMath(j);
                if (progress != null)
                    progress.Report((j + 1) * 100 / 1000000);
            }
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            progressBar1.Maximum = 100;
            progressBar1.Step = 1;

            var progress = new Progress<int>(v => { progressBar1.Value = v; });
            await Task.Run(() => StartWork(progress));
            Calc Calc;
            Calc = new Calc(mat);
            label1.Text = Calc(1000, 1000).ToString();
            MessageBox.Show("Calculations compleated", "Done");
        }
    }
    public delegate double Calc(double x, double y);
}
