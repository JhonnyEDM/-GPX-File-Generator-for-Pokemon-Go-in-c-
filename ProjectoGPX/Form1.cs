using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ProjectoGPX
{
    public partial class Form1 : Form
    {
        string linea;
        string aquiestartodas;
        List<string> todas = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string Cabecera = "<?xml version = \"1.0\" encoding=\"UTF - 8\"?> <gpx>";
                string Pie = "</gpx>";
                string Latinicio = "<wpt lat=\"";
                string Loninicio = "\"lon=\"";
                string Lonfinal= "\"></wpt>";

                var hola = textBox1.Text;
                string[] corrdenadas = hola.Split('\n');

                foreach (var item in corrdenadas)
                {
                    string[] final = item.Split(',');
                    string longitud = final[1].Trim();
                    todas.Add(linea = Latinicio + final[0] + Loninicio + longitud + Lonfinal);
                }

                foreach (var una in todas)
                {
                    aquiestartodas = aquiestartodas + una;
                }
                var elfinai = Cabecera + aquiestartodas + Pie;

                File.WriteAllText(Application.StartupPath +"\\Coordenadas.gpx", elfinai);
                MessageBox.Show("SE GENERO LAS COORDENADAS CON EXITO");
                textBox1.Clear();
                textBox1.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show("TE JODISTE ARIELITO" , "\n " + ex.Message);
                textBox1.Clear();
                textBox1.Focus();
            }
        }
    }
}
