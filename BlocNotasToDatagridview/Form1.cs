using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Moises_Masis_Merge_Sort
{
    public partial class Form1 : Form
    {
        //Instancia de la clase Leer
        Leer l = new Leer();

        //Alamcena la ruta del archivo .txt
        public string ARCHIVO = "";

 
        int cantidad;
        int archivo;
        int i;
        int[] Datos;
        public Form1()
        {
            InitializeComponent();
            groupBoxValores.Enabled = false;
            groupBoxDatos.Enabled = false;
        }

        //Abre el openFileDialog y captura la ruta del bloc de notas'
        public void cargarArchivo()
        {
            try
            {
                this.openFileDialog1.ShowDialog();

                if (!string.IsNullOrEmpty(this.openFileDialog1.FileName))
                {
                    ARCHIVO = this.openFileDialog1.FileName;
                    l.lecturaArchivo(dataGridView1, ',', ARCHIVO);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cargarArchivo();
        }

        public void PedirCantidad()
        {
            try
            {
                i = 0;
                cantidad = Convert.ToInt32(txtCantidad.Text);

                if (cantidad <= 0 || txtCantidad.Text  == string.Empty)
                    MessageBox.Show("Por favor reitifique su cantidad ya que esta debe Ser mayor a 0");
                else
                {
                    MessageBox.Show($"El archivo {archivo} Tiene un Total de Elementos : {cantidad}");
                    Datos = new int[cantidad];
                    txtCantidad.Clear();
                    groupBoxDatos.Enabled = false;
                    groupBoxValores.Enabled = true;
                    txtDato.Focus();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"Hubo un problema al ingresar Daots," +
                        $"Por favor revise el siguente Problema: \n {error}", "Error",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            l.CrearArchivo();
            groupBoxDatos.Enabled = true;
            txtCantidad.Focus();
        }

        private void btnAsignarValor_Click(object sender, EventArgs e)
        {
            int numeros;

               try
                {
                    numeros = Convert.ToInt32(txtDato.Text);

                    if (numeros <= 0 || txtDato.Text == string.Empty)
                    {
                        MessageBox.Show("El valor que intenta ingresar no es Admitido\n" +
                            "Revise si esta completando el campo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Datos[i] = numeros;
                        MessageBox.Show($"Numero Agregado : {numeros}");
                        txtDato.Focus();    
                        txtDato.Clear();
                        i++;
                    }

                    if (i == cantidad)
                        l.MandarAlData(dataGridView1,Datos);

                }
                catch (Exception error)
                {
                    MessageBox.Show($"Hubo un problema al ingresar Daots," +
                        $"Por favor revise el siguente Problema: \n {error}", "Error",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            
        }
        private void btnCantidad_Click(object sender, EventArgs e)
        {
            PedirCantidad();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            cantidad = 0;
            btnCrear.Focus();
        }
    }
}
