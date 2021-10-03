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
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
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

            pictureBox1.Image = Image.FromFile("imgs/" + json["currently"]["icon"].ToString() + ".png");
            pictureBox3.Image = Image.FromFile("imgs/" + json["daily"]["data"][0]["icon"].ToString() + ".png");
            pictureBox4.Image = Image.FromFile("imgs/" + json["daily"]["data"][1]["icon"].ToString() + ".png");
            pictureBox5.Image = Image.FromFile("imgs/" + json["daily"]["data"][2]["icon"].ToString() + ".png");
            pictureBox6.Image = Image.FromFile("imgs/" + json["daily"]["data"][3]["icon"].ToString() + ".png");
            pictureBox7.Image = Image.FromFile("imgs/" + json["daily"]["data"][4]["icon"].ToString() + ".png");
            pictureBox8.Image = Image.FromFile("imgs/" + json["daily"]["data"][5]["icon"].ToString() + ".png");
            pictureBox9.Image = Image.FromFile("imgs/" + json["daily"]["data"][6]["icon"].ToString() + ".png");
            
            DateTime a = UnixTimeStampToDateTime(Convert.ToDouble(json["daily"]["data"][1]["time"]));
            label4.Text = a.DayOfWeek.ToString();

            DateTime b = UnixTimeStampToDateTime(Convert.ToDouble(json["daily"]["data"][2]["time"]));
            label5.Text = b.DayOfWeek.ToString();

            DateTime c = UnixTimeStampToDateTime(Convert.ToDouble(json["daily"]["data"][3]["time"]));
            label6.Text = c.DayOfWeek.ToString();

            DateTime f = UnixTimeStampToDateTime(Convert.ToDouble(json["daily"]["data"][4]["time"]));
            label7.Text = f.DayOfWeek.ToString();

            DateTime g = UnixTimeStampToDateTime(Convert.ToDouble(json["daily"]["data"][5]["time"]));
            label8.Text = g.DayOfWeek.ToString();

            DateTime h = UnixTimeStampToDateTime(Convert.ToDouble(json["daily"]["data"][6]["time"]));
            label9.Text = h.DayOfWeek.ToString();

            DateTime j = UnixTimeStampToDateTime(Convert.ToDouble(json["daily"]["data"][7]["time"]));
            label10.Text = j.DayOfWeek.ToString();

            DateTime k = UnixTimeStampToDateTime(Convert.ToDouble(json["daily"]["data"][7]["time"]));
            label11.Text = k.ToLongDateString();

            label2.Text = "C°"+json["currently"]["temperature"].ToString();

            timer1.Start();
            label12.Text = DateTime.Now.ToString("HH:mm:ss");

            label1.Text = "Buenos Aires, CABA";

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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label12.Text = DateTime.Now.ToString("HH:mm:ss");
            timer1.Start();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
