using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practicas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Cliente nuevoCliente;
        Cliente[] listaClientes = new Cliente[5];
        int indiceCliente;
        int cantClientes;
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            Fcliente nuevoForm = new Fcliente();

            if (nuevoForm.ShowDialog() == DialogResult.OK)
            {
                int nro = Convert.ToInt32(nuevoForm.tBnumeroCliente.Text);
                double costoB = Convert.ToDouble(nuevoForm.tBcostoBase.Text);
                nuevoCliente = new Cliente(nro, costoB);

                //_-----------------------------
                listaClientes[cantClientes] = nuevoCliente;
                cantClientes++;
                indiceCliente = BusquedaBinaria(nro);
            }
            
        }

        private void btnServicio_Click(object sender, EventArgs e)
        {
            Fservicio nuevoServicio = new Fservicio();

            if(nuevoServicio.ShowDialog()== DialogResult.OK)
            {
                if (indiceCliente > 0)
                {
                    int nroCliente = Convert.ToInt32(nuevoServicio.tBnumC.Text);
                    int horasTrabajadas = Convert.ToInt32(nuevoServicio.tBhorasT.Text);
                    int empleadosExtras = Convert.ToInt32(nuevoServicio.tBempleadosE.Text);

                    nuevoCliente.AgregarServicio(horasTrabajadas, empleadosExtras);
                }


            }
        }

        public int BusquedaBinaria(int nro)
        {
            int izq = 0;
            int der = listaClientes.Length-1;
            int med;
            int i = 0;

            while(izq<der && i < der)
            {
                med = (izq + der) / 2;

                if (listaClientes[i].NroCliente == nro)
                {
                    return med;
                }
                else if (listaClientes[med].NroCliente < nro)
                {
                     izq = med + 1;
                }
                else
                {
                    der = med - 1;
                }
            }
            return -1; //si no lo encuentra
        }

        private void btnResumen_Click(object sender, EventArgs e)
        {
            Fresumen nuevoResumen = new Fresumen();

            nuevoResumen.lBresumen.Items.Clear();
            nuevoResumen.lBresumen.Items.Add("Numero: " + nuevoCliente.NroCliente);
            nuevoResumen.lBresumen.Items.Add("Promedio Horas:  " + nuevoCliente.PromedioHorasTrabajadas());
            nuevoResumen.lBresumen.Items.Add("Total a pagar: " + nuevoCliente.CostoTotal);
            nuevoResumen.ShowDialog();
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("nro cliente: " + nuevoCliente.NroCliente + "\nTiempo: " + nuevoCliente.HorasTotalesTrabajadas + "\nCosto: " + nuevoCliente.CostoTotal);
        }
    }

}
