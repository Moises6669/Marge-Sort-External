using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Moises_Masis_Merge_Sort
{
    class Leer
    {
        TextWriter Nuevoarchivo;
        int archivo;

        //Leer el archivo y llama al metodo agregarFilaDatagridview para que por cada linea del bloc agregue una linea en el datagridview'
        public void lecturaArchivo(DataGridView tabla, char caracter, string ruta)
        {
            StreamReader objReader = new StreamReader(ruta);
            tabla.Rows.Clear();
            tabla.AllowUserToAddRows = false;

            //leyendo el Archivo de Texto
            string text = objReader.ReadToEnd();
            string[] lines = text.Split('\r');

            //Conviritiendo a int el arreglo sacado del archivo de texto
            int[] NumerosTexto = Array.ConvertAll(lines, s => int.Parse(s));
            int len = NumerosTexto.Length;

            //ordenando los numeros del arreglo
            MetodoSort(NumerosTexto, 0, len - 1);

            foreach (var item in NumerosTexto)
            {
                MessageBox.Show($"{item}");
                tabla.Rows.Add(item,null);
            }


            objReader.Close();
        }
        public void CrearArchivo()
        {
            MessageBox.Show($"El archivo F{archivo} se ha creado correctamente");
            Nuevoarchivo = new StreamWriter($"archivo{archivo}.txt");
        }

        public void MandarAlData(DataGridView tabla, int[] array)
        {
            int len = array.Length;
            MetodoSort(array, 0, len - 1);

            foreach (var item in array)
            {
                tabla.Rows.Add(item, null);
                Nuevoarchivo.WriteLine(item);
            }
            Nuevoarchivo.Close();
        }

        //Meotodo de Ordenacion Externo Mezcla Equilibrada, Mezcla Natural o tambien conocido
        //como MergeSort
        public void MetodoMerge(int[] arreglo, int izquierda, int mitad, int derecha)
        {
            int[] temp = new int[25];
            int i, izquierda_final, num_elementos, temporal_pos;

            izquierda_final = (mitad - 1);
            temporal_pos = izquierda;
            num_elementos = (derecha - izquierda + 1);

            while ((izquierda <= izquierda_final) && (mitad <= derecha))
            {
                if (arreglo[izquierda] <= arreglo[mitad])
                    temp[temporal_pos++] = arreglo[izquierda++];
                else
                    temp[temporal_pos++] = arreglo[mitad++];
            }
            while (izquierda <= izquierda_final)
                temp[temporal_pos++] = arreglo[izquierda++];
            while (mitad <= derecha)
                temp[temporal_pos++] = arreglo[mitad++];
            for (i = 0; i < num_elementos; i++)
            {
                arreglo[derecha] = temp[derecha];
                derecha--;
            }
        }
        public void MetodoSort(int[] numeros, int izquierda, int derecha)
        {
            int mitad;
            if (derecha > izquierda)
            {
                mitad = (derecha + izquierda) / 2;
                MetodoSort(numeros, izquierda, mitad);
                MetodoSort(numeros, (mitad + 1), derecha);
                MetodoMerge(numeros, izquierda, (mitad + 1), derecha);
            }
        }

    }
}
