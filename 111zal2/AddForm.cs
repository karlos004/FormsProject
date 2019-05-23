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
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            using (DBEntities2 db = new DBEntities2())
            {
                karlitos_products addnew = new karlitos_products();
                if (textBox1.Text != "" || textBox2.Text != "" || comboBox1.Text != "")
                {
                    addnew.ProductName = textBox1.Text;
                    addnew.SerialNumber = textBox2.Text;
                    addnew.Color = textBox3.Text;
                    if (float.TryParse(textBox4.Text, out float n))
                    {
                        addnew.Price = float.Parse(textBox4.Text);
                    }
                    else
                    {
                        MessageBox.Show("Invalid price format."+"\nPrice was set to 0.");
                        addnew.Price = 0;
                    }
                    addnew.Type = comboBox1.Text;
                    addnew.QTY = long.Parse(numericUpDown1.Value.ToString());
                    db.karlitos_products.Add(addnew);
                    db.SaveChanges();
                    MessageBox.Show("Product added successfully");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    comboBox1.Text = "";
                    numericUpDown1.Value = 0;
                }
                else
                {
                    MessageBox.Show("Product was not added please fix any errors and try again");
                }
            }
        }
    }
}
