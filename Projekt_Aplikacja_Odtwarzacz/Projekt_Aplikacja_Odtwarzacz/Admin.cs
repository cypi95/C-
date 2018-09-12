using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_Aplikacja_Odtwarzacz
{
    public partial class Admin : Form
    {
        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=player_project;Integrated Security=True;");
        Int64 ilosc_kont = 0;
        Int64 ilosc_albumow = 0;
        Int64 ilosc_wykonawcow = 0;
        Int64 ilosc_utworow = 0;
        public Admin()
        {
            con.Open();
            InitializeComponent();
            konta.FlatStyle = FlatStyle.Flat;
            konta.FlatAppearance.BorderSize = 0;
            konta.BackColor = Color.FromArgb(130, 0, 0, 0);
            albumy.FlatStyle = FlatStyle.Flat;
            albumy.FlatAppearance.BorderSize = 0;
            albumy.BackColor = Color.FromArgb(130, 0, 0, 0);
            wykonawcy.FlatStyle = FlatStyle.Flat;
            wykonawcy.FlatAppearance.BorderSize = 0;
            wykonawcy.BackColor = Color.FromArgb(130, 0, 0, 0);
            utwory.FlatStyle = FlatStyle.Flat;
            utwory.FlatAppearance.BorderSize = 0;
            utwory.BackColor = Color.FromArgb(130, 0, 0, 0);
            panel1.Location = new Point(
            this.ClientSize.Width / 2 - panel1.Size.Width / 2,
            this.ClientSize.Height / 2 - panel1.Size.Height / 2);
            panel1.Anchor = AnchorStyles.None;
            panel2.BackColor = Color.FromArgb(80, 0, 0, 0);
            
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            Zatwierdz_dodawanie_konta.Visible = false;
            Zatwierdz_usuwanie_konta.Visible = false;
            Zatwierdz_zmiane_hasla.Visible = false;
            Zatwierdz_zmiane_loginu.Visible = false;
            Zatwierdz_dodawanie_wykonawcy.Visible = false;
            Zatwierdz_usuwanie_wykonawcy.Visible = false;
            Zatwierdz_dodawanie_albumu.Visible = false;
            Zatwierdz_usuwanie_albumu.Visible = false;
            Zatwierdz_dodawanie_utworu.Visible = false;
            Zatwierdz_usuwanie_utworu.Visible = false;

            comboBox1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            listBox1.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;

            panel_albumy.Hide();
            panel_utwory.Hide();
            panel_konto.Hide();
            panel_wykonawcy.Hide();
        }

        private void konta_Click(object sender, EventArgs e)
        {
            
            panel_konto.Show();
            panel_albumy.Hide();
            panel_utwory.Hide();
            panel_wykonawcy.Hide();

            String query = "SELECT max(user_id) as temp FROM [dbo].[User]";

            SqlCommand cmd1 = new SqlCommand(query, con);
            SqlDataReader dbr1;
            dbr1 = cmd1.ExecuteReader();
            Int64 id = 0;
            if (dbr1.Read())
            {
               id = (Int64)dbr1["temp"]; //name is coming from database
            }

            Console.WriteLine(id);
            ilosc_kont = id;
            dbr1.Close();
        }

        private void albumy_Click(object sender, EventArgs e)
        {
            panel_albumy.Show();
            panel_utwory.Hide();
            panel_konto.Hide();
            panel_wykonawcy.Hide();

            String query = "SELECT max(album_id) as temp FROM [dbo].[Album]";

            SqlCommand cmd1 = new SqlCommand(query, con);
            SqlDataReader dbr1;
            dbr1 = cmd1.ExecuteReader();
            Int64 id = 0;
            if (dbr1.Read())
            {
                id = (Int64)dbr1["temp"]; //name is coming from database
            }

            Console.WriteLine(id);
            ilosc_albumow = id;
           
            dbr1.Close();
        }

        private void utwory_Click(object sender, EventArgs e)
        {
            panel_utwory.Show();
            panel_albumy.Hide();
            panel_konto.Hide();
            panel_wykonawcy.Hide();

            String query = "SELECT max(track_id) as temp FROM [dbo].[Track]";

            SqlCommand cmd1 = new SqlCommand(query, con);
            SqlDataReader dbr1;
            dbr1 = cmd1.ExecuteReader();
            Int64 id = 0;
            if (dbr1.Read())
            {
                id = (Int64)dbr1["temp"]; //name is coming from database
            }

            Console.WriteLine(id);
            ilosc_utworow = id;

            dbr1.Close();
        }

        private void wykonawcy_Click(object sender, EventArgs e)
        {
            panel_wykonawcy.Show();
            panel_albumy.Hide();
            panel_utwory.Hide();
            panel_konto.Hide();

            String query = "SELECT max(performer_id) as temp FROM [dbo].[Performer]";

            SqlCommand cmd1 = new SqlCommand(query, con);
            SqlDataReader dbr1;
            dbr1 = cmd1.ExecuteReader();
            Int64 id = 0;
            if (dbr1.Read())
            {
                id = (Int64)dbr1["temp"]; //name is coming from database
            }

            Console.WriteLine(id);
            ilosc_wykonawcow = id;

            dbr1.Close();
        }

        private void DodajKonto_Click(object sender, EventArgs e)
        {
            Zatwierdz_dodawanie_konta.Visible = true;
            Zatwierdz_usuwanie_konta.Visible = false;
            Zatwierdz_zmiane_hasla.Visible = false;
            Zatwierdz_zmiane_loginu.Visible = false;
            Zatwierdz_dodawanie_wykonawcy.Visible = false;
            Zatwierdz_usuwanie_wykonawcy.Visible = false;
            Zatwierdz_dodawanie_albumu.Visible = false;
            Zatwierdz_usuwanie_albumu.Visible = false;
            Zatwierdz_dodawanie_utworu.Visible = false;
            Zatwierdz_usuwanie_utworu.Visible = false;

            comboBox1.Visible = false;
            
            label2.Text = "Dodawanie Konta";
            label2.Visible = true;
            label3.Text = "Wpisz nazwe konta";
            label3.Visible = true;
            label4.Text = "Wpisz haslo";
            label4.Visible = true;
            
            textBox1.Visible = true;
            textBox2.Visible = true;
            listBox1.Visible = false;
        }

        private void UsunKonto_Click(object sender, EventArgs e)
        {
            Zatwierdz_dodawanie_konta.Visible = false;
            Zatwierdz_usuwanie_konta.Visible = true;
            Zatwierdz_zmiane_hasla.Visible = false;
            Zatwierdz_zmiane_loginu.Visible = false;
            Zatwierdz_dodawanie_wykonawcy.Visible = false;
            Zatwierdz_usuwanie_wykonawcy.Visible = false;
            Zatwierdz_dodawanie_albumu.Visible = false;
            Zatwierdz_usuwanie_albumu.Visible = false;
            Zatwierdz_dodawanie_utworu.Visible = false;
            Zatwierdz_usuwanie_utworu.Visible = false;
            comboBox1.Visible = false;
            label2.Text = "Usuwanie konta";
            label3.Text = "Wpisz nazwe konta";
            textBox1.Visible = true;
            textBox2.Visible = false;
            label4.Visible = false;
            listBox1.Visible = false;
        }

        private void ZmienHaslo_Click(object sender, EventArgs e)
        {
            Zatwierdz_dodawanie_konta.Visible = false;
            Zatwierdz_usuwanie_konta.Visible = false;
            Zatwierdz_zmiane_hasla.Visible = true;
            Zatwierdz_zmiane_loginu.Visible = false;
            Zatwierdz_dodawanie_wykonawcy.Visible = false;
            Zatwierdz_usuwanie_wykonawcy.Visible = false;
            Zatwierdz_dodawanie_albumu.Visible = false;
            Zatwierdz_usuwanie_albumu.Visible = false;
            Zatwierdz_dodawanie_utworu.Visible = false;
            Zatwierdz_usuwanie_utworu.Visible = false;
            comboBox1.Visible = false;
            label2.Text = "Zmiana hasla";
            label2.Visible = true;
            label3.Text = "Wpisz nazwe konta";
            label3.Visible = true;
            label4.Text = "Wpisz nowe haslo";
            label4.Visible = true;

            textBox1.Visible = true;
            textBox2.Visible = true;
            listBox1.Visible = false;
        }

        private void ZmienLogin_Click(object sender, EventArgs e)
        {
            Zatwierdz_dodawanie_konta.Visible = false;
            Zatwierdz_usuwanie_konta.Visible = false;
            Zatwierdz_zmiane_hasla.Visible = false;
            Zatwierdz_zmiane_loginu.Visible = true;
            Zatwierdz_dodawanie_wykonawcy.Visible = false;
            Zatwierdz_usuwanie_wykonawcy.Visible = false;
            Zatwierdz_dodawanie_albumu.Visible = false;
            Zatwierdz_usuwanie_albumu.Visible = false;
            Zatwierdz_dodawanie_utworu.Visible = false;
            Zatwierdz_usuwanie_utworu.Visible = false;
            comboBox1.Visible = false;
            label2.Text = "Zmiana loginu";
            label2.Visible = true;
            label3.Text = "Wpisz nazwe konta";
            label3.Visible = true;
            label4.Text = "Wpisz nowy login";
            label4.Visible = true;

            textBox1.Visible = true;
            textBox2.Visible = true;
            listBox1.Visible = false;
        }

        private void DodajWykonawce_Click(object sender, EventArgs e)
        {

            Zatwierdz_dodawanie_konta.Visible = false;
            Zatwierdz_usuwanie_konta.Visible = false;
            Zatwierdz_zmiane_hasla.Visible = false;
            Zatwierdz_zmiane_loginu.Visible = false;
            Zatwierdz_dodawanie_wykonawcy.Visible = true;
            Zatwierdz_usuwanie_wykonawcy.Visible = false;
            Zatwierdz_dodawanie_albumu.Visible = false;
            Zatwierdz_usuwanie_albumu.Visible = false;
            Zatwierdz_dodawanie_utworu.Visible = false;
            Zatwierdz_usuwanie_utworu.Visible = false;
            comboBox1.Visible = false;
            label2.Text = "Dodawanie wykonawcy";
            label2.Visible = true;
            label3.Text = "Nazwa wykonawcy";
            label3.Visible = true;
            label4.Visible = false;

            textBox1.Visible = true;
            textBox2.Visible = false;
            listBox1.Visible = false;
        }

        private void UsunWykonawce_Click(object sender, EventArgs e)
        {
            Zatwierdz_dodawanie_konta.Visible = false;
            Zatwierdz_usuwanie_konta.Visible = false;
            Zatwierdz_zmiane_hasla.Visible = false;
            Zatwierdz_zmiane_loginu.Visible = false;
            Zatwierdz_dodawanie_wykonawcy.Visible = false;
            Zatwierdz_usuwanie_wykonawcy.Visible = true;
            Zatwierdz_dodawanie_albumu.Visible = false;
            Zatwierdz_usuwanie_albumu.Visible = false;
            Zatwierdz_dodawanie_utworu.Visible = false;
            Zatwierdz_usuwanie_utworu.Visible = false;

            comboBox1.Visible = false;
            label2.Text = "Usuniecie wykanawcy";
            label2.Visible = true;
            label3.Text = "Nazwa wykonawcy";
            label3.Visible = true;
            label4.Visible = false;

            textBox1.Visible = true;
            textBox2.Visible = false;
            listBox1.Visible = false;
        }

        private void ListaUtworowWykonawcy_Click(object sender, EventArgs e)
        {
            listBox1.Visible = true;
            comboBox1.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label2.Visible = true;
            label2.Text = "Lista wykonawcow";
            String query = "Select Performer.performer_name from Performer";

            SqlCommand cmd1 = new SqlCommand(query, con);


            SqlDataReader dbr1;


            dbr1 = cmd1.ExecuteReader();
            listBox1.Items.Clear();
            while (dbr1.Read())

            {
                
                string sname = (string)dbr1["performer_name"]; ; //name is coming from database

                listBox1.Items.Add(sname);

            }
            dbr1.Close();
        }

        private void DodajAlbum_Click(object sender, EventArgs e)
        {
            Zatwierdz_dodawanie_konta.Visible = false;
            Zatwierdz_usuwanie_konta.Visible = false;
            Zatwierdz_zmiane_hasla.Visible = false;
            Zatwierdz_zmiane_loginu.Visible = false;
            Zatwierdz_dodawanie_wykonawcy.Visible = false;
            Zatwierdz_usuwanie_wykonawcy.Visible = false;
            Zatwierdz_dodawanie_albumu.Visible = true;
            Zatwierdz_usuwanie_albumu.Visible = false;
            Zatwierdz_dodawanie_utworu.Visible = false;
            Zatwierdz_usuwanie_utworu.Visible = false;
            label2.Visible = true;
            label3.Visible = true;
            label2.Text = "Dodawanie albumu";
            label3.Text = "Podaj nazwe albumu";
            textBox1.Visible = true;
            textBox2.Visible = false;
            listBox1.Visible = false;
            comboBox1.Visible = true;
            comboBox1.Items.Clear();
            String query3 = "Select Performer.performer_name from Performer";

            SqlCommand cmd13 = new SqlCommand(query3, con);


            SqlDataReader dbr13;


            dbr13 = cmd13.ExecuteReader();
            
            while (dbr13.Read())

            {

                string ssname = (string)dbr13["performer_name"]; ; //name is coming from database

                comboBox1.Items.Add(ssname);

            }
            dbr13.Close();

            EncryptFile();
        }
   

        private void UsunAlbum_Click(object sender, EventArgs e)
        {
            Zatwierdz_dodawanie_konta.Visible = false;
            Zatwierdz_usuwanie_konta.Visible = false;
            Zatwierdz_zmiane_hasla.Visible = false;
            Zatwierdz_zmiane_loginu.Visible = false;
            Zatwierdz_dodawanie_wykonawcy.Visible = false;
            Zatwierdz_usuwanie_wykonawcy.Visible = false;
            Zatwierdz_dodawanie_albumu.Visible = false;
            Zatwierdz_usuwanie_albumu.Visible = true;
            Zatwierdz_dodawanie_utworu.Visible = false;
            Zatwierdz_usuwanie_utworu.Visible = false;
            label2.Visible = true;
            label3.Visible = true;
            label2.Text = "Usuwanie albumu";
            label3.Text = "Podaj nazwe albumu";
            textBox1.Visible = true;
            textBox2.Visible = false;
            listBox1.Visible = false;
            comboBox1.Visible = false;
           
        }

        private void Zatwierdz_dodawanie_albumu_Click(object sender, EventArgs e)
        {

            int temp = 0;
            

            listBox1.Items.Clear();
            String query = "Select album_name from [dbo].[Album] where album_name = '" + textBox1.Text + "'";

            SqlCommand cmd1 = new SqlCommand(query, con);
            SqlDataReader dbr1;
            dbr1 = cmd1.ExecuteReader();
            string sname = null;
            if (dbr1.Read())
            {
                
                sname = (string)dbr1["album_name"]; //name is coming from database

                int i = textBox1.Text.Length;
                Console.WriteLine(textBox1.Text.Substring(0, i));
                Console.WriteLine(sname);
                if (textBox1.Text == sname.Substring(0, i))
                {
                    temp = 1;
                }

            }

            if (temp == 0 && comboBox1.SelectedIndex > -1)
            {
                String query1 = "INSERT INTO [dbo].[Album] (album_id,album_name, album_date,performer_id,album_pic_path) VALUES(" + (ilosc_albumow+1) + ",'" + textBox1.Text + "',2000,"+ (comboBox1.SelectedIndex + 1)+",'"+textBox2.Text+"')";
                dbr1.Close();
                cmd1 = new SqlCommand(query1, con);
                cmd1.ExecuteNonQuery();
                label2.Text = "Album zostal dodany";
                ilosc_albumow +=1;
            }
            if (temp == 1)
            {
                label2.Text = "Istnieje album o tej nazwie. Wpisz inna nazwe albumu";
            }
            dbr1.Close();
        }

        private void Zatwierdz_usuwanie_albumu_Click(object sender, EventArgs e)
        {

            comboBox1.Visible = false;
            int temp = 0;
            int temp1 = 0;

            listBox1.Items.Clear();
            String query = "Select album_name from [dbo].[Album] where album_name = '" + textBox1.Text + "'";

            SqlCommand cmd1 = new SqlCommand(query, con);
            SqlDataReader dbr1;
            dbr1 = cmd1.ExecuteReader();
            string sname = null;
            if (dbr1.Read())
            {
                temp1 += 1;
                sname = (string)dbr1["album_name"]; ; //name is coming from database

                int i = textBox1.Text.Length;
                Console.WriteLine(textBox1.Text.Substring(0, i));
                Console.WriteLine(sname);
                if (textBox1.Text == sname.Substring(0, i))
                {
                    temp = 1;
                }

            }

            if (temp == 0)
            {
                label2.Text = "Nie istnieje album o tej nazwie";
            }
            if (temp == 1)
            {
                String query1 = " DELETE FROM [dbo].[Album] where album_name = '" + textBox1.Text + "'";

                dbr1.Close();
                cmd1 = new SqlCommand(query1, con);
                cmd1.ExecuteNonQuery();



                label2.Text = "Album zostal usuniety";
            }
            dbr1.Close();
        }

        private void Zatwierdz_dodawanie_utworu_Click(object sender, EventArgs e)
        {

            int temp = 0;


            listBox1.Items.Clear();
            String query = "Select track_name from [dbo].[Track] where track_name = '" + textBox1.Text + "'";

            SqlCommand cmd1 = new SqlCommand(query, con);
            SqlDataReader dbr1;
            dbr1 = cmd1.ExecuteReader();
            string sname = null;
            if (dbr1.Read())
            {

                sname = (string)dbr1["track_name"]; //name is coming from database

                int i = textBox1.Text.Length;
                Console.WriteLine(textBox1.Text.Substring(0, i));
                Console.WriteLine(sname);
                if (textBox1.Text == sname.Substring(0, i))
                {
                    temp = 1;
                }

            }

            if (temp == 0 && comboBox1.SelectedIndex > -1)
            {
                String query1 = "INSERT INTO [dbo].[Track] (track_id,track_name,album_id,track_path) VALUES(" + (ilosc_utworow + 1) + ",'" + textBox1.Text + "'," + (comboBox1.SelectedIndex+1) + ",'" + textBox2.Text + "')";
                dbr1.Close();
                cmd1 = new SqlCommand(query1, con);
                cmd1.ExecuteNonQuery();
                label2.Text = "Utwor zostal dodany";
                ilosc_utworow += 1;
            }
            if (temp == 1)
            {
                label2.Text = "Istnieje utwor o tej nazwie. Wpisz inna nazwe utworu";
            }
            dbr1.Close();
        }

        private void Zatwierdz_usuwanie_utworu_Click(object sender, EventArgs e)
        {

            comboBox1.Visible = false;
            int temp = 0;
            int temp1 = 0;

            listBox1.Items.Clear();
            String query = "Select track_name from [dbo].[Track] where track_name = '" + textBox1.Text + "'";

            SqlCommand cmd1 = new SqlCommand(query, con);
            SqlDataReader dbr1;
            dbr1 = cmd1.ExecuteReader();
            string sname = null;
            if (dbr1.Read())
            {
                temp1 += 1;
                sname = (string)dbr1["track_name"]; ; //name is coming from database

                int i = textBox1.Text.Length;
                Console.WriteLine(textBox1.Text.Substring(0, i));
                Console.WriteLine(sname);
                if (textBox1.Text == sname.Substring(0, i))
                {
                    temp = 1;
                }

            }

            if (temp == 0)
            {
                label2.Text = "Nie istnieje utwor o tej nazwie";
            }
            if (temp == 1)
            {
                String query1 = " DELETE FROM [dbo].[Track] where track_name = '" + textBox1.Text + "'";

                dbr1.Close();
                cmd1 = new SqlCommand(query1, con);
                cmd1.ExecuteNonQuery();



                label2.Text = "Utwor zostal usuniety";
            }
            dbr1.Close();
        }

        public void EncryptFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            dialog.InitialDirectory = @"C:\";
            dialog.Title = "Wybierz obraz albumu";

            

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string fullPath = dialog.FileName;
                string fileName = dialog.SafeFileName;
                string path = fullPath.Replace(fileName, "");
                textBox2.Text = fullPath;
            }
        }

        public void EncryptFile1()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Music files (*.wav, *.mp3) | *.wav; *.mp3";
            dialog.InitialDirectory = @"C:\";
            dialog.Title = "Wybierz obraz albumu";



            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string fullPath = dialog.FileName;
                string fileName = dialog.SafeFileName;
                string path = fullPath.Replace(fileName, "");
                textBox2.Text = fullPath;
            }
        }

        private void ListaAlbumow_Click(object sender, EventArgs e)
        {
            listBox1.Visible = true;
            label2.Visible = true;
            label3.Visible = false;
            label4.Visible = false;
            label2.Text = "Lista albumow";
            listBox1.Items.Clear();
            String query = "Select Album.album_name from Album";
            SqlCommand cmd1 = new SqlCommand(query, con);
            SqlDataReader dbr1;


            dbr1 = cmd1.ExecuteReader();

            while (dbr1.Read())

            {

                string sname = (string)dbr1["album_name"]; ; //name is coming from database

                listBox1.Items.Add(sname);

            }
            dbr1.Close();
        }

        private void DodajUtwor_Click(object sender, EventArgs e)
        {
            Zatwierdz_dodawanie_konta.Visible = false;
            Zatwierdz_usuwanie_konta.Visible = false;
            Zatwierdz_zmiane_hasla.Visible = false;
            Zatwierdz_zmiane_loginu.Visible = false;
            Zatwierdz_dodawanie_wykonawcy.Visible = false;
            Zatwierdz_usuwanie_wykonawcy.Visible = false;
            Zatwierdz_dodawanie_albumu.Visible = false;
            Zatwierdz_usuwanie_albumu.Visible = false;
            Zatwierdz_dodawanie_utworu.Visible = true;
            Zatwierdz_usuwanie_utworu.Visible = false;
            label2.Visible = true;
            label3.Visible = true;
            label2.Text = "Dodawanie utworu Wybierz album";
            label3.Text = "Podaj nazwe utworu";
            textBox1.Visible = true;
            textBox2.Visible = false;
            listBox1.Visible = false;
            comboBox1.Visible = true;
            comboBox1.Items.Clear();
            String query3 = "Select Album.album_name from Album";

            SqlCommand cmd13 = new SqlCommand(query3, con);


            SqlDataReader dbr13;


            dbr13 = cmd13.ExecuteReader();

            while (dbr13.Read())

            {

                string ssname = (string)dbr13["album_name"]; ; //name is coming from database

                comboBox1.Items.Add(ssname);

            }
            dbr13.Close();

            EncryptFile1();
        }

        private void UsunUtwor_Click(object sender, EventArgs e)
        {
            Zatwierdz_dodawanie_konta.Visible = false;
            Zatwierdz_usuwanie_konta.Visible = false;
            Zatwierdz_zmiane_hasla.Visible = false;
            Zatwierdz_zmiane_loginu.Visible = false;
            Zatwierdz_dodawanie_wykonawcy.Visible = false;
            Zatwierdz_usuwanie_wykonawcy.Visible = false;
            Zatwierdz_dodawanie_albumu.Visible = false;
            Zatwierdz_usuwanie_albumu.Visible = false;
            Zatwierdz_dodawanie_utworu.Visible = false;
            Zatwierdz_usuwanie_utworu.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label2.Text = "Usuwanie utworu";
            label3.Text = "Podaj nazwe utworu";
            textBox1.Visible = true;
            textBox2.Visible = false;
            listBox1.Visible = false;
            comboBox1.Visible = false;
        }

        private void ListaWszytskichUtworow_Click(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            textBox2.Visible = false;
            label2.Visible = true;
            label2.Text = "Lista utworow";
            listBox1.Visible = true;
            comboBox1.Visible = false;
            listBox1.Items.Clear();
            String query = "Select Track.track_name from Track";
            SqlCommand cmd1 = new SqlCommand(query, con);
            SqlDataReader dbr1;


            dbr1 = cmd1.ExecuteReader();

            while (dbr1.Read())

            {

                string sname = (string)dbr1["track_name"]; ; //name is coming from database

                listBox1.Items.Add(sname);

            }
            dbr1.Close();
            
        }

        private void Zatwierdz_dodawanie_konta_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = false;
            int temp=0;
            

            listBox1.Items.Clear();
            String query = "Select user_name from [dbo].[User] where user_name = '" + textBox1.Text + "'";

            SqlCommand cmd1 = new SqlCommand(query, con);
            SqlDataReader dbr1;
            dbr1 = cmd1.ExecuteReader();
            string sname = null;
           
            if (dbr1.Read())
            {
                
                sname = (string)dbr1["user_name"]; //name is coming from database
                
                int i = textBox1.Text.Length;
                Console.WriteLine(textBox1.Text.Substring(0, i));
                Console.WriteLine(sname);
               
                if (textBox1.Text == sname.Substring(0, i))
                {
                    temp = 1;
                }
                
            }

            if (temp==0 && textBox1.Text.Length!=0)
            {
                String query1 = "INSERT INTO [dbo].[User] (user_id,user_name, user_password,role_id) VALUES("+(ilosc_kont+1)+",'" + textBox1.Text + "', '" + textBox2.Text + "',2)";
                dbr1.Close();
                cmd1 = new SqlCommand(query1, con);
                cmd1.ExecuteNonQuery();
                label2.Text = "Konto zostalo dodane";
                ilosc_kont +=1;
            }
            if (temp == 1)
            {
                label2.Text = "Istnieje Konto o tej nazwie. Podaj inna nazwe konta";
            }
            dbr1.Close();
        }

        private void Zatwierdz_usuwanie_konta_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = false;
            int temp = 0;
            int temp1 = 0;

            listBox1.Items.Clear();
            String query = "Select user_name from [dbo].[User] where user_name = '" + textBox1.Text + "'";

            SqlCommand cmd1 = new SqlCommand(query, con);
            SqlDataReader dbr1;
            dbr1 = cmd1.ExecuteReader();
            string sname = null;
            if (dbr1.Read())
            {
                temp1 += 1;
                sname = (string)dbr1["user_name"]; ; //name is coming from database
                
                int i = textBox1.Text.Length;
                Console.WriteLine(textBox1.Text.Substring(0, i));
                Console.WriteLine(sname);
                if (textBox1.Text == sname.Substring(0, i))
                {
                    temp = 1;
                }

            }

            if (temp == 0)
            { 
                label2.Text = "Nie istnieje konto o tej nazwie1";
            }
            if (temp == 1)
            {
                String query1 = " DELETE FROM [dbo].[User] where user_name = '" + textBox1.Text + "'" ;
                dbr1.Close();
                cmd1 = new SqlCommand(query1, con);
                cmd1.ExecuteNonQuery();
                label2.Text = "Konto zostalo usuniete";
            }
            dbr1.Close();
        }
        private void Zatwierdz_zmiane_loginu_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = false;
            int temp = 0;
            int temp1 = 0;

            listBox1.Items.Clear();
            String query = "Select user_name from [dbo].[User] where user_name = '" + textBox1.Text + "'";

            SqlCommand cmd1 = new SqlCommand(query, con);
            SqlDataReader dbr1;
            dbr1 = cmd1.ExecuteReader();
            string sname = null;
            if (dbr1.Read())
            {
                temp1 += 1;
                sname = (string)dbr1["user_name"]; //name is coming from database

                int i = textBox1.Text.Length;
                Console.WriteLine(textBox1.Text.Substring(0, i));
                Console.WriteLine(sname);
                if (textBox1.Text == sname.Substring(0, i))
                {
                    temp = 1;
                }

            }

            if (temp == 0)
            {
                label2.Text = "Nie istnieje konto o tej nazwie1";
            }
            if (temp == 1)
            {
                String query1 = " UPDATE [dbo].[User] SET user_name = ' " + textBox2.Text + "' where user_name = '" + textBox1.Text + "'";
                dbr1.Close();
                cmd1 = new SqlCommand(query1, con);
                cmd1.ExecuteNonQuery();
                label2.Text = "Login konta został zmieniony";
            }
            dbr1.Close();
        }

        private void Zatwierdz_zmiane_hasla_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = false;
            int temp = 0;
            int temp1 = 0;

            listBox1.Items.Clear();
            String query = "Select user_name from [dbo].[User] where user_name = '" + textBox1.Text + "'";

            SqlCommand cmd1 = new SqlCommand(query, con);
            SqlDataReader dbr1;
            dbr1 = cmd1.ExecuteReader();
            string sname = null;
            if (dbr1.Read())
            {
                temp1 += 1;
                sname = (string)dbr1["user_name"]; ; //name is coming from database

                int i = textBox1.Text.Length;
                Console.WriteLine(textBox1.Text.Substring(0, i));
                Console.WriteLine(sname);
                if (textBox1.Text == sname.Substring(0, i))
                {
                    temp = 1;
                }

            }

            if (temp == 0)
            {
                label2.Text = "Nie istnieje konto o tej nazwie1";
            }
            if (temp == 1)
            {
                
                String query1 = " UPDATE [dbo].[User] SET user_password = ' "+ textBox2.Text +"' where user_name = '" + textBox1.Text + "'";
                dbr1.Close();
                cmd1 = new SqlCommand(query1, con);
                cmd1.ExecuteNonQuery();
                label2.Text = "Haslo zostalo zmienione";
            }
            dbr1.Close();
        }

        private void Zatwierdz_usuniecie_wykonawcy_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = false;
            int temp = 0;
            int temp1 = 0;

            listBox1.Items.Clear();
            String query = "Select performer_name from [dbo].[Performer] where performer_name = '" + textBox1.Text + "'";

            SqlCommand cmd1 = new SqlCommand(query, con);
            SqlDataReader dbr1;
            dbr1 = cmd1.ExecuteReader();
            string sname = null;
            if (dbr1.Read())
            {
                temp1 += 1;
                sname = (string)dbr1["performer_name"]; ; //name is coming from database

                int i = textBox1.Text.Length;
                Console.WriteLine(textBox1.Text.Substring(0, i));
                Console.WriteLine(sname);
                if (textBox1.Text == sname.Substring(0, i))
                {
                    temp = 1;
                }

            }

            if (temp == 0)
            {
                label2.Text = "Nie istnieje wykonawca o tej nazwie";
            }
            if (temp == 1)
            {
                String query1 = " DELETE FROM [dbo].[Performer] where performer_name = '" + textBox1.Text + "'";
                
                dbr1.Close();
                cmd1 = new SqlCommand(query1, con);
                cmd1.ExecuteNonQuery();



                label2.Text = "Wykonawca zostal usuniety";
            }
            dbr1.Close();
        }

        private void Zatwierdz_dodawanie_wykonawcy_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = false;
            int temp = 0;
            int temp1 = 0;

            listBox1.Items.Clear();
            String query = "Select performer_name from [dbo].[Performer] where performer_name = '" + textBox1.Text + "'";

            SqlCommand cmd1 = new SqlCommand(query, con);
            SqlDataReader dbr1;
            dbr1 = cmd1.ExecuteReader();
            string sname = null;
            if (dbr1.Read())
            {
                temp1 += 1;
                sname = (string)dbr1["performer_name"]; ; //name is coming from database

                int i = textBox1.Text.Length;
                Console.WriteLine(textBox1.Text.Substring(0, i));
                Console.WriteLine(sname);
                if (textBox1.Text == sname.Substring(0, i))
                {
                    temp = 1;
                }

            }

            if (temp == 0 && textBox1.Text.Length!=0)
            {
                String query1 = "INSERT INTO [dbo].[Performer] (performer_id,performer_name) VALUES(" + (ilosc_wykonawcow+1) + ",'" + textBox1.Text + "')";
                dbr1.Close();
                cmd1 = new SqlCommand(query1, con);
                cmd1.ExecuteNonQuery();
                label2.Text = "Wykonawca "+ textBox1.Text +" dodany";
                ilosc_wykonawcow +=1;
            }
            if (temp == 1)
            {
                label2.Text = "Istnieje taki wykonawca";
            }
            dbr1.Close();
        }
    }
}

