using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _111zal2
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SearchByName(textBox1.Text);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm About = new AboutForm();
            About.ShowDialog();
        }

        public void odswiezgrida()
        {
            dataGridView1.AutoGenerateColumns = false;
            using (DBEntities2 db = new DBEntities2())
            {
                dataGridView1.DataSource = db.karlitos_products.ToList();
                dataGridView2.DataSource = db.karlitos_products.Where(a => a.Type == "Smartphone").ToList();
                dataGridView3.DataSource = db.karlitos_products.Where(a => a.Type == "Tv").ToList();
                dataGridView4.DataSource = db.karlitos_products.Where(a => a.Type == "Laptop").ToList();
            }
        }

        public void SearchByName(string abc)
        {
            using (DBEntities2 db = new DBEntities2())
            {
                dataGridView1.DataSource = db.karlitos_products.Where(a => a.ProductName.Contains(abc)).ToList();
            }
        }
        public void SearchByType(string abc)
        {
            using (DBEntities2 db = new DBEntities2())
            {
                dataGridView1.DataSource = db.karlitos_products.Where(a => a.Type.Contains(abc)).ToList();
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            odswiezgrida();
        }

        private void EditToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EditForm Edit = new EditForm();
            Edit.ShowDialog();
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddForm Add = new AddForm();
            Add.ShowDialog();
        }

        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            odswiezgrida();
        }

        private void SmartphonesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel3.Hide();
            panel4.Hide();
            panel2.Show();
        }

        private void HomeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panel1.Show();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
        }

        private void TVsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            panel3.Show();
            panel4.Hide();
        }

        private void LaptopsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.Show();
        }

        private void ComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            SearchByType(comboBox1.Text);
        }
    }
}
