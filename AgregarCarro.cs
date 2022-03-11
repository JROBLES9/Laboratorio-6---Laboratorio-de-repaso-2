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

namespace Laboratorio_6___Laboratorio_de_repaso_2
{
    public partial class AgregarCarro : Form
    {
        Form1 f = new Form1();
        public AgregarCarro()
        {
            InitializeComponent();
        }//Placa, marca, modelo, color, precio por kilómetro.

        private void buttonGuardarCarro_Click(object sender, EventArgs e)
        {
            Carro carro = new Carro();
            carro.Placa = textBoxPlaca.Text;
            carro.Marca = textBoxMarca.Text;
            carro.Modelo = textBoxModelo.Text;
            carro.Color = textBoxColor.Text;
            carro.PrecioXKilometro = Convert.ToInt32(textBoxPrecioXKilometro.Text);

            f.Carros.Add(carro);

            string fileName = "carros.txt";
            FileStream stream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            writer.WriteLine("\n" + carro.Placa);
            writer.WriteLine(carro.Marca);
            writer.WriteLine(carro.Modelo);
            writer.WriteLine(carro.Color);
            writer.WriteLine(carro.PrecioXKilometro);
            
            writer.Close();

            f.ActualizarDGVCarros();
        }
    }
}
