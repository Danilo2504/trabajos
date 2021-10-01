using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Reproductor_de_Audio
{
    public partial class Form1 : Form
    {
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string command, StringBuilder returnValue, int returnLength, IntPtr winHandle);
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fileName = "audio.mp3";
            string mediaName = "MP3";
            string playCommand;



            playCommand = "Open \"" + fileName + "\" type mpegvideo alias " + mediaName;
            mciSendString(playCommand, null, 0, IntPtr.Zero);

            playCommand = "Play " + mediaName;
            mciSendString(playCommand, null, 0, IntPtr.Zero);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool bandera = true;
            if (bandera)
            {
                string mediaName = "MP3";
                string playCommand;
                bandera = false;
                playCommand = "Stop " + mediaName;
                mciSendString(playCommand, null, 0, IntPtr.Zero);
            }
        }
    }
}
