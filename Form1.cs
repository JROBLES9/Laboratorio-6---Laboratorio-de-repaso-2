using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio_6___Laboratorio_de_repaso_2
{
    public partial class Form1 : Form
    {
        List<Cliente> Clientes = new List<Cliente>();
        public List<Carro> Carros = new List<Carro>();
        List<Alquiler> Alquileres = new List<Alquiler>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string fileName = "clientes.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Cliente b = new Cliente();
                b.Nit = reader.ReadLine();
                b.Nombre = reader.ReadLine();
                b.Direccion = reader.ReadLine();

                Clientes.Add(b);
            }
            reader.Close();

            dataGridView1.DataSource = null;
            dataGridView1.Show();

            dataGridView1.DataSource = Clientes;
            dataGridView1.Show();

            fileName = "carros.txt";
            stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Carro carro = new Carro();
                carro.Placa = reader.ReadLine();
                carro.Marca = reader.ReadLine();
                carro.Modelo = reader.ReadLine();
                carro.Color = reader.ReadLine();
                carro.PrecioXKilometro = Convert.ToInt32(reader.ReadLine());

                Carros.Add(carro);
            }
            reader.Close();

            ActualizarDGVCarros();

            fileName = "alquiler.txt";
            stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                // Nit, placa, fecha alquiler, fecha devolución, kilómetros recorridos.
                Alquiler alquiler = new Alquiler();
                alquiler.Nit = reader.ReadLine();
                alquiler.placa = reader.ReadLine();
                alquiler.FechaAlquiler = Convert.ToDateTime(reader.ReadLine());
                alquiler.FechaDevolución = Convert.ToDateTime(reader.ReadLine());
                alquiler.KilometrosRecorridos = Convert.ToInt32(reader.ReadLine());

                Alquileres.Add(alquiler);
            }
            reader.Close();

            dataGridView3.DataSource = null;
            dataGridView3.Show();

            dataGridView3.DataSource = Alquileres;
            dataGridView3.Show();
        }

        private void buttonNuevoCarro_Click(object sender, EventArgs e)
        {
            AgregarCarro agregarCarro = new AgregarCarro();
            agregarCarro.Visible = true;
        }

        private void buttonNuevaRenta_Click(object sender, EventArgs e)
        {
            AgregarAlquiler agregarAlquiler = new AgregarAlquiler();
            agregarAlquiler.Visible = true;

        }

        public void ActualizarDGVCarros()
        {
            dataGridView2.DataSource = null;
            dataGridView2.Show();

            dataGridView2.DataSource = Carros;
            dataGridView2.Show();
        }
    }
}
