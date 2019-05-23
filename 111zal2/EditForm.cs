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

        private void Button1_Click(object sender, EventArgs e)
        {
            using (DBEntities2 db = new DBEntities2())
            {
                if (textBox1.Text != "")
                {
                    karlitos_products edit = new karlitos_products();
                    int id = int.Parse(textBox1.Text);
                    edit = db.karlitos_products.Where(a => a.ProductId == id).First();
                    if (double.TryParse(textBox4.Text, out double x) == false)
                    {
                        MessageBox.Show("Invalid price format");
                    }
                    else
                    {
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
                else
                {
                    MessageBox.Show("First select id to edit");
                }
                
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            using (DBEntities2 db = new DBEntities2())
            {
                karlitos_products edit = new karlitos_products();
                int id;
                if (int.TryParse(textBox1.Text, out int x))
                {
                    id = int.Parse(textBox1.Text);
                }
                else
                {
                    MessageBox.Show("Id must be a number");
                    id = 1;
                    textBox1.Text = id.ToString();
                }
                if (db.karlitos_products.Where(a => a.ProductId == id).Count() == 1)
                {
                    //Console.WriteLine(db.karlitos_products.Where(a => a.ProductId == id).Count());
                    edit = db.karlitos_products.Where(a => a.ProductId == id).First();
                }
                else
                {
                    id = int.Parse(textBox1.Text);
                    MessageBox.Show("Product with id = " + id + " was not found");
                    id = 1;
                    textBox1.Text = id.ToString();
                    edit = db.karlitos_products.Where(a => a.ProductId == id).First();
                }
                textBox5.Text = edit.ProductName;
                textBox2.Text = edit.SerialNumber;
                textBox3.Text = edit.Color;
                textBox4.Text = edit.Price.ToString();
                comboBox1.Text = "";
                comboBox1.SelectedText = edit.Type;
                numericUpDown1.Value = decimal.Parse(edit.QTY.ToString());
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            using (DBEntities2 db = new DBEntities2())
            {
                if (textBox1.Text != "")
                {
                    karlitos_products del = new karlitos_products();
                    int id = int.Parse(textBox1.Text);
                    del = db.karlitos_products.Where(a => a.ProductId == id).First();
                    db.karlitos_products.Remove(del);
                    db.SaveChanges();
                    MessageBox.Show("Product deleted");
                    this.Close();
                } else
                {
                    MessageBox.Show("First select id to delete");
                }
            }
        }
    }
}
