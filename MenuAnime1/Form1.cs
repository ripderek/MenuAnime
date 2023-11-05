using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuAnime1
{
    public partial class Form1 : Form, IFormularioComunicador
    {
        public event Action<string> EnviarDatosEvent;

        // Método para enviar datos al formulario padre
        private void EnviarDatosAlPadre(string datos)
        {
            EnviarDatosEvent?.Invoke(datos);
        }

        //variable para el color primario 
        Color PrimaryColor = Color.FromArgb(158, 12, 43);
        Color SecondColor = Color.FromName("DimGray");
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            if (this.WindowState == FormWindowState.Normal) this.WindowState = FormWindowState.Maximized;
            else this.WindowState = FormWindowState.Normal;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //panel transparente 
            panel3.BackColor = Color.FromArgb(230, Color.White);

            //colocarle el color primario a todos los objetos que lo usen
            label1.ForeColor = PrimaryColor;
            label2.ForeColor = SecondColor;
            label10.ForeColor = PrimaryColor;
            //Boton con Gradiente 
            uI_GradientPanel1.UIBottomRight = PrimaryColor;
            uI_GradientPanel1.UITopRight = Color.FromArgb(234, 17, 63);
            uI_GradientPanel1.UITopLeft = PrimaryColor;
        }
        private void label3_MouseEnter(object sender, EventArgs e)
        {
            cambiar_color(sender);
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            cambiar_color(sender, false);
            
        }
        private void cambiar_color(object sender, bool indicador = true) 
        {
            if (sender is Label)
            {
               // ((Label)sender).ForeColor = nuevoColor;
                if (indicador)
                    ((Label)sender).ForeColor = PrimaryColor;
                else
                    ((Label)sender).ForeColor = Color.FromName("DimGray");
            }
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            cambiar_color(sender);
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            cambiar_color(sender);
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            cambiar_color(sender);
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            cambiar_color(sender, false);
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            cambiar_color(sender, false);
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            cambiar_color(sender, false);
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void uI_GradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Define el radio de las esquinas redondeadas
            int radio = 15;

            // Crea una región con esquinas redondeadas
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.StartFigure();
            path.AddArc(0, 0, radio * 2, radio * 2, 180, 90);
            path.AddLine(radio, 0, uI_GradientPanel1.Width - radio, 0);
            path.AddArc(uI_GradientPanel1.Width - (radio * 2), 0, radio * 2, radio * 2, 270, 90);
            path.AddLine(uI_GradientPanel1.Width, radio, uI_GradientPanel1.Width, uI_GradientPanel1.Height - radio);
            path.AddArc(uI_GradientPanel1.Width - (radio * 2), uI_GradientPanel1.Height - (radio * 2), radio * 2, radio * 2, 0, 90);
            path.AddLine(uI_GradientPanel1.Width - radio, uI_GradientPanel1.Height, radio, uI_GradientPanel1.Height);
            path.AddArc(0, uI_GradientPanel1.Height - (radio * 2), radio * 2, radio * 2, 90, 90);
            path.CloseFigure();

            // Aplica la región al panel
            uI_GradientPanel1.Region = new Region(path);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            EnviarDatosAlPadre("Ventana About");
        }
        private void label4_Click(object sender, EventArgs e)
        {
            EnviarDatosAlPadre("ListaAnimes");
        }
    }
}
