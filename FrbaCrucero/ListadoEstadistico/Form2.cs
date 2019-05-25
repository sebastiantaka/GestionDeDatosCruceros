using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.ListadoEstadistico
{
    public partial class Form2 : Form
    {

        public delegate void pasar(string dato); //lo creamos para pasar datos entre formularios
        public event pasar pasado;

        public Form2()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

            textBox1.Text = monthCalendar1.SelectionEnd.Date.ToShortDateString();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            monthCalendar1.SelectionStart = new DateTime(1995, 1, 31);

            textBox1.Text = monthCalendar1.SelectionEnd.Date.ToShortDateString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            textBox1.Text = monthCalendar1.SelectionEnd.Date.ToShortDateString();

            pasado(textBox1.Text);  //le pasamos el parametro al form padre

            

            this.Close();

            



        }
    }
}
