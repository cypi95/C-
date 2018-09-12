using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using NAudio.Wave;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_Aplikacja_Odtwarzacz
{
    public partial class User : Form
    {

        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=player_project;Integrated Security=True;");

        public void Temp()
        {

            string query1 = "Select Track.track_name,Album.album_name,Performer.performer_name from Track INNER JOIN Album ON Track.album_id = Album.album_id INNER JOIN Performer ON Album.performer_id = Performer.performer_id where Track.track_id = 4";
            string query2 = "Select performer_name from Performer";

            SqlCommand cmd1 = new SqlCommand(query2, con);


            SqlDataReader dbr1;

            con.Open();
            dbr1 = cmd1.ExecuteReader();

            while (dbr1.Read())

            {

                string sname = (string)dbr1["performer_name"];  //name is coming from database

                comboBox1.Items.Add(sname);

            }
            dbr1.Close();

        }
        public User()
        {
            InitializeComponent();
            Temp();
            
        }

        NAudio.Wave.WaveFileReader wave = null;
        NAudio.Wave.DirectSoundOut output = null;
        NAudio.Wave.BlockAlignReductionStream stream = null;
        NAudio.Wave.WaveStream pcm;

        private void button1_Click(object sender, EventArgs e)
        {
            DisposeWave();


        }
        Bitmap bmp;
        private void PictureSet()
        {
            string query1 = "Select Album.album_pic_path from  Album where Album.album_name = '" + listBox2.SelectedItem.ToString() + "'";
            

            SqlCommand cmd1 = new SqlCommand(query1, con);


            SqlDataReader dbr1;


            dbr1 = cmd1.ExecuteReader();

            while (dbr1.Read())

            {

                string sname = (string)dbr1["album_pic_path"]; ; //name is coming from database
                Console.WriteLine(sname);
                try
                {
                    bmp = new Bitmap(@sname);
                    pictureBox1.Image = bmp;
                }
                catch
                {
                    Console.WriteLine("Blad ladowania obrazka");
                }
                

            }
            dbr1.Close();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            listBox1.Items.Clear();
           
            string query1 = "Select Track.track_name from Track INNER JOIN Album ON Track.album_id = Album.album_id where Album.album_name = '"+ listBox2.SelectedItem.ToString()+"'";
           

            SqlCommand cmd1 = new SqlCommand(query1, con);


            SqlDataReader dbr1;

            
            dbr1 = cmd1.ExecuteReader();

            while (dbr1.Read())

            {

                string sname = (string)dbr1["track_name"]; ; //name is coming from database

                listBox1.Items.Add(sname);

            }
            dbr1.Close();
            PictureSet();
        }
        private void DisposeWave()
        {
            if (output != null)
            {
                if (output.PlaybackState == NAudio.Wave.PlaybackState.Playing) output.Stop();
                output.Dispose();
                output = null;
            }
            if (stream != null)
            {
                stream.Dispose();
                stream = null;
            }
        }

        private void User_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisposeWave();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (output != null)
            {
                if (output.PlaybackState == NAudio.Wave.PlaybackState.Playing) output.Pause();
                else if (output.PlaybackState == NAudio.Wave.PlaybackState.Paused) output.Play();
            }

        }

        void NextTrack(Object sender, EventArgs e)
        {
            

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisposeWave();
            string query1 = "Select Track.track_path from Track where Track_name = '" + listBox1.SelectedItem.ToString() + "'";


            SqlCommand cmd1 = new SqlCommand(query1, con);


            SqlDataReader dbr1;


            dbr1 = cmd1.ExecuteReader();
            string sname=null;
            while (dbr1.Read())

            {

                sname = (string)dbr1["track_path"]; ; // is coming from database

               

            }
            dbr1.Close();
           
            pcm = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream(new NAudio.Wave.Mp3FileReader(sname));
            stream = new NAudio.Wave.BlockAlignReductionStream(pcm);
            output = new NAudio.Wave.DirectSoundOut();
            output.Init(stream);
            output.Play();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            string query1 = "Select Album.album_name from  Album  INNER JOIN Performer ON Album.performer_id = Performer.performer_id where Performer.performer_name ='" + comboBox1.SelectedItem.ToString()+"'";
            string query2 = "Select album_name from Album";

            SqlCommand cmd1 = new SqlCommand(query1, con);


            SqlDataReader dbr1;

      
            dbr1 = cmd1.ExecuteReader();

            while (dbr1.Read())

            {

                string sname = (string)dbr1["album_name"]; ; //name is coming from database

                listBox2.Items.Add(sname);

            }
            dbr1.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == listBox1.SelectedIndex+1) listBox1.SelectedIndex = 0;
            else listBox1.SelectedIndex += 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex==0 || listBox1.SelectedIndex==-1) listBox1.SelectedIndex = (listBox1.Items.Count-1);
            
            else listBox1.SelectedIndex -= 1;
        }
    }
}
