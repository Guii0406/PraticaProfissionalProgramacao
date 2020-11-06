using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lanhouse
{
    public partial class FormIniciar : Form
    {
        Point DragCursor;
        Point DragForm;
        bool Dragging;
        List<Cliente> listaClientes;
        Form1 form1;
        
        public FormIniciar(List<Cliente> listaClientes, Form1 form1)
        {
            InitializeComponent();
            this.listaClientes = listaClientes;
            this.form1 = form1;
            form1.cancelar = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            form1.logado = false;
            foreach (Cliente c in listaClientes)
            {
                if(c.Cpf == textBox3.Text)
                {
                    form1.logado = true;
                    MessageBox.Show("logado");
                    this.Close();
                }
            }
            if(form1.logado == false)
            {
                MessageBox.Show("nenhum usuario com esse cpf foi encontrado");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            form1.cancelar = true;
            this.Close();
        }
        private void button11_Click(object sender, EventArgs e)
        {
            form1.logado = false;
            this.Close();
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            Dragging = false;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (Dragging == true)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(DragCursor));
                this.Location = Point.Add(DragForm, new Size(dif));
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            Dragging = true;
            DragCursor = Cursor.Position;
            DragForm = this.Location;
        }

        
    }
}
