using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaCrucero.ListadoEstadistico
{
    public partial class Form1 : Form
    {
       

        public Form1()
        {
            InitializeComponent();

       
        }
                

        private void button1_Click(object sender, EventArgs e)
        {   
          

            SqlConnection conn = new SqlConnection(@"Data Source=localhost\SQLSERVER2012;Initial Catalog=GD1C2019;Persist Security Info=True;User ID=gdCruceros2019;Password=gd2019");

            SqlCommand cmd = new SqlCommand();
            
            cmd.Connection = conn;

            
            listView1.Items.Clear();

           

            try
            {
                conn.Open();  // abrimos la conexion

                string Exacto;

                if (checkBox1.Checked == true)  // aritmetica de select valor exacto o libre
                {
                    Exacto = " =  '" + textBox1.Text.ToString() + "'";
                 }
                else
                {    
                    Exacto = " like  '%" + textBox1.Text.ToString() + "%'";
                }

                string Filtro2;

                if (checkBox2.Checked == true)  // aritmetica de select valor exacto o libre
                {
                    Filtro2 = " =  '" + textBox2.Text.ToString() + "'";
                }
                else
                {
                    Filtro2 = " like  '%" + textBox2.Text.ToString() + "%'";
                }

                string XOR;

                if (radioButton3.Checked == true) { XOR = " AND "; }
                else { XOR = " OR "; }

                    
              switch(comboBox1.Text)
              {
                  case "( Todas Las Columnas )":
                    cmd.CommandText = "select * from gd_esquema.Maestra where CLI_NOMBRE like '%" + textBox1.Text + "%' "
                      + " OR " + "CLI_APELLIDO like '%" + textBox1.Text + "%' "
                      + " OR " + "CLI_DIRECCION like '%" + textBox1.Text + "%' "
                      + " OR " + "CLI_MAIL like '%" + textBox1.Text + "%' "  
                      ;
                      
                      break;
                 case "Nombre":
                 cmd.CommandText = "select * from gd_esquema.Maestra where CLI_NOMBRE " + Exacto;
                 break;

                 case "Apellido":
                 cmd.CommandText = "select * from gd_esquema.Maestra where CLI_APELLIDO " + Exacto;
                 break;

                 case "Dirección":
                 cmd.CommandText = "select * from gd_esquema.Maestra where CLI_DIRECCION " + Exacto;
                 break;

                 case "Dni":
                 cmd.CommandText = "select * from gd_esquema.Maestra where CLI_DNI " + Exacto;
                 break;

                 case "Teléfono":
                 cmd.CommandText = "select * from gd_esquema.Maestra where CLI_TELEFONO " + Exacto;
                 break;
                 case "Fecha Nac":  
                 cmd.CommandText = "select * from gd_esquema.Maestra where CLI_FECHA_NAC = '" + textBox3.Text + "' ";
                 break;

                 case "Mail":

                 cmd.CommandText = "select * from gd_esquema.Maestra where CLI_MAIL " + Exacto;


                 break;


                 default:
                 cmd.CommandText = "select * from gd_esquema.Maestra where CLI_NOMBRE " + Exacto;
                 break;
            }
                // ***************
              if (groupBox3.Enabled == true)
              {

                  switch (comboBox2.Text)
                  {
                      //case "( Todas Las Columnas )":
                      //    cmd.CommandText = "select * from gd_esquema.Maestra where CLI_NOMBRE like '%" + textBox1.Text + "%' "
                      //      + " OR " + "CLI_APELLIDO like '%" + textBox1.Text + "%' "
                      //      + " OR " + "CLI_DIRECCION like '%" + textBox1.Text + "%' "
                      //      + " OR " + "CLI_MAIL like '%" + textBox1.Text + "%' "
                      //      ;

                      //    break;
                      case "Nombre":
                          cmd.CommandText = cmd.CommandText.ToString() + XOR + "CLI_NOMBRE "  + Filtro2;
                          break;

                      case "Apellido":
                          

                          cmd.CommandText = cmd.CommandText.ToString() + XOR + "CLI_APELLIDO " + Filtro2;
                          break;

                      case "Dirección":
                          cmd.CommandText = cmd.CommandText.ToString() + XOR + "CLI_DIRECCION" + Filtro2;
                          
                          break;

                      case "Dni":
                          cmd.CommandText = cmd.CommandText.ToString() + XOR + "CLI_DNI" + Filtro2;
                    
                          break;

                      case "Teléfono":
                          cmd.CommandText = cmd.CommandText.ToString() + XOR + "CLI_TELEFONO" + Filtro2;
                      break;
                      case "Fecha Nac":
                      cmd.CommandText = cmd.CommandText.ToString() + XOR + "  CLI_FECHA_NAC = '" + textBox4.Text + "' ";
                          //cmd.CommandText = "select * from gd_esquema.Maestra where ;
                          break;

                      case "Mail":
                          cmd.CommandText = cmd.CommandText.ToString() + XOR + " CLI_MAIL " + Filtro2;
                         

                          break;


                      default:
                          cmd.CommandText = "select * from gd_esquema.Maestra where CLI_NOMBRE " + Exacto;
                          break;
                  }

              }


        //***********************************************************************
                this.Text = cmd.CommandText;

                SqlDataReader reader = cmd.ExecuteReader();


                int counter = 1;

                while (reader.Read())
                {

                   // ListViewItem item = new ListViewItem(reader["cli_nombre"].ToString());


                    ListViewItem item = new ListViewItem((counter++).ToString());
                    
                  //  item.SubItems.Add((100).ToString());

                    item.SubItems.Add(reader["cli_nombre"].ToString());

                    item.SubItems.Add(reader["cli_apellido"].ToString());

                    item.SubItems.Add(reader["cli_dni"].ToString());

                    item.SubItems.Add(reader["cli_direccion"].ToString());

                    item.SubItems.Add(reader["cli_telefono"].ToString());

                    item.SubItems.Add(reader["cli_mail"].ToString());

                    item.SubItems.Add(reader["cli_fecha_nac"].ToString());
               


                    listView1.Items.Add(item);
                    
                }

             

            }
            catch (SqlException)
            {
             ///   MessageBox.Show("no se pudo conectar con la base de datos ");
               
                MessageBox.Show("No se pudo conectar con la base de datos", "Alerta ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);

            }

            finally
            {
               // progressBar1.Visible = false;
                conn.Close();   // terminamos la conexion
            }

          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.FullRowSelect = true; // propiedad que permite seleccionar toda la fila.
            
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 1;
        }
           

        private void button3_Click(object sender, EventArgs e)
        {
            
            switch (comboBox1.Text)
            {
                case "Nombre":
                     textBox3.Text= "select * from gd_esquema.Maestra where CLI_NOMBRE like '%"+ textBox1.Text + "%' ";
                    break;
                case "Fecha Nac":

                    Form2 calendario = new Form2();

                    calendario.pasado += new Form2.pasar(ejecutar);

                    calendario.ShowDialog();

                    break;


                case "Dni":
                    textBox3.Text = "Dni";
                    break;

                 default:
                    textBox3.Text = "select * from gd_esquema.Maestra where CLI_NOMBRE = '" + textBox1.Text + "' ";


                    break;

            }
             
        }
        public void ejecutar(string dato)
        {
            textBox3.Text = dato;  // le pasamos el dato mediante el metodo creado
        }

        public void ejecutar2(string dato)
        {
            textBox4.Text = dato;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            listView1.Items.Clear();
            textBox1.Text = "";
            comboBox1.SelectedIndex = 0;
                       

               string Exacto;

                if (checkBox1.Checked == true)
                {
                    Exacto = " =  '" + textBox1.Text.ToString() + "'";
                }else { 
                    Exacto =  " like  '%" + textBox1.Text.ToString() + "%'";
                 }

                this.Text = Exacto;




        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

                int sIndex = comboBox1.SelectedIndex;

                if (comboBox2.SelectedIndex == sIndex) // le prohibimos al programa elegir opciones iguales
                {
                    if ( sIndex  == 0) { comboBox2.SelectedIndex = 1; }else { comboBox2.SelectedIndex = 0; }
                 }

            switch (comboBox1.Text)
            {
                case "Fecha Nac": 
                    textBox3.Text = "1995/01/31";
                    button3.Enabled = true;
                    comboBox2.SelectedIndex = 0;
                    
                break;

                default:
                textBox3.Text = "";
                button3.Enabled = false;
         
            
                  
                break;
            }

          

        
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true) groupBox3.Enabled = false;

            groupBox4.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true) groupBox3.Enabled = true;
            comboBox2.SelectedIndex = 0;
            textBox2.Text = "";
            groupBox4.Visible = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {


             int sIndex = comboBox2.SelectedIndex;

                if (comboBox1.SelectedIndex == sIndex)
                {
                    if ( sIndex  == 0) { comboBox2.SelectedIndex = 1; }else { comboBox2.SelectedIndex = 0; }
                   

                }
            switch (comboBox2.Text)
            {
                case "Fecha Nac":
                    textBox4.Text = "1995/01/31";
                    button4.Enabled = true;

                    break;

                default:
                    textBox4.Text = "";
                    button4.Enabled = false;

                
            

                    break;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

            switch (comboBox2.Text)
            {
                case "Nombre":
                    textBox4.Text = "select * from gd_esquema.Maestra where CLI_NOMBRE like '%" + textBox2.Text + "%' ";
                    break;
                case "Fecha Nac":

                    Form2 calendario = new Form2();

                    calendario.pasado += new Form2.pasar(ejecutar2);

                    calendario.ShowDialog();

                    break;


                case "Dni":
                    textBox4.Text = "Dni";
                    break;

                default:
                    textBox4.Text = "select * from gd_esquema.Maestra where CLI_NOMBRE = '" + textBox2.Text + "' ";


                    break;

            }



        }
    }
}
