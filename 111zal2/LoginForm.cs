using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace _111zal2
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            panel1.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool login()
        {
            using (DBEntities2 db = new DBEntities2())
            {
                var user = db.karlitos_users.FirstOrDefault(u => u.Username == textBox1.Text);
                if (user != null)
                {
                    if (user.Password == textBox2.Text)
                    {
                        MessageBox.Show("Login succesfull");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Wrong password");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("No user found");
                    return false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool logged = login();
            if (logged == true)
            {
                this.Hide();
                Main a = new Main();
                a.Show();
            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel1.Show();
            panel1.BringToFront();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            textBox5.Clear();
            textBox3.Clear();
            textBox4.Clear();
            panel1.Hide();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            using (DBEntities2 db = new DBEntities2())
            {
                karlitos_users add = new karlitos_users();
                int user = db.karlitos_users.Where(a => a.Username == textBox5.Text).Count();
                if (textBox3.Text == textBox4.Text)
                {
                    if (user != 0)
                    {
                        MessageBox.Show("Username is already in use");
                        textBox5.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                    }
                    else
                    {
                        add.Username = textBox5.Text;
                        add.Password = textBox3.Text;
                        db.karlitos_users.Add(add);
                        db.SaveChanges();
                        panel1.Hide();
                    }
                }
                else
                {
                    textBox3.Clear();
                    textBox4.Clear();
                    MessageBox.Show("Passwords must match");
                }
            }
        }
    }
}
