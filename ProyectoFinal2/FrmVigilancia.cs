using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.Util;

namespace ProyectoFinal2
{
    public partial class FrmVigilancia : Form
    {
        private Mat Frame;
        private VideoCapture Camara;
        public FrmVigilancia()
        {
            InitializeComponent();
            timerFechaHora.Interval = 1000; // Actualiza cada segundo
            timerFechaHora.Tick += timerFechaHora_Tick_1;
            timerFechaHora.Start();
        }

        private void tick(object sender, EventArgs e)
        {
            Frame = new Mat();
            Camara = new VideoCapture();
            timer1.Interval = 60;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btnEncender_Click(object sender, EventArgs e)
        {
            Camara.Start();
            if (!timer1.Enabled) timer1.Enabled = true;

        }

        private void btnApagar_Click_1(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Enabled = false;
            Camara.Stop();
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            pictureBox4.Image = null;
            pictureBox5.Image = null;
            pictureBox6.Image = null;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Camara.IsOpened)
            {
                Camara.Read(Frame);
                pictureBox1.Image = Frame.ToBitmap();
                pictureBox2.Image = Frame.ToBitmap();
                pictureBox3.Image = Frame.ToBitmap();
                pictureBox4.Image = Frame.ToBitmap();
                pictureBox5.Image = Frame.ToBitmap();
                pictureBox6.Image = Frame.ToBitmap();

            }
        }


        private void timerFechaHora_Tick_1(object sender, EventArgs e)
        {
            // Actualiza la etiqueta con la fecha y hora actual
            lblFechaHora.Text = DateTime.Now.ToString();
        }
    }
}