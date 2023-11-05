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
    public partial class ListaAnimes : Form, IFormularioComunicador
    {
        public event Action<string> EnviarDatosEvent;

        public ListaAnimes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EnviarDatosAlPadre("Form1");
        }

        // Método para enviar datos al formulario padre
        private void EnviarDatosAlPadre(string datos)
        {
            EnviarDatosEvent?.Invoke(datos);
        }
    }
}
