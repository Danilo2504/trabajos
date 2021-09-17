using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Servcicio_Post_DarkSky
{
    public partial class Form1 : Form
    {
        /* 
        https://docs.microsoft.com/en-us/troubleshoot/iis/make-get-request
        https://www.youtube.com/watch?v=ryz3Q_xsmPI
        */
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sURL;
            WebRequest wrGETURL;
            JObject json;
            Stream objStream;

            sURL = "https://api.darksky.net/forecast/b4497c8a6b18bf75776b7fd997f2b90a/-34.6119666,-58.4030375?lang=es&units=ca";            
            wrGETURL = WebRequest.Create(sURL);
            objStream = wrGETURL.GetResponse().GetResponseStream();
            StreamReader objReader = new StreamReader(objStream);

            string sLine = "";
            string sLinePrev = "";
            int i = 0;

            while (sLine != null)
            {
                i++;
                sLinePrev = sLine;
                sLine = objReader.ReadLine();
                //if (sLine != null)
                //    MessageBox.Show(sLine);                    
                
            }
            //MessageBox.Show(sLinePrev);

            json = JObject.Parse(sLinePrev);

            pictureBox1.Image = Image.FromFile("imgs/" + json["daily"]["data"][0]["icon"].ToString() + ".jpg");
            pictureBox9.Image = Image.FromFile("imgs/" + json["daily"]["data"][1]["icon"].ToString() + ".jpg");
            pictureBox3.Image = Image.FromFile("imgs/" + json["daily"]["data"][2]["icon"].ToString() + ".jpg");
            pictureBox4.Image = Image.FromFile("imgs/" + json["daily"]["data"][3]["icon"].ToString() + ".jpg");
            pictureBox5.Image = Image.FromFile("imgs/" + json["daily"]["data"][4]["icon"].ToString() + ".jpg");
            pictureBox6.Image = Image.FromFile("imgs/" + json["daily"]["data"][5]["icon"].ToString() + ".jpg");
            pictureBox7.Image = Image.FromFile("imgs/" + json["daily"]["data"][6]["icon"].ToString() + ".jpg");
            pictureBox8.Image = Image.FromFile("imgs/" + json["daily"]["data"][7]["icon"].ToString() + ".jpg");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
