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
    public partial class EditForm : Form
    {
        public EditForm()
        {
            InitializeComponent();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            using (DBEntities2 db = new DBEntities2())
            {
                karlitos_products edit = new karlitos_products();
                int id = int.Parse(textBox1.Text);
                edit = db.karlitos_products.Where(a => a.ProductId == id).First();
                textBox5.Text = edit.ProductName;
                textBox2.Text = edit.SerialNumber;
                textBox3.Text = edit.Color;
                textBox4.Text = edit.Price.ToString();
                comboBox1.Text = "";
                comboBox1.SelectedText = edit.Type;
                numericUpDown1.Value = decimal.Parse(edit.QTY.ToString());
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            using (DBEntities2 db = new DBEntities2())
            {
                karlitos_products edit = new karlitos_products();
                int id = int.Parse(textBox1.Text);
                edit = db.karlitos_products.Where(a => a.ProductId == id).First();
                edit.ProductName = textBox5.Text;
                edit.SerialNumber = textBox2.Text;
                edit.Color = textBox3.Text;
                edit.Price = double.Parse(textBox4.Text);
                edit.Type = comboBox1.Text;
                edit.QTY = long.Parse(numericUpDown1.Value.ToString());
                db.SaveChanges();
                this.Close();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
