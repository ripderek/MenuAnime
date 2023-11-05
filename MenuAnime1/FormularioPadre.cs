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
    public partial class FormularioPadre : Form
    {
        Color PrimaryColor = Color.FromArgb(158, 12, 43);
        Color SecondColor = Color.FromName("DimGray");
        public FormularioPadre()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            if (this.WindowState == FormWindowState.Normal) this.WindowState = FormWindowState.Maximized;
            else this.WindowState = FormWindowState.Normal;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormularioPadre_Load(object sender, EventArgs e)
        {
            //Para que se pueda ver la barra de tareas 
            this.MaximumSize = SystemInformation.PrimaryMonitorMaximizedWindowSize;
            panel2.BackColor = PrimaryColor;


            //por defecto abrir un formulario hijo 
            Form1 form1 = new Form1();
            form1.EnviarDatosEvent += FormularioHijo_EnviarDatosEvent; //esto funciona para que el formulario hijo pueda enviar info al formulario padre
            AbrirFormulario(form1);
        }
        //para abrir los formularios hijos xdxd skere modo diablo 
        private Form formularioActivo = null;
        public void AbrirFormulario(Form nuevoFormulario)
        {
            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }
            formularioActivo = nuevoFormulario;
            nuevoFormulario.TopLevel = false;
            nuevoFormulario.FormBorderStyle = FormBorderStyle.None;
            nuevoFormulario.Dock = DockStyle.Fill;
            panelOPCIONES.Controls.Add(nuevoFormulario);
            panelOPCIONES.Tag = nuevoFormulario;
            nuevoFormulario.BringToFront();
            nuevoFormulario.Show();
        }

        //con esta funcion obtengo los datos enviados por un formulario hijo
        //en este caso lo uso para abrir un formulario con el nombre que se recibe en el parametro
        //para evitar usar case o if anidados
        private void FormularioHijo_EnviarDatosEvent(string datos)
        {
            //Para abrir un formulario enviando el nombre del formulario para no hacer un case when o if concatenados 
            string nombreFormulario = datos; // Reemplaza con el nombre de tu formulario

            // Construye el nombre completo de la clase del formulario
            string nombreClase = "MenuAnime1." + nombreFormulario;

            // Usa reflexión para crear una instancia del formulario
            Type tipoFormulario = Type.GetType(nombreClase);
            if (tipoFormulario != null)
            {
                //en este caso tengo que enviarle la funcion que abre el formulario dentro del panel y tambien adjuntarle los eventos del padre
                Form formulario = (Form)Activator.CreateInstance(tipoFormulario);
                //formulario.EnviarDatosEvent += FormularioHijo_EnviarDatosEvent; //esto funciona para que el formulario hijo pueda enviar info al formulario padre
                
                formulario.Show(); // Muestra el formulario
            }
            else
            {
                MessageBox.Show("No se pudo encontrar el formulario especificado.");
            }
        }
    }
}
