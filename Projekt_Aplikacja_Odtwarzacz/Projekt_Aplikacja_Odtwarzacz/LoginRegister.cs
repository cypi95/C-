using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Projekt_Aplikacja_Odtwarzacz
{
    public partial class LoginRegister : Form
    {
        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=player_project;Integrated Security=True;");

        private void button1_MouseHover(object sender, System.EventArgs e)
        {
            
        }

        private void button1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            button1.BackColor = Color.FromArgb(0, 0, 0, 0);
        }

        public LoginRegister()
        {
            con.Open();
            InitializeComponent();
            Bitmap bmp = new Bitmap(@"C:\Users\Cyprian\source\repos\Projekt_Aplikacja_Odtwarzacz\img\login.png");
            pictureBox1.Image = bmp;
            pictureBox1.BackColor = Color.FromArgb(0,0,0,0);
            panel2.BackColor = Color.FromArgb(50,0,0,0);
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.BackColor= Color.FromArgb(0, 0, 0, 0);

            this.button1.MouseHover += new System.EventHandler(this.button1_MouseHover);
            this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);

            panel1.Location = new Point(
            this.ClientSize.Width / 2 - panel1.Size.Width / 2,
            this.ClientSize.Height / 2 - panel1.Size.Height / 2);
            panel1.Anchor = AnchorStyles.None;


        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            String query = "Select user_name from [dbo].[User] where user_name = '" + textBox1.Text + "'";
            String query1 = "Select user_password from [dbo].[User] where user_password = '" + textBox2.Text + "'";
            String query2 = "Select A.role_name from  Role as A  LEFT JOIN [User] as B ON A.role_id = B.role_id where B.user_name ='" + textBox1.Text + "'";

            SqlCommand cmd1 = new SqlCommand(query, con);
            SqlDataReader dbr1;
            dbr1 = cmd1.ExecuteReader();
            
            string sname = null;
            string pass = null;
            string role = null;
            if (dbr1.Read())
            {
                sname = (string)dbr1["user_name"];
                dbr1.Close();

                cmd1=new SqlCommand(query1,con);
                dbr1 = cmd1.ExecuteReader();
                if (dbr1.Read())
                {
                    pass = (string)dbr1["user_password"];

                    int i = textBox1.Text.Length;
                    int j = textBox2.Text.Length;
                    Console.WriteLine(textBox1.Text.Substring(0, i) + "   " + textBox2.Text.Substring(0, j));
                    Console.WriteLine(sname.Substring(0, i) + "   " + pass.Substring(0, j));
                    if (textBox1.Text == sname.Substring(0, i) && textBox2.Text == pass.Substring(0, j))
                    {
                        dbr1.Close();

                        cmd1 = new SqlCommand(query2, con);
                        dbr1 = cmd1.ExecuteReader();
                        if (dbr1.Read())
                        {
                            role = (string)dbr1["role_name"];
                            if (role.Substring(0,5) == "ADMIN")
                            {
                                Admin admin2 = new Admin();
                                admin2.Show();
                            }
                            else
                            {
                                User user2 = new User();
                                user2.Show();
                            }
                        }
                        Console.WriteLine("Udalo sie zalogowac");
                    }

                }
                else
                {
                    textBox2.Text = "";
                    textBox1.Text = "Podales zle haslo";
                }
            }
            else
            {
                textBox2.Text = "";
                textBox1.Text = "Nie ma takiego konta";
            }
            dbr1.Close();
        }

        private void LoginRegister_Load(object sender, EventArgs e)
        {

        }
    }
}
