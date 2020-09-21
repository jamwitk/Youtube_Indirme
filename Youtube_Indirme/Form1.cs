using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoLibrary;
using MediaToolkit;
using System.IO;
using MediaToolkit.Model;

namespace Youtube_Indirme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            YouTube youtube = YouTube.Default;
            Video vid = youtube.GetVideo(textBox1.Text);
            label2.Text = vid.FullName;
            File.WriteAllBytes(Application.StartupPath + @"\mp3\" + vid.FullName, vid.GetBytes());
            var inputfile = new MediaFile { Filename = $"{Application.StartupPath + @"\mp3\" + vid.FullName}" };
            var outputfile = new MediaFile { Filename = $"{Application.StartupPath + @"\mp3\" + vid.FullName}.mp3"};
            if (true)
            {
                using (var engine = new Engine())
                {
                    engine.GetMetadata(inputfile);
                    engine.Convert(inputfile, outputfile);
                }
                MessageBox.Show("İndirme tamamlandı ! ","Youtube İndirme ");

                label2.Text = "";
                textBox1.Text = "";

                if (chMP3.Checked==true)
                {//delete mp4 for mp3
                    File.Delete(Application.StartupPath + @"\mp3\" + vid.FullName);
                }
                else if(chMP4.Checked==true)
                {//delete mp3 for mp4
                    File.Delete(Application.StartupPath + @"\mp3\" + vid.FullName+".mp3");
                }
                
                //mp3 u silip sadece mp4 u geride bırakıyor
                //izlediğiniz için tşk :D
            }
            else
                MessageBox.Show("İndirme tamamlanamadı !","Youtube İndirme ");

            // Hem video hem mp3 indiriyor sadece mp3 indirmesini istersek mp4 dosyayı silicez 
            // veya tam tersi mp3 u silip video dosyasına erişebiliriz 

        }
    }
}
